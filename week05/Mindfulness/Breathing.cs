using System;
using System.Threading;

public class Breathing : Activity
{

    public Breathing(string name, string description) : base(name, description)
    {
    }
    
    public void Run()
    {
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();

        int remaining = GetDuration();
        while (remaining > 0)
        {
            Console.Write("Breathe in... ");
            int inhale = Math.Min(4, remaining);
            ShowCountDown(inhale);
            remaining -= inhale;

            if (remaining <= 0)
            {
                break;
            }

            Console.Write("Breathe out... ");
            int exhale = Math.Min(4, remaining);
            ShowCountDown(exhale);
            remaining -= exhale;
        }

        Console.WriteLine();
        DisplayEndingMessage();
    }

}
