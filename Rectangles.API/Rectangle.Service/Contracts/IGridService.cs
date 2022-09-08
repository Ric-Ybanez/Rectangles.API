using Rectangles.Common.Models;
using Rectangles.Common.Request;

namespace Rectangles.Service.Contracts
{
    public interface IGridService
    {
        Rectangle? RemoveRectangle(Point point);

        Rectangle? SearchRectangle(Point point);

        Rectangle PlaceRectangle(CreateRectangleRequest request);

        IEnumerable<Rectangle> GetAllRectangles();

        void InitializeGrid(int Width, int Height);
    }
}
