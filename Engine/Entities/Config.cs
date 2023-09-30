using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using System.Windows.Forms;

namespace Engine.Entities
{
    public class Config
    {
        public static IList<Config> config;

        public virtual int    ID            { get; protected set; }
        public virtual string Code          { get; set; }
        public virtual string Description   { get; set; }
        public virtual string Target        { get; set; }
        public virtual string Observation   { get; set; }

        public static IList<Config> GetAllConfig()
        {
            if (Connection.session != null)
            {
                try
                {
                    ProcessConsole.ProcessStart("Localizando Configurações...");
                    string slq = "FROM Config";
                    ProcessConsole.ProcessProcessing("Checando Configurações...");
                    IQuery query = Engine.Connection.session.CreateQuery(slq);
                    ProcessConsole.ProcessProcessing("Globalizando Configurações...");
                    config = query.List<Config>();

                    ProcessConsole.ProcessProcessing("Configurações Encontradas: " + config.Count.ToString());
                    ProcessConsole.ProcessDone("Sistema Configurado!");
                    return config;

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
            return config;
        }
        public static Config GetConfigById(int id) 
        {
            if (Connection.session != null)
            {
                try
                {
                    ProcessConsole.ProcessStart("Localizando Configuração...");
                    string slq = "FROM Config c WHERE c.ID = :id ";
                    ProcessConsole.ProcessProcessing("Checando Configuraççao...");
                    IQuery query = Engine.Connection.session.CreateQuery(slq).SetString("id", id.ToString());
                    ProcessConsole.ProcessProcessing("Globalizando Configuração...");
                    config = query.List<Config>();

                    foreach (Config cfg in config) 
                    {
                        ProcessConsole.ProcessProcessing("Configuração Encontradas: " + config.Count.ToString());
                        return cfg;
                    }
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
            return null;
        }
        public static Config GetConfigByName(string name)
        {
            if (Connection.session != null)
            {
                try
                {
                    ProcessConsole.ProcessStart("Localizando Configuração...");
                    string slq = "FROM Config c WHERE c.Observation = :id ";
                    ProcessConsole.ProcessProcessing("Checando Configuraççao...");
                    IQuery query = Engine.Connection.session.CreateQuery(slq).SetString("id", name);
                    ProcessConsole.ProcessProcessing("Globalizando Configuração...");
                    config = query.List<Config>();

                    foreach (Config cfg in config)
                    {
                        ProcessConsole.ProcessProcessing("Configuração Encontradas: " + config.Count.ToString());
                        return cfg;
                    }
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
            return null;
        }
        public static void CreateConfig(Config cfg)
        {
            try
            {
                ProcessConsole.ProcessStart("Cadastrado Configuração...");
                Connection.session.BeginTransaction();
                Connection.session.Save(cfg);
                Connection.session.Transaction.Commit();
                ProcessConsole.ProcessDone("Configuração Cadastrada!");
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                Connection.session.Transaction.Rollback();
            }
        }

        public static void UpdateConfig(Config cfg)
        {
            try
            {
                ProcessConsole.ProcessStart("Atualizando Configuração...");
                Connection.session.BeginTransaction();
                Connection.session.Update(cfg);
                Connection.session.Transaction.Commit();
                ProcessConsole.ProcessDone("Configuração Atualizada!");
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                Connection.session.Transaction.Rollback();
            }
        }
    }


}
