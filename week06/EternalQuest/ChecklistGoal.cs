public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private readonly int _target;
    private readonly int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus,
        int amountCompleted = 0)
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;
        int earnedPoints = GetPoints();

        if (_amountCompleted == _target)
        {
            earnedPoints += _bonus;
        }

        return earnedPoints;
    }


    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_target}|{_bonus}|{_amountCompleted}";
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Completed {_amountCompleted}/{_target} times";
    }
}
