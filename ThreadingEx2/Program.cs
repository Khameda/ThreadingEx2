using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using ThreadingEx2;

namespace FindSmallest
{
    internal class Program
    {

    Generator _generator = new Generator();
    {
      
    }
    
  

        private static readonly int[][] Data = new int[][]
        {
            new[] {1, 5, 4, 2},
            new[] {3, 2, 4, 11, 4},
            new[] {33, 2, 3, -1, 10},
            new[] {3, 2, 8, 9, -1},
            new[] {1, 22, 1, 9, -3, 5}
            
        };


        private static int FindSmallest(int[] numbers)
        {
            if (numbers.Length < 1)
            {
                throw new ArgumentException("There must be at least one element in the array");
            }

            int smallestSoFar = numbers[0];
            foreach (int number in numbers)
            {
                if (number < smallestSoFar)
                {
                    smallestSoFar = number;
                }
            }
            return smallestSoFar;
        }

        private static int FindLargest(int[] numbers)
        {
            if (numbers.Length < 1)
            {
                throw new ArgumentException("There must be at least one element in the array");
            }

            int largestSoFar = numbers[0];
            foreach (int number in numbers)
            {
                if (number > largestSoFar)
                {
                    largestSoFar = number;
                }
                
            }
            return largestSoFar;
        }

        private static void Main()
        {
         
            List<Task<int>> Liste = new List<Task<int>>();


            foreach (int[] littled in Data)
            {
                Task<int> minTredjeOpg = new Task<int>(() =>
                {
                    int smallest = FindSmallest(littled);
                    Console.WriteLine(smallest);
                    return smallest;

                }
                    );
                minTredjeOpg.Start();
                Liste.Add(minTredjeOpg);
                //Thread t1 = new Thread(() =>
                //{

                //    int smallest = FindSmallest(littled);

                //    Console.WriteLine(smallest);
                //    // Console.WriteLine("\t" + String.Join(", ", littled) + "\n-> " + smallest);



                //t1.Start();
                // Console.ReadLine();

            }
            foreach (int[] biggerd in Data)
            {
                Task<int> minFjerdeOpg = new Task<int>(() =>
                {
                    int largest = FindLargest(biggerd);
                    Console.WriteLine(largest);
                    return largest;
                }
                );
                minFjerdeOpg.Start();
                
                Liste.Add(minFjerdeOpg);
            }

            Task.WaitAll(Liste.ToArray());
           
        }
    }
}
