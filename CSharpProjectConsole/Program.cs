/* This Program is maded by Thomas Vanmellaerts and co*/

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
            MasterMindGame game = new MasterMindGame(20, 4);
            while (!game.GameFinished) {
                game.SetColor(0, (Color)int.Parse(Console.ReadLine()));
                game.SetColor(1, (Color)int.Parse(Console.ReadLine()));
                game.SetColor(2, (Color)int.Parse(Console.ReadLine()));
                game.SetColor(3, (Color)int.Parse(Console.ReadLine()));
                MasterMindResult result = game.EndTry();
                Console.WriteLine("Posmatch: " + result.PosMatch);
                Console.WriteLine("colormatch: " + result.ColorMatch);
                Console.WriteLine(game.GetDebugInfo());
            }
            if (game.GameWon) {
                Console.WriteLine("You have Won");
            }
            else{
                Console.WriteLine("You have lost");
            }

            Console.ReadKey(true);


        }
    }
}
