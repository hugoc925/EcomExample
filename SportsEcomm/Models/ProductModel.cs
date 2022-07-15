using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsEcomm.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public float  price { get; set; }
        public string image { get; set; }

        public string description { get; set; }
        [ForeignKey("category")]
        public int categoryId { get; set; }
        public Category category { get; set; }

        public bool check { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imgPath { get; set; }

    }

    public class Inventory
    {
        public int id { get; set; }
        public int quantity { get; set; }

        [ForeignKey("product")]
        public int productId { get; set; }

        public Product product { get; set; }
        [ForeignKey("category")]
        public int categoryId { get; set; }
        public Category category { get; set; }

        public int reOrderLevel { get; set; }

    }

    public class ProductSold
    {
        public int id { get; set; }

        [ForeignKey("product")]
        public int productId { get; set; }

        public Product product { get; set; }
        public int quantity { get; set; }

        public float price { get; set; }
        public DateTime timeStamp { get; set; }
        [ForeignKey("sale")]
        public int saleId{get; set;}

        public Sale sale { get; set; }
    }
    public class Cart
    {
        public int id { get; set; }

        public float subTotal { get; set; }

        public decimal tax { get; set; }
        public float totalPrice { get; set; }

        public float cartQuantity { get; set; }

        [ForeignKey("product")]
        public int productId { get; set; }

        public Product product { get; set; }

        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public Category category { get; set; }

        public DateTime timeStamp { get; set; }

    }

    public class Sale
    {
        public int id { get; set; }
        public float subTotal { get; set; }

        public decimal tax { get; set; }
        public float totalPrice { get; set; }

        public DateTime purchaseDate { get; set; }

        
    }

    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) :base(options)
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Sale> sale { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<ProductSold> productSold { get; set; }
        public DbSet<Inventory> inventory { get; set; }
    }
}
