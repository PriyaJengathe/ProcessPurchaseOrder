using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessPurchaseOrder.BusinessEntity;
using ProcessPurchaseOrder.Common;

namespace ProcessPurchaseOrder.BusinessLogic
{
    public class ProcessOrder : IProcessOrder
    {
        private Customer _customer ;
        private string _generateSlip = string.Empty;
        private PurchaseOrder _purchaseOrder ;
      
        public ProcessOrder(PurchaseOrder purchaseOrder)
        {
            _purchaseOrder = purchaseOrder;
            
        }
        public Tuple<Status, Customer, string> Process()
        {
            try
            {
                
                if (_purchaseOrder == null || _purchaseOrder.ItemLines== null)
                {

                    return new Tuple<Status, Customer, string>(Status.Invalid, null, null);

                }
                if (_purchaseOrder.ItemLines.MembershipTypes!=null)
                {
                    _customer= ActivateMemberShip(_purchaseOrder);
                }
                if (_purchaseOrder.ItemLines.Products!=null)
                {
                    _generateSlip = GenerateSlip();
                }
                return new Tuple<Status, Customer, string>(Status.Success, _customer, _generateSlip);
            }
            catch (Exception ex)
            {
                return new Tuple<Status, Customer, string>(Status.Failed, null, null);
            }
        }

        private Customer ActivateMemberShip(PurchaseOrder purchaseOrder)
        {
            return new Customer()
            {
                CustomerId = purchaseOrder.CustomerId,
                MembershipType = purchaseOrder.ItemLines.MembershipTypes
            };
        }
        private string GenerateSlip()
        {
            return Constants.Messages.SlipGenerate;
        }
    }
}
