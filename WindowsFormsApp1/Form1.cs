using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string value2 ;
        int trying;
        List<string> history;
        string path;
        string login;


        public Form1(string login)
        {
            InitializeComponent();
            path = $"{Environment.CurrentDirectory}\\file.txt";
            value2 = GenerateDigit();
            label1.Text = "число сгенерировано";
            LoadToListView();
            trying = 0;
            this.login = login;

        }
        public void LoadToListView()
        {
            listView1.Items.Clear();
            LoadText();
            foreach (var v in history)
            {
                listView1.Items.Add(v);
            }
        }
        private void LoadText()
        {

            if (File.Exists(path))
            {
                if(history != null)
                {
                    history.Clear();
                }
                history = File.ReadAllLines(path).ToList<string>();
            }
            else
            {
                history = new List<string>();
            }
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
           
            string value = textBox1.Text;
            Console.WriteLine(value);
            Check check = new Check(value2);
            label1.Text = check.CheckDigit(value);
            trying++;
            listView2.Items.Add(value);
            if (label1.Text == "Pobeda")
            {
                history.Add($"{login}: Попытки {trying} на число {value2}");
                File.WriteAllText(path, ListToString(history));
                LoadToListView();
                label1.Text += " новое число сгенерировано";
                value2 = GenerateDigit();
                trying = 0;
                listView2.Items.Clear();
            }


        }
        private string ListToString(List<string> h) {
            StringBuilder sb = new StringBuilder();
            foreach(string s in h)
            {
                sb.Append(s+"\n");
            }
            return sb.ToString();
        }
        private string GenerateDigit()
        {
            Random random = new Random();
            string result = "";
            int i = 0;
            while (i < 4) { 
                string digit = random.Next(0, 10).ToString();
                if (!SymbolInDigit(result, digit)) { result += digit; i++; }
            }
            return result;
            
        }
        private bool SymbolInDigit(string dd, string s)
        {
            foreach(char c in dd)
            {
                if(Convert.ToChar(s) == c)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
