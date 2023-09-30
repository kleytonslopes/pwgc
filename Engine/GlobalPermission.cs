using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class GlobalPermission
    {


        public static bool[] permissionIndex = new bool[96];


        public static void SetPermission()
        {

            if(GlobalSystem.permission.permCatCad          == "S"){permissionIndex[0]   = true;}else{permissionIndex[0] = false;} 
            if(GlobalSystem.permission.permCatCadInsert    == "S"){permissionIndex[1]   = true;}else{permissionIndex[1] = false;} 
            if(GlobalSystem.permission.permCatCadVerify    == "S"){permissionIndex[2]   = true;}else{permissionIndex[2] = false;} 
            if(GlobalSystem.permission.permCatCadCarg      == "S"){permissionIndex[3]   = true;}else{permissionIndex[3] = false;} 
            if(GlobalSystem.permission.permCatCadCarg_1    == "S"){permissionIndex[4]   = true;}else{permissionIndex[4] = false;} 
            if(GlobalSystem.permission.permCatCadCarg_2    == "S"){permissionIndex[5]   = true;}else{permissionIndex[5] = false;} 
            if(GlobalSystem.permission.permCatCadCarg_3    == "S"){permissionIndex[6]   = true;}else{permissionIndex[6] = false;} 
            if(GlobalSystem.permission.permCatCadCarg_4    == "S"){permissionIndex[7]   = true;}else{permissionIndex[7] = false;} 
            if(GlobalSystem.permission.permCatCadCarg_5    == "S"){permissionIndex[8]   = true;}else{permissionIndex[8] = false;} 
            if(GlobalSystem.permission.permCatCadRank      == "S"){permissionIndex[9]   = true;}else{permissionIndex[9] = false;} 
            if(GlobalSystem.permission.permCatCadRank_1    == "S"){permissionIndex[10]  = true;}else{permissionIndex[10]= false;} 
            if(GlobalSystem.permission.permCatCadRank_2    == "S"){permissionIndex[11]  = true;}else{permissionIndex[11]= false;} 
            if(GlobalSystem.permission.permCatCadRank_3    == "S"){permissionIndex[12]  = true;}else{permissionIndex[12]= false;} 
            if(GlobalSystem.permission.permCatCadRank_4    == "S"){permissionIndex[13]  = true;}else{permissionIndex[13]= false;} 
            if(GlobalSystem.permission.permCatCadRank_5    == "S"){permissionIndex[14]  = true;}else{permissionIndex[14]= false;} 
            if(GlobalSystem.permission.permCatCadRank_6    == "S"){permissionIndex[15]  = true;}else{permissionIndex[15]= false;} 
            if(GlobalSystem.permission.permCatCadRank_7    == "S"){permissionIndex[16]  = true;}else{permissionIndex[16]= false;} 
            if(GlobalSystem.permission.permCatCadRank_8    == "S"){permissionIndex[17]  = true;}else{permissionIndex[17]= false;} 
            if(GlobalSystem.permission.permCatCadRank_9    == "S"){permissionIndex[18]  = true;}else{permissionIndex[18]= false;} 
            if(GlobalSystem.permission.permCatCadStat      == "S"){permissionIndex[19]  = true;}else{permissionIndex[19]= false;} 
            if(GlobalSystem.permission.permCatCadStat_1    == "S"){permissionIndex[20]  = true;}else{permissionIndex[20]= false;} 
            if(GlobalSystem.permission.permCatCadStat_2    == "S"){permissionIndex[21]  = true;}else{permissionIndex[21]= false;} 
            if(GlobalSystem.permission.permCatCadStat_3    == "S"){permissionIndex[22]  = true;}else{permissionIndex[22]= false;} 
            if(GlobalSystem.permission.permCatCadStat_4    == "S"){permissionIndex[23]  = true;}else{permissionIndex[23]= false;} 
            if(GlobalSystem.permission.permCatCadStat_5    == "S"){permissionIndex[24]  = true;}else{permissionIndex[24]= false;} 
            if(GlobalSystem.permission.permCatCadStat_6    == "S"){permissionIndex[25]  = true;}else{permissionIndex[25]= false;} 
            if(GlobalSystem.permission.permCatCadClass     == "S"){permissionIndex[26]  = true;}else{permissionIndex[26]= false;} 
            if(GlobalSystem.permission.permCatCadClass_1   == "S"){permissionIndex[27]  = true;}else{permissionIndex[27]= false;} 
            if(GlobalSystem.permission.permCatCadClass_2   == "S"){permissionIndex[28]  = true;}else{permissionIndex[28]= false;} 
            if(GlobalSystem.permission.permCatCadClass_3   == "S"){permissionIndex[29]  = true;}else{permissionIndex[29]= false;} 
            if(GlobalSystem.permission.permCatCadClass_4   == "S"){permissionIndex[30]  = true;}else{permissionIndex[30]= false;} 
            if(GlobalSystem.permission.permCatCadClass_5   == "S"){permissionIndex[31]  = true;}else{permissionIndex[31]= false;} 
            if(GlobalSystem.permission.permCatCadClass_6   == "S"){permissionIndex[32]  = true;}else{permissionIndex[32]= false;} 
            if(GlobalSystem.permission.permCatCadClass_7   == "S"){permissionIndex[33]  = true;}else{permissionIndex[33]= false;} 
            if(GlobalSystem.permission.permCatCadClass_8   == "S"){permissionIndex[34]  = true;}else{permissionIndex[34]= false;} 
            if(GlobalSystem.permission.permCatCadClass_9   == "S"){permissionIndex[35]  = true;}else{permissionIndex[35]= false;} 
            if(GlobalSystem.permission.permCatCadClass_10  == "S"){permissionIndex[36]  = true;}else{permissionIndex[36]= false;} 
            if(GlobalSystem.permission.permCatCadClass_11  == "S"){permissionIndex[37]  = true;}else{permissionIndex[37]= false;} 
            if(GlobalSystem.permission.permCatCadClass_12  == "S"){permissionIndex[38]  = true;}else{permissionIndex[38]= false;} 
            if(GlobalSystem.permission.permCatCadReborn    == "S"){permissionIndex[39]  = true;}else{permissionIndex[39]= false;} 
            if(GlobalSystem.permission.permCatCadReborn_1  == "S"){permissionIndex[40]  = true;}else{permissionIndex[40]= false;} 
            if(GlobalSystem.permission.permCatCadReborn_2  == "S"){permissionIndex[41]  = true;}else{permissionIndex[41]= false;} 
            if(GlobalSystem.permission.permCatCadReborn_3  == "S"){permissionIndex[42]  = true;}else{permissionIndex[42]= false;} 
            if(GlobalSystem.permission.permCatCadReborn_4  == "S"){permissionIndex[43]  = true;}else{permissionIndex[43]= false;} 
            if(GlobalSystem.permission.permEditEdit        == "S"){permissionIndex[44]  = true;}else{permissionIndex[44]= false;} 
            if(GlobalSystem.permission.permEditAlter       == "S"){permissionIndex[45]  = true;}else{permissionIndex[45]= false;} 
            if(GlobalSystem.permission.permEditExclu       == "S"){permissionIndex[46]  = true;}else{permissionIndex[46]= false;} 
            if(GlobalSystem.permission.permEditSetob       == "S"){permissionIndex[47]  = true;}else{permissionIndex[47]= false;} 
            if(GlobalSystem.permission.permEditCargo       == "S"){permissionIndex[48]  = true;}else{permissionIndex[48]= false;} 
            if(GlobalSystem.permission.permEditCargo_1     == "S"){permissionIndex[49]  = true;}else{permissionIndex[49]= false;} 
            if(GlobalSystem.permission.permEditCargo_2     == "S"){permissionIndex[50]  = true;}else{permissionIndex[50]= false;} 
            if(GlobalSystem.permission.permEditCargo_3     == "S"){permissionIndex[51]  = true;}else{permissionIndex[51]= false;} 
            if(GlobalSystem.permission.permEditCargo_4     == "S"){permissionIndex[52]  = true;}else{permissionIndex[52]= false;} 
            if(GlobalSystem.permission.permEditCargo_5     == "S"){permissionIndex[53]  = true;}else{permissionIndex[53]= false;} 
            if(GlobalSystem.permission.permEditRank        == "S"){permissionIndex[54]  = true;}else{permissionIndex[54]= false;} 
            if(GlobalSystem.permission.permEditRank_1      == "S"){permissionIndex[55]  = true;}else{permissionIndex[55]= false;} 
            if(GlobalSystem.permission.permEditRank_2      == "S"){permissionIndex[56]  = true;}else{permissionIndex[56]= false;} 
            if(GlobalSystem.permission.permEditRank_3      == "S"){permissionIndex[57]  = true;}else{permissionIndex[57]= false;} 
            if(GlobalSystem.permission.permEditRank_4      == "S"){permissionIndex[58]  = true;}else{permissionIndex[58]= false;} 
            if(GlobalSystem.permission.permEditRank_5      == "S"){permissionIndex[59]  = true;}else{permissionIndex[59]= false;} 
            if(GlobalSystem.permission.permEditRank_6      == "S"){permissionIndex[60]  = true;}else{permissionIndex[60]= false;} 
            if(GlobalSystem.permission.permEditRank_7      == "S"){permissionIndex[61]  = true;}else{permissionIndex[61]= false;} 
            if(GlobalSystem.permission.permEditRank_8      == "S"){permissionIndex[62]  = true;}else{permissionIndex[62]= false;} 
            if(GlobalSystem.permission.permEditRank_9      == "S"){permissionIndex[63]  = true;}else{permissionIndex[63]= false;} 
            if(GlobalSystem.permission.permEditStatus      == "S"){permissionIndex[64]  = true;}else{permissionIndex[64]= false;} 
            if(GlobalSystem.permission.permEditStatus_1    == "S"){permissionIndex[65]  = true;}else{permissionIndex[65]= false;} 
            if(GlobalSystem.permission.permEditStatus_2    == "S"){permissionIndex[66]  = true;}else{permissionIndex[66]= false;} 
            if(GlobalSystem.permission.permEditStatus_3    == "S"){permissionIndex[67]  = true;}else{permissionIndex[67]= false;} 
            if(GlobalSystem.permission.permEditStatus_4    == "S"){permissionIndex[68]  = true;}else{permissionIndex[68]= false;} 
            if(GlobalSystem.permission.permEditStatus_5    == "S"){permissionIndex[69]  = true;}else{permissionIndex[69]= false;} 
            if(GlobalSystem.permission.permEditStatus_6    == "S"){permissionIndex[70]  = true;}else{permissionIndex[70]= false;} 
            if(GlobalSystem.permission.permEditClass       == "S"){permissionIndex[71]  = true;}else{permissionIndex[71]= false;} 
            if(GlobalSystem.permission.permEditClass_1     == "S"){permissionIndex[72]  = true;}else{permissionIndex[72]= false;} 
            if(GlobalSystem.permission.permEditClass_2     == "S"){permissionIndex[73]  = true;}else{permissionIndex[73]= false;} 
            if(GlobalSystem.permission.permEditClass_3     == "S"){permissionIndex[74]  = true;}else{permissionIndex[74]= false;} 
            if(GlobalSystem.permission.permEditClass_4     == "S"){permissionIndex[75]  = true;}else{permissionIndex[75]= false;} 
            if(GlobalSystem.permission.permEditClass_5     == "S"){permissionIndex[76]  = true;}else{permissionIndex[76]= false;} 
            if(GlobalSystem.permission.permEditClass_6     == "S"){permissionIndex[77]  = true;}else{permissionIndex[77]= false;} 
            if(GlobalSystem.permission.permEditClass_7     == "S"){permissionIndex[78]  = true;}else{permissionIndex[78]= false;} 
            if(GlobalSystem.permission.permEditClass_8     == "S"){permissionIndex[79]  = true;}else{permissionIndex[79]= false;} 
            if(GlobalSystem.permission.permEditClass_9     == "S"){permissionIndex[80]  = true;}else{permissionIndex[80]= false;} 
            if(GlobalSystem.permission.permEditClass_10    == "S"){permissionIndex[81]  = true;}else{permissionIndex[81]= false;} 
            if(GlobalSystem.permission.permEditClass_11    == "S"){permissionIndex[82]  = true;}else{permissionIndex[82]= false;} 
            if(GlobalSystem.permission.permEditClass_12    == "S"){permissionIndex[83]  = true;}else{permissionIndex[83]= false;} 
            if(GlobalSystem.permission.permEditReborn      == "S"){permissionIndex[84]  = true;}else{permissionIndex[84]= false;} 
            if(GlobalSystem.permission.permEditReborn_1    == "S"){permissionIndex[85]  = true;}else{permissionIndex[85]= false;} 
            if(GlobalSystem.permission.permEditReborn_2    == "S"){permissionIndex[86]  = true;}else{permissionIndex[86]= false;} 
            if(GlobalSystem.permission.permEditReborn_3    == "S"){permissionIndex[87]  = true;}else{permissionIndex[87]= false;} 
            if(GlobalSystem.permission.permEditReborn_4    == "S"){permissionIndex[88]  = true;}else{permissionIndex[88]= false;} 
            if(GlobalSystem.permission.permEditConsultar   == "S"){permissionIndex[89]  = true;}else{permissionIndex[89]= false;}

            if (GlobalSystem.permission.permAdmin           == "S") { permissionIndex[90] = true; } else { permissionIndex[90] = false; }
            if (GlobalSystem.permission.permAdminUser       == "S") { permissionIndex[91] = true; } else { permissionIndex[91] = false; }
            if (GlobalSystem.permission.permAdminCharacter  == "S") { permissionIndex[92] = true; } else { permissionIndex[92] = false; }
            if (GlobalSystem.permission.permAdminEvent      == "S") { permissionIndex[93] = true; } else { permissionIndex[93] = false; }
            if (GlobalSystem.permission.permAdminSystem     == "S") { permissionIndex[94] = true; } else { permissionIndex[94] = false; }
            if (GlobalSystem.permission.permAdminGlobal     == "S") { permissionIndex[95] = true; } else { permissionIndex[95] = false; }
            
        }                                                                      
    }
}
