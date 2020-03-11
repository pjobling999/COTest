using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;
        private readonly Dictionary<string, int> _sizeIndex;
        private readonly Dictionary<string, int> _colorIndex;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;
            _sizeIndex = Size.SizeIndexes();
            _colorIndex = Color.ColourIndexes();
        }

        public SearchResults Search(SearchOptions options)
        {
            //set up variables to hold return data
            var shirts = new List<Shirt>();
            var totalSizes = Size.All.Select(x => new SizeCount() { Size = x, Count = 0 }).ToList();
            var totalColors = Color.All.Select(x => new ColorCount() { Color = x, Count = 0 }).ToList();
            
            //one pass through
            foreach (var shirt in _shirts)
            {
                if ((options.Sizes.Contains(shirt.Size) || !options.Sizes.Any()) && (options.Colors.Contains(shirt.Color) || !options.Colors.Any()))
                {
                    shirts.Add(shirt);

                    totalSizes[_sizeIndex[shirt.Size.Id.ToString()]].Count++;
                    totalColors[_colorIndex[shirt.Color.Id.ToString()]].Count++;
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
