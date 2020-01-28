using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreakyGeekyCrafts.App_Code.DAL;

namespace FreakyGeekyCrafts.App_Code.BLL
{
    public class UserLogin
    {
        private string id, email, lastname, firstname, address, city, postcode, phone, password, status;
        public UserLogin (string email, string lastname, string firstname, string address, string city, string postcode, string phone)
        {
            this.email = email;
            this.lastname = lastname;
            this.firstname = firstname;
            this.address = address;
            this.city = city;
            this.postcode = postcode;
            this.phone = phone;
        }//constructor

        public UserLogin( string email, string lastname, string firstname, string address, string city, string postcode, string phone, string password, string status)
        {
            this.email = email;
            this.lastname = lastname;
            this.firstname = firstname;
            this.address = address;
            this.city = city;
            this.postcode = postcode;
            this.phone = phone;
            this.password = password;
            this.status = status;
        }//constructor


        public UserLogin(string id, string email, string lastname, string firstname, string address, string city, string postcode, string phone, string password, string status)
        {
            this.id = id;
            this.email = email;
            this.lastname = lastname;
            this.firstname = firstname;
            this.address = address;
            this.city = city;
            this.postcode = postcode;
            this.phone = phone;
            this.password = password;
            this.status = status;
        }//constructor

        public UserLogin()
        {
            this.email = "Unknown";
            this.lastname = "Unknown";
            this.firstname = "Unknown";
            this.address = "Unknown";
            this.city = "Unknown";
            this.postcode = "Unknown";
            this.phone = "Unknown";
            this.password = "Unknown";
            this.status = "Unknown";


        }

        //public property for field email  
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }//Email  

        public string getFullName()
        {
            string details = "";
            details = this.firstname + " " + this.lastname;
            return details;
        }//getFullname   

        public string getAddress()
        {
            string details = "";
            details = this.address;
            details += " ";
            details += this.city;
            details += " ";
            details += this.postcode;
            details += " ";
            return details;
        }//getAddress   

       
        public String getEmail()
        {
            return email;
        }

        public String getID()
        {
            return id;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }

        public string getForename()
        {
            return firstname;
        }

        public void setForename(String forename)
        {
            this.firstname = forename;
        }


        public string getSurname()
        {
            return lastname;
        }

        public void setSurname(String surname)
        {
            this.lastname = surname;
        }

        public string getStatus()
        {
            return status;
        }

        public void setStatus(String status)
        {
            this.status = status;
        }


        public string getVarAddress()
        {
            return address;
        }

        public void setAddress(String address)
        {
            this.address = address;
        }


        public string getPostcode()
        {
            return postcode;
        }

        public void setPostcode(String postcode)
        {
            this.postcode = postcode;
        }


        public string getPhone()
        {
            return phone;
        }

        public void setPhone(String phone)
        {
            this.phone = phone;
        }

        public string getCity()
        {
            return city;
        }

        public void setCity(String city)
        {
            this.city = city;
        }

        public string getPassword()
        {
            return password;
        }

        public void setPassword(String password)
        {
            this.password = password;
        }




        public static UserLogin checkLogin(string email, string pwd)
        {
            return DataAccess.checkLogin(email, pwd);
        }//checkLogin

        public static UserLogin register(UserLogin reg)
        {
            return DataAccess.register(reg);
        }
    }
}