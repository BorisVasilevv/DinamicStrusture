using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmComplexityLab4
{
    class Task3Queue
    {
        public static void queue()
        {
            Queue<int> q1 = new Queue<int>(Enumerable.Repeat(new Random(), 20).Select(r => r.Next(-60, 61)));
            Console.WriteLine(String.Join(", ", q1));
            Queue<int> q2 = new Queue<int>();
            for (int i = q1.Count; i != 0; i--)
            {
                int n = q1.Dequeue();
                (n < 0 ? q1 : q2).Enqueue(n);
            }
            while (q1.Count != 0)
            {
                q2.Enqueue(q1.Dequeue());
            }
            Console.WriteLine(String.Join(", ", q2));
        }
    }
}
