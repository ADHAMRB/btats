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
    /// Interaction logic for MOVIEDETAIL.xaml
    /// </summary>
    public partial class MOVIEDETAIL : Page
    {
        MoviesEntities db = new MoviesEntities();
        int idd;
        public MOVIEDETAIL(int id)
        {
            InitializeComponent();
            idd = id;
            var moviesss = db.Movies.First(x => x.MovieID == id);
            this.DataContext = moviesss;
        }
    }
}
