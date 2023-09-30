using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Engine.Entities
{
    public class Permissions
    {
        public static IList<Permissions> minha = null;
        public static IList<Permissions> permissoes = null;
        #region Declaraçoes
        public virtual int Id { get; set; }
        public virtual string permCatCad           { get; set; }
        public virtual string permCatCadInsert     { get; set; }
        public virtual string permCatCadVerify     { get; set; }
        public virtual string permCatCadCarg       { get; set; }
        public virtual string permCatCadCarg_1     { get; set; }
        public virtual string permCatCadCarg_2     { get; set; }
        public virtual string permCatCadCarg_3     { get; set; }
        public virtual string permCatCadCarg_4     { get; set; }
        public virtual string permCatCadCarg_5     { get; set; }
        public virtual string permCatCadRank       { get; set; }
        public virtual string permCatCadRank_1     { get; set; }
        public virtual string permCatCadRank_2     { get; set; }
        public virtual string permCatCadRank_3     { get; set; }
        public virtual string permCatCadRank_4     { get; set; }
        public virtual string permCatCadRank_5     { get; set; }
        public virtual string permCatCadRank_6     { get; set; }
        public virtual string permCatCadRank_7     { get; set; }
        public virtual string permCatCadRank_8     { get; set; }
        public virtual string permCatCadRank_9     { get; set; }
        public virtual string permCatCadStat       { get; set; }
        public virtual string permCatCadStat_1     { get; set; }
        public virtual string permCatCadStat_2     { get; set; }
        public virtual string permCatCadStat_3     { get; set; }
        public virtual string permCatCadStat_4     { get; set; }
        public virtual string permCatCadStat_5     { get; set; }
        public virtual string permCatCadStat_6     { get; set; }
        public virtual string permCatCadClass      { get; set; }
        public virtual string permCatCadClass_1    { get; set; }
        public virtual string permCatCadClass_2    { get; set; }
        public virtual string permCatCadClass_3    { get; set; }
        public virtual string permCatCadClass_4    { get; set; }
        public virtual string permCatCadClass_5    { get; set; }
        public virtual string permCatCadClass_6    { get; set; }
        public virtual string permCatCadClass_7    { get; set; }
        public virtual string permCatCadClass_8    { get; set; }
        public virtual string permCatCadClass_9    { get; set; }
        public virtual string permCatCadClass_10   { get; set; }
        public virtual string permCatCadClass_11   { get; set; }
        public virtual string permCatCadClass_12   { get; set; }
        public virtual string permCatCadReborn     { get; set; }
        public virtual string permCatCadReborn_1   { get; set; }
        public virtual string permCatCadReborn_2   { get; set; }
        public virtual string permCatCadReborn_3   { get; set; }
        public virtual string permCatCadReborn_4   { get; set; }
        public virtual string permEditEdit         { get; set; }
        public virtual string permEditAlter        { get; set; }
        public virtual string permEditExclu        { get; set; }
        public virtual string permEditSetob        { get; set; }
        public virtual string permEditCargo        { get; set; }
        public virtual string permEditCargo_1      { get; set; }
        public virtual string permEditCargo_2      { get; set; }
        public virtual string permEditCargo_3      { get; set; }
        public virtual string permEditCargo_4      { get; set; }
        public virtual string permEditCargo_5      { get; set; }
        public virtual string permEditRank         { get; set; }
        public virtual string permEditRank_1       { get; set; }
        public virtual string permEditRank_2       { get; set; }
        public virtual string permEditRank_3       { get; set; }
        public virtual string permEditRank_4       { get; set; }
        public virtual string permEditRank_5       { get; set; }
        public virtual string permEditRank_6       { get; set; }
        public virtual string permEditRank_7       { get; set; }
        public virtual string permEditRank_8       { get; set; }
        public virtual string permEditRank_9       { get; set; }
        public virtual string permEditStatus       { get; set; }
        public virtual string permEditStatus_1     { get; set; }
        public virtual string permEditStatus_2     { get; set; }
        public virtual string permEditStatus_3     { get; set; }
        public virtual string permEditStatus_4     { get; set; }
        public virtual string permEditStatus_5     { get; set; }
        public virtual string permEditStatus_6     { get; set; }
        public virtual string permEditClass        { get; set; }
        public virtual string permEditClass_1      { get; set; }
        public virtual string permEditClass_2      { get; set; }
        public virtual string permEditClass_3      { get; set; }
        public virtual string permEditClass_4      { get; set; }
        public virtual string permEditClass_5      { get; set; }
        public virtual string permEditClass_6      { get; set; }
        public virtual string permEditClass_7      { get; set; }
        public virtual string permEditClass_8      { get; set; }
        public virtual string permEditClass_9      { get; set; }
        public virtual string permEditClass_10     { get; set; }
        public virtual string permEditClass_11     { get; set; }
        public virtual string permEditClass_12     { get; set; }
        public virtual string permEditReborn       { get; set; }
        public virtual string permEditReborn_1     { get; set; }
        public virtual string permEditReborn_2     { get; set; }
        public virtual string permEditReborn_3     { get; set; }
        public virtual string permEditReborn_4     { get; set; }
        public virtual string permEditConsultar    { get; set; }
        public virtual string permAdmin { get; set; }
        public virtual string permAdminUser { get; set; }
        public virtual string permAdminCharacter { get; set; }
        public virtual string permAdminEvent { get; set; }
        public virtual string permAdminSystem { get; set; }
        public virtual string permAdminGlobal { get; set; }

        #endregion

        public static IList<Permissions> GetAllPermission() 
        {
            if (Connection.session != null) 
            {
                try
                {
                    ProcessConsole.ProcessStart("Startando Consulta...");
                    string sql = "FROM Permissions";
                    IQuery query = Engine.Connection.session.CreateQuery(sql);

                    permissoes = query.List<Permissions>();

                    ProcessConsole.ProcessProcessing(permissoes.Count.ToString());
                    ProcessConsole.ProcessDone("Consulta Finalizada!");
                    return permissoes;


                }
                catch (Exception erro)
                {

                    ProcessConsole.ProcessBreak(erro);
                }
            }
            else
            {
                ProcessConsole.ProcessInformation("Conexão Expirou ou não Iniciada. Por favor tente novamente em uma Nova Instancia");
            }
            return permissoes;
        }
        public static IList<Permissions> GetPermission(int id) 
        {
            try
            {
                string sql = "FROM Permissions p WHERE p.Id = :id";
                ProcessConsole.ProcessStart("Iniciando Busca da Permissão...");
                IQuery query = Connection.session.CreateQuery(sql).SetInt32("id", id);

                minha = query.List<Permissions>();
                ProcessConsole.ProcessDone("Permissão encontrada!");
                foreach (Permissions p in minha) 
                {
                    ProcessConsole.ProcessProcessing("Globalizando permissão...");
                    GlobalSystem.permission = p;
                    ProcessConsole.ProcessDone("Permissão Globalizada!");
                }
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                return null;
            }
            return minha;
        }

        public static void InsertPermission(Permissions p) 
        {
            try
            {
                ProcessConsole.ProcessStart("Iniciando Criação da Permissão...");
                Connection.session.BeginTransaction();
                ProcessConsole.ProcessProcessing("Salvando Informações...");
                Connection.session.Save(p);
                ProcessConsole.ProcessProcessing("Enviando Informações...");
                Connection.session.Transaction.Commit();
                ProcessConsole.ProcessDone("Permissão Cadastrada");
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                Connection.session.Transaction.Rollback();
            }
        }
        public static void Update(Permissions p)
        {
            try
            {
                ProcessConsole.ProcessStart("Iniciando Modificação da Permissão...");
                Connection.session.BeginTransaction();
                ProcessConsole.ProcessProcessing("Atualizando Informações...");
                Connection.session.Update(p);
                ProcessConsole.ProcessProcessing("Enviando Informações...");
                Connection.session.Transaction.Commit();
                ProcessConsole.ProcessProcessing("Permissão "+ p.Id.ToString() + " Atualizada");
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                Connection.session.Transaction.Rollback();
            }
        }
    }
}


