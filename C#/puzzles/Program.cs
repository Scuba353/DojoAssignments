using System;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // System.Console.WriteLine(RandomArr());
            // System.Console.WriteLine(CoinToss());
            // System.Console.WriteLine(TossMultipleCoins(5));
        
            string[] array = { "Todd", "Tiffany", "Charlie", "Geneva", "Sydney" };
            Shuffle(array);
            foreach (string value in array)
            {
                Console.WriteLine(value);
            }
            foreach(string value in array){
                if(value.Length<5){
                    continue;
                }
                else{
                    Console.WriteLine(value);
                }
            }
            


        }

    // Random Array
    // public static int[] RandomArr(){
    //     Random rand = new Random();
    //     int[] Arr= new int[10];
    //     int sum= 0;
    //     int max= 0;
    //     int min=0;
    //     for(int i=0; i<=9; i++){
    //         int r= rand.Next(5,25);
    //         Arr[i]= r;
    //         sum= sum + r;
    //         if(r > max){
    //             max = r;
    //         }
    //         if(r < min){
    //             min = r;
    //         }
    //     }
    //     int[] results= {max, min, sum};
    //     return results; 
    // }

    // Coin Toss
    // public static string CoinToss(){
    //     Random rand = new Random();
    //     Console.WriteLine("I'm tossing a coin!");
    //     int r= rand.Next(-1, 1);
    //     if(r >= 0){
    //         Console.WriteLine("Heads");
    //         return "Heads";
    //     }
    //     else{
    //         Console.WriteLine("Tails");
    //         return "Tails";
    //     }
    // }

    // public static double TossMultipleCoins(int num){ 
    //     int count= 0;
    //     for(var i=0; i<=num; i++){
    //         var temp= CoinToss();
    //         if(temp == "Heads"){
    //             count ++; 
    //             Console.WriteLine(count);
    //         }
    //         else{
    //             continue;
    //         }  
    //     }
    //     Console.WriteLine(num);
    //     // int avg = count/num;
    //     // double ratio= avg;
    //     return avg;
    // }

    // Names
//Fisher Yates Shuffle
    // <typeparam name="T">Array element type
    // <param name="array">Array to shuffle
    public static void Shuffle<T>(T[] array){
        int len= array.Length;
        Random rand = new Random();
        for(int i=0; i<len; i++){
            int r = i + rand.Next(len - i);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
    }
}
