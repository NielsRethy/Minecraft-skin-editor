using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Minecraft_skin_editor.ViewModels;
using SharpDX;

namespace Minecraft_skin_editor.Commands
{
    public class LeftTurn : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var v = parameter as ViewModel;
            var b = v.Viewport as DX10Viewport;
            b.TurnOnce = true;
            b.Turndegrees = 0.2f;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
    public class Up : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var v = parameter as ViewModel;
            var b = v.Viewport as DX10Viewport;
            b.TurnOnce = true;
            b.XAss = true;
            b.Turndegrees = -0.2f;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
    public class Down : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var v = parameter as ViewModel;
            var b = v.Viewport as DX10Viewport;
            b.TurnOnce = true;
            b.XAss = true;
            b.Turndegrees = 0.2f;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
    public class RightTurn : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var v = parameter as ViewModel;
            var b = v.Viewport as DX10Viewport;
            b.TurnOnce = true;

            b.Turndegrees = -0.2f;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
    public class AutoTurn : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var v = parameter as ViewModel;
            var b = v.Viewport as DX10Viewport;
            b.AutoTurn = !b.AutoTurn; ;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
