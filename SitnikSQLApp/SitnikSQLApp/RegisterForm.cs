using MySql.Data.MySqlClient;
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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            userNameField.Text = "Введите имя";
            userNameField.ForeColor = Color.IndianRed;

            userNameField1.Text = "Введите фамилию";
            userNameField1.ForeColor = Color.IndianRed;

            passField.Text = "Введите логин";
            passField.ForeColor = Color.IndianRed;

            passField1.Text = "Введите пароль";
            passField1.ForeColor = Color.IndianRed;
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

        Point lastPoint;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите имя")
            {
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;
            }
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Введите имя";
                userNameField.ForeColor = Color.IndianRed;
            }
        }

        private void userNameField1_Enter(object sender, EventArgs e)
        {
            if (userNameField1.Text == "Введите фамилию")
            {
                userNameField1.Text = "";
                userNameField1.ForeColor = Color.Black;
            }
        }

        private void userNameField1_Leave(object sender, EventArgs e)
        {
            if (userNameField1.Text == "")
            {
                userNameField1.Text = "Введите фамилию";
                userNameField1.ForeColor = Color.IndianRed;
            }
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Введите логин")
            {
                passField.Text = "";
                passField.ForeColor = Color.Black;
            }
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "")
            {
                passField.Text = "Введите логин";
                passField.ForeColor = Color.IndianRed;
            }
        }

        private void passField1_Enter(object sender, EventArgs e)
        {
            if (passField1.Text == "Введите пароль")
            {
                passField1.Text = "";
                passField1.ForeColor = Color.Black;
            }
        }

        private void passField1_Leave(object sender, EventArgs e)
        {
            if (passField1.Text == "")
            {
                passField1.Text = "Введите пароль";
                passField1.ForeColor = Color.IndianRed;
            }
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {

            if (userNameField.Text == "Введите имя")
            {
                MessageBox.Show("Введите имя");
                return; 
            }

            if (userNameField1.Text == "")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }

            if (checkUser())
                return;
            DBS dbs = new DBS();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`id`, `login`, `pass`, `name`, `surname`) VALUES (NULL, @login, @pass, @name, @surname);", dbs.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = passField.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passField1.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userNameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userNameField1.Text;

            dbs.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт был создан");
            else
                MessageBox.Show("Аккаунт не был создан");

            dbs.closeConnection();
        }

        public Boolean checkUser()
        {
            DBS db = new DBS();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL ", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = passField.Text;


            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже есь введите другой!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lgForm = new LoginForm();
            lgForm.Show();
        }
    }
}
