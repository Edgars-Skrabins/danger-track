using UnityEngine;

public class MenuNavigationUI : MonoBehaviour
{
    [SerializeField] private MenuUI m_startingMenu;
    private MenuUI m_activeMenu;

    private void Start()
    {
        m_activeMenu = m_startingMenu;
        m_startingMenu.Show();
    }

    public void NavigateToMenu(MenuUI _menu)
    {
        m_activeMenu.Hide();
        _menu.Show();
        m_activeMenu = _menu;
    }
}
