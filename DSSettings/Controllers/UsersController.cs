using DSSettings.Models.Repository;
using DSSettings.Models.UserPermission;
using DSSettings.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSSettings.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDataRepository<User> _dataRepository;

        public UsersController(IDataRepository<User> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _dataRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(long id)
        {
            User user = _dataRepository.Get(id);

            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("USer data is null.");
            }

            _dataRepository.Add(user);
            _dataRepository.Save();
            return CreatedAtRoute(
                  "GetUserById",
                  new { user.Id },
                  user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Message is null.");
            }

            User userToUpdate = _dataRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            var service = new UserService();
            service.Update(userToUpdate, user);
            _dataRepository.Save();
            return Ok(userToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            User user = _dataRepository.Get(id);
            if (user == null)
            {
                return NotFound("The User record couldn't be found.");
            }

            _dataRepository.Delete(user);
            _dataRepository.Save();
            return Ok();
        }
    }
}