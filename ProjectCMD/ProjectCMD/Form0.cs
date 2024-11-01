using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCMD
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 changeform1 = new Form1();
            changeform1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
