using System;

namespace first_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
        // for (int i=1; i<256; i++)
        // {
        //     Console.WriteLine(i);
        // }

        // for(int j=1; j<100; j++){
        //     if(j%3 <1 || j%5 <1){
        //         Console.WriteLine(j);
        //     }
        //     else if(j%3 <1 && j%5 <1){
        //         continue;
        //     }
        // }
        for(int j=1; j<100; j++){
            if(j%3 <1){
                 Console.WriteLine("Fizz");
            }
            if(j%5 <1){
                Console.WriteLine("Buzz");
            }
            if(j%3 <1 && j%5 <1){
                Console.WriteLine("FizzBuzz");
            }
        }
        
        }
    }
}
