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
            UriTemplate = "sale/{transKey},{Bank},{amount},{cashBack},{tillNO},{CashierId}")]
        FEFTResponse sale(string transKey, string Bank, string amount, string cashBack, string CashierId, string tillNO);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "reversal/{TransKey},{Bank},{Amount}")]
        FEFTResponse reversal(string TransKey, string Bank, string Amount);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "recon/{Bank}")]
        ReconResponse recon(string Bank);

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
