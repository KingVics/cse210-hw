public class Cycling: Activity
{
    private double _speed;


    public Cycling(double speed, int length, string name, DateOnly? date = null): base(length, name, date)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        // Distance in miles: speed * hours
        return _speed * (GetLength() / 60.0);
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        // Pace in min/mile: minutes / distance
        return GetLength() / GetDistance();
    }

    public override string GetSummary()
    {
        string date = GetDate().ToString("dd MMM yyyy");
        string name = GetName();
        int minute = GetLength();
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{date} {name} ({minute} min)- Distance {distance:F2} miles, Speed {speed:F2} mph, Pace: {pace:F2} min per mile";
    }
}
