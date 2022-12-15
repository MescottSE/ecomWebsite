using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ecom.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int product_id { get; set; }
        public String customer_id { get; set; }
    }
}
