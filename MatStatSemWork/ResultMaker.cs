namespace MatStatSemWork;

public static class ResultMaker
{
    public static Result GetResult(this List<double> attrCollection)
    {
        var calculator = new Calculator(attrCollection);
        var n = attrCollection.Count;
        var k = calculator.GetIntervalsCount(n);
        var l = calculator.GetIntervalsLength(attrCollection.Min(),attrCollection.Max(),k);
        var intervals = calculator.GetIntervals(attrCollection.Min(),attrCollection.Max(),l,k);
        var xWaved = calculator.GetSampleAverage(intervals);
        var accum = 0;
        foreach (var interval in intervals)
        {
            interval.zi = calculator.GetDeviation(interval.XMedial,xWaved);
            accum += interval.ni;
            interval.nAccumulated += accum;
        }

        var variance = calculator.GetVariance(intervals);
        var standardDeviationOfTheSample = Math.Sqrt(variance);
        var modeIntervalWithTwoNeighbours = calculator.GetModeIntervalWithTwoNeighbours(intervals);
        var x0Mode = modeIntervalWithTwoNeighbours[1].Start;
        var nM = modeIntervalWithTwoNeighbours[1].ni;
        var nMPrev = modeIntervalWithTwoNeighbours[0].ni;
        var nMNext = modeIntervalWithTwoNeighbours[2].ni;
        var M0 = calculator.GetM0(x0Mode, nM, nMPrev, nMNext, l);
        var medianInterval = calculator.GetMedianInterval(intervals);
        var x0Median = medianInterval[1].Start;
        var nAccumPrev = medianInterval[0].nAccumulated;
        var nMedian = medianInterval[1].ni;
        var median = calculator.GetMedian(x0Median, nAccumPrev, nMedian, l);
        var A3 = calculator.GetCoefficientOfAsymmetry(intervals, standardDeviationOfTheSample);
        var Ek = calculator.GetCoefficientOfExcess(intervals, standardDeviationOfTheSample);

        return new Result(intervals, xWaved, variance, standardDeviationOfTheSample,  M0, median, Ek,  A3);
    }
}