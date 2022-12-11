using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ECR
{
	[DesignerGenerated]
	public class frmDosetup : Form
	{
		private IContainer components;

		[AccessedThroughProperty("butSave")]
		private Button _butSave;

		[AccessedThroughProperty("butClose")]
		private Button _butClose;

		[AccessedThroughProperty("grpGeneral")]
		private GroupBox _grpGeneral;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("cmdTracePath")]
		private Button _cmdTracePath;

		[AccessedThroughProperty("Label11")]
		private Label _Label11;

		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		[AccessedThroughProperty("txtTracePath")]
		private TextBox _txtTracePath;

		[AccessedThroughProperty("txtUploadTimeout")]
		private TextBox _txtUploadTimeout;

		[AccessedThroughProperty("chkTrace")]
		private CheckBox _chkTrace;

		[AccessedThroughProperty("Label13")]
		private Label _Label13;

		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		[AccessedThroughProperty("txtTxnTimeout")]
		private TextBox _txtTxnTimeout;

		[AccessedThroughProperty("chkWaitRes")]
		private CheckBox _chkWaitRes;

		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		[AccessedThroughProperty("Label14")]
		private Label _Label14;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("txtHTimeOut")]
		private TextBox _txtHTimeOut;

		[AccessedThroughProperty("txtPort")]
		private TextBox _txtPort;

		[AccessedThroughProperty("txtIP")]
		private TextBox _txtIP;

		[AccessedThroughProperty("Label10")]
		private Label _Label10;

		[AccessedThroughProperty("Label12")]
		private Label _Label12;

		internal virtual Button butSave
		{
			get
			{
				return this._butSave;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.butSave_Click);
				if (this._butSave != null)
				{
					this._butSave.Click -= value2;
				}
				this._butSave = value;
				if (this._butSave != null)
				{
					this._butSave.Click += value2;
				}
			}
		}

		internal virtual Button butClose
		{
			get
			{
				return this._butClose;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.butClose_Click);
				if (this._butClose != null)
				{
					this._butClose.Click -= value2;
				}
				this._butClose = value;
				if (this._butClose != null)
				{
					this._butClose.Click += value2;
				}
			}
		}

		internal virtual GroupBox grpGeneral
		{
			get
			{
				return this._grpGeneral;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._grpGeneral = value;
			}
		}

		internal virtual Label Label4
		{
			get
			{
				return this._Label4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label4 = value;
			}
		}

		internal virtual Button cmdTracePath
		{
			get
			{
				return this._cmdTracePath;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.cmdTracePath_Click);
				if (this._cmdTracePath != null)
				{
					this._cmdTracePath.Click -= value2;
				}
				this._cmdTracePath = value;
				if (this._cmdTracePath != null)
				{
					this._cmdTracePath.Click += value2;
				}
			}
		}

		internal virtual Label Label11
		{
			get
			{
				return this._Label11;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label11 = value;
			}
		}

		internal virtual Label Label8
		{
			get
			{
				return this._Label8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label8 = value;
			}
		}

		internal virtual TextBox txtTracePath
		{
			get
			{
				return this._txtTracePath;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtTracePath = value;
			}
		}

		internal virtual TextBox txtUploadTimeout
		{
			get
			{
				return this._txtUploadTimeout;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.txtTimeout_KeyPress);
				if (this._txtUploadTimeout != null)
				{
					this._txtUploadTimeout.KeyPress -= value2;
				}
				this._txtUploadTimeout = value;
				if (this._txtUploadTimeout != null)
				{
					this._txtUploadTimeout.KeyPress += value2;
				}
			}
		}

		internal virtual CheckBox chkTrace
		{
			get
			{
				return this._chkTrace;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkTrace = value;
			}
		}

		internal virtual Label Label13
		{
			get
			{
				return this._Label13;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label13 = value;
			}
		}

		internal virtual Label Label7
		{
			get
			{
				return this._Label7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label7 = value;
			}
		}

		internal virtual TextBox txtTxnTimeout
		{
			get
			{
				return this._txtTxnTimeout;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.txtTimeout_KeyPress);
				if (this._txtTxnTimeout != null)
				{
					this._txtTxnTimeout.KeyPress -= value2;
				}
				this._txtTxnTimeout = value;
				if (this._txtTxnTimeout != null)
				{
					this._txtTxnTimeout.KeyPress += value2;
				}
			}
		}

		internal virtual CheckBox chkWaitRes
		{
			get
			{
				return this._chkWaitRes;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._chkWaitRes = value;
			}
		}

		internal virtual GroupBox GroupBox1
		{
			get
			{
				return this._GroupBox1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox1 = value;
			}
		}

		internal virtual Label Label14
		{
			get
			{
				return this._Label14;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label14 = value;
			}
		}

		internal virtual Label Label3
		{
			get
			{
				return this._Label3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label3 = value;
			}
		}

		internal virtual TextBox txtHTimeOut
		{
			get
			{
				return this._txtHTimeOut;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.txtTimeout_KeyPress);
				if (this._txtHTimeOut != null)
				{
					this._txtHTimeOut.KeyPress -= value2;
				}
				this._txtHTimeOut = value;
				if (this._txtHTimeOut != null)
				{
					this._txtHTimeOut.KeyPress += value2;
				}
			}
		}

		internal virtual TextBox txtPort
		{
			get
			{
				return this._txtPort;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtPort = value;
			}
		}

		internal virtual TextBox txtIP
		{
			get
			{
				return this._txtIP;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._txtIP = value;
			}
		}

		internal virtual Label Label10
		{
			get
			{
				return this._Label10;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label10 = value;
			}
		}

		internal virtual Label Label12
		{
			get
			{
				return this._Label12;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label12 = value;
			}
		}

		public frmDosetup()
		{
			base.Load += new EventHandler(this.frmDosetup_Load);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && this.components != null)
				{
					this.components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.butSave = new Button();
			this.butClose = new Button();
			this.grpGeneral = new GroupBox();
			this.chkWaitRes = new CheckBox();
			this.Label13 = new Label();
			this.chkTrace = new CheckBox();
			this.Label7 = new Label();
			this.txtTxnTimeout = new TextBox();
			this.Label4 = new Label();
			this.cmdTracePath = new Button();
			this.Label11 = new Label();
			this.Label8 = new Label();
			this.txtTracePath = new TextBox();
			this.txtUploadTimeout = new TextBox();
			this.GroupBox1 = new GroupBox();
			this.Label14 = new Label();
			this.Label3 = new Label();
			this.txtHTimeOut = new TextBox();
			this.txtPort = new TextBox();
			this.txtIP = new TextBox();
			this.Label10 = new Label();
			this.Label12 = new Label();
			this.grpGeneral.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			this.butSave.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			Control arg_140_0 = this.butSave;
			Point location = new Point(125, 243);
			arg_140_0.Location = location;
			this.butSave.Name = "butSave";
			Control arg_167_0 = this.butSave;
			Size size = new Size(85, 37);
			arg_167_0.Size = size;
			this.butSave.TabIndex = 2;
			this.butSave.Text = "&Save";
			this.butSave.UseVisualStyleBackColor = true;
			this.butClose.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			Control arg_1C9_0 = this.butClose;
			location = new Point(301, 243);
			arg_1C9_0.Location = location;
			this.butClose.Name = "butClose";
			Control arg_1F0_0 = this.butClose;
			size = new Size(85, 37);
			arg_1F0_0.Size = size;
			this.butClose.TabIndex = 3;
			this.butClose.Text = "&Close";
			this.butClose.UseVisualStyleBackColor = true;
			this.grpGeneral.BackColor = Color.Transparent;
			this.grpGeneral.Controls.Add(this.chkWaitRes);
			this.grpGeneral.Controls.Add(this.Label13);
			this.grpGeneral.Controls.Add(this.chkTrace);
			this.grpGeneral.Controls.Add(this.Label7);
			this.grpGeneral.Controls.Add(this.txtTxnTimeout);
			this.grpGeneral.Controls.Add(this.Label4);
			this.grpGeneral.Controls.Add(this.cmdTracePath);
			this.grpGeneral.Controls.Add(this.Label11);
			this.grpGeneral.Controls.Add(this.Label8);
			this.grpGeneral.Controls.Add(this.txtTracePath);
			this.grpGeneral.Controls.Add(this.txtUploadTimeout);
			this.grpGeneral.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			Control arg_34E_0 = this.grpGeneral;
			location = new Point(21, 87);
			arg_34E_0.Location = location;
			this.grpGeneral.Name = "grpGeneral";
			Control arg_37B_0 = this.grpGeneral;
			size = new Size(517, 138);
			arg_37B_0.Size = size;
			this.grpGeneral.TabIndex = 1;
			this.grpGeneral.TabStop = false;
			this.grpGeneral.Text = "General";
			this.chkWaitRes.AutoSize = true;
			Control arg_3C6_0 = this.chkWaitRes;
			location = new Point(20, 104);
			arg_3C6_0.Location = location;
			this.chkWaitRes.Name = "chkWaitRes";
			Control arg_3F0_0 = this.chkWaitRes;
			size = new Size(182, 18);
			arg_3F0_0.Size = size;
			this.chkWaitRes.TabIndex = 10;
			this.chkWaitRes.Text = "Wait for Response message";
			this.chkWaitRes.UseVisualStyleBackColor = true;
			this.Label13.AutoSize = true;
			this.Label13.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Label13.ForeColor = Color.Brown;
			Control arg_46C_0 = this.Label13;
			location = new Point(146, 33);
			arg_46C_0.Location = location;
			this.Label13.Name = "Label13";
			Control arg_493_0 = this.Label13;
			size = new Size(43, 14);
			arg_493_0.Size = size;
			this.Label13.TabIndex = 2;
			this.Label13.Text = "second";
			this.chkTrace.AutoSize = true;
			Control arg_4D5_0 = this.chkTrace;
			location = new Point(436, 27);
			arg_4D5_0.Location = location;
			this.chkTrace.Name = "chkTrace";
			Control arg_4FC_0 = this.chkTrace;
			size = new Size(56, 18);
			arg_4FC_0.Size = size;
			this.chkTrace.TabIndex = 6;
			this.chkTrace.Text = "Trace";
			this.chkTrace.UseVisualStyleBackColor = true;
			this.Label7.AutoSize = true;
			Control arg_546_0 = this.Label7;
			location = new Point(6, 30);
			arg_546_0.Location = location;
			this.Label7.Name = "Label7";
			Control arg_56D_0 = this.Label7;
			size = new Size(82, 14);
			arg_56D_0.Size = size;
			this.Label7.TabIndex = 0;
			this.Label7.Text = "Txn Timeout :";
			this.txtTxnTimeout.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			Control arg_5BD_0 = this.txtTxnTimeout;
			location = new Point(91, 27);
			arg_5BD_0.Location = location;
			this.txtTxnTimeout.MaxLength = 5;
			this.txtTxnTimeout.Name = "txtTxnTimeout";
			Control arg_5F0_0 = this.txtTxnTimeout;
			size = new Size(51, 20);
			arg_5F0_0.Size = size;
			this.txtTxnTimeout.TabIndex = 1;
			this.Label4.AutoSize = true;
			this.Label4.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Label4.ForeColor = Color.Brown;
			Control arg_64F_0 = this.Label4;
			location = new Point(359, 33);
			arg_64F_0.Location = location;
			this.Label4.Name = "Label4";
			Control arg_676_0 = this.Label4;
			size = new Size(43, 14);
			arg_676_0.Size = size;
			this.Label4.TabIndex = 5;
			this.Label4.Text = "second";
			this.cmdTracePath.Font = new Font("Arial", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.cmdTracePath.ForeColor = Color.Brown;
			Control arg_6D9_0 = this.cmdTracePath;
			location = new Point(456, 66);
			arg_6D9_0.Location = location;
			this.cmdTracePath.Name = "cmdTracePath";
			Control arg_700_0 = this.cmdTracePath;
			size = new Size(42, 22);
			arg_700_0.Size = size;
			this.cmdTracePath.TabIndex = 9;
			this.cmdTracePath.Text = "...";
			this.cmdTracePath.UseVisualStyleBackColor = true;
			this.Label11.AutoSize = true;
			Control arg_74C_0 = this.Label11;
			location = new Point(17, 69);
			arg_74C_0.Location = location;
			this.Label11.Name = "Label11";
			Control arg_773_0 = this.Label11;
			size = new Size(70, 14);
			arg_773_0.Size = size;
			this.Label11.TabIndex = 7;
			this.Label11.Text = "Trace Path :";
			this.Label8.AutoSize = true;
			Control arg_7B5_0 = this.Label8;
			location = new Point(200, 29);
			arg_7B5_0.Location = location;
			this.Label8.Name = "Label8";
			Control arg_7DC_0 = this.Label8;
			size = new Size(99, 14);
			arg_7DC_0.Size = size;
			this.Label8.TabIndex = 3;
			this.Label8.Text = "Upload Timeout :";
			this.txtTracePath.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			Control arg_82C_0 = this.txtTracePath;
			location = new Point(91, 67);
			arg_82C_0.Location = location;
			this.txtTracePath.MaxLength = 500;
			this.txtTracePath.Name = "txtTracePath";
			Control arg_866_0 = this.txtTracePath;
			size = new Size(354, 20);
			arg_866_0.Size = size;
			this.txtTracePath.TabIndex = 8;
			this.txtUploadTimeout.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			Control arg_8A9_0 = this.txtUploadTimeout;
			location = new Point(302, 27);
			arg_8A9_0.Location = location;
			this.txtUploadTimeout.MaxLength = 5;
			this.txtUploadTimeout.Name = "txtUploadTimeout";
			Control arg_8DC_0 = this.txtUploadTimeout;
			size = new Size(51, 20);
			arg_8DC_0.Size = size;
			this.txtUploadTimeout.TabIndex = 4;
			this.GroupBox1.Controls.Add(this.Label14);
			this.GroupBox1.Controls.Add(this.Label3);
			this.GroupBox1.Controls.Add(this.txtHTimeOut);
			this.GroupBox1.Controls.Add(this.txtPort);
			this.GroupBox1.Controls.Add(this.txtIP);
			this.GroupBox1.Controls.Add(this.Label10);
			this.GroupBox1.Controls.Add(this.Label12);
			this.GroupBox1.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			Control arg_9B6_0 = this.GroupBox1;
			location = new Point(21, 18);
			arg_9B6_0.Location = location;
			this.GroupBox1.Name = "GroupBox1";
			Control arg_9E0_0 = this.GroupBox1;
			size = new Size(517, 55);
			arg_9E0_0.Size = size;
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Router Details";
			this.Label14.AutoSize = true;
			Control arg_A2E_0 = this.Label14;
			location = new Point(309, 25);
			arg_A2E_0.Location = location;
			this.Label14.Name = "Label14";
			Control arg_A55_0 = this.Label14;
			size = new Size(59, 14);
			arg_A55_0.Size = size;
			this.Label14.TabIndex = 4;
			this.Label14.Text = "Timeout :";
			this.Label3.AutoSize = true;
			this.Label3.Font = new Font("Arial", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Label3.ForeColor = Color.Brown;
			Control arg_AC4_0 = this.Label3;
			location = new Point(404, 25);
			arg_AC4_0.Location = location;
			this.Label3.Name = "Label3";
			Control arg_AEB_0 = this.Label3;
			size = new Size(55, 14);
			arg_AEB_0.Size = size;
			this.Label3.TabIndex = 6;
			this.Label3.Text = "seconds";
			this.txtHTimeOut.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			Control arg_B3E_0 = this.txtHTimeOut;
			location = new Point(374, 22);
			arg_B3E_0.Location = location;
			this.txtHTimeOut.MaxLength = 3;
			this.txtHTimeOut.Name = "txtHTimeOut";
			Control arg_B71_0 = this.txtHTimeOut;
			size = new Size(28, 20);
			arg_B71_0.Size = size;
			this.txtHTimeOut.TabIndex = 5;
			Control arg_B97_0 = this.txtPort;
			location = new Point(232, 23);
			arg_B97_0.Location = location;
			this.txtPort.Name = "txtPort";
			Control arg_BBE_0 = this.txtPort;
			size = new Size(35, 20);
			arg_BBE_0.Size = size;
			this.txtPort.TabIndex = 3;
			this.txtPort.Text = "1500";
			Control arg_BF1_0 = this.txtIP;
			location = new Point(88, 23);
			arg_BF1_0.Location = location;
			this.txtIP.Name = "txtIP";
			Control arg_C18_0 = this.txtIP;
			size = new Size(89, 20);
			arg_C18_0.Size = size;
			this.txtIP.TabIndex = 1;
			this.txtIP.Text = "127.0.0.1";
			this.txtIP.Visible = false;
			this.Label10.AutoSize = true;
			Control arg_C63_0 = this.Label10;
			location = new Point(10, 25);
			arg_C63_0.Location = location;
			this.Label10.Name = "Label10";
			Control arg_C8A_0 = this.Label10;
			size = new Size(74, 14);
			arg_C8A_0.Size = size;
			this.Label10.TabIndex = 0;
			this.Label10.Text = "IP Address :";
			this.Label10.Visible = false;
			this.Label12.AutoSize = true;
			Control arg_CD8_0 = this.Label12;
			location = new Point(194, 26);
			arg_CD8_0.Location = location;
			this.Label12.Name = "Label12";
			Control arg_CFF_0 = this.Label12;
			size = new Size(36, 14);
			arg_CFF_0.Size = size;
			this.Label12.TabIndex = 2;
			this.Label12.Text = "Port :";
			SizeF autoScaleDimensions = new SizeF(6f, 14f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = AutoScaleMode.Font;
			size = new Size(550, 295);
			this.ClientSize = size;
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.grpGeneral);
			this.Controls.Add(this.butClose);
			this.Controls.Add(this.butSave);
			this.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmDosetup";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "System Configuration";
			this.grpGeneral.ResumeLayout(false);
			this.grpGeneral.PerformLayout();
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.ResumeLayout(false);
		}

		private void frmDosetup_Load(object sender, EventArgs e)
		{
			try
			{
				this.LoadSettings();
				this.txtIP.Text = "127.0.0.1";
			}
			catch (Exception expr_18)
			{
				ProjectData.SetProjectError(expr_18);
				Exception ex = expr_18;
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ProjectData.ClearProjectError();
			}
		}

		private void LoadSettings()
		{
			try
			{
				this.txtTxnTimeout.Text = Conversions.ToString((int)modMain.Settings.TxnTimeout);
				this.txtTracePath.Text = modMain.Settings.TracePath;
				this.txtUploadTimeout.Text = Conversions.ToString((int)modMain.Settings.UploadTimeout);
				this.chkTrace.Checked = modMain.Settings.Trace;
				this.chkWaitRes.Checked = modMain.Settings.flgWaitRes;
				this.txtIP.Text = modMain.Settings.HostIp;
				this.txtPort.Text = Conversions.ToString(modMain.Settings.HostPort);
				this.txtHTimeOut.Text = Conversions.ToString(modMain.Settings.HostTimeout);
			}
			catch (Exception expr_BE)
			{
				ProjectData.SetProjectError(expr_BE);
				Exception ex = expr_BE;
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ProjectData.ClearProjectError();
			}
		}

		private void butSave_Click(object sender, EventArgs e)
		{
			checked
			{
				try
				{
					if (Conversion.Val(this.txtTxnTimeout.Text) < 60.0)
					{
						MessageBox.Show("Txn Timeout should be more than 60 seconds.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						this.txtTxnTimeout.Text = Conversions.ToString(60);
					}
					else if (Conversion.Val(this.txtHTimeOut.Text) < 10.0)
					{
						MessageBox.Show("Host Timeout should be greater than 10 seconds.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						this.txtHTimeOut.Text = Conversions.ToString(30);
					}
					else
					{
						if (Operators.CompareString(this.txtTxnTimeout.Text, "", false) == 0)
						{
							this.txtTxnTimeout.Text = Conversions.ToString(120);
						}
						else if (Conversion.Val(this.txtTxnTimeout.Text) <= 0.0)
						{
							this.txtTxnTimeout.Text = Conversions.ToString(120);
						}
						if (Operators.CompareString(this.txtTxnTimeout.Text, "", false) == 0 | Conversion.Val(this.txtTxnTimeout.Text) <= 0.0)
						{
							this.txtTxnTimeout.Text = Conversions.ToString(120);
						}
						modMain.Settings.TxnTimeout = (short)Conversions.ToInteger(this.txtTxnTimeout.Text);
						if (Operators.CompareString(this.txtUploadTimeout.Text, "", false) == 0 | Conversion.Val(this.txtUploadTimeout.Text) <= 0.0)
						{
							this.txtUploadTimeout.Text = Conversions.ToString(300);
						}
						modMain.Settings.UploadTimeout = (short)Conversions.ToInteger(this.txtUploadTimeout.Text);
						if (Operators.CompareString(this.txtTracePath.Text, "", false) == 0)
						{
							this.txtTracePath.Text = Application.StartupPath;
						}
						modMain.Settings.TracePath = this.txtTracePath.Text;
						modMain.Settings.Trace = this.chkTrace.Checked;
						modMain.Settings.flgWaitRes = this.chkWaitRes.Checked;
						modMain.Settings.HostIp = this.txtIP.Text;
						modMain.Settings.HostPort = Conversions.ToInteger(this.txtPort.Text);
						modMain.Settings.HostTimeout = Conversions.ToInteger(this.txtHTimeOut.Text);
						modMain.Settings.Save();
						MessageBox.Show("System Configuration Saved Successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.DialogResult = DialogResult.Yes;
						this.Close();
					}
				}
				catch (Exception expr_295)
				{
					ProjectData.SetProjectError(expr_295);
					Exception ex = expr_295;
					MessageBox.Show(ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					MessageBox.Show(ex.ToString(), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.DialogResult = DialogResult.No;
					ProjectData.ClearProjectError();
				}
			}
		}

		private void butClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cmdTracePath_Click(object sender, EventArgs e)
		{
			try
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				folderBrowserDialog.SelectedPath = this.txtTracePath.Text;
				folderBrowserDialog.ShowDialog();
				this.txtTracePath.Text = folderBrowserDialog.SelectedPath;
			}
			catch (Exception expr_31)
			{
				ProjectData.SetProjectError(expr_31);
				Exception ex = expr_31;
				MessageBox.Show(ex.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				MessageBox.Show(ex.ToString(), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ProjectData.ClearProjectError();
			}
		}

		private void txtTimeout_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (!Versioned.IsNumeric(e.KeyChar) & Strings.Asc(e.KeyChar) != 8)
				{
					e.Handled = true;
				}
			}
			catch (Exception expr_30)
			{
				ProjectData.SetProjectError(expr_30);
				ProjectData.ClearProjectError();
			}
		}

		private bool Connect()
		{
			TcpClient tcpClient = null;
			bool result = false;
			try
			{
				string text = this.txtIP.Text;
				if (text.Length >= 0)
				{
					int port = Conversions.ToInteger(this.txtPort.Text);
					tcpClient = new TcpClient();
					if (char.IsDigit(text[0]))
					{
						tcpClient.Connect(IPAddress.Parse(text), port);
					}
					else
					{
						tcpClient.Connect(text, port);
					}
					result = true;
				}
			}
			catch (IOException expr_5D)
			{
				ProjectData.SetProjectError(expr_5D);
				ProjectData.ClearProjectError();
			}
			catch (Exception expr_6C)
			{
				ProjectData.SetProjectError(expr_6C);
				Exception ex = expr_6C;
				MessageBox.Show(ex.Message);
				ProjectData.ClearProjectError();
			}
			try
			{
				tcpClient.Close();
			}
			catch (Exception expr_90)
			{
				ProjectData.SetProjectError(expr_90);
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}
}
