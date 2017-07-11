using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace musicTherapy1
{
	/// <summary>
	/// Summary description for DeleteInstrument.
	/// </summary>
	public class DeleteInstrument : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboBoxSubCategory;
		private System.Windows.Forms.ComboBox comboBoxCategory;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelInstrCategory;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.ComboBox comboBoxName;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		 public Form parentForm;
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
			get {return this.comboBoxName.Text;}
		}
		public DeleteInstrument()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteInstrument));
            this.comboBoxSubCategory = new System.Windows.Forms.ComboBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelInstrCategory = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxSubCategory
            // 
            this.comboBoxSubCategory.Location = new System.Drawing.Point(152, 52);
            this.comboBoxSubCategory.Name = "comboBoxSubCategory";
            this.comboBoxSubCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSubCategory.TabIndex = 13;
            this.comboBoxSubCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxSubCategory_SelectedIndexChanged);
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.Location = new System.Drawing.Point(152, 16);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategory.TabIndex = 12;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(16, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sub Category:";
            // 
            // labelInstrCategory
            // 
            this.labelInstrCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelInstrCategory.Location = new System.Drawing.Point(16, 16);
            this.labelInstrCategory.Name = "labelInstrCategory";
            this.labelInstrCategory.Size = new System.Drawing.Size(120, 23);
            this.labelInstrCategory.TabIndex = 10;
            this.labelInstrCategory.Text = "Category:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(16, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(117, 143);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Cancel";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(198, 143);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 15;
            this.buttonOK.Text = "OK";
            // 
            // comboBoxName
            // 
            this.comboBoxName.Location = new System.Drawing.Point(152, 88);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxName.TabIndex = 17;
            // 
            // DeleteInstrument
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(303, 187);
            this.Controls.Add(this.comboBoxName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSubCategory);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelInstrCategory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeleteInstrument";
            this.Text = "Delete instrument";
            this.Load += new System.EventHandler(this.DeleteInstrument_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void comboBoxCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ArrayList instCategList = ((InstrumentManager)this.parentForm).instCategList;
			string currentCategory = this.comboBoxCategory.Text;
			
			comboBoxSubCategory.Items.Clear();
			this.comboBoxSubCategory.Text="";
			comboBoxSubCategory.BeginUpdate();
			comboBoxName.Items.Clear();
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
						ArrayList imageList = (ArrayList)subCategory.ImageList;
						for (int imageCounter =0; imageCounter <imageList.Count;imageCounter++)
						{
							myImage my_image  = (myImage)imageList[imageCounter];
							comboBoxName.Items.Add(my_image.instrumentName);
						}
					}
				}
				else if (currentCategory == category.CategoryName)
				{
					ArrayList imageList = (ArrayList)category.ImageList;
					for (int imageCounter =0; imageCounter <imageList.Count;imageCounter++)
					{
						myImage my_image  = (myImage)imageList[imageCounter];
						comboBoxName.Items.Add(my_image.instrumentName);
					}
				}
			}
			comboBoxSubCategory.EndUpdate();
		}

		private void DeleteInstrument_Load(object sender, System.EventArgs e)
		{
			ArrayList instCategList = ((InstrumentManager)this.parentForm).instCategList;
			
			comboBoxCategory.BeginUpdate();
			for (int categoryCounter = 0;  categoryCounter< instCategList.Count; categoryCounter++)
			{
				Category category =  (Category)instCategList[categoryCounter];
				comboBoxCategory.Items.Add("" + category.CategoryName);
			}
			comboBoxCategory.EndUpdate();
		}

		private void comboBoxSubCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
