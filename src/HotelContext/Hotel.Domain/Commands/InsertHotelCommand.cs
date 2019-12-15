using System.Collections.Generic;
using Hotel.Domain.Core.Commands;

namespace Hotel.Domain.Commands
{
    public class InsertHotelCommand : ICommand
    {
        public InsertHotelCommand(string name, string description, double rating, string street, string number, string zipCode, string state, string city, string featureDescriptions)
        {
            Name = name;
            Description = description;
            Rating = rating;
            Street = street;
            Number = number;
            ZipCode = zipCode;
            State = state;
            City = city;
            FeatureDescriptions = featureDescriptions;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Rating { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string ZipCode { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string FeatureDescriptions { get; private set; }
        
    }
}