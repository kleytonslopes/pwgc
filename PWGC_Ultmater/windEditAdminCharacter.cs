using Engine;
using Engine.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PWGC_Ultmater
{
    public partial class windEditAdminCharacter : Form
    {
        IList<Character> allCharacter;
        Character character;
        Character characterbase;
        public windEditAdminCharacter()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.gclogoicon;
        }

        public void LoadAllCharacter()
        {
            try
            {
                allCharacter = Character.GetAllCharacterAdmin();
                treeView1.Nodes.Clear();
                ListPopulate(allCharacter, treeView1);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ListPopulate(IList<Character> list, TreeView tree)
        {
            //progBar.Maximum = list.Count;
            //tree.Nodes.Clear();
            //lblCountSK.Text = "0"; int countSK = 0;
            //lblCountMY.Text = "0"; int countMY = 0;
            //lblCountWR.Text = "0"; int countWR = 0;
            //lblCountMG.Text = "0"; int countMG = 0;
            //lblCountWB.Text = "0"; int countWB = 0;
            //lblCountWF.Text = "0"; int countWF = 0;
            //lblCountEA.Text = "0"; int countEA = 0;
            //lblCountEP.Text = "0"; int countEP = 0;
            //lblCountAS.Text = "0"; int countAS = 0;
            //lblCountES.Text = "0"; int countES = 0;
            //lblCountRE.Text = "0"; int countRE = 0;
            //lblCountTO.Text = "0"; int countTO = 0;
            //lblTotal.Text = "0"; int countTotal = 0;
            //lblCountND.Text = "0"; int countND = 0;

            #region Metodo Todos Os Perssonagens

            foreach (Character m in list)
            {
                // progBar.Value++;
                #region Contagem das Classes
                // if (m.Grade == GlobalSystem.Class.Arcano.ToString())
                //     countSK++;
                // else if (m.Grade == GlobalSystem.Class.Mistico.ToString())
                //     countMY++;
                // else if (m.Grade == GlobalSystem.Class.Guerreiro.ToString())
                //     countWR++;
                // else if (m.Grade == GlobalSystem.Class.Mago.ToString())
                //     countMG++;
                // else if (m.Grade == GlobalSystem.Class.Barbaro.ToString())
                //     countWB++;
                // else if (m.Grade == GlobalSystem.Class.Feiticeira.ToString())
                //     countWF++;
                // else if (m.Grade == GlobalSystem.Class.Arqueiro.ToString())
                //     countEA++;
                // else if (m.Grade == GlobalSystem.Class.Sacerdote.ToString())
                //     countEP++;
                // else if (m.Grade == GlobalSystem.Class.Mercenário.ToString())
                //     countAS++;
                // else if (m.Grade == GlobalSystem.Class.Espiritualista.ToString())
                //     countES++;
                // else if (m.Grade == GlobalSystem.Class.Retalhador.ToString())
                //     countRE++;
                // else if (m.Grade == GlobalSystem.Class.Tormentador.ToString())
                //     countTO++;
                // else
                // {
                //     m.Grade = GlobalSystem.Common.NãoDeterminado.ToString();
                //     countND++;
                // }

                #endregion
                if (m.Status == null)
                    m.Status = GlobalSystem.Common.NãoDeterminado.ToString();
                if (m.Reborn == null)
                    m.Reborn = GlobalSystem.Reborn.SemReborn.ToString();
                if (m.Rank == null)
                    m.Rank = GlobalSystem.Rank.SemRank.ToString();
                //Se na Tree tiver um root da Classe
                if (tree.Nodes.ContainsKey(m.Grade))
                {
                    //Se o Root da classe tiver um Status
                    if (tree.Nodes[m.Grade].Nodes.ContainsKey(m.Status))
                    {
                        //Se este Status Não tiver um PErssonagem com o Mesmo nome
                        if (!tree.Nodes[m.Grade].Nodes[m.Status].Nodes.ContainsKey(m.Nick))
                            //Adiciona o Membro neste estatus
                            tree.Nodes[m.Grade].Nodes[m.Status].Nodes.Add(m.Nick);

                    }
                    else//caso não
                    {
                        //Adiciona um Status
                        tree.Nodes[m.Grade].Nodes.Add(m.Status, m.Status);
                        //e Depois Adiciona o Membro a este estatus
                        tree.Nodes[m.Grade].Nodes[m.Status].Nodes.Add(m.Nick);

                    }
                }
                else//Caso nao Tiver uma root da classe
                {
                    //se a Classe for Nula Adiciona por Padrao a Classe Nao Definida
                    if (m.Grade == null)
                        m.Grade = GlobalSystem.Common.NãoDeterminado.ToString();

                    //Como nao tem uma root de Classe entao ele cria uma
                    tree.Nodes.Add(m.Grade, m.Grade);

                    if (tree.Nodes[m.Grade].Name == GlobalSystem.Common.NãoDeterminado.ToString())
                        tree.Nodes[m.Grade].ForeColor = Color.Red;
                    //se a root da classe nao tiver um status
                    if (!tree.Nodes[m.Grade].Nodes.ContainsKey(m.Status))
                    {
                        //cria o status na root da class
                        tree.Nodes[m.Grade].Nodes.Add(m.Status, m.Status);
                        //depois adiciona o membro a este status

                        tree.Nodes[m.Grade].Nodes[m.Status].Nodes.Add(m.Nick);

                    }
                    else//caso ja tenha a status na root
                    {
                        //adiciona este membro ao status
                        tree.Nodes[m.Grade].Nodes[m.Status].Nodes.Add(m.Nick);
                    }
                }
            }
            #endregion
            //lblCountSK.Text = countSK.ToString();
            //lblCountMY.Text = countMY.ToString();
            //lblCountWR.Text = countWR.ToString();
            //lblCountMG.Text = countMG.ToString();
            //lblCountWB.Text = countWB.ToString();
            //lblCountWF.Text = countWF.ToString();
            //lblCountEA.Text = countEA.ToString();
            //lblCountEP.Text = countEP.ToString();
            //lblCountAS.Text = countAS.ToString();
            //lblCountES.Text = countES.ToString();
            //lblCountRE.Text = countRE.ToString();
            //lblCountTO.Text = countTO.ToString();
            //lblTotal.Text = list.Count.ToString();
            //lblCountND.Text = countND.ToString();
            //progBar.Value = 0;
        }

        private void windEditAdminCharacter_Load(object sender, EventArgs e)
        {
            LoadAllCharacter();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //txtAtualizado.ForeColor = Color.White;
            try
            {
                string sql = "";
                foreach (Character c in allCharacter)
                {
                    if (c.Nick == treeView1.SelectedNode.Text)
                    {
                        character = Character.GetCharacterByCodeAdmin(c.Id);
                    }
                }
                GetCharacter();
                /*
                btnNick.Text = character.Nick;
                txtLevel.Text = character.Level.ToString();

                if (character.Reborn == null)
                    cbReborn.SelectedIndex = 0;
                if (character.Reborn == GlobalSystem.Reborn.SemReborn.ToString())
                    cbReborn.SelectedIndex = 0;
                if (character.Reborn == GlobalSystem.Reborn.Reborn_I.ToString())
                    cbReborn.SelectedIndex = 1;
                if (character.Reborn == GlobalSystem.Reborn.Reborn_II.ToString())
                    cbReborn.SelectedIndex = 2;

                if (character.Rank == null)
                    cbRank.SelectedIndex = 0;
                if (character.Rank == GlobalSystem.Rank.SemRank.ToString())
                    cbRank.SelectedIndex = 0;
                if (character.Rank == GlobalSystem.Rank.I.ToString())
                    cbRank.SelectedIndex = 1;
                if (character.Rank == GlobalSystem.Rank.II.ToString())
                    cbRank.SelectedIndex = 2;
                if (character.Rank == GlobalSystem.Rank.III.ToString())
                    cbRank.SelectedIndex = 3;
                if (character.Rank == GlobalSystem.Rank.IV.ToString())
                    cbRank.SelectedIndex = 4;
                if (character.Rank == GlobalSystem.Rank.V.ToString())
                    cbRank.SelectedIndex = 5;
                if (character.Rank == GlobalSystem.Rank.VI.ToString())
                    cbRank.SelectedIndex = 6;
                if (character.Rank == GlobalSystem.Rank.VII.ToString())
                    cbRank.SelectedIndex = 7;
                if (character.Rank == GlobalSystem.Rank.VIII.ToString())
                    cbRank.SelectedIndex = 8;
                if (character.Rank == GlobalSystem.Rank.X.ToString())
                    cbRank.SelectedIndex = 9;

                txtID.Text = character.Id.ToString();
                txtLastLevel.Text = character.LastLevel.ToString();
                txtLevelCad.Text = character.LevelEntrance.ToString();
                txtEntrada.Text = character.Entry.ToShortDateString();
                txtClass.Text = character.Grade;
                txtLastStatus.Text = character.LastStatus;
                //                txtTitulo.Text = character.titl

                btnRecrutante.Text = character.Recruter;
                btnIndicator.Text = character.Idicated;
                txtMerito.Text = character.Merit.ToString();
                txtMeriAnterior.Text = character.LastMerit.ToString();
                txtAtualizado.Text = character.Updated.ToShortDateString();
                txtUltAtt.Text = character.LastUpdated.ToShortDateString();
                txtOwner.Text = character.Owner;
                txtLastOwner.Text = character.LastOwner;
                txtOwnerMaster.Text = character.OwnerEntrance;

                if (character.Visible == "S")
                    chkVisible.Checked = true;
                else
                    chkVisible.Checked = false;

                cbReborn.SelectedText = character.Reborn;
                cbRank.SelectedText = character.Rank;

                GlobalSystem.MaxDayToInactive = 20;
                DateTime now = new DateTime();
                DateTime update = new DateTime();
                DateTime updatefix = new DateTime();
                now = DateTime.Now;
                update = character.Updated;

                updatefix = update.AddDays(7);

                if (updatefix.Date < now.Date)
                {
                    txtAtualizado.ForeColor = Color.Salmon;
                    MessageBox.Show("Perssonagem Desatualizado!");

                }

                if (character.Office == GlobalSystem.Cargo.Soldado.ToString())
                {
                    rbSoldado.Checked = true;
                    txtCargo.Text = GlobalSystem.Cargo.Soldado.ToString();
                }
                if (character.Office == GlobalSystem.Cargo.Capitão.ToString())
                {
                    rbCapitao.Checked = true;
                    txtCargo.Text = GlobalSystem.Cargo.Capitão.ToString();
                }
                if (character.Office == GlobalSystem.Cargo.Major.ToString())
                {
                    rbMajor.Checked = true;
                    txtCargo.Text = GlobalSystem.Cargo.Major.ToString();
                }
                if (character.Office == GlobalSystem.Cargo.General.ToString())
                {
                    rbGeneral.Checked = true;
                    txtCargo.Text = GlobalSystem.Cargo.General.ToString();
                }
                if (character.Office == GlobalSystem.Cargo.Marechal.ToString())
                {
                    rbMarechal.Checked = true;
                    txtCargo.Text = GlobalSystem.Cargo.Marechal.ToString();
                }

                if (character.Status == GlobalSystem.Status.Ativo.ToString())
                {
                    rbAtivo.Checked = true;
                    txtStatus.Text = GlobalSystem.Status.Ativo.ToString();
                }
                if (character.Status == GlobalSystem.Status.Inativo.ToString())
                {
                    rbInativo.Checked = true;
                    txtStatus.Text = GlobalSystem.Status.Ativo.ToString();
                }
                if (character.Status == GlobalSystem.Status.Desertor.ToString())
                {
                    rbDesertor.Checked = true;
                    txtStatus.Text = GlobalSystem.Status.Ativo.ToString();
                }
                if (character.Status == GlobalSystem.Status.Banido.ToString())
                {
                    rbBanido.Checked = true;
                    txtStatus.Text = GlobalSystem.Status.Ativo.ToString();
                }
                if (character.Status == GlobalSystem.Status.Ausente.ToString())
                {
                    rbAusente.Checked = true;
                    txtStatus.Text = GlobalSystem.Status.Ativo.ToString();
                }
                if (character.Status == GlobalSystem.Status.Análise.ToString())
                {
                    rbAnalise.Checked = true;
                    txtStatus.Text = GlobalSystem.Status.Ativo.ToString();
                }

                rtbObservation.Text = character.Observation;
                //limpa o registro do personagem selecionado anteriormente
                characterbase = null;
                //carrega o registro do perssonagem selecionado atual para um registro base
                characterbase = character;

                int merti = 0;
                merti = character.Merit - character.LastMerit;
                txtMeriDiferential.Text = merti.ToString();

                if (merti <= GlobalSystem.MinMeritTolerance)// tolerancia minima de merito
                {
                    if (character.Status != GlobalSystem.Status.Inativo.ToString() && character.Status != GlobalSystem.Status.Banido.ToString() && character.Status != GlobalSystem.Status.Desertor.ToString())
                    {
                        txtMeriDiferential.ForeColor = Color.Red;

                        DialogResult resultado;
                        resultado = MessageBox.Show(this, "Minimo de Merito Alcaçado! \nDeseja Atribuir Inativo a este membro?", "", MessageBoxButtons.YesNo);

                        if (resultado == DialogResult.Yes)
                        {
                            character.Status = GlobalSystem.Status.Inativo.ToString();
                            rbInativo.Checked = true;
                        }
                    }

                }
                */

            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
            }
        }
        #region Setar Classes
        private void btnSK_Click(object sender, EventArgs e)
        {
            character.Grade = GlobalSystem.Class.Arcano.ToString();
            txtClass.Text = character.Grade;
            if (txtClass.Text == characterbase.Grade)
            {
                txtClass.ForeColor = Color.Black;
            }
            else
            {
                txtClass.ForeColor = Color.Blue;
            }
        }

        private void btnMY_Click(object sender, EventArgs e)
        {
            character.Grade = GlobalSystem.Class.Mistico.ToString();
            txtClass.Text = character.Grade;
            if (txtClass.Text == characterbase.Grade)
            {
                txtClass.ForeColor = Color.Black;
            }
            else
            {
                txtClass.ForeColor = Color.Blue;
            }
        }

        private void btnWR_Click(object sender, EventArgs e)
        {
            character.Grade = GlobalSystem.Class.Guerreiro.ToString();
            txtClass.Text = character.Grade;
            if (txtClass.Text == characterbase.Grade)
            {
                txtClass.ForeColor = Color.Black;
            }
            else
            {
                txtClass.ForeColor = Color.Blue;
            }
        }

        private void btnMG_Click(object sender, EventArgs e)
        {
            character.Grade = GlobalSystem.Class.Mago.ToString();
            txtClass.Text = character.Grade;
            if (txtClass.Text == characterbase.Grade)
            {
                txtClass.ForeColor = Color.Black;
            }
            else
            {
                txtClass.ForeColor = Color.Blue;
            }
        }

        private void btnEA_Click(object sender, EventArgs e)
        {
            character.Grade = GlobalSystem.Class.Arqueiro.ToString();
            txtClass.Text = character.Grade;
            if (txtClass.Text == characterbase.Grade)
            {
                txtClass.ForeColor = Color.Black;
            }
            else
            {
                txtClass.ForeColor = Color.Blue;
            }
        }

        private void btnEP_Click(object sender, EventArgs e)
        {
            character.Grade = GlobalSystem.Class.Sacerdote.ToString();
            txtClass.Text = character.Grade;
            if (txtClass.Text == characterbase.Grade)
            {
                txtClass.ForeColor = Color.Black;
            }
            else
            {
                txtClass.ForeColor = Color.Blue;
            }
        }

        private void btnWB_Click(object sender, EventArgs e)
        {
            character.Grade = GlobalSystem.Class.Barbaro.ToString();
            txtClass.Text = character.Grade;
            if (txtClass.Text == characterbase.Grade)
            {
                txtClass.ForeColor = Color.Black;
            }
            else
            {
                txtClass.ForeColor = Color.Blue;
            }
        }

        private void btnWF_Click(object sender, EventArgs e)
        {
            character.Grade = GlobalSystem.Class.Feiticeira.ToString();
            txtClass.Text = character.Grade;
            if (txtClass.Text == characterbase.Grade)
            {
                txtClass.ForeColor = Color.Black;
            }
            else
            {
                txtClass.ForeColor = Color.Blue;
            }
        }

        private void btnAS_Click(object sender, EventArgs e)
        {
            character.Grade = GlobalSystem.Class.Mercenário.ToString();
            txtClass.Text = character.Grade;
            if (txtClass.Text == characterbase.Grade)
            {
                txtClass.ForeColor = Color.Black;
            }
            else
            {
                txtClass.ForeColor = Color.Blue;
            }
        }

        private void btnES_Click(object sender, EventArgs e)
        {
            character.Grade = GlobalSystem.Class.Espiritualista.ToString();
            txtClass.Text = character.Grade;
            if (txtClass.Text == characterbase.Grade)
            {
                txtClass.ForeColor = Color.Black;
            }
            else
            {
                txtClass.ForeColor = Color.Blue;
            }
        }

        private void btnRET_Click(object sender, EventArgs e)
        {
            character.Grade = GlobalSystem.Class.Retalhador.ToString();
            txtClass.Text = character.Grade;
            if (txtClass.Text == characterbase.Grade)
            {
                txtClass.ForeColor = Color.Black;
            }
            else
            {
                txtClass.ForeColor = Color.Blue;
            }
        }

        private void btnTOR_Click(object sender, EventArgs e)
        {
            character.Grade = GlobalSystem.Class.Tormentador.ToString();
            txtClass.Text = character.Grade;
            if (txtClass.Text == characterbase.Grade)
            {
                txtClass.ForeColor = Color.Black;
            }
            else
            {
                txtClass.ForeColor = Color.Blue;
            }
        }
        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (!GlobalPermission.permissionIndex[92])
                return;


            GlobalSystem.MaxDayToInactive = 20;
            DateTime now = new DateTime();
            now = character.Updated;
            now.AddDays(GlobalSystem.MaxDayToInactive);

            DialogResult result;

            if (now.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                result = MessageBox.Show("Personagem já Atualizado Hoje! \nDeseja realmente Atualiza-lo?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;

            }
            if (cbReborn.SelectedIndex < 0)
                cbReborn.SelectedIndex = 0;

            if (!Character.VerifyCharacter(character.Nick))
                return;

            if (characterbase == null)
            {
                ProcessConsole.ProcessInformation("Erro ao tentar atualizar, Supostamente o Identificador esta fora. por favor selecione novamente o Perssonagem.");
                MessageBox.Show("Identificador de Perssonagem esta fora!");

                return;
            }

            character.LastLevel = characterbase.Level;
            character.LastMerit = characterbase.Merit;
            character.LastOwner = characterbase.Owner;
            character.LastStatus = characterbase.Status;
            character.LastUpdated = characterbase.Updated;
            character.Level = Convert.ToInt32(txtLevel.Text);
            character.Merit = Convert.ToInt32(txtMerito.Text);
            character.Observation = rtbObservation.Text;
            character.Owner = GlobalSystem.usuario.Nick;
            character.Rank = cbRank.SelectedItem.ToString();

            if (chkVisible.Checked)
                character.Visible = "S";
            else
                character.Visible = "N";

            character.Reborn = cbReborn.SelectedItem.ToString();

            character.Updated = DateTime.Now;

            if (rbSoldado.Checked)
                character.Office = GlobalSystem.Cargo.Soldado.ToString();
            else if (rbCapitao.Checked)
                character.Office = GlobalSystem.Cargo.Capitão.ToString();
            else if (rbMajor.Checked)
                character.Office = GlobalSystem.Cargo.Major.ToString();
            else if (rbGeneral.Checked)
                character.Office = GlobalSystem.Cargo.General.ToString();
            else if (rbMarechal.Checked)
                character.Office = GlobalSystem.Cargo.Marechal.ToString();
            else
                character.Office = GlobalSystem.Common.NãoDeterminado.ToString();

            if (rbAtivo.Checked)
                character.Status = GlobalSystem.Status.Ativo.ToString();
            else if (rbInativo.Checked)
                character.Status = GlobalSystem.Status.Inativo.ToString();
            else if (rbDesertor.Checked)
                character.Status = GlobalSystem.Status.Desertor.ToString();
            else if (rbBanido.Checked)
                character.Status = GlobalSystem.Status.Banido.ToString();
            else if (rbAusente.Checked)
                character.Status = GlobalSystem.Status.Ausente.ToString();
            else if (rbAnalise.Checked)
                character.Status = GlobalSystem.Status.Análise.ToString();
            else
                character.Status = GlobalSystem.Common.NãoDeterminado.ToString();

            Character.UpdateCharacter(character);

            characterbase = null;
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            LoadAllCharacter();
        }

        private void btnNick_Click(object sender, EventArgs e)
        {
            string str = Clipboard.GetText();
            if (str.Length < 10)
            {
                btnNick.Text = Clipboard.GetText();

                character = Character.GetCharacterByName(btnNick.Text);

                GetCharacter();
            }
        }

        public void GetCharacter()
        {

            btnNick.Text = character.Nick;
            txtLevel.Text = character.Level.ToString();

            if (character.Reborn == null)
                cbReborn.SelectedIndex = 0;
            if (character.Reborn == GlobalSystem.Reborn.SemReborn.ToString())
                cbReborn.SelectedIndex = 0;
            if (character.Reborn == GlobalSystem.Reborn.Reborn_I.ToString())
                cbReborn.SelectedIndex = 1;
            if (character.Reborn == GlobalSystem.Reborn.Reborn_II.ToString())
                cbReborn.SelectedIndex = 2;

            if (character.Rank == null)
                cbRank.SelectedIndex = 0;
            if (character.Rank == GlobalSystem.Rank.SemRank.ToString())
                cbRank.SelectedIndex = 0;
            if (character.Rank == GlobalSystem.Rank.I.ToString())
                cbRank.SelectedIndex = 1;
            if (character.Rank == GlobalSystem.Rank.II.ToString())
                cbRank.SelectedIndex = 2;
            if (character.Rank == GlobalSystem.Rank.III.ToString())
                cbRank.SelectedIndex = 3;
            if (character.Rank == GlobalSystem.Rank.IV.ToString())
                cbRank.SelectedIndex = 4;
            if (character.Rank == GlobalSystem.Rank.V.ToString())
                cbRank.SelectedIndex = 5;
            if (character.Rank == GlobalSystem.Rank.VI.ToString())
                cbRank.SelectedIndex = 6;
            if (character.Rank == GlobalSystem.Rank.VII.ToString())
                cbRank.SelectedIndex = 7;
            if (character.Rank == GlobalSystem.Rank.VIII.ToString())
                cbRank.SelectedIndex = 8;
            if (character.Rank == GlobalSystem.Rank.X.ToString())
                cbRank.SelectedIndex = 9;

            txtID.Text = character.Id.ToString();
            txtLastLevel.Text = character.LastLevel.ToString();
            txtLevelCad.Text = character.LevelEntrance.ToString();
            txtEntrada.Text = character.Entry.ToShortDateString();
            txtClass.Text = character.Grade;
            txtLastStatus.Text = character.LastStatus;
            //                txtTitulo.Text = character.titl

            btnRecrutante.Text = character.Recruter;
            btnIndicator.Text = character.Idicated;
            txtMerito.Text = character.Merit.ToString();
            txtMeriAnterior.Text = character.LastMerit.ToString();
            txtAtualizado.Text = character.Updated.ToShortDateString();
            txtUltAtt.Text = character.LastUpdated.ToShortDateString();
            txtOwner.Text = character.Owner;
            txtLastOwner.Text = character.LastOwner;
            txtOwnerMaster.Text = character.OwnerEntrance;

            if (character.Visible == "S")
                chkVisible.Checked = true;
            else
                chkVisible.Checked = false;

            cbReborn.SelectedText = character.Reborn;
            cbRank.SelectedText = character.Rank;

            GlobalSystem.MaxDayToInactive = 20;
            DateTime now = new DateTime();
            DateTime update = new DateTime();
            DateTime updatefix = new DateTime();
            now = DateTime.Now;
            update = character.Updated;

            updatefix = update.AddDays(7);

            if (updatefix.Date < now.Date)
            {
                txtAtualizado.ForeColor = Color.Salmon;
                MessageBox.Show("Perssonagem Desatualizado!");

            }

            if (character.Office == GlobalSystem.Cargo.Soldado.ToString())
            {
                rbSoldado.Checked = true;
                txtCargo.Text = GlobalSystem.Cargo.Soldado.ToString();
            }
            if (character.Office == GlobalSystem.Cargo.Capitão.ToString())
            {
                rbCapitao.Checked = true;
                txtCargo.Text = GlobalSystem.Cargo.Capitão.ToString();
            }
            if (character.Office == GlobalSystem.Cargo.Major.ToString())
            {
                rbMajor.Checked = true;
                txtCargo.Text = GlobalSystem.Cargo.Major.ToString();
            }
            if (character.Office == GlobalSystem.Cargo.General.ToString())
            {
                rbGeneral.Checked = true;
                txtCargo.Text = GlobalSystem.Cargo.General.ToString();
            }
            if (character.Office == GlobalSystem.Cargo.Marechal.ToString())
            {
                rbMarechal.Checked = true;
                txtCargo.Text = GlobalSystem.Cargo.Marechal.ToString();
            }

            if (character.Status == GlobalSystem.Status.Ativo.ToString())
            {
                rbAtivo.Checked = true;
                txtStatus.Text = GlobalSystem.Status.Ativo.ToString();
            }
            if (character.Status == GlobalSystem.Status.Inativo.ToString())
            {
                rbInativo.Checked = true;
                txtStatus.Text = GlobalSystem.Status.Ativo.ToString();
            }
            if (character.Status == GlobalSystem.Status.Desertor.ToString())
            {
                rbDesertor.Checked = true;
                txtStatus.Text = GlobalSystem.Status.Ativo.ToString();
            }
            if (character.Status == GlobalSystem.Status.Banido.ToString())
            {
                rbBanido.Checked = true;
                txtStatus.Text = GlobalSystem.Status.Ativo.ToString();
            }
            if (character.Status == GlobalSystem.Status.Ausente.ToString())
            {
                rbAusente.Checked = true;
                txtStatus.Text = GlobalSystem.Status.Ativo.ToString();
            }
            if (character.Status == GlobalSystem.Status.Análise.ToString())
            {
                rbAnalise.Checked = true;
                txtStatus.Text = GlobalSystem.Status.Ativo.ToString();
            }

            rtbObservation.Text = character.Observation;
            //limpa o registro do personagem selecionado anteriormente
            characterbase = null;
            //carrega o registro do perssonagem selecionado atual para um registro base
            characterbase = character;

            int merti = 0;
            merti = character.Merit - character.LastMerit;
            txtMeriDiferential.Text = merti.ToString();

            if (merti <= GlobalSystem.MinMeritTolerance)// tolerancia minima de merito
            {
                if (character.Status != GlobalSystem.Status.Inativo.ToString() && character.Status != GlobalSystem.Status.Banido.ToString() && character.Status != GlobalSystem.Status.Desertor.ToString())
                {
                    txtMeriDiferential.ForeColor = Color.Red;

                    DialogResult resultado;
                    resultado = MessageBox.Show(this, "Minimo de Merito Alcaçado! \nDeseja Atribuir Inativo a este membro?", "", MessageBoxButtons.YesNo);

                    if (resultado == DialogResult.Yes)
                    {
                        character.Status = GlobalSystem.Status.Inativo.ToString();
                        rbInativo.Checked = true;
                    }
                }

            }
        }
    }
    
}
