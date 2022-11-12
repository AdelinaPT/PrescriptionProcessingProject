using System;
using System.Collections.Generic;

namespace PrescriptionProcessing.Models.DBObjects
{
    public partial class Order
    {
        public Order()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        public Guid IdOrder { get; set; }
        public string PrescriptionNumber { get; set; } = null!;
        public string IssuedBy { get; set; } = null!;
        public string Details { get; set; } = null!;

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
