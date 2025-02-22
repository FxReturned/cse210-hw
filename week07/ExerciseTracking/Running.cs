public class Running : Activity
{
    // Atributo único para Running: distancia (en kilómetros)
    private double _distance;

    public Running(DateTime date, double length, double distance)
        : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed()
    {
        return _distance / (Length / 60);
    }

    public override double GetPace()
    {
        return Length / _distance;
    }

    public override string GetSummary()
    {
        string dateStr = Date.ToString("dd MMM yyyy");
        return $"{dateStr} Running ({Length} min) - Distance: {GetDistance():F2} km, " +
               $"Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}
