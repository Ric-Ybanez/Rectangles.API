using Rectangles.Common.Models;
using System.ComponentModel.DataAnnotations;


namespace Rectangles.Common.Request
{
    public class CreateRectangleRequest
    {
        public Point Start { get; set; }
        [Range(0, int.MaxValue)]
        public int Width { get; set; }
        [Range(0, int.MaxValue)]
        public int Height { get; set; }
    }
}
