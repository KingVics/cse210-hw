using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage? ");
        int score = int.Parse(Console.ReadLine());

        string letter;
        if(score >= 90)
        {
            letter = "A";
        }
        else if (score >= 80)
        {
            letter = "B";
        }
        else if(score >= 70)
        {
            letter = "C";
        }
        else if(score >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
    
      
        string sign = lastDigit(score, letter);

        Console.WriteLine($"{letter}{sign}");
        if(score > 70)
        {
            Console.WriteLine("Congratulations!! You passed the course");
        }
        else
        {
            Console.WriteLine("You fail the course, but We recognized your effort. Try harder next time");
  
        }
    }

      static string lastDigit(int number, string letter)
    {
        int last  = number % 10;

        if(last >= 7 && letter != "A" && letter != "F") return "+";
        else if(last < 3 && letter != "F") return "-";
        return "";
    }
}