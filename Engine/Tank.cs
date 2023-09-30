using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Tank
    {
        private const int Range = 512;
        private const string keyHash = "YUQL23KL23DF90WI5E1JAS467NMCXXL6JAOAUWWMCL0AOMM4A4VZYW9KHJUI2347EJHJKDF3424SKL K3LAKDJSL9RTIKJ";

        public static string Generate(string entrance)
        {
            string str;
            int num;
            try
            {
                string hashable = "";
                int SrcASC = 0;
                int OffSet = 0;
                int keyPos = 0;
                OffSet = (new Random()).Next(256);
                hashable = string.Format("{0:X}", OffSet);
                for (int i = 0; i < entrance.Length; i++)
                {
                    SrcASC = (entrance[i] + (char)OffSet) % 255;
                    if (keyPos < "YUQL23KL23DF90WI5E1JAS467NMCXXL6JAOAUWWMCL0AOMM4A4VZYW9KHJUI2347EJHJKDF3424SKL K3LAKDJSL9RTIKJ".Length)
                    {
                        num = keyPos + 1;
                        keyPos = num;
                    }
                    else
                    {
                        num = 1;
                        keyPos = num;
                    }
                    keyPos = num;
                    SrcASC = SrcASC ^ "YUQL23KL23DF90WI5E1JAS467NMCXXL6JAOAUWWMCL0AOMM4A4VZYW9KHJUI2347EJHJKDF3424SKL K3LAKDJSL9RTIKJ"[keyPos - 1];
                    hashable = string.Concat(hashable, string.Format("{0:X2}", SrcASC));
                    OffSet = SrcASC;
                }
                str = hashable;
            }
            catch
            {
                throw;
            }
            return str;
        }

        public static string Retrive(string entrance)
        {
            try
            {
                string str;
                int num;
                try
                {
                    string hashable = "";
                    int OffSet = 0;
                    int keyPos = 0;
                    int SrcPos = 0;
                    int SrcAsc = 0;
                    int TmpSrcAsc = 0;
                    OffSet = Convert.ToInt32(entrance.Substring(0, 2), 16);
                    SrcPos = 3;
                    bool desc = true;
                    while (desc)
                    {
                        SrcAsc = Convert.ToInt32(entrance.Substring(SrcPos - 1, 2), 16);
                        if (keyPos < "YUQL23KL23DF90WI5E1JAS467NMCXXL6JAOAUWWMCL0AOMM4A4VZYW9KHJUI2347EJHJKDF3424SKL K3LAKDJSL9RTIKJ".Length)
                        {
                            num = keyPos + 1;
                            keyPos = num;
                        }
                        else
                        {
                            num = 1;
                            keyPos = num;
                        }
                        keyPos = num;
                        TmpSrcAsc = SrcAsc ^ "YUQL23KL23DF90WI5E1JAS467NMCXXL6JAOAUWWMCL0AOMM4A4VZYW9KHJUI2347EJHJKDF3424SKL K3LAKDJSL9RTIKJ"[keyPos - 1];
                        TmpSrcAsc = (TmpSrcAsc > OffSet ? TmpSrcAsc + -OffSet : 255 + TmpSrcAsc - OffSet);
                        hashable = string.Concat(hashable, (char)TmpSrcAsc);
                        OffSet = SrcAsc;
                        SrcPos = SrcPos + 2;
                        if (SrcPos >= entrance.Length)
                        {
                            desc = false;
                        }
                    }
                    str = hashable;
                }
                catch
                {
                    throw;
                }
                return str;
            }
            catch
            {
                throw;
            }
        }
    }
}
