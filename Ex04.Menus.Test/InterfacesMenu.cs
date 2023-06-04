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
            BuildMainMenuInterfaces();
        }
        public static MainMenu BuildMainMenuInterfaces()
        {
            MainMenu myMenu = new MainMenu("Interface Main Menu");
            MenuItem VersionAndSpaces = new MenuItem("Version and Spaces");
            MenuItem DateTime = new MenuItem("Show Date/Time");
            MenuItem ShowVersion = new MenuItem("Show Version", new ShowVersionButton());
            MenuItem CountUppercase = new MenuItem("Count Spaces", new CountSpaces());
            VersionAndSpaces.AddMenuItem(ShowVersion);
            VersionAndSpaces.AddMenuItem(CountUppercase);
            MenuItem ShowDate = new MenuItem("Show Date", new ShowDateButton());
            MenuItem ShowTime = new MenuItem("Show Time", new ShowTimeButton());
            DateTime.AddMenuItem(ShowDate);
            DateTime.AddMenuItem(ShowTime);
            myMenu.AddMenuItem(VersionAndSpaces);
            myMenu.AddMenuItem(DateTime);
            return myMenu;
        }
    }
}