namespace PrescriptionProcessing.ViewModel
{
    public class PrescriptionViewModel
    {
        public Guid IdPrescription { get; set; }
        public Guid IdEmployee { get; set; }
        public string Name { get; set; } = null!;
        public Guid IdOrder { get; set; }
        public string IssuedBy { get; set; } = null!;
        public string Details { get; set; } = null!;
        public string Status { get; set; } = null!;

    }
}
