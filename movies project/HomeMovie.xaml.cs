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
    /// Interaction logic for HomeMovie.xaml
    /// </summary>
    public partial class HomeMovie : Page
    {
        public HomeMovie()
        {
            InitializeComponent();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            MoviesEntities db = new MoviesEntities();
            if (Combo.Text == null || Combo.Text == "All")
            {
                var movie = db.Movies.Select(x => new { x.MovieID, x.MovieName, x.Categoty }).ToList();
                MoviesDataGrid.ItemsSource = movie;
            }
            else
            {
                var movie = db.Movies.Where(x => x.Categoty == Combo.Text).Select(x => new { x.MovieID, x.MovieName, x.Categoty }).ToList();
                MoviesDataGrid.ItemsSource = movie;
            }
        }
        private void Show_Click(object sender, RoutedEventArgs e)
        {
            MoviesEntities db = new MoviesEntities();
            var id = int.Parse(IdTextBox.Text);
            var movie = db.Movies.FirstOrDefault(x => x.MovieID == id );
            if (movie != null)
            {
                this.NavigationService.Navigate(new MOVIEDETAIL(id));
            }
            else
            {
                MessageBox.Show("ID not found");
            }
        }
    }
}
