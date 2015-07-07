using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieStore
{
    /// <span class="code-SummaryComment"><summary></span>
    /// A helper method for checking if there is already existing 
    /// an movie entry duplicate before persist the current movie
    /// <span class="code-SummaryComment"></summary></span>
    class DuplicateData
    {
        public bool Check(List<MovieData> movies, MovieData movie)
        {
            try
            {
                foreach (MovieData mov in movies)
                {
                    if (mov.Director.Equals(movie.Director) && mov.Title.Equals(movie.Title))
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" You have to input the Title before saving " 
                    + "the current movie entry!");
                return false;
            }
        }
    }
}
