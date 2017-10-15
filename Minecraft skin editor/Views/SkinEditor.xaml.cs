using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minecraft_skin_editor.Views
{
    /// <summary>
    /// Interaction logic for SkinEditor.xaml
    /// </summary>


    public partial class SkinEditor : UserControl
    {
        public SkinEditor()
        {
            InitializeComponent();
            Picture.PICTURE = SkinBack;
        }

        private void Rectangle_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Picture.PICTURE = SkinBack;
        }
    }
}
