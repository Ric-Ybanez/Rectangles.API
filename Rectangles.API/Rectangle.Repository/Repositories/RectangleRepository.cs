using Rectangles.Common.Models;
using Rectangles.Repository.Contracts;

namespace Rectangles.Repository.Repositories
{
    public class RectangleRepository : IRectangleRepository
    {
        public IEnumerable<Rectangle> GetAll()
        {
            return Grid.Rectangles;
        }
        public void Create(Rectangle rectangle)
        {
            Grid.Rectangles.Add(rectangle);
        }
        public void Delete(Rectangle rectangle)
        {
            Grid.Rectangles.Remove(rectangle);
        }
    }
}
