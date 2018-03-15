using System;

namespace WizardNinjaSamurai{

public class Samurai : Human{
    public Samurai(string name) : base(name){
        health = 200;
  
    }
    public void dealthblow(object obj){
        Human target = obj as Human;
        if(target == null)
        {
            Console.WriteLine("Failed Attack");
        }
        if(target.health<50)
        {
            attack(target);
            target.health = 0;
        }
    }

    public void meditate(){
        health = 200;
    }
}
}