using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
        }
        MoviesEntities db = new MoviesEntities();
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int year = int.Parse(YearTextBox.Text);
            var movie = db.Movies.Where(x => x.MovieName == MovieNameTextBox.Text && x.Categoty == CategoryTextBox.Text && x.Producer == ProducerTextBox.Text && x.MovieYear == year).Select(x => new { x.MovieID, x.MovieName, x.Categoty }).ToList();
            MoviesDataGrid.ItemsSource = movie;
            if (movie != null)
            {
                Movy moviee = new Movy();
                moviee.MovieName = MovieNameTextBox.Text;
                moviee.Categoty = CategoryTextBox.Text;
                moviee.Producer = ProducerTextBox.Text;
                moviee.MovieYear = year;
                db.Movies.Add(moviee);
                db.SaveChanges();
                MessageBox.Show("Movie Added!");
                MoviesDataGrid.ItemsSource = movie;
                var movieList = db.Movies.Select(x => new{x.MovieID,x.MovieName,x.Categoty,x.Producer,x.MovieYear}).ToList();
                MoviesDataGrid.ItemsSource = movieList;

            }
            else
            {
                MessageBox.Show("This Movie Already Exists");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
