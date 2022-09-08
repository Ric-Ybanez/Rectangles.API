namespace Rectangles.Common.Models
{
    public class Rectangle
    {
        public Rectangle(Point start, int width, int height)
        {
            UpperLeft = start;
            BottomRight = new Point { X = start.X + (width -1 ), Y = start.Y + (height -1) };
            Width = width;
            Height = height;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Point UpperLeft { get; set; }
        public Point BottomRight { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

}
