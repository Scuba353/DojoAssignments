using System;
using System.Collections.Generic;
namespace DeckofCards
{

public class Card
{
    //attributes
    public string cardFace;
    public string cardSuit;
    public int cardVal; 

    //constructor for the individual card 
    public Card(string face, string suit, int val){ 
        cardFace= face;
        cardSuit= suit;
        cardVal= val;
    }
}

public class Deck
{
//attribute- list of card objects    
public List<Card> cards  {get; set; } //= new List<Card>();

List<string> Suits = new List<string> { "Hearts", "Spades", "Diamonds", "Clubs" };
List<string> Faces = new List<string> {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
List<int> Vals= new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};

//Deck Constructor which calls the function to make the cards for the list of card objects 
public Deck(){
    CreateCards();
}

public void CreateCards(){
    //create a new card list
    cards = new List<Card>();
    //Function to create card objects for list
    foreach(string suit in Suits){
        for(var i=0; i<Faces.Count; i++){  
                int currentVal= Vals[i];
                string currentFace= Faces[i];
                //at each itteration a new card object (myCard) is created and then added to the list(cards)
                Card myCard= new Card(currentFace, suit, currentVal);
                cards.Add(myCard);
                Console.WriteLine("This is the {0} of {1} with val {2}", myCard.cardFace, myCard.cardSuit, myCard.cardVal);
        }
    }
}

public Card drawAcard(){
    Card carddrawn = cards[0];
    cards.RemoveAt(0);
    return carddrawn;
    }

public void Shuffle(){
    Random rand= new Random();
    for(int i=0; i<cards.Count; i++){
        int swap = rand.Next(0, cards.Count);
        Card temp = cards[i];
        cards[i]= cards[swap];
        cards[swap] = temp;

    }
}

public void PrintAllCards(){
    foreach(Card c in cards){
        System.Console.WriteLine("This is the {0} of {1} with val {2}",c.cardFace, c.cardSuit, c.cardVal);
    }
}
public void reset(){
    CreateCards();
}
}

public class Player{

    public string Name;
    public List<Card> hand;

public Player(string n){
    Name = n;
    hand = new List<Card>();
}

public Card Discard(int idx){
    if(hand.Count <= idx){
        System.Console.WriteLine("You don't have that many cards");
        return null;
    }
    Card toss = hand[idx];  
    hand.RemoveAt(idx);
    
    return toss;
}

}

}


 




