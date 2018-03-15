using System;
using DbConnection;

namespace cRuD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // DbConnector.Query("SELECT * FROM Users;");
            CRUD.Read();
            // CRUD.Insert();
        }

    }
}
