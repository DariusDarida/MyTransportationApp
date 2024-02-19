namespace MyTransportationApp.Models
{
    public class Stop
    {
        public int ID { get; set; }
        public string StopName { get; set; }
        public int? CityID { get; set; }
        public City? City { get; set; } //navigation property
    }
}
