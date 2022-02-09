using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessPurchaseOrder.Common
{
    public static class Constants
    {
        public static class Messages
        {
            public const string SlipGenerate = "Slip is generated";
        }
    }
    public enum Membership
    {
        Premium,
        BookClub,
        VideoClub,

    }
    public enum Status
    {
        Success,
        Invalid,
        Failed
    }
    
}
