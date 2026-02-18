public class Swimming: Activity
{
    private int _numberOfLaps;


    public Swimming(int numberOfLaps, int length, string name, DateOnly? date = null): base(length, name, date)
    {
        _numberOfLaps = numberOfLaps;
    }

    public override double GetDistance()
    {
        // Distance in kilometers: laps * 50m / 1000
        return _numberOfLaps * 50.0 / 1000.0;
    
    }

    public override double GetSpeed()
    {
        // Speed in kph: (distance / minutes) * 60
        return (GetDistance() / GetLength()) * 60;
    }

    public override double GetPace()
    {
        // Pace in min/km: minutes / distance
        return GetLength() / GetDistance();
    }
    public override string GetSummary()
    {
        string name = GetName();

        int minute = GetLength();

        double distance = GetDistance();

        double speed = GetSpeed();

        double pace = GetPace();

        string date = GetDate().ToString("dd MMM yyyy");

        return $"{date} {name} ({minute} min)- Distance {distance:F2} km, Speed {speed:F2} kph, Pace: {pace:F2} min per km";
    }
}
