using System.Windows;


namespace Tema1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Top = 200;
            this.Left = 300;
        }

        private void admin_Click(object sender, RoutedEventArgs e)
        {
            LoginDialog loginWindow = new LoginDialog();
            if (loginWindow.ShowDialog() == true)
            {
                Administrative adminWindow = new Administrative();
                adminWindow.Show();
                this.Close();
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            Search search = new Search();
            search.Show();
            this.Close();
        }

        private void game_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game();
            game.Show();
            this.Close();
        }
    }
}
