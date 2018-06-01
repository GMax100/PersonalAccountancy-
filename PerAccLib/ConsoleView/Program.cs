using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleView
{
    class Program
    {
        private static Model m;

        static void Main(string[] args)
        {
            m = new Model();
            WriteModel();
            Console.ReadKey();
        }

        private static void WriteModel()
        {
            WriteUser();
            string indent = "  ";
        }

        private static void WriteUser()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("User - ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(m.U.Name + "\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write("Budgs: \n");
            Console.Write(" Own budgs: \n");
            if (m.U.RedactBudgs.Count == 0)
                Console.Write(" - \n");
            else
            {
                List<string> budgs = m.U.RedactBudgs;
                for (int i = 0; i < budgs.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("  *");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" - ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(budgs[i] + '\n');
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
            }


            Console.Write("\n" + " Read budgs: \n");
            if (m.U.ReadBudgs.Count == 0)
                Console.Write(" - \n");
            else
            {
                List<string> budgs = m.U.ReadBudgs;
                for (int i = 0; i < budgs.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("  *");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" - ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(budgs[i] + '\n');
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
            }
        }
    }
}
