using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace musicTherapy1
{
	/// <summary>
	/// Summary description for AddTextDialogBox.
	/// </summary>
	public class AddTextDialogBox : System.Windows.Forms.Form
	{
		private int recordIndex=0;
		public Form  parentForm;
		private bool isNewTextNotAdded=false;
		private bool isInsertMode=false;
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox shortTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox groupTextBox;
		public System.Windows.Forms.TextBox serialTextBox;
		public System.Windows.Forms.RichTextBox longTextBox;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Button buttonUpRecord;
		private System.Windows.Forms.Button buttonDownRecord;
		private System.Windows.Forms.Button buttonUpEnd;
		private System.Windows.Forms.Button buttonDownEnd;
		private System.Windows.Forms.Button buttonNew;
		private System.Windows.Forms.Button buttonUpdate;
		private System.Windows.Forms.Button buttonEdit;
		private System.ComponentModel.IContainer components;

		private ErrorProvider OkErrorProvider = new  System.Windows.Forms.ErrorProvider();
		


		public AddTextDialogBox()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			OkErrorProvider.SetIconAlignment (this.OK, ErrorIconAlignment.MiddleRight);
			OkErrorProvider.SetIconPadding (this.OK, 2);
			OkErrorProvider.BlinkRate = 1000;
			OkErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AddTextDialogBox));
			this.OK = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.longTextBox = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.shortTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.serialTextBox = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.buttonUpEnd = new System.Windows.Forms.Button();
			this.buttonUpRecord = new System.Windows.Forms.Button();
			this.buttonDownRecord = new System.Windows.Forms.Button();
			this.buttonDownEnd = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonNew = new System.Windows.Forms.Button();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// OK
			// 
			this.OK.Location = new System.Drawing.Point(272, 320);
			this.OK.Name = "OK";
			this.OK.Size = new System.Drawing.Size(144, 23);
			this.OK.TabIndex = 5;
			this.OK.Text = "Add topic to timeline";
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(152, 320);
			this.Cancel.Name = "Cancel";
			this.Cancel.TabIndex = 4;
			this.Cancel.Text = "Cancel";
			// 
			// longTextBox
			// 
			this.longTextBox.Location = new System.Drawing.Point(216, 127);
			this.longTextBox.Name = "longTextBox";
			this.longTextBox.Size = new System.Drawing.Size(168, 72);
			this.longTextBox.TabIndex = 3;
			this.longTextBox.Text = "Long text here";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(16, 92);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(184, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Add brief text here:";
			// 
			// shortTextBox
			// 
			this.shortTextBox.Location = new System.Drawing.Point(216, 92);
			this.shortTextBox.MaxLength = 30;
			this.shortTextBox.Name = "shortTextBox";
			this.shortTextBox.Size = new System.Drawing.Size(176, 20);
			this.shortTextBox.TabIndex = 2;
			this.shortTextBox.Text = "Short text here";
			this.toolTip1.SetToolTip(this.shortTextBox, "toolTip1gg");
			this.shortTextBox.TextChanged += new System.EventHandler(this.shortTextBox_TextChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.label2.Location = new System.Drawing.Point(16, 127);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(192, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Add detailed text here:";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label3.Location = new System.Drawing.Point(16, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 24);
			this.label3.TabIndex = 7;
			this.label3.Text = "Topic  (A, B ...)";
			// 
			// groupTextBox
			// 
			this.groupTextBox.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.groupTextBox.Location = new System.Drawing.Point(216, 16);
			this.groupTextBox.MaxLength = 1;
			this.groupTextBox.Name = "groupTextBox";
			this.groupTextBox.Size = new System.Drawing.Size(24, 23);
			this.groupTextBox.TabIndex = 0;
			this.groupTextBox.Text = "A";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label4.Location = new System.Drawing.Point(16, 54);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(176, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Sub Topic  (1,2,3 ...)";
			// 
			// serialTextBox
			// 
			this.serialTextBox.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.serialTextBox.Location = new System.Drawing.Point(216, 54);
			this.serialTextBox.MaxLength = 2;
			this.serialTextBox.Name = "serialTextBox";
			this.serialTextBox.Size = new System.Drawing.Size(24, 23);
			this.serialTextBox.TabIndex = 1;
			this.serialTextBox.Text = "1";
			// 
			// buttonUpEnd
			// 
			this.buttonUpEnd.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonUpEnd.Image")));
			this.buttonUpEnd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonUpEnd.Location = new System.Drawing.Point(320, 224);
			this.buttonUpEnd.Name = "buttonUpEnd";
			this.buttonUpEnd.Size = new System.Drawing.Size(32, 40);
			this.buttonUpEnd.TabIndex = 13;
			this.buttonUpEnd.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonUpRecord
			// 
			this.buttonUpRecord.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonUpRecord.Image")));
			this.buttonUpRecord.Location = new System.Drawing.Point(296, 224);
			this.buttonUpRecord.Name = "buttonUpRecord";
			this.buttonUpRecord.Size = new System.Drawing.Size(24, 40);
			this.buttonUpRecord.TabIndex = 12;
			this.buttonUpRecord.Click += new System.EventHandler(this.buttonUpRecord_Click);
			// 
			// buttonDownRecord
			// 
			this.buttonDownRecord.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonDownRecord.Image")));
			this.buttonDownRecord.Location = new System.Drawing.Point(264, 224);
			this.buttonDownRecord.Name = "buttonDownRecord";
			this.buttonDownRecord.Size = new System.Drawing.Size(24, 40);
			this.buttonDownRecord.TabIndex = 11;
			this.buttonDownRecord.Click += new System.EventHandler(this.buttonDownRecord_Click);
			// 
			// buttonDownEnd
			// 
			this.buttonDownEnd.Image = ((System.Drawing.Bitmap)(resources.GetObject("buttonDownEnd.Image")));
			this.buttonDownEnd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDownEnd.Location = new System.Drawing.Point(232, 224);
			this.buttonDownEnd.Name = "buttonDownEnd";
			this.buttonDownEnd.Size = new System.Drawing.Size(32, 40);
			this.buttonDownEnd.TabIndex = 14;
			this.buttonDownEnd.Click += new System.EventHandler(this.buttonDownEnd_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(88, 176);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(56, 23);
			this.buttonAdd.TabIndex = 7;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(24, 224);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(56, 23);
			this.buttonDelete.TabIndex = 8;
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// buttonNew
			// 
			this.buttonNew.Location = new System.Drawing.Point(24, 176);
			this.buttonNew.Name = "buttonNew";
			this.buttonNew.Size = new System.Drawing.Size(56, 23);
			this.buttonNew.TabIndex = 6;
			this.buttonNew.Text = "New";
			this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Location = new System.Drawing.Point(88, 272);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(56, 23);
			this.buttonUpdate.TabIndex = 15;
			this.buttonUpdate.Text = "Update";
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// buttonEdit
			// 
			this.buttonEdit.Location = new System.Drawing.Point(24, 272);
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size(56, 23);
			this.buttonEdit.TabIndex = 16;
			this.buttonEdit.Text = "Edit";
			this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
			// 
			// AddTextDialogBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 365);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.buttonEdit,
																		  this.buttonUpdate,
																		  this.buttonNew,
																		  this.buttonDelete,
																		  this.buttonAdd,
																		  this.buttonDownEnd,
																		  this.buttonDownRecord,
																		  this.buttonUpRecord,
																		  this.buttonUpEnd,
																		  this.serialTextBox,
																		  this.label4,
																		  this.groupTextBox,
																		  this.label3,
																		  this.label2,
																		  this.shortTextBox,
																		  this.label1,
																		  this.longTextBox,
																		  this.Cancel,
																		  this.OK});
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddTextDialogBox";
			this.Text = "AddTextDialogBox";
			this.Load += new System.EventHandler(this.AddTextDialogBox_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void shortTextBox_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		//private void OK_Click(object sender, System.EventArgs e)
		//{
		/*	Sessions session = (Sessions)this.parentForm;
			if (isNewTextNotAdded)
			{
				
				MessageBox.Show("You are still in NEW mode. Add the new topic or choose another topic",
					"Add topic to timeline",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);
				this.buttonAdd.Focus();
                return ;
			}
*/
			//TextTalkedinSession textBox ;
			//textBox = (TextTalkedinSession)session.document[docNumber].listText[recordIndex];
		
			//if (	this.longTextBox.Text=="") 
			//	MessageBox.Show("long text is not entered!","Add text warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);


/*					DialogResult res=MessageBox.Show("Are you sure you want to delete this topic?",
								"Delete topic",
								MessageBoxButtons.YesNo,
								MessageBoxIcon.Exclamation,
								MessageBoxDefaultButton.Button2);*/
			//return DialogResult.OK;
				//this.Close();
					
		//}

		private void AddTextDialogBox_Load(object sender, System.EventArgs e)
		{	
			//close the Text boxes to editing
			CloseTextBoxesForEditing();
			//insert defualt vales
			Sessions session = (Sessions)this.parentForm;
			if (session.document[session.docNumber].listText.Count>0)
			{//put lat item in list , if the list is not empty
				recordIndex=session.document[session.docNumber].listText.Count-1;
				TextTalkedinSession textBox ;
				textBox = (TextTalkedinSession)session.document[session.docNumber].listText[recordIndex];
				this.serialTextBox.Text=textBox.subTopic;
				this.groupTextBox.Text=textBox.topic;
				this.shortTextBox.Text=textBox.shortText;
				this.longTextBox.Text=textBox.longText;
			}
			else
			{//or put blanks in the Text Boxes
				this.serialTextBox.Text="";
				this.groupTextBox.Text="";
				this.shortTextBox.Text="";
				this.longTextBox.Text="";
				this.disableNavigateButtons();
				this.OK.Enabled=false;
				this.buttonDelete.Enabled=false;
				//this.buttonInsert.Enabled=false;
				this.buttonEdit.Enabled=false;
				
			}
				this.buttonUpdate.Enabled=false;
				this.buttonAdd.Enabled=false;
		}

		private void buttonUpRecord_Click(object sender, System.EventArgs e)
		{
			Sessions session = (Sessions)this.parentForm;
			if (session.document[session.docNumber].listText.Count==0)
			{
				this.serialTextBox.Text="";
				this.groupTextBox.Text="";
				this.shortTextBox.Text="";
				this.longTextBox.Text="";
			}
			else
			{
				if (recordIndex+1<session.document[session.docNumber].listText.Count)
					recordIndex++;
				TextTalkedinSession textBox ;
				textBox = (TextTalkedinSession)session.document[session.docNumber].listText[recordIndex];
				this.serialTextBox.Text=textBox.subTopic;
				this.groupTextBox.Text=textBox.topic;
				this.shortTextBox.Text=textBox.shortText;
				this.longTextBox.Text=textBox.longText;
				isNewTextNotAdded=false;
			}
			//close text boxes for editing
			CloseTextBoxesForEditing();
		}
	

		private void buttonDownRecord_Click(object sender, System.EventArgs e)
		{
			Sessions session = (Sessions)this.parentForm;
			if (session.document[session.docNumber].listText.Count==0)
			{
				MessageBox.Show("There are no topics in the list");
				this.serialTextBox.Text="";
				this.groupTextBox.Text="";
				this.shortTextBox.Text="";
				this.longTextBox.Text="";
			}
			else
			{
				if (recordIndex>0)
					recordIndex--;
				TextTalkedinSession textBox ;
				textBox = (TextTalkedinSession)session.document[session.docNumber].listText[recordIndex];
				this.serialTextBox.Text=textBox.subTopic;
				this.groupTextBox.Text=textBox.topic;
				this.shortTextBox.Text=textBox.shortText;
				this.longTextBox.Text=textBox.longText;
				isNewTextNotAdded=false;
			}
			//close text boxes for editing
			CloseTextBoxesForEditing();
		}

		private void buttonAdd_Click(object sender, System.EventArgs e)
		{
			Sessions session = (Sessions)this.parentForm;
			TextTalkedinSession textBox,temptextBox, prevTextBox ;
			string tmpTextIndex;
			string tmpDialogTextIndex;
			int compare;
			int x;
			int index=0;
			
		//check validity o fthe text boxes
			if (this.serialTextBox.Text=="")
			{
				MessageBox.Show("subTopic is not entered!","Add text warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.serialTextBox.Focus();
				return;
			}
			if (this.groupTextBox.Text=="") 
			{
				MessageBox.Show("Topic is not entered!","Add text warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.groupTextBox.Focus();
				return;
			}
			if (	this.shortTextBox.Text=="") 
			{
				MessageBox.Show("Shor text is not entered!","Add text warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.shortTextBox.Focus();
				return;
			}
			//##########################################################
			
			// Find the correct place, and insert the new item in the text list	
			for ( x=0;x<session.document[session.docNumber].listText.Count;x++)
			{	//go over the text list			
				textBox = (TextTalkedinSession)session.document[session.docNumber].listText[x];
				tmpTextIndex=textBox.topic+textBox.subTopic;
				tmpDialogTextIndex=this.groupTextBox.Text.ToString()+ this.serialTextBox.Text.ToString();
				//compare the topic and subtopic which are the index
				compare= tmpDialogTextIndex.CompareTo(tmpTextIndex); 
				if ( compare>0)//did not rich the item yet
					continue;
				else if (compare==0)
				{// the item already exists
					if (MessageBox.Show("The topic already exists in list. If you want to insert it into the list prees ok.",
						"Add new item",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.Cancel)
					{
						return;
					}
					else
					{
						isInsertMode=true;
						break;
					}
					/*if (!isInsertMode)
					{
						MessageBox.Show("The topic already exists in list","Add new item");
						return;
					}
					else
					{//insert mode. Move all needed itmes forward and insert new item
						break;
					}*/
				}
				else
				{//found the item +1
					break;
				}
			}
			index=x;
			//-------------------------------------------------------------
			ArrayList tempArrayList;
			int totalCountofList;
			if (isInsertMode)
			{
				//cancal the Inser mode
				isInsertMode=false;
				//bool isNewSubTopic;
				//find out if you have to increas the Topic or the subTopic
				prevTextBox=(TextTalkedinSession)session.document[session.docNumber].listText[x-1];
				if (prevTextBox.topic==this.groupTextBox.Text)
				{
					//					isNewSubTopic=true;
					//means that you have to increase only the subTopics of this Topic
					totalCountofList=session.document[session.docNumber].listText.Count;
					int listCounter;
					for (listCounter=x;listCounter<totalCountofList;listCounter++)
					{
						temptextBox = (TextTalkedinSession)session.document[session.docNumber].listText[listCounter];
						if (temptextBox.topic==this.groupTextBox.Text)
							continue;
					}
					//found the last place in list to replace
					//now get the sublist from original list
					tempArrayList = new ArrayList(session.document[session.docNumber].listText.GetRange(x,(listCounter-x)));
					for (int tempCounter=0;tempCounter<tempArrayList.Count;tempCounter++)
					{//replace the subTopic
						temptextBox = (TextTalkedinSession)tempArrayList[tempCounter];
						char[] rr =temptextBox.subTopic.ToCharArray(0,1);
						char t='d';
						t=rr[0];
						int intt=t+1;
						string ss;
						t=(char)intt;
						ss=""+t;
						temptextBox.subTopic=ss;
					}	
				}
				else
				{
					//isNewSubTopic=false;
					//means that you have to increase all the Topics of the remaining list
					totalCountofList=session.document[session.docNumber].listText.Count;
					tempArrayList = new ArrayList(session.document[session.docNumber].listText.GetRange(x,(totalCountofList-x)));
					for (int tempCounter=0;tempCounter<tempArrayList.Count;tempCounter++)
					{
						temptextBox = (TextTalkedinSession)tempArrayList[tempCounter];
						char[] rr =temptextBox.subTopic.ToCharArray(0,1);
						char t='d';
						t=rr[0];
						int intt=t+1;
						string ss;
						t=(char)intt;
						ss=""+t;
						//temptextBox.subTopic=ss;
						rr =temptextBox.topic.ToCharArray(0,1);
						t=rr[0];
						intt=t+1;
						t=Convert.ToChar(intt);
						//t=(char)intt;
						ss=""+t;
						temptextBox.topic=ss;
					}	
				}
				
				session.document[session.docNumber].listText.RemoveRange(x,totalCountofList-x);
				session.document[session.docNumber].listText.AddRange(tempArrayList);
			}		
				//acctualy insert the item to list
				session.document[session.docNumber].listText.Insert(index,new TextTalkedinSession( this.shortTextBox.Text,
					this.longTextBox.Text,
					this.groupTextBox.Text,
					this.serialTextBox.Text));
				
			
			//set the flag for NOT Editing Mode
				isNewTextNotAdded=false;
			//refresh the text panel to show new items in list
				session.AddTextToTextPanel();
			//close text boxes for editing
			CloseTextBoxesForEditing();
				this.enableNavigateButtons();
				this.OK.Enabled=true;
				this.buttonDelete.Enabled=true;
				//this.buttonInsert.Enabled=true;
				this.buttonEdit.Enabled=true;
				this.buttonUpdate.Enabled=false;
				this.buttonAdd.Enabled=true;
				this.buttonNew.Enabled=true;

		}

		private void buttonDelete_Click(object sender, System.EventArgs e)
		{
			Sessions session = (Sessions)this.parentForm;
			if (isNewTextNotAdded)
			{
				MessageBox.Show("You are in Editing mode. Add new item or Cancel","Delete item from list");
			}
			else if (session.document[session.docNumber].listText.Count==0)
			{
				MessageBox.Show("There is no topic in list to delete.","Delete item fromlist");
				
			}
			else
			{
				
				DialogResult res=MessageBox.Show("Are you sure you want to delete this topic?",
								"Delete topic",
								MessageBoxButtons.YesNo,
								MessageBoxIcon.Exclamation,
								MessageBoxDefaultButton.Button2);
				if (res == DialogResult.Yes)
				{
					TextTalkedinSession textBox ;
					textBox = (TextTalkedinSession)session.document[session.docNumber].listText[recordIndex];
					session.deleteTextTopicsFromButtons(textBox.topic+textBox.subTopic);
					session.document[session.docNumber].listText.RemoveAt(recordIndex);
					session.AddTextToTextPanel();
					
					buttonDownRecord_Click(sender,e);
				}
				
			}
		}

		private void buttonDownEnd_Click(object sender, System.EventArgs e)
		{
			CloseTextBoxesForEditing();
			Sessions session = (Sessions)this.parentForm;
			if (session.document[session.docNumber].listText.Count==0)
			{
				MessageBox.Show("There are no topics in the list");
				this.serialTextBox.Text="";
				this.groupTextBox.Text="";
				this.shortTextBox.Text="";
				this.longTextBox.Text="";
			}
			else
			{
				recordIndex=0;
				TextTalkedinSession textBox ;
				textBox = (TextTalkedinSession)session.document[session.docNumber].listText[recordIndex];
				this.serialTextBox.Text=textBox.subTopic;
				this.groupTextBox.Text=textBox.topic;
				this.shortTextBox.Text=textBox.shortText;
				this.longTextBox.Text=textBox.longText;
				isNewTextNotAdded=false;
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Sessions session = (Sessions)this.parentForm;
			if (session.document[session.docNumber].listText.Count==0)
			{
				this.serialTextBox.Text="";
				this.groupTextBox.Text="";
				this.shortTextBox.Text="";
				this.longTextBox.Text="";
			}
			else
			{
				recordIndex = session.document[session.docNumber].listText.Count-1;
				TextTalkedinSession textBox ;
				textBox = (TextTalkedinSession)session.document[session.docNumber].listText[recordIndex];
				this.serialTextBox.Text=textBox.subTopic;
				this.groupTextBox.Text=textBox.topic;
				this.shortTextBox.Text=textBox.shortText;
				this.longTextBox.Text=textBox.longText;
			}
		}
		private void OpenTextBoxesForEditing()
		{
			this.serialTextBox.ReadOnly=false;
			this.groupTextBox.ReadOnly=false;
			this.shortTextBox.ReadOnly=false;
			this.longTextBox.ReadOnly=false;
		}
		private void CloseTextBoxesForEditing()
		{
			this.serialTextBox.ReadOnly=true;
			this.groupTextBox.ReadOnly=true;
			this.shortTextBox.ReadOnly=true;
			this.longTextBox.ReadOnly=true;
		}
		private void buttonNew_Click(object sender, System.EventArgs e)
		{
			//enable the writing and editing into the text boxes
			OpenTextBoxesForEditing();
			
			//insert a defualt vale to text boxes
			Sessions session = (Sessions)this.parentForm;
			TextTalkedinSession textBox ;
			
			if (session.document[session.docNumber].listText.Count>0)
			{//take the last one +1 in the subTopic
				textBox = (TextTalkedinSession)session.document[session.docNumber].listText[session.document[session.docNumber].listText.Count-1];
				//for hisrotic reasons, the groupTextBox is the topic 
				// and the serialTextBox is the subTopic.
				// Change it whenever you have time
				this.groupTextBox.Text=textBox.topic;
				//int tempInt=(int)textBox.topic.ToString() +1;
				string subTopicPlusOne;
				//temp="" + temp;
				int i = Int32.Parse(textBox.subTopic);
				i++;
				subTopicPlusOne=""+i;
				this.serialTextBox.Text=subTopicPlusOne;
			}
			else
			{//or take the defual "A1"
				this.groupTextBox.Text="A";
				this.serialTextBox.Text="1";
			}
			
			// in the short and long just the defualt
			this.shortTextBox.Text="Add short text here";
			this.longTextBox.Text="Add long text here";	
			
			//set the flag in order to know that you are in editing mode
			isNewTextNotAdded=true;
			
			//set focus on the Add button
			this.buttonAdd.Focus();
//			this.disableNavigateButtons();
			this.OK.Enabled=false;
			this.buttonDelete.Enabled=false;
			//this.buttonInsert.Enabled=false;
			this.buttonEdit.Enabled=false;
			this.buttonUpdate.Enabled=false;
			this.buttonAdd.Enabled=true;
			this.buttonNew.Enabled=false;

		}

		private void buttonUpdate_Click(object sender, System.EventArgs e)
		{
			Sessions session = (Sessions)this.parentForm;
			if (session.document[session.docNumber].listText.Count==0)
			{
				MessageBox.Show("Ther are no items in list to update.","Update item in list");
			}
			else
			{
				TextTalkedinSession textBox;
				textBox = (TextTalkedinSession)session.document[session.docNumber].listText[recordIndex];
				textBox.shortText=this.shortTextBox.Text;
				textBox.longText=this.longTextBox.Text;
				session.document[session.docNumber].listText.RemoveAt(recordIndex);
				session.document[session.docNumber].listText.Insert(recordIndex,textBox);
				session.AddTextToTextPanel();
				enableNavigateButtons();
			}
		}
		private void disableNavigateButtons()
		{
			this.buttonDownEnd.Enabled=false;
			this.buttonDownRecord.Enabled=false;
			this.buttonUpEnd.Enabled=false;
			this.buttonUpRecord.Enabled=false;
		}
		private void enableNavigateButtons()
		{
			this.buttonDownEnd.Enabled=true;
			this.buttonDownRecord.Enabled=true;
			this.buttonUpEnd.Enabled=true;
			this.buttonUpRecord.Enabled=true;
		}
		private void buttonEdit_Click(object sender, System.EventArgs e)
		{
			//set the flag in order to know that you are in editing mode
			isNewTextNotAdded=true;
			//OpenTextBoxesForEditing();
			this.shortTextBox.ReadOnly=false;
			this.longTextBox.ReadOnly=false;

			disableNavigateButtons();
			this.disableNavigateButtons();
//			this.OK.Enabled=false;
			this.buttonDelete.Enabled=false;
//			this.buttonInsert.Enabled=true;
//			this.buttonEdit.Enabled=false;
			this.buttonUpdate.Enabled=true;
			this.buttonAdd.Enabled=false;

		}

		private void buttonInsert_Click(object sender, System.EventArgs e)
		{
			isNewTextNotAdded=true;
			//OpenTextBoxesForEditing();
			OpenTextBoxesForEditing();
			//disable the up-down navifation buttons
			disableNavigateButtons();
			this.serialTextBox.Text="";
			this.groupTextBox.Text="";
			this.shortTextBox.Text="";
			this.longTextBox.Text="";
			isInsertMode=true;
			disableNavigateButtons();
			this.disableNavigateButtons();
			this.OK.Enabled=false;
			this.buttonDelete.Enabled=false;
			//this.buttonInsert.Enabled=true;
			this.buttonEdit.Enabled=false;
			this.buttonUpdate.Enabled=true;
			this.buttonAdd.Enabled=true;

		}

		/*private void OK_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{	
			if (isNewTextNotAdded)
			{
				
				MessageBox.Show("You are still in NEW mode. Add the new topic or choose another topic",
					"Add topic to timeline",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);
				this.buttonAdd.Focus();
				return ;
			}
		}*/

		private void OK_Click(object sender, System.EventArgs e)
		{	
			if (isNewTextNotAdded)
			{
				
				MessageBox.Show("You are still in NEW mode. Add the new topic or choose another topic",
					"Add topic to timeline",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);
				this.buttonAdd.Focus();
				return ;
			}
			else 
			{
				this.DialogResult=DialogResult.OK;
				this.Close();
			}
		
		}		
	}
}
