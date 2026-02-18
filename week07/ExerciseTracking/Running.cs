public class Running: Activity
{
    private double _distance;


    public Running(double distance, int length, string name, DateOnly? date = null): base(length, name, date)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        // Speed in mph: (distance / minutes) * 60
        return (GetDistance() / GetLength()) * 60;
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
