using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dz22
{
    class Program
    {



        static void Main(string[] args)
        {
            Console.WriteLine("введите размер массива");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, n);
            }
            foreach (var element in array)
            {
                Console.Write(element + " ");
            }
            Task<int> task1 = new Task<int>(() => Sum(array));
            task1.Start();
            Console.WriteLine($"\nсумма массива равна {task1.Result}");
            Task<int> task2 = task1.ContinueWith(S => Maximum(array));
            Console.WriteLine($"\nмаксимальное значение массива равно {task2.Result}");
            task2.Wait();
            Console.WriteLine("End of Main");
            Console.ReadKey();
        }
        static int Sum(int[] array)
        {
            Console.WriteLine("\nметод сумма начал работать");
            int S = 0;
            for (int i = 0; i < array.Length; i++)
            {
                S += array[i];
                Thread.Sleep(300);
            }
            Console.WriteLine("\nметод сумма завершил работу");
            return S;
        }
        static int Maximum(int[] array)
        {
            Console.WriteLine("\nметод максимум начал работать");
            int Max = array[0];
            for (int i = 1; i < array.Length; i++)
            {

                if (array[i] > Max)
                {
                    Max = array[i];
                    Thread.Sleep(100);
                }
            }
            Console.WriteLine("\nметод максимум завершил");
            return Max;
        }
    }
}
