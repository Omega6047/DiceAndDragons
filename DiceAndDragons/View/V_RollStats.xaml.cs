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
    /// Interaction logic for V_RollStats.xaml
    /// </summary>
    public partial class V_RollStats : Window
    {
        public V_RollStats()
        {
            InitializeComponent();
        }

        private void saveRollMode(object sender, RoutedEventArgs e)
        {
            if (d20.IsChecked == true)
            {
                Settings.Default.rollModeD6 = false;
            }
            else if (d20.IsChecked == false)
            {
                Settings.Default.rollModeD6 = true;
            }
            Close();
        }
    }
}
