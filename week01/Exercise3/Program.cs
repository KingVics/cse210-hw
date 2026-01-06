using System;

class Program
{
    static void Main(string[] args)
    {
        
        Random rnd = new Random();
        int number = rnd.Next(1, 101);
        int guesses = 0;
        string startWord = "yes";

        while (startWord.ToLower() == "yes")
        {
            Console.Write("What is the guess number? ");
            int guessNumber = int.Parse(Console.ReadLine());
            guesses += 1;

            if(guessNumber > number)
            {
                Console.WriteLine("Higher");
            } 
            else if(guessNumber < number)
            {
                Console.WriteLine("Lower"); 
            } 
            else
            {
               Console.WriteLine("You guessed it!"); 
               Console.WriteLine($"It took you {guesses} to get the magic number"); 
               Console.Write("Do you want to play again? Enter Yes/No");
               startWord = Console.ReadLine();

               if(startWord.ToLower() == "yes")
                {
                    number = rnd.Next(1, 101);
                    guesses = 0;
                }
            }
        }
    }
}