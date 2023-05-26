using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public delegate void ChosenItemDelegate(); 

    public class MenuItem
    {
        private string Name { get; set; }
        private MenuItem m_ParentItem = null;
        private List<MenuItem> m_SubItems;
        public event ChosenItemDelegate ChosenItem;

        public MenuItem(string i_Name)
        {
            Name = i_Name;
            m_SubItems = new List<MenuItem>();
            ChosenItem += ShowItem;
        }

        public MenuItem(string i_Name, ChosenItemDelegate i_Func)
        {
            Name = i_Name;
            ChosenItem += i_Func;
        }

        public MenuItem ParentItem
        {
            get { return m_ParentItem; }

            set
            {
                m_ParentItem = value;
            }
        }

        public void ShowItem()
        {
            string firstChoice = "Back";

            if(this is MainMenu)
            {
                firstChoice = "Exit";
            }

            Console.WriteLine("**{0}**", Name);
            Console.WriteLine("-----------------------");
            for(int i = 0; i < m_SubItems.Count; i++)
            {
                Console.WriteLine("{0} -> {1}", i + 1, m_SubItems[i].Name);
            }

            Console.WriteLine("0 -> {0}", firstChoice);
            Console.WriteLine("-----------------------");
            Console.WriteLine("Enter your request: (1 to {0} or press '0' to {1}).", m_SubItems.Count, firstChoice);
            executeChoice(getChoiceFromUser());
        }

        private void executeChoice(int i_Choice)
        {
            if(i_Choice > 0)
            {
                m_SubItems[i_Choice - 1].OnChosen();
                OnChosen();
            }
            else
            {
                if(!(this is MainMenu))
                {
                    if(m_ParentItem != null)
                    {
                        m_ParentItem.OnChosen();
                    }
                    else
                    {
                        throw new Exception("An item without parent must be MainMenu type.");
                    }
                }
                else
                {
                    //Remove listeners from MainMenu to avoid recursion and exit.
                    ChosenItem = null;
                }
            }
        }

        private int getChoiceFromUser()
        {
            int userChoice = int.MinValue;
            bool isValid = false;

            while(!isValid)
            {
                isValid = int.TryParse(Console.ReadLine(), out userChoice);

                if(!isValid || userChoice > m_SubItems.Count || userChoice < 0)
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    isValid = false;
                }
            }

            return userChoice;
        }

        public void AddItem(MenuItem i_SubItem)
        {
            if(i_SubItem != null)
            {
                i_SubItem.ParentItem = this;
                m_SubItems.Add(i_SubItem);
            }
            else
            {
                throw new Exception("Trying to add empty item.");
            }
        }
        
        public void RemoveItem(MenuItem i_SubItem)
        {
            if (m_SubItems.Contains(i_SubItem))
            {
                m_SubItems.Remove(i_SubItem);
            }
            else
            {
                throw new Exception("Sub item doesn't exist.");
            }
        }

        protected virtual void OnChosen()
        {
            if(ChosenItem != null)
            {
                //if (m_SubItems.Count > 0)
                //{
                //    foreach (MenuItem subItem in m_SubItems)
                //    {
                //        if (subItem.ChosenItem.GetInvocationList().Contains((ChosenItemDelegate)ShowItem))
                //        {
                //            Console.Clear();
                //        }
                //    }
                //}

                ChosenItem.Invoke();
            }
        }
    }
}
