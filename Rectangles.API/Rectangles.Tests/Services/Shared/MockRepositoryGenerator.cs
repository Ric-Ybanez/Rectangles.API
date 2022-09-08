using Moq;
using Rectangles.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangles.Tests.Services.Shared
{
    public static class MockRepositoryGenerator
    {
        public static Mock<IRectangleRepository> GetMockRectangleRepository() => new Mock<IRectangleRepository>();
    }
}
