using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace DiceAndDragons.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class V_AddExp : Window
    {
        public V_AddExp()
        {
            InitializeComponent();
        }

        private void buttonAdd(object sender, RoutedEventArgs e)
        {
            Settings.Default.bioExp += int.Parse(addExp.Text);
            this.Close();
        }

        private void IsNumeric(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex ("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
