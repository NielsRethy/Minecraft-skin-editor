using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Minecraft_skin_editor.ViewModels;

using System.Windows.Media.Imaging;
using SharpDX;
using Color = System.Drawing.Color;
using Rectangle = System.Drawing.Rectangle;


namespace Minecraft_skin_editor.Commands
{
    public class PaintCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            var b = parameter as ViewModel;
            if (b.EnabledBrush)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {

          
            var b = parameter as ViewModel;
            if (b.ImageSource == null)
                return;
            if (!b.UsePen)
            {
                b.IsMouseDown = true;
                return;
            }

            var myBitmapImage = b.ImageSource as BitmapImage;
            Bitmap bmp = BitmapConverter.BitmapImage2Bitmap(myBitmapImage);

            
            var p = Mouse.GetPosition(Picture.PICTURE);


            p.X /= Picture.PICTURE.ActualWidth / b.ImageSource.Width;
            p.Y /= Picture.PICTURE.ActualHeight / b.ImageSource.Height;
            if (p.X < b.Skin.Width && p.X > 0 && p.Y < b.Skin.Height && p.Y > 0)
            {
                var col = new Color();
                col = Color.FromArgb(b.BrushColorPick.A, b.BrushColorPick.R, b.BrushColorPick.G, b.BrushColorPick.B);
                bmp.SetPixel((int) p.X, (int) p.Y, col);
                b.Skin = bmp;
                b.ImageSource = BitmapConverter.BitmapToImageSource(bmp);
                b.UndoRedoBitmap.Add(bmp);
            }


            

        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

      
    }

    public class PaintMoveCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            var b = parameter as ViewModel;
            if (b.IsMouseDown)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {


            var b = parameter as ViewModel;
            if (b.ImageSource == null)
                return;
            var myBitmapImage = b.ImageSource as BitmapImage;
            Bitmap bmp = BitmapConverter.BitmapImage2Bitmap(myBitmapImage);


            var p = Mouse.GetPosition(Picture.PICTURE);


            p.X /= Picture.PICTURE.ActualWidth / b.ImageSource.Width;
            p.Y /= Picture.PICTURE.ActualHeight / b.ImageSource.Height;
            if (p.X < b.Skin.Width && p.X > 0 && p.Y < b.Skin.Height && p.Y > 0)
            {
                var col = new Color();
                col = Color.FromArgb(b.BrushColorPick.A, b.BrushColorPick.R, b.BrushColorPick.G, b.BrushColorPick.B);
                bmp.SetPixel((int)p.X, (int)p.Y, col);
                b.Skin = bmp;
                b.ImageSource = BitmapConverter.BitmapToImageSource(bmp);
            }




        }

        public event EventHandler CanExecuteChanged { add { } remove { } }


    }

    public class MouseUpCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var b = parameter as ViewModel;
            if (b.IsMouseDown)
            {
                b.UndoRedoBitmap.Add( b.Skin);
            }
            b.IsMouseDown = false;
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }


}
