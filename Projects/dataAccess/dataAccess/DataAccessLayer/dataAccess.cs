using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;



namespace DataAccess

{
    public class dataAccess
    {
        #region
        //private variables
        // private string connectionStr = "Data Source = DESKTOP-V7H8POU\\SQLEXPRESS2017; Initial Catalog = Webshop2017; Integrated Security=True";
        private string connectionStr = "Data Source = LAPTOP-R35DSQVG\\SQLEXPRESS01; Initial Catalog = Webshop2017; Integrated Security=True";
        private SqlDataAdapter SqlAd;
        private string commandTex;
        #endregion

        #region
        public dataAccess()
        {
            
        }
        #endregion

        #region Local Helping Methods

        private void CreateTableByQuery1()
        {
                using (SqlConnection SqlConn = new SqlConnection(connectionStr))
                {
                    if (SqlConn != null)
                    {
                        SqlCommand SqlComm;
                        SqlConn.Open();
                        SqlComm = new SqlCommand(commandTex, SqlConn);
                        SqlComm.ExecuteNonQuery();
                    }
                }
        }

        public DataTable CreateTableByQuery2()
        {
                using (SqlConnection SqlConn = new SqlConnection(connectionStr))
                {
                    if (SqlConn != null)
                    {
                        DataTable table = new DataTable();
                        SqlCommand SqlComm;
                        SqlConn.Open();
                        SqlComm = new SqlCommand(commandTex, SqlConn);
                        SqlAd = new SqlDataAdapter();
                        SqlAd.SelectCommand = SqlComm;
                        SqlAd.Fill(table);
                        return table;
                    }
                    else
                    {
                        return null;
                    }
            }
        }

        #endregion

        #region insert functions
        //insert Goods
        public void insertGoods(string Goodsname, string Price, int Quantity, string Size, String Weight, String Type, String Vendname, String Picture)
        {
            commandTex = "Insert into dbo.Goods values ('" + Goodsname + "', '" + Price + "', " + Quantity + ", '" + Size + "', '" + Weight + "', '" + Type + "', '" + Vendname + "', '" + Picture + "')";
            CreateTableByQuery1();
        }

        //insert customer
        public void insertCustomer(string Custemail, string Passwrd, string Username, string Gender, string Userrole)
        {
            commandTex = "Insert into dbo.Customers (Custname, Billingadrs, Telephone, Custemail, Passwrd, Points, Username, Gender, Timeupdate, Userrole) values (' ', ' ', ' ', '" + Custemail + "', '" + Passwrd + "', " + 0 + ", '" + Username + "', '" + Gender + "', '" + Userrole + "', '" + DateTime.Now.ToString() + "')";
            CreateTableByQuery1();
        }

        //insert orders
        public void insertOrders(string Custname, int Item1, int Item2, int Item3, int Item4, int Item5, int Item6, int Item7, int Item8, int Item9, int Item10, DateTime Ordertime, string Shippingsta, string Complainment, string Resolution)
        {
            commandTex = "Insert into dbo.Orders (Username, Item1, Ordertime, Shippingsta, Complainment, Resolution, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9, Item10) values ('" + Custname + "', " + Item1 + ", '" + Ordertime + "', '" + Shippingsta + "', '" + Complainment + "', '" + Resolution + "', " + Item2 + ", " + Item3 + ", " + Item4 + ", " + Item5 + ", " + Item6 + ", " + Item7 + ", " + Item8 + ", " + Item9 + ", " + Item10 +  ")";
            CreateTableByQuery1();
        }
    
        //insert vendor
        public void insertVendor(string Vendname, string Vendadrs, string Vendtelephone, string Vendemail, string Contactperson1, string Contactperson2)
        {
            commandTex = "Insert into dbo.Vendors (Vendname, Vendadrs, Vendtelephone, Vendemail, Contactperson1, Contactperson2) values ('" + Vendname + "', '" + Vendadrs + "', '" + Vendtelephone + "', '" + Vendemail + "', '" + Contactperson1 + "', '" + Contactperson2 + "')";
            CreateTableByQuery1();
        }

        //insert supplement
        public void insertSupplement(int GoodsId, int VendorId, int Supplementquantity, string Ordertime, string Totalprice, string Payment, string Supplementstate)
        {
            commandTex = "Insert into Supplements (GoodsId, VendorId, Supplementquantity, Ordertime, Totalprice, Payment, Supplementstate) values (" + GoodsId + ", " + VendorId + ", " + Supplementquantity + ", '" + Ordertime + "', '" + Totalprice + "', '" + Payment + "', '" + Supplementstate + "')";
            CreateTableByQuery1();
        }
        #endregion

        #region update functions
        //update vendor information
        public void updateVendor(string Vendname, string Vendadrs, string Vendtelephone, string Vendemail, string Contactperson1, string Contactperson2, int ID)
        {
            commandTex = "Update Vendors Set Vendname = '" + Vendname + "', Vendadrs = '" + Vendadrs + "', Vendtelephone = " + Vendtelephone + ", Vendemail = '" + Vendemail + "', Contactperson1 = '" + Contactperson1 + "', Contactperson2 = '" + Contactperson2 + "' where ID = " + ID;
            CreateTableByQuery1();
        }
        //update all goods information
        public void updateGoods(string Goodsname, string Price, int Quantity, string Size, string Weight, string Type, string Vendname, string Picture, int ID)
        {
            commandTex = "Update Goods Set Goodsname = '" + Goodsname + "', Price = '" + Price + "', Quantity = " + Quantity + ", Size = '" + Size + "', Weight = '" + Weight + "', Type = '" + Type + "', Vendname = '" + Vendname + "', Picture = '" + Picture + "' where ID = " + ID;
            CreateTableByQuery1();
        }
        //update customer profile
        public void updateCustProfile(string Custname, string Billingadrs, string Telephone, string Custemail, string Username, string Gender, string Timeupdate, string currentName)
        {
            commandTex = "Update Customers Set Custname = '" + Custname + "', Billingadrs = '" + Billingadrs + "', Telephone = '" + Telephone + "', Custemail = '" + Custemail + "', Username = '" + Username + "', Gender = '" + Gender + "', Timeupdate = '" + Timeupdate + "' where Username = '" + currentName + "'";
            CreateTableByQuery1();
        }
        //update customer points
        public void updateCustPoints(int Points, string Custname)
        {
            commandTex = "Update Customers Set Points = " + Points + " where Goodsname = '" + Custname + "'";
            CreateTableByQuery1();
        }

        //update customer contact information
        public void updateContactInfor(string Custname, string Telephone, string Billingadrs, string Custemail)
        {
            commandTex = "Update Customers Set Custname = '" + Custname + "', Telephone = '" + Telephone + "', Billingadrs = '" + Billingadrs + "', Custemail = '" + Custemail +  "'";
            CreateTableByQuery1();
        }
        //update customer passwrd
        public void updateCustPasswrd(string Username, string Passwrd)
        {
            commandTex = "Update Customers Set Passwrd = '" + Passwrd + "' where Username = '" + Username + "'";
            CreateTableByQuery1();
        }

        //update updatTime
        public void updateTimeupdate(string Custemail)
        {
            commandTex = "Update Customers Set Timeupdate = '" + DateTime.Now + "' where Custemail = '" + Custemail + "'";
            CreateTableByQuery1();
        }

        //update order items
        public void updateOrderItem1(int item, int Orderid)
        {
            commandTex = "Update Orders Set Item1 = " + item + " where ID = " + Orderid;
            CreateTableByQuery1();
        }
        public void updateOrderItem2(int item, int Orderid)
        {
            commandTex = "Update Orders Set Item2 = " + item + " where ID = " + Orderid;
            CreateTableByQuery1();
        }
        public void updateOrderItem3(int item, int Orderid)
        {
            commandTex = "Update Orders Set Item3 = " + item + " where ID = " + Orderid;
            CreateTableByQuery1();
        }
        public void updateOrderItem4(int item, int Orderid)
        {
            commandTex = "Update Orders Set Item4 = " + item + " where ID = " + Orderid;
            CreateTableByQuery1();
        }
        public void updateOrderItem5(int item, int Orderid)
        {
            commandTex = "Update Orders Set Item5 = " + item + " where ID = " + Orderid;
            CreateTableByQuery1();
        }
        public void updateOrderItem6(int item, int Orderid)
        {
            commandTex = "Update Orders Set Item6 = " + item + " where ID = " + Orderid;
            CreateTableByQuery1();
        }
        public void updateOrderItem7(int item, int Orderid)
        {
            commandTex = "Update Orders Set Item7 = " + item + " where ID = " + Orderid;
            CreateTableByQuery1();
        }
        public void updateOrderItem8(int item, int Orderid)
        {
            commandTex = "Update Orders Set Item8 = " + item + " where ID = " + Orderid;
            CreateTableByQuery1();
        }
        public void updateOrderItem9(int item, int Orderid)
        {
            commandTex = "Update Orders Set Item9 = " + item + " where ID = " + Orderid;
            CreateTableByQuery1();
        }
        public void updateOrderItem10(int item, int Orderid)
        {
            commandTex = "Update Orders Set Item10 = " + item + " where ID = " + Orderid;
            CreateTableByQuery1();
        }
        public void updateShipping(string Shippingsta, int Orderid)
        {
            commandTex = "Update Orders Set Shippingsta = '" + Shippingsta + "' where ID = " + Orderid;
            CreateTableByQuery1();
        }
        //update order complainment
        public void updateComplainment(string Complainment, string Resolution, int Orderid)
        {
            commandTex = "Update Orders Set Complainment = '" + Complainment + "', Resolution = '" + Resolution + "' where Orderid = " + Orderid;
            CreateTableByQuery1();
        }
      
        #endregion
        #region delete functions
        //delete customer
        public void deleteCustomer(string Username)
        {
            commandTex = "Delete from Customers where Username = '" + Username + "'";
            CreateTableByQuery1();
        }
        //delete goods
        public void deleteGoodsById(int Goodsid)
        {
            commandTex = "Delete from Goods where ID = " + Goodsid;
            CreateTableByQuery1();
        }
        //delete a vendor
        public void deleteVendor(int Vendorid)
        {
            commandTex = "Delete from Vendors where ID = " + Vendorid;
            CreateTableByQuery1();
        }
        //delete an order
        public void deleteOrder(int Orderid)
        {
            commandTex = "Delete from Customers where ID = " + Orderid;
            CreateTableByQuery1();
        }

        #endregion

        #region get functions
        #region get goods
      
        //get goods by type
        public DataTable getGoodsByType(string Type)
        {
            commandTex = "SELECT ID, Goodsname, Price, Size, Weight, Picture from Goods where Type = '" + Type + "'";
            DataTable typeTable = CreateTableByQuery2();
            return typeTable;
        }

        //get goods by price
        public DataTable getGoodsByPrice(decimal price)
        {
            commandTex = "SELECT ID, Goodsname, Price, Size, Weight, Picture from Goods where CAST(Price AS decimal) < " + price;
            DataTable typeTable = CreateTableByQuery2();
            return typeTable;
        }

        //get goods by Id
        public DataTable getGoodsById(int Id)
        {
            commandTex = "SELECT Goodsname, Price, Size, Weight from Goods where ID = " + Id;
            DataTable typeTable = CreateTableByQuery2();
            return typeTable;
        }
        //get the username and the last updatetime by email
        public DataTable getUserUpdatetime(string Custemail)
        {
            commandTex = "Select Username, Timeupdate from Customers where Custemail = '" + Custemail + "'";
            DataTable theTable = CreateTableByQuery2();
            return theTable;
        }

        //get goods full information by Id
        public DataTable getGoodsFullInforById(int Id)
        {
            commandTex = "SELECT * from Goods where ID = " + Id;
            DataTable typeTable = CreateTableByQuery2();
            return typeTable;
        }
        //get goods quantity Id
        public DataTable getGoodsQuantity(int Id)
        {
            commandTex = "SELECT Quantity from Goods where ID = " + Id;
            DataTable quantityTable = CreateTableByQuery2();
            return quantityTable;
        }

        //get goods quantity Id
        public DataTable getSmallGoodsQuantity()
        {
            commandTex = "SELECT Goods.Id, Goods.Goodsname, Price, Size, Weight, Vendors.Vendname, Vendemail from Goods inner join Vendors on Goods.Vendname = Vendors.Vendname where Quantity <= 300";
            DataTable quantityTable = CreateTableByQuery2();
            return quantityTable;
        }
        #endregion
        #region get customers
        //get customers profile by the shipping states of their orders
        public DataTable getCustProfil(string Username)
        {
            commandTex = "SELECT Custname, Telephone, Custemail, Billingadrs, Username, Gender, Points from Customers where Username = '" + Username + "'";
            DataTable theTable = CreateTableByQuery2();
            return theTable;
        }

        //get customers email by the shipping states of their orders
        public void getCustEmails3Monthes(string Shippingsta)
        {
            commandTex = "SELECT Custemail from Customers JOIN Orders ON Custmers.Custname = Orders.Custname where Orders.Ordertime = " + DateTime.Now.AddDays(-90);
            CreateTableByQuery1();
        }
        //get login information
        public DataTable getLogin(string Username)
        {
            commandTex = "SELECT * from Customers where Username = '" + Username + "'";
            DataTable theTable = CreateTableByQuery2();
            return theTable;
        }
       
        //get all emails addresses of the customers
        public DataTable getAllMailAddress()
        {
            DataTable emailTable;
            commandTex = "SELECT Custemail from Customers";
            emailTable = CreateTableByQuery2();
            return emailTable;
        }
        //get customer Username
        public DataTable getUser(string Username)
        {
            DataTable usernameTable;
            commandTex = "SELECT * from Customers where Username = '" + Username + "'";
            usernameTable = CreateTableByQuery2();
            return usernameTable;
        }
        //get customer by email
        public DataTable getUserByEmail(string Custemail)
        {
            DataTable usernameTable;
            commandTex = "SELECT Username from Customers where Custemail = '" + Custemail + "'";
            usernameTable = CreateTableByQuery2();
            return usernameTable;
        }
        //get last updatetime by username. This function is used to check the querystring to reset password
        public DataTable getUpdatetimeByUsername(string Username)
        {
            DataTable usernameTable;
            commandTex = "SELECT Updatetime from Customers where Username = '" + Username + "'";
            usernameTable = CreateTableByQuery2();
            return usernameTable;
        }
        #endregion
        #region get orders
        //get a order
        public DataTable getOrderById(int Orderid)
        {
            DataTable orderTable;
            commandTex = "SELECT Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9, Item10 from Orders where ID = " + Orderid;
            orderTable = CreateTableByQuery2();
            return orderTable;
        }

        //get item by OrderId
        public DataTable getItemByOrderId(int orderId, int itemNumber)
        {
            commandTex = "SELECT Item" + itemNumber.ToString() + " from Orders where ID = " + orderId;
            DataTable typeTable = CreateTableByQuery2();
            return typeTable;
        }


        //get orders by username
        public DataTable getOrdersByUsername(string Username)
        {
            DataTable orderTable;
            commandTex = "SELECT ID from Orders where Username = '" + Username + "'";
            orderTable = CreateTableByQuery2();
            return orderTable;
        }

        //get order id
        //get a order
        public DataTable getMaxOrderId()
        {
            DataTable orderTable;
            commandTex = "SELECT Max(ID) as maxid from Orders";
            orderTable = CreateTableByQuery2();
            return orderTable;
        }

        //get today's orders
        public DataTable getOrdersToday(DateTime TodayDate)
        {
            DataTable orderTable;
            commandTex = "SELECT * from Orders where Ordertime < '" + TodayDate.AddDays(1) + "' and Ordertime > '" + TodayDate.AddDays(-1) + "' and Shippingsta = 'Paid'";
            orderTable = CreateTableByQuery2();
            return orderTable;
        }

        //get the orders in certain period
        public DataTable getOrdersCertainPeriod(DateTime FromTime, DateTime ToTime)
        {
            DataTable orderTable;
            commandTex = "SELECT * from Orders where Ordertime >= '" + FromTime  + "' and Ordertime <= '" + ToTime.AddDays(1) + "' and Shippingsta = 'Paid'";
            orderTable = CreateTableByQuery2();
            return orderTable;
        }

        #endregion
        #region get vendor
        //get vendor by id 
        public DataTable getVendor(int ID)
        {
            commandTex = "Select * from Vendors where ID = " + ID;
            DataTable theTable = CreateTableByQuery2();
            return theTable;
        }

        //get all vendors
        public DataTable getAllVendors()
        {
            commandTex = "Select * from Vendors";
            DataTable theTable = CreateTableByQuery2();
            return theTable;
        }
        #endregion
        #endregion
    }

}
