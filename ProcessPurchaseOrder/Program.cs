// See https://aka.ms/new-console-template for more information
using ProcessPurchaseOrder.BusinessEntity;
using ProcessPurchaseOrder.BusinessLogic;
using ProcessPurchaseOrder.Common;

Console.WriteLine("Enter Purchase Order");

PurchaseOrder purchaseOrder = new PurchaseOrder()
{
    CustomerId = 4567890,
    OrderId = 3344656,
    Total = 48.50,
    ItemLines = new ItemLines()
    {
        Products = new List<Product>()
        {
            new Product() { ProductId = 1, ProductName = "Comprehensive First Aid Training", ProductType = "Video" },
            new Product() { ProductId = 2, ProductName = "The Girl on the train", ProductType = "Book" }
        },
        MembershipTypes = Membership.BookClub.ToString()
    }
};
ProcessOrder processPurchaseOrder = new ProcessOrder(purchaseOrder);
Tuple<Status, Customer, string> result = processPurchaseOrder.Process();
Console.WriteLine($"Purchase Order Status : {result.Item1} for CustId {purchaseOrder.CustomerId}");
Console.WriteLine($"Membership Activated : {result.Item2?.MembershipType}");
Console.WriteLine($"Slip Generated? {result.Item3}");

Console.ReadLine();


