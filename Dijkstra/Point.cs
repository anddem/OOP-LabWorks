using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Point
    {
        public string Name { get; set; }

        public int Label { get; set; } = Int32.MaxValue;

        public bool Visited { get; set; } = false;

        public List<Point> Relations { get; set; } = new List<Point>();

        public Point(string name) => Name = name;

        public void AddRelation(Point point) => Relations.Add(point);

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;
            else
            {
                Point point = (Point)obj;

                return this.Name == point.Name;
            }
        }

        public override int GetHashCode()
        {
            return $"{Name}/{Label}/{Visited}".GetHashCode();
        }
    }
}
