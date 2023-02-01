using System.Diagnostics;
using System.Windows;
using DiceAndDragons.Model;
using System.IO;
using System;

namespace DiceAndDragons.View
{
    public partial class V_MainPanel : Window
    {

        M_Dice D = new M_Dice();
        public V_MainPanel()
        {
            InitializeComponent();
            DataContext = D;
        }

        private void rollD20(object sender, RoutedEventArgs e)
        {
            D.rollDice(1, 20);
        }

        private void rollD10(object sender, RoutedEventArgs e)
        {
            D.rollDice(1, 10);
        }

        private void rollD8(object sender, RoutedEventArgs e)
        {
            D.rollDice(1, 8);
        }

        private void rollD6(object sender, RoutedEventArgs e)
        {
            D.rollDice(1, 6);
        }

        private void rollD4(object sender, RoutedEventArgs e)
        {
            D.rollDice(1, 4);
        }

        private void rollCustom(object sender, RoutedEventArgs e)
        {
            D.rollDice(Settings.Default.customDiceMin, Settings.Default.customDiceMax);
        }

        private void editCustom(object sender, RoutedEventArgs e)
        {
            new View.V_EditCustom().ShowDialog();
        }

        private void addExp(object sender, RoutedEventArgs e)
        {
            new View.V_AddExp().ShowDialog();
        }

        private void createChar(object sender, RoutedEventArgs e)
        {
            new View.V_CreateCharacter().Show();

        }

        private void loadChar(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog charData = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = charData.ShowDialog();

            using (StreamReader sr = new StreamReader(charData.FileName))
            {
                string line;
                string[] id;

                while (true)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        id = line.Split(":");
                    }
                    else return;

                    switch (id[0])
                    {
                        case "Name":
                            Settings.Default.bioName = line.Replace("Name:", "");
                            break;
                        case "Alignment":
                            Settings.Default.bioAlignment = line.Replace("Alignment:", "");
                            break;
                        case "Race":
                            Settings.Default.bioRace = line.Replace("Race:", "");
                            break;
                        case "Class":
                            Settings.Default.bioClass = line.Replace("Class:", "");
                            break;
                        case "FullBio":
                            Settings.Default.bioFull = line.Replace("FullBio:", "");
                            break;
                        case "Level":
                            Settings.Default.bioLvl = int.Parse(line.Replace("Level:", ""));
                            break;
                        case "Exp":
                            Settings.Default.bioExp = int.Parse(line.Replace("Exp:", ""));
                            break;
                        case "STR":
                            Settings.Default.charSTR = int.Parse(id[1]);
                            Settings.Default.bonusSTR = calcStatBonus(int.Parse(id[1]));
                            break;
                        case "DEX":
                            Settings.Default.charDEX = int.Parse(id[1]);
                            Settings.Default.bonusDEX = calcStatBonus(int.Parse(id[1]));
                            break;
                        case "CON":
                            Settings.Default.charCON = int.Parse(id[1]);
                            Settings.Default.bonusCON = calcStatBonus(int.Parse(id[1]));
                            break;
                        case "INT":
                            Settings.Default.charINT = int.Parse(id[1]);
                            Settings.Default.bonusINT = calcStatBonus(int.Parse(id[1]));
                            break;
                        case "WIS":
                            Settings.Default.charWIS = int.Parse(id[1]);
                            Settings.Default.bonusWIS = calcStatBonus(int.Parse(id[1]));
                            break;
                        case "CHA":
                            Settings.Default.charCHA = int.Parse(id[1]);
                            Settings.Default.bonusCHA = calcStatBonus(int.Parse(id[1]));
                            break;
                        case "FullImg":
                            Settings.Default.imgPortreit = line.Replace("FullImg:", "");
                            break;
                        case "Age":
                            Settings.Default.bioAge = line.Replace("Age:", "");
                            break;
                        case "Height":
                            Settings.Default.bioHeight = line.Replace("Height:", "");
                            break;
                        case "Sex":
                            Settings.Default.bioSex = line.Replace("Sex:", "");
                            break;
                        case "Gender":
                            Settings.Default.bioGender = line.Replace("Gender:", "");
                            break;
                        case "Birthe Date":
                            Settings.Default.bioBirthD = line.Replace("Birthe Date:", "");
                            break;
                        case "Birth Place":
                            Settings.Default.bioBirthP = line.Replace("Birthe Place:", "");
                            break;
                        case "Blood Type":
                            Settings.Default.bioBlood = line.Replace("Blood Type:", "");
                            break;
                        case "Appearance":
                            Settings.Default.bioAppearance = line.Replace("Appearance:", "");
                            break;
                        case "Strengths":
                            Settings.Default.bioStrong = line.Replace("Strengths:", "");
                            break;
                        case "Weaknesses":
                            Settings.Default.bioWeak = line.Replace("Weaknesses:", "");
                            break;
                        case "Allies":
                            Settings.Default.bioAlly = line.Replace("Allies:", "");
                            break;
                        case "Enemies":
                            Settings.Default.bioEnemy = line.Replace("Enemies:", "");
                            break;
                        case "Personality":
                            Settings.Default.bioPersonality = line.Replace("Personality:", "");
                            break;
                    }
                }
            }
        }

        public string calcStatBonus(int stat)
        {
            string bonus;
            if (stat == 10)
            {
                bonus = "(+0)";
            }
            else if (stat > 10)
            {
                int x = stat - 10;
                if (x % 2 == 1)
                {
                    x--;
                }
                bonus = "(+" + x / 2 + ")";
            }
            else
            {
                int x = stat;
                if (x % 2 == 1)
                {
                    x--;
                }
                int y = 0;
                for(int i = x; i < 10; i += 2)
                {
                    y -= 1;
                }
                bonus = "(" + y + ")";
            }
            return bonus;
        }

        private void showBio(object sender, RoutedEventArgs e)
        {
            new View.V_FullBio().Show();
        }
    }
}
