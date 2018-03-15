namespace humans
{
    public class Humans{
        public string Name;
        public int Strength = 3;
        public int Intelegence = 3;
        public int Dexterity = 3;
        public int Health = 100;
        
        public Humans(string name){
            Name = name;
        }

        //if Humans not called as a parameter then it needs to be called inside function
        //public void Attack(object obj)
        // Humans enemy = obj as Humans
        // int damage = strength * 5
        // enemy.health -=damage
        
        public void Attack(Humans obj){
            int damage= Strength*5;
            obj.Health -= damage;

        }


    }
}