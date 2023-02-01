using System.Windows;
using System.IO;
using DiceAndDragons.Model;
using System;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace DiceAndDragons.View
{
    /// <summary>
    /// Interaction logic for V_CreateCharacter.xaml
    /// </summary>
    public partial class V_CreateCharacter : Window
    {
        M_Dice D = new M_Dice();
        public V_CreateCharacter()
        {
            InitializeComponent();
            DataContext = D;
        }

        private void clearData(object sender, RoutedEventArgs e)
        {
            Close();
            new View.V_CreateCharacter().Show();
        }

        private void rollStats(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.rollModeD6 == false)
            {
                statSTR.Text = D.rollStats(1, 20).ToString();
                statDEX.Text = D.rollStats(1, 20).ToString();
                statCON.Text = D.rollStats(1, 20).ToString();
                statINT.Text = D.rollStats(1, 20).ToString();
                statWIS.Text = D.rollStats(1, 20).ToString();
                statCHA.Text = D.rollStats(1, 20).ToString();
            }
            else
            {
                statSTR.Text = rollD6().ToString();
                statDEX.Text = rollD6().ToString();
                statCON.Text = rollD6().ToString();
                statINT.Text = rollD6().ToString();
                statWIS.Text = rollD6().ToString();
                statCHA.Text = rollD6().ToString();
            }
        }

        private int rollD6()
        {
            int x = 0;
            for(int i = 0; i < 5; i++)
            {
                x += D.rollStats(1, 6);
            }
            return x;
        }

        private void rollStatsSetting(object sender, RoutedEventArgs e)
        {
            new View.V_RollStats().Show();
        }

        private void charSave(object sender, RoutedEventArgs e)
        {
            string[] character =
            {
                "////////////////////////-Base Info-////////////////////////",
                "Name:"+charName.Text,
                "Alignment:"+charAlign.Text,
                "Race:"+charRace.Text,
                "Class:"+charClass.Text,
                "FullBio:"+charBio.Text,
                "Level:1",
                "Exp:0",
                "////////////////////////-Additional Info-////////////////////////",
                "Age:"+charAge.Text,
                "Height:"+charHeight.Text,
                "Sex:"+charSex.Text,
                "Gender:"+charGender.Text,
                "Birth Date:"+charBirthD.Text,
                "Birth Place:"+charBirthP.Text,
                "Blood Type:"+charBlood.Text,
                "Appearance:"+charAppearance.Text,
                "Pesudonims:"+charAltName.Text,
                "Allies:"+charAlly.Text,
                "Enemies:"+charEnemy.Text,
                "Strengths:"+charStrong.Text,
                "Weaknesses:"+charWeak.Text,
                "Personality:"+charPersonality.Text,
                "////////////////////////-Attributes-////////////////////////",
                "STR:"+statSTR.Text,
                "DEX:"+statDEX.Text,
                "CON:"+statCON.Text,
                "INT:"+statINT.Text,
                "WIS:"+statWIS.Text,
                "CHA:"+statCHA.Text,
            };

            string fileName = charName.Text.Replace(" ", "") + ".txt";

            if(!Directory.Exists("Characters")) Directory.CreateDirectory("Characters");

            if (Directory.Exists(charName.Text))
            {
                MessageBox.Show("A character with this name already exists, pick another one.", "I'm afraid I can't let you do that");
            }
            else
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Characters");
                Directory.CreateDirectory(Path.Combine(filePath, charName.Text));

                filePath = Path.Combine(filePath, charName.Text);

                File.Copy(imgFull.Text, Path.Combine(filePath, Path.GetFileName(imgFull.Text)));
                File.Copy(imgMin.Text, Path.Combine(filePath, Path.GetFileName(imgMin.Text)));

                string[] images =
                {
                    "////////////////////////-Images-////////////////////////",
                    "FullImg:" + Path.Combine(filePath,  Path.GetFileName(imgFull.Text)),
                    "Miniature:" + Path.Combine(filePath, Path.GetFileName(imgMin.Text))
                };

                using (StreamWriter sw = new StreamWriter(Path.Combine(filePath, fileName)))
                {
                    for (int i = 0; i < character.Length; i++)
                    {
                        sw.WriteLine(character[i]);
                    }
                    for (int i = 0; i < images.Length; i++)
                    {
                        sw.WriteLine(images[i]);
                    }
                }
                Close();
            }

        }

        private void selectImage(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog imgSelect = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = imgSelect.ShowDialog();

            if (result == true)
            {
                imgFull.Text = imgSelect.FileName;
            }
        }

        private void selectMin(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog imgSelect = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = imgSelect.ShowDialog();

            if (result == true)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(imgSelect.FileName, UriKind.RelativeOrAbsolute);
                img.EndInit();

                if (img.Width == img.Height)
                {
                    imgMin.Text = imgSelect.FileName;
                    disMin.Source = img;
                }
                else MessageBox.Show("A Miniature must have equal dimensions", "Wrong image size");
                
            }
        }
    }
}
