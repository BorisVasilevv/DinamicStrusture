using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmComplexityLab4
{
    public class MyStack<T>
    {
        private Node<T> top=null;
        private int count=0;
        
        public void Push(T elem)
        {
            Node<T> node = new Node<T>(elem);
            top.Previous=node;
            node.Next = top;
            top=node;
            count++;
        }

        public T Pop()
        {
            if (count == 0) throw new IndexOutOfRangeException("Stack is empty");
            count--;
            T data = top.Data;
            top = top.Next;
            return data;
        }

        public int Count()
        {
            return count;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public T Top()
        {
            if (count == 0) throw new IndexOutOfRangeException("Stack is empty");
            return top.Data;
        }

        public void Print()
        {
            Node<T> node = top;
            while(node != null)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
        }

        
    }
}
