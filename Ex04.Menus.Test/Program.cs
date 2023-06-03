using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Test
{
    class Program
    {
        public static void Main()
        {
            DelegatesMenu delegatesMenu = new DelegatesMenu();
            InterfaceMainMenu interfacesMenu = new InterfaceMainMenu();

            delegatesMenu.Show();
            interfacesMenu.Start();
        }
    }
}
