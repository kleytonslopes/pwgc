using NHibernate;
using System;
using System.Reflection;
using System.Windows.Forms;
using Engine;
using Engine.Entities;
using PWGC_Ultmater;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Configuration;

namespace PWGC_Ultimater
{
    public partial class windPWGC : Form
    {

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeConsole();

        //bool console = ProcessConsole.AllocConsole();
        SplashScreen frms = new SplashScreen();
        ISession session = null;
        bool console = false;
        

        public windPWGC()
        {
            InitializeComponent();
            frms.Show();
            //ProcessConsole.AllocConsole();
            string consoles = ConfigurationSettings.AppSettings["SysLog"];
            string debugkey = ConfigurationSettings.AppSettings["SRC"];
            string debugmod = ConfigurationSettings.AppSettings["GCCode"];
            string myToken = Tank.Generate(GlobalSystem.GetMACAddress());
           // if (consoles.Equals("1"))
           // {
           //     if(Tank.Retrive(debugkey) == GlobalSystem.GetMACAddress())
           //     {
           //         if(Tank.Retrive(debugmod) == "Hubalu")
           //         {
                        AllocConsole();
                        ProcessConsole.ProcessMessage("Console Ativado!");
           //         }
           //     }
           // }

            ProcessConsole.ProcessMessage( GlobalSystem.GetMACAddress());
            //usar futuramente pra criar arquivos
            //MakeFile.CriarArquivo();

            
        }    


        private void windPWGC_Load(object sender, EventArgs e)
        {


            Splash();

            lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            
            if(GlobalSystem.config == null)
            {
                ProcessConsole.ProcessBreak("Configurações não Carregadas Corretamente. O Sistema entrou em colapso e precisa ser Reiniciado!");
                DialogResult result = MessageBox.Show("Configurações não Carregadas Corretamente ou Servidor estava Fora.\nO Sistema entrou em colapso e precisa ser Reiniciado!", "PWGC - Erro", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                    Application.Restart();
                else
                    Application.Exit();

                return;
            }

            foreach (Config c in GlobalSystem.config)
            {
                GlobalSystem.cfg.Add(c);
            }
            if (GlobalSystem.cfg.Count <= 0) 
            {
                MessageBox.Show("Configurações não Inicializadas.\nEsta Aplicação sera finalizada, por gentileza retornar em alguns minutos.", "PWGC - Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

            #region Checa Versao
            if (GlobalSystem.cfg[0].ID == 1)
            {
                if (GlobalSystem.cfg[0].Description != lblVersion.Text)
                {
                    ProcessConsole.ProcessInformation("Sistema Desatualizado, não é aconselhável\ncontinuar para isso iremos finalizar o processo desta versão!\nPor favor Verifique se não há um novo Link para download, caso\nnão encontre um Link contacte um Adiministrador!");
                    MessageBox.Show("Sistema Desatualizado!\nNova Versão Encontrada: " + GlobalSystem.cfg[0].Description + "\n\nEsta Aplicação sera finalizada e você será Redirecionado a Página de Download!\nSolicite um novo Link caso o redirecionamento não Funcione!", "PWGC - Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(GlobalSystem.cfg[1].Description);
                    Application.Exit();
                }

            }
            #endregion

            #region Checa Download Opcional
            if (GlobalSystem.cfg[3].ID == 9)
            {
                if (GlobalSystem.cfg[3].Description != lblVersion.Text && GlobalSystem.cfg[3].Target == "M")
                {
                    ProcessConsole.ProcessInformation("Sistema Desatualizado, não é aconselhável\ncontinuar e tambem esta não é obrigatória.\nPor favor Verifique se não há um novo Link para download, caso\nnão encontre um Link contacte um Adiministrador!");
                    
                    DialogResult result = MessageBox.Show("Sistema Desatualizado!\nNova Versão Encontrada: " + GlobalSystem.cfg[3].Description + "\n\nDeseja ser Redirecionado a Página de Download?\nSolicite um novo Link caso o redirecionamento não Funcione!", "PWGC - Informação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                        System.Diagnostics.Process.Start(GlobalSystem.cfg[4].Description);
                }

            }
            #endregion

            #region Chega Maximo de Dias
            if (GlobalSystem.cfg[6].ID == 12)
            {
                GlobalSystem.MaxDayToInactive = Convert.ToInt32(GlobalSystem.cfg[6].Description);
            }
            #endregion

            #region Checa Minimo de Mérito
            if (GlobalSystem.cfg[2].ID == 3) 
            {
                GlobalSystem.MinMeritTolerance = Convert.ToInt32(GlobalSystem.cfg[2].Description);
            }
            #endregion

            ProcessConsole.ProcessMessage("Aguardando Autenticação do usuario!");
            windLogin frm = new windLogin();
            frm.ShowDialog(this);

            if (GlobalSystem.usuario == null)
            {
                Application.Exit();
                return;
            }
            else
            {

                tsslbUser.Text = GlobalSystem.usuario.Nick;
                tsslUserId.Text = GlobalSystem.usuario.ID.ToString();

                #region Permissoes aos Componentes
                #region MenuStrip
                ControlModifier.ControlPermission(tsmiPersonCadastrar, 0);
                ControlModifier.ControlPermission(tsmiCharacterUpdate, 44);
                ControlModifier.ControlPermission(verificarToolStripMenuItem, 2);
                ControlModifier.ControlPermission(administraçãoToolStripMenuItem, 90);
                ControlModifier.ControlPermission(usuarioToolStripMenuItem1, 91);
                ControlModifier.ControlPermission(personagemToolStripMenuItem1, 92);
                ControlModifier.ControlPermission(eventosToolStripMenuItem, 93);
                ControlModifier.ControlPermission(sistemaToolStripMenuItem, 94);
                ControlModifier.ControlPermission(globalToolStripMenuItem, 95);

                //if(GlobalPermission.permissionIndex[90])
                //    ProcessConsole.AllocConsole();

                #endregion
                #endregion
            }
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            SFX.MouseEnter();
        }

        public void Splash()
        {

            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);

            workerThread.Start();

            while (!workerThread.IsAlive);

            Thread.Sleep(100);

            workerObject.RequestStop();

            workerThread.Join();
            frms.Close();
        }

        private void tsmiPersonCadastrar_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            windCadCharacter form = new windCadCharacter();
            form.MdiParent = this;
            form.Show();
        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            windUpdateCharacter form = new windUpdateCharacter();
            form.MdiParent = this;
            form.Show();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            windUserAdmin form = new windUserAdmin();
            //form.MdiParent = this;
            form.Show();
        }

        private void personagemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            windEditAdminCharacter form = new windEditAdminCharacter();
            form.Show();
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string myKey = Tank.Generate(GlobalSystem.GetMACAddress());

            Configuration config =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["SRC"].Value = GlobalSystem.GetMACAddress();
            config.Save(ConfigurationSaveMode.Modified);
        }
        
        private void sistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            windConfig form = new windConfig();
            form.Show();
        }

        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void méritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            windEventMerit form = new windEventMerit();
            form.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       private void configuraçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            windClientConfig form = new windClientConfig();
            form.ShowDialog();
        }
    }

}
