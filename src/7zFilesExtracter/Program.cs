using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace _7zFilesExtracter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = ConfigurationManager.AppSettings["RootFolder"];
            DirectorySearch(path);
        }

        public static void DirectorySearch(string dir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(dir))
                {
                    if (Path.GetExtension(f).Contains(".7z"))
                    {
                        ExtractAndDelete(f, dir);
                    }
                }
                foreach (string d in Directory.GetDirectories(dir))
                {
                    DirectorySearch(d);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ExtractAndDelete(string path, string dest)
        {
            string zPath = "7ZipFiles/7za.exe";
            try
            {
                ProcessStartInfo pro = new ProcessStartInfo();
                pro.WindowStyle = ProcessWindowStyle.Hidden;
                pro.FileName = zPath;
                pro.Arguments = string.Format("x \"{0}\" -y -o\"{1}\"", path, dest);
                Process x = Process.Start(pro);
                x.WaitForExit();

                var ifExtract = ConfigurationManager.AppSettings["DeleteExtractedFiles"];
                try
                {
                    
                    if (bool.Parse(ifExtract) == true)
                    {
                        File.Delete(path);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine("Cannot extract " + Path.GetFileName(path));
                Console.WriteLine("Error message: " + Ex.Message);
            }
        }
    }
}
