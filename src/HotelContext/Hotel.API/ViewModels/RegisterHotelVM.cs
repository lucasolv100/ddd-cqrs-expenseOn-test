namespace Hotel.API.ViewModels
{
    public class RegisterHotelVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string FeatureDescriptions { get; set; }
    }
}