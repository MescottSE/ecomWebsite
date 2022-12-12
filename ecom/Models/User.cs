using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ecom.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string email { get; set; }
        public string Access_level { get; set; }
    }
}
