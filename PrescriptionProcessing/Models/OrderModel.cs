using System.ComponentModel.DataAnnotations;

namespace PrescriptionProcessing.Models
{
    public class OrderModel
    {
        public Guid IdOrder { get; set; }
        public string PrescriptionNumber { get; set; } = null!;
        public string PatientName { get; set; } = null!;
        public string Details { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTimeOffset? IssuedDate { get; set; }
        public string? Status { get; set; }
        public string? PickedUpBy { get; set; }
    }
}
