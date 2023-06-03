using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : IChoiceListener
    {
        private readonly List<MenuItem> r_MenuItemsList = new List<MenuItem>();
        private string m_MainMenuName;

        public MainMenu(string i_MainMenuName)
        {
            m_MainMenuName = i_MainMenuName;
        }

        public void AddMenuItem(MenuItem i_Item)
        {
            r_MenuItemsList.Add(i_Item);
        }

        public void OnSelection(MenuItem i_ItemSelected)
        {
            i_ItemSelected.Show();
        }

        public void Show()
        {
            bool exit = false;
            int counter, choice;

            do
            {
                Console.Clear();
                counter = 1;
                Console.WriteLine(string.Format("**{0}**", m_MainMenuName));
                Console.WriteLine("----------------------");
                foreach(MenuItem item in r_MenuItemsList)
                {
                    Console.WriteLine(string.Format("{0} -> {1}", counter, item.ItemName));
                    counter++;
                }

                Console.WriteLine("0 -> Exit");
                Console.WriteLine("----------------------");
                Console.WriteLine(string.Format("Enter your request: ({0} to {1} or press '0' to Exit).", 1, r_MenuItemsList.Count));
                choice = askInputFromUser();
                if(choice == 0)
                {
                    exit = true;
                }

                else
                {
                    choice -= 1;
                    r_MenuItemsList[choice].OnSelected();
                }
            }
            while(!exit);
        }

        private int askInputFromUser()
        {
            bool validInput = false;
            string inputStr;
            int choiceInt;

            do
            {
                inputStr = Console.ReadLine();
                if(int.TryParse(inputStr, out choiceInt))
                {
                    if(choiceInt >= 0 & choiceInt <= r_MenuItemsList.Count)
                    {
                        validInput = true;
                    }

                    else
                    {
                        Console.WriteLine("Wrong choice, Try Again!");
                    }
                }

                else
                {
                    Console.WriteLine("Input Incorrect, Try Again!");
                }
            }
            while(!validInput);

            return choiceInt;
        }
    }
}