using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Passwood
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public enum operation
        {
            not_set,
            login,
            reset,
            clear,
            register
        }
        public operation oprt = operation.not_set;
        public bool register = false;
        public string recoverq = "";
        public string password = "";
        public string answerda = "";
        public byte[] encpaswd;
        private void Login_Load(object sender, EventArgs e)
        {
            if (register)
            {
                Securityq.Text = "";
                this.Controls.Remove(Logn);
                this.Controls.Remove(recv);
                this.Controls.Remove(button1);
            }
            else
            {
                label1.Text = "Enter Password";
                Securityq.Text = "Security question : " + recoverq;
                this.Controls.Remove(Securityt);
                this.Controls.Remove(labl);
                this.Controls.Remove(CFM);
                this.Controls.Remove(reg);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PWD.UseSystemPasswordChar)
            {
                shide.Text = "Hide";
                PWD.UseSystemPasswordChar = false;
            }
            else
            {
                shide.Text = "Show";
                PWD.UseSystemPasswordChar = true;
            }
        }

        private void reg_Click(object sender, EventArgs e)
        {
            if (PWD.Text != CFM.Text)
            {
                MessageBox.Show("Failed to confirm");
                return;
            }
            if (PWD.Text.Length == 0)
            {
                MessageBox.Show("Enter a password");
                return;
            }
            if (Securityt.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                if (MessageBox.Show("If you don't set a security question and answer you can not recover your entries if you forgot your password.", "Passwood", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
            }
            password = PWD.Text;
            recoverq = Securityt.Text;
            answerda = textBox2.Text;
            oprt = operation.register;
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            oprt = operation.clear;
            this.Close();
        }

        private void recv_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                answerda = textBox2.Text;
                oprt = operation.reset;
                this.Close();
            }
            else{
                MessageBox.Show("Enter your security questions answer");
            }
        }

        private void Logn_Click(object sender, EventArgs e)
        {
            if (PWD.Text.Length > 0)
            {
                password = PWD.Text;
                oprt = operation.login;
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter your password");
            }
        }
    }
}
