using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieStore
{
    class LoadData
    {
        /// <span class="code-SummaryComment"><summary></span>
        /// Load the current movie into the form
        /// <span class="code-SummaryComment"></summary></span>
        public void LoadCurrentMovie(TextBox textBox1, TextBox textBox2, DateTimePicker dateTimePicker, MovieData currentMovie)
        {
            try
            {
                textBox1.Text = currentMovie.Title;
                textBox2.Text = currentMovie.Director;
                dateTimePicker.Value = currentMovie.ReleaseDate;
            }
            catch { }
        }
    }
}
