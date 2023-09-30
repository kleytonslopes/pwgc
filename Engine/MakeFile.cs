using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class MakeFile
    {
        public static void CriarArquivo()
        {
            String debugOn = "0";
            FileStream arquivo = new FileStream("element.pwgc", FileMode.Create);
            BinaryFormatter bina = new BinaryFormatter();
            bina.Serialize(arquivo, debugOn);
            arquivo.Close();
        }
    }
}
