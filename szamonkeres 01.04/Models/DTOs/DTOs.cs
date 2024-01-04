namespace szamonkeres_01._04.Models.DTOs
{
    public record PersonDto(Guid Id, string FullName, int ZipCode, DateTime Born);
    public record CreatePersonDto(string FullName, int ZipCode, DateTime Born);
    public record UpdatePersonDto(string FullName, int ZipCode, DateTime Born);

    public record CreditCardDto(Guid id, string CardNumber, string NameOnCard, string Cvv, Guid OwnerId);
    public record CreateCreditCardDto(string CardNumber, string Cvv, Guid OwnerId);
    public record UpdateCreditCardDto(string NameOnCard, Guid OwnerId);
}
