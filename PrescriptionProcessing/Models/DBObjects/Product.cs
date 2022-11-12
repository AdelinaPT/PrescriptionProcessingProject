using System;
using System.Collections.Generic;

namespace PrescriptionProcessing.Models.DBObjects
{
    public partial class Product
    {
        public Guid IdProduct { get; set; }
        public string ProductName { get; set; } = null!;
        public string ActiveIngredients { get; set; } = null!;
        public decimal PriceUnit { get; set; }
        public int Stock { get; set; }
        public DateTime Bbd { get; set; }
    }
}
