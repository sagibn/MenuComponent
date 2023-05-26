using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Test
{
    public class InvokedMethods
    {
        public void ShowDate()
        {
            Console.WriteLine("The Date is: {0}", DateTime.Now.ToString("d"));
            Console.WriteLine();
            Console.WriteLine();
        }

        public void ShowTime()
        {
            Console.WriteLine("The Hour is: {0}", DateTime.Now.ToString("T"));
            Console.WriteLine();
            Console.WriteLine();
        }

        public void ShowVersion()
        {
            Console.WriteLine("Version: 23.2.4.9805");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void CountSpaces()
        {
            Console.WriteLine("Please enter your sentence:");
            string sentence = Console.ReadLine();
            int countSpaces = 0;

            foreach(char c in sentence)
            {
                if(c == ' ')
                {
                    countSpaces++;
                }
            }

            Console.WriteLine("There {0} {1} space{2} in your sentence.",
                countSpaces != 1 ? "are" : "is", countSpaces, countSpaces != 1 ? "s" : "");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
