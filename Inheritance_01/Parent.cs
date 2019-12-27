using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inheritance_01
{
    public partial class Parent : Form
    {


        public Parent()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void child01ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Child01 c = new Child01();


            c.Visible = true;
        }

        private void parentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parent p = new Parent();
            p.Visible = true;

        }
    }
}
