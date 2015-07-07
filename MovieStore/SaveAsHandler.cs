using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieStore
{
    /// <span class="code-SummaryComment"><summary></span>
    /// Save the existing movie data file with
    /// a new file name
    /// <span class="code-SummaryComment"></summary></span>
    /// <span class="code-SummaryComment"><param name="sender"></param></span>
    /// <span class="code-SummaryComment"><param name="e"></param></span>
    class SaveAsHandler
    {
        public void saveAs(string currentFilePath, List<MovieData> movies, bool dirtyForm)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();

            try
            {
                SaveFileDialog1.Title = "Save MOVIE Document";
                SaveFileDialog1.Filter = "MOV Documents (*.movie)|*.movie";

                if (SaveFileDialog1.ShowDialog() ==
                       System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
            }
            catch
            {
                return;
            }

            currentFilePath = SaveFileDialog1.FileName;

            if (String.IsNullOrEmpty(currentFilePath))
            {
                return;
            }

            FileSerializer.Serialize(currentFilePath, movies);

            MessageBox.Show("File " + currentFilePath + " saved.", "File Saved.");

            dirtyForm = false;
        }
    }
}
