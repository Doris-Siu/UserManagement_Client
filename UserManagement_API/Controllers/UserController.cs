using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement_Client.VM;
using UserManagement_Data;
using UserManagement_Data.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement_API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            var response = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(_dbContext.Users);
            return response;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<UserDTO> Get(long id)
        {

            var obj = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (obj != null)
            {
                return _mapper.Map<User, UserDTO>(obj);
            }
            return new UserDTO();


            //// POST api/values
            //    [HttpPost]



            //// PUT api/values/5
            //[HttpPut("{id}")]
            //public void Put(int id, [FromBody]string value)
            //{
            //}

            //// DELETE api/values/5
            //[HttpDelete("{id}")]
            //public void Delete(int id)
            //{
            //}
        }
    }
}
