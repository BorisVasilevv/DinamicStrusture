using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmComplexityLab4
{
    class FileWorker
    {
        public static string[] ReadFile()
        {
            string[] commands =File.ReadAllText("..//..//..//..//input.txt").Split(' ',',');
            return commands;
        }
    }
}
