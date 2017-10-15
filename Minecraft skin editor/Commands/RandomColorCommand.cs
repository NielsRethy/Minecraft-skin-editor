using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Minecraft_skin_editor.ViewModels;

namespace Minecraft_skin_editor.Commands
{
    public class RandomColorCommand: ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int width = 64, height = 32;

            //bitmap
            Bitmap bmp = new Bitmap(width, height);

            //random number
            Random rand = new Random();

            //create random pixels
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //generate random ARGB value
                    int a = rand.Next(256);
                    int r = rand.Next(256);
                    int g = rand.Next(256);
                    int b = rand.Next(256);

                    //set ARGB value
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            var v = parameter as ViewModel;
            v.Skin = bmp;
            v.ImageSource = BitmapConverter.BitmapToImageSource(bmp);
            v.UndoRedoBitmap.Reset();
            v.UndoRedoBitmap.Add(bmp);
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
