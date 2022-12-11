using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FEFTWnSvc
{
    [DataContract]
    public class SaleRequest
    {
        [DataMember]
        public String TransKey { get; set; }
        [DataMember]
        public String Amount { get; set; }
        [DataMember]
        public String CashBack { get; set; }
        [DataMember]
        public String TillNO { get; set; }
        [DataMember]
        public String Bank { get; set; }

        [DataMember]
        public String CashierId { get; set; }
    }
}
