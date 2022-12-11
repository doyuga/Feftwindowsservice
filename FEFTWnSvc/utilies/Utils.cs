using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FEFTWnSvc
{
    public class Utils
    {
        #region VALIDATE SALE TRANSACTIONS
        public static bool validSaleRequest(SaleRequest req, ref string msg) {
            Validation val = new Validation();

            bool valid = true;

            //empty string for amnt
            if (string.IsNullOrEmpty(req.Amount))
            {
                msg = "REQ: Sale - Trans.amount not provided";
                valid = false;
            }
            else 
            {
                //valid number for amount
                valid = val.IsNumber(req.Amount);
                if (!valid)
                    msg = "REQ: Sale - Invalid Trans.Amount: " + req.Amount;
                else
                {
                    //cashback provided
                    if (!string.IsNullOrEmpty(req.CashBack))
                    {
                        valid = val.IsNumber(req.CashBack);
                        if (!valid)
                            msg = "REQ: Sale - Invalid Cashback Amount: " + req.CashBack;
                    }

                    //must have transaction key also number
                    if (valid)
                    {
                        valid = string.IsNullOrEmpty(req.TransKey) ? false : true;
                        if (!valid)
                            msg = "REQ: Sale - Trans.Key not provided";
                    }
                }
            }

            return valid;
        }
        public static bool validSaleRequest(string Amount, string cashBack,string CashierId, string tillNO, string transKey, ref string msg)
        {
            Validation val = new Validation();

            bool valid = true;

            //empty string for amnt
            if (string.IsNullOrEmpty(Amount))
            {
                msg = "REQ: Sale - Trans.Amount not provided";
                valid = false;
            }
            else
            {
                //valid number for amount
                valid = val.IsNumber(Amount);
                if (!valid)
                    msg = "REQ: Sale - Invalid Trans.Amount: " + Amount;
                else
                {
                    //cashback provided
                    if (!string.IsNullOrEmpty(cashBack))
                    {
                        valid = val.IsNumber(cashBack);
                        if (!valid)
                            msg = "REQ: Sale - Invalid Cashback Amount: " + cashBack;
                    }

                    //must have transaction key also number
                    if (valid)
                    {
                        valid = string.IsNullOrEmpty(transKey) ? false : true;
                        if (!valid)
                            msg = "REQ: Sale - Trans.Key not provided";
                    }

                }
            }

            return valid;
        }
        #endregion

        #region VALIDATE REVERSAL TRANSACTIONS
        public static bool validReversalRequest(ReversalRequest req, ref string msg)
        {
            Validation val = new Validation();

            bool valid = true;

            //empty string for amnt
            if (string.IsNullOrEmpty(req.Amount))
            {
                msg = "REQ: Reversal - Trans.Amount not provided";
                valid = false;
            }
            else
            {
                //valid number for amount
                valid = val.IsNumber(req.Amount);
                if (!valid)
                    msg = "REQ: Reversal - Invalid Trans.Amount: " + req.Amount;
                else
                {
                    //must have transaction key also number
                    if (valid)
                    {
                        valid = string.IsNullOrEmpty(req.TransKey) ? false : true;
                        if (!valid)
                            msg = "REQ: Reversal - RRN not provided";
                    }
                }
            }

            return valid;
        }
        public static bool validReversalRequest(string Amount, string Transkey, ref string msg)
        {
            Validation val = new Validation();

            bool valid = true;

            //empty string for amnt
            if (string.IsNullOrEmpty(Amount))
            {
                msg = "REQ: Reversal - Trans.Amount not provided";
                valid = false;
            }
            else
            {
                //valid number for amount
                valid = val.IsNumber(Amount);
                if (!valid)
                    msg = "REQ: Reversal - Invalid Trans.Amount: " + Amount;
                else
                {
                    //must have transaction key also number
                    if (valid)
                    {
                        valid = string.IsNullOrEmpty(Transkey) ? false : true;
                        if (!valid)
                            msg = "REQ: Reversal - RRN not provided";
                    }
                }
            }

            return valid;
        }
        #endregion

        #region OS RELATED
        public static string GetOS()
        {
            string version = GetOSVersion();
            if (string.Equals(version, "5.1"))
                return "WinXP";
            else if (string.Equals(version, "5.2"))
                return "WinXP/03";
            else if (string.Equals(version, "6.0"))
                return "WinVista/08";
            else if (string.Equals(version, "6.1"))
                return "Win7/08R2";
            else if (string.Equals(version, "6.2"))
                return "Win8/12";
            else
                return "Unknown";
        }
        public static string GetOSVersion() {
            return string.Format("{0}.{1}", System.Environment.OSVersion.Version.Major, System.Environment.OSVersion.Version.Minor);
        }
        #endregion
    }
}
