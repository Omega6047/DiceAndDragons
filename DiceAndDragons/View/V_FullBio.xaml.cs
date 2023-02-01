using System.Windows;
using System.Windows.Controls;

namespace DiceAndDragons.View
{
    /// <summary>
    /// Interaction logic for V_FullBio.xaml
    /// </summary>
    public partial class V_FullBio : Window
    {
        public V_FullBio()
        {
            InitializeComponent();
        }

        private void setText(object sender, System.EventArgs e)
        {
            var tag = ((TextBlock)sender).Tag;

            switch (tag)
            {
                case "Age":
                    if(Settings.Default.bioAge == "")
                    {
                        ((TextBlock)sender).Visibility = Visibility.Collapsed;
                    }
                    break;

                case "BirthD":
                    if(Settings.Default.bioBirthD == "")
                    {
                        ((TextBlock)sender).Visibility = Visibility.Collapsed;
                    }
                    break;

                case "BirthP":
                    if(Settings.Default.bioBirthP == "")
                    {
                        ((TextBlock)sender).Visibility = Visibility.Collapsed;
                    }
                    break;

                case "Height":
                    if(Settings.Default.bioHeight == "")
                    {
                        ((TextBlock)sender).Visibility = Visibility.Collapsed;
                    }
                    break;

                case "Blood":
                    if(Settings.Default.bioBlood == "")
                    {
                        ((TextBlock)sender).Visibility = Visibility.Collapsed;
                    }
                    break;

                case "Weak":
                    if(Settings.Default.bioWeak == "")
                    {
                        ((TextBlock)sender).Visibility = Visibility.Collapsed;
                    }
                    break;

                case "Strong":
                    if(Settings.Default.bioStrong == "")
                    {
                        ((TextBlock)sender).Visibility = Visibility.Collapsed;
                    }
                    break;

                case "Ally":
                    if(Settings.Default.bioAlly == "")
                    {
                        ((TextBlock)sender).Visibility = Visibility.Collapsed;
                    }
                    break;

                case "Enemy":
                    if(Settings.Default.bioEnemy == "")
                    {
                        ((TextBlock)sender).Visibility = Visibility.Collapsed;
                    }
                    break;

                case "AltName":
                    if(Settings.Default.bioAltName == "")
                    {
                        ((TextBlock)sender).Visibility = Visibility.Collapsed;
                    }
                    break;
            }
        }
    }
}
