using System;

namespace WizardNinjaSamurai{

public class Ninja : Human{
    public Ninja(string name) : base(name){
        dexterity = 175;
    }
    // public Ninja() : base("Ninja", 3, 25, 3, 50){}
    
    public void Steal(object obj){
        Human target = obj as Human;
        if(target == null)
        {
            Console.WriteLine("Failed Attack");
        }
        else
        {
            attack(target);
            health -= 15;
        }
    }
    
    public void steal(){
        health += 10;
    }
    

}
}







