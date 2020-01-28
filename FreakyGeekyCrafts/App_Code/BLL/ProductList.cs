using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FreakyGeekyCrafts.App_Code.DAL;

namespace FreakyGeekyCrafts.App_Code.BLL
{
    public class ProductList
    {
        public static DataSet getProducts()
        {
            return DataAccess.getProducts();
        }//getProducts

        public static String[] getProductNames()
        {
            return DataAccess.getProductNames();
        }

        public static void changeStock(int id, int stockDecrease)
        {
            DataAccess.changeStock(id, stockDecrease);
        }

    }
}