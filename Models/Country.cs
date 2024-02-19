namespace MyTransportationApp.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public string IsoCode { get; set; }
        public ICollection<City>? Cities { get; set; } //navigation property
        public ICollection<Transporter>? Transporters { get; set; } //navigation property
    }
}
