using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace musicTherapy1
{
	/// <summary>
	/// Summary description for EnterNAmeDialogBox.
	/// </summary>
	public class EnterNAmeDialogBox : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		public string PatiantName
		{
			get {return this.nameTextBox.Text;}
			set {this.nameTextBox.Text=value;}
		}
		public string additionalInfo
		{
			get {return this.addtionalInfoTextBox.Text;}
			set {this.addtionalInfoTextBox.Text = value;}
		}
		public bool isPatiantAbsent
		{
			get {return this.IsPatiantAbsentCheckBox.Checked;}
			set {this.IsPatiantAbsentCheckBox.Checked= value;}
		}

		//public int numOfPatiants
		//{
		//	get { return (int)numericUpDown1.Value; }
		//}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RichTextBox addtionalInfoTextBox;
		private System.Windows.Forms.CheckBox IsPatiantAbsentCheckBox;
		public System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Button OK;
		public string PatiantNAme;
		public EnterNAmeDialogBox()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EnterNAmeDialogBox));
			this.OK = new System.Windows.Forms.Button();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.button2 = new System.Windows.Forms.Button();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.addtionalInfoTextBox = new System.Windows.Forms.RichTextBox();
			this.IsPatiantAbsentCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// OK
			// 
			this.OK.ContextMenu = this.contextMenu1;
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Location = new System.Drawing.Point(176, 232);
			this.OK.Name = "OK";
			this.OK.TabIndex = 0;
			this.OK.Text = "OK";
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// contextMenu1
			// 
			this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(40, 232);
			this.button2.Name = "button2";
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(40, 56);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.TabIndex = 2;
			this.nameTextBox.Text = "";
			this.nameTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "What is the name of the Patiant?";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Additional information:";
			// 
			// addtionalInfoTextBox
			// 
			this.addtionalInfoTextBox.Location = new System.Drawing.Point(40, 120);
			this.addtionalInfoTextBox.Name = "addtionalInfoTextBox";
			this.addtionalInfoTextBox.Size = new System.Drawing.Size(160, 32);
			this.addtionalInfoTextBox.TabIndex = 5;
			this.addtionalInfoTextBox.Text = "Add additional text here about the patiant";
			this.addtionalInfoTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
			// 
			// IsPatiantAbsentCheckBox
			// 
			this.IsPatiantAbsentCheckBox.Location = new System.Drawing.Point(40, 176);
			this.IsPatiantAbsentCheckBox.Name = "IsPatiantAbsentCheckBox";
			this.IsPatiantAbsentCheckBox.TabIndex = 6;
			this.IsPatiantAbsentCheckBox.Text = "Patiant absent";
			// 
			// EnterNAmeDialogBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.IsPatiantAbsentCheckBox,
																		  this.addtionalInfoTextBox,
																		  this.label2,
																		  this.label1,
																		  this.nameTextBox,
																		  this.button2,
																		  this.OK});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "EnterNAmeDialogBox";
			this.Text = "EnterNAmeDialogBox";
			this.ResumeLayout(false);

		}
		#endregion

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			MenuItem menuItem1 = new MenuItem("&Copy");
			MenuItem menuItem2 = new MenuItem("&Find and Replace");
			// Define the MenuItem object to display for the PictureBox.
			MenuItem menuItem3 = new MenuItem("C&hange Picture");

			// Clear all previously added MenuItems.
			contextMenu1.MenuItems.Clear();

			if(contextMenu1.SourceControl == button2)
			{
				// Add MenuItems to display for the TextBox.
				contextMenu1.MenuItems.Add(menuItem1);
				contextMenu1.MenuItems.Add(menuItem2);
			}

			if(contextMenu1.SourceControl == OK)
			{
				// Add MenuItems to display for the TextBox.
				contextMenu1.MenuItems.Add(menuItem1);
				contextMenu1.MenuItems.Add(menuItem2);
			}
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
		//	this.PatiantNAme=nameTextBox.Text;
		}

		private void richTextBox1_TextChanged(object sender, System.EventArgs e)
		{
		//	this.additionalInfo=this.addtionalInfoTextBox.Text;
		}

		private void OK_Click(object sender, System.EventArgs e)
		{
			this.additionalInfo=this.addtionalInfoTextBox.Text;
			this.PatiantNAme=this.nameTextBox.Text;
		}

		

	}
}
