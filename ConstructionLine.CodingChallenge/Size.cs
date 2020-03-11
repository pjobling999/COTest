using System;
using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class Size
    {
        public Guid Id { get; }

        public string Name { get; }

        private Size(Guid id, string name)
        {
            Id = id;
            Name = name;
        }


        public static Size Small = new Size(Guid.NewGuid(), "Small");
        public static Size Medium = new Size(Guid.NewGuid(), "Medium");
        public static Size Large = new Size(Guid.NewGuid(), "Large");

        public static Dictionary<string, int> SizeIndexes()
        {
            int index = 0;
            var sizeIndexes = new Dictionary<string, int>();
            foreach (var size in Size.All)
            {
                sizeIndexes.Add(size.Id.ToString(), index);
                index++;
            }

            return sizeIndexes;
        }

        public static List<Size> All = 
            new List<Size>
            {
                Small,
                Medium,
                Large
            };
    }
}
