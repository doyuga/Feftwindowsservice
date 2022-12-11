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
        public String Amount { get; set; }
        [DataMember]
        public String TransKey { get; set; }
        [DataMember]
        public String Bank { get; set; }

    }
}
