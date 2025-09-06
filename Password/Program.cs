using System.Runtime.CompilerServices;

namespace Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Username = "admin";
            string Password = "admin123";
            string user_password;
            int Maxattempts = 3;
            bool isloggedin = false;

            Console.Write("Enter Username:");
            string User_name = Console.ReadLine();

            //Exits the program if (the username is Wrong
            if (Username != User_name)
            {
                Console.WriteLine("Incorrect Username. Exiting");
                Thread.Sleep(200);
                return;
            }

            //For loop that adds 1 to attempts per failed attempts until its equall to Maxattempts
            for (int attempts = 1; attempts <= Maxattempts; attempts++)
            {
                Console.Write("Password:");
                user_password = Console.ReadLine();

                //the input is the == password you get promted that your in
                if (user_password == Password)
                {
                    isloggedin = true;

                    while (isloggedin)
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
                                Console.WriteLine("Jk rowling Harry potter");
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
                                return;
                            default:
                                Console.WriteLine("Invalid Input\n");
                                break;

                        }
                    }

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

        }
    }
}
