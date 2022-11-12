namespace PrescriptionProcessing.Models
{
    public class EmployeeModel
    {
        public Guid IdEmployee { get; set; }
        public string Name { get; set; } = null!;
        public string Position { get; set; } = null!;
    }
}
