using System.Collections.Generic;
using System;

namespace collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] numArr = {1, 2, 3, 4, 5, 6, 7, 8, 9;
            string[] myNames = {"Tim", "Martin", "Nikki", "Sara"};
            // bool[] TF = {true, false, true, false, true, false, true, false, true, false};
            // System.Console.WriteLine(Multiply(new int[10,10]));

        List<string> flavors= new List<string>();
        flavors.Add("Vanilla");
        flavors.Add("Chocolate");
        flavors.Add("Strawberry");
        flavors.Add("Sherbert");
        flavors.Add("Salted Caramel");

        Console.WriteLine("We currently have {0} icecream flavors.", flavors.Count);
        Console.WriteLine(flavors[3]);
       
        flavors.RemoveAt(3);
        Console.WriteLine("We currently have {0} icecream flavors.", flavors.Count);

        Random rand = new Random();
        Dictionary<string,string> names = new Dictionary<string,string>();
            for(int i=0; i< myNames.Length; i++){
                names.Add(myNames[i], flavors[rand.Next(0,4)]);
                Console.WriteLine(names);
            }
            foreach (KeyValuePair<string,string> entry in names)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }   


        }

        // public static int[,] Multiply(int[,] array2D){
        //     for(int row=0; row<10; row++){
        //         for(int col=0; col<10; col++){
        //             array2D[row,col]= (row+1) * (col+1);
        //         }
        //     }
        //     Console.WriteLine(array2D[9,9]);
        //     return array2D;
        // }


        
        


    }
}
