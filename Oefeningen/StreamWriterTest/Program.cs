using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;

namespace StreamWriterTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter("text.txt"))
            {
                //string woord;
                //do
                //{
                //    woord = Console.ReadLine();
                //    sw.WriteLine(woord);
                //}
                //while (woord != "exit");

                //string woord;
                //do
                //{
                //    woord = Console.ReadLine();
                //    if (woord != "exit")
                //    {
                //        sw.WriteLine(woord);
                //    }
                //}
                //while (woord != "exit");

                string woord = Console.ReadLine(); //Eerste input
                while (woord != "exit")
                {
                    sw.WriteLine(woord);
                    woord = Console.ReadLine();
                }

            }
        }
    }
}
