using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessPurchaseOrder.BusinessEntity;
using ProcessPurchaseOrder.Common;

namespace ProcessPurchaseOrder.BusinessLogic
{
    public interface IProcessOrder
    {
        public Tuple<Status, Customer, string> Process();
    }
}
