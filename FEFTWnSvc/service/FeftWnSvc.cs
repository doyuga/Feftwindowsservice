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
        public FEFTResponse sale(string transKey, string Bank, string amount, string cashBack, string CashierId, string tillNO)
        {
            bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);
            FEFTResponse cres = new FEFTResponse();
            try
            {
                //VALIDATE THE REQUEST


                //DETERMINE ROUTE HERE
                //TRIGGER ARCUS DLL THROUGH A FRIEND ;)
                if (Bank == "2") // Equity Bank
                {
                    log.logingmode = "EQUITY";
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Sale Request's parameters");

                    string errMsg = null;
                    bool valid = Utils.validSaleRequest(amount, cashBack, CashierId, tillNO, transKey, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.ArcusDll dll = new FEFTHelper.ArcusDll();
                    Hashtable hsh = dll.execSale(amount, cashBack, CashierId, tillNO, transKey, log_Debug);
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

                else if (Bank == "1") // KCB Ingenico
                {
                    log.logingmode = "KCB";
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Sale Request's parameters");

                    string errMsg = null;
                    bool valid = Utils.validSaleRequest(amount, cashBack, CashierId, tillNO, transKey, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.ArcusDll dll = new FEFTHelper.ArcusDll();
                    Hashtable hsh = dll.execSale(amount, cashBack, CashierId, tillNO, transKey, log_Debug);
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

                else if (Bank == "0") ///----KCB Bank Verifone----
                {
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Sale Request's parameters");

                    string errMsg = null;
                    bool valid = Utils.validSaleRequest(amount, cashBack, CashierId, tillNO, transKey, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.MarshallDLL dll = new FEFTHelper.MarshallDLL();
                    Hashtable hsh = dll.execSale(amount, cashBack, CashierId, tillNO, transKey, log_Debug);
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
                else if (Bank == "3") ///----BBK Bank ----
                {
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Sale Request's parameters");

                    string errMsg = null;
                    bool valid = Utils.validSaleRequest(amount, cashBack, CashierId, tillNO, transKey, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.Barclays dll = new FEFTHelper.Barclays();
                    Hashtable hsh = dll.execSale(amount, cashBack, CashierId, tillNO, transKey, log_Debug);
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
                else if (Bank == "5") ///----UBA Bank ----
                {
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Sale Request's parameters");

                    string errMsg = null;
                    bool valid = Utils.validSaleRequest(amount, cashBack, CashierId, tillNO, transKey, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.Uba dll = new FEFTHelper.Uba();
                    Hashtable hsh = dll.execSale(amount, cashBack, tillNO, transKey, log_Debug);
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
                else if (Bank == "4") ///----Ezzypay ----
                {
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_EZZYPAY, LogLevel.INFO, "Validating Sale Request's parameters");

                    string errMsg = null;
                    bool valid = Utils.validSaleRequest(amount, cashBack, CashierId, tillNO, transKey, ref errMsg);

                    if (!valid)
                        throw new Exception(errMsg);
                    FEFTHelper.Ezzypay dll = new FEFTHelper.Ezzypay();
                    Hashtable hsh = dll.execSale(amount, cashBack, CashierId, tillNO, transKey, log_Debug);
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
                    Hashtable hsh = dll.execSale(amount, cashBack, CashierId, tillNO, transKey, log_Debug);
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
                if (Bank == "2") // Equity Bank
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
                return this.sale(creq.TransKey, creq.Bank, creq.Amount, creq.CashBack, creq.CashierId, creq.TillNO);
        }
        public FEFTResponse opSale(SaleRequest creq)
        {
            if (creq == null)
                return null;
            else
                return this.sale(creq.TransKey, creq.Bank, creq.Amount, creq.CashBack, creq.CashierId, creq.TillNO);
        }
        #endregion

        #region REVERSAL TRANSACTIONS
        //public FEFTResponse reversal(string Amount, string Bank, string Transkey)
        public FEFTResponse reversal(string TransKey, string Bank, string Amount)
        {
            bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);
            FEFTResponse cres = new FEFTResponse();
            try
            {


                //DETERMINE ROUTE HERE
                //TRIGGER ARCUS DLL THROUGH A FRIEND ;)
                if (Bank == "1") // kcb ingenico

                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        //log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters");
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + Amount + "  Transkey: " + TransKey + "  Bank" + Bank);

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
                else if (Bank == "2") // Equity Bank

                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        //log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters");
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + Amount + "  Transkey: " + TransKey + "  Bank" + Bank);

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
                else if (Bank == "3") ///--- BBK
                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + Amount + "  Transkey: " + TransKey + "  Bank" + Bank);

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
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + Amount + "  Transkey: " + TransKey + "  Bank" + Bank);

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
                if (Bank == "2") // Equity Bank
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
                return this.reversal(creq.TransKey, creq.Bank, creq.Amount);
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
        public ReconResponse recon(string Bank)
        {
            bool log_Debug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["log_Debug"]);
            ReconResponse cres = new ReconResponse();
            try
            {


                //DETERMINE ROUTE HERE
                //TRIGGER ARCUS DLL THROUGH A FRIEND ;)
                if (Bank == "1") // KCB Bank Ingenico 

                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        //log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters");
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + 0 + "  Transkey: " + "" + "  Bank" + Bank);

                    string errMsg = null;
                    FEFTHelper.ArcusDll dll = new FEFTHelper.ArcusDll();
                    Hashtable hsh = dll.execRecon(log_Debug);

                    //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                    cres.slip = (string)hsh["slip"];
                    cres.ResponseCodeHost = (string)hsh["ResponseCodeHost"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.msg = (string)hsh["msg"];

                }
                else if (Bank == "2") // Equity Bank

                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        //log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters");
                        log.LogMsg(LogModes.FILE_DEBUG, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + 0 + "  Transkey: " + "" + "  Bank" + Bank);

                    string errMsg = null;

                    FEFTHelper.ArcusDll dll = new FEFTHelper.ArcusDll();
                    Hashtable hsh = dll.execRecon(log_Debug);

                    //ASSIGN VARIABLES TO RESPONSE CONTRACT CLASS
                    cres.slip = (string)hsh["slip"];
                    cres.ResponseCodeHost = (string)hsh["ResponseCodeHost"];
                    cres.respCode = (string)hsh["respCode"];
                    cres.msg = (string)hsh["msg"];

                }
                else if (Bank == "3") ///--- BBK
                {
                    //VALIDATE THE REQUEST
                    if (log_Debug)
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + 0 + "  Transkey: " + "" + "  Bank" + Bank);

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
                        log.LogMsg(LogModes.FILE_DEBUG_KCB, LogLevel.INFO, "Validating Reversal Request's parameters" + " Amount: " + 0 + "  Transkey: " + "" + "  Bank" + Bank);

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
                if (Bank == "2") // Equity Bank
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
                return this.recon(creq.Bank);
        }
        #endregion
    }
}
