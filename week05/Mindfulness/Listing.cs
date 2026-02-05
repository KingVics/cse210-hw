using System;
using System.Collections.Generic;

public class Listing : Activity
{
    private int _count;

    private List<string> _prompts;


    public Listing(List<string> prompt, int count, string name, string description) : base(name, description)
    {
        _count = count;
        _prompts = prompt;
    }

    public string GetRandomPrompt()
    {
        Random rand  = new Random();
        int index = rand.Next(_prompts.Count);
        string reflection = _prompts[index];

        return reflection;
    }


    public void ListingActivity()
    {
        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
    }

    
    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(entry))
            {
                items.Add(entry);
            }
        }

        _count = items.Count;
        return items;
    }
       

    public void Run()
    {
        Console.WriteLine();
        Console.Write("Get ready...");
        ShowSpinner(5);

        ListingActivity();

        Console.Write("You may begin in: ");
        int remaining = GetDuration();
        int start = Math.Min(4, remaining);
        ShowCountDown(start);
        GetListFromUser();
        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }

}
