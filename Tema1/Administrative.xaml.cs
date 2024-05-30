using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Tema1
{
    /// <summary>
    /// Interaction logic for Administrative.xaml
    /// </summary>
    public partial class Administrative : Window
    {
        public Administrative()
        {
            InitializeComponent();
            this.Top = 10;
            this.Left = 300;

            if (new FileInfo("D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\dex.txt").Length == 0)
            {
                txtid.Text = "1";
            }
            else
            {
                List<string> comboBox = new List<string>();
                comboBox = (DataContext as Dictionary).Read();
                int i = 0;
                while (i < comboBox.Count)
                {
                    if (txtcategory.Items.Contains(comboBox[i]) == false)
                    {
                        txtcategory.Items.Add(comboBox[i]);
                    }
                    i++;
                }
                string lastLine = File.ReadLines("D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\dex.txt").Last();
                string[] textLine;
                textLine = lastLine.Split('|');

                txtid.Text = textLine[0];
                int index = int.Parse(txtid.Text);
                index += 1;
                txtid.Text = index.ToString();
            }
        }

        int id;
        bool firstClick = true;
        string category = null;

        string imgPath = null;

        private void txtword_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // verif daca textul introdus contine doar litere sau "-"
            if (!e.Text.All(char.IsLetter) && e.Text != "-")
            {
                e.Handled = true; // anulez introducerea textului
            }
        }
        private void addWords_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtword.Text) ||
                string.IsNullOrWhiteSpace(txtcategory.Text) ||
                string.IsNullOrWhiteSpace(txtdescription.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (firstClick == true)
            {
                firstClick = false;
                id = int.Parse(txtid.Text);
            }

            string path = "D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\dex.txt";

            if (imgPath == null)
            {
                imgPath = "D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\noImage.jpg";
            }
            string txt = txtid.Text + "|" + txtword.Text + "|" + txtcategory.Text + "|" + txtdescription.Text + "|" + imgPath;

            using (StreamWriter objWriter = new StreamWriter(path, true))
            {
                objWriter.WriteLine(txt);
                objWriter.Close();
            }

           (DataContext as Dictionary).DictionaryItems.Add(new Word()
           {
               Id = id.ToString(),
               WordName = txtword.Text,
               Category = txtcategory.Text,
               Description = txtdescription.Text,
               Path = imgPath
           });
            image.Source = new BitmapImage(new Uri("D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\noImage.jpg"));
            imgPath = null;
            id++;
            txtid.Text = id.ToString();

            txtNewCategory.Clear();
            txtdescription.Clear();
            txtword.Clear();
            txtcategory.SelectedIndex = -1;

            if (AddCategory.IsChecked == true)
            {
                AddCategory.IsChecked = false;
            }
        }

        private void AddCategory_Checked(object sender, RoutedEventArgs e)
        {
            category = txtNewCategory.Text;
            txtcategory.Items.Add(category);
            //print category items:
            for (int i = 0; i < txtcategory.Items.Count; i++)
            {
                Console.WriteLine(txtcategory.Items[i]);
            }
        }

        private void modifyWords_Click(object sender, RoutedEventArgs e)
        {
            imgPath = image.Source.ToString();
            string txt = txtid.Text + "|" + txtword.Text + "|" + txtcategory.Text + "|" + txtdescription.Text + "|" + imgPath;

            var item = (DataContext as Dictionary).DictionaryItems.FirstOrDefault(x => x.Id == txtid.Text);
            int i = (DataContext as Dictionary).DictionaryItems.IndexOf(item);

            (DataContext as Dictionary).DictionaryItems[i] = new Word()
            {
                Id = txtid.Text,
                WordName = txtword.Text,
                Description = txtdescription.Text,
                Category = txtcategory.Text,
                Path = image.Source.ToString()
            };

            Read read = new Read();
            read.ChangeFile(txtid.Text, txt);

            string lastLine = File.ReadLines("D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\dex.txt").Last();
            string[] textLine;
            textLine = lastLine.Split('|');

            txtid.Text = textLine[0];
            int index = int.Parse(txtid.Text);
            index += 1;

            txtid.Text = index.ToString();

            txtNewCategory.Clear();
            txtdescription.Clear();
            txtword.Clear();
            txtcategory.SelectedIndex = -1;

            if (AddCategory.IsChecked == true)
            {
                AddCategory.IsChecked = false;
            }
        }

        private void deleteWords_Click(object sender, RoutedEventArgs e)
        {
            imgPath = image.Source.ToString();
            string txt = txtid.Text + "|" + txtword.Text + "|" + txtcategory.Text + "|" + txtdescription.Text + "|" + imgPath;

            var item = (DataContext as Dictionary).DictionaryItems.FirstOrDefault(x => x.Id == txtid.Text);
            if (item != null)
            {
                (DataContext as Dictionary).DictionaryItems.Remove(item);
            }

            Read read = new Read();
            read.DeleteItem(txtid.Text);

            // reincarca lista de elemente din interfata dupa stergere
            var comboBox = (DataContext as Dictionary).Read();
            txtcategory.Items.Clear();
            foreach (var category in comboBox)
            {
                txtcategory.Items.Add(category);
            }

            // actualizeaza id-ul pentru urmat elem
            var lastLine = File.ReadLines("D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\dex.txt").Last();
            var textLine = lastLine.Split('|');
            txtid.Text = (int.Parse(textLine[0]) + 1).ToString();

            // resetare campuri si imagine
            txtdescription.Clear();
            txtword.Clear();
            txtcategory.SelectedIndex = -1;
            image.Source = new BitmapImage(new Uri("D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\noImage.jpg"));
            imgPath = null;
        }

        private void addImg_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = false;
            CommonFileDialogResult result = dialog.ShowDialog();
            imgPath = dialog.FileName;

            var uriSource = new Uri(imgPath);
            image.Source = new BitmapImage(uriSource);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


    }
}
