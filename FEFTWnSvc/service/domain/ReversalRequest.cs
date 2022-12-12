using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FEFTWnSvc
{
    [DataContract]
    public class ReversalRequest
    {
        [DataMember]
        public String amount { get; set; }
        [DataMember]
        public String transKey { get; set; }
        [DataMember]
        public String bank { get; set; }

    }
}
