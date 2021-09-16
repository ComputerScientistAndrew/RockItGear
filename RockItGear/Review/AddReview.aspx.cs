using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using RockItGear.Models;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Validation;

namespace RockItGear
{
    public partial class AddReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["ProductID"]))
            {
                int productID = 0;
                
                Int32.TryParse(Request.QueryString["ProductID"].ToString(), out productID);
                using (ProductContext _db = new ProductContext())
                {
                    try
                    {
                        var thisProduct = (from p in _db.Products where p.ProductID == productID select p).FirstOrDefault();
                        ProductName.Text = thisProduct.ProductName;
                                                
                    }
                    catch (Exception exp)
                    {
                        throw new Exception("Error: Unable to add product review - " + exp.Message.ToString(), exp);
                    }
                }
            }
            else
            {
                Debug.Fail("ERROR: We should never get to AddReview.aspx without a product id!");
                throw new Exception("Error : AddReview.aspx cannot be loaded without setting a Product Id.");
            }
        }

        protected void ReviewAddButton_Click(object sender, ImageClickEventArgs e)
        {            
            if(Page.IsValid == true)
            {
                int productId = Int32.Parse(Request["productID"]);
                int rating = Rating1.CurrentRating;

                using (ProductContext _db = new ProductContext())
                {
                    
                    try
                    {
                        Review newReview = new Review
                        {
                            ReviewID = Guid.NewGuid().ToString(),
                            ProductID = productId,
                            Rating = rating,                            
                            CustomerName = HttpUtility.HtmlEncode(Name.Text),                            
                            CustomerEmail = Context.User.Identity.GetUserName(),
                            Comment = HttpUtility.HtmlEncode(UserComment.Text),
                            DateCreated = DateTime.Now,

                        };

                        _db.Reviews.Add(newReview);
                        _db.SaveChanges();
                    }
                    catch (Exception exp)
                    {
                        
                        throw new Exception("ERROR: Unable to save Review - " + exp.Message.ToString(), exp);
                    }

                    Server.Transfer("~/ProductDetails.aspx?ProductID=" + productId);

                }
                Response.Redirect("~/ProductList.aspx");
            }
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
       
    }
}