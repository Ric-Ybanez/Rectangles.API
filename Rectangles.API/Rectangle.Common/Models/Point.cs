using System.ComponentModel.DataAnnotations;

namespace Rectangles.Common.Models
{
    public class Point
    {
        [Range(0, int.MaxValue)]
        public int X { get; set; }
        [Range(0, int.MaxValue)]
        public int Y { get; set; }
    }
}
