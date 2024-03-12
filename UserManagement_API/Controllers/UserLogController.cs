using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement_API.DtoModel;
using UserManagement_Data;
using UserManagement_Data.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement_API.Controllers
{
    [Route("api/[controller]")]
    public class UserLogController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserLogController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }



        // GET api/values/5
        [HttpGet]
        [Route("userId/{userId}")]
        public async Task<ActionResult<List<UserLogDTO?>>> Get(long userId)
        {

            var logs = await _dbContext.UserLogs.Where(u => u.UserId == userId).OrderByDescending(x=>x.Id).ToListAsync(); ;

            if (logs != null)
            {
                return Ok(_mapper.Map < List<UserLog>, List<UserLogDTO>> (logs));
            }
            return BadRequest();

        }



        // POST api/values
        [HttpPost]
        public async Task<ActionResult<UserLogDTO?>> Create([FromBody] UserLogDTO objDTO)
        {
            try
            {
                var obj = _mapper.Map<UserLogDTO, UserLog>(objDTO);
                var addedObj = _dbContext.UserLogs.Add(obj);
                await _dbContext.SaveChangesAsync();

                return Ok(_mapper.Map<UserLog, UserLogDTO>(addedObj.Entity));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
