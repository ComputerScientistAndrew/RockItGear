using Microsoft.AspNet.Identity;
using RockItGear.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

namespace RockItGear.Account
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<RockItGear.Models.Order> Grid_OrderList_GetData()
        {
            var _db = new RockItGear.Models.ProductContext();
            IQueryable<Order> query = _db.Orders;

            string username = Context.User.Identity.GetUserName().ToString();
            query = query.Where(p => p.Username == username).OrderByDescending(p => p.OrderId);

            if(query.Any())
            {
                return query;
            }
            else
            {
                return null;
            }
            
        }
    }
}