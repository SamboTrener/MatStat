namespace MatStatSemWork;

    public class Pumpkin
    {
        public double Area { get;  }
        public double Perimeter { get;  }
        public double MajorAxisLength { get;  }
        public double MinorAxisLength { get; }
        public double ConvexArea { get;}
        public double EquivDiameter { get;  }
     /*   public double Eccentricity { get;  }
        public double Solidity { get;  }*/
        public double Extent { get;  }
        public double Roundness { get;  }
        public double AspectRation { get;  }
        public double Compactness { get;  }
        public string PumpkinType { get; }

        public Pumpkin(int area, double perimeter, double majorAxisLength, double minorAxisLength, int convexArea,
            double equivDiameter/*, double eccentricity, double solidity*/, double extent, double roundness,
            double aspectRation, double compactness, string pumpkinType)
        {
            Area = area;
            Perimeter = perimeter;
            MajorAxisLength = majorAxisLength;
            MinorAxisLength = minorAxisLength;
            ConvexArea = convexArea;
            EquivDiameter = equivDiameter;
           /* Eccentricity = eccentricity;
            Solidity = solidity;*/
            Extent = extent;
            Roundness = roundness;
            AspectRation = aspectRation;
            Compactness = compactness;
            PumpkinType = pumpkinType;
        }
    }
