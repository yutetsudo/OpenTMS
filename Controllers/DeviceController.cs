using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenTMS.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly DataContext _context;
        public DeviceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Device>>> Get()
        {
            return Ok(await _context.Devices.ToArrayAsync());
        }

        [HttpGet("{token}")]
        public async Task<ActionResult<Device>> Get(string token)
        {
            var device = await _context.Devices.FindAsync(token);
            if (device == null)
            {
                return NotFound($"Device {token} not found");
            }
            else
            {
                return Ok(device);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Device>>> Post(Device request)
        {
            _context.Devices.Add(request);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), request);
        }

        [HttpPut("{token}")]
        public async Task<ActionResult<Device>> Put(string token, Device request)
        {
            var device = await _context.Devices.FindAsync(token);
            if (device == null)
            {
                return NotFound($"Device {token} not found");
            }
            else
            {
                device.Type = request.Type;
                device.Address = request.Address;
                await _context.SaveChangesAsync();
                return Ok($"Succesfully modified {device.Type} {device.Token}");
            }
        }

        [HttpDelete("{token}")]
        public async Task<ActionResult<Device>> Delete(string token)
        {
            var device = await _context.Devices.FindAsync(token);
            if (device == null)
            {
                return NotFound($"Device {token} not found");
            }
            else
            {
                _context.Devices.Remove(device);
                await _context.SaveChangesAsync();
                return Ok($"Succesfully deleted {device.Type} {device.Token}");
            }
        }

    }
}
