using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitnikSQLApp
{
    public partial class VidWorkForm : Form
    {
        public VidWorkForm()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            DBS dbs = new DBS();


            dbs.openConnection();


            MySqlCommand command = new MySqlCommand("SELECT * FROM `VidiWork` ORDER BY id", dbs.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[3]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
            }

            reader.Close();

            dbs.closeConnection();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm = new MainForm();
            MainForm.Show();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            this.closeButton.ForeColor = Color.Green;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            this.closeButton.ForeColor = Color.White;
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            this.label3.ForeColor = Color.Green;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            this.label3.ForeColor = Color.White;
        }
    }
}
