using System;
using System.IO;

class KlasorKopyalamaSınıf
{
    public static void KlasorCopy(string KlasorY, string Hedef, bool AltKopyala)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(KlasorY);

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Kaynak Klasörü Bulunamadı: " + KlasorY);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        // If the destination directory doesn't exist, create it.
        if (!Directory.Exists(Hedef))
        {
            Directory.CreateDirectory(Hedef);
        }

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(Hedef, file.Name);
        file.CopyTo(temppath, true);
        }

        // If copying subdirectories, copy them and their contents to new location.
        if (AltKopyala)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(Hedef, subdir.Name);
                KlasorCopy(subdir.FullName, temppath, AltKopyala);
            }
        }
    }
}