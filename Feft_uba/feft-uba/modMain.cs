using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.IO.Ports;

using System.Xml;
using System.Text;

namespace feft_uba
{
    [StandardModule]
    public class modMain
    {
        public struct Setting
        {
            public short Timeout;

            public short TxnTimeout;

            public string TracePath;

            public short UploadTimeout;

            public bool Trace;

            public string PortName;

            public int BaudRate;

            public bool Delay;

            public int DelayTimeout;

            public string LICData;

            public bool flgWaitRes;

            public string HostIp;

            public int HostPort;

            public int HostTimeout;

            public void Save()
            {
                modMain.SaveFile();
            }
        }

        public static modMain.Setting Settings = default(modMain.Setting);

        private static string GetCurrPath()
        {
            string text = Application.StartupPath;
            try
            {
                text = Assembly.GetExecutingAssembly().Location;
                text = text.Substring(0, text.LastIndexOf("\\"));
            }
            catch (Exception expr_26)
            {
                ProjectData.SetProjectError(expr_26);
                text = Application.StartupPath;
                ProjectData.ClearProjectError();
            }
            return text;
        }

        private static void SaveFile()
        {
            IEnumerator enumerator = null;
            DataSet dataSet = new DataSet();
            try
            {
                string text = modMain.GetCurrPath() + "\\Settings.xml";
                if (!File.Exists(text))
                {
                    dataSet.Tables.Add("Settings");
                    dataSet.Tables[0].Columns.Add("PortName");
                    dataSet.Tables[0].Columns.Add("BaudRate");
                    dataSet.Tables[0].Columns.Add("Timeout");
                    dataSet.Tables[0].Columns.Add("TxnTimeout");
                    dataSet.Tables[0].Columns.Add("UploadTimeout");
                    dataSet.Tables[0].Columns.Add("Trace");
                    dataSet.Tables[0].Columns.Add("TracePath");
                    dataSet.Tables[0].Columns.Add("Delay");
                    dataSet.Tables[0].Columns.Add("DelayTimeout");
                    dataSet.Tables[0].Columns.Add("LICData");
                    dataSet.Tables[0].Columns.Add("flgWaitRes");
                    dataSet.Tables[0].Columns.Add("HostIp");
                    dataSet.Tables[0].Columns.Add("HostPort");
                    dataSet.Tables[0].Columns.Add("HostTimeout");
                    DataRow dataRow = dataSet.Tables["Settings"].NewRow();
                    dataRow["PortName"] = modMain.Settings.PortName;
                    dataRow["BaudRate"] = modMain.Settings.BaudRate;
                    dataRow["Timeout"] = modMain.Settings.Timeout;
                    dataRow["TxnTimeout"] = modMain.Settings.TxnTimeout;
                    dataRow["UploadTimeout"] = modMain.Settings.UploadTimeout;
                    dataRow["Trace"] = modMain.Settings.Trace.ToString();
                    dataRow["TracePath"] = modMain.Settings.TracePath;
                    dataRow["Delay"] = modMain.Settings.Delay;
                    dataRow["DelayTimeout"] = modMain.Settings.DelayTimeout;
                    dataRow["LICData"] = modMain.Settings.LICData;
                    dataRow["flgWaitRes"] = modMain.Settings.flgWaitRes;
                    dataRow["HostIp"] = modMain.Settings.HostIp;
                    dataRow["HostPort"] = modMain.Settings.HostPort;
                    dataRow["HostTimeout"] = modMain.Settings.HostTimeout;
                    dataSet.Tables["Settings"].Rows.Add(dataRow);
                    dataSet.WriteXml(text);
                }
                else
                {
                    dataSet.ReadXml(text);
                    try
                    {
                        enumerator = dataSet.Tables[0].Rows.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            DataRow dataRow2 = (DataRow)enumerator.Current;
                            dataRow2["PortName"] = modMain.Settings.PortName;
                            dataRow2["BaudRate"] = modMain.Settings.BaudRate;
                            dataRow2["Timeout"] = modMain.Settings.Timeout;
                            dataRow2["TxnTimeout"] = modMain.Settings.TxnTimeout;
                            dataRow2["UploadTimeout"] = modMain.Settings.UploadTimeout;
                            dataRow2["TracePath"] = modMain.Settings.TracePath;
                            dataRow2["LICData"] = modMain.Settings.LICData;
                            dataRow2["Trace"] = modMain.Settings.Trace;
                            dataRow2["Delay"] = modMain.Settings.Delay;
                            dataRow2["DelayTimeout"] = modMain.Settings.DelayTimeout;
                            if (dataSet.Tables[0].Columns.IndexOf("flgWaitRes") < 0)
                            {
                                dataSet.Tables[0].Columns.Add("flgWaitRes");
                            }
                            dataRow2["flgWaitRes"] = modMain.Settings.flgWaitRes;
                            if (dataSet.Tables[0].Columns.IndexOf("HostIp") < 0)
                            {
                                dataSet.Tables[0].Columns.Add("HostIp");
                            }
                            dataRow2["HostIp"] = modMain.Settings.HostIp;
                            if (dataSet.Tables[0].Columns.IndexOf("HostPort") < 0)
                            {
                                dataSet.Tables[0].Columns.Add("HostPort");
                            }
                            dataRow2["HostPort"] = modMain.Settings.HostPort;
                            if (dataSet.Tables[0].Columns.IndexOf("HostTimeout") < 0)
                            {
                                dataSet.Tables[0].Columns.Add("HostTimeout");
                            }
                            dataRow2["HostTimeout"] = modMain.Settings.HostTimeout;
                        }
                    }
                    finally
                    {
                        //IEnumerator enumerator;
                        if (enumerator is IDisposable)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                    dataSet.WriteXml(text);
                }
            }
            catch (Exception expr_5EE)
            {
                ProjectData.SetProjectError(expr_5EE);
                Exception ex = expr_5EE;
                MessageBox.Show(ex.Message, "Save File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(ex.ToString(), "Save File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
        }

        public static void CreateLoadSettings()
        {
            DataSet dataSet = new DataSet();
            try
            {
                string text = modMain.GetCurrPath() + "\\ubaSettings.xml";
                DataRow dataRow;
                if (!File.Exists(text))
                {
                    dataSet.Tables.Add("Settings");
                    dataSet.Tables[0].Columns.Add("PortName");
                    dataSet.Tables[0].Columns.Add("BaudRate");
                    dataSet.Tables[0].Columns.Add("Timeout");
                    dataSet.Tables[0].Columns.Add("TxnTimeout");
                    dataSet.Tables[0].Columns.Add("UploadTimeout");
                    dataSet.Tables[0].Columns.Add("Trace");
                    dataSet.Tables[0].Columns.Add("TracePath");
                    dataSet.Tables[0].Columns.Add("Delay");
                    dataSet.Tables[0].Columns.Add("DelayTimeout");
                    dataSet.Tables[0].Columns.Add("LICData");
                    dataSet.Tables[0].Columns.Add("flgWaitRes");
                    dataSet.Tables[0].Columns.Add("HostIp");
                    dataSet.Tables[0].Columns.Add("HostPort");
                    dataSet.Tables[0].Columns.Add("HostTimeout");
                    dataRow = dataSet.Tables["Settings"].NewRow();
                    dataRow["PortName"] = "COM9";
                    dataRow["BaudRate"] = "115200";
                    dataRow["Timeout"] = "10";
                    dataRow["TxnTimeout"] = "90";
                    dataRow["UploadTimeout"] = "300";
                    dataRow["Trace"] = "1";
                    dataRow["TracePath"] = modMain.GetCurrPath();
                    dataRow["Delay"] = "0";
                    dataRow["DelayTimeout"] = "5";
                    dataRow["LICData"] = "15CEB6E991F3279E";
                    dataRow["flgWaitRes"] = "0";
                    dataRow["HostIp"] = "196.216.144.142";
                    dataRow["HostPort"] = "9091";
                    dataRow["HostTimeout"] = "30";
                    dataSet.Tables["Settings"].Rows.Add(dataRow);
                    dataSet.WriteXml(text);
                }
                dataSet.ReadXml(text);
                dataRow = dataSet.Tables[0].Rows[0];
                modMain.Settings.PortName = Conversions.ToString(dataRow["PortName"]);
                modMain.Settings.BaudRate = Conversions.ToInteger(dataRow["BaudRate"]);
                modMain.Settings.Timeout = Conversions.ToShort(dataRow["Timeout"]);
                modMain.Settings.TxnTimeout = Conversions.ToShort(dataRow["TxnTimeout"]);
                modMain.Settings.UploadTimeout = Conversions.ToShort(dataRow["UploadTimeout"]);
                modMain.Settings.TracePath = dataRow["TracePath"].ToString();
                modMain.Settings.LICData = dataRow["LICData"].ToString();
                modMain.Settings.Trace = Conversions.ToBoolean(dataRow["Trace"].ToString());
                modMain.Settings.Delay = Conversions.ToBoolean(dataRow["Delay"].ToString());
                modMain.Settings.DelayTimeout = (int)Conversions.ToShort(dataRow["DelayTimeout"]);
                if (dataSet.Tables[0].Columns.IndexOf("flgWaitRes") < 0)
                {
                    dataSet.Tables[0].Columns.Add("flgWaitRes");
                    dataSet.Tables[0].Rows[0]["flgWaitRes"] = "0";
                }
                modMain.Settings.flgWaitRes = Conversions.ToBoolean(dataRow["flgWaitRes"]);
                if (dataSet.Tables[0].Columns.IndexOf("HostIp") < 0)
                {
                    dataSet.Tables[0].Columns.Add("HostIp");
                    dataSet.Tables[0].Rows[0]["HostIp"] = "127.0.0.1";
                }
                modMain.Settings.HostIp = Conversions.ToString(dataRow["HostIp"]);
                if (dataSet.Tables[0].Columns.IndexOf("HostPort") < 0)
                {
                    dataSet.Tables[0].Columns.Add("HostPort");
                    dataRow["HostPort"] = "3457";
                }
                modMain.Settings.HostPort = Conversions.ToInteger(dataRow["HostPort"]);
                if (dataSet.Tables[0].Columns.IndexOf("HostTimeout") < 0)
                {
                    dataSet.Tables[0].Columns.Add("HostTimeout");
                    dataRow["HostTimeout"] = "30";
                }
                modMain.Settings.HostTimeout = Conversions.ToInteger(dataRow["HostTimeout"]);
            }
            catch (Exception expr_5BE)
            {
                ProjectData.SetProjectError(expr_5BE);
                Exception ex = expr_5BE;
                MessageBox.Show(ex.Message, "Load File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(ex.ToString(), "Load File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ProjectData.ClearProjectError();
            }
        }

    }
}