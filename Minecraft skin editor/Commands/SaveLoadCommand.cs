using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Minecraft_skin_editor.ViewModels;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace Minecraft_skin_editor.Commands
{
    public class LoadSkinCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            var v = parameter as ViewModel;

            Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog();
            if (file.ShowDialog() == true)
            {
                try
                {
                    var bmp = new Bitmap(file.FileName);

                    if (bmp.Width == 64 && (bmp.Height == 64 || bmp.Height == 32))
                    {
                        Rectangle section = new Rectangle(new Point(0, 0), new Size(64, 32));
                        bmp = BitmapConverter.CropImage(bmp, section);
                        v.UndoRedoBitmap.Reset();
                        v.Skin = bmp;
                        v.ImageSource = BitmapConverter.BitmapToImageSource(bmp);


                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("Failed to open file? Not a correct minecraft skin");
                }

            }


        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }

    public class SaveSkinCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {

            return true;
        }

        public void Execute(object parameter)
        {

            try
            {

                var v = parameter as ViewModel;
                if (v.Skin == null)
                    return;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG-File | *.png";
                if (saveFileDialog.ShowDialog() == true)
                {
                    v.Skin.Save(saveFileDialog.FileName);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Failed to save. Maybe try another name? ");
            }
           
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
