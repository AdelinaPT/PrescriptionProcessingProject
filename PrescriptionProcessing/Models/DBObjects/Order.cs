using System;
using System.Collections.Generic;

namespace PrescriptionProcessing.Models.DBObjects
{
    public partial class Order
    {
        public Guid IdOrder { get; set; }
        public string PrescriptionNumber { get; set; } = null!;
        public string PatientName { get; set; } = null!;
        public string Details { get; set; } = null!;
        public DateTimeOffset? IssuedDate { get; set; }
        public string? Status { get; set; }
        public string? PickedUpBy { get; set; }
    }
}
