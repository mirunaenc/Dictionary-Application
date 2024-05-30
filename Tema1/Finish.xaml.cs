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

namespace Tema1
{
    /// <summary>
    /// Interaction logic for Finish.xaml
    /// </summary>
    public partial class Finish : Window
    {
        public Finish()
        {
            InitializeComponent();
        }

        private void playAgain_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game();
            game.Show();
            this.Close();
        }
    }
}
