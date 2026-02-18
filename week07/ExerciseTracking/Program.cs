using System;

class Program
{
    static void Main(string[] args)
    {

        List<Activity> activities = new List<Activity>();

        Swimming swimming = new Swimming(20, 10, "Swimming");

        Running running = new Running(20.5, 40, "Running");

        Cycling cycling = new Cycling(20.5, 35, "Cycling");

        activities.Add(swimming);
        activities.Add(running);
        activities.Add(cycling);


        for (int i = 0; i < activities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {activities[i].GetSummary()}");
        
        }


    }
}
