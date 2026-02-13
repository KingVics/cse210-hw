public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return GetPoints();
    }


    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }
}
