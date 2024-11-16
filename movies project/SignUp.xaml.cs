using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            MoviesEntities db = new MoviesEntities();
            var check = db.Users.FirstOrDefault(x => x.UserName == Nametxt.Text && x.UserEmail == Emailtxt.Text);

            if (check == null)
            {
                User user = new User();
                user.UserName = Nametxt.Text;
                user.UserEmail = Emailtxt.Text;
                user.UserPassword = Passtxt.Text;
                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("congrats!");
                this.NavigationService.Navigate(new HomeMovie());
            }

            else
            {
                MessageBox.Show("user already exists");
            }
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Login());

        }
    }
}
