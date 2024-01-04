using szamonkeres_01._04.Models;
using szamonkeres_01._04.Models.DTOs;
using szamonkeres_01._04.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace szamonkeres_01._04.Models
{
    [Route("CreditCard")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardInterface creditCardInterface;

        public CreditCardController(ICreditCardInterface creditCardInterface)
        {
            this.creditCardInterface = creditCardInterface;
        }

        [HttpPost]
        public async Task<ActionResult<CreditCardDto>> Post(CreateCreditCardDto createCreditCardDto)
        {
            var result = await creditCardInterface.Post(createCreditCardDto);

            if (result == null) return StatusCode(404, "No owner found");

            return StatusCode(201, result);

        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<CreditCard>> Get()
        {
            return await creditCardInterface.Get();
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<CreditCard>> GetById(Guid id)
        {
            var result = await creditCardInterface.GetById(id);

            if (result == null) return StatusCode(404, "Card not found");

            return StatusCode(200, result);
        }

        [HttpGet("GetOwnerById")]
        public async Task<ActionResult<CreditCard>> GetOwnerById(Guid id)
        {
            var result = await creditCardInterface.GetOwnerById(id);

            if (result == null) return StatusCode(404, "Card not found");

            return StatusCode(200, result);
        }

        [HttpDelete]
        public async Task<ActionResult<CreditCard>> DeleteById(Guid id)
        {
            var result = await creditCardInterface.DeleteById(id);

            if (result == null) return StatusCode(404, "Card not found");

            return StatusCode(200, result);
        }

        [HttpPut]
        public async Task<ActionResult<CreditCard>> Put(Guid id, UpdateCreditCardDto updateCreditCardDto)
        {
            var result = await creditCardInterface.Put(id, updateCreditCardDto);

            if (result == null) return StatusCode(404, "Card not found");

            return StatusCode(200, result);
        }
    }
}
