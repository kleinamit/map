namespace musicTherapy1
{
    /// <summary>
    /// Summary description for AddAttributeInTime.
    /// </summary>
    public class AddAttributeInTime : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Button Cancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private bool pIsAddText,pIsChangeName;
		public bool IsAddText
		{
			get { return pIsAddText; }
		}
		public bool IsChangeName
		{
			get { return pIsChangeName; }
		}
		public AddAttributeInTime()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.OK = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(64, 80);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Add test";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "What would you like to do?";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(64, 112);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 2;
			this.radioButton2.Text = "Change name";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// OK
			// 
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Location = new System.Drawing.Point(160, 184);
			this.OK.Name = "OK";
			this.OK.TabIndex = 3;
			this.OK.Text = "OK";
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(48, 184);
			this.Cancel.Name = "Cancel";
			this.Cancel.TabIndex = 4;
			this.Cancel.Text = "Cancel";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// AddAttributeInTime
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Cancel,
																		  this.OK,
																		  this.radioButton2,
																		  this.label1,
																		  this.radioButton1});
			this.Name = "AddAttributeInTime";
			this.Text = "AddAttributeInTime";
			this.Load += new System.EventHandler(this.AddAttributeInTime_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioButton1.Checked)
			{
				pIsAddText=true;
			}
			else
			{
				pIsAddText=false;
			}
		}

		private void AddAttributeInTime_Load(object sender, System.EventArgs e)
		{
		
		}

		private void OK_Click(object sender, System.EventArgs e)
		{
			if (radioButton1.Checked)
			{
				pIsAddText=true;
			}
			else
			{
				pIsAddText=false;
			}
			if (radioButton2.Checked)
			{
				pIsChangeName=true;
			}
			else
			{
				pIsChangeName=false;
			}

			this.Close();
		}

		private void Cancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioButton2.Checked)
			{
				pIsChangeName=true;
			}
			else
			{
				pIsChangeName=false;
			}
		}
	}
}
