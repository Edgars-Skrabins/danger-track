using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class RuleScriptableObjectGenerator
{
    [MenuItem("Tools/Generate Rule Scriptable Objects")]
    public static void GenerateRuleScriptableObjects()
    {
        string outputFolder = "Assets/GameRules/Rules";

        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        var ruleTypes = GetRuleTypesFromScripts();
        
        foreach (var ruleType in ruleTypes)
        {
            CreateScriptableObject(ruleType, outputFolder);
        }

        AssetDatabase.Refresh();
        Debug.Log($"Generated {ruleTypes.Count} rule scriptable objects in {outputFolder}");
    }

    private static List<Type> GetRuleTypesFromScripts()
    {
        var ruleTypes = new List<Type>();
        var assembly = AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "Assembly-CSharp");

        foreach (var type in assembly.GetTypes())
        {
            if (type.IsAbstract) continue;
            if (type.Name.EndsWith("Base")) continue;

            if (typeof(ICardPickupRule).IsAssignableFrom(type) || typeof(ICardTrainPickupRule).IsAssignableFrom(type))
            {
                ruleTypes.Add(type);
            }
        }

        return ruleTypes;
    }

    private static void CreateScriptableObject(Type ruleType, string outputFolder)
    {
        string assetPath = Path.Combine(outputFolder, $"{ruleType.Name}.asset");

        if (File.Exists(assetPath))
        {
            return;
        }

        try
        {
            var instance = ScriptableObject.CreateInstance(ruleType);
            
            if (instance == null)
            {
                Debug.LogError($"Failed to create instance of {ruleType.Name}");
                return;
            }

            AssetDatabase.CreateAsset(instance, assetPath);
            Debug.Log($"Created {assetPath}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error creating {ruleType.Name}: {ex.Message}");
        }
    }
}
