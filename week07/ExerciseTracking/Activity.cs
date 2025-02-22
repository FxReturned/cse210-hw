using System;

public abstract class Activity
{
    private DateTime _date;
    private double _length;

    public Activity(DateTime date, double length)
    {
        _date = date;
        _length = length;
    }

    public DateTime Date
    {
        get { return _date; }
    }

    public double Length
    {
        get { return _length; }
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string dateString = _date.ToString("dd MMM yyyy");
        return $"{dateString} {this.GetType().Name} ({_length} min)";
    }
}
