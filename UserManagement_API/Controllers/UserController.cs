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
            var response = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(_dbContext.Users.OrderBy(x=>x.Id));
            return response;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO?>> Get(long id)
        {

            var obj = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (obj != null)
            {
                return Ok(_mapper.Map<User, UserDTO>(obj));
            }
            return Ok(new UserDTO());

        }
        // GET api/values/5
        [HttpGet]
        [Route("email/{email}/dateOfBirth/{dateOfBirth}")]
        public async Task<ActionResult<UserDTO?>> Get(string email, string dateOfBirth)
        {

            var obj = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower()
            && dateOfBirth == u.DateOfBirth);

            if (obj != null)
            {
                return Ok(_mapper.Map<User, UserDTO>(obj));
            }
            return NotFound();

        }
        // POST api/values
        [HttpPost]
        public async Task<ActionResult<UserDTO?>> Create([FromBody] UserDTO objDTO)
        {
            try
            {
                var obj = _mapper.Map<UserDTO, User>(objDTO);
                var addedObj = _dbContext.Users.Add(obj);
                await _dbContext.SaveChangesAsync();

                return Ok(_mapper.Map<User, UserDTO>(addedObj.Entity));
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO?>> Update([FromBody] UserDTO objDTO)
        {
            
                var objFromDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
                if (objFromDb != null)
                {
                    objFromDb.Forename = objDTO.Forename;
                    objFromDb.Surname = objDTO.Surname;
                    objFromDb.DateOfBirth = objDTO.DateOfBirth;
                    objFromDb.Email = objDTO.Email;
                    objFromDb.IsActive = objDTO.IsActive;

                _dbContext.Users.Update(objFromDb);
                    await _dbContext.SaveChangesAsync();
                    return Ok(_mapper.Map<User, UserDTO>(objFromDb));
                }
                return Ok(objDTO);
            }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var objFromDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (objFromDb != null)
            {
                _dbContext.Users.Remove(objFromDb);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

    }



}
