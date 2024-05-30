using System.Windows;
using System.IO;

namespace Tema1
{
    public partial class LoginDialog : Window
    {
        public string Username => txtUsername.Text;
        public string Password => txtPassword.Password;

        private bool Authenticate(string username, string password, string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && parts[0] == username && parts[1] == password)
                    return true;
            }
            return false;
        }

        public LoginDialog()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "D:\\FACULTATE\\Anul II\\Semestrul II\\MVP\\Teme\\Tema1\\Tema1\\Tema1\\users.txt";
            if (Authenticate(Username, Password, filePath))
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.");
            }
        }
    }
}