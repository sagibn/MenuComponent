using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    class DelegatesMenu
    {
        MainMenu m_MainMenu;

        public DelegatesMenu()
        {
            m_MainMenu = new MainMenu("Delegates Main Menu");
            addSubMenusAndMethods();
        }

        public void Show()
        {
            m_MainMenu.ShowItem();
        }

        private void addSubMenusAndMethods()
        {
            MenuItem subMenuItem1 = new MenuItem("Show Date/Time");

            subMenuItem1.AddItem(new MenuItem("Show Date", new InvokedMethods().ShowDate));
            subMenuItem1.AddItem(new MenuItem("Show Time", new InvokedMethods().ShowTime));

            MenuItem subMenuItem2 = new MenuItem("Version and Spaces");
            subMenuItem2.AddItem(new MenuItem("Show Version", new InvokedMethods().ShowVersion));
            subMenuItem2.AddItem(new MenuItem("Count Spaces", new InvokedMethods().CountSpaces));

            m_MainMenu.AddItem(subMenuItem1);
            m_MainMenu.AddItem(subMenuItem2);
        }
    }
}
