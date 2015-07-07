using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieStore
{
    /// <span class="code-SummaryComment"><summary></span>
    /// Helper method to Open an existing movie data file
    /// <span class="code-SummaryComment"></summary></span>
    class OpenHandler
    {
        public List<MovieData> open(string currentFilePath, List<MovieData> movies, bool dirtyForm, 
            TextBox textBox1, TextBox textBox2, DateTimePicker dateTimePicker, MovieData currentMovie)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Title = "Open MOVIE Document";
            OpenFileDialog1.Filter = "MOVIE Documents (*.movie)|*.movie";
            if (OpenFileDialog1.ShowDialog() ==
            System.Windows.Forms.DialogResult.Cancel)
            {
                return null;
            }

            currentFilePath = OpenFileDialog1.FileName;
            if (String.IsNullOrEmpty(currentFilePath))
            {
                return null;
            }

            if (System.IO.File.Exists(currentFilePath) == false)
            {
                return null;
            }

            movies = FileSerializer.Deserialize(currentFilePath);

            // Load movie at position zero
            if (movies != null)
            {
                currentMovie = movies.ElementAt<MovieStore.MovieData>(0);
                LoadData ld = new LoadData();
                ld.LoadCurrentMovie(textBox1, textBox2, dateTimePicker, currentMovie);
                dirtyForm = false;
            }

            return movies;
        }
    }
}
