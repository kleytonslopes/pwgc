using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWGC_Ultmater
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.gclogoicon;

        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            label1.Text = "PWGC Ultimater. Versão: "+ Assembly.GetExecutingAssembly().GetName().Version.ToString();

        }
    }
}
