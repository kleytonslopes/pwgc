using Engine.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWGC_Ultmater
{
    public partial class windRegisterUser : Form
    {
        public windRegisterUser()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.gclogoicon;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Formato Inválido para Login!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Formato Inválido para Senha!");
                return;
            }
            else 
            {
                if (txtSenha.Text != txtSenhaN.Text)
                {
                    MessageBox.Show("Senhas Diferentes!");
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(txtNick.Text))
            {
                MessageBox.Show("Formato Inválido para Nick!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Formato Inválido para Email!");
                return;
            }

            User u = new User();

            u.Login = txtLogin.Text;
            u.Password = txtSenha.Text;
            u.Nick = txtNick.Text;
            u.Email = txtEmail.Text;
            u.Permission = 1;
            u.LastLogin = DateTime.Now;
            u.Blocked = "N";

            User.Insert(u);
        }
    }
}
