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
using System.Windows.Shapes;

namespace DiceAndDragons.View
{
    /// <summary>
    /// Interaction logic for V_EditCustom.xaml
    /// </summary>
    public partial class V_EditCustom : Window
    {
        public V_EditCustom()
        {
            InitializeComponent();
        }

        private void closeCustom(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
