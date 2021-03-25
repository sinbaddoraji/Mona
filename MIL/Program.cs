using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = System.IO.File.ReadAllText("Hello-World.mil");

            TokenizerParser tokenizerParser = new TokenizerParser(code);
            tokenizerParser.ParseRun();
            Console.ReadKey();
            try
            {
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            

        }
    }
}
