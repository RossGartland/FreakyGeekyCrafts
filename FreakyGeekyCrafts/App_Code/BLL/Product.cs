using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreakyGeekyCrafts.App_Code.DAL;

namespace FreakyGeekyCrafts.App_Code.BLL
{


    public class Product
    {
        int strProductID;
        private string strProductName, strProductDesc;
        private string strImageFile;
        private double dblPrice;
        private int intStock;

        public Product()
        {

        }

        public Product(String name, String description, String imageFile, double price, int stock)
        {
            this.strProductName = name;
            this.strProductDesc = description;
            this.strImageFile = imageFile;
            this.dblPrice = price;
            this.intStock = stock;
        }

        public int getStrProductID()
        {
            return strProductID;
        }
        public void setStrProductID(int pProductID)
        {
            strProductID = pProductID;
        }
        public string getStrProductName()
        {
            return strProductName;
        }
        public void setStrProductName(string pProductName)
        {
            strProductName = pProductName;
        }
        public string getStrProductDesc()
        {
            return strProductDesc;
        }
        public void setStrProductDesc(string pDescription)
        {
            strProductDesc = pDescription;
        }

        public string getStrImageFile()
        {
            return strImageFile;
        }
        public void setStrImageFile(string pImageFile)
        {
            strImageFile = pImageFile;
        }

        public double getDblPrice()
        {
            return dblPrice;
        }

        public void setDblPrice(double pPrice)
        {
            dblPrice = pPrice;
        }
        public void setIntStock(int pStock)
        {
            intStock = pStock;
        }
        public int getIntStock()
        {
            return intStock;
        }

        public void loadProduct(int pProductID)
        {
            Product tmpProduct = DataAccess.getProduct(pProductID);
            strProductID = tmpProduct.getStrProductID();
            strProductName = tmpProduct.getStrProductName();
            strProductDesc = tmpProduct.getStrProductDesc();
            strImageFile = tmpProduct.getStrImageFile();
            dblPrice = tmpProduct.getDblPrice();
            intStock = tmpProduct.getIntStock();
        }//loadProduct

        public static void addProduct(String type, String name, String description, double price, String imageFile, int stock)
        {
            DataAccess.addProduct(type, name, description, price, imageFile, stock);
        }


        public static void updateProduct(int id, String name, double price, String description)
        {
            DataAccess.updateProduct(id,name,price,description);
        }

        public static void restock(int id)
        {
            DataAccess.restock(id);
        }

        public static void updateImage(String imgPath, int id)
        {
            DataAccess.updateImage(imgPath, id);
        }

        public static void deleteProduct(int id)
        {
            DataAccess.deleteProduct(id);
        }
    }
}