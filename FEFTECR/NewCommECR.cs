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
	public interface NewCommECR
	{
        [DispId(23)]
        string GetSet_VFI_ECRRcptNum
        {
            [DispId(23)]
            get;
            [DispId(23)]
            set;
        }

        [DispId(24)]
        string GetSet_VFI_Amount
        {
            [DispId(24)]
            get;
            [DispId(24)]
            set;
        }

        [DispId(25)]
        string GetSet_VFI_CardNum
        {
            [DispId(25)]
            get;
        }

        [DispId(26)]
        string GetSet_VFI_CHName
        {
            [DispId(26)]
            get;
        }

        [DispId(27)]
        string GetSet_VFI_MessNum
        {
            [DispId(27)]
            get;
            [DispId(27)]
            set;
        }

        [DispId(28)]
        string GetSet_VFI_RespCode
        {
            [DispId(28)]
            get;
        }

        [DispId(29)]
        string GetSet_VFI_RespMess
        {
            [DispId(29)]
            get;
        }

        [DispId(30)]
        string GetSet_VFI_ApprovalCode
        {
            [DispId(30)]
            get;
        }

        [DispId(31)]
        string GetSet_VFI_DateTime
        {
            [DispId(31)]
            get;
        }

        [DispId(32)]
        string GetSet_VFI_Batch
        {
            [DispId(32)]
            get;
        }

        [DispId(33)]
        string GetSet_VFI_REFNO
        {
            [DispId(33)]
            get;
        }

        [DispId(34)]
        string GetSet_VFI_InvoiceNo
        {
            [DispId(34)]
            get;
            [DispId(34)]
            set;
        }

        [DispId(35)]
        string GetSet_VFI_TID
        {
            [DispId(35)]
            get;
            [DispId(35)]
            set;
        }

        [DispId(36)]
        string GetSet_VFI_PTID
        {
            [DispId(36)]
            set;
        }

        [DispId(37)]
        string GetSet_VFI_MID
        {
            [DispId(37)]
            get;
        }

        [DispId(38)]
        string GetSet_VFI_TransSource
        {
            [DispId(38)]
            get;
        }

        [DispId(39)]
        string GetSet_VFI_AuthMode
        {
            [DispId(39)]
            get;
        }

        [DispId(40)]
        string GetSet_VFI_TransType
        {
            [DispId(40)]
            get;
            [DispId(40)]
            set;
        }

        [DispId(41)]
        string GetSet_VFI_Expiry
        {
            [DispId(41)]
            get;
        }

        [DispId(42)]
        string GetSet_VFI_CardName
        {
            [DispId(42)]
            get;
        }

        [DispId(43)]
        string GetSet_VFI_CHVerification
        {
            [DispId(43)]
            get;
        }

        [DispId(44)]
        string GetSet_VFI_EMV_Label
        {
            [DispId(44)]
            get;
        }

        [DispId(45)]
        string GetSet_VFI_EMV_AID
        {
            [DispId(45)]
            get;
        }

        [DispId(46)]
        string GetSet_VFI_EMV_TVR
        {
            [DispId(46)]
            get;
        }

        [DispId(47)]
        string GetSet_VFI_EMV_TSI
        {
            [DispId(47)]
            get;
        }

        [DispId(48)]
        string GetSet_VFI_EMV_AC
        {
            [DispId(48)]
            get;
        }

        [DispId(49)]
        string GetSet_VFI_AdditionalInfo
        {
            [DispId(49)]
            get;
            [DispId(49)]
            set;
        }

        [DispId(50)]
        string GetSet_VFI_VoidInvoiceNo
        {
            [DispId(50)]
            get;
            [DispId(50)]
            set;
        }

        [DispId(51)]
        string GetSet_VFI_DBCount
        {
            [DispId(51)]
            get;
        }

        [DispId(52)]
        string GetSet_VFI_CRCount
        {
            [DispId(52)]
            get;
        }

        [DispId(53)]
        string GetSet_VFI_DBAmount
        {
            [DispId(53)]
            get;
        }

        [DispId(54)]
        string GetSet_VFI_CRAmount
        {
            [DispId(54)]
            get;
        }

        [DispId(55)]
        string GetSet_VFI_ReportType
        {
            [DispId(55)]
            get;
            [DispId(55)]
            set;
        }

        [DispId(56)]
        string GetSet_VFI_CurrCode
        {
            [DispId(56)]
            get;
            [DispId(56)]
            set;
        }

        [DispId(57)]
        string GetSet_VFI_EMV_CID
        {
            [DispId(57)]
            get;
        }

        [DispId(58)]
        string GetSet_VFI_TIPAmount
        {
            [DispId(58)]
            get;
            [DispId(58)]
            set;
        }

        [DispId(59)]
        string GetSet_VFI_PreauthComplAmount
        {
            [DispId(59)]
            get;
            [DispId(59)]
            set;
        }

        [DispId(60)]
        string GetSet_VFI_OrgionalInvoiceNo
        {
            [DispId(60)]
            get;
            [DispId(60)]
            set;
        }

        [DispId(61)]
        string GetSet_VFI_PreauthApprovalCode
        {
            [DispId(61)]
            get;
            [DispId(61)]
            set;
        }

        [DispId(62)]
        string GetSet_VFI_TelNo
        {
            [DispId(62)]
            get;
        }

        [DispId(63)]
        string GetSet_VFI_CashBackAmount
        {
            [DispId(63)]
            get;
            [DispId(63)]
            set;
        }

        [DispId(1)]
        void Install();

        [DispId(2)]
        void Uninstall();

        [DispId(3)]
        bool VFI_LoadSetting();

        [DispId(4)]
        bool VFI_LoadSetting(ref string RespCode, ref string RespMess);

        [DispId(5)]
        bool VFI_DoSetup();

        [DispId(6)]
        bool VFI_DoSetup(ref string RespCode, ref string RespMess);

        [DispId(7)]
        bool VFI_InitializeAll();

        [DispId(8)]
        string VFI_DllVersion();

        [DispId(9)]
        string VFI_AboutDll();

        [DispId(10)]
        bool VFI_GetAuth();

        [DispId(11)]
        bool VFI_VoidTrans();

        [DispId(12)]
        bool VFI_Settle();

        [DispId(13)]
        bool VFI_Report();

        [DispId(14)]
        bool VFI_GetTelNo();

        [DispId(15)]
        bool VFI_GetAuth(string TID, string Amount, string ECRRcptNum, ref string RespCode, ref string RespMess);

        [DispId(16)]
        bool VFI_VoidTrans(string TID, string Amount, string VoidInvoiceNo, string ECRRcptNum, ref string RespCode, ref string RespMess);

        [DispId(17)]
        bool GetSettings(ref string PortName, ref int BaudRate, ref short Timeout, ref int TxnTimeout, ref int UploadTimeout, ref string TracePath, ref bool Trace, ref bool Delay, ref short DelayTimeout, ref bool WaitMessge);

        [DispId(18)]
        bool SaveSettings(string PortName, int BaudRate, short Timeout, int TxnTimeout, int UploadTimeout, string TracePath, bool Trace, bool Delay, short DelayTimeout, bool WaitMessge);

        [DispId(19)]
        bool VFI_GetFieldValue(short FieldID, ref string FieldValue);

        [DispId(20)]
        bool VFI_SetFieldValue(short FieldID, string TValue);

        [DispId(21)]
        string VFI_GetFieldValue(short FieldID);

        [DispId(22)]
        string VFI_SetFieldValue1(short FieldID, string TValue);

        [DispId(64)]
        void Dispose();
    }
}
