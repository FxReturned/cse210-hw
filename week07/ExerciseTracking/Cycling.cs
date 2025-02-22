public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, double length, double speed)
        : base(date, length)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetDistance()
    {
        return _speed * (Length / 60);
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return distance > 0 ? Length / distance : 0;
    }
}
