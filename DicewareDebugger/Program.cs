using System;
using System.Collections.Generic;
using System.Linq;
using Diceware;

namespace DicewareDebugger
{
    class Program
    {
        static void Main(string[] args)
        {
            Diceware.Diceware dw = new Diceware.Diceware(Wordlist.Diceware, 5, " ");
            
            for(int i=0;i<5000;i++)
            {
                Console.WriteLine("{0}", dw.GetPassword());
            }
            
            

            Console.ReadLine();
        }
    }
}
