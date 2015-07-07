using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieStore
{
    /// <span class="code-SummaryComment"><summary></span>
    /// Clear all form fields
    /// <span class="code-SummaryComment"></summary></span>
    class ClearData
    {
        public void clear(TextBox textBox1, TextBox textBox2, DateTimePicker dateTimePicker, bool dirtyForm)
        {
            dirtyForm = false;

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            dateTimePicker.Value = DateTime.Now;
        }
    }
}
