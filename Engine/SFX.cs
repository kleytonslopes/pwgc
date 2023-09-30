using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class SFX
    {
        public static void MouseEnter()
        {
            Console.Beep(200, 50);
        }
        public static void MouseClick()
        {
            Console.Beep(1000, 50);
        }
    }
}
