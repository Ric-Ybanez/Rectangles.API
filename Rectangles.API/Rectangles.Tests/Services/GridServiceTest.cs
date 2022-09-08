using Rectangles.Common.Models;
using Rectangles.Common.Request;
using Rectangles.Tests.Services.Shared;
using System;
using System.Collections.Generic;
using Xunit;

namespace Rectangles.Tests.Services
{
    
    public class GridServiceTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        [InlineData(0.01, 0.01)]
        [InlineData(4, 25)]
        [InlineData(25, 4)]
        [InlineData(26, 5)]
        [InlineData(5, 26)]
        public void InitializeGrid_ThrowsArgumentException(int width, int height)
        {
            var moqRepository = MockRepositoryGenerator.GetMockRectangleRepository();
            var service = ServiceGenerator.GetGridService(moqRepository.Object);


            Assert.Throws<ArgumentException>(() => service.InitializeGrid(width, height));
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(25, 25)]
        [InlineData(24, 24)]
        [InlineData(6, 6)]
        [InlineData(5, 25)]
        [InlineData(25, 5)]
        public void InitializeGrid_Void(int width, int height)
        {
            var moqRepository = MockRepositoryGenerator.GetMockRectangleRepository();
            var service = ServiceGenerator.GetGridService(moqRepository.Object);

            service.InitializeGrid(width, height);
            Assert.Equal(width, Grid.Width);
            Assert.Equal(height, Grid.Height);
        }

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(2, 1, true)]
        [InlineData(3, 1, true)]
        [InlineData(1, 2, true)]
        [InlineData(2, 2, true)]
        [InlineData(3, 2, true)]
        [InlineData(1, 3, true)]
        [InlineData(2, 3, true)]
        [InlineData(3, 3, true)]
        [InlineData(1, 4, true)]
        [InlineData(2, 4, true)]
        [InlineData(3, 4, true)]
        [InlineData(4, 1, false)]
        [InlineData(7, 5, false)]
        [InlineData(0, 0, false)]
        [InlineData(0, 5, false)]
        [InlineData(1, 0, false)]
        [InlineData(0, 1, false)]
        [InlineData(0, 4, false)]
        [InlineData(1, 5, false)]
        [InlineData(4, 4, false)]
        [InlineData(4, 5, false)]
        [InlineData(3, 5, false)]
        public void SearchRectangle_ReturnsRectangle(int x, int y, bool expected)
        {
            var point = new Point();
            point.X = x;
            point.Y = y;
            var moqRepository = MockRepositoryGenerator.GetMockRectangleRepository();
            var service = ServiceGenerator.GetGridService(moqRepository.Object);
            service.InitializeGrid(12, 8);

            moqRepository.Setup(i => i.GetAll())
              .Returns(new List<Rectangle>() { new Rectangle(new Point() { X = 1, Y = 1}, 3, 4) });

            var response = service.SearchRectangle(point);
            Assert.Equal(response != null, expected);
        }

        [Fact]
        public void SearchRectangle_ThrowsArgumentException()
        {
            var point = new Point();
            var moqRepository = MockRepositoryGenerator.GetMockRectangleRepository();
            var service = ServiceGenerator.GetGridService(moqRepository.Object);
            Grid.Width = 0;
            Grid.Height = 0;

            Assert.Throws<ArgumentException>(() => service.SearchRectangle(point));
        }

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(2, 1, true)]
        [InlineData(3, 1, true)]
        [InlineData(1, 2, true)]
        [InlineData(2, 2, true)]
        [InlineData(3, 2, true)]
        [InlineData(1, 3, true)]
        [InlineData(2, 3, true)]
        [InlineData(3, 3, true)]
        [InlineData(1, 4, true)]
        [InlineData(2, 4, true)]
        [InlineData(3, 4, true)]
        public void RemoveRectangle_ReturnsRectangle(int x, int y, bool expected)
        {
            var point = new Point();
            point.X = x;
            point.Y = y;
            var moqRepository = MockRepositoryGenerator.GetMockRectangleRepository();
            var service = ServiceGenerator.GetGridService(moqRepository.Object);
            service.InitializeGrid(12, 8);

            moqRepository.Setup(i => i.GetAll())
              .Returns(new List<Rectangle>() { new Rectangle(new Point() { X = 1, Y = 1 }, 3, 4) });

            var response = service.RemoveRectangle(point);
            Assert.Equal(response != null, expected);
        }

        [InlineData(4, 1)]
        [InlineData(7, 5)]
        [InlineData(0, 0)]
        [InlineData(0, 5)]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 4)]
        [InlineData(1, 5)]
        [InlineData(4, 4)]
        [InlineData(4, 5)]
        [InlineData(3, 5)]
        [Theory]
        public void SearchRectangle_Notfound_ThrowsArgumentException(int x, int y)
        {
            var point = new Point();
            point.X = x;
            point.Y = y;
            var moqRepository = MockRepositoryGenerator.GetMockRectangleRepository();
            var service = ServiceGenerator.GetGridService(moqRepository.Object);
            service.InitializeGrid(12, 8);

            moqRepository.Setup(i => i.GetAll())
              .Returns(new List<Rectangle>() { new Rectangle(new Point() { X = 1, Y = 1 }, 3, 4) });

            Assert.Throws<ArgumentException>(() => service.RemoveRectangle(point));
        }

        [Fact]
        public void RemoveRectangle_ThrowsArgumentException()
        {
            var point = new Point();
            var moqRepository = MockRepositoryGenerator.GetMockRectangleRepository();
            var service = ServiceGenerator.GetGridService(moqRepository.Object);



            Assert.Throws<ArgumentException>(() => service.RemoveRectangle(point));
        }

        [Theory]
        [InlineData(25, 25, 26, 26)]
        [InlineData(12, 10, 13, 11)]
        [InlineData(12, 10, 13, 10)]
        [InlineData(12, 10, 14, 9)]
        [InlineData(12, 10, 2, 11)]
        [InlineData(12, 10, 2, 12)]
        [InlineData(12, 10, 13, 2)]
        public void PlaceRectangle_ThrowsArgumentException(int GridWith, int GridHeight, int rectWidth, int recHeight)
        {
            var start = new Point();
            start.X = 0;
            start.Y = 0;
            var request = new CreateRectangleRequest();
            request.Start = start;
            request.Height = recHeight;
            request.Width = rectWidth;
            
            var moqRepository = MockRepositoryGenerator.GetMockRectangleRepository();
            var service = ServiceGenerator.GetGridService(moqRepository.Object);
            service.InitializeGrid(GridWith, GridHeight);

            Assert.Throws<ArgumentException>(() => service.PlaceRectangle(request));
        }


        [Theory]
        [InlineData(3, 2, 3, 5)]
        [InlineData(1, 8, 5, 2)]
        [InlineData(3, 11, 3, 4)]
        [InlineData(6, 4, 2, 3)]
        [InlineData(8, 2, 3, 5)]
        [InlineData(8, 8, 4, 2)]
        [InlineData(8, 11, 3, 4)]
        [InlineData(6, 11, 2, 4)]
        public void PlaceRectangle_Overlapping_ThrowsArgumentException(int startX, int startY, int rectWidth, int recHeight)
        {
            var start = new Point();
            start.X = startX;
            start.Y = startY;
            var request = new CreateRectangleRequest();
            request.Start = start;
            request.Height = recHeight;
            request.Width = rectWidth;

            var moqRepository = MockRepositoryGenerator.GetMockRectangleRepository();
            var service = ServiceGenerator.GetGridService(moqRepository.Object);
            service.InitializeGrid(15, 15);

            moqRepository.Setup(i => i.GetAll())
              .Returns(new List<Rectangle>() { new Rectangle(new Point() { X = 5, Y = 6 }, 4, 6) });

            var aex = Assert.Throws<ArgumentException>(() => service.PlaceRectangle(request));
            Assert.Equal(true, aex.Message.Contains("Overlaps"));
        }

        [Theory]
        [InlineData(3, 3, 2, 3)]
        [InlineData(3, 8, 2, 3)]
        [InlineData(3, 12, 2, 3)]
        [InlineData(6, 2, 2, 4)]
        [InlineData(9, 1, 2, 5)]
        [InlineData(9, 8, 2, 3)]
        [InlineData(9, 12, 2, 3)]
        [InlineData(6, 12, 2, 3)]
        public void PlaceRectangle_NotEmpty_ReturnsRectangle(int startX, int startY, int rectWidth, int recHeight)
        {
            var start = new Point();
            start.X = startX;
            start.Y = startY;
            var request = new CreateRectangleRequest();
            request.Start = start;
            request.Height = recHeight;
            request.Width = rectWidth;

            var moqRepository = MockRepositoryGenerator.GetMockRectangleRepository();
            var service = ServiceGenerator.GetGridService(moqRepository.Object);
            service.InitializeGrid(15, 15);

            moqRepository.Setup(i => i.GetAll())
              .Returns(new List<Rectangle>() { new Rectangle(new Point() { X = 5, Y = 6 }, 4, 6) });

            var response = service.PlaceRectangle(request);
            Assert.NotNull(response);
        }

        [Fact]
        public void PlaceRectangle_Empty_ReturnsRectangle()
        {
            var start = new Point();
            start.X = 5;
            start.Y = 6;
            var request = new CreateRectangleRequest();
            request.Start = start;
            request.Height = 4;
            request.Width = 6;

            var moqRepository = MockRepositoryGenerator.GetMockRectangleRepository();
            var service = ServiceGenerator.GetGridService(moqRepository.Object);
            service.InitializeGrid(15, 15);

            moqRepository.Setup(i => i.GetAll())
              .Returns(new List<Rectangle>());

            var response = service.PlaceRectangle(request);
            Assert.NotNull(response);
        }

        [Fact]
        public void GetAllRectangles_ReturnsManyRectangle()
        {
            var moqRepository = MockRepositoryGenerator.GetMockRectangleRepository();
            var service = ServiceGenerator.GetGridService(moqRepository.Object);
            service.InitializeGrid(15, 15);

            moqRepository.Setup(i => i.GetAll())
                .Returns(new List<Rectangle>() { new Rectangle(new Point() { X = 5, Y = 6 }, 4, 6) });

            var response = service.GetAllRectangles();
            Assert.NotNull(response);
            Assert.NotEmpty(response);
        }
    }
}
