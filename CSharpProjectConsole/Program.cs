using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjectConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MasterMindRow row1 = new MasterMindRow(4);
            MasterMindRow row2 = new MasterMindRow(4);

            if (row1 == row2)
            {
                Console.WriteLine("match");
            }
            else {
                Console.WriteLine("no match");
            }


            Console.ReadKey(true);
        }
    }
}
