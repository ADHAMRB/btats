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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace movies_project
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Singup_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SignUp());
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MoviesEntities db = new MoviesEntities();
            var user = db.Users.FirstOrDefault(x => x.UserEmail == Emailtxt.Text && x.UserPassword == Passtxt.Text);
            if (Emailtxt.Text == "admin@gmail.com" && Passtxt.Text == "admin1234")
            {
                this.NavigationService.Navigate(new Admin());
                MessageBox.Show("welcome admin");
            }
            else
            {
                if (user != null)
                {
                    this.NavigationService.Navigate(new HomeMovie());
                    MessageBox.Show("welcome user");
                }
                else
                {
                    MessageBox.Show("Account Does Not Exist");
                }
            }
            
        }
        private void ForgetPassword_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ForgetPassword());
        }
    }
}
