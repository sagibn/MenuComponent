using System;

namespace Ex04.Menus.Interfaces
{
    public delegate void FunctionSelected();

    public class Function : MenuItem
    {
        private readonly FunctionSelected r_FunctionSelected;

        public Function(string i_MenuItemTitle, FunctionSelected i_ExecutableAction, MainMenu i_MainMenu)
            : base(i_MenuItemTitle, i_MainMenu)
        {
            r_FunctionSelected += i_ExecutableAction;
        }

        public override void Show()
        {
            r_FunctionSelected?.Invoke();
        }
    }
}