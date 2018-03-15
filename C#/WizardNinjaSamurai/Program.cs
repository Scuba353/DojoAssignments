using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human1= new Human("Bob");
            Console.WriteLine("Hello World!");
            Ninja someninja= new Ninja("NINJA1");
            Ninja someninja2= new Ninja("NINJA2");
            System.Console.WriteLine(someninja.name);
            someninja.steal();
            System.Console.WriteLine(someninja.dexterity);
            System.Console.WriteLine(someninja.health);
            System.Console.WriteLine(someninja2.health);

        }
    }
}
