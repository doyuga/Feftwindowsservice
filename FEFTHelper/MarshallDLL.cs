using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Net;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
//using ECR.My; Syst
//using System.Configuration.

namespace FEFTHelper
{
    public class MarshallDLL
    {
        // logger for ...
        private static Logger log = new Logger();
        public string invoiceno;
        public Hashtable execSale(string amount, string cashBack, string CashierID,string TillNo, string transKey, bool log_Debug)
        
        {
            Hashtable hsh = null;
            try
            {
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Instantiating Marshall.dll's Request & Response objects");
                //ecr.
                
                
                ECR.ComECR preq = new ECR.ComECR();
                double x = 0;
                double z = 0.00;
                double.TryParse(amount, out x);
                double y = 0;
                double.TryParse(cashBack, out y);
                double cback;

                if (y > 0)
                {
                    if (x / 100 >= 500)
                    {
                        z = ((x + y)/ 100) + 30;
                        cback = y / 100;
                    }
                    else
                    {
                        z = (x) / 100;
                        cback = y / 100;
                        //y = 0;
                        //cback = 0;
                    }
                }
                else
                {
                    z = (x) / 100;
                    cback = 0;
                    //y = 0;
                }
                string vfiamount;
                vfiamount = z.ToString("0.00");

                preq.GetSet_VFI_Amount = Utils.formatAmount(vfiamount, true);
                //preq.GetSet_VFI_Amount = Utils.formatAmount(lesscashbakamount, true);
                preq.GetSet_VFI_ECRRcptNum = "123";
                preq.GetSet_VFI_CashBackAmount = Utils.formatAmount(y.ToString("0.00"), true);
                //preq.GetSet_VFI_CashBackAmount = Utils.formatAmount("0", true);
                preq.GetSet_VFI_CurrCode = ConfigurationManager.AppSettings["currencyCode"];

                preq.GetSet_VFI_TID = ConfigurationManager.AppSettings["kcbtid"];
                preq.GetSet_VFI_PTID = ConfigurationManager.AppSettings["kcbptid"];

                preq.GetSet_VFI_OrgionalInvoiceNo = "1234";

                if (cback <= 0)
                {
                    //preq.VFI_GetTelNo();
                    preq.VFI_GetAuth();



                    //preq.OperationCode = Convert.ToInt32(ConfigurationManager.AppSettings["sale_Op"]);

                    log.LogMsg(LogModes.FILE_LOG_KCB,
                        LogLevel.INFO,
                        string.Format("REQ.SALE. Marshall Request: Amount={0}, Cashback={1}, CurrencyCode={2}, OperationCode={3}",
                       preq.GetSet_VFI_Amount, 0, preq.GetSet_VFI_CurrCode, ""));

                    //debug
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB,
                            LogLevel.INFO,
                            string.Format("REQ.SALE. Marshall Request: Amount={0}, Cashback={1}, CurrencyCode={2}, OperationCode={3}",
                            preq.GetSet_VFI_Amount, 0, preq.GetSet_VFI_CurrCode, ""));

                    //log initializations
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Instantiating Marshall.dll and executing the Sale Transaction");

                    hsh = new Hashtable();


                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Retrieving results from Mashall.dll Sale Transaction");

                    //hsh = new Hashtable();
                    if (y > 500)
                    {
                        hsh["amount"] = Utils.formatAmount(((z - 30) * 100).ToString("0.00"), false);

                    }
                    else
                    {
                        hsh["amount"] = Utils.formatAmount(preq.GetSet_VFI_Amount, false);
                    }
                    hsh["cashBack"] = Utils.formatAmount(preq.GetSet_VFI_CashBackAmount, false);

                    hsh["cashBack"] = Utils.formatAmount((cback * 100).ToString("0.00"), false);
                    string hpaydetails1;
                    hpaydetails1 = preq.GetSet_VFI_CHVerification;

                    if (hpaydetails1 == "1")
                    {
                        hsh["msg"] = "Attempted Fraud case, Pin Bypassed";
                        hsh["respCode"] = "DANGER..XX";
                    }
                    else
                    {
                        hsh["respCode"] = (string.IsNullOrEmpty(preq.GetSet_VFI_RespCode)) ? "999" : ((preq.GetSet_VFI_RespCode == "000") ? "00" : preq.GetSet_VFI_RespCode);
                        hsh["msg"] = preq.GetSet_VFI_RespMess;
                    }

                    hsh["authCode"] = preq.GetSet_VFI_ApprovalCode;
                    hsh["rrn"] = preq.GetSet_VFI_REFNO;

                    hsh["invoiceNo"] = preq.GetSet_VFI_InvoiceNo;
                    //ConfigurationManager.AppSettings


                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["invoiceno"].Value = preq.GetSet_VFI_InvoiceNo;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");

                    if ((string.IsNullOrEmpty(preq.GetSet_VFI_ApprovalCode) || string.IsNullOrEmpty(preq.GetSet_VFI_REFNO))
                        &&
                       (Convert.ToString(preq.GetSet_VFI_RespCode) == "000" || Convert.ToString(preq.GetSet_VFI_RespCode) == "00"))
                    {
                        hsh["respCode"] = "";
                        hsh["msg"] = "Refer to your Bank";
                    }

                    hsh["cardExpiry"] = preq.GetSet_VFI_Expiry;
                    hsh["currency"] = preq.GetSet_VFI_CurrCode;
                    hsh["pan"] = Utils.maskPAN(preq.GetSet_VFI_CardNum);
                    hsh["tid"] = preq.GetSet_VFI_TID;
                    hsh["transType"] = "Sale";
                    hsh["payDetails"] = preq.GetSet_VFI_CardName;
                    hsh["mid"] = preq.GetSet_VFI_MID;
                    hsh["sign"] = "";

                    hsh["pin"] = "true";
                    string merchant = ConfigurationManager.AppSettings["merchant"];
                    string branch = ConfigurationManager.AppSettings["branch"];
                }
                else if(x<50000)
                {
                    hsh = new Hashtable();
                    hsh["msg"] = "You do not qualify for Cash back; insufficient Purchase";
                    hsh["respCode"] = "CBX";
                }
                else if (cback > 20000)
                {
                    hsh = new Hashtable();
                    hsh["msg"] = "Cashback amount exceeded";
                    hsh["respCode"] = "CBX";
                }

                else
                {
                    preq.VFI_GetAuth();



                    //preq.OperationCode = Convert.ToInt32(ConfigurationManager.AppSettings["sale_Op"]);

                    log.LogMsg(LogModes.FILE_LOG_KCB,
                        LogLevel.INFO,
                        string.Format("REQ.SALE. Marshall Request: Amount={0}, Cashback={1}, CurrencyCode={2}, OperationCode={3}",
                       preq.GetSet_VFI_Amount, 0, preq.GetSet_VFI_CurrCode, ""));

                    //debug
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB,
                            LogLevel.INFO,
                            string.Format("REQ.SALE. Marshall Request: Amount={0}, Cashback={1}, CurrencyCode={2}, OperationCode={3}",
                            preq.GetSet_VFI_Amount, 0, preq.GetSet_VFI_CurrCode, ""));

                    //log initializations
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Instantiating Marshall.dll and executing the Sale Transaction");

                    hsh = new Hashtable();


                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Retrieving results from Mashall.dll Sale Transaction");

                    //hsh = new Hashtable();
                    if (y > 500)
                    {
                        hsh["amount"] = Utils.formatAmount(((z - 30) * 100).ToString("0.00"), false);

                    }
                    else
                    {
                        hsh["amount"] = Utils.formatAmount(preq.GetSet_VFI_Amount, false);
                    }
                    hsh["cashBack"] = Utils.formatAmount(preq.GetSet_VFI_CashBackAmount, false);

                    hsh["cashBack"] = Utils.formatAmount((cback * 100).ToString("0.00"), false);
                    hsh["authCode"] = preq.GetSet_VFI_ApprovalCode;
                    hsh["rrn"] = preq.GetSet_VFI_REFNO;
                    hsh["msg"] = preq.GetSet_VFI_RespMess;
                    hsh["respCode"] = (string.IsNullOrEmpty(preq.GetSet_VFI_RespCode)) ? "999" : ((preq.GetSet_VFI_RespCode == "000") ? "00" : preq.GetSet_VFI_RespCode);
                    hsh["invoiceNo"] = preq.GetSet_VFI_InvoiceNo;
                   


                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["invoiceno"].Value = preq.GetSet_VFI_InvoiceNo;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");

                    if ((string.IsNullOrEmpty(preq.GetSet_VFI_ApprovalCode) || string.IsNullOrEmpty(preq.GetSet_VFI_REFNO))
                        &&
                       (Convert.ToString(preq.GetSet_VFI_RespCode) == "000" || Convert.ToString(preq.GetSet_VFI_RespCode) == "00"))
                    {
                        hsh["respCode"] = "";
                        hsh["msg"] = "Refer to your Bank";
                    }

                    hsh["cardExpiry"] = preq.GetSet_VFI_Expiry;
                    hsh["currency"] = preq.GetSet_VFI_CurrCode;
                    hsh["pan"] = Utils.maskPAN(preq.GetSet_VFI_CardNum);
                    hsh["tid"] = preq.GetSet_VFI_TID;
                    hsh["transType"] = "Sale";
                    hsh["payDetails"] = preq.GetSet_VFI_CardName;
                    hsh["mid"] = preq.GetSet_VFI_MID;
                    hsh["sign"] = "";
                    hsh["pin"] = "true";
                    string merchant = ConfigurationManager.AppSettings["merchant"];
                    string branch = ConfigurationManager.AppSettings["branch"];
                }
                string respcode = (string.IsNullOrEmpty(preq.GetSet_VFI_RespCode)) ? "999" : ((preq.GetSet_VFI_RespCode == "000") ? "00" : preq.GetSet_VFI_RespCode);



                //logtocloud(preq.GetSet_VFI_REFNO, preq.GetSet_VFI_ApprovalCode, z, x , y, "KCB", "KCB", preq.GetSet_VFI_MID, preq.GetSet_VFI_TID, preq.GetSet_VFI_CardNum, preq.GetSet_VFI_CardName, DateTime.Now, "SALE",preq.GetSet_VFI_RespMess, preq.GetSet_VFI_MID, preq.GetSet_VFI_TID, CashierID, preq.GetSet_VFI_InvoiceNo,respcode,TillNo);


                log.LogMsg(LogModes.FILE_LOG_KCB,
                    LogLevel.INFO,
                    string.Format("RES.SALE. Marshall Response: Amount={0}, CashBack={1}, AuthCode={2}, ResponseCode={3}, CardExpiry={4}, CurrencyCode={5}, Message={6}, PAN={7}, TID={8}, RRN={9}, TransType={10}",
                    preq.GetSet_VFI_Amount, "0", hsh["authCode"], hsh["respCode"], hsh["cardExpiry"], hsh["currency"], hsh["msg"], hsh["pan"], hsh["tid"], hsh["rrn"], hsh["transType"]));

                //debug
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG_KCB,
                    LogLevel.INFO,
                    string.Format("RES.SALE. Marshall Response: Amount={0}, CashBack={1}, AuthCode={2}, ResponseCode={3}, CardExpiry={4}, CurrencyCode={5}, Message={6}, PAN={7}, TID={8}, RRN={9}, TransType={10}",
                    preq.GetSet_VFI_Amount, "0", hsh["authCode"], hsh["respCode"], hsh["cardExpiry"], hsh["currency"], hsh["msg"], hsh["pan"], hsh["tid"], hsh["rrn"], hsh["transType"]));
            }
            catch (Exception ex)
            {
                log.LogMsg(LogModes.FILE_LOG_KCB, LogLevel.ERROR, ex.ToString());
            }
           

            return hsh;
        }

        public Hashtable execReversal(string Amount, string TransKey, bool log_Debug)
        {
            Hashtable hsh = null;
            try
            {
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Instantiating Marshall.dll's Request & Response objects");

                //ARCCOMLib.SAPacketObj preq = new ARCCOMLib.SAPacketObj();
                ECR.ComECR preq = new ECR.ComECR();
                //ARCCOMLib.SAPacketObj pres = new ARCCOMLib.SAPacketObj();

               // preq.ReferenceNumber = rrn;
                preq.GetSet_VFI_ECRRcptNum=TransKey;
                //preq.VFI_ECRRcptNum = ;
                preq.GetSet_VFI_Amount = Utils.formatAmount(Amount, true);
/////////////////////////////////////////////////////////////////////////////////////////////////////

                preq.GetSet_VFI_VoidInvoiceNo = ConfigurationManager.AppSettings["invoiceno"];//for auto reverals eg safaricom
                preq.GetSet_VFI_CurrCode = ConfigurationManager.AppSettings["currencyCode"];
                preq.GetSet_VFI_PTID = ConfigurationManager.AppSettings["kcbptid"];
               // preq.OperationCode = Convert.ToInt32(ConfigurationManager.AppSettings["reversal_Op"]);
                log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "starting");
                
                if (!preq.VFI_VoidTrans())
                {


                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "failuresssssssss");
                }

                else
                {
                    //log initializations
                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "starting2");

                    hsh = new Hashtable();
                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "s3");


                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Retrieving results from Marshall.dll Reversal Transaction");
                    //hsh = new Hashtable();
                    hsh["amount"] = Utils.formatAmount(preq.GetSet_VFI_Amount, false);
                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Reversal passed1" + preq.VFI_Amount);
                    hsh["cashBack"] = Utils.formatAmount("0", false);
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
                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "sv" + preq.GetSet_VFI_CardName);
                    //}
                    //else
                    //{
                    //    hsh["rrn"] = Transkey;
                    //    hsh["amount"] = amount;
                    //    hsh["respCode"] = "402";
                    //    hsh["msg"] = "Connection broke. Transaction could not be completed.";
                    //}

                    //log initializations
                    log.LogMsg(LogModes.FILE_LOG_KCB,
                        LogLevel.INFO,
                        string.Format("RES.REVERSAL. Marshall Response: Amount={0}, Cashback={1}, AuthCode={2}, ResponseCode={3}, CardExpiry={4}, CurrencyCode={5}, Message={6}, PAN={7}, TID={8}, RRN={9}, TransType={10}",
                        preq.VFI_Amount, hsh["authCode"], hsh["respCode"], hsh["cardExpiry"], hsh["currency"], hsh["msg"], hsh["pan"], hsh["tid"], hsh["rrn"], hsh["transType"]));

                    //debug
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB,
                            LogLevel.INFO,
                            string.Format("RES.REVERSAL. Marshall Response: Amount={0}, Cashback={1}, AuthCode={2}, ResponseCode={3}, CardExpiry={4}, CurrencyCode={5}, Message={6}, PAN={7}, TID={8}, RRN={9}, TransType={10}",
                            preq.VFI_Amount, hsh["authCode"], hsh["respCode"], hsh["cardExpiry"], hsh["currency"], hsh["msg"], hsh["pan"], hsh["tid"], hsh["rrn"], hsh["transType"]));
                }
               }

            catch (Exception ex)
            {
                log.LogMsg(LogModes.FILE_LOG_KCB, LogLevel.ERROR, ex.ToString());
            }

            return hsh;
        
        }
        public Hashtable getphoneno(bool log_Debug)
        {
            Hashtable hsh = null;
            try
            {
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Instantiating Marshall.dll's Request & Response objects");

                ECR.ComECR preq = new ECR.ComECR();
    
                preq.GetSet_VFI_PTID = ConfigurationManager.AppSettings["kcbptid"];
                // preq.OperationCode = Convert.ToInt32(ConfigurationManager.AppSettings["reversal_Op"]);
                log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "starting");

                if (!preq.VFI_GetTelNo())
                {
                   // preq.vfi

                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "failuresssssssss");
                }

                else
                {
                    //log initializations
                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "starting2");

                    hsh = new Hashtable();
                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "s3");
                    //if (con)
                    //{
                    //ARCCOMLib.PCPOSTConnectorObj svr = new ARCCOMLib.PCPOSTConnectorObj();
                    //int status = svr.Exchange(ref preq, ref preq, 12000);

                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Retrieving results from Marshall.dll Reversal Transaction");
                    //hsh = new Hashtable();
                    hsh["amount"] = Utils.formatAmount(preq.GetSet_VFI_Amount, false);
                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Reversal passed1" + preq.VFI_Amount);
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
                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "sv" + preq.GetSet_VFI_CardName);
                    //}
                    //else
                    //{
                    //    hsh["rrn"] = Transkey;
                    //    hsh["amount"] = amount;
                    //    hsh["respCode"] = "402";
                    //    hsh["msg"] = "Connection broke. Transaction could not be completed.";
                    //}

                    //log initializations
                    log.LogMsg(LogModes.FILE_LOG_KCB,
                        LogLevel.INFO,
                        string.Format("RES.REVERSAL. Marshall Response: Amount={0}, Cashback={1}, AuthCode={2}, ResponseCode={3}, CardExpiry={4}, CurrencyCode={5}, Message={6}, PAN={7}, TID={8}, RRN={9}, TransType={10}",
                        preq.VFI_Amount, hsh["authCode"], hsh["respCode"], hsh["cardExpiry"], hsh["currency"], hsh["msg"], hsh["pan"], hsh["tid"], hsh["rrn"], hsh["transType"]));

                    //debug
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB,
                            LogLevel.INFO,
                            string.Format("RES.REVERSAL. Marshall Response: Amount={0}, Cashback={1}, AuthCode={2}, ResponseCode={3}, CardExpiry={4}, CurrencyCode={5}, Message={6}, PAN={7}, TID={8}, RRN={9}, TransType={10}",
                            preq.VFI_Amount, hsh["authCode"], hsh["respCode"], hsh["cardExpiry"], hsh["currency"], hsh["msg"], hsh["pan"], hsh["tid"], hsh["rrn"], hsh["transType"]));
                }
            }

            catch (Exception ex)
            {
                log.LogMsg(LogModes.FILE_LOG_KCB, LogLevel.ERROR, ex.ToString());
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
        private bool logtocloud(string rrn,string authcode,double amount,double saleamount,double cashback,string bankcode, string bankname,string mid,string tid, string pan, string cardholder,DateTime transdate,string transtype,string msg,string merchant, string branch,string cashierid,string invoiceno,string respcode,string TillNo)
        {
            bool success = false;
            //string connectionString = "Persist Security Info=False;User ID=feft;Password=Delivered,1206!;Initial Catalog=FEFT;Server=208.91.198.196";
            string connectionString = ConfigurationManager.ConnectionStrings["Cloud"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO feft.EFTTransactions (Rrn, Authcode, Amount,Saleamount,Cashback,Bankcode,Bankname,Mid,Tid,Pan,Cardholder,Transdate,Transtype,Msg,Merchant,Branch,CashierID,invoiceno,respcode,tillno) VALUES (@rrn, @authcode, @amount,@saleamount,@cashback,@bankcode,@bankname,@mid,@tid,@pan,@cardholder,@transdate,@transtype,@msg,@merchant,@branch,@cashierid,@invoiceno,@respcode,@tillno)");
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

                        cmd.Parameters.AddWithValue("@amount", amount);
                    
                        cmd.Parameters.AddWithValue("@saleamount", saleamount);

                        cmd.Parameters.AddWithValue("@cashback", cashback);
                        cmd.Parameters.AddWithValue("@msg", msg);
                  

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

                    if (string.IsNullOrEmpty(cashierid))
                    {
                        cmd.Parameters.AddWithValue("@cashierid", DBNull.Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@cashierid", cashierid);
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

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                
            }
            catch (Exception ex)
            {
                string ms = ex.ToString();
                success = false;
            }

            return success;
        }
    }
}
