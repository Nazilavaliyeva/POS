namespace POS
{
    public class Product
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int MinStock { get; set; }
        public string Unit { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
    }
}