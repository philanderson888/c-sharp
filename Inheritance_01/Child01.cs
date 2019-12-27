using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inheritance_01
{
    public partial class Child01 : Inheritance_01.Parent
    {
        public Child01()
        {
            InitializeComponent();
        }

        private void child1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parent p = new Parent();
            p.Visible = true;
        }
    }
}
