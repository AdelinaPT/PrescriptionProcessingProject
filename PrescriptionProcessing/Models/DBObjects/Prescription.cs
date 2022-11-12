using System;
using System.Collections.Generic;

namespace PrescriptionProcessing.Models.DBObjects
{
    public partial class Prescription
    {
        public Guid IdPrescription { get; set; }
        public Guid IdEmployee { get; set; }
        public Guid IdOrder { get; set; }
        public string Details { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
        public virtual Order IdOrderNavigation { get; set; } = null!;
    }
}
