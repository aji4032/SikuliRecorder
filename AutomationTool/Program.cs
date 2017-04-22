using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                //while()
                //
                
                //if (key == "c")
                //{
                //    region test = new region(Utilities.CurrentMousePosition(), 100, 100);
                //    Utilities.CaptureScreen(test, @"C:\Users\Aji\Desktop\test.png");
                //    Console.WriteLine();
                //}
            }
            //Console.WriteLine(Utilities.CurrentMousePosition());
        }
        private static void decideAction(string key)
        {
            switch (key.ToLower())
            {
                case "c":
                    caseC();
                    break;

                case "d":
                    caseD();
                    break;

                case "v":
                    caseV();
                    break;

                default:
                    Console.WriteLine("Invalid selection!");
                    break;
            }

        }
        private static void caseC()
        {
            throw new NotImplementedException();
        }
    }
}
