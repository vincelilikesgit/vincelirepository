using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieStore
{
    class PopulateData
    {
        /// <span class="code-SummaryComment"><summary></span>
        /// Thie method stores user input data to the current movie object
        /// <span class="code-SummaryComment"></summary></span>
        public void populate(TextBox textBox1, TextBox textBox2, DateTimePicker dateTimePicker, MovieData currentMovie)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    currentMovie.Title = textBox1.Text;
                    currentMovie.Director = textBox2.Text;
                    currentMovie.ReleaseDate = dateTimePicker.Value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" You have to input the Title before saving "
                        + "the current movie entry!");
                }
            }
        }
    }
}
