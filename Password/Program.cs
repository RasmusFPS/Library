using System;

namespace Password
{
    internal class Program
    {
        //global arrays for all the functions
        static string[] bookTitles = { "Dune", "Sagan om ringen", "Animal farm", "no longer human", "The setting sun" };
        static int[] Copies = { 2, 3, 1, 4, 2 };
        static int[] Loans = { 0, 1, 0, 0, 0 };
        static int account = -1;

        //keeps track and limits user to only have 5 loans
        static string[,] userLoans = new string[5,5];


        static void Main(string[] args)
        {
            //arrays for usernames and passwords needed for login
            string[] Users = {"Rasmus","Bengt","Olof", "Jens", "CowLord" };
            string[] Passwords = { "1234", "123", "olof", "12345", "LordCow" };

            //added a loan so that i could see the function being used worked
            userLoans[3,3] = "no longer human";

            string user_password;
            int Maxattempts = 3;

            while (true)
            {
                Console.WriteLine("1.Login \n2.Exit");
                var login = Console.ReadLine();

                //choose between exiting the program or to login
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

                //arrays cant be -1 so by setting userindex to -1 we ensure that no bugs happen
                int UserIndex = -1;
                bool Valid = false;

                //until you use a valid username it will loop
                while(!Valid)
                {

                    Console.Write("Enter Username:");
                    string UserInput = Console.ReadLine().ToLower();

                    //checks if the userinput exist within the users array
                    for (int i = 0; i < Users.Length; i++)
                    {
                        if (Users[i].ToLower() == UserInput)
                        {
                            UserIndex = i;
                            account = i;
                            Valid = true;
                            break;
                        }    
                    }

                    if (Valid == false)
                    {
                        Console.WriteLine("No matching username found...");
                        break;
                    }

                }


                bool isloggedin = false;

                //For loop that adds 1 to attempts per failed attempts until its equall to Maxattempts
                for (int attempts = 1; attempts <= Maxattempts; attempts++)
                {
                    Console.Write("Password:");
                    user_password = Console.ReadLine();

                    //Checks if your password is in the password array if so then you login
                    if (user_password == Passwords[UserIndex])
                    {
                        isloggedin = true;
                        break;
                    }
                    else
                    {
                        //this runs if the inputed password dosent corespond with a password in the array
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

                    //this only starts if we have logged in correctly and the bool isloggedin is true
                    while (stayLoggedin)
                    {
                        Console.WriteLine("1. Vissa böcker");
                        Console.WriteLine("2. Låna bok");
                        Console.WriteLine("3. Lämna tillbaka bok");
                        Console.WriteLine("4. Mina Lån");
                        Console.WriteLine("5. Logga ut");

                        string choice = Console.ReadLine();

                        //the number you choose calls a diffrent function that will be called
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

            //goes through my array of books than prints out indexNum, title and copies.
            for (int i = 0; i < bookTitles.Length; i++)
            {
                int availableCopies = Copies[i] - Loans[i];
                Console.WriteLine($"{i + 1}. {bookTitles[i]} | Copies:{availableCopies}");
            }
        }

        static void LoanBook()
        {
            //just call the lib so i dont have to write it again, this is more efficent
            Library();

            Console.WriteLine("Ange numret av boken du vill låna");

            int choice = int.Parse(Console.ReadLine());
            //makes the choice -1 since c# arrays start at 0
            int Index = choice - 1;

            //checks if there are enough copies than creates a empty var so if that remains -1 we will not loan to it
            if (Copies[Index] - Loans[Index] > 0)
            {
                int emptyspot = -1;
                //if it finds a null spot in userLoans than it replaces emptyspot to become i
                for (int i = 0; i < userLoans.Length; i++)
                {
                    if (userLoans[i,account] == null)
                    {
                        emptyspot = i;
                        break;
                    }
                }
                //if emptyspot has changed than we take that number and loan the book with the same index number
                if (emptyspot != -1)
                {
                    userLoans[emptyspot,account] = bookTitles[Index];
                    Loans[Index]++;
                    Console.WriteLine($"du har lånat {bookTitles[Index]}");

                }
                else
                {
                    Console.WriteLine("du kan inte låna mer");

                }
            }
            //this happens if there are no copies of that book
            else
            {
                Console.WriteLine("tyvärr är denna utlånad");

            }
        }

        public static void ReturnBook()
        {
            Console.Clear();
            //once again insted of writing it all again we use that function we made before to efficently show the loans
            ShowLoans();

            Console.Write("Välj numret på boken du vill lämna tillbaka:");

            int choice = int.Parse(Console.ReadLine());
            //makes the choice -1 since c# arrays start at 0
            int LoanIndex = choice - 1;

            //checks if the number we choose - 1, has a book in the array
            if (userLoans[LoanIndex,account] != null)
            {
                //we copie the name of the book and index number to this string
                string BookToReturn = userLoans[LoanIndex,account];

                int BookIndex = -1;
                //go through our books to see if we find a matching from the Booktoreturn string and if we do we change Bookindex to i
                for(int i = 0; i <bookTitles.Length; i++)
                {
                    if (bookTitles[i] == BookToReturn) 
                    { 
                        BookIndex = i; 
                        break; 
                    }
                }
                //removes the book from the Loans array and sets it to null so its empty
                Loans[BookIndex]--;

                userLoans[LoanIndex,account] = null;

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
            //checks if we have any loans and if we do we add +1 to the printed message becuase arrays start at 0
            for (int i = 0; i < Loans.Length; i++)
            {
                if(userLoans[i,account] != null)
                {
                    Console.WriteLine($"{i+1}. {userLoans[i,account]}");
                    hasloan = true;
                }
            }
            //if the bool remains false we dont have any loans and we print that out
            if (hasloan == false)
            {
                Console.WriteLine("du har inga lån!");


            }
        }
    }
}
