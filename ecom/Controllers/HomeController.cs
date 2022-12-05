using ecom.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace ecom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlReader;
        SqlConnection dbConnection = new SqlConnection();
        List<Product> products = new List<Product>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            dbConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-ecom-0035D4FD-FB3B-4E0E-9AC8-877EB8521E9E;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public async Task<IActionResult> Index()
        {
            fetchProducts();
            return View(products);
        }

        private void fetchProducts()
        {
            try
            {
                dbConnection.Open();
                sqlCommand.Connection = dbConnection;
                sqlCommand.CommandText = "Select * From Product";
                sqlReader = sqlCommand.ExecuteReader();


                if(products.Count > 0)
                {
                    products.Clear();
                }
                while (sqlReader.Read())
                {
                    products.Add(new Product() {
                        id = Convert.ToInt32(sqlReader["id"]),
                        product_name = sqlReader["product_name"].ToString(),
                        description = sqlReader["description"].ToString(),
                        brand = sqlReader["brand"].ToString(),
                        price = Convert.ToDouble(sqlReader["price"]),
                        quantity = Convert.ToInt32(sqlReader["quantity"]),
                        discount = Convert.ToInt32(sqlReader["discount"]),
                        image = sqlReader["image"].ToString(),
                        category = sqlReader["category"].ToString()
                        
                    });
                }
                dbConnection.Close();
            }catch (Exception ex){
                throw ex;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Computers()
        {
            fetchProducts();
            return View(products);
        }

        public IActionResult Gaming()
        {
            fetchProducts();
            return View(products);
        }

        public IActionResult Phones()
        {
            fetchProducts();
            return View(products);
        }

        public IActionResult Televisions()
        {
            fetchProducts();
            return View(products);
        }

        public IActionResult Toys()
        {
            fetchProducts();
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}