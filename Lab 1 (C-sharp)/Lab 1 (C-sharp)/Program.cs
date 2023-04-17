using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_1c_sharp
{
    internal class Program
    {
        private static bool canStop;
       
        static void Main(string[] args)
        {
            Console.Write("Введить кiлькiсть потокiв: ");
            String str = Console.ReadLine();
            
            int n = Convert.ToInt32(str);    
            for (int i = 0; i < n; i++)
            {
                (new Thread(calculation)).Start();
            }
            (new Thread(Stoper)).Start();
            Console.ReadKey();
        }

        static void calculation()
        {
            Random r = new Random();
            int num_r = r.Next(1, 10);
            long sum = 0;
            int num_iteration = 0;
            do
            {
                num_iteration++;
                sum += num_r;
            } while (!canStop);
            Console.WriteLine( " ID потокy: " + Thread.CurrentThread.ManagedThreadId + " Кiлькiсть iтерацiй " + num_iteration);
        }
        static void Stoper()
        {
            Thread.Sleep(3*1000);
            canStop = true;
        }
    }
}
