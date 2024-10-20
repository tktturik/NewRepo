using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            bool isAuth = false;

            foreach (string pair in File.ReadAllLines("C:\\Users\\tkturik\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\Users.txt"))
            {
                string[] d = pair.Split(' ');
                if (d[0] == login && d[1] == password)
                {
                    isAuth = true;
                }
            }
            if (isAuth)
            {
                MessageBox.Show("Успешный вход");
                Form1 d = new Form1(login);
                d.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
