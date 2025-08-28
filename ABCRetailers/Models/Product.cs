using Azure;
using Azure.Data.Tables;
using System.ComponentModel.DataAnnotations;
namespace ABCRetailers.Models
{
    public class Product : ITableEntity
    {
        public string PartitionKey { get; set; } = "Product";

        public string RowKey { get; set; } = Guid.NewGuid().ToString();

        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }

        [Display(Name = "Product ID")]

        public string ProductId => RowKey;

        [Required(ErrorMessage = "Product name is required")]
        [Display(Name = "Product Name")]

        public string ProductName { get; set; } = string.Empty;

        //description
        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]

        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]

        public string PriceString { get; set; } = string.Empty;

        [Display(Name ="Price")]

        public double Price
        {
            get
            {
                return double.TryParse(PriceString, out var result) ? result : 0;
            }
            set
            {
                PriceString = value.ToString("F2");
            }
        }
        

        

        [Required(ErrorMessage = "Stock available is required")]
        [Display(Name = "Stock Avilable")]

        public int StockAvailable { get; set; }

        [Display(Name = "Image URL")]

        public string ImageUrl { get; set; } = string.Empty;


    }
}
