using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var mtVernonHome = from artist in Artists where artist.Hometown == "Mount Vernon" select artist;
            System.Console.WriteLine(mtVernonHome);

            //Who is the youngest artist in our collection of artists?
            string youngest = Artists.OrderBy(a => a.Age).First().ArtistName;
            System.Console.WriteLine(youngest);
            // var youngest = from art in Artists orderby art.Age select art;
            // System.Console.WriteLine(youngest); 

            //Display all artists with 'William' somewhere in their real name
            IEnumerable<Artist> realWiliams = Artists.Where(artist => artist.RealName.Contains("William"));
            foreach(Artist a in realWiliams){
                System.Console.WriteLine(a.RealName);
            }
            //Display the 3 oldest artist from Atlanta
            IEnumerable<Artist> atlantaDudes = Artists.OrderByDescending(a => a.Age).Where(artist => artist.Hometown == "Atlanta").Take(3);
            foreach(Artist b in atlantaDudes){
                System.Console.WriteLine(b.ArtistName);
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
