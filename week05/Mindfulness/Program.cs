using System;
using System.Collections.Generic;
using System.IO;

// Added extra requirement by Keeping a log of how many times activities were performed.
// And persiting the log

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;
        string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        string logPath = Path.Combine(projectRoot, "activity_log.txt");

        if (File.Exists(logPath))
        {
            string[] lines = File.ReadAllLines(logPath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('=', 2);
                if (parts.Length != 2)
                {
                    continue;
                }

                string key = parts[0].Trim();
                string value = parts[1].Trim();
                if (!int.TryParse(value, out int count))
                {
                    continue;
                }

                if (key.Equals("Breathing", StringComparison.OrdinalIgnoreCase))
                {
                    breathingCount = count;
                }
                else if (key.Equals("Reflecting", StringComparison.OrdinalIgnoreCase))
                {
                    reflectingCount = count;
                }
                else if (key.Equals("Listing", StringComparison.OrdinalIgnoreCase))
                {
                    listingCount = count;
                }
            }
        }
        while (choice != 4)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. View activity log");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice, try again");
                Console.WriteLine();
                continue;
            }

            bool ranActivity = false;
            switch (choice)
            {
                case 1:
                    Breathing breathing = new Breathing(
                        "Breathing",
                        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
                        );
                    breathing.DisplayStartingMessage();

                    Console.Write("How long in seconds would you like this session? ");
                    if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
                    {
                        breathing.SetDuration(duration);
                        breathing.Run();
                        breathingCount++;
                        ranActivity = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a positive number.");
                    }
                    break;
                case 2:
                    Prompts prompts = new Prompts();
                    List<string> questions =  prompts.GetQuestion();
                    List<string> prompt =  prompts.GetPrompts();
                    Reflecting reflecting = new Reflecting(prompt, questions, "Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                    
                    reflecting.DisplayStartingMessage();
                    Console.WriteLine();
                    Console.Write("How long in seconds would you like this session? ");
                    if (int.TryParse(Console.ReadLine(), out int duration2) && duration2 > 0)
                    {
                        reflecting.SetDuration(duration2);
                        reflecting.Run();
                        reflectingCount++;
                        ranActivity = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a positive number.");
                    }
                    break;
                case 3:
                    Prompts listPrompts = new Prompts();
                    List<string> list =  listPrompts.GetList();

                    Listing listing = new Listing(list, 3, "Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                    listing.DisplayStartingMessage();
                    Console.WriteLine();
                    Console.Write("How long in seconds would you like this session? ");

                    if (int.TryParse(Console.ReadLine(), out int duration3) && duration3 > 0)
                    {
                        listing.SetDuration(duration3);
                        listing.Run();
                        listingCount++;
                        ranActivity = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a positive number.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Activity log:");
                    Console.WriteLine($"Breathing: {breathingCount}");
                    Console.WriteLine($"Reflecting: {reflectingCount}");
                    Console.WriteLine($"Listing: {listingCount}");
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;
                 case 5:
                    Console.WriteLine("Thank you");
                    Console.WriteLine();
                    Console.WriteLine("Activity log:");
                    Console.WriteLine($"Breathing: {breathingCount}");
                    Console.WriteLine($"Reflecting: {reflectingCount}");
                    Console.WriteLine($"Listing: {listingCount}");

                    string[] output =
                    {
                        $"Breathing={breathingCount}",
                        $"Reflecting={reflectingCount}",
                        $"Listing={listingCount}"
                    };
                    File.WriteAllLines(logPath, output);
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again");
                    break;
            }
            if (ranActivity)
            {
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
            Console.WriteLine();
        }
    }
}
