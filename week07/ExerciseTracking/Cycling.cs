public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, double length, double speed)
        : base(date, length)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;

    public override double GetDistance()
    {
        return _speed * (Length / 60);
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return distance > 0 ? Length / distance : 0;
    }

    public override string GetSummary()
    {
        string dateStr = Date.ToString("dd MMM yyyy");
        return $"{dateStr} Cycling ({Length} min) - Speed: {GetSpeed():F2} kph, " +
               $"Distance: {GetDistance():F2} km, Pace: {GetPace():F2} min per km";
    }
}
