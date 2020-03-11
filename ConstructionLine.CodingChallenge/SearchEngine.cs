using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;
        }

        public SearchResults Search(SearchOptions options)
        {
            //set up variables to hold return data
            var shirts = new List<Shirt>();
            var totalSizes = new List<SizeCount>()
            { new SizeCount(){ Size = Size.Small, Count = 0 },
              new SizeCount(){ Size = Size.Medium, Count = 0 },
              new SizeCount(){ Size = Size.Large, Count = 0 } };
            var totalColors = new List<ColorCount>()
            { new ColorCount() { Color = Color.Red, Count = 0 },
              new ColorCount() { Color = Color.Blue, Count = 0 },
              new ColorCount() { Color = Color.Yellow, Count = 0 },
              new ColorCount() { Color = Color.White, Count = 0 },
              new ColorCount() { Color = Color.Black, Count = 0 } };


            //store index of count objects for fast lookup during loop
            var sizeIndexes = new Dictionary<string, int>()
            { 
                [Size.Small.Id.ToString()] =  0,
                [Size.Medium.Id.ToString()] = 1,
                [Size.Large.Id.ToString()] = 2
            };
            var colourIndexes = new Dictionary<string, int>()
            {
                [Color.Red.Id.ToString()] = 0,
                [Color.Blue.Id.ToString()] = 1,
                [Color.Yellow.Id.ToString()] = 2,
                [Color.White.Id.ToString()] = 3,
                [Color.Black.Id.ToString()] = 4
            };

            //one pass through
            foreach (var shirt in _shirts)
            {
                if ((options.Sizes.Contains(shirt.Size) || !options.Sizes.Any()) && (options.Colors.Contains(shirt.Color) || !options.Colors.Any()))
                {
                    shirts.Add(shirt);

                    totalSizes[sizeIndexes[shirt.Size.Id.ToString()]].Count++;
                    totalColors[colourIndexes[shirt.Color.Id.ToString()]].Count++;
                }
            }

            return new SearchResults
            {
                Shirts = shirts,
                ColorCounts = totalColors,
                SizeCounts = totalSizes
            };

        }
    }
}
