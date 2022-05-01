namespace MatStatSemWork
{
    public class Calculator
    {
        private readonly List<double> _fields;

        public Calculator(List<double> fields)
        {
            _fields = fields;
        }
    
        public int GetIntervalsCount(int n)
        {
            return Convert.ToInt32(Math.Round(1 + 3.322 * Math.Log10(n)));
        }

        public double GetIntervalsLength(double xMin, double xMax, int k)
        {
            return Math.Round((xMax - xMin) / k,3);
        }

        public List<Interval> GetIntervals(double xMin, double xMax, double length, int count)
        {
            var intervals = new List<Interval>();
            for (var i = 0; i < count; i++)
            {
                var start = xMin;
                var finish = xMin + length;
                var ni = Get_ni(start, finish);
                var xMedial = GetMedialX(start, finish);
                intervals.Add(new Interval(Math.Round(start,3), Math.Round(finish,3), ni,Math.Round((double)ni/_fields.Count,3), xMedial));
                xMin += length;
            }

            return intervals;
        }

        private int Get_ni(double start, double finish)
        {
            return _fields
                .Count(field => field < finish && field >= start);
        }
        
        private double GetMedialX(double start, double finish)
        {
            return Math.Round((start + finish) / 2.0,3);
        }

        //zi
        public double GetDeviation(double xMedial, double xWaved)
        {
            return Math.Round(xMedial - xWaved,3);
        }

        //икс с волной
        public double GetSampleAverage(List<Interval> intervals)
        {
            var sum = intervals.Sum(interval => interval.ni * interval.XMedial);

            return sum / _fields.Count;
        }

        //дисперсик
        public double GetVariance(List<Interval> intervals)
        {
            var sum = intervals.Sum(interval => interval.ni * interval.zi * interval.zi);

            return Math.Round(sum / _fields.Count,3);
        }

        public Interval[] GetModeIntervalWithTwoNeighbours(List<Interval> intervals)
        {
            var orderedIntervals = intervals.OrderBy(inter => inter.Start).ToList();
            var prev = new Interval();
            var next = new Interval();
            var maxInterval = new Interval();
            var max = 0;
            for (var i = 1; i < orderedIntervals.Count - 1; i++)
            {
                if (orderedIntervals[i].ni <= max) continue;
                prev = orderedIntervals[i - 1];
                next = orderedIntervals[i + 1];
                maxInterval = orderedIntervals[i];
                max = orderedIntervals[i].ni;
            }

            return new[] { prev, maxInterval, next };
        }

        public double GetM0(double x0, int nM, double nMPrev, double nMNext, double h)
        {
            return Math.Round(x0 + (nM - nMPrev) * h / (nM - nMPrev + (nM - nMNext)),3);
        }

        public Interval[] GetMedianInterval(List<Interval> intervals)
        {
            var orderedIntervals = intervals.OrderBy(inter => inter.Start).ToList();
            Interval result;
            Interval prev;
            if (_fields.Count % 2 == 0)
            { 
                prev = orderedIntervals.Last(inter => inter.nAccumulated < _fields.Count / 2 + 1);
                result = orderedIntervals.First(inter => inter.nAccumulated > _fields.Count / 2 + 1);
            }
            else
            {
                prev = orderedIntervals.Last(inter => inter.nAccumulated < _fields.Count / 2 + 1);
                result = orderedIntervals.First(inter => inter.nAccumulated > _fields.Count / 2);
            }

            return new[] { prev, result };
        }

        public double GetMedian(double x0, double nAccumulatedPrev, double nMedian, double l)
        {
            return Math.Round(x0 + l * (0.5 * _fields.Count - nAccumulatedPrev) / nMedian,3);
        }

        public double GetCoefficientOfAsymmetry(List<Interval> intervals, double standardDeviationOfTheSample)
        {
            return Math.Round(intervals.Sum(inter => Math.Pow(inter.zi, 3) * inter.ni) / _fields.Count /
                              Math.Pow(standardDeviationOfTheSample, 3),3);
        }

        public double GetCoefficientOfExcess(List<Interval> intervals, double standardDeviationOfTheSample)
        {
            return Math.Round(intervals.Sum(inter => Math.Pow(inter.zi, 4) * inter.ni) / _fields.Count /
                Math.Pow(standardDeviationOfTheSample, 4) - 3,3);
        }
    }
}