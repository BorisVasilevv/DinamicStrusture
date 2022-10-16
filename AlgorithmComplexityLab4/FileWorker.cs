using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmComplexityLab4
{
    class FileWorker
    {

        private const string path= "..//..//..//..//input.txt";

        public static string[] ReadFile()
        {
            string[] commands =File.ReadAllText(path).Split(' ',',');
            return commands;
        }

        public static void GenerateFile(int amountOfCommands)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            for(int i=0;i<amountOfCommands; i++)
            {
                int a=random.Next()%5+1;
                sb.Append(a.ToString());
                if(a==1)
                {
                    sb.Append(',');
                    if(random.Next()%2==0) { sb.Append(random.Next()); }
                    else { sb.Append("cat"); }
                }
                if(i!=amountOfCommands-1) sb.Append(' ');
            }
            File.WriteAllText(path,sb.ToString());
        }

    }
}
