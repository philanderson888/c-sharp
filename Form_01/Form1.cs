using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            n++;
            button1.Text = "Clicked " + n + " . . . " + n%3;
            if (n%3 == 0)
            {
                tabPage1.Text = n.ToString();
                tabPage1.Show();
                tabPage2.Hide();
            }
            else if (n % 3 == 1)
            {
                tabPage2.Text = n.ToString();
                tabPage2.Show();
                tabPage1.Hide();
                
            }
            else if (n % 3 == 2)
            {
                tabPage3.Text = n.ToString();
                tabPage1.Hide();
                tabPage2.Hide();
                tabPage3.Show();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
