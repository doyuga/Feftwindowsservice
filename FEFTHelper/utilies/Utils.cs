using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FEFTHelper
{
    class Utils
    {
        public static string formatAmount(string amnt, bool toPinpad)
        {
            if (toPinpad)
                return (Convert.ToDouble(amnt) * 100).ToString();
            else
                return (Convert.ToDouble(amnt) / 100.0).ToString();
        }

        public static string maskPAN(string pan)
        {
            //check for empty string
            if (string.IsNullOrEmpty(pan)) return pan;
            
            //check the length of pan
            int panLen = pan.Length;
            if (panLen <= 10) return pan;

            //mask pan
            int padLen = panLen - 10;
            int padEndMark = panLen - 4;

            string bin = pan.Substring(0, 6);
            string bin_n_pad_n_trail = bin.PadRight(6 + padLen, 'x') + pan.Substring(padEndMark, 4);

            return bin_n_pad_n_trail;
        }
    }
}
