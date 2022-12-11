using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FEFTWnSvc
{
    [DataContract]
    public class FEFTResponse
    {
        [DataMember]
        public String amount { get; set; }
        [DataMember]
        public String cashBack { get; set; }
        [DataMember]
        public String respCode { get; set; }
        [DataMember]
        public String msg { get; set; }
        [DataMember]
        public String rrn { get; set; }
        [DataMember]
        public String pan { get; set; }
        [DataMember]
        public String cardExpiry { get; set; }
        [DataMember]
        public String currency { get; set; }
        [DataMember]
        public String tid { get; set; }
        [DataMember]
        public String mid { get; set; }
        [DataMember]
        public String transactionType { get; set; }
        [DataMember]
        public String authCode { get; set; }
        [DataMember]
        public String paymentDetails { get; set; }
        [DataMember]
        public String invoiceNo { get; set; }

        [DataMember]
        public String sign { get; set; }
        [DataMember]
        public String pin { get; set; }

        [DataMember]
        public String slip { get; set; }

    }
}
