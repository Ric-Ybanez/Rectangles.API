using Microsoft.AspNetCore.Mvc;
using Moq;
using Rectangles.Common.Request;
using Rectangles.Tests.Controllers.Shared;
using System;
using Xunit;

namespace Rectangles.Tests.Controllers
{
    public class GridControllerTest
    {
        [Fact]
        public void Post_ReturnsBadRequest()
        {
            var request = new InitializeGridRequest();

            var mockService = MockServiceGenerator.GetMockGridService();
            var controller = ControllerGenerator.GetGridController(mockService.Object);

            mockService.Setup(i => i.InitializeGrid(It.IsAny<int>(), It.IsAny<int>()))
             .Throws<ArgumentException>();

            var response = controller.Post(request);
            var result = response as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Post_ReturnsOk()
        {
            var request = new InitializeGridRequest();

            var mockService = MockServiceGenerator.GetMockGridService();
            var controller = ControllerGenerator.GetGridController(mockService.Object);

            var response = controller.Post(request);
            var result = response as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result?.StatusCode);
        }
    }
}
