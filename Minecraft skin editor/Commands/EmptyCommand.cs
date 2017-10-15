using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Minecraft_skin_editor.ViewModels;

namespace Minecraft_skin_editor.Commands
{
    public class EmptyCommand: ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var b = parameter as ViewModel;
            var filepath = System.AppDomain.CurrentDomain.BaseDirectory;
            filepath += "\\Resources\\Tex\\SkinTemplate.png";
            Bitmap bm = new Bitmap(filepath);
            b.Skin = bm;
            b.ImageSource = BitmapConverter.BitmapToImageSource(bm);  
            b.UndoRedoBitmap.Reset();
            b.UndoRedoBitmap.Add(bm);          

        }

        public event EventHandler CanExecuteChanged { add { } remove { } }



    }
}


