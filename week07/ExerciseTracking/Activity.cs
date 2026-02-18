public abstract class Activity
{
    private string _name;
    private int _length;
    private DateOnly _date;


    public Activity(int length, string name, DateOnly? date = null)
    {
        _length = length;
        _name = name;
        _date = date ?? DateOnly.FromDateTime(DateTime.Today);
    }

    public DateOnly GetDate()
    {
        return _date;
    }
    
    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }


    public int GetLength()
    {
        return _length;
    }

    public string GetName()
    {
        return _name;
    }


    public abstract string GetSummary();
}
