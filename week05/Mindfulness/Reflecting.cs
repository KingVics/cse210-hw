public class Reflecting : Activity
{
    private List<string> _prompts;

    private List<string> _questions;

    public Reflecting(List<string> prompt, List<string> question, string name, string description) : base(name, description)
    {
        _prompts = prompt;
        _questions = question;
    }


    public string GetRandomPrompt()
    {
        Random rand  = new Random();
        int index = rand.Next(_prompts.Count);
        string reflection = _prompts[index];

        return reflection;
    }


    public string GetRandomQuestion()
    {
        Random rand  = new Random();
        int index = rand.Next(_questions.Count);
        string reflection = _questions[index];

        return reflection;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"---- {GetRandomPrompt()} ----");
    }

    public void DisplayQuestions()
    {
        Console.Write($"> {GetRandomQuestion()} ");
    }


    public void ReflectingActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        DisplayPrompt();
        Console.WriteLine();  
    }




    public void Run()
    {
        Console.WriteLine();
        Console.Write("Get ready...");
        ShowSpinner(5);
        ReflectingActivity();
        Console.WriteLine("When you have something in mind, press enter to continue");
        ConsoleKeyInfo choice = Console.ReadKey();

        if (choice.Key == ConsoleKey.Enter)
        {
            Console.WriteLine("Now ponder on each of the following questions as they related to the experience.");
            Console.Write("You may begin in... ");

            int remaining = GetDuration();
           
            int inhale = Math.Min(4, remaining);
            ShowCountDown(inhale);

            Console.Clear();
            while (remaining > 0)
            {
                DisplayQuestions();
                int exhale = Math.Min(10, remaining);
                ShowSpinner(exhale);
                Console.WriteLine();

                if (remaining <= 0)
                {
                    break;
                }

                remaining -= exhale;

            }

            Console.WriteLine();
            DisplayEndingMessage();


        }
    }

}