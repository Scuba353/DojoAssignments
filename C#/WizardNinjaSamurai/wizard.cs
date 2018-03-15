using System;

namespace WizardNinjaSamurai{

public class Wizard : Human{
    public Wizard(string name) : base(name){
        health = 50;
        intelligence= 25;
    }
    public void fireball(object obj){
        Human target = obj as Human;
        Random rand = new Random();
        if(target == null)
        {
            Console.WriteLine("Failed Attack");
        }
        else
        {
            attack(target);
            health -= rand.Next(20,50);
        }
    }

    public void heal(){
        intelligence += 10;
    }
}
}