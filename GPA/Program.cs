using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA
{
    internal class PrintTable
    {
        static void Main(string[] args)
        {


            Console.Write("I am a Grade Point Average Calculator, What is your name?  ");
            string name = Console.ReadLine()!;
            Gpaclass calculate = new Gpaclass(name);
            calculate.CollectData();

            Console.WriteLine("\n\n");
            Console.WriteLine("|-------------------|------------------|---------------|----------------|--------------|-----------------|");
            Console.WriteLine("|  COURSE & CODE    |   COURSE UNIT    |     GRADE     |   GRADE UNIT   |  WEIGHT Pt   |      REMARK     |");
            Console.WriteLine("|                   |                  |               |                |              |                 |");
            Console.WriteLine("|-------------------|------------------|---------------|----------------|--------------|-----------------|");


            calculate.PrintResult();

            Console.WriteLine("\n\n\n");

        }
    }
}
