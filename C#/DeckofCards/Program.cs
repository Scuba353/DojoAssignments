using System;

namespace DeckofCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Deck newDeck = new Deck();
            newDeck.Shuffle();
            newDeck.PrintAllCards();
            //stores card drawn as a variable so that it acn be passed elsewhere
            Card drawn = newDeck.drawAcard();
            Player allyse= new Player("Allyse");
            allyse.hand.Add(drawn);
            
            allyse.Discard(0);

            newDeck.reset();
          
            
            

        }
    }
}
