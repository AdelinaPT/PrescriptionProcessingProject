namespace PrescriptionProcessing.Models
{
    public class OrderModel
    {
        public Guid IdOrder { get; set; }
        public string PrescriptionNumber { get; set; } = null!;
        public string IssuedBy { get; set; } = null!;
        public string Details { get; set; } = null!;
    }
}
