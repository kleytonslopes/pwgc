using Engine;
using Engine.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PWGC_Ultmater
{
    public partial class windUserAdmin : Form
    {
        IList<User> usuarios;
        User usuario;
        IList<Permissions> permission;
        IList<Permissions> permissions;
        Permissions perm;

        public Permissions newPermission = new Permissions();

        public List<CheckBox> checkers;
        public windUserAdmin()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.gclogoicon;
        }

        private void windUserAdmin_Load(object sender, EventArgs e)
        {
            usuarios = User.GetAllUser();
            foreach (User u in usuarios)
            {
                treeView1.Nodes.Add(u.Login, u.Login);
            }
            permissions = Permissions.GetAllPermission();
            foreach (Permissions p in permissions) 
            {
                comboUserPermission.Items.Add(p.Id);
            }
            #region Set Controles de Permissoes
            checkers = new List<CheckBox>();

            checkers.Add(chk_Geral_Cad);            //[0].
            checkers.Add(chk_Cad_Cadastrar);        //[1].
            checkers.Add(chk_Cad_Verificar);        //[2].
            checkers.Add(chk_Cad_Cargo);            //[3].
            checkers.Add(chk_Cad_Cargo_Soldado);    //[4].
            checkers.Add(chk_Cad_Cargo_Capitao);    //[5].
            checkers.Add(chk_Cad_Cargo_Major);      //[6].
            checkers.Add(chk_Cad_Cargo_General);    //[7].
            checkers.Add(chk_Cad_Cargo_Marechal);   //[8].
            checkers.Add(chk_Cad_Rank);             //[9].
            checkers.Add(chk_Cad_Rank_1);           //[10]

            checkers.Add(chk_Cad_Rank_2);           //[11]
            checkers.Add(chk_Cad_Rank_3);           //[12]
            checkers.Add(chk_Cad_Rank_4);           //[13]
            checkers.Add(chk_Cad_Rank_5);           //[14]
            checkers.Add(chk_Cad_Rank_6);           //[15]
            checkers.Add(chk_Cad_Rank_7);           //[16]
            checkers.Add(chk_Cad_Rank_8);           //[17]
            checkers.Add(chk_Cad_Rank_9);           //[18]
            checkers.Add(chk_Cad_Status);           //[19]
            checkers.Add(chk_Cad_Status_1);         //[20]

            checkers.Add(chk_Cad_Status_2);         //[21]
            checkers.Add(chk_Cad_Status_3);         //[22]
            checkers.Add(chk_Cad_Status_4);         //[23]
            checkers.Add(chk_Cad_Status_5);         //[24]
            checkers.Add(chk_Cad_Status_6);         //[25]
            checkers.Add(chk_Cad_Classe);           //[26]
            checkers.Add(chk_Cad_Classe_1);         //[27]
            checkers.Add(chk_Cad_Classe_2);         //[28]
            checkers.Add(chk_Cad_Classe_3);         //[29]
            checkers.Add(chk_Cad_Classe_4);         //[30]

            checkers.Add(chk_Cad_Classe_5);         //[31]
            checkers.Add(chk_Cad_Classe_6);         //[32]
            checkers.Add(chk_Cad_Classe_7);         //[33]
            checkers.Add(chk_Cad_Classe_8);         //[34]
            checkers.Add(chk_Cad_Classe_9);         //[35]
            checkers.Add(chk_Cad_Classe_10);        //[36]
            checkers.Add(chk_Cad_Classe_11);        //[37]
            checkers.Add(chk_Cad_Classe_12);//41    //[38]
            checkers.Add(chk_Cad_Reborn);           //[39]
            checkers.Add(chk_Cad_Reborn_1);         //[40]

            checkers.Add(chk_Cad_Reborn_2);         //[41]
            checkers.Add(chk_Geral_Edit);           //[42]
            checkers.Add(chk_Edit_Alterar);         //[43]
            checkers.Add(chk_Edit_Excluir);         //[44]
            checkers.Add(chk_Edit_SetObs);          //[45]
            checkers.Add(chk_Edit_Cargo);           //[46]
            checkers.Add(chk_Edit_Cargo_1);         //[47]
            checkers.Add(chk_Edit_Cargo_2);         //[48]
            checkers.Add(chk_Edit_Cargo_3);         //[49]
            checkers.Add(chk_Edit_Cargo_4);         //[50]
            
            checkers.Add(chk_Edit_Cargo_5);         //[51]
            checkers.Add(chk_Edit_Rank);            //[52]
            checkers.Add(chk_Edit_Rank_1);          //[53]
            checkers.Add(chk_Edit_Rank_2);          //[54]
            checkers.Add(chk_Edit_Rank_3);          //[55]
            checkers.Add(chk_Edit_Rank_4);          //[56]
            checkers.Add(chk_Edit_Rank_5);          //[57]
            checkers.Add(chk_Edit_Rank_6);          //[58]
            checkers.Add(chk_Edit_Rank_7);          //[59]
            checkers.Add(chk_Edit_Rank_8);          //[60]

            checkers.Add(chk_Edit_Rank_9);          //[61]
            checkers.Add(chk_Edit_Status);          //[62]
            checkers.Add(chk_Edit_Status_1);        //[63]
            checkers.Add(chk_Edit_Status_2);        //[64]
            checkers.Add(chk_Edit_Status_3);        //[65]
            checkers.Add(chk_Edit_Status_4);        //[66]
            checkers.Add(chk_Edit_Status_5);        //[67]
            checkers.Add(chk_Edit_Status_6);        //[68]
            checkers.Add(chk_Edit_Reborn);          //[69]
            checkers.Add(chk_Edit_Reborn_1);        //[70]

            checkers.Add(chk_Edit_Reborn_2);        //[71]
            checkers.Add(chk_Edit_Classe);          //[72]
            checkers.Add(chk_Edit_Classe_1);        //[73]
            checkers.Add(chk_Edit_Classe_2);        //[74]
            checkers.Add(chk_Edit_Classe_3);        //[75]
            checkers.Add(chk_Edit_Classe_4);        //[76]
            checkers.Add(chk_Edit_Classe_5);        //[77]
            checkers.Add(chk_Edit_Classe_6);        //[78]
            checkers.Add(chk_Edit_Classe_7);        //[79]
            checkers.Add(chk_Edit_Classe_8);        //[80]

            checkers.Add(chk_Edit_Classe_9);        //[81]
            checkers.Add(chk_Edit_Classe_10);       //[82]
            checkers.Add(chk_Edit_Classe_11);       //[83]
            checkers.Add(chk_Edit_Classe_12);       //[84]
            checkers.Add(chk_Edit_Consultar);       //[85]

            checkers.Add(chk_admin);                //[86]
            checkers.Add(chk_admin_user);           //[87]
            checkers.Add(chk_admin_character);      //[88]
            checkers.Add(chk_admin_event);          //[89]
            checkers.Add(chk_admin_system);         //[90]
            checkers.Add(chk_admin_global);         //[91]


            #endregion

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                //seta desabilitado para todos os checkbox de permissoes
                for (int i = 0; i < checkers.Count; i++)
                {
                    checkers[i].Checked = false;
                }

                string sql = "";
                foreach (User u in usuarios)
                {
                    if (u.Login == treeView1.SelectedNode.Text)
                    {
                        usuario = u;

                        permission = User.GetMePermission(u.Permission);
                        tsslbIdUsu.Text = u.ID.ToString();
                        tsslbIdPerm.Text = u.Permission.ToString();
                        txt_user_id.Text = u.ID.ToString();
                        txt_user_login.Text = u.Login;
                        txt_user_pass.Text = u.Password;
                        txt_user_nick.Text = u.Nick;
                        txt_user_lastlogin.Text = u.LastLogin.ToString();
                        comboUserPermission.Text = u.Permission.ToString();

                        if (u.Blocked == "S")
                            checkBox1.Checked = true;
                        else
                            checkBox1.Checked = false;
                        
                        button2.Enabled = true;
                        foreach (Permissions p in permission)
                        {
                            perm = p;
                            CheckBoxGetPermissions(p);
                        }
                        break;

                    }
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);

            }
        }

        public void CheckBoxGetPermissions(Permissions p)
        {

            string Use = "S";
            if (p.permCatCad            == Use) checkers[0].Checked = true; // cadastrar
            if (p.permCatCadInsert      == Use) checkers[1].Checked = true; // inserir
            if (p.permCatCadVerify      == Use) checkers[2].Checked = true; // verificar
            if (p.permCatCadCarg        == Use) checkers[3].Checked = true; // cargos
            if (p.permCatCadCarg_1      == Use) checkers[4].Checked = true; // cargo 1 soldado
            if (p.permCatCadCarg_2      == Use) checkers[5].Checked = true; // cargo 2 capitao
            if (p.permCatCadCarg_3      == Use) checkers[6].Checked = true; // cargo 3 major
            if (p.permCatCadCarg_4      == Use) checkers[7].Checked = true; // cargo 4 general
            if (p.permCatCadCarg_5      == Use) checkers[8].Checked = true; // cargo 5 marechal
            if (p.permCatCadRank        == Use) checkers[9].Checked = true; // ranck
            if (p.permCatCadRank_1      == Use) checkers[10].Checked = true;//

            if (p.permCatCadRank_2      == Use) checkers[11].Checked = true;
            if (p.permCatCadRank_3      == Use) checkers[12].Checked = true;
            if (p.permCatCadRank_4      == Use) checkers[13].Checked = true;
            if (p.permCatCadRank_5      == Use) checkers[14].Checked = true;
            if (p.permCatCadRank_6      == Use) checkers[15].Checked = true;
            if (p.permCatCadRank_7      == Use) checkers[16].Checked = true;
            if (p.permCatCadRank_8      == Use) checkers[17].Checked = true;
            if (p.permCatCadRank_9      == Use) checkers[18].Checked = true;
            if (p.permCatCadStat        == Use) checkers[19].Checked = true;
            if (p.permCatCadStat_1      == Use) checkers[20].Checked = true;

            if (p.permCatCadStat_2      == Use) checkers[21].Checked = true;
            if (p.permCatCadStat_3      == Use) checkers[22].Checked = true;
            if (p.permCatCadStat_4      == Use) checkers[23].Checked = true;
            if (p.permCatCadStat_5      == Use) checkers[24].Checked = true;
            if (p.permCatCadStat_6      == Use) checkers[25].Checked = true;
            if (p.permCatCadClass       == Use) checkers[26].Checked = true;
            if (p.permCatCadClass_1     == Use) checkers[27].Checked = true;
            if (p.permCatCadClass_2     == Use) checkers[28].Checked = true;
            if (p.permCatCadClass_3     == Use) checkers[29].Checked = true;
            if (p.permCatCadClass_4     == Use) checkers[30].Checked = true;

            if (p.permCatCadClass_5     == Use) checkers[31].Checked = true;
            if (p.permCatCadClass_6     == Use) checkers[32].Checked = true;
            if (p.permCatCadClass_7     == Use) checkers[33].Checked = true;
            if (p.permCatCadClass_8     == Use) checkers[34].Checked = true;
            if (p.permCatCadClass_9     == Use) checkers[35].Checked = true;
            if (p.permCatCadClass_10    == Use) checkers[36].Checked = true;
            if (p.permCatCadClass_11    == Use) checkers[37].Checked = true;
            if (p.permCatCadClass_12    == Use) checkers[38].Checked = true;
            if (p.permCatCadReborn      == Use) checkers[39].Checked = true;
            if (p.permCatCadReborn_1    == Use) checkers[40].Checked = true;

            if (p.permCatCadReborn_2    == Use) checkers[41].Checked = true;
            if (p.permEditEdit          == Use) checkers[42].Checked = true;
            if (p.permEditAlter         == Use) checkers[43].Checked = true;
            if (p.permEditExclu         == Use) checkers[44].Checked = true;
            if (p.permEditSetob         == Use) checkers[45].Checked = true;
            if (p.permEditCargo         == Use) checkers[46].Checked = true;
            if (p.permEditCargo_1       == Use) checkers[47].Checked = true;
            if (p.permEditCargo_2       == Use) checkers[48].Checked = true;
            if (p.permEditCargo_3       == Use) checkers[49].Checked = true;
            if (p.permEditCargo_4       == Use) checkers[50].Checked = true;

            if (p.permEditCargo_5       == Use) checkers[51].Checked = true;
            if (p.permEditRank          == Use) checkers[52].Checked = true;
            if (p.permEditRank_1        == Use) checkers[53].Checked = true;
            if (p.permEditRank_2        == Use) checkers[54].Checked = true;
            if (p.permEditRank_3        == Use) checkers[55].Checked = true;
            if (p.permEditRank_4        == Use) checkers[56].Checked = true;
            if (p.permEditRank_5        == Use) checkers[57].Checked = true;
            if (p.permEditRank_6        == Use) checkers[58].Checked = true;
            if (p.permEditRank_7        == Use) checkers[59].Checked = true;
            if (p.permEditRank_8        == Use) checkers[60].Checked = true;

            if (p.permEditRank_9        == Use) checkers[61].Checked = true;
            if (p.permEditStatus        == Use) checkers[62].Checked = true;
            if (p.permEditStatus_1      == Use) checkers[63].Checked = true;
            if (p.permEditStatus_2      == Use) checkers[64].Checked = true;
            if (p.permEditStatus_3      == Use) checkers[65].Checked = true;
            if (p.permEditStatus_4      == Use) checkers[66].Checked = true;
            if (p.permEditStatus_5      == Use) checkers[67].Checked = true;
            if (p.permEditStatus_6      == Use) checkers[68].Checked = true;
            if (p.permEditReborn        == Use) checkers[69].Checked = true;
            if (p.permEditReborn_1      == Use) checkers[70].Checked = true;

            if (p.permEditReborn_2      == Use) checkers[71].Checked = true;
            if (p.permEditClass         == Use) checkers[72].Checked = true;
            if (p.permEditClass_1       == Use) checkers[73].Checked = true;
            if (p.permEditClass_2       == Use) checkers[74].Checked = true;
            if (p.permEditClass_3       == Use) checkers[75].Checked = true;
            if (p.permEditClass_4       == Use) checkers[76].Checked = true;
            if (p.permEditClass_5       == Use) checkers[77].Checked = true;
            if (p.permEditClass_6       == Use) checkers[78].Checked = true;
            if (p.permEditClass_7       == Use) checkers[79].Checked = true;
            if (p.permEditClass_8       == Use) checkers[80].Checked = true;

            if (p.permEditClass_9       == Use) checkers[81].Checked = true;
            if (p.permEditClass_10      == Use) checkers[82].Checked = true;
            if (p.permEditClass_11      == Use) checkers[83].Checked = true;
            if (p.permEditClass_12      == Use) checkers[84].Checked = true;

            if (p.permEditConsultar     == Use) checkers[85].Checked = true;
            if (p.permAdmin             == Use) checkers[86].Checked = true;
            if (p.permAdminUser         == Use) checkers[87].Checked = true;
            if (p.permAdminCharacter    == Use) checkers[88].Checked = true;
            if (p.permAdminEvent        == Use) checkers[89].Checked = true;
            if (p.permAdminSystem       == Use) checkers[90].Checked = true;
            if (p.permAdminGlobal       == Use) checkers[91].Checked = true;

        }
        public void SetPropertyPermission(Permissions p)
        {

            if(checkers[0].Checked ){p.permCatCad            =  "S";}else{p.permCatCad            = "N";}
            if(checkers[1].Checked ){p.permCatCadInsert      =  "S";}else{p.permCatCadInsert      = "N";}
            if(checkers[2].Checked ){p.permCatCadVerify      =  "S";}else{p.permCatCadVerify      = "N";}
            if(checkers[3].Checked ){p.permCatCadCarg        =  "S";}else{p.permCatCadCarg        = "N";}
            if(checkers[4].Checked ){p.permCatCadCarg_1      =  "S";}else{p.permCatCadCarg_1      = "N";}
            if(checkers[5].Checked ){p.permCatCadCarg_2      =  "S";}else{p.permCatCadCarg_2      = "N";}
            if(checkers[6].Checked ){p.permCatCadCarg_3      =  "S";}else{p.permCatCadCarg_3      = "N";}
            if(checkers[7].Checked ){p.permCatCadCarg_4      =  "S";}else{p.permCatCadCarg_4      = "N";}
            if(checkers[8].Checked ){p.permCatCadCarg_5      =  "S";}else{p.permCatCadCarg_5      = "N";}
            if(checkers[9].Checked ){p.permCatCadRank        =  "S";}else{p.permCatCadRank        = "N";}
            if(checkers[10].Checked){p.permCatCadRank_1      =  "S";}else{p.permCatCadRank_1      = "N";}
            
            if(checkers[11].Checked){p.permCatCadRank_2      =  "S";}else{p.permCatCadRank_2      = "N";}
            if(checkers[12].Checked){p.permCatCadRank_3      =  "S";}else{p.permCatCadRank_3      = "N";}
            if(checkers[13].Checked){p.permCatCadRank_4      =  "S";}else{p.permCatCadRank_4      = "N";}
            if(checkers[14].Checked){p.permCatCadRank_5      =  "S";}else{p.permCatCadRank_5      = "N";}
            if(checkers[15].Checked){p.permCatCadRank_6      =  "S";}else{p.permCatCadRank_6      = "N";}
            if(checkers[16].Checked){p.permCatCadRank_7      =  "S";}else{p.permCatCadRank_7      = "N";}
            if(checkers[17].Checked){p.permCatCadRank_8      =  "S";}else{p.permCatCadRank_8      = "N";}
            if(checkers[18].Checked){p.permCatCadRank_9      =  "S";}else{p.permCatCadRank_9      = "N";}
            if(checkers[19].Checked){p.permCatCadStat        =  "S";}else{p.permCatCadStat        = "N";}
            if(checkers[20].Checked){p.permCatCadStat_1      =  "S";}else{p.permCatCadStat_1      = "N";}
            
            if(checkers[21].Checked){p.permCatCadStat_2      =  "S";}else{p.permCatCadStat_2      = "N";}
            if(checkers[22].Checked){p.permCatCadStat_3      =  "S";}else{p.permCatCadStat_3      = "N";}
            if(checkers[23].Checked){p.permCatCadStat_4      =  "S";}else{p.permCatCadStat_4      = "N";}
            if(checkers[24].Checked){p.permCatCadStat_5      =  "S";}else{p.permCatCadStat_5      = "N";}
            if(checkers[25].Checked){p.permCatCadStat_6      =  "S";}else{p.permCatCadStat_6      = "N";}
            if(checkers[26].Checked){p.permCatCadClass       =  "S";}else{p.permCatCadClass       = "N";}
            if(checkers[27].Checked){p.permCatCadClass_1     =  "S";}else{p.permCatCadClass_1     = "N";}
            if(checkers[28].Checked){p.permCatCadClass_2     =  "S";}else{p.permCatCadClass_2     = "N";}
            if(checkers[29].Checked){p.permCatCadClass_3     =  "S";}else{p.permCatCadClass_3     = "N";}
            if(checkers[30].Checked){p.permCatCadClass_4     =  "S";}else{p.permCatCadClass_4     = "N";}
            
            if(checkers[31].Checked){p.permCatCadClass_5     =  "S";}else{p.permCatCadClass_5     = "N";}
            if(checkers[32].Checked){p.permCatCadClass_6     =  "S";}else{p.permCatCadClass_6     = "N";}
            if(checkers[33].Checked){p.permCatCadClass_7     =  "S";}else{p.permCatCadClass_7     = "N";}
            if(checkers[34].Checked){p.permCatCadClass_8     =  "S";}else{p.permCatCadClass_8     = "N";}
            if(checkers[35].Checked){p.permCatCadClass_9     =  "S";}else{p.permCatCadClass_9     = "N";}
            if(checkers[36].Checked){p.permCatCadClass_10    =  "S";}else{p.permCatCadClass_10    = "N";}
            if(checkers[37].Checked){p.permCatCadClass_11    =  "S";}else{p.permCatCadClass_11    = "N";}
            if(checkers[38].Checked){p.permCatCadClass_12    =  "S";}else{p.permCatCadClass_12    = "N";}
            if(checkers[39].Checked){p.permCatCadReborn      =  "S";}else{p.permCatCadReborn      = "N";}
            if(checkers[40].Checked){p.permCatCadReborn_1    =  "S";}else{p.permCatCadReborn_1    = "N";}
            
            if(checkers[41].Checked){p.permCatCadReborn_2    =  "S";}else{p.permCatCadReborn_2    = "N";}
            if(checkers[42].Checked){p.permEditEdit          =  "S";}else{p.permEditEdit          = "N";}
            if(checkers[43].Checked){p.permEditAlter         =  "S";}else{p.permEditAlter         = "N";}
            if(checkers[44].Checked){p.permEditExclu         =  "S";}else{p.permEditExclu         = "N";}
            if(checkers[45].Checked){p.permEditSetob         =  "S";}else{p.permEditSetob         = "N";}
            if(checkers[46].Checked){p.permEditCargo         =  "S";}else{p.permEditCargo         = "N";}
            if(checkers[47].Checked){p.permEditCargo_1       =  "S";}else{p.permEditCargo_1       = "N";}
            if(checkers[48].Checked){p.permEditCargo_2       =  "S";}else{p.permEditCargo_2       = "N";}
            if(checkers[49].Checked){p.permEditCargo_3       =  "S";}else{p.permEditCargo_3       = "N";}
            if(checkers[50].Checked){p.permEditCargo_4       =  "S";}else{p.permEditCargo_4       = "N";}
            
            if(checkers[51].Checked){p.permEditCargo_5       =  "S";}else{p.permEditCargo_5       = "N";}
            if(checkers[52].Checked){p.permEditRank          =  "S";}else{p.permEditRank          = "N";}
            if(checkers[53].Checked){p.permEditRank_1        =  "S";}else{p.permEditRank_1        = "N";}
            if(checkers[54].Checked){p.permEditRank_2        =  "S";}else{p.permEditRank_2        = "N";}
            if(checkers[55].Checked){p.permEditRank_3        =  "S";}else{p.permEditRank_3        = "N";}
            if(checkers[56].Checked){p.permEditRank_4        =  "S";}else{p.permEditRank_4        = "N";}
            if(checkers[57].Checked){p.permEditRank_5        =  "S";}else{p.permEditRank_5        = "N";}
            if(checkers[58].Checked){p.permEditRank_6        =  "S";}else{p.permEditRank_6        = "N";}
            if(checkers[59].Checked){p.permEditRank_7        =  "S";}else{p.permEditRank_7        = "N";}
            if(checkers[60].Checked){p.permEditRank_8        =  "S";}else{p.permEditRank_8        = "N";}
            
            if(checkers[61].Checked){p.permEditRank_9        =  "S";}else{p.permEditRank_9        = "N";}
            if(checkers[62].Checked){p.permEditStatus        =  "S";}else{p.permEditStatus        = "N";}
            if(checkers[63].Checked){p.permEditStatus_1      =  "S";}else{p.permEditStatus_1      = "N";}
            if(checkers[64].Checked){p.permEditStatus_2      =  "S";}else{p.permEditStatus_2      = "N";}
            if(checkers[65].Checked){p.permEditStatus_3      =  "S";}else{p.permEditStatus_3      = "N";}
            if(checkers[66].Checked){p.permEditStatus_4      =  "S";}else{p.permEditStatus_4      = "N";}
            if(checkers[67].Checked){p.permEditStatus_5      =  "S";}else{p.permEditStatus_5      = "N";}
            if(checkers[68].Checked){p.permEditStatus_6      =  "S";}else{p.permEditStatus_6      = "N";}
            if(checkers[69].Checked){p.permEditReborn        =  "S";}else{p.permEditReborn        = "N";}
            if(checkers[70].Checked){p.permEditReborn_1      =  "S";}else{p.permEditReborn_1      = "N";}
            
            if(checkers[71].Checked){p.permEditReborn_2      =  "S";}else{p.permEditReborn_2      = "N";}
            if(checkers[72].Checked){p.permEditClass         =  "S";}else{p.permEditClass         = "N";}
            if(checkers[73].Checked){p.permEditClass_1       =  "S";}else{p.permEditClass_1       = "N";}
            if(checkers[74].Checked){p.permEditClass_2       =  "S";}else{p.permEditClass_2       = "N";}
            if(checkers[75].Checked){p.permEditClass_3       =  "S";}else{p.permEditClass_3       = "N";}
            if(checkers[76].Checked){p.permEditClass_4       =  "S";}else{p.permEditClass_4       = "N";}
            if(checkers[77].Checked){p.permEditClass_5       =  "S";}else{p.permEditClass_5       = "N";}
            if(checkers[78].Checked){p.permEditClass_6       =  "S";}else{p.permEditClass_6       = "N";}
            if(checkers[79].Checked){p.permEditClass_7       =  "S";}else{p.permEditClass_7       = "N";}
            if(checkers[80].Checked){p.permEditClass_8       =  "S";}else{p.permEditClass_8       = "N";}
            
            if(checkers[81].Checked){p.permEditClass_9       =  "S";}else{p.permEditClass_9       = "N";}
            if(checkers[82].Checked){p.permEditClass_10      =  "S";}else{p.permEditClass_10      = "N";}
            if(checkers[83].Checked){p.permEditClass_11      =  "S";}else{p.permEditClass_11      = "N";}
            if(checkers[84].Checked){p.permEditClass_12      =  "S";}else{p.permEditClass_12      = "N";}
            
            if(checkers[85].Checked){ p.permEditConsultar    =  "S";}else{p.permEditConsultar     = "N";}
            if(checkers[86].Checked){ p.permAdmin            =  "S";}else{ p.permAdmin            = "N"; }
            if(checkers[87].Checked){ p.permAdminUser        =  "S";}else{ p.permAdminUser        = "N"; }
            if(checkers[88].Checked){ p.permAdminCharacter   =  "S";}else{ p.permAdminCharacter   = "N"; }
            if(checkers[89].Checked){ p.permAdminEvent       =  "S";}else{ p.permAdminEvent       = "N"; }
            if(checkers[90].Checked){ p.permAdminSystem      =  "S";}else{ p.permAdminSystem      = "N"; }
            if(checkers[91].Checked){ p.permAdminGlobal      =  "S";}else{ p.permAdminGlobal      = "N"; }

            //Permissions.Update(p);
            //permissions = Permissions.GetAllPermission();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Permissions p = new Permissions();
            //seta desabilitado para todos os checkbox de permissoes
            for (int i = 0; i < checkers.Count; i++)
            {
                checkers[i].Checked = false;
            }

            SetPropertyPermission(p);

            try
            {
                if (Connection.CheckSession())
                {
                    ProcessConsole.ProcessStart("Criando nova Permissão...");
                    Permissions.InsertPermission(p);
                    ProcessConsole.ProcessDone("Criado uma Nova Permissao!");

                    ProcessConsole.ProcessStart("Recarregando Permissões...");
                    permissions = Permissions.GetAllPermission();
                    ProcessConsole.ProcessDone("Permissões recarregadas!");
                    comboUserPermission.Items.Clear();
                    foreach (Permissions pe in permissions)
                    {
                        comboUserPermission.Items.Add(pe.Id);
                    }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usuario.Login = txt_user_login.Text;
            usuario.Password = txt_user_pass.Text;
            usuario.Nick = txt_user_nick.Text;
            usuario.Permission = Convert.ToInt32(comboUserPermission.Text);
            if (checkBox1.Checked)
                usuario.Blocked = "S";
            else
                usuario.Blocked = "N";

            if (usuario.ID != null) 
            {
                User.UpdateUser(usuario);
            }

            button2.Enabled = false;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SetPropertyPermission(perm);
            Permissions.Update(perm);
            permissions = Permissions.GetAllPermission();

        }

        private void comboUserPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            IList<Permissions> p;
            Permissions pp;
            p = Permissions.GetPermission(Convert.ToInt32(comboUserPermission.SelectedItem.ToString()));
            foreach (Permissions thisP in p)
            {
                CheckBoxGetPermissions(thisP);
            }
        }
    }
}