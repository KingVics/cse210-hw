public class NegativeGoal : Goal
{
    private int _timesRecorded;

    public NegativeGoal(string name, string description, int points, int timesRecorded = 0)
        : base(name, description, points)
    {
        _timesRecorded = timesRecorded;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        return -GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Recorded {_timesRecorded} times (loses {GetPoints()} points each time)";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_timesRecorded}";
    }
}
