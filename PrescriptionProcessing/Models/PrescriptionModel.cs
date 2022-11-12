namespace PrescriptionProcessing.Models
{
    public class PrescriptionModel
    {
        public Guid IdPrescription { get; set; }
        public Guid IdEmployee { get; set; }
        public Guid IdOrder { get; set; }
        public string Details { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
