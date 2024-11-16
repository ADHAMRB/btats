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
    /// Interaction logic for ForgetPassword.xaml
    /// </summary>
    public partial class ForgetPassword : Page
    {
        public ForgetPassword()
        {
            InitializeComponent();
        }
        private void ResetPassword_Click(object sender, RoutedEventArgs e)
        {
            MoviesEntities db = new MoviesEntities();
            var rec = db.Users.FirstOrDefault(x => x.UserEmail == Emailtxt.Text);
            if (rec != null)
            {
                
                rec.UserPassword = NewPasstxt.Text;
                db.Users.AddOrUpdate(rec);
                db.SaveChanges();
                MessageBox.Show("done!");
                this.NavigationService.Navigate(new Login());
            }
            else
            {
                MessageBox.Show("Email doesnt exist ya 5owl");
            }
        }
    }
}
