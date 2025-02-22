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
        string activityType = this.GetType().Name;
        return $"{dateString} {activityType} ({_length} min) - " +
               $"Distance: {GetDistance():F2} km, " +
               $"Speed: {GetSpeed():F2} kph, " +
               $"Pace: {GetPace():F2} min per km";
    }
}
