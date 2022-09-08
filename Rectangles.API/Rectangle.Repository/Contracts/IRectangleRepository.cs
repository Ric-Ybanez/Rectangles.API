using System;
using Rectangles.Common.Models;

namespace Rectangles.Repository.Contracts
{
    public interface IRectangleRepository
    {
        void Create(Rectangle rectangle);
        void Delete(Rectangle rectangle);
        IEnumerable<Rectangle> GetAll();
    }
}
