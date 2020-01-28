using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using FreakyGeekyCrafts.App_Code.BLL;
using System.Data;
using System.Data.SqlClient;

namespace FreakyGeekyCrafts.App_Code.DAL
{
    public class DataAccess
    {
        private static OleDbConnection openConnection()
        {
            string configPath = "~";
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath);
            // declaring the connection string
            string conStr = null;
            // get the value(s) in the connection string
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                try
                {
                    conStr = rootWebConfig.ConnectionStrings.ConnectionStrings["conStr"].ToString();
                }
                catch (Exception ex)
                {
                    conStr = null;
                }
                if (conStr != null)
                {
                    HttpContext.Current.Trace.Warn("Connection string = \"{0}\"", conStr);
                    //Create an OleDbConnection object using the Connection String  
                    OleDbConnection conn = new OleDbConnection(conStr);
                    //Open the connection.   
                    conn.Open();
                    return conn;
                }
                else
                {
                    HttpContext.Current.Trace.Warn("No connection string");
                    return null;
                }
            }
            return null;
        }

        private static void closeConnection(OleDbConnection cn)
        {
            cn.Close();
        }//closeConnection

        public static DataSet getProducts()
        {
            OleDbConnection conn = openConnection();
            //create dataset (virtual database)
            DataSet dsFGC = new DataSet();
            string strSQL = "SELECT * FROM tblProducts";
            //data adapter is bridge between database and dataset
            OleDbDataAdapter daProducts = new OleDbDataAdapter(strSQL, conn);
            //populate the data table in the dataset 
            //with records from the database table
            daProducts.Fill(dsFGC, "dtProducts");
            conn.Close();
            return dsFGC;
        }//getProducts


        //Gets the names of all products in the database
        public static String[] getProductNames()
        {
            String[] productNames = new String[70];
            OleDbConnection conn = openConnection();
            string SQLstring = "SELECT ProductName, ProductID FROM tblProducts";
            OleDbCommand cmd = new OleDbCommand(SQLstring, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            int loop = 0;

            while (reader.Read())
            {
                productNames[loop] += (reader["ProductName"]);
                loop++;
                productNames[loop] += (reader["ProductID"]);
                loop++;
            }
            reader.Close();
            closeConnection(conn);
            return productNames;
        }

        //Updates selected product with new details
        public static void updateProduct(int id, String name, double price, String description)
        {
            OleDbConnection conn = openConnection();
            String sqlString = "UPDATE tblProducts SET ProductName = @name, ProductDesc = @desc, RetailPrice = @price WHERE ProductID = @id";
            OleDbCommand cmd = new OleDbCommand(sqlString, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@desc", description);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Retrieves details of selected item
        public static Product getProduct(int pProductID)
        {
            Product productObj = new Product();
            OleDbConnection conn = openConnection();
            string strSQL = "SELECT * FROM tblProducts WHERE ProductID = @id";
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@id", pProductID);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productObj.setStrProductID(Convert.ToInt32(reader["ProductID"]));
                productObj.setStrProductName(reader["ProductName"].ToString());
                productObj.setStrProductDesc(reader["ProductDesc"].ToString());
                productObj.setStrImageFile(reader["ImageFile"].ToString());
                productObj.setIntStock(Convert.ToInt32(reader["InStock"]));
                productObj.setDblPrice(Convert.ToDouble(reader["RetailPrice"]));
            }
            //while 
            reader.Close();
            closeConnection(conn);
            return productObj;
        }//getProduct

        //Checks that login details are valid so user can login
        public static UserLogin checkLogin(string email, string pwd)
        {
            OleDbConnection conn = openConnection();
            string strSQL = "select * FROM tblCustomers WHERE Email='" + email + "' and pwd='" + pwd + "'";
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            UserLogin custObj = null;
            while (reader.Read())
            {
                string id = reader["CustomerID"].ToString();
                string lastname = reader["LastName"].ToString();
                string firstname = reader["FirstName"].ToString();
                string address = reader["Address"].ToString();
                string postcode = reader["Postcode"].ToString();
                string city = reader["City"].ToString();
                string phone = reader["PhoneNumber"].ToString();
                string password = reader["pwd"].ToString();
                string status = reader["Status"].ToString();
                
                custObj = new UserLogin(id, email, lastname, firstname, address, city, postcode, phone, password, status);
            }
            reader.Close();
            closeConnection(conn);
            return custObj;
        }

        //Adds an invoice tied to an account after a purchase is made
        public static Invoice addInvoice(Invoice inv)
        {
            OleDbConnection conn = openConnection();
            string SQLstring = "INSERT INTO tblInvoices(CustomerID,OrderDate,Total) VALUES(@id,@date,@price) ";
            OleDbCommand cmd = new OleDbCommand(SQLstring, conn);
            cmd.Parameters.AddWithValue("@id", inv.getCustomerID());
            cmd.Parameters.AddWithValue("@date", inv.getpurchaseDate());
            cmd.Parameters.AddWithValue("@price", inv.gettotalPrice());
            cmd.ExecuteNonQuery();
            closeConnection(conn);
            return null;
        }

        //Gets the most recent invoice after a purchase is made
        public static Invoice getRecentInvoice()
        {
            Invoice invObj = new Invoice();
            OleDbConnection conn = openConnection();
            string SQLstring = "SELECT TOP 1 * FROM tblInvoices ORDER BY InvoiceNumber DESC";
            OleDbCommand cmd = new OleDbCommand(SQLstring, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                invObj.setInvoiceID(Convert.ToInt32(reader["InvoiceNumber"]));
                invObj.setCustomerID(Convert.ToInt32(reader["CustomerID"]));
                invObj.setpurchaseDate(reader["OrderDate"].ToString());
                invObj.settotalPrice(Convert.ToDouble(reader["Total"]));
            }
            reader.Close();
            closeConnection(conn);
            return invObj;
        }

        //Retrieves all invoices tied to a specific user so they can be displayed.
        public static String[] getAllUserInvoices(String userID)
        {
            String[] userInvoice = new String[100]; 
            OleDbConnection conn = openConnection();
            string SQLstring = "SELECT * FROM tblInvoices WHERE CustomerID = @id";           
            OleDbCommand cmd = new OleDbCommand(SQLstring, conn);
            cmd.Parameters.AddWithValue("@id", userID);
            OleDbDataReader reader = cmd.ExecuteReader();
            int loop = 0;

            while (reader.Read())
            {
                userInvoice[loop] += "Invoice Number: " + (reader["InvoiceNumber"] + " ");
                userInvoice[loop] += "Customer ID: " +(reader["CustomerID"] + " ");
                userInvoice[loop] += "Order Date: " +(reader["OrderDate"].ToString()) + " ";
                userInvoice[loop] += "Total: £" +(reader["Total"]);
                loop++;
            }
            reader.Close();
            closeConnection(conn);
            return userInvoice;
        }

        //Creates new login details for a user
        public static UserLogin register(UserLogin reg)
        {
            OleDbConnection conn = openConnection();
            string SQLstring = "INSERT INTO tblCustomers(Email, LastName, FirstName, Address, City, PostCode, PhoneNumber, pwd, Status) VALUES(@email, @lastname, @forename, @address, @city, @postcode, @phone, @password, @status)";
            OleDbCommand cmd = new OleDbCommand(SQLstring, conn);
            cmd.Parameters.AddWithValue("@email", reg.getEmail());
            cmd.Parameters.AddWithValue("@lastname", reg.getSurname());
            cmd.Parameters.AddWithValue("@forename", reg.getForename());
            cmd.Parameters.AddWithValue("@address", reg.getAddress());
            cmd.Parameters.AddWithValue("@city", reg.getCity());
            cmd.Parameters.AddWithValue("@postcode", reg.getPostcode());
            cmd.Parameters.AddWithValue("@phone", reg.getPhone());
            cmd.Parameters.AddWithValue("@password", reg.getPassword());
            cmd.Parameters.AddWithValue("@status", reg.getStatus());
            cmd.ExecuteNonQuery();
            closeConnection(conn);
            return null;
        }


        //Decreases the stock of an item whenever it is purchased
        public static void changeStock(int id, int stockDecrease)
        {
            OleDbConnection conn = openConnection();
            string SQLstring = "UPDATE tblProducts SET InStock = InStock - @stockDecrease WHERE ProductID = @id";
            OleDbCommand cmd = new OleDbCommand(SQLstring, conn);
            cmd.Parameters.AddWithValue("@stockDecrease", stockDecrease);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            closeConnection(conn);
        }


        //Restocks an item to its maximum value
        public static void restock(int id)
        {
            OleDbConnection conn = openConnection();
            string SQLstring = "UPDATE tblProducts SET InStock = RestockValue WHERE ProductID = @id";
            OleDbCommand cmd = new OleDbCommand(SQLstring, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            closeConnection(conn);
        }

        //Adds a new product to the Product table
        public static void addProduct(String type, String name, String description, double price, String imageFile, int stock)
        {
            OleDbConnection conn = openConnection();
            string SQLstring = "INSERT INTO tblProducts(ProductType,ProductName,ProductDesc, RetailPrice, ImageFile, InStock, RestockValue) VALUES(@type,@name,@desc,@price, @img, @stock, @max) ";
            OleDbCommand cmd = new OleDbCommand(SQLstring, conn);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@desc", description);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@img", imageFile);
            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.Parameters.AddWithValue("@max", stock);
            cmd.ExecuteNonQuery();
            closeConnection(conn);
        }

        //Updates image for selected product
        public static void updateImage(String imgPath, int id)
        {
            OleDbConnection conn = openConnection();
            string SQLstring = "UPDATE tblProducts SET ImageFile = @path WHERE ProductID = @id";
            OleDbCommand cmd = new OleDbCommand(SQLstring, conn);
            cmd.Parameters.AddWithValue("@path", imgPath);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            closeConnection(conn);
        }

        //Delete selected product from the database
        public static void deleteProduct(int id)
        {
            OleDbConnection conn = openConnection();
            string SQLstring = "DELETE FROM tblProducts WHERE ProductID = @id";
            OleDbCommand cmd = new OleDbCommand(SQLstring, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            closeConnection(conn);
        }

        //Return all reviews for selected product
        public static String[] returnReviews(String productid)
        {
            String[] reviews = new String[10];
            OleDbConnection conn = openConnection();
            string SQLstring = "SELECT * FROM tblReview WHERE ProductID = @id";
            OleDbCommand cmd = new OleDbCommand(SQLstring, conn);
            cmd.Parameters.AddWithValue("@id", productid);
            OleDbDataReader reader = cmd.ExecuteReader();
            int loop = 0;         
            while (reader.Read())
            {
                reviews[loop] += "?" + (reader["UserName"]) + "?";
                reviews[loop] += "%" + (reader["Details"]) + "%";
                reviews[loop] += "^" + (reader["ReviewDate"]) + "^";
                loop++;
            }
            reader.Close();
            closeConnection(conn);
            return reviews;
        }

        //Adds a new review for a product to the database
        public static void addReview(String productid, String type, String username, String details, String date)
        {
            OleDbConnection conn = openConnection();
            string SQLstring = "INSERT INTO tblReview(ProductID, Type, Username, Details, ReviewDate) VALUES(@id, @type, @username, @details, @reviewdate)";
            OleDbCommand cmd = new OleDbCommand(SQLstring, conn);
            cmd.Parameters.AddWithValue("@id", productid);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@details", details);
            cmd.Parameters.AddWithValue("@reviewdate", date);
            cmd.ExecuteNonQuery();
            closeConnection(conn);
        }
    }
}