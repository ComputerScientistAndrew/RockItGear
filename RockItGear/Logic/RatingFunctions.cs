using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RockItGear.Models;

namespace RockItGear.Logic
{
    public class RatingFunctions
    {
        public static string GetRatingAverage(int productId)
        {
            string avg = "";
      
            var _db = new RockItGear.Models.ProductContext();
            IQueryable<Review> query = _db.Reviews;      
            
            if (productId > 0)
            {
                query = query.Where(p => p.ProductID == productId).OrderByDescending(p => p.Rating);
                if (query.Count() > 0)
                {
                    var querySelect = new { Average = query.Average(x => x.Rating) };
                    avg = Math.Round(querySelect.Average).ToString();
                }
                else
                {
                    avg = "0";
                }
  
            }
            
            return $"/Images/reviewrating{avg}.jpg";
        }

        public static string GetRatingCount(int productId)
        {           
            var _db = new RockItGear.Models.ProductContext();
            IQueryable<Review> query = _db.Reviews;        
            
            if (productId > 0)
            {
                query = query.Where(p => p.ProductID == productId).OrderByDescending(p => p.Rating);
                return query.Count().ToString();


            }
            return "0";
        }
    }
}