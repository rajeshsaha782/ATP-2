using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easylife.Models.AdminViewModel
{
    public class ProductModel
    {
        //Product View
        public string ProductName;
        public int TotalSell;
        public int  Price;
        public DateTime LastPurchase;
        public int RemainingQuantity;
        public int TotalProduct;
        public int RemainingProduct;


        //Invoice View
        public int InvoiceId;
        public string Buyer;
        public DateTime InvoiceDate;
        public string OrderStatus;
        public string PaymentStatus;
        public string DeliveryMan;

        //Order View
        public int ProductCode;
        public int Invoice;
        public DateTime OrederPlace;
        public int TotalOrder;





    }
}