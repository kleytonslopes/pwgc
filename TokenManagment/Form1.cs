using Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TokenManagment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength < 12)
                textBox1.ForeColor = Color.LightPink;
            else
                textBox1.ForeColor = Color.LightGreen;

             textBox2.Text = Tank.Generate(textBox1.Text);
             textBox3.Text = Tank.Generate("Hubalu");
        }
    }
}
