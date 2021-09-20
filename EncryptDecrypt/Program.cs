using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EncryptDecrypt
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Zadej cestu k souboru: ");
            string path = Console.ReadLine();
            if (!File.Exists(path))
            {
                Console.WriteLine("Cesta k souboru neexistuje!!!");
                Console.ReadLine();
                return;
            }
            string text = File.ReadAllText(path);
            Console.WriteLine("Zadej klíč: ");
            string key = Console.ReadLine();
            if (key == "")
            {
                Console.WriteLine("Není zadán žádný klíč!!!");
                Console.ReadLine();
                return;
            }
            Console.WriteLine();
            string path2 = path.Split(new string[] { ".txt" }, StringSplitOptions.None)[0] + ".cry";
            File.AppendAllText(path2, Encrypt(text, key));
            Console.ReadKey();
        }
        static string Encrypt(string text, string key)
        {
            int position = 0;
            string result = "";
            foreach (var item in text)
            {
                if (position == key.Length)
                    position = 0;
                result += (char)(item ^ key[position]);
                position++;
            }
            return result;
        }
    }
}
