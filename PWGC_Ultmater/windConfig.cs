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
    public partial class windConfig : Form
    {
        IList<Config> configs;
        Config cfg;
        public windConfig()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //cfg.ID       = textBox1.Text ;

            cfg = new Config();
            cfg.Description         = txtCondition.Text ;
            cfg.Code                = txtParam.Text ;
            cfg.Target              = txtType.Text ;
            cfg.Observation         = txtDescription.Text;

            Config.CreateConfig(cfg);
        }
        private void windConfig_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.gclogoicon;
            configs = Config.GetAllConfig();

           foreach (Config conf in configs) 
           {
               treeView1.Nodes.Add(conf.Observation, conf.Observation);
               if (conf.Target == "T")
                   treeView1.Nodes[conf.Observation].ForeColor = Color.Blue;
               if (conf.Target == "S")
                   treeView1.Nodes[conf.Observation].ForeColor = Color.Gray;
               if (conf.Target == "D")
                   treeView1.Nodes[conf.Observation].ForeColor = Color.Red;
               if (conf.Target == "M")
                   treeView1.Nodes[conf.Observation].ForeColor = Color.Purple;
           }

           MessageBox.Show("Aréa Desenvolvedor. Por favor não Adicionar ou Remover Configurações \n\nModificar apenas Configurações do tipo \"T\" Geralmente as que estão em Azul.", "PWGC - Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            cfg = Config.GetConfigByName(treeView1.SelectedNode.Text);
            txtId.Text = cfg.ID.ToString();
            txtCondition.Text = cfg.Description;
            txtParam.Text = cfg.Code.ToString();
            txtType.Text = cfg.Target.ToString();
            txtDescription.Text = cfg.Observation;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cfg.Description = txtCondition.Text;
            cfg.Code = txtParam.Text;
            cfg.Target = txtType.Text;
            cfg.Observation = txtDescription.Text;

            Config.UpdateConfig(cfg);
        }
    }
}
