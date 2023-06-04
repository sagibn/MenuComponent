using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Test
{
    public class ShowTimeButton : Interfaces.IButtonFunction
    {
        InvokedMethods m_InvokedMethods = new InvokedMethods();

        public void OnClick()
        {
            m_InvokedMethods.ShowTime();
        }
    }
}
