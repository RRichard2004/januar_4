using szamonkeres_01._04.Models;
using szamonkeres_01._04.Models.DTOs;

namespace szamonkeres_01._04
{
    public static class Extention
    {
        public static PersonDto AsDto(this Person person)
        {
            return new(person.Id, person.FullName, person.ZipCode, person.Born);
        }

        public static CreditCardDto AsCCDto(this CreditCard creditCard)
        {
            return new(creditCard.Id, creditCard.NameOnCard, creditCard.CardNumber, creditCard.Cvv, creditCard.OwnerId);
        }
    }
}
