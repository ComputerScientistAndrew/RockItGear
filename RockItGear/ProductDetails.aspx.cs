using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using RockItGear.Models;
using System.Web.ModelBinding;
using System.Text.RegularExpressions;

namespace RockItGear
{
    public partial class ProductDetails : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<Product> GetProduct(
        [QueryString("ProductID")] int? productId,
        [RouteData] string productName)
        {
            var _db = new RockItGear.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductID == productId);
            }
            else if (!String.IsNullOrEmpty(productName))
            {
                query = query.Where(p =>
                      String.Compare(p.ProductName, productName) == 0);
            }
            else
            {
                query = null;
            }

            return query;
        }

        public IQueryable<Review> GetReviews(
        [QueryString("ProductID")] int? productId,
        [RouteData] string productName)
        {
            int id = 0;
            var _db = new RockItGear.Models.ProductContext();
            IQueryable<Review> query = _db.Reviews;

            if (!String.IsNullOrEmpty(productName))
            {
                var item = _db.Products.Where(i => i.ProductName == productName).Select(u => new { ProductID = u.ProductID }).Single();
                id = item.ProductID;
                productId = id;
            }
           
            
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductID == productId).OrderByDescending(p => p.Rating);
                int count = query.Count();
            }
            else
            {
                query = null;
            }

            return query;
        }

        public string MaskEmail(string email)
        {
            string pattern = @"(?<=[\w]{1})[\w-\._\+%]*(?=[\w]{1}@)";
            return Regex.Replace(email, pattern, m => new string('*', m.Length));
        }

        //Example of DataBound control
        protected void productDetail_DataBound(object sender, EventArgs e)
        {
            
            //Product item = (Product) productDetail.DataItem;
            //if (Enumerable.Range(1, 10).Contains(item.ProductID))
            //{
            //    productDetail.FindControl("sizeChart").Visible = true;
            //}
        }
    }
}