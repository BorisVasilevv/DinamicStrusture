using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmComplexityLab4
{
    class MyQueue<T>
    {
        private Node<T> start=null;
        private Node<T> end=null;

        private int count=0;

        public void Add(T elem)
        {
            count++; 
            Node<T> node=new Node<T>(elem);
            if (end == null)
            {
                start = node;
                end = node;
            }
            //else if (start == end)
            //{
            //    start.Next = node;
            //    node.Previous = start;
            //    end=node;
            //}
            else
            {
                end.Next = node;
                node.Previous=end;
                end = node;
            }
        }

        public void Add(T elem, int index)
        {
            if(index<0||index>count+1) throw new IndexOutOfRangeException();
            count++;
            Node<T> newNode = new Node<T>(elem);
            Node<T> node = start;
            if (index == count+1)
            {
                Add(elem);
                return;
            }
            if(index==0)
            {
                node.Next.Previous = null;
                start = node.Next;
            }
            for(int i=1; i<index;i++)
            {
                node = node.Next;
            }
            newNode.Next = node.Next;
            newNode.Previous= node;
            node.Next = newNode;
            newNode.Next.Previous= newNode;
        }

        public void Delete()
        {
            if (count == 0) throw new IndexOutOfRangeException("Queye is empty");
            count--;
            if(start==end)
            {
                start = null;            
                end = null;
            }
            else
            {
                start = start.Next;
                start.Previous = null;
            }
        }

        public void Delete(int index)
        {
            if (index < 0 || index >count) throw new IndexOutOfRangeException();
            count--;
            Node<T> node = start;
            if (index == 0)
            {
                Delete();
                return;
            }
            for (int i = 1; i < index; i++)
            {
                node = node.Next;
            }
            node.Next.Previous = node.Previous;
            node.Previous.Next = node.Next;
            node.Next = null;
            node.Previous = null;
            node = null;
        }

        public void Print()
        {
            if (count == 0) throw new IndexOutOfRangeException("Queye is empty");
            Node<T> node = start;
            while (node!=null)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
        }

        public Node<T> StartElem()
        {
            if (count == 0) throw new IndexOutOfRangeException("Queye is empty");
            return start;
        }

        public bool IsEmpty() => count== 0;

    }
}
