namespace MatStatSemWork;

public class Result
{
    public List<Interval> Intervals { get; }
    public double xWaved { get; }
    public double variance { get; }
    public double standardDeviationOfTheSample { get; }

    public double M0 { get; }
    
    public double Me { get; }
    
    public double A3 { get; }
    public double Ek { get; }
    
    public Result(List<Interval> intervals, double xWaved, double variance, double standardDeviationOfTheSample, double m0, double me, double ek, double a3)
    {
        Intervals = intervals;
        this.xWaved = xWaved;
        this.variance = variance;
        this.standardDeviationOfTheSample = standardDeviationOfTheSample;
        M0 = m0;
        Me = me;
        Ek = ek;
        A3 = a3;
    }
}