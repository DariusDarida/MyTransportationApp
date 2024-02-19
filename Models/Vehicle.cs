namespace MyTransportationApp.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string RegistrationNumber { get; set; }
        public int? TransporterID { get; set; }
        public Transporter? Transporter { get; set; } //navigation property
    }
}
