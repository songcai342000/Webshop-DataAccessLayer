using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;

namespace Members
{
    public class Supplements
    {
        public Supplements()
        {
        }
        public Supplements(int GoodsId, int VendorId, int Supplementquantity, string Ordertime, string Totalprice, string Payment, string Supplementstate)
        {
            GoodsId = goodsId;
        }

        private int goodsId;
        public int GoodsId
        {
            get
            {
                return goodsId;
            }
            set
            {
                goodsId = value;
            }
        }

        private int vendorId;
        public int VendorId
        {
            get
            {
                return vendorId;
            }
            set
            {
                vendorId = value;
            }
        }

        private int supplementQuantity;
        public int SupplementQuantity
        {
            get
            {
                return supplementQuantity;
            }
            set
            {
                supplementQuantity = value;
            }
        }

        private string orderTime;
        public string OrderTime
        {
            get
            {
                return orderTime;
            }
            set
            {
                orderTime = value;
            }
        }

        private string totalPrice;
        public string TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
            }
        }

        private string payment;
        public string Payment
        {
            get
            {
                return payment;
            }
            set
            {
                payment = value;
            }
        }

        private string supplementState;
        public string SupplementState
        {
            get
            {
                return supplementState;
            }
            set
            {
                supplementState = value;
            }
        }

        //insert new order
        public void insertSupplement(int GoodsId, int VendorId, int Supplementquantity, string Ordertime, string Totalprice, string Payment, string Supplementstate)
        {
            dataAccess myDataAccess = new dataAccess();
            myDataAccess.insertSupplement(GoodsId, VendorId, Supplementquantity, Ordertime, Totalprice, Payment, Supplementstate);
        } 
    }
}
    

