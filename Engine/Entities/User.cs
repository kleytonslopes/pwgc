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
    public class User
    {
        public static IList<User> eu = null;
        private static IList<User> usuarios = null;
        public static IList<Permissions> minha = null;

        public virtual int      ID { get; protected set; }
        public virtual string   Login { get; set; }
        public virtual string   Password { get; set; }
        public virtual string   Name { get; set; }
        public virtual string   Nick { get; set; }
        public virtual string   Email { get; set; }
        public virtual int      Permission { get; set; }
        public virtual DateTime LastLogin { get; set; }
        public virtual string Blocked { get; set; }

        public static IList<User> GetAllUser()
        {
            if (Connection.session != null)
            {
                try
                {
                    //CryptoString.AssignNewKey();
                    ProcessConsole.ProcessStart("Startando Consulta...");
                    string slq = "FROM User";
                    IQuery query = Engine.Connection.session.CreateQuery(slq);
                    usuarios = query.List<User>();

                    ProcessConsole.ProcessProcessing(usuarios.Count.ToString());
                    ProcessConsole.ProcessDone("Consulta Finalizada!");
                    return usuarios;
                    
                }
                catch (Exception erro)
                {
                    //button1.Enabled = true;
                    ProcessConsole.ProcessBreak(erro);

                }
            }
            else
            {
                ProcessConsole.ProcessInformation("Conexão Expirou ou não Iniciada. Por favor tente novamente em uma Nova Instancia");
            }
            return usuarios;
        }
        public static IList<User> GetUserByLoginPassword(string Login, string Password)
        {
            ProcessConsole.ProcessStart("Iniciando Login...");
            if (Connection.session != null)
            {
                try
                {
                    string sql = "FROM User u WHERE u.Login= :login";

                    ProcessConsole.ProcessStart("Logando Usuário...");
                    IQuery query = Connection.session.CreateQuery(sql).SetString("login", Login);

                    eu = query.List<User>();

                    if (eu.Count < 1)
                    {
                        ProcessConsole.ProcessProcessing(GlobalMessage.OpsMessage);
                        return null;
                    }
                    foreach (User us in eu)
                    {
                        if (us.Password == Password)
                        {

                            ProcessConsole.ProcessMessage("Bem Vindo " + us.Name + " Sua ID é: " + us.ID + " memorize, poderemos usar isso\npara uma futura alteração em sua conta.");
                            GlobalSystem.usuario = us;
                            ProcessConsole.ProcessStart("Carregando Permissão...");
                            Permissions.GetPermission(GlobalSystem.usuario.Permission);
                            ProcessConsole.ProcessDone("Permissões Carregadas!");
                            us.LastLogin = DateTime.Now;
                            Update(us);

                            return eu;
                        }
                        else
                        {
                            ProcessConsole.ProcessProcessing(GlobalMessage.OpsMessage);
                            return null;
                        }
                    }
                }
                catch (Exception erro)
                {
                    return null;
                    ProcessConsole.ProcessBreak(erro);
                }
            }
            else
            {
                ProcessConsole.ProcessInformation(GlobalMessage.ExpirationSession);
            }
            return eu;
        }

        public static IList<Permissions> GetMePermission(int id) 
        {
            IList<Permissions> esta = null;
            try
            {
                string sql = "FROM Permissions p WHERE p.Id = :id";

                IQuery query = Connection.session.CreateQuery(sql).SetInt32("id", id);

                esta = query.List<Permissions>();
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                return null;
            }
            return esta;
        }

        public static void UpdateUser(User usu) 
        {
            try
            {
                Connection.session.BeginTransaction();
                ProcessConsole.ProcessStart("Atualizando Usuário...");
                Connection.session.Update(usu);
                ProcessConsole.ProcessProcessing("Enviando Informações...");
                Connection.session.Transaction.Commit();
                ProcessConsole.ProcessDone("Usuario Alterado!");
                MessageBox.Show("Usuário Alterado", "PWGC - Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                Connection.session.Transaction.Rollback();
                MessageBox.Show("Erro Inesperado", "PWGC - Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public static void Update(User usu)
        {
            try
            {
                Connection.session.BeginTransaction();
                ProcessConsole.ProcessStart("Atualizando Usuário...");
                Connection.session.Update(usu);
                ProcessConsole.ProcessProcessing("Enviando Informações...");
                Connection.session.Transaction.Commit();
                ProcessConsole.ProcessDone("Usuario Alterado!");
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                Connection.session.Transaction.Rollback();
                MessageBox.Show("Erro Inesperado", "PWGC - Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public static void Insert(User usu)
        {
            try
            {
                Connection.session.BeginTransaction();
                ProcessConsole.ProcessStart("Cadastrando Usuário...");
                Connection.session.Save(usu);
                ProcessConsole.ProcessProcessing("Enviando Informações...");
                Connection.session.Transaction.Commit();
                ProcessConsole.ProcessDone("Usuario Cadastrado!!");
                MessageBox.Show("Usuário Cadastrado", "PWGC - Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                ProcessConsole.ProcessBreak(erro);
                Connection.session.Transaction.Rollback();
                MessageBox.Show("Erro Inesperado", "PWGC - Informação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
