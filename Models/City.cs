namespace MyTransportationApp.Models
{
    public class City
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public int? CountryID { get; set; }
        public Country? Country { get; set; } //navigation property
        public ICollection<Stop>? Stops { get; set; } //navigation property
    }
}
