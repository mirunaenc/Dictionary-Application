using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Tema1
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        List<string> wordsListBox;

        public Search()
        {
            InitializeComponent();
            wordsListBox = new List<string>();
            string pathToRead = "D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\dex.txt";

            string[] Line = File.ReadAllLines(pathToRead);
            int m = 0;
            while (m < Line.Length)
            {
                string[] str;
                str = Line[m].Split('|');
                wordsListBox.Add(str[1]);
                m++;
            }

            txtBox.TextChanged += new TextChangedEventHandler(txtBox_TextChanged);
        }

        private void txtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string strWord = txtBox.Text;
            List<string> listWords = new List<string>();

            foreach (string s in wordsListBox)
            {
                if (!string.IsNullOrEmpty(txtBox.Text))
                {
                    if (s.StartsWith(strWord))
                    {
                        listWords.Add(s);
                    }
                }
            }
            if (listWords.Count > 0)
            {
                list.ItemsSource = listWords;
                list.Visibility = Visibility.Visible;
            }
            else
            {
                if (txtBox.Text.Equals(""))
                {
                    list.Visibility = Visibility.Collapsed;
                    list.ItemsSource = null;
                }
                else
                {
                    list.Visibility = Visibility.Collapsed;
                    list.ItemsSource = null;
                }
            }
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.ItemsSource != null)
            {
                list.Visibility = Visibility.Collapsed;
                txtBox.TextChanged -= new TextChangedEventHandler(txtBox_TextChanged);
                if (list.SelectedIndex != -1)
                {
                    txtBox.Text = list.SelectedItem.ToString();
                }
                txtBox.TextChanged += new TextChangedEventHandler(txtBox_TextChanged);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\dex.txt";

            string[] arrLine;
            List<string> listWords = new List<string>();

            arrLine = File.ReadAllLines(fileName);

            foreach (string line in arrLine)
            {
                string[] textLine = line.Split('|');

                if (textLine[1] == txtBox.Text)
                {
                    word.Text = textLine[1];
                    category.Text = textLine[2];
                    description.Text = textLine[3];
                    image.Source = new BitmapImage(new Uri(textLine[4]));

                    // ascunde lista de sugestii
                    list.Visibility = Visibility.Collapsed;

                    return;
                }
                else if (textLine[1].StartsWith(txtBox.Text))
                {
                    listWords.Add(textLine[1]); // adaug cuv sugerat in lista
                }
            }

            // actualizez lista cu cuvinte sugerate si o fac vizibila doar daca exista sugestii
            if (listWords.Count > 0)
            {
                list.ItemsSource = listWords;
                list.Visibility = Visibility.Visible;
            }
            else
            {
                list.Visibility = Visibility.Collapsed;
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
