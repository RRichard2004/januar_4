using szamonkeres_01._04.Models;
using szamonkeres_01._04.Models.DTOs;
using szamonkeres_01._04.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace szamonkeres_01._04.Repositories.Services
{
    public class CreditCardService : ICreditCardInterface
    {
        private readonly PeopleDbContext dbContext;
        public CreditCardService(PeopleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CreditCardDto> Post(CreateCreditCardDto createCreditCardDto)
        {
            var owner = dbContext.Person.FirstOrDefault(x => x.Id == createCreditCardDto.OwnerId);
            
            if (owner != null)
            {
                var cc = new CreditCard
                {
                    Id = Guid.NewGuid(),
                    NameOnCard = owner.FullName,
                    CardNumber = createCreditCardDto.CardNumber,
                    Cvv = createCreditCardDto.Cvv,
                    OwnerId = createCreditCardDto.OwnerId,
                    Person = owner
                };

                await dbContext.CreditCard.AddAsync(cc);
                await dbContext.SaveChangesAsync();

                return cc.AsCCDto();
            }
            else
            {
                return null;
            }
        }
        public async Task<CreditCard> DeleteById(Guid id)
        {
            var cc = dbContext.CreditCard.FirstOrDefault(x => x.Id == id);

            if (cc != null)
            {
                dbContext.CreditCard.Remove(cc);
                await dbContext.SaveChangesAsync();
                return cc;
            }
            else
            {
                return cc;
            }

        }

        public async Task<IEnumerable<CreditCard>> Get()
        {
            return await dbContext.CreditCard.ToListAsync();
        }

        public async Task<CreditCard> GetById(Guid id)
        {
            return await dbContext.CreditCard.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Person> GetOwnerById(Guid id)
        {
            var card = dbContext.CreditCard.FirstOrDefaultAsync(x => x.Id == id).Result.OwnerId;
            return await dbContext.Person.FirstOrDefaultAsync(x => x.Id == card);
        }

        public async Task<CreditCard> Put(Guid id, UpdateCreditCardDto updateCreditCardDto)
        {
            var cc = dbContext.CreditCard.FirstOrDefault(x => x.Id == id);

            if (cc != null)
            {
                cc.NameOnCard = updateCreditCardDto.NameOnCard;
                cc.OwnerId = updateCreditCardDto.OwnerId;

                dbContext.CreditCard.Update(cc);
                await dbContext.SaveChangesAsync();

                return cc;
            }
            else
            {
                return cc;
            }
        }
    }
}
