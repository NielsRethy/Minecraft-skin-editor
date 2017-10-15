using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Minecraft_skin_editor.ViewModels;

namespace Minecraft_skin_editor.Commands
{
    public class AddSkinToList : ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                var v = parameter as ViewModel;
                if (v != null)
                {
                    if (v.NameOfSkin != "")
                        return true;
                    return false;
                }
            }
            return true;
        }

        public void Execute(object parameter)
        {
            var v = parameter as ViewModel;
            string webURL = "https://mcskinsearch.com/api/download/" + v.NameOfSkin;
            if (CheckIfCorrectURl(webURL))
            {
                var lbi = new ListBoxItem();
                lbi.FontSize = 20;
                lbi.Content = v.NameOfSkin;
                v.NamesDownloaded.Add(lbi);
            }
            else
            {
                MessageBox.Show($"There is no skin named: {v.NameOfSkin}");
            }
            v.NameOfSkin = "";

        }

        public event EventHandler CanExecuteChanged { add { } remove { } }

        private bool CheckIfCorrectURl(string url)
        {

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            try
            {
                Bitmap bm = new Bitmap(responseStream);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
