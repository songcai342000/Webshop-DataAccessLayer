using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using System.Data;

namespace Members
{
    /// <summary>
    /// Vendors 的摘要说明
    /// </summary>
    public class Vendors
    {
        public Vendors()
        { }
        public Vendors(string Vendname, string Vendadrs, string Vendtelephone, string Vendemail, string Contactperson1, string Contactperson2)
        {
            vendname = Vendname;
            vendadrs = Vendadrs;
            vendtelephone = Vendtelephone;
            vendemail = Vendemail;
            contactperson1 = Contactperson1;
            contactperson2 = Contactperson2;
        }

        //define properties
        private string vendname;
        public string Vendname
        {
            get
            {
                return vendname;
            }
            set
            {
                vendname = value;
            }
        }

        private string vendadrs;
        public string Vendadrs
        {
            get
            {
                return vendadrs;
            }
            set
            {
                vendadrs = value;
            }
        }

        private string vendtelephone;
        public string Vendtelephone
        {
            get
            {
                return vendtelephone;
            }
            set
            {
                vendtelephone = value;
            }
        }

        private string vendemail;
        public string Vendemail
        {
            get
            {
                return vendemail;
            }
            set
            {
                vendemail = value;
            }
        }

        private string contactperson1;
        public string Contactperson1
        {
            get
            {
                return contactperson1;
            }
            set
            {
                contactperson1 = value;
            }
        }

        private string contactperson2;
        public string Contactperson2
        {
            get
            {
                return contactperson2;
            }
            set
            {
                contactperson2 = value;
            }
        }

        //variables
        dataAccess myAccess = new dataAccess();
        public void insertVendor()
        {
            myAccess.insertVendor(Vendname, Vendadrs, Vendtelephone, Vendemail, Contactperson1, Contactperson2);
        }

        //update vendor information
        public void updateVendor()
        {
            myAccess.insertVendor(Vendname, Vendadrs, Vendtelephone, Vendemail, Contactperson1, Contactperson2);
        }

        //get vendor information
        public DataTable getVendor(int ID)
        {
            DataTable theTable = myAccess.getVendor(ID);
            return theTable;

        }

        //get all vendors
        public DataTable getAllVendors()
        {
            DataTable theTable = myAccess.getAllVendors();
            return theTable;

        }

        //delete a vendor
        public void deleteVendor(int ID)
        {
            myAccess.deleteVendor(ID);

        }


    }
}