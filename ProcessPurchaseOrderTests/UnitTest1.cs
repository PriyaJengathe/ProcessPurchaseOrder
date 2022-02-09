using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProcessPurchaseOrder.BusinessEntity;
using ProcessPurchaseOrder.BusinessLogic;
using ProcessPurchaseOrder.Common;
using static ProcessPurchaseOrder.Common.Constants;

namespace ProcessPurchaseOrderTests
{
    [TestClass]
    public class ProcessPurchaseOrderUnitTest
    {
        

        [TestMethod]
        public void PurchaseOrder_Success_Using_Moq()
        {
            Mock<IProcessOrder> processOrder = new Mock<IProcessOrder>();
            processOrder.Setup(x => x.Process()).Returns(new Tuple<Status,Customer,string>(
                Status.Success, new Customer(), Messages.SlipGenerate));
            
            var result= processOrder.Object.Process();
            Assert.AreEqual(Status.Success, result.Item1); 

        }
      
        [TestMethod]
        public void PurchaseOrder_Success()
        {
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
            
            ProcessOrder processOrder = new ProcessOrder(purchaseOrder);
            var result = processOrder.Process();
            Assert.AreEqual(Status.Success, result.Item1);

        }
        [TestMethod]
        public void PurchaseOrder_Success_Account_Activate()
        {
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

            ProcessOrder processOrder = new ProcessOrder(purchaseOrder);
            var result = processOrder.Process();
            Assert.AreEqual(Status.Success, result.Item1);
            Assert.AreEqual(Membership.BookClub.ToString(), result.Item2.MembershipType);

        }
        [TestMethod]
        public void PurchaseOrder_Success_Slip_Genearted()
        {
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
                   
                }
            };

            ProcessOrder processOrder = new ProcessOrder(purchaseOrder);
            var result = processOrder.Process();
            Assert.AreEqual(Status.Success, result.Item1);
            Assert.AreEqual(Messages.SlipGenerate, result.Item3.ToString());

        }
        [TestMethod]
        public void PurchaseOrder_Invalid_PruchaseOrder()
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder()
            {
                CustomerId = 4567890,
                OrderId = 3344656,
                Total = 48.50,
                ItemLines = null
            };

            ProcessOrder processOrder = new ProcessOrder(purchaseOrder);
            var result = processOrder.Process();
            Assert.AreEqual(Status.Invalid, result.Item1);

        }
       

    }
}