using System.Security.Cryptography;

public static class RoomCodeGenerator
{
    private const string Characters = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

    public static string GenerateCode(int length = 6)
    {
        char[] result = new char[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = Characters[
                RandomNumberGenerator.GetInt32(Characters.Length)
            ];
        }

        return new string(result);
    }
}
