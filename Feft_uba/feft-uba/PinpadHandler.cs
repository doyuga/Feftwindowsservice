using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Timers;
namespace feft_uba
{
	public class PinpadHandler
	{
		private int hostPort;

		private SerialPort mySerialPort;
		private string indata;

		private string hostIpAddress;

		private bool responseFromPort = false;
        private bool flgSysConfig;

        private bool timeout = false;

        public PinpadHandler()
		{
            this.mySerialPort = new SerialPort();

            modMain.CreateLoadSettings();
           
		}

		private void disconnect()
		{
			if (this.mySerialPort.IsOpen)
			{
				this.mySerialPort.Close();
			}
		}
        public string sendEftRequest(long amount)
        {
            string result;
            try
            {
                try
                {
                    //this.mySerialPort.Open();
                    this.mySerialPort.PortName = modMain.Settings.PortName;
                    this.mySerialPort.BaudRate = modMain.Settings.BaudRate; ;
                    this.mySerialPort.Parity = Parity.None;
                    this.mySerialPort.DataBits = 8;
                    this.mySerialPort.StopBits = StopBits.One;
                    this.mySerialPort.Handshake = Handshake.None;
                    this.mySerialPort.DataReceived += new SerialDataReceivedEventHandler(this.serial_DataReceived);
                    this.mySerialPort.Open();
                }
                catch (Exception ex)
                {
                    result = string.Concat(new object[]
                    {
                        "<TransactionResponse><Status>Port error</Status><Amount>",
                        amount,
                        "</Amount><ErrorMessage>",
                        ex.Message,
                        "</ErrorMessage></TransactionResponse>"
                    });
                    return result;
                }
                string eftTransactionData = this.getEftTransactionData(amount);
                Console.WriteLine("Purchase request : " + eftTransactionData);
                if (eftTransactionData.Contains("Canceled"))
                {
                    this.mySerialPort.Write("");
                    Thread.Sleep(200);
                    this.disconnect();
                    result = eftTransactionData;
                }
                else if (eftTransactionData.Contains("not prep"))
                {
                    this.mySerialPort.Write("");
                    Thread.Sleep(200);
                    this.disconnect();
                    result = "Prep Terminal";
                }
                else
                {
                    Console.WriteLine("Sending transaction request");
                    string text = this.sendAndReceiveData(eftTransactionData);
                    Console.WriteLine("Sending transaction result to pinpad");
                    this.mySerialPort.Write(text);
                    this.checkEftResponse();
                    this.disconnect();
                    result = this.getEftResponse();
                }
            }
            catch (Exception ex)
            {
                result = "<TransactionResponse><Status>Error</Status><ErrorMessage>" + ex.Message + "</ErrorMessage></TransactionResponse>";
            }
            return result;
        }



        //public string sendEftRequest(long amount)
        //{

        //          string result2;
        //          try
        //          {
        //              try
        //              {
        //                  this.mySerialPort.PortName = modMain.Settings.PortName;
        //                  this.mySerialPort.BaudRate = modMain.Settings.BaudRate;;
        //                  this.mySerialPort.Parity = Parity.None;
        //                  this.mySerialPort.DataBits = 8;
        //                  this.mySerialPort.StopBits = StopBits.One;
        //                  this.mySerialPort.Handshake = Handshake.None;
        //                  this.mySerialPort.DataReceived += new SerialDataReceivedEventHandler(this.serial_DataReceived);
        //                  this.mySerialPort.Open();
        //              }
        //              catch (Exception e)
        //              {
        //                  result2 = string.Concat(new object[]
        //			{
        //				"<TransactionResponse><Status>Port error</Status><Amount>",
        //				amount,
        //				"</Amount><ErrorMessage>",
        //				e.Message,
        //				"</ErrorMessage></TransactionResponse>"
        //			});
        //                  return result2;
        //              }
        //              string eftTransactionData = this.getEftTransactionData(amount);
        //              Console.WriteLine("Purchase request : " + eftTransactionData);
        //              if (eftTransactionData.Contains("Canceled"))
        //              {
        //                  this.mySerialPort.Write("");
        //                  Thread.Sleep(200);
        //                  this.disconnect();
        //                  result2 = eftTransactionData;
        //              }
        //              else
        //              {
        //                  string result = this.sendAndReceiveData(eftTransactionData);
        //                  this.mySerialPort.Write(result);
        //                  while (!this.checkEftResponse())
        //                  {
        //                  }
        //                  this.disconnect();
        //                  result2 = this.getEftResponse();
        //              }
        //          }
        //          catch (Exception e)
        //          {
        //              result2 = "<TransactionResponse><Status>Error</Status><ErrorMessage>" + e.Message + "</ErrorMessage></TransactionResponse>";
        //          }
        //          return result2;

        //}

        private string getEftTransactionData(long amount)
        {
            this.mySerialPort.DiscardInBuffer();
            this.mySerialPort.DiscardOutBuffer();
            string text = "ITEX_Purchase~" + amount;
            string result;
            try
            {
                this.mySerialPort.Write(text);
            }
            catch (Exception ex)
            {
                result = string.Concat(new object[]
                {
                    "<TransactionResponse><Status>Port error</Status><Amount>",
                    amount,
                    "</Amount><ErrorMessage>",
                    ex.Message,
                    "</ErrorMessage></TransactionResponse>"
                });
                return result;
            }
            this.checkEftResponse();
            result = this.getEftResponse();
            return result;
        }

        //      private string getEftTransactionData(long amount)
        //{

        //          this.mySerialPort.DiscardInBuffer();
        //          this.mySerialPort.DiscardOutBuffer();
        //          string data = "ITEX_Purchase~" + amount;
        //          string result;
        //          try
        //          {
        //              this.mySerialPort.Write(data);
        //          }
        //          catch (Exception e)
        //          {
        //              result = string.Concat(new object[]
        //		{
        //			"<TransactionResponse><Status>Port error</Status><Amount>",
        //			amount,
        //			"</Amount><ErrorMessage>",
        //			e.Message,
        //			"</ErrorMessage></TransactionResponse>"
        //		});
        //              return result;
        //          }
        //          while (!this.checkEftResponse())
        //          {
        //          }
        //          result = this.getEftResponse();
        //          return result;

        //}

        //private bool checkEftResponse()
        //{
        //	return this.responseFromPort;
        //}

        private bool checkEftResponse()
        {
            int num = 0;
            try
            {
                do
                {
                    Thread.Sleep(1000);
                    num++;
                    if (num > 40)
                    {
                        break;
                    }
                }
                while (!this.responseFromPort);
            }
            catch (Exception var_1_33)
            {
            }
            return this.responseFromPort;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            this.timeout = true;
            this.mySerialPort.Write("<TransactionResponse><Status>Time out</Status></TransactionResponse>");
            Console.WriteLine("Timer");
        }

        private string getEftResponse()
        {
            string result;
            if (this.responseFromPort)
            {
                this.responseFromPort = false;
                result = this.indata;
            }
            else
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		//private string getEftResponse()
		//{
  //          string result;
  //          if (this.responseFromPort)
  //          {
  //              this.responseFromPort = false;
  //              result = this.indata;
  //          }
  //          else
  //          {
  //              result = null;
  //          }
  //          return result;
		//}
        /// <summary>
        /// ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;
            this.indata = serialPort.ReadExisting();
            this.responseFromPort = true;
        }

        //private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //          SerialPort sp = (SerialPort)sender;
        //          this.indata = sp.ReadExisting();
        //          this.responseFromPort = true;
        //}

        public void setHostParameters()//(string IpAdress, int Port)
		{
			//this.hostPort = Port;
            this.hostPort = modMain.Settings.HostPort;
            this.hostIpAddress = modMain.Settings.HostIp;
		}

        public string prepTerminal()
		{
            string result2;
            try
            {
                this.mySerialPort.Open();
                this.mySerialPort.DiscardInBuffer();
                this.mySerialPort.DiscardOutBuffer();
                Console.WriteLine("hostIpAddress: " + this.hostIpAddress);
                for (int loop = 1; loop <= 5; loop++)
                {
                    string data = "ITEX_Prep~" + loop;
                    Console.WriteLine("data sent: " + data);
                    this.mySerialPort.Write(data);
                    while (!this.checkEftResponse())
                    {
                    }
                    data = this.getEftResponse();
                    if (data == "Failed")
                    {
                        result2 = "<TransactionResponse><Status>Failure</Status><Message>Prep terminal failed</Message></TransactionResponse>";
                        return result2;
                    }
                    if (data == "Canceled")
                    {
                        result2 = data;
                        return result2;
                    }
                    string result = this.sendAndReceiveData(data);
                    Console.WriteLine(string.Concat(new object[]
					{
						"\nresult ",
						loop,
						": ",
						result.Length
					}));
                    Console.WriteLine("\nresult : " + result);
                    this.mySerialPort.Write(result);
                    Console.WriteLine("\nwaiting for response");
                    while (!this.checkEftResponse())
                    {
                    }
                    data = this.getEftResponse();
                    Console.WriteLine(string.Concat(new object[]
					{
						"response ",
						loop,
						": ",
						data,
						"\n"
					}));
                    if (data == "FAILED")
                    {
                        this.disconnect();
                        result2 = "<TransactionResponse><Status>Failure</Status><Message>Prep terminal failed</Message></TransactionResponse>";
                        return result2;
                    }
                }
                this.disconnect();
                result2 = "<TransactionResponse><Status>Success</Status><Message>Prep terminal successfull</Message></TransactionResponse>";
            }
            catch (Exception e)
            {
                this.disconnect();
                result2 = "<TransactionResponse><Status>Port error</Status><ErrorMessage>" + e.Message + "</ErrorMessage></TransactionResponse>";
            }
            return result2;
		}

		private void postRequest(string data)
		{
			WebRequest request = WebRequest.Create("https://196.6.103.4:80/tams/tams/devinterface/newkey.php");
			request.Method = "POST";
			string postData = "This is a test that posts this string to a Web server.";
			byte[] byteArray = Encoding.UTF8.GetBytes(postData);
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = (long)byteArray.Length;
			Stream dataStream = request.GetRequestStream();
			dataStream.Write(byteArray, 0, byteArray.Length);
			dataStream.Close();
			WebResponse response = request.GetResponse();
			Console.WriteLine(((HttpWebResponse)response).StatusDescription);
			dataStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(dataStream);
			string responseFromServer = reader.ReadToEnd();
			Console.WriteLine(responseFromServer);
			reader.Close();
			dataStream.Close();
			response.Close();
		}

		private string sendAndReceive(string request_url)
		{
			string hostName = "196.6.103.4";
			int hostPort = 80;
			string page = null;
			byte[] array = new byte[1];
			byte[] bytesReceived = array;
			IPAddress host = IPAddress.Parse(hostName);
			IPEndPoint hostep = new IPEndPoint(host, hostPort);
			Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			sock.Connect(hostep);
			int response = sock.Send(Encoding.UTF8.GetBytes(request_url));
			int bytes = sock.Receive(bytesReceived, bytesReceived.Length, SocketFlags.None);
			page += Encoding.ASCII.GetString(bytesReceived, 0, bytes);
			Console.WriteLine(page);
			string[] tokens = page.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None);
			Console.WriteLine(tokens[1]);
			sock.Close();
			return page;
		}
        private string sendAndReceiveData(string transData)
        {
            byte[] array = new byte[2048];
            string result;
            try
            {
                IPAddress address = IPAddress.Parse(this.hostIpAddress);
                IPEndPoint remoteEP = new IPEndPoint(address, this.hostPort);
                Socket socket;
                try
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    if (socket == null)
                    {
                        result = "<TransactionResponse><Status>Socket error</Status><ErrorMesage>Cannot open the socket</ErrorMessage></TransactionResponse>";
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    result = "<TransactionResponse><Status>Socket error</Status><ErrorMesage>" + ex.Message + "</ErrorMessage></TransactionResponse>";
                    return result;
                }
                try
                {
                    try
                    {
                        socket.Connect(remoteEP);
                    }
                    catch (Exception ex)
                    {
                        result = "<TransactionResponse><Status>Comm error</Status><ErrorMesage>" + ex.Message + "</ErrorMessage></TransactionResponse>";
                        return result;
                    }
                    Console.WriteLine("Socket connected to {0}", socket.RemoteEndPoint.ToString());
                    byte[] bytes = Encoding.ASCII.GetBytes(transData);
                    try
                    {
                        int num = socket.Send(bytes);
                        if (num <= 0)
                        {
                            result = "<TransactionResponse><Status>Comm error</Status><ErrorMesage>Sending failed</ErrorMessage></TransactionResponse>";
                            return result;
                        }
                    }
                    catch (Exception ex)
                    {
                        result = "<TransactionResponse><Status>Comm error</Status><ErrorMesage>" + ex.Message + "</ErrorMessage></TransactionResponse>";
                        return result;
                    }
                    int num2 = socket.Receive(array);
                    if (num2 <= 0)
                    {
                        result = "<TransactionResponse><Status>Timeout</Status><ErrorMesage>No response received</ErrorMessage></TransactionResponse>";
                    }
                    else
                    {
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                        Console.WriteLine("\nbytesRec = " + num2);
                        string @string = Encoding.Default.GetString(array, 0, num2);
                        Console.WriteLine("\nreturned value = '{0}'", @string);
                        string text = @string.Substring(@string.IndexOf("\r\n\r\n"), @string.Length - @string.IndexOf("\r\n\r\n"));
                        Console.WriteLine("\ntoken : " + text.Substring(4));
                        result = text;
                    }
                }
                catch (ArgumentNullException ex2)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ex2.ToString());
                    result = "<TransactionResponse><Status>Error</Status><ErrorMessage>" + ex2.Message + "</ErrorMessage></TransactionResponse>";
                }
                catch (SocketException ex3)
                {
                    Console.WriteLine("SocketException : {0}", ex3.ToString());
                    result = "<TransactionResponse><Status>Error</Status><ErrorMessage>" + ex3.Message + "</ErrorMessage></TransactionResponse>";
                }
                catch (Exception ex)
                {
                    result = "<TransactionResponse><Status>Error</Status><ErrorMessage>" + ex.Message + "</ErrorMessage></TransactionResponse>";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result = "ERROR: " + ex.ToString();
            }
            return result;
        }
        //private string sendAndReceiveData(string transData)
        //      {
        //         byte[] bytes = new byte[2048];
        //	string result;
        //	try
        //	{
        //		IPAddress ipAddress = IPAddress.Parse(this.hostIpAddress);
        //		IPEndPoint remoteEP = new IPEndPoint(ipAddress, this.hostPort);
        //		Socket sender;
        //		try
        //		{
        //			sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //			if (sender == null)
        //			{
        //				result = "<TransactionResponse><Status>Socket error</Status><ErrorMesage>Cannot open the socket</ErrorMessage></TransactionResponse>";
        //				return result;
        //			}
        //		}
        //		catch (Exception e)
        //		{
        //			result = "<TransactionResponse><Status>Socket error</Status><ErrorMesage>" + e.Message + "</ErrorMessage></TransactionResponse>";
        //			return result;
        //		}
        //		try
        //		{
        //			try
        //			{
        //				sender.Connect(remoteEP);
        //			}
        //			catch (Exception e)
        //			{
        //				result = "<TransactionResponse><Status>Comm error</Status><ErrorMesage>" + e.Message + "</ErrorMessage></TransactionResponse>";
        //				return result;
        //			}
        //			Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
        //			byte[] msg = Encoding.ASCII.GetBytes(transData);
        //			try
        //			{
        //				int bytesSent = sender.Send(msg);
        //				if (bytesSent <= 0)
        //				{
        //					result = "<TransactionResponse><Status>Comm error</Status><ErrorMesage>Sending failed</ErrorMessage></TransactionResponse>";
        //					return result;
        //				}
        //			}
        //			catch (Exception e)
        //			{
        //				result = "<TransactionResponse><Status>Comm error</Status><ErrorMesage>" + e.Message + "</ErrorMessage></TransactionResponse>";
        //				return result;
        //			}
        //			int bytesRec = sender.Receive(bytes);
        //			if (bytesRec <= 0)
        //			{
        //				result = "<TransactionResponse><Status>Timeout</Status><ErrorMesage>No response received</ErrorMessage></TransactionResponse>";
        //			}
        //			else
        //			{
        //				sender.Shutdown(SocketShutdown.Both);
        //				sender.Close();
        //				Console.WriteLine("\nbytesRec = " + bytesRec);
        //				string resp = Encoding.Default.GetString(bytes, 0, bytesRec);
        //				Console.WriteLine("\nreturned value = '{0}'", resp);
        //				string[] tokens = resp.Split(new string[]
        //				{
        //					"\r\n\r\n"
        //				}, StringSplitOptions.None);
        //				Console.WriteLine("token 1: " + tokens[1]);
        //				result = tokens[1];
        //			}
        //		}
        //		catch (ArgumentNullException ane)
        //		{
        //			Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
        //			result = "<TransactionResponse><Status>Error</Status><ErrorMessage>" + ane.Message + "</ErrorMessage></TransactionResponse>";
        //		}
        //		catch (SocketException se)
        //		{
        //			Console.WriteLine("SocketException : {0}", se.ToString());
        //			result = "<TransactionResponse><Status>Error</Status><ErrorMessage>" + se.Message + "</ErrorMessage></TransactionResponse>";
        //		}
        //		catch (Exception e)
        //		{
        //			result = "<TransactionResponse><Status>Error</Status><ErrorMessage>" + e.Message + "</ErrorMessage></TransactionResponse>";
        //		}
        //	}
        //	catch (Exception e)
        //	{
        //		Console.WriteLine(e.ToString());
        //		result = "ERROR: " + e.ToString();
        //	}
        //	return result;

        //      }
        private bool LoadSettings()
        {
            bool result;
            try
            {
                if (this.flgSysConfig)
                {
                    result = true;
                }
                else
                {
                    modMain.CreateLoadSettings();
                    if (Operators.CompareString(modMain.Settings.HostIp, "", false) == 0)
                    {
                        modMain.Settings.HostIp = "127.0.0.1";
                    }
                    if (modMain.Settings.HostPort < 0)
                    {
                        modMain.Settings.HostPort = 3457;
                    }
                    if (modMain.Settings.HostTimeout <= 0)
                    {
                        modMain.Settings.HostTimeout = 30;
                    }
                    if (modMain.Settings.UploadTimeout <= 0)
                    {
                        modMain.Settings.UploadTimeout = 300;
                    }
                    if (modMain.Settings.TxnTimeout <= 0)
                    {
                        modMain.Settings.UploadTimeout = 90;
                    }
                    if (Operators.CompareString(modMain.Settings.TracePath, "", false) == 0)
                    {
                        modMain.Settings.TracePath = this.GetCurrPath();
                    }
                    result = true;
                }
            }
            catch (Exception expr_D1)
            {
                ProjectData.SetProjectError(expr_D1);
                Exception ex = expr_D1;
                this.Trace("LoadSettings Error : " + ex.Message);
                this.Trace("LoadSettings Error : " + ex.ToString());
                result = false;
                ProjectData.ClearProjectError();
            }
            return result;
        }
        private string GetCurrPath()
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
        private bool Trace(string msg)
        {
            StreamWriter streamWriter = null;
            bool result = false;
            try
            {
                if (!modMain.Settings.Trace)
                {
                    return true;
                }
                if (!Directory.Exists(modMain.Settings.TracePath))
                {
                    Directory.CreateDirectory(modMain.Settings.TracePath);
                }
                streamWriter = new StreamWriter(modMain.Settings.TracePath + "\\TR" + DateAndTime.Now.ToString("yyyyMMdd") + ".TXT", true);
                streamWriter.WriteLine(Strings.Format(DateAndTime.Now, "HH:mm:ss") + " " + msg + "");
                streamWriter.Flush();
                streamWriter.Close();
                streamWriter.Dispose();
                result = true;
            }
            catch (Exception expr_AB)
            {
                ProjectData.SetProjectError(expr_AB);
                Exception ex = expr_AB;
                Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
                ProjectData.ClearProjectError();
            }
            try
            {
                if (streamWriter != null)
                {
                    streamWriter.Dispose();
                }
            }
            catch (Exception expr_D2)
            {
                ProjectData.SetProjectError(expr_D2);
                ProjectData.ClearProjectError();
            }
            return result;
        }

        private bool Trace(string strmsg, byte[] msg, int Llen)
        {
            bool result;
            try
            {
                if (!modMain.Settings.Trace)
                {
                    result = true;
                }
                else
                {
                    if (!Directory.Exists(modMain.Settings.TracePath))
                    {
                        Directory.CreateDirectory(modMain.Settings.TracePath);
                    }
                    strmsg += this.ByteToTraceStr(msg, Llen);
                    StreamWriter streamWriter = new StreamWriter(modMain.Settings.TracePath + "\\TR" + DateAndTime.Now.ToString("yyyyMMdd") + ".TXT", true);
                    streamWriter.WriteLine(Strings.Format(DateAndTime.Now, "HH:mm:ss") + " " + strmsg);
                    streamWriter.Flush();
                    streamWriter.Close();
                    streamWriter.Dispose();
                    result = true;
                }
            }
            catch (Exception expr_B1)
            {
                ProjectData.SetProjectError(expr_B1);
                Exception ex = expr_B1;
                Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
                result = false;
                ProjectData.ClearProjectError();
            }
            return result;
        }
        private byte[] ByteStrToByte(string str)
        {
            checked
            {
                byte[] array = new byte[str.Length / 2 - 1 + 1];
                byte[] result;
                try
                {
                    if (str.Length % 2 != 0)
                    {
                        result = null;
                    }
                    else
                    {
                        int arg_2E_0 = 0;
                        int num = str.Length / 2 - 1;
                        for (int i = arg_2E_0; i <= num; i++)
                        {
                            array[i] = Conversions.ToByte("&H" + Strings.Mid(str, i * 2 + 1, 2));
                        }
                        result = array;
                    }
                }
                catch (Exception expr_5C)
                {
                    ProjectData.SetProjectError(expr_5C);
                    Exception ex = expr_5C;
                    this.Trace("ByteStrToByte Error : " + ex.Message);
                    this.Trace("ByteStrToByte Error : " + ex.ToString());
                    result = null;
                    ProjectData.ClearProjectError();
                }
                return result;
            }
        }

        private string ByteToTraceStr(byte[] msg, int Llen)
        {
            string text = "";
            checked
            {
                try
                {
                    int arg_0C_0 = 0;
                    int num = Llen - 1;
                    for (int i = arg_0C_0; i <= num; i++)
                    {
                        if (msg[i] < 32 | msg[i] > 127)
                        {
                            text = text + "<" + Conversion.Hex(msg[i]) + ">";
                        }
                        else
                        {
                            text += Conversions.ToString(Strings.Chr((int)msg[i]));
                        }
                    }
                }
                catch (Exception expr_5A)
                {
                    ProjectData.SetProjectError(expr_5A);
                    Exception ex = expr_5A;
                    this.Trace("ByteToTraceStr Error : " + ex.Message);
                    this.Trace("ByteToTraceStr Error : " + ex.ToString());
                    text = "";
                    ProjectData.ClearProjectError();
                }
                return text;
            }
        }
        private bool Open_Port(ref SerialPort Serial_Port, int BaudRate)
        {
            bool result;
            try
            {
                try
                {
                    if (Serial_Port.IsOpen)
                    {
                        this.Trace("Already port is opened,It is restart the port. ");
                        Serial_Port.Close();
                    }
                }
                catch (Exception expr_1E)
                {
                    ProjectData.SetProjectError(expr_1E);
                    Exception ex = expr_1E;
                    this.Trace("Open_Port : " + ex.Message);
                    ProjectData.ClearProjectError();
                }
                Serial_Port.PortName = modMain.Settings.PortName;
                Serial_Port.BaudRate = BaudRate;
                Serial_Port.Parity = Parity.None;
                Serial_Port.DataBits = 8;
                Serial_Port.StopBits = StopBits.One;
                Serial_Port.Handshake = Handshake.None;
                Serial_Port.Open();
                this.Trace("Port open successfully ...........");
                result = true;
            }
            catch (Exception expr_93)
            {
                ProjectData.SetProjectError(expr_93);
                Exception ex2 = expr_93;
                this.Trace("Open_Port Error : " + ex2.Message);
                result = false;
                ProjectData.ClearProjectError();
            }
            return result;
        }

        //private bool Open_Port(ref SerialPort Serial_Port, string PortNmame, int BaudRate)
        private bool Open_Port(ref SerialPort Serial_Port)
        {
            bool result;
            try
            {
                try
                {
                    if (Serial_Port.IsOpen)
                    {
                        this.Trace("Already port is opened,It is restart the port. ");
                        Serial_Port.Close();
                    }
                }
                catch (Exception expr_1E)
                {
                    ProjectData.SetProjectError(expr_1E);
                    Exception ex = expr_1E;
                    this.Trace("Open_Port : " + ex.Message);
                    ProjectData.ClearProjectError();
                }
                Serial_Port.PortName = modMain.Settings.PortName;
                Serial_Port.BaudRate = modMain.Settings.BaudRate;
                Serial_Port.Parity = Parity.None;
                //Serial_Port.
                Serial_Port.DataBits = 8;
                Serial_Port.StopBits = StopBits.One;
                Serial_Port.Handshake = Handshake.None;
                Serial_Port.DataReceived += new SerialDataReceivedEventHandler(this.serial_DataReceived);
                Serial_Port.Open();
                this.Trace("Port open successfully ...........");
                result = true;
            }
            catch (Exception expr_8A)
            {
                ProjectData.SetProjectError(expr_8A);
                Exception ex2 = expr_8A;
                this.Trace("Open_Port Error : " + ex2.Message);
                result = false;
                ProjectData.ClearProjectError();
            }
            return result;
        }

        private bool Port_Setting(ref SerialPort Serial_Port, int BaudRate)
        {
            bool result;
            try
            {
                if (!Serial_Port.IsOpen)
                {
                    Serial_Port.PortName = modMain.Settings.PortName;
                    Serial_Port.BaudRate = BaudRate;
                    Serial_Port.Parity = Parity.None;
                    Serial_Port.DataBits = 8;
                    Serial_Port.StopBits = StopBits.One;
                    Serial_Port.Handshake = Handshake.None;
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception expr_4C)
            {
                ProjectData.SetProjectError(expr_4C);
                Exception ex = expr_4C;
                this.Trace("Port_Setting Error : " + ex.Message);
                result = false;
                ProjectData.ClearProjectError();
            }
            return result;
        }

        private bool Close_Port(ref SerialPort Serial_Port)
        {
            bool result;
            try
            {
                if (Serial_Port.IsOpen)
                {
                    Serial_Port.Close();
                }
                this.Trace("Port closed successfully ...........");
                result = true;
            }
            catch (Exception expr_20)
            {
                ProjectData.SetProjectError(expr_20);
                Exception ex = expr_20;
                this.Trace("Close_Port Error : " + ex.Message);
                result = false;
                ProjectData.ClearProjectError();
            }
            return result;
        }
	}
}
