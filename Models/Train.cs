namespace MyTransportationApp.Models
{
    public class Train
    {
        public int ID { get; set; }
        public string TrainCode { get; set; }
        public int? TransporterID { get; set; }
        public Transporter? Transporter { get; set; } //navigation property
    }
}
