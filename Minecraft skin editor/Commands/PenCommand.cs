using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Minecraft_skin_editor.ViewModels;

namespace Minecraft_skin_editor.Commands
{
    public class PenPixelDownCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var v = parameter as ViewModel;
            v.UsePen = true;
            v.EnabledBrush = true;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
