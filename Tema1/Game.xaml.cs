using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Tema1
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public int result = 0;
        List<string> randList;
        int indexWords = 0;

        string[] descriptionOrImage = { "description", "image" };
        public Game()
        {
            InitializeComponent();
            Random random = new Random();
            string[] Dex = File.ReadAllLines("D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\dex.txt");
            randList =new List<string>();
            for(int i=0;i<5;i++)
            {
                int indexDex = random.Next(Dex.Length);
                if(!randList.Contains(Dex[indexDex]))
                {
                    randList.Add(Dex[indexDex]);
                }
                else
                {
                    i--;
                }
            }
            Functionality();
        }
        public void Functionality()
        {
            string[] textLine;
            textLine = randList[indexWords].Split('|');

            Random ran = new Random();
            int choice = ran.Next(descriptionOrImage.Length);

            if (textLine[4] == "D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\noImage.jpg")
            {
                title.Content = "Guess the word from the description below:";
                gameTxt.Text = textLine[3];
                gameTxt.Visibility = Visibility.Visible;
            }
            else
            {
                if(descriptionOrImage[choice]=="image")
                {
                    title.Content = "Guess the word from the image below:";
                    gameImg.Source = new BitmapImage(new Uri(textLine[4]));
                    gameImg.Visibility = Visibility.Visible;
                }
                else 
                {
                    title.Content = "Guess the word from the description below:";
                    gameTxt.Text = textLine[3];
                    gameTxt.Visibility = Visibility.Visible;
                }
                
            }
        }

        private void nextQ_Click(object sender, RoutedEventArgs e)
        {
            indexWords++;
            if (indexWords == 4)
            {
                nextQ.Content = "Finish";
            }
            if(indexWords<5)
            {
                answer.Text = "";
                check.Visibility = Visibility.Collapsed;
                gameTxt.Visibility = Visibility.Collapsed;
                gameImg.Visibility = Visibility.Collapsed;
                if (checkBox.IsChecked == true)
                {
                    checkBox.IsChecked = false;
                }
                Functionality();
            }
            else
            {
                Finish finish = new Finish();
                finish.message.Content = result.ToString();
                finish.Show();
                this.Close();
            }
            
        }

        private void previousQ_Click(object sender, RoutedEventArgs e)
        {
            indexWords--;
            if (indexWords < 0)
            {
                indexWords = 0;
            }
            answer.Text = "";
            check.Visibility = Visibility.Collapsed;
            gameTxt.Visibility = Visibility.Collapsed;
            gameImg.Visibility = Visibility.Collapsed;
            if (checkBox.IsChecked == true)
            {
                checkBox.IsChecked = false;
            }
            Functionality();
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            string[] textLine;
            textLine = randList[indexWords].Split('|');


            if (answer.Text == textLine[1])
            {
                check.Content = "Correct!";
                Color c = Colors.LightGreen;
                check.Background = new SolidColorBrush(c);
                check.Visibility = Visibility.Visible;
                result++;
            }
            else
            {
                check.Content = "The word was: " + textLine[1];
                Color c = Colors.Red;
                check.Background = new SolidColorBrush(c);
                check.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
