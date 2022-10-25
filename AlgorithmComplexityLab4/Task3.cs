using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmComplexityLab4
{
    class Task3
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



        //Формулировка задачи:
        //9.«Считалка». N ребят стоят по кругу.Начав отсчет от первого, удаляют каждого К-го, смыкая круг после каждого удаления.Определить, кто остался последним.
        public static void CountingRhyme()
        {
            MyList<int> list = new MyList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Console.WriteLine("Введите шаг считалочки");
            int k = int.Parse(Console.ReadLine());
            int count = list.Count;
            int removeAt = 0;

            while ( count > 1)
            {
             
                removeAt = (removeAt + k - 1) % count;

                Console.WriteLine("Выбыл с позиции: {0}, под номером {1}", removeAt+1, list[removeAt].Data);

                list.Delete(removeAt);

                Console.WriteLine("Текущее состоянее: {0}", list.ToString());

                count--;
            }
            Console.WriteLine($"Победитель : {list.ToString()}");

            Console.WriteLine("End.");
            Console.ReadKey();
        }

        //В первой строке ввода дан размер массива n.Далее идут n чисел – элементы массива.
        //Предполагая, что элементы массива – это высоты некоторых сооружений, необходимо определить сколько таких сооружений,
        //можно увидеть из начальной точки 0. Все остальные точки (от 1 до n) – это элементы массива.
        //Пример входных данных:
        //6
        //8 2 3 11 11 10

        //5
        //12 20 39 45 89

        //Выходные данные:

        //2
        //5

        //Пояснение:
        //В первом случае, нам видна точка 8, за ней следует 11 (2 и 3 не видно, так как они меньше 8),
        //последние два элемента(11 и 10) также не видны так как 11 находится на том же уровне,
        //что и 4 элемент(тоже 11), а 10 – еще ниже.Таким образом, видны только два сооружения – 8 и 11 и ответ будет 2.
        //Во втором случае, будут видны все элементы, так как они расположены по возрастанию и ответом будет 5.

        public static void CountBuilding()
        {
            int x;

            Console.WriteLine("Введите количество домов");
            int houseCount = int.Parse(
                Console.ReadLine());

            MyStack<int> stack = new MyStack<int>();

            for (int i = 0; i < houseCount; i++)
            {
                Console.WriteLine($"Введите высоту {i}-го дома");
                x = int.Parse(
                    Console.ReadLine());
                if (i == 0)
                {
                    stack.Push(x);
                }
                if (i > 0)
                {
                    if (x > stack.Top().Data)
                    {
                        stack.Push(x);
                    }
                }
            }

            Console.WriteLine($"С высоты первого здания будет видно {stack.Count()} дома(ов)");
        }


    }
}

