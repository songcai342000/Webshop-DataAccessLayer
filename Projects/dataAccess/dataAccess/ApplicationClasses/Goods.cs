using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccess;


namespace Members
{
    /// <summary>
    /// Perfume 的摘要说明
    /// </summary>
    public class Goods
    {
        //constructors
        public Goods()
        { }
        public Goods(string Goodsname, string Price, int Quantity, String Size, String Weight, String Type, String Vendname, String Picture)
        {
            goodsname = Goodsname;
            price = Price;
            quantity = Quantity;
            weight = Weight;
            size = Size;
            type = Type;
            vendname = Vendname;
            picture = Picture;
        }
        public Goods(string Goodsname, string Price, String Size, String Weight)
        {
            goodsname = Goodsname;
            price = Price;
            weight = Weight;
            size = Size;
        }

        //define properties
        private string goodsname;
        public string Goodsname
        {
            get
            {
                return goodsname;
            }
            set
            {
                goodsname = value;
            }
        }

        private string price;
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        private int quantity;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        private string weight;
        public string Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        private string size;
        public string Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

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

        private string picture;
        public string Picture
        {
            get
            {
                return picture;
            }
            set
            {
                picture = value;
            }
        }

        #region variables
        dataAccess myAccess = new dataAccess();
        #endregion 
        #region methods
        //insert new Goods
        public void insertGoods()
        {
            myAccess.insertGoods(Goodsname, Price, Quantity, Size, Weight, Type, Vendname, Picture);
        }

        //update Goods information
        public void updateGoods(string Goodsname, string Price, int Quantity, string Size, string Weight, string Type, string Vendname, string Picture, int ID)
        {
            myAccess.updateGoods(Goodsname, Price, Quantity, Size, Weight, Type, Vendname, Picture, ID);
        }

    //get goods by type
    public DataTable getGoodsByType(string Type)
        {
            DataTable typeTable = myAccess.getGoodsByType(Type);
            return typeTable;
        }

        //get goods by price
        public DataTable getGoodsByPrice(decimal price)
        {
            DataTable typeTable = myAccess.getGoodsByPrice(price);
            return typeTable;
        }

        //get goods name, size, weight, price, picture by id
        public DataTable getGoodsById(int ID)
        {
            DataTable typeTable = myAccess.getGoodsById(ID);
            return typeTable;
        }

        //get goods full information by id
        public DataTable getGoodsFullInforById(int ID)
        {
            DataTable typeTable = myAccess.getGoodsFullInforById(ID);
            return typeTable;
        }
        //get goods quantity by id
        public DataTable getGoodsQuantity(int ID)
        {
            DataTable quantityTable = myAccess.getGoodsById(ID);
            return quantityTable;
        }
        //get the goods whose quantity are less than 300
        public DataTable getSmallGoodsQuantity()
        {
            DataTable quantityTable = myAccess.getSmallGoodsQuantity();
            return quantityTable;
        }

        //delete goods
        public void deleteGoodsById(int Goodsid)
        {
            myAccess.deleteGoodsById(Goodsid);
        }
        #endregion
    }
}