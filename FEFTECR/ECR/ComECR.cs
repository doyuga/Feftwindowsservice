using ECR.My;
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

namespace ECR
{
	[ComClass("73f50a01-9dc5-409d-b101-f70c341115aa", "72fe1453-1651-4ac3-9fd2-d756f3342523", "3ecee5fc-c913-454c-83ab-d2aa91308b32"), ClassInterface(ClassInterfaceType.None), Guid("73f50a01-9dc5-409d-b101-f70c341115aa")]
	public class ComECR : NewCommECR
	{
		[ComVisible(true), Guid("72fe1453-1651-4ac3-9fd2-d756f3342523")]
        //public interface _ComECR
        //{
        //    [DispId(23)]
        //    string GetSet_VFI_ECRRcptNum
        //    {
        //        [DispId(23)]
        //        get;
        //        [DispId(23)]
        //        set;
        //    }

        //    [DispId(24)]
        //    string GetSet_VFI_Amount
        //    {
        //        [DispId(24)]
        //        get;
        //        [DispId(24)]
        //        set;
        //    }

        //    [DispId(25)]
        //    string GetSet_VFI_CardNum
        //    {
        //        [DispId(25)]
        //        get;
        //    }

        //    [DispId(26)]
        //    string GetSet_VFI_CHName
        //    {
        //        [DispId(26)]
        //        get;
        //    }

        //    [DispId(27)]
        //    string GetSet_VFI_MessNum
        //    {
        //        [DispId(27)]
        //        get;
        //        [DispId(27)]
        //        set;
        //    }

        //    [DispId(28)]
        //    string GetSet_VFI_RespCode
        //    {
        //        [DispId(28)]
        //        get;
        //    }

        //    [DispId(29)]
        //    string GetSet_VFI_RespMess
        //    {
        //        [DispId(29)]
        //        get;
        //    }

        //    [DispId(30)]
        //    string GetSet_VFI_ApprovalCode
        //    {
        //        [DispId(30)]
        //        get;
        //    }

        //    [DispId(31)]
        //    string GetSet_VFI_DateTime
        //    {
        //        [DispId(31)]
        //        get;
        //    }

        //    [DispId(32)]
        //    string GetSet_VFI_Batch
        //    {
        //        [DispId(32)]
        //        get;
        //    }

        //    [DispId(33)]
        //    string GetSet_VFI_REFNO
        //    {
        //        [DispId(33)]
        //        get;
        //    }

        //    [DispId(34)]
        //    string GetSet_VFI_InvoiceNo
        //    {
        //        [DispId(34)]
        //        get;
        //        [DispId(34)]
        //        set;
        //    }

        //    [DispId(35)]
        //    string GetSet_VFI_TID
        //    {
        //        [DispId(35)]
        //        get;
        //        [DispId(35)]
        //        set;
        //    }

        //    [DispId(36)]
        //    string GetSet_VFI_PTID
        //    {
        //        [DispId(36)]
        //        set;
        //    }

        //    [DispId(37)]
        //    string GetSet_VFI_MID
        //    {
        //        [DispId(37)]
        //        get;
        //    }

        //    [DispId(38)]
        //    string GetSet_VFI_TransSource
        //    {
        //        [DispId(38)]
        //        get;
        //    }

        //    [DispId(39)]
        //    string GetSet_VFI_AuthMode
        //    {
        //        [DispId(39)]
        //        get;
        //    }

        //    [DispId(40)]
        //    string GetSet_VFI_TransType
        //    {
        //        [DispId(40)]
        //        get;
        //        [DispId(40)]
        //        set;
        //    }

        //    [DispId(41)]
        //    string GetSet_VFI_Expiry
        //    {
        //        [DispId(41)]
        //        get;
        //    }

        //    [DispId(42)]
        //    string GetSet_VFI_CardName
        //    {
        //        [DispId(42)]
        //        get;
        //    }

        //    [DispId(43)]
        //    string GetSet_VFI_CHVerification
        //    {
        //        [DispId(43)]
        //        get;
        //    }

        //    [DispId(44)]
        //    string GetSet_VFI_EMV_Label
        //    {
        //        [DispId(44)]
        //        get;
        //    }

        //    [DispId(45)]
        //    string GetSet_VFI_EMV_AID
        //    {
        //        [DispId(45)]
        //        get;
        //    }

        //    [DispId(46)]
        //    string GetSet_VFI_EMV_TVR
        //    {
        //        [DispId(46)]
        //        get;
        //    }

        //    [DispId(47)]
        //    string GetSet_VFI_EMV_TSI
        //    {
        //        [DispId(47)]
        //        get;
        //    }

        //    [DispId(48)]
        //    string GetSet_VFI_EMV_AC
        //    {
        //        [DispId(48)]
        //        get;
        //    }

        //    [DispId(49)]
        //    string GetSet_VFI_AdditionalInfo
        //    {
        //        [DispId(49)]
        //        get;
        //        [DispId(49)]
        //        set;
        //    }

        //    [DispId(50)]
        //    string GetSet_VFI_VoidInvoiceNo
        //    {
        //        [DispId(50)]
        //        get;
        //        [DispId(50)]
        //        set;
        //    }

        //    [DispId(51)]
        //    string GetSet_VFI_DBCount
        //    {
        //        [DispId(51)]
        //        get;
        //    }

        //    [DispId(52)]
        //    string GetSet_VFI_CRCount
        //    {
        //        [DispId(52)]
        //        get;
        //    }

        //    [DispId(53)]
        //    string GetSet_VFI_DBAmount
        //    {
        //        [DispId(53)]
        //        get;
        //    }

        //    [DispId(54)]
        //    string GetSet_VFI_CRAmount
        //    {
        //        [DispId(54)]
        //        get;
        //    }

        //    [DispId(55)]
        //    string GetSet_VFI_ReportType
        //    {
        //        [DispId(55)]
        //        get;
        //        [DispId(55)]
        //        set;
        //    }

        //    [DispId(56)]
        //    string GetSet_VFI_CurrCode
        //    {
        //        [DispId(56)]
        //        get;
        //        [DispId(56)]
        //        set;
        //    }

        //    [DispId(57)]
        //    string GetSet_VFI_EMV_CID
        //    {
        //        [DispId(57)]
        //        get;
        //    }

        //    [DispId(58)]
        //    string GetSet_VFI_TIPAmount
        //    {
        //        [DispId(58)]
        //        get;
        //        [DispId(58)]
        //        set;
        //    }

        //    [DispId(59)]
        //    string GetSet_VFI_PreauthComplAmount
        //    {
        //        [DispId(59)]
        //        get;
        //        [DispId(59)]
        //        set;
        //    }

        //    [DispId(60)]
        //    string GetSet_VFI_OrgionalInvoiceNo
        //    {
        //        [DispId(60)]
        //        get;
        //        [DispId(60)]
        //        set;
        //    }

        //    [DispId(61)]
        //    string GetSet_VFI_PreauthApprovalCode
        //    {
        //        [DispId(61)]
        //        get;
        //        [DispId(61)]
        //        set;
        //    }

        //    [DispId(62)]
        //    string GetSet_VFI_TelNo
        //    {
        //        [DispId(62)]
        //        get;
        //    }

        //    [DispId(63)]
        //    string GetSet_VFI_CashBackAmount
        //    {
        //        [DispId(63)]
        //        get;
        //        [DispId(63)]
        //        set;
        //    }

        //    [DispId(1)]
        //    void Install();

        //    [DispId(2)]
        //    void Uninstall();

        //    [DispId(3)]
        //    bool VFI_LoadSetting();

        //    [DispId(4)]
        //    bool VFI_LoadSetting(ref string RespCode, ref string RespMess);

        //    [DispId(5)]
        //    bool VFI_DoSetup();

        //    [DispId(6)]
        //    bool VFI_DoSetup(ref string RespCode, ref string RespMess);

        //    [DispId(7)]
        //    bool VFI_InitializeAll();

        //    [DispId(8)]
        //    string VFI_DllVersion();

        //    [DispId(9)]
        //    string VFI_AboutDll();

        //    [DispId(10)]
        //    bool VFI_GetAuth();

        //    [DispId(11)]
        //    bool VFI_VoidTrans();

        //    [DispId(12)]
        //    bool VFI_Settle();

        //    [DispId(13)]
        //    bool VFI_Report();

        //    [DispId(14)]
        //    bool VFI_GetTelNo();

        //    [DispId(15)]
        //    bool VFI_GetAuth(string TID, string Amount, string ECRRcptNum, ref string RespCode, ref string RespMess);

        //    [DispId(16)]
        //    bool VFI_VoidTrans(string TID, string Amount, string VoidInvoiceNo, string ECRRcptNum, ref string RespCode, ref string RespMess);

        //    [DispId(17)]
        //    bool GetSettings(ref string PortName, ref int BaudRate, ref short Timeout, ref int TxnTimeout, ref int UploadTimeout, ref string TracePath, ref bool Trace, ref bool Delay, ref short DelayTimeout, ref bool WaitMessge);

        //    [DispId(18)]
        //    bool SaveSettings(string PortName, int BaudRate, short Timeout, int TxnTimeout, int UploadTimeout, string TracePath, bool Trace, bool Delay, short DelayTimeout, bool WaitMessge);

        //    [DispId(19)]
        //    bool VFI_GetFieldValue(short FieldID, ref string FieldValue);

        //    [DispId(20)]
        //    bool VFI_SetFieldValue(short FieldID, string TValue);

        //    [DispId(21)]
        //    string VFI_GetFieldValue(short FieldID);

        //    [DispId(22)]
        //    string VFI_SetFieldValue1(short FieldID, string TValue);

        //    [DispId(64)]
        //    void Dispose();
        //}

		private class MsgType
		{
			public const string CVFI_InitTrans = "01";

			public const string CVFI_GetAuth = "02";

			public const string CVFI_VoidTrans = "03";

			public const string CVFI_Settle = "04";

			public const string CVFI_Report = "05";

			public const string CVFI_SendHost = "06";

			public const string CVFI_GetTelNo = "07";
		}

		public enum Results : short
		{
			CVFI_ECRRcptNum = 1,
			CVFI_TransType,
			CVFI_Amount,
			CVFI_CardNum,
			CVFI_Expiry,
			CVFI_CHName,
			CVFI_MessNum,
			CVFI_CardName,
			CVFI_TransSource,
			CVFI_AuthMode,
			CVFI_CHVerification,
			CVFI_RespCode,
			CVFI_RespMess,
			CVFI_ApprovalCode,
			CVFI_DateTime,
			CVFI_EMV_Label,
			CVFI_EMV_AID,
			CVFI_EMV_TVR,
			CVFI_EMV_TSI,
			CVFI_EMV_AC,
			CVFI_TIPAmount,
			CVFI_PreauthComplAmount,
			CVFI_PreauthApprovalCode,
			CVFI_VoidInvoiceNo,
			CVFI_DBCount,
			CVFI_CRCount,
			CVFI_DBAmount,
			CVFI_CRAmount,
			CVFI_AdditionalInfo,
			CVFI_ReportType,
			CVFI_RefNo,
			CVFI_InvoiceNo,
			CVFI_TID,
			CVFI_MID,
			CVFI_BatchNo,
			CVFI_MacSourceData,
			CVFI_MAC,
			CVFI_EMV_CID,
			CVFI_OrgionalInvoiceNo,
			CVFI_CurrCode,
			CVFI_CashBackAmount,
			Length
		}

		public const string ClassId = "73f50a01-9dc5-409d-b101-f70c341115aa";

		public const string InterfaceId = "72fe1453-1651-4ac3-9fd2-d756f3342523";

		public const string EventsId = "3ecee5fc-c913-454c-83ab-d2aa91308b32";

		private SerialPort Serial_Port;

		private byte[] STX;

		private byte[] ETX;

		private byte[] ACK;

		private byte[] NAK;

		private const short NORMAL_TIMEOUT = 0;

		private const short TXN_TIMEOUT = 1;

		private const short Upload_Timeout = 2;

		public string VFI_ECRRcptNum;

		public string VFI_VoidInvoiceNo;

		public string VFI_Amount;

		public string VFI_CardNum;

		public string VFI_CHName;

		public string VFI_MessNum;

		public string VFI_Batch;

		public string VFI_ApprovalCode;

		public string VFI_RefNo;

		public string VFI_InvoiceNo;

		public string VFI_CardName;

		public string VFI_CHVerification;

		public string VFI_EMV_Label;

		public string VFI_EMV_AID;

		public string VFI_EMV_TVR;

		public string VFI_EMV_TSI;

		public string VFI_EMV_AC;

		public string VFI_AdditionalInfo;

		public string VFI_DateTime;

		public string VFI_RespCode;

		public string VFI_RespMess;

		public string VFI_MAC;

		public string VFI_TID;

		public string VFI_MID;

		public string VFI_TransType;

		public string VFI_Expiry;

		public string VFI_AuthMode;

		public string VFI_TransSource;

		public string VFI_ReportType;

		public string VFI_TelNo;

		public string VFI_DBCount;

		public string VFI_CRCount;

		public string VFI_DBAmount;

		public string VFI_CRAmount;

		public string VFI_CurrCode;

		public string VFI_EMV_CID;

		public string VFI_PTID;

		public string VFI_TIPAmount;

		public string VFI_PreauthComplAmount;

		public string VFI_OrgionalInvoiceNo;

		public string VFI_PreauthApprovalCode;

		public string VFI_CashBackAmount;

		private string VFI_TxnDateTime;

		private string VFI_TslNo;

		private string VFI_MName;

		private byte[] Tx;

		private byte[] Rx;

		private int buffLen;

		private short Ptr;

		private string Dump;

		private string Mess;

		private bool flgSysConfig;

		private bool flgLic;

		private bool flgcLic;

		private bool LicVerified;

		private bool flgDoEvents;

		private bool flgSleep;

		private bool flgTcp;

		private bool flgchkRouter;

		public string GetSet_VFI_ECRRcptNum
		{
			get
			{
				return this.VFI_ECRRcptNum;
			}
			set
			{
				this.VFI_ECRRcptNum = value;
			}
		}

		public string GetSet_VFI_Amount
		{
			get
			{
				return this.VFI_Amount;
			}
			set
			{
				this.VFI_Amount = value;
			}
		}

		public string GetSet_VFI_CardNum
		{
			get
			{
				return this.VFI_CardNum;
			}
		}

		public string GetSet_VFI_CHName
		{
			get
			{
				return this.VFI_CHName;
			}
		}

		public string GetSet_VFI_MessNum
		{
			get
			{
				return this.VFI_MessNum;
			}
			set
			{
				this.VFI_MessNum = value;
			}
		}

		public string GetSet_VFI_RespCode
		{
			get
			{
				return this.VFI_RespCode;
			}
		}

		public string GetSet_VFI_RespMess
		{
			get
			{
				return this.VFI_RespMess;
			}
		}

		public string GetSet_VFI_ApprovalCode
		{
			get
			{
				return this.VFI_ApprovalCode;
			}
		}

		public string GetSet_VFI_DateTime
		{
			get
			{
				return this.VFI_DateTime;
			}
		}

		public string GetSet_VFI_Batch
		{
			get
			{
				return this.VFI_Batch;
			}
		}

		public string GetSet_VFI_REFNO
		{
			get
			{
				return this.VFI_RefNo;
			}
		}

		public string GetSet_VFI_InvoiceNo
		{
			get
			{
				return this.VFI_InvoiceNo;
			}
			set
			{
				this.VFI_InvoiceNo = value;
			}
		}

		public string GetSet_VFI_TID
		{
			get
			{
				return this.VFI_TID;
			}
			set
			{
				this.VFI_TID = value;
			}
		}

		public string GetSet_VFI_PTID
		{
			set
			{
				this.VFI_PTID = value;
			}
		}

		public string GetSet_VFI_MID
		{
			get
			{
				return this.VFI_MID;
			}
		}

		public string GetSet_VFI_TransSource
		{
			get
			{
				return this.VFI_TransSource;
			}
		}

		public string GetSet_VFI_AuthMode
		{
			get
			{
				return this.VFI_AuthMode;
			}
		}

		public string GetSet_VFI_TransType
		{
			get
			{
				return this.VFI_TransType;
			}
			set
			{
				this.VFI_TransType = value;
			}
		}

		public string GetSet_VFI_Expiry
		{
			get
			{
				return this.VFI_Expiry;
			}
		}

		public string GetSet_VFI_CardName
		{
			get
			{
				return this.VFI_CardName;
			}
		}

		public string GetSet_VFI_CHVerification
		{
			get
			{
				return this.VFI_CHVerification;
			}
		}

		public string GetSet_VFI_EMV_Label
		{
			get
			{
				return this.VFI_EMV_Label;
			}
		}

		public string GetSet_VFI_EMV_AID
		{
			get
			{
				return this.VFI_EMV_AID;
			}
		}

		public string GetSet_VFI_EMV_TVR
		{
			get
			{
				return this.VFI_EMV_TVR;
			}
		}

		public string GetSet_VFI_EMV_TSI
		{
			get
			{
				return this.VFI_EMV_TSI;
			}
		}

		public string GetSet_VFI_EMV_AC
		{
			get
			{
				return this.VFI_EMV_AC;
			}
		}

		public string GetSet_VFI_AdditionalInfo
		{
			get
			{
				return this.VFI_AdditionalInfo;
			}
			set
			{
				this.VFI_AdditionalInfo = value;
			}
		}

		public string GetSet_VFI_VoidInvoiceNo
		{
			get
			{
				return this.VFI_VoidInvoiceNo;
			}
			set
			{
				this.VFI_VoidInvoiceNo = value;
			}
		}

		public string GetSet_VFI_DBCount
		{
			get
			{
				return this.VFI_DBCount;
			}
		}

		public string GetSet_VFI_CRCount
		{
			get
			{
				return this.VFI_CRCount;
			}
		}

		public string GetSet_VFI_DBAmount
		{
			get
			{
				return this.VFI_DBAmount;
			}
		}

		public string GetSet_VFI_CRAmount
		{
			get
			{
				return this.VFI_CRCount;
			}
		}

		public string GetSet_VFI_ReportType
		{
			get
			{
				return this.VFI_ReportType;
			}
			set
			{
				this.VFI_ReportType = value;
			}
		}

		public string GetSet_VFI_CurrCode
		{
			get
			{
				return this.VFI_CurrCode;
			}
			set
			{
				this.VFI_CurrCode = value;
			}
		}

		public string GetSet_VFI_EMV_CID
		{
			get
			{
				return this.VFI_EMV_CID;
			}
		}

		public string GetSet_VFI_TIPAmount
		{
			get
			{
				return this.VFI_TIPAmount;
			}
			set
			{
				this.VFI_TIPAmount = value;
			}
		}

		public string GetSet_VFI_PreauthComplAmount
		{
			get
			{
				return this.VFI_PreauthComplAmount;
			}
			set
			{
				this.VFI_PreauthComplAmount = value;
			}
		}

		public string GetSet_VFI_OrgionalInvoiceNo
		{
			get
			{
				return this.VFI_OrgionalInvoiceNo;
			}
			set
			{
				this.VFI_OrgionalInvoiceNo = value;
			}
		}

		public string GetSet_VFI_PreauthApprovalCode
		{
			get
			{
				return this.VFI_PreauthApprovalCode;
			}
			set
			{
				this.VFI_PreauthApprovalCode = value;
			}
		}

		public string GetSet_VFI_TelNo
		{
			get
			{
				return this.VFI_TelNo;
			}
		}

		public string GetSet_VFI_CashBackAmount
		{
			get
			{
				return this.VFI_CashBackAmount;
			}
			set
			{
				this.VFI_CashBackAmount = value;
			}
		}

		public void Install()
		{
			try
			{
				object obj = Assembly.LoadFile(Assembly.GetExecutingAssembly().Location);
				object obj2 = new RegistrationServices();
				object arg_55_0 = obj2;
				Type arg_55_1 = null;
				string arg_55_2 = "RegisterAssembly";
				object[] array = new object[]
				{
					RuntimeHelpers.GetObjectValue(obj),
					AssemblyRegistrationFlags.SetCodeBase
				};
				object[] arg_55_3 = array;
				string[] arg_55_4 = null;
				Type[] arg_55_5 = null;
				bool[] array2 = new bool[]
				{
					true,
					false
				};
				object arg_6A_0 = NewLateBinding.LateGet(arg_55_0, arg_55_1, arg_55_2, arg_55_3, arg_55_4, arg_55_5, array2);
				if (array2[0])
				{
					obj = RuntimeHelpers.GetObjectValue(array[0]);
				}
				object objectValue = RuntimeHelpers.GetObjectValue(arg_6A_0);
			}
			catch (Exception expr_72)
			{
				ProjectData.SetProjectError(expr_72);
				ProjectData.ClearProjectError();
			}
		}

		public void Uninstall()
		{
			try
			{
				object obj = Assembly.LoadFile(Assembly.GetExecutingAssembly().Location);
				object obj2 = new RegistrationServices();
				object arg_46_0 = obj2;
				Type arg_46_1 = null;
				string arg_46_2 = "UnregisterAssembly";
				object[] array = new object[]
				{
					RuntimeHelpers.GetObjectValue(obj)
				};
				object[] arg_46_3 = array;
				string[] arg_46_4 = null;
				Type[] arg_46_5 = null;
				bool[] array2 = new bool[]
				{
					true
				};
				object arg_5B_0 = NewLateBinding.LateGet(arg_46_0, arg_46_1, arg_46_2, arg_46_3, arg_46_4, arg_46_5, array2);
				if (array2[0])
				{
					obj = RuntimeHelpers.GetObjectValue(array[0]);
				}
				object objectValue = RuntimeHelpers.GetObjectValue(arg_5B_0);
			}
			catch (Exception expr_63)
			{
				ProjectData.SetProjectError(expr_63);
				ProjectData.ClearProjectError();
			}
		}

		public ComECR()
		{
			this.Serial_Port = new SerialPort();
			this.STX = new byte[]
			{
				2
			};
			this.ETX = new byte[]
			{
				3
			};
			this.ACK = new byte[]
			{
				6
			};
			this.NAK = new byte[]
			{
				21
			};
			this.Tx = new byte[2046];
			this.Rx = new byte[2046];
			this.buffLen = 2045;
			this.flgSysConfig = false;

            //this.flgLic = true;
            //this.flgcLic = true;
            //this.LicVerified = false;

            this.flgLic = false;
            this.flgcLic = false;
            this.LicVerified = true;

			this.flgDoEvents = false;
			this.flgSleep = false;
			//this.flgTcp = true;
            this.flgTcp = false;
			this.flgchkRouter = false;
			this.Trace("New");
			modMain.CreateLoadSettings();
		}

		private bool ValidateLicense(ref string strMsg)
		{
			if (!this.flgLic)
			{
				return true;
			}
			if (this.LicVerified)
			{
				return true;
			}
			try
			{
				string text = "";
				string licFile = "";
				string text2 = "";
				string text3 = "";
				string text4 = "";
				strMsg = "Error on Lic";
				this.CreatePreLicense();
				if (Directory.GetFiles(this.GetCurrPath(), "*.lic").Length <= 0)
				{
					strMsg = "License file dose not exist in the Path. " + this.GetCurrPath();
				}
				else if (Directory.GetFiles(this.GetCurrPath(), "*.lic").Length > 1)
				{
					strMsg = "More than one license file found. " + this.GetCurrPath();
				}
				else
				{
					licFile = Directory.GetFiles(this.GetCurrPath(), "*.lic")[0];
					text2 = this.GetLicFileData(licFile);
					if (Operators.CompareString(text2, "", false) != 0)
					{
						if (text2.Contains("="))
						{
							text2 = text2.Substring(Strings.InStr(text2, "=", CompareMethod.Binary));
						}
						bool flag = false;
						string text5 = "KCBECR".PadRight(8, '*');
						text4 = this.GetVolumeSerialNumber("C");
						NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
						if (allNetworkInterfaces != null)
						{
							if (allNetworkInterfaces.Length >= 1)
							{
								int arg_12B_0 = 0;
								checked
								{
									int num = allNetworkInterfaces.Length - 1;
									for (int i = arg_12B_0; i <= num; i++)
									{
										text = "";
										try
										{
											text = BitConverter.ToString(allNetworkInterfaces[i].GetPhysicalAddress().GetAddressBytes());
										}
										catch (Exception expr_14F)
										{
											ProjectData.SetProjectError(expr_14F);
											ProjectData.ClearProjectError();
										}
										if (Operators.CompareString(text, "", false) != 0)
										{
											text = text.Replace("-", "");
											text += text4;
											if (text.Length > 24)
											{
												text = text.Remove(24);
											}
											else
											{
												text = text.PadRight(24, '#');
											}
											text3 = this.INV_TripleDES(text, text2);
											if (Operators.CompareString(text3, "", false) != 0)
											{
												if (Operators.CompareString(text3.Substring(0, 8), text5, false) == 0)
												{
													flag = true;
													break;
												}
												this.Trace("Please check the license for the same appln.");
											}
										}
									}
								}
								if (flag)
								{
									if (text3.Length == 8)
									{
										bool result = true;
										return result;
									}
									if (Operators.CompareString(text3.Substring(8), "0000000000000000", false) == 0)
									{
										bool result = true;
										return result;
									}
									DateTime date;
									try
									{
										date = DateTime.ParseExact(text3.Substring(8, 8), "yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
									}
									catch (Exception arg_24D_0)
									{
										ProjectData.SetProjectError(arg_24D_0);
										this.Trace("Date Conversion error.");
										date = DateTime.ParseExact(text3.Substring(8, 8), "yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
										ProjectData.ClearProjectError();
									}
									text4 = text5 + text3.Substring(8, 8) + DateAndTime.DateDiff(DateInterval.Day, DateAndTime.Now, date, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1).ToString("00000000");
									if (DateAndTime.DateDiff(DateInterval.Day, DateAndTime.Now.AddDays(-1.0), date, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < (long)Conversions.ToInteger(text3.Substring(16)) & Conversions.ToInteger(text3.Substring(16)) > 0)
									{
										text3 = this.TripleDES(text, text4);
										if (!this.SetLicFileData(licFile, text3))
										{
											return false;
										}
										if (Conversions.ToInteger(text4.Substring(16)) <= 30 & Conversions.ToInteger(text4.Substring(16)) > 0)
										{
											MessageBox.Show("Your licence going to expiry in " + Conversions.ToString(Conversions.ToInteger(text4.Substring(16))) + " Days", "Licence Expiry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
										}
									}
									else
									{
										this.Trace("No Date diff / Expired.");
									}
									if (Conversions.ToInteger(text4.Substring(8, 8)) > Conversions.ToInteger(DateAndTime.Now.ToString("yyyyMMdd")) & Conversions.ToInteger(text4.Substring(16)) > 0)
									{
										bool result = true;
										return result;
									}
								}
							}
						}
					}
				}
			}
			catch (Exception expr_3B2)
			{
				ProjectData.SetProjectError(expr_3B2);
				Exception ex = expr_3B2;
				this.Trace("Error on License Validation:" + ex.Message);
				this.Trace("Error on License Validation:" + ex.ToString());
				ProjectData.ClearProjectError();
			}
			return false;
		}

		private bool ValidateLic(string Details)
		{
			if (this.flgLic & this.LicVerified)
			{
				return true;
			}
			if (!this.flgcLic)
			{
				return true;
			}
			try
			{
				if (Operators.CompareString(Details, "", false) == 0)
				{
					bool result = false;
					return result;
				}
				this.Createpclf(Details);
				string strData = "KCBECR".PadRight(8, '*');
				string text = this.VFI_TslNo.Replace("-", "");
				text = text.PadRight(16, 'F');
				string text2 = "Marshal ECR KCB Dubai 3436";
				text2 = this.VFI_MName + text2;
				text2 = text2.Remove(24);
				string text3 = this.Triple_DES(text, strData, text2);
				if (Operators.CompareString(text3, Details, false) == 0)
				{
					bool result = true;
					return result;
				}
				this.Createpclf(text3);
				this.Trace("Error on Load lic : Licesne (.CLF) failed");
			}
			catch (Exception expr_C7)
			{
				ProjectData.SetProjectError(expr_C7);
				Exception ex = expr_C7;
				this.Trace("Error on License Validation : " + ex.Message);
				this.Trace("Error on License Validation : " + ex.ToString());
				ProjectData.ClearProjectError();
			}
			return false;
		}

		private bool CreatePreLicense()
		{
			try
			{
				if (Directory.GetFiles(this.GetCurrPath(), "*.plic").Length >= 1)
				{
					bool result = true;
					return result;
				}
				string text = this.PhysicalAddress();
				if (Operators.CompareString(text, "", false) != 0)
				{
					text = text.Replace("-", "");
				}
				text += this.GetVolumeSerialNumber("C");
				if (Operators.CompareString(text, "", false) != 0)
				{
					if (text.Length > 24)
					{
						text = text.Remove(24);
					}
					text = text.PadRight(24, '#');
					string str = this.Triple_DES(text);
					this.SetLicFileData(this.GetCurrPath() + "\\" + MyProject.Computer.Name + ".plic", text.TrimEnd(new char[]
					{
						'#'
					}) + "=" + str);
					bool result = true;
					return result;
				}
				MessageBox.Show("Could not Retrive the pre license data, So can not create pre license file.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			catch (Exception expr_ED)
			{
				ProjectData.SetProjectError(expr_ED);
				Exception ex = expr_ED;
				this.Trace("Error on CreatePreLicense :" + ex.Message);
				this.Trace("Error on CreatePreLicense :" + ex.ToString());
				ProjectData.ClearProjectError();
			}
			return false;
		}

		private bool Createpclf(string ResultStr)
		{
			try
			{
				bool result;
				if (Directory.GetFiles(this.GetCurrPath(), "*.clf").Length >= 1)
				{
					result = true;
					return result;
				}
				this.SetLicFileData(this.GetCurrPath() + "\\" + MyProject.Computer.Name + ".clf", string.Concat(new string[]
				{
					this.VFI_TslNo,
					",",
					this.VFI_MName,
					"=",
					ResultStr
				}));
				result = true;
				return result;
			}
			catch (Exception expr_79)
			{
				ProjectData.SetProjectError(expr_79);
				Exception ex = expr_79;
				this.Trace("Error on CreatePreLicense :" + ex.Message);
				this.Trace("Error on CreatePreLicense :" + ex.ToString());
				ProjectData.ClearProjectError();
			}
			return false;
		}

		private string GetLicFileData(string LicFile)
		{
			StreamReader streamReader = null;
			try
			{
				streamReader = new StreamReader(LicFile);
				LicFile = streamReader.ReadToEnd();
				streamReader.Close();
			}
			catch (Exception expr_19)
			{
				ProjectData.SetProjectError(expr_19);
				this.Trace("Read Lic file Failed.");
				LicFile = "";
				ProjectData.ClearProjectError();
			}
			finally
			{
				if (streamReader != null)
				{
					streamReader.Dispose();
				}
			}
			return LicFile;
		}

		private bool SetLicFileData(string LicFile, string ResultStr)
		{
			StreamWriter streamWriter = null;
			bool result;
			try
			{
				streamWriter = new StreamWriter(LicFile);
				streamWriter.Write(ResultStr);
				streamWriter.Flush();
				streamWriter.Close();
				result = true;
			}
			catch (Exception expr_20)
			{
				ProjectData.SetProjectError(expr_20);
				this.Trace("Write Lic file Failed");
				result = false;
				ProjectData.ClearProjectError();
			}
			finally
			{
				if (streamWriter != null)
				{
					streamWriter.Dispose();
				}
			}
			return result;
		}

		private string PhysicalAddress()
		{
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			try
			{
				if (allNetworkInterfaces == null | allNetworkInterfaces.Length < 1)
				{
					string result = "";
					return result;
				}
				NetworkInterface[] array = allNetworkInterfaces;
				int num = 0;
				if (num < array.Length)
				{
					NetworkInterface networkInterface = array[num];
					PhysicalAddress physicalAddress = networkInterface.GetPhysicalAddress();
					byte[] addressBytes = physicalAddress.GetAddressBytes();
					string text = BitConverter.ToString(addressBytes);
					string result = text;
					return result;
				}
			}
			catch (Exception expr_50)
			{
				ProjectData.SetProjectError(expr_50);
				Exception ex = expr_50;
				this.Trace("Error on PhysicalAddress :" + ex.Message);
				this.Trace("Error on PhysicalAddress :" + ex.ToString());
				ProjectData.ClearProjectError();
			}
			return "";
		}

		private string GetVolumeSerialNumber(string driveletter)
		{
            ManagementObjectCollection.ManagementObjectEnumerator enumerator = null;
			try
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk WHERE Name = '" + driveletter + ":'");
				try
				{
					 enumerator = managementObjectSearcher.Get().GetEnumerator();
					if (enumerator.MoveNext())
					{
						ManagementObject managementObject = (ManagementObject)enumerator.Current;
						return Conversions.ToString(managementObject["VolumeSerialNumber"]);
					}
				}
				finally
				{
					 
                    if (enumerator != null)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
			}
			catch (Exception expr_5E)
			{
				ProjectData.SetProjectError(expr_5E);
				Exception ex = expr_5E;
				MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ProjectData.ClearProjectError();
			}
			return "";
		}

		private string TripleDES(string tdesKeyStr, string DataStr)
		{
			byte[] rgbIV = new byte[]
			{
				170,
				187,
				187,
				221,
				238,
				255,
				17,
				34
			};
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			ICryptoTransform cryptoTransform = null;
			byte[] array = new byte[8];
			byte[] rgbKey = new byte[24];
			byte[] inputBuffer = new byte[8];
			string text = "";
			checked
			{
				string result;
				try
				{
					if (DataStr.Length % 8 != 0)
					{
						result = "";
					}
					else if (tdesKeyStr.Length != 24)
					{
						result = "";
					}
					else
					{
						rgbKey = Encoding.ASCII.GetBytes(tdesKeyStr);
						inputBuffer = Encoding.ASCII.GetBytes(DataStr);
						int arg_C5_0 = 0;
						int num = DataStr.Length - 1;
						for (int i = arg_C5_0; i <= num; i += 8)
						{
							array = new byte[8];
							cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV);
							cryptoTransform.TransformBlock(inputBuffer, i, 8, array, 0);
							text += BitConverter.ToString(array).Replace("-", "");
						}
						result = text;
					}
				}
				catch (Exception expr_118)
				{
					ProjectData.SetProjectError(expr_118);
					Exception ex = expr_118;
					this.Trace("TripleDES Error : " + ex.Message);
					result = "";
					ProjectData.ClearProjectError();
				}
				finally
				{
					if (cryptoTransform != null)
					{
						cryptoTransform.Dispose();
					}
					tripleDESCryptoServiceProvider.Clear();
				}
				return result;
			}
		}

		private string INV_TripleDES(string TdesKeyStr, string DataStr)
		{
			byte[] rgbIV = new byte[]
			{
				170,
				187,
				187,
				221,
				238,
				255,
				17,
				34
			};
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			ICryptoTransform cryptoTransform = null;
			byte[] array = new byte[8];
			byte[] array2 = new byte[16];
			byte[] array3 = new byte[8];
			byte[] rgbKey = new byte[24];
			string text = "";
			checked
			{
				string result;
				try
				{
					if (DataStr.Length % 8 != 0)
					{
						result = "";
					}
					else if (TdesKeyStr.Length != 24)
					{
						result = "";
					}
					else
					{
						array3 = this.ByteStrToByte(DataStr);
						rgbKey = Encoding.ASCII.GetBytes(TdesKeyStr);
						int arg_C6_0 = 0;
						int num = array3.Length - 1;
						for (int i = arg_C6_0; i <= num; i += 8)
						{
							array = new byte[8];
							array2 = new byte[16];
							Array.Copy(array3, i, array2, 0, 8);
							cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor(rgbKey, rgbIV);
							cryptoTransform.TransformBlock(array2, 0, 16, array, 0);
							text += Encoding.ASCII.GetString(array);
						}
						result = text;
					}
				}
				catch (Exception expr_127)
				{
					ProjectData.SetProjectError(expr_127);
					Exception ex = expr_127;
					this.Trace("INV_TripleDES Error : " + ex.Message);
					result = null;
					ProjectData.ClearProjectError();
				}
				finally
				{
					if (cryptoTransform != null)
					{
						cryptoTransform.Dispose();
					}
					tripleDESCryptoServiceProvider.Clear();
				}
				return result;
			}
		}

		private byte[] TripleDES_(string DataStr)
		{
			byte[] rgbKey = new byte[]
			{
				214,196,0,147,63,199,236,21,179,7,134,124,94,129,68,115,214,196,0,147,63,199,236,21
			};
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			ICryptoTransform cryptoTransform = null;
			byte[] rgbIV = new byte[8];
			byte[] array = new byte[8];
			byte[] array2 = new byte[8];
			checked
			{
				byte[] result;
				try
				{
					short num = (short)DataStr.Length;
					if (num % 8 != 0)
					{
						num += (short)(8 - num % 8);
					}
					array = new byte[(int)(num - 1 + 1)];
					int arg_124_0 = 0;
					int num2 = DataStr.Length - 1;
					for (int i = arg_124_0; i <= num2; i += 8)
					{
						array2 = new byte[8];
						num = (short)(DataStr.Length - i);
						if (num > 8)
						{
							num = 8;
						}
						Encoding.ASCII.GetBytes(DataStr, i, (int)num, array2, 0);
						cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV);
						cryptoTransform.TransformBlock(array2, 0, 8, array, i);
					}
					result = array;
				}
				catch (Exception expr_17C)
				{
					ProjectData.SetProjectError(expr_17C);
					Exception ex = expr_17C;
					this.Trace("TripleDES_ Error : " + ex.Message);
					result = array;
					ProjectData.ClearProjectError();
				}
				finally
				{
					if (cryptoTransform != null)
					{
						cryptoTransform.Dispose();
					}
					tripleDESCryptoServiceProvider.Clear();
				}
				return result;
			}
		}

		private string TripleDES(string StrIV, string strData, byte[] Key)
		{
			byte[] array = new byte[24];
			byte[] array2 = new byte[8];
			byte[] array3 = new byte[8];
			string text = "";
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			ICryptoTransform cryptoTransform = null;
			checked
			{
				string result;
				try
				{
					if (strData.Length != 8)
					{
						result = text;
					}
					else if (StrIV.Length != 8)
					{
						result = text;
					}
					else
					{
						byte[] bytes = Encoding.ASCII.GetBytes(StrIV);
						int num = strData.Length;
						if (num % 8 != 0)
						{
							num += 8 - num % 8;
						}
						array3 = new byte[num - 1 + 1];
						Encoding.ASCII.GetBytes(strData, 0, strData.Length, array3, 0);
						num = Key.Length;
						if (num >= 24)
						{
							Array.Copy(Key, 0, array, 0, 24);
						}
						else if (num > 16 & num < 24)
						{
							Array.Copy(Key, 0, array, 0, Key.Length);
						}
						else if (num <= 16 & num > 8)
						{
							Array.Copy(Key, 0, array, 0, Key.Length);
							Array.Copy(Key, 0, array, 16, 8);
						}
						else
						{
							if (num <= 8 & num > 0)
							{
								DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
								array = new byte[8];
								Array.Copy(Key, 0, array, 0, Key.Length);
								int arg_132_0 = 0;
								int num2 = array3.Length - 1;
								for (int i = arg_132_0; i <= num2; i += 8)
								{
									array2 = new byte[8];
									dESCryptoServiceProvider.CreateEncryptor(array, bytes).TransformBlock(array3, i, 8, array2, 0);
									text += BitConverter.ToString(array2).Replace("-", "");
								}
								result = text;
								return result;
							}
							result = text;
							return result;
						}
						int arg_197_0 = 0;
						int num3 = array3.Length - 1;
						for (int j = arg_197_0; j <= num3; j += 8)
						{
							array2 = new byte[8];
							cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor(array, bytes);
							cryptoTransform.TransformBlock(array3, j, 8, array2, 0);
							text += BitConverter.ToString(array2).Replace("-", "");
						}
						result = text;
					}
				}
				catch (Exception expr_1EA)
				{
					ProjectData.SetProjectError(expr_1EA);
					Exception ex = expr_1EA;
					this.Trace("TripleDES Error : " + ex.Message);
					result = text;
					ProjectData.ClearProjectError();
				}
				finally
				{
					if (cryptoTransform != null)
					{
						cryptoTransform.Dispose();
					}
					tripleDESCryptoServiceProvider.Clear();
				}
				return result;
			}
		}

		private string Triple_DES(string DataStr)
		{
			byte[] rgbIV = new byte[]
			{
				170,
				187,
				187,
				221,
				238,
				255,
				17,
				34
			};
			byte[] rgbKey = new byte[]
			{
				17,
				34,
				51,
				68,
				85,
				102,
				119,
				136,
				153,
				0,
				170,
				187,
				187,
				221,
				238,
				255,
				161,
				178,
				195,
				212,
				229,
				246,
				171,
				205
			};
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			ICryptoTransform cryptoTransform = null;
			byte[] array = new byte[8];
			byte[] inputBuffer = new byte[8];
			string text = "";
			checked
			{
				string result;
				try
				{
					if (DataStr.Length % 8 != 0)
					{
						result = "";
					}
					else
					{
						inputBuffer = Encoding.ASCII.GetBytes(DataStr);
						int arg_174_0 = 0;
						int num = DataStr.Length - 1;
						for (int i = arg_174_0; i <= num; i += 8)
						{
							array = new byte[8];
							cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV);
							cryptoTransform.TransformBlock(inputBuffer, i, 8, array, 0);
							text += BitConverter.ToString(array).Replace("-", "");
						}
						result = text;
					}
				}
				catch (Exception expr_1C7)
				{
					ProjectData.SetProjectError(expr_1C7);
					Exception ex = expr_1C7;
					Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
					result = "";
					ProjectData.ClearProjectError();
				}
				finally
				{
					if (cryptoTransform != null)
					{
						cryptoTransform.Dispose();
					}
					tripleDESCryptoServiceProvider.Clear();
				}
				return result;
			}
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

		private string TripleDESBCD(string BCDDataStr)
		{
			byte[] rgbKey = new byte[]
			{
				18,
				52,
				86,
				120,
				144,
				171,
				205,
				239,
				171,
				205,
				239,
				18,
				52,
				86,
				120,
				144,
				18,
				52,
				86,
				120,
				144,
				171,
				205,
				239
			};
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			ICryptoTransform cryptoTransform = null;
			byte[] rgbIV = new byte[8];
			byte[] array = new byte[8];
			byte[] inputBuffer = new byte[8];
			string text = "";
			string result;
			try
			{
				if (BCDDataStr.Length % 8 != 0)
				{
					result = "";
				}
				else
				{
					inputBuffer = this.ByteStrToByte(BCDDataStr);
					cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV);
					cryptoTransform.TransformBlock(inputBuffer, 0, 8, array, 0);
					text += BitConverter.ToString(array).Replace("-", "");
					result = text;
				}
			}
			catch (Exception expr_14F)
			{
				ProjectData.SetProjectError(expr_14F);
				Exception ex = expr_14F;
				this.Trace("TripleDESBCD Error : " + ex.Message);
				result = "";
				ProjectData.ClearProjectError();
			}
			finally
			{
				if (cryptoTransform != null)
				{
					cryptoTransform.Dispose();
				}
				tripleDESCryptoServiceProvider.Clear();
			}
			return result;
		}

		private string INV_TripleDES(string DataStr)
		{
			byte[] rgbIV = new byte[8];
			byte[] rgbKey = new byte[]
			{
				18,
				52,
				86,
				120,
				144,
				171,
				205,
				239,
				171,
				205,
				239,
				18,
				52,
				86,
				120,
				144,
				18,
				52,
				86,
				120,
				144,
				171,
				205,
				239
			};
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			ICryptoTransform cryptoTransform = null;
			byte[] array = new byte[8];
			byte[] array2 = new byte[16];
			byte[] array3 = new byte[8];
			string text = "";
			checked
			{
				string result;
				try
				{
					if (DataStr.Length % 8 != 0)
					{
						result = "";
					}
					else
					{
						array3 = this.ByteStrToByte(DataStr);
						int arg_125_0 = 0;
						int num = array3.Length - 1;
						for (int i = arg_125_0; i <= num; i += 8)
						{
							array = new byte[8];
							array2 = new byte[16];
							Array.Copy(array3, i, array2, 0, 8);
							cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor(rgbKey, rgbIV);
							cryptoTransform.TransformBlock(array2, 0, 16, array, 0);
							text += BitConverter.ToString(array).Replace("-", "");
						}
						result = text;
					}
				}
				catch (Exception expr_190)
				{
					ProjectData.SetProjectError(expr_190);
					Exception ex = expr_190;
					this.Trace("INV_TripleDES Error : " + ex.Message);
					result = null;
					ProjectData.ClearProjectError();
				}
				finally
				{
					if (cryptoTransform != null)
					{
						cryptoTransform.Dispose();
					}
					tripleDESCryptoServiceProvider.Clear();
				}
				return result;
			}
		}

		private string TripleDES(string StrIV, string strData, string strKey)
		{
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			ICryptoTransform cryptoTransform = null;
			byte[] array = new byte[8];
			byte[] array2 = new byte[8];
			string text = "";
			checked
			{
				string result;
				try
				{
					if (strData.Length % 8 != 0)
					{
						result = "";
					}
					else if (StrIV.Length % 8 != 0)
					{
						result = "";
					}
					else if (strKey.Length % 8 != 0)
					{
						result = "";
					}
					else
					{
						if (strKey.Length == 16)
						{
							strKey += strKey.Substring(0, 8);
						}
						byte[] bytes = Encoding.ASCII.GetBytes(StrIV);
						array2 = Encoding.ASCII.GetBytes(strData);
						byte[] bytes2 = Encoding.ASCII.GetBytes(strKey);
						int arg_AA_0 = 0;
						int num = array2.Length - 1;
						for (int i = arg_AA_0; i <= num; i += 8)
						{
							array = new byte[8];
							cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor(bytes2, bytes);
							cryptoTransform.TransformBlock(array2, i, 8, array, 0);
							text += BitConverter.ToString(array).Replace("-", "");
						}
						result = text;
					}
				}
				catch (Exception expr_FD)
				{
					ProjectData.SetProjectError(expr_FD);
					Exception ex = expr_FD;
					this.Trace("TripleDES Error : " + ex.Message);
					result = "";
					ProjectData.ClearProjectError();
				}
				finally
				{
					if (cryptoTransform != null)
					{
						cryptoTransform.Dispose();
					}
					tripleDESCryptoServiceProvider.Clear();
				}
				return result;
			}
		}

		private string TripleDES(string DataStr)
		{
			byte[] rgbKey = new byte[]
			{
				18,
				52,
				86,
				120,
				144,
				171,
				205,
				239,
				171,
				205,
				239,
				18,
				52,
				86,
				120,
				144,
				18,
				52,
				86,
				120,
				144,
				171,
				205,
				239
			};
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			ICryptoTransform cryptoTransform = null;
			byte[] rgbIV = new byte[8];
			byte[] array = new byte[8];
			byte[] array2 = new byte[8];
			string text = "";
			checked
			{
				string result;
				try
				{
					short num = (short)DataStr.Length;
					if (num % 8 != 0)
					{
						num += (short)(8 - num % 8);
					}
					array = new byte[(int)(num + 1)];
					int arg_122_0 = 0;
					int num2 = DataStr.Length - 1;
					for (int i = arg_122_0; i <= num2; i += 8)
					{
						array = new byte[8];
						array2 = new byte[8];
						num = (short)(DataStr.Length - i);
						if (num > 8)
						{
							num = 8;
						}
						Encoding.ASCII.GetBytes(DataStr, i, (int)num, array2, 0);
						cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV);
						cryptoTransform.TransformBlock(array2, 0, 8, array, i);
					}
					text += BitConverter.ToString(array).Replace("-", "");
					result = text;
				}
				catch (Exception expr_1A1)
				{
					ProjectData.SetProjectError(expr_1A1);
					Exception ex = expr_1A1;
					this.Trace("TripleDES Error : " + ex.Message);
					result = "";
					ProjectData.ClearProjectError();
				}
				finally
				{
					if (cryptoTransform != null)
					{
						cryptoTransform.Dispose();
					}
					tripleDESCryptoServiceProvider.Clear();
				}
				return result;
			}
		}

		private bool VerifyMAC(string MacData, string Mac)
		{
			bool result;
			try
			{
				MacData = MacData.Trim();
				if (MacData.Length > 8)
				{
					MacData = MacData.Remove(8);
				}
				else
				{
					MacData = MacData.PadLeft(8, '0');
				}
				if (Operators.CompareString(this.TripleDES(MacData), Mac.Trim(), false) != 0)
				{
					this.Trace("MAC Verification Failed.");
					this.ClearData();
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch (Exception expr_57)
			{
				ProjectData.SetProjectError(expr_57);
				Exception ex = expr_57;
				this.Trace("MAC Verify Error: " + ex.Message);
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private string Triple_DES(string StrIV, string strData, string strKey)
		{
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			ICryptoTransform cryptoTransform = null;
			byte[] array = new byte[8];
			byte[] array2 = new byte[8];
			string text = "";
			try
			{
				if (strData.Length % 8 != 0)
				{
					string result = "";
					return result;
				}
				if (StrIV.Length % 8 != 0)
				{
					string result = "";
					return result;
				}
				if (strKey.Length % 8 != 0)
				{
					string result = "";
					return result;
				}
				if (strKey.Length == 16)
				{
					strKey += strKey.Substring(0, 8);
				}
				byte[] rgbIV = this.ByteStrToByte(StrIV);
				array2 = Encoding.ASCII.GetBytes(strData);
				byte[] bytes = Encoding.ASCII.GetBytes(strKey);
				array = new byte[checked(array2.Length - 1 + 1)];
				cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor(bytes, rgbIV);
				cryptoTransform.TransformBlock(array2, 0, array2.Length, array, 0);
				text += BitConverter.ToString(array).Replace("-", "");
				text = text.Substring(0, 4) + text.Substring(12, 4);
			}
			catch (Exception expr_FE)
			{
				ProjectData.SetProjectError(expr_FE);
				Exception ex = expr_FE;
				this.Trace("TripleDES Error : " + ex.Message);
				text = "";
				ProjectData.ClearProjectError();
			}
			finally
			{
				if (cryptoTransform != null)
				{
					cryptoTransform.Dispose();
				}
				tripleDESCryptoServiceProvider.Clear();
			}
			return text;
		}

		public bool VFI_LoadSetting()
		{
			bool result;
			try
			{
				if (!this.LoadSettings())
				{
					this.VFI_RespCode = "99";
					this.VFI_RespMess = "Error on Load settings.";
					this.Trace("Error on Load Setting " + this.VFI_RespMess);
					result = false;
				}
				else
				{
					this.VFI_RespCode = "00";
					this.VFI_RespMess = "Successfully Proessed !!!";
					this.Trace("Load Setting " + this.VFI_RespMess);
					result = true;
				}
			}
			catch (Exception expr_6A)
			{
				ProjectData.SetProjectError(expr_6A);
				Exception ex = expr_6A;
				this.VFI_RespCode = "99";
				this.VFI_RespMess = ex.Message;
				this.Trace("Load setting Err :" + ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public bool VFI_LoadSetting(ref string RespCode, ref string RespMess)
		{
			bool result;
			try
			{
				if (!this.LoadSettings())
				{
					RespCode = "99";
					RespMess = "Error on Load settings.";
					this.Trace("Error on Load Setting " + RespMess);
					result = false;
				}
				else
				{
					RespCode = "00";
					RespMess = "Successfully Proessed !!!";
					this.Trace("Load Setting " + RespMess);
					result = true;
				}
			}
			catch (Exception expr_52)
			{
				ProjectData.SetProjectError(expr_52);
				Exception ex = expr_52;
				RespCode = "99";
				RespMess = ex.Message;
				this.Trace("Load setting Err :" + ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

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

		private string GetLicData()
		{
			string text = "";
			if (!this.flgLic)
			{
				return text;
			}
			try
			{
				if (Directory.GetFiles(this.GetCurrPath(), "*.lic").Length <= 0)
				{
					MessageBox.Show("License file dose not exist.", "License file error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else if (Directory.GetFiles(this.GetCurrPath(), "*.lic").Length > 1)
				{
					MessageBox.Show("More than one license file found.", "License file error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					text = Directory.GetFiles(this.GetCurrPath(), "*.lic")[0];
					text = this.GetLicFileData(text);
					if (Operators.CompareString(text, "", false) != 0)
					{
						if (text.Contains("="))
						{
							text = text.Substring(Strings.InStr(text, "=", CompareMethod.Binary));
						}
					}
				}
			}
			catch (Exception expr_B5)
			{
				ProjectData.SetProjectError(expr_B5);
				this.Trace("Read Lic file Failed.");
				ProjectData.ClearProjectError();
			}
			return text;
		}

		public bool VFI_DoSetup()
		{
			bool result;
			try
			{
				modMain.CreateLoadSettings();
				frmDosetup frmDosetup = new frmDosetup();
				frmDosetup.ShowDialog();
				this.VFI_RespCode = "00";
				this.VFI_RespMess = "Successfully Proessed !!!";
				this.Trace("Do Setup " + this.VFI_RespMess);
				result = true;
			}
			catch (Exception expr_43)
			{
				ProjectData.SetProjectError(expr_43);
				Exception ex = expr_43;
				this.VFI_RespCode = "99";
				this.VFI_RespMess = ex.Message;
				this.Trace("Do Setup Err :" + ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public bool VFI_DoSetup(ref string RespCode, ref string RespMess)
		{
			bool result;
			try
			{
				this.VFI_DoSetup();
				RespCode = this.VFI_RespCode;
				RespMess = this.VFI_RespMess;
				result = true;
			}
			catch (Exception expr_1B)
			{
				ProjectData.SetProjectError(expr_1B);
				Exception ex = expr_1B;
				RespCode = "99";
				RespMess = ex.Message;
				this.Trace("Do Setup Err :" + ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public bool VFI_InitializeAll()
		{
			bool result;
			try
			{
				this.Trace("VFI_InitializeAll Starts.");
				this.VFI_ECRRcptNum = "";
				this.VFI_TransType = "";
				this.VFI_Amount = "";
				this.VFI_CardNum = "";
				this.VFI_Expiry = "";
				this.VFI_CHName = "";
				this.VFI_MessNum = "";
				this.VFI_TransSource = "";
				this.VFI_AuthMode = "";
				this.VFI_RespCode = "";
				this.VFI_RespMess = "";
				this.VFI_ApprovalCode = "";
				this.VFI_DateTime = "";
				this.VFI_TID = "";
				this.VFI_MID = "";
				this.VFI_Batch = "";
				this.VFI_MAC = "";
				this.VFI_RespCode = "00";
				this.VFI_RespMess = "Successfully Proessed !!!";
				this.Trace("VFI_InitializeAll :" + this.VFI_RespMess);
				result = true;
			}
			catch (Exception expr_F8)
			{
				ProjectData.SetProjectError(expr_F8);
				Exception ex = expr_F8;
				this.VFI_RespCode = "99";
				this.VFI_RespMess = ex.Message;
				this.Trace("VFI_InitializeAll Err:" + ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private void ClearData()
		{
			try
			{
				this.VFI_ECRRcptNum = "";
				this.VFI_TransType = "";
				this.VFI_Amount = "";
				this.VFI_CardNum = "";
				this.VFI_Expiry = "";
				this.VFI_CHName = "";
				this.VFI_MessNum = "";
				this.VFI_TransSource = "";
				this.VFI_AuthMode = "";
				this.VFI_RespCode = "";
				this.VFI_RespMess = "";
				this.VFI_ApprovalCode = "";
				this.VFI_DateTime = "";
				this.VFI_RefNo = "";
				this.VFI_TID = "";
				this.VFI_MID = "";
				this.VFI_Batch = "";
				this.VFI_MAC = "";
			}
			catch (Exception expr_C8)
			{
				ProjectData.SetProjectError(expr_C8);
				Exception ex = expr_C8;
				this.Trace("Clear data Err:" + ex.ToString());
				ProjectData.ClearProjectError();
			}
		}

		public string VFI_DllVersion()
		{
			string result = "";
			try
			{
				result = "ECR-POS Communication with Router application for KCB 1.1.1.12";
				result = "ECR-POS Communication with Router application for KCB " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
			catch (Exception expr_2D)
			{
				ProjectData.SetProjectError(expr_2D);
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public string VFI_AboutDll()
		{
			string result = "";
			try
			{
				result = this.VFI_AboutDll();
			}
			catch (Exception expr_0F)
			{
				ProjectData.SetProjectError(expr_0F);
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public bool VFI_GetAuth()
		{
			bool result;
			try
			{
				if (this.flgTcp)
				{
					result = this.TCP_GetAuth();
				}
				else
				{
					result = this.COM_GetAuth();
				}
			}
			catch (Exception expr_1A)
			{
				ProjectData.SetProjectError(expr_1A);
				Exception ex = expr_1A;
				this.VFI_RespCode = "99";
				this.VFI_RespMess = ex.Message;
				this.Trace("VFI_GetAuth Err:" + ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public bool VFI_VoidTrans()
		{
			bool result;
			try
			{
				if (this.flgTcp)
				{
					result = this.TCP_VoidTrans();
				}
				else
				{
					result = this.COM_VoidTrans();
				}
			}
			catch (Exception expr_1A)
			{
				ProjectData.SetProjectError(expr_1A);
				Exception ex = expr_1A;
				this.VFI_RespCode = "99";
				this.VFI_RespMess = ex.Message;
				this.Trace("VFI_VoidTrans Err:" + ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public bool VFI_Settle()
		{
			bool result;
			try
			{
				if (this.flgTcp)
				{
					result = this.TCP_Settle();
				}
				else
				{
					result = this.COM_Settle();
				}
			}
			catch (Exception expr_1A)
			{
				ProjectData.SetProjectError(expr_1A);
				Exception ex = expr_1A;
				this.VFI_RespCode = "99";
				this.VFI_RespMess = ex.Message;
				this.Trace("VFI_Settle :" + ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public bool VFI_Report()
		{
			bool result;
			try
			{
				if (this.flgTcp)
				{
					result = this.TCP_Report();
				}
				else
				{
					result = this.COM_Report();
				}
			}
			catch (Exception expr_1A)
			{
				ProjectData.SetProjectError(expr_1A);
				Exception ex = expr_1A;
				this.VFI_RespCode = "99";
				this.VFI_RespMess = ex.Message;
				this.Trace("VFI_Report :" + ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public bool VFI_GetTelNo()
		{
			bool result;
			try
			{
				if (this.flgTcp)
				{
					result = this.TCP_GetTelNo();
				}
				else
				{
					result = this.COM_GetTelNo();
				}
			}
			catch (Exception expr_1A)
			{
				ProjectData.SetProjectError(expr_1A);
				Exception ex = expr_1A;
				this.VFI_RespCode = "99";
				this.VFI_RespMess = ex.Message;
				this.Trace("VFI_Report :" + ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private bool COM_GetAuth()
		{
			bool flag = true;
			string text = "02";
			string left = "";
			checked
			{
				bool result;
				try
				{
					this.Trace("VFI_GetAuth starts.");
					this.VFI_RespCode = "99";
					if (!this.ValidateLicense(ref this.VFI_RespMess))
					{
						this.VFI_RespCode = "91";
						if (Operators.CompareString(this.VFI_RespMess, "", false) == 0)
						{
							this.VFI_RespMess = "Error on Load lic";
						}
						this.Trace("Error on Load lic " + this.VFI_RespMess);
						if (!this.flgcLic)
						{
							result = false;
							return result;
						}
					}
					else if (this.flgLic)
					{
						this.LicVerified = true;
					}
					this.VFI_RespMess = "System Error";
					if (this.LoadSettings())
					{
						this.flgSysConfig = true;
						if (Operators.CompareString(this.VFI_TransType, "", false) == 0)
						{
							this.VFI_TransType = "01";
						}
						this.VFI_TransType = this.VFI_TransType.TrimEnd(new char[]
						{
							'0'
						});
						this.VFI_TransType = this.VFI_TransType.Trim();
						if (this.VFI_TransType.Length <= 0)
						{
							this.VFI_TransType = "01";
						}
						if (Conversions.ToInteger(this.VFI_TransType) < 1 | Conversions.ToInteger(this.VFI_TransType) > 7)
						{
							this.VFI_RespCode = "71";
							this.VFI_RespMess = "Invalid Txn Type";
							this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
							result = false;
						}
						else
						{
							this.VFI_TID = this.VFI_PTID;
							if (Operators.CompareString(this.VFI_TID, "", false) == 0)
							{
								this.VFI_TID = "00";
							}
							this.VFI_TID = this.VFI_TID.Trim();
							if (this.VFI_TID.Length <= 0)
							{
								this.VFI_TID = "00";
							}
							if (this.VFI_TID.Length <= 0)
							{
								this.VFI_RespCode = "72";
								this.VFI_RespMess = "Terminal Number Missing";
								this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
								result = false;
							}
							else
							{
								if (this.VFI_TID.Length > 8)
								{
									this.VFI_TID = this.VFI_TID.Remove(8);
								}
								else
								{
									this.VFI_TID = this.VFI_TID.PadLeft(8, '0');
								}
								if (Operators.CompareString(this.VFI_Amount, "", false) == 0)
								{
									this.VFI_Amount = "00";
								}
								this.VFI_Amount = this.VFI_Amount.Trim();
								if (this.VFI_Amount.Length <= 0)
								{
									this.VFI_Amount = "00";
								}
								if (Conversions.ToLong(this.VFI_Amount) <= 0L)
								{
									this.VFI_RespCode = "73";
									this.VFI_RespMess = "Zero Amount not allowed";
									this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
									result = false;
								}
								else
								{
									if (Operators.CompareString(this.VFI_ECRRcptNum, "", false) == 0)
									{
										this.VFI_ECRRcptNum = "00";
									}
									this.VFI_ECRRcptNum = this.VFI_ECRRcptNum.Trim();
									if (this.VFI_ECRRcptNum.Length <= 0)
									{
										this.VFI_ECRRcptNum = "00";
									}
									if (Conversions.ToLong(this.VFI_ECRRcptNum) <= 0L)
									{
										this.VFI_RespCode = "74";
										this.VFI_RespMess = "ECR Receipt Number is must";
										this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
										result = false;
									}
									else
									{
										string text2 = "0";
										if (Conversions.ToInteger(this.VFI_TransType) == 4)
										{
											if (Operators.CompareString(this.VFI_PreauthComplAmount, "", false) == 0)
											{
												this.VFI_PreauthComplAmount = "0";
											}
											text2 = this.VFI_PreauthComplAmount;
										}
										else if (Conversions.ToInteger(this.VFI_TransType) == 6)
										{
											if (Operators.CompareString(this.VFI_TIPAmount, "", false) == 0)
											{
												this.VFI_TIPAmount = "0";
											}
											text2 = this.VFI_TIPAmount;
										}
										else if (Conversions.ToInteger(this.VFI_TransType) == 8)
										{
											if (Operators.CompareString(this.VFI_CashBackAmount, "", false) == 0)
											{
												this.VFI_CashBackAmount = "0";
											}
											text2 = this.VFI_CashBackAmount;
										}
										if (Operators.CompareString(this.VFI_OrgionalInvoiceNo, "", false) == 0)
										{
											this.VFI_OrgionalInvoiceNo = "00";
										}
										if (Conversions.ToInteger(this.VFI_TransType) == 4 | Conversions.ToInteger(this.VFI_TransType) == 6)
										{
											text2 = text2.Trim();
											if (text2.Length <= 0)
											{
												text2 = "00";
											}
											if (Conversions.ToInteger(text2) < Conversions.ToInteger(Interaction.IIf(Conversions.ToInteger(this.VFI_TransType) == 4, 1, 0)))
											{
												this.VFI_RespCode = "99";
												this.VFI_RespMess = "Zero Amount not allowed for Txn Completion";
												this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
												result = false;
												return result;
											}
											this.VFI_OrgionalInvoiceNo = this.VFI_OrgionalInvoiceNo.Trim();
											if (this.VFI_OrgionalInvoiceNo.Length <= 0)
											{
												this.VFI_OrgionalInvoiceNo = "00";
											}
											if (Conversions.ToInteger(this.VFI_OrgionalInvoiceNo) <= 0)
											{
												this.VFI_RespCode = "99";
												this.VFI_RespMess = "Orgional Invoice Number is must";
												this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
												result = false;
												return result;
											}
										}
										this.Serial_Port = new SerialPort();
										if (!this.Open_Port(ref this.Serial_Port, modMain.Settings.PortName, modMain.Settings.BaudRate))
										{
											this.VFI_RespCode = "93";
											this.VFI_RespMess = "Port Error";
											this.Trace("VFI_GetAuth Connect Error.");
											flag = false;
										}
										else
										{
											this.VFI_TxnDateTime = DateAndTime.Now.ToString("MMddHHmm");
											if (!this.VFI_InitTxn(ref this.Serial_Port, ref this.VFI_RespCode, ref this.VFI_RespMess))
											{
												flag = false;
											}
											else
											{
												if (modMain.Settings.Delay)
												{
													int millisecondsTimeout = modMain.Settings.DelayTimeout * 1000;
													Thread.Sleep(millisecondsTimeout);
													Application.DoEvents();
												}
												string text3 = this.CalculateMAC();
												this.Ptr = 0;
												this.Tx[(int)this.Ptr] = this.STX[0];
												this.Ptr += 1;
												this.Dump = string.Concat(new string[]
												{
													text,
													",",
													this.VFI_TransType,
													",",
													this.VFI_ECRRcptNum,
													",",
													this.VFI_Amount,
													",",
													this.VFI_TID,
													",",
													text2,
													",",
													this.VFI_OrgionalInvoiceNo,
													",",
													text3.Substring(0, 8),
													",",
													this.VFI_CurrCode,
													",",
													this.VFI_PreauthApprovalCode,
													","
												});
												if (this.Tx.Length <= this.Dump.Length + 3)
												{
													this.Tx = (byte[])Utils.CopyArray((Array)this.Tx, new byte[this.Dump.Length + 3 + 1]);
												}
												Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
												this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
												this.Tx[(int)this.Ptr] = this.ETX[0];
												this.Ptr += 1;
												this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
												this.Ptr += 1;
												if (!this.ExchangePkt(ref this.Serial_Port, this.Tx, this.Ptr))
												{
													this.Trace("VFI_GetAuth Exchange pos error.");
													this.VFI_RespCode = "92";
													this.VFI_RespMess = "Send Error";
													flag = false;
												}
												else
												{
													DateTime dateTime = DateAndTime.Now.AddSeconds((double)modMain.Settings.TxnTimeout);
													while (true)
													{
														short num = this.RxBlock(ref this.Serial_Port, ref this.Rx, ref dateTime, ref this.VFI_RespMess, text);
														if (this.VFI_RespMess.Length <= 0)
														{
															this.VFI_RespMess = "No Response / Timeout ";
														}
														if (num == 0)
														{
															this.Trace("VFI_GetAuth Err Rx :" + this.VFI_RespMess);
															if (!modMain.Settings.flgWaitRes)
															{
																goto IL_8E2;
															}
															this.Mess = this.VFI_RespMess + "\r\nAre you want to wait for response?";
															if (MessageBox.Show(this.Mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
															{
																break;
															}
														}
														if (!this.ProcessBlock(this.Rx, (int)num, ref left))
														{
															goto Block_42;
														}
														if (Operators.CompareString(left, "06", false) != 0)
														{
															goto IL_91C;
														}
													}
													flag = false;
													goto IL_945;
													IL_8E2:
													flag = false;
													goto IL_945;
													Block_42:
													this.Trace("VFI_GetAuth disconnect Error.");
													flag = false;
													goto IL_945;
													IL_91C:
													if (Conversions.ToInteger(this.VFI_RespCode) == 0)
													{
														flag = true;
													}
													if (this.VFI_RespMess.Length <= 0)
													{
														this.VFI_RespMess = "No Response / Timeout ";
													}
												}
											}
										}
										IL_945:
										if (!this.Close_Port(ref this.Serial_Port))
										{
											this.Trace("VFI_GetAuth disconnect Error.");
											result = false;
										}
										else
										{
											this.Trace("VFI_GetAuth success.");
											result = flag;
										}
									}
								}
							}
						}
					}
					else
					{
						this.VFI_RespCode = "92";
						this.VFI_RespMess = "Error on Load settings";
						this.Trace("Error on Load Setting " + this.VFI_RespMess);
						result = false;
					}
				}
				catch (Exception expr_973)
				{
					ProjectData.SetProjectError(expr_973);
					Exception ex = expr_973;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("VFI_GetAuth Err:" + ex.ToString());
					result = false;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private bool COM_VoidTrans()
		{
			bool flag = true;
			string text = "03";
			string left = "";
			checked
			{
				bool result;
				try
				{
					this.Trace("VFI_VoidTrans starts.");
					this.VFI_RespCode = "99";
					if (!this.ValidateLicense(ref this.VFI_RespMess))
					{
						this.VFI_RespCode = "91";
						if (Operators.CompareString(this.VFI_RespMess, "", false) == 0)
						{
							this.VFI_RespMess = "Error on Load lic";
						}
						this.Trace("Error on Load lic " + this.VFI_RespMess);
						if (!this.flgcLic)
						{
							result = false;
							return result;
						}
					}
					else if (this.flgLic)
					{
						this.LicVerified = true;
					}
					this.VFI_RespMess = "System Error";
					if (this.LoadSettings())
					{
						this.flgSysConfig = true;
						this.VFI_TID = this.VFI_PTID;
						if (Operators.CompareString(this.VFI_TID, "", false) == 0)
						{
							this.VFI_TID = "00";
						}
						this.VFI_TID = this.VFI_TID.Trim();
						if (this.VFI_TID.Length <= 0)
						{
							this.VFI_TID = "00";
						}
						if (this.VFI_TID.Length <= 0)
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = "Terminal Number Missing";
							this.Trace("VFI_VoidTrans Err :" + this.VFI_RespMess);
							result = false;
						}
						else
						{
							if (this.VFI_TID.Length > 8)
							{
								this.VFI_TID = this.VFI_TID.Remove(8);
							}
							else
							{
								this.VFI_TID = this.VFI_TID.PadLeft(8, '0');
							}
							if (Operators.CompareString(this.VFI_Amount, "", false) == 0)
							{
								this.VFI_Amount = "00";
							}
							this.VFI_Amount = this.VFI_Amount.Trim();
							if (this.VFI_Amount.Length <= 0)
							{
								this.VFI_Amount = "00";
							}
							if (Conversions.ToLong(this.VFI_Amount) <= 0L)
							{
								this.VFI_RespCode = "99";
								this.VFI_RespMess = "Zero Amount not allowed";
								this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
								result = false;
							}
							else
							{
								if (Operators.CompareString(this.VFI_ECRRcptNum, "", false) == 0)
								{
									this.VFI_ECRRcptNum = "00";
								}
								this.VFI_ECRRcptNum = this.VFI_ECRRcptNum.Trim();
								if (this.VFI_ECRRcptNum.Length <= 0)
								{
									this.VFI_ECRRcptNum = "00";
								}
								if (Conversions.ToLong(this.VFI_ECRRcptNum) <= 0L)
								{
									this.VFI_RespCode = "74";
									this.VFI_RespMess = "ECR Receipt Number is must";
									this.Trace("VFI_VoidTrans Err :" + this.VFI_RespMess);
									result = false;
								}
								else
								{
									if (Operators.CompareString(this.VFI_VoidInvoiceNo, "", false) == 0)
									{
										this.VFI_VoidInvoiceNo = "00";
									}
									this.VFI_VoidInvoiceNo = this.VFI_VoidInvoiceNo.Trim();
									if (this.VFI_VoidInvoiceNo.Length <= 0)
									{
										this.VFI_VoidInvoiceNo = "00";
									}
									if (Conversions.ToInteger(this.VFI_VoidInvoiceNo) <= 0)
									{
										this.VFI_RespCode = "75";
										this.VFI_RespMess = " Void Invoice Number is must";
										this.Trace("VFI_VoidTrans Err :" + this.VFI_RespMess);
										result = false;
									}
									else
									{
										this.Serial_Port = new SerialPort();
										if (!this.Open_Port(ref this.Serial_Port, modMain.Settings.PortName, modMain.Settings.BaudRate))
										{
											this.Trace("VFI_VoidTrans Connect Error.");
											this.VFI_RespCode = "93";
											this.VFI_RespMess = "Port Error";
											flag = false;
										}
										else
										{
											this.VFI_TxnDateTime = DateAndTime.Now.ToString("MMddHHmm");
											if (!this.VFI_InitTxn(ref this.Serial_Port, ref this.VFI_RespCode, ref this.VFI_RespMess))
											{
												flag = false;
											}
											else
											{
												if (modMain.Settings.Delay)
												{
													int millisecondsTimeout = modMain.Settings.DelayTimeout * 1000;
													Thread.Sleep(millisecondsTimeout);
													Application.DoEvents();
												}
												string text2 = this.CalculateMAC();
												this.Ptr = 0;
												this.Tx[(int)this.Ptr] = this.STX[0];
												this.Ptr += 1;
												this.Dump = string.Concat(new string[]
												{
													text,
													",",
													this.VFI_ECRRcptNum,
													",",
													this.VFI_Amount,
													",",
													this.VFI_VoidInvoiceNo,
													",",
													this.VFI_TID,
													",",
													text2.Substring(0, 8),
													","
												});
												if (this.Tx.Length <= this.Dump.Length + 3)
												{
													this.Tx = (byte[])Utils.CopyArray((Array)this.Tx, new byte[this.Dump.Length + 3 + 1]);
												}
												Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
												this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
												this.Tx[(int)this.Ptr] = this.ETX[0];
												this.Ptr += 1;
												this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
												this.Ptr += 1;
												if (!this.ExchangePkt(ref this.Serial_Port, this.Tx, this.Ptr))
												{
													this.Trace("VFI_VoidTrans Exchange pos error.");
													this.VFI_RespCode = "91";
													this.VFI_RespMess = "Send Error";
													flag = false;
												}
												else
												{
													DateTime dateTime = DateAndTime.Now.AddSeconds((double)modMain.Settings.TxnTimeout);
													while (true)
													{
														short num = this.RxBlock(ref this.Serial_Port, ref this.Rx, ref dateTime, ref this.VFI_RespMess, text);
														if (this.VFI_RespMess.Length <= 0)
														{
															this.VFI_RespMess = "No Response / Timeout ";
														}
														if (num == 0)
														{
															this.Trace("VFI_VoidTrans Err Rx :" + this.VFI_RespMess);
															if (!modMain.Settings.flgWaitRes)
															{
																goto IL_68E;
															}
															this.Mess = this.VFI_RespMess + "\r\nAre you want to wait for response?";
															if (MessageBox.Show(this.Mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
															{
																break;
															}
														}
														if (!this.ProcessBlock(this.Rx, (int)num, ref left))
														{
															goto Block_30;
														}
														if (Operators.CompareString(left, "06", false) != 0)
														{
															goto IL_6C8;
														}
													}
													flag = false;
													goto IL_6F1;
													IL_68E:
													flag = false;
													goto IL_6F1;
													Block_30:
													this.Trace("VFI_VoidTrans disconnect Error.");
													flag = false;
													goto IL_6F1;
													IL_6C8:
													if (Conversions.ToInteger(this.VFI_RespCode) == 0)
													{
														flag = true;
													}
													if (this.VFI_RespMess.Length <= 0)
													{
														this.VFI_RespMess = "No Response / Timeout ";
													}
												}
											}
										}
										IL_6F1:
										if (!this.Close_Port(ref this.Serial_Port))
										{
											this.Trace("VFI_VoidTrans disconnect Error.");
											result = false;
										}
										else
										{
											this.Trace("VFI_VoidTrans success.");
											result = flag;
										}
									}
								}
							}
						}
					}
					else
					{
						this.VFI_RespCode = "99";
						this.VFI_RespMess = "Error on Load settings.";
						this.Trace("Error on Load Setting " + this.VFI_RespMess);
						result = false;
					}
				}
				catch (Exception expr_71F)
				{
					ProjectData.SetProjectError(expr_71F);
					Exception ex = expr_71F;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("VFI_VoidTrans Err:" + ex.ToString());
					result = false;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private bool COM_Settle()
		{
			bool flag = true;
			string text = "04";
			checked
			{
				bool result;
				try
				{
					this.Trace("VFI_Settle Starts");
					if (!this.ValidateLicense(ref this.VFI_RespMess))
					{
						this.VFI_RespCode = "91";
						if (Operators.CompareString(this.VFI_RespMess, "", false) == 0)
						{
							this.VFI_RespMess = "Error on Load lic";
						}
						this.Trace("Error on Load lic " + this.VFI_RespMess);
						if (!this.flgcLic)
						{
							result = false;
							return result;
						}
					}
					else if (this.flgLic)
					{
						this.LicVerified = true;
					}
					if (!this.flgSysConfig)
					{
						if (!this.LoadSettings())
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = "Error on Load settings.";
							this.Trace("Error on Load Setting " + this.VFI_RespMess);
							result = false;
							return result;
						}
						this.flgSysConfig = true;
					}
					this.VFI_TID = this.VFI_PTID;
					if (Operators.CompareString(this.VFI_TID, "", false) == 0)
					{
						this.VFI_TID = "00";
					}
					this.VFI_TID = this.VFI_TID.Trim();
					if (this.VFI_TID.Length <= 0)
					{
						this.VFI_TID = "00";
					}
					if (this.VFI_TID.Length <= 0)
					{
						this.VFI_RespCode = "99";
						this.VFI_RespMess = "Terminal Number Missing";
						this.Trace("VFI_Report Err :" + this.VFI_RespMess);
						result = false;
					}
					else
					{
						if (this.VFI_TID.Length > 8)
						{
							this.VFI_TID = this.VFI_TID.Remove(8);
						}
						else
						{
							this.VFI_TID = this.VFI_TID.PadLeft(8, '0');
						}
						this.Serial_Port = new SerialPort();
						if (!this.Open_Port(ref this.Serial_Port, modMain.Settings.PortName, modMain.Settings.BaudRate))
						{
							this.VFI_RespCode = "93";
							this.VFI_RespMess = "Port Error";
							this.Trace("VFI_GetAuth Connect Error.");
							flag = false;
						}
						else
						{
							this.VFI_TxnDateTime = DateAndTime.Now.ToString("MMddHHmm");
							if (!this.VFI_InitTxn(ref this.Serial_Port, ref this.VFI_RespCode, ref this.VFI_RespMess))
							{
								flag = false;
							}
							else
							{
								if (modMain.Settings.Delay)
								{
									int millisecondsTimeout = modMain.Settings.DelayTimeout * 1000;
									Thread.Sleep(millisecondsTimeout);
									Application.DoEvents();
								}
								this.VFI_MAC = this.CalculateMAC();
								this.Ptr = 0;
								this.Tx[(int)this.Ptr] = this.STX[0];
								this.Ptr += 1;
								this.Dump = string.Concat(new string[]
								{
									text,
									",",
									this.VFI_TID,
									",",
									this.VFI_MAC.Substring(0, 8),
									",",
									this.VFI_CurrCode,
									","
								});
								if (this.Tx.Length <= this.Dump.Length + 3)
								{
									this.Tx = (byte[])Utils.CopyArray((Array)this.Tx, new byte[this.Dump.Length + 3 + 1]);
								}
								Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
								this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
								this.Tx[(int)this.Ptr] = this.ETX[0];
								this.Ptr += 1;
								this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
								this.Ptr += 1;
								if (!this.ExchangePkt(ref this.Serial_Port, this.Tx, this.Ptr))
								{
									this.Trace("VFI_Settle Exchange pos error.");
									flag = false;
								}
								else
								{
									string left = "";
									DateTime dateTime = DateAndTime.Now.AddSeconds((double)modMain.Settings.TxnTimeout);
									while (true)
									{
										short num = this.RxBlock(ref this.Serial_Port, ref this.Rx, ref dateTime, ref this.VFI_RespMess, text);
										if (this.VFI_RespMess.Length <= 0)
										{
											this.VFI_RespMess = "No Response / Timeout ";
										}
										if (num == 0)
										{
											this.Trace("VFI_VoidTrans Err Rx :" + this.VFI_RespMess);
											if (!modMain.Settings.flgWaitRes)
											{
												goto IL_4A4;
											}
											this.Mess = this.VFI_RespMess + "\r\nAre you want to wait for response?";
											if (MessageBox.Show(this.Mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
											{
												break;
											}
										}
										if (!this.ProcessBlock(this.Rx, (int)num, ref left))
										{
											goto Block_22;
										}
										if (Operators.CompareString(left, "06", false) != 0)
										{
											goto IL_4DE;
										}
									}
									flag = false;
									goto IL_507;
									IL_4A4:
									flag = false;
									goto IL_507;
									Block_22:
									this.Trace("VFI_VoidTrans disconnect Error.");
									flag = false;
									goto IL_507;
									IL_4DE:
									if (Conversions.ToInteger(this.VFI_RespCode) == 0)
									{
										flag = true;
									}
									if (this.VFI_RespMess.Length <= 0)
									{
										this.VFI_RespMess = "No Response / Timeout ";
									}
								}
							}
						}
						IL_507:
						if (!this.Close_Port(ref this.Serial_Port))
						{
							this.Trace("VFI_Settle Disconnect Err");
							result = false;
						}
						else
						{
							this.Trace("VFI_Settle Success");
							result = flag;
						}
					}
				}
				catch (Exception expr_535)
				{
					ProjectData.SetProjectError(expr_535);
					Exception ex = expr_535;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("VFI_Settle :" + ex.ToString());
					result = false;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private bool COM_Report()
		{
			bool flag = true;
			string text = "05";
			checked
			{
				bool result;
				try
				{
					this.Trace("VFI_Report Starts");
					if (!this.ValidateLicense(ref this.VFI_RespMess))
					{
						this.VFI_RespCode = "91";
						if (Operators.CompareString(this.VFI_RespMess, "", false) == 0)
						{
							this.VFI_RespMess = "Error on Load lic";
						}
						this.Trace("Error on Load lic " + this.VFI_RespMess);
						if (!this.flgcLic)
						{
							result = false;
							return result;
						}
					}
					else if (this.flgLic)
					{
						this.LicVerified = true;
					}
					if (!this.flgSysConfig)
					{
						if (!this.LoadSettings())
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = "Error on Load settings.";
							this.Trace("Error on Load Setting " + this.VFI_RespMess);
							result = false;
							return result;
						}
						this.flgSysConfig = true;
					}
					this.VFI_TID = this.VFI_PTID;
					if (Operators.CompareString(this.VFI_TID, "", false) == 0)
					{
						this.VFI_TID = "00";
					}
					this.VFI_TID = this.VFI_TID.Trim();
					if (this.VFI_TID.Length <= 0)
					{
						this.VFI_TID = "00";
					}
					if (this.VFI_TID.Length <= 0)
					{
						this.VFI_RespCode = "99";
						this.VFI_RespMess = "Terminal Number Missing";
						this.Trace("VFI_Report Err :" + this.VFI_RespMess);
						result = false;
					}
					else
					{
						if (this.VFI_TID.Length > 8)
						{
							this.VFI_TID = this.VFI_TID.Remove(8);
						}
						else
						{
							this.VFI_TID = this.VFI_TID.PadLeft(8, '0');
						}
						if (Operators.CompareString(this.VFI_ReportType, "", false) == 0)
						{
							this.VFI_ReportType = "0";
						}
						this.VFI_ReportType = this.VFI_ReportType.Trim();
						if (this.VFI_ReportType.Length <= 0)
						{
							this.VFI_ReportType = "0";
						}
						if (Conversions.ToInteger(this.VFI_ReportType) < 0)
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = "Zero Report not allowed";
							this.Trace("VFI_Report Err :" + this.VFI_RespMess);
							result = false;
						}
						else
						{
							this.Serial_Port = new SerialPort();
							if (!this.Open_Port(ref this.Serial_Port, modMain.Settings.PortName, modMain.Settings.BaudRate))
							{
								this.VFI_RespCode = "93";
								this.VFI_RespMess = "Port Error";
								this.Trace("VFI_Report Connect Error.");
								flag = false;
							}
							else
							{
								this.VFI_TxnDateTime = DateAndTime.Now.ToString("MMddHHmm");
								if (!this.VFI_InitTxn(ref this.Serial_Port, ref this.VFI_RespCode, ref this.VFI_RespMess))
								{
									flag = false;
								}
								else
								{
									if (modMain.Settings.Delay)
									{
										int millisecondsTimeout = modMain.Settings.DelayTimeout * 1000;
										Thread.Sleep(millisecondsTimeout);
										Application.DoEvents();
									}
									this.Ptr = 0;
									this.Tx[(int)this.Ptr] = this.STX[0];
									this.Ptr += 1;
									string text2 = this.CalculateMAC();
									this.Dump = string.Concat(new string[]
									{
										text,
										",",
										this.VFI_TID,
										",",
										this.VFI_ReportType,
										",",
										text2.Substring(0, 8),
										",",
										this.VFI_CurrCode,
										","
									});
									if (this.Tx.Length <= this.Dump.Length + 3)
									{
										this.Tx = (byte[])Utils.CopyArray((Array)this.Tx, new byte[this.Dump.Length + 3 + 1]);
									}
									Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
									this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
									this.Tx[(int)this.Ptr] = this.ETX[0];
									this.Ptr += 1;
									this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
									this.Ptr += 1;
									if (!this.ExchangePkt(ref this.Serial_Port, this.Tx, this.Ptr))
									{
										this.Trace("VFI_Report Exchange pos error.");
										flag = false;
									}
									else
									{
										string left = "";
										DateTime dateTime = DateAndTime.Now.AddSeconds((double)modMain.Settings.TxnTimeout);
										while (true)
										{
											short num = this.RxBlock(ref this.Serial_Port, ref this.Rx, ref dateTime, ref this.VFI_RespMess, text);
											if (this.VFI_RespMess.Length <= 0)
											{
												this.VFI_RespMess = "No Response / Timeout ";
											}
											if (num == 0)
											{
												this.Trace("VFI_VoidTrans Err Rx :" + this.VFI_RespMess);
												if (!modMain.Settings.flgWaitRes)
												{
													goto IL_53D;
												}
												this.Mess = this.VFI_RespMess + "\r\nAre you want to wait for response?";
												if (MessageBox.Show(this.Mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
												{
													break;
												}
											}
											if (!this.ProcessBlock(this.Rx, (int)num, ref left))
											{
												goto Block_25;
											}
											if (Operators.CompareString(left, "06", false) != 0)
											{
												goto IL_577;
											}
										}
										flag = false;
										goto IL_5A0;
										IL_53D:
										flag = false;
										goto IL_5A0;
										Block_25:
										this.Trace("VFI_VoidTrans disconnect Error.");
										flag = false;
										goto IL_5A0;
										IL_577:
										if (Conversions.ToInteger(this.VFI_RespCode) == 0)
										{
											flag = true;
										}
										if (this.VFI_RespMess.Length <= 0)
										{
											this.VFI_RespMess = "No Response / Timeout ";
										}
									}
								}
							}
							IL_5A0:
							if (!this.Close_Port(ref this.Serial_Port))
							{
								this.Trace("VFI_Report Disconnect Err");
								result = false;
							}
							else
							{
								this.Trace("VFI_Report Success");
								result = flag;
							}
						}
					}
				}
				catch (Exception expr_5CE)
				{
					ProjectData.SetProjectError(expr_5CE);
					Exception ex = expr_5CE;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("VFI_Report :" + ex.ToString());
					result = false;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private bool COM_GetTelNo()
		{
			bool flag = true;
			string text = "07";
			checked
			{
				try
				{
					this.Trace("VFI_GetTelNo Starts");
					bool result;
					if (!this.ValidateLicense(ref this.VFI_RespMess))
					{
						this.VFI_RespCode = "91";
						if (Operators.CompareString(this.VFI_RespMess, "", false) == 0)
						{
							this.VFI_RespMess = "Error on Load lic";
						}
						this.Trace("Error on Load lic " + this.VFI_RespMess);
						if (!this.flgcLic)
						{
							result = false;
							return result;
						}
					}
					else if (this.flgLic)
					{
						this.LicVerified = true;
					}
					if (!this.flgSysConfig)
					{
						if (!this.LoadSettings())
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = "Error on Load settings.";
							this.Trace("Error on Load Setting " + this.VFI_RespMess);
							result = false;
							return result;
						}
						this.flgSysConfig = true;
					}
					this.VFI_TID = this.VFI_PTID;
					if (Operators.CompareString(this.VFI_TID, "", false) == 0)
					{
						this.VFI_TID = "00";
					}
					this.VFI_TID = this.VFI_TID.Trim();
					if (this.VFI_TID.Length <= 0)
					{
						this.VFI_TID = "00";
					}
					if (this.VFI_TID.Length <= 0)
					{
						this.VFI_RespCode = "99";
						this.VFI_RespMess = "Terminal Number Missing";
						this.Trace("VFI_GetTelNo Err :" + this.VFI_RespMess);
						result = false;
						return result;
					}
					if (this.VFI_TID.Length > 8)
					{
						this.VFI_TID = this.VFI_TID.Remove(8);
					}
					else
					{
						this.VFI_TID = this.VFI_TID.PadLeft(8, '0');
					}
					this.Serial_Port = new SerialPort();
					if (!this.Open_Port(ref this.Serial_Port, modMain.Settings.PortName, modMain.Settings.BaudRate))
					{
						this.VFI_RespCode = "93";
						this.VFI_RespMess = "Port Error";
						this.Trace("VFI_GetTelNo Connect Error.");
						flag = false;
					}
					else
					{
						this.VFI_TxnDateTime = DateAndTime.Now.ToString("MMddHHmm");
						if (!this.VFI_InitTxn(ref this.Serial_Port, ref this.VFI_RespCode, ref this.VFI_RespMess))
						{
							flag = false;
						}
						else
						{
							if (modMain.Settings.Delay)
							{
								int millisecondsTimeout = modMain.Settings.DelayTimeout * 1000;
								Thread.Sleep(millisecondsTimeout);
								Application.DoEvents();
							}
							this.Ptr = 0;
							this.Tx[(int)this.Ptr] = this.STX[0];
							this.Ptr += 1;
							string text2 = this.CalculateMAC();
							this.Dump = string.Concat(new string[]
							{
								text,
								",",
								this.VFI_TID,
								",",
								text2.Substring(0, 8),
								","
							});
							if (this.Tx.Length <= this.Dump.Length + 3)
							{
								this.Tx = (byte[])Utils.CopyArray((Array)this.Tx, new byte[this.Dump.Length + 3 + 1]);
							}
							Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
							this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
							this.Tx[(int)this.Ptr] = this.ETX[0];
							this.Ptr += 1;
							this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
							this.Ptr += 1;
							if (!this.ExchangePkt(ref this.Serial_Port, this.Tx, this.Ptr))
							{
								this.Trace("VFI_GetTelNo Exchange pos error.");
								flag = false;
							}
							else
							{
								string left = "";
								DateTime dateTime = DateAndTime.Now.AddSeconds((double)modMain.Settings.TxnTimeout);
								while (true)
								{
									short num = this.RxBlock(ref this.Serial_Port, ref this.Rx, ref dateTime, ref this.VFI_RespMess, text);
									if (this.VFI_RespMess.Length <= 0)
									{
										this.VFI_RespMess = "No Response / Timeout ";
									}
									if (num == 0)
									{
										this.Trace("VFI_GetTelNo Err Rx :" + this.VFI_RespMess);
										if (!modMain.Settings.flgWaitRes)
										{
											goto IL_48A;
										}
										this.Mess = this.VFI_RespMess + "\r\nAre you want to wait for response?";
										if (MessageBox.Show(this.Mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
										{
											break;
										}
									}
									if (!this.ProcessBlock(this.Rx, (int)num, ref left))
									{
										goto Block_22;
									}
									if (Operators.CompareString(left, "06", false) != 0)
									{
										goto IL_4C4;
									}
								}
								flag = false;
								goto IL_4ED;
								IL_48A:
								flag = false;
								goto IL_4ED;
								Block_22:
								this.Trace("VFI_GetTelNo process Error.");
								flag = false;
								goto IL_4ED;
								IL_4C4:
								if (Conversions.ToInteger(this.VFI_RespCode) == 0)
								{
									flag = true;
								}
								if (this.VFI_RespMess.Length <= 0)
								{
									this.VFI_RespMess = "No Response / Timeout ";
								}
							}
						}
					}
					IL_4ED:
					if (!this.Close_Port(ref this.Serial_Port))
					{
						this.Trace("VFI_GetTelNo Disconnect Err");
						result = false;
						return result;
					}
					this.Trace("VFI_GetTelNo Success");
					result = flag;
					return result;
				}
				catch (Exception expr_51B)
				{
					ProjectData.SetProjectError(expr_51B);
					Exception ex = expr_51B;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("VFI_GetTelNo :" + ex.ToString());
					ProjectData.ClearProjectError();
				}
				return false;
			}
		}

		private bool VFI_InitTxn(ref SerialPort Serial_Port, ref string RespCode, ref string RespMess)
		{
			string text = "01";
			checked
			{
				bool result;
				try
				{
					this.Trace("Init Txn starts.");
					this.Ptr = 0;
					this.Tx[(int)this.Ptr] = this.STX[0];
					this.Ptr += 1;
					this.Dump = string.Concat(new string[]
					{
						text,
						",",
						this.VFI_TID,
						",",
						this.VFI_TxnDateTime,
						","
					});
					if (this.Tx.Length <= this.Dump.Length + 3)
					{
						this.Tx = (byte[])Utils.CopyArray((Array)this.Tx, new byte[this.Dump.Length + 3 + 1]);
					}
					Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
					this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
					this.Tx[(int)this.Ptr] = this.ETX[0];
					this.Ptr += 1;
					this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
					this.Ptr += 1;
					if (!this.ExchangePkt(ref Serial_Port, this.Tx, this.Ptr))
					{
						this.Trace("Init Txn Exchange pos error.");
						result = false;
					}
					else
					{
						short num = this.RxBlock(ref Serial_Port, ref this.Rx, 1, ref RespMess, text);
						if (num == 0)
						{
							if (RespMess.Length <= 0)
							{
								RespMess = "No Response / Timeout ";
							}
							this.Trace("Init Txn Err :" + RespMess);
							RespCode = "99";
							RespMess = "Init Txn : " + RespMess;
							result = false;
						}
						else if (!this.ProcessBlock(this.Rx, (int)num))
						{
							this.Trace("Init Txn Process error.");
							RespCode = "99";
							RespMess = "Init Txn Process error.";
							result = false;
						}
						else
						{
							this.Trace("Init Txn success.");
							result = true;
						}
					}
				}
				catch (Exception expr_217)
				{
					ProjectData.SetProjectError(expr_217);
					Exception ex = expr_217;
					RespCode = "99";
					RespMess = ex.Message;
					this.Trace("Init Txn Err:" + ex.ToString());
					result = false;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private bool TCP_GetAuth()
		{
			bool flag = true;
			string text = "02";
			string left = "";
			checked
			{
				bool result;
				try
				{
					this.Trace("VFI_GetAuth starts.");
					this.VFI_RespCode = "99";
					if (!this.ValidateLicense(ref this.VFI_RespMess))
					{
						this.VFI_RespCode = "91";
						if (Operators.CompareString(this.VFI_RespMess, "", false) == 0)
						{
							this.VFI_RespMess = "Error on Load lic";
						}
						this.Trace("Error on Load lic " + this.VFI_RespMess);
						if (!this.flgcLic)
						{
							result = false;
							return result;
						}
					}
					else if (this.flgLic)
					{
						this.LicVerified = true;
					}
					this.VFI_RespMess = "System Error";
					if (this.LoadSettings())
					{
						this.flgSysConfig = true;
						if (Operators.CompareString(this.VFI_TransType, "", false) == 0)
						{
							this.VFI_TransType = "01";
						}
						this.VFI_TransType = this.VFI_TransType.TrimEnd(new char[]
						{
							'0'
						});
						this.VFI_TransType = this.VFI_TransType.Trim();
						if (this.VFI_TransType.Length <= 0)
						{
							this.VFI_TransType = "01";
						}
						if (Conversions.ToInteger(this.VFI_TransType) < 1 | Conversions.ToInteger(this.VFI_TransType) > 8)
						{
							this.VFI_RespCode = "71";
							this.VFI_RespMess = "Invalid Txn Type";
							this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
							result = false;
						}
						else
						{
							this.VFI_TID = this.VFI_PTID;
							if (Operators.CompareString(this.VFI_TID, "", false) == 0)
							{
								this.VFI_TID = "00";
							}
							this.VFI_TID = this.VFI_TID.Trim();
							if (this.VFI_TID.Length <= 0)
							{
								this.VFI_TID = "00";
							}
							if (this.VFI_TID.Length <= 0)
							{
								this.VFI_RespCode = "72";
								this.VFI_RespMess = "Terminal Number Missing";
								this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
								result = false;
							}
							else
							{
								if (this.VFI_TID.Length > 8)
								{
									this.VFI_TID = this.VFI_TID.Remove(8);
								}
								else
								{
									this.VFI_TID = this.VFI_TID.PadLeft(8, '0');
								}
								if (Operators.CompareString(this.VFI_Amount, "", false) == 0)
								{
									this.VFI_Amount = "00";
								}
								this.VFI_Amount = this.VFI_Amount.Trim();
								if (this.VFI_Amount.Length <= 0)
								{
									this.VFI_Amount = "00";
								}
								if (Conversions.ToLong(this.VFI_Amount) <= 0L)
								{
									this.VFI_RespCode = "73";
									this.VFI_RespMess = "Zero Amount not allowed";
									this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
									result = false;
								}
								else
								{
									if (Operators.CompareString(this.VFI_ECRRcptNum, "", false) == 0)
									{
										this.VFI_ECRRcptNum = "00";
									}
									this.VFI_ECRRcptNum = this.VFI_ECRRcptNum.Trim();
									if (this.VFI_ECRRcptNum.Length <= 0)
									{
										this.VFI_ECRRcptNum = "00";
									}
									if (Conversions.ToLong(this.VFI_ECRRcptNum) <= 0L)
									{
										this.VFI_RespCode = "74";
										this.VFI_RespMess = "ECR Receipt Number is must";
										this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
										result = false;
									}
									else
									{
										string text2 = "0";
										if (Conversions.ToInteger(this.VFI_TransType) == 4)
										{
											if (Operators.CompareString(this.VFI_PreauthComplAmount, "", false) == 0)
											{
												this.VFI_PreauthComplAmount = "0";
											}
											text2 = this.VFI_PreauthComplAmount;
										}
										else if (Conversions.ToInteger(this.VFI_TransType) == 6)
										{
											if (Operators.CompareString(this.VFI_TIPAmount, "", false) == 0)
											{
												this.VFI_TIPAmount = "0";
											}
											text2 = this.VFI_TIPAmount;
										}
										else if (Conversions.ToInteger(this.VFI_TransType) == 8)
										{
											if (Operators.CompareString(this.VFI_CashBackAmount, "", false) == 0)
											{
												this.VFI_CashBackAmount = "0";
											}
											text2 = this.VFI_CashBackAmount;
										}
										if (Operators.CompareString(this.VFI_OrgionalInvoiceNo, "", false) == 0)
										{
											this.VFI_OrgionalInvoiceNo = "00";
										}
										if (Conversions.ToInteger(this.VFI_TransType) == 4 | Conversions.ToInteger(this.VFI_TransType) == 6)
										{
											text2 = text2.Trim();
											if (text2.Length <= 0)
											{
												text2 = "00";
											}
											if (Conversions.ToInteger(text2) < Conversions.ToInteger(Interaction.IIf(Conversions.ToInteger(this.VFI_TransType) == 4, 1, 0)))
											{
												this.VFI_RespCode = "99";
												this.VFI_RespMess = "Zero Amount not allowed for Txn Completion";
												this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
												result = false;
												return result;
											}
											this.VFI_OrgionalInvoiceNo = this.VFI_OrgionalInvoiceNo.Trim();
											if (this.VFI_OrgionalInvoiceNo.Length <= 0)
											{
												this.VFI_OrgionalInvoiceNo = "00";
											}
											if (Conversions.ToInteger(this.VFI_OrgionalInvoiceNo) <= 0)
											{
												this.VFI_RespCode = "99";
												this.VFI_RespMess = "Orgional Invoice Number is must";
												this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
												result = false;
												return result;
											}
										}
										Socket socket = null;
										if (!this.Connect(ref socket))
										{
											this.VFI_RespCode = "93";
											this.VFI_RespMess = "Please check Router application is Running";
											this.Trace("VFI_GetAuth Connect Error.");
											flag = false;
										}
										else
										{
											this.VFI_TxnDateTime = DateAndTime.Now.ToString("MMddHHmm");
											if (!this.VFI_InitTxn(ref socket, ref this.VFI_RespCode, ref this.VFI_RespMess))
											{
												flag = false;
											}
											else
											{
												if (modMain.Settings.Delay)
												{
													int millisecondsTimeout = modMain.Settings.DelayTimeout * 1000;
													Thread.Sleep(millisecondsTimeout);
													Application.DoEvents();
												}
												string text3 = this.CalculateMAC();
												this.Ptr = 0;
												this.Tx[(int)this.Ptr] = this.STX[0];
												this.Ptr += 1;
												this.Dump = string.Concat(new string[]
												{
													text,
													",",
													this.VFI_TransType,
													",",
													this.VFI_ECRRcptNum,
													",",
													this.VFI_Amount,
													",",
													this.VFI_TID,
													",",
													text2,
													",",
													this.VFI_OrgionalInvoiceNo,
													",",
													text3.Substring(0, 8),
													",",
													this.VFI_CurrCode,
													",",
													this.VFI_PreauthApprovalCode,
													","
												});
												if (this.Tx.Length <= this.Dump.Length + 3)
												{
													this.Tx = (byte[])Utils.CopyArray((Array)this.Tx, new byte[this.Dump.Length + 3 + 1]);
												}
												Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
												this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
												this.Tx[(int)this.Ptr] = this.ETX[0];
												this.Ptr += 1;
												this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
												this.Ptr += 1;
												if (!this.TCP_ExchangePkt(ref socket, this.Tx, this.Ptr))
												{
													this.Trace("VFI_GetAuth Exchange pos error.");
													this.VFI_RespCode = "92";
													this.VFI_RespMess = "Send Error";
													flag = false;
												}
												else
												{
													DateTime dateTime = DateAndTime.Now.AddSeconds((double)modMain.Settings.TxnTimeout);
													while (true)
													{
														short num = this.TCP_RxBlock(ref socket, ref this.Rx, ref dateTime, ref this.VFI_RespMess, text);
														if (this.VFI_RespMess.Length <= 0)
														{
															this.VFI_RespMess = "No Response / Timeout ";
														}
														if (num == 0)
														{
															this.Trace("VFI_GetAuth Err Rx :" + this.VFI_RespMess);
															if (!modMain.Settings.flgWaitRes)
															{
																goto IL_8D4;
															}
															this.Mess = this.VFI_RespMess + "\r\nAre you want to wait for response?";
															if (MessageBox.Show(this.Mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
															{
																break;
															}
														}
														if (!this.ProcessBlock(this.Rx, (int)num, ref left))
														{
															goto Block_42;
														}
														if (Operators.CompareString(left, "06", false) != 0)
														{
															goto IL_924;
														}
													}
													this.VFI_RespCode = "99";
													this.VFI_RespMess = "No Response / Timeout";
													flag = false;
													goto IL_94D;
													IL_8D4:
													this.VFI_RespCode = "99";
													this.VFI_RespMess = "No Response / Timeout";
													flag = false;
													goto IL_94D;
													Block_42:
													this.Trace("VFI_GetAuth disconnect Error.");
													flag = false;
													goto IL_94D;
													IL_924:
													if (Conversions.ToInteger(this.VFI_RespCode) == 0)
													{
														flag = true;
													}
													if (this.VFI_RespMess.Length <= 0)
													{
														this.VFI_RespMess = "No Response / Timeout ";
													}
												}
											}
										}
										IL_94D:
										if (!this.Disconnect(ref socket))
										{
											this.Trace("VFI_GetAuth disconnect Error.");
										}
										this.Trace("VFI_GetAuth success.");
										result = flag;
									}
								}
							}
						}
					}
					else
					{
						this.VFI_RespCode = "92";
						this.VFI_RespMess = "Error on Load settings";
						this.Trace("Error on Load Setting " + this.VFI_RespMess);
						result = false;
					}
				}
				catch (Exception expr_974)
				{
					ProjectData.SetProjectError(expr_974);
					Exception ex = expr_974;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("VFI_GetAuth Err:" + ex.ToString());
					result = false;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private bool TCP_VoidTrans()
		{
			bool flag = true;
			string text = "03";
			string left = "";
			checked
			{
				bool result;
				try
				{
					this.Trace("VFI_VoidTrans starts.");
					this.VFI_RespCode = "99";
					if (!this.ValidateLicense(ref this.VFI_RespMess))
					{
						this.VFI_RespCode = "91";
						if (Operators.CompareString(this.VFI_RespMess, "", false) == 0)
						{
							this.VFI_RespMess = "Error on Load lic";
						}
						this.Trace("Error on Load lic " + this.VFI_RespMess);
						if (!this.flgcLic)
						{
							result = false;
							return result;
						}
					}
					else if (this.flgLic)
					{
						this.LicVerified = true;
					}
					this.VFI_RespMess = "System Error";
					if (this.LoadSettings())
					{
						this.flgSysConfig = true;
						this.VFI_TID = this.VFI_PTID;
						if (Operators.CompareString(this.VFI_TID, "", false) == 0)
						{
							this.VFI_TID = "00";
						}
						this.VFI_TID = this.VFI_TID.Trim();
						if (this.VFI_TID.Length <= 0)
						{
							this.VFI_TID = "00";
						}
						if (this.VFI_TID.Length <= 0)
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = "Terminal Number Missing";
							this.Trace("VFI_VoidTrans Err :" + this.VFI_RespMess);
							result = false;
						}
						else
						{
							if (this.VFI_TID.Length > 8)
							{
								this.VFI_TID = this.VFI_TID.Remove(8);
							}
							else
							{
								this.VFI_TID = this.VFI_TID.PadLeft(8, '0');
							}
							if (Operators.CompareString(this.VFI_Amount, "", false) == 0)
							{
								this.VFI_Amount = "00";
							}
							this.VFI_Amount = this.VFI_Amount.Trim();
							if (this.VFI_Amount.Length <= 0)
							{
								this.VFI_Amount = "00";
							}
							if (Conversions.ToLong(this.VFI_Amount) <= 0L)
							{
								this.VFI_RespCode = "99";
								this.VFI_RespMess = "Zero Amount not allowed";
								this.Trace("VFI_GetAuth Err :" + this.VFI_RespMess);
								result = false;
							}
							else
							{
								if (Operators.CompareString(this.VFI_ECRRcptNum, "", false) == 0)
								{
									this.VFI_ECRRcptNum = "00";
								}
								this.VFI_ECRRcptNum = this.VFI_ECRRcptNum.Trim();
								if (this.VFI_ECRRcptNum.Length <= 0)
								{
									this.VFI_ECRRcptNum = "00";
								}
								if (Conversions.ToLong(this.VFI_ECRRcptNum) <= 0L)
								{
									this.VFI_RespCode = "74";
									this.VFI_RespMess = "ECR Receipt Number is must";
									this.Trace("VFI_VoidTrans Err :" + this.VFI_RespMess);
									result = false;
								}
								else
								{
									if (Operators.CompareString(this.VFI_VoidInvoiceNo, "", false) == 0)
									{
										this.VFI_VoidInvoiceNo = "00";
									}
									this.VFI_VoidInvoiceNo = this.VFI_VoidInvoiceNo.Trim();
									if (this.VFI_VoidInvoiceNo.Length <= 0)
									{
										this.VFI_VoidInvoiceNo = "00";
									}
									if (Conversions.ToInteger(this.VFI_VoidInvoiceNo) <= 0)
									{
										this.VFI_RespCode = "75";
										this.VFI_RespMess = " Void Invoice Number is must";
										this.Trace("VFI_VoidTrans Err :" + this.VFI_RespMess);
										result = false;
									}
									else
									{
										Socket socket = null;
										if (!this.Connect(ref socket))
										{
											this.Trace("VFI_VoidTrans Connect Error.");
											this.VFI_RespCode = "93";
											this.VFI_RespMess = "Please check Router application is Running";
											flag = false;
										}
										else
										{
											this.VFI_TxnDateTime = DateAndTime.Now.ToString("MMddHHmm");
											if (!this.VFI_InitTxn(ref socket, ref this.VFI_RespCode, ref this.VFI_RespMess))
											{
												flag = false;
											}
											else
											{
												if (modMain.Settings.Delay)
												{
													int millisecondsTimeout = modMain.Settings.DelayTimeout * 1000;
													Thread.Sleep(millisecondsTimeout);
													Application.DoEvents();
												}
												string text2 = this.CalculateMAC();
												this.Ptr = 0;
												this.Tx[(int)this.Ptr] = this.STX[0];
												this.Ptr += 1;
												this.Dump = string.Concat(new string[]
												{
													text,
													",",
													this.VFI_ECRRcptNum,
													",",
													this.VFI_Amount,
													",",
													this.VFI_VoidInvoiceNo,
													",",
													this.VFI_TID,
													",",
													text2.Substring(0, 8),
													","
												});
												if (this.Tx.Length <= this.Dump.Length + 3)
												{
													this.Tx = (byte[])Utils.CopyArray((Array)this.Tx, new byte[this.Dump.Length + 3 + 1]);
												}
												Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
												this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
												this.Tx[(int)this.Ptr] = this.ETX[0];
												this.Ptr += 1;
												this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
												this.Ptr += 1;
												if (!this.TCP_ExchangePkt(ref socket, this.Tx, this.Ptr))
												{
													this.Trace("VFI_VoidTrans Exchange pos error.");
													this.VFI_RespCode = "91";
													this.VFI_RespMess = "Send Error";
													flag = false;
												}
												else
												{
													DateTime dateTime = DateAndTime.Now.AddSeconds((double)modMain.Settings.TxnTimeout);
													while (true)
													{
														short num = this.TCP_RxBlock(ref socket, ref this.Rx, ref dateTime, ref this.VFI_RespMess, text);
														if (this.VFI_RespMess.Length <= 0)
														{
															this.VFI_RespMess = "No Response / Timeout ";
														}
														if (num == 0)
														{
															this.Trace("VFI_VoidTrans Err Rx :" + this.VFI_RespMess);
															if (!modMain.Settings.flgWaitRes)
															{
																goto IL_67E;
															}
															this.Mess = this.VFI_RespMess + "\r\nAre you want to wait for response?";
															if (MessageBox.Show(this.Mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
															{
																break;
															}
														}
														if (!this.ProcessBlock(this.Rx, (int)num, ref left))
														{
															goto Block_30;
														}
														if (Operators.CompareString(left, "06", false) != 0)
														{
															goto IL_6CE;
														}
													}
													this.VFI_RespCode = "99";
													this.VFI_RespMess = "No Response / Timeout";
													flag = false;
													goto IL_6F7;
													IL_67E:
													this.VFI_RespCode = "99";
													this.VFI_RespMess = "No Response / Timeout";
													flag = false;
													goto IL_6F7;
													Block_30:
													this.Trace("VFI_VoidTrans disconnect Error.");
													flag = false;
													goto IL_6F7;
													IL_6CE:
													if (Conversions.ToInteger(this.VFI_RespCode) == 0)
													{
														flag = true;
													}
													if (this.VFI_RespMess.Length <= 0)
													{
														this.VFI_RespMess = "No Response / Timeout ";
													}
												}
											}
										}
										IL_6F7:
										if (!this.Disconnect(ref socket))
										{
											this.Trace("VFI_VoidTrans disconnect Error.");
										}
										this.Trace("VFI_VoidTrans success.");
										result = flag;
									}
								}
							}
						}
					}
					else
					{
						this.VFI_RespCode = "99";
						this.VFI_RespMess = "Error on Load settings.";
						this.Trace("Error on Load Setting " + this.VFI_RespMess);
						result = false;
					}
				}
				catch (Exception expr_71E)
				{
					ProjectData.SetProjectError(expr_71E);
					Exception ex = expr_71E;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("VFI_VoidTrans Err:" + ex.ToString());
					result = false;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private bool TCP_Settle()
		{
			bool flag = true;
			string text = "04";
			checked
			{
				bool result;
				try
				{
					this.Trace("VFI_Settle Starts");
					if (!this.ValidateLicense(ref this.VFI_RespMess))
					{
						this.VFI_RespCode = "91";
						if (Operators.CompareString(this.VFI_RespMess, "", false) == 0)
						{
							this.VFI_RespMess = "Error on Load lic";
						}
						this.Trace("Error on Load lic " + this.VFI_RespMess);
						if (!this.flgcLic)
						{
							result = false;
							return result;
						}
					}
					else if (this.flgLic)
					{
						this.LicVerified = true;
					}
					if (!this.flgSysConfig)
					{
						if (!this.LoadSettings())
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = "Error on Load settings.";
							this.Trace("Error on Load Setting " + this.VFI_RespMess);
							result = false;
							return result;
						}
						this.flgSysConfig = true;
					}
					this.VFI_TID = this.VFI_PTID;
					if (Operators.CompareString(this.VFI_TID, "", false) == 0)
					{
						this.VFI_TID = "00";
					}
					this.VFI_TID = this.VFI_TID.Trim();
					if (this.VFI_TID.Length <= 0)
					{
						this.VFI_TID = "00";
					}
					if (this.VFI_TID.Length <= 0)
					{
						this.VFI_RespCode = "99";
						this.VFI_RespMess = "Terminal Number Missing";
						this.Trace("VFI_Report Err :" + this.VFI_RespMess);
						result = false;
					}
					else
					{
						if (this.VFI_TID.Length > 8)
						{
							this.VFI_TID = this.VFI_TID.Remove(8);
						}
						else
						{
							this.VFI_TID = this.VFI_TID.PadLeft(8, '0');
						}
						Socket socket = null;
						if (!this.Connect(ref socket))
						{
							this.VFI_RespCode = "93";
							this.VFI_RespMess = "Please check Router application is Running";
							this.Trace("VFI_GetAuth Connect Error.");
							flag = false;
						}
						else
						{
							this.VFI_TxnDateTime = DateAndTime.Now.ToString("MMddHHmm");
							if (!this.VFI_InitTxn(ref socket, ref this.VFI_RespCode, ref this.VFI_RespMess))
							{
								flag = false;
							}
							else
							{
								if (modMain.Settings.Delay)
								{
									int millisecondsTimeout = modMain.Settings.DelayTimeout * 1000;
									Thread.Sleep(millisecondsTimeout);
									Application.DoEvents();
								}
								this.VFI_MAC = this.CalculateMAC();
								this.Ptr = 0;
								this.Tx[(int)this.Ptr] = this.STX[0];
								this.Ptr += 1;
								this.Dump = string.Concat(new string[]
								{
									text,
									",",
									this.VFI_TID,
									",",
									this.VFI_MAC.Substring(0, 8),
									",",
									this.VFI_CurrCode,
									","
								});
								if (this.Tx.Length <= this.Dump.Length + 3)
								{
									this.Tx = (byte[])Utils.CopyArray((Array)this.Tx, new byte[this.Dump.Length + 3 + 1]);
								}
								Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
								this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
								this.Tx[(int)this.Ptr] = this.ETX[0];
								this.Ptr += 1;
								this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
								this.Ptr += 1;
								if (!this.TCP_ExchangePkt(ref socket, this.Tx, this.Ptr))
								{
									this.Trace("VFI_Settle Exchange pos error.");
									flag = false;
								}
								else
								{
									string left = "";
									DateTime dateTime = DateAndTime.Now.AddSeconds((double)modMain.Settings.TxnTimeout);
									while (true)
									{
										short num = this.TCP_RxBlock(ref socket, ref this.Rx, ref dateTime, ref this.VFI_RespMess, text);
										if (this.VFI_RespMess.Length <= 0)
										{
											this.VFI_RespMess = "No Response / Timeout ";
										}
										if (num == 0)
										{
											this.Trace("VFI_VoidTrans Err Rx :" + this.VFI_RespMess);
											if (!modMain.Settings.flgWaitRes)
											{
												goto IL_491;
											}
											this.Mess = this.VFI_RespMess + "\r\nAre you want to wait for response?";
											if (MessageBox.Show(this.Mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
											{
												break;
											}
										}
										if (!this.ProcessBlock(this.Rx, (int)num, ref left))
										{
											goto Block_22;
										}
										if (Operators.CompareString(left, "06", false) != 0)
										{
											goto IL_4E1;
										}
									}
									this.VFI_RespCode = "99";
									this.VFI_RespMess = "No Response / Timeout";
									flag = false;
									goto IL_50A;
									IL_491:
									this.VFI_RespCode = "99";
									this.VFI_RespMess = "No Response / Timeout";
									flag = false;
									goto IL_50A;
									Block_22:
									this.Trace("VFI_VoidTrans disconnect Error.");
									flag = false;
									goto IL_50A;
									IL_4E1:
									if (Conversions.ToInteger(this.VFI_RespCode) == 0)
									{
										flag = true;
									}
									if (this.VFI_RespMess.Length <= 0)
									{
										this.VFI_RespMess = "No Response / Timeout ";
									}
								}
							}
						}
						IL_50A:
						if (!this.Disconnect(ref socket))
						{
							this.Trace("VFI_Settle Disconnect Err");
						}
						this.Trace("VFI_Settle Success");
						result = flag;
					}
				}
				catch (Exception expr_530)
				{
					ProjectData.SetProjectError(expr_530);
					Exception ex = expr_530;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("VFI_Settle :" + ex.ToString());
					result = false;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private bool TCP_Report()
		{
			bool flag = true;
			string text = "05";
			checked
			{
				bool result;
				try
				{
					this.Trace("VFI_Report Starts");
					if (!this.ValidateLicense(ref this.VFI_RespMess))
					{
						this.VFI_RespCode = "91";
						if (Operators.CompareString(this.VFI_RespMess, "", false) == 0)
						{
							this.VFI_RespMess = "Error on Load lic";
						}
						this.Trace("Error on Load lic " + this.VFI_RespMess);
						if (!this.flgcLic)
						{
							result = false;
							return result;
						}
					}
					else if (this.flgLic)
					{
						this.LicVerified = true;
					}
					if (!this.flgSysConfig)
					{
						if (!this.LoadSettings())
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = "Error on Load settings.";
							this.Trace("Error on Load Setting " + this.VFI_RespMess);
							result = false;
							return result;
						}
						this.flgSysConfig = true;
					}
					this.VFI_TID = this.VFI_PTID;
					if (Operators.CompareString(this.VFI_TID, "", false) == 0)
					{
						this.VFI_TID = "00";
					}
					this.VFI_TID = this.VFI_TID.Trim();
					if (this.VFI_TID.Length <= 0)
					{
						this.VFI_TID = "00";
					}
					if (this.VFI_TID.Length <= 0)
					{
						this.VFI_RespCode = "99";
						this.VFI_RespMess = "Terminal Number Missing";
						this.Trace("VFI_Report Err :" + this.VFI_RespMess);
						result = false;
					}
					else
					{
						if (this.VFI_TID.Length > 8)
						{
							this.VFI_TID = this.VFI_TID.Remove(8);
						}
						else
						{
							this.VFI_TID = this.VFI_TID.PadLeft(8, '0');
						}
						if (Operators.CompareString(this.VFI_ReportType, "", false) == 0)
						{
							this.VFI_ReportType = "0";
						}
						this.VFI_ReportType = this.VFI_ReportType.Trim();
						if (this.VFI_ReportType.Length <= 0)
						{
							this.VFI_ReportType = "0";
						}
						if (Conversions.ToInteger(this.VFI_ReportType) < 0)
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = "Zero Report not allowed";
							this.Trace("VFI_Report Err :" + this.VFI_RespMess);
							result = false;
						}
						else
						{
							Socket socket = null;
							if (!this.Connect(ref socket))
							{
								this.VFI_RespCode = "93";
								this.VFI_RespMess = "Please check Router application is Running";
								this.Trace("VFI_Report Connect Error.");
								flag = false;
							}
							else
							{
								this.VFI_TxnDateTime = DateAndTime.Now.ToString("MMddHHmm");
								if (!this.VFI_InitTxn(ref socket, ref this.VFI_RespCode, ref this.VFI_RespMess))
								{
									flag = false;
								}
								else
								{
									if (modMain.Settings.Delay)
									{
										int millisecondsTimeout = modMain.Settings.DelayTimeout * 1000;
										Thread.Sleep(millisecondsTimeout);
										Application.DoEvents();
									}
									this.Ptr = 0;
									this.Tx[(int)this.Ptr] = this.STX[0];
									this.Ptr += 1;
									string text2 = this.CalculateMAC();
									this.Dump = string.Concat(new string[]
									{
										text,
										",",
										this.VFI_TID,
										",",
										this.VFI_ReportType,
										",",
										text2.Substring(0, 8),
										",",
										this.VFI_CurrCode,
										","
									});
									if (this.Tx.Length <= this.Dump.Length + 3)
									{
										this.Tx = (byte[])Utils.CopyArray((Array)this.Tx, new byte[this.Dump.Length + 3 + 1]);
									}
									Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
									this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
									this.Tx[(int)this.Ptr] = this.ETX[0];
									this.Ptr += 1;
									this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
									this.Ptr += 1;
									if (!this.TCP_ExchangePkt(ref socket, this.Tx, this.Ptr))
									{
										this.Trace("VFI_Report Exchange pos error.");
										flag = false;
									}
									else
									{
										string left = "";
										DateTime dateTime = DateAndTime.Now.AddSeconds((double)modMain.Settings.TxnTimeout);
										while (true)
										{
											short num = this.TCP_RxBlock(ref socket, ref this.Rx, ref dateTime, ref this.VFI_RespMess, text);
											if (this.VFI_RespMess.Length <= 0)
											{
												this.VFI_RespMess = "No Response / Timeout ";
											}
											if (num == 0)
											{
												this.Trace("VFI_VoidTrans Err Rx :" + this.VFI_RespMess);
												if (!modMain.Settings.flgWaitRes)
												{
													goto IL_52B;
												}
												this.Mess = this.VFI_RespMess + "\r\nAre you want to wait for response?";
												if (MessageBox.Show(this.Mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
												{
													break;
												}
											}
											if (!this.ProcessBlock(this.Rx, (int)num, ref left))
											{
												goto Block_25;
											}
											if (Operators.CompareString(left, "06", false) != 0)
											{
												goto IL_57B;
											}
										}
										this.VFI_RespCode = "99";
										this.VFI_RespMess = "No Response / Timeout";
										flag = false;
										goto IL_5A4;
										IL_52B:
										this.VFI_RespCode = "99";
										this.VFI_RespMess = "No Response / Timeout";
										flag = false;
										goto IL_5A4;
										Block_25:
										this.Trace("VFI_VoidTrans disconnect Error.");
										flag = false;
										goto IL_5A4;
										IL_57B:
										if (Conversions.ToInteger(this.VFI_RespCode) == 0)
										{
											flag = true;
										}
										if (this.VFI_RespMess.Length <= 0)
										{
											this.VFI_RespMess = "No Response / Timeout ";
										}
									}
								}
							}
							IL_5A4:
							if (!this.Disconnect(ref socket))
							{
								this.Trace("VFI_Report Disconnect Err");
							}
							this.Trace("VFI_Report Success");
							result = flag;
						}
					}
				}
				catch (Exception expr_5CB)
				{
					ProjectData.SetProjectError(expr_5CB);
					Exception ex = expr_5CB;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("VFI_Report :" + ex.ToString());
					result = false;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private bool TCP_GetTelNo()
		{
			bool flag = true;
			string text = "07";
			checked
			{
				bool result;
				try
				{
					this.Trace("VFI_GetTelNo Starts");
					if (!this.ValidateLicense(ref this.VFI_RespMess))
					{
						this.VFI_RespCode = "91";
						if (Operators.CompareString(this.VFI_RespMess, "", false) == 0)
						{
							this.VFI_RespMess = "Error on Load lic";
						}
						this.Trace("Error on Load lic " + this.VFI_RespMess);
						if (!this.flgcLic)
						{
							result = false;
							return result;
						}
					}
					else if (this.flgLic)
					{
						this.LicVerified = true;
					}
					if (!this.flgSysConfig)
					{
						if (!this.LoadSettings())
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = "Error on Load settings.";
							this.Trace("Error on Load Setting " + this.VFI_RespMess);
							result = false;
							return result;
						}
						this.flgSysConfig = true;
					}
					this.VFI_TID = this.VFI_PTID;
					if (Operators.CompareString(this.VFI_TID, "", false) == 0)
					{
						this.VFI_TID = "00";
					}
					this.VFI_TID = this.VFI_TID.Trim();
					if (this.VFI_TID.Length <= 0)
					{
						this.VFI_TID = "00";
					}
					if (this.VFI_TID.Length <= 0)
					{
						this.VFI_RespCode = "99";
						this.VFI_RespMess = "Terminal Number Missing";
						this.Trace("VFI_GetTelNo Err :" + this.VFI_RespMess);
						result = false;
					}
					else
					{
						if (this.VFI_TID.Length > 8)
						{
							this.VFI_TID = this.VFI_TID.Remove(8);
						}
						else
						{
							this.VFI_TID = this.VFI_TID.PadLeft(8, '0');
						}
						Socket socket = null;
						if (!this.Connect(ref socket))
						{
							this.VFI_RespCode = "93";
							this.VFI_RespMess = "Please check Router application is Running";
							this.Trace("VFI_GetTelNo Connect Error.");
							flag = false;
						}
						else
						{
							this.VFI_TxnDateTime = DateAndTime.Now.ToString("MMddHHmm");
							if (!this.VFI_InitTxn(ref socket, ref this.VFI_RespCode, ref this.VFI_RespMess))
							{
								flag = false;
							}
							else
							{
								if (modMain.Settings.Delay)
								{
									int millisecondsTimeout = modMain.Settings.DelayTimeout * 1000;
									Thread.Sleep(millisecondsTimeout);
									Application.DoEvents();
								}
								this.Ptr = 0;
								this.Tx[(int)this.Ptr] = this.STX[0];
								this.Ptr += 1;
								string text2 = this.CalculateMAC();
								this.Dump = string.Concat(new string[]
								{
									text,
									",",
									this.VFI_TID,
									",",
									text2.Substring(0, 8),
									","
								});
								if (this.Tx.Length <= this.Dump.Length + 3)
								{
									this.Tx = (byte[])Utils.CopyArray((Array)this.Tx, new byte[this.Dump.Length + 3 + 1]);
								}
								Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
								this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
								this.Tx[(int)this.Ptr] = this.ETX[0];
								this.Ptr += 1;
								this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
								this.Ptr += 1;
								if (!this.TCP_ExchangePkt(ref socket, this.Tx, this.Ptr))
								{
									this.Trace("VFI_GetTelNo Exchange pos error.");
									flag = false;
								}
								else
								{
									string left = "";
									DateTime dateTime = DateAndTime.Now.AddSeconds((double)modMain.Settings.TxnTimeout);
									while (true)
									{
										short num = this.TCP_RxBlock(ref socket, ref this.Rx, ref dateTime, ref this.VFI_RespMess, text);
										if (this.VFI_RespMess.Length <= 0)
										{
											this.VFI_RespMess = "No Response / Timeout ";
										}
										if (num == 0)
										{
											this.Trace("VFI_GetTelNo Err Rx :" + this.VFI_RespMess);
											if (!modMain.Settings.flgWaitRes)
											{
												goto IL_477;
											}
											this.Mess = this.VFI_RespMess + "\r\nAre you want to wait for response?";
											if (MessageBox.Show(this.Mess, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
											{
												break;
											}
										}
										if (!this.ProcessBlock(this.Rx, (int)num, ref left))
										{
											goto Block_22;
										}
										if (Operators.CompareString(left, "06", false) != 0)
										{
											goto IL_4C7;
										}
									}
									this.VFI_RespCode = "99";
									this.VFI_RespMess = "No Response / Timeout";
									flag = false;
									goto IL_4F0;
									IL_477:
									this.VFI_RespCode = "99";
									this.VFI_RespMess = "No Response / Timeout";
									flag = false;
									goto IL_4F0;
									Block_22:
									this.Trace("VFI_GetTelNo process Error.");
									flag = false;
									goto IL_4F0;
									IL_4C7:
									if (Conversions.ToInteger(this.VFI_RespCode) == 0)
									{
										flag = true;
									}
									if (this.VFI_RespMess.Length <= 0)
									{
										this.VFI_RespMess = "No Response / Timeout ";
									}
								}
							}
						}
						IL_4F0:
						if (!this.Disconnect(ref socket))
						{
							this.Trace("VFI_GetTelNo Disconnect Err");
						}
						this.Trace("VFI_GetTelNo Success");
						result = flag;
					}
				}
				catch (Exception expr_517)
				{
					ProjectData.SetProjectError(expr_517);
					Exception ex = expr_517;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("VFI_GetTelNo :" + ex.ToString());
					result = false;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private bool VFI_InitTxn(ref Socket TcpSocket, ref string RespCode, ref string RespMess)
		{
			string text = "01";
			checked
			{
				bool result;
				try
				{
					this.Trace("Init Txn starts.");
					this.Ptr = 0;
					this.Tx[(int)this.Ptr] = this.STX[0];
					this.Ptr += 1;
					this.Dump = string.Concat(new string[]
					{
						text,
						",",
						this.VFI_TID,
						",",
						this.VFI_TxnDateTime,
						","
					});
					if (this.Tx.Length <= this.Dump.Length + 3)
					{
						this.Tx = (byte[])Utils.CopyArray((Array)this.Tx, new byte[this.Dump.Length + 3 + 1]);
					}
					Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
					this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
					this.Tx[(int)this.Ptr] = this.ETX[0];
					this.Ptr += 1;
					this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
					this.Ptr += 1;
					if (!this.TCP_ExchangePkt(ref TcpSocket, this.Tx, this.Ptr))
					{
						this.Trace("Init Txn Exchange pos error.");
						result = false;
					}
					else
					{
						DateTime dateTime = DateAndTime.Now.AddSeconds((double)modMain.Settings.TxnTimeout);
						short num = this.TCP_RxBlock(ref TcpSocket, ref this.Rx, ref dateTime, ref RespMess, text);
						if (num == 0)
						{
							if (RespMess.Length <= 0)
							{
								RespMess = "No Response / Timeout ";
							}
							this.Trace("Init Txn Err :" + RespMess);
							RespCode = "99";
							RespMess = "Init Txn : " + RespMess;
							result = false;
						}
						else if (!this.ProcessBlock(this.Rx, (int)num))
						{
							this.Trace("Init Txn Process error.");
							RespCode = "99";
							RespMess = "Init Txn Process error.";
							result = false;
						}
						else
						{
							this.Trace("Init Txn success.");
							result = true;
						}
					}
				}
				catch (Exception expr_232)
				{
					ProjectData.SetProjectError(expr_232);
					Exception ex = expr_232;
					RespCode = "99";
					RespMess = ex.Message;
					this.Trace("Init Txn Err:" + ex.ToString());
					result = false;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		public bool VFI_GetAuth(string TID, string Amount, string ECRRcptNum, ref string RespCode, ref string RespMess)
		{
			bool result = false;
			try
			{
				this.VFI_Amount = Amount;
				this.VFI_TID = TID;
				this.VFI_ECRRcptNum = ECRRcptNum;
				result = this.VFI_GetAuth();
				RespCode = this.VFI_RespCode;
				RespMess = this.VFI_RespMess;
			}
			catch (Exception expr_32)
			{
				ProjectData.SetProjectError(expr_32);
				Exception ex = expr_32;
				RespCode = "99";
				RespMess = ex.Message;
				this.Trace("GetAuth1 Err:" + ex.ToString());
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public bool VFI_VoidTrans(string TID, string Amount, string VoidInvoiceNo, string ECRRcptNum, ref string RespCode, ref string RespMess)
		{
			bool result = false;
			try
			{
				this.VFI_Amount = Amount;
				this.VFI_TID = TID;
				this.VFI_ECRRcptNum = ECRRcptNum;
				this.VFI_VoidInvoiceNo = VoidInvoiceNo;
				result = this.VFI_VoidTrans();
				RespCode = this.VFI_RespCode;
				RespMess = this.VFI_RespMess;
			}
			catch (Exception expr_3A)
			{
				ProjectData.SetProjectError(expr_3A);
				Exception ex = expr_3A;
				RespCode = "99";
				RespMess = ex.Message;
				this.Trace("VFI_VoidTrans1 Err:" + ex.ToString());
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private bool VFI_Settle(ref string RespCode, ref string RespMess, string DccHost)
		{
			bool result = false;
			try
			{
				result = this.VFI_Settle();
				RespCode = this.VFI_RespCode;
				RespMess = this.VFI_RespMess;
			}
			catch (Exception expr_1B)
			{
				ProjectData.SetProjectError(expr_1B);
				Exception ex = expr_1B;
				RespCode = "99";
				RespMess = ex.Message;
				this.Trace("VFI_Settle1 Err:" + ex.ToString());
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private bool VFI_Report(ref string TID, ref string RespCode, ref string RespMess)
		{
			bool result = false;
			try
			{
				this.VFI_TID = TID;
				result = this.VFI_Report();
				RespCode = this.VFI_RespCode;
				RespMess = this.VFI_RespMess;
			}
			catch (Exception expr_23)
			{
				ProjectData.SetProjectError(expr_23);
				Exception ex = expr_23;
				RespCode = "99";
				RespMess = ex.Message;
				this.Trace("VFI_Report1 Err:" + ex.ToString());
				ProjectData.ClearProjectError();
			}
			return result;
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

                ManagementObjectCollection mReturn;
                ManagementObjectSearcher mSearch;
                mSearch = new ManagementObjectSearcher("Select * from Win32_SerialPort where Description ='SAGEM Telium'");
                mReturn = mSearch.Get();
                if (mReturn.Count < 1)
                {
                    foreach (ManagementObject mObj in mReturn)
                    {


                        //Serial_Port.PortName = modMain.Settings.PortName;
                        Serial_Port.PortName = mObj["DeviceID"].ToString();
                       

                    }
                }
                else
                {

                    Serial_Port.PortName ="COM1";
                }

                //Serial_Port.PortName = modMain.Settings.PortName;
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

		private bool Open_Port(ref SerialPort Serial_Port, string PortName, int BaudRate)
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
				Serial_Port.PortName = PortName;
				Serial_Port.BaudRate = BaudRate;
				Serial_Port.Parity = Parity.None;
				Serial_Port.DataBits = 8;
				Serial_Port.StopBits = StopBits.One;
				Serial_Port.Handshake = Handshake.None;
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

		private byte GetLrc(byte[] BPkt, int blen)
		{
			checked
			{
				byte result=0;
				try
				{
					byte b = 0;
					if (blen >= 2)
					{
						int arg_0E_0 = 1;
						int num = blen - 1;
						for (int i = arg_0E_0; i <= num; i++)
						{
							b ^= BPkt[i];
						}
						result = b;
					}
				}
				catch (Exception expr_24)
				{
					ProjectData.SetProjectError(expr_24);
					Exception ex = expr_24;
					this.Trace("GetLrc Error : " + ex.Message);
					result = 0;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private byte GetLrc(string BPkt, int blen)
		{
			checked
			{
				byte result=0;
				try
				{
					byte b = 0;
					if (blen >= 2)
					{
						int arg_0E_0 = 1;
						int num = blen - 1;
						for (int i = arg_0E_0; i <= num; i++)
						{
							b = (byte)((int)b ^ Strings.Asc(BPkt[i]));
							b &= 255;
						}
						result = b;
					}
				}
				catch (Exception expr_37)
				{
					ProjectData.SetProjectError(expr_37);
					Exception ex = expr_37;
					this.Trace("GetLrc Error : " + ex.Message);
					result = 0;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private short RxBlock(ref SerialPort Serial_port, ref byte[] RxPkt, short TimeoutType, ref string RespMess)
		{
			checked
			{
				short result;
				try
				{
					short num = 0;
					this.Trace("Rx Block Starts");
					while (num < 3)
					{
						num += 1;
						short num2 = 0;
						RxPkt = new byte[this.buffLen + 1];
						int num3;
						if (TimeoutType == 1)
						{
							num3 = (int)modMain.Settings.TxnTimeout;
						}
						else if (TimeoutType == 2)
						{
							num3 = (int)modMain.Settings.UploadTimeout;
						}
						else
						{
							num3 = (int)modMain.Settings.Timeout;
						}
						DateTime date = DateAndTime.Now.AddSeconds((double)num3);
						bool flag=false;
						bool flag2=false;
						while (DateAndTime.DateDiff(DateInterval.Second, date, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < 0L)
						{
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(1);
							}
							else
							{
								Thread.Sleep(0);
							}
							if (Serial_port.BytesToRead <= 0)
							{
								if (this.flgDoEvents)
								{
									Application.DoEvents();
								}
								if (this.flgSleep)
								{
									Thread.Sleep(5);
								}
								else
								{
									Thread.Sleep(1);
								}
							}
							else
							{
                                flag = false;
								if (!flag)
								{
									num2 = 0;
								}
								RxPkt[(int)num2] = (byte)Serial_port.ReadByte();
								if (RxPkt[(int)num2] == 2 & !flag2)
								{
									flag2 = false;
									flag = true;
								}
								if (flag2)
								{
									break;
								}
								if (flag & RxPkt[(int)num2] == 3)
								{
									flag2 = true;
								}
								num2 += 1;
							}
						}
						this.Trace("RX : ", RxPkt, (int)num2);
						if (DateAndTime.DateDiff(DateInterval.Second, date, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) >= 0L & num2 <= 0)
						{
							RespMess = "Timeout / No Response from Device";
							this.Trace("Process Block Err - " + this.VFI_RespMess);
							result = 0;
							return result;
						}
						flag2 = false;
						flag = false;
						byte lrc = this.GetLrc(this.Rx, (int)num2);
						if (lrc == this.Rx[(int)num2])
						{
							Serial_port.Write(this.ACK, 0, 1);
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(10);
							}
							else
							{
								Thread.Sleep(1);
							}
							this.Trace("Rx Block - ACK sent");
							result = num2;
							return result;
						}
						Serial_port.Write(this.NAK, 0, 1);
						if (this.flgDoEvents)
						{
							Application.DoEvents();
						}
						if (this.flgSleep)
						{
							Thread.Sleep(10);
						}
						else
						{
							Thread.Sleep(1);
						}
						this.Trace("Rx Block - NAK sent");
					}
					RespMess = "Timeout / No Response from Device";
					this.Trace("Process Block Err - " + this.VFI_RespMess);
					result = 0;
				}
				catch (Exception expr_23F)
				{
					ProjectData.SetProjectError(expr_23F);
					Exception ex = expr_23F;
					RespMess = ex.Message;
					this.Trace("Rx Block Err - " + ex.ToString());
					result = 0;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private short RxBlock(ref SerialPort Serial_port, ref byte[] RxPkt, short TimeoutType, ref string RespMess, string strMsgType)
		{
			string text = "";
			checked
			{
				try
				{
					short num = 0;
					this.Trace("Rx Block Starts");
					while (num < 3)
					{
						num += 1;
						short num2 = 0;
						RxPkt = new byte[this.buffLen + 1];
						int num3;
						if (TimeoutType == 1)
						{
							num3 = (int)modMain.Settings.TxnTimeout;
						}
						else if (TimeoutType == 2)
						{
							num3 = (int)modMain.Settings.UploadTimeout;
						}
						else
						{
							num3 = (int)modMain.Settings.Timeout;
						}
						DateTime date = DateAndTime.Now.AddSeconds((double)num3);
						bool flag=false;
						bool flag2=false;
						while (DateAndTime.DateDiff(DateInterval.Second, date, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < 0L)
						{
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(1);
							}
							else
							{
								Thread.Sleep(0);
							}
							if (Serial_port.BytesToRead <= 0)
							{
								if (this.flgDoEvents)
								{
									Application.DoEvents();
								}
								if (this.flgSleep)
								{
									Thread.Sleep(5);
								}
								else
								{
									Thread.Sleep(1);
								}
							}
							else
							{
								if (RxPkt.Length <= (int)num2)
								{
									RxPkt = (byte[])Utils.CopyArray((Array)RxPkt, new byte[(int)(num2 + 1)]);
								}
								if (!flag)
								{
									num2 = 0;
								}
								RxPkt[(int)num2] = (byte)Serial_port.ReadByte();
								if (RxPkt[(int)num2] == 2 & !flag2)
								{
									flag2 = false;
									flag = true;
								}
								if (flag2)
								{
									break;
								}
								if (flag & RxPkt[(int)num2] == 3)
								{
									flag2 = true;
								}
								num2 += 1;
							}
						}
						this.Trace("RX : ", RxPkt, (int)num2);
						if (DateAndTime.DateDiff(DateInterval.Second, date, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) >= 0L & num2 <= 0)
						{
							RespMess = "Timeout / No Response from Device";
							this.Trace("Process Block Err - " + this.VFI_RespMess);
							short result = 0;
							return result;
						}
						flag2 = false;
						flag = false;
						byte lrc = this.GetLrc(this.Rx, (int)num2);
						if (num2 > 2)
						{
							text = Encoding.ASCII.GetString(RxPkt, 1, 2);
						}
						if (Operators.CompareString(text, strMsgType, false) == 0 & lrc == RxPkt[(int)num2])
						{
							Serial_port.Write(this.ACK, 0, 1);
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(10);
							}
							else
							{
								Thread.Sleep(1);
							}
							this.Trace("Rx Block - ACK sent");
							short result = num2;
							return result;
						}
						try
						{
							if (Serial_port.BytesToRead > 0)
							{
								this.Dump = Serial_port.ReadExisting();
								this.Trace("Junk : " + this.Dump);
							}
						}
						catch (Exception expr_250)
						{
							ProjectData.SetProjectError(expr_250);
							ProjectData.ClearProjectError();
						}
						if (Operators.CompareString(text, strMsgType, false) != 0)
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = string.Concat(new string[]
							{
								"Invalid Response(",
								text,
								"-",
								strMsgType,
								") from Device"
							});
							this.Trace("RxBlock Err - " + this.VFI_RespMess);
							return 0;
						}
						this.Trace("LRC Cal :" + lrc.ToString() + "," + Conversions.ToString(RxPkt[(int)num2]));
						Serial_port.Write(this.NAK, 0, 1);
						if (this.flgDoEvents)
						{
							Application.DoEvents();
						}
						if (this.flgSleep)
						{
							Thread.Sleep(10);
						}
						else
						{
							Thread.Sleep(1);
						}
						this.Trace("Rx Block - NAK sent");
					}
					RespMess = "Timeout / No Response from Device";
					this.Trace("Process Block Err - " + this.VFI_RespMess);
				}
				catch (Exception expr_35C)
				{
					ProjectData.SetProjectError(expr_35C);
					Exception ex = expr_35C;
					RespMess = ex.Message;
					this.Trace("Rx Block Err - " + ex.ToString());
					ProjectData.ClearProjectError();
				}
				return 0;
			}
		}

		private short RxBlock(ref SerialPort Serial_port, ref byte[] RxPkt, ref DateTime dtTimeout, ref string RespMess, string strMsgType)
		{
			string text = "";
			checked
			{
				try
				{
					short num = 1;
					this.Trace("Rx Block Starts");
					while (num < 3)
					{
						short num2 = 0;
						RxPkt = new byte[this.buffLen + 1];
						bool flag=false;
						bool flag2=false;
						while (DateAndTime.DateDiff(DateInterval.Second, dtTimeout, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < 0L)
						{
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(1);
							}
							else
							{
								Thread.Sleep(0);
							}
							if (Serial_port.BytesToRead <= 0)
							{
								if (this.flgDoEvents)
								{
									Application.DoEvents();
								}
								if (this.flgSleep)
								{
									Thread.Sleep(5);
								}
								else
								{
									Thread.Sleep(1);
								}
							}
							else
							{
								if (RxPkt.Length <= (int)num2)
								{
									RxPkt = (byte[])Utils.CopyArray((Array)RxPkt, new byte[(int)(num2 + 1)]);
								}
								if (!flag)
								{
									num2 = 0;
								}
								RxPkt[(int)num2] = (byte)Serial_port.ReadByte();
								if (RxPkt[(int)num2] == 2 & !flag2)
								{
									flag2 = false;
									flag = true;
								}
								if (flag2)
								{
									break;
								}
								if (!flag)
								{
									num2 = 0;
								}
								if (flag & RxPkt[(int)num2] == 3)
								{
									flag2 = true;
								}
								num2 += 1;
							}
						}
						this.Trace("RX : ", RxPkt, (int)num2);
						if (DateAndTime.DateDiff(DateInterval.Second, dtTimeout, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) >= 0L & num2 <= 0)
						{
							RespMess = "Timeout / No Response from Device";
							this.Trace("Process Block Err - " + this.VFI_RespMess);
							short result = 0;
							return result;
						}
						flag2 = false;
						flag = false;
						byte lrc = this.GetLrc(this.Rx, (int)num2);
						if (num2 > 2)
						{
							text = Encoding.ASCII.GetString(RxPkt, 1, 2);
						}
						if ((Operators.CompareString(text, strMsgType, false) == 0 | Operators.CompareString(text, "06", false) == 0) & lrc == RxPkt[(int)num2])
						{
							Serial_port.Write(this.ACK, 0, 1);
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(10);
							}
							else
							{
								Thread.Sleep(1);
							}
							this.Trace("Rx Block - ACK sent");
							short result = num2;
							return result;
						}
						try
						{
							if (Serial_port.BytesToRead > 0)
							{
								this.Dump = Serial_port.ReadExisting();
								this.Trace("Junk : " + this.Dump);
							}
						}
						catch (Exception expr_228)
						{
							ProjectData.SetProjectError(expr_228);
							ProjectData.ClearProjectError();
						}
						if (Operators.CompareString(text, strMsgType, false) != 0)
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = string.Concat(new string[]
							{
								"Invalid Response(",
								text,
								"-",
								strMsgType,
								") from Device"
							});
							this.Trace("RxBlock Err - " + this.VFI_RespMess);
							return 0;
						}
						if (Operators.CompareString(strMsgType, "06", false) == 0)
						{
							this.Trace("LRC Cal :" + lrc.ToString() + "," + Conversions.ToString(RxPkt[(int)num2]));
							Serial_port.Write(this.NAK, 0, 1);
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(10);
							}
							else
							{
								Thread.Sleep(1);
							}
							this.Trace("Rx Block - NAK sent");
							dtTimeout = DateAndTime.Now.AddSeconds((double)modMain.Settings.TxnTimeout);
							num += 1;
						}
					}
					RespMess = "Timeout / No Response from Device";
					this.Trace("Rx Block Err - " + this.VFI_RespMess);
				}
				catch (Exception expr_36D)
				{
					ProjectData.SetProjectError(expr_36D);
					Exception ex = expr_36D;
					RespMess = ex.Message;
					this.Trace("Rx Block Err - " + ex.ToString());
					ProjectData.ClearProjectError();
				}
				return 0;
			}
		}

		private short RxBlock(ref SerialPort Serial_port, ref byte[] RxPkt, short TimeoutType)
		{
			checked
			{
				short result;
				try
				{
					short num = 0;
					short num2 = 0;
					RxPkt = new byte[this.buffLen + 1];
					this.Trace("Rx Block Starts");
					while (num < 3)
					{
						num += 1;
						int num3;
						if (TimeoutType == 1)
						{
							num3 = (int)modMain.Settings.TxnTimeout;
						}
						else
						{
							num3 = (int)modMain.Settings.Timeout;
						}
						DateTime date = DateAndTime.Now.AddSeconds((double)num3);
						bool flag=false;
						bool flag2=false;
						while (DateAndTime.DateDiff(DateInterval.Second, date, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < 0L)
						{
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(1);
							}
							else
							{
								Thread.Sleep(0);
							}
							if (Serial_port.BytesToRead <= 0)
							{
								if (this.flgDoEvents)
								{
									Application.DoEvents();
								}
								if (this.flgSleep)
								{
									Thread.Sleep(10);
								}
								else
								{
									Thread.Sleep(1);
								}
							}
							else
							{
								if (!flag)
								{
									num2 = 0;
								}
								RxPkt[(int)num2] = (byte)Serial_port.ReadByte();
								if (RxPkt[(int)num2] == 2 & !flag2)
								{
									flag2 = false;
									flag = true;
								}
								if (flag2)
								{
									break;
								}
								if (flag & RxPkt[(int)num2] == 3)
								{
									flag2 = true;
								}
								num2 += 1;
							}
						}
						this.Trace("RX : ", RxPkt, (int)num2);
						if (DateAndTime.DateDiff(DateInterval.Second, date, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) >= 0L & num2 <= 0)
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = "Timeout / No Response from Device";
							this.Trace("Process Block Err - " + this.VFI_RespMess);
							result = 0;
							return result;
						}
						flag2 = false;
						flag = false;
						byte lrc = this.GetLrc(this.Rx, (int)num2);
						if (lrc == this.Rx[(int)num2])
						{
							Serial_port.Write(this.ACK, 0, 1);
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(10);
							}
							else
							{
								Thread.Sleep(1);
							}
							this.Trace("Rx Block - ACK sent");
							result = num2;
							return result;
						}
						Serial_port.Write(this.NAK, 0, 1);
						if (this.flgDoEvents)
						{
							Application.DoEvents();
						}
						if (this.flgSleep)
						{
							Thread.Sleep(10);
						}
						else
						{
							Thread.Sleep(1);
						}
						this.Trace("Rx Block - NAK sent");
					}
					this.VFI_RespCode = "99";
					this.VFI_RespMess = "Timeout / No Response from Device";
					this.Trace("Process Block Err - " + this.VFI_RespMess);
					result = 0;
				}
				catch (Exception expr_24A)
				{
					ProjectData.SetProjectError(expr_24A);
					Exception ex = expr_24A;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("Rx Block Err - " + ex.ToString());
					result = 0;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private bool ProcessBlock(byte[] RxPkt, int Llen)
		{
			checked
			{
				try
				{
					this.Trace("Process Block.");
					this.Dump = Encoding.ASCII.GetString(RxPkt, 0, Llen);
					string[] array = this.Dump.Split(new char[]
					{
						','
					});
					if (this.Dump.Length <= 0)
					{
						bool result = false;
						return result;
					}
					string left = array[0].Substring(1, 2);
					if (Operators.CompareString(left, "01", false) == 0)
					{
						this.VFI_TID = array[1];
						this.VFI_PTID = this.VFI_TID;
						this.VFI_TslNo = array[2];
						this.VFI_MAC = array[3];
						if (array.Length > 5)
						{
							this.VFI_MName = array[4];
						}
						if (array.Length > 6)
						{
							this.Dump = array[5];
						}
						if (this.VerifyMAC())
						{
							if (this.ValidateLic(this.Dump))
							{
								bool result = true;
								return result;
							}
						}
					}
					else if (Operators.CompareString(left, "02", false) == 0)
					{
						this.VFI_RespCode = array[1];
						this.VFI_RespMess = array[2];
						this.VFI_TransType = array[3];
						this.VFI_ECRRcptNum = array[4];
						this.VFI_Amount = array[5];
						this.VFI_CardNum = array[6];
						this.VFI_Expiry = array[7];
						this.VFI_CHName = array[8];
						this.VFI_MessNum = array[9];
						this.VFI_CardName = array[10];
						this.VFI_TransSource = array[11];
						this.VFI_AuthMode = array[12];
						this.VFI_CHVerification = array[13];
						this.VFI_ApprovalCode = array[14];
						this.VFI_DateTime = array[15];
						this.VFI_EMV_Label = array[16];
						this.VFI_EMV_AID = array[17];
						this.VFI_EMV_TVR = array[18];
						this.VFI_EMV_TSI = array[19];
						this.VFI_AdditionalInfo = array[21];
						this.VFI_EMV_AC = array[20];
						this.VFI_TID = array[22];
						this.VFI_Batch = array[23];
						this.VFI_MID = array[24];
						this.VFI_RefNo = array[25];
						this.VFI_InvoiceNo = array[26];
						this.VFI_MAC = array[27];
						this.VFI_EMV_CID = array[28];
						this.VFI_CurrCode = array[29];
						if (this.VerifyMAC())
						{
							bool result = true;
							return result;
						}
					}
					else if (Operators.CompareString(left, "03", false) == 0)
					{
						this.VFI_RespCode = array[1];
						this.VFI_RespMess = array[2];
						this.VFI_TransType = array[3];
						this.VFI_ECRRcptNum = array[4];
						this.VFI_Amount = array[5];
						this.VFI_CardNum = array[6];
						this.VFI_Expiry = array[7];
						this.VFI_CHName = array[8];
						this.VFI_MessNum = array[9];
						this.VFI_CardName = array[10];
						this.VFI_TransSource = array[11];
						this.VFI_AuthMode = array[12];
						this.VFI_CHVerification = array[13];
						this.VFI_ApprovalCode = array[14];
						this.VFI_DateTime = array[15];
						this.VFI_EMV_Label = array[16];
						this.VFI_EMV_AID = array[17];
						this.VFI_EMV_TVR = array[18];
						this.VFI_EMV_TSI = array[19];
						this.VFI_EMV_AC = array[20];
						this.VFI_VoidInvoiceNo = array[21];
						this.VFI_TID = array[22];
						this.VFI_Batch = array[23];
						this.VFI_MID = array[24];
						this.VFI_RefNo = array[25];
						this.VFI_InvoiceNo = array[26];
						this.VFI_MAC = array[27];
						this.VFI_EMV_CID = array[28];
						this.VFI_CurrCode = array[29];
						if (this.VerifyMAC())
						{
							bool result = true;
							return result;
						}
					}
					else if (Operators.CompareString(left, "04", false) == 0)
					{
						this.VFI_RespCode = array[1];
						this.VFI_RespMess = array[2];
						this.VFI_DBCount = array[3];
						this.VFI_CRCount = array[4];
						this.VFI_DBAmount = array[5];
						this.VFI_CRAmount = array[6];
						this.VFI_TID = array[7];
						this.VFI_Batch = array[8];
						this.VFI_MID = array[9];
						this.VFI_RefNo = array[10];
						this.VFI_MAC = array[11];
						this.VFI_CurrCode = array[12];
						if (this.VerifyMAC())
						{
							bool result = true;
							return result;
						}
					}
					else if (Operators.CompareString(left, "05", false) == 0)
					{
						this.VFI_RespCode = array[1];
						this.VFI_RespMess = array[2];
						this.VFI_DBCount = array[3];
						this.VFI_CRCount = array[4];
						this.VFI_DBAmount = array[5];
						this.VFI_CRAmount = array[6];
						this.VFI_TID = array[7];
						this.VFI_Batch = array[8];
						this.VFI_MID = array[9];
						this.VFI_MAC = array[10];
						this.VFI_CurrCode = array[11];
						if (this.VerifyMAC())
						{
							bool result = true;
							return result;
						}
					}
					else
					{
						bool result;
						if (Operators.CompareString(left, "06", false) != 0)
						{
							this.VFI_RespCode = array[1];
							this.VFI_RespMess = array[2];
							result = true;
							return result;
						}
						byte[] array2 = new byte[1];
						int num = array[0].Length + 1 + array[1].Length + 1;
						int num2 = Conversions.ToInteger(array[1]);
						byte[] array3 = new byte[num2 - 1 + 1];
						Array.Copy(RxPkt, num, array3, 0, num2);
						this.VFI_MAC = this.Dump.Substring(num + num2 + 1, 8);
						if (!this.VerifyMAC())
						{
							result = false;
							return result;
						}
						if (this.SendHost(array3, ref array2))
						{
							result = true;
							return result;
						}
						result = false;
						return result;
					}
				}
				catch (Exception expr_516)
				{
					ProjectData.SetProjectError(expr_516);
					Exception ex = expr_516;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("Process Block Err - " + ex.Message);
					ProjectData.ClearProjectError();
				}
				return false;
			}
		}

		private bool ProcessBlock(byte[] RxPkt, int Llen, ref string strMsgType)
		{
			bool result = false;
			try
			{
				this.Trace("Process Block.");
				this.Dump = Encoding.ASCII.GetString(RxPkt, 0, Llen);
				string[] array = this.Dump.Split(new char[]
				{
					','
				});
				if (this.Dump.Length > 0)
				{
					strMsgType = array[0].Substring(1, 2);
					string left = strMsgType;
					if (Operators.CompareString(left, "01", false) == 0)
					{
						this.VFI_TID = array[1];
						this.VFI_TslNo = array[2];
						this.VFI_MAC = array[3];
						if (array.Length > 5)
						{
							this.VFI_MName = array[4];
						}
						if (array.Length > 6)
						{
							this.Dump = array[5];
						}
						if (this.VerifyMAC())
						{
							if (this.ValidateLic(this.Dump))
							{
								result = true;
							}
						}
					}
					else if (Operators.CompareString(left, "02", false) == 0)
					{
						this.GetAuth(array);
						if (this.VerifyMAC())
						{
							result = true;
						}
					}
					else if (Operators.CompareString(left, "03", false) == 0)
					{
						this.GetVoid(array);
						if (this.VerifyMAC())
						{
							result = true;
						}
					}
					else if (Operators.CompareString(left, "04", false) == 0)
					{
						this.GetSettle(array);
						if (this.VerifyMAC())
						{
							result = true;
						}
					}
					else if (Operators.CompareString(left, "05", false) == 0)
					{
						this.GetReport(array);
						if (this.VerifyMAC())
						{
							result = true;
						}
					}
					else if (Operators.CompareString(left, "06", false) == 0)
					{
						if (this.SendHost(array[1]))
						{
							result = true;
						}
					}
					else if (Operators.CompareString(left, "07", false) == 0)
					{
						this.VFI_RespCode = array[1];
						this.VFI_RespMess = array[2];
						this.VFI_TelNo = array[3];
						this.VFI_MAC = array[4];
						if (this.VerifyMAC())
						{
							result = true;
						}
					}
					else
					{
						this.VFI_RespCode = array[1];
						this.VFI_RespMess = array[2];
						result = true;
					}
				}
			}
			catch (Exception expr_1FB)
			{
				ProjectData.SetProjectError(expr_1FB);
				Exception ex = expr_1FB;
				this.VFI_RespCode = "99";
				this.VFI_RespMess = ex.Message;
				this.Trace("Process Block Err - " + ex.Message);
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private void GetAuth(string[] TFields)
		{
			try
			{
				this.VFI_RespCode = TFields[1];
				this.VFI_RespMess = TFields[2];
				this.VFI_TransType = TFields[3];
				this.VFI_ECRRcptNum = TFields[4];
				this.VFI_Amount = TFields[5];
				this.VFI_CardNum = TFields[6];
				this.VFI_Expiry = TFields[7];
				this.VFI_CHName = TFields[8];
				this.VFI_MessNum = TFields[9];
				this.VFI_CardName = TFields[10];
				this.VFI_TransSource = TFields[11];
				this.VFI_AuthMode = TFields[12];
				this.VFI_CHVerification = TFields[13];
				this.VFI_ApprovalCode = TFields[14];
				this.VFI_DateTime = TFields[15];
				this.VFI_EMV_Label = TFields[16];
				this.VFI_EMV_AID = TFields[17];
				this.VFI_EMV_TVR = TFields[18];
				this.VFI_EMV_TSI = TFields[19];
				this.VFI_AdditionalInfo = TFields[21];
				this.VFI_EMV_AC = TFields[20];
				this.VFI_TID = TFields[22];
				this.VFI_Batch = TFields[23];
				this.VFI_MID = TFields[24];
				this.VFI_RefNo = TFields[25];
				this.VFI_InvoiceNo = TFields[26];
				this.VFI_MAC = TFields[27];
				this.VFI_EMV_CID = TFields[28];
				this.VFI_CurrCode = TFields[29];
			}
			catch (Exception expr_11C)
			{
				ProjectData.SetProjectError(expr_11C);
				ProjectData.ClearProjectError();
			}
		}

		private void GetVoid(string[] TFields)
		{
			try
			{
				this.VFI_RespCode = TFields[1];
				this.VFI_RespMess = TFields[2];
				this.VFI_TransType = TFields[3];
				this.VFI_ECRRcptNum = TFields[4];
				this.VFI_Amount = TFields[5];
				this.VFI_CardNum = TFields[6];
				this.VFI_Expiry = TFields[7];
				this.VFI_CHName = TFields[8];
				this.VFI_MessNum = TFields[9];
				this.VFI_CardName = TFields[10];
				this.VFI_TransSource = TFields[11];
				this.VFI_AuthMode = TFields[12];
				this.VFI_CHVerification = TFields[13];
				this.VFI_ApprovalCode = TFields[14];
				this.VFI_DateTime = TFields[15];
				this.VFI_EMV_Label = TFields[16];
				this.VFI_EMV_AID = TFields[17];
				this.VFI_EMV_TVR = TFields[18];
				this.VFI_EMV_TSI = TFields[19];
				this.VFI_EMV_AC = TFields[20];
				this.VFI_VoidInvoiceNo = TFields[21];
				this.VFI_TID = TFields[22];
				this.VFI_Batch = TFields[23];
				this.VFI_MID = TFields[24];
				this.VFI_RefNo = TFields[25];
				this.VFI_InvoiceNo = TFields[26];
				this.VFI_MAC = TFields[27];
				this.VFI_EMV_CID = TFields[28];
				this.VFI_CurrCode = TFields[29];
			}
			catch (Exception expr_11C)
			{
				ProjectData.SetProjectError(expr_11C);
				ProjectData.ClearProjectError();
			}
		}

		private void GetSettle(string[] TFields)
		{
			try
			{
				this.VFI_RespCode = TFields[1];
				this.VFI_RespMess = TFields[2];
				this.VFI_DBCount = TFields[3];
				this.VFI_CRCount = TFields[4];
				this.VFI_DBAmount = TFields[5];
				this.VFI_CRAmount = TFields[6];
				this.VFI_TID = TFields[7];
				this.VFI_Batch = TFields[8];
				this.VFI_MID = TFields[9];
				this.VFI_RefNo = TFields[10];
				this.VFI_MAC = TFields[11];
				this.VFI_CurrCode = TFields[12];
			}
			catch (Exception expr_72)
			{
				ProjectData.SetProjectError(expr_72);
				ProjectData.ClearProjectError();
			}
		}

		private void GetReport(string[] TFields)
		{
			try
			{
				this.VFI_RespCode = TFields[1];
				this.VFI_RespMess = TFields[2];
				this.VFI_DBCount = TFields[3];
				this.VFI_CRCount = TFields[4];
				this.VFI_DBAmount = TFields[5];
				this.VFI_CRAmount = TFields[6];
				this.VFI_TID = TFields[7];
				this.VFI_Batch = TFields[8];
				this.VFI_MID = TFields[9];
				this.VFI_MAC = TFields[10];
				this.VFI_CurrCode = TFields[11];
			}
			catch (Exception expr_68)
			{
				ProjectData.SetProjectError(expr_68);
				ProjectData.ClearProjectError();
			}
		}

		private bool ExchangePkt(ref SerialPort Serial_Port, byte[] TxPkt, short Llen)
		{
			checked
			{
				bool result;
				try
				{
					short num = 0;
					byte b = 0;
					this.Trace("Exchange Pkt Starts");
					while (num < 3)
					{
						Serial_Port.Write(this.Tx, 0, (int)Llen);
						if (this.flgDoEvents)
						{
							Application.DoEvents();
						}
						if (this.flgSleep)
						{
							Thread.Sleep(10);
						}
						else
						{
							Thread.Sleep(1);
						}
						this.Trace("Exchange Pkt Tx: ", TxPkt, (int)Llen);
						int timeout = (int)modMain.Settings.Timeout;
						DateTime date = DateAndTime.Now.AddSeconds((double)timeout);
						while (DateAndTime.DateDiff(DateInterval.Second, date, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < 0L)
						{
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(5);
							}
							else
							{
								Thread.Sleep(1);
							}
							if (Serial_Port.BytesToRead > 0)
							{
								b = (byte)Serial_Port.ReadByte();
								this.Trace("Exchange Pkt Rx : " + Conversion.Hex(b));
								if (b == this.ACK[0])
								{
									break;
								}
								if (b == this.NAK[0])
								{
									break;
								}
							}
							else
							{
								if (this.flgDoEvents)
								{
									Application.DoEvents();
								}
								if (this.flgSleep)
								{
									Thread.Sleep(10);
								}
								else
								{
									Thread.Sleep(1);
								}
							}
						}
						if (b == this.ACK[0])
						{
							break;
						}
						num += 1;
					}
					if (num >= 3)
					{
						this.VFI_RespCode = "99";
						this.VFI_RespMess = "Timeout / No Response from Device";
						this.Trace("Exchange Pkt Err - " + this.VFI_RespMess);
						result = false;
					}
					else
					{
						this.Trace("Exchange Pkt Ends");
						result = true;
					}
				}
				catch (Exception expr_174)
				{
					ProjectData.SetProjectError(expr_174);
					Exception ex = expr_174;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("Exchange Pkt Err - " + this.VFI_RespMess);
					result = false;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private short TCP_RxBlock(ref Socket TcpSocket, ref byte[] RxPkt, ref DateTime dtTimeout, ref string RespMess, string strMsgType)
		{
			string text = "";
			byte[] array = new byte[1];
			checked
			{
				try
				{
					short num = 1;
					this.Trace("Rx Block Starts");
					while (num < 3)
					{
						short num2 = 0;
						RxPkt = new byte[this.buffLen + 1];
						bool flag=false;
						bool flag2=false;
						while (DateAndTime.DateDiff(DateInterval.Second, dtTimeout, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < 0L)
						{
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(1);
							}
							else
							{
								Thread.Sleep(0);
							}
							if (TcpSocket.Available < 1)
							{
								if (!this.chkConnction(ref TcpSocket))
								{
									short result = 0;
									return result;
								}
								if (this.flgDoEvents)
								{
									Application.DoEvents();
								}
								if (this.flgSleep)
								{
									Thread.Sleep(5);
								}
								else
								{
									Thread.Sleep(1);
								}
							}
							else
							{
								int num3 = TcpSocket.Receive(array);
								if (num3 >= 1)
								{
									if (RxPkt.Length <= (int)num2)
									{
										RxPkt = (byte[])Utils.CopyArray((Array)RxPkt, new byte[(int)(num2 + 1)]);
									}
									if (!flag)
									{
										num2 = 0;
									}
									RxPkt[(int)num2] = array[0];
									if (RxPkt[(int)num2] == 2 & !flag2)
									{
										flag2 = false;
										flag = true;
									}
									if (flag2)
									{
										break;
									}
									if (flag & RxPkt[(int)num2] == 3)
									{
										flag2 = true;
									}
									num2 += 1;
								}
							}
						}
						this.Trace("RX : ", RxPkt, (int)num2);
						if (DateAndTime.DateDiff(DateInterval.Second, dtTimeout, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) >= 0L & num2 <= 0)
						{
							RespMess = "Timeout / No Response from Device";
							this.Trace("Process Block Err - " + this.VFI_RespMess);
							short result = 0;
							return result;
						}
						flag2 = false;
						flag = false;
						byte lrc = this.GetLrc(this.Rx, (int)num2);
						if (num2 > 2)
						{
							text = Encoding.ASCII.GetString(RxPkt, 1, 2);
						}
						if ((Operators.CompareString(text, strMsgType, false) == 0 | Operators.CompareString(text, "06", false) == 0) & lrc == RxPkt[(int)num2])
						{
							TcpSocket.Send(this.ACK);
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(10);
							}
							else
							{
								Thread.Sleep(1);
							}
							this.Trace("Rx Block - ACK sent");
							short result = num2;
							return result;
						}
						try
						{
							if (TcpSocket.Available > 0)
							{
								this.Trace("Junk : " + this.Dump);
							}
						}
						catch (Exception expr_239)
						{
							ProjectData.SetProjectError(expr_239);
							ProjectData.ClearProjectError();
						}
						if (Operators.CompareString(text, strMsgType, false) != 0)
						{
							this.VFI_RespCode = "99";
							this.VFI_RespMess = string.Concat(new string[]
							{
								"Invalid Response(",
								text,
								"-",
								strMsgType,
								") from Device"
							});
							this.Trace("RxBlock Err - " + this.VFI_RespMess);
							return 0;
						}
						if (Operators.CompareString(strMsgType, "06", false) == 0)
						{
							this.Trace("LRC Cal :" + lrc.ToString() + "," + Conversions.ToString(RxPkt[(int)num2]));
							TcpSocket.Send(this.NAK);
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(10);
							}
							else
							{
								Thread.Sleep(1);
							}
							this.Trace("Rx Block - NAK sent");
							dtTimeout = DateAndTime.Now.AddSeconds((double)modMain.Settings.TxnTimeout);
							num += 1;
						}
					}
					RespMess = "Timeout / No Response from Device";
					this.Trace("Rx Block Err - " + this.VFI_RespMess);
				}
				catch (Exception expr_37D)
				{
					ProjectData.SetProjectError(expr_37D);
					Exception ex = expr_37D;
					RespMess = ex.Message;
					this.Trace("Rx Block Err - " + ex.ToString());
					ProjectData.ClearProjectError();
				}
				return 0;
			}
		}

		private bool TCP_ExchangePkt(ref Socket TcpSocket, byte[] TxPkt, short Llen)
		{
			byte[] array = new byte[1];
			checked
			{
				bool result=false;
				try
				{
					short num = 0;
					array[0] = 0;
					this.Trace("Exchange Pkt Starts");
					while (num < 3)
					{
						if (!this.chkConnction(ref TcpSocket))
						{
							return result;
						}
						TcpSocket.Send(this.Tx, 0, (int)Llen, SocketFlags.None);
						if (this.flgDoEvents)
						{
							Application.DoEvents();
						}
						if (this.flgSleep)
						{
							Thread.Sleep(10);
						}
						else
						{
							Thread.Sleep(1);
						}
						this.Trace("Exchange Pkt Tx: ", TxPkt, (int)Llen);
						int timeout = (int)modMain.Settings.Timeout;
						DateTime date = DateAndTime.Now.AddSeconds((double)timeout);
						while (DateAndTime.DateDiff(DateInterval.Second, date, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < 0L)
						{
							if (this.flgDoEvents)
							{
								Application.DoEvents();
							}
							if (this.flgSleep)
							{
								Thread.Sleep(5);
							}
							else
							{
								Thread.Sleep(1);
							}
							if (TcpSocket.Available >= 1 && TcpSocket.Receive(array, 0, 1, SocketFlags.None) >= 1)
							{
								this.Trace("Exchange Pkt Rx : " + Conversions.ToString(array[0]));
								if (array[0] == this.ACK[0] || array[0] == this.NAK[0])
								{
									break;
								}
							}
						}
						if (array[0] == this.ACK[0])
						{
							break;
						}
						num += 1;
					}
					if (num >= 3)
					{
						this.VFI_RespCode = "99";
						this.VFI_RespMess = "Timeout / No Response from Device";
						this.Trace("Exchange Pkt Err - " + this.VFI_RespMess);
						result = false;
					}
					else
					{
						this.Trace("Exchange Pkt Ends");
						result = true;
					}
				}
				catch (Exception expr_171)
				{
					ProjectData.SetProjectError(expr_171);
					Exception ex = expr_171;
					this.VFI_RespCode = "99";
					this.VFI_RespMess = ex.Message;
					this.Trace("Exchange Pkt Err - " + this.VFI_RespMess);
					result = false;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private bool SendHost(byte[] ReqPkt, ref byte[] ResPkt)
		{
			TcpClient tcpClient = null;
			Socket socket = null;
			bool flag = false;
			try
			{
				if (this.Connect(ref tcpClient, ref socket))
				{
					if (this.TCP_TransmitPacket(ref socket, ReqPkt))
					{
						if (this.TCP_ReadBuffer(ref socket, ref ResPkt))
						{
							flag = true;
						}
					}
				}
			}
			catch (Exception expr_32)
			{
				ProjectData.SetProjectError(expr_32);
				Exception ex = expr_32;
				this.Trace(ex.Message);
				this.Trace(ex.ToString());
				ProjectData.ClearProjectError();
			}
			checked
			{
				try
				{
					string str = this.CalculateMAC();
					this.Ptr = 0;
					this.Tx[(int)this.Ptr] = this.STX[0];
					this.Ptr += 1;
					this.Dump = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("06,", Interaction.IIf(flag, "00", "99")), ","), ResPkt.Length.ToString()), ","));
					Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
					this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
					if (flag)
					{
						Array.Copy(this.Tx, (int)this.Ptr, ResPkt, 0, ResPkt.Length);
						this.Ptr = (short)((int)this.Ptr + ResPkt.Length);
					}
					this.Dump = "," + str + ",";
					Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
					this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
					this.Tx[(int)this.Ptr] = this.ETX[0];
					this.Ptr += 1;
					this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
					this.Ptr += 1;
					if (!this.ExchangePkt(ref this.Serial_Port, this.Tx, this.Ptr))
					{
						this.Trace("VFI_GetAuth Exchange pos error.");
						this.VFI_RespCode = "92";
						this.VFI_RespMess = "Send Error";
						flag = false;
					}
				}
				catch (Exception expr_237)
				{
					ProjectData.SetProjectError(expr_237);
					Exception ex2 = expr_237;
					this.Trace(ex2.Message);
					this.Trace(ex2.ToString());
					ProjectData.ClearProjectError();
				}
				try
				{
					socket.Shutdown(SocketShutdown.Both);
					tcpClient.Close();
				}
				catch (Exception expr_271)
				{
					ProjectData.SetProjectError(expr_271);
					Exception ex3 = expr_271;
					this.Trace(ex3.Message);
					this.Trace(ex3.ToString());
					ProjectData.ClearProjectError();
				}
				return flag;
			}
		}

		private bool SendHost(byte[] ReqPkt)
		{
			byte[] bytes = new byte[1025];
			bool flag = false;
			checked
			{
				try
				{
					flag = this.Send_Host(ReqPkt, ref bytes);
					string right;
					if (flag)
					{
						right = this.ByteToByteStr(bytes);
					}
					else
					{
						right = "";
					}
					this.Ptr = 0;
					this.Tx[(int)this.Ptr] = this.STX[0];
					this.Ptr += 1;
					this.Dump = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("06,", Interaction.IIf(flag, "00", "99")), ","), right), ","));
					Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
					this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
					this.Tx[(int)this.Ptr] = this.ETX[0];
					this.Ptr += 1;
					this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
					this.Ptr += 1;
					if (!this.ExchangePkt(ref this.Serial_Port, this.Tx, this.Ptr))
					{
						this.Trace("SendHost Exchange error.");
						this.VFI_RespCode = "92";
						this.VFI_RespMess = "Send Error";
						flag = false;
					}
				}
				catch (Exception expr_16A)
				{
					ProjectData.SetProjectError(expr_16A);
					Exception ex = expr_16A;
					this.Trace("Error on SendHost :" + ex.Message);
					this.Trace("Error on SendHost :" + ex.ToString());
					ProjectData.ClearProjectError();
				}
				return flag;
			}
		}

		private bool SendHost(string strReqPkt)
		{
			byte[] bytes = new byte[1025];
			bool flag = false;
			checked
			{
				try
				{
					byte[] reqPkt = this.ByteStrToByte(strReqPkt);
					flag = this.Send_Host(reqPkt, ref bytes);
					string right;
					if (flag)
					{
						right = this.ByteToByteStr(bytes);
					}
					else
					{
						right = "";
					}
					this.Ptr = 0;
					this.Tx[(int)this.Ptr] = this.STX[0];
					this.Ptr += 1;
					this.Dump = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("06,", Interaction.IIf(flag, "00", "99")), ","), right), ","));
					if (this.Dump.Length > this.Tx.Length)
					{
						this.Tx = new byte[this.Dump.Length + 10 + 1];
					}
					Encoding.ASCII.GetBytes(this.Dump, 0, this.Dump.Length, this.Tx, (int)this.Ptr);
					this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
					this.Tx[(int)this.Ptr] = this.ETX[0];
					this.Ptr += 1;
					this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
					this.Ptr += 1;
					if (!this.ExchangePkt(ref this.Serial_Port, this.Tx, this.Ptr))
					{
						this.Trace("SendHost Exchange error.");
						this.VFI_RespCode = "92";
						this.VFI_RespMess = "Send Error";
						flag = false;
					}
				}
				catch (Exception expr_1A5)
				{
					ProjectData.SetProjectError(expr_1A5);
					Exception ex = expr_1A5;
					this.Trace("Error on SendHost :" + ex.Message);
					this.Trace("Error on SendHost :" + ex.ToString());
					ProjectData.ClearProjectError();
				}
				return flag;
			}
		}

		private bool SendHost1(byte[] ReqPkt)
		{
			byte[] bytes = new byte[1025];
			bool flag = false;
			checked
			{
				try
				{
					flag = this.Send_Host(ReqPkt, ref bytes);
					string text;
					if (!flag)
					{
						text = "";
					}
					else
					{
						text = this.ByteToByteStr(bytes);
					}
					this.Ptr = 0;
					this.Tx[(int)this.Ptr] = this.STX[0];
					this.Ptr += 1;
					this.Dump = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("06,", Interaction.IIf(flag, "00", "99")), ","), text.Length), ","), text), ","));
					this.Ptr = (short)((int)this.Ptr + this.Dump.Length);
					this.Tx[(int)this.Ptr] = this.ETX[0];
					this.Ptr += 1;
					this.Tx[(int)this.Ptr] = this.GetLrc(this.Tx, (int)this.Ptr);
					this.Ptr += 1;
					if (!this.ExchangePkt(ref this.Serial_Port, this.Tx, this.Ptr))
					{
						this.Trace("VFI_GetAuth Exchange pos error.");
						this.VFI_RespCode = "92";
						this.VFI_RespMess = "Send Error";
						flag = false;
					}
				}
				catch (Exception expr_15B)
				{
					ProjectData.SetProjectError(expr_15B);
					Exception ex = expr_15B;
					this.Trace(ex.Message);
					this.Trace(ex.ToString());
					ProjectData.ClearProjectError();
				}
				return flag;
			}
		}

		private bool Send_Host(byte[] ReqPkt, ref byte[] ResPkt)
		{
			TcpClient tcpClient = null;
			Socket socket = null;
			bool result = false;
			try
			{
				if (this.Connect(ref tcpClient, ref socket))
				{
					if (this.TCP_TransmitPacket(ref socket, ReqPkt))
					{
						if (this.TCP_ReadBuffer(ref socket, ref ResPkt))
						{
							result = true;
						}
					}
				}
			}
			catch (Exception expr_32)
			{
				ProjectData.SetProjectError(expr_32);
				Exception ex = expr_32;
				this.Trace(ex.Message);
				this.Trace(ex.ToString());
				ProjectData.ClearProjectError();
			}
			try
			{
				socket.Shutdown(SocketShutdown.Both);
				tcpClient.Close();
			}
			catch (Exception expr_6C)
			{
				ProjectData.SetProjectError(expr_6C);
				Exception ex2 = expr_6C;
				this.Trace("Error on Send_Host : " + ex2.Message);
				this.Trace("Error on Send_Host : " + ex2.ToString());
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private bool TCP_ReadBuffer(ref Socket TcpSocket, ref byte[] RecPkt)
		{
			checked
			{
				try
				{
					short num = 0;
					byte[] array = new byte[1];
					DateTime date = DateAndTime.Now.AddSeconds((double)modMain.Settings.HostTimeout);
					while (true)
					{
						Application.DoEvents();
						Thread.Sleep(0);
						Application.DoEvents();
						if (!this.chkConnction(ref TcpSocket))
						{
							break;
						}
						if (TcpSocket.Available > 0)
						{
							short num2 = (short)(RecPkt.Length - (int)num);
							num2 = (short)TcpSocket.Receive(RecPkt, (int)num, (int)num2, SocketFlags.None);
							if (num2 > 0)
							{
								unchecked
								{
									num += num2;
								}
								if (num > 2)
								{
									num2 = (short)((int)RecPkt[0] * 256 + (int)RecPkt[1]);
								}
								if (num > num2 + 1)
								{
									goto IL_9B;
								}
							}
						}
						if (DateAndTime.DateDiff(DateInterval.Second, date, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) >= 0L)
						{
							goto IL_9B;
						}
					}
					return false;
					IL_9B:
					this.Trace("Received : " + this.Byte2ByteStr(RecPkt, 0, (short)(num + 1)));
					if (!(DateAndTime.DateDiff(DateInterval.Second, date, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) >= 0L & num <= 0))
					{
						RecPkt = (byte[])Utils.CopyArray((Array)RecPkt, new byte[(int)(num - 1 + 1)]);
						return true;
					}
					this.Trace("ReadBuffer - Timeout / No Response from Device");
				}
				catch (Exception expr_108)
				{
					ProjectData.SetProjectError(expr_108);
					Exception ex = expr_108;
					this.Trace("Error on TCP_ReadBuffer : " + ex.Message);
					this.Trace("Error on TCP_ReadBuffer : " + ex.ToString());
					ProjectData.ClearProjectError();
				}
				return false;
			}
		}

		private bool chkConnction(ref Socket TcpSocket)
		{
			bool result;
			try
			{
				bool flag = TcpSocket.Poll(10, SelectMode.SelectRead);
				if (flag & TcpSocket.Available == 0)
				{
					throw new Exception("Closed");
				}
				result = true;
			}
			catch (Exception arg_28_0)
			{
				ProjectData.SetProjectError(arg_28_0);
				this.Trace("Client Disconnected.");
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private bool TCP_TransmitPacket(ref Socket TcpSocket, byte[] ResponsePkt)
		{
			bool result;
			try
			{
				if (this.flgSleep)
				{
					Thread.Sleep(1);
				}
				else
				{
					Thread.Sleep(1);
				}
				if (this.flgDoEvents)
				{
					Application.DoEvents();
				}
				TcpSocket.Send(ResponsePkt);
				this.Trace("Request : " + this.ByteToByteStr(ResponsePkt));
				int num = ResponsePkt.Length;
				if (this.flgDoEvents)
				{
					Application.DoEvents();
				}
				if (this.flgSleep)
				{
					Thread.Sleep(10);
				}
				else
				{
					Thread.Sleep(1);
				}
				result = true;
			}
			catch (Exception expr_70)
			{
				ProjectData.SetProjectError(expr_70);
				Exception ex = expr_70;
				this.Trace(ex.Message);
				this.Trace(ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private bool Connect(ref TcpClient PConn, ref Socket PNet_stream)
		{
			bool result = false;
			try
			{
				string hostIp = modMain.Settings.HostIp;
				if (hostIp.Length >= 0)
				{
					int hostPort = modMain.Settings.HostPort;
					PConn = new TcpClient();
					if (char.IsDigit(hostIp[0]))
					{
						PConn.Connect(IPAddress.Parse(hostIp), hostPort);
					}
					else
					{
						PConn.Connect(hostIp, hostPort);
					}
					PNet_stream = PConn.Client;
					result = true;
				}
			}
			catch (IOException expr_5E)
			{
				ProjectData.SetProjectError(expr_5E);
				ProjectData.ClearProjectError();
			}
			catch (Exception expr_6D)
			{
				ProjectData.SetProjectError(expr_6D);
				Exception ex = expr_6D;
				this.Trace(ex.Message);
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private bool Connect(ref Socket PNet_stream)
		{
			bool result = false;
			try
			{
				this.chkRouter();
				PNet_stream = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				modMain.Settings.HostIp = "127.0.0.1";
				string hostIp = modMain.Settings.HostIp;
				if (hostIp.Length >= 0)
				{
					int hostPort = modMain.Settings.HostPort;
					if (char.IsDigit(hostIp[0]))
					{
						PNet_stream.Connect(IPAddress.Parse(hostIp), hostPort);
					}
					else
					{
						PNet_stream.Connect(hostIp, hostPort);
					}
					result = true;
				}
			}
			catch (IOException expr_6E)
			{
				ProjectData.SetProjectError(expr_6E);
				ProjectData.ClearProjectError();
			}
			catch (Exception expr_7D)
			{
				ProjectData.SetProjectError(expr_7D);
				Exception ex = expr_7D;
				this.Trace(ex.Message);
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private bool chkRouter()
		{
			if (!this.flgchkRouter)
			{
				return true;
			}
			try
			{
				if (Information.UBound(Process.GetProcessesByName("TerminalECRRouter"), 1) > 0)
				{
					return true;
				}
				try
				{
					string text = this.GetCurrPath() + "\\TerminalECRRouter.exe";
					if (File.Exists(text))
					{
						Process.Start(text);
					}
				}
				catch (Exception expr_43)
				{
					ProjectData.SetProjectError(expr_43);
					ProjectData.ClearProjectError();
				}
			}
			catch (Exception expr_51)
			{
				ProjectData.SetProjectError(expr_51);
				Exception ex = expr_51;
				this.Trace("Error : " + ex.Message);
				this.Trace("Error : " + ex.ToString());
				ProjectData.ClearProjectError();
			}
			return false;
		}

		private bool Disconnect(ref Socket PNet_stream)
		{
			bool result = false;
			try
			{
				PNet_stream.Shutdown(SocketShutdown.Both);
				PNet_stream.Close();
				result = true;
			}
			catch (IOException expr_15)
			{
				ProjectData.SetProjectError(expr_15);
				ProjectData.ClearProjectError();
			}
			catch (SocketException expr_23)
			{
				ProjectData.SetProjectError(expr_23);
				ProjectData.ClearProjectError();
			}
			catch (Exception expr_31)
			{
				ProjectData.SetProjectError(expr_31);
				Exception ex = expr_31;
				this.Trace(ex.Message);
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public bool GetSettings(ref string PortName, ref int BaudRate, ref short Timeout, ref int TxnTimeout, ref int UploadTimeout, ref string TracePath, ref bool Trace, ref bool Delay, ref short DelayTimeout, ref bool WaitMessge)
		{
			try
			{
				PortName = modMain.Settings.PortName;
				BaudRate = modMain.Settings.BaudRate;
				Timeout = modMain.Settings.Timeout;
				TxnTimeout = (int)modMain.Settings.TxnTimeout;
				TxnTimeout = (int)modMain.Settings.UploadTimeout;
				UploadTimeout = (int)modMain.Settings.UploadTimeout;
				TracePath = modMain.Settings.TracePath;
				Trace = modMain.Settings.Trace;
				Delay = modMain.Settings.Delay;
				DelayTimeout = checked((short)modMain.Settings.DelayTimeout);
				WaitMessge = modMain.Settings.flgWaitRes;
			}
			catch (Exception expr_8F)
			{
				ProjectData.SetProjectError(expr_8F);
				Exception ex = expr_8F;
				MessageBox.Show(ex.Message, "Error on GetSettings:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				MessageBox.Show(ex.ToString(), "Error on GetSettings:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				bool result = false;
				ProjectData.ClearProjectError();
				return result;
			}
			return true;
		}

		public bool SaveSettings(string PortName, int BaudRate, short Timeout, int TxnTimeout, int UploadTimeout, string TracePath, bool Trace, bool Delay, short DelayTimeout, bool WaitMessge)
		{
			checked
			{
				try
				{
					modMain.Settings.PortName = PortName;
					modMain.Settings.BaudRate = BaudRate;
					modMain.Settings.Timeout = Timeout;
					modMain.Settings.TxnTimeout = (short)TxnTimeout;
					modMain.Settings.UploadTimeout = (short)UploadTimeout;
					modMain.Settings.TracePath = TracePath;
					modMain.Settings.Trace = Trace;
					modMain.Settings.Delay = Delay;
					modMain.Settings.DelayTimeout = (int)DelayTimeout;
					modMain.Settings.flgWaitRes = WaitMessge;
					modMain.Settings.Save();
				}
				catch (Exception expr_83)
				{
					ProjectData.SetProjectError(expr_83);
					Exception ex = expr_83;
					MessageBox.Show(ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					MessageBox.Show(ex.ToString(), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					bool result = false;
					ProjectData.ClearProjectError();
					return result;
				}
				return true;
			}
		}

		private string CalculateMAC()
		{
			string text = "";
			string result;
			try
			{
				text = this.TripleDES(this.VFI_TID, this.VFI_TxnDateTime, this.TripleDES_(this.VFI_TslNo));
				if (Operators.CompareString(text, "", false) == 0)
				{
					text = "00";
				}
				text = text.PadRight(8, '0');
				result = text;
			}
			catch (Exception expr_48)
			{
				ProjectData.SetProjectError(expr_48);
				Exception ex = expr_48;
				this.Trace("MAC Calculation Error: " + ex.Message);
				result = text;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private bool VerifyMAC(string MacData, string strTID, string strSlNo, string Mac)
		{
			bool result;
			try
			{
				MacData = MacData.Trim();
				if (MacData.Length > 8)
				{
					MacData = MacData.Remove(8);
				}
				else
				{
					MacData = MacData.PadLeft(8, '0');
				}
				string text = this.TripleDES(strTID, MacData, this.TripleDES_(strSlNo));
				if (Operators.CompareString(text.Substring(0, Mac.Length), Mac.Trim(), false) != 0)
				{
					this.Trace("MAC Verification Failed.");
					this.ClearData();
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch (Exception expr_6F)
			{
				ProjectData.SetProjectError(expr_6F);
				Exception ex = expr_6F;
				this.Trace("MAC Verify Error : " + ex.Message);
				this.Trace("MAC Verify Error : " + ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private bool VerifyMAC()
		{
			bool result;
			try
			{
				string text = this.TripleDES(this.VFI_PTID, this.VFI_TxnDateTime, this.TripleDES_(this.VFI_TslNo));
				if (Operators.CompareString(text, "", false) == 0)
				{
					text = "00";
				}
				if (text.Length > this.VFI_MAC.Length)
				{
					text = text.Remove(this.VFI_MAC.Length);
				}
				else
				{
					text = text.PadRight(this.VFI_MAC.Length, '0');
				}
				if (Operators.CompareString(text, this.VFI_MAC, false) != 0)
				{
					this.Trace("MAC Verification Failed.");
					this.ClearData();
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch (Exception expr_99)
			{
				ProjectData.SetProjectError(expr_99);
				Exception ex = expr_99;
				this.Trace("MAC Verify Error : " + ex.Message);
				this.Trace("MAC Verify Error : " + ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private string STR2DSP(string STR_IN)
		{
			string text = "";
			try
			{
				text = BitConverter.ToString(Encoding.ASCII.GetBytes(STR_IN));
				text = text.Replace("-", "");
			}
			catch (Exception expr_2A)
			{
				ProjectData.SetProjectError(expr_2A);
				Exception ex = expr_2A;
				this.Trace("STR2DSP Error : " + ex.Message);
				this.Trace("STR2DSP Error : " + ex.ToString());
				ProjectData.ClearProjectError();
			}
			return text;
		}

		private string STR2DSP(ref string STR_IN, ref short Length)
		{
			string text = "";
			try
			{
				text = BitConverter.ToString(Encoding.ASCII.GetBytes(Conversions.ToCharArrayRankOne(STR_IN), 0, (int)Length));
				text = text.Replace("-", "");
			}
			catch (Exception expr_33)
			{
				ProjectData.SetProjectError(expr_33);
				Exception ex = expr_33;
				this.Trace("STR2DSP Error : " + ex.Message);
				this.Trace("STR2DSP Error : " + ex.ToString());
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

		private string Byte2ByteStr(byte[] bytes, short index, short Llen)
		{
			string result;
			try
			{
				string text = BitConverter.ToString(bytes, (int)index, (int)Llen);
				text = text.Replace("-", " ");
				result = text;
			}
			catch (Exception expr_1E)
			{
				ProjectData.SetProjectError(expr_1E);
				Exception ex = expr_1E;
				this.Trace(ex.Message);
				this.Trace(ex.ToString());
				result = null;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private string ByteToByteStr(byte[] bytes, short index, short Llen)
		{
			string result;
			try
			{
				string text = BitConverter.ToString(bytes, (int)index, (int)Llen);
				text = text.Replace("-", "");
				result = text;
			}
			catch (Exception expr_1E)
			{
				ProjectData.SetProjectError(expr_1E);
				Exception ex = expr_1E;
				this.Trace(ex.Message);
				this.Trace(ex.ToString());
				result = null;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private string ByteToByteStr(byte[] bytes)
		{
			return this.ByteToByteStr(bytes, 0, checked((short)bytes.Length));
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

		public bool VFI_GetFieldValue(short FieldID, ref string FieldValue)
		{
			try
			{
				this.Trace("VFI_GetFieldValue Starts " + FieldID.ToString());
				bool result;
				if (FieldID <= 0 | FieldID > 42)
				{
					FieldValue = "Invalid field ID";
					this.Trace("VFI_GetFieldValue Err : Invalid field ID");
					result = false;
					return result;
				}
				switch (FieldID)
				{
				case 1:
					FieldValue = this.VFI_ECRRcptNum;
					break;
				case 3:
					FieldValue = this.VFI_Amount;
					break;
				case 4:
					FieldValue = this.VFI_CardNum;
					break;
				case 6:
					FieldValue = this.VFI_CHName;
					break;
				case 7:
					FieldValue = this.VFI_MessNum;
					break;
				case 8:
					FieldValue = this.VFI_CardName;
					break;
				case 11:
					FieldValue = this.VFI_CHVerification;
					break;
				case 12:
					FieldValue = this.VFI_RespCode;
					break;
				case 13:
					FieldValue = this.VFI_RespMess;
					break;
				case 14:
					FieldValue = this.VFI_ApprovalCode;
					break;
				case 15:
					FieldValue = this.VFI_DateTime;
					break;
				case 16:
					FieldValue = this.VFI_EMV_Label;
					break;
				case 17:
					FieldValue = this.VFI_EMV_AID;
					break;
				case 18:
					FieldValue = this.VFI_EMV_TVR;
					break;
				case 19:
					FieldValue = this.VFI_EMV_TSI;
					break;
				case 20:
					FieldValue = this.VFI_EMV_AC;
					break;
				case 21:
					FieldValue = this.VFI_TIPAmount;
					break;
				case 22:
					FieldValue = this.VFI_PreauthComplAmount;
					break;
				case 23:
					FieldValue = this.VFI_PreauthApprovalCode;
					break;
				case 24:
					FieldValue = this.VFI_VoidInvoiceNo;
					break;
				case 25:
					FieldValue = this.VFI_DBCount;
					break;
				case 26:
					FieldValue = this.VFI_CRCount;
					break;
				case 27:
					FieldValue = this.VFI_DBAmount;
					break;
				case 28:
					FieldValue = this.VFI_CRAmount;
					break;
				case 29:
					FieldValue = this.VFI_AdditionalInfo;
					break;
				case 30:
					FieldValue = this.VFI_ReportType;
					break;
				case 31:
					FieldValue = this.VFI_RefNo;
					break;
				case 32:
					FieldValue = this.VFI_InvoiceNo;
					break;
				case 33:
					FieldValue = this.VFI_TID;
					break;
				case 34:
					FieldValue = this.VFI_MID;
					break;
				case 35:
					FieldValue = this.VFI_Batch;
					break;
				case 38:
					FieldValue = this.VFI_EMV_CID;
					break;
				case 39:
					FieldValue = this.VFI_OrgionalInvoiceNo;
					break;
				case 40:
					FieldValue = this.VFI_CurrCode;
					break;
				case 41:
					FieldValue = this.VFI_CashBackAmount;
					break;
				}
				this.Trace("VFI_GetFieldValue Success ");
				result = true;
				return result;
			}
			catch (Exception expr_2A0)
			{
				ProjectData.SetProjectError(expr_2A0);
				Exception ex = expr_2A0;
				FieldValue = ex.Message;
				this.Trace("VFI_GetFieldValue Err :" + ex.ToString());
				ProjectData.ClearProjectError();
			}
			return false;
		}

		public bool VFI_SetFieldValue(short FieldID, string TValue)
		{
			bool result;
			try
			{
				this.Trace("VFI_SetFieldValue Starts " + Conversion.Str(FieldID) + " Value: " + TValue);
				if (FieldID <= 0 | FieldID > 42)
				{
					this.Trace("VFI_SetFieldValue : Invalid Field ID");
					result = false;
				}
				else
				{
					switch (FieldID)
					{
					case 1:
						this.VFI_ECRRcptNum = TValue;
						break;
					case 3:
						this.VFI_Amount = TValue;
						break;
					case 4:
						this.VFI_CardNum = TValue;
						break;
					case 6:
						this.VFI_CHName = TValue;
						break;
					case 7:
						this.VFI_MessNum = TValue;
						break;
					case 8:
						this.VFI_CardName = TValue;
						break;
					case 11:
						this.VFI_CHVerification = TValue;
						break;
					case 12:
						this.VFI_RespCode = TValue;
						break;
					case 13:
						this.VFI_RespMess = TValue;
						break;
					case 14:
						this.VFI_ApprovalCode = TValue;
						break;
					case 15:
						this.VFI_DateTime = TValue;
						break;
					case 16:
						this.VFI_EMV_Label = TValue;
						break;
					case 17:
						this.VFI_EMV_AID = TValue;
						break;
					case 18:
						this.VFI_EMV_TVR = TValue;
						break;
					case 19:
						this.VFI_EMV_TSI = TValue;
						break;
					case 20:
						this.VFI_EMV_AC = TValue;
						break;
					case 21:
						this.VFI_TIPAmount = TValue;
						break;
					case 22:
						this.VFI_PreauthComplAmount = TValue;
						break;
					case 23:
						this.VFI_PreauthApprovalCode = TValue;
						break;
					case 24:
						this.VFI_VoidInvoiceNo = TValue;
						break;
					case 25:
						this.VFI_DBCount = TValue;
						break;
					case 26:
						this.VFI_CRCount = TValue;
						break;
					case 27:
						this.VFI_DBAmount = TValue;
						break;
					case 28:
						this.VFI_CRAmount = TValue;
						break;
					case 29:
						this.VFI_AdditionalInfo = TValue;
						break;
					case 30:
						this.VFI_ReportType = TValue;
						break;
					case 31:
						this.VFI_RefNo = TValue;
						break;
					case 32:
						this.VFI_InvoiceNo = TValue;
						break;
					case 33:
						this.VFI_TID = TValue;
						break;
					case 34:
						this.VFI_MID = TValue;
						break;
					case 35:
						this.VFI_Batch = TValue;
						break;
					case 38:
						this.VFI_EMV_CID = TValue;
						break;
					case 39:
						this.VFI_OrgionalInvoiceNo = TValue;
						break;
					case 40:
						this.VFI_CurrCode = TValue;
						break;
					case 41:
						this.VFI_CashBackAmount = TValue;
						break;
					}
					this.Trace("VFI_SetFieldValue Success");
					result = true;
				}
			}
			catch (Exception expr_27A)
			{
				ProjectData.SetProjectError(expr_27A);
				Exception ex = expr_27A;
				this.Trace("VFI_SetFieldValue Err:" + ex.ToString());
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public string VFI_GetFieldValue(short FieldID)
		{
			try
			{
				string result = "";
				if (this.VFI_GetFieldValue(FieldID, ref result))
				{
					return result;
				}
			}
			catch (Exception expr_17)
			{
				ProjectData.SetProjectError(expr_17);
				this.Trace("VFI_GetFieldValue Error :" + Information.Err().Description);
				ProjectData.ClearProjectError();
			}
			return "-1";
		}

		public string VFI_SetFieldValue1(short FieldID, string TValue)
		{
			try
			{
				if (this.VFI_SetFieldValue(FieldID, TValue))
				{
					return "1";
				}
			}
			catch (Exception expr_14)
			{
				ProjectData.SetProjectError(expr_14);
				this.Trace("VFI_SetFieldValue Err:" + Information.Err().Description);
				ProjectData.ClearProjectError();
			}
			return "-1";
		}

		public void Dispose()
		{
            //this.Trace("Finalize");
            //base.Finalize();
		}
	}
}
