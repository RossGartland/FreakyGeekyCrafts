using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreakyGeekyCrafts.App_Code.DAL;

namespace FreakyGeekyCrafts.App_Code.BLL
{
    public class Reviews
    {

        public Reviews()
        {

        }

        //Returns all reviews for a product.
        public static String[] returnReviews(String productID)
        {
            return DataAccess.returnReviews(productID);
        }

        //Adds review for a product.
        public static void addReview(String productID, String username, String review, String date)
        {
            DataAccess.addReview(productID, "Review", username, review, date);
        }

    }
}