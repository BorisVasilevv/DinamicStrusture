using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlgorithmComplexityLab4
{
    public class BinaryTree
    {
        public readonly int value;
        public readonly MyList<BinaryTree> leaves = new MyList<BinaryTree>();

        public BinaryTree(int value)
        {
            this.value = value;
        }

        //Функция, опеределяющая количество уровней дерева
        public int GetHigh()
        {
            int max = 0;
            for (int i=0;i<leaves.Count;i++) 
            {
                int current = leaves[i].Data.GetHigh();
                if (current > max)
                    max = current;
            }
            return max + 1;
        }

        public static void task3()
        {
            BinaryTree root = new BinaryTree(1);
            Console.WriteLine(root.GetHigh());
            root.leaves.Add(new BinaryTree(0));
            Console.WriteLine(root.GetHigh());

            Console.ReadKey();

        }
    }
}