using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using System.Data;


namespace Members
{
    /// <summary>
    /// Customers 的摘要说明
    /// </summary>
    [Serializable]
    public class Customers 
    {
        public Customers()
        { }
        public Customers(string Custname, string Telephone, string Custemail, string Billingadrs, string Passwrd, int Points, string Username, string Gender, string Userrole, string Timeupdate)
        {
            custname = Custname;
            telephone = Telephone;
            custemail = Custemail;
            billingadrs = Billingadrs;
            passwrd = Passwrd;
            points = Points;
            username = Username;
            gender = Gender;
            userrole = Userrole;
            timeupdate = Timeupdate;
        }

        //define properties
        //define properties
        private string custname;
        public string Custname
        {
            get
            {
                return custname;
            }
            set
            {
                custname = value;
            }
        }

        private string billingadrs;
        public string Billingadrs
        {
            get
            {
                return billingadrs;
            }
            set
            {
                billingadrs = value;
            }
        }

        private string telephone;
        public string Telephone
        {
            get
            {
                return telephone;
            }
            set
            {
                telephone = value;
            }
        }

        private string custemail;
        public string Custemail
        {
            get
            {
                return custemail;
            }
            set
            {
                custemail = value;
            }
        }

        private string passwrd;
        public string Passwrd
        {
            get
            {
                return Passwrd;
            }
            set
            {
                passwrd = value;
            }
        }

        private int points;
        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        private string gender;
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        private string userrole;
        public string Userrole
        {
            get
            {
                return userrole;
            }
            set
            {
                userrole = value;
            }
        }

        private string timeupdate;
        public string Timeupdate
        {
            get
            {
                return timeupdate;
            }
            set
            {
                timeupdate = value;
            }
        }

        //public methods
        #region
        //variables 
        dataAccess myAccess = new dataAccess();
        DataTable myTable = new DataTable();
        //get login information
        public DataTable logIn(string Username)
        {
            myTable = myAccess.getLogin(Username);
            return myTable;
        }
        //get the identity to reset password
        public DataTable getUserUpdateTime(string Custemail)
        {
            DataTable theTable = myAccess.getUserUpdatetime(Custemail);
            return theTable;
        }
        //get the last updatetime by username
        public DataTable getUpdateTimeByUsername(string Username)
        {
            DataTable theTable = myAccess.getUserUpdatetime(Username);
            return theTable;
        }

        //update customer profile
       /* public void custProfil()
        {
            myAccess.updateCustProfile(Custname, Billingadrs, Telephone, Custemail, Username, Gender, Timeupdate);
        }*/

        //reset password
        public void updatePasswrd(string Username, string Passwrd)
        {
            myAccess.updateCustPasswrd(Username, Passwrd);
        }

        //insert new Customer
        public void insertCustomer(string Custemail, string Passwrd, string Username, String Gender, string Userrole)
        {
            myAccess.insertCustomer(Custemail, Passwrd, Username, Gender, Userrole);       
        }

        //get customer profile
        public DataTable getProfil(string Username)
        {
            DataTable theTable;
            if (Username != null)
            {
                theTable = myAccess.getCustProfil(Username);

                return theTable;
            }
            else
                return null;
        }

        //get customer with Username 
        public DataTable getUser(string Username)
        {
            DataTable theTable;
            if (Username != null)
            {
                theTable = myAccess.getUser(Username);

                return theTable;
            }
            else
                return null;
        }
        //get customer by Email 
        public DataTable getUserByEmail(string Custemail)
        {
               DataTable theTable = myAccess.getUserByEmail(Custemail);
               return theTable;
        }

        //update customer contact information
        public void updateContactInfor(string Custname, string Telephone, string Billingadrs, string Custemail)
        {
            myAccess.updateContactInfor(Custname, Telephone, Billingadrs, Custemail);
        }

        //update customer profile
        public void updateProfil(string Custname, string Billingadrs, string Telephone, string Custemail, string Username, string Gender, string Timeupdate, string currentName)
        {
            myAccess.updateCustProfile(Custname, Billingadrs, Telephone, Custemail, Username, Gender, Timeupdate, currentName);
        }

        //update Timeupdate by email
        public void updateTime(string Custemail)
        {
            myAccess.updateTimeupdate(Custemail);
        }

        //delete customer
        public void deleteCustomer(string Username)
        {
            myAccess.deleteCustomer(Username);
        }
        #endregion
    }
}