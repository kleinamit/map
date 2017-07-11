using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace musicTherapy1
{
	/// <summary>
	/// Summary description for DiscAttributes.
	/// </summary>
	public class DiscAttributes : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Label TitleLable;
		private System.Windows.Forms.Label AdditionlInfo;
		private System.Windows.Forms.Label PerformaLable;
		private System.Windows.Forms.TextBox TitleTextBox;
		private System.Windows.Forms.TextBox AdditionalInfoTextBox;
		private System.Windows.Forms.TextBox PerformerTextBox;
		private System.Windows.Forms.Button Color;
		private System.Windows.Forms.Panel ColorPanel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DiscAttributes()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public Color SingColor
		{
			get { return this.ColorPanel.BackColor; }
		}
		public string Title
		{
			get 
			{
				return this.TitleTextBox.Text;
			}
		}
		public string performance
		{
			get 
			{
				return this.PerformerTextBox.Text;
			}
		}
		public string AdditionalInfo
		{
			get 
			{
				return this.AdditionalInfoTextBox.Text;
			}
		}
		public void setTitle(string newTitle)
		{
			this.TitleTextBox.Text=newTitle;
		}
		public void setPerformance(string newPerformance)
		{
			this.PerformerTextBox.Text=newPerformance;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DiscAttributes));
			this.OK = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.TitleLable = new System.Windows.Forms.Label();
			this.AdditionlInfo = new System.Windows.Forms.Label();
			this.PerformaLable = new System.Windows.Forms.Label();
			this.TitleTextBox = new System.Windows.Forms.TextBox();
			this.AdditionalInfoTextBox = new System.Windows.Forms.TextBox();
			this.PerformerTextBox = new System.Windows.Forms.TextBox();
			this.ColorPanel = new System.Windows.Forms.Panel();
			this.Color = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// OK
			// 
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Location = new System.Drawing.Point(176, 224);
			this.OK.Name = "OK";
			this.OK.TabIndex = 0;
			this.OK.Text = "OK";
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(64, 224);
			this.Cancel.Name = "Cancel";
			this.Cancel.TabIndex = 1;
			this.Cancel.Text = "Cancel";
			// 
			// TitleLable
			// 
			this.TitleLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.TitleLable.Location = new System.Drawing.Point(16, 32);
			this.TitleLable.Name = "TitleLable";
			this.TitleLable.Size = new System.Drawing.Size(64, 23);
			this.TitleLable.TabIndex = 2;
			this.TitleLable.Text = "Title:";
			// 
			// AdditionlInfo
			// 
			this.AdditionlInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.AdditionlInfo.Location = new System.Drawing.Point(16, 112);
			this.AdditionlInfo.Name = "AdditionlInfo";
			this.AdditionlInfo.Size = new System.Drawing.Size(120, 23);
			this.AdditionlInfo.TabIndex = 5;
			this.AdditionlInfo.Text = "Additionl info";
			// 
			// PerformaLable
			// 
			this.PerformaLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.PerformaLable.Location = new System.Drawing.Point(16, 72);
			this.PerformaLable.Name = "PerformaLable";
			this.PerformaLable.Size = new System.Drawing.Size(64, 23);
			this.PerformaLable.TabIndex = 6;
			this.PerformaLable.Text = "Performer";
			// 
			// TitleTextBox
			// 
			this.TitleTextBox.Location = new System.Drawing.Point(152, 32);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.Size = new System.Drawing.Size(192, 20);
			this.TitleTextBox.TabIndex = 7;
			this.TitleTextBox.Text = "";
			// 
			// AdditionalInfoTextBox
			// 
			this.AdditionalInfoTextBox.Location = new System.Drawing.Point(152, 112);
			this.AdditionalInfoTextBox.Name = "AdditionalInfoTextBox";
			this.AdditionalInfoTextBox.Size = new System.Drawing.Size(192, 20);
			this.AdditionalInfoTextBox.TabIndex = 8;
			this.AdditionalInfoTextBox.Text = "NOT IN USE FOR NOW!!";
			// 
			// PerformerTextBox
			// 
			this.PerformerTextBox.Location = new System.Drawing.Point(152, 72);
			this.PerformerTextBox.Name = "PerformerTextBox";
			this.PerformerTextBox.Size = new System.Drawing.Size(192, 20);
			this.PerformerTextBox.TabIndex = 9;
			this.PerformerTextBox.Text = "";
			// 
			// ColorPanel
			// 
			this.ColorPanel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.ColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ColorPanel.Location = new System.Drawing.Point(152, 160);
			this.ColorPanel.Name = "ColorPanel";
			this.ColorPanel.Size = new System.Drawing.Size(40, 32);
			this.ColorPanel.TabIndex = 10;
			// 
			// Color
			// 
			this.Color.Location = new System.Drawing.Point(32, 168);
			this.Color.Name = "Color";
			this.Color.Size = new System.Drawing.Size(88, 23);
			this.Color.TabIndex = 11;
			this.Color.Text = "Change color";
			this.Color.Click += new System.EventHandler(this.Color_Click);
			// 
			// DiscAttributes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Color,
																		  this.ColorPanel,
																		  this.PerformerTextBox,
																		  this.AdditionalInfoTextBox,
																		  this.TitleTextBox,
																		  this.PerformaLable,
																		  this.AdditionlInfo,
																		  this.TitleLable,
																		  this.Cancel,
																		  this.OK});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DiscAttributes";
			this.Text = "DiscAttributes";
			this.ResumeLayout(false);

		}
		#endregion

		private void Color_Click(object sender, System.EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.AllowFullOpen = true;
			colorDialog.AnyColor = true;
			colorDialog.SolidColorOnly = false;
			colorDialog.ShowHelp = true;
			
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				//arrow.color= colorDialog.Color;
				this.ColorPanel.BackColor = colorDialog.Color;
			}
		}

		private void OK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	
	}
}
