using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Engine
{
    public class ControlModifier
    {
        public static void ButtonColorChanger(int btnIndex, Button[] btn)
        {
            for(int i = 0; i < btn.Length; i++)
            {
                btn[i].BackColor = Color.White;
            }
            btn[btnIndex].BackColor = Color.Green;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controlIndex">Index</param>
        /// <param name="control">Array de Controladores</param>
        /// <param name="visible">Visivel True / False</param>
        /// <param name="enabled">Ativo True / False</param>
        public static void ControlVisibleEnable(int controlIndex, Control[] control, bool visible, bool enabled) 
        {
            control[controlIndex].Enabled = enabled;
            control[controlIndex].Visible = visible;
        }

        public static void ControlVisibleEnable(Control control, bool visible, bool enabled)
        {
            control.Enabled = enabled;
            control.Visible = visible;
        }

        public static void ControlPermission(ToolStripMenuItem tsmi, int index)
        {
            tsmi.Enabled = GlobalPermission.permissionIndex[index];
            tsmi.Visible = GlobalPermission.permissionIndex[index];
        }

        public static void ControlPermission(Button btn, int index)
        {
            btn.Enabled = GlobalPermission.permissionIndex[index];
            btn.Visible = GlobalPermission.permissionIndex[index];
        }

        public static void ControlPermission(Panel pnl, int index)
        {
            pnl.Enabled = GlobalPermission.permissionIndex[index];
            pnl.Visible = GlobalPermission.permissionIndex[index];
        }

        public static void ControlPermission(CheckBox cb, int index)
        {
            cb.Enabled = GlobalPermission.permissionIndex[index];
            cb.Visible = GlobalPermission.permissionIndex[index];
        }

        public static void ControlPermission(RadioButton rb, int index)
        {
            rb.Enabled = GlobalPermission.permissionIndex[index];
            rb.Visible = GlobalPermission.permissionIndex[index];
        }
    }
}
