using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> objects = new List<object>();
            objects.Add(7);
            objects.Add(28);
            objects.Add(-1);
            objects.Add(true);
            objects.Add("chair");

            foreach(var o in objects){
                Console.WriteLine(o);
            }

            int sum = 0;
            foreach(var o in objects){
                if(o is int){
                    sum= sum + (int)o;
                }
            }
            // return sum;
            Console.WriteLine(sum);
        }
    }
}
