using System;

namespace group_project
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(Sigma(6));
            System.Console.WriteLine(Add2(new int[] {1,2,3,4}));
            System.Console.WriteLine(IsItNegative(new int[]{-1,3,-7,5}));

        }
        static public int Sigma(int val)
        {
            int sum = 0;
            for (int i=1; i<= val; i++)
            {
                sum += i;
            }
            return sum;
        }
        static public int[] Add2(int[] myArr)
        {
            for (int i = 0; i<myArr.Length; i++)
            {
                myArr[i] += 2;
            }
            return myArr;
        }
        static public int[] IsItNegative(int[] arr)
        {
            object[] newList = new object[arr.Length];
            for (int i=0; i<arr.Length;i++)
            {
                if (arr[i] < 0)
                {
                    newList[i] = "Dojo";
                }
                else
                {
                   newList[i] = arr[i];
                }
            }
            return arr;
        }

    }
}
