using System;

namespace humans
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Humans human1= new Humans("Allyse");
            Console.WriteLine(human1.Name);
            Humans human2= new Humans("Ruben");
            Console.WriteLine(human2.Health);
            Humans human3= new Humans("Mags");
            Humans human4= new Humans("Brian");
            human1.Attack(human2);
            Console.WriteLine(human2.Health);

        }
    }
}
