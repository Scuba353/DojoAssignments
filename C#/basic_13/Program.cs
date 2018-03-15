using System;

namespace basic_13
{
    class Program
    {
        static void Main(string[] args)
        {
            // print1_255();
            // printodd1_255();
            // int_sum();
            // IttArr(new int[] {1, 3, 5, 7, 9});
            // System.Console.WriteLine(MaxArr(new int[] {-1,-3,-7}));
            // System.Console.WriteLine(AvgArr(new int[] {2, 10, 3}));
            // System.Console.WriteLine(oddArr());
            // System.Console.WriteLine(GreaterThan(new int[] {1, 3, 5, 7}, 3));
            // System.Console.WriteLine(square(new int[] {1, 5, 10, -2}));
            // System.Console.WriteLine(noNegs(new int[] {1, 5, 10, -2}));
            // System.Console.WriteLine(MaxMinAvg(new int[] {1, 5, 10, -2}));
            System.Console.WriteLine(shift(new int[] {1, 5, 10, -2}));
            // System.Console.WriteLine(IsItNegative(new int[]{-1,3,-7,5}));







        }
        // static public void print1_255()
        // {
        //     for (int i=1; i<= 255; i++)
        //     {
        //         Console.WriteLine(i);
        //     }
        // }

        // static public void printodd1_255()
        // {
        //     for (int i=1; i<= 255; i=i+2)
        //     {
        //         Console.WriteLine(i);
        //     }   
        // }

        // static public void int_sum()
        // {
        //     int sum = 0;
        //     for (int i=1; i<= 50; i++)
        //     {
        //         sum= sum + i;
        //         Console.WriteLine("The int is "+ i + " and the sum is "+ sum);
        //     }
        // }

        // static public void IttArr(int[] myArr)
        // {
        //     for (int i = 0; i<myArr.Length; i++)
        //     {
        //         Console.WriteLine(myArr[i]);
        //     }
        // }

        // static public int MaxArr(int[] myArr)
        // {
        //     int max= myArr[0];
        //     for (int i = 1; i<myArr.Length; i++)
        //     {
        //         if(myArr[i]>max){
        //             max=myArr[i];
        //         }
        //     }
        //     return max;
        // }

        // static public int AvgArr(int[] myArr)
        // {
        //     int sum= 0;
        //     for (int i = 0; i<myArr.Length; i++)
        //     {
        //         sum += myArr[i];
        //     }
        //     return sum/(myArr.Length);
        // }

        // static public int[] oddArr()
        // {
        //     int[] y = new int[128];
        //     int count= 0;
        //     for (int i = 1; i<256; i= i+2)
        //     {
        //         y[count]= i;
        //         count ++;
        //     }
        //     return y;
        // }

        // static public int GreaterThan(int[] myArr, int val)
        // {
        //     int count = 0;
        //     for (int i = 0; i<myArr.Length; i++)
        //     {
        //         if(myArr[i]>val){
        //             count ++;
        //         }
        //     }
        //     return count;
        // }

        // static public int[] square(int[] myArr)
        // {
        //     for (int i = 0; i<myArr.Length; i++)
        //     {
        //         myArr[i] = myArr[i]* myArr[i];
        //     }
        //     return myArr;
        // }

        // static public int[] noNegs(int[] myArr)
        // {
        //     for (int i = 0; i<myArr.Length; i++)
        //     {
        //         if(myArr[i]<0){
        //             myArr[i]=0;
        //         }
        //     }
        //     return myArr;
        // }

        // static public int[] MaxMinAvg(int[] myArr)
        // {
        //     int max= myArr[0];
        //     int min= myArr[0];
        //     int sum= 0;
        //     for (int i = 1; i<myArr.Length; i++)
        //     {
        //         sum= sum + myArr[i];
        //         if(myArr[i] > max){
        //             max=myArr[i];
        //         }
        //         if(myArr[i] < min){
        //             min=myArr[i];
        //         }
        //     }
        //     int[] results= {max, min, (sum/myArr.Length)};
        //     return results;
        // }

        static public int[] shift(int[] myArr)
        {
            for (int i = 0; i<myArr.Length-1; i++)
            {
                int temp= myArr[i];
                myArr[i] = myArr[i+1];
            }
            int last = myArr.Length -1;
            last= 0;
            return myArr;
        }

        // static public int[] IsItNegative(int[] arr)
        // {
        //     object[] newList = new object[arr.Length];
        //     for (int i=0; i<arr.Length;i++)
        //     {
        //         if (arr[i] < 0)
        //         {
        //             newList[i] = "Dojo";
        //         }
        //         else
        //         {
        //            newList[i] = arr[i];
        //         }
        //     }
        //     return arr;
        // }









    }
}
