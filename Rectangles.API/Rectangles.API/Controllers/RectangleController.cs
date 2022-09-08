using Microsoft.AspNetCore.Mvc;
using Rectangles.Common.Models;
using Rectangles.Common.Request;
using Rectangles.Service.Contracts;

namespace Rectangles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectangleController : ControllerBase
    {
        private readonly IGridService _gridService;
        public RectangleController(IGridService gridService)
        {
            _gridService = gridService;
        }

        [HttpPost("search")]
        public ActionResult Search([FromBody] Point point)
        {
            try
            {
                var rectangle = _gridService.SearchRectangle(point);

                if (rectangle == null)
                    return NotFound($"Rectangle with Point X: {point.X} and Point Y: {point.Y} could not be found!");

                return Ok(rectangle);
            }
            catch (ArgumentException aex)
            {

                return BadRequest(aex.Message);
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var rectangles = _gridService.GetAllRectangles();
                return Ok(rectangles);
            }
            catch (ArgumentException aex)
            {

                return BadRequest(aex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(CreateRectangleRequest request)
        {
            try
            {
                var rectangle = _gridService.PlaceRectangle(request);
                return Ok($"Sucessfully placed Rectangle with Id: {rectangle.Id}");
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
        }


        [HttpDelete]
        public ActionResult Delete([FromBody] Point point)
        {
            try
            {
                var rectangle = _gridService.RemoveRectangle(point);
                return Ok($"Sucessfully removed Rectangle with Id: {rectangle.Id}");
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
        }
    }
}
