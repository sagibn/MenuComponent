using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class CountSpacesButton : Interfaces.IButtonFunction
    {
        InvokedMethods m_InvokedMethods = new InvokedMethods();

        public void OnClick()
        {
            m_InvokedMethods.CountSpaces();
        }
    }
}
