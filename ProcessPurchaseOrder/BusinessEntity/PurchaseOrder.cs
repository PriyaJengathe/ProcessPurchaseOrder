using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessPurchaseOrder.BusinessEntity
{
    public class PurchaseOrder
    {
        public int OrderId { get; set; }
        public double Total { get; set; }
        public int CustomerId { get; set; }
        public ItemLines ItemLines { get; set; }
    }
    public class ItemLines
    {
        public List<Product> Products { get; set; }
        public string MembershipTypes { get; set; } 

    }
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
    }
    public class Customer
    {
        public int CustomerId { get; set; }
        public string MembershipType { get; set; }
    }
   
}
