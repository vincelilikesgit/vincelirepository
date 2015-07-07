using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieStore
{
    /// <span class="code-SummaryComment"><summary></span>
    /// This form class is used to display all of the
    /// current movies in a sorted data grid view control.
    /// 
    /// NOTE: sorteddatagridview.dll is an 3rd party library for sorting functionality
    /// User can click on any column header to sort the movie list either ASC or DESC
    /// <span class="code-SummaryComment"></summary></span>
    public partial class Form2 : Form
    {
        List<MovieData> movies;
        /// <span constructor="code-SummaryComment"><summary></span>
        /// This form class is used to display all of the
        /// current movies in a sorted data grid view control.
        /// <span constructor="code-SummaryComment"></summary></span>
        public Form2(List<MovieData> md)
        {
            InitializeComponent();
            PopulateGrid(md);
            movies = md;
           
        }

        private void sortedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <span method="code-SummaryComment"><summary></span>
        /// This private method populates all the movie in the .movie file
        /// to a sorteddatagridview.
        /// <span method="code-SummaryComment"></summary></span>
        private void PopulateGrid(List<MovieData> md)
        {
            foreach (MovieData Movie in md)
            {
                int rowNum = sortedDataGridView1.Rows.Add(new object[] {Movie.Title,
                    Movie.Director, Movie.ReleaseDate});
                sortedDataGridView1.Rows[rowNum].Tag = Movie;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            filter_helper();
        }
        /// <span method="code-SummaryComment"><summary></span>
        /// This private method filters all the movie in the .movie file
        /// to a sorteddatagridview according to textbox control 1.
        /// <span method="code-SummaryComment"></summary></span>
        private void filter_helper()
        {
            List<MovieData> myList = movies;
            // This will filter out the list of movies that are not in the textbox control, "Where" returns an
            // IEnumerable<T> so a call to ToList is required to convert back to a List<T>.
            List<MovieData> filteredList = myList.Where(x => x.Title.ToString().Contains(textBox1.Text)).ToList();
            sortedDataGridView1.Rows.Clear();
            PopulateGrid(filteredList);
        }
    }
}
