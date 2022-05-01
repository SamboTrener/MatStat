namespace MatStatSemWork;

    public class Interval
    {
        public double Start { get; }
        public double Finish { get; }
        public int ni { get; }

        public double wi { get; }

        public double XMedial { get; }

        public double zi { get; set; }
        public int nAccumulated { get; set; }

        public Interval(double start, double finish, int ni, double wi, double xMedial)
        {
            Start = start;
            Finish = finish;
            this.ni = ni;
            this.wi = wi;
            XMedial = xMedial;
        }

        public Interval()
        {
        }
    }