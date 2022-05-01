using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using System.Data;

namespace Members
{
    /// <summary>
    /// Orders 的摘要说明
    /// </summary>
    public class Orders
    {
        public Orders()
        { }
        public Orders(string Username, int Item1, int Item2, int Item3, int Item4, int Item5, int Item6, int Item7, int Item8, int Item9, int Item10, DateTime Ordertime, string Shippingsta, string Complainment, string Resolution)
        {
            username = Username;
            item1 = Item1;
            item2 = Item2;
            item3 = Item3;
            item4 = Item4;
            item5 = Item5;
            item6 = Item6;
            item7 = Item7;
            item8 = Item8;
            item9 = Item9;
            item10 = Item10;
            ordertime = Ordertime;
            shippingsta = Shippingsta;
            complainment = Complainment;
            resolution = Resolution;
        }

        //define properties
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

        private int item1;
        public int Item1
        {
            get
            {
                return item1;
            }
            set
            {
                item1 = value;
            }
        }

        private int item2;
        public int Item2
        {
            get
            {
                return item2;
            }
            set
            {
                item2 = value;
            }
        }

        private int item3;
        public int Item3
        {
            get
            {
                return item3;
            }
            set
            {
                item3 = value;
            }
        }

        private int item4;
        public int Item4
        {
            get
            {
                return item4;
            }
            set
            {
                item4 = value;
            }
        }

        private int item5;
        public int Item5
        {
            get
            {
                return item5;
            }
            set
            {
                item5 = value;
            }
        }

        private int item6;
        public int Item6
        {
            get
            {
                return item6;
            }
            set
            {
                item6 = value;
            }
        }

        private int item7;
        public int Item7
        {
            get
            {
                return item7;
            }
            set
            {
                item7 = value;
            }
        }

        private int item8;
        public int Item8
        {
            get
            {
                return item8;
            }
            set
            {
                item8 = value;
            }
        }

        private int item9;
        public int Item9
        {
            get
            {
                return item9;
            }
            set
            {
                item9 = value;
            }
        }

        private int item10;
        public int Item10
        {
            get
            {
                return item10;
            }
            set
            {
                item10 = value;
            }
        }

        private DateTime ordertime;
        public DateTime Ordertime
        {
            get
            {
                return ordertime;
            }
            set
            {
                ordertime = value;
            }
        }

        private string shippingsta;
        public string Shippingsta
        {
            get
            {
                return shippingsta;
            }
            set
            {
                shippingsta = value;
            }
        }

        private string complainment;
        public string Complainment
        {
            get
            {
                return complainment;
            }
            set
            {
                complainment = value;
            }
        }

        private string resolution;
        public string Resolution
        {
            get
            {
                return resolution;
            }
            set
            {
                resolution = value;
            }
        }

        #region variables
        dataAccess myAccess = new dataAccess();
        #endregion 

        #region methods
        //insert new Order
        public void insertTable()
        {
            myAccess.insertOrders(Username, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9, Item10, Ordertime, Shippingsta, Complainment, Resolution);
        }

        //delete an order
        public void deleteOrder(int Orderid)
        {
            myAccess.deleteOrder(Orderid);
        }

        //update an order item
        public void updateOrderItem1(int Itemquantity, int Orderid)
        {
            myAccess.updateOrderItem1(Itemquantity, Orderid);
        }
        public void updateOrderItem2(int Itemquantity, int Orderid)
        {
            myAccess.updateOrderItem2(Itemquantity, Orderid);
        }
        public void updateOrderItem3(int Itemquantity, int Orderid)
        {
            myAccess.updateOrderItem3(Itemquantity, Orderid);
        }
        public void updateOrderItem4(int Itemquantity, int Orderid)
        {
            myAccess.updateOrderItem4(Itemquantity, Orderid);
        }
        public void updateOrderItem5(int Itemquantity, int Orderid)
        {
            myAccess.updateOrderItem5(Itemquantity, Orderid);
        }
        public void updateOrderItem6(int Itemquantity, int Orderid)
        {
            myAccess.updateOrderItem6(Itemquantity, Orderid);
        }
        public void updateOrderItem7(int Itemquantity, int Orderid)
        {
            myAccess.updateOrderItem7(Itemquantity, Orderid);
        }
        public void updateOrderItem8(int Itemquantity, int Orderid)
        {
            myAccess.updateOrderItem8(Itemquantity, Orderid);
        }
        public void updateOrderItem9(int Itemquantity, int Orderid)
        {
            myAccess.updateOrderItem9(Itemquantity, Orderid);
        }
        public void updateOrderItem10(int Itemquantity, int Orderid)
        {
            myAccess.updateOrderItem10(Itemquantity, Orderid);
        }
        //update an order shipping state
        public void updateShipping(string Shippingsta, int Orderid)
        {
            myAccess.updateShipping(Shippingsta, Orderid);
        }

        //update order complainment
        public void updateComplain(int Orderid)
        {
            myAccess.updateComplainment(Complainment, Resolution, Orderid);
        }

        //get order by ID
        public DataTable getOrderByID(int ID)
        {
            DataTable theTable = myAccess.getOrderById(ID);
            return theTable;
        }
        //get max order ID
        public DataTable getMaxOrderID()
        {
            DataTable theTable = myAccess.getMaxOrderId();
            return theTable;
        }

        //get orderID by username
        public DataTable getOrderIdByUsername(string Username)
        {
            DataTable theTable = myAccess.getOrdersByUsername(Username);
            return theTable;
        }

        //get item by order
        public DataTable getItemByOrderId(int orderId, int itemNumber)
        {
            DataTable typeTable = myAccess.getItemByOrderId(orderId, itemNumber);
            return typeTable;
        }

        //get todays sales
        public DataTable getSalesToday(DateTime TodayDate)
        {
            DataTable theTable = myAccess.getOrdersToday(TodayDate);
            return theTable;
        }

        //get sales in a chosen period
        public DataTable getSalesCertainPeriod(DateTime FromTime, DateTime ToTime)
        {
            DataTable theTable = myAccess.getOrdersCertainPeriod(FromTime, ToTime);
            return theTable;
        }
        #endregion
    }
}