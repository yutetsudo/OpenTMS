using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenTMS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InitServerController : ControllerBase
    {
        private readonly DataContext _context;      
        public InitServerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Info>>> Get()
        {
            var dbInfo = await _context.Infos.ToListAsync();
            
            if (dbInfo.Count == 0)
            {
                Info info = new Info();
                info.Token = Guid.NewGuid().ToString();
                info.Type = "OpenTMS";
                info.Version = "0.1b";

                _context.Infos.Add(info);
                await _context.SaveChangesAsync();
                return Ok($"Successfully initialized Open Train Managment Server : Token = {info.Token}");
            }
            else
            {
                return BadRequest($"Server is alredy initialized : Token = {dbInfo[0].Token}");
            }
        }
    }
}
