using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;


namespace Ex04.Menus.Test
{
    internal class InterfaceMainMenu
    {
        private MainMenu m_MainMenu;

        public InterfaceMainMenu()
        {
            m_MainMenu = new MainMenu("Interfaces Main Menu");
            exampleInitialize();
        }

        private void exampleInitialize()
        {
            MenuItem mi1 = new MenuItem("Version and Spaces", m_MainMenu);
            MenuItem mi2 = new MenuItem("Show Date/Time", m_MainMenu);

            Function fm11 = new Function("Count Spaces", new InvokedMethods().CountSpaces, m_MainMenu);
            Function fm12 = new Function("Show Version", new InvokedMethods().ShowVersion, m_MainMenu);
            mi1.AddItem(fm11);
            mi1.AddItem(fm12);

            Function fm21 = new Function("Show Time", new InvokedMethods().ShowTime, m_MainMenu);
            Function fm22 = new Function("Show Date", new InvokedMethods().ShowDate, m_MainMenu);
            mi2.AddItem(fm21);
            mi2.AddItem(fm22);

            m_MainMenu.AddMenuItem(mi1);
            m_MainMenu.AddMenuItem(mi2);
        }

        public void Start()
        {
            m_MainMenu.Show();
        }
    }
}