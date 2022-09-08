using Microsoft.AspNetCore.Mvc;
using Rectangles.Common.Models;
using Rectangles.Common.Request;
using Rectangles.Service.Contracts;

namespace Rectangles.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GridController : ControllerBase
    {
        private readonly IGridService _gridService;
        public GridController(IGridService gridService)
        {
            _gridService = gridService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] InitializeGridRequest request)
        {
            try
            {
                _gridService.InitializeGrid(request.Width, request.Height);
                return Ok($"Grid Succesfully Initialize with Width: {request.Width} and Height: {request.Height}");
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
           
        }
    }
}
