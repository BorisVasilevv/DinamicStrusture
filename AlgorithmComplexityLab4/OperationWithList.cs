using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmComplexityLab4
{
    static class OperationWithList
    {

        public static void Start()
        {
            //1.
            List<int> list = new List<int> { 2, 4, 6, 8 };

            ReverseList(list);
            Console.WriteLine(String.Join(',', list));

            //2.
            // Инициализируем массив
            List<int> intArr1 = new List<int> { 1, 5, 6, 2, 8, 9, 7 };

            // Перестановка элементов массива
            MoveElement<int>(intArr1, intArr1.Count - 1, 0);

            // Вывод результата
            foreach (var item in intArr1)
            {
                if (item == intArr1[0])
                    Console.Write("{0}{1}", '{', item);
                else Console.Write(", {0}", item);
            }
            Console.WriteLine("{0}", '}');

            //3.
            List<int> intArr2 = new List<int> { 1, 2, 3, 2, 2, 1 };

            int answ = GetUniqueElementsCount(intArr2);
            Console.WriteLine(answ);

            //4.
            //List<int> answ4 = intArr2.Distinct().ToList<int>();
            RemoveDuplicateElement(intArr2);
            foreach (var element in intArr2)
            {
                Console.Write(element);
            }
            Console.WriteLine();

            //5. 
            List<int> intArr3 = new List<int> { 1, 2, 3 };
            List<int> newIntArr3 = MakeSelfDuplicate(intArr3, 2);
            foreach (var element in newIntArr3)
            {
                Console.Write(element);
            }
            Console.WriteLine();

            //6.
            List<int> newIntArr4 = InsertElement(intArr3, 3);
            foreach (var element in newIntArr4)
            {
                Console.Write(element);
            }
            Console.WriteLine();

            //7. 
            List<int> newIntArr5 = DeleteElements(intArr3, 3);
            foreach (var element in newIntArr5)
            {
                Console.Write(element);
            }
            Console.WriteLine();

            //8.
            List<int> newIntArr6 = InsertElement(intArr3, 3, 2);
            foreach (var element in newIntArr6)
            {
                Console.Write(element);
            }
            Console.WriteLine();

            //10. 
            (List<int> firstArr, List<int> secondArr) = MakeTwoLists(intArr3, 0);
            foreach (var element in firstArr)
            {
                Console.Write(element);
            }
            Console.WriteLine();
            if (secondArr.Count > 0)
            {
                foreach (var element in secondArr)
                {
                    Console.Write(element);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Список не изменился");
            }

            //11.
            List<int> newDoubleList = MakeDoubleList(intArr3);
            foreach (var element in newDoubleList)
            {
                Console.Write(element);
            }
            Console.WriteLine();
        }

        //1. Написать функцию, которая переворачивает список L, т.е. изменяет ссылки
        //в этом списке так, чтобы его элементы оказались расположенными в обратном порядке.
        public static void ReverseList<T>(List<T> list)
        {
            if (list == null || list.Count <= 1)
            {
                return;
            }

            // удаляем первый элемент
            T value = list[0];
            list.RemoveAt(0);

            // повторить для оставшихся элементов
            ReverseList(list);

            // вставляем верхний элемент обратно после рекурсии для оставшихся элементов
            list.Add(value);
        }

        static void RemoveElementAt<T>(this List<T> array, int index)
        {
            List<T> newArray = new List<T>();
            for (int i = 0; i < index; i++)
            {
                newArray.Add(array[i]);
            }
            for (int i = index + 1; i < array.Count; i++)
            {
                newArray.Add(array[i]);
            }
            array = newArray;
        }

        //2. Написать функцию, которая переносит в начало (в конец) непустого списка L его последний (первый) элемент. 
        static void MoveElement<T>(List<T> array, int indexFrom, int indexTo)
        {
            T temp = array[indexFrom];
            T value = temp;

            if (indexFrom < indexTo)
            {
                for (int i = indexFrom + 1; i <= indexTo; i++)
                {
                    temp = array[i];
                    array[i] = value;
                    value = temp;
                }

                array[indexFrom] = temp;
            }
            else
            {
                for (int i = indexFrom - 1; i >= indexTo; i--)
                {
                    temp = array[i];
                    array[i] = value;
                    value = temp;
                }

                array[indexFrom] = temp;
            }
        }

        //3. Написать функцию, которая определяет количество различных элементов списка, содержащего целые числа.
        //Суть алгоритма в том, что он ищет в подпоследовательностях повторяющиеся элементы:
        //если находит, отбрасывает один элемент из начала списка и идёт дальше по новой подпоследовательности
        //если нет, то прибавляет единицу к ответу.
        static int GetUniqueElementsCount<T>(List<T> array)
        {
            int uniqueElementsCount = 1;

            for (int start = 0; start < array.Count - 1; start++)
            {
                for (int next = start + 1; next < array.Count; next++)
                {
                    if (array[start].Equals(array[next]))
                        break;

                    if (next == array.Count - 1)
                        uniqueElementsCount++;
                }
            }

            return uniqueElementsCount;
        }

        //4. Написать функцию, которая удаляет из списка L второй из двух одинаковых элементов.
        static void RemoveDuplicateElement<T>(List<T> array)
        {
            for (int start = 0; start < array.Count - 1; start++)
            {
                for (int next = start + 1; next < array.Count; next++)
                {
                    if (array[start].Equals(array[next]))
                    {
                        array.RemoveAt(next);
                        break;
                    }
                }
            }
        }

        //5. Написать функцию вставки списка самого в себя вслед за первым вхождением числа х.
        static List<T> MakeSelfDuplicate<T>(List<T> array, int x)
        {
            List<T> newArray = new List<T>();
            int dotX = 0;

            for (int i = 0; i < array.Count; i++)
            {
                newArray.Add(array[i]);
                if (array[i].Equals(x))
                {
                    dotX = i;
                    break;
                }
            }
            for (int i = 0; i < array.Count; i++)
            {
                newArray.Add(array[i]);
            }
            for (int i = dotX + 1; i < array.Count; i++)
            {
                newArray.Add(array[i]);
            }

            return newArray;
        }

        //6. Написать функцию, которая вставляет в непустой список L, элементы которого упорядочены по не убыванию, новый элемент Е так, чтобы сохранилась упорядоченность
        static List<int> InsertElement(List<int> array, int e)
        {
            List<int> newArray = new List<int>();

            for (int i = 0; i < array.Count; i++)
            {
                if ((array[i].Equals(e)) || (array[i + 1] > e))
                {
                    newArray.Add(array[i]);
                    newArray.Add(e);
                    continue;
                }
                newArray.Add(array[i]);

            }
            return newArray;
        }

        //7. Написать функцию, которая удаляет из списка L все элементы Е, если таковые имеются.
        static List<T> DeleteElements<T>(List<T> array, int e)
        {
            List<T> newArray = new List<T>();

            for (int i = 0; i < array.Count; i++)
            {
                if (array[i].Equals(e))
                    continue;
                newArray.Add(array[i]);
            }
            return newArray;
        }

        //8. Написать функцию, которая вставляет в список L новый элемент F перед первым вхождением элемента Е, если Е входит в L
        static List<T> InsertElement<T>(List<T> array, T e, T f)
        {
            List<T> newArray = new List<T>();

            for (int i = 0; i < array.Count; i++)
            {
                if (array[i].Equals(e))
                {
                    newArray.Add(f);
                    newArray.Add(array[i]);
                    continue;
                }
                newArray.Add(array[i]);
            }
            return newArray;
        }

        //9. Функция дописывает к списку L список E. Оба списка содержат целые числа. В основной программе считать их из файла. 
        static List<int> MergeLists(string firstPath, string secondPath)
        {
            List<int> firstList = File.ReadAllLines(firstPath).Select(x => int.Parse(x)).ToList<int>();
            List<int> secondList = File.ReadAllLines(secondPath).Select(x => int.Parse(x)).ToList<int>();

            List<int> mergedLists = new List<int>();

            for (int i = 0; i < firstList.Count; i++)
                mergedLists.Add(firstList[i]);

            for (int i = 0; i < secondList.Count; i++)
                mergedLists.Add(secondList[i]);

            return mergedLists;
        }

        //10. Функция разбивает список целых чисел на два списка по первому вхождению заданного числа.
        //    Если этого числа в списке нет, второй список будет пустым, а первый не изменится.
        static (List<int>, List<int>) MakeTwoLists(List<int> array, int x)
        {
            List<int> newFirstArray = new List<int>();
            List<int> newSecondArray = new List<int>();

            int dotX = 0;

            for (int i = 0; i < array.Count; i++)
            {
                newFirstArray.Add(array[i]);
                if (array[i].Equals(x))
                {
                    dotX = i;
                    break;
                }
            }

            if (newFirstArray.Count != array.Count)
            {
                for (int i = dotX + 1; i < array.Count; i++)
                {
                    newSecondArray.Add(array[i]);
                }
            }

            return (newFirstArray, newSecondArray);
        }

        //11. Функция удваивает список, т.е. приписывает в конец списка себя самого.
        static List<T> MakeDoubleList<T>(List<T> array)
        {
            List<T> newArray = new List<T>();

            for (int i = 0; i < array.Count; i++)
            {
                newArray.Add(array[i]);
            }
            for (int i = 0; i < array.Count; i++)
            {
                newArray.Add(array[i]);
            }
            return newArray;
        }

        //12. Функция меняет местами два элемента списка, заданные пользователем
        static void SwapElements<T>(this List<T> list, int indexFrom, int indexTo)
        {
            T temp = list[indexFrom];
            list[indexFrom] = list[indexTo];
            list[indexTo] = temp;
        }
    }
}


