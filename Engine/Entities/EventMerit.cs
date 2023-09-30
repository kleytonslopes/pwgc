using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.Entities
{
    public class EventMerit
    {
        #region Declarações de Variaveis
        public virtual int ID { get; protected set; }
        public virtual string NickCharacter { get; set; }
        public virtual int FirstMerit { get; set; }
        public virtual int LastMerit { get; set; }
        public virtual string FirstOwner { get; set; }
        public virtual string LastOwner { get; set; }
        #endregion

        public static IList<EventMerit> GetAllEvents() 
        {
            try
            {
                if (Connection.session != null) 
                {
                    ProcessConsole.ProcessStart("Consultando Eventos...");
                    string sql = "From EventMerit";

                    IQuery query = Connection.session.CreateQuery(sql);
                    ProcessConsole.ProcessProcessing("Preenchendo Lista...");
                    IList<EventMerit> eventos = query.List<EventMerit>();
                    ProcessConsole.ProcessDone("Eventos Carregados.");
                    return eventos;
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                throw;
            }
            return null;
        }
        public static EventMerit GetMemberOnEvent(string nick)
        {
            EventMerit noevento = new EventMerit();
            try
            {
                if (Connection.CheckSession())
                {
                    ProcessConsole.ProcessStart("Verificando o personagem no Evento...");
                    String str = "From EventMerit Where NickCharacter = :nick";
                    IQuery query = Connection.session.CreateQuery(str).SetString("nick", nick);
                    IList<EventMerit> este = query.List<EventMerit>();
                    if(este.Count > 0)
                    {
                        foreach(EventMerit em in este)
                        {
                            ProcessConsole.ProcessMessage("Personagem Encontrado no Evento!");
                            return em;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                return null;
            }
            return noevento;
        }

        public static void Insert(EventMerit eventMember)
        {
            Tracking rastrear = new Tracking();

            rastrear.Action = GlobalSystem.Tracking.Cadastro.ToString();
            rastrear.DateTrack = DateTime.Now;
            rastrear.CharacterName = eventMember.NickCharacter;
            rastrear.CharacterMerit = eventMember.FirstMerit;
            rastrear.UserID = GlobalSystem.usuario.ID;
            rastrear.UserName = GlobalSystem.usuario.Nick;
            Tracking.Insert(rastrear);

            try
            {
                if(Connection.session != null) {
                    ProcessConsole.ProcessStart("Cadastrando personagem no Evento de Merito...");
                    Connection.session.BeginTransaction();
                    ProcessConsole.ProcessProcessing("Salvando Informações...");
                    Connection.session.Save(eventMember);
                    ProcessConsole.ProcessProcessing("Enviando Informações...");
                    Connection.session.Transaction.Commit();
                    ProcessConsole.ProcessDone("Personagem Cadastrado no Evento!");
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                MessageBox.Show("Erro Inesperado", "PWGC - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public static void Update(EventMerit eventmerit)
        {
            Tracking rastrear = new Tracking();

            rastrear.Action = GlobalSystem.Tracking.Cadastro.ToString();
            rastrear.DateTrack = DateTime.Now;
            rastrear.CharacterName = eventmerit.NickCharacter;
            rastrear.CharacterMerit = eventmerit.LastMerit;
            rastrear.UserID = GlobalSystem.usuario.ID;
            rastrear.UserName = GlobalSystem.usuario.Nick;
            Tracking.Insert(rastrear);

            try
            {
                if (Connection.session != null)
                {
                    ProcessConsole.ProcessStart("Salvando evento de mérito do Personagem...");
                    Connection.session.BeginTransaction();
                    ProcessConsole.ProcessProcessing("Salvando Informações...");
                    Connection.session.Update(eventmerit);
                    ProcessConsole.ProcessProcessing("Enviando Informações...");
                    Connection.session.Transaction.Commit();
                    ProcessConsole.ProcessDone("Evento Alterado!");
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                MessageBox.Show("Erro Inesperado", "PWGC - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public static void Clean() 
        {
            Tracking rastrear = new Tracking();

            rastrear.Action = GlobalSystem.Tracking.Exclusão.ToString();
            rastrear.DateTrack = DateTime.Now;
            rastrear.UserID = GlobalSystem.usuario.ID;
            rastrear.UserName = GlobalSystem.usuario.Nick;
            Tracking.Insert(rastrear);

            try
            {
                if (Connection.session != null)
                {
                    ProcessConsole.ProcessStart("Limpando eventos de mérito dos Personagems...");
                    Connection.session.BeginTransaction();
                    ProcessConsole.ProcessProcessing("Salvando Informações...");
                    Connection.session.Delete("From EventMerit em");
                    ProcessConsole.ProcessProcessing("Enviando Informações...");
                    Connection.session.Transaction.Commit();
                    ProcessConsole.ProcessDone("Eventos Excluidos!");
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                MessageBox.Show("Erro Inesperado", "PWGC - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
