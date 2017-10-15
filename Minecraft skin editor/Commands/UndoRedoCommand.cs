using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Minecraft_skin_editor.ViewModels;

namespace Minecraft_skin_editor.Commands
{
    public class UndoCommand:ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            var v = parameter as ViewModel;
            var bmp = v.UndoRedoBitmap.Undo();
            if (bmp == null) return;
            v.Skin = bmp;
            v.ImageSource = BitmapConverter.BitmapToImageSource(bmp);
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
    public class RedoCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var v = parameter as ViewModel;
            var bmp = v.UndoRedoBitmap.Redo();
            if (bmp == null) return;
            v.Skin = bmp;
            v.ImageSource = BitmapConverter.BitmapToImageSource(bmp);
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
