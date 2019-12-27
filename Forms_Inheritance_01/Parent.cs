using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms_Inheritance_01
{
    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();


            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parent Label";
            this.label1.BackColor = Color.Aquamarine;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 531);
            this.BackColor = Color.AliceBlue;
            this.Name = "Parent From Text";
            this.Text = "Parent From Text";
            this.ResumeLayout(false);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Child2 childForm = new Child2();
            childForm.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Parent parentForm = new Parent();
            parentForm.Show();
            this.Hide();

       
        }
    }
}
