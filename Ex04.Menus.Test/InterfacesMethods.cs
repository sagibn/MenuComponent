using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class ShowVersionButton : Interfaces.IButtonFunctionality
    {
        InvokedMethods m_InvokedMethods = new InvokedMethods();

        public void OnClick()
        {
            m_InvokedMethods.ShowVersion();
        }
    }

    public class CountSpaces : Interfaces.IButtonFunctionality
    {
        InvokedMethods m_InvokedMethods = new InvokedMethods();

        public void OnClick()
        {
            m_InvokedMethods.CountSpaces();
        }
    }

    public class ShowDateButton : Interfaces.IButtonFunctionality
    {
        InvokedMethods m_InvokedMethods = new InvokedMethods();

        public void OnClick()
        {
            m_InvokedMethods.ShowDate();
        }
    }

    public class ShowTimeButton : Interfaces.IButtonFunctionality
    {
        InvokedMethods m_InvokedMethods = new InvokedMethods();

        public void OnClick()
        {
            m_InvokedMethods.ShowTime();
        }
    }

}
