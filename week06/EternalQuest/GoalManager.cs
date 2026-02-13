public class GoalManager
{
    private readonly List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _eventsRecorded = 0;

    private const int MilestoneInterval = 5;
    private const int MilestoneBonus = 250;

    public GoalManager()
    {
    }


    public void Start()
    {
        bool keepRunning = true;
        while (keepRunning)
        {
            DisplayPlayerInfo();
            Menu.Show();
            Console.Write("Select a choice from the list: ");
            string input = Console.ReadLine() ?? "";

            Console.WriteLine();
            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level: {GetLevel()} ({GetTitle()})");
        Console.WriteLine($"Points to next level: {GetPointsToNextLevel()}");
        Console.WriteLine();
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }


    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("Your Goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Enter 'b' at any prompt to return to the main menu.");
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");
        string typeChoice = ReadTextOrBack("Which type of goal would you like to create? ");
        if (typeChoice == null)
        {
            return;
        }

        string name = ReadTextOrBack("What is the name of your goal? ");
        if (name == null)
        {
            return;
        }

        string description = ReadTextOrBack("What is a short description of it? ");
        if (description == null)
        {
            return;
        }

        int? points = ReadIntOrBack("What is the amount of points associated with this goal? ");
        if (!points.HasValue)
        {
            return;
        }

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points.Value));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points.Value));
                break;
            case "3":
                int? target = ReadIntOrBack("How many times does this goal need to be accomplished for a bonus? ");
                if (!target.HasValue)
                {
                    return;
                }

                int? bonus = ReadIntOrBack("What is the bonus for accomplishing it that many times? ");
                if (!bonus.HasValue)
                {
                    return;
                }

                _goals.Add(new ChecklistGoal(name, description, points.Value, target.Value, bonus.Value));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points.Value));
                break;
            default:
                Console.WriteLine("Invalid goal type. Goal not created.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("Enter 'b' to return to the main menu.");
        Console.WriteLine("The goals are:");
        ListGoalNames();
        int? goalNumber = ReadIntOrBack("Which goal did you accomplish? ");
        if (!goalNumber.HasValue)
        {
            return;
        }

        int goalIndex = goalNumber.Value - 1;

        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int earned = _goals[goalIndex].RecordEvent();
        _score += earned;

        if (earned >= 0)
        {
            Console.WriteLine($"You earned {earned} points!");
        }
        else
        {
            Console.WriteLine($"You lost {Math.Abs(earned)} points.");
        }

        if (earned != 0)
        {
            _eventsRecorded++;
            if (_eventsRecorded % MilestoneInterval == 0)
            {
                _score += MilestoneBonus;
                Console.WriteLine($"Milestone bonus! +{MilestoneBonus} points for completing {MilestoneInterval} events.");
            }
        }

        Console.WriteLine($"You now have {_score} points.");
    }


    public void SaveGoals()
    {
        Console.WriteLine("Enter 'b' to return to the main menu.");
        string filename = ReadTextOrBack("What is the filename for the goal file? ");
        if (filename == null)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        string filePath = ResolveFilePath(filename);

        var lines = new List<string>
        {
            $"Score|{_score}",
            $"Events|{_eventsRecorded}"
        };
        foreach (Goal goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }

        File.WriteAllLines(filePath, lines);
        Console.WriteLine($"Goals saved successfully to: {filePath}");
    }

    public void LoadGoals()
    {
        Console.WriteLine("Enter 'b' to return to the main menu.");
        string filename = ReadTextOrBack("What is the filename for the goal file? ");
        if (filename == null)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        string filePath = ResolveFilePath(filename);

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        _goals.Clear();
        int startIndex = 0;
        _score = 0;
        _eventsRecorded = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            if (line.StartsWith("Score|"))
            {
                _score = ParseScore(line);
                startIndex = i + 1;
            }
            else if (line.StartsWith("Events|"))
            {
                _eventsRecorded = ParseEvents(line);
                startIndex = i + 1;
            }
            else if (int.TryParse(line, out int oldScore))
            {
                _score = oldScore;
                startIndex = i + 1;
            }
            else
            {
                startIndex = i;
                break;
            }
        }

        for (int i = startIndex; i < lines.Length; i++)
        {
            Goal goal = ParseGoal(lines[i]);
            if (goal != null)
            {
                _goals.Add(goal);
            }
        }

        Console.WriteLine($"Goals loaded successfully from: {filePath}");
    }

    private static int? ReadIntOrBack(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";
            if (IsBackCommand(input))
            {
                return null;
            }

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.WriteLine("Please enter a valid number.");
        }
    }

    private static string ReadTextOrBack(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine() ?? "";
        return IsBackCommand(input) ? null : input;
    }

    private static bool IsBackCommand(string input)
    {
        string value = input.Trim();
        return value.Equals("b", StringComparison.OrdinalIgnoreCase)
            || value.Equals("back", StringComparison.OrdinalIgnoreCase);
    }

    private static Goal ParseGoal(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length == 0)
        {
            return null;
        }

        switch (parts[0])
        {
            case "SimpleGoal":
                return new SimpleGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]));
            case "EternalGoal":
                return new EternalGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]));
            case "ChecklistGoal":
                return new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5]),
                    int.Parse(parts[6]));
            case "NegativeGoal":
                return new NegativeGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]));
            default:
                return null;
        }
    }

    private static int ParseScore(string scoreLine)
    {
        string[] parts = scoreLine.Split('|');
        if (parts.Length == 2 && parts[0] == "Score")
        {
            return int.Parse(parts[1]);
        }

        return int.Parse(scoreLine);
    }

    private static int ParseEvents(string eventsLine)
    {
        string[] parts = eventsLine.Split('|');
        if (parts.Length == 2 && parts[0] == "Events")
        {
            return int.Parse(parts[1]);
        }

        return 0;
    }

    private static string ResolveFilePath(string filename)
    {
        if (Path.IsPathRooted(filename))
        {
            return filename;
        }

        string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
        return Path.Combine(projectRoot, filename);
    }

    private int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    private int GetPointsToNextLevel()
    {
        int nextLevelFloor = GetLevel() * 1000;
        return Math.Max(0, nextLevelFloor - _score);
    }

    private string GetTitle()
    {
        if (_score < 500)
        {
            return "Seeker";
        }

        if (_score < 1500)
        {
            return "Disciple";
        }

        if (_score < 3000)
        {
            return "Pathfinder";
        }

        if (_score < 5000)
        {
            return "Covenant Keeper";
        }

        return "Eternal Champion";
    }

}
