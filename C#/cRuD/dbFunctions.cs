using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using DbConnection;

namespace cRuD
{

public class CRUD{
    public static void Read(){
        DbConnector.Query("SELECT * FROM Users;");  
        foreach(Dictionary<string, object> dict in DbConnector.Query("SELECT * FROM Users;")){
            foreach(KeyValuePair<string, object> data in dict){
                System.Console.WriteLine(data.Key);
                if (data.Value is string){
                    System.Console.WriteLine(data.Value as string);
                }
                if (data.Value is int){
                    System.Console.WriteLine(data.Value.ToString());
                }
            }
        }
    }

    public static void Insert(){
        System.Console.WriteLine("Please provide your First Name");
        string FirstName = Console.ReadLine();
        System.Console.WriteLine("Please provide your Last Name");
        string LastName = Console.ReadLine();
        System.Console.WriteLine("What is your favorite number?");
        string FavoriteNumber = Console.ReadLine();
        int numero= Int32.Parse(FavoriteNumber);
        string querystring= "INSERT INTO Users (FirstName, LastName, FavoriteNumber) VALUES ('" +FirstName+ "', '" +LastName+ "', " +numero+ ");";
        // DbConnector.Execute("INSERT INTO Users (FirstName, LastName, FavoriteNumber) VALUES ('{0}', '{1}', {2})", FirstName, LastName, numero);
        System.Console.WriteLine(querystring);
        DbConnector.Execute(querystring);
    }



}
}
