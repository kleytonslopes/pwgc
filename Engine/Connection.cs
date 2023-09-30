using System;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;

namespace Engine
{
    public class Connection
    {
        private static Configuration config;
        private static ISessionFactory factory;
        public static ISession session;

        /// <summary>
        /// Carregar arquivo de Configuração que se encontra na pasta do Sistema
        /// </summary>

        public static ISessionFactory CreateSession()
        {
            
            string server = "";
            string database = "";
            string username = "";
            string password = "";
            
            try
            {
                var strcon = MySQLConfiguration.Standard.ConnectionString(c => c.Is( "Server="+server+";Database="+database+";User="+username+";Password="+password+";CharSet=utf8"));//.FormatSql().ShowSql();
                ProcessConsole.ProcessStart("Configurando Fabrica...");
                factory = Fluently.Configure().Database(strcon).Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())).BuildSessionFactory();
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                return null;
            }
            ProcessConsole.ProcessDone("Fabrica Configurada!");
            return factory;
        }

        /// <summary>
        /// Abrir uma Sessão
        /// </summary>
        /// <returns></returns>
        public static ISession OpenSessison()
        {
            ProcessConsole.ProcessStart("Iniciando Sessão...");
            ISession session = null;
            try
            {
                session = CreateSession().OpenSession();
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                return null;
            }

           ProcessConsole.ProcessDone("Sessão Iniciada!");
            return session;
        }

        public static bool CheckSession()
        {
            if(session != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
