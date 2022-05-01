using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly DataContext _context;

        public InfoController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<Info>> Get()
        {
            return Ok(await _context.Infos.ToListAsync());
        }
    }
}
