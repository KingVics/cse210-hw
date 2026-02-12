public abstract class Goal
{
    private readonly string _shortName;
    private readonly string _description;
    private readonly int _points;

    protected Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public virtual int RecordEvent()
    {
        return _points;
    }

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "X" : " ";
        return $"[{status}] {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}
