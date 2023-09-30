using System;
using System.Windows.Forms;
using Engine.Entities;
using Engine;
using System.Collections.Generic;

namespace PWGC_Ultmater
{
    public partial class windEventMerit : Form
    {
        bool enabledEvent;
        IList<EventMerit> eventos;
        public windEventMerit()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.gclogoicon;
            if (GlobalSystem.cfg[5].Description == "ON") 
            {
                enabledEvent = true;
                btnStartStop.Text = "Finalizar";
            }
            else 
            {
                enabledEvent = false;
                btnStartStop.Text = "Ativar";
            }

            eventos = EventMerit.GetAllEvents();
            IList<EventMerit> participantes = EventMerit.GetAllEvents();
            List<EventMerit> lista = new List<EventMerit>();
            //dataGridView1.DataSource = participantes;
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            foreach(EventMerit c in participantes)
            {
                int a = c.FirstMerit;
                int b = c.LastMerit;
                int r = 0;
                if ((b - a) < 0)
                    r = 0;
                else
                    r = (b - a);

                this.dataGridView1.Rows.Add(c.ID, c.NickCharacter, c.FirstOwner, c.LastOwner, c.FirstMerit, c.LastMerit, r.ToString());
               // this.dataGridView1.Rows.Insert(c.ID, c.NickCharacter, c.FirstOwner, c.LastOwner, c.FirstMerit, c.LastMerit, (b - a).ToString());
                 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!enabledEvent)
            {
                GlobalSystem.cfg[5].Description = "ON";
                Character.StatusEventCharacterMerit("L");

                Tracking rastrear = new Tracking();

                if (GlobalSystem.cfg[5].Description.Equals("ON"))
                    rastrear.Action = GlobalSystem.Tracking.EventoMeritoON.ToString();
                else
                    rastrear.Action = GlobalSystem.Tracking.EventoMeritoOFF.ToString();

                rastrear.DateTrack = DateTime.Now;
                rastrear.UserID = GlobalSystem.usuario.ID;
                rastrear.UserName = GlobalSystem.usuario.Nick;
                Tracking.Insert(rastrear);
                btnStartStop.Text = "Finalizar";
                enabledEvent = !enabledEvent;
                Config Atual = GlobalSystem.cfg[5];
                
                
                Config.UpdateConfig(Atual);

            }
            else
            {
                GlobalSystem.cfg[5].Description = "OFF";
                Character.StatusEventCharacterMerit("A");

                Tracking rastrear = new Tracking();

                if (GlobalSystem.cfg[5].Description.Equals("ON"))
                    rastrear.Action = GlobalSystem.Tracking.EventoMeritoON.ToString();
                else
                    rastrear.Action = GlobalSystem.Tracking.EventoMeritoOFF.ToString();

                rastrear.DateTrack = DateTime.Now;
                rastrear.UserID = GlobalSystem.usuario.ID;
                rastrear.UserName = GlobalSystem.usuario.Nick;
                Tracking.Insert(rastrear);
                btnStartStop.Text = "Ativar";
                enabledEvent = !enabledEvent;

                Config Atual = GlobalSystem.cfg[5];


                Config.UpdateConfig(Atual);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Cuidado Operação não recomendada!\nDeseja realmente excluir todos os registros de Evento?", "PWGC - Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes) 
            {
                if (GlobalSystem.cfg[5].Description == "OFF")
                {
                    EventMerit.Clean();
                    dataGridView1.Rows.Clear();
                }
                else
                    MessageBox.Show("O Evento esta em Execução!\nPor favor finaliza-lo para prosseguir com a Exclusão dos Registros!");
            }
            
        }
    }
}
