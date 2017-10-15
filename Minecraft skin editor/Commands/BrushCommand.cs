using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Minecraft_skin_editor.ViewModels;

namespace Minecraft_skin_editor.Commands
{
    public class BrushCommand :ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var a = parameter as ViewModel;
            a.EnabledBrush = true;
            a.UsePen = false;
            var test = a.ImageSource;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
