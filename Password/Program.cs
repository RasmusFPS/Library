using System.ComponentModel;
using System.Dynamic;
using System.Numerics;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Password
{
    internal class Program
    {
        static string[] bookTitles = { "Harry potter", "Sagan om ringen", "Animal farm", "no longer human", "The setting sun" };
        static int[] Copies = { 2, 3, 1, 4, 2 };
        static int[] Loans = { 0, 1, 0, 0, 0 };

        static string[] userLoans = new string[5];

        static void Library()
        {
            Console.Clear();

            Console.WriteLine("--- Bibliotekets böcker ---");

            for (int i = 0; i < bookTitles.Length; i++)
            {
                int availableCopies = Copies[i] - Loans[i];
                Console.WriteLine($"{i+1}. {bookTitles[i]}");
            }

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();
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
                string UserInput = Console.ReadLine();

                //Exits the program if (the username is Wrong
                if (Username != UserInput)
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
                                LoanBook();
                                Console.ReadLine();
                                break;
                            case "3":
                                Console.WriteLine("Vilken bok ska du lämna tillbaka");
                                Console.ReadLine();
                                break;
                            case "4":
                                Console.WriteLine("Dina lån");
                                Console.ReadLine();
                                break;
                            case "5":
                                Console.WriteLine("Loggar ut...");
                                stayLoggedin = false;
                                break;
                            default:
                                Console.WriteLine("Invalid Input\n");
                                Console.ReadLine();
                                Thread.Sleep(400);
                                Console.Clear();
                                break;

                        }
                    }

                }
            }


        }

        static void LoanBook()
        {
            Library();

            Console.WriteLine("Ange numret av boken du vill låna");

            int choice = Convert.ToInt32(Console.ReadLine());
            int bookIndex = choice - 1;

            if (Copies[bookIndex] - Loans[bookIndex] > 0)
            {
                int emptyspot = -1;

                for (int i = 0; i < userLoans.Length; i++)
                {
                    if (userLoans[i] == null)
                    {
                        emptyspot = i;
                        break;
                    }
                }

                if (emptyspot != -1)
                {
                    userLoans[emptyspot] = bookTitles[bookIndex];
                    Loans[bookIndex]++;
                    Console.WriteLine($"du har lånat {bookTitles[bookIndex]}");
                }
                else
                {
                    Console.WriteLine("du kan inte låna mer");
                }
            }
            else
            {
                Console.WriteLine("tyvärr är denna utlånad");
            }
        }
    }
}
