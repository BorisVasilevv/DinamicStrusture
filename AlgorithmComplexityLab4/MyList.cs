using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace AlgorithmComplexityLab4
{
    public class MyList<T>
    {
        internal Node<T> start = null;
        internal Node<T> end = null;

        public int Count { get; private set; }

        public Node<T> this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                Node<T> node = start;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
                return node;
            }
            set
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                Node<T> node = start;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
                node = value;
            }

        }
        public MyList() { }

        public MyList(MyList<T> list)
        {

            for (int i=0;i<list.Count;i++)
            {
                this.Add(list[i].Data);
            }
        }

        public void Add(T elem)
        {
            Count++;
            Node<T> node = new Node<T>(elem);
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
                node.Previous = end;
                end = node;
            }
        }

        public void Add(T elem, int index)
        {
            if (index < 0 || index > Count + 1) throw new IndexOutOfRangeException();
            Count++;
            Node<T> newNode = new Node<T>(elem);
            Node<T> node = start;
            if (index == Count + 1)
            {
                Add(elem);
                return;
            }
            if (index == 0)
            {
                node.Next.Previous = null;
                start = node.Next;
            }
            for (int i = 1; i < index; i++)
            {
                node = node.Next;
            }
            newNode.Next = node.Next;
            newNode.Previous = node;
            node.Next = newNode;
            newNode.Next.Previous = newNode;
        }

        public void Delete()
        {
            if (Count == 0) throw new IndexOutOfRangeException("List is empty");
            Count--;
            if (start == end)
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
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            Node<T> node = start;
            if (index == 0 || Count == 1)
            {
                Delete();
                return;
            }
            if (index == Count - 1)
            {
                end = end.Previous;
                end.Next.Previous = null;
                end.Next = null;
                Count--;
                return;
            }
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }
            node.Next.Previous = node.Previous;
            node.Previous.Next = node.Next;
            node.Next = null;
            node.Previous = null;
            node = null;
            Count--;
        }

        public void Print()
        {
            if (Count == 0) throw new IndexOutOfRangeException("List is empty");
            Node<T> node = start;
            while (node != null)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
        }

        public Node<T> StartElem()
        {
            if (Count == 0) throw new IndexOutOfRangeException("List is empty");
            return start;
        }

        public bool IsEmpty() => Count == 0;


        //1.Написать функцию, которая переворачивает список L,
        //т.е. изменяет ссылки в этом списке так,
        //чтобы его элементы оказались расположенными в обратном порядке. 
        public void Reverse()
        {
            if (Count <= 1) return;
            Node<T> node = start;
            while (node != null)
            {
                Node<T> connection = node.Next;
                node.Next = node.Previous;
                node.Previous = connection;
                node = node.Previous;
            }

            node = start;
            start = end;
            end = node;
        }

        //2.Написать функцию, которая переносит в начало (в конец) непустого списка L его последний (первый) элемент. 
        public void LastOnFirstPosition()
        {
            if (Count <= 1) return;
            Node<T> node = start;
            node.Previous = end;
            end.Next = node;
            end = end.Previous;
            end.Next.Previous = null;
            end.Next = null;
            start = start.Previous;
        }

        public void FirstOnLastPosition()
        {
            if (Count <= 1) return;
            end.Next = start;
            start.Previous = end;
            start = start.Next;
            start.Previous = null;
            end = end.Next;
            end.Next = null;
        }

        //3.Написать функцию, которая определяет количество различных элементов списка, содержащего целые числа.
        public int AmountOfIntegerNumbers()
        {
            int total = 0;
            Node<T> node = start;
            while (node != null)
            {
                try
                {
                    double a = Double.Parse(node.Data.ToString());
                    if (a == Math.Truncate(a)) total++;
                }
                catch (Exception ignoreException)
                {

                }
                node = node.Next;
            }
            return total;
        }

        //4.Написать функцию, которая удаляет из списка L второй из двух одинаковых элементов.
        public void DeleteTheDoubledElem()
        {
            List<int> a = new List<int>();
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count; j++)
                {
                    if (i == j) continue;
                    if (this[i].Data.Equals(this[j].Data))
                    {
                        Delete(j);
                        return;
                    }
                }
            }
        }


        //5.Написать функцию вставки списка самого в себя вслед за первым вхождением числа х.
        public void MakeSelfDuplicateByIndex(int insertIndex)
        {
            if (insertIndex < 0 || insertIndex >= Count) throw new IndexOutOfRangeException();
            Node<T> node = start;
            MyList<T> copyOfList = new MyList<T>();
            for (int i = 0; i < Count; i++)
                copyOfList.Add(this[i].Data);
            for (int i = 0; i < insertIndex - 1; i++)
            {
                node = node.Next;
            }
            if (insertIndex == Count - 1) return;
            Node<T> copyOfConnect = node.Next;
            node.Next = copyOfList.start;
            copyOfList.start.Previous = node;
            copyOfList.end.Next = copyOfConnect;
            copyOfConnect.Previous = copyOfList.end;
        }

        //7.Написать функцию, которая удаляет из списка L все элементы Е, если таковые имеются. 
        public void DeleteElements(T elem)
        {
            MyList<int> indexsOfMatched = new MyList<int>();
            for (int i = 0; i < Count; i++)
                if (this[i].Data.Equals(elem))
                    indexsOfMatched.Add(i);

            for (int i = indexsOfMatched.Count - 1; i >= 0; i--)
                Delete(indexsOfMatched[i].Data);
        }

        //8.Написать функцию, которая вставляет в список L новый элемент F перед первым вхождением элемента Е, если Е входит в L.
        public void InsertElement( T insertedElem, T elemAfter)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Data.Equals(elemAfter))
                {
                    Add(insertedElem, i);
                    return;
                }
            }
        }


        //9.Функция дописывает к списку L список E. Оба списка содержат целые числа. В основной программе считать их из файла. 
        public void Append(MyList<T> myList)
        {
            end.Next = myList.start;
            myList.start.Previous = end;
            this.Count += myList.Count;
        }


        //10.Функция разбивает список целых чисел на два списка по первому вхождению заданного числа.
        //Если этого числа в списке нет, второй список будет пустым, а первый не изменится.
        public MyList<T> CutByElem(T elem)
        {
            MyList<T> myList = new MyList<T>();
            int index = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (index == -1 && this[i].Data.Equals(elem))
                {
                    index = i;
                }
            }

            if (index != -1)
            {
                Node<T> node = this[index].Next;

                node.Previous.Next = null;
                node.Previous = null;
                for (int i = 0; i < this.Count - index; i++)
                {
                    myList.Add(node.Data);
                    node = node.Next;

                }
                this.Count = index + 1;
            }
            return myList;
        }

        //11.Функция удваивает список, т.е. приписывает в конец списка себя самого.
        public void TwiceMyList()
        {
            MyList<T> myList = new MyList<T>(this);
            Append(myList);
        }


        //12.Функция меняет местами два элемента списка, заданные пользователем
        public  void ChangePlacesTwoElems( int firstIndex, int secondIndex)
        {
            if (firstIndex >= Count || secondIndex >= Count) throw new IndexOutOfRangeException();
            if (firstIndex == secondIndex) return;
            if (firstIndex > secondIndex)
            {
                int a = firstIndex;
                firstIndex = secondIndex;
                secondIndex = a;
            }
            Node<T> first = this[firstIndex];
            Node<T> second = this[secondIndex];

            Node<T> copyOfConnectionNext = first.Next;
            Node<T> copyOfConnectionPrevious = first.Previous;

            if (firstIndex == 0)
            {
                first.Next.Previous = second;
                first.Next = second.Next;
                first.Previous = second.Previous;

                start = second;
            }
            else
            {
                first.Next.Previous = second;
                first.Previous.Next = second;
                first.Next = second.Next;
                first.Previous = second.Previous;
            }

            if (secondIndex == Count - 1)
            {

                second.Previous.Next = first;
                second.Next = copyOfConnectionNext;
                second.Previous = copyOfConnectionPrevious;
                end = first;
            }
            else
            {
                second.Next.Previous = first;
                second.Previous.Next = first;
                second.Next = copyOfConnectionNext;
                second.Previous = copyOfConnectionPrevious;
            }
        }

    }

    public static class MyListExtension
    {
        //6.Написать функцию, которая вставляет в непустой список L,
        //элементы которого упорядочены по не убыванию,
        //новый элемент Е так, чтобы сохранилась упорядоченность.

        public static void InsertElement(this MyList<int> list, int elem)
        {
            if (list.Count == 0) list.Add(elem);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Data >= elem)
                {
                    list.Add(elem, i);
                    return;
                }

            }
            list.Add(elem, list.Count - 1);
        }
    }
}

