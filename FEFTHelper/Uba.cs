using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace FEFTHelper
{
    public class Uba
    {
        // logger for ...uba
        private static Logger log = new Logger();
        public string invoiceno;
        public Hashtable execSale(string amount, string cashBack, string tillNO, string transKey, bool log_Debug)
        {
            Hashtable hsh = null;
            try
            {
                //if (log_Debug)
                //    log.LogMsg(LogModes.FILE_DEBUG_UBA, LogLevel.INFO, "Instantiating Marshall.dll's Request & Response objects");
                ////ecr.

                feft_uba.PinpadHandler pinpad = new feft_uba.PinpadHandler();
                pinpad.setHostParameters();//("", 9091);

                double x = 0;
                double z = 0.00;
                double.TryParse(amount, out x);
                double y = 0;
                double.TryParse(cashBack, out y);

                //if (y > 0)
                //{
                //    z = (x ) / 100;
                //}
                //else
                //{
                //    z = (x) / 100;
                //}
                z = (x) / 100;
                if (y <= 0)
                {
                    string vfiamount;
                    vfiamount = z.ToString("0.00");
                    string received = pinpad.sendEftRequest((long)int.Parse(amount));
                    //Response: <TransactionResponse><Status>Declined</Status><BatchNo>41</BatchNo><SequenceNo>36</SequenceNo><Date></Date><Time>08/07/2016</Time><MaskedPAN>18:46</MaskedPAN><CardHolderName>517335XXXX4247</CardHolderName></TransactionResponse>

                    if (received != null)
                    {
                        hsh = new Hashtable();
                        hsh["amount"] = Utils.formatAmount(amount, false);
                        hsh["cashBack"] = Utils.formatAmount("0", false);
                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml(received);

                        XmlNode p = xml.SelectSingleNode("TransactionResponse");

                        if (p != null)
                        {
                            if (p["AuthID"] != null)
                            {
                                hsh["authCode"] = p["AuthID"].InnerText;
                            }

                            if (p["RefNo"] != null)
                            {
                                hsh["rrn"] = p["RefNo"].InnerText;
                            }

                            if (p["Status"] != null)
                            {
                                hsh["msg"] = p["Status"].InnerText;
                            }
                            string message;
                            message = p["Status"].InnerText;
                            if (message == "Approved")
                            {
                                hsh["respCode"] = "00";
                            }
                            else
                            {
                                hsh["respCode"] = "94";
                            }

                            if (p["MaskedPAN"] != null)
                            {
                                hsh["pan"] = p["MaskedPAN"].InnerText;
                            }

                            if (p["TID"] != null)
                            {
                                hsh["tid"] = p["TID"].InnerText;
                            }
                            if (p["MID"] != null)
                            {
                                hsh["mid"] = p["MID"].InnerText;
                            }
                            hsh["transType"] = "SALE";
                            if (p["CardHolderName"] != null)
                            {
                                hsh["payDetails"] = p["CardHolderName"].InnerText;
                            }
                            hsh["sign"] = "";
                            hsh["pin"] = "true";
                            //if (message == "Approved")
                            //{
                            //    logtocloud(p["RefNo"].InnerText, p["AuthID"].InnerText, x / 100, x / 100, 0, "UBA", "UBA", p["MID"].InnerText, p["TID"].InnerText, p["MaskedPAN"].InnerText, p["CardHolderName"].InnerText, DateTime.Now, "SALE");

                            //}

                        }

                    }
                    else
                    {
                        hsh = new Hashtable();
                        hsh["msg"] = "No response from POS";
                        hsh["respCode"] = "94";
                    }
                }
                else
                {
                    hsh = new Hashtable();
                    hsh["msg"] = "Cash Back Not Allowed";
                    hsh["respCode"] = "CBX";
                }

            }
            catch (Exception ex)
            {
                log.LogMsg(LogModes.FILE_LOG_UBA, LogLevel.ERROR, ex.ToString());
            }

            return hsh;
        }

        public Hashtable execReversal(string Amount, string TransKey, bool log_Debug)
        {
            Hashtable hsh = null;
            try
            {
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG_UBA, LogLevel.INFO, "Instantiating Marshall.dll's Request & Response objects");

                ECR.ComECR preq = new ECR.ComECR();

                preq.GetSet_VFI_ECRRcptNum = TransKey;
                preq.GetSet_VFI_Amount = Utils.formatAmount(Amount, true);
                /////////////////////////////////////////////////////////////////////////////////////////////////////

                preq.GetSet_VFI_VoidInvoiceNo = ConfigurationManager.AppSettings["invoiceno"];//for auto reverals eg safaricom
                preq.GetSet_VFI_CurrCode = ConfigurationManager.AppSettings["currencyCode"];
                preq.GetSet_VFI_PTID = ConfigurationManager.AppSettings["kcbptid"];
                // preq.OperationCode = Convert.ToInt32(ConfigurationManager.AppSettings["reversal_Op"]);
                log.LogMsg(LogModes.FILE_DEBUG_UBA, LogLevel.INFO, "starting");

                if (!preq.VFI_VoidTrans())
                {


                    log.LogMsg(LogModes.FILE_DEBUG_UBA, LogLevel.INFO, "failuresssssssss");
                }

                else
                {
                    //log initializations
                    log.LogMsg(LogModes.FILE_DEBUG_UBA, LogLevel.INFO, "starting2");

                    hsh = new Hashtable();
                    log.LogMsg(LogModes.FILE_DEBUG_UBA, LogLevel.INFO, "s3");
           
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_UBA, LogLevel.INFO, "Retrieving results from Marshall.dll Reversal Transaction");
                    //hsh = new Hashtable();
                    hsh["amount"] = Utils.formatAmount(preq.GetSet_VFI_Amount, false);
                    log.LogMsg(LogModes.FILE_DEBUG_UBA, LogLevel.INFO, "Validating Reversal passed1" + preq.VFI_Amount);
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
                    hsh["sign"] = "";
                    hsh["pin"] = "true";
                    log.LogMsg(LogModes.FILE_DEBUG_UBA, LogLevel.INFO, "sv" + preq.GetSet_VFI_CardName);

                    log.LogMsg(LogModes.FILE_LOG_UBA,
                        LogLevel.INFO,
                        string.Format("RES.REVERSAL. Marshall Response: Amount={0}, Cashback={1}, AuthCode={2}, ResponseCode={3}, CardExpiry={4}, CurrencyCode={5}, Message={6}, PAN={7}, TID={8}, RRN={9}, TransType={10}",
                        preq.VFI_Amount, hsh["authCode"], hsh["respCode"], hsh["cardExpiry"], hsh["currency"], hsh["msg"], hsh["pan"], hsh["tid"], hsh["rrn"], hsh["transType"]));

                    //debug
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_UBA,
                            LogLevel.INFO,
                            string.Format("RES.REVERSAL. Marshall Response: Amount={0}, Cashback={1}, AuthCode={2}, ResponseCode={3}, CardExpiry={4}, CurrencyCode={5}, Message={6}, PAN={7}, TID={8}, RRN={9}, TransType={10}",
                            preq.VFI_Amount, hsh["authCode"], hsh["respCode"], hsh["cardExpiry"], hsh["currency"], hsh["msg"], hsh["pan"], hsh["tid"], hsh["rrn"], hsh["transType"]));
                }
            }

            catch (Exception ex)
            {
                log.LogMsg(LogModes.FILE_LOG_UBA, LogLevel.ERROR, ex.ToString());
            }

            return hsh;

        }

        private bool logtocloud(string rrn, string authcode, double amount, double saleamount, double cashback, string bankcode, string bankname, string mid, string tid, string pan, string cardholder, DateTime transdate, string transtype)
        {
            bool success = false;
            string connectionString = "Persist Security Info=False;User ID=feft;Password=Delivered,1206!;Initial Catalog=FEFT;Server=208.91.198.59";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO EFTTransactions (Rrn, Authcode, Amount,Saleamount,Cashback,Bankcode,Bankname,Mid,Tid,Pan,Cardholder,Transdate,Transtype) VALUES (@rrn, @authcode, @amount,@saleamount,@cashback,@bankcode,@bankname,@mid,@tid,@pan,@cardholder,@transdate,@transtype)");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@rrn", rrn);
                    cmd.Parameters.AddWithValue("@authcode", authcode);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@saleamount", saleamount);
                    cmd.Parameters.AddWithValue("@cashback", cashback);
                    cmd.Parameters.AddWithValue("@bankcode", bankcode);
                    cmd.Parameters.AddWithValue("@bankname", bankname);
                    cmd.Parameters.AddWithValue("@mid", mid);
                    cmd.Parameters.AddWithValue("@tid", tid);
                    cmd.Parameters.AddWithValue("@pan", pan);
                    cmd.Parameters.AddWithValue("@cardholder", cardholder);
                    cmd.Parameters.AddWithValue("@transdate", transdate);
                    cmd.Parameters.AddWithValue("@transtype", transtype);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    success = true;
                }

            }
            catch (Exception)
            {
                success = false;
            }

            return success;
        }
  
    }
}
