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
        public String transKey { get; set; }
        [DataMember]
        public String amount { get; set; }
        [DataMember]
        public String cashBack { get; set; }
        [DataMember]
        public String tillNo { get; set; }
        [DataMember]
        public String bank { get; set; }

        [DataMember]
        public String cashierId { get; set; }
        [DataMember]
        public String mobileId { get; set; }
    }
}
