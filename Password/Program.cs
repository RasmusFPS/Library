using System.ComponentModel;
using System.Dynamic;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Password
{
    internal class Program
    {

        public class Lib
        {
            public string Title { get; set; }
            public int Amount { get; set; }
            public int rentedBooks { get; set; }
            public int avalible => Amount - rentedBooks;

            public override string ToString()
            {
                return $"Title: {Title} Amount: {Amount} Rented {rentedBooks} Avalible: {avalible}";
            }
        }

        static void Library()
        {
            List<Lib> Books = new List<Lib>();

            Books.Add(new Lib { Title = "Harry potter and the philosopher's stone", Amount = 2, rentedBooks = 0, });
            Books.Add(new Lib { Title = "The animal farm", Amount = 1, rentedBooks = 0, });
            Books.Add(new Lib { Title = "C# for fun", Amount = 3, rentedBooks = 2, });
            Books.Add(new Lib { Title = "Lord of the rings", Amount = 5, rentedBooks = 0, });
            Books.Add(new Lib { Title = "Karlsson på taket", Amount = 2, rentedBooks = 2});
            
            foreach (Lib book in Books)
            {
                Console.WriteLine(book);
            }
        }

        static void Main(string[] args)
        {
            string Username = "admin";
            string Password = "admin123";
            string user_password;
            int Maxattempts = 3;

            while (true)
            {
                Console.WriteLine("1.Login \n2.Exit");
                var login = Console.ReadLine();

                switch (login)
                {
                    case "1":
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Exiting....");
                        Thread.Sleep(200);
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid input!");
                        Console.Clear();
                        continue;
                }


                Console.Write("Enter Username:");
                string User_name = Console.ReadLine();

                //Exits the program if (the username is Wrong
                if (Username != User_name)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect Username. Exiting");
                    Thread.Sleep(200);
                    return;
                }

                bool isloggedin = false;

                //For loop that adds 1 to attempts per failed attempts until its equall to Maxattempts
                for (int attempts = 1; attempts <= Maxattempts; attempts++)
                {
                    Console.Write("Password:");
                    user_password = Console.ReadLine();

                    //the input is the == password you get promted that your in
                    if (user_password == Password)
                    {
                        isloggedin = true;
                        break;
                    }
                    else
                    {
                        //this runs if the input was not the password
                        if (attempts < Maxattempts)
                        {
                            Console.WriteLine($"You have {Maxattempts - attempts} attempts left");
                            Thread.Sleep(500);
                            Console.Clear();
                        }
                        //when all of the attempts are used the program closes
                        else
                        {
                            Console.WriteLine("You have no attempts left \nExiting....");
                        }
                    }
                }

                if (isloggedin)
                {
                    bool stayLoggedin = true;
                    while (stayLoggedin)
                    {
                        Console.WriteLine("1. Vissa böcker");
                        Console.WriteLine("2. Låna bok");
                        Console.WriteLine("3. Lämna tillbaka bok");
                        Console.WriteLine("4. Mina Lån");
                        Console.WriteLine("5. Logga ut");

                        string choice = Console.ReadLine();

                        //depending on what number you choose depends what function will be started: NOT FINNISHED
                        switch (choice)
                        {
                            case "1":
                                Library();
                                break;
                            case "2":
                                Console.WriteLine("Vilken bok vill du låna");
                                break;
                            case "3":
                                Console.WriteLine("Vilken bok ska du lämna tillbaka");
                                break;
                            case "4":
                                Console.WriteLine("Dina lån");
                                break;
                            case "5":
                                Console.WriteLine("Loggar ut...");
                                stayLoggedin = false;
                                break;
                            default:
                                Console.WriteLine("Invalid Input\n");
                                Thread.Sleep(400);
                                Console.Clear();
                                break;

                        }
                    }

                }
            }




        }
    }
}
