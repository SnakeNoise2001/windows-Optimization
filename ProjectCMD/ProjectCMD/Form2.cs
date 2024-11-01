using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCMD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/C shutdown -r -t 0");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 changeform1 = new Form1();
            changeform1.Show();
            this.Hide();
        }
    }
}
