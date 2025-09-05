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

            Console.WriteLine("Enter Username: ");
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
                Console.WriteLine("Password:");
                user_password = Console.ReadLine();

                //the input is the == password you get promted that your in
                if (user_password == Password)
                {
                    Console.WriteLine("You are in");
                    Thread.Sleep(200);
                    return;
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
