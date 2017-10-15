using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Minecraft_skin_editor.ViewModels;

namespace Minecraft_skin_editor.Commands
{
    public class DeleteSkinFromList: ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                var v = parameter as ViewModel;
                if (v != null)
                {
                    if (v.SelecteListItem!= null)
                        return true;
                    return false;
                }
            }
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                var v = parameter as ViewModel;
                if (v != null)
                {
                    v.NamesDownloaded.Remove(v.SelecteListItem);

                }
            }
        }

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
