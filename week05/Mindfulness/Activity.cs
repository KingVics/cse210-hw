public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    private Spinner spinner = new Spinner();


    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"{_description}");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Well done!!");
        ShowSpinner(4);
        Console.WriteLine();
        Console.WriteLine($"You have compeleted another {_duration} seconds of the {_name} Activity");
        ShowSpinner(5);
    }

    public void ShowSpinner(int seconds)
    {
        int i = 0;
        DateTime startDate = DateTime.Now;
        DateTime endTime = startDate.AddSeconds(seconds);
        List<string> s = spinner.GetSpinner();

        while (DateTime.Now < endTime)
        {
          string spin = s[i];
          Console.Write(spin);
          Thread.Sleep(1000);
          Console.Write("\b \b");

          i++;

          if(i >= s.Count)
            {
                i = 0;
            }
        }
    }


     public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public int GetDuration()
    {
        return _duration;
    }
}
