using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;


namespace Ex04.Menus.Test
{
    internal class InterfacesMenu
    {
        private MainMenu m_MainMenu;

        public InterfacesMenu()
        {
            m_MainMenu = new MainMenu("Interfaces Main Menu");
            initializeExample();
        }

        private void initializeExample()
        {
            MenuItem menuItem1 = new MenuItem("Version and Spaces", m_MainMenu);
            MenuItem menuItem2 = new MenuItem("Show Date/Time", m_MainMenu);

            Function functionMenu11 = new Function("Count Spaces", new InvokedMethods().CountSpaces, m_MainMenu);
            Function functionMenu12 = new Function("Show Version", new InvokedMethods().ShowVersion, m_MainMenu);
            menuItem1.AddItem(functionMenu11);
            menuItem1.AddItem(functionMenu12);

            Function functionMenu21= new Function("Show Time", new InvokedMethods().ShowTime, m_MainMenu);
            Function functionMenu22 = new Function("Show Date", new InvokedMethods().ShowDate, m_MainMenu);
            menuItem2.AddItem(functionMenu21);
            menuItem2.AddItem(functionMenu22);

            m_MainMenu.AddItem(menuItem1);
            m_MainMenu.AddItem(menuItem2);
        }

        public void Show()
        {
            m_MainMenu.Show();
        }
    }
}