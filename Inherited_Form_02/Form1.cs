using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inherited_Form_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void parentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            f.Show();
        }

        private void childToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var g = new InheritedForm();
            g.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            g.Show();
        }
    }
}
