using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Minecraft_skin_editor.ViewModels;

namespace Minecraft_skin_editor.Commands
{
    public class ApplyTextureToSkin : ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                var v = parameter as ViewModel;
                if (v != null)
                {
                    if (v.SelecteListItem != null)
                        return true;
                    return false;
                }
            }
            return true;
        }

        public void Execute(object parameter)
        {
            var b = parameter as ViewModel;
            string webURL = "https://mcskinsearch.com/api/download/" + b.SelecteListItem.Content;
            WebRequest request = WebRequest.Create(webURL);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            Bitmap bmp = new Bitmap(responseStream);
            Rectangle section = new Rectangle(new Point(0, 0), new Size(64, 32));
            bmp = BitmapConverter.CropImage(bmp, section);
            b.Skin = bmp;
            b.ImageSource = BitmapConverter.BitmapToImageSource(bmp);
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

    }

}
