using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphisme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStore<int> intStore = new DataStore<int>();
            DataStore<string> stringStore = new DataStore<string>();

            intStore.Data = 5;
            stringStore.Data = "5";

        }

    }
}
