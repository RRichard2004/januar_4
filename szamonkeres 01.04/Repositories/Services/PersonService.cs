using szamonkeres_01._04.Models;
using szamonkeres_01._04.Models.DTOs;
using szamonkeres_01._04.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace szamonkeres_01._04.Repositories.Services
{
    public class PersonService : IPersonInterface
    {
        private readonly PeopleDbContext dbContext;
        public PersonService(PeopleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<PersonDto> Post(CreatePersonDto createPersonDto)
        {
            var thatguy = new Person
            {
                Id = Guid.NewGuid(),
                FullName = createPersonDto.FullName,
                ZipCode = createPersonDto.ZipCode,
                Born = createPersonDto.Born,
            };

            await dbContext.Person.AddAsync(thatguy);
            await dbContext.SaveChangesAsync();

            return thatguy.AsDto();
        }
        public async Task<Person> DeleteById(Guid id)
        {
            var thatguy = dbContext.Person.FirstOrDefault(x => x.Id == id);

            if (thatguy != null)
            {
                dbContext.Person.Remove(thatguy);
                await dbContext.SaveChangesAsync();
                return thatguy;
            }
            else
            {
                return thatguy;
            }

        }

        public async Task<IEnumerable<Person>> Get()
        {
            return await dbContext.Person.ToListAsync();
        }


        public async Task<IEnumerable<CreditCard>> GetCards(Guid id)
        {
            var result = dbContext.CreditCard.Where(x => x.OwnerId == id);
            if (result.Any())
            {
                return await result.ToListAsync();
            }
            return new List<CreditCard>();
        }


        public async Task<Person> GetById(Guid id)
        {
            return await dbContext.Person.FirstOrDefaultAsync(x => x.Id == id);
        }

        
        public async Task<Person> Put(Guid id, UpdatePersonDto updatePersonDto)
        {
            var thatguy = dbContext.Person.FirstOrDefault(x => x.Id == id);

            if (thatguy != null)
            {
                thatguy.FullName = updatePersonDto.FullName;
                thatguy.ZipCode = updatePersonDto.ZipCode;
                thatguy.Born = updatePersonDto.Born;

                dbContext.Person.Update(thatguy);
                await dbContext.SaveChangesAsync();

                return thatguy;
            }
            else
            {
                return thatguy;
            }
        }
    }
}
