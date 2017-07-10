using System.Collections;
using System.Windows.Forms;
using System.IO;
namespace musicTherapy1
{
    /// <summary>
    /// Summary description for AddInstrument.
    /// </summary>
    public class AddInstrument : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxInstrName;
		private System.Windows.Forms.Label labelInstrCategory;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxCategory;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxSubCategory;
		private System.Windows.Forms.RichTextBox richTextBoxDescription;
		private System.Windows.Forms.Label labelFileLocation;
		private System.Windows.Forms.Button buttonBrows;
		private System.Windows.Forms.TextBox textBoxFile;
		private System.Windows.Forms.ErrorProvider CategoryErrorProvider;
		private System.Windows.Forms.ErrorProvider SubCategoryErrorProvider;
		private System.Windows.Forms.ErrorProvider FileNAmeErrorProvider;
		private System.Windows.Forms.ErrorProvider NAmeErrorProvider;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private Button CanceButton;
		//private 
		public string fileName
		{
			get {return this.textBoxFile.Text;}
		}
		public string instrumentCategory
		{
			get {return this.comboBoxCategory.Text;}
		}
		public string instrumentSubCategory
		{
			get {return this.comboBoxSubCategory.Text;}
		}
		public string InstrumentName
		{
			get {return this.textBoxInstrName.Text;}
		}
		public string InstrumentDescription
		{
			get {return this.richTextBoxDescription.Text;}
		}
		public Form parentForm;
		public AddInstrument()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			CategoryErrorProvider = new  System.Windows.Forms.ErrorProvider();
			CategoryErrorProvider.SetIconAlignment (this.comboBoxCategory, ErrorIconAlignment.MiddleRight);
			CategoryErrorProvider.SetIconPadding (this.comboBoxCategory, 2);
			CategoryErrorProvider.BlinkRate = 300;
			CategoryErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
			
			SubCategoryErrorProvider = new  System.Windows.Forms.ErrorProvider();
			SubCategoryErrorProvider.SetIconAlignment (this.comboBoxSubCategory, ErrorIconAlignment.MiddleRight);
			SubCategoryErrorProvider.SetIconPadding (this.comboBoxSubCategory, 2);
			SubCategoryErrorProvider.BlinkRate = 300;
			SubCategoryErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink; 

			FileNAmeErrorProvider = new  System.Windows.Forms.ErrorProvider();
			FileNAmeErrorProvider.SetIconAlignment (this.comboBoxCategory, ErrorIconAlignment.MiddleRight);
			FileNAmeErrorProvider.SetIconPadding (this.comboBoxCategory, 2);
			FileNAmeErrorProvider.BlinkRate = 300;
			FileNAmeErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;

			NAmeErrorProvider = new  System.Windows.Forms.ErrorProvider();
			NAmeErrorProvider.SetIconAlignment (this.comboBoxCategory, ErrorIconAlignment.MiddleRight);
			NAmeErrorProvider.SetIconPadding (this.comboBoxCategory, 2);
			NAmeErrorProvider.BlinkRate = 300;
			NAmeErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddInstrument));
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInstrName = new System.Windows.Forms.TextBox();
            this.labelInstrCategory = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSubCategory = new System.Windows.Forms.ComboBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.labelFileLocation = new System.Windows.Forms.Label();
            this.buttonBrows = new System.Windows.Forms.Button();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.CanceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(214, 285);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(32, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // textBoxInstrName
            // 
            this.textBoxInstrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxInstrName.Location = new System.Drawing.Point(168, 102);
            this.textBoxInstrName.Name = "textBoxInstrName";
            this.textBoxInstrName.Size = new System.Drawing.Size(121, 26);
            this.textBoxInstrName.TabIndex = 3;
            this.textBoxInstrName.Validated += new System.EventHandler(this.textBoxInstrName_Validated);
            // 
            // labelInstrCategory
            // 
            this.labelInstrCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelInstrCategory.Location = new System.Drawing.Point(32, 33);
            this.labelInstrCategory.Name = "labelInstrCategory";
            this.labelInstrCategory.Size = new System.Drawing.Size(120, 23);
            this.labelInstrCategory.TabIndex = 5;
            this.labelInstrCategory.Text = "Category:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(32, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sub Category:";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.Location = new System.Drawing.Point(168, 32);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategory.TabIndex = 7;
            this.comboBoxCategory.Validated += new System.EventHandler(this.comboBoxCategory_Validated);
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(32, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Description:";
            // 
            // comboBoxSubCategory
            // 
            this.comboBoxSubCategory.Location = new System.Drawing.Point(168, 67);
            this.comboBoxSubCategory.Name = "comboBoxSubCategory";
            this.comboBoxSubCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSubCategory.TabIndex = 9;
            this.comboBoxSubCategory.Validated += new System.EventHandler(this.comboBoxSubCategory_Validated);
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(168, 142);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(120, 64);
            this.richTextBoxDescription.TabIndex = 10;
            this.richTextBoxDescription.Text = "Add description";
            // 
            // labelFileLocation
            // 
            this.labelFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFileLocation.Location = new System.Drawing.Point(32, 232);
            this.labelFileLocation.Name = "labelFileLocation";
            this.labelFileLocation.Size = new System.Drawing.Size(48, 23);
            this.labelFileLocation.TabIndex = 11;
            this.labelFileLocation.Text = "File:";
            // 
            // buttonBrows
            // 
            this.buttonBrows.Location = new System.Drawing.Point(214, 232);
            this.buttonBrows.Name = "buttonBrows";
            this.buttonBrows.Size = new System.Drawing.Size(75, 24);
            this.buttonBrows.TabIndex = 12;
            this.buttonBrows.Text = "Brows...";
            this.buttonBrows.Click += new System.EventHandler(this.buttonBrows_Click);
            // 
            // textBoxFile
            // 
            this.textBoxFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxFile.Location = new System.Drawing.Point(73, 232);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(128, 26);
            this.textBoxFile.TabIndex = 13;
            this.textBoxFile.Validated += new System.EventHandler(this.textBoxFile_Validated);
            // 
            // CanceButton
            // 
            this.CanceButton.Location = new System.Drawing.Point(127, 285);
            this.CanceButton.Name = "CanceButton";
            this.CanceButton.Size = new System.Drawing.Size(75, 23);
            this.CanceButton.TabIndex = 14;
            this.CanceButton.Text = "Cancel";
            this.CanceButton.UseVisualStyleBackColor = true;
            // 
            // AddInstrument
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(312, 331);
            this.Controls.Add(this.CanceButton);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.buttonBrows);
            this.Controls.Add(this.labelFileLocation);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.comboBoxSubCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelInstrCategory);
            this.Controls.Add(this.textBoxInstrName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddInstrument";
            this.Text = "Add instrument";
            this.Load += new System.EventHandler(this.AddInstrument_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void buttonBrows_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.DefaultExt = "*.*";
			openFileDialog.Filter = "picture files (*.mpg;*.jpg;*.bmp;*.JPG)|*.JPG;*.mpg;*.jpg;*.bmp;*.jpeg|All files (*.*)|*.*" ;
			openFileDialog.RestoreDirectory = true ;

			if(openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.textBoxFile.Text = openFileDialog.FileName.ToString();
			}
		}

		private void AddInstrument_Load(object sender, System.EventArgs e)
		{
			ArrayList instCategList = ((InstrumentManager)this.parentForm).instCategList;
			
			comboBoxCategory.BeginUpdate();
			for (int categoryCounter = 0;  categoryCounter< instCategList.Count; categoryCounter++)
			{
				Category category =  (Category)instCategList[categoryCounter];
				comboBoxCategory.Items.Add("" + category.CategoryName);
			}
			comboBoxCategory.EndUpdate();
			this.buttonBrows.Enabled = false;
			this.textBoxFile.Enabled = false;
		}

		private void comboBoxCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ArrayList instCategList = ((InstrumentManager)this.parentForm).instCategList;
			string currentCategory = this.comboBoxCategory.Text;
			
			comboBoxSubCategory.Items.Clear();
			this.comboBoxSubCategory.Text="";
			comboBoxSubCategory.BeginUpdate();
			for (int categoryCounter = 0;  categoryCounter< instCategList.Count; categoryCounter++)
			{
				Category category =  (Category)instCategList[categoryCounter];
			
				if (category.SubCategoryList.Count > 0 && currentCategory == category.CategoryName)
				{
					ArrayList subCategoryList = (ArrayList)category.SubCategoryList;
					
					for (int subCategoryCounter =0 ;subCategoryCounter<subCategoryList.Count;subCategoryCounter++)
					{
						SubCategory subCategory =  (SubCategory)subCategoryList[subCategoryCounter];
						comboBoxSubCategory.Items.Add("" + subCategory.SubCategoryName); 
					}
				}
				else
				{
					this.buttonBrows.Enabled= true;
					this.textBoxFile.Enabled = true;
				}
			}
			
			comboBoxSubCategory.EndUpdate();
		
		}

		private void comboBoxCategory_Validated(object sender, System.EventArgs e)
		{
			if (this.comboBoxSubCategory.Items.Count==0)
			{
				this.buttonBrows.Enabled = true;
				this.textBoxFile.Enabled = true;
			}
			else
			{
				this.buttonBrows.Enabled = false;
				this.textBoxFile.Enabled = false;
			}
			if (this.comboBoxCategory.Text == "" )
			{
				this.buttonBrows.Enabled = false;
				this.textBoxFile.Enabled = false;
				CategoryErrorProvider.SetError(this.comboBoxCategory,"Category is requiered!");
			}
			else
				CategoryErrorProvider.SetError(this.comboBoxCategory,"");
		}

		private void textBoxInstrName_Validated(object sender, System.EventArgs e)
		{
			if (this.textBoxInstrName.Text == "")
				this.NAmeErrorProvider.SetError(this.textBoxInstrName,"Am Instrument name is requierd!");
			else
				this.NAmeErrorProvider.SetError(this.textBoxInstrName,"");
		}

		private void textBoxFile_Validated(object sender, System.EventArgs e)
		{
			
			if (this.textBoxFile.Text == ""  )
			{
				this.FileNAmeErrorProvider.SetError(this.textBoxFile,"An Instrument file name is requierd!");
				return;
			}
			FileInfo f1 = new FileInfo(this.textBoxFile.Text);
			if ( !f1.Exists )
				this.FileNAmeErrorProvider.SetError(this.textBoxFile,"A valid Instrument file name is requierd!");
			else
				this.FileNAmeErrorProvider.SetError(this.textBoxFile,"");
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			//FileInfo f1 = new FileInfo(this.textBoxFile.Text);
			if (this.textBoxFile.Text		== "" ||
				this.textBoxInstrName.Text  == "" ||
				this.comboBoxCategory.Text  == "" )
			{
				MessageBox.Show("There Are invalid fields!");

			}
			else if ( !(new FileInfo(this.textBoxFile.Text).Exists)/*f1.Exists*/ )
				MessageBox.Show("File: "+ this.textBoxFile.Text+ " does not exist.");
			else
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void comboBoxSubCategory_Validated(object sender, System.EventArgs e)
		{
			if (this.comboBoxSubCategory.Text == "" && this.comboBoxSubCategory.Items.Count>0)
			{
				this.buttonBrows.Enabled = false;
				this.textBoxFile.Enabled = false;
				SubCategoryErrorProvider.SetError(this.comboBoxCategory,"A SubCategory is requiered!");
			}
			else if (this.comboBoxCategory.Text== "")
			{
				this.buttonBrows.Enabled = false;
				this.textBoxFile.Enabled = false;
				CategoryErrorProvider.SetError(this.comboBoxCategory,"A Category is requiered");
			}
			else
			{
				this.buttonBrows.Enabled = true;
				this.textBoxFile.Enabled = true;
				CategoryErrorProvider.SetError(this.comboBoxCategory,"");

			}
		}
	}
}
