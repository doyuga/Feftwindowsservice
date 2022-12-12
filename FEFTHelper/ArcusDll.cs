 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Management;

namespace FEFTHelper
{
    public class ArcusDll
    {
        // logger for ...
        private static Logger log = new Logger();

        public Hashtable execSale(string Amount, string cashBack, string cashierId, string tillNo, string transKey, string mobileId,bool log_Debug)
        {
            //Updatecashregini();
            updatecashreg();
            //log.logingmode = "EQUITY";
            Hashtable hsh = null;
            try
            {
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Instantiating Arcus.dll's Request & Response objects");

                double x = 0;
                double z = 0.00;
                double.TryParse(Amount, out x);
                double y = 0;
                double.TryParse(cashBack, out y);

                if (y > 0)
                {
                    z = (x + y) / 100;
                }
                else
                {
                    z = (x) / 100;
                }

                string vfiamount;
                //vfiamount = z.ToString("0.00");
                vfiamount = (x/100).ToString("0.00");

                ARCCOMLib.SAPacketObj preq = new ARCCOMLib.SAPacketObj();
                ARCCOMLib.SAPacketObj pres = new ARCCOMLib.SAPacketObj();
                preq.Amount = Utils.formatAmount(vfiamount, true);

                preq.CurrencyCode = ConfigurationManager.AppSettings["currencyCode"];
                preq.OperationCode = Convert.ToInt32(ConfigurationManager.AppSettings["sale_Op"]);

                log.LogMsg(LogModes.FILE_LOG,
                    LogLevel.INFO,
                    string.Format("REQ.SALE. Arcus Request: Amount={0}, Cashback={1}, CurrencyCode={2}, OperationCode={3}",
                    preq.Amount, "0", preq.CurrencyCode, preq.OperationCode));

                //debug
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG,
                        LogLevel.INFO,
                        string.Format("REQ.SALE. Arcus Request: Amount={0}, Cashback={1}, CurrencyCode={2}, OperationCode={3}",
                        preq.Amount, "0", preq.CurrencyCode, preq.OperationCode));

                //log initializations
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Instantiating Arcus.dll and executing the Sale Transaction");

                bool con = ConnectionAvailable();
                hsh = new Hashtable();

                if (con)
                {
                    ARCCOMLib.PCPOSTConnectorObj svr = new ARCCOMLib.PCPOSTConnectorObj();
                    int status = svr.Exchange(ref preq, ref pres, 12000);

                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Retrieving results from Arcus.dll Sale Transaction");

                    //hsh = new Hashtable();
                    hsh["amount"] = Utils.formatAmount(pres.Amount, false);
                    //hsh["cashBack"] = Utils.formatAmount(pres.CashbackAmount, false);
                    hsh["cashBack"] = "0.00";
                     hsh["authCode"] = pres.AuthorizationCode;
                    hsh["rrn"] = pres.ReferenceNumber;
                    hsh["msg"] = pres.TextResponse;
                    hsh["respCode"] = (string.IsNullOrEmpty(pres.ResponseCodeHost)) ? "999" : ((pres.ResponseCodeHost == "000") ? "00" : pres.ResponseCodeHost);

                    if ((string.IsNullOrEmpty(pres.AuthorizationCode) || string.IsNullOrEmpty(pres.ReferenceNumber))
                        &&
                       (Convert.ToString(pres.ResponseCodeHost) == "000" || Convert.ToString(pres.ResponseCodeHost) == "00"))
                    {
                        hsh["respCode"] = "";
                        hsh["msg"] = "Refer to your Bank";
                    }

                    string respcode= (string.IsNullOrEmpty(pres.ResponseCodeHost)) ? "999" : ((pres.ResponseCodeHost == "000") ? "00" : pres.ResponseCodeHost);
                    hsh["invoiceNo"] = pres.TrxID;
                    hsh["cardExpiry"] = pres.CardExpiryDate;
                    hsh["currency"] = pres.CurrencyCode;
                    hsh["pan"] = Utils.maskPAN(pres.PAN);
                    hsh["tid"] = pres.TerminalOutID;
                    hsh["mid"] = pres.CRMID;
                    string mymid = pres.CRMID;
                    hsh["transType"] = "Sale";
                    hsh["InvoiceNo"] = pres.TrxID.ToString();
                    hsh["payDetails"] = pres.PaymentDetails;
                    hsh["sign"] = "";
                    hsh["pin"] = "true";
                    hsh["slip"] = pres.Slip;


            }
                else
            {
                hsh["Amount"] = Amount;
                hsh["respCode"] = "402";
                hsh["msg"] = "Connection broke. Transaction could not be completed.";
            }

            //log initializations
            log.LogMsg(LogModes.FILE_LOG,
                    LogLevel.INFO,
                    string.Format("RES.SALE. Arcus Response: Amount={0}, Cashback={1}, AuthCode={2}, ResponseCode={3}, CardExpiry={4}, CurrencyCode={5}, Message={6}, PAN={7}, TID={8}, RRN={9}, TransType={10}",
                    preq.Amount, "0", hsh["authCode"], hsh["respCode"], hsh["cardExpiry"], hsh["currency"], hsh["msg"], hsh["pan"], hsh["tid"], hsh["rrn"], hsh["transType"]));

                //debug
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG,
                    LogLevel.INFO,
                    string.Format("RES.SALE. Arcus Response: Amount={0}, Cashback={1}, AuthCode={2}, ResponseCode={3}, CardExpiry={4}, CurrencyCode={5}, Message={6}, PAN={7}, TID={8}, RRN={9}, TransType={10}",
                    preq.Amount, "0", hsh["authCode"], hsh["respCode"], hsh["cardExpiry"], hsh["currency"], hsh["msg"], hsh["pan"], hsh["tid"], hsh["rrn"], hsh["transType"]));
            }
            catch (Exception ex)
            {
                log.LogMsg(LogModes.FILE_LOG, LogLevel.ERROR, ex.ToString());
            }

            return hsh;
        }

        public Hashtable execReversal(string Amount, string rrn, bool log_Debug)
        {
            updatecashreg();
            Hashtable hsh = null;
            try
            {
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Instantiating Arcus.dll's Request & Response objects");

                ARCCOMLib.SAPacketObj preq = new ARCCOMLib.SAPacketObj();
                ARCCOMLib.SAPacketObj pres = new ARCCOMLib.SAPacketObj();

                preq.CurrencyCode = ConfigurationManager.AppSettings["currencyCode"];
                //preq.ReferenceNumber = "12234";
                preq.Amount = Amount;
                preq.ReferenceNumber = rrn;
               // preq.OperationCode = Convert.ToInt32(ConfigurationManager.AppSettings["reversal_Op"]);
                preq.OperationCode = 3;

                bool con = ConnectionAvailable();
                hsh = new Hashtable();

                if (con)
                {

                    ARCCOMLib.PCPOSTConnectorObj svr = new ARCCOMLib.PCPOSTConnectorObj();

                int status = svr.Exchange(ref preq, ref pres, 12000);

                     string respcode = (string.IsNullOrEmpty(pres.ResponseCodeHost)) ? "999" : ((pres.ResponseCodeHost == "000") ? "00" : pres.ResponseCodeHost);
                    hsh["amount"] = pres.Amount;
                    hsh["authCode"] = pres.AuthorizationCode;
                    hsh["msg"] = pres.TextResponse;
                    hsh["rrn"] = pres.ReferenceNumber;
                    hsh["respCode"] = string.IsNullOrEmpty(pres.ResponseCodeHost) ? "999" : ((pres.ResponseCodeHost == "000") ? "00" : pres.ResponseCodeHost);
                    hsh["cardExpiry"] = pres.CardExpiryDate;
                    hsh["currency"] = pres.CurrencyCode;
                    hsh["pan"] = Utils.maskPAN(pres.PAN);
                    hsh["tid"] = pres.TerminalOutID;
                    hsh["transType"] = "Reversal";
                    hsh["payDetails"] = pres.PaymentDetails;
                    hsh["sign"] = "";
                    hsh["pin"] = "true";
                    hsh["slip"] = pres.Slip;
                }
                else
                {

                    hsh["respCode"] = "402";
                    hsh["msg"] = "Connection broke. Transaction could not be completed.";
                }


             }
            catch (Exception ex)
            {
                
                log.LogMsg(LogModes.FILE_LOG, LogLevel.ERROR, ex.ToString());
            }

            return hsh;
        }

        public Hashtable execRecon(bool log_Debug)
        {
            updatecashreg();
            Hashtable hsh = null;
            try
            {
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Instantiating Arcus.dll's Request & Response objects");
                ARCCOMLib.SAPacketObj preq = new ARCCOMLib.SAPacketObj();
                ARCCOMLib.SAPacketObj pres = new ARCCOMLib.SAPacketObj();

                //preq.CurrencyCode = ConfigurationManager.AppSettings["currencyCode"];
                //preq.ReferenceNumber = "12234";

                //preq.OperationCode = Convert.ToInt32(ConfigurationManager.AppSettings["close_Op"]);
                preq.OperationCode = 11;

                //int opcode = preq.OperationCode;
                bool con = ConnectionAvailable();
                hsh = new Hashtable();

                if (con)
                {

                    ARCCOMLib.IPCPOSTConnectorObj svr = new ARCCOMLib.PCPOSTConnectorObj();

                int status = svr.Exchange(ref preq, ref pres, 12000);
                string respcode = (string.IsNullOrEmpty(pres.ResponseCodeHost)) ? "999" : ((pres.ResponseCodeHost == "000") ? "00" : pres.ResponseCodeHost);
                hsh["slip"] = pres.Slip;
                hsh["responseCodeHost"] = pres.ResponseCodeHost;
                hsh["msg"] = pres.TextResponse;
                 
                hsh["respCode"] = string.IsNullOrEmpty(pres.ResponseCodeHost) ? "999" : ((pres.ResponseCodeHost == "000") ? "00" : pres.ResponseCodeHost);
                    string message= pres.TextResponse;
                }
                else
                {

                    hsh["respCode"] = "402";
                    hsh["msg"] = "Connection broke. Transaction could not be completed.";
                }

 }
            catch (Exception ex)
            {

                log.LogMsg(LogModes.FILE_LOG, LogLevel.ERROR, ex.ToString());
            }

            return hsh;
        }

        public Hashtable execEchotest()
        {
            Hashtable hsh = null;
            try
            {
                hsh = new Hashtable();
                hsh["msg"] = "Echo test successful";
              
                hsh["respCode"] = "800";
          }
            catch (Exception ex)
            {

                log.LogMsg(LogModes.FILE_LOG, LogLevel.ERROR, ex.ToString());
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
        private bool logtocloud(string rrn, string authcode, double amount, double saleamount, double cashback, string bankcode, string bankname, string mid, string tid, string pan, string cardholder, DateTime transdate, string transtype, string msg, string merchant, string branch, string cashierId, string invoiceno, string respcode, string TillNo)
        {
            bool success = false;
            //string connectionString = "Persist Security Info=False;User ID=feft;Password=Delivered,1206!;Initial Catalog=FEFT;Server=208.91.198.196";
            string connectionString = ConfigurationManager.ConnectionStrings["CloudEquity"].ConnectionString;
            //string connectionString = ConfigurationManager.ConnectionStrings["Cloud"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO EFTTransactions (Rrn, Authcode, Amount,Saleamount,Cashback,Bankcode,Bankname,Mid,Tid,Pan,Cardholder,Transdate,Transtype,Msg,Merchant,Branch,cashierId,invoiceno,respcode,tillno) VALUES (@rrn, @authcode, @amount,@saleamount,@cashback,@bankcode,@bankname,@mid,@tid,@pan,@cardholder,@transdate,@transtype,@msg,@merchant,@branch,@cashierId,@invoiceno,@respcode,@tillno)");
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
        public bool Updatecashregini()
        {
            string portno;
            bool sucess = false;
            try
            {
                ManagementObjectCollection mReturn;
                ManagementObjectSearcher mSearch;

                //mSearch = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\" and Description like'Sagem Telium%'");

                //mSearch = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");
                mSearch = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_SerialPort  where Name like'Sagem Telium%'");
                mReturn = mSearch.Get();

                if (mReturn.Count > 0)
                {
                    foreach (ManagementObject mObj in mReturn)
                    {

                        string item = mObj["DeviceID"].ToString();
                        //string item2 = mObj["Name"].ToString();
                        portno = item;
                        //int indexOfCom = item.IndexOf("(COM");
                        //portno = item.Substring(indexOfCom + 1, item.Length - indexOfCom - 2);

                        IniFile.WriteValue("C:\\Arcus2\\INI\\cashreg.ini", "port section", "PORT", portno);
                    }
                }

            }

            catch (Exception)
            {
            }
            return sucess;
        }
        public bool updatecashreg()
        {
            string portno;
            bool sucess = false;
            try
            {
                ManagementObjectCollection mReturn;
                ManagementObjectSearcher mSearch;
                mSearch = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_SerialPort  where Name like'Sagem Telium%'");
                mReturn = mSearch.Get();
                if (mReturn.Count > 0)
                {
                    foreach (ManagementObject mObj in mReturn)
                    {
                        string item = mObj["DeviceID"].ToString();
                        //string item2 = mObj["Name"].ToString();
                        portno = item;
                        string path = "C:\\Arcus2\\INI\\cashreg.ini";
                        StringBuilder stringBuilder = new StringBuilder();
                        string text = "";
                        string[] array = File.ReadAllLines(path);
                        foreach (string text2 in array)
                        {
                            if (text2.Contains("PORT="))
                            {
                                string newValue = "PORT=" + portno;
                                text = text2.Replace(text2, newValue);
                                stringBuilder.Append(text + "\r\n");
                            }
                            else
                            {
                                stringBuilder.Append(text2 + "\r\n");
                            }
                        }
                        File.WriteAllText(path, stringBuilder.ToString());
                    }
                }
            }
            catch (Exception )
            {
                
            }
            return sucess;
        }
    }
}
