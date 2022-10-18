using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgorithmComplexityLab4
{
    class Programm
    {

        public static void Main()
        {

            TimeExperiment();


            //TimeExperiment();
            //if (File.Exists("..//..//..//..//input22.txt"))
            //{
            //    string content = File.ReadAllText("..//..//..//..//input22.txt");
            //    WorkWithPostfix(content);
            //}
            string infix = "A*(B*C+D*E)+F";
            string postfix = Postfix.infixToPostfix(infix);
            Console.WriteLine(postfix);

        }

        public static void TimeExperiment()
        {
            MyQueue<string> queue = new MyQueue<string>();

            List<string> listQ = new List<string>();
            List<string> listS = new List<string>();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            double a;
            stopWatch.Reset();
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
