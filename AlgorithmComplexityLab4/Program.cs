using System;

namespace AlgorithmComplexityLab4
{
    class Programm
    {
        public static void Main()
        {
            MyQueue<string> queue = new MyQueue<string>();
            FileWorker.GenerateFile(1000);
            string[] setOfCommands = FileWorker.ReadFile();
            queue.Add("cdf");
            for(int i=0;i<12;i++)
            {
                queue.Add(i.ToString());
            }
            queue.Print();
            WorkWithStack(setOfCommands);
            Thread.Sleep(10);
            WorkWithQueue(setOfCommands);




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
                            queue.WriteFirstElem();
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