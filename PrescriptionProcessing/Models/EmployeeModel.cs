using System.ComponentModel.DataAnnotations;

namespace PrescriptionProcessing.Models
{
    public class EmployeeModel
    {
        public Guid IdEmployee { get; set; }
        public string Name { get; set; } = null!;
        public string Position { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? DateStarted { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public string? JobDescription { get; set; }
    }
}
