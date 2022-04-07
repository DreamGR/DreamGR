using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitnikSQLApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            this.closeButton.ForeColor = Color.Green;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            this.closeButton.ForeColor = Color.White;
        }

        Point point;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            VidWorkForm VidWForm = new VidWorkForm();
            VidWForm.Show();
        }
    } 
}
