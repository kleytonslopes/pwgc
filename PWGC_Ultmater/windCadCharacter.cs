using Engine;
using Engine.Entities;
using System;
using System.Windows.Forms;

namespace PWGC_Ultmater
{
    public partial class windCadCharacter : Form
    {
        Button[] btnClass;
        Character character = new Character();
        public windCadCharacter()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.gclogoicon;
            label7.Text = "Observação: " + tbObservacao.TextLength.ToString() + " - " + tbObservacao.MaxLength.ToString();

            btnClass = new Button[12] 
            {
                btnSK,//SK
                btnMY,//MY
                btnWR,//WR
                btnMG,//BG
                btnEA,//EA
                btnEP,//EP
                btnWB,//WB
                btnWF,//WF
                btnAS,//AS
                btnES,//ES
                btnRET,//RETA
                btnTOR//TORM
            };


            #region Botoes                           
            ControlModifier.ControlPermission(btnSK, 27);
            ControlModifier.ControlPermission(btnMY, 28);
            ControlModifier.ControlPermission(btnWR, 29);
            ControlModifier.ControlPermission(btnMG, 30);
            ControlModifier.ControlPermission(btnEA, 31);
            ControlModifier.ControlPermission(btnEP, 32);
            ControlModifier.ControlPermission(btnWB, 33);
            ControlModifier.ControlPermission(btnWF, 34);
            ControlModifier.ControlPermission(btnAS, 35);
            ControlModifier.ControlPermission(btnES, 36);
            ControlModifier.ControlPermission(btnRET,37);
            ControlModifier.ControlPermission(btnTOR,38);

            ControlModifier.ControlPermission(btnCadastrar, 1);
            ControlModifier.ControlPermission(panel2, 26);




            #endregion

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!GlobalPermission.permissionIndex[1])
                return;

            if (String.IsNullOrEmpty(tbNivel.Text))
                return;

            character.Entry = DateTime.Now;
            //meCharacter.Grade = "?";
            //meCharacter.Idicated = "Indicado";
            character.LastLevel = Convert.ToInt32( tbNivel.Text);
            character.LastMerit = 0;
            character.LastOwner = GlobalSystem.usuario.Nick;
            character.LastStatus = GlobalSystem.Status.Análise.ToString();
            character.LastUpdated = DateTime.Now;
            character.Level = Convert.ToInt32( tbNivel.Text);
            character.LevelEntrance = Convert.ToInt32( tbNivel.Text);
            character.Merit = 0;
            //meCharacter.Nick = "GCNew2";
            character.Observation = tbObservacao.Text;
            character.Office = GlobalSystem.Cargo.Soldado.ToString();
            character.OtherChar = "0";
            character.Owner = GlobalSystem.usuario.Nick;
            character.OwnerEntrance = GlobalSystem.usuario.Nick;

            character.Rank = GlobalSystem.Rank.SemRank.ToString();
            if (cbRank.SelectedIndex >= 0)
                character.Rank = cbRank.SelectedItem.ToString();

            character.Reborn = GlobalSystem.Reborn.SemReborn.ToString();
            if (cbReborn.SelectedIndex >= 0)
                character.Reborn = cbReborn.SelectedItem.ToString();
            //meCharacter.Recruter = "recrut";
            character.Status = GlobalSystem.Status.Análise.ToString();
            character.Updated = DateTime.Now;
            character.Visible = "S";

            if (cbReborn.SelectedIndex == null)
                MessageBox.Show("Sem Reborn");

            if (character.Grade == null)
                character.Grade = GlobalSystem.Common.NãoDeterminado.ToString();

            try
            {
                if(Connection.CheckSession())
                {
                    Character.InsertCharacter(character);
                    ProcessConsole.ProcessDone("Personagem " + character.Nick + " Cadastrado!");
                    MessageBox.Show("Personagem " + character.Nick + " Cadastrado!", "PWGC - Informação");
                }
                else
                {
                    ProcessConsole.ProcessInformation(GlobalMessage.ExpirationSession);
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
            }
        }

        private void btnColaNick_Click(object sender, EventArgs e)
        {
            string clip = Clipboard.GetText();
            if (clip.Length > 9 || String.IsNullOrWhiteSpace(clip))
            {

                MessageBox.Show("Nick Inválido: Limites de caracteres permitido Ultrapassados \nOu Não contem Caracteres.");
                return;
            }
            else
            {
                if (Character.VerifyCharacter(clip))
                {
                    ProcessConsole.ProcessInformation("Perssonagem já Cadastrado!");
                    MessageBox.Show("Perssonagem já Cadastrado!");
                    return;
                }
                this.btnColaNick.Text = Clipboard.GetText();
                character.Nick = Clipboard.GetText();
                ProcessConsole.ProcessDone("Nick do Personagem Setado!");
            }
        }

        private void btnColaRecr_Click(object sender, EventArgs e)
        {
            string clip = Clipboard.GetText();
            if (clip.Length > 9 || String.IsNullOrWhiteSpace(clip))
            {

                MessageBox.Show("Nick Inválido: Limites de caracteres permitido Ultrapassados \nOu Não contem Caracteres.");
                return;
            }
            else
            {
                this.btnColaRecr.Text = Clipboard.GetText();
                character.Recruter = Clipboard.GetText();
                ProcessConsole.ProcessDone("Nick do Recrutador Setado!");
            }
        }

        private void btnColaIndi_Click(object sender, EventArgs e)
        {
            string clip = Clipboard.GetText();
            if (clip.Length > 9 || String.IsNullOrWhiteSpace(clip))
            {

                MessageBox.Show("Nick Inválido: Limites de caracteres permitido Ultrapassados \nOu Não contem Caracteres.");
                return;
            }
            else
            {
                this.btnColaIndi.Text = Clipboard.GetText();
                character.Idicated = Clipboard.GetText();
                ProcessConsole.ProcessDone("Nick do Recrutador Setado!");
            }
        }

        //Classes
        private void btnSK_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[26])
            {
                if (GlobalPermission.permissionIndex[27])
                {
                    ControlModifier.ButtonColorChanger(0, btnClass);
                    character.Grade = GlobalSystem.Class.Arcano.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }

        private void btnMY_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[26])
            {
                if (GlobalPermission.permissionIndex[28])
                {
                    ControlModifier.ButtonColorChanger(1, btnClass);
                    character.Grade = GlobalSystem.Class.Mistico.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }

        private void btnWR_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[26])
            {
                if (GlobalPermission.permissionIndex[29])
                {
                    ControlModifier.ButtonColorChanger(2, btnClass);
                    character.Grade = GlobalSystem.Class.Guerreiro.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }

        private void btnMG_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[26])
            {
                if (GlobalPermission.permissionIndex[30])
                {
                    ControlModifier.ButtonColorChanger(3, btnClass);
                    character.Grade = GlobalSystem.Class.Mago.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }

        private void btnEA_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[26])
            {
                if (GlobalPermission.permissionIndex[31])
                {
                    ControlModifier.ButtonColorChanger(4, btnClass);
                    character.Grade = GlobalSystem.Class.Arqueiro.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }

        private void btnEP_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[26])
            {
                if (GlobalPermission.permissionIndex[32])
                {
                    ControlModifier.ButtonColorChanger(5, btnClass);
                    character.Grade = GlobalSystem.Class.Sacerdote.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }

        private void btnWB_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[26])
            {
                if (GlobalPermission.permissionIndex[33])
                {
                    ControlModifier.ButtonColorChanger(6, btnClass);
                    character.Grade = GlobalSystem.Class.Barbaro.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }

        private void btnWF_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[26])
            {
                if (GlobalPermission.permissionIndex[34])
                {
                    ControlModifier.ButtonColorChanger(7, btnClass);
                    character.Grade = GlobalSystem.Class.Feiticeira.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }

        private void btnAS_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[26])
            {
                if (GlobalPermission.permissionIndex[35])
                {
                    ControlModifier.ButtonColorChanger(8, btnClass);
                    character.Grade = GlobalSystem.Class.Mercenário.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }

        private void btnES_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[26])
            {
                if (GlobalPermission.permissionIndex[36])
                {
                    ControlModifier.ButtonColorChanger(9, btnClass);
                    character.Grade = GlobalSystem.Class.Espiritualista.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }

        private void btnRET_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[26])
            {
                if (GlobalPermission.permissionIndex[37])
                {
                    ControlModifier.ButtonColorChanger(10, btnClass);
                    character.Grade = GlobalSystem.Class.Retalhador.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }

        private void btnTOR_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[26])
            {
                if (GlobalPermission.permissionIndex[38])
                {
                    ControlModifier.ButtonColorChanger(11, btnClass);
                    character.Grade = GlobalSystem.Class.Tormentador.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }

        private void tbObservacao_TextChanged(object sender, EventArgs e)
        {
            label7.Text = "Observação: " + tbObservacao.TextLength.ToString() + " - " + tbObservacao.MaxLength.ToString();
        }
    }
}
