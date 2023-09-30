using Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWGC_Ultmater
{
    public partial class windClientConfig : Form
    {
        public windClientConfig()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SysLog"].Value = txtSafe.Text;
            config.AppSettings.Settings["Password"].Value = txtPass.Text;
            config.AppSettings.Settings["Login"].Value = txtLogin.Text;
            config.AppSettings.Settings["SRC"].Value = txtSRC.Text;
            config.AppSettings.Settings["GCCode"].Value = txtToken.Text;
            config.Save(ConfigurationSaveMode.Modified);

            ProcessConsole.ProcessInformation("Configurações do Sistema Salvo! o Sistema vai Reiniciar...");
            MessageBox.Show("Configurações do Sistema Salvo! \nO Sistema vai Reiniciar.");
            Application.Restart();
        }

        private void windClientConfig_Load(object sender, EventArgs e)
        {
            txtID.Text = GlobalSystem.GetMACAddress();
            txtLogin.Text = ConfigurationSettings.AppSettings["Login"];
            txtPass.Text = ConfigurationSettings.AppSettings["Password"];
            txtSRC.Text = ConfigurationSettings.AppSettings["SRC"];
            txtToken.Text = ConfigurationSettings.AppSettings["GCCode"];
            txtSafe.Text = ConfigurationSettings.AppSettings["SysLog"];
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Função Indisponivel nesta Versão!", "PWGC - Informação");
        }
    }
}
