using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace musicTherapy1
{
    /// <summary>
    /// Summary description for InstrumentManager.
    /// </summary>
    /// 

    public class InstrumentManager : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Button buttonAddNew;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		public Form  parentForm;
		public ArrayList instCategList;
		private System.Windows.Forms.TreeView treeView1;
		public myImage activeInstrument;
		private ArrayList pictureArrayList = new ArrayList();
		private ArrayList lableArrayList= new ArrayList();
		private ArrayList instrumentLableList = new ArrayList();
		private System.Windows.Forms.Button buttonDelete; 
		TreeNode rootNode;
		private ToolTip instrumentManagerToolTip;
		public InstrumentManager()
		{
			//
			// Required for Windows Form Designer support
			//
			
			InitializeComponent();
			instrumentManagerToolTip = new ToolTip();
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
			//TreeNode this.rootNode = treeView1.Nodes.Add("Instrument");
			//InitializeMyScrollBar();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		/*private void InitializeMyScrollBar()
		{
			// Create and initialize a VScrollBar.
			VScrollBar vScrollBar1 = new VScrollBar();
    
			// Dock the scroll bar to the right side of the form.
			vScrollBar1.Dock = DockStyle.Right;
    
			// Add the scroll bar to the form.
			Controls.Add(vScrollBar1);
		}*/

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstrumentManager));
            this.buttonAddNew = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonAddNew.Location = new System.Drawing.Point(23, 16);
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.Size = new System.Drawing.Size(160, 27);
            this.buttonAddNew.TabIndex = 1;
            this.buttonAddNew.Text = "Add new instrument";
            this.buttonAddNew.Click += new System.EventHandler(this.buttonAddNew_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(23, 99);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(160, 224);
            this.treeView1.TabIndex = 2;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonDelete.Location = new System.Drawing.Point(23, 45);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(160, 27);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete instrument";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // InstrumentManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(768, 335);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.buttonAddNew);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InstrumentManager";
            this.Text = "Instrument Manager";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.InstrumentManager_Paint);
            this.Load += new System.EventHandler(this.InstrumentManager_Load);
            this.ResumeLayout(false);

		}
		#endregion

		public void loadInstruments()
		{
			this.drawInstrument("Instrument","Instrument",true);			
		}

		public void initTreeView()
		{
			instCategList =  ((MainForm)((Sessions)this.parentForm).ParentForm).instrumentCategorylist;
			int numOfCategories = instCategList.Count;
				
			int globalCategoryAnsSubCategoryLineCounter = 0;
			treeView1.Nodes.Clear();
			rootNode = treeView1.Nodes.Add("Instrument");
			rootNode.ImageIndex = 0;
			rootNode.SelectedImageIndex = 0;
			//this.treeView1.Nodes.Add
			rootNode.Expand();
			treeView1.SelectedNode = null;
			
			for (int CategoryCount=0;CategoryCount<instCategList.Count;CategoryCount++)
			{
				Category category =  (Category)instCategList[CategoryCount];
				TreeNode categoryNode = this.rootNode.Nodes.Add(category.CategoryName);
				
				if (category.SubCategoryList.Count == 0)
				{
					
				
				}
				else //has a sub catagory
				{
					ArrayList subCategoryList = (ArrayList)category.SubCategoryList;
					
					for (int subCategoryCounter =0 ;subCategoryCounter<subCategoryList.Count;subCategoryCounter++)
					{
						SubCategory subCategory =  (SubCategory)subCategoryList[subCategoryCounter];
						categoryNode.Nodes.Add(subCategory.SubCategoryName);
				
						
						ArrayList imageList = (ArrayList)subCategory.ImageList;
						
						
						globalCategoryAnsSubCategoryLineCounter++;
						
					}
					//category.
				}//has has sub category
				
				
				globalCategoryAnsSubCategoryLineCounter++;
			}
			
			//	this.Show();
		}
		public void InstrumentManager_Load(object sender, System.EventArgs e)
		{
		
		
		}
		private void treeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			//remove the picture and lable from form
			// and clear the array lists for another iteration

			for (int x=0;x<this.pictureArrayList.Count;x++)
				this.Controls.Remove((PictureBox)this.pictureArrayList[x]);	
			this.pictureArrayList.Clear();
		
			for (int x=0;x<this.lableArrayList.Count;x++)
				this.Controls.Remove((Label)this.lableArrayList[x]);	
			this.lableArrayList.Clear();

			for (int x=0;x<this.instrumentLableList.Count;x++)
				this.Controls.Remove((Label)this.instrumentLableList[x]);	
			this.instrumentLableList.Clear();

			if (e.Node.Text == "Instrument")
				this.drawInstrument("Instrument","Instrument",true);	
			else
				this.drawInstrument(e.Node.Text,e.Node.Parent.Text,false);
		}

		private void drawInstrument(string startCategoryName, string startCategoryParent, bool showAll)
		{
			
			instCategList =  ((MainForm)((Sessions)this.parentForm).ParentForm).instrumentCategorylist;
			int numOfCategories = instCategList.Count;
			int counterOfPicturesInLine=0;
			int counterOfPictureLines=0;
			int numOfPictureInLine = ((MainForm)((Sessions)this.parentForm).ParentForm).mainFormDocument.numOfInstrumentsInLine;
            int upBorderHeight = ((MainForm)((Sessions)this.parentForm).ParentForm).mainFormDocument.upBorderHeight;//50;
            int heightOfPicture = ((MainForm)((Sessions)this.parentForm).ParentForm).mainFormDocument.HeightOfInstrumentPicture;// 66;//ss
            int widthOfPicture = ((MainForm)((Sessions)this.parentForm).ParentForm).mainFormDocument.WidthOfInstrumentPicture;
            int sidesBorderWidth = ((MainForm)((Sessions)this.parentForm).ParentForm).mainFormDocument.sidesBorderWidth;// 200;
            int verticalIntervalBetweenPictures = ((MainForm)((Sessions)this.parentForm).ParentForm).mainFormDocument.verticalIntervalBetweenPictures;// 50;
            int HorizontalIntervalBetweenPictures = ((MainForm)((Sessions)this.parentForm).ParentForm).mainFormDocument.HorizontalIntervalBetweenPictures;// 10;
            int heighOfCategoryAndSubCategoryLable = ((MainForm)((Sessions)this.parentForm).ParentForm).mainFormDocument.heighOfCategoryAndSubCategoryLable;// 50;
		
			Label topicLable = new Label();
			Font myFont = new System.Drawing.Font("Arial",18,FontStyle.Bold);
			topicLable.Text = "Instrument Manager";
			topicLable.ForeColor = Color.Blue;
			topicLable.Font = myFont;
			topicLable.Location = new Point (10+sidesBorderWidth,0);
            topicLable.Size = new Size(1000, heighOfCategoryAndSubCategoryLable/*50*/);
			this.Controls.Add(topicLable);
			int globalCategoryAnsSubCategoryLineCounter = 0;
			
			//treeView1.SelectedNode = null;
			bool startPointIsACategory;
			if (startCategoryParent == "Instrument")
				startPointIsACategory=true;
			else 
				startPointIsACategory=false;
			
			for (int CategoryCount=0;CategoryCount<instCategList.Count;CategoryCount++)
			{
				Category category =  (Category)instCategList[CategoryCount];
				if (startPointIsACategory && !showAll)
				{
					if (category.CategoryName != startCategoryName)
						continue;
				}
				else //start point is a sub category
				{
					if (category.CategoryName != startCategoryParent && !showAll)
						continue;
				}
				Label categoryLable = new Label();
				categoryLable.Text = "Category: " + category.CategoryName;
                categoryLable.Size = new Size(5000, heighOfCategoryAndSubCategoryLable/*50*/);
				categoryLable.Location = new Point(10+sidesBorderWidth,upBorderHeight+(counterOfPictureLines*heightOfPicture)+ (counterOfPictureLines*verticalIntervalBetweenPictures)+globalCategoryAnsSubCategoryLineCounter*heighOfCategoryAndSubCategoryLable);
				categoryLable.Font = myFont;
				this.lableArrayList.Add(categoryLable);
				
				if (category.SubCategoryList.Count == 0)
				{	
					ArrayList imageList = (ArrayList)category.ImageList;
					for (int imageCounter =0; imageCounter <imageList.Count;imageCounter++)
					{
						myImage my_image  = (myImage)imageList[imageCounter];
                        if (my_image.instrumentImage == null)
                        {
                            Bitmap image = new Bitmap(my_image.instrumentImage);
                            my_image.pictureBox.Image = image;
                        }
                        else 
                        {
                            my_image.pictureBox.Image = my_image.instrumentImage;
                        }
                        
						my_image.categoryName = category.CategoryName;
						my_image.subCategoryName = "";
						my_image.pictureBox.Location = new Point(/*x*/counterOfPicturesInLine*widthOfPicture+sidesBorderWidth+counterOfPicturesInLine*HorizontalIntervalBetweenPictures,
													 			/*y*/upBorderHeight+(counterOfPictureLines)*heightOfPicture+counterOfPictureLines*verticalIntervalBetweenPictures+(globalCategoryAnsSubCategoryLineCounter+1)*heighOfCategoryAndSubCategoryLable);
						my_image.pictureBox.DoubleClick += new System.EventHandler(PictureBoxDoubleClick);
						instrumentManagerToolTip.SetToolTip(my_image.pictureBox,my_image.instrumentInfo.Description);
						this.pictureArrayList.Add(my_image.pictureBox);
						Label instrumentName = new Label();
                      //  instrumentName.BackColor = Color.Red;
                        instrumentName.TextAlign= ContentAlignment.MiddleCenter;
						instrumentName.Text = my_image.instrumentName;
                        // רגיל
                        instrumentName.Size = new Size(/*100,70*/widthOfPicture, verticalIntervalBetweenPictures/*15*/);
						instrumentName.Location = new Point(/*x*/counterOfPicturesInLine*widthOfPicture+sidesBorderWidth+counterOfPicturesInLine*HorizontalIntervalBetweenPictures,
                            upBorderHeight+(counterOfPictureLines+1)*heightOfPicture+counterOfPictureLines*verticalIntervalBetweenPictures+(globalCategoryAnsSubCategoryLineCounter+1)*heighOfCategoryAndSubCategoryLable);
							///*y*//*105*/upBorderHeight+(counterOfPictureLines+1)*heightOfPicture+counterOfPictureLines*(verticalIntervalBetweenPictures)+(globalCategoryAnsSubCategoryLineCounter+1)*heighOfCategoryAndSubCategoryLable);
						this.instrumentLableList.Add(instrumentName);
						
						//this.Controls.Add(my_image.pictureBox);
						if (counterOfPicturesInLine<numOfPictureInLine)
						{
							counterOfPicturesInLine++;
						}
						else
						{
							counterOfPicturesInLine=0;
							counterOfPictureLines++;
							
						}
					}
					counterOfPictureLines++;
					counterOfPicturesInLine=0;
					globalCategoryAnsSubCategoryLineCounter++;
				}
				else //has a sub catagory
				{
					ArrayList subCategoryList = (ArrayList)category.SubCategoryList;
					
					for (int subCategoryCounter =0 ;subCategoryCounter<subCategoryList.Count;subCategoryCounter++)
					{
						SubCategory subCategory =  (SubCategory)subCategoryList[subCategoryCounter];
						if (!startPointIsACategory)
						{
							if (subCategory.SubCategoryName!= startCategoryName && !showAll)
								continue;
						}
						//categoryNode.Nodes.Add(subCategory.SubCategoryName);
						Label subCategoryLable = new Label();
						subCategoryLable.Text = "Sub Category: " +  subCategory.SubCategoryName;
                        subCategoryLable.Size = new Size(5000, heighOfCategoryAndSubCategoryLable/*50*/);
						subCategoryLable.Location = new Point(20+sidesBorderWidth,upBorderHeight+counterOfPictureLines*heightOfPicture+ counterOfPictureLines*verticalIntervalBetweenPictures+(globalCategoryAnsSubCategoryLineCounter+1)*heighOfCategoryAndSubCategoryLable);
						subCategoryLable.Font = myFont;
						subCategoryLable.ForeColor = Color.Gray;
						this.lableArrayList.Add(subCategoryLable);
						//this.Controls.Add(subCategoryLable);

						ArrayList imageList = (ArrayList)subCategory.ImageList;
						for (int imageCounter =0; imageCounter <imageList.Count;imageCounter++)
						{
							myImage my_image  = (myImage)imageList[imageCounter];
							//Bitmap  image = new Bitmap( my_image.instrumentImage);

                            if (my_image.instrumentImage == null)
                            {
                                Bitmap image = new Bitmap(my_image.instrumentImage);
                                my_image.pictureBox.Image = image;
                            }
                            else
                            {
                                my_image.pictureBox.Image = my_image.instrumentImage;
                            }


							my_image.categoryName = category.CategoryName;
							my_image.subCategoryName = subCategory.SubCategoryName;
							
							my_image.pictureBox.Location = new Point(/*x*/counterOfPicturesInLine*widthOfPicture+sidesBorderWidth+counterOfPicturesInLine*HorizontalIntervalBetweenPictures,
																	/*y*/upBorderHeight+counterOfPictureLines*heightOfPicture+counterOfPictureLines*verticalIntervalBetweenPictures+(globalCategoryAnsSubCategoryLineCounter+2)*heighOfCategoryAndSubCategoryLable);
							my_image.pictureBox.DoubleClick += new System.EventHandler(PictureBoxDoubleClick);
							instrumentManagerToolTip.SetToolTip(my_image.pictureBox,"s,dfhsdjfshjk");
							this.pictureArrayList.Add(my_image.pictureBox);
							Label instrumentName = new Label();
                            //instrumentName.BackColor = Color.Salmon;
                            instrumentName.TextAlign = ContentAlignment.MiddleCenter;
							instrumentName.Text = my_image.instrumentName;
                            instrumentName.Size = new Size(/*100,70*/widthOfPicture, verticalIntervalBetweenPictures/*15*/);
							instrumentName.Location = new Point(/*x*/counterOfPicturesInLine*widthOfPicture+sidesBorderWidth+counterOfPicturesInLine*HorizontalIntervalBetweenPictures,
                                                                upBorderHeight + (counterOfPictureLines +1)* heightOfPicture + counterOfPictureLines * verticalIntervalBetweenPictures + (globalCategoryAnsSubCategoryLineCounter + 2) * heighOfCategoryAndSubCategoryLable);								
                                ////*y*//*105*/upBorderHeight+counterOfPictureLines*heightOfPicture+counterOfPictureLines*(verticalIntervalBetweenPictures)+(globalCategoryAnsSubCategoryLineCounter/*+2*/)*heighOfCategoryAndSubCategoryLable);
							this.instrumentLableList.Add(instrumentName);
							
							if (counterOfPicturesInLine<numOfPictureInLine)
							{
								counterOfPicturesInLine++;
							}
							else
							{
								counterOfPicturesInLine=0;
								counterOfPictureLines++;	
							}

						}//for
						counterOfPictureLines++;
						globalCategoryAnsSubCategoryLineCounter++;
						counterOfPicturesInLine=0;
					}//for of sub catefories
                    globalCategoryAnsSubCategoryLineCounter++;
				}//has has sub category
				//counterOfPictureLines++;
				//counterOfPicturesInLine=0;
				//globalCategoryAnsSubCategoryLineCounter++;
			}
			counterOfPictureLines++;
			//	this.Show();
			for (int x=0;x<this.pictureArrayList.Count;x++)
				this.Controls.Add((PictureBox)this.pictureArrayList[x]);
			for (int x=0;x<this.lableArrayList.Count;x++)
				this.Controls.Add((Label)this.lableArrayList[x]);
			for (int x=0;x<this.instrumentLableList.Count;x++)
				this.Controls.Add((Label)this.instrumentLableList[x]);
			
		}
		private void buttonAddNew_Click(object sender, System.EventArgs e)
		{
			AddInstrument addInstrumentDialog = new AddInstrument();
			addInstrumentDialog.parentForm = this;
			if(addInstrumentDialog.ShowDialog() == DialogResult.OK)
			{
				string filename = addInstrumentDialog.fileName.ToString();
				FileInfo fi1 = new FileInfo(filename);
				if (!this.isCategoryExist(addInstrumentDialog.instrumentCategory) && addInstrumentDialog.instrumentCategory != "")
				{
					string path = ((MainForm)( (Sessions)this.parentForm).ParentForm).MainDirectory+ "\\pictures\\instruments\\"+addInstrumentDialog.instrumentCategory;
					Directory.CreateDirectory(path);
				}
				if (!this.isSubCategoryExist(addInstrumentDialog.instrumentSubCategory) && addInstrumentDialog.instrumentSubCategory != "")
				{
					string path = ((MainForm)( (Sessions)this.parentForm).ParentForm).MainDirectory+ "\\pictures\\instruments\\"+addInstrumentDialog.instrumentCategory+"\\"+ addInstrumentDialog.instrumentSubCategory;
					Directory.CreateDirectory(path);
				}
				string path2 = ((MainForm)( (Sessions)this.parentForm).ParentForm).MainDirectory+ "\\pictures\\instruments\\"+addInstrumentDialog.instrumentCategory+"\\"+ addInstrumentDialog.instrumentSubCategory+"\\"+addInstrumentDialog.InstrumentName+".jpg";
				FileInfo fi2 = new FileInfo(path2);
				fi2.Delete();//just incase it exists
				
				((ArrayList)((MainForm) ((Sessions)this.parentForm).ParentForm).mainFormDocument.instrumetnInfoList).Add(new InstrumentInfo(addInstrumentDialog.instrumentCategory,addInstrumentDialog.instrumentSubCategory,addInstrumentDialog.InstrumentDescription,addInstrumentDialog.InstrumentName+".jpg" ));
//				
				fi1.CopyTo(path2);
				((MainForm) ( (Sessions)this.parentForm).ParentForm).saveInstrumentInfo();
				ClearAllListAndMemoryOfPictures();
				((MainForm) ( (Sessions)this.parentForm).ParentForm).initInstrumentManager();
				initTreeView();
				loadInstruments();
				this.Invalidate();
				
				
			}
		}
		private bool isCategoryExist(string findCategory)
		{
			//instCategList = ((InstrumentManager)this.parentForm).instCategList;
			for (int categoryCounter = 0;  categoryCounter< instCategList.Count; categoryCounter++)
			{
				Category category =  (Category)instCategList[categoryCounter];
				if (category.CategoryName == findCategory)
					return true;
			}
			return false;
		}
		private bool isSubCategoryExist(string findSubCategory)
		{
			//ArrayList instCategList = ((InstrumentManager)this.parentForm).instCategList;
			for (int categoryCounter = 0;  categoryCounter< instCategList.Count; categoryCounter++)
			{
				Category category =  (Category)instCategList[categoryCounter];
				if (category.SubCategoryList.Count > 0 )
				{
					ArrayList subCategoryList = (ArrayList)category.SubCategoryList;
					for (int subCategoryCounter =0 ;subCategoryCounter<subCategoryList.Count;subCategoryCounter++)
					{
						SubCategory subCategory =  (SubCategory)subCategoryList[subCategoryCounter];
						if (subCategory.SubCategoryName== findSubCategory)
							return true;
					}
				}
				
				
			}
			return false;
		}
		private void InstrumentManager_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
			

		}
		private void PictureBoxDoubleClick(object sender, System.EventArgs e)
		{
			myPictureBox pictureBox = (myPictureBox)sender;
		//	MessageBox.Show("dd" + ((myImage)pictureBox.my_image).instrumentName);
			//Sessions session = (Sessions)this.parentForm;
			activeInstrument = ((myImage)pictureBox.my_image);
			DialogResult =  DialogResult.OK;
			this.Close();

		}
		private void ClearAllListAndMemoryOfPictures()
		{
			//clear local list instCategList od class InstrumentManager
			for (int categoryCounter = 0;  categoryCounter< instCategList.Count; categoryCounter++)
			{
				Category category =  (Category)instCategList[categoryCounter];
				if (category.SubCategoryList.Count > 0 )
				{
					ArrayList subCategoryList = (ArrayList)category.SubCategoryList;
					for (int subCategoryCounter =0 ;subCategoryCounter<subCategoryList.Count;subCategoryCounter++)
					{
						SubCategory subCategory =  (SubCategory)subCategoryList[subCategoryCounter];
						ArrayList imageList = (ArrayList)subCategory.ImageList;
						for (int imageCounter =0; imageCounter <imageList.Count;imageCounter++)
						{
							myImage my_image  = (myImage)imageList[imageCounter];
							my_image.pictureBox.Image.Dispose();
							my_image.instrumentImage.Dispose();
							
							//comboBoxName.Items.Add(my_image.instrumentName);
						}
					}
				}
				else
				{
					ArrayList imageList = (ArrayList)category.ImageList;
					for (int imageCounter =0; imageCounter <imageList.Count;imageCounter++)
					{
						myImage my_image  = (myImage)imageList[imageCounter];
						my_image.pictureBox.Image.Dispose();
						my_image.instrumentImage.Dispose();
							
						//comboBoxName.Items.Add(my_image.instrumentName);
					}
				}

			}
			// clear list of MainForm instrumentCategorylist
			instCategList = ((MainForm)((Sessions)this.parentForm).ParentForm).instrumentCategorylist;
			for (int categoryCounter = 0;  categoryCounter< instCategList.Count; categoryCounter++)
			{
				Category category =  (Category)instCategList[categoryCounter];
				if (category.SubCategoryList.Count > 0 )
				{
					ArrayList subCategoryList = (ArrayList)category.SubCategoryList;
					for (int subCategoryCounter =0 ;subCategoryCounter<subCategoryList.Count;subCategoryCounter++)
					{
						SubCategory subCategory =  (SubCategory)subCategoryList[subCategoryCounter];
						ArrayList imageList = (ArrayList)subCategory.ImageList;
						for (int imageCounter =0; imageCounter <imageList.Count;imageCounter++)
						{
							myImage my_image  = (myImage)imageList[imageCounter];
							my_image.pictureBox.Image.Dispose();
							my_image.instrumentImage.Dispose();
						}
					}
				}
				else
				{
					ArrayList imageList = (ArrayList)category.ImageList;
					for (int imageCounter =0; imageCounter <imageList.Count;imageCounter++)
					{
						myImage my_image  = (myImage)imageList[imageCounter];
						my_image.pictureBox.Image.Dispose();
						my_image.instrumentImage.Dispose();
							
						//comboBoxName.Items.Add(my_image.instrumentName);
					}
				}
			}

			this.instCategList.Clear();
			//clear pictureArrayList
			for (int x=0;x<this.pictureArrayList.Count;x++)
			{
				PictureBox ff = (PictureBox)this.pictureArrayList[x];
				ff.Dispose();
				this.Controls.Remove((PictureBox)this.pictureArrayList[x]);	
			}	
			this.pictureArrayList.Clear();
		
			for (int x=0;x<this.lableArrayList.Count;x++)
				this.Controls.Remove((Label)this.lableArrayList[x]);	
			this.lableArrayList.Clear();

			for (int x=0;x<this.instrumentLableList.Count;x++)
				this.Controls.Remove((Label)this.instrumentLableList[x]);	
			this.instrumentLableList.Clear();
			
			((MainForm)( (Sessions)this.parentForm).ParentForm).instrumentCategorylist.Clear();
			this.instrumentManagerToolTip.RemoveAll();
			treeView1.Nodes.Clear();
		}
		private void buttonDelete_Click(object sender, System.EventArgs e)
		{
			DeleteInstrument deleteInstrumentDialog = new DeleteInstrument();
			deleteInstrumentDialog.parentForm = this;
			if(deleteInstrumentDialog.ShowDialog() == DialogResult.OK)
			{
				ClearAllListAndMemoryOfPictures();
				//if Category, subCategory and name is givven delete spesific file 
				if (deleteInstrumentDialog.instrumentSubCategory !="" &&  deleteInstrumentDialog.instrumentCategory != "" && deleteInstrumentDialog.InstrumentName !="" )
				{
					string path = ((MainForm)( (Sessions)this.parentForm).ParentForm).MainDirectory+ "\\pictures\\instruments\\"+deleteInstrumentDialog.instrumentCategory+"\\"+deleteInstrumentDialog.instrumentSubCategory+"\\"+deleteInstrumentDialog.InstrumentName;
					FileInfo fi = new FileInfo(path);
					fi.Delete();
					((MainForm)( (Sessions)this.parentForm).ParentForm).deleteFromInstrumentInfoList(deleteInstrumentDialog.instrumentCategory,deleteInstrumentDialog.instrumentSubCategory,deleteInstrumentDialog.InstrumentName);
				}//if only Category and subcategory are givven delte all files in subcategory
				else if (deleteInstrumentDialog.instrumentSubCategory !="" &&  deleteInstrumentDialog.instrumentCategory != "" )
				{
					string path = ((MainForm)( (Sessions)this.parentForm).ParentForm).MainDirectory+ "\\pictures\\instruments\\"+deleteInstrumentDialog.instrumentCategory+"\\"+deleteInstrumentDialog.instrumentSubCategory+"\\";
					Directory.Delete(path,true);
					((MainForm)( (Sessions)this.parentForm).ParentForm).deleteFromInstrumentInfoList(deleteInstrumentDialog.instrumentCategory,deleteInstrumentDialog.instrumentSubCategory,"");
				}// if Category and file is given, delete spesific file
				else if (deleteInstrumentDialog.instrumentCategory !="" &&  deleteInstrumentDialog.InstrumentName != "")
				{
					string path = ((MainForm)( (Sessions)this.parentForm).ParentForm).MainDirectory+ "\\pictures\\instruments\\"+deleteInstrumentDialog.instrumentCategory+"\\"+deleteInstrumentDialog.InstrumentName;
					FileInfo fi = new FileInfo(path);
					fi.Delete();
					((MainForm)( (Sessions)this.parentForm).ParentForm).deleteFromInstrumentInfoList(deleteInstrumentDialog.instrumentCategory,"",deleteInstrumentDialog.InstrumentName);
				}//if only ctegory is givven delete al category directory 
				else if (deleteInstrumentDialog.instrumentCategory !="" )
				{
					string path = ((MainForm)( (Sessions)this.parentForm).ParentForm).MainDirectory+ "\\pictures\\instruments\\"+deleteInstrumentDialog.instrumentCategory;
					Directory.Delete(path,true);
					((MainForm)( (Sessions)this.parentForm).ParentForm).deleteFromInstrumentInfoList(deleteInstrumentDialog.instrumentCategory,"","");
				}
				
				((MainForm) ( (Sessions)this.parentForm).ParentForm).saveInstrumentInfo();
				((MainForm)( (Sessions)this.parentForm).ParentForm).initInstrumentManager();
				initTreeView();
				loadInstruments();
				this.Invalidate();

			}
		}

	
	}
	//------------------------------------------------------------------------
	public class Category
	{
		public string CategoryName;
		public ArrayList SubCategoryList = new ArrayList();
		public ArrayList ImageList = new ArrayList();
	
	}
	//-----------------------------------------------------------------------
	public class SubCategory
	{
		public string SubCategoryName;
		public ArrayList ImageList = new ArrayList();
	}
	//-----------------------------------------------------------------------
	
	public class myImage //actual instrument
	{
		public Bitmap instrumentImage;
		public string instrumentName;
		public string subCategoryName;
		public string categoryName;
		public InstrumentInfo instrumentInfo;
		public myPictureBox pictureBox;
		public  myImage()
		{
			pictureBox = new myPictureBox();
            pictureBox.Size = new Size(66, 66);//100,100);
			pictureBox.BackColor =Color.White;
			pictureBox.BorderStyle = BorderStyle.FixedSingle;
			//pictureBox.Dock = DockStyle.Fill; 
			pictureBox.SizeMode = PictureBoxSizeMode.StretchImage ;
			pictureBox.my_image = this;
		}
	}
	//-----------------------------------------------------------------------
	public class myPictureBox : PictureBox
	{
		public myImage my_image;
		
		public myPictureBox() {}	
		 ~myPictureBox()
		{
			//MessageBox.Show("fffff");
		}

	}
	[Serializable]
	public class InstrumentInfo
	{
		public string Category;
		public string SubCategory;
		public string Description;
		public string Name;
		public static bool operator ==(InstrumentInfo inst1,InstrumentInfo inst2)
		{
			if (inst1.Category == inst2.Category &&
				inst1.SubCategory == inst2.SubCategory &&
				inst1.Name == inst2.Name )
				return true;
			else 
				return false;
		}
		public static bool operator !=(InstrumentInfo inst1,InstrumentInfo inst2)
		{
			if (inst1.Category != inst2.Category ||
				inst1.SubCategory != inst2.SubCategory ||
				inst1.Name != inst2.Name )
				return true;
			else 
				return false;
		}
		//Always override GetHashCode(),Equals when overloading ==
		public override bool Equals(object o)
		{
			return this==(InstrumentInfo)o;
		}  
		public override int GetHashCode()
		{
			return (int)1;
		}  
		/*public static implicit operator InstrumentInfo( InstrumentInfo inst2)
		{
			return new InstrumentInfo(inst2.Category,inst2.SubCategory,inst2.Description,inst2.Name);
			
		}*/
		public void ClearInstrumentInfo()
		{
			this.Category="";
			this.Description="";
			this.SubCategory="";
			this.Name="";
		}

		public InstrumentInfo ( string category,string subcategory, string description, string name)
		{
			Category=category;
			SubCategory=subcategory;
			Description=description;
			Name=name;
		}
	}
}
