using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MovieStore
{
    /// <span class="code-SummaryComment"><summary></span>
    /// A simple project used to maintain data about a
    /// collection of movies, and to
    /// display that data to the user, persist the data,
    /// and allow the user to retrieve the
    /// data without using a database.
    /// <span class="code-SummaryComment"></summary></span>
    public partial class Form1 : Form
    {
        #region Variable Declarations

        private List<MovieData> movies;   // a container for the movie collection
        MovieData currentMovie;           // the current movie (displayed)
        string currentFilePath;         // the path to the movie data file
        int currentPosition;            // the position within the movie list
        bool dirtyForm;                 // mark the form dirty when changed

        #endregion

        #region Constructor

        /// <span class="code-SummaryComment"><summary></span>
        /// constructor initializes movie list and
        /// defaults values
        /// <span class="code-SummaryComment"></summary></span>
        public Form1()
        {
            InitializeComponent();

            // create new movie data list
            // ready to write data
            movies = new List<MovieData>();
            currentMovie = new MovieData();

            // set the date time pickers to now
            dateTimePicker1.Value = DateTime.Now;

            // init current position to zero
            currentPosition = 0;

            // mark form as not dirty
            dirtyForm = false;
        }

        #endregion

        #region Housekeeping

        /// <span class="code-SummaryComment"><summary></span>
        /// The exit tool bar item Exit the application
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="sender"></param></span>
        /// <span class="code-SummaryComment"><param name="e"></param></span>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dirtyForm == true)
            {
                if (MessageBox.Show(this, "You have not saved the current movie data; would you like to save before exiting?", "Save Current Data",
                  MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(this, new EventArgs());
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }

        }
 
        /// <span class="code-SummaryComment"><summary></span>
        /// Create a new movie data file, .movie, that stores movie entries
        /// which will be keyed in by user one by one
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="sender"></param></span>
        /// <span class="code-SummaryComment"><param name="e"></param></span>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dirtyForm == true)
            {
                if (MessageBox.Show(this, "You have not saved the current movie data; would you like to save before starting a new "
                                 + "movie database?", "Save Current Data",
                    MessageBoxButtons.YesNo) ==
                    System.Windows.Forms.DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(this, new EventArgs());
                }
                else
                {
                    // discard and start new document
                    movies = new List<MovieData>();
                    ClearData cd = new ClearData();
                    cd.clear(textBox1, textBox2, dateTimePicker1, dirtyForm);
                }
            }
            else
            {
                // start new document
                movies = new List<MovieData>();
                ClearData cd = new ClearData();
                cd.clear(textBox1, textBox2, dateTimePicker1, dirtyForm);
            }
        }
        
        /// <span class="code-SummaryComment"><summary></span>
        /// Open an existing movie data file which contains all the movie entries
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="sender"></param></span>
        /// <span class="code-SummaryComment"><param name="e"></param></span>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dirtyForm == true)
            {
                if (MessageBox.Show(this, "You have not saved the current movie data; "
                + "would you like to save before opening a different " +
                "movie database?", "Save Current Data", MessageBoxButtons.YesNo) ==
                     System.Windows.Forms.DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(this, new EventArgs());
                }
                else
                {
                    OpenHandler oh = new OpenHandler();
                    movies = oh.open(currentFilePath, movies, dirtyForm, textBox1, 
                        textBox2, dateTimePicker1,  currentMovie);
                }
            }
            else
            {
                OpenHandler oh = new OpenHandler();
                movies = oh.open(currentFilePath, movies, dirtyForm, textBox1,
                    textBox2, dateTimePicker1, currentMovie);
            }
        }
 
        /// <span class="code-SummaryComment"><summary></span>
        /// Save the existing movie data file with
        /// a new file name
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="sender"></param></span>
        /// <span class="code-SummaryComment"><param name="e"></param></span>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsHandler sah = new SaveAsHandler();
            sah.saveAs(currentFilePath, movies, dirtyForm);
        }

        #endregion

        #region Movie Data Management
        
        /// <span class="code-SummaryComment"><summary></span>
        /// List all of the movies in the movie
        /// data file
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="sender"></param></span>
        /// <span class="code-SummaryComment"><param name="e"></param></span>
        /// 
        private void listAllMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form2 f = new Form2(movies);
            f.Show();            
        }
        
        /// <span class="code-SummaryComment"><summary></span>
        /// Adds one movie to the movie list file
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="sender"></param></span>
        /// <span class="code-SummaryComment"><param name="e"></param></span>
        /// 
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            
            currentMovie = new MovieData();
            PopulateData pd = new PopulateData();
            pd.populate(textBox1, textBox2, dateTimePicker1, currentMovie);

            ClearData cd = new ClearData();
            cd.clear(textBox1, textBox2, dateTimePicker1, dirtyForm);
            DuplicateData dd = new DuplicateData();

            if (!dd.Check(movies , currentMovie))
            {
                movies.Add(currentMovie);//Add current movie to the List object
            }
            dirtyForm = true;
        }
        
        #endregion

        #region Dirty the Form

        /// <span class="code-SummaryComment"><summary></span>
        /// Dirty the form if the user enters text into
        /// the movie name textbox
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="sender"></param></span>
        /// <span class="code-SummaryComment"><param name="e"></param></span>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dirtyForm = true;
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Dirty the form if the user enters text into
        /// the Director textbox
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="sender"></param></span>
        /// <span class="code-SummaryComment"><param name="e"></param></span>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dirtyForm = true;
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Dirty the form if the user picks a date from the
        /// control
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="sender"></param></span>
        /// <span class="code-SummaryComment"><param name="e"></param></span>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dirtyForm = true;
        }

        #endregion

    }
}
