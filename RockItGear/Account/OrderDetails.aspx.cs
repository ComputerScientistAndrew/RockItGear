using Microsoft.AspNet.Identity;
using RockItGear.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RockItGear.Account
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<RockItGear.Models.Order> GetOrder()
        {
            var _db = new RockItGear.Models.ProductContext();
            IQueryable<Order> query = _db.Orders;

            string username = Context.User.Identity.GetUserName().ToString();
            query = query.Where(p => p.Username == username).OrderByDescending(p => p.OrderId);

            if (query.Any())
            {
                return query;
            }
            else
            {
                return null;
            }

        }

        public IQueryable<RockItGear.Models.OrderDetail> GetOrderDetail([QueryString("OrderId")] int? orderId)
        {
            var _db = new RockItGear.Models.ProductContext();
            IQueryable<OrderDetail> query = _db.OrderDetails;
                        
            query = query.Where(p => p.OrderId == orderId);

            return query;
            

        }

        public string GetProductName(int productId)
        {
            var _db = new RockItGear.Models.ProductContext();
            IQueryable<Product> query = _db.Products;

            var thisProduct = (from p in _db.Products where p.ProductID == productId select p).FirstOrDefault();
            return thisProduct.ProductName.ToString();
        }

        public string GetImage(int productId)
        {
            var _db = new RockItGear.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            var thisProduct = (from p in _db.Products where p.ProductID == productId select p).FirstOrDefault();
            return "~/Catalog/Images/Thumbs/" + thisProduct.ImagePath.ToString();

        }
    }
}