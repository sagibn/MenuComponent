using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        protected readonly List<MenuItem> r_ItemsList = new List<MenuItem>();
        protected string m_ItemName;
        protected MainMenu m_MainMenu;
        protected readonly IButtonFunction m_ButtonFunctionalities;

        public MenuItem(string i_ItemName)
        {
            m_ItemName = i_ItemName;
        }

        public MenuItem(string i_ItemName, List<MenuItem> i_MenuItems)
        {
            m_ItemName = i_ItemName;
            r_ItemsList = i_MenuItems;
        }

        public MenuItem(string i_ItemName, IButtonFunction i_Functionality)
        {
            m_ItemName = i_ItemName;
            this.m_ButtonFunctionalities = i_Functionality;
        }

        public string ItemName
        {
            get
            {
                return m_ItemName;
            }
        }

        public void AddMenuItem(MenuItem i_Item)
        {
            r_ItemsList.Add(i_Item);
        }

        public void RemoveItem(MenuItem i_Item)
        {
            r_ItemsList.Remove(i_Item);
        }

        public void ButtonClick()
        {
            if (r_ItemsList.Count > 0)
            {
                this.Show();
            }

            else
            {
                m_ButtonFunctionalities.OnClick();
            }

        }

        public virtual void Show()
        {
            bool backPressed;
            int counter, choice;
            string exitOrBack;

            do
            {
                if(this is MainMenu)
                {
                    exitOrBack = "Exit";
                    Console.Clear();
                }
                else
                {
                    exitOrBack = "Back";
                }

                counter = 1;
                Console.WriteLine(string.Format("**{0}**", m_ItemName));
                Console.WriteLine("----------------------");
                foreach(MenuItem item in r_ItemsList)
                {
                    Console.WriteLine(string.Format("{0} -> {1}", counter, item.ItemName));
                    counter++;
                }

                Console.WriteLine("0 -> {0}", exitOrBack);
                Console.WriteLine("----------------------");
                Console.WriteLine(string.Format("Enter your request: ({0} to {1} or press '0' to {2}).", 1, r_ItemsList.Count, exitOrBack));
                choice = askInputFromUser(out backPressed);
                Console.Clear();
                if(choice != 0)
                {
                    choice -= 1;
                    r_ItemsList[choice].ButtonClick();
                }
                else
                {
                    backPressed = true;
                }

            }
            while (!backPressed);
        }

        private int askInputFromUser(out bool io_BackPressed)
        {
            bool isInputIncorrect = true;
            string inputStr;
            int choiceInt;

            io_BackPressed = false;

            do
            {
                inputStr = Console.ReadLine();
                if(int.TryParse(inputStr, out choiceInt))
                {
                    if(choiceInt >= 0 & choiceInt <= r_ItemsList.Count)
                    {
                        isInputIncorrect = false;
                        if(choiceInt == 0)
                        {
                            io_BackPressed = true;
                        }

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
            while(isInputIncorrect);

            return choiceInt;
        }
    }
}