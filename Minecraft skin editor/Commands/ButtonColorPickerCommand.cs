using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Minecraft_skin_editor.ViewModels;
using Xceed.Wpf.Toolkit;

namespace Minecraft_skin_editor.Commands
{
    public class ButtonColorPickerCommand: ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var v = parameter as ViewModel;
            v.SetColorPicker = !v.SetColorPicker;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
