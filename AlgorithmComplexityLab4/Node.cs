using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmComplexityLab4
{
    public class Node <T>
    {
        public T Data;



        //public Node(T data, Node<T> next, Node<T> previous)
        //{
        //    Data = data;
        //    Next = next;
        //    Previous = previous;
        //}

        public Node(T data)
        {
            Data = data;
        }
        


        //public Node(){}

        public Node<T> Next=null;
        public Node<T> Previous=null;

    }
}
