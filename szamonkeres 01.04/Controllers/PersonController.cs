using szamonkeres_01._04.Models;
using szamonkeres_01._04.Models.DTOs;
using szamonkeres_01._04.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace szamonkeres_01._04.Models
{
    [Route("Person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonInterface personInterface;

        public PersonController(IPersonInterface personInterface)
        {
            this.personInterface = personInterface;
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> Post(CreatePersonDto createPersonDto)
        {
            return StatusCode(201, await personInterface.Post(createPersonDto));
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Person>> Get()
        {
            return await personInterface.Get();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Person>> GetById(Guid id)
        {
            var result = await personInterface.GetById(id);

            if (result == null) return StatusCode(404, "User not found");

            return StatusCode(200, result);
        }

        [HttpDelete]
        public async Task<ActionResult<Person>> DeleteById(Guid id)
        {
            var result = await personInterface.DeleteById(id);

            if (result == null) return StatusCode(404, "User not found");

            return StatusCode(200, result);
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Put(Guid id, UpdatePersonDto updatePersonDto)
        {
            var result = await personInterface.Put(id, updatePersonDto);

            if (result == null) return StatusCode(404, "User not found");

            return StatusCode(200, result);
        }
    }
}
