using Flunt.Validations;
using Hotel.Domain.Core.ValueObjects;

namespace Hotel.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string zipCode, string state, string city)
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
            State = state;
            City = city;

            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Street, "Hotel.Street", "A rua é obrigatória")
                .IsNotNullOrEmpty(Number, "Hotel.Number", "O número é obrigatório")
                .IsNotNullOrEmpty(ZipCode, "Hotel.ZipCode", "A cep é obrigatório")
                .IsNotNullOrEmpty(State, "Hotel.State", "O estado é obrigatório")
                .IsNotNullOrEmpty(City, "Hotel.City", "A cidade é obrigatório")
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string ZipCode { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
    }
}