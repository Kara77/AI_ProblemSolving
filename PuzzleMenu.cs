using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_ProblemSolving
{
    public partial class PuzzleMenu : Form
    {
        public PuzzleMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose the problem and the algorithm !";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // PuzzleMenu
            // 
            this.ClientSize = new System.Drawing.Size(642, 555);
            this.Controls.Add(this.label1);
            this.Name = "PuzzleMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
