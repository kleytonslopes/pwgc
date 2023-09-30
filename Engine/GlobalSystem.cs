using Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine
{
    public class GlobalSystem
    {
        /// <summary>
        /// Usuario Logado
        /// </summary>
        public static User usuario {get; set;}
        public static Permissions permission { get; set; }
        /// <summary>
        /// Configuração Atual
        /// </summary>
        public static IList<Config> config { get; set; }
        public static List<Config> cfg = new List<Config>();
        public static IList<Character> globalCharacters { get; set; }
        public static int MinMeritTolerance { get; set; }
        public static int MaxDayToInactive { get; set; }

        public enum Class
        {
            Arcano,
            Mistico,
            Guerreiro,
            Mago,
            Arqueiro,
            Sacerdote,
            Barbaro,
            Feiticeira,
            Mercenário,
            Espiritualista,
            Retalhador,
            Tormentador
        };
        public enum Cargo
        {
            Soldado,
            Capitão,
            Major,
            General,
            Marechal
        };
        public enum Status
        {
            Ativo,
            Inativo,
            Banido,
            Desertor,
            Análise,
            Ausente
        };
        public enum Reborn
        {
            SemReborn,
            Reborn_I,
            Reborn_II
        };
        public enum Rank
        {
            SemRank,
            I,
            II,
            III,
            IV,
            V,
            VI,
            VII,
            VIII,
            IX,
            X
        };
        public enum Common
        {
            NãoDeterminado
        };
        public enum Tracking
        {
            Cadastro,
            Atualização,
            Exclusão,
            EventoMeritoON,
            EventoMeritoOFF
        };


        public static void PermissionCheker(Control controlador, bool bolean) 
        {
            if (bolean) 
            {
                controlador.Enabled = true;
                controlador.Visible = true;
            }
            else 
            {
                controlador.Enabled = false;
                controlador.Visible = false;
            }
        }
        public static void PermissionCheker(ToolStripMenuItem controlador, bool bolean, Keys key) 
        {
            if (bolean)
            {
                controlador.ShortcutKeys = key;
                controlador.Enabled = true;
                controlador.Visible = true;
            }
            else
            {
                controlador.Enabled = false;
                controlador.Visible = false;
            }
        }
        public static void PermissionCheker(ToolStripMenuItem controlador, bool bolean)
        {
            if (bolean)
            {
                controlador.Enabled = true;
                controlador.Visible = true;
            }
            else
            {
                controlador.Enabled = false;
                controlador.Visible = false;
            }
        }

        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

    }
}
