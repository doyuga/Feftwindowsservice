using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Net;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace FEFTHelper
{
    public class Ezzypay
        {
        // logger for ...
        private static Logger log = new Logger();
        public string invoiceno;
        public string respoX;
        //-----

        //-----
        public Hashtable execSale(string amount, string cashBack, string cashierId,string tillNO, string transKey, string mobileId, bool log_Debug)
        {

            string refno = null;
            string whopaid = null;
            string eauthcode = null;
            string paidmount = null;
            string errn = null;
            string epan = null;
            string etid = null;
            string emsg = null;
            string erespcode = null;
            string eamount = null;


            //string mobileno = Prompt.ShowDialog("Mobile No", "Key In");

            //int mobno = Convert.ToInt32(mobileno);
            int mobno = Convert.ToInt32(mobileId);
            Hashtable hsh = null;

            try
            {
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG_EZZYPAY, LogLevel.INFO, "MPESA's Request & Response");

                hsh = new Hashtable();
                if (log_Debug)
                    log.LogMsg(LogModes.FILE_DEBUG_EZZYPAY, LogLevel.INFO, "Retrieving results from MPESA Sale Transaction");

                using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Eazzypay"].ConnectionString))

                {
                    sqlConn.Open();
                    using (var command = sqlConn.CreateCommand())
                    {

                        string query = "SELECT * FROM tblMpesa WHERE MSISDN=@MobileNumber and TransAmount=@Amount and Consumed=@Consumed";


                        command.CommandType = CommandType.Text;
                        command.CommandText = query;
                        string realmobileno = "254" + mobno.ToString();
                        command.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = realmobileno;
                        //string amounts = Utils.formatAmount(amount, false) ;
                        string amounts = amount;
                        command.Parameters.Add("@Amount", SqlDbType.VarChar).Value = amounts;
                        command.Parameters.Add("@Consumed", SqlDbType.Bit).Value = false;

                        using (var reader = command.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows)
                            {
                                whopaid = reader["FirstName"].ToString() + " " + reader["MiddleName"].ToString() + " " + reader["LastName"].ToString();
                                refno = reader["TransId"].ToString();
                                paidmount = reader["TransAmount"].ToString();

                                // hsh["amount"] = Utils.formatAmount(amount, false);
                                hsh["amount"] = amount;
                                //eamount = Utils.formatAmount(amount, false);
                                eamount = amount;

                                hsh["cashBack"] = Utils.formatAmount("0", false);
                                string ecashback = Utils.formatAmount("0", false);

                                hsh["authCode"] = reader["BusinessShortCode"].ToString();
                                eauthcode = reader["BusinessShortCode"].ToString();

                                hsh["rrn"] = reader["TransId"].ToString();
                                errn = reader["TransId"].ToString();
                                hsh["msg"] = "Successful";
                                emsg = "Successful";
                                hsh["respCode"] = "00";
                                erespcode = "00";
                                hsh["pan"] = reader["MSISDN"].ToString();
                                epan = reader["MSISDN"].ToString();

                                // hsh["tid"] = reader["CustomerName"].ToString();
                                hsh["tid"] = whopaid;
                                //etid = reader["CustomerName"].ToString();

                                etid = whopaid;
                                hsh["sign"] = "";
                                hsh["pin"] = "true";
                                updateezzypaytable(refno);
                                //command.CommandType = System.Data.CommandType.StoredProcedure;
                                //command.CommandText = "spUpdateconsumed";

                                //command.Parameters.Add("@TransactionRefNo", SqlDbType.VarBinary).Value = refno;
                            }
                            else
                            {
                                // hsh["amount"] = Utils.formatAmount(amount, false);
                                hsh["amount"] = amount;
                                hsh["cashBack"] = Utils.formatAmount("0", false);
                                hsh["authCode"] = "0";
                                hsh["rrn"] = "0";
                                hsh["msg"] = "No Payment of KES " + amount + " for mobile number:" + mobno + " was found";
                                emsg = "Declined";
                                hsh["respCode"] = "555";
                                erespcode = "555";
                                hsh["pan"] = "0";
                                hsh["tid"] = "0";
                                hsh["transType"] = "Sale";
                                hsh["payDetails"] = "0";
                            }
                            // logtocloud(refno,eauthcode ,Convert.ToDouble(eamount), Convert.ToDouble(amount),0,"MPESA", "MPESA", tillNO, tillNO, "MPESA", etid, DateTime.Now, "SALE", emsg, etid,etid, cashierId, eauthcode, erespcode, tillNO);

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                hsh["msg"] = ex.ToString();

                log.LogMsg(LogModes.FILE_LOG_EZZYPAY, LogLevel.ERROR, ex.ToString());
            }

            return hsh;
        }

        public static class Prompt
        {
            [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
            public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

            [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport("user32.dll")]
            public static extern IntPtr SetActiveWindow(IntPtr hWnd);

            [DllImport("User32.dll", EntryPoint = "ShowWindowAsync")]
            private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
            private const int WS_SHOWNORMAL = 1;
            public static string ShowDialog(string text, string caption)
            {

                Form prompt = new Form()
                {
                    //Width = 400,
                    //Height = 400,
                    WindowState=FormWindowState.Maximized,
                    FormBorderStyle = FormBorderStyle.None,
                    Text = caption,
                   // StartPosition = FormStartPosition.CenterScreen,
                    MaximizeBox = true,
                    TopMost = true,
                    Name = "Tendereza",
                    
                    MinimizeBox = false
                    



                };

                //Form fc = Application.OpenForms["Tendereza"]; //if (fc != null) fc.Close();
                //if (fc == null)
                //{
                    Label textLabel = new Label() { Left = prompt.Width / 2, Top = 100, Width = 250, Height = 50, Text = text };
                    textLabel.Font = new Font("Arial", 24);
                    TextBox textBox = new TextBox() { Left = prompt.Width/2, Top = prompt.Height/2, Width = 300, Height = 100 };
                    textBox.Font = new Font("Arial", 24);
                    Button confirmation = new Button() { Text = "Ok", Left = 250, Width = 100, Height = 70, Top = 200, DialogResult = DialogResult.OK };
                    //Button Close = new Button() { Text = "Cancel", Left = 100, Width = 100, Height = 70, Top = 250, DialogResult = DialogResult.Cancel};
                    confirmation.Font = new Font("Arial", 24);
                    //Close.Font = new Font("Arial", 24);
                    confirmation.Click += (sender, e) => { prompt.Close(); };
                    //Close.Click += (sender, e) => { prompt.Close(); };
                    prompt.Controls.Add(textBox);
                    prompt.Controls.Add(confirmation);
                    prompt.Controls.Add(textLabel);
                    prompt.AcceptButton = confirmation;
               
                    //Process.Start("osk.exe");
                

                    //prompt.Activate();
                    //    prompt.BringToFront();
                    //textBox.Focus();
                    Process[] p = Process.GetProcessesByName("FEFTHost");

                // Activate the first application we find with this name
                if (p.Count() > 0)
                    SetForegroundWindow(p[0].MainWindowHandle);


                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";


            }
        }
        private bool updateezzypaytable(string rrn)
        {
            bool success = false;
            // string connectionString = "Persist Security Info=False;User ID=feft;Password=Delivered,1206!;Initial Catalog=FEFT;Server=208.91.198.196";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Eazzypay"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Update tblMpesa set consumed=@Consumed , DateConsumed=@DateConsumed where TransId=@rrn");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;


                    cmd.Parameters.Add("@rrn", SqlDbType.VarChar).Value = rrn;
                    cmd.Parameters.Add("@Consumed", SqlDbType.Bit).Value = true;
                    cmd.Parameters.Add("@DateConsumed", SqlDbType.DateTime).Value = DateTime.Now;



                    connection.Open();
                    cmd.ExecuteNonQuery();
                    success = true;
                }

            }
            catch (Exception ex)
            {
                log.LogMsg(LogModes.FILE_LOG_EZZYPAY, LogLevel.ERROR, ex.ToString());
                success = false;
            }

            return success;
        }
        private bool logtocloud(string rrn, string authcode, double amount, double saleamount, double cashback, string bankcode, string bankname, string mid, string tid, string pan, string cardholder, DateTime transdate, string transtype, string msg, string merchant, string branch, string cashierId, string invoiceno, string respcode, string TillNo)
        {
            bool success = false;
            //string connectionString = "Persist Security Info=False;User ID=feft;Password=Delivered,1206!;Initial Catalog=FEFT;Server=208.91.198.196";
            string connectionString = ConfigurationManager.ConnectionStrings["CloudEquity"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO feft.EFTTransactions (Rrn, Authcode, Amount,Saleamount,Cashback,bankcode,bankname,Mid,Tid,Pan,Cardholder,Transdate,Transtype,Msg,Merchant,Branch,cashierId,invoiceno,respcode,tillno) VALUES (@rrn, @authcode, @amount,@saleamount,@cashback,@bankcode,@bankname,@mid,@tid,@pan,@cardholder,@transdate,@transtype,@msg,@merchant,@branch,@cashierId,@invoiceno,@respcode,@tillno)");
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
            catch (Exception ex)
            {
                string ms = ex.ToString();
                success = false;
            }

            return success;
        }

    }
}
