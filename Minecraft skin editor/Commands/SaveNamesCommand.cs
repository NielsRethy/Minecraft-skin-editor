using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using Microsoft.Win32;
using Minecraft_skin_editor.ViewModels;

namespace Minecraft_skin_editor.Commands
{
    public class SaveNamesCommand: ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var v = parameter as ViewModel;
            var pList = new NamesOfPlayers();

            foreach (var n in v.NamesDownloaded)
            {
                var np = new NamePlayer() {Name = n.Content.ToString()};
                pList.NamePlayersList.Add(np);
            }
            
            

            var xmlSerializer = new XmlSerializer(typeof(NamesOfPlayers));



            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML-File | *.xml";
            if (saveFileDialog.ShowDialog() == true)
            { 
                xmlSerializer.Serialize(File.Create(saveFileDialog.FileName), pList);
            }
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
