namespace MyTransportationApp.Models
{
    public class Transporter
    {
        public int ID { get; set; }
        public string TransporterName { get; set; }
        public int? CountryID { get; set; }
        public Country? Country { get; set; } //navigation property
        public ICollection<Train>? Train { get; set; } //navigation property
        public ICollection<Vehicle>? Vehicle { get; set; } //navigation property
    }
}
