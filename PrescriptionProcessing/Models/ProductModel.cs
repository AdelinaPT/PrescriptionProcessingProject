using System.ComponentModel.DataAnnotations;

namespace PrescriptionProcessing.Models
{
    public class ProductModel
    {
        public Guid IdProduct { get; set; }
        public string ProductName { get; set; } = null!;
        public string ActiveIngredients { get; set; } = null!;
        public decimal PriceUnit { get; set; }
        public int Stock { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime Bbd { get; set; }
    }
}
