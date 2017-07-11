using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Microsoft.Win32;
using System.Xml.Serialization;



namespace musicTherapy1
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	/// 
	
	public class MainForm : System.Windows.Forms.Form
	{
		[System.Runtime.InteropServices.DllImport("gdi32.dll")]
		public static extern long BitBlt (IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

		private Sessions[] SessionsArray;
		//private InstrumentsDocument instrumentDocument;
		public MainFormDocument mainFormDocument;
		public int numOfSessions=0;
		public string MainDirectory = "d:\\Documents and Settings\\Loki\\My Documents\\Visual Studio Projects\\musicTherapy1.5.3\\";
		//public string MainDirectory = "d:\\Documents and Settings\\amklein\\My Documents\\Visual Studio Projects\\musicTherapy1.5.1";
		public ArrayList instrumentCategorylist = new ArrayList();
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton AddText;
		private System.Windows.Forms.ToolBarButton AddInstrument;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolBarButton colors;
		private System.Windows.Forms.ToolBarButton removeText;
		private System.Windows.Forms.ToolBarButton openFile;
		private System.Windows.Forms.ToolBarButton newFile;
		private System.Windows.Forms.ToolBarButton saveFile;
		private System.Windows.Forms.ToolBarButton seperator9;
		private System.Windows.Forms.ToolBarButton RemoveInstrument;
		public System.Windows.Forms.ImageList InstrumentImageList;
		private System.Windows.Forms.ToolBarButton DrawPixel;
		private System.Windows.Forms.ToolBarButton StopDraw;
		private System.Windows.Forms.ToolBarButton AddOpacPanel;
		private System.Windows.Forms.ToolBarButton BringOpacPanelFront;
		private System.Windows.Forms.ToolBarButton AddArrow;
		private Bitmap memoryImage;
		private System.Windows.Forms.ToolBarButton OpenVideo;
		private System.Windows.Forms.ToolBarButton RemoveArrow;
		private System.Windows.Forms.ToolBarButton AddSing;
		private System.Windows.Forms.ToolBarButton RemoveSing;
		private System.Windows.Forms.ToolBarButton AddScream;
		private System.Windows.Forms.ToolBarButton RemoveScream;
		private System.Windows.Forms.ToolBarButton AddVideo;
		private System.Windows.Forms.ToolBarButton RemoveVideo;
		public StatusBarPanel SessionNumberPannel;
		private System.Windows.Forms.ToolBarButton SessionUP;
		private System.Windows.Forms.ToolBarButton SessionDown;
		private System.Windows.Forms.ToolBarButton PanelUp;
		private System.Windows.Forms.ToolBarButton PanelDown;
		public VideoDirectShow videoForm;
		//public bool VideoTile
		
		private int ShowPanelNumber=0;
		private System.Windows.Forms.ToolBarButton NewSession;
		private int ShowSessionNumber=0;
		private System.Windows.Forms.ToolBarButton AddDisc;
		private System.Windows.Forms.ToolBarButton RemoveDisc;
		public System.Windows.Forms.ToolBarButton instrumentCach1;
		private System.Windows.Forms.ToolBarButton instrumentCach2;
		private System.Windows.Forms.ToolBarButton instrumentCach3;
		private string fileName="";
		static private string tmpFileName="NOFILE";
		//private int NumberOfSessions=0;
		int cachIndex=0;
		private System.Windows.Forms.ToolBarButton RemoveOpac;
		private System.Windows.Forms.ToolBarButton seperator;
		private System.Windows.Forms.ToolBarButton seperator2;
		private System.Windows.Forms.ToolBarButton DeleteSession;
		private System.Windows.Forms.ToolBarButton AddRichText;
		private System.Windows.Forms.ToolBarButton RemoveRichText;
		public InstrumentInfo[] instrumentCachArray;
		

		private void CaptureScreen()
		{
			Graphics mygraphics = this.ActiveMdiChild.CreateGraphics();
			Size s = this.ActiveMdiChild.Size;
			memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
			Graphics memoryGraphics = Graphics.FromImage(memoryImage);
			IntPtr dc1 = mygraphics.GetHdc();
			IntPtr dc2 = memoryGraphics.GetHdc();
			BitBlt(dc2, 0, 0, this.ActiveMdiChild.ClientRectangle.Width, this.ActiveMdiChild.ClientRectangle.Height, dc1, 0, 0, 13369376);
			mygraphics.ReleaseHdc(dc1);
			memoryGraphics.ReleaseHdc(dc2);
		
		}

		private System.ComponentModel.IContainer components;
		~MainForm()
		{
			MessageBox.Show("ffffffffffffffff");
			saveInstrumentInfo();
		}
		public void enableSessionAndPanelNavigationButtons()
		{
			this.PanelDown.Enabled= true;
			this.PanelUp.Enabled= true;
		}
		public void disableSessionAndPanelNavigationButtons()
		{
			this.PanelDown.Enabled= false;
			this.PanelUp.Enabled= false;
		}
		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			getRegistryValues();
			AddMenusaa();
			AddColorMenu();
			LoadInstrumentsInfo();
			initInstrumentManager();
			SessionsArray = new Sessions[5];
			CreateMyStatusBar();
			mainFormDocument = new MainFormDocument();
			videoForm = new VideoDirectShow ();
			videoForm .MdiParent = this;
			disableButtons();
			this.WindowState=FormWindowState.Maximized;			//
			instrumentCachArray= new InstrumentInfo[3];
			initInstrumentCach();
			// TODO: Add any constructor code after InitializeComponent call
			//

			//initInstrumetnInfo();
			
			//ideoForm.Location=new Point(0,0);
			//videoForm.Size=new Size(200,200);
					
			//saveInstrumentInfo();
		}
		private void initInstrumentCach()
		{
			for (int x=0;x<3;x++)
			{
				instrumentCachArray[x]= new InstrumentInfo("","","","");
			}
		}
	
		public void AddColorMenu()
		{
			ContextMenu contextMenu = new ContextMenu();
			this.colors.DropDownMenu = contextMenu;
			
			MenuItem chanhePanelColor = new MenuItem("Change panel color");
			MenuItem chanheFrameColor = new MenuItem("Change frame color");
			
			chanheFrameColor.Click += new System.EventHandler(this.changeFrameColor_Click);
			chanhePanelColor.Click += new System.EventHandler(this.changePanelColor_Click);
			
			contextMenu.MenuItems.Add(chanheFrameColor);
			contextMenu.MenuItems.Add(chanhePanelColor);

		}
		private void getRegistryValues()
		{
			
			RegistryKey rkHKLM = Registry.LocalMachine;
			RegistryKey rkRun;
			try
			{
				rkRun = rkHKLM.OpenSubKey("Software\\Map",true);
			}
			catch
			{
				// error while opening the subkey...
				Console.WriteLine("Unable to open the RUN subkey!");

				// close the HKLM key...
				rkHKLM.Close();
				return;
			}
			string path="installPath";
			MainDirectory=(string)rkRun.GetValue(path);
			// close the subkey...
			rkRun.Close();
			// close the HKLM key...
			rkHKLM.Close();
		}
		public void deleteFromInstrumentInfoList(string instCategory, string instSubCategory, string instName)
		{
			if (instName == "")
			{
				for (int instrumetnCounter=0;instrumetnCounter<this.mainFormDocument.instrumetnInfoList.Count;instrumetnCounter++)
				{
					InstrumentInfo inst = (InstrumentInfo)this.mainFormDocument.instrumetnInfoList[instrumetnCounter];
					if (inst.Category == instCategory &&
						inst.SubCategory == instSubCategory )
						this.mainFormDocument.instrumetnInfoList.RemoveAt(instrumetnCounter);
				}
			}
			else if (instSubCategory == "")
			{
				for (int instrumetnCounter=0;instrumetnCounter<this.mainFormDocument.instrumetnInfoList.Count;instrumetnCounter++)
				{
					InstrumentInfo inst = (InstrumentInfo)this.mainFormDocument.instrumetnInfoList[instrumetnCounter];
					if (inst.Category == instCategory )
						this.mainFormDocument.instrumetnInfoList.RemoveAt(instrumetnCounter);
				}

			}
			else
			{
				for (int instrumetnCounter=0;instrumetnCounter<this.mainFormDocument.instrumetnInfoList.Count;instrumetnCounter++)
				{
					InstrumentInfo inst = (InstrumentInfo)this.mainFormDocument.instrumetnInfoList[instrumetnCounter];
					if (inst.Category == instCategory && inst.SubCategory==instSubCategory &&inst.Name==instName)
						this.mainFormDocument.instrumetnInfoList.RemoveAt(instrumetnCounter);
				}
			}
			this.saveInstrumentInfo();
		}
		public string getInstrumentInfo(string instCategory, string instSubCategory, string instName)
		{
			for (int instrumetnCounter=0;instrumetnCounter<this.mainFormDocument.instrumetnInfoList.Count;instrumetnCounter++)
			{
				InstrumentInfo inst = (InstrumentInfo)this.mainFormDocument.instrumetnInfoList[instrumetnCounter];
				if (inst.Category == instCategory &&
					inst.SubCategory == instSubCategory &&
					inst.Name == instName)
					return inst.Description;
			}
			return "";
		}
		public void initInstrumentManager()
		{
			
			//clear the list
			instrumentCategorylist.Clear();
			
			DirectoryInfo di = new DirectoryInfo(MainDirectory+"\\pictures\\instruments\\");
			DirectoryInfo[] CategoriesDirs = di.GetDirectories();
			
			//_l stands for local variable
			foreach(DirectoryInfo l_Category in CategoriesDirs)
			{	
				DirectoryInfo[] SubCategoriesDirs = l_Category.GetDirectories();
				Category category = new Category();
				
				category.CategoryName = l_Category.Name;
				//if no sub category
				if (SubCategoriesDirs.GetLength(0)==0)
				{
					FileInfo[] rgFiles = l_Category.GetFiles("*.jpg");
					foreach(FileInfo fi in rgFiles)
					{
						myImage imList = new myImage();
						imList.instrumentImage = new Bitmap(fi.FullName);
						imList.instrumentName = fi.ToString();
						category.ImageList.Add(imList);	
						imList.instrumentInfo =new InstrumentInfo(category.CategoryName,"",getInstrumentInfo(category.CategoryName,"",imList.instrumentName ),imList.instrumentName);
//						imList.instrumentInfo.Description=getInstrumentInfo(category.CategoryName,"",imList.instrumentName );
					}
				}
				else // has sub category
				{
					int subCategoryCounter=0;
					foreach(DirectoryInfo l_SubCategory in SubCategoriesDirs)
					{	
						SubCategory subCategory = new SubCategory();
						subCategory.SubCategoryName = l_SubCategory.ToString();
						
						//get file in subCategory
						FileInfo[] rgFiles = l_SubCategory.GetFiles("*.jpg");
						foreach(FileInfo fi in rgFiles)
						{
							myImage imList = new myImage();
							imList.instrumentImage = new Bitmap(fi.FullName);
							imList.instrumentName = fi.ToString();
							imList.instrumentInfo =new InstrumentInfo(category.CategoryName,subCategory.SubCategoryName,getInstrumentInfo(category.CategoryName,"",imList.instrumentName ),imList.instrumentName);
							subCategory.ImageList.Add(imList);
							
						}
						category.SubCategoryList.Add(subCategory);
						//categoryNode.Nodes.Add(subCategoryNode);
						subCategoryCounter++;
					}
				}
				instrumentCategorylist.Add(category);
			}
			

		}
		public void AddMenusaa()
		{
			MainMenu mainMenu = new MainMenu();
			this.Menu = mainMenu;
                  
			//File menu
			MenuItem myMenuItemFile  = new MenuItem("&File");
			MenuItem myMenuItemNew   = new MenuItem("&New");
			MenuItem myMenuItemOpen  = new MenuItem("&Open");
			MenuItem myMenuItemSave  = new MenuItem("&Save");
			MenuItem myMenuItemSaveAs  = new MenuItem("&Save as");
			MenuItem myMenuItemPrint = new MenuItem("&Print");
			//add file menu to main menu
			mainMenu.MenuItems.Add(myMenuItemFile);
			//add other File items to File menu
			myMenuItemFile.MenuItems.Add(myMenuItemNew);
			myMenuItemFile.MenuItems.Add(myMenuItemOpen);
			myMenuItemFile.MenuItems.Add(myMenuItemSave);
			myMenuItemFile.MenuItems.Add(myMenuItemSaveAs);
			myMenuItemFile.MenuItems.Add(myMenuItemPrint);
			//add events to items in File menu
			myMenuItemNew.Click += new System.EventHandler(this.New_Click);
			myMenuItemOpen.Click += new System.EventHandler(this.Open_Click);
			myMenuItemPrint.Click += new System.EventHandler(this.Print_Click);
			myMenuItemSaveAs.Click += new System.EventHandler(this.SaveAs_Click);
			myMenuItemSave.Click += new System.EventHandler(this.Save_Click);
			//View menu
			MenuItem myMenuItemView = new MenuItem ("&View");
			mainMenu.MenuItems.Add(myMenuItemView);
			//Actions Menu
			MenuItem myMenuItemActions = new MenuItem ("&Actions");
			mainMenu.MenuItems.Add(myMenuItemActions);
			MenuItem myMenuItemActionsAddText = new MenuItem("&Add text");
			MenuItem myMenuItemActionsAddVideo = new MenuItem("&Add Video");
			MenuItem myMenuItemActionsRemoveVideo = new MenuItem("&Remove Video");

			myMenuItemActions.MenuItems.Add(myMenuItemActionsAddText);
			myMenuItemActions.MenuItems.Add(myMenuItemActionsAddVideo);
			myMenuItemActions.MenuItems.Add(myMenuItemActionsRemoveVideo);

			myMenuItemActionsAddText.Click += new System.EventHandler(this.ActionsAddText_Click);
			myMenuItemActionsAddVideo.Click += new System.EventHandler(this.ActionsAddVideo_Click);
			myMenuItemActionsRemoveVideo.Click += new System.EventHandler(this.ActionsRemoveVideo_Click);
			//options Menu
			MenuItem myMenuItemOptions = new MenuItem ("&Options");
			mainMenu.MenuItems.Add(myMenuItemOptions);
			MenuItem myMenuItemPreferences = new MenuItem("&Preferences");
			myMenuItemOptions.MenuItems.Add(myMenuItemPreferences);
			myMenuItemPreferences.Click += new System.EventHandler(this.OptionsPreferences_Click);
			//Windows Menu
			MenuItem myMenuItemWindows = new MenuItem("&Windows");
			mainMenu.MenuItems.Add(myMenuItemWindows);
			MenuItem myMenuItemTile = new MenuItem("&Tile");
			myMenuItemWindows.MenuItems.Add(myMenuItemTile);
			myMenuItemTile.Click += new System.EventHandler(this.WindowsTile_Click);
			
		/*	MenuItem myMenuItemStam = new MenuItem("&stam");
			mainMenu.MenuItems.Add(myMenuItemStam);
			MenuItem myMenuItemStam2 = new MenuItem("&stam2");
			myMenuItemStam.MenuItems.Add(myMenuItemStam2);
			myMenuItemStam2.Click += new System.EventHandler(this.StamStam2_Click);
		*/	

		//	this.PanelLabel.Enabled=false;
			//this.PanelLabel.Text=" \n        0   " ;

		}
		private void StamStam2_Click(object sender, System.EventArgs e)
		{
			//this.videoForm.m_movie.Dispose();	
		}
		public void WindowsTile_Click(object sender, System.EventArgs e)
		{
			
			//if (this.videoForm.WindowState ==  WindowState.== null)
			//	return;
			int width=this.Size.Width;
			int height=this.Size.Height;
			if (this.SessionsArray[0]==null)
				return;
			this.SessionsArray[0].Size=new Size(width*3/4,height);
			this.SessionsArray[0].Location = new Point(width/4,0);
			this.videoForm.Size=new Size(width/4,height);
			this.videoForm.Location = new Point(0,0);
			//this.LayoutMdi(MdiLayout.TileVertical);
		}
		private void OptionsPreferences_Click(object sender, System.EventArgs e)
		{
			Preferences Pref= new Preferences();
			Sessions session= (Sessions)this.ActiveMdiChild;
			if (Pref.ShowDialog() == DialogResult.OK)
			{
				session.document[session.docNumber].widthOfTimeLineButton = Pref.timeLineWidth;
			}

		}
		
		private void ActionsAddVideo_Click(object sender, System.EventArgs e)
		{
			this.turnOffAllToolbarButtons();
			//Sessions tmp= (Sessions) this.ActiveMdiChild;
			Sessions tmp= (Sessions) this.SessionsArray[0];
			tmp.AddVideo=true;
			
		}
		private void ActionsRemoveVideo_Click(object sender, System.EventArgs e)
		{
			this.turnOffAllToolbarButtons();
			//Sessions tmp= (Sessions) this.ActiveMdiChild;
			Sessions tmp= (Sessions) this.SessionsArray[0];
			tmp.RemoveVideo=true;
			
			
		}
		
		private void ActionsAddText_Click(object sender, System.EventArgs e)
		{
			AddTextDialogBox doc= new AddTextDialogBox();
			Point pressedButton =new Point();
			Sessions session= (Sessions)this.ActiveMdiChild;
			pressedButton=session.getPressedButton();

			if (pressedButton!=new Point(9,9))// < 0 || pressedButton >60)
			{
				if (doc.ShowDialog() == DialogResult.OK)
				{
					
					//session.document[docNumber].timeLine[pressedButton.X].MinutesArray[pressedButton.Y].longTextSentences= doc.richTextBox1.Text;
					//session.document[docNumber].timeLine[pressedButton.X].MinutesArray[pressedButton.Y].shortTextSentences= doc.richTextBox1.Text;
					//session.AddTextToTextPanel(pressedButton.X,pressedButton.Y,doc.richTextBox1.Text);
				}
			}
			else
				MessageBox.Show("No button in timeline is pressed");

		}

		private void changePanelColor_Click(object sender, System.EventArgs e)
		{
			Sessions temp = (Sessions) this.ActiveMdiChild;
			temp.ChangePanelBackroundColor_Click(sender, e);
		
		
		}
		private void changeFrameColor_Click(object sender, System.EventArgs e)
		{
			Sessions temp = (Sessions) this.ActiveMdiChild;
			temp.ChangeFrameBackroubdColor_Click(sender, e);
		}
		private void initInstrumetnInfo()
		{
			//this.instrumentDocument = new InstrumentsDocument();
			this.mainFormDocument = new MainFormDocument();
			InstrumentInfo instInf = new InstrumentInfo("fff","rrr","eee","rrr");
			instInf.Category="999";
			instInf.Description="999";
			instInf.Name = "999";
			instInf.SubCategory="999";
			this.mainFormDocument.instrumetnInfoList.Add(instInf);
			//this.instrumentDocument.instrumetnInfoList.Add(instInf);
		}
		private void LoadInstrumentsInfo()
		{
			//OpenFileDialog openFileDialog = new OpenFileDialog();
			//openFileDialog.DefaultExt = "*.*";
			//if(openFileDialog.ShowDialog() == DialogResult.OK)
		//	{
		//		Size size = new Size(this.Size.Width,this.Size.Height);
		//		SessionsArray[numOfSessions] = new Sessions(/*size*/);
								
				FileStream fs = new FileStream(this.MainDirectory+"\\instrumentInfo.dat", FileMode.Open);
				try 
				{
					BinaryFormatter formatter = new BinaryFormatter();

					// Deserialize the hashtable from the file and 
					// assign the reference to the local variable.
					this.mainFormDocument = (MainFormDocument)formatter.Deserialize(fs);
					//this.instrumentDocument = (InstrumentsDocument) formatter.Deserialize(fs);
				}
				catch 
				{
					MessageBox.Show("Failed to deserialize. Reason: " );
					Console.WriteLine("Failed to deserialize. Reason: " );
					throw;
				}
				finally 
				{
					fs.Close();
				}
		}
		public void saveInstrumentInfo()
		{
			FileStream fs = new FileStream(this.MainDirectory+"\\instrumentInfo.dat", FileMode.Create);
	
			// Construct a BinaryFormatter and use it to serialize the data to the stream.
			BinaryFormatter formatter = new BinaryFormatter();
			try 
			{
				//Sessions ss= (Sessions)this.ActiveMdiChild;
				//Document doc= ss.document;
				MainFormDocument doc = this.mainFormDocument;
				//InstrumentsDocument doc = this.instrumentDocument;
				formatter.Serialize(fs ,doc);
			}
			catch  
			{
				Console.WriteLine("Failed to serialize. Reason: " );
				throw;
			}
			finally 
			{
				fs.Close();
			}

		}
		private void New_Click(object sender, System.EventArgs e)
		{
			//int numOfPatiants=3;
			NumPatiansDialogBox doc = new NumPatiansDialogBox();
			doc.MyParentForm = this;
			if (doc.ShowDialog() == DialogResult.OK)
			{
				//Size size = new Size(this.Size.Width,this.Size.Height);
				SessionsArray[numOfSessions] = new Sessions(/*size,*/ doc.numOfPatiants, doc.sessionDuration, doc.timeIntervalBetweenBars);
				SessionsArray[numOfSessions].sessionNumber=numOfSessions;
				
				SessionsArray[numOfSessions].MdiParent = this;
				SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber].initTimeLines();
				
				SessionsArray[numOfSessions].AddTextPanel();
				SessionsArray[numOfSessions].drawLines();
				this.enableButtons();
				SessionsArray[numOfSessions].initTextBoxesInTextPanel();
				SessionsArray[numOfSessions].setBackroundColor();
				//SessionsArray[numOfSessions].SuspendLayout();	
				SessionsArray[numOfSessions].drawVideoPanel();
				SessionsArray[numOfSessions].Size = this.Size;
				SessionsArray[numOfSessions].drawVerticalLinesInTimeLine();
				SessionsArray[numOfSessions].mainSplitter.SplitPosition = SessionsArray[numOfSessions].Size.Height* SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber].proportionOfPanelArearAndTextArea/100;
				
				
				SessionsArray[numOfSessions].Show();
				//NumberOfSessions++;
				numOfSessions++; //holds the number of MDI windows open 
				//SessionsArray[numOfSessions].ResumeLayout();
			}
		}

		
		public void disableButtons()
		{
			this.AddInstrument.Enabled= false;
			this.RemoveInstrument.Enabled = false;
			this.AddText.Enabled= false;
			this.removeText.Enabled= false;
			this.colors.Enabled= false;
			this.saveFile.Enabled= false;
			this.AddArrow.Enabled=false;
			this.RemoveArrow.Enabled = false;
			this.AddOpacPanel.Enabled=false;
			this.BringOpacPanelFront.Enabled=false;
			this.AddSing.Enabled = false;
			this.RemoveSing.Enabled = false;
			this.AddScream.Enabled = false;
			this.RemoveScream.Enabled = false;
			this.AddVideo.Enabled=false;
			this.RemoveVideo.Enabled=false;
			this.SessionDown.Enabled=false;
			this.SessionUP.Enabled=false;
			this.PanelDown.Enabled=false;
			this.PanelUp.Enabled=false;
			this.AddDisc.Enabled=false;
			this.RemoveDisc.Enabled=false;
			this.NewSession.Enabled = false;
			this.RemoveOpac.Enabled = false;
			this.BringOpacPanelFront.Enabled = false;
			this.DrawPixel.Enabled = false;
			this.StopDraw.Enabled = false;
			this.instrumentCach1.Enabled = false;
			this.instrumentCach2.Enabled = false;
			this.instrumentCach3.Enabled = false;
			
		}
		private void enableButtons()
		{
			this.AddInstrument.Enabled= true;
			this.RemoveInstrument.Enabled = true;
			this.AddText.Enabled= true;
			this.removeText.Enabled= true;
			this.colors.Enabled= true;
			this.saveFile.Enabled= true;
			this.AddArrow.Enabled=true;
			this.RemoveArrow.Enabled = true;
			this.AddOpacPanel.Enabled=true;
			this.BringOpacPanelFront.Enabled=true;
			this.AddSing.Enabled = true;
			this.RemoveSing.Enabled = true;
			this.AddScream.Enabled = true;
			this.RemoveScream.Enabled = true;
			this.AddVideo.Enabled=true;
			this.RemoveVideo.Enabled=true;
			this.AddDisc.Enabled=true;
			this.RemoveDisc.Enabled=true;
			this.NewSession.Enabled = true;
			this.RemoveOpac.Enabled = true;
			this.BringOpacPanelFront.Enabled = true;
			this.DrawPixel.Enabled = true;
			this.StopDraw.Enabled = true;
			this.instrumentCach1.Enabled = true;
			this.instrumentCach2.Enabled = true;
			this.instrumentCach3.Enabled = true;
			

		}
		private void Open_Click(object sender, System.EventArgs e)
		{
		//	Stream myStream;
			OpenFileDialog openFileDialog = new OpenFileDialog();
			//openFileDialog.DefaultExt = "*.*";
			openFileDialog.Filter = "map files (*.map)|*.map"  ;
			//openFileDialog.Filter = "map files (*.map)|*.map|All files(*.*)|*.*"  ;
			if(openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Size size = new Size(this.Size.Width,this.Size.Height);
				SessionsArray[numOfSessions] = new Sessions(/*size*/);
								
				FileStream fs = new FileStream(openFileDialog.FileName.ToString()/*"C:\\DataFile.dat"*/, FileMode.Open);
				try 
				{
					BinaryFormatter formatter = new BinaryFormatter();

					// Deserialize the hashtable from the file and 
					// assign the reference to the local variable.
					SessionsArray[numOfSessions].document = (Document[]) formatter.Deserialize(fs);
					this.fileName=openFileDialog.FileName.ToString();
				}
				catch 
				{
					MessageBox.Show("Failed to deserialize. Reason: " );
					throw;
				}
				finally 
				{
					fs.Close();
				}
				SessionsArray[numOfSessions].sessionInit();
				SessionsArray[numOfSessions].sessionNumber=numOfSessions;
				SessionsArray[numOfSessions].MdiParent = this;
				SessionsArray[numOfSessions].AddTextPanel();
				SessionsArray[numOfSessions].drawLines();
				enableButtons();
				SessionsArray[numOfSessions].initTextBoxesInTextPanel();
				SessionsArray[numOfSessions].setBackroundColor();
				SessionsArray[numOfSessions].drawVideoPanel();
				SessionsArray[numOfSessions].Size = this.Size;
				
				SessionsArray[numOfSessions].drawVerticalLinesInTimeLine();
				SessionsArray[numOfSessions].mainSplitter.SplitPosition = SessionsArray[numOfSessions].Size.Height* SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber].proportionOfPanelArearAndTextArea/100;
				SessionsArray[numOfSessions].AddTextToTextPanel();
				SessionsArray[numOfSessions].refreshTopicLablesOnButtons();
				SessionsArray[numOfSessions].mainSplitter.SplitPosition = SessionsArray[numOfSessions].Size.Height* SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber].proportionOfPanelArearAndTextArea/100;
				SessionsArray[numOfSessions].refreshInstrumentIndicationInTimeLine();
				SessionsArray[numOfSessions].refreshOpacPanels();
				SessionsArray[numOfSessions].refreshTopicLablesOnButtons();
				SessionsArray[numOfSessions].refreshArrows();
				SessionsArray[numOfSessions].refreshDiscPanels();
				SessionsArray[numOfSessions].refreshRichTextBoxes();
				SessionsArray[numOfSessions].refreshSingScream();
				SessionsArray[numOfSessions].refreshAbsentPatiant();
				SessionsArray[numOfSessions].refreshInstrumentIndicationInTimeLine();
				int numOfDocuments;
				for ( numOfDocuments=0;numOfDocuments<20;numOfDocuments++)
				{
					if (SessionsArray[numOfSessions].document[numOfDocuments] ==null)
						break;
				}
				if (numOfDocuments>0)
				{
					this.SessionDown.Enabled=true;
					this.SessionUP.Enabled=true;
				}
				SessionsArray[numOfSessions].Show();
				
				numOfSessions++;

			}	 
		}
		private void OpenFileFromOutside_Click(string fileName/*object sender, System.EventArgs e*/)
		{
			//	Stream myStream;
			//OpenFileDialog openFileDialog = new OpenFileDialog();
			
			//openFileDialog.Filter = "map files (*.map)|*.map"  ;
			
			//if(openFileDialog.ShowDialog() == DialogResult.OK)
			//{
				Size size = new Size(this.Size.Width,this.Size.Height);
				SessionsArray[numOfSessions] = new Sessions(/*size*/);
								
				FileStream fs = new FileStream(fileName/*"C:\\DataFile.dat"*/, FileMode.Open);
				try 
				{
					BinaryFormatter formatter = new BinaryFormatter();

					// Deserialize the hashtable from the file and 
					// assign the reference to the local variable.
					SessionsArray[numOfSessions].document = (Document[]) formatter.Deserialize(fs);
					this.fileName=fileName;
				}
				catch 
				{
					MessageBox.Show("Failed to deserialize. Reason: " );
					throw;
				}
				finally 
				{
					fs.Close();
				}
				SessionsArray[numOfSessions].sessionInit();
				SessionsArray[numOfSessions].sessionNumber=numOfSessions;
				SessionsArray[numOfSessions].MdiParent = this;
				//NumberOfSessions++;
				//SessionsArray[numOfSessions].document[docNumber].initTimeLines();
				
				SessionsArray[numOfSessions].AddTextPanel();
				SessionsArray[numOfSessions].drawLines();
				enableButtons();
				SessionsArray[numOfSessions].initTextBoxesInTextPanel();
				SessionsArray[numOfSessions].setBackroundColor();
				//SessionsArray[numOfSessions].Show();
				SessionsArray[numOfSessions].drawVideoPanel();
				SessionsArray[numOfSessions].Size = this.Size;
				
				SessionsArray[numOfSessions].drawVerticalLinesInTimeLine();
				SessionsArray[numOfSessions].mainSplitter.SplitPosition = SessionsArray[numOfSessions].Size.Height* SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber].proportionOfPanelArearAndTextArea/100;
				SessionsArray[numOfSessions].AddTextToTextPanel();
				SessionsArray[numOfSessions].refreshTopicLablesOnButtons();
				SessionsArray[numOfSessions].refreshInstrumentIndicationInTimeLine();
				SessionsArray[numOfSessions].mainSplitter.SplitPosition = SessionsArray[numOfSessions].Size.Height* SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber].proportionOfPanelArearAndTextArea/100;
				SessionsArray[numOfSessions].refreshOpacPanels();
				SessionsArray[numOfSessions].refreshTopicLablesOnButtons();
				SessionsArray[numOfSessions].refreshArrows();
				SessionsArray[numOfSessions].refreshDiscPanels();
				SessionsArray[numOfSessions].refreshRichTextBoxes();
				SessionsArray[numOfSessions].refreshSingScream();
				SessionsArray[numOfSessions].refreshAbsentPatiant();
				SessionsArray[numOfSessions].refreshInstrumentIndicationInTimeLine();
					
				int numOfDocuments;
				for ( numOfDocuments=0;numOfDocuments<20;numOfDocuments++)
				{
					if (SessionsArray[numOfSessions].document[numOfDocuments] ==null)
						break;
				}
				if (numOfDocuments>0)
				{
					this.SessionDown.Enabled=true;
					this.SessionUP.Enabled=true;
				}
				SessionsArray[numOfSessions].Show();
				
				numOfSessions++;

			//}	 
		}
		private void Print_Click(object sender, System.EventArgs e)
		{
			CaptureScreen();
			printDocument1.Print();
		}
		
	private void Save_Click(object sender, System.EventArgs e)
	{
		
		SaveFileDialog saveFileDialog = new SaveFileDialog();
 
		saveFileDialog.Filter = "map files (*.map)|*.map|All files (*.*)|*.*"  ;
		saveFileDialog.FilterIndex = 2 ;
		saveFileDialog.RestoreDirectory = true ;
 
		//if(saveFileDialog.ShowDialog() == DialogResult.OK)
		//{
			
		//	FileInfo ff = new FileInfo(saveFileDialog.FileName.ToString());
		//	string fileName;
		//	if (ff.Extension == "")
		//		fileName=ff.FullName+".map";
		//	else
		//		fileName=ff.FullName;
		if (this.fileName=="")
		{
			SaveAs_Click(null,null);
			return;
		}
		  FileStream fs = new FileStream(this.fileName, FileMode.Create);
		//this.fileName=fileName;
			// Construct a BinaryFormatter and use it to serialize the data to the stream.
			BinaryFormatter formatter = new BinaryFormatter();
			try 
			{
				Sessions ss= (Sessions)this.ActiveMdiChild;
				Document[] doc= ss.document;
				formatter.Serialize(fs ,doc);
			}
			catch  
			{
				Console.WriteLine("Failed to serialize. Reason: " );
				throw;
			}
			finally 
			{
				fs.Close();
			}
			this.fileName=fileName;
		//}
}
		private void SaveAs_Click(object sender, System.EventArgs e)
		{
		
			SaveFileDialog saveFileDialog = new SaveFileDialog();
 
			saveFileDialog.Filter = "map files (*.map)|*.map|All files (*.*)|*.*"  ;
			saveFileDialog.FilterIndex = 2 ;
			saveFileDialog.RestoreDirectory = true ;
 
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
			
				FileInfo ff = new FileInfo(saveFileDialog.FileName.ToString());
				string fileName;
				if (ff.Extension == "")
					fileName=ff.FullName+".map";
				else
					fileName=ff.FullName;

				


				FileStream fs = new FileStream(fileName, FileMode.Create);
				this.fileName=fileName;
				// Construct a BinaryFormatter and use it to serialize the data to the stream.
				BinaryFormatter formatter = new BinaryFormatter();
				StreamWriter myWriter = new StreamWriter("myFileName.xml");
				try 
				{
					Sessions ss= (Sessions)this.ActiveMdiChild;
					Document[] doc= ss.document;
					formatter.Serialize(fs ,doc);
					//MySerializableClass myObject = new MySerializableClass();
					// Insert code to set properties and fields of the object.
				//	XmlSerializer mySerializer = new 
				//		XmlSerializer(typeof(Document[]));
					// To write to a file, create a StreamWriter object.
					
				//	mySerializer.Serialize(myWriter, doc);
					
				}
				catch  
				{
					Console.WriteLine("Failed to serialize. Reason: " );
					throw;
				}
				finally 
				{
					fs.Close();
				//	myWriter.Close();
				}
				this.fileName=fileName;
			}
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.newFile = new System.Windows.Forms.ToolBarButton();
			this.openFile = new System.Windows.Forms.ToolBarButton();
			this.saveFile = new System.Windows.Forms.ToolBarButton();
			this.NewSession = new System.Windows.Forms.ToolBarButton();
			this.DeleteSession = new System.Windows.Forms.ToolBarButton();
			this.SessionDown = new System.Windows.Forms.ToolBarButton();
			this.SessionUP = new System.Windows.Forms.ToolBarButton();
			this.PanelDown = new System.Windows.Forms.ToolBarButton();
			this.PanelUp = new System.Windows.Forms.ToolBarButton();
			this.colors = new System.Windows.Forms.ToolBarButton();
			this.OpenVideo = new System.Windows.Forms.ToolBarButton();
			this.seperator9 = new System.Windows.Forms.ToolBarButton();
			this.AddText = new System.Windows.Forms.ToolBarButton();
			this.removeText = new System.Windows.Forms.ToolBarButton();
			this.AddInstrument = new System.Windows.Forms.ToolBarButton();
			this.RemoveInstrument = new System.Windows.Forms.ToolBarButton();
			this.AddArrow = new System.Windows.Forms.ToolBarButton();
			this.RemoveArrow = new System.Windows.Forms.ToolBarButton();
			this.AddSing = new System.Windows.Forms.ToolBarButton();
			this.RemoveSing = new System.Windows.Forms.ToolBarButton();
			this.AddScream = new System.Windows.Forms.ToolBarButton();
			this.RemoveScream = new System.Windows.Forms.ToolBarButton();
			this.AddVideo = new System.Windows.Forms.ToolBarButton();
			this.RemoveVideo = new System.Windows.Forms.ToolBarButton();
			this.AddDisc = new System.Windows.Forms.ToolBarButton();
			this.RemoveDisc = new System.Windows.Forms.ToolBarButton();
			this.AddOpacPanel = new System.Windows.Forms.ToolBarButton();
			this.RemoveOpac = new System.Windows.Forms.ToolBarButton();
			this.BringOpacPanelFront = new System.Windows.Forms.ToolBarButton();
			this.AddRichText = new System.Windows.Forms.ToolBarButton();
			this.RemoveRichText = new System.Windows.Forms.ToolBarButton();
			this.DrawPixel = new System.Windows.Forms.ToolBarButton();
			this.StopDraw = new System.Windows.Forms.ToolBarButton();
			this.seperator = new System.Windows.Forms.ToolBarButton();
			this.seperator2 = new System.Windows.Forms.ToolBarButton();
			this.instrumentCach1 = new System.Windows.Forms.ToolBarButton();
			this.instrumentCach2 = new System.Windows.Forms.ToolBarButton();
			this.instrumentCach3 = new System.Windows.Forms.ToolBarButton();
			this.InstrumentImageList = new System.Windows.Forms.ImageList(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// toolBar1
			// 
			this.toolBar1.AutoSize = false;
			this.toolBar1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.newFile,
																						this.openFile,
																						this.saveFile,
																						this.NewSession,
																						this.DeleteSession,
																						this.SessionDown,
																						this.SessionUP,
																						this.PanelDown,
																						this.PanelUp,
																						this.colors,
																						this.OpenVideo,
																						this.seperator9,
																						this.AddText,
																						this.removeText,
																						this.AddInstrument,
																						this.RemoveInstrument,
																						this.AddArrow,
																						this.RemoveArrow,
																						this.AddSing,
																						this.RemoveSing,
																						this.AddScream,
																						this.RemoveScream,
																						this.AddVideo,
																						this.RemoveVideo,
																						this.AddDisc,
																						this.RemoveDisc,
																						this.AddOpacPanel,
																						this.RemoveOpac,
																						this.BringOpacPanelFront,
																						this.AddRichText,
																						this.RemoveRichText,
																						this.DrawPixel,
																						this.StopDraw,
																						this.seperator,
																						this.seperator2,
																						this.instrumentCach1,
																						this.instrumentCach2,
																						this.instrumentCach3});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.InstrumentImageList;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(976, 88);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// newFile
			// 
			this.newFile.ImageIndex = 0;
			this.newFile.ToolTipText = "New file";
			// 
			// openFile
			// 
			this.openFile.ImageIndex = 1;
			this.openFile.ToolTipText = "Open file";
			// 
			// saveFile
			// 
			this.saveFile.Enabled = false;
			this.saveFile.ImageIndex = 2;
			this.saveFile.ToolTipText = "Save file";
			// 
			// NewSession
			// 
			this.NewSession.ImageIndex = 27;
			this.NewSession.ToolTipText = "New session";
			// 
			// DeleteSession
			// 
			this.DeleteSession.ImageIndex = 27;
			this.DeleteSession.ToolTipText = "Delete Session";
			// 
			// SessionDown
			// 
			this.SessionDown.ImageIndex = 28;
			this.SessionDown.ToolTipText = "Previous sesion";
			// 
			// SessionUP
			// 
			this.SessionUP.ImageIndex = 29;
			this.SessionUP.ToolTipText = "Next session";
			// 
			// PanelDown
			// 
			this.PanelDown.ImageIndex = 28;
			this.PanelDown.ToolTipText = "Previous staff";
			// 
			// PanelUp
			// 
			this.PanelUp.ImageIndex = 29;
			this.PanelUp.ToolTipText = "Next staff";
			// 
			// colors
			// 
			this.colors.Enabled = false;
			this.colors.ImageIndex = 7;
			this.colors.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.colors.ToolTipText = "Change color";
			// 
			// OpenVideo
			// 
			this.OpenVideo.ImageIndex = 24;
			this.OpenVideo.ToolTipText = "Open video ";
			// 
			// seperator9
			// 
			this.seperator9.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// AddText
			// 
			this.AddText.Enabled = false;
			this.AddText.ImageIndex = 3;
			this.AddText.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.AddText.ToolTipText = "Add text";
			// 
			// removeText
			// 
			this.removeText.Enabled = false;
			this.removeText.ImageIndex = 4;
			this.removeText.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.removeText.ToolTipText = "Remove text";
			// 
			// AddInstrument
			// 
			this.AddInstrument.Enabled = false;
			this.AddInstrument.ImageIndex = 5;
			this.AddInstrument.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.AddInstrument.ToolTipText = "Add instrument";
			// 
			// RemoveInstrument
			// 
			this.RemoveInstrument.Enabled = false;
			this.RemoveInstrument.ImageIndex = 6;
			this.RemoveInstrument.ToolTipText = "Remove instrument";
			// 
			// AddArrow
			// 
			this.AddArrow.ImageIndex = 8;
			this.AddArrow.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.AddArrow.ToolTipText = "Add arrow";
			// 
			// RemoveArrow
			// 
			this.RemoveArrow.ImageIndex = 9;
			this.RemoveArrow.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.RemoveArrow.ToolTipText = "Remove arrow";
			// 
			// AddSing
			// 
			this.AddSing.ImageIndex = 12;
			this.AddSing.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.AddSing.ToolTipText = "Add vocal expression";
			// 
			// RemoveSing
			// 
			this.RemoveSing.ImageIndex = 13;
			this.RemoveSing.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.RemoveSing.ToolTipText = "Remove vocal expression";
			// 
			// AddScream
			// 
			this.AddScream.ImageIndex = 16;
			this.AddScream.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.AddScream.ToolTipText = "Add scream";
			// 
			// RemoveScream
			// 
			this.RemoveScream.ImageIndex = 17;
			this.RemoveScream.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.RemoveScream.ToolTipText = "Remove scream";
			// 
			// AddVideo
			// 
			this.AddVideo.ImageIndex = 10;
			this.AddVideo.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.AddVideo.ToolTipText = "Add video excerpt";
			// 
			// RemoveVideo
			// 
			this.RemoveVideo.ImageIndex = 11;
			this.RemoveVideo.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.RemoveVideo.ToolTipText = "Remove video excerpt";
			// 
			// AddDisc
			// 
			this.AddDisc.ImageIndex = 14;
			this.AddDisc.ToolTipText = "Add disc representation";
			// 
			// RemoveDisc
			// 
			this.RemoveDisc.ImageIndex = 15;
			this.RemoveDisc.ToolTipText = "Remove disc representaion";
			// 
			// AddOpacPanel
			// 
			this.AddOpacPanel.ImageIndex = 20;
			this.AddOpacPanel.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.AddOpacPanel.ToolTipText = "Add Opac panel";
			// 
			// RemoveOpac
			// 
			this.RemoveOpac.ImageIndex = 21;
			this.RemoveOpac.ToolTipText = "Remove opac panel";
			// 
			// BringOpacPanelFront
			// 
			this.BringOpacPanelFront.ImageIndex = 30;
			this.BringOpacPanelFront.ToolTipText = "flip for/background";
			// 
			// AddRichText
			// 
			this.AddRichText.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			// 
			// RemoveRichText
			// 
			this.RemoveRichText.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			// 
			// DrawPixel
			// 
			this.DrawPixel.ImageIndex = 22;
			this.DrawPixel.ToolTipText = "Add scribble";
			// 
			// StopDraw
			// 
			this.StopDraw.ImageIndex = 23;
			this.StopDraw.ToolTipText = "Remove scribble";
			// 
			// seperator
			// 
			this.seperator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// seperator2
			// 
			this.seperator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// instrumentCach1
			// 
			this.instrumentCach1.ImageIndex = 31;
			this.instrumentCach1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.instrumentCach1.ToolTipText = "Previous instrument1";
			// 
			// instrumentCach2
			// 
			this.instrumentCach2.ImageIndex = 32;
			this.instrumentCach2.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.instrumentCach2.ToolTipText = "Previous instrument2";
			// 
			// instrumentCach3
			// 
			this.instrumentCach3.ImageIndex = 33;
			this.instrumentCach3.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.instrumentCach3.ToolTipText = "Previous instrument3";
			// 
			// InstrumentImageList
			// 
			this.InstrumentImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.InstrumentImageList.ImageSize = new System.Drawing.Size(32, 32);
			this.InstrumentImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("InstrumentImageList.ImageStream")));
			this.InstrumentImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// toolTip1
			// 
			this.toolTip1.AutomaticDelay = 100;
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(976, 566);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.toolBar1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Therapy Session Explorer";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{
			
			if( args.Length == 1 ) 
			{
				tmpFileName = Path.GetFullPath(args[0]);
				//MessageBox.Show("ggggg " +Path.GetFullPath(args[0]));
			}

			Application.Run(new MainForm());
		}

		

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			e.Graphics.DrawImage(memoryImage, 0, 0);
//			e.Graphics.DrawString("SampleText", 
//				new Font("Arial", 80, FontStyle.Bold), Brushes.Black, 150, 125);


		}

		private void TextPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}
		public void turnOffAllToolbarButtons()
		{
			this.AddText.Pushed= false;
			this.removeText.Pushed= false;
			this.AddInstrument.Pushed = false;
			this.RemoveInstrument.Pushed = false;
			this.AddOpacPanel.Pushed = false;
			this.RemoveOpac.Pushed = false;
			this.AddSing.Pushed = false;
			this.RemoveSing.Pushed = false;
			this.AddScream.Pushed = false;
			this.RemoveScream.Pushed = false;
			this.AddDisc.Pushed = false;
			this.RemoveDisc.Pushed = false;
			this.AddArrow.Pushed = false;
			this.RemoveArrow.Pushed = false;
			this.AddRichText.Pushed = false;
			this.RemoveRichText.Pushed = false;
			

			//update session pressed button flags
			Sessions tmp= (Sessions) this.SessionsArray[0];//this.ActiveMdiChild;
			tmp.AddTextButtonPushed = false;
			tmp.AddInstrumentButtonPushed = false;
			tmp.RemoveInstrumentButtonPushed = false;
			tmp.RemoveTextButtonPushed = false;
			tmp.AddOpacPanel = false;
			tmp.RemoveOpac = false;
			tmp.AddArrow = false;
			tmp.RemoveArrow = false;
			tmp.AddVideo = false;
			tmp.RemoveVideo=false;
			tmp.AddSingSinus = false;
			tmp.RemoveSingSinus = false;
			tmp.AddScreamZigzag = false;
			tmp.RemoveScreapZigzag = false;
			tmp.AddDisc = false;
			tmp.RemoveDisc = false;
			tmp.RichText = false;
			tmp.RemoveRichText = false;

		}
		private void turnOfInstrumentCachButtons()
		{
			this.instrumentCach1.Pushed = false;
			this.instrumentCach2.Pushed = false;
			this.instrumentCach3.Pushed = false;
		}

		private void updateSessionAndPanelInStatusBar()
		{
			this.SessionNumberPannel.Text="Session: "+ (this.ShowSessionNumber+1)+" ;Panel: " +(this.ShowPanelNumber+1);
		}
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == AddRichText)
			{
				//aaa
				turnOffAllToolbarButtons();
				this.AddRichText.Pushed = true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.RichText= true;
			}
			if (e.Button == RemoveRichText)
			{
				//aaa
				turnOffAllToolbarButtons();
				this.RemoveRichText.Pushed = true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.RemoveRichText= true;
			}

			if (e.Button == instrumentCach1)
			{
				if (instrumentCach1.Pushed)
				{
					turnOfInstrumentCachButtons();
					this.instrumentCach1.Pushed = true;
					Sessions tmp= (Sessions) this.ActiveMdiChild;
					tmp.usingCachInstrument=1;
				}
				else
				{
					Sessions tmp= (Sessions) this.ActiveMdiChild;
					tmp.usingCachInstrument=0;
				}


			}
			if (e.Button == instrumentCach2)
			{
				if (instrumentCach2.Pushed)
				{
					turnOfInstrumentCachButtons();
					this.instrumentCach2.Pushed = true;
					Sessions tmp= (Sessions) this.ActiveMdiChild;
					tmp.usingCachInstrument=2;
				}
				else
				{
					Sessions tmp= (Sessions) this.ActiveMdiChild;
					tmp.usingCachInstrument=0;
				}
			}
			if (e.Button == instrumentCach3)
			{
				if (instrumentCach3.Pushed)
				{
					turnOfInstrumentCachButtons();
					this.instrumentCach3.Pushed = true;
					Sessions tmp= (Sessions) this.ActiveMdiChild;
					tmp.usingCachInstrument=3;
				}
				else
				{
					Sessions tmp= (Sessions) this.ActiveMdiChild;
					tmp.usingCachInstrument=0;
				}
			}
			
			if (e.Button == AddDisc)
			{
				turnOffAllToolbarButtons();
				this.AddDisc.Pushed = true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.AddDisc= true;
			}
			if (e.Button == RemoveDisc)
			{
				turnOffAllToolbarButtons();
				this.RemoveDisc.Pushed = true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.RemoveDisc= true;
			}

			if (e.Button == AddVideo)
				ActionsAddVideo_Click(null,null);
			if (e.Button == RemoveVideo)
				ActionsRemoveVideo_Click(null,null);
			if (e.Button == DeleteSession)
			{
				

				
				//int numOfPatiants=3;
				//SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber]=null;
				//SessionsArray[numOfSessions].docNumber--;

				Sessions sesion = (Sessions)this.ActiveMdiChild;
				int numOfDocuments;
				//calculate the number of documents in session
				for ( numOfDocuments=0;numOfDocuments<20;numOfDocuments++)
				{
					if (sesion.document[numOfDocuments] ==null)
						break;
				}
				//check if can delete
				if ( numOfDocuments>1)
				{
					if (ShowSessionNumber ==0)
					{
						ShowSessionNumber=0;
					}
					else
					{
						ShowSessionNumber--;
					}
					ShowPanelNumber=0;
					//sesion.docNumber--;
				}
				else return;
				if(numOfDocuments==2)
				{
					this.SessionDown.Enabled=false;
					this.SessionUP.Enabled=false;
				}
				updateSessionAndPanelInStatusBar();
				
				int x;
				for( x=sesion.docNumber;x<numOfDocuments;x++)
					sesion.document[x]=sesion.document[x+1];
				sesion.document[x+1]=null;
				if (sesion.docNumber==0)
					sesion.docNumber=0;
				else
					sesion.docNumber--;
				SessionsArray[numOfSessions].ClearSessionControls();
				//update also panel
				if(SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber].numOfPatiants>6)
				{
					sesion.ActiveSessionPanel=this.ShowPanelNumber;
					for ( x=1;x<=sesion.document[sesion.docNumber].numOfPanelsInSession;x++)
					{
						sesion.timeLinePanel[x-1].Hide();
					}
					sesion.timeLinePanel[this.ShowPanelNumber].Show();
				}
			
			}
			if (e.Button == NewSession)
			{

				this.SessionDown.Enabled=true;
				this.SessionUP.Enabled=true;
				//int numOfPatiants=3;
				SessionsArray[numOfSessions].docNumber++;
				SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber]=new Document( SessionsArray[numOfSessions].document[(SessionsArray[numOfSessions].docNumber-1)].numOfPatiants ,
															SessionsArray[numOfSessions].document[(SessionsArray[numOfSessions].docNumber-1)].sessionDuration ,
															SessionsArray[numOfSessions].document[(SessionsArray[numOfSessions].docNumber-1)].intervalBetweenDashedVerticalLinesInTimeLine);
				
				SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber].initTimeLines();
				ShowSessionNumber++;
				ShowPanelNumber=0;
				SessionsArray[numOfSessions].ClearSessionControls();
				updateSessionAndPanelInStatusBar();
				if(SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber].numOfPatiants>6)
				{
					//update also panel
					SessionsArray[numOfSessions].ActiveSessionPanel=this.ShowPanelNumber;
					for (int x=1;x<=SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber].numOfPanelsInSession;x++)
					{
						SessionsArray[numOfSessions].timeLinePanel[x-1].Hide();
					}
					SessionsArray[numOfSessions].timeLinePanel[this.ShowPanelNumber].Show();
				}
				//NumberOfSessions++;
				
			}
			if (e.Button == PanelDown)
			{
				if (ShowPanelNumber >0)
					ShowPanelNumber--;
				else
					return;
				updateSessionAndPanelInStatusBar();
				//this.SessionNumberPannel.Text="Session: "+ this.ShowSessionNumber+" ;Panel: " +this.ShowPanelNumber+1;
				//this.PanelLabel.Text=" \n   " + this.PanelhScrollBar.Value.ToString();
				Sessions sesion = (Sessions)this.ActiveMdiChild;
				sesion.ActiveSessionPanel=ShowPanelNumber;
				for (int x=1;x<=sesion.document[sesion.docNumber].numOfPanelsInSession;x++)
				{
					sesion.timeLinePanel[x-1].Hide();
				}
				sesion.timeLinePanel[this.ShowPanelNumber/*PanelhScrollBar.Value-1*/].Show();
			}
			if (e.Button == PanelUp)
			{
				if (ShowPanelNumber <2)
					ShowPanelNumber++;
				else
					return;
				updateSessionAndPanelInStatusBar();
				Sessions sesion = (Sessions)this.ActiveMdiChild;
				sesion.ActiveSessionPanel=this.ShowPanelNumber;
				for (int x=1;x<=sesion.document[sesion.docNumber].numOfPanelsInSession;x++)
				{
					sesion.timeLinePanel[x-1].Hide();
				}
				sesion.timeLinePanel[this.ShowPanelNumber].Show();
			}
			if (e.Button == SessionUP)
			{
				Sessions sesion = (Sessions)this.ActiveMdiChild;
				int numOfDocuments;
				for ( numOfDocuments=0;numOfDocuments<20;numOfDocuments++)
				{
					if (sesion.document[numOfDocuments] ==null)
						break;
				}
				
				if (ShowSessionNumber <(numOfDocuments-1))
				{
					ShowSessionNumber++;
					ShowPanelNumber=0;
					sesion.docNumber++;
				}
				else return;
				updateSessionAndPanelInStatusBar();
				SessionsArray[numOfSessions].ClearSessionControls();
				
				//update also panel
				if(SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber].numOfPatiants>6)
				{
					sesion.ActiveSessionPanel=this.ShowPanelNumber;
					for (int x=1;x<=sesion.document[sesion.docNumber].numOfPanelsInSession;x++)
					{
						sesion.timeLinePanel[x-1].Hide();
					}
					sesion.timeLinePanel[this.ShowPanelNumber].Show();
				}
			}
			if (e.Button == SessionDown)
			{
				Sessions sesion = (Sessions)this.ActiveMdiChild;
				if (ShowSessionNumber >0)
				{
					ShowSessionNumber--;
					ShowPanelNumber=0;
					sesion.docNumber--;

				}
				else return;
				updateSessionAndPanelInStatusBar();
				SessionsArray[numOfSessions].ClearSessionControls();
				
				//update also panel
				if(SessionsArray[numOfSessions].document[SessionsArray[numOfSessions].docNumber].numOfPatiants>6)
				{
					sesion.ActiveSessionPanel=this.ShowPanelNumber;
					for (int x=1;x<=sesion.document[sesion.docNumber].numOfPanelsInSession;x++)
					{
						sesion.timeLinePanel[x-1].Hide();
					}
					sesion.timeLinePanel[this.ShowPanelNumber].Show();
				}
			}
			if (e.Button == AddSing )
			{
				turnOffAllToolbarButtons();
				this.AddSing.Pushed = true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.AddSingSinus = true;
			}
			if (e.Button == AddScream )
			{
				turnOffAllToolbarButtons();
				this.AddScream.Pushed = true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.AddScreamZigzag = true;
			}
			if (e.Button == RemoveSing )
			{
				turnOffAllToolbarButtons();
				this.RemoveSing.Pushed = true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.RemoveSingSinus = true;
			}
			if (e.Button == RemoveScream )
			{
				turnOffAllToolbarButtons();
				this.RemoveScream.Pushed = true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.RemoveScreapZigzag = true;
			}
			if (e.Button == OpenVideo)
			{
				//Sessions tmp= (Sessions) this.ActiveMdiChild;
				if (videoForm ==null)
				{
					videoForm = new VideoDirectShow ();
					videoForm .MdiParent = this;
				}
				
				Sessions tmp= (Sessions) this.SessionsArray[0];//this.ActiveMdiChild;
				if (tmp !=null)
				tmp.WindowState = FormWindowState.Normal;
				videoForm.WindowState = FormWindowState.Normal;
				videoForm.Show();
				WindowsTile_Click(null , null);
				//VideoDirectShow videoDirecShow = new VideoDirectShow();
			}			
			if (e.Button == AddArrow)
			{
				turnOffAllToolbarButtons();
				this.AddArrow.Pushed=true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.AddArrow = true;
				
			}
			if (e.Button == RemoveArrow)
			{
				turnOffAllToolbarButtons();
				this.RemoveArrow.Pushed=true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.RemoveArrow= true;
			}
			if (e.Button == BringOpacPanelFront)
			{
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.BringOpacPanelsToFront();
			}
			if (e.Button == AddOpacPanel)
			{
				turnOffAllToolbarButtons();
				this.AddOpacPanel.Pushed=true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.AddOpacPanel = true;
				
			}
			if (e.Button == RemoveOpac)
			{
				turnOffAllToolbarButtons();
				this.RemoveOpac.Pushed=true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.RemoveOpac = true;
				
			}
			if ( e.Button == AddInstrument )
			{
				turnOffAllToolbarButtons();
				this.AddInstrument.Pushed = true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.AddInstrumentButtonPushed = true;
			} 
			if ( e.Button == RemoveInstrument )
			{
				turnOffAllToolbarButtons();
				this.RemoveInstrument.Pushed = true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.RemoveInstrumentButtonPushed = true;
			} 
			if ( e.Button == this.newFile )
				this.New_Click(sender,e);		
			if (e.Button == this.saveFile)
				this.Save_Click(sender,e);
			if ( e.Button == this.openFile )
				this.Open_Click(sender,e);		
			if ( e.Button == AddText )
			{
				turnOffAllToolbarButtons();
				this.AddText.Pushed= true;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.AddTextButtonPushed = true;
			}
			if ( e.Button == DrawPixel)
			{
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.openPictureBoxForScrabling();
			}
			if ( e.Button == StopDraw)
			{
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				tmp.stopScrabling();
			}
			
			if ( e.Button == removeText )
			{
				this.AddText.Pushed= false;
				this.removeText.Pushed= true;
				this.AddInstrument.Pushed = false;
				this.RemoveInstrument.Pushed = false;
				this.AddOpacPanel.Pushed = false;
				Sessions tmp= (Sessions) this.ActiveMdiChild;
				//update session pressed button flags
				tmp.AddTextButtonPushed = false;
				tmp.AddInstrumentButtonPushed = false;
				tmp.RemoveInstrumentButtonPushed = false;
				tmp.RemoveTextButtonPushed = true;
				tmp.AddOpacPanel = false;
				
			}
		}
		private void CreateMyStatusBar()
		{
			// Create a StatusBar control.
			StatusBar statusBar1 = new StatusBar();
			// Create two StatusBarPanel objects to display in the StatusBar.
			StatusBarPanel panel1 = new StatusBarPanel();
			StatusBarPanel panel2 = new StatusBarPanel();
			SessionNumberPannel = new StatusBarPanel();

			// Display the first panel with a sunken border style.
			panel1.BorderStyle = StatusBarPanelBorderStyle.Sunken;
			// Initialize the text of the panel.
			panel1.Text = "Ready...";
			// Set the AutoSize property to use all remaining space on the StatusBar.
			panel1.AutoSize = StatusBarPanelAutoSize.Spring;
    
			// Display the second panel with a raised border style.
			panel2.BorderStyle = StatusBarPanelBorderStyle.Raised;
    
			// Create ToolTip text that displays time the application was 
			//started.
			panel2.ToolTipText = "Started: " + System.DateTime.Now.ToShortTimeString();
			// Set the text of the panel to the current date.
			panel2.Text = System.DateTime.Today.ToLongDateString();
			// Set the AutoSize property to size the panel to the size of the contents.
			panel2.AutoSize = StatusBarPanelAutoSize.Contents;
                
			SessionNumberPannel.Text="-- -- --";
			// Display panels in the StatusBar control.
			statusBar1.ShowPanels = true;

			// Add both panels to the StatusBarPanelCollection of the StatusBar.            
			statusBar1.Panels.Add(panel1);
			statusBar1.Panels.Add(SessionNumberPannel);
			statusBar1.Panels.Add(panel2);
			

			// Add the StatusBar to the form.
			this.Controls.Add(statusBar1);
		}

	/*	private void hScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			
			//this.PanelLabel.Text=" \n   " + this.PanelhScrollBar.Value.ToString();
			Sessions sesion = (Sessions)this.ActiveMdiChild;
			sesion.ActiveSessionPanel=this.PanelhScrollBar.Value;
			for (int x=1;x<=sesion.document[docNumber].numOfPanelsInSession;x++)
			{
				sesion.timeLinePanel[x-1].Hide();
			}
			sesion.timeLinePanel[this.PanelhScrollBar.Value-1].Show();
		}
*/
		private void MainForm_Load(object sender, System.EventArgs e)
		{
			if (tmpFileName!="NOFILE")
				OpenFileFromOutside_Click(tmpFileName);
		}

		
		public void setPictureCach(InstrumentInfo picture)
		{
		//toolbar buttons 35-37 are the instrument cach buttons
		// if you add another button don't forget to update the numbers here
			instrumentCachArray[2]=instrumentCachArray[1];
			instrumentCachArray[1]=instrumentCachArray[0];
			instrumentCachArray[0]=picture;
			this.InstrumentImageList.Images.RemoveAt(33);
			this.InstrumentImageList.Images.RemoveAt(32);
			this.InstrumentImageList.Images.RemoveAt(31);

			if (instrumentCachArray[0].Name!= "")
			{
				string fileName = this.MainDirectory+ "\\pictures\\instruments\\" +instrumentCachArray[0].Category+ "\\" + instrumentCachArray[0].SubCategory+ "\\" +instrumentCachArray[0].Name;
				Bitmap  image1 = new Bitmap(fileName);
				this.InstrumentImageList.Images.Add(image1);
				this.toolBar1.Buttons[35].ImageIndex=31;
				
			}
			else
			{
				string fileName = this.MainDirectory+ "\\pictures\\instrumentCach.ico" ;
				Bitmap  image1 = new Bitmap(fileName);
				this.InstrumentImageList.Images.Add(image1);
				this.toolBar1.Buttons[35].ImageIndex=31;
			}
			if (instrumentCachArray[1].Name != "")
			{
				string fileName = this.MainDirectory+ "\\pictures\\instruments\\" +instrumentCachArray[1].Category+ "\\" + instrumentCachArray[1].SubCategory+ "\\" +instrumentCachArray[1].Name;
				Bitmap  image1 = new Bitmap(fileName);
				this.InstrumentImageList.Images.Add(image1);
				this.toolBar1.Buttons[36].ImageIndex=32;
			}
			else
			{
				string fileName = this.MainDirectory+ "pictures\\instrumentCach.ico" ;
				Bitmap  image1 = new Bitmap(fileName);
				this.InstrumentImageList.Images.Add(image1);
				this.toolBar1.Buttons[36].ImageIndex=32;
			}
			if (instrumentCachArray[2].Name != "")
			{
				string fileName = this.MainDirectory+ "\\pictures\\instruments\\" +instrumentCachArray[2].Category+ "\\" + instrumentCachArray[2].SubCategory+ "\\" +instrumentCachArray[2].Name;
				Bitmap  image1 = new Bitmap(fileName);
				this.InstrumentImageList.Images.Add(image1);
				this.toolBar1.Buttons[37].ImageIndex=33;
			}
			else
			{
				string fileName = this.MainDirectory+ "\\pictures\\instrumentCach.ico" ;
				Bitmap  image1 = new Bitmap(fileName);
				this.InstrumentImageList.Images.Add(image1);
				this.toolBar1.Buttons[37].ImageIndex=33;
			}
			this.toolBar1.Invalidate();
		}
		private void instrumentPictureBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		//	PictureBox button = (PictureBox)sender;
		//	button.DoDragDrop(button.Image.ToString(), DragDropEffects.Scroll );
		}

		private void instrumentPictureBox_Click(object sender, System.EventArgs e)
		{
		
		}

		

		
	}

	public class AButton : Button
	{
		public AButton() { }
		public int x, y;
		public bool Pressed=false;
		public bool PrevPressed= false;
		
		private void InitializeComponent()
		{
			this.SuspendLayout();
			this.ResumeLayout(false);
		}
	}
	public class APictureBox : PictureBox
	{
		public int x, y;
		public bool atBack=false;
	}

	public class APanel : Panel
	{
		public APanel() { }
		public int panelNumber;
	}
	public class ARichTextBox : RichTextBox
	{
		public ARichTextBox() { }
		public RichTextBox richTextBox;
		public int RichTectBoxNumber;
	}
	public class ALable : Label
	{
		public ALable() { }
		public int x, y;
		public bool Pressed=false;
		public bool PrevPressed= false;
		
		private void InitializeComponent()
		{
			this.SuspendLayout();
			this.ResumeLayout(false);
		}
	}
}
