using System;

namespace January2018.CardCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a name for your file");
            CardCatalog cc = new CardCatalog(Console.ReadLine());
            string choice = "";
            do
            {
                Console.WriteLine("Enter a menu option");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. List all books");
                Console.WriteLine("3. Save and exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter a title");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter an author");
                        string author = Console.ReadLine();
                        Console.WriteLine("Enter a genre");
                        string genre = Console.ReadLine();
                        Console.WriteLine("Enter a year");
                        int year = int.Parse(Console.ReadLine());
                        cc.AddBook(title, author, genre, year);
                        break;
                    case "2":
                        cc.ListBooks();
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (choice != "3");
            cc.Save();


        }
    }
}
