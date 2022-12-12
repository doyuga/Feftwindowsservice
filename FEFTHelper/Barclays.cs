using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
//using fe

//using System.Net.

namespace FEFTHelper
{
   public class Barclays
    {
        // logger for ...
        private static Logger log = new Logger();
        public string invoiceno;
        public string respoX;
        //public Hashtable execSale(string amount, string cashBack, string tillNO, string transKey, bool log_Debug)
        public Hashtable execSale(string amount, string cashBack, string cashierId, string tillNo, string transKey,string mobileId, bool log_Debug)
        {
            Hashtable hsh = null;
            try
            {
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG_BBK, LogLevel.INFO, "Instantiating Marshall.dll's Request & Response objects");

                respoX = HttpGetRequest("", "", transKey, amount, tillNo);
                var p = JsonConvert.DeserializeObject<responsedata>(respoX);         

                hsh = new Hashtable();

                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG_BBK, LogLevel.INFO, "Retrieving results from Mashall.dll Sale Transaction");
                double x = 0;
                double.TryParse(amount, out x);
                hsh["amount"] = Utils.formatAmount(amount, false);
                hsh["cashBack"] = Utils.formatAmount("0", false);
                hsh["authCode"] = p.authCode;
                hsh["rrn"] = p.retRefNr;
                hsh["msg"] = p.message;
                if (p.rspCode == "000")
                {
                    hsh["respCode"] = "00";
                }
                else
                {
                    hsh["respCode"] = p.rspCode;
                }
                hsh["pan"] =p.pan; 
                hsh["tid"] = p.tid;
                hsh["transType"] = "Sale";
                hsh["payDetails"] = p.cardholderName;
                hsh["invoiceNo"] = p.stan;

                hsh["cardExpiry"] = p.cardExpiry;
                hsh["currency"] = p.currency;
                hsh["pan"] = p.pan;
                hsh["tid"] = p.tid;
                hsh["transType"] = "Sale";
                hsh["payDetails"] = p.cardholderName;
                hsh["mid"] = p.mid;
                hsh["sign"] = p.pinVerified;
                hsh["pin"] = "true";
                string merchant = ConfigurationManager.AppSettings["merchant"];
                string branch = ConfigurationManager.AppSettings["branch"];
                
                logtocloud(p.retRefNr, p.authCode, x/100, x/100, 0, "BBK", "BBK", p.mid, p.tid, p.pan, p.cardholderName, DateTime.Now, "SALE", p.message, "TNH", p.mid, cashierId, p.stan, p.rspCode, tillNo,transKey);


            }
            catch (Exception ex)
            {
                log.LogMsg(LogModes.FILE_LOG_BBK, LogLevel.ERROR, ex.ToString());
            }

            return hsh;
        }

        public Hashtable execReversal(string Amount, string TransKey, bool log_Debug)
        {
            Hashtable hsh = null;
            try
            {
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG_BBK, LogLevel.INFO, "Instantiating Till Integration Request & Response objects");

                respoX = HttpGetReversalRequest("", "", TransKey, Amount);
                var p = JsonConvert.DeserializeObject<responsedata>(respoX);

                hsh = new Hashtable();

                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG_BBK, LogLevel.INFO, "Retrieving results from Till Integration Reversal Transaction");
                double x = 0;
                double.TryParse(Amount, out x);
                hsh["amount"] = Utils.formatAmount(Amount, false);
                hsh["cashBack"] = Utils.formatAmount("0", false);
                hsh["authCode"] = p.authCode;
                hsh["rrn"] = p.retRefNr;
                hsh["msg"] = p.message;
                if (p.rspCode == "000")
                {
                    hsh["respCode"] = "00";
                    if (string.IsNullOrEmpty(p.message))
                    {
                        hsh["msg"] = "Reversal Successful";
                    }
                }
                else
                {
                    hsh["respCode"] = p.rspCode;
                }
                hsh["pan"] = p.pan;
                hsh["tid"] = p.tid;
                hsh["transType"] = "Reversal";
                hsh["payDetails"] = p.cardholderName;
                hsh["invoiceNo"] = p.stan;

                hsh["cardExpiry"] = p.cardExpiry;
                hsh["currency"] = p.currency;
                hsh["pan"] = p.pan;
                hsh["tid"] = p.tid;
                hsh["transType"] = "Reversal";
                hsh["payDetails"] = p.cardholderName;
                hsh["mid"] = p.mid;
                hsh["sign"] = p.pinVerified;
                hsh["pin"] = "true";
                string merchant = ConfigurationManager.AppSettings["merchant"];
                string branch = ConfigurationManager.AppSettings["branch"];

                logtocloud(p.retRefNr, p.authCode, x / 100, x / 100, 0, "BBK", "BBK", p.mid, p.tid, p.pan, p.cardholderName, DateTime.Now, "Reversal", p.message, "TNH", p.mid, "0", p.stan, p.rspCode, "0", TransKey);


            }
            catch (Exception ex)
            {
                log.LogMsg(LogModes.FILE_LOG_BBK, LogLevel.ERROR, ex.ToString());
            }

            return hsh;

        }

        private bool logtocloud(string rrn, string authcode, double amount, double saleamount, double cashback, string bankcode, string bankname, string mid, string tid, string pan, string cardholder, DateTime transdate, string transtype, string msg, string merchant, string branch, string cashierId, string invoiceno, string respcode, string TillNo,string transKey)
        {
            bool success = false;
            //string connectionString = "Persist Security Info=False;User ID=feft;Password=Delivered,1206!;Initial Catalog=FEFT;Server=208.91.198.196";
            string connectionString = ConfigurationManager.ConnectionStrings["Cloudbbk"].ConnectionString;
            //string connectionString = ConfigurationManager.ConnectionStrings["Cloud"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO EFTTransactions (Rrn, Authcode, Amount,Saleamount,Cashback,Bankcode,Bankname,Mid,Tid,Pan,Cardholder,Transdate,Transtype,Msg,Merchant,Branch,cashierId,invoiceno,respcode,tillno,transKey) VALUES (@rrn, @authcode, @amount,@saleamount,@cashback,@bankcode,@bankname,@mid,@tid,@pan,@cardholder,@transdate,@transtype,@msg,@merchant,@branch,@cashierId,@invoiceno,@respcode,@tillno,@transKey)");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;

                    if (string.IsNullOrEmpty(rrn))
                    {
                        cmd.Parameters.AddWithValue("@rrn", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@rrn", rrn);
                    }

                    if (string.IsNullOrEmpty(authcode))
                    {
                        cmd.Parameters.AddWithValue("@authcode", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@authcode", authcode);
                    }

                    if (string.IsNullOrEmpty(msg))
                    {
                        cmd.Parameters.AddWithValue("@msg", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@msg", msg);
                    }


                    //if (string.IsNullOrEmpty(amount))
                    //{
                    //    cmd.Parameters.AddWithValue("@amount", DBNull.Value.ToString());
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@amount", amount);
                    //}
                    cmd.Parameters.AddWithValue("@amount", amount);

                    cmd.Parameters.AddWithValue("@saleamount", saleamount);

                    cmd.Parameters.AddWithValue("@cashback", cashback);
                   


                    if (string.IsNullOrEmpty(bankcode))
                    {
                        cmd.Parameters.AddWithValue("@bankcode", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@bankcode", bankcode);
                    }

                    if (string.IsNullOrEmpty(bankname))
                    {
                        cmd.Parameters.AddWithValue("@bankname", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@bankname", bankname);
                    }

                    if (string.IsNullOrEmpty(mid))
                    {
                        cmd.Parameters.AddWithValue("@mid", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@mid", mid);
                    }

                    if (string.IsNullOrEmpty(tid))
                    {
                        cmd.Parameters.AddWithValue("@tid", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@tid", tid);
                    }

                    if (string.IsNullOrEmpty(pan))
                    {
                        cmd.Parameters.AddWithValue("@pan", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@pan", pan);
                    }

                    if (string.IsNullOrEmpty(cardholder))
                    {
                        cmd.Parameters.AddWithValue("@cardholder", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@cardholder", cardholder);
                    }


                    cmd.Parameters.AddWithValue("@transdate", transdate);


                    if (string.IsNullOrEmpty(transtype))
                    {
                        cmd.Parameters.AddWithValue("@transtype", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@transtype", transtype);
                    }

                    if (string.IsNullOrEmpty(merchant))
                    {
                        cmd.Parameters.AddWithValue("@merchant", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@merchant", merchant);
                    }

                    if (string.IsNullOrEmpty(branch))
                    {
                        cmd.Parameters.AddWithValue("@branch", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@branch", branch);
                    }

                    if (string.IsNullOrEmpty(cashierId))
                    {
                        cmd.Parameters.AddWithValue("@cashierId", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@cashierId", cashierId);
                    }

                    if (string.IsNullOrEmpty(invoiceno))
                    {
                        cmd.Parameters.AddWithValue("@invoiceno", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@invoiceno", invoiceno);
                    }

                    if (string.IsNullOrEmpty(respcode))
                    {
                        cmd.Parameters.AddWithValue("@respcode", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@respcode", respcode);
                    }

                    if (string.IsNullOrEmpty(TillNo))
                    {
                        cmd.Parameters.AddWithValue("@TillNo", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TillNo", TillNo);
                    }

                    if (string.IsNullOrEmpty(transKey))
                    {
                        cmd.Parameters.AddWithValue("@transKey", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@transKey", transKey);
                    }

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    success = true;
                }

            }
            catch (Exception e )
            {
                string x=e.Message;
                success = false;
            }

            return success;
        }


        public Hashtable getphoneno(bool log_Debug)
        {
            Hashtable hsh = null;
            try
            {
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG_BBK, LogLevel.INFO, "Instantiating Marshall.dll's Request & Response objects");

                ECR.ComECR preq = new ECR.ComECR();

                preq.GetSet_VFI_PTID = ConfigurationManager.AppSettings["BBKptid"];
                // preq.OperationCode = Convert.ToInt32(ConfigurationManager.AppSettings["reversal_Op"]);
                log.LogMsg(LogModes.FILE_DEBUG_BBK, LogLevel.INFO, "starting");

                if (!preq.VFI_GetTelNo())
                {
                    // preq.vfi

                    log.LogMsg(LogModes.FILE_DEBUG_BBK, LogLevel.INFO, "failuresssssssss");
                }

                else
                {
                    //log initializations
                    log.LogMsg(LogModes.FILE_DEBUG_BBK, LogLevel.INFO, "starting2");
                    hsh = new Hashtable();
                    log.LogMsg(LogModes.FILE_DEBUG_BBK, LogLevel.INFO, "s3");
                    //if (con)
                    //{
                    //ARCCOMLib.PCPOSTConnectorObj svr = new ARCCOMLib.PCPOSTConnectorObj();
                    //int status = svr.Exchange(ref preq, ref preq, 12000);

                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_BBK, LogLevel.INFO, "Retrieving results from Marshall.dll Reversal Transaction");
                    //hsh = new Hashtable();
                    hsh["amount"] = Utils.formatAmount(preq.GetSet_VFI_Amount, false);
                    log.LogMsg(LogModes.FILE_DEBUG_BBK, LogLevel.INFO, "Validating Reversal passed1" + preq.VFI_Amount);
                    //hsh["cashBack"] = Utils.formatAmount(preq.CashbackAmount, false);
                    hsh["cashBack"] = 0;
                    hsh["authCode"] = preq.GetSet_VFI_ApprovalCode;
                    hsh["msg"] = preq.GetSet_VFI_RespMess;
                    hsh["rrn"] = preq.GetSet_VFI_ECRRcptNum;
                    hsh["respCode"] = string.IsNullOrEmpty(preq.GetSet_VFI_RespCode) ? "999" : ((preq.GetSet_VFI_RespCode == "000") ? "00" : preq.GetSet_VFI_RespCode);
                    hsh["cardExpiry"] = preq.GetSet_VFI_Expiry;
                    hsh["currency"] = preq.GetSet_VFI_CurrCode;
                    hsh["pan"] = Utils.maskPAN(preq.GetSet_VFI_CardNum);
                    hsh["tid"] = preq.VFI_TID;
                    hsh["transType"] = preq.GetSet_VFI_TransType;
                    hsh["payDetails"] = preq.GetSet_VFI_CardName;
                    hsh["sign"] = "";
                    hsh["pin"] = "true";
                    log.LogMsg(LogModes.FILE_DEBUG_BBK, LogLevel.INFO, "sv" + preq.GetSet_VFI_CardName);

                    log.LogMsg(LogModes.FILE_LOG_BBK,
                        LogLevel.INFO,
                        string.Format("RES.REVERSAL. Marshall Response: Amount={0}, Cashback={1}, AuthCode={2}, ResponseCode={3}, CardExpiry={4}, CurrencyCode={5}, Message={6}, PAN={7}, TID={8}, RRN={9}, TransType={10}",
                        preq.VFI_Amount, hsh["authCode"], hsh["respCode"], hsh["cardExpiry"], hsh["currency"], hsh["msg"], hsh["pan"], hsh["tid"], hsh["rrn"], hsh["transType"]));

                    //debug
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_BBK,
                            LogLevel.INFO,
                            string.Format("RES.REVERSAL. Marshall Response: Amount={0}, Cashback={1}, AuthCode={2}, ResponseCode={3}, CardExpiry={4}, CurrencyCode={5}, Message={6}, PAN={7}, TID={8}, RRN={9}, TransType={10}",
                            preq.VFI_Amount, hsh["authCode"], hsh["respCode"], hsh["cardExpiry"], hsh["currency"], hsh["msg"], hsh["pan"], hsh["tid"], hsh["rrn"], hsh["transType"]));
                }
            }

            catch (Exception ex)
            {
                log.LogMsg(LogModes.FILE_LOG_BBK, LogLevel.ERROR, ex.ToString());
            }

            return hsh;

        }

        private bool ConnectionAvailable()
        {
            bool success = false;
            string ip = ConfigurationManager.AppSettings["bankServerIP"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["bankServerPort"]);
            int timeout = Convert.ToInt32(ConfigurationManager.AppSettings["connectionTimeout"]);

            try
            {
                using (System.Net.Sockets.TcpClient tcp = new System.Net.Sockets.TcpClient())
                {
                    IAsyncResult ar = tcp.BeginConnect(ip, port, null, null);
                    System.Threading.WaitHandle wh = ar.AsyncWaitHandle;
                    try
                    {
                        if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(timeout), false))
                        {
                            tcp.Close();
                            throw new TimeoutException();
                        }
                        success = tcp.Connected;
                        tcp.EndConnect(ar);
                    }
                    finally
                    {
                        wh.Close();
                    }
                }
            }
            catch (Exception)
            {
                //log.LogMsg(LogModes.FILE_DEBUG, LogLevel.ERROR, ex.Message);
            }

            return success;
        }
        private string  HttpGetRequest(String url,String parameters,String trankey,String Amount,String tellerId) 
        {
            string  respstring = "";
            //var respstring;
           WinHttp.WinHttpRequest req; 
          
            string ip = ConfigurationManager.AppSettings["bankServerIP"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["bankServerPort"]);
            int timeout = Convert.ToInt32(ConfigurationManager.AppSettings["connectionTimeout"]);
               
            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:9991/api/sale");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"amount\":\"" + Amount + "\",\"cashback\":\"0\", \"tellerId\":\""+ tellerId +"\",\"tranKey\":\"" + trankey+"\",\"forcePan\":\"\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                     respstring = streamReader.ReadToEnd();

                }

            }
            catch (Exception)
            {
                //log.LogMsg(LogModes.FILE_DEBUG, LogLevel.ERROR, ex.Message);
            }

            return respstring;
        }
        private string HttpGetReversalRequest(String url, String parameters, String trankey, String Amount)
        {
            string respstring = "";
            //var respstring;
            WinHttp.WinHttpRequest req;

            string ip = ConfigurationManager.AppSettings["bankServerIP"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["bankServerPort"]);
            int timeout = Convert.ToInt32(ConfigurationManager.AppSettings["connectionTimeout"]);

            try
            {

                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:9991/api/reverse");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    //string json = "{\"amount\":\"" + Amount + "\",\"cashback\":\"0\", \"tellerId\":\"" + tellerId + "\",\"tranKey\":\"" + trankey + "\",\"forcePan\":\"\"}";
                    string json = "{\"tranKey\":\"" + trankey + "\"}";
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    respstring = streamReader.ReadToEnd();

                }

            }
            catch (Exception)
            {
                //log.LogMsg(LogModes.FILE_DEBUG, LogLevel.ERROR, ex.Message);
            }

            return respstring;
        }
    }
    public class responsedata
    {
        public String authCode { get; set; }
        public String retRefNr { get; set; }
        public String rspCode { get; set; }
        public String message { get; set; }
        public String pan { get; set; }
        public String tid { get; set; }
        public String mid { get; set; }
        public String cardholderName { get; set; }

        public String scheme { get; set; }
        public String tsi { get; set; }
        public String appExpiryDate { get; set; }
        public String tranKey { get; set; }
        public String cryptogramType { get; set; }
         public String currency { get; set; }
        public String applLabel { get; set; }
        public String cryptogram { get; set; }
        public String amount { get; set; }
         public String uti { get; set; }
        public String appPanSeqnum { get; set; }
        public String version { get; set; }
        public String appStartDate { get; set; }
        public String tvr { get; set; }
        public String pinVerified { get; set; }
        public String cardExpiry { get; set; }
        public String signatureRequired { get; set; }
        public String stan { get; set; }
        public String aid { get; set; }
    }
}
