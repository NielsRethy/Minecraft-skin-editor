using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;
using Minecraft_skin_editor.ViewModels;

namespace Minecraft_skin_editor.Commands
{
    public class LoadNamesCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            

            NamesOfPlayers pl = null;
            XmlSerializer serializer = new XmlSerializer(typeof(NamesOfPlayers));
            Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog();
            if (file.ShowDialog() == true)
            {
                try
                {
                    StreamReader reader = new StreamReader(file.FileName);
                    pl = (NamesOfPlayers)serializer.Deserialize(reader);
                    reader.Close();
                    var v = parameter as ViewModel;
                    v.NamesDownloaded.Clear();

                    var orderdlist2 = from nameINList in pl.NamePlayersList
                                      orderby nameINList.Name ascending
                                      select nameINList;

                    foreach (var p in orderdlist2)
                    {
                        var lbi = new ListBoxItem();
                        lbi.FontSize = 20;
                        lbi.Content = p.Name;

                        v.NamesDownloaded.Add(lbi);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to open file? Not correct XML file");
                }

            }

          

            

        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
