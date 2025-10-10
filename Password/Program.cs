using System;

namespace Password
{
    internal class Program
    {
        static string[] bookTitles = { "Dune", "Sagan om ringen", "Animal farm", "no longer human", "The setting sun" };
        static int[] Copies = { 2, 3, 1, 4, 2 };
        static int[] Loans = { 0, 1, 0, 0, 0 };

        static string[] userLoans = new string[5];


        static void Main(string[] args)
        {
            string[] Users = {"Rasmus","Bengt","Olof", "Jens", "CowLord" };
            string[] Passwords = { "1234", "123", "olof","12345","LordCow" };

            userLoans[3] = "no longer human";

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

                int UserIndex = -1;

                Console.Write("Enter Username:");
                string UserInput = Console.ReadLine();

                for(int i = 0; i < Users.Length; i++)
                {
                    if (Users[i] == UserInput)
                    {
                        UserIndex = i;
                        break;
                    }
                }

                if(UserIndex == -1)
                {
                    Console.WriteLine("No matching username found...");
                    break;
                }

                bool isloggedin = false;

                //For loop that adds 1 to attempts per failed attempts until its equall to Maxattempts
                for (int attempts = 1; attempts <= Maxattempts; attempts++)
                {
                    Console.Write("Password:");
                    user_password = Console.ReadLine();

                    //the input is the == password you get promted that your in
                    if (user_password == Passwords[UserIndex])
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
                            return;
                        }
                    }
                }

                if (isloggedin)
                {
                    Console.Clear();
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
                                Console.Clear();
                                Library();
                                Console.WriteLine("Tryck enter för att återgå till huvudmenyn");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "2":
                                Console.WriteLine("Vilken bok vill du låna");
                                LoanBook();
                                Console.WriteLine("Tryck enter för att återgå till huvudmenyn");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "3":
                                Console.WriteLine("Vilken bok ska du lämna tillbaka");
                                ReturnBook();
                                Console.WriteLine("Tryck enter för att återgå till huvudmenyn");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case "4":
                                Console.WriteLine("Dina lån");
                                ShowLoans();
                                Console.WriteLine("Tryck enter för att återgå till huvudmenyn");
                                Console.ReadLine();
                                Console.Clear();
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
        static void Library()
        {
            Console.Clear();

            Console.WriteLine("Bibliotekets böcker");

            for (int i = 0; i < bookTitles.Length; i++)
            {
                int availableCopies = Copies[i] - Loans[i];
                Console.WriteLine($"{i + 1}. {bookTitles[i]}  Copies:{availableCopies}");
            }
        }

        static void LoanBook()
        {
            Library();

            Console.WriteLine("Ange numret av boken du vill låna");

            int choice = int.Parse(Console.ReadLine());
            int Index = choice - 1;

            if (Copies[Index] - Loans[Index] > 0)
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
                    userLoans[emptyspot] = bookTitles[Index];
                    Loans[Index]++;
                    Console.WriteLine($"du har lånat {bookTitles[Index]}");

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

        public static void ReturnBook()
        {
            Console.Clear();
            ShowLoans();

            Console.Write("Välj numret på boken du vill lämna tillbaka:");

            int choice = int.Parse(Console.ReadLine());
            int LoanIndex = choice - 1;

            if (userLoans[LoanIndex] != null)
            {
                string BookToReturn = userLoans[LoanIndex];

                int BookIndex = -1;
                for(int i = 0; i <bookTitles.Length; i++)
                {
                    if (bookTitles[i] == BookToReturn) 
                    { 
                        BookIndex = i; 
                        break; 
                    }
                }

                Loans[BookIndex]--;

                userLoans[LoanIndex] = null;

                Console.WriteLine($"Du har lämnat tillbaka {BookToReturn}");
            }
            else
            {
                Console.WriteLine("Du har ingen bok på den platsen");

            }

        }

        static void ShowLoans()
        {
            bool hasloan = false;

            for (int i = 0; i < Loans.Length; i++)
            {
                if(userLoans[i] != null)
                {
                    Console.WriteLine($"{i+1}. {userLoans[i]}");
                    hasloan = true;
                }
            }

            if (hasloan == false)
            {
                Console.WriteLine("du har inga lån!");


            }
        }
    }
}
