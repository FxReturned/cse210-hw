public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, double length, int laps)
        : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 0.05;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (Length / 60);
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return distance > 0 ? Length / distance : 0;
    }

    public override string GetSummary()
    {
        string dateStr = Date.ToString("dd MMM yyyy");
        return $"{dateStr} Swimming ({Length} min) - Laps: {_laps}, " +
               $"Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}
