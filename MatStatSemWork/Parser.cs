using System.Globalization;

namespace MatStatSemWork;

public class Parser
{
    public async Task<List<Pumpkin>> Parse()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(),"Pumpkin_Seeds_Dataset.arff");
        var pumpkins = new List<Pumpkin>();
        using (StreamReader reader = new StreamReader(path))
        {
            var line = await reader.ReadLineAsync();
            while (line is not null)
            {
                var parsedLine = line.Split(",");
                var area = int.Parse(parsedLine[0]);
                var perimeter = Math.Round(double.Parse(parsedLine[1], CultureInfo.InvariantCulture),3);
                var majorAxisLength = Math.Round(double.Parse(parsedLine[2], CultureInfo.InvariantCulture),3);
                var minorAxisLength = Math.Round(double.Parse(parsedLine[3], CultureInfo.InvariantCulture),3);
                var convexArea = int.Parse(parsedLine[4]);
                var equivDiameter = Math.Round(double.Parse(parsedLine[5], CultureInfo.InvariantCulture),3);
                /*var eccentricity = Math.Round(double.Parse(parsedLine[6], CultureInfo.InvariantCulture),3);
                var solidity = Math.Round(double.Parse(parsedLine[7], CultureInfo.InvariantCulture),3);*/
                var extent = Math.Round(double.Parse(parsedLine[8], CultureInfo.InvariantCulture),3);
                var roundness = Math.Round(double.Parse(parsedLine[9], CultureInfo.InvariantCulture),3);
                var aspectRation = Math.Round(double.Parse(parsedLine[10], CultureInfo.InvariantCulture),3);
                var compactness = Math.Round(double.Parse(parsedLine[11], CultureInfo.InvariantCulture),3);
                var pumpkinType = parsedLine[12];
                pumpkins.Add(new Pumpkin(area,perimeter,majorAxisLength,minorAxisLength,convexArea,
                    equivDiameter/*,eccentricity,solidity*/,extent,roundness,
                    aspectRation,compactness,pumpkinType));
                line = await reader.ReadLineAsync();
            }
        }

        return pumpkins;
    }
}