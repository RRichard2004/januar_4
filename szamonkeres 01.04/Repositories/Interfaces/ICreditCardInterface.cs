using szamonkeres_01._04.Models.DTOs;
using szamonkeres_01._04.Models;

namespace szamonkeres_01._04.Repositories.Interfaces
{
    public interface ICreditCardInterface
    {
        Task<IEnumerable<CreditCard>> Get();
        Task<CreditCard> GetById(Guid id);
        Task<Person> GetOwnerById(Guid id);
        Task<CreditCardDto> Post(CreateCreditCardDto createCreditCardDto);
        Task<CreditCard> Put(Guid id, UpdateCreditCardDto updateCreditCardDto);
        Task<CreditCard> DeleteById(Guid id);
    }
}
