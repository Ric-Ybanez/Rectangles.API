using Rectangles.Common.Models;
using Rectangles.Tests.Repositories.Shared;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace Rectangles.Tests.Repositories
{
    public class RectangleRepositoryTest
    {

        [Fact]
        public void Create_Void()
        {
            var rectangle = new Rectangle(new Point() { X = 1, Y = 1 }, 3, 4);
            var repository = RepositoryGenerator.GetRectangleRepository();
            Grid.Rectangles = new List<Rectangle>();

            int expected = Grid.Rectangles.Count + 1;
            repository.Create(rectangle);

            Assert.Equal(Grid.Rectangles.Count, expected);
            Assert.NotEmpty(Grid.Rectangles);
        }

        [Fact]
        public void Remove_Void()
        {
            var rectangle = new Rectangle(new Point() { X = 1, Y = 1 }, 3, 4);
            var repository = RepositoryGenerator.GetRectangleRepository();
            Grid.Rectangles = new List<Rectangle>();

            repository.Create(rectangle);
            int expected = Grid.Rectangles.Count - 1;

            repository.Delete(rectangle);
            Assert.Equal(expected, Grid.Rectangles.Count);
            Assert.Empty(Grid.Rectangles);
        }

        [Fact]
        public void GetAll_ReturnsRectangles()
        {
            int expected = 1;
            var rectangle = new Rectangle(new Point() { X = 1, Y = 1 }, 3, 4);
            Grid.Rectangles = new List<Rectangle>();
            var repository = RepositoryGenerator.GetRectangleRepository();

            repository.Create(rectangle);
            var rectangles = repository.GetAll();

            Assert.NotEmpty(rectangles);
            Assert.Equal(rectangles.Count(), expected);
        }
    }
}
