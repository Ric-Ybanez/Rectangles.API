using Moq;
using Rectangles.Service.Contracts;

namespace Rectangles.Tests.Controllers.Shared
{
    public static class MockServiceGenerator
    {
        public static Mock<IGridService> GetMockGridService() => new Mock<IGridService>();
    }
}
