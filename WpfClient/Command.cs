﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfClient
{
    class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action<object> _action;
        public MyCommand(Action<object> act)
        {
            _action = act;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
