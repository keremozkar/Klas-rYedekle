using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasörYedekleme
{
    class BoyutBul
    {

        public static long Hesaplama(DirectoryInfo directory, bool includeSubdirectories)
        {
            long ToplamBoyut = 0;
            // Examine all contained files.
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                ToplamBoyut += file.Length;
            }
            // Examine all contained directories.
            if (includeSubdirectories)
            {
                DirectoryInfo[] dirs = directory.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    ToplamBoyut += Hesaplama(dir, true);
                }
            }
            return ToplamBoyut;
        }
        public static String BytesToString(long ByteSayı)
        {
            string[] Boyutİsim = { " Bayt", " KiloBayt", " MegaBayt", " GigaBayt", " TeraBayt", " PetaBayt", " EksaBayt" }; //Longs run out around EB
            if (ByteSayı == 0)
                return "0" + Boyutİsim[0];
            long bytes = Math.Abs(ByteSayı);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(ByteSayı) * num).ToString() + Boyutİsim[place];
        }
        public static String SadeceSayi(long ByteSayı)
        {
            string[] Boyutİsim = { "" }; //Longs run out around EB
            if (ByteSayı == 0)
                return "0" + Boyutİsim[0];
            long bytes = Math.Abs(ByteSayı);
            int place = 0;
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(ByteSayı) * num).ToString() + Boyutİsim[place];
        }
    }
}
