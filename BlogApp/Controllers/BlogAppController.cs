using Microsoft.AspNetCore.Mvc;
using BlogApp.DbContextData;
using BlogApp.Repository;
using BlogApp.Models;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAppController : ControllerBase
    {
        private readonly BlogAppDbContext _context;
        public BlogAppController(BlogAppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddContent")]
        public async Task<IActionResult> AddContent(ContentDto req)
        {
            var service = new ContentRepo(_context);
            var response = await service.AddContent(req);
            return Ok("Content addedd successfully");
        }

        [HttpGet("GetAllContent")]
        public async Task<IActionResult> GetAllContents()
        {
            var service = new ContentRepo(_context);
            var response = await service.GetAllContents();
            return Ok(response);
        }

        [HttpGet("GetContent")]
        public async Task<IActionResult> GetContent(string Id)
        {
            var service = new ContentRepo(_context);
            var response = await service.GetContent(Id);
            return Ok(response);
        }

        [HttpPatch("UpdateContent")]
        public async Task<IActionResult> UpdateContent(string Id, ContentDto req)
        {
            var service = new ContentRepo(_context);
            var response = await service.UpdateContent(Id, req);
            return Ok(response);
        }

        [HttpDelete("DeleteContent")]
        public async Task<IActionResult> DeleteContent(string Id)
        {
            var service = new ContentRepo(_context);
            var response = await service.DeleteContent(Id);
            return Ok(response);
        }



    }
}
