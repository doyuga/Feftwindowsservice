using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FEFTWnSvc
{
    [DataContract]
    public class ReconResponse
    {
        [DataMember]
        public String slip { get; set; }
        [DataMember]
        public String ResponseCodeHost { get; set; }
        [DataMember]
        public String respCode { get; set; }
        [DataMember]
        public String msg { get; set; }
    }
}
