using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Casino_Dice_Roller
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, welcome to the Grand Casino. I hope we can cater to your every need.");

            // this while loop especially for if they get the number wrong, or input a non-valid answer
            while (true)
            {
                Console.WriteLine("What sided die would you like to roll today?");
                Console.WriteLine("Our special today is the 6 sided die and the 25 sided die, with custom print!");


                int result = 0;


                // gets the user input and trys to convert it to a int
                try
                {
                    string userinput = Console.ReadLine();
                    result = int.Parse(userinput);

                    
                }
                // catches the letters exception, but doesnt catch a number exception
                catch(FormatException)
                {
                    Console.WriteLine("You input was not a valid number, please try again!");
                    continue;
                }

               

                if (result <=0)
                {
                    Console.WriteLine(" Please input a positive number!");
                    continue;
                }

                // THIS WAS FROM BEFORE THE TRY-CATCH METHOD AND WORKED JUST AS WELL
                //string userinput = Console.ReadLine();
                //int.TryParse(userinput, out int result);


                // loops the program where they get random numbers if they answer y
                    while (true)
                    {
                    // getting the random number
                        int num1 = RandomNumber(result);
                        int num2 = RandomNumber(result);


                    // if die = 6 sided
                        if (result == 6)
                        {
                            DisplayIfSix(num1, num2);
                        }
                        // if die is 25 sided
                        else if (result == 25)
                        {
                            DisplayIfTF(result, num1, num2);
                        }
                        // if die is anything other than 6 or 25 sided
                        else 
                        {
                            DisplayDiceInfo(num1, num2);
                        }
                        // do you want to roll again? 
                        if (RollAgain() == false)
                        {
                            break;
                        }

                        // this writeline is for console formatting purposes
                        Console.WriteLine();
                    }

                break;
            }

        }


        static bool RollAgain()
        {
            Console.WriteLine("Would you like to roll again? Y/N");
            string restart = Console.ReadLine().ToLower();
            if (restart == "y" || restart == "yes")
            {
                return true;
            }
            else if (restart == "n" || restart == "no")
            {
                // ends the program
                Console.WriteLine("Come back another day!");
                return false;
            }
            else
            {
                // runs the program again
                Console.WriteLine(" Im sorry, im not sure what that meant.");
                return RollAgain();
            }

        }

        // gets the users number, enters it as the max, then outputs a number between 1 - usersnumber (+1) because I couldnt fix it
        static int RandomNumber(int usersNumber)
        {
            Random rd = new Random();
            int randNum = rd.Next(1, usersNumber+1);
            return randNum;
        }


        // if the user wanted a six sided die it runs this method
        static void DisplayIfSix( int randNum, int randNum2)
        {
            
            // displays what the user rolled
                Console.WriteLine($" You have rolled a {randNum} and a {randNum2}! Total[{randNum + randNum2}]");


            // special cases where if certain criteria is met, certain prompts are displayed
                if (randNum == 1 && randNum2 == 1)
                {
                    Console.WriteLine("Snake Eyes!!!");
                }
                else if (randNum + randNum2 == 3)
                {
                    Console.WriteLine("Ace Deuce!");

                }
                else if (randNum == 6 && randNum2 == 6)
                {
                    Console.WriteLine("Box Cars!");
                }
                else if (randNum + randNum2 == 7 || randNum + randNum2 == 11)
                {
                    Console.WriteLine("Win!");
                }

                if (randNum + randNum2 == 3 || randNum + randNum2 == 2 || randNum + randNum2 == 12)
                {
                    Console.WriteLine("Craps!");
                }

        }


        

        // If the user rolls a 25 sided die this method runs
        static void DisplayIfTF(int usersNumber, int randNum, int randNum2)
        {
            // displays what the user rolled
            Console.WriteLine($" You have rolled a {randNum} and a {randNum2}! Total[{randNum + randNum2}]");

            // special cases where if certain criteria is met, certain prompts are displayed
                if (randNum == 1 && randNum2 == 1)
                {
                    Console.WriteLine("lowest role ever.");
                }
                else if (randNum + randNum2 == usersNumber * 2)
                {
                    Console.WriteLine(" HIGHEST ROLE EVER YOU WON!!!");
                }
                else if (randNum + randNum == usersNumber)
                {
                    Console.WriteLine("this was pretty mid....");
                }
                else if (randNum + randNum2 == 26)
                {
                    Console.WriteLine("Better than most....");
                }


            // special cases where if certain criteria is met, certain prompts are displayed
                if (randNum + randNum2 < usersNumber)
                {
                    Console.WriteLine("this role sucked");
                }
                else if (randNum + randNum2 == usersNumber)
                {
                    Console.WriteLine("almost there");
                }
                else
                {
                    Console.WriteLine("YOU ARE DOING AMAZING BETTER THAN USUAL!!!!");
                }

        }

        // If the user chooses any number besides 6 or 25, this method is run
        static void DisplayDiceInfo(int randNum, int randNum2)
        {
            
            // tells the users what diced they have rolled 
               Console.WriteLine($" You have rolled a {randNum} and a {randNum2}! Total[{randNum + randNum2}]");

            // one special pair outside of 6 and 25
            if (randNum == randNum2)
            {
               Console.WriteLine("Doubles!");
            }

        }
        
    }
}