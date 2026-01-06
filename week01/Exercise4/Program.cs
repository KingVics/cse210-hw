using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        List<int> numberArray = new List<int>();
        int sum = 0;
        int largest = 0;

        while(number > 0)
        {
            numberArray.Add(number);
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
        }

        foreach (int item in numberArray)
        {
            Console.WriteLine(item);
            if(item > largest)
            {
                largest = item;
            }
            sum += item;
        }

        double avg = sum / numberArray.Count;
        List<int> sortedList = numberArray.OrderBy(x => x).ToList();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine("The sorted list is:");
        foreach (int item in sortedList)
        {
            Console.WriteLine(item);
        }
    }
}