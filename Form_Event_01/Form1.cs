using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Event_01
{
    public partial class Form1 : Form
    {

        int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = this.dateTimePicker1.Value.ToLongDateString();
            counter++;
            label1.Text += "   " + counter;
        }
    }
}
