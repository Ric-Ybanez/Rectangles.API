using Rectangles.API.Controllers;
using Rectangles.Service.Contracts;

namespace Rectangles.Tests.Controllers.Shared
{
    public static class ControllerGenerator
    {
        public static RectangleController GetRectangleController(IGridService service) => new RectangleController(service);
        public static GridController GetGridController(IGridService service) => new GridController(service);

    }
}
