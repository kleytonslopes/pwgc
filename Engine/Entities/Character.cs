using NHibernate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.Entities
{
    public class Character
    {
        public static ISession session = Connection.session;
        public static IList<Character> allCharacter;

        #region declarations
        /// <summary>
        /// ID Primary KEY
        /// </summary>
        public virtual int    Id                { get; protected set; }
        /// <summary>
        /// Nick Name
        /// </summary>
        public virtual string Nick              {get;set;}
        /// <summary>
        /// Classe
        /// </summary>
        public virtual string Grade             {get;set;}
        /// <summary>
        /// Nivel Atual
        /// </summary>
        public virtual int Level             {get;set;}
        /// <summary>
        /// Status Atual
        /// </summary>
        public virtual string Status            {get;set;}
        /// <summary>
        /// Titulo
        /// </summary>
        //public virtual string Title             {get;set;}
        /// <summary>
        /// Cargo
        /// </summary>
        public virtual string Office             {get;set;}
        /// <summary>
        /// Merito Atual
        /// </summary>
        public virtual int Merit             {get;set;}
        /// <summary>
        /// Data de Entrada
        /// </summary>
        public virtual DateTime Entry { get; set; }
        /// <summary>
        /// Data da Atualização
        /// </summary>
        public virtual DateTime Updated { get; set; }
        /// <summary>
        /// Quantidade de Triais Participada
        /// </summary>
        //public virtual string TrialCount        {get;set;}
        /// <summary>
        /// Quantidade de Contribuição
        /// </summary>
        //public virtual string ContributionCount {get;set;}
        /// <summary>
        /// ID de Outro personagem
        /// </summary>
        public virtual string OtherChar           {get;set;}
        /// <summary>
        /// Proprietario Modificador
        /// </summary>
        public virtual string Owner             {get;set;}
        /// <summary>
        /// Level de Entrada
        /// </summary>
        public virtual int LevelEntrance            {get;set;}
        /// <summary>
        /// Crecrutado por Quem?
        /// </summary>
        public virtual string Recruter          {get;set;}
        /// <summary>
        /// Proprietario Cadastrador
        /// </summary>
        public virtual string OwnerEntrance              {get;set;}
        /// <summary>
        /// Ultimo Nivel
        /// </summary>
        public virtual int LastLevel         {get;set;}
        /// <summary>
        /// Ultimo Merito
        /// </summary>
        public virtual int LastMerit         {get;set;}
        /// <summary>
        /// Ultima Atualização
        /// </summary>
        public virtual DateTime LastUpdated { get; set; }
        /// <summary>
        /// Ultimo Status
        /// </summary>
        public virtual string LastStatus        {get;set;}
        /// <summary>
        /// Ultima Trial
        /// </summary>
        //public virtual string LastTrial         {get;set;}
        /// <summary>
        /// Ultimo Proprietario Modificador
        /// </summary>
        public virtual string LastOwner         {get;set;}
        /// <summary>
        /// Meritos Ganhos
        /// </summary>
        //public virtual string MeritWinnings        {get;set;}
        /// <summary>
        /// Observação
        /// </summary>
        public virtual string Observation               {get;set;}
        /// <summary>
        /// Nivel de Reborn
        /// </summary>
        public virtual string Reborn            {get;set;}
        /// <summary>
        /// Nick do Indicador
        /// </summary>
        public virtual string Idicated          {get;set;}
        /// <summary>
        /// Nivel de Rank
        /// </summary>
        public virtual string Rank              { get; set; }
        public virtual string Visible { get; set; }

        public virtual char EventMerit { get;set;}
        #endregion
        public static IList<Character> GetAllCharacter()
        {
            try
            {
                ProcessConsole.ProcessStart(GlobalMessage.CheckSession);
                if (Connection.session != null)
                {
                    ProcessConsole.ProcessStart(GlobalMessage.SearhPersons);
                    string sql = "From Character Where Visible ='S'";

                    IQuery query = Connection.session.CreateQuery(sql);
                    
                    ProcessConsole.ProcessStart(GlobalMessage.SearhPersons);
                    allCharacter = query.List<Character>();
                    ProcessConsole.ProcessProcessing(GlobalMessage.PersonsFound);
                    return allCharacter;//

                }
                else
                {
                    ProcessConsole.ProcessInformation(GlobalMessage.CheckSessionFaill);
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
            }
            return allCharacter;

        }
        public static IList<Character> GetAllCharacterAdmin()
        {
            try
            {
                ProcessConsole.ProcessStart(GlobalMessage.CheckSession);
                if (Connection.session != null)
                {
                    ProcessConsole.ProcessStart(GlobalMessage.SearhPersons);
                    string sql = "From Character";

                    IQuery query = Connection.session.CreateQuery(sql);

                    ProcessConsole.ProcessStart(GlobalMessage.SearhPersons);
                    allCharacter = query.List<Character>();
                    ProcessConsole.ProcessProcessing(GlobalMessage.PersonsFound);
                    return allCharacter;//

                }
                else
                {
                    ProcessConsole.ProcessInformation(GlobalMessage.CheckSessionFaill);
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
            }
            return allCharacter;

        }
        public static IList<Character> GetAllCharacter(string parametro)
        {
            try
            {
                ProcessConsole.ProcessStart(GlobalMessage.CheckSession);
                if (Connection.session != null)
                {
                    //select * From data_char where ch_id = 0 or ((1=1 and ch_status='Inativo') or (1=1 and ch_status='Ativo')) and ch_show ='S' 

                    ProcessConsole.ProcessStart(GlobalMessage.SearhPersons);
                    string sql = "From Character c where c.Id=0 or (" + parametro + " ch_status='TEMP') and c.Visible ='S' ";

                    IQuery query = Connection.session.CreateQuery(sql);

                    ProcessConsole.ProcessStart(GlobalMessage.SearhPersons);
                    allCharacter = query.List<Character>();
                    ProcessConsole.ProcessProcessing(GlobalMessage.PersonsFound);
                    return allCharacter;//988039099  34731830

                }
                else
                {
                    ProcessConsole.ProcessInformation(GlobalMessage.CheckSessionFaill);
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
            }
            return allCharacter;

        }

        public static Character GetCharacterByCode(int code) 
        {
            IList<Character> meList;
            try
            {
                ProcessConsole.ProcessStart(GlobalMessage.CheckSession);
                if (Connection.session != null)
                {
                    ProcessConsole.ProcessStart("Proucurando por ID: " + code.ToString());
                    string sql = "From Character Where Id= :code";
                    IQuery query = Connection.session.CreateQuery(sql).SetString("code", code.ToString());
                    ProcessConsole.ProcessStart(GlobalMessage.SearhPersons);
                    meList = query.List<Character>();
                    ProcessConsole.ProcessProcessing(GlobalMessage.PersonsFound);
                    //988039099  34731830
                    foreach (Character me in meList)
                    {
                        ProcessConsole.ProcessMessage("Personagem Encontrado!\n" + " ID: " + me.Id + " NICK: " + me.Nick + " Classe: " + me.Grade + " Status: " + me.Status);
                        return me;
                    }

                }
                else
                {
                    ProcessConsole.ProcessInformation(GlobalMessage.CheckSessionFaill);
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
            }
            return null;
        }

        public static void InsertCharacter (Character thischar)
        {
            Tracking rastrear = new Tracking();

            rastrear.Action = GlobalSystem.Tracking.Cadastro.ToString();
            rastrear.DateTrack = DateTime.Now;
            rastrear.CharacterClass = thischar.Grade;
            rastrear.CharacterLevel = thischar.Level;
            rastrear.CharacterName = thischar.Nick;
            rastrear.UserID = GlobalSystem.usuario.ID;
            rastrear.UserName = GlobalSystem.usuario.Nick;
            Tracking.Insert(rastrear);

            try
            {
                ProcessConsole.ProcessStart("Cadastrado Personagem...");
                Connection.session.BeginTransaction();
                Connection.session.Save(thischar);
                Connection.session.Transaction.Commit();
                ProcessConsole.ProcessDone("Personagem Cadastrado!");
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                Connection.session.Transaction.Rollback();
            }
        }
        public static bool VerifyCharacter (String nick)
        {
            try
            {
                if (Connection.CheckSession())
                {
                    ProcessConsole.ProcessStart("Verificando Personagem...");
                    string str = "FROM Character WHERE Nick= :nick";
                    IQuery query = Connection.session.CreateQuery(str).SetString("nick", nick);
                    IList<Character> este = query.List<Character>();
                    if (este.Count > 0)
                    {
                        foreach (Character c in este)
                        {
                            ProcessConsole.ProcessMessage("Personagem Encontrado!\n" + " ID: " + c.Id + " NICK: " + c.Nick + " Classe: " + c.Grade + " Status: " + c.Status);
                        }
                        return true;
                    }
                    else
                    {
                        ProcessConsole.ProcessMessage("Personagem não Encontrado!");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                return false;
            }
        }

        public static void UpdateCharacter(Character character) 
        {
            Tracking rastrear = new Tracking();

            rastrear.Action = GlobalSystem.Tracking.Atualização.ToString();
            rastrear.DateTrack = DateTime.Now;
            rastrear.CharacterClass = character.Grade;
            rastrear.CharacterLevel = character.Level;
            rastrear.CharacterLastLevel = character.LastLevel;
            rastrear.CharacterMerit = character.Merit;
            rastrear.CharacterLastMerit = character.LastMerit;
            rastrear.CharacterStatus = character.Status;
            rastrear.CharacterLastStatus = character.LastStatus;
            rastrear.CharacterName = character.Nick;
            rastrear.UserID = GlobalSystem.usuario.ID;
            rastrear.UserName = GlobalSystem.usuario.Nick;
            Tracking.Insert(rastrear);
            try 
            {
                Connection.session.BeginTransaction();
                ProcessConsole.ProcessStart("Atualizando Personagem...");
                Connection.session.Update(character);
                Connection.session.Transaction.Commit();
                MessageBox.Show("Personagem Alterado", "PWGC - Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                Connection.session.Transaction.Rollback();
                MessageBox.Show("Erro Inesperado", "PWGC - Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static IList<Character> GetAllCharacterByFilter(string grade, string stats)
        {
            allCharacter = null;
            IList<Character> meList;
            Character me = new Character();
            try
            {
                ProcessConsole.ProcessStart(GlobalMessage.CheckSession);
                if (Connection.session != null)
                {
                    //string sql = "from Character c where c.Visible ='S' and c.Id = '0' " + grade + " and (c.Status='0' " + stats + ") ";
                    string sql = "from Character c where c.Id=0 or (" + grade + "  ch_status='TEMP') and c.Visible ='S' and (" + stats + "ch_status='TEMP') and c.Visible ='S' ";
                    
                    IQuery query = Connection.session.CreateQuery(sql);
                    //IQuery query = Connection.session.CreateQuery("from Character c where c.Id = '0' and c.Visible ='S' " + grade + ") and (c.Status='0' " + stats + ") ");
                    allCharacter = query.List<Character>();
                    ProcessConsole.ProcessProcessing(GlobalMessage.PersonsFound);
                    return allCharacter;
                }
                else
                {
                    ProcessConsole.ProcessInformation(GlobalMessage.CheckSessionFaill);
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
            }
            return allCharacter;
        }

        public static Character GetCharacterByName(string nick)
        {
            Character chara = new Character();
            try
            {
                if (Connection.CheckSession())
                {
                    ProcessConsole.ProcessStart("Verificando Personagem...");
                    string str = "FROM Character WHERE Nick= :nick";
                    IQuery query = Connection.session.CreateQuery(str).SetString("nick", nick);
                    IList<Character> este = query.List<Character>();
                    if (este.Count > 0)
                    {
                        foreach (Character c in este)
                        {
                            ProcessConsole.ProcessMessage("Personagem Encontrado!\n" + " ID: " + c.Id + " NICK: " + c.Nick + " Classe: " + c.Grade + " Status: " + c.Status);
                            return c;
                        }
                        
                    }
                    else
                    {
                        ProcessConsole.ProcessMessage("Personagem não Encontrado!");
                        return null;
                    }
                }
                else
                {
                    
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                
            }
            return chara;
        }

        public static Character GetCharacterByCodeAdmin(int code)
        {
            IList<Character> meList;
            try
            {
                ProcessConsole.ProcessStart(GlobalMessage.CheckSession);
                if (Connection.session != null)
                {
                    ProcessConsole.ProcessStart("Proucurando por ID: " + code.ToString());
                    string sql = "From Character Where Id= :code ";
                    IQuery query = Connection.session.CreateQuery(sql).SetString("code", code.ToString());
                    ProcessConsole.ProcessStart(GlobalMessage.SearhPersons);
                    meList = query.List<Character>();
                    ProcessConsole.ProcessProcessing(GlobalMessage.PersonsFound);
                    foreach (Character me in meList) 
                    {
                        ProcessConsole.ProcessMessage("Personagem Encontrado!\n" + " ID: " + me.Id + " NICK: " + me.Nick + " Classe: " + me.Grade + " Status: " + me.Status);
                        return me;
                    }

                }
                else
                {
                    ProcessConsole.ProcessInformation(GlobalMessage.CheckSessionFaill);
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
            }
            return null;

        }

        public static void StatusEventCharacterMerit(string str)
        {

            try
            {
                string sql = "UPDATE Character c SET c.EventMerit = :stat where c.Status='Ativo' or c.Status='Análise' and c.Visible='S' ";
                ProcessConsole.ProcessStart("Atualizando Personagems...");
                var update = Connection.session.CreateQuery(sql).SetParameter("stat", str);
                update.ExecuteUpdate();
                MessageBox.Show("Evento de Merito Modificado", "PWGC - Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                //Connection.session.Transaction.Rollback();
                MessageBox.Show("Erro Inesperado", "PWGC - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public static IList<Character> GetAllCharacterEventMerit()
        {
            try
            {
                ProcessConsole.ProcessStart(GlobalMessage.CheckSession);
                if (Connection.session != null)
                {
                    ProcessConsole.ProcessStart(GlobalMessage.SearhPersons);
                    string sql = "From Character Where Visible ='S' and EventMerit = 'S'";

                    IQuery query = Connection.session.CreateQuery(sql);

                    ProcessConsole.ProcessStart(GlobalMessage.SearhPersons);
                    allCharacter = query.List<Character>();
                    ProcessConsole.ProcessProcessing(GlobalMessage.PersonsFound);
                    return allCharacter;//

                }
                else
                {
                    ProcessConsole.ProcessInformation(GlobalMessage.CheckSessionFaill);
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
            }
            return allCharacter;
        }
    }
}
