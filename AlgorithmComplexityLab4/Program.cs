using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgorithmComplexityLab4
{
    class Programm
    {

        public static void Main()
        {

            //TestMyListFunctionality();

            //TimeExperiment();


            //TimeExperiment();
            //if (File.Exists("..//..//..//..//input22.txt"))
            //{
            //    string content = File.ReadAllText("..//..//..//..//input22.txt");
            //    WorkWithPostfix(content);
            //}

            //Task3.CountingRhyme(); //3 часть список
            //Task3.queue(); //3 часть очередь
            //Task3.CountBuilding(); //3 часть стек
            BinaryTree.task3(); //3 часть дерево
            string infix = "A*(B*C+D*E)+F";
            string postfix = Postfix.infixToPostfix(infix);
            Console.WriteLine(postfix);

        }


        public static void TestMyListFunctionality()
        {
            //1.Написать функцию, которая переворачивает список L,
            //т.е. изменяет ссылки в этом списке так,
            //чтобы его элементы оказались расположенными в обратном порядке. 
            Console.WriteLine("task 1");
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(1);
            list.Add(3);
            list.Add(4, 2);

            list.Print();
            Console.WriteLine();

            list.Reverse();
            list.Print();
            Console.WriteLine();

            //2.Написать функцию, которая переносит в начало (в конец) непустого списка L его последний (первый) элемент. 
            Console.WriteLine("task 2");
            list.LastOnFirstPosition();
            list.Print();
            Console.WriteLine();

            list.FirstOnLastPosition();
            list.Print();
            Console.WriteLine();

            //3.Написать функцию, которая определяет количество различных элементов списка, содержащего целые числа.
            Console.WriteLine("task 3");
            Console.WriteLine(list.AmountOfIntegerNumbers());
            Console.WriteLine();

            //4.Написать функцию, которая удаляет из списка L второй из двух одинаковых элементов.
            Console.WriteLine("task 4");
            list.DeleteTheDoubledElem();
            list.Print();
            Console.WriteLine();

            //5.Написать функцию вставки списка самого в себя вслед за первым вхождением числа х.
            Console.WriteLine("task 5");
            list.MakeSelfDuplicateByIndex(2);
            list.Print();
            Console.WriteLine();

            //6.Написать функцию, которая вставляет в непустой список L,
            //элементы которого упорядочены по не убыванию,
            //новый элемент Е так, чтобы сохранилась упорядоченность.
            Console.WriteLine("task 6");
            MyList<int> orderedList = new MyList<int>();
            orderedList.Add(1);
            orderedList.Add(2);
            orderedList.Add(3);
            orderedList.Add(3);
            orderedList.Add(5);
            orderedList.Add(6);
            orderedList.InsertElement(3);
            orderedList.Print();
            Console.WriteLine();

            //7.Написать функцию, которая удаляет из списка L все элементы Е, если таковые имеются
            Console.WriteLine("task 7");
            orderedList.DeleteElements(3);
            orderedList.Print();
            Console.WriteLine();

            //8.Написать функцию, которая вставляет в список L новый элемент F перед первым вхождением элемента Е, если Е входит в L.
            Console.WriteLine("task 8");
            orderedList.InsertElement(4, 5);
            orderedList.Print();
            Console.WriteLine();

            //9.Функция дописывает к списку L список E. Оба списка содержат целые числа. В основной программе считать их из файла. 
            Console.WriteLine("task 9");
            orderedList.Append(list);
            orderedList.Print();
            Console.WriteLine();

            //10.Функция разбивает список целых чисел на два списка по первому вхождению заданного числа.
            //Если этого числа в списке нет, второй список будет пустым, а первый не изменится.

            Console.WriteLine("task 10");

            list = orderedList.CutByElem(6);
            orderedList.Print();
            Console.WriteLine();          
            list.Print();
            Console.WriteLine();

            //11.Функция удваивает список, т.е. приписывает в конец списка себя самого. 
            Console.WriteLine("task 11");

            list.TwiceMyList();
            list.Print();
            Console.WriteLine();

            //12.Функция меняет местами два элемента списка, заданные пользователем
            Console.WriteLine("task 12");
            list = new MyList<int>();
            for (int i=0;i<10;i++)
                list.Add(i);
            list.Print();
            Console.WriteLine();
            list.ChangePlacesTwoElems(0, 4);
            list.ChangePlacesTwoElems(3, 9);
            list.Print();


        }

        public static void TimeExperiment()
        {
            MyQueue<string> queue = new MyQueue<string>();

            List<string> listQ = new List<string>();
            List<string> listS = new List<string>();
            Stopwatch stopWatch = new Stopwatch();
            double a;

            for (int i = 1; i <= 100; i++)
            {

                string[] setOfCommands = FileWorker.GenerateCommands(100 * i);

                stopWatch.Start();
                WorkWithStack(setOfCommands);
                stopWatch.Stop();

                a = stopWatch.Elapsed.TotalMilliseconds;
                listS.Add(a.ToString());

                stopWatch.Reset();

                stopWatch.Start();
                WorkWithQueue(setOfCommands);
                stopWatch.Stop();
                a = stopWatch.Elapsed.TotalMilliseconds;
                listQ.Add(a.ToString());

                stopWatch.Reset();

            }
            File.WriteAllLines("..//..//..//..//Stack.txt", listS);
            File.WriteAllLines("..//..//..//..//Queue.txt", listQ);
        }


        public static void WorkWithStack(string[] setOfCommands)
        {
            MyStack<string> stack = new MyStack<string>();
            for (int i = 0; i < setOfCommands.Length; i++)
            {
                try
                {
                    switch (setOfCommands[i])
                    {
                        case "1":
                            stack.Push(setOfCommands[++i]);
                            break;
                        case "2":
                            stack.Pop();
                            break;
                        case "3":
                            stack.Top();
                            break;
                        case "4":
                            stack.IsEmpty();
                            break;
                        case "5":
                            stack.Print();
                            break;
                        default: throw new Exception("Not idintificated command");

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void WorkWithQueue(string[] setOfCommands)
        {
            MyQueue<string> queue = new MyQueue<string>();
            for (int i = 0; i < setOfCommands.Length; i++)
            {
                try
                {
                    switch (setOfCommands[i])
                    {
                        case "1":
                            queue.Add(setOfCommands[++i]);
                            break;
                        case "2":
                            queue.Delete();
                            break;
                        case "3":
                            queue.StartElem();
                            break;
                        case "4":
                            queue.IsEmpty();
                            break;
                        case "5":
                            queue.Print();
                            break;
                        default:
                            throw new Exception("Not idintificated command");


                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

}
