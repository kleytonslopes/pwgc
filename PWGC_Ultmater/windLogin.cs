using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engine.Entities;
using Engine;
using System.Configuration;
using System.Xml;

namespace PWGC_Ultmater
{
    public partial class windLogin : Form
    {
        int eastereggscountclick;
        public windLogin()
        {
            InitializeComponent();
        }

        private void windLogin_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.gclogoicon;
            try
            {
                //SysLogin.LoadFile(textBox1, textBox2);
                textBox1.Text = ConfigurationSettings.AppSettings["Login"];
                textBox2.Text = ConfigurationSettings.AppSettings["Password"];

            }
            catch (Exception)
            {
                //SysLogin.GeraArquivo();
            }


        }
        private void windLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void windLogin_Click(object sender, EventArgs e)
        {
            eastereggscountclick += 1;
            if (eastereggscountclick > 5)
            {
                
                ProcessConsole.ProcessEasterEggs();
                eastereggscountclick = 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Digite um Login!");
                ProcessConsole.ProcessInformation("Digite um Login!");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Digite uma Senha!");
                ProcessConsole.ProcessInformation("Digite uma Senha!");
                return;
            }


            IList<User> lista;
            lista = User.GetUserByLoginPassword(textBox1.Text, textBox2.Text);

            if (lista == null) 
            {
                ProcessConsole.ProcessInformation("Usuário ou Senha Incorreto!");
                return;
            }
            GlobalPermission.SetPermission();

            
            if (GlobalSystem.usuario != null)
            {
                ProcessConsole.ProcessDone("Sistema Destravado!");

                Configuration config =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["Login"].Value = textBox1.Text;
                config.AppSettings.Settings["Password"].Value = textBox2.Text;
                config.Save(ConfigurationSaveMode.Modified);

                ProcessConsole.ProcessInformation("Usuário e Senha salvo no Sistema!");

                this.Hide();

            }
            else
            {
                ProcessConsole.ProcessInformation("Usuario ou Senha Incorretos!");
                MessageBox.Show("Usuario ou Senha Incorretos!");

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void timerChecker_Tick(object sender, EventArgs e)
        {
            if (Connection.session == null)
            {
                ProcessConsole.ProcessInformation("Central Não Conectada! Reinicie o Sistema.");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            windRegisterUser form = new windRegisterUser();
            form.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                if (!string.IsNullOrEmpty(textBox2.Text)) 
                {
                    button1.Focus();
                }
                else 
                {
                    textBox2.Focus();
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    button1.Focus();
                }
                else
                {
                    textBox1.Focus();
                }
            }
        }
    }
}
