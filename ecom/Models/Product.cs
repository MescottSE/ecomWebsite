using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ecom.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string product_name { get; set; }
        public string description { get; set; }
        public string brand { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public int discount { get; set; }
        public string image { get; set; }

    }
}
