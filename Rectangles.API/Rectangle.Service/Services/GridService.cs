using Rectangles.Common.Models;
using Rectangles.Common.Request;
using Rectangles.Repository.Contracts;
using Rectangles.Service.Contracts;

namespace Rectangles.Service.Services
{
    public class GridService : IGridService
    {
        private readonly IRectangleRepository _repository;
        private const int GRID_MIN_SIZE = 5;
        private const int GRID_MAX_SIZE = 25;
        public GridService(IRectangleRepository repository)
        {
            _repository = repository;
        }

        public void InitializeGrid(int Width, int Height)
        {
            if (!IsValidGridSize(Width, Height))
                throw new ArgumentException($"A grid must have a width and height of no less than {GRID_MIN_SIZE} and no greater than {GRID_MAX_SIZE}");

            Grid.Width = Width;
            Grid.Height = Height;
        }

        //Search rectangle in Grid using point
        public Rectangle? SearchRectangle(Point point)
        {
            if (!IsGridInitialize())
                throw new ArgumentException("Grid is not yet Initialized!");

            foreach (var rectangleInGrid in _repository.GetAll())
            {
                if (HasFoundRectangle(point, rectangleInGrid))
                    return rectangleInGrid;
            }

            return null;
        }

        public Rectangle? RemoveRectangle(Point point)
        {
            if (!IsGridInitialize())
                throw new ArgumentException("Grid is not yet Initialized!");

            var rectangle = SearchRectangle(point);

            if (rectangle == null)
                throw new ArgumentException("Rectangle not found");

            _repository.Delete(rectangle);
            return rectangle;
        }

        public Rectangle PlaceRectangle(CreateRectangleRequest request)
        {
            if (!IsGridInitialize())
                throw new ArgumentException("Grid is not yet Initialized!");

            var rectangle = new Rectangle(request.Start, request.Width, request.Height);

            if (IsRectangleBeyondGridEdge(rectangle))
                throw new ArgumentException("Rectangles must not extend beyond the edge of the grid");

            if (!_repository.GetAll().Any())
            {
                _repository.Create(rectangle);
                return rectangle;
            }

            foreach (var rectangleInGrid in _repository.GetAll())
            {
                if (HasOverlapRectangle(rectangleInGrid, rectangle))
                    throw new ArgumentException("Invalid: Rectangle Overlaps");
            }

            _repository.Create(rectangle);
            return rectangle;
        }

        public IEnumerable<Rectangle> GetAllRectangles() => _repository.GetAll();

        #region private methods
        private bool HasFoundRectangle(Point point, Rectangle rectangle) =>
            ((point.X >= rectangle.UpperLeft.X && point.X <= rectangle.BottomRight.X) &&
            (point.Y >= rectangle.UpperLeft.Y && point.Y <= rectangle.BottomRight.Y));

        private bool HasOverlapRectangle(Rectangle rectangle1, Rectangle rectangle2)
        {
            if (rectangle1.UpperLeft.X == rectangle1.BottomRight.X || rectangle1.UpperLeft.Y == rectangle1.BottomRight.Y
                || rectangle2.UpperLeft.X == rectangle2.BottomRight.X || rectangle2.UpperLeft.Y == rectangle2.BottomRight.Y)
                return false;

            if (rectangle1.UpperLeft.X > rectangle2.BottomRight.X || rectangle2.UpperLeft.X > rectangle1.BottomRight.X)
                return false;

            if (rectangle1.BottomRight.Y < rectangle2.UpperLeft.Y || rectangle2.BottomRight.Y < rectangle1.UpperLeft.Y)
                return false;

            return true;
        }

        private bool IsValidGridSize(int width, int height) =>
            !(width > GRID_MAX_SIZE || width < GRID_MIN_SIZE || height > GRID_MAX_SIZE || height < GRID_MIN_SIZE);

        private bool IsGridInitialize() => 
            Grid.Width >= GRID_MIN_SIZE && Grid.Height >= GRID_MIN_SIZE;

        private bool IsRectangleBeyondGridEdge(Rectangle rectangle) =>
            rectangle.BottomRight.X >= Grid.Width || rectangle.BottomRight.Y >= Grid.Height;
         
        #endregion
    }
}
