using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Entities
{
    public class Tracking
    {
        public virtual int      ID                  { get; protected set; }
        public virtual string   Action              { get; set; }
        public virtual DateTime DateTrack           { get; set; }
        public virtual int      UserID                   { get; set; }
        public virtual string   UserName                 { get; set; }
        public virtual int      CharacterID         { get; set; }
        public virtual string   CharacterName       { get; set; }
        public virtual int      CharacterLevel      { get; set; }
        public virtual int      CharacterLastLevel  { get; set; }
        public virtual string   CharacterClass      { get; set; }
        public virtual string   CharacterLastClass  { get; set; }
        public virtual string   CharacterStatus     { get; set; }
        public virtual string   CharacterLastStatus { get; set; }
        public virtual int      CharacterMerit      { get; set; }
        public virtual int      CharacterLastMerit  { get; set; }

        public static void Insert(Tracking rastreamento)
        {
            try
            {
                ProcessConsole.ProcessStart("...");
                Connection.session.BeginTransaction();
                Connection.session.Save(rastreamento);
                Connection.session.Transaction.Commit();
                ProcessConsole.ProcessDone("= = = = = = = =");
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                Connection.session.Transaction.Rollback();
            }
        }
    }


}
