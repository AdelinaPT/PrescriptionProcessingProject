using System;
using System.Collections.Generic;

namespace PrescriptionProcessing.Models.DBObjects
{
    public partial class Employee
    {
        public Guid IdEmployee { get; set; }
        public string Name { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateTime? DateStarted { get; set; }
        public DateTime? EndDate { get; set; }
        public string? JobDescription { get; set; }
    }
}
