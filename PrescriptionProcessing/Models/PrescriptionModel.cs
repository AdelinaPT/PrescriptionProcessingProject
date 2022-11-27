using System.ComponentModel.DataAnnotations;

namespace PrescriptionProcessing.Models
{
    public class PrescriptionModel
    {
        public Guid IdPrescription { get; set; }
        
        public string Details { get; set; } = null!;
        public string Status { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? PickUpDate { get; set; }
        public decimal? Cost { get; set; }
    }
}
