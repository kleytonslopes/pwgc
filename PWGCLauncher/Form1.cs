using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Diagnostics;

namespace PWGCLauncher
{
    public partial class Form1 : Form
    {
        WebClient webClient;

        Uri uriexe = new Uri("<exe.link>");
        public string exename = @"\PWGC_Ultmater.exe";
        Uri uriengdll = new Uri("<Engine.dll.link>");
        public string engdllname;
        public Form1()
        {

            InitializeComponent();
            ProcessConsole.AllocConsole();
            workerDownloader.WorkerReportsProgress = true;
            workerDownloader.WorkerSupportsCancellation = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            engdllname = Path.GetDirectoryName(Application.ExecutablePath) + "\\Engine.dll";
            try
            {
                if (File.Exists(engdllname))
                {
                    MessageBox.Show("Arquivo Existente");
                }
                else
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFileAsync(uriengdll, engdllname);
                    wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(workerDownloader_ProgressChanged);
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(downloadComplet);
                }
            }

            catch (Exception erro)
            {
                Console.WriteLine(erro.ToString());
            }


            if (workerDownloader.IsBusy != true) 
            {
                workerDownloader.RunWorkerAsync();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void workerDownloader_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void downloadComplet(object sender, AsyncCompletedEventArgs e) 
        {
            if (e.Error == null) 
            {
                Console.WriteLine("download");
                //Process.Start("Dile.exe");
            }
            if (e.Error != null)
            {
                Console.WriteLine("Erro no download");
            }
        }

        private void workerDownloader_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage.ToString() + "%");
        }

        private void workerDownloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                Console.WriteLine("Canceled!");
            }
            else if (e.Error != null)
            {
                 Console.WriteLine( "Error: " + e.Error.Message);
            }
            else
            {
                 Console.WriteLine("Done!");
            }
        }
    }
}
