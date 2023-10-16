namespace DiceRoller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grand Circus Casino!");
            string want2Continue = "Y";
            do
            {
                Console.Write("How many sides should your dice have?  ");
                string usrNumber = Console.ReadLine();
                if (int.TryParse(usrNumber, out int validNumber))
                {
                    if (validNumber <= 1)
                    {
                        Console.WriteLine("Sorry but, the number of sides should be greater than 1!");
                    }
                    else
                    {
                        int rollCount = 0;
                        string rollAgain = "Y";
                        do
                        {
                            rollCount++;
                            int randomNmbr1 = generateRandomNmbr(validNumber);
                            int randomNmbr2 = generateRandomNmbr(validNumber);
                            int randomTotal = randomNmbr1 + randomNmbr2;   
                            Console.WriteLine($"Roll {rollCount}: ");
                            Console.WriteLine($"You rolled a {randomNmbr1} and a {randomNmbr2} ({randomTotal} total)");
                            string FirstMsg = checkRndNumbers(randomNmbr1, randomNmbr2);
                            if (FirstMsg != "")
                            {
                                Console.WriteLine(FirstMsg);                                
                            }
                            else
                            {
                                string SecondMsg = checkRndTotal(randomTotal);
                                if (SecondMsg != "")                                
                                {
                                    Console.WriteLine(SecondMsg);
                                }
                            }                                                            
                            rollAgain = checkAnswer("Roll again?");
                        }
                        while (rollAgain == "Y");                        
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(usrNumber))
                    {
                        usrNumber = "EmptyValue";
                    }
                    Console.WriteLine($"Sorry, {usrNumber} is not a valid entry for this game!");
                }
                want2Continue = checkAnswer("Do you want to play again?");
            } 
            while (want2Continue == "Y");
            Console.WriteLine("Thanks for playing!!");
        }

        static int generateRandomNmbr(int diceSides)
        {
            Random rnd = new Random();
            return rnd.Next(1, diceSides + 1);
        } // generateRandomNmbr

        static string checkAnswer(string screenMsg)
        {
            bool validAnswer = false;
            string want2Continue = "";
            do
            {
                Console.Write($"{screenMsg} Y/N  ");
                want2Continue = Console.ReadLine();
                if (string.IsNullOrEmpty(want2Continue) || (want2Continue.ToUpper() != "Y" && want2Continue.ToUpper() != "N"))
                {
                    Console.WriteLine("Please enter Y or N as answer.");
                }
                else
                {
                    validAnswer = true;
                    break;
                }
            }
            while (validAnswer == false);
            return want2Continue.ToUpper();
        } // checkAnswer

        static string checkRndNumbers(int rndNumber1, int rndNumber2)
        {
            string displayMsg = "";
            if (rndNumber1 == 1)
            {
                if (rndNumber2 == 1)
                {
                    displayMsg = "Snake Eyes";
                }
                else if (rndNumber2 == 2)
                {
                    displayMsg = "Ace Deuce";
                }
            } // if (rndNumber1 == 1)
            else if (rndNumber1 == 6 && rndNumber2 == 6)
            {
                displayMsg = "Box Cars";
            }
            return displayMsg;
        } // checkRndNumbers

        static string checkRndTotal(int rndTotal)
        {
            string displayMsg = "";
            if (rndTotal == 7 || rndTotal == 11)
            {
                displayMsg = "Win";
            }
            else if (rndTotal == 2 || rndTotal == 3 || rndTotal == 12)
            {
                displayMsg = "Craps";
            }
            return displayMsg;
        } // checkRndTotal
    }
}