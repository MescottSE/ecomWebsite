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
        private readonly IHttpContextAccessor _contextAccessor;
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataReader sqlReader;
        SqlConnection dbConnection = new SqlConnection();
        List<Product> productsList = new List<Product>();
        List<Cart> cartList = new List<Cart>();
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor context)
        {
            _logger = logger;
            dbConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-ecom-0035D4FD-FB3B-4E0E-9AC8-877EB8521E9E;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _contextAccessor = context;
        }

        public async Task<IActionResult> Index()
        {

            fetchproductsList("SELECT TOP 4 * FROM product ORDER BY discount DESC");
            fetchCarts("SELECT * FROM cart WHERE customer_id = 1");
            ViewData["cartList"] = cartList;
            ViewData["productList"] = productsList;
            return View();
        }

        private void fetchCarts(String query)
        {
            try
            {
                dbConnection.Open();
                sqlCommand.Connection = dbConnection;
                sqlCommand.CommandText = query;
                sqlReader = sqlCommand.ExecuteReader();


                if (cartList.Count > 0)
                {
                    cartList.Clear();
                }
                while (sqlReader.Read())
                {
                    cartList.Add(new Cart()
                    {
                        Id = Convert.ToInt32(sqlReader["Id"]),
                        product_id = Convert.ToInt32(sqlReader["product_id"]),
                        customer_id = Convert.ToInt32(sqlReader["customer_id"])

                    });
                }
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void fetchproductsList(String query)
        {
            try
            {
                dbConnection.Open();
                sqlCommand.Connection = dbConnection;
                sqlCommand.CommandText = query;
                sqlReader = sqlCommand.ExecuteReader();


                if(productsList.Count > 0)
                {
                    productsList.Clear();
                }
                while (sqlReader.Read())
                {
                    productsList.Add(new Product() {
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

        public IActionResult addToCart()
        {
            fetchproductsList("SELECT * FROM product INNER JOIN cart ON product.id = cart.product_id");
            fetchCarts("SELECT * FROM cart WHERE customer_id = 1");
            ViewData["cartList"] = cartList;
            ViewData["productList"] = productsList;
            return View();
        }
        public IActionResult AllproductsList()
        {
            fetchproductsList("Select * From product");
            fetchCarts("SELECT * FROM cart WHERE customer_id = 1");
            ViewData["cartList"] = cartList;
            return View("AllProducts", productsList);
        }

        public IActionResult Computers()
        {
            fetchproductsList("Select * From Product Where category = 'Computers'");
            fetchCarts("SELECT * FROM cart WHERE customer_id = 1");
            ViewData["cartList"] = cartList;
            return View(productsList);
        }

        public IActionResult Gaming()
        {
            fetchproductsList("Select * From product Where category = 'Gaming'");
            fetchCarts("SELECT * FROM cart WHERE customer_id = 1");
            ViewData["cartList"] = cartList;
            return View(productsList);
        }

        public IActionResult Phones()
        {
            fetchproductsList("Select * From product Where category = 'Phones'");
            fetchCarts("SELECT * FROM cart WHERE customer_id = 1");
            ViewData["cartList"] = cartList;
            return View(productsList);
        }

        public IActionResult Televisions()
        {
            fetchproductsList("Select * From product Where category = 'Televisions'");
            fetchCarts("SELECT * FROM cart WHERE customer_id = 1");
            ViewData["cartList"] = cartList;
            return View(productsList);
        }

        public IActionResult Toys()
        {
            fetchproductsList("Select * From product Where category = 'Toys'");
            fetchCarts("SELECT * FROM cart WHERE customer_id = 1");
            ViewData["cartList"] = cartList;
            return View(productsList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}