using System;
using System.IO;

namespace FirstLab
{
    public static class FileWork
    {
        public static Tree GetFromFile()
        {

            try
            {
                using (StreamReader stream = new StreamReader(GetPath()))
                {
                    try
                    {
                        
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid filepath");
            }
        }
        public static String GetPath()
        {
            Console.WriteLine("Enter path to file:");
            string path = Console.ReadLine();
            try
            {
                path = Path.GetFullPath(path);
            }
            catch
            {
                Console.WriteLine("Проверьте путь");
                path = GetPath();
            }
            return path;
        }
    }
}