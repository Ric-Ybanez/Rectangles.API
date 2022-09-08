using Microsoft.AspNetCore.Mvc;
using Moq;
using Rectangles.Common.Models;
using Rectangles.Common.Request;
using Rectangles.Tests.Controllers.Shared;
using System;
using System.Collections.Generic;
using Xunit;

namespace Rectangles.Tests.Controllers
{
    public class RectangleControllerTest
    {
        [Fact]
        public void Search_ReturnsBadRequest()
        {
            var request = new Point { X = 0, Y = 0 };

            var mockService = MockServiceGenerator.GetMockGridService();
            var controller = ControllerGenerator.GetRectangleController(mockService.Object);

            mockService.Setup(i => i.SearchRectangle(It.IsAny<Point>()))
              .Throws<ArgumentException>(); ;


            var response =  controller.Search(request);
            var result = response as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Search_ReturnsNotFOund()
        {
            var request = new Point { X = 0, Y = 0 };

            var mockService = MockServiceGenerator.GetMockGridService();
            var controller = ControllerGenerator.GetRectangleController(mockService.Object);

            mockService.Setup(i => i.SearchRectangle(It.IsAny<Point>()))
              .Returns((Rectangle)null); ;


            var response = controller.Search(request);
            var result = response as NotFoundObjectResult;
            Assert.NotNull(result);
            Assert.Equal(404, result?.StatusCode);
        }

        [Fact]
        public void Search_ReturnsOk()
        {
            var request = new Point { X = 0, Y = 0 };

            var mockService = MockServiceGenerator.GetMockGridService();
            var controller = ControllerGenerator.GetRectangleController(mockService.Object);

            mockService.Setup(i => i.SearchRectangle(It.IsAny<Point>()))
              .Returns(new Rectangle(new Point(),0,0));


            var response = controller.Search(request);
            var result = response as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result?.StatusCode);
        }

        [Fact]
        public void Get_ReturnsBadRequest()
        {
            var request = new Point { X = 0, Y = 0 };

            var mockService = MockServiceGenerator.GetMockGridService();
            var controller = ControllerGenerator.GetRectangleController(mockService.Object);

            mockService.Setup(i => i.GetAllRectangles())
              .Throws<ArgumentException>(); ;


            var response = controller.Get();
            var result = response as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Get_ReturnsOk()
        {
            var request = new Point { X = 0, Y = 0 };

            var mockService = MockServiceGenerator.GetMockGridService();
            var controller = ControllerGenerator.GetRectangleController(mockService.Object);

            mockService.Setup(i => i.GetAllRectangles())
              .Returns(new List<Rectangle>() { new Rectangle(new Point(), 0, 0) });


            var response = controller.Get();
            var result = response as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result?.StatusCode);
        }

        [Fact]
        public void Post_ReturnsBadRequest()
        {
            var request = new CreateRectangleRequest();

            var mockService = MockServiceGenerator.GetMockGridService();
            var controller = ControllerGenerator.GetRectangleController(mockService.Object);

            mockService.Setup(i => i.PlaceRectangle(It.IsAny<CreateRectangleRequest>()))
              .Throws<ArgumentException>(); ;


            var response = controller.Post(request);
            var result = response as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Post_ReturnsOk()
        {
            var request = new CreateRectangleRequest();

            var mockService = MockServiceGenerator.GetMockGridService();
            var controller = ControllerGenerator.GetRectangleController(mockService.Object);

            mockService.Setup(i => i.PlaceRectangle(It.IsAny<CreateRectangleRequest>()))
              .Returns(new Rectangle(new Point(), 0, 0));


            var response = controller.Post(request);
            var result = response as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result?.StatusCode);
        }

        [Fact]
        public void Delete_ReturnsBadRequest()
        {
            var request = new Point { X = 0, Y = 0 };

            var mockService = MockServiceGenerator.GetMockGridService();
            var controller = ControllerGenerator.GetRectangleController(mockService.Object);

            mockService.Setup(i => i.RemoveRectangle(It.IsAny<Point>()))
              .Throws<ArgumentException>(); ;


            var response = controller.Delete(request);
            var result = response as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Delete_ReturnsOk()
        {
            var request = new Point { X = 0, Y = 0 };

            var mockService = MockServiceGenerator.GetMockGridService();
            var controller = ControllerGenerator.GetRectangleController(mockService.Object);

            mockService.Setup(i => i.RemoveRectangle(It.IsAny<Point>()))
              .Returns(new Rectangle(new Point(), 0, 0));


            var response = controller.Delete(request);
            var result = response as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result?.StatusCode);
        }
    }
}
