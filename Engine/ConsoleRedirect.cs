using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine
{
    public class ConsoleRedirect : TextWriter
    {
        RichTextBox richText = null;

        public ConsoleRedirect(RichTextBox rtb) 
        {
            richText = rtb;
        }

        public override void Write(char value)
        {
            try
            {

            base.Write(value);
            richText.AppendText(value.ToString());
            }
            catch (Exception)
            {

            }
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
