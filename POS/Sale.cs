using System;

namespace POS
{
    public class Sale
    {
        public int SaleId { get; set; }
        public string TransactionId { get; set; }
        public DateTime SaleDate { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductName { get; set; }
        public int QuantitySold { get; set; }
        public decimal SalePrice { get; set; }
    }
}