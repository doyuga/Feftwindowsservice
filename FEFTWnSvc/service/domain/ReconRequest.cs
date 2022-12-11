using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FEFTWnSvc
{
    [DataContract]
    public class ReconRequest
    {

        [DataMember]
        public String Bank { get; set; }
    }
}
