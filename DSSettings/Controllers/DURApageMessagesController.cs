using DSSettings.Models.durapage;
using DSSettings.Models.Repository;
using DSSettings.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSSettings.Controllers
{
    [Route("api/durapage/messages")]
    [ApiController]
    public class DURApageMessagesController : ControllerBase
    {
        private readonly IDataRepository<DURApageMessage> _dataRepository;

        public DURApageMessagesController(IDataRepository<DURApageMessage> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var messages = _dataRepository.GetAll();
            return Ok(messages);
        }

        [HttpGet("{id}", Name = "GetDuraPageMessagesById")]
        [ProducesResponseType(typeof(DURApageMessage), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(long id)
        {
            DURApageMessage message = _dataRepository.Get(id);

            if (message == null)
            {
                return NotFound("The DURApage Message record couldn't be found.");
            }

            return Ok(message);
        }

        [HttpPost]
        public IActionResult Post([FromBody] DURApageMessage message)
        {
            if (message == null)
            {
                return BadRequest("Message is null.");
            }

            _dataRepository.Add(message);
            _dataRepository.Save();
            return CreatedAtRoute(
                  "GetDuraPageMessagesById",
                  new { message.Id },
                  message);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] DURApageMessage message)
        {
            if (message == null)
            {
                return BadRequest("Message is null.");
            }

            DURApageMessage messageToUpdate = _dataRepository.Get(id);
            if (messageToUpdate == null)
            {
                return NotFound("The DURApage Message record couldn't be found.");
            }

            var service = new DURApageMessageService();
            service.Update(messageToUpdate, message);
            _dataRepository.Save();
            return Ok(messageToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            DURApageMessage message = _dataRepository.Get(id);
            if (message == null)
            {
                return NotFound("The DURApage Message record couldn't be found.");
            }

            _dataRepository.Delete(message);
            _dataRepository.Save();
            return Ok();
        }
    }
}