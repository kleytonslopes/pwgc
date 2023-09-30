using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Engine;
using Engine.Entities;
using PWGC_Ultimater;

namespace PWGC_Ultmater
{
    public partial class windUpdateCharacter : Form
    {
        Button[] btnClass;
        Character character = new Character();
        Character characterbase = new Character();
        IList<Character> ListaMembros;
        public windUpdateCharacter()
        {
            InitializeComponent();
            Random range = new Random(100);

            if (range.Next(0, 100) == 10) 
            {

            }

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

            ControlModifier.ControlPermission(btnConsultar, 89);
            ControlModifier.ControlPermission(btnUpdate, 45);

            ControlModifier.ControlPermission(btnSK, 72); 
            ControlModifier.ControlPermission(btnMY, 73); 
            ControlModifier.ControlPermission(btnWR, 74);
            ControlModifier.ControlPermission(btnMG, 75);
            ControlModifier.ControlPermission(btnEA, 76);
            ControlModifier.ControlPermission(btnEP, 77);
            ControlModifier.ControlPermission(btnWB, 78);
            ControlModifier.ControlPermission(btnWF, 79);
            ControlModifier.ControlPermission(btnAS, 80);
            ControlModifier.ControlPermission(btnES, 81);
            ControlModifier.ControlPermission(btnRET, 82);
            ControlModifier.ControlPermission(btnTOR, 83);

            ControlModifier.ControlPermission(cbSK, 72);
            ControlModifier.ControlPermission(cbMY, 73);
            ControlModifier.ControlPermission(cbWR, 74);
            ControlModifier.ControlPermission(cbMG, 75);
            ControlModifier.ControlPermission(cbEA, 76);
            ControlModifier.ControlPermission(cbEP, 77);
            ControlModifier.ControlPermission(cbWB, 78);
            ControlModifier.ControlPermission(cbWF, 79);
            ControlModifier.ControlPermission(cbAS, 80);
            ControlModifier.ControlPermission(cbES, 81);
            ControlModifier.ControlPermission(cbRE, 82);
            ControlModifier.ControlPermission(cbTO, 83);

            ControlModifier.ControlPermission(panel8, 64);
            ControlModifier.ControlPermission(rbAtivo, 65);
            ControlModifier.ControlPermission(rbInativo, 66);
            ControlModifier.ControlPermission(rbBanido, 67);
            ControlModifier.ControlPermission(rbDesertor, 68);
            ControlModifier.ControlPermission(rbAnalise, 69);
            ControlModifier.ControlPermission(rbAusente, 70);

            ControlModifier.ControlPermission(cbAtivo, 65);
            ControlModifier.ControlPermission(cbInativo, 66);
            ControlModifier.ControlPermission(cbBanido, 67);
            ControlModifier.ControlPermission(cbDesertor, 68);
            ControlModifier.ControlPermission(cbAnalise, 69);
            ControlModifier.ControlPermission(cbAusente, 70);

            ControlModifier.ControlPermission(panel7, 48);
            ControlModifier.ControlPermission(rbSoldado, 49);
            ControlModifier.ControlPermission(rbCapitao, 50);
            ControlModifier.ControlPermission(rbMajor, 51);
            ControlModifier.ControlPermission(rbGeneral, 52);
            ControlModifier.ControlPermission(rbMarechal, 53);

        }

        private bool ValidarPermissao() 
        {
            bool este = true;
            if (GlobalPermission.permissionIndex[71])
            {
                if (!GlobalPermission.permissionIndex[72])
                {
                    if (character.Grade == GlobalSystem.Class.Arcano.ToString())
                        este = false;
                }
                if (!GlobalPermission.permissionIndex[73])
                {
                    if (character.Grade == GlobalSystem.Class.Mistico.ToString())
                        este =  false;
                }
                if (!GlobalPermission.permissionIndex[74])
                {
                    if (character.Grade == GlobalSystem.Class.Guerreiro.ToString())
                        este =  false;
                }
                if (!GlobalPermission.permissionIndex[75])
                {
                    if (character.Grade == GlobalSystem.Class.Mago.ToString())
                        este =  false;
                }
                if (!GlobalPermission.permissionIndex[76])
                {
                    if (character.Grade == GlobalSystem.Class.Arqueiro.ToString())
                        este =  false;
                }
                if (!GlobalPermission.permissionIndex[77])
                {
                    if (character.Grade == GlobalSystem.Class.Sacerdote.ToString())
                        este =  false;
                }
                if (!GlobalPermission.permissionIndex[78])
                {
                    if (character.Grade == GlobalSystem.Class.Barbaro.ToString())
                        este =  false;
                }
                if (!GlobalPermission.permissionIndex[79])
                {
                    if (character.Grade == GlobalSystem.Class.Feiticeira.ToString())
                        este =  false;
                }
                if (!GlobalPermission.permissionIndex[80])
                {
                    if (character.Grade == GlobalSystem.Class.Mercenário.ToString())
                        este =  false;
                }
                if (!GlobalPermission.permissionIndex[81])
                {
                    if (character.Grade == GlobalSystem.Class.Espiritualista.ToString())
                        este =  false;
                }
                if (!GlobalPermission.permissionIndex[82])
                {
                    if (character.Grade == GlobalSystem.Class.Retalhador.ToString())
                        este =  false;
                }
                if (!GlobalPermission.permissionIndex[83])
                {
                    if (character.Grade == GlobalSystem.Class.Tormentador.ToString())
                        este =  false;
                }
            }
            return este;
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidarPermissao())
                return;


            GlobalSystem.MaxDayToInactive = 20;
            DateTime now = new DateTime();
            now = character.Updated;
            now.AddDays(GlobalSystem.MaxDayToInactive);

            DialogResult result;

            if (now.ToShortDateString() == DateTime.Now.ToShortDateString()) 
            {
                result = MessageBox.Show("Personagem já Atualizado Hoje! \nDeseja realmente Atualiza-lo?","", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) 
                    return;

            }
            if (cbReborn.SelectedIndex < 0)
                cbReborn.SelectedIndex = 0;

            //character = new Character();
            if (!Character.VerifyCharacter(character.Nick))
                return;

            if (characterbase == null)
            {
                ProcessConsole.ProcessInformation("Erro ao tentar atualizar, Supostamente o Identificador esta fora. por favor selecione novamente o Perssonagem.");
                MessageBox.Show("Identificador de Perssonagem esta fora!");

                return;
            }
            
            
            //character = Character.GetCharacterByCode("Buscopan'");

            character.LastLevel = characterbase.Level;
            character.LastMerit = characterbase.Merit;
            character.LastOwner = characterbase.Owner;
            character.LastStatus = characterbase.Status;
            character.LastUpdated = characterbase.Updated;
            character.Level = Convert.ToInt32(txtLevel.Text);
            character.Merit = Convert.ToInt32(txtMerito.Text);
            character.Observation = rtbObservation.Text;
            character.Owner = GlobalSystem.usuario.Nick;

            if (cbRank.SelectedIndex <= -1)
                cbRank.SelectedIndex = 0;

            character.Rank = cbRank.SelectedItem.ToString();

            if (cbReborn.SelectedIndex <= -1)
                cbReborn.SelectedIndex = 0;

            character.Reborn = cbReborn.SelectedItem.ToString();

            character.Updated = DateTime.Now;

            if(rbSoldado.Checked)
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

            char tempEventMerit = 'D';

            tempEventMerit = character.EventMerit;

            //Se o evento tiver Ligado ele cadastra
            if (tempEventMerit == 'L')// L: Ligado
            {
                EventMerit noevento = new EventMerit();
                noevento.NickCharacter = character.Nick;
                noevento.FirstMerit = character.Merit;
                noevento.FirstOwner = character.Owner;
                character.EventMerit = 'D';
                EventMerit.Insert(noevento);
            }

            //se o evento estiver Aguarndando ele atualiza
            if (tempEventMerit == 'A') // A: Aguardandoo Final
            {
                try
                {
                    EventMerit noevento;
                    noevento = EventMerit.GetMemberOnEvent(character.Nick);
                    //noevento.NickCharacter = character.Nick;
                    noevento.LastMerit = character.Merit;
                    noevento.LastOwner = character.Owner;
                    EventMerit.Update(noevento);
                    character.EventMerit = 'D'; // D: Desligado
                }
                catch (Exception)
                {
                    ProcessConsole.ProcessMessage("Personagem com Evento Ativado mas nao foi encontrado no sistema, Modificando Status do evento para Desabilitado!");
                    character.EventMerit = 'D'; // D: Desligado
                }


            }

            Character.UpdateCharacter(character);


            characterbase = null;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ProcessConsole.ProcessProcessing("Consultar...");
            ListaMembros = null;
            if (
            #region Condicoes
                !cbSK.Checked &&
                !cbMY.Checked &&
                !cbWR.Checked &&
                !cbMG.Checked &&
                !cbWB.Checked &&
                !cbWF.Checked &&
                !cbEA.Checked &&
                !cbEP.Checked &&
                !cbAS.Checked &&
                !cbES.Checked &&
                !cbRE.Checked &&
                !cbTO.Checked

            #endregion
)
            {
                if (!cbAtivo.Checked &&
                !cbInativo.Checked &&
                !cbDesertor.Checked &&
                !cbBanido.Checked &&
                !cbAnalise.Checked &&
                !cbAusente.Checked) 
                {
                    #region Metodo Todos Os Perssonagens
                    ListaMembros = null;
                    ListaMembros = Character.GetAllCharacter();
                    ProcessConsole.ProcessProcessing(GlobalMessage.PopulateList);
                    //Popula a Lista de Perssonagens Encontrados
                    ListPopulate(ListaMembros, treeView1);

                    #endregion
                }
                else
                {
                    #region Metodo Todos por Status
                    string param = "";
                    if (cbAnalise.Checked)
                        param += "(1=1 and c.Status='" + GlobalSystem.Status.Análise + "') or ";
                    if (cbAtivo.Checked)
                        param += "(1=1 and c.Status='" + GlobalSystem.Status.Ativo + "') or ";
                    if (cbAusente.Checked)
                        param += "(1=1 and c.Status='" + GlobalSystem.Status.Ausente + "') or ";
                    if (cbBanido.Checked)
                        param += "(1=1 and c.Status='" + GlobalSystem.Status.Banido + "') or ";
                    if (cbDesertor.Checked)
                        param += "(1=1 and c.Status='" + GlobalSystem.Status.Desertor + "') or ";
                    if (cbInativo.Checked)
                        param += "(1=1 and c.Status='" + GlobalSystem.Status.Inativo + "') or ";

                    ListaMembros = null;
                    ListaMembros = Character.GetAllCharacter(param);
                    
                    if (ListaMembros == null)
                        return;

                    ProcessConsole.ProcessProcessing(GlobalMessage.PopulateList);
                    //Popula a Lista de Perssonagens Encontrados
                    ListPopulate(ListaMembros, treeView1);

                    #endregion
                }
            }
            else if (
            #region Condicoes
                !cbAtivo.Checked &&
                !cbInativo.Checked &&
                !cbDesertor.Checked &&
                !cbBanido.Checked &&
                !cbAnalise.Checked &&
                !cbAusente.Checked

            #endregion
)
            {
                string param = "";
                if (cbSK.Checked)
                    param += "(1=1 and c.Grade='" + GlobalSystem.Class.Arcano + "') or ";
                if (cbMY.Checked)
                    param += "(1=1 and c.Grade='" + GlobalSystem.Class.Mistico + "') or ";
                if (cbWR.Checked)
                    param += "(1=1 and c.Grade='" + GlobalSystem.Class.Guerreiro + "') or ";
                if (cbMG.Checked)
                    param += "(1=1 and c.Grade='" + GlobalSystem.Class.Mago + "') or ";
                if (cbWB.Checked)
                    param += "(1=1 and c.Grade='" + GlobalSystem.Class.Barbaro + "') or ";
                if (cbWF.Checked)
                    param += "(1=1 and c.Grade='" + GlobalSystem.Class.Feiticeira + "') or ";
                if (cbEA.Checked)
                    param += "(1=1 and c.Grade='" + GlobalSystem.Class.Arqueiro + "') or ";
                if (cbEP.Checked)
                    param += "(1=1 and c.Grade='" + GlobalSystem.Class.Sacerdote + "') or " ;
                if (cbAS.Checked)
                    param += "(1=1 and c.Grade='" + GlobalSystem.Class.Mercenário + "') or ";
                if (cbES.Checked)
                    param += "(1=1 and c.Grade='" + GlobalSystem.Class.Espiritualista + "') or ";
                if (cbTO.Checked)
                    param += "(1=1 and c.Grade='" + GlobalSystem.Class.Tormentador + "') or ";
                if (cbRE.Checked)
                    param += "(1=1 and c.Grade='" + GlobalSystem.Class.Retalhador + "') or ";

                ListaMembros = null;
                ListaMembros = Character.GetAllCharacter(param);

                if (ListaMembros == null)
                    return;
                
                //Popula a Lista de Perssonagens Encontrados
                ListPopulate(ListaMembros, treeView1);
                    

            }
            else
            {
                string ClassSql = "";
                string StatsSql = "";
                #region Filtros

                if (cbSK.Checked)
                    ClassSql += "(1=1 and c.Grade='" + GlobalSystem.Class.Arcano + "') or ";
                if (cbMY.Checked)
                    ClassSql += "(1=1 and c.Grade='" + GlobalSystem.Class.Mistico + "') or ";
                if (cbWR.Checked)
                    ClassSql += "(1=1 and c.Grade='" + GlobalSystem.Class.Guerreiro + "') or ";
                if (cbMG.Checked)
                    ClassSql += "(1=1 and c.Grade='" + GlobalSystem.Class.Mago + "') or ";
                if (cbWB.Checked)
                    ClassSql += "(1=1 and c.Grade='" + GlobalSystem.Class.Barbaro + "') or ";
                if (cbWF.Checked)
                    ClassSql += "(1=1 and c.Grade='" + GlobalSystem.Class.Feiticeira + "') or ";
                if (cbEA.Checked)
                    ClassSql += "(1=1 and c.Grade='" + GlobalSystem.Class.Arqueiro + "') or ";
                if (cbEP.Checked)
                    ClassSql += "(1=1 and c.Grade='" + GlobalSystem.Class.Sacerdote + "') or ";
                if (cbAS.Checked)
                    ClassSql += "(1=1 and c.Grade='" + GlobalSystem.Class.Mercenário + "') or ";
                if (cbES.Checked)
                    ClassSql += "(1=1 and c.Grade='" + GlobalSystem.Class.Espiritualista + "') or ";
                if (cbTO.Checked)
                    ClassSql += "(1=1 and c.Grade='" + GlobalSystem.Class.Tormentador + "') or ";
                if (cbRE.Checked)
                    ClassSql += "(1=1 and c.Grade='" + GlobalSystem.Class.Retalhador + "') or ";

                if (cbAtivo.Checked)
                    StatsSql += "(1=1 and c.Status='" + GlobalSystem.Status.Ativo + "') or ";
                if (cbInativo.Checked)
                    StatsSql += "(1=1 and c.Status='" + GlobalSystem.Status.Inativo + "') or ";
                if (cbDesertor.Checked)
                    StatsSql += "(1=1 and c.Status='" + GlobalSystem.Status.Desertor + "') or ";
                if (cbBanido.Checked)
                    StatsSql += "(1=1 and c.Status='" + GlobalSystem.Status.Banido + "') or ";
                if (cbAnalise.Checked)
                    StatsSql += "(1=1 and c.Status='" + GlobalSystem.Status.Análise + "') or ";
                if (cbAusente.Checked)
                    StatsSql += "(1=1 and c.Status='" + GlobalSystem.Status.Ausente + "') or ";

                #endregion
                ListaMembros = null;
               ListaMembros= Character.GetAllCharacterByFilter(ClassSql, StatsSql);
               
                if (ListaMembros == null)
                   return;
                ProcessConsole.ProcessProcessing(GlobalMessage.PopulateList);
               //Popula a Lista de Perssonagens Encontrados
               ListPopulate(ListaMembros, treeView1);

            }
        }

        public void ListPopulate(IList<Character> list, TreeView tree) 
        {
            ProcessConsole.ProcessProcessing(GlobalMessage.PopulateList);
            progBar.Maximum = list.Count;
            tree.Nodes.Clear();
            lblCountSK.Text = "0"; int countSK = 0;
            lblCountMY.Text = "0"; int countMY = 0;
            lblCountWR.Text = "0"; int countWR = 0;
            lblCountMG.Text = "0"; int countMG = 0;
            lblCountWB.Text = "0"; int countWB = 0;
            lblCountWF.Text = "0"; int countWF = 0;
            lblCountEA.Text = "0"; int countEA = 0;
            lblCountEP.Text = "0"; int countEP = 0;
            lblCountAS.Text = "0"; int countAS = 0;
            lblCountES.Text = "0"; int countES = 0;
            lblCountRE.Text = "0"; int countRE = 0;
            lblCountTO.Text = "0"; int countTO = 0;
            lblTotal.Text = "0"; int countTotal = 0;
            lblCountND.Text = "0"; int countND = 0;

            #region Metodo Todos Os Perssonagens

            foreach (Character m in list)
            {
                progBar.Value++;
                #region Contagem das Classes
                if (m.Grade == GlobalSystem.Class.Arcano.ToString())
                    countSK++;
                else if (m.Grade == GlobalSystem.Class.Mistico.ToString())
                    countMY++;
                else if (m.Grade == GlobalSystem.Class.Guerreiro.ToString())
                    countWR++;
                else if (m.Grade == GlobalSystem.Class.Mago.ToString())
                    countMG++;
                else if (m.Grade == GlobalSystem.Class.Barbaro.ToString())
                    countWB++;
                else if (m.Grade == GlobalSystem.Class.Feiticeira.ToString())
                    countWF++;
                else if (m.Grade == GlobalSystem.Class.Arqueiro.ToString())
                    countEA++;
                else if (m.Grade == GlobalSystem.Class.Sacerdote.ToString())
                    countEP++;
                else if (m.Grade == GlobalSystem.Class.Mercenário.ToString())
                    countAS++;
                else if (m.Grade == GlobalSystem.Class.Espiritualista.ToString())
                    countES++;
                else if (m.Grade == GlobalSystem.Class.Retalhador.ToString())
                    countRE++;
                else if (m.Grade == GlobalSystem.Class.Tormentador.ToString())
                    countTO++;
                else
                {
                    m.Grade = GlobalSystem.Common.NãoDeterminado.ToString();
                    countND++;
                }

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
            ProcessConsole.ProcessDone("Lista Populada!");
            #endregion
            lblCountSK.Text = countSK.ToString();
            lblCountMY.Text = countMY.ToString();
            lblCountWR.Text = countWR.ToString();
            lblCountMG.Text = countMG.ToString();
            lblCountWB.Text = countWB.ToString();
            lblCountWF.Text = countWF.ToString();
            lblCountEA.Text = countEA.ToString();
            lblCountEP.Text = countEP.ToString();
            lblCountAS.Text = countAS.ToString();
            lblCountES.Text = countES.ToString();
            lblCountRE.Text = countRE.ToString();
            lblCountTO.Text = countTO.ToString();
            lblTotal.Text = list.Count.ToString();
            lblCountND.Text = countND.ToString();
            progBar.Value = 0;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            txtAtualizado.ForeColor = Color.White;
            try 
            {
                string sql = "";
                foreach (Character c in ListaMembros) 
                {
                    if (c.Nick == treeView1.SelectedNode.Text)
                    {
                        character = Character.GetCharacterByCode(c.Id);
                        characterbase = character;
                        continue;
                    }
                }

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

                btnRecrutante.Text = character.Recruter;
                btnIndicator.Text = character.Idicated;
                txtMerito.Text = character.Merit.ToString();
                txtMeriAnterior.Text = character.LastMerit.ToString();
                txtAtualizado.Text = character.Updated.ToShortDateString();
                txtUltAtt.Text = character.LastUpdated.ToShortDateString();
                txtOwner.Text = character.Owner;
                

                if (character.EventMerit == 'A')
                {
                    chkEventAguardando.Checked = true;
                    chkEventLigado.Checked = false;
                    chkEventDesligado.Checked = false;
                }else if (character.EventMerit == 'L')
                {
                    chkEventAguardando.Checked = false;
                    chkEventLigado.Checked = true;
                    chkEventDesligado.Checked = false;
                }
                else if(character.EventMerit == 'D')
                {
                    chkEventAguardando.Checked = false;
                    chkEventLigado.Checked = false;
                    chkEventDesligado.Checked = true;
                }
                else
                {
                    chkEventAguardando.Checked = false;
                    chkEventLigado.Checked = false;
                    chkEventDesligado.Checked = false;
                }

               
                DateTime now = new DateTime();
                DateTime update = new DateTime();
                DateTime updatefix = new DateTime();
                now = DateTime.Now;
                update = character.Updated;

                updatefix = update.AddDays(GlobalSystem.MaxDayToInactive);
                txtDatRecomendado.Text = updatefix.ToShortDateString();
                if (updatefix.Date < now.Date) 
                {
                    txtAtualizado.ForeColor = Color.Salmon;
                    MessageBox.Show("Perssonagem Desatualizado!");

                }

                if (character.Office == GlobalSystem.Cargo.Soldado.ToString())
                    rbSoldado.Checked = true;
                if (character.Office == GlobalSystem.Cargo.Capitão.ToString())
                    rbCapitao.Checked = true;
                if (character.Office == GlobalSystem.Cargo.Major.ToString())
                    rbMajor.Checked = true;
                if (character.Office == GlobalSystem.Cargo.General.ToString())
                    rbGeneral.Checked = true;
                if (character.Office == GlobalSystem.Cargo.Marechal.ToString())
                    rbMarechal.Checked = true;

                if (character.Status == GlobalSystem.Status.Ativo.ToString())
                    rbAtivo.Checked = true;
                if (character.Status == GlobalSystem.Status.Inativo.ToString())
                    rbInativo.Checked = true;
                if (character.Status == GlobalSystem.Status.Desertor.ToString())
                    rbDesertor.Checked = true;
                if (character.Status == GlobalSystem.Status.Banido.ToString())
                    rbBanido.Checked = true;
                if (character.Status == GlobalSystem.Status.Ausente.ToString())
                    rbAusente.Checked = true;
                if (character.Status == GlobalSystem.Status.Análise.ToString())
                    rbAnalise.Checked = true;
                
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
            catch (Exception erro) 
            {
                ProcessConsole.ProcessBreak(erro);
            }
        }

        private void btnSK_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[71])//71
            {
                if (GlobalPermission.permissionIndex[72])
                {
                    ControlModifier.ButtonColorChanger(0, btnClass);
                    character.Grade = GlobalSystem.Class.Arcano.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }
        private void btnMY_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[71])
            {
                if (GlobalPermission.permissionIndex[73])
                {
                    ControlModifier.ButtonColorChanger(1, btnClass);
                    character.Grade = GlobalSystem.Class.Mistico.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }
        private void btnWR_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[71])
            {
                if (GlobalPermission.permissionIndex[74])
                {
                    ControlModifier.ButtonColorChanger(2, btnClass);
                    character.Grade = GlobalSystem.Class.Guerreiro.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }
        private void btnMG_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[71])
            {
                if (GlobalPermission.permissionIndex[75])
                {
                    ControlModifier.ButtonColorChanger(3, btnClass);
                    character.Grade = GlobalSystem.Class.Mago.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }
        private void btnEA_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[71])
            {
                if (GlobalPermission.permissionIndex[76])
                {
                    ControlModifier.ButtonColorChanger(4, btnClass);
                    character.Grade = GlobalSystem.Class.Arqueiro.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }
        private void btnEP_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[71])
            {
                if (GlobalPermission.permissionIndex[77])
                {
                    ControlModifier.ButtonColorChanger(5, btnClass);
                    character.Grade = GlobalSystem.Class.Sacerdote.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }
        private void btnWB_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[71])
            {
                if (GlobalPermission.permissionIndex[78])
                {
                    ControlModifier.ButtonColorChanger(6, btnClass);
                    character.Grade = GlobalSystem.Class.Barbaro.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }
        private void btnWF_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[71])
            {
                if (GlobalPermission.permissionIndex[79])
                {
                    ControlModifier.ButtonColorChanger(7, btnClass);
                    character.Grade = GlobalSystem.Class.Feiticeira.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }
        private void btnAS_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[71])
            {
                if (GlobalPermission.permissionIndex[80])
                {
                    ControlModifier.ButtonColorChanger(8, btnClass);
                    character.Grade = GlobalSystem.Class.Mercenário.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }
        private void btnES_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[71])
            {
                if (GlobalPermission.permissionIndex[81])
                {
                    ControlModifier.ButtonColorChanger(9, btnClass);
                    character.Grade = GlobalSystem.Class.Espiritualista.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }
        private void btnRET_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[71])
            {
                if (GlobalPermission.permissionIndex[82])
                {
                    ControlModifier.ButtonColorChanger(10, btnClass);
                    character.Grade = GlobalSystem.Class.Retalhador.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }
        private void btnTOR_Click(object sender, EventArgs e)
        {
            if (GlobalPermission.permissionIndex[71])
            {
                if (GlobalPermission.permissionIndex[83])
                {
                    ControlModifier.ButtonColorChanger(11, btnClass);
                    character.Grade = GlobalSystem.Class.Tormentador.ToString();
                    ProcessConsole.ProcessProcessing("Classe Selecionada: " + character.Grade);
                }
            }
        }

        private void txtNick_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btnNick_Click(object sender, EventArgs e)
        {
            string str = Clipboard.GetText();
            if (str.Length < 10)
            {
                btnNick.Text = Clipboard.GetText();

                character = Character.GetCharacterByName(btnNick.Text);




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

                btnRecrutante.Text = character.Recruter;
                btnIndicator.Text = character.Idicated;
                txtMerito.Text = character.Merit.ToString();
                txtMeriAnterior.Text = character.LastMerit.ToString();
                txtAtualizado.Text = character.Updated.ToShortDateString();
                txtUltAtt.Text = character.LastUpdated.ToShortDateString();
                txtOwner.Text = character.Owner;


                GlobalSystem.MaxDayToInactive = 20;
                DateTime now = new DateTime();
                DateTime update = new DateTime();
                DateTime updatefix = new DateTime();
                now = DateTime.Now;
                update = character.Updated;

                updatefix = update.AddDays(GlobalSystem.MaxDayToInactive);
                txtDatRecomendado.Text = updatefix.ToShortDateString();
                if (updatefix.Date < now.Date) 
                {
                    txtAtualizado.ForeColor = Color.Salmon;
                    MessageBox.Show("Perssonagem Desatualizado!");

                }

                if (character.Office == GlobalSystem.Cargo.Soldado.ToString())
                    rbSoldado.Checked = true;
                if (character.Office == GlobalSystem.Cargo.Capitão.ToString())
                    rbCapitao.Checked = true;
                if (character.Office == GlobalSystem.Cargo.Major.ToString())
                    rbMajor.Checked = true;
                if (character.Office == GlobalSystem.Cargo.General.ToString())
                    rbGeneral.Checked = true;
                if (character.Office == GlobalSystem.Cargo.Marechal.ToString())
                    rbMarechal.Checked = true;

                if (character.Status == GlobalSystem.Status.Ativo.ToString())
                    rbAtivo.Checked = true;
                if (character.Status == GlobalSystem.Status.Inativo.ToString())
                    rbInativo.Checked = true;
                if (character.Status == GlobalSystem.Status.Desertor.ToString())
                    rbDesertor.Checked = true;
                if (character.Status == GlobalSystem.Status.Banido.ToString())
                    rbBanido.Checked = true;
                if (character.Status == GlobalSystem.Status.Ausente.ToString())
                    rbAusente.Checked = true;
                if (character.Status == GlobalSystem.Status.Análise.ToString())
                    rbAnalise.Checked = true;
                
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

        private void windUpdateCharacter_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.gclogoicon;
        }
    }
}




