using szamonkeres_01._04.Models;
using szamonkeres_01._04.Models.DTOs;

namespace szamonkeres_01._04.Repositories.Interfaces
{
    public interface IPersonInterface
    {
        Task<IEnumerable<Person>> Get();
        Task<IEnumerable<CreditCard>> GetCards(Guid Id);
        Task<Person> GetById(Guid id);
        Task<PersonDto> Post(CreatePersonDto createBlogUserDto);
        Task<Person> Put(Guid id, UpdatePersonDto updateBlogUserDto);
        Task<Person> DeleteById(Guid id);
    }
}
