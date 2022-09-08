using Rectangles.Repository.Contracts;
using Rectangles.Service.Services;

namespace Rectangles.Tests.Services.Shared
{
    public static class ServiceGenerator
    {
        public static GridService GetGridService(IRectangleRepository repository) => new GridService(repository);
    }
}
