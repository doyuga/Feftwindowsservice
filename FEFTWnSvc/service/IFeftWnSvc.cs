using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;



namespace FEFTWnSvc
{
    [ServiceContract]
   public interface IFeftWnSvc
    {
        //const string DefaultValue = "1";
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "sale/{transKey},{bank},{amount},{cashBack},{tillNO},{cashierId},{mobileId}")]
        FEFTResponse sale(string transKey, string bank, string amount, string cashBack, string tillNo, string cashierId,string mobileId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "reversal/{transKey},{bank},{amount}")]
        FEFTResponse reversal(string TransKey, string bank, string Amount);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "recon/{bank}")]
        ReconResponse recon(string bank);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "echotest")]
        EchotestResponse echotest();

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "sale")]
        FEFTResponse execSale(SaleRequest req);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "reversal")]
        FEFTResponse execReversal(ReversalRequest req);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "echotest")]
        EchotestResponse execEchotest(EchotestRequest req);



        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "recon")]
        ReconResponse execRecon(ReconRequest req);




        [OperationContract]
        [WebInvoke(Method = "OPTIONS",
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "sale")]
        FEFTResponse opSale(SaleRequest req);
    }
}
