using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_API.Request;
using Test_API.Response;
using Test_BusinessLogic;
using Test_DataAccess;

namespace Test_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitizenController : ControllerBase
    {
        private readonly CitizenDbContext _context;
        private readonly ILogger<CitizenController> _logger;
        private readonly IMapper _mapper;

        public CitizenController(CitizenDbContext context, ILogger<CitizenController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitizenResponse>>> GetAsync()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<CitizenResponse>>(await _context.Citizens.ToListAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CitizenResponse>> GetAsync(long id)
        {
            try
            {
                CitizenResponse? response = _mapper.Map<CitizenResponse>(await _context.Citizens.FindAsync(id));
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CitizenResponse>> PostAsync([FromBody] CitizenRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var citizen = await _context.Citizens.AddAsync(_mapper.Map<Citizen>(request));
                    await _context.SaveChangesAsync();
                    return Ok(_mapper.Map<CitizenResponse>(citizen.Entity));
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CitizenResponse>> PutAsync(long id, [FromBody]CitizenRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Citizen? citizen = await _context.Citizens.FindAsync(id);
                    if(citizen == null)
                    {
                        return NotFound();
                    }
                    _mapper.Map(request, citizen);
                    await _context.SaveChangesAsync();
                    return Ok(_mapper.Map<CitizenResponse>(citizen));
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CitizenResponse>> DeleteAsync(long id)
        {
            try
            {
                Citizen? citizen = await _context.Citizens.FindAsync(id);
                if (citizen == null)
                {
                    return NotFound();
                }
                _context.Citizens.Remove(citizen);
                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<CitizenResponse>(citizen));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex);
            }
        }
    }
}
