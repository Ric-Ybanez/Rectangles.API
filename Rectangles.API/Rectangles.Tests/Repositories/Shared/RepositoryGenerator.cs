using Rectangles.Repository.Repositories;

namespace Rectangles.Tests.Repositories.Shared
{
    public static class RepositoryGenerator
    {
        public static RectangleRepository GetRectangleRepository() => new RectangleRepository();
    }
}
