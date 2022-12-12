using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FEFTWnSvc
{
    public class FeftWnSvc: IFeftWnSvc
    {
        private static Logger log = new Logger();

        #region SALE TRANSACTIONS
        public FEFTResponse sale(string transKey, string bank, string amount, string cashBack, string tillNo, string cashierId,string mobileId)
        {
            bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);
            FEFTResponse cres = new FEFTResponse();
            try
            {
                //VALIDATE THE REQUEST

                    //                "TransKey": "2",
                    //"bank": "4",
                    //"Amount": 100,
                    //"CashBack":"0",
                    //"TillNO": "12",
                    //"cashierId": "10",
                    //"MobileID": "0729566878"
                //DETERMINE ROUTE HERE
                //TRIGGER ARCUS DLL THROUGH A FRIEND ;)
                if (bank == "2") // Equity bank
                {
                    log.logingmode = "EQUITY";
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Sale Request's parameters");

                    string errMsg = null;
                    bool valid = Utils.validSaleRequest(amount, cashBack, cashierId, tillNo, transKey,mobileId, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.ArcusDll dll = new FEFTHelper.ArcusDll();
                    Hashtable hsh = dll.execSale(amount, cashBack, cashierId, tillNo, transKey,mobileId, log_Debug);
                    //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                    cres.amount = (string)hsh["amount"];
                    cres.cashBack = (string)hsh["cashback"];
                    cres.authCode = (string)hsh["authCode"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.cardExpiry = (string)hsh["cardExpiry"];
                    cres.currency = (string)hsh["currency"];
                    cres.msg = (string)hsh["msg"];
                    cres.pan = (string)hsh["pan"];
                    cres.tid = (string)hsh["tid"];
                    cres.mid = (string)hsh["mid"];
                    cres.rrn = (string)hsh["rrn"];
                    cres.transactionType = (string)hsh["transType"];
                    cres.pin = (string)hsh["pin"];
                    cres.sign = (string)hsh["sign"];

                    cres.paymentDetails = (string)hsh["payDetails"];
                    cres.slip = (string)hsh["slip"];
                }

                else if (bank == "1") // KCB Ingenico
                {
                    log.logingmode = "KCB";
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Sale Request's parameters");

                    string errMsg = null;
                    bool valid = Utils.validSaleRequest(amount, cashBack, cashierId, tillNo, transKey,mobileId, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.ArcusDll dll = new FEFTHelper.ArcusDll();
                    Hashtable hsh = dll.execSale(amount, cashBack, cashierId, tillNo, transKey, mobileId,log_Debug);
                    //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                    cres.amount = (string)hsh["amount"];
                    cres.cashBack = (string)hsh["cashback"];
                    cres.authCode = (string)hsh["authCode"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.cardExpiry = (string)hsh["cardExpiry"];
                    cres.currency = (string)hsh["currency"];
                    cres.msg = (string)hsh["msg"];
                    cres.pan = (string)hsh["pan"];
                    cres.tid = (string)hsh["tid"];
                    cres.mid = (string)hsh["mid"];
                    cres.rrn = (string)hsh["rrn"];
                    cres.transactionType = (string)hsh["transType"];
                    cres.pin = (string)hsh["pin"];
                    cres.sign = (string)hsh["sign"];

                    cres.paymentDetails = (string)hsh["payDetails"];
                    cres.slip = (string)hsh["slip"];
                }

                else if (bank == "0") ///----KCB bank Verifone----
                {
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Sale Request's parameters");

                    string errMsg = null;
                    bool valid = Utils.validSaleRequest(amount, cashBack, cashierId, tillNo, transKey,mobileId, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.MarshallDLL dll = new FEFTHelper.MarshallDLL();
                    Hashtable hsh = dll.execSale(amount, cashBack, cashierId, tillNo, transKey, mobileId, log_Debug);
                    //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                    cres.amount = (string)hsh["amount"];
                    cres.cashBack = (string)hsh["cashBack"];
                    cres.authCode = (string)hsh["authCode"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.cardExpiry = (string)hsh["cardExpiry"];
                    cres.currency = (string)hsh["currency"];
                    cres.msg = (string)hsh["msg"];
                    cres.pan = (string)hsh["pan"];
                    cres.tid = (string)hsh["tid"];
                    cres.mid = (string)hsh["mid"];
                    cres.rrn = (string)hsh["rrn"];
                    cres.transactionType = (string)hsh["transType"];
                    cres.invoiceNo = (string)hsh["invoiceNo"];
                    cres.paymentDetails = (string)hsh["payDetails"];

                    cres.pin = (string)hsh["pin"];
                    cres.sign = (string)hsh["sign"];
                    cres.slip = (string)hsh["slip"];

                }
                else if (bank == "3") ///----BBK bank ----
                {
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Sale Request's parameters");

                    string errMsg = null;
                    bool valid = Utils.validSaleRequest(amount, cashBack, cashierId, tillNo, transKey,mobileId, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.Barclays dll = new FEFTHelper.Barclays();
                    Hashtable hsh = dll.execSale(amount, cashBack, cashierId, tillNo, transKey,mobileId, log_Debug);
                    //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                    cres.amount = (string)hsh["amount"];
                    cres.cashBack = (string)hsh["cashBack"];
                    cres.authCode = (string)hsh["authCode"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.cardExpiry = (string)hsh["cardExpiry"];
                    cres.currency = (string)hsh["currency"];
                    cres.msg = (string)hsh["msg"];
                    cres.pan = (string)hsh["pan"];
                    cres.tid = (string)hsh["tid"];
                    cres.mid = (string)hsh["mid"];
                    cres.rrn = (string)hsh["rrn"];
                    cres.transactionType = (string)hsh["transType"];
                    cres.invoiceNo = (string)hsh["invoiceNo"];
                    cres.paymentDetails = (string)hsh["payDetails"];
                    cres.slip = (string)hsh["slip"];
                }
                else if (bank == "5") ///----UBA bank ----
                {
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Sale Request's parameters");

                    string errMsg = null;
                    bool valid = Utils.validSaleRequest(amount, cashBack, cashierId, tillNo, transKey, mobileId, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.Uba dll = new FEFTHelper.Uba();
                    Hashtable hsh = dll.execSale(amount, cashBack, tillNo, transKey,mobileId, log_Debug);
                    //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                    cres.amount = (string)hsh["amount"];
                    cres.cashBack = (string)hsh["cashBack"];
                    cres.authCode = (string)hsh["authCode"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.cardExpiry = (string)hsh["cardExpiry"];
                    cres.currency = (string)hsh["currency"];
                    cres.msg = (string)hsh["msg"];
                    cres.pan = (string)hsh["pan"];
                    cres.tid = (string)hsh["tid"];
                    cres.mid = (string)hsh["mid"];
                    cres.rrn = (string)hsh["rrn"];
                    cres.transactionType = (string)hsh["transType"];
                    cres.invoiceNo = (string)hsh["invoiceNo"];
                    cres.paymentDetails = (string)hsh["payDetails"];
                    cres.pin = (string)hsh["pin"];
                    cres.sign = (string)hsh["sign"];
                    cres.slip = (string)hsh["slip"];
                }
                else if (bank == "4") ///----Ezzypay ----
                {
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_EZZYPAY, LogLevel.INFO, "Validating Sale Request's parameters");

                    string errMsg = null;
                    bool valid = Utils.validSaleRequest(amount, cashBack, cashierId, tillNo, transKey,mobileId, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.Ezzypay dll = new FEFTHelper.Ezzypay();
                    Hashtable hsh = dll.execSale(amount, cashBack, cashierId, tillNo, transKey,mobileId, log_Debug);
                    //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                    cres.amount = (string)hsh["amount"];
                    cres.cashBack = (string)hsh["cashBack"];
                    cres.authCode = (string)hsh["authCode"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.cardExpiry = "9999";
                    cres.currency = (string)hsh["currency"];
                    cres.msg = (string)hsh["msg"];
                    cres.pan = (string)hsh["pan"];
                    cres.tid = (string)hsh["tid"];
                    cres.mid = (string)hsh["mid"];
                    cres.rrn = (string)hsh["rrn"];
                    cres.transactionType = (string)hsh["transType"];
                    cres.invoiceNo = (string)hsh["invoiceNo"];
                    cres.paymentDetails = (string)hsh["payDetails"];
                    cres.slip = (string)hsh["slip"];
                }

                else ///--- Pass everything through KCB pinpad
                {
                    FEFTHelper.MarshallDLL dll = new FEFTHelper.MarshallDLL();
                    Hashtable hsh = dll.execSale(amount, cashBack, cashierId, tillNo, transKey,mobileId, log_Debug);
                    //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                    cres.amount = (string)hsh["amount"];
                    cres.cashBack = (string)hsh["cashBack"];
                    cres.authCode = (string)hsh["authCode"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.cardExpiry = (string)hsh["cardExpiry"];
                    cres.currency = (string)hsh["currency"];
                    cres.msg = (string)hsh["msg"];
                    cres.pan = (string)hsh["pan"];
                    cres.tid = (string)hsh["tid"];
                    cres.mid = (string)hsh["mid"];
                    cres.rrn = (string)hsh["rrn"];
                    cres.transactionType = (string)hsh["transType"];
                    cres.invoiceNo = (string)hsh["invoiceNo"];
                    cres.paymentDetails = (string)hsh["payDetails"];
                    cres.pin = (string)hsh["pin"];
                    cres.sign = (string)hsh["sign"];
                    cres.slip = (string)hsh["slip"];

                }
            }


            catch (Exception ex)
            {
                if (bank == "2") // Equity bank
                {
                    log.LogMsg(LogModes.FILE_LOG, LogLevel.ERROR, ex.Message);

                    //DEBUG
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.ERROR, ex.Message);
                    cres.msg = ex.Message;
                }
                else
                {
                    log.LogMsg(LogModes.FILE_LOG_KCB, LogLevel.ERROR, ex.Message);

                    //DEBUG
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.ERROR, ex.Message);
                    cres.msg = ex.Message;
                }
            }

            return cres;
        }
        public FEFTResponse execSale(SaleRequest creq)
        {
            if (creq == null)
                return null;
            else
                return this.sale(creq.transKey, creq.bank, creq.amount, creq.cashBack, creq.cashierId, creq.tillNo,creq.mobileId);
        }
        public FEFTResponse opSale(SaleRequest creq)
        {
            if (creq == null)
                return null;
            else
                return this.sale(creq.transKey, creq.bank, creq.amount, creq.cashBack, creq.cashierId, creq.tillNo,creq.mobileId);
        }
        #endregion

        #region REVERSAL TRANSACTIONS
        //public FEFTResponse reversal(string Amount, string bank, string Transkey)
        public FEFTResponse reversal(string TransKey, string bank, string Amount)
        {
            bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);
            FEFTResponse cres = new FEFTResponse();
            try
            {


                //DETERMINE ROUTE HERE
                //TRIGGER ARCUS DLL THROUGH A FRIEND ;)
                if (bank == "1") // kcb ingenico

                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        //log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters");
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + Amount + "  Transkey: " + TransKey + "  bank" + bank);

                    string errMsg = null;
                    bool valid = Utils.validReversalRequest(Amount, TransKey, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.ArcusDll dll = new FEFTHelper.ArcusDll();
                    Hashtable hsh = dll.execReversal(Amount, TransKey, log_Debug);

                    //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                    cres.amount = (string)hsh["amount"];
                    cres.cashBack = (string)hsh["cashBack"];
                    cres.authCode = (string)hsh["authCode"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.cardExpiry = (string)hsh["cardExpiry"];
                    cres.currency = (string)hsh["currency"];
                    cres.msg = (string)hsh["msg"];
                    cres.pan = (string)hsh["pan"];
                    cres.tid = (string)hsh["tid"];
                    cres.mid = (string)hsh["tid"];
                    cres.rrn = (string)hsh["rrn"];
                    cres.transactionType = (string)hsh["transType"];
                    cres.paymentDetails = (string)hsh["payDetails"];
                }
                else if (bank == "2") // Equity bank

                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        //log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters");
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + Amount + "  Transkey: " + TransKey + "  bank" + bank);

                    string errMsg = null;
                    bool valid = Utils.validReversalRequest(Amount, TransKey, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.ArcusDll dll = new FEFTHelper.ArcusDll();
                    Hashtable hsh = dll.execReversal(Amount, TransKey, log_Debug);

                    //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                    cres.amount = (string)hsh["amount"];
                    cres.cashBack = (string)hsh["cashBack"];
                    cres.authCode = (string)hsh["authCode"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.cardExpiry = (string)hsh["cardExpiry"];
                    cres.currency = (string)hsh["currency"];
                    cres.msg = (string)hsh["msg"];
                    cres.pan = (string)hsh["pan"];
                    cres.tid = (string)hsh["tid"];
                    cres.mid = (string)hsh["tid"];
                    cres.rrn = (string)hsh["rrn"];
                    cres.transactionType = (string)hsh["transType"];
                    cres.paymentDetails = (string)hsh["payDetails"];
                }
                else if (bank == "3") ///--- BBK
                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + Amount + "  Transkey: " + TransKey + "  bank" + bank);

                    string errMsg = null;
                    bool valid = Utils.validReversalRequest(Amount, TransKey, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.Barclays dll = new FEFTHelper.Barclays();


                    Hashtable hsh = dll.execReversal(Amount, TransKey, log_Debug);
                    cres.amount = (string)hsh["amount"];
                    cres.cashBack = (string)hsh["cashBack"];
                    cres.authCode = (string)hsh["authCode"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.cardExpiry = (string)hsh["cardExpiry"];
                    cres.currency = (string)hsh["currency"];
                    cres.msg = (string)hsh["msg"];
                    cres.pan = (string)hsh["pan"];
                    cres.tid = (string)hsh["tid"];
                    cres.mid = (string)hsh["tid"];
                    cres.rrn = (string)hsh["rrn"];
                    cres.transactionType = (string)hsh["transType"];
                    cres.paymentDetails = (string)hsh["payDetails"];

                }

                else ///--- Pass everything through KCB pinpad
                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + Amount + "  Transkey: " + TransKey + "  bank" + bank);

                    string errMsg = null;
                    bool valid = Utils.validReversalRequest(Amount, TransKey, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.MarshallDLL dll = new FEFTHelper.MarshallDLL();


                    Hashtable hsh = dll.execReversal(Amount, TransKey, log_Debug);
                    cres.amount = (string)hsh["amount"];
                    cres.cashBack = (string)hsh["cashBack"];
                    cres.authCode = (string)hsh["authCode"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.cardExpiry = (string)hsh["cardExpiry"];
                    cres.currency = (string)hsh["currency"];
                    cres.msg = (string)hsh["msg"];
                    cres.pan = (string)hsh["pan"];
                    cres.tid = (string)hsh["tid"];
                    cres.mid = (string)hsh["tid"];
                    cres.rrn = (string)hsh["rrn"];
                    cres.transactionType = (string)hsh["transType"];
                    cres.paymentDetails = (string)hsh["payDetails"];

                }
            }
            catch (Exception ex)
            {
                if (bank == "2") // Equity bank
                {
                    log.LogMsg(LogModes.FILE_LOG, LogLevel.ERROR, ex.Message);

                    //DEBUG
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.ERROR, ex.Message);
                    cres.msg = ex.Message;
                }
                else
                {
                    log.LogMsg(LogModes.FILE_LOG_KCB, LogLevel.ERROR, ex.Message);

                    //DEBUG
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.ERROR, ex.Message);
                    cres.msg = ex.Message;
                }


            }

            return cres;
        }
        public FEFTResponse execReversal(ReversalRequest creq)
        {
            if (creq == null)
                return null;
            else
                return this.reversal(creq.transKey, creq.bank, creq.amount);
        }
        #endregion
        #region Echotest
        public EchotestResponse echotest()
        {
            bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);
            EchotestResponse cres = new EchotestResponse();
            try
            {



                //VALIDATE THE REQUEST
                if (log_Debug)
                    //log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters");
                    log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating echotest Request's parameters");

                string errMsg = null;
                // bool valid = Utils.validReversalRequest("", "", ref errMsg);

                //if (!valid)
                //    throw new Exception(errMsg);
                FEFTHelper.ArcusDll dll = new FEFTHelper.ArcusDll();
                Hashtable hsh = dll.execEchotest();

                //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS

                cres.respCode = (string)hsh["respCode"];
                string message = (string)hsh["msg"];
                cres.msg = (string)hsh["msg"];



            }
            catch (Exception ex)
            {

                log.LogMsg(LogModes.FILE_LOG_KCB, LogLevel.ERROR, ex.Message);

                //DEBUG
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.ERROR, ex.Message);
                cres.msg = ex.Message;



            }

            return cres;
        }
        public EchotestResponse execEchotest(EchotestRequest creq)
        {
            if (creq == null)
                return null;
            else
                return this.echotest();
        }
        #endregion

        #region Recon
        public ReconResponse recon(string bank)
        {
            bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);
            ReconResponse cres = new ReconResponse();
            try
            {


                //DETERMINE ROUTE HERE
                //TRIGGER ARCUS DLL THROUGH A FRIEND ;)
                if (bank == "1") // KCB bank Ingenico 

                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        //log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters");
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + 0 + "  Transkey: " + "" + "  bank" + bank);

                    string errMsg = null;
                    FEFTHelper.ArcusDll dll = new FEFTHelper.ArcusDll();
                    Hashtable hsh = dll.execRecon(log_Debug);

                    //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                    cres.slip = (string)hsh["slip"];
                    cres.ResponseCodeHost = (string)hsh["ResponseCodeHost"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.msg = (string)hsh["msg"];

                }
                else if (bank == "2") // Equity bank

                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        //log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters");
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + 0 + "  Transkey: " + "" + "  bank" + bank);

                    string errMsg = null;

                    FEFTHelper.ArcusDll dll = new FEFTHelper.ArcusDll();
                    Hashtable hsh = dll.execRecon(log_Debug);

                    //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                    cres.slip = (string)hsh["slip"];
                    cres.ResponseCodeHost = (string)hsh["ResponseCodeHost"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.msg = (string)hsh["msg"];

                }
                else if (bank == "3") ///--- BBK
                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + 0 + "  Transkey: " + "" + "  bank" + bank);

                    string errMsg = null;

                    FEFTHelper.Barclays dll = new FEFTHelper.Barclays();


                    Hashtable hsh = dll.execReversal("", "", log_Debug);
                    cres.slip = (string)hsh["slip"];
                    cres.ResponseCodeHost = (string)hsh["ResponseCodeHost"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.msg = (string)hsh["msg"];

                }

                else ///--- Pass everything through KCB pinpad
                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + 0 + "  Transkey: " + "" + "  bank" + bank);

                    string errMsg = null;
                    bool valid = Utils.validReversalRequest("", "", ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.MarshallDLL dll = new FEFTHelper.MarshallDLL();


                    Hashtable hsh = dll.execReversal("", "", log_Debug);
                    cres.slip = (string)hsh["slip"];
                    cres.ResponseCodeHost = (string)hsh["ResponseCodeHost"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.msg = (string)hsh["msg"];

                }
            }
            catch (Exception ex)
            {
                if (bank == "2") // Equity bank
                {
                    log.LogMsg(LogModes.FILE_LOG, LogLevel.ERROR, ex.Message);

                    //DEBUG
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.ERROR, ex.Message);
                    cres.msg = ex.Message;
                }
                else
                {
                    log.LogMsg(LogModes.FILE_LOG_KCB, LogLevel.ERROR, ex.Message);

                    //DEBUG
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.ERROR, ex.Message);
                    cres.msg = ex.Message;
                }


            }

            return cres;
        }
        public ReconResponse execRecon(ReconRequest creq)
        {
            if (creq == null)
                return null;
            else
                return this.recon(creq.bank);
        }
        #endregion
    }
}
