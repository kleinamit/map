using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using AmitOpacControl;
using AmitSingSinusControl;
using DShowNET;
//using AmitBracesControl;
//*************************************************
// This program was written by Amit Klein         *
//*************************************************

//using Aurigma.GraphicsMill.Transforms;


namespace musicTherapy1
{
    public class Sessions : System.Windows.Forms.Form
	{
		
		
		public MainForm MyParentForm;
		public Document[] document;
		public int sessionNumber;
		private AButton[,] ButtonArray;
		//private ALable[,] LableArray;
		private TextBox[,] TextBoxArray;
		private APictureBox[,] InstrumentPictureArray;
        //private PictureBox[] CurlyBracesArray;
        private AmitBracesUserControl[] CurlyBracesArray;
		private ALable[,] NameButtonArray;
		private AButton[,] EndInstrumentSectionButtonArray;
		private ToolTip sessionToolTip;
		public bool AddTextButtonPushed= false;
		public bool AddInstrumentButtonPushed = false;
		public bool RemoveTextButtonPushed = false;
		public bool RemoveInstrumentButtonPushed = false;
		public bool AddOpacPanel = false;
		public bool RemoveOpac = false;
        public bool AddSilence = false;
        public bool RemoveSilence = false;
        public bool RemoveMusicNotes = false;
        public bool AddMusicNotes = false;
        public bool AddFrame = false;
        public bool RemoveFrame = false;
        
        public bool Legend = false;
        public bool AddArrow=false;
		public bool RemoveArrow=false;
		public bool AddVideo= false;
		public bool RemoveVideo= false;
		public bool AddSingSinus = false;
		public bool RemoveSingSinus = false;
		public bool AddScreamZigzag= false;
		public bool RemoveScreapZigzag = false;
		public bool AddDisc = false;
		public bool RemoveDisc = false;
		public bool RichText = false;
		public bool RemoveRichText = false;
		public Panel TextPanel;
		public APanel[] timeLinePanel;
		public APanel[] videoPanel;
		public Bitmap[] bitmapArray;
		private System.Windows.Forms.ContextMenu mainContextMenu;
		public int ChoosedInstrument=0;
		public int ActiveSessionPanel=1;
		private System.Windows.Forms.MenuItem AddText;
		private System.Windows.Forms.MenuItem RemoveText;
		private System.Windows.Forms.MenuItem ChanheColors;
		private System.Windows.Forms.MenuItem ChangeBackroubdColor;
		private System.Windows.Forms.MenuItem ChangePanelBackroundColor;
		private System.Windows.Forms.ImageList InstrumentImageList;
		private System.ComponentModel.IContainer components;
		private bool isWaitingForinstrumentEndSectionClick;
		private bool isWaitingForOpacPanelEnsdSectionClick;
        private bool isWaitingForSilencePanelEnsdSectionClick;
        private bool isWaitingForFramePanelEnsdSectionClick;
        private bool isWaitingForMusicNotesEnsdSectionClick;
		private bool isWaitingForArrowEndClick;
		private bool isWaitingForSingSectionEndClick;
		private bool isWaitingForDiscEndClick;
		private InstrumentInfo cachInstrumentInfo;
		public int usingCachInstrument=0;
		//private bool isWaitingForScreamSectionEndClick;
		public Panel mainPanel; 
		public  Splitter mainSplitter ;
		Point startInstrumentSection = new Point();
		Point startOpacPanelSection = new Point();
        Point startSilencePanelSection = new Point();
        Point startFramePanelSection = new Point();
        Point startMusicNotesSection = new Point();
		Point startArrowPosition = new Point();
		Point startSingPosition = new Point();
		Point startDiscPosition = new Point();
		//Point startScreamPosition = new Point();
		InstrumentInfo tmpInstrInfo;
		
		private bool shouldPaint = false;
		//private Bitmap bitmap = new Bitmap(1000,1000);
		private PictureBox generalPictureBox= new PictureBox();
		private Panel bitmapPanel= new Panel();
		private bool startDrawing = false;
		private ArrayList OpacPanelsArrayList;
        private ArrayList SilencePanelsArrayList;
        private ArrayList FramePanelsArrayList;
        private ArrayList TopicLablesArrayList;
        private ArrayList MusicNotesPanelsArrayList;
		private ArrayList SingScreamArrayList;
		private ArrayList DiscArrayList;
		private ArrayList RichTextList;
		private AmitOpacUserControl opac;
		private bool bringOpacPanelsToFront=false;
		private ContextMenu ButtonsContextMenu = new ContextMenu();
		private bool startArroFromButton=false;
		private int videoPanelClicked=0;
		private int CurrentVidoeStartPoint=0;
		private bool VideoIndicatorColor=false;
		public int docNumber=0;
        public bool _bFullScreenMode = false;
        public int MaxNumOfPatiantsBeforeSplitingTimePanel = 8;

        public bool isDoubleClick = false;
		public Sessions(/*Size size,*/ int numOfPatiants, int sessionDuration, int timeIntervalBetweenBars)
		{
			document = new Document[20];
			document[0]=new Document(numOfPatiants,sessionDuration,timeIntervalBetweenBars);
			InitializeComponent();
			ButtonArray = new AButton[document[docNumber].numOfPatiants,document[docNumber].sessionDuration*2];
			EndInstrumentSectionButtonArray= new AButton[document[docNumber].numOfPatiants,document[docNumber].sessionDuration*2];
//			LableArray  = new ALable[document[docNumber].numOfPatiants,document[docNumber].sessionDuration*2];
			TextBoxArray = new TextBox[document[docNumber].numOfTextBoxInColumn,document[docNumber].numOfTextBoxColumns];
			InstrumentPictureArray = new APictureBox[document[docNumber].numOfPatiants,document[docNumber].sessionDuration*2];
			//CurlyBracesArray = new PictureBox[document[docNumber].numOfPanelsInSession];
            CurlyBracesArray = new AmitBracesUserControl[document[docNumber].numOfPanelsInSession];
			timeLinePanel =new APanel[document[docNumber].numOfPanelsInSession];
			videoPanel = new APanel[document[docNumber].numOfPanelsInSession];
			bitmapArray = new Bitmap[document[docNumber].numOfPanelsInSession];
			NameButtonArray = new ALable[document[docNumber].numOfPanelsInSession,document[docNumber].numOfPatiants];
			sessionToolTip = new ToolTip();
			OpacPanelsArrayList = new ArrayList();
            SilencePanelsArrayList = new ArrayList();
            FramePanelsArrayList = new ArrayList();
            TopicLablesArrayList = new ArrayList();
            MusicNotesPanelsArrayList = new ArrayList();
			SingScreamArrayList = new ArrayList();
			DiscArrayList = new ArrayList();
			RichTextList  = new ArrayList();
			opac = new AmitOpacUserControl();
			AddContextMenuForButtons();
			this.WindowState = FormWindowState.Maximized;
            //KeyEventArgs dd = new KeyEventArgs(Keys.F9);
            //this.Sessions_KeyUp(null, dd);
            //this.StatusBarMainPanel.Text = "To go back to normal view press ESC";
            //MaxNumOfPatiantsBeforeSplitingTimePanel = 8;
			//this.TopMost=true;
		//	videoPanel  = new Panel();
			//bitmap.MakeTransparent();	
			//bitmapPanel.Size=this.Size;
		//	bitmapPanel.Location=new Point(0,0);
			//bitmapPanel.BackColor=Color.Transparent;
			//generalPictureBox.Image=bitmap;
			//Image image11=bitmap;
			//bitmapPanel.BackgroundImage = image11;
			//bitmapPanel.BackColor = Color.Transparent;
			//bitmapPanel.Controls.Add(image11);
			//generalPictureBox.BackColor = Color.Black;
			//generalPictureBox.Image.;
		
			//bitmapPanel.MouseDown +=new System.Windows.Forms.MouseEventHandler(this.Painter_MouseDown );
			//bitmapPanel.MouseUp +=new System.Windows.Forms.MouseEventHandler(this.Painter_MouseUp );
			//bitmapPanel.MouseMove +=new System.Windows.Forms.MouseEventHandler(this.Painter_MouseMove );
			//this.Controls.Add(bitmapPanel);
			//this.setSize(size);	

			/*	float[][] ptsArray ={ 
									new float[] {1, 0, 0, 0, 0},
									new float[] {0, 1, 0, 0, 0},
									new float[] {0, 0, 1, 0, 0},
									new float[] {0, 0, 0, 0.5f, 0}, 
									new float[] {0, 0, 0, 0, 1}}; 
			ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
			ImageAttributes imgAttributes = new ImageAttributes();
			imgAttributes.SetColorMatrix(clrMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap);
*/
			//m_sound = new AudioDX.Sound(this.Handle,"C:\\wildeep.wav");
			//m_sound.Play();
			//m_movie = new AudioDX.Movie( this.Handle, this.Bounds,"C:\\fmsample.avi.avi");
            
		}
		public Sessions(/*Size size*/)
		{
			
		}
		public void openPictureBoxForScrabling()
		{
			startDrawing= true;
			
		}
       //private void Sessions_KeyUp(object sender, KeyEventArgs e)
        //{

  

//        }
		public void stopScrabling()
		{
			startDrawing= false;
			Bitmap tmp=new Bitmap(bitmapArray[0],new Size(600,100));// ResizeBitmap(bitmapArray[0], 600,100);
			
			bitmapArray[0].Dispose();
			bitmapArray[0]=tmp;
			drawPanelBitmaps(1);
		}		

		private void drawPanelBitmaps(int panelCounter)
		{
			int width = bitmapArray[panelCounter-1].Width;
			int height = bitmapArray[panelCounter-1].Height;
			int i, j;
			for (i = 0; i< width; i++) 
			{
				for (j=0; j<height; j++)
				{
					Color pixelColor = bitmapArray[panelCounter-1].GetPixel(i, j);
				//	int r = pixelColor.R; // the Red component
				//	int b = pixelColor.B; // the Blue component
				//	Color newColor = Color.FromArgb(r, 0, b);
				//	bitmapArray[panelCounter-1].SetPixel(i, j, newColor);
					if (pixelColor==Color.FromArgb(10,10,10))
					{
						Graphics g  = timeLinePanel[panelCounter-1].CreateGraphics();
						g.FillEllipse(new SolidBrush( Color.Black ),i, j, 4, 4 );
						
					}
				}
			}
			
		}

		private void AddContextMenuForButtons()
		{
			
			//this.colors.DropDownMenu = contextMenu;
			MenuItem AddOpacMenuItem= new MenuItem("Add opac Panel");
			MenuItem RemoveOpacMenuItem= new MenuItem("Remove opac Panel");
			MenuItem ToggleOpacPanelMenuItem = new MenuItem("Toggle back/forground");
			MenuItem AddArrowMenuItem = new MenuItem("Add arrow");
			MenuItem RemoveArrowMenuItem = new MenuItem("Remove arrow");
            MenuItem HideLineFragmentMenuItem = new MenuItem("Hide line fragment");
            MenuItem ShowLineFragmentMenuItem = new MenuItem("Show line fragment");
			
			AddOpacMenuItem.Click += new System.EventHandler(this.AddOpacPanelMenu);
			RemoveOpacMenuItem.Click += new System.EventHandler(this.RemoveOpacPanelMenu);
			ToggleOpacPanelMenuItem.Click += new System.EventHandler(this.BringOpacPanelsToFront);
			//AddArrowMenuItem.Click += new System.EventHandler(this.removeArrowFromButton);
			RemoveArrowMenuItem.Click += new System.EventHandler(this.removeArrowFromButton);
            HideLineFragmentMenuItem.Click += new System.EventHandler(this.HideLineFragment);
            ShowLineFragmentMenuItem.Click += new System.EventHandler(this.ShowLineFragment);
			
            ButtonsContextMenu.MenuItems.Add(AddOpacMenuItem);
			ButtonsContextMenu.MenuItems.Add(RemoveOpacMenuItem);
			ButtonsContextMenu.MenuItems.Add(ToggleOpacPanelMenuItem);
			ButtonsContextMenu.MenuItems.Add(AddArrowMenuItem);
			ButtonsContextMenu.MenuItems.Add(RemoveArrowMenuItem);
            ButtonsContextMenu.MenuItems.Add(HideLineFragmentMenuItem);
            ButtonsContextMenu.MenuItems.Add(ShowLineFragmentMenuItem);

		}
		private void AddOpacPanelMenu(object e, System.EventArgs arg)
		{
			MenuItem aa = (MenuItem)e;
			System.Windows.Forms.ContextMenu ss= aa.GetContextMenu();
			
			this.ButtonClick(ss.SourceControl,arg);
		}
		private void RemoveOpacPanelMenu(object e, System.EventArgs arg)
		{
			MenuItem aa = (MenuItem)e;
			System.Windows.Forms.ContextMenu ss= aa.GetContextMenu();
			RemoveOpacPanel((AButton)ss.SourceControl);		
		}
		private void RemoveOpacPanel(AButton button)
		{
			this.document[docNumber].timeLine[button.y].MinutesArray[button.x].isOpacPanelStartHere=false;
			refreshOpacPanels();
		}

		public void ClearSessionControls()
		{
			refreshInstrumentPictureBox();
			AddTextToTextPanel();
		//	refreshTopicLablesOnButtons();
            refreshTopicLables();
            refreshInstrumentIndicationInTimeLine();
			refreshOpacPanels();
			refreshSingScream();
			refreshArrows();
		//	refreshTopicLablesOnButtons();
			refreshDiscPanels();
			refreshRichTextBoxes();
            refreshSilencePanels();
            refreshFrameePanels();
            refreshMusicNotes();
			this.OnPaint(null);
			//clear VIDEO panel
			

			//

		}
		public void refreshOpacPanels()
		{
			//first  the opca panels from the time lines
			foreach (Control cont in OpacPanelsArrayList)
			{
				for (int x=0;x<this.document[docNumber].numOfPanelsInSession;x++)
				{
					this.timeLinePanel[x].Controls.Remove(cont);
				}
			}
			//clear the array list
			OpacPanelsArrayList.Clear();
			//go over the time lines in the document and see if there is an opac panel
			//remember, the time lines have no connection to the panels. Each time line 
			// has the buttons for all the patiant's buttons (from all panels)
			//
			for (int patiantsConter = 0; patiantsConter < document[docNumber].numOfPatiants; patiantsConter++)
			{
				for (int numOfButtons = 0; numOfButtons <  document[docNumber].sessionDuration*2; numOfButtons++)
				{
					if(this.document[docNumber].timeLine[patiantsConter].MinutesArray[numOfButtons].isOpacPanelStartHere)
					{
						AmitOpacUserControl OpacPanel=new AmitOpacUserControl();
						OpacPanel.AmitColor= this.document[docNumber].timeLine[patiantsConter].MinutesArray[numOfButtons].opacPanel.color;
						OpacPanel.Location=calculateOpacPanelLocation(patiantsConter,numOfButtons);
						OpacPanel.Size = calculateOpacPanelSize(patiantsConter,numOfButtons,
														this.document[docNumber].timeLine[patiantsConter].MinutesArray[numOfButtons].opacPanel.endPoint.Y-numOfButtons,this.document[docNumber].timeLine[patiantsConter].MinutesArray[numOfButtons].opacPanel.endPoint.X-patiantsConter);
						OpacPanel.AmitOpacity=100;
						int panelNumber =numOfButtons/document[docNumber].numOfButtonsInTimeLine;
						/*for (int x=numOfButtons;x<this.document[docNumber].numOfPanelsInSession*this.document[docNumber].numOfButtonsInTimeLine;x=x-this.document[docNumber].numOfButtonsInTimeLine)
						{
							if (x<=0)
								break;
							panelNumber++;
						}*/
						timeLinePanel[panelNumber].Controls.Add(OpacPanel);
						OpacPanelsArrayList.Add(OpacPanel);
						OpacPanel.Show();
						//timeLinePanel[panelNumber].Invalidate();
					}
				}
			}
		}
        public void refreshMusicNotes()
        {
            //first  the opca panels from the time lines
            foreach (Control cont in MusicNotesPanelsArrayList)
            {
                for (int x = 0; x < this.document[docNumber].numOfPanelsInSession; x++)
                {
                    this.timeLinePanel[x].Controls.Remove(cont);
                }
            }
            //clear the array list
            MusicNotesPanelsArrayList.Clear();

            for (int musicNotesCounter = 0; musicNotesCounter < this.document[docNumber].MusicNotesList.Count; musicNotesCounter++)
            {
                MusicNotes musicNotes = (MusicNotes)this.document[docNumber].MusicNotesList[musicNotesCounter];
                //SilencePanel silence = (SilencePanel)this.document[docNumber].SilencePanelList[silenceCounter];
                //Disc disc = (Disc)this.document[docNumber].DiscList[discCounter];
                int startPanelNumber = musicNotes.startPoint / this.document[docNumber].numOfButtonsInTimeLine;
                //    int endPanelNumber = silence.endPoint / this.document[docNumber].numOfButtonsInTimeLine;

              //  Panel musicNotePanel = new Panel();
                Size ButtonsSize = calculateButtonsSize(timeLinePanel[0]);
                APanel musicNotePanel = new APanel();
             //   musicNotePanel.BackColor = silence.color;
                musicNotePanel.BorderStyle = BorderStyle.FixedSingle;
                musicNotePanel.Location = calculateMusicNotesPanelLocation(0, musicNotes.startPoint); //calculateDiscPanelLocation(0, silence.startPoint);//calculateSingScreamLoaction(disc.startPoint,0,40);
                musicNotePanel.Size = calculateMusicNotesPanelSize(0, musicNotes.startPoint, musicNotes.endPoint - musicNotes.startPoint, this.document[docNumber].numOfPatiants);//calculateDiscPanelSize(silence.endPoint - silence.startPoint);
                
                Panel tempoPanel = new Panel();
                int tempoPanelWidth = 66;
                tempoPanel.Size = new Size(tempoPanelWidth, musicNotePanel.Size.Height);
                tempoPanel.Location = new Point(musicNotePanel.Size.Width - tempoPanelWidth, 0);
                
                PictureBox tempoPicture = new PictureBox();
                tempoPicture.Image = new Bitmap(((MainForm)this.ParentForm).MainDirectory + "note.quater.up.nodash.nodot.png");
                tempoPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                tempoPicture.Size = new Size(tempoPanelWidth/2, tempoPanel.Size.Height);
                tempoPicture.Location = new Point(0, 0);
                tempoPanel.Controls.Add(tempoPicture);
                ALable tempoLable = new ALable();
                tempoLable.Size = new Size(tempoPanelWidth/2, tempoPanel.Size.Height);
                tempoLable.Location = new Point(tempoPanelWidth/2, 0);
                tempoLable.Text = "= " + musicNotes.tempo;
                tempoLable.TextAlign = ContentAlignment.MiddleCenter;
                tempoPanel.Controls.Add(tempoLable);
                musicNotePanel.Controls.Add(tempoPanel);
                if (musicNotes.NotesPictureFileName != "")
                {
                    PictureBox notesPictureBox = new PictureBox();
                    notesPictureBox.Location = new Point(0, 0);
                    notesPictureBox.Size = new Size(musicNotePanel.Size.Width - tempoPanelWidth, musicNotePanel.Size.Height);
                    notesPictureBox.Image = new Bitmap(musicNotes.NotesPictureFileName);
                    notesPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    musicNotePanel.Controls.Add(notesPictureBox);
                }
                else
                {
                    Finale mm = new Finale();
                    mm.parentForm = this;
                    //   mm.initStafLineArray();
                    //mm.drawStaf
                    mm.Mafteach = musicNotes.Mafteach;
                    mm.drawStaf(musicNotePanel);
                    mm.initStafLineArray(musicNotePanel);
                    mm.noteWidth = musicNotePanel.Size.Height * 30 / 54;
                    mm.setNotesLocation(musicNotes.NotesList);
                    mm.refreshNotes(musicNotePanel, musicNotes.NotesList);
                   
                }
                tempoLable.LableNumber = musicNotes.startPoint;
                tempoLable.Click += new System.EventHandler(MusicNotePanelClick);   
                //musicNotePanel.panelNumber = musicNotes.startPoint;

                this.timeLinePanel[musicNotes.startPoint / this.document[docNumber].numOfButtonsInTimeLine].Controls.Add(musicNotePanel);
                //silencePanel.BringToFront();
                this.MusicNotesPanelsArrayList.Add(musicNotePanel);
            }
        }
        public void refreshSilencePanels()
        {
            //first  the opca panels from the time lines
            foreach (Control cont in SilencePanelsArrayList)
            {
                for (int x = 0; x < this.document[docNumber].numOfPanelsInSession; x++)
                {
                    this.timeLinePanel[x].Controls.Remove(cont);
                }
            }
            //clear the array list
            SilencePanelsArrayList.Clear();

            for (int silenceCounter = 0; silenceCounter < this.document[docNumber].SilencePanelList.Count; silenceCounter++)
            {
                SilencePanel silence = (SilencePanel)this.document[docNumber].SilencePanelList[silenceCounter];
                //Disc disc = (Disc)this.document[docNumber].DiscList[discCounter];
                int startPanelNumber = silence.startPoint / this.document[docNumber].numOfButtonsInTimeLine;
            //    int endPanelNumber = silence.endPoint / this.document[docNumber].numOfButtonsInTimeLine;

                Size ButtonsSize = calculateButtonsSize(timeLinePanel[0]);
                APanel silencePanel = new APanel();
                silencePanel.BackColor = silence.color;
                silencePanel.BorderStyle = BorderStyle.FixedSingle;
                silencePanel.Location = calculateSilencePanelLocation(0, silence.startPoint); //calculateDiscPanelLocation(0, silence.startPoint);//calculateSingScreamLoaction(disc.startPoint,0,40);
                silencePanel.Size = calculateSilencePanelSize(1, silence.startPoint, silence.endPoint - silence.startPoint, this.document[docNumber].numOfPatiants);//calculateDiscPanelSize(silence.endPoint - silence.startPoint);
                ALable timeLable = new ALable();
                timeLable.Size = silencePanel.Size;// new Size(38, 20);
                //timeLable.Location = new Point(silencePanel.Size.Width / 2 - 19, silencePanel.Size.Height / 2 - 10);
                timeLable.BackColor = silence.color;
                timeLable.BorderStyle = BorderStyle.None;
                timeLable.Text = silence.TimeOfSilence;
                timeLable.TextAlign = ContentAlignment.MiddleCenter;
                silencePanel.Controls.Add(timeLable);
                //Graphics g = silencePanel.CreateGraphics();
                //g.DrawString(silence.TimeOfSilence,new Font("Arial", 80, FontStyle.Bold), Brushes.Black, 150, 125);
                timeLable.Click += new System.EventHandler(SilencePanelClick);
                timeLable.LableNumber = silence.startPoint;
                silencePanel.panelNumber = silence.startPoint;
                this.timeLinePanel[silence.startPoint / this.document[docNumber].numOfButtonsInTimeLine].Controls.Add(silencePanel);
                silencePanel.BringToFront();
                this.SilencePanelsArrayList.Add(silencePanel);
              
            }
            
            
            
            
        }
         public void refreshFrameePanels()
        {
            //first  the opca panels from the time lines
            foreach (Control cont in FramePanelsArrayList)
            {
                for (int x = 0; x < this.document[docNumber].numOfPanelsInSession; x++)
                {
                    this.timeLinePanel[x].Controls.Remove(cont);
                }
            }
            //clear the array list
            FramePanelsArrayList.Clear();

            for (int silenceCounter = 0; silenceCounter < this.document[docNumber].FramePanelList.Count; silenceCounter++)
            {
               FramePanel silence = (FramePanel)this.document[docNumber].FramePanelList[silenceCounter];
                
                int startPanelNumber = silence.startPoint.Y / this.document[docNumber].numOfButtonsInTimeLine;
                int endPanelNumber = silence.endPoint.Y / this.document[docNumber].numOfButtonsInTimeLine;

                Size ButtonsSize = calculateButtonsSize(timeLinePanel[0]);
            
                AmitFrameControl.AmitFrameUserControl framePanel = new AmitFrameControl.AmitFrameUserControl();
                framePanel.Location = calculateOpacPanelLocation(silence.startPoint.X, silence.startPoint.Y);
                framePanel.Size = calculateOpacPanelSize(silence.startPoint.X, silence.startPoint.Y, silence.endPoint.Y-silence.startPoint.Y, silence.endPoint.X-silence.startPoint.X);
                framePanel.type = silence.type;
                framePanel.width = silence.width;
                framePanel.AmitColor = silence.color;
                framePanel.buttonLocation = silence.startPoint;
                framePanel.Click += new System.EventHandler(FramePanelClick);
                this.timeLinePanel[silence.startPoint.Y / this.document[docNumber].numOfButtonsInTimeLine].Controls.Add(framePanel );
                framePanel.SendToBack();
                this.FramePanelsArrayList.Add(framePanel);
              
            }      
         }
        public void refreshTopicLables()
        {
            //first  the opca panels from the time lines
            foreach (Control cont in TopicLablesArrayList)
            {
                for (int xx = 0; xx < this.document[docNumber].numOfPanelsInSession; xx++)
                {
                    this.timeLinePanel[xx].Controls.Remove(cont);
                }
            }
            //clear the array list
            TopicLablesArrayList.Clear();
            for (int x = 0; x < document[docNumber].numOfPatiants; x++)
            {
                for (int y = 0; y < (document[docNumber].sessionDuration * 2); y++)
                {
                     //aaa
                    if (document[docNumber].timeLine[x].MinutesArray[y].topicAndSubTopic == "" ||
                        document[docNumber].timeLine[x].MinutesArray[y].topicAndSubTopic == null)
                        continue;
                    else
                    {

                        int panelCounter = y / document[docNumber].numOfButtonsInTimeLine;
                        int buttonNumberInPanel = y - panelCounter * document[docNumber].numOfButtonsInTimeLine;
                        ALable topicLable = new ALable();
                        topicLable.Size = calculateLablesSize(timeLinePanel[panelCounter]);
                        topicLable.Location = calculateLableLocation(panelCounter, x, buttonNumberInPanel);
                        topicLable.BackColor = Color.LightGray;//Color.FromArgb(220,220,220);
                        topicLable.Font = new System.Drawing.Font("Times New Roman", 9);
                        //LableArray[x, yy].ForeColor = Color.White;
                       
                        topicLable.TextAlign = ContentAlignment.MiddleCenter;
                        topicLable.Click += new System.EventHandler(LablePictureClick);
                        topicLable.x = x;
                        topicLable.y = y;
                        topicLable.Text = document[docNumber].timeLine[x].MinutesArray[y].topicAndSubTopic;
                        TextTalkedinSession textBox;
                        for (int xxx = 0; xxx < this.document[docNumber].listText.Count; xxx++)
                        {	//go over the text list			
                            textBox = (TextTalkedinSession)this.document[docNumber].listText[xxx];
                            string tmpTextIndex = textBox.topic + textBox.subTopic;
                            //tmpDialogTextIndex = this.groupTextBox.Text.ToString() + this.serialTextBox.Text.ToString();
                            //compare the topic and subtopic which are the index
                            int compare = tmpTextIndex.CompareTo(topicLable.Text);
                            if (compare != 0)//did not rich the item yet
                                continue;
                            else if (compare == 0)
                            {
                                sessionToolTip.SetToolTip(topicLable, textBox.shortText);     
                            }
                            
                        }
                        
                        timeLinePanel[panelCounter].Controls.Add(topicLable);
                        TopicLablesArrayList.Add(topicLable);
                        topicLable.Show();
                        topicLable.BringToFront();
                        // LableArray[x, y].Hide();
                    }
                   
                }
            }

            for (int silenceCounter = 0; silenceCounter < this.document[docNumber].FramePanelList.Count; silenceCounter++)
            {
                FramePanel silence = (FramePanel)this.document[docNumber].FramePanelList[silenceCounter];

                int startPanelNumber = silence.startPoint.Y / this.document[docNumber].numOfButtonsInTimeLine;
                int endPanelNumber = silence.endPoint.Y / this.document[docNumber].numOfButtonsInTimeLine;

                Size ButtonsSize = calculateButtonsSize(timeLinePanel[0]);

                AmitFrameControl.AmitFrameUserControl framePanel = new AmitFrameControl.AmitFrameUserControl();
                framePanel.Location = calculateOpacPanelLocation(silence.startPoint.X, silence.startPoint.Y);
                framePanel.Size = calculateOpacPanelSize(silence.startPoint.X, silence.startPoint.Y, silence.endPoint.Y - silence.startPoint.Y, silence.endPoint.X - silence.startPoint.X);
                framePanel.type = silence.type;
                framePanel.width = silence.width;
                framePanel.AmitColor = silence.color;
                framePanel.buttonLocation = silence.startPoint;
                framePanel.Click += new System.EventHandler(FramePanelClick);
                this.timeLinePanel[silence.startPoint.Y / this.document[docNumber].numOfButtonsInTimeLine].Controls.Add(framePanel);
                framePanel.SendToBack();
                this.FramePanelsArrayList.Add(framePanel);

            }
        }
		private void BringOpacPanelsToFront(object e, System.EventArgs arg)
		{
			BringOpacPanelsToFront();
		}
		public void drawLines()
		{				
			int numOfButtonsInRow=getNumOfButtonsInRow();
			
			mainPanel = new Panel();
			mainPanel.Dock = DockStyle.Top;
			//this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Sessions_mainPanel_Paint);
			//mainPanel.Size = new Size(this.Size.Width,this.Size.Height*document[docNumber].proportionOfPanelArearAndTextArea/100);
			//mainPanel.BackColor =Color.BlanchedAlmond;
			
			mainSplitter = new Splitter();
			mainSplitter.Dock = DockStyle.Top;
			mainSplitter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitterMoved);
			//mainSplitter.SplitPosition = 200;//this.Size.Height*document[docNumber].proportionOfPanelArearAndTextArea/100;
			//mainSplitter.MinExtra = 50;
			//mainSplitter.MinSize = 20;
		
			this.Controls.Add(mainSplitter);
			this.Controls.Add(mainPanel);
			//add the time lines to the maiPanel
			for ( int panelCounter  = 0;panelCounter <document[docNumber].numOfPanelsInSession;panelCounter++)
			{
				timeLinePanel[panelCounter]=setTimeLinePanel(panelCounter+1);
				//this.Controls.Add(timeLinePanel[panelCounter]);
				mainPanel.Controls.Add(timeLinePanel[panelCounter]);
                AmitBracesUserControl braces = new AmitBracesUserControl(1,1);

                CurlyBracesArray[panelCounter] = new AmitBracesUserControl(1, 1);// PictureBox();
			    CurlyBracesArray[panelCounter].Location = calculateCurlyBracesLocation(timeLinePanel[panelCounter]);//new Point(0,0);
                CurlyBracesArray[panelCounter].Size = calculateCurlyBracesSize(timeLinePanel[panelCounter]);
                CurlyBracesArray[panelCounter].ClientSize = calculateCurlyBracesSize(timeLinePanel[panelCounter]);
                CurlyBracesArray[panelCounter].AmitColor = Color.Gray;
                timeLinePanel[panelCounter].Controls.Add(CurlyBracesArray[panelCounter]);
				
				int x = 0, y = 0;
				for (x = 0; x < document[docNumber].numOfPatiants; x++)
				{
					for (y = 0; y < numOfButtonsInRow; y++)
					{
						int yy=y+numOfButtonsInRow*panelCounter;
						ButtonArray[x, yy] = new AButton();
						ButtonArray[x, yy].AllowDrop= true;
                        ButtonArray[x, yy].MouseDown += new System.Windows.Forms.MouseEventHandler(buttonMouseDown);
                        //ButtonArray[x, yy].DoubleClick += new System.EventHandler(ButtonDoubleClick);
                        ButtonArray[x, yy].Click += new System.EventHandler(ButtonClick);
                        
						ButtonArray[x, yy].BackColor = this.document[docNumber].timeLine[x].ButtonColor;//Color.FromName("ControlDark");
						ButtonArray[x, yy].x = y+numOfButtonsInRow*panelCounter;
						ButtonArray[x, yy].y = x;					
						ButtonArray[x, yy].Location = calculateButtonLocation(panelCounter,x,y); 
						ButtonArray[x, yy].Size = calculateButtonsSize(timeLinePanel[panelCounter]);
						ButtonArray[x, yy].SendToBack();
						ButtonArray[x,yy].FlatStyle = FlatStyle.Flat;
						ButtonArray[x,yy].AllowDrop = true;
						ButtonArray[x,yy].ContextMenu = ButtonsContextMenu;
						//ButtonArray[x,yy].I
						//ButtonArray[x,yy].MouseDown += new System.Windows.Forms.MouseEventHandler(button_MouseDown);
						ButtonArray[x,yy].DragDrop+= new System.Windows.Forms.DragEventHandler(this.button_DragDrop);
						ButtonArray[x,yy].DragEnter += new System.Windows.Forms.DragEventHandler(this.button_DragEnter);
						//ButtonArray[x,yy].MouseHover += new System.Windows.Forms.MouseEventHandler(this.button_mouseHover);
						ButtonArray[x,yy].MouseHover += new System.EventHandler(this.button_mouseHover);
						ButtonArray[x,yy].MouseLeave += new System.EventHandler(this. button_mouseLeave);
					
                        
                        //LableArray[x,yy] = new ALable();
                        //LableArray[x, yy].Size = calculateLablesSize(timeLinePanel[panelCounter]);
                        //LableArray[x,yy].Location = calculateLableLocation(panelCounter,x,y);
                        //LableArray[x, yy].BackColor=Color.LightGray;//Color.FromArgb(220,220,220);
                        //LableArray[x, yy].Font = new System.Drawing.Font("Times New Roman", 9);
                        ////LableArray[x, yy].ForeColor = Color.White;
                        //LableArray[x, yy].BringToFront();
                        //LableArray[x, yy].TextAlign=ContentAlignment.MiddleCenter;
                        //LableArray[x, yy].Click += new System.EventHandler(LablePictureClick);
                        //LableArray[x, yy].x = x;
                        //LableArray[x, yy].y = yy;
                        //LableArray[x, yy].Hide();
                        //LableArray[x, yy].BorderStyle = BorderStyle.FixedSingle;

					
						InstrumentPictureArray[x, yy] = new APictureBox();
						InstrumentPictureArray[x, yy].Size = calculateInstrumentPictureSize(timeLinePanel[panelCounter]);
						InstrumentPictureArray[x,yy].Location = calculateInstrumentPictureLocation(panelCounter,x,y); //same as lable
						InstrumentPictureArray[x,yy].Hide();
						InstrumentPictureArray[x,yy].BorderStyle = BorderStyle.FixedSingle;
						InstrumentPictureArray[x,yy].SizeMode = PictureBoxSizeMode.StretchImage ;
						InstrumentPictureArray[x, yy].Click += new System.EventHandler(InstrumentPictureClick);
						InstrumentPictureArray[x, yy].x = y+numOfButtonsInRow*panelCounter;
						InstrumentPictureArray[x, yy].y = x;	
					
                        EndInstrumentSectionButtonArray[x,yy] = new AButton();
						EndInstrumentSectionButtonArray[x,yy].Location = calculateEndInstrumentSectionButtonLocation(panelCounter,x,y);
						EndInstrumentSectionButtonArray[x,yy].Size = new Size(document[docNumber].widthOfEndInstrumentSectionButton,document[docNumber].heightOfEndInstrumentSectionButton);
						EndInstrumentSectionButtonArray[x,yy].Hide();
						EndInstrumentSectionButtonArray[x,yy].Enabled=false;
						EndInstrumentSectionButtonArray[x,yy].FlatStyle = FlatStyle.Flat;
						EndInstrumentSectionButtonArray[x,yy].BackColor = this.document[docNumber].EndInstrumentButtonColor;
						EndInstrumentSectionButtonArray[x,yy].ForeColor= this.document[docNumber].EndInstrumentButtonColor;
						string sec;
						if (yy % 2==0)
							sec="00";
						else
							sec="30";
						string time = (Convert.ToString( (int)yy/2));
						sessionToolTip.SetToolTip (ButtonArray[x,yy],this.document[docNumber].timeLine[x].PatiantName +", Time: " + time + ":" +sec );
			
						timeLinePanel[panelCounter].Controls.Add(InstrumentPictureArray[x, yy]);
						timeLinePanel[panelCounter].Controls.Add(ButtonArray[x, yy]);
						//timeLinePanel[panelCounter].Controls.Add(LableArray[x, yy]);
						timeLinePanel[panelCounter].Controls.Add(EndInstrumentSectionButtonArray[x,yy]);
					}
					
				}
			}
			drawNamesButtons();
		}
		private void Painter_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e )
		{
		if (startDrawing)
			shouldPaint = true;
		//	bitmapPanel.BringToFront();
		}
		
		private void VideoPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e )
		{
			//MessageBox.Show(" " + e.X+ " " + e.Y);
			APanel tt =(APanel)sender;
			videoPanelClicked=tt.panelNumber;
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[0]); 
			int button=e.X/ButtonsSize.Width+videoPanelClicked*this.document[docNumber].numOfButtonsInTimeLine;
			
			for(int videoCounter=0;videoCounter<this.document[docNumber].videoFileList.Count;videoCounter++)
			{
				VideoFile videoFile=(VideoFile)this.document[docNumber].videoFileList[videoCounter];
				if (videoFile.startPoint<=button && videoFile.endPoint>=button )
				{
					MainForm tmpParent= (MainForm)this.MdiParent;
					if (tmpParent.videoForm==null)
					{
						tmpParent.videoForm=new VideoDirectShow();
						tmpParent.videoForm.MdiParent = tmpParent;
					}
					
					this.WindowState = FormWindowState.Normal;
					tmpParent.videoForm.WindowState = FormWindowState.Normal;
					CurrentVidoeStartPoint=videoFile.startPoint;
					tmpParent.videoForm.Show();
					tmpParent.videoForm.loadVideoFile(videoFile.videoFileName,button-videoFile.startPoint,videoFile.startPoint);
					tmpParent.WindowsTile_Click(null , null);
					//MessageBox.Show("found");
				}
			}
		}
		private void Painter_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e )
		{
			shouldPaint = false;
		}

		protected void Painter_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e )
		{
			APanel panel = (APanel) sender;

			if ( shouldPaint )
			{
			/*	float[][] ptsArray ={ 
										new float[] {1, 0, 0, 0, 0},
										new float[] {0, 1, 0, 0, 0},
										new float[] {0, 0, 1, 0, 0},
										new float[] {0, 0, 0, 0.5f, 0}, 
										new float[] {0, 0, 0, 0, 1}}; 
				ColorMatrix clrMatrix = new ColorMatrix(ptsArray);
				ImageAttributes imgAttributes = new ImageAttributes();*/
				Graphics graphics = timeLinePanel[panel.panelNumber-1].CreateGraphics();
				graphics.FillEllipse(new SolidBrush( Color.Black ),e.X, e.Y, 4, 4 );
				
				if (e.X <bitmapArray[(panel.panelNumber)-1].Size.Width && e.X >0 && 
					e.Y <bitmapArray[(panel.panelNumber)-1].Size.Height && e.Y >0 )
				bitmapArray[(panel.panelNumber)-1].SetPixel(e.X, e.Y,Color.FromArgb(10,10,10));
				
				
				//bitmap.SetPixel(e.X+1, e.Y,Color.Red);
				//bitmap.SetPixel(e.X-1, e.Y,Color.Red);
				//	graphics.DrawImage(bitmap,1,1);
				/*graphics.DrawImage(bitmap, 
					new Rectangle(1, 1, 100, 100), 
					10, 10, 100, 100,
					GraphicsUnit.Pixel, imgAttributes);*/

			}
		}
		public void  sessionInit()
		{
			InitializeComponent();
			ButtonArray = new AButton[document[docNumber].numOfPatiants,document[docNumber].sessionDuration*2];
			EndInstrumentSectionButtonArray= new AButton[document[docNumber].numOfPatiants,document[docNumber].sessionDuration*2];
//			LableArray  = new ALable[document[docNumber].numOfPatiants,document[docNumber].sessionDuration*2];
			TextBoxArray = new TextBox[document[docNumber].numOfTextBoxInColumn,document[docNumber].numOfTextBoxColumns];
			InstrumentPictureArray = new APictureBox[document[docNumber].numOfPatiants,document[docNumber].sessionDuration*2];
			//CurlyBracesArray = new PictureBox[document[docNumber].numOfPanelsInSession];
            CurlyBracesArray = new AmitBracesUserControl[document[docNumber].numOfPanelsInSession];
			timeLinePanel =new APanel[document[docNumber].numOfPanelsInSession];
			videoPanel = new APanel[document[docNumber].numOfPanelsInSession];
			NameButtonArray = new ALable[document[docNumber].numOfPanelsInSession,document[docNumber].numOfPatiants];
			sessionToolTip = new ToolTip();
			bitmapArray = new Bitmap[document[docNumber].numOfPanelsInSession];
			OpacPanelsArrayList = new ArrayList();
			SingScreamArrayList = new ArrayList();
			DiscArrayList = new ArrayList();
			RichTextList  = new ArrayList();
			opac = new AmitOpacUserControl();
            SilencePanelsArrayList = new ArrayList();
            FramePanelsArrayList = new ArrayList();
            TopicLablesArrayList = new ArrayList();
            MusicNotesPanelsArrayList = new ArrayList();
			AddContextMenuForButtons();
            
            if (this.document[docNumber].FramePanelList == null)
                this.document[docNumber].FramePanelList = new ArrayList();
		}
	
		public void AddTextPanel()
		{
			TextPanel = new Panel();
			//TextPanel.Location = new Point(this.Location.X,(int)(this.Location.Y+this.Size.Height*(document[docNumber].proportionOfPanelArearAndTextArea)));
			//TextPanel.Size = new Size(this.Size.Width,this.Size.Height/3);
			TextPanel.BackColor=Color.White;
			TextPanel.Dock = DockStyle.Fill;
			// Set the Borderstyle for the Panel to three-dimensional.
			TextPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(TextPanel);
		}
		private void NameButtonClick(object sender, System.EventArgs e)
		{
			ALable b = (ALable)sender;
			int btn_x = b.x;
			int btn_y = b.y;
			EnterNAmeDialogBox nameDialogBox= new EnterNAmeDialogBox();
			
			//Change the textBox1 to private !!!
			nameDialogBox.nameTextBox.Text=NameButtonArray[btn_x,btn_y].Text;
			nameDialogBox.isPatiantAbsent=document[docNumber].timeLine[btn_y].IsPatiantAbsent;
			nameDialogBox.additionalInfo=document[docNumber].timeLine[btn_y].additionalInfoAboutPatiant;
			if (nameDialogBox.ShowDialog() == DialogResult.OK)
			{
				//update name and additional info
				document[docNumber].timeLine[btn_y].PatiantName=nameDialogBox.PatiantNAme;
				document[docNumber].timeLine[btn_y].additionalInfoAboutPatiant=nameDialogBox.additionalInfo;
				for (int panelCounter = 0 ;panelCounter<document[docNumber].numOfPanelsInSession;panelCounter++)
				{
					NameButtonArray[panelCounter,btn_y].Text=nameDialogBox.PatiantNAme;
					NameButtonArray[panelCounter,btn_y].Invalidate();	
					sessionToolTip.SetToolTip(NameButtonArray[panelCounter,btn_y],this.document[docNumber].timeLine[btn_y].additionalInfoAboutPatiant);
				}
				document[docNumber].timeLine[btn_y].IsPatiantAbsent=nameDialogBox.isPatiantAbsent;
			}
			refreshAbsentPatiant();
		}
		public void refreshAbsentPatiant()
		{
			this.SuspendLayout();
			for (int patiantCounter=0;patiantCounter<document[docNumber].numOfPatiants;patiantCounter++)
			{
                this.document[docNumber].ColorForAbsentPatiant = this.document[docNumber].sessionColor.PanelColor;
				for (int buttonCounter=0;buttonCounter<document[docNumber].sessionDuration*2;buttonCounter++)
					{	
					string sec;
					if (buttonCounter % 2==0)
						sec="00";
					else
						sec="30";
					string time = (Convert.ToString( (int)buttonCounter/2));
					
			
					//int panelNumber = buttonCounter/document[docNumber].numOfButtonsInTimeLine ;
					if (!document[docNumber].timeLine[patiantCounter].IsPatiantAbsent)
					{
						this.ButtonArray[patiantCounter ,buttonCounter].Enabled=true;
						this.ButtonArray[patiantCounter,buttonCounter].BackColor = document[docNumber].timeLine[patiantCounter].ButtonColor;
						this.ButtonArray[patiantCounter,buttonCounter].ForeColor = document[docNumber].timeLine[patiantCounter].ButtonColor;
						sessionToolTip.SetToolTip (ButtonArray[patiantCounter,buttonCounter],this.document[docNumber].timeLine[patiantCounter].PatiantName +", Time: " + time + ":" +sec );
					}
					else
					{
						this.ButtonArray[patiantCounter ,buttonCounter].Enabled=false;
						this.ButtonArray[patiantCounter,buttonCounter].BackColor = document[docNumber].ColorForAbsentPatiant;
						this.ButtonArray[patiantCounter,buttonCounter].ForeColor = document[docNumber].ColorForAbsentPatiant;
						sessionToolTip.SetToolTip (ButtonArray[patiantCounter,buttonCounter],this.document[docNumber].timeLine[patiantCounter].PatiantName +", Time: " + time + ":" +sec );
					}

					}
			}
			this.ResumeLayout();
		}
		private void buttonMouseDown(object sender, 
			System.Windows.Forms.MouseEventArgs e)
		{
			AButton b= (AButton) sender;
            if (e.Clicks == 2)
            {
                isDoubleClick = true;
              // MessageBox.Show("is double click");
               
                    if (AddInstrumentButtonPushed)
                    {
                        if (this.document[docNumber].timeLine[b.y].MinutesArray[b.x].isInstrumentInButton)
                        {
                           // MessageBox.Show("sfdssdafsa");
                           
                            switch (this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity)
                            {
                                case 0:
                                    this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 10;
                                    break;
                                case 2:
                                    this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 12;
                                    break;
                                case 4:
                                    this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 14;
                                    break;
                                case 6:
                                    this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 0;
                                    break;
                                case 8:
                                    this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 2;
                                    break;
                                case 10:
                                    this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 4;
                                    break;
                                case 12:
                                    this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 6;
                                    break;
                                case 14:
                                    this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 8;
                                    break;

                            }
                        }

                        refreshInstrumentIndicationInTimeLine();
                    }
                    return;
                
            }
            if (e.Clicks == 1)
                isDoubleClick = false;

			
		}
		private void removeArrowFromButton(object sender, System.EventArgs e)
		{
			
			MenuItem aa = (MenuItem)sender;
			System.Windows.Forms.ContextMenu ss= aa.GetContextMenu();
			AButton b=(AButton)ss.SourceControl;
			this.document[docNumber].timeLine[b.y].MinutesArray[b.x].arrowList.Clear();
			refreshArrows();
		}
        private void HideLineFragment(object sender, System.EventArgs e)
		{
			MenuItem aa = (MenuItem)sender;
			System.Windows.Forms.ContextMenu ss= aa.GetContextMenu();
			AButton b=(AButton)ss.SourceControl;
            this.document[docNumber].timeLine[b.y].MinutesArray[b.x].buttonBackColor = this.document[docNumber].sessionColor.PanelColor;
			refreshBottons();
		}
        private void ShowLineFragment(object sender, System.EventArgs e)
        {
            MenuItem aa = (MenuItem)sender;
            System.Windows.Forms.ContextMenu ss = aa.GetContextMenu();
            AButton b = (AButton)ss.SourceControl;
            this.document[docNumber].timeLine[b.y].MinutesArray[b.x].buttonBackColor = this.document[docNumber].timeLine[b.y].ButtonColor;
            refreshBottons();
        }

        private void LablePictureClick(object sender, System.EventArgs e)
        {
            ALable pic = (ALable)sender;

            if (RemoveTextButtonPushed)
            {
                this.document[docNumber].timeLine[pic.x].MinutesArray[pic.y].topicAndSubTopic = "";
                this.refreshTopicLables();
                // this.LableArray[pic.x, pic.y].Text = "";
               // this.LableArray[pic.x, pic.y].BackColor = Color.White;
               // this.LableArray[pic.x, pic.y].Hide();
            }
            else
            {
                if (pic.atBack)
                {
                    pic.BringToFront();
                    pic.atBack = false;
                }
                else
                {
                    pic.SendToBack();
                    pic.atBack = true;
                }
            }
            
        }
        private void InstrumentPictureClick(object sender, System.EventArgs e)
		{
			APictureBox pic=(APictureBox) sender;
			if (!this.AddArrow && !this.isWaitingForArrowEndClick)
			{
				if (pic.atBack)
				{
					pic.BringToFront();
					pic.atBack=false;
				}
				else
				{
					pic.SendToBack();
					pic.atBack=true;
				}
				return;
			}
			if (this.AddArrow)
			{
				// if it is the second click for the end section 
				if (isWaitingForArrowEndClick)
				{
					//check if the point is legal;
				/*	if (startArrowPosition.Y > pic.x)
					{
						MessageBox.Show("This is an ilegal end point");
						return;
					}
				*/	
					//this.document[docNumber].timeLine[startArrowPosition.X].MinutesArray[startArrowPosition.Y].isOpacPanelStartHere=true;
					Arrow arrow =new Arrow(Color.Black,new Point(startArrowPosition.X,startArrowPosition.Y),new Point(pic.y,pic.x),2);
					//choose color
					ColorDialog colorDialog = new ColorDialog();
					colorDialog.AllowFullOpen = true;
					colorDialog.AnyColor = true;
					colorDialog.SolidColorOnly = false;
					colorDialog.ShowHelp = true;
			
					if (colorDialog.ShowDialog() == DialogResult.OK)
					{
						arrow.color= colorDialog.Color;
					}
					if (startArroFromButton)
						arrow.arrowType=2;
					else
						arrow.arrowType=3;
					this.document[docNumber].timeLine[startArrowPosition.X].MinutesArray[startArrowPosition.Y].arrowList.Add(arrow);
					//restart the flag
					isWaitingForArrowEndClick=false;
					refreshArrows();
					this.Cursor = Cursors.Arrow;
				}
				else
				{
					Cursor.Current = new Cursor( (((MainForm) (this.MdiParent)).MainDirectory)+"\\secondklick1.ico"  );
					this.Cursor = Cursor.Current;
					//keep the point for the next click to calculate the time interval between the start and the end
					startArrowPosition= new Point(pic.y,pic.x);
					startArroFromButton=false;
					//update the flag to indicate that the next click should be the end section point button
					isWaitingForArrowEndClick=true;
				}
			}

		}
		public void refreshArrows()
		{//xxx
			for (int patiantsConter = 0; patiantsConter < document[docNumber].numOfPatiants; patiantsConter++)
			{
				for (int numOfButtons = 0; numOfButtons <  document[docNumber].sessionDuration*2; numOfButtons++)
				{
					for (int count=0;count<this.document[docNumber].timeLine[patiantsConter].MinutesArray[numOfButtons].arrowList.Count;count++)
					{
						Arrow arrow = (Arrow )this.document[docNumber].timeLine[patiantsConter].MinutesArray[numOfButtons].arrowList[count];
						Point[] ArrowAtartEndPoints;
						ArrowAtartEndPoints=new Point[2];
						
						ArrowAtartEndPoints=calculateArrowStartEndPoints(arrow);
						//arrowStartPoint=calculateArrowStartPoint(patiantsConter,numOfButton);
						//arrowEndPoint=calculateArrowEndPoint(patiantsConter,numOfButton);
							
						Color arrowColor = arrow.color;
						
						int panelNumber =numOfButtons/document[docNumber].numOfButtonsInTimeLine;
						Pen p = new Pen(arrow.color,4);
						p.StartCap = LineCap.Round;
						p.EndCap = LineCap.ArrowAnchor;
						Graphics g = timeLinePanel[panelNumber].CreateGraphics();
						g.SmoothingMode=SmoothingMode.AntiAlias;
						//g.DrawLine(new System.Drawing.Pen(new System.Drawing.SolidBrush(arrow.color),30),new Point(10,10),new Point(100,20));							
						g.DrawLine(p,ArrowAtartEndPoints[0],ArrowAtartEndPoints[1]);
						g.Dispose();
					}
				}
			}
		}
		private Point[] calculateArrowStartEndPoints(Arrow arrow)
		{
			Point startPoint;
			Point endPoint;
			bool arrowDown= false;
			bool arrowBack=false;

			if (arrow.startPoint.Y>arrow.endPoint.Y )
				arrowBack=true;
			else
				arrowBack=false;
			if (arrow.startPoint.X<arrow.endPoint.X)
				arrowDown=true;
			else
				arrowDown=false;
			Point loc;
			Size size;
			int panelNumber;
			int buttonnumber;//number in panel (not in timeline)
			switch (arrow.arrowType)
			{
				
				case 1://from button to button
					startPoint=calculateButtonLocation(arrow.startPoint.X,arrow.startPoint.Y);
					endPoint=calculateButtonLocation(arrow.endPoint.X,arrow.endPoint.Y);
					break;
				case 2: //button to picture
					startPoint=calculateButtonLocation(arrow.startPoint.X,arrow.startPoint.Y);
					panelNumber = arrow.startPoint.Y/document[docNumber].numOfButtonsInTimeLine ;
					buttonnumber= arrow.endPoint.Y-panelNumber*document[docNumber].numOfButtonsInTimeLine;
					loc= calculateInstrumentPictureLocation(panelNumber,arrow.endPoint.X,buttonnumber);
					size=calculateInstrumentPictureSize(timeLinePanel[panelNumber]);
					if (arrowBack)
						endPoint=new Point(loc.X+size.Width,(size.Height/2)+loc.Y);
					else
						endPoint=new Point(loc.X,(size.Height/2)+loc.Y);
					//endPoint=new Point(loc.X,(size.Height/2)+loc.Y);
					break;
				case 3: //picture to picture;
					panelNumber = arrow.startPoint.Y/document[docNumber].numOfButtonsInTimeLine ; 
					buttonnumber= arrow.startPoint.Y-panelNumber*document[docNumber].numOfButtonsInTimeLine;
					loc= calculateInstrumentPictureLocation(panelNumber,arrow.startPoint.X,buttonnumber);
					size=calculateInstrumentPictureSize(timeLinePanel[panelNumber]);
					if (arrowDown )
						startPoint=new Point (loc.X+size.Width/2,(loc.Y+size.Height));
					else
						startPoint=new Point (loc.X+size.Width/2,loc.Y);
					//startPoint=calculateButtonLocation(arrow.startPoint.X,arrow.startPoint.Y);
					panelNumber = arrow.startPoint.Y/document[docNumber].numOfButtonsInTimeLine ;
					buttonnumber= arrow.endPoint.Y-panelNumber*document[docNumber].numOfButtonsInTimeLine;
					loc= calculateInstrumentPictureLocation(panelNumber,arrow.endPoint.X,buttonnumber);
					size=calculateInstrumentPictureSize(timeLinePanel[panelNumber]);
					if (arrowBack)
						endPoint=new Point(loc.X+size.Width,(size.Height/2)+loc.Y);
					else
						endPoint=new Point(loc.X,(size.Height/2)+loc.Y);

					break;
				case 4://picture to button
					panelNumber = arrow.startPoint.Y/document[docNumber].numOfButtonsInTimeLine ; 
					buttonnumber= arrow.startPoint.Y-panelNumber*document[docNumber].numOfButtonsInTimeLine;
					loc= calculateInstrumentPictureLocation(panelNumber,arrow.startPoint.X,buttonnumber);
					size=calculateInstrumentPictureSize(timeLinePanel[panelNumber]);
					if (arrowDown )
						startPoint=new Point (loc.X+size.Width/2,(loc.Y+size.Height));
					else 
						startPoint=new Point (loc.X+size.Width/2,loc.Y);
					
					//startPoint=calculateButtonLocation(arrow.startPoint.X,arrow.startPoint.Y);
					panelNumber = arrow.startPoint.Y/document[docNumber].numOfButtonsInTimeLine ;
					buttonnumber= arrow.endPoint.Y-panelNumber*document[docNumber].numOfButtonsInTimeLine;
					loc= calculateInstrumentPictureLocation(panelNumber,arrow.endPoint.X,buttonnumber);
					size=calculateInstrumentPictureSize(timeLinePanel[panelNumber]);
					endPoint=calculateButtonLocation(arrow.endPoint.X,arrow.endPoint.Y);
					break;
				default:
					startPoint=calculateButtonLocation(arrow.startPoint.X,arrow.startPoint.Y);
					endPoint=calculateButtonLocation(arrow.endPoint.X,arrow.endPoint.Y);
					break;
					
			}
			Point[] pp=new Point[2];
			pp[0]=startPoint;
			pp[1]=endPoint;
			return pp;
		}
		/***************************************************************
		 * this is the main function. here something happens when one of the 
		 *  buttons in the time lines is clicked
		 * */
		public void drawVideoPanel()
		{
			
			for (int panelCounter=0;panelCounter<this.document[docNumber].numOfPanelsInSession;panelCounter++)
			{
				
				videoPanel[panelCounter]= new APanel();
				videoPanel[panelCounter].Click+=new System.EventHandler(this.VideoPanel_Click);
				videoPanel[panelCounter].MouseDown+=new System.Windows.Forms.MouseEventHandler(this.VideoPanel_MouseDown);
				videoPanel[panelCounter].Location=calculateVideoPanelLocation();
				videoPanel[panelCounter].Size=calculateVideoPanelSize();
				videoPanel[panelCounter].BackColor=this.document[docNumber].sessionColor.PanelColor;
				videoPanel[panelCounter].panelNumber=panelCounter;
				timeLinePanel[panelCounter].Controls.Add(videoPanel[panelCounter]);
			}
		}
		public void refeshVideoPointer(int position)
		{
			 
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[1]);
			
			int objectivePosition=position+CurrentVidoeStartPoint*30/*seconds*/;
			int panelNumber=(((position/60)*2)+CurrentVidoeStartPoint)/this.document[docNumber].numOfButtonsInTimeLine;
			int secondsInPanel=((position+(CurrentVidoeStartPoint*30))-(panelNumber*this.document[docNumber].numOfButtonsInTimeLine*30));
			int Point=videoPanel[panelNumber].Size.Width*secondsInPanel/(this.document[docNumber].numOfButtonsInTimeLine*30);
			refreshVideoPanels();
			Graphics g=videoPanel[panelNumber].CreateGraphics();
			
			if (VideoIndicatorColor)
			{
				System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Blue,5);
				VideoIndicatorColor=false;
				g.DrawLine(myPen, Point, 3, Point+5, 3);
			}
			else
			{
				System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.White,5);
				VideoIndicatorColor=true;
				g.DrawLine(myPen, Point, 3, Point+5, 3);
			}
			
			
		}
		private void refreshVideoPanels()
		{
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[1]);
			//clear to res before painting
			for (int x=0;x<3;x++)
			{
				Graphics g=videoPanel[x].CreateGraphics();
				g.Clear(this.document[docNumber].sessionColor.PanelColor);
			}
			for (int videoCounter=0;videoCounter<this.document[docNumber].videoFileList.Count;videoCounter++)
			{
				VideoFile tmpVideo=(VideoFile)this.document[docNumber].videoFileList[videoCounter];
				int startPanelNumber=tmpVideo.startPoint/this.document[docNumber].numOfButtonsInTimeLine;
				int endPanelNumer=tmpVideo.endPoint/this.document[docNumber].numOfButtonsInTimeLine;
				if (endPanelNumer> this.document[docNumber].numOfPanelsInSession)
					endPanelNumer= this.document[docNumber].numOfPanelsInSession;
				bool fileEndsInThisPanel=false;
				bool filesStartedInThisPanel=false;
				//int remainingButtons;
				int nextStartPoint=0;
				for (int panelCounter=startPanelNumber;panelCounter<=endPanelNumer;panelCounter++)
				{
					int startPoint=0;
					int endPoint=0 ;
					if (tmpVideo.startPoint>panelCounter*this.document[docNumber].numOfButtonsInTimeLine 
							&& tmpVideo.startPoint < (panelCounter+1)*this.document[docNumber].numOfButtonsInTimeLine) 
						filesStartedInThisPanel=true;
					else
						filesStartedInThisPanel=false;
					if (tmpVideo.endPoint< (panelCounter+1)*this.document[docNumber].numOfButtonsInTimeLine) 
						fileEndsInThisPanel=true;
					else
						fileEndsInThisPanel=false;
					//-----------
					if (filesStartedInThisPanel && fileEndsInThisPanel)
					{
						startPoint=(tmpVideo.startPoint-panelCounter*this.document[docNumber].numOfButtonsInTimeLine)*ButtonsSize.Width;
						endPoint = /*(tmpVideo.endPoint-nextStartPoint)*ButtonsSize.Width; */((int)tmpVideo.videoFileDuration/30)*ButtonsSize.Width+startPoint;
					}
					else if(filesStartedInThisPanel && !fileEndsInThisPanel)
					{
						startPoint=(tmpVideo.startPoint-panelCounter*this.document[docNumber].numOfButtonsInTimeLine)*ButtonsSize.Width;
						endPoint = videoPanel[panelCounter].Size.Width;
						nextStartPoint=(panelCounter+1)*this.document[docNumber].numOfButtonsInTimeLine;
						//((int)tmpVideo.videoFileDuration/60)*ButtonsSize.Width*2+startPoint;
					}
					else if (!filesStartedInThisPanel && fileEndsInThisPanel)
					{
						startPoint=0;//(tmpVideo.endPoint-nextStartPoint)*ButtonsSize.Width;
						endPoint = (tmpVideo.endPoint-nextStartPoint)*ButtonsSize.Width;//((int)tmpVideo.videoFileDuration/60)*ButtonsSize.Width*2+startPoint;
					}
					else if (!filesStartedInThisPanel && !fileEndsInThisPanel)
					{
						startPoint= 0;//(nextStartPoint-panelCounter*this.document[docNumber].numOfButtonsInTimeLine)*ButtonsSize.Width;
						endPoint = videoPanel[panelCounter].Size.Width;//-startPoint;
						nextStartPoint=(panelCounter+1)*this.document[docNumber].numOfButtonsInTimeLine;
					}
					//startPoint=(tmpVideo.startPoint-panelNumber*this.document[docNumber].numOfButtonsInTimeLine)*ButtonsSize.Width;
					//endPoint = ((int)tmpVideo.videoFileDuration/60)*ButtonsSize.Width*2+startPoint;
					//int panelNumber=tmpVideo.startPoint/this.document[docNumber].numOfButtonsInTimeLine;
					Graphics g=videoPanel[panelCounter].CreateGraphics();
					
					System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Green,3);
					g.DrawLine(myPen, startPoint, 3, endPoint, 3);
				}
				//g.FillEllipse(new SolidBrush( Color.Green),startPoint, 0, endPoint, 7 );
			}
		}


        private void FramePanelClick(object sender, System.EventArgs e)
        {
            if (RemoveFrame)
            {
                AmitFrameControl.AmitFrameUserControl framePanel = (AmitFrameControl.AmitFrameUserControl)sender;
                for (int x = 0; x < this.FramePanelsArrayList.Count;x++ )
                {
                    FramePanel ff = (FramePanel)this.document[docNumber].FramePanelList[x];
                    if (ff.startPoint == framePanel.buttonLocation)
                        this.document[docNumber].FramePanelList.RemoveAt(x);
                }
                refreshFrameePanels();
               // MessageBox.Show("got click");

            }
        }
        private void ButtonDoubleClick(object sender, System.EventArgs e)
        {
            AButton b = (AButton)sender;
            //buttonMouseDown
            //ButtonArray[x, yy].DoubleClick += new System.EventHandler(ButtonDoubleClick);
            //verify which action is needed
            
        }
		private void ButtonClick(object sender, System.EventArgs e)
		{
			AButton b = (AButton)sender;
			//
            System.Windows.Forms.MouseEventArgs aa = (System.Windows.Forms.MouseEventArgs)e;
          //  if (aa.Clicks==1)
            //    isDoubleClick = true;
            //if (aa.Clicks == 2 && isDoubleClick== true)
           
			//verify which action is needed
           
            if (this.AddMusicNotes)
            {
                // if it is the second click for the end section 
                if (isWaitingForMusicNotesEnsdSectionClick)
                {
                    //check if the point is legal;
                    if (startMusicNotesSection.Y > b.x)
                    {
                        MessageBox.Show("This is an ilegal end point");
                        return;
                    }
                    MusicNotes musicNotes = new MusicNotes();
                    //SilencePanel silence = new SilencePanel();
                    //sss
                    Finale finaleDialog = new Finale();
                    finaleDialog.parentForm = this;
                    finaleDialog.Mafteach = 0;
                    finaleDialog.initStafLineArray(finaleDialog.sketchPanel);
                    finaleDialog.drawStaf(finaleDialog.sketchPanel);
                  //  SilenceAttributes silenceDialogBox = new SilenceAttributes();
                    if (finaleDialog.ShowDialog() == DialogResult.OK)
                    {
                        musicNotes.startPoint = startMusicNotesSection.Y;
                        musicNotes.endPoint = b.x;
                     //   musicNotes.color = silenceDialogBox.SilenceColor;
                        isWaitingForMusicNotesEnsdSectionClick = false;
                        musicNotes.NotesList = finaleDialog.notesArrayList;
                        musicNotes.tempo = finaleDialog.Tempo;
                        musicNotes.Mafteach = finaleDialog.Mafteach;

                        musicNotes.NotesPictureFileName = finaleDialog.NotePictureFileName;
                       // silence.TimeOfSilence = silenceDialogBox.SilenceTime;
                        this.document[docNumber].MusicNotesList.Add(musicNotes);
                        this.Cursor = Cursors.Arrow;
                        refreshMusicNotes();
                    }

                }
                else // it is the first click for the start section point or a click for expanding the button width
                {
                   
                    //change the cursor
                    Cursor.Current = new Cursor((((MainForm)(this.MdiParent)).MainDirectory) + "\\secondklick1.ico");
                    this.Cursor = Cursor.Current;
                    //keep the point for the next click to calculate the time interval between the start and the end
                    startMusicNotesSection = new Point(b.y, b.x);
                    //update the flag to indicate that the next click should be the end section point button
                    isWaitingForMusicNotesEnsdSectionClick = true;
                }
            }
            if (this.AddFrame)
            {
                  // if it is the second click for the end section 
                if (isWaitingForFramePanelEnsdSectionClick)
                {
                    //check if the point is legal;
                    if (startFramePanelSection.Y > b.x)
                    {
                        MessageBox.Show("This is an ilegal end point");
                        return;
                    }
                    FramePanel frame = new FramePanel();
                    
                    //sss
                    FrameAttributes frameDialogBox = new FrameAttributes();
                    frameDialogBox.FrameType = 0;
                    frameDialogBox.FrameColor = Color.Red;
                    if (frameDialogBox.ShowDialog() == DialogResult.OK)
                    {
                        frame.startPoint = startFramePanelSection;
                        frame.endPoint = new Point(b.y,b.x);
                        frame.width = frameDialogBox.FrameWidth;
                        frame.color = frameDialogBox.FrameColor;
                        frame.type = frameDialogBox.FrameType;
                        
                        isWaitingForFramePanelEnsdSectionClick = false;
                        //frame.TimeOfSilence = silenceDialogBox.SilenceTime;
                        this.document[docNumber].FramePanelList.Add(frame);
                        this.Cursor = Cursors.Arrow;
                        refreshFrameePanels();
                    }
                }
                else // it is the first click for the start section point or a click for expanding the button width
                {
                    //change the cursor
                    Cursor.Current = new Cursor((((MainForm)(this.MdiParent)).MainDirectory) + "\\secondklick1.ico");
                    this.Cursor = Cursor.Current;
                    //keep the point for the next click to calculate the time interval between the start and the end
                    startFramePanelSection = new Point(b.y, b.x);
                    //update the flag to indicate that the next click should be the end section point button
                    isWaitingForFramePanelEnsdSectionClick = true;
                }
            }
            if (this.AddSilence)
            {
                // if it is the second click for the end section 
                if (isWaitingForSilencePanelEnsdSectionClick)
                {
                    //check if the point is legal;
                    if (startSilencePanelSection.Y > b.x)
                    {
                        MessageBox.Show("This is an ilegal end point");
                        return;
                    }
                    SilencePanel silence = new SilencePanel();
                    //sss
                    SilenceAttributes silenceDialogBox = new SilenceAttributes();
                    if (silenceDialogBox.ShowDialog() == DialogResult.OK)
                    {
                        silence.startPoint = startSilencePanelSection.Y;
                        silence.endPoint = b.x;
                        silence.color = silenceDialogBox.SilenceColor;
                        isWaitingForSilencePanelEnsdSectionClick = false;
                        silence.TimeOfSilence = silenceDialogBox.SilenceTime;
                        this.document[docNumber].SilencePanelList.Add(silence);
                        this.Cursor = Cursors.Arrow;
                        refreshSilencePanels();
                    }
                  
                }
                else // it is the first click for the start section point or a click for expanding the button width
                {
                    //change the cursor
                    Cursor.Current = new Cursor((((MainForm)(this.MdiParent)).MainDirectory) + "\\secondklick1.ico");
                    this.Cursor = Cursor.Current;
                    //keep the point for the next click to calculate the time interval between the start and the end
                    startSilencePanelSection = new Point(b.y, b.x);
                    //update the flag to indicate that the next click should be the end section point button
                    isWaitingForSilencePanelEnsdSectionClick = true;
                }
            }
           
			if ( this.RichText)
			{
				
				RichTextAboveTimeLine richTextAboveTimeLine= new RichTextAboveTimeLine ();
				richTextAboveTimeLine.startPoint = b.x;
													
				RichText richTexta = new RichText();
				Size buttonSize = calculateButtonsSize(this.timeLinePanel[0]);
				int PanelNember = b.x/this.document[docNumber].numOfButtonsInTimeLine;
				int numOfButtonsFromStartOfTimeLine = b.x -this.document[docNumber].numOfButtonsInTimeLine*PanelNember ;
				richTexta.MaximumLength=(this.document[docNumber].numOfButtonsInTimeLine - numOfButtonsFromStartOfTimeLine)*buttonSize.Width/7;
				if (richTexta.ShowDialog()==DialogResult.OK) 
				{
					//richTextAboveTimeLine.Text/*richTextBox*/=richTexta.MainText;
					richTextAboveTimeLine.Text=richTexta.MainTextUpdate;
					richTextAboveTimeLine.RTF=richTexta.RTF;
					richTextAboveTimeLine.AdditionalText=richTexta.AdditionalText;
				}
				else return;
				this.document[docNumber].RichTextList.Add(richTextAboveTimeLine);
				refreshRichTextBoxes();
			}
			if (this.AddDisc)
			{
				if (isWaitingForDiscEndClick)
				{
					//check if the point is legal;
					if (startDiscPosition.Y > b.x/* && startSingPosition.X==b.y*/)
					{
						MessageBox.Show("This is an ilegal end point start point should be before end point");
						return;
					}
					int startPanelNumber= startDiscPosition.Y/this.document[docNumber].numOfButtonsInTimeLine;
					int endPanelNumber=b.x/this.document[docNumber].numOfButtonsInTimeLine;
			
					if( endPanelNumber -startPanelNumber ==2)
					{
						MessageBox.Show("This is an ilegal end point, end point to far");
						return;
					}
			
					Disc disc= new Disc();
					disc.startPoint = startDiscPosition.Y;
					disc.endPoint = b.x;
										
					DiscAttributes discDialog = new DiscAttributes();
					
					if (discDialog .ShowDialog() == DialogResult.OK)
					{
						disc.color = discDialog.SingColor ;
						disc.title = discDialog.Title;
						disc.performance = discDialog.performance;
						//disc.additionlInfo = discDialog.AdditionalInfo;
					}
					else return;

					this.document[docNumber].DiscList.Add(disc);
					for (int x=disc.startPoint;x<=disc.endPoint;x++)
					{
						for (int y=0;y<this.document[docNumber].numOfPatiants;y++)
						{
							document[docNumber].timeLine[y].MinutesArray[x].buttonBackColor= this.document[docNumber].ColorForButtonsWithDisc;
						}
					}
					//restart the flag
					isWaitingForDiscEndClick=false;
					refreshDiscPanels();
					this.Cursor = Cursors.Arrow;
				}
				else // it is the first click for the start section point or a click for expanding the button width
				{
					//check if this button allready has an singScream indication
					if (checkDiscIndication(b.x,b.y)>=0)
					{
						MessageBox.Show("Cannot place another Disc here!");
						return;
					}
					
					//change the cursor
					Cursor.Current = new Cursor( (((MainForm) (this.MdiParent)).MainDirectory)+"\\secondklick1.ico"  );
					this.Cursor = Cursor.Current;
					//keep the point for the next click to calculate the time interval between the start and the end
					startDiscPosition= new Point(b.y,b.x);
					//startArroFromButton=true;
					//update the flag to indicate that the next click should be the end section point button
					isWaitingForDiscEndClick=true;
				}
			}
			
			/*if (this.RemoveDisc)
			{
				int removeItem=checkDiscIndication(b.x,b.y);
				if (removeItem>=0) this.document[docNumber].DiscList.RemoveAt(removeItem);
				this.refreshDiscPanels();
			}*/
			if (this.AddSingSinus || this.AddScreamZigzag)
			{
				if (isWaitingForSingSectionEndClick)
				{
					//check if the point is legal;
					if (startSingPosition.Y > b.x && startSingPosition.X==b.y)
					{
						MessageBox.Show("This is an ilegal end point");
						return;
					}
					if (startSingPosition.X!=b.y)
					{
						MessageBox.Show("This is an ilegal end point, end point must end on smae patiant");
						return;
					}
				int startPanelNumber= startSingPosition.Y/this.document[docNumber].numOfButtonsInTimeLine;
				int endPanelNumber=b.x/this.document[docNumber].numOfButtonsInTimeLine;
			
				if( endPanelNumber -startPanelNumber ==2)
				{
					MessageBox.Show("This is an ilegal end point, end point to far");
					return;
				}
			

						SingSinusAndScreamZigzag sing = new SingSinusAndScreamZigzag();
					sing.startPoint = startSingPosition.Y;
					sing.endPoint = b.x;
					sing.type=1;
					
					SingScreamAttributes singDialog = new SingScreamAttributes();
					
					if (singDialog.ShowDialog() == DialogResult.OK)
					{
						sing.color = singDialog.SingColor ;
						sing.amplitude= singDialog.Amplitude;
						sing.Phase = singDialog.Phase;
						sing.Width = singDialog.WidthOfSingScream;
						switch(singDialog.Frequncy)
						{
							case 0:
							sing.frequency = 1;
								break;
							case 1:
								sing.frequency = 3;
								break;
							case 2:
								sing.frequency = 5;
								break;
						}
					}
					else return;

					if (AddSingSinus)
						sing.type=1;
					else
						sing.type=2;
					sing.patiantNumber=b.y;
					
					this.document[docNumber].SingScreamList.Add(sing);

					//restart the flag
					isWaitingForSingSectionEndClick=false;
					refreshSingScream();
					this.Cursor = Cursors.Arrow;
				}
				else // it is the first click for the start section point or a click for expanding the button width
				{
					//check if this button allready has an singScream indication
					if (checkSingScreamIndication(b.x,b.y)>=0)
					{
						MessageBox.Show("Cannot place another sing or scream here!");
						return;
					}
					
					//change the cursor
					Cursor.Current = new Cursor( (((MainForm) (this.MdiParent)).MainDirectory)+"\\secondklick1.ico"  );
					this.Cursor = Cursor.Current;
					//keep the point for the next click to calculate the time interval between the start and the end
					startSingPosition= new Point(b.y,b.x);
					//startArroFromButton=true;
					//update the flag to indicate that the next click should be the end section point button
					isWaitingForSingSectionEndClick=true;
				}
			}
			if (this.RemoveSingSinus || this.RemoveScreapZigzag)
			{
				int removeItem=checkSingScreamIndication(b.x,b.y);
				if (removeItem>=0) this.document[docNumber].SingScreamList.RemoveAt(removeItem);
				this.refreshSingScream();
			}
			if (this.RemoveVideo)
			{
				MainForm main =(MainForm) this.MdiParent;
				if (main.videoForm != null)
				main.videoForm.menuFileCloseClip_Click(null, null);
				for (int videoCounter=0;videoCounter<this.document[docNumber].videoFileList.Count;videoCounter++)
				{
					VideoFile tmpVideo=(VideoFile)this.document[docNumber].videoFileList[videoCounter];
					if (b.x>=tmpVideo.startPoint && b.x<=tmpVideo.endPoint)
					{
						this.document[docNumber].videoFileList.RemoveAt(videoCounter);
					}
				}
				refreshVideoPanels();
			}
			if (this.AddVideo)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.DefaultExt = "*.avi";
				openFileDialog.Filter = "avi files (*.avi)|*.avi|*.wmv|*.*"  ;
				//openFileDialog.Filter = "map files (*.map)|*.map|All files(*.*)|*.*"  ;
				if(openFileDialog.ShowDialog() == DialogResult.OK)
				{
					Type comtype = null;
					object comobj = null; 
					IGraphBuilder			graphBuilder;
					comtype = Type.GetTypeFromCLSID( Clsid.FilterGraph );
					if( comtype == null )
						throw new NotSupportedException( "DirectX (8.1 or higher) not installed?" );
					comobj = Activator.CreateInstance( comtype );
					graphBuilder = (IGraphBuilder) comobj; comobj = null;
			
					int hr = graphBuilder.RenderFile( openFileDialog.FileName, null );
					IMediaPosition			mediaPos;
					IMediaSeeking mediaSeek	= (IMediaSeeking)  graphBuilder;
					mediaPos	= (IMediaPosition) graphBuilder;
					VideoFile tmpVideo = new VideoFile();
					long duration;
					mediaSeek.GetDuration(out duration);
					tmpVideo.videoFileDuration=(int)(duration/10000000);
					if (tmpVideo.videoFileDuration/60>this.document[docNumber].sessionDuration)
					{
						MessageBox.Show("The file is too big for this Session");
						return;
					}
					tmpVideo.startPoint=b.x;
					if (tmpVideo.videoFileDuration/60+(tmpVideo.startPoint/2)>this.document[docNumber].sessionDuration)
					{
						MessageBox.Show("Theere is not enough room for this file at this location");
						return;
					}

					
					if ((int)tmpVideo.videoFileDuration>30)
						tmpVideo.endPoint=tmpVideo.startPoint-1+((int)tmpVideo.videoFileDuration/30);
					else
						tmpVideo.endPoint=tmpVideo.startPoint+1;
				
					tmpVideo.videoFileName=openFileDialog.FileName;
					this.document[docNumber].videoFileList.Add(tmpVideo);
					refreshVideoPanels();
					
				}
			}
			if (this.AddArrow)
			{
				// if it is the second click for the end section 
				if (isWaitingForArrowEndClick)
				{
					//check if the point is legal;
					/*if (startArrowPosition.Y > b.x)
					{
						MessageBox.Show("This is an ilegal end point");
						return;
					}*/
					
					//this.document[docNumber].timeLine[startArrowPosition.X].MinutesArray[startArrowPosition.Y].isOpacPanelStartHere=true;
					Arrow arrow =new Arrow(Color.Black,new Point(startArrowPosition.X,startArrowPosition.Y),new Point(b.y,b.x),1);
					//choose color
					ColorDialog colorDialog = new ColorDialog();
					colorDialog.AllowFullOpen = true;
					colorDialog.AnyColor = true;
					colorDialog.SolidColorOnly = false;
					colorDialog.ShowHelp = true;
			
					if (colorDialog.ShowDialog() == DialogResult.OK)
					{
						arrow.color= colorDialog.Color;
					}
					if (startArroFromButton)
						arrow.arrowType=1;
					else
						arrow.arrowType=4;
					this.document[docNumber].timeLine[startArrowPosition.X].MinutesArray[startArrowPosition.Y].arrowList.Add(arrow);
					//restart the flag
					isWaitingForArrowEndClick=false;
					refreshArrows();
					this.Cursor = Cursors.Arrow;
				}
				else // it is the first click for the start section point or a click for expanding the button width
				{
					/*if (this.document[docNumber].timeLine[b.y].MinutesArray[b.x].isOpacPanelStartHere)
					{
						MessageBox.Show("This place allready has an opac panel");	
						return;
					}*/
					/*if (this.document[docNumber].timeLine[b.y].MinutesArray[b.x+1].isInstrumentInButton)
					{
						MessageBox.Show("Can't place another instrumetn so close");
						return;
					}*/
					//change the cursor
					Cursor.Current = new Cursor( (((MainForm) (this.MdiParent)).MainDirectory)+"\\secondklick1.ico"  );
					this.Cursor = Cursor.Current;
					//keep the point for the next click to calculate the time interval between the start and the end
					startArrowPosition= new Point(b.y,b.x);
					startArroFromButton=true;
					//update the flag to indicate that the next click should be the end section point button
					isWaitingForArrowEndClick=true;
				}
			}
			else if (this.RemoveArrow)
			{
				this.document[docNumber].timeLine[b.y].MinutesArray[b.x].arrowList.Clear();
				refreshArrows();
				timeLinePanel[0].Invalidate();
				timeLinePanel[1].Invalidate();
				timeLinePanel[2].Invalidate();
			}
				//in case it is opac panelto add
			else if (this.AddOpacPanel)
			{
				// if it is the second click for the end section 
				if (isWaitingForOpacPanelEnsdSectionClick)
				{
					//check if the point is legal;
					if (startOpacPanelSection.Y > b.x)
					{
						MessageBox.Show("This is an ilegal end point");
						return;
					}
                    int startPanel = startOpacPanelSection.Y / this.document[docNumber].numOfButtonsInTimeLine;
                    int endPanel = b.x / this.document[docNumber].numOfButtonsInTimeLine;
                    if (startPanel != endPanel)
                    {
                        MessageBox.Show("This is an ilegal end point");
                        return;
                    }
					this.document[docNumber].timeLine[startOpacPanelSection.X].MinutesArray[startOpacPanelSection.Y].isOpacPanelStartHere=true;
					AmitOpacUserControl OpacPanel=new AmitOpacUserControl();
					//choose color
					ColorDialog colorDialog = new ColorDialog();
					colorDialog.AllowFullOpen = true;
					colorDialog.AnyColor = true;
					colorDialog.SolidColorOnly = false;
					colorDialog.ShowHelp = true;
			
					if (colorDialog.ShowDialog() == DialogResult.OK)
					{
						OpacPanel.AmitColor= colorDialog.Color;
						this.document[docNumber].timeLine[startOpacPanelSection.X].MinutesArray[startOpacPanelSection.Y].opacPanel.color=colorDialog.Color;
					}
					this.document[docNumber].timeLine[startOpacPanelSection.X].MinutesArray[startOpacPanelSection.Y].opacPanel.endPoint=new Point(b.y,b.x);
					//restart the flag
					isWaitingForOpacPanelEnsdSectionClick=false;
					
					OpacPanel.Location=calculateOpacPanelLocation(startOpacPanelSection.X,startOpacPanelSection.Y);
					OpacPanel.Size = calculateOpacPanelSize(startOpacPanelSection.X,startOpacPanelSection.Y,b.x-startOpacPanelSection.Y,b.y-startOpacPanelSection.X);
					OpacPanel.AmitOpacity=100;
					int panelNumber =-1;
					for (int x=b.x;x<this.document[docNumber].numOfPanelsInSession*this.document[docNumber].numOfButtonsInTimeLine;x=x-this.document[docNumber].numOfButtonsInTimeLine)
					{
						if (x<=0)
							break;
						panelNumber++;
					}
					timeLinePanel[panelNumber].Controls.Add(OpacPanel);
					OpacPanelsArrayList.Add(OpacPanel);
					OpacPanel.Show();
					// refresh the buttons (change their width and location)
					//refreshInstrumentIndicationInTimeLine();
					this.Cursor = Cursors.Arrow;
				}
				else // it is the first click for the start section point or a click for expanding the button width
				{
					if (this.document[docNumber].timeLine[b.y].MinutesArray[b.x].isOpacPanelStartHere)
					{
						MessageBox.Show("This place allready has an opac panel");	
						return;
					}
					
					//change the cursor
					Cursor.Current = new Cursor( (((MainForm) (this.MdiParent)).MainDirectory)+"\\secondklick1.ico"  );
					this.Cursor = Cursor.Current;
					//keep the point for the next click to calculate the time interval between the start and the end
					startOpacPanelSection = new Point(b.y,b.x);
					//update the flag to indicate that the next click should be the end section point button
					isWaitingForOpacPanelEnsdSectionClick=true;
				}
			}
			else if (this.RemoveOpac)
			{
				RemoveOpacPanel(b);	
			}
			else if ( this.AddTextButtonPushed)
			{
				AddTextDialogBox dialogBox= new AddTextDialogBox();
				dialogBox.parentForm = this;
				DialogResult res=dialogBox.ShowDialog();
				if ( res== DialogResult.OK)
				{
					this.document[docNumber].timeLine[b.y].MinutesArray[b.x].topicAndSubTopic=dialogBox.groupTextBox.Text+dialogBox.serialTextBox.Text;
					string temp=this.document[docNumber].timeLine[b.y].MinutesArray[b.x].topicAndSubTopic;
                    refreshTopicLables(); 
                    //LableArray[b.y, b.x].Text=temp;
                    //sessionToolTip.SetToolTip(LableArray[b.y, b.x], this.document[docNumber].timeLine[b.y].MinutesArray[b.x].topicAndSubTopic);
					//LableArray[b.y, b.x].Show();					
				}
			}//-------------------------------------
				// in case it is instrument add handaling
			else if (this.AddInstrumentButtonPushed)
			{
				// if it is the second click for the end section 
				if (isWaitingForinstrumentEndSectionClick)
				{
					//check if the point is legal;
					if (startInstrumentSection.X!=b.y ||
						startInstrumentSection.Y > b.x)
					{
						MessageBox.Show("This is an ilegal end point");
						return;
					}
					for (int buttonCounter=startInstrumentSection.Y;buttonCounter<=b.x;buttonCounter++)
					{//update the document 
						if (this.document[docNumber].timeLine[b.y].MinutesArray[buttonCounter].isInstrumentInButton)
						{
							MessageBox.Show("This is an ilegal end point");
							return ;
						}	
					}
					
					
					//show the end section button only if the end poinr is not the start point
					if (startInstrumentSection.X!=b.y || startInstrumentSection.Y!=b.x)	
					{
						this.document[docNumber].timeLine[b.y].MinutesArray[b.x].instrumentEndHere=true;
						EndInstrumentSectionButtonArray[b.y,b.x].Show();
					}
					//restart the flag
					isWaitingForinstrumentEndSectionClick=false;
					//update all the buttons in the instrument section
					if (startInstrumentSection.Y==b.x)
						//no need to color any button, just inducate for statistcs
						this.document[docNumber].timeLine[b.y].MinutesArray[b.x].isInstrumentInButton = true;
					else
					{
						for (int buttonCounter=startInstrumentSection.Y;buttonCounter<=b.x;buttonCounter++)
						{//update the document 
							this.document[docNumber].timeLine[b.y].MinutesArray[buttonCounter].levelOfInstrumentIntensity = 4;
							this.document[docNumber].timeLine[b.y].MinutesArray[buttonCounter].isInstrumentInButton = true;
							this.document[docNumber].timeLine[b.y].MinutesArray[buttonCounter].buttonBackColor= Color.Blue;
							this.document[docNumber].timeLine[b.y].MinutesArray[buttonCounter].instrumetnInfo=tmpInstrInfo;
						}
					}
					// refresh the buttons (change their width and location)
					refreshInstrumentIndicationInTimeLine();
					this.Cursor = Cursors.Arrow;
				}
				else // it is the first click for the start section point or a click for expanding the button width
				{
					if (this.document[docNumber].timeLine[b.y].MinutesArray[b.x].isInstrumentInButton)
					{
						switch(this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity)
						{
							case 0:
								this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 2;
								break;
							case 2:
								this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 4;
								break;
							case 4:
								this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 6;
								break;
							case 6:
								this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 8;
								break;
							case 8:
								this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 10;
								break;
							case 10:
								this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 12;
								break;
							case 12:
								this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 14;
								break;
							case 14:
								this.document[docNumber].timeLine[b.y].MinutesArray[b.x].levelOfInstrumentIntensity = 0;
								break;

						}
						refreshInstrumentIndicationInTimeLine();
					}
					else
					{
						if (this.document[docNumber].timeLine[b.y].MinutesArray[b.x+1].isInstrumentInButton)
						{
							MessageBox.Show("Can't place another instrumetn so close");
							return;
						}
						if (usingCachInstrument>0 && ((MainForm) (this.MdiParent)).instrumentCachArray[usingCachInstrument-1].Name!= "" )
						{
							//change the cursor
							Cursor.Current = new Cursor( (((MainForm) (this.MdiParent)).MainDirectory)+"\\secondklick1.ico"  );
							this.Cursor = Cursor.Current;
							//updtae the document
							this.document[docNumber].timeLine[b.y].MinutesArray[b.x].instrumentStartHere=true; 
							this.document[docNumber].timeLine[b.y].MinutesArray[b.x].instrumetnInfo= ((MainForm) (this.MdiParent)).instrumentCachArray[usingCachInstrument-1] ;
							//keep the instrumetn info for the nexe step when end section click arives
							tmpInstrInfo=this.document[docNumber].timeLine[b.y].MinutesArray[b.x].instrumetnInfo;
							//show the instrumetn picture in the instrumetn picture array
							string fileName = ((MainForm) (this.MdiParent)).MainDirectory+ "\\pictures\\instruments\\" +tmpInstrInfo.Category+ "\\" + tmpInstrInfo.SubCategory+ "\\" +tmpInstrInfo.Name;
							InstrumentPictureArray[b.y, b.x].Image = new Bitmap(fileName);
							InstrumentPictureArray[b.y, b.x].Show();
							//InstrumentPictureArray[b.y, b.x].SendToBack();
							//qqq
							//keep the point for the next click to calculate the time interval between the start and the end
							startInstrumentSection = new Point(b.y,b.x);
							//update the flag to indicate that the next click should be the end section point button
							isWaitingForinstrumentEndSectionClick=true;
								
							
						}
						else
						{
							InstrumentManager instrumentDialogBox = new InstrumentManager();
							instrumentDialogBox.parentForm = this;
							//instrumentDialogBox.InstrumentManager_Load(sender,e);
							instrumentDialogBox.loadInstruments();
							instrumentDialogBox.initTreeView();
							//open the instrument manager dialog box to choose a instrument
                            instrumentDialogBox.WindowState = FormWindowState.Maximized;
                            DialogResult res = instrumentDialogBox.ShowDialog();
							if ( res== DialogResult.OK )
							{	
								//change the cursor
								Cursor.Current = new Cursor( (((MainForm) (this.MdiParent)).MainDirectory)+"\\secondklick1.ico"  );
								this.Cursor = Cursor.Current;
								//updtae the document
								this.document[docNumber].timeLine[b.y].MinutesArray[b.x].instrumentStartHere=true; 
								this.document[docNumber].timeLine[b.y].MinutesArray[b.x].instrumetnInfo= new InstrumentInfo(instrumentDialogBox.activeInstrument.categoryName,instrumentDialogBox.activeInstrument.subCategoryName,"",instrumentDialogBox.activeInstrument.instrumentName);
								cachInstrumentInfo = this.document[docNumber].timeLine[b.y].MinutesArray[b.x].instrumetnInfo;
								//keep the instrumetn info for the nexe step when end section click arives
								tmpInstrInfo=this.document[docNumber].timeLine[b.y].MinutesArray[b.x].instrumetnInfo;
								//show the instrumetn picture in the instrumetn picture array
								string fileName = ((MainForm) (this.MdiParent)).MainDirectory+ "\\pictures\\instruments\\" +instrumentDialogBox.activeInstrument.categoryName+ "\\" + instrumentDialogBox.activeInstrument.subCategoryName+ "\\" +instrumentDialogBox.activeInstrument.instrumentName;
								InstrumentPictureArray[b.y, b.x].Image = new Bitmap(fileName);
								InstrumentPictureArray[b.y, b.x].Show();
								//InstrumentPictureArray[b.y, b.x].SendToBack();
								//qqq
								//keep the point for the next click to calculate the time interval between the start and the end
								startInstrumentSection = new Point(b.y,b.x);
								//update the flag to indicate that the next click should be the end section point button
								isWaitingForinstrumentEndSectionClick=true;
								((MainForm)this.MdiParent).setPictureCach(tmpInstrInfo);
                                //instrumentDialogBox.iDispose();//  = null;//amit
							}
						}
					}
				}
			}
			else if(this.RemoveInstrumentButtonPushed)
			{
				//this.document[docNumber].timeLine[b.y].MinutesArray[b.x].instrumentEndHere=false;
				//show the end section button
				
				//restart the flag
				//isWaitingForinstrumentEndSectionClick=false;
				//update all the buttons in the instrument section
				int startPoint=FindStartPointOfInstrument(b.y,b.x,this.document[docNumber].timeLine[b.y].MinutesArray[b.x].instrumetnInfo);
				int endPoint = FindEndPointOfInstrument(b.y,b.x,this.document[docNumber].timeLine[b.y].MinutesArray[b.x].instrumetnInfo);
				InstrumentPictureArray[b.y,startPoint].Hide();
				EndInstrumentSectionButtonArray[b.y,endPoint].Hide();
				for (int buttonCounter=startPoint ;buttonCounter<=endPoint;buttonCounter++)
				{
					if (this.document[docNumber].timeLine[b.y].MinutesArray[buttonCounter].isInstrumentInButton)
					{
						this.document[docNumber].timeLine[b.y].MinutesArray[buttonCounter].isInstrumentInButton=false;
						this.document[docNumber].timeLine[b.y].MinutesArray[buttonCounter].instrumentEndHere= false;
						this.document[docNumber].timeLine[b.y].MinutesArray[buttonCounter].instrumentStartHere = false;
						this.document[docNumber].timeLine[b.y].MinutesArray[buttonCounter].levelOfInstrumentIntensity = 2;
						this.document[docNumber].timeLine[b.y].MinutesArray[buttonCounter].buttonBackColor = Color.Black;
					}
				}
				// refresh the buttons (change their width and location)
				refreshInstrumentIndicationInTimeLine();
				//this.Cursor  = Cursor.
				this.Cursor = Cursors.Arrow;

			}
			else if (this.RemoveTextButtonPushed)
			{			
				this.document[docNumber].timeLine[b.y].MinutesArray[b.x].topicAndSubTopic="";
				//this.refreshTopicLablesOnButtons();
                this.refreshTopicLables();
			}
		}
		
		public void refreshInstrumentPictureBox()
		{
			for ( int patiantCounter= 0;patiantCounter<document[docNumber].numOfPatiants;patiantCounter++)
			{
				for (int buttonCounter= 0;buttonCounter< (document[docNumber].sessionDuration)*2; buttonCounter++)
				{
			
					if (this.document[docNumber].timeLine[patiantCounter].MinutesArray[patiantCounter].instrumentEndHere)
						EndInstrumentSectionButtonArray[patiantCounter, buttonCounter].Show();
					else
						EndInstrumentSectionButtonArray[patiantCounter, buttonCounter].Hide();
					if (this.document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].instrumentStartHere)
					{
						//string fileName = ((MainForm) (this.MdiParent)).MainDirectory+ "\\pictures\\instruments\\" +instrumentDialogBox.activeInstrument.categoryName+ "\\" + instrumentDialogBox.activeInstrument.subCategoryName+ "\\" +instrumentDialogBox.activeInstrument.instrumentName;
                        string fileName = ((MainForm)(this.MdiParent)).MainDirectory + "\\pictures\\instruments\\" + this.document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].instrumetnInfo.Category + "\\" + this.document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].instrumetnInfo.SubCategory + "\\" + this.document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].instrumetnInfo.Name;
						InstrumentPictureArray[patiantCounter, buttonCounter].Image = new Bitmap(fileName);
						InstrumentPictureArray[patiantCounter, buttonCounter].Show();
						
						
					}
					else
						InstrumentPictureArray[patiantCounter, buttonCounter].Hide();
				}
			}
		}
		private int checkSingScreamIndication(int button, int patiantNumber)
		{
			int found=-1;
			for (int singCounter=0;singCounter<this.document[docNumber].SingScreamList.Count;singCounter++)
			{
				SingSinusAndScreamZigzag sing = (SingSinusAndScreamZigzag)this.document[docNumber].SingScreamList[singCounter];
				if (button>=sing.startPoint && 
					button<=sing.endPoint   &&
					patiantNumber==sing.patiantNumber)
				{
					found=singCounter;
					return found;
				}
			}
			return found;
		}
		private int checkDiscIndication(int button, int patiantNumber)
		{
			int found=-1;
			for (int discCounter=0;discCounter<this.document[docNumber].DiscList.Count;discCounter++)
			{
				Disc disc = (Disc)this.document[docNumber].DiscList[discCounter];
				if (button>=disc.startPoint && button<=disc.endPoint )
				{
					found=discCounter;
					return found;
				}
			}
			return found;
		}
       
		private int checkRichTextIndication(int button, int patiantNumber)
		{
			int found=-1;
			for (int discCounter=0;discCounter<this.document[docNumber].RichTextList.Count;discCounter++)
			{
				RichTextAboveTimeLine richText = (RichTextAboveTimeLine)this.document[docNumber].RichTextList[discCounter];

				if (button==richText.startPoint )
				{
					found=discCounter;
					return found;
				}
			}
			return found;
		}
		public void refreshSingScream()
		{
			//first  the opca panels from the time lines
			foreach (Control cont in SingScreamArrayList)
			{
				for (int x=0;x<this.document[docNumber].numOfPanelsInSession;x++)
				{
					this.timeLinePanel[x].Controls.Remove(cont);
				}
			}
			//clear the array list
			SingScreamArrayList.Clear();
			
			
			for (int singCounter=0;singCounter<this.document[docNumber].SingScreamList.Count;singCounter++)
			{
				SingSinusAndScreamZigzag sing = (SingSinusAndScreamZigzag)this.document[docNumber].SingScreamList[singCounter];
				int startPanelNumber=sing.startPoint/this.document[docNumber].numOfButtonsInTimeLine;
				int endPanelNumber=sing.endPoint/this.document[docNumber].numOfButtonsInTimeLine;
				
				if(startPanelNumber != endPanelNumber)
				{//starts and ends on different oanels
					if (endPanelNumber-startPanelNumber == 1)
					{
						Size ButtonsSize=calculateButtonsSize(timeLinePanel[0]);
						AmitSingSinusControl.AmitSinusUserControl singControl1 = new AmitSingSinusControl.AmitSinusUserControl(sing.amplitude, ButtonsSize.Width/sing.frequency);
						AmitSingSinusControl.AmitSinusUserControl singControl2 = new AmitSingSinusControl.AmitSinusUserControl(sing.amplitude, ButtonsSize.Width/sing.frequency);
						singControl1.AmitColor=sing.color;
						singControl1.phase=sing.Phase;
                        singControl1.width= sing.Width;
						singControl2.AmitColor=sing.color;
						singControl2.phase=sing.Phase;
						singControl2.width=sing.Width;
						
						singControl1.Location = calculateSingScreamLoaction(sing.startPoint,sing.patiantNumber,sing.amplitude);
						singControl1.Size = calculateSingScreamSize((startPanelNumber+1)*this.document[docNumber].numOfButtonsInTimeLine/* sing.endPoint*/-sing.startPoint,sing.amplitude);
						singControl2.Location = calculateSingScreamLoaction( (endPanelNumber *this.document[docNumber].numOfButtonsInTimeLine)/*sing.startPoint*/,sing.patiantNumber,sing.amplitude);
						singControl2.Size = calculateSingScreamSize(sing.endPoint-((endPanelNumber )*this.document[docNumber].numOfButtonsInTimeLine)+1,sing.amplitude);
						
						if (sing.type==1)	
						{ 
							singControl1.tension=1.05F;
							singControl2.tension=1.05F;
						}
						else
						{
							singControl1.tension=0;
							singControl2.tension=0;
						}
						this.timeLinePanel[sing.startPoint/ this.document[docNumber].numOfButtonsInTimeLine].Controls.Add(singControl1);
						this.SingScreamArrayList.Add(singControl1);
						this.timeLinePanel[sing.endPoint/ this.document[docNumber].numOfButtonsInTimeLine].Controls.Add(singControl2);
						this.SingScreamArrayList.Add(singControl2);

					}

				}
				else
				{
					Size ButtonsSize=calculateButtonsSize(timeLinePanel[0]);
					AmitSingSinusControl.AmitSinusUserControl singControl = new AmitSingSinusControl.AmitSinusUserControl(sing.amplitude, ButtonsSize.Width/sing.frequency);
					singControl.AmitColor=sing.color;
					singControl.phase=sing.Phase;
					singControl.width=sing.Width;

					singControl.Location = calculateSingScreamLoaction(sing.startPoint,sing.patiantNumber,sing.amplitude);
					singControl.Size = calculateSingScreamSize(sing.endPoint-sing.startPoint+1,sing.amplitude);
					if (sing.type==1)
						singControl.tension=1.05F;
					else
						singControl.tension=0;
					this.timeLinePanel[sing.startPoint/ this.document[docNumber].numOfButtonsInTimeLine].Controls.Add(singControl);
					this.SingScreamArrayList.Add(singControl);
				}
			}

		}
		public void refreshRichTextBoxes()
		{
			//first  the opca panels from the time lines
			foreach (Control cont in this.RichTextList)
			{
				for (int x=0;x<this.document[docNumber].numOfPanelsInSession;x++)
				{
					this.timeLinePanel[x].Controls.Remove(cont);
				}
			}
			//clear the array list
			this.RichTextList.Clear();

			for (int discCounter=0;discCounter<this.document[docNumber].RichTextList.Count;discCounter++)
			{
				RichTextAboveTimeLine richTextBox= (RichTextAboveTimeLine)this.document[docNumber].RichTextList[discCounter];
				int startPanelNumber=richTextBox.startPoint/this.document[docNumber].numOfButtonsInTimeLine;
				Size ButtonsSize=calculateButtonsSize(timeLinePanel[0]);
				
				RichTextBox rich = new RichTextBox();				
				rich.Rtf= richTextBox.RTF;
				rich.Tag=richTextBox.startPoint;
				rich.Multiline = false;
				rich.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseUp);
                rich.BorderStyle = BorderStyle.None;
                rich.BackColor = Color.WhiteSmoke;
				rich.ReadOnly=true;
				rich.Location = calculateDiscPanelLocation(0, richTextBox.startPoint);
                rich.Location =new Point(rich.Location.X ,0);
				rich.Size =new Size(richTextBox.Text.Length*7, 15/*richTextBox.richTextBox.Size.Height*/); 
				sessionToolTip.SetToolTip(rich,richTextBox.AdditionalText);
				this.timeLinePanel[richTextBox.startPoint/ this.document[docNumber].numOfButtonsInTimeLine].Controls.Add(rich);
				this.RichTextList.Add(rich);
			}
			

		}
		private void richTextBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			RichTextBox richTextBox=(RichTextBox)sender;
			int index=this.checkRichTextIndication((int) richTextBox.Tag,0);
			if (index<0) return;
			if (this.RemoveRichText)
			{
				this.document[docNumber].RichTextList.RemoveAt(index);
				refreshRichTextBoxes();
			}
			else if (RichText)
			{
				
				RichTextAboveTimeLine rich=(RichTextAboveTimeLine)	this.document[docNumber].RichTextList[index];
				RichText richTextDialog = new RichText();
				richTextDialog.MainTextUpdate = rich.Text;
				richTextDialog.RTF=rich.RTF;
				richTextDialog.AdditionalText = rich.AdditionalText;
				if (richTextDialog .ShowDialog() == DialogResult.OK)
				{
					rich.Text=richTextDialog.MainTextUpdate;
					rich.RTF=richTextDialog.RTF;
					rich.AdditionalText = richTextDialog.AdditionalText;
					refreshRichTextBoxes();
				}
				else return;
				
			}
			
		
		}
		public void refreshDiscPanels()
		{
			//first  the opca panels from the time lines
			foreach (Control cont in DiscArrayList)
			{
				for (int x=0;x<this.document[docNumber].numOfPanelsInSession;x++)
				{
					this.timeLinePanel[x].Controls.Remove(cont);
				}
			}
			//clear the array list
			DiscArrayList.Clear();
			
			
			for (int discCounter=0;discCounter<this.document[docNumber].DiscList.Count;discCounter++)
			{
				Disc disc= (Disc)this.document[docNumber].DiscList[discCounter];
				int startPanelNumber=disc.startPoint/this.document[docNumber].numOfButtonsInTimeLine;
				int endPanelNumber=disc.endPoint/this.document[docNumber].numOfButtonsInTimeLine;
						
				Size ButtonsSize=calculateButtonsSize(timeLinePanel[0]);
				APanel discPanel = new APanel();
				discPanel.BackColor=disc.color;
									
				discPanel.Location = calculateSilencePanelLocation/* calculateDiscPanelLocation*/(0, disc.startPoint);
                //ddd
				//discPanel.Size = calculateDiscPanelSize(disc.endPoint-disc.startPoint);
                discPanel.Size = calculateSilencePanelSize(0, disc.startPoint, 2, this.document[docNumber].numOfPatiants);
				this.timeLinePanel[disc.startPoint/ this.document[docNumber].numOfButtonsInTimeLine].Controls.Add(discPanel);
				discPanel.BringToFront();
				Label title=new Label();
				title.Location=new Point(0,2);
				title.Size=new Size (discPanel.Size.Width,title.Font.Height);
				title.BorderStyle = BorderStyle.FixedSingle;
				title.Text="T: "+disc.title;
				title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				//discPanel.Controls.Add(title);
				//					g.DrawString("Title: "+disc.title,new Font("Ariel",12),Brushes.Black,10,10);
				Label performance=new Label();
				performance.Location=new Point(0,title.Font.Height+2+2);
				performance.Size=new Size (discPanel.Size.Width,performance.Font.Height);
				performance.BorderStyle = BorderStyle.FixedSingle;
				performance.Text="P: "+disc.performance;
				performance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				//discPanel.Controls.Add(performance);

                string temp = "T: " + disc.title + "P: " + disc.performance;
                sessionToolTip.SetToolTip(discPanel, temp);
				//aaa
                
                PictureBox discPicture=new PictureBox();
				Bitmap  image1 = new Bitmap(((MainForm)this.MdiParent).MainDirectory+"\\add.disk.64x64.ico");
				discPicture.SizeMode  = PictureBoxSizeMode.StretchImage;
				discPicture.Image= image1;
				discPicture.Size = new Size(40,40);
				discPicture.Location = new Point(/*x*/((discPanel.Size.Width-discPicture.Size.Width)/2),
												/*y*/(discPanel.Size.Height-discPicture.Size.Height) /*-title.Size.Height-performance.Size.Height)*//2/*+(title.Size.Height+performance.Size.Height)*/); 
				discPanel.Controls.Add(discPicture);
				discPanel.panelNumber=disc.startPoint;
				discPanel.Click += new System.EventHandler(discPanelClick);
				this.DiscArrayList.Add(discPanel);
				for (int x=disc.startPoint;x<=disc.endPoint;x++)
				{
					for (int y=0;y<this.document[docNumber].numOfPatiants;y++)
					{
						this.ButtonArray[y,x].BackColor = document[docNumber].timeLine[y].MinutesArray[x].buttonBackColor;//Color.Blue;
						this.ButtonArray[y,x].ForeColor = document[docNumber].timeLine[y].MinutesArray[x].buttonBackColor;//Color.GreenYellow;
						this.EndInstrumentSectionButtonArray[y,disc.endPoint].BackColor=document[docNumber].timeLine[y].MinutesArray[x].buttonBackColor;
						this.EndInstrumentSectionButtonArray[y,disc.endPoint].ForeColor=document[docNumber].timeLine[y].MinutesArray[x].buttonBackColor;
						this.EndInstrumentSectionButtonArray[y,disc.endPoint].Show();

					}
				}
			}

		}
		
		public void refreshBottons()
		{//
			int numOfButtonsInRow=getNumOfButtonsInRow();
			for ( int panelCounter  = 0;panelCounter <document[docNumber].numOfPanelsInSession;panelCounter++)
			{
				
				int x = 0, y = 0;
				for (x = 0; x < document[docNumber].numOfPatiants; x++)
				{
					for (y = 0; y < numOfButtonsInRow; y++)
					{
						int yy=y+numOfButtonsInRow*panelCounter;
						//ButtonArray[x, yy].BackColor=this.document[docNumber].timeLine[x].MinutesArray[y].buttonBackColor;
						ButtonArray[x, yy].Refresh();
					}
				}
			}
			
		}
        
        private void MusicNotePanelClick(object sender, System.EventArgs e)
		{
            //ALable silencePanel = (ALable)sender;
            ALable musicNotePanel = (ALable)sender;
            int index = musicNotePanel.LableNumber;
            
            if (RemoveMusicNotes)
            {
                int found = 0;
                for (int x = 0; x < this.document[docNumber].MusicNotesList.Count; x++)
                {
                    MusicNotes note = (MusicNotes)this.document[docNumber].MusicNotesList[x];
                    if (note.startPoint == index)
                        found = x;
                }

                this.document[docNumber].MusicNotesList.RemoveAt(found);
                refreshMusicNotes();
            }
            else if (AddMusicNotes)
            {
                int found = 0;
                for (int x = 0; x < this.document[docNumber].MusicNotesList.Count; x++)
                {
                    MusicNotes sil = (MusicNotes)this.document[docNumber].MusicNotesList[x];
                    if (sil.startPoint == index)
                        found = x;
                }
                MusicNotes musicNotes = (MusicNotes)this.document[docNumber].MusicNotesList[found];
                Finale finaleDialog = new Finale();
                finaleDialog.parentForm = this;
                finaleDialog.initStafLineArray(finaleDialog.sketchPanel);
                finaleDialog.drawStaf(finaleDialog.sketchPanel);
                finaleDialog.NotePictureFileName = musicNotes.NotesPictureFileName;
               
                if (finaleDialog.ShowDialog() == DialogResult.OK)
                {
                    musicNotes.NotesList = finaleDialog.notesArrayList;
                    musicNotes.tempo = finaleDialog.Tempo;
                    musicNotes.NotesPictureFileName = finaleDialog.NotePictureFileName;
                    refreshMusicNotes();
                }
              
            }
            else if (this.AddArrow)
            {
                // if it is the second click for the end section 
                if (isWaitingForArrowEndClick)
                {

                    Arrow arrow = new Arrow(Color.Black, new Point(startArrowPosition.X, startArrowPosition.Y), new Point(0,musicNotePanel.LableNumber), 2);
                    //choose color
                    ColorDialog colorDialog = new ColorDialog();
                    colorDialog.AllowFullOpen = true;
                    colorDialog.AnyColor = true;
                    colorDialog.SolidColorOnly = false;
                    colorDialog.ShowHelp = true;

                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        arrow.color = colorDialog.Color;
                    }
                    if (startArroFromButton)
                        arrow.arrowType = 2;
                    else
                        arrow.arrowType = 5;
                    this.document[docNumber].timeLine[startArrowPosition.X].MinutesArray[startArrowPosition.Y].arrowList.Add(arrow);
                    //restart the flag
                    isWaitingForArrowEndClick = false;
                    refreshArrows();
                    this.Cursor = Cursors.Arrow;
                }
                else
                {
                    //Cursor.Current = new Cursor((((MainForm)(this.MdiParent)).MainDirectory) + "\\secondklick1.ico");
                    //this.Cursor = Cursor.Current;
                    ////keep the point for the next click to calculate the time interval between the start and the end
                    //startArrowPosition = new Point(pic.y, pic.x);
                    //startArroFromButton = false;
                    ////update the flag to indicate that the next click should be the end section point button
                    //isWaitingForArrowEndClick = true;
                }
            }
                
        }
        private void SilencePanelClick(object sender, System.EventArgs e)
		{
			ALable silencePanel=(ALable)sender;
            int index = silencePanel.LableNumber;
			//int index=this.checkDiscIndication( discPanel.panelNumber,0);
			if (RemoveSilence)
			{
                int found=0;
                for (int x = 0; x < this.document[docNumber].SilencePanelList.Count; x++)
                {
                    SilencePanel sil = (SilencePanel)this.document[docNumber].SilencePanelList[x];
                    if (sil.startPoint == index)
                        found = x;
                }

				this.document[docNumber].SilencePanelList.RemoveAt(found);
				refreshSilencePanels();
			}
			else if (AddSilence)
			{
                int found = 0;
                for (int x = 0; x < this.document[docNumber].SilencePanelList.Count; x++)
                {
                    SilencePanel sil = (SilencePanel)this.document[docNumber].SilencePanelList[x];
                    if (sil.startPoint == index)
                        found = x;
                }

                SilencePanel silence = (SilencePanel)this.document[docNumber].SilencePanelList[found];
                //Disc disc=(Disc)	this.document[docNumber].DiscList[index];
				//DiscAttributes discDialog = new DiscAttributes();
				//discDialog.setTitle(disc.title);
                
				//discDialog.setPerformance(disc.performance);
                SilenceAttributes silenceDialogBox = new SilenceAttributes();
                silenceDialogBox.SilenceTime = silence.TimeOfSilence;
                silenceDialogBox.SilenceColor = silence.color;
                if (silenceDialogBox.ShowDialog() == DialogResult.OK)
                {
                    //silence.startPoint = startSilencePanelSection.Y;
                    //silence.endPoint = b.x;
                    silence.color = silenceDialogBox.SilenceColor;
                    //isWaitingForSilencePanelEnsdSectionClick = false;
                    silence.TimeOfSilence = silenceDialogBox.SilenceTime;
                    //this.document[docNumber].SilencePanelList.Add(silence);
                    //this.Cursor = Cursors.Arrow;
                    refreshSilencePanels();
                }
				//if (discDialog .ShowDialog() == DialogResult.OK)
			//	{
			//		disc.color = discDialog.SingColor ;
			//		disc.title = discDialog.Title;
			//		disc.performance = discDialog.performance;
			//		disc.additionlInfo = discDialog.AdditionalInfo;
			//		refreshDiscPanels();
			//	}
				else return;
			}
			
		}
		private void discPanelClick(object sender, System.EventArgs e)
		{
			APanel discPanel=(APanel)sender;
			int index=this.checkDiscIndication( discPanel.panelNumber,0);
			if (RemoveDisc)
			{
				Disc disc= (Disc)this.document[docNumber].DiscList[index];
				for (int x=disc.startPoint;x<=disc.endPoint;x++)
				{
					for (int y=0;y<this.document[docNumber].numOfPatiants;y++)
					{
						document[docNumber].timeLine[y].MinutesArray[x].buttonBackColor=Color.Black;
						this.ButtonArray[y,x].BackColor=document[docNumber].timeLine[y].MinutesArray[x].buttonBackColor;
						this.ButtonArray[y,x].ForeColor=document[docNumber].timeLine[y].MinutesArray[x].buttonBackColor;
						this.EndInstrumentSectionButtonArray[y,disc.endPoint].BackColor=this.document[docNumber].EndInstrumentButtonColor;
						this.EndInstrumentSectionButtonArray[y,disc.endPoint].ForeColor=this.document[docNumber].EndInstrumentButtonColor;
						this.EndInstrumentSectionButtonArray[y,disc.endPoint].Hide();

					}
				}
				
				this.document[docNumber].DiscList.RemoveAt(index);
				refreshDiscPanels();
			}
			else if (AddDisc)
			{
				Disc disc=(Disc)	this.document[docNumber].DiscList[index];
				DiscAttributes discDialog = new DiscAttributes();
				discDialog.setTitle(disc.title);
				discDialog.setPerformance(disc.performance);
				if (discDialog .ShowDialog() == DialogResult.OK)
				{
					disc.color = discDialog.SingColor ;
					disc.title = discDialog.Title;
					disc.performance = discDialog.performance;
					//disc.additionlInfo = discDialog.AdditionalInfo;
					refreshDiscPanels();
				}
				else return;
			}
			
		}
		//---------------------------------------------------------------------
		private int FindStartPointOfInstrument(int patiant,int minute, InstrumentInfo instrumentInfo/*string category, string subCategory, string instrumetnName*/)
		{
			int minuteCounter;
			for (minuteCounter=minute;minuteCounter>0;minuteCounter--)
			{
				if (this.document[docNumber].timeLine[patiant].MinutesArray[minuteCounter].instrumetnInfo!=instrumentInfo)
					break;
			}
			return minuteCounter+1;
		}
		//---------------------------------------------------------------------------
		private int FindEndPointOfInstrument(int patiant,int minute, InstrumentInfo instrumentInfo)
		{
			int minuteCounter;
			for (minuteCounter=minute;minuteCounter<this.document[docNumber].sessionDuration*2 /*numOfButtonsInTimeLine*2*/;minuteCounter++)
			{
				if (this.document[docNumber].timeLine[patiant].MinutesArray[minuteCounter].instrumetnInfo!=instrumentInfo)
					break;
			}
			return minuteCounter-1;
		}
		//-----------------------------------------------------------
		public void refreshInstrumentIndicationInTimeLine()
		{
			for (int patiantCounter=0;patiantCounter<document[docNumber].numOfPatiants;patiantCounter++)
			{
				for (int buttonCounter=0;buttonCounter<document[docNumber].sessionDuration*2;buttonCounter++)
				{	
					int panelNumber = buttonCounter/document[docNumber].numOfButtonsInTimeLine ;
					if(document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].levelOfInstrumentIntensity==0)
					{
						this.ButtonArray[patiantCounter,buttonCounter].BackColor = document[docNumber].sessionColor.PanelColor;
						this.ButtonArray[patiantCounter,buttonCounter].ForeColor = document[docNumber].sessionColor.PanelColor;
					}
					else
					{
					
						this.ButtonArray[patiantCounter,buttonCounter].BackColor = document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].buttonBackColor;//Color.Blue;
						this.ButtonArray[patiantCounter,buttonCounter].ForeColor = document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].buttonBackColor;//Color.Blue;
					}
					if(document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].levelOfInstrumentIntensity==0)
						this.ButtonArray[patiantCounter,buttonCounter].Size = new Size(ButtonArray[patiantCounter,buttonCounter].Size.Width,2);
					else	
						this.ButtonArray[patiantCounter,buttonCounter].Size = new Size(ButtonArray[patiantCounter,buttonCounter].Size.Width,document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].levelOfInstrumentIntensity);
					this.ButtonArray[patiantCounter,buttonCounter].Location = calculateButtonLocation(patiantCounter,buttonCounter);
					this.ButtonArray[patiantCounter,buttonCounter].Invalidate();
					
					if (document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].instrumentEndHere)
					{
						EndInstrumentSectionButtonArray[patiantCounter,buttonCounter].Show();		
					}
					if (document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].instrumentStartHere)
					{
						string fileName = ((MainForm) (this.MdiParent)).MainDirectory+ "\\pictures\\instruments\\" +document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].instrumetnInfo.Category + "\\" +document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].instrumetnInfo.SubCategory+"\\"+document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].instrumetnInfo.Name;
						InstrumentPictureArray[patiantCounter,buttonCounter].Image = new Bitmap(fileName);
						InstrumentPictureArray[patiantCounter,buttonCounter].Show();	
					}
				}
			}
		}
		//-----------------------------------------------------------------------
		public void deleteTextTopicsFromButtons(string topicAndSubTopic)
		{
			for (int x=0;x<this.document[docNumber].numOfPatiants;x++)
			{
				for (int y=0;y<this.document[docNumber].sessionDuration*2;y++)
				{
					if (this.document[docNumber].timeLine[x].MinutesArray[y].topicAndSubTopic==topicAndSubTopic)
					{
						this.document[docNumber].timeLine[x].MinutesArray[y].topicAndSubTopic="";
                        this.refreshTopicLables();
                        //this.LableArray[x,y].Text="";
						//this.LableArray[x,y].BackColor=Color.White;
					}
					
				}
			}
		}
		//-------------------------------------------
		private int setColumnSize()
		{
			return this.TextPanel.Size.Width/document[docNumber].numOfTextBoxInColumn;
		}
		//-----------------------------------------------
		private int setLineSize()
		{
			int x = (this.TextPanel.Size.Height/ document[docNumber].numOfTextBoxInColumn)-1;
			return x;
		}
		//---------------------------------------------------
		public void initTextBoxesInTextPanel()
		{		
			int columWidth=setColumnSize();
			int lineHeight=setLineSize();
            TextPanel.Controls.Clear();
			for (int x=0;x<document[docNumber].numOfTextBoxInColumn;x++)
			{
				for (int y=0;y<document[docNumber].numOfTextBoxColumns ;y++)
				{
					TextBoxArray[x, y] = new TextBox();
					TextBoxArray[x, y].Location = new System.Drawing.Point(x*columWidth , y*lineHeight);
					TextBoxArray[x, y].Size = new System.Drawing.Size(columWidth, lineHeight);
					TextBoxArray[x, y].BackColor = Color.White;// this.document[docNumber].timeLine[x].TextColor;
					TextBoxArray[x, y].ReadOnly= true;
					TextBoxArray[x, y].BorderStyle= BorderStyle.None;
					TextPanel.Controls.Add(TextBoxArray[x,y]);
				}
			}
            this.AddTextToTextPanel();
		}
		//----------------------------------------------------
        //public void refreshTopicLablesOnButtons()
        //{
        //    for (int x=0;x<document[docNumber].numOfPatiants;x++)
        //    {
        //        for (int y=0;y<(document[docNumber].sessionDuration*2);y++)
        //        {
        //            LableArray[x,y].Text=document[docNumber].timeLine[x].MinutesArray[y].topicAndSubTopic;
        //            if (LableArray[x,y].Text!= "")
        //                LableArray[x,y].Show();
        //            else
        //                LableArray[x,y].Hide();
        //        }
        //    }

        //}
		//--------------------------------------------------------
		public void AddTextToTextPanel()//refressh the text panel
		{
			int counter=0;
			for (int x=0;x<document[docNumber].numOfTextBoxInColumn;x++)
			{
				for (int y=0;y<document[docNumber].numOfTextBoxColumns ;y++)
				{
					//if (this.document[docNumber].listText.Count.Equals(counter))
					//	break;
					if (this.document[docNumber].listText.Count>counter)
					{
						TextTalkedinSession textBoxInfo= (TextTalkedinSession) (this.document[docNumber].listText[counter]);
						string temp= textBoxInfo.topic + " " + textBoxInfo.subTopic+ " " + textBoxInfo.shortText;
						TextBoxArray[x, y].Text=temp;		
						sessionToolTip.SetToolTip(TextBoxArray[x, y],textBoxInfo.longText);
						counter++;
					}
					else
					{
					TextBoxArray[x, y].Text="";
					}
				}
			}
		}	
		//--------------------------------------------------------
		private int setImeLineSectionHeight()
		{
			return this.mainPanel.Size.Height;//(int)(this.Size.Height*document[docNumber].proportionOfPanelArearAndTextArea/*3/4*/);
		}
		//----------------------------------
		private int setTimeLineSectionWidth()
		{
			return this.mainPanel.Size.Width;
		}
		//-----------------------------------
		private Point setTimeLinePanelLocation(int panelNumber)
		{
			//The size of the section of the window for the time lines
			int timeLineSectionHeight=setImeLineSectionHeight();
			int timeLineSectionWidth=setTimeLineSectionWidth();
            int numOfPanels=document[docNumber].numOfPanelsInSession;
            int percentageOfPanels = 95;
			//The 
			int timeLineHeight=timeLineSectionHeight/document[docNumber].numOfPatiants;
			int x,y;
			if (document[docNumber].numOfPatiants>this.MaxNumOfPatiantsBeforeSplitingTimePanel)//amit num of patiants here
			{
				y= ((timeLineSectionHeight - (document[docNumber].percentOfPanelAreaOfHoleWindow*timeLineSectionHeight/100)));
			}
			else
			{
                y = ((timeLineSectionHeight - (percentageOfPanels * timeLineSectionHeight * numOfPanels / 100 / numOfPanels)) / (numOfPanels + 1)) * panelNumber +
                    ((percentageOfPanels * timeLineSectionHeight / 100 / numOfPanels) * (panelNumber - 1));
			}
			x= timeLineSectionWidth*(100-document[docNumber].percentOfPanelAreaOfHoleWindow)/2/100;
			return new Point(x,y);
		
		}
		//---------------------------------------------------------
		private Size setTimeLinePanelSize(int panelNumber)
		{
			int timeLineSectionHeight=setImeLineSectionHeight();
			int timeLineSectionWidth=setTimeLineSectionWidth();
            int numOfPanels = document[docNumber].numOfPanelsInSession;
            int percentageOfPanels = 95;
			int x,y;
			if (document[docNumber].numOfPatiants>this.MaxNumOfPatiantsBeforeSplitingTimePanel)
			{
				x=(document[docNumber].percentOfPanelAreaOfHoleWindow * timeLineSectionWidth /100);
                y = (percentageOfPanels * timeLineSectionHeight / 100);
			}
			else
			{
				x=(document[docNumber].percentOfPanelAreaOfHoleWindow * timeLineSectionWidth /100);
                y = (percentageOfPanels * timeLineSectionHeight / 100 / numOfPanels);
			}
			return new Size(x,y);
		}
		private APanel setTimeLinePanel(int panelNumber)
		{
			APanel TimeLinePanel = new APanel();
			TimeLinePanel.Parent= this.mainPanel;	
			TimeLinePanel.Location = setTimeLinePanelLocation(panelNumber);
			TimeLinePanel.Size = setTimeLinePanelSize(panelNumber); 
			TimeLinePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			TimeLinePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TimeLinePanel_Paint);
			TimeLinePanel.BackColor=this.document[docNumber].sessionColor.PanelColor;//Color.Brown;
			TimeLinePanel.MouseDown +=new System.Windows.Forms.MouseEventHandler(this.Painter_MouseDown );
			TimeLinePanel.MouseUp +=new System.Windows.Forms.MouseEventHandler(this.Painter_MouseUp );
			TimeLinePanel.MouseMove +=new System.Windows.Forms.MouseEventHandler(this.Painter_MouseMove );
			TimeLinePanel.panelNumber=panelNumber;
			bitmapArray[panelNumber-1] = new Bitmap(TimeLinePanel.Size.Width,TimeLinePanel.Size.Height);
			
			return TimeLinePanel; 
		}
		private Point calculateButtonsStartLocation(Panel atimeLinePanel, int timeLineNum)
		{
			Point buttonStartLocation=new Point();
			buttonStartLocation.X=atimeLinePanel.Size.Width*document[docNumber].percentOfSpaceBeforeButtonsInTimeLine/100;//amit
			
			buttonStartLocation.Y= ((atimeLinePanel.Size.Height-(document[docNumber].numOfPatiants*document[docNumber].widthOfTimeLineButton))/(document[docNumber].numOfPatiants+1) * (timeLineNum+1)) +(document[docNumber].widthOfTimeLineButton*((timeLineNum+1)-1)); 
			return buttonStartLocation;
		}
		private Point calculateSingScreamLoaction(int buttonCounter, int patiantNumber, int Height)
		{
			//Point StartLocation=new Point(0,0);
			int panelCounter = buttonCounter/document[docNumber].numOfButtonsInTimeLine;
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[panelCounter]);
			Point StartLocation=calculateButtonsStartLocation(timeLinePanel[panelCounter],patiantNumber);
			return new System.Drawing.Point((StartLocation.X + ((buttonCounter-panelCounter*document[docNumber].numOfButtonsInTimeLine) * ButtonsSize.Width)), StartLocation.Y-Height/2);
		}
		private Size calculateButtonsSize(Panel timeLinePanel)
		{
			Size buttonStartSize=new Size();
			buttonStartSize.Width=timeLinePanel.Size.Width/document[docNumber].numOfButtonsInTimeLine*(100-document[docNumber].percentOfSpaceBeforeButtonsInTimeLine)/100;
			buttonStartSize.Height=document[docNumber].widthOfTimeLineButton;
			return buttonStartSize;
		}
		private Size calculateSingScreamSize(int numberOfButtons, int Height)
		{
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[0]);
			return new Size(ButtonsSize.Width*numberOfButtons,Height);
		}
		private Size calculateButtonsSize(Panel timeLinePanel,int patiantCounter,int buttonCounter)
		{
			Size buttonStartSize=new Size();
			buttonStartSize.Width=timeLinePanel.Size.Width/document[docNumber].numOfButtonsInTimeLine*(100-document[docNumber].percentOfSpaceBeforeButtonsInTimeLine)/100;
			buttonStartSize.Height=document[docNumber].timeLine[patiantCounter].MinutesArray[buttonCounter].levelOfInstrumentIntensity;//document[docNumber].widthOfTimeLineButton;
			return buttonStartSize;
		}
		private Size calculateLablesSize(Panel timeLinePanel)
		{
			Size lableSize=new Size();
			if (document[docNumber].numOfButtonsInTimeLine>15 && document[docNumber].numOfButtonsInTimeLine<=20 )
			{
				lableSize.Width=timeLinePanel.Size.Width/document[docNumber].numOfButtonsInTimeLine*90/100*2/3;//  2/3 size of the button	
			}
			else if (document[docNumber].numOfButtonsInTimeLine>20)
			{
				lableSize.Width=timeLinePanel.Size.Width/document[docNumber].numOfButtonsInTimeLine*90/100*96/100;
			}
			else
			{
				lableSize.Width=timeLinePanel.Size.Width/document[docNumber].numOfButtonsInTimeLine*90/100/2;//  half size of the button	
			}
			document[docNumber].widthOfLable=lableSize.Width;
			lableSize.Height=document[docNumber].heightOfLable;
			return lableSize;
		}
		private Size calculateInstrumentPictureSize(Panel timeLinePanel)
		{
			Size lableSize=new Size();
            Size button = this.calculateButtonsSize(timeLinePanel);

            //aaaa
            if (this.MaxNumOfPatiantsBeforeSplitingTimePanel < document[docNumber].numOfPatiants)
            {
                if (document[docNumber].numOfButtonsInTimeLine > 30 && document[docNumber].numOfButtonsInTimeLine <= 40)
                {
                    //lableSize.Width = button.Width;
                    //lableSize.Height = (int)((float)button.Width * 0.714);
                    lableSize.Height = timeLinePanel.Size.Height / (document[docNumber].numOfPatiants + 1) * 90 / 100;
                    lableSize.Width = (int)((double)lableSize.Height * 1.4);
                }
                else if (document[docNumber].numOfButtonsInTimeLine > 40)
                {

                    //lableSize.Width = button.Width;
                    //lableSize.Height = (int)((float)button.Width * 0.714);
                    
                    lableSize.Height = timeLinePanel.Size.Height / (document[docNumber].numOfPatiants + 1) * 90 / 100;
                    lableSize.Width = (int)((double)lableSize.Height * 1.4);
                }
                else
                {
                    

                    //lableSize.Width = button.Width;
                   // lableSize.Height =(int) ((float)button.Width * 0.714);
                    lableSize.Height = timeLinePanel.Size.Height / (document[docNumber].numOfPatiants + 1) * 45 / 100;
                    lableSize.Width = (int)((double)lableSize.Height * 1.4);
                }

            }
            else
            {
                if (document[docNumber].numOfButtonsInTimeLine > 30 && document[docNumber].numOfButtonsInTimeLine <= 40)
                {
                    //lableSize.Width=timeLinePanel.Size.Width/document[docNumber].numOfButtonsInTimeLine*90/100*2;//  2/3 size of the button	
                    lableSize.Height = timeLinePanel.Size.Height / (document[docNumber].numOfPatiants + 1) * 90 / 100;
                    lableSize.Width = (int)((double)lableSize.Height * 1.4);
                }
                else if (document[docNumber].numOfButtonsInTimeLine > 40)
                {
                    //lableSize.Width=timeLinePanel.Size.Width/document[docNumber].numOfButtonsInTimeLine*90/100*2;
                    lableSize.Height = timeLinePanel.Size.Height / (document[docNumber].numOfPatiants + 1) * 90 / 100;
                    lableSize.Width = (int)((double)lableSize.Height * 1.4);
                }
                else
                {
                  
                   lableSize.Height = timeLinePanel.Size.Height / (document[docNumber].numOfPatiants + 1) * 90 / 100;
                    lableSize.Width = (int)((double)lableSize.Height * 1.4);
                   // lableSize.Width = button.Width;
                   // lableSize.Height = (int)((float)button.Width * 0.714);
                }
            }
			//lableSize.Height=document[docNumber].heightOfLable;
			return lableSize;
		}
		private Point calculateNameButonLocation(Panel atimeLinePanel, int timeLineNum)
				   {
					   Point nameButtoLication= new Point();
					   int xx=2;
					   int ButtonLineHeight=atimeLinePanel.Size.Height/document[docNumber].numOfPatiants;
					   int yy=ButtonLineHeight*30/100-2+ButtonLineHeight*timeLineNum;
						yy=((atimeLinePanel.Size.Height-(document[docNumber].numOfPatiants*document[docNumber].widthOfTimeLineButton))/(document[docNumber].numOfPatiants+1) * (timeLineNum+1)) +(document[docNumber].widthOfTimeLineButton*((timeLineNum+1)-1)- document[docNumber].nameButtonHeight/2); 
						nameButtoLication.X=xx;
					   nameButtoLication.Y=yy;
					   return nameButtoLication;
				   }
		private Point calculateNameButtonSize(Panel atimeLinePanel)
		{
			Point nameButtonSize= new Point();
			int xx= atimeLinePanel.Size.Width*document[docNumber].percentOfSpaceBeforeButtonsInTimeLine/100*document[docNumber].percentOfSizeOfNameButtonOfSizeOfSpaceBeforeButtonInTimeLine/100;//4/100;
			int yy;
			if (document[docNumber].numOfPatiants > this.MaxNumOfPatiantsBeforeSplitingTimePanel)
				yy = document[docNumber].nameButtonHeight-2;
			else
				yy = document[docNumber].nameButtonHeight;
			nameButtonSize.X=xx;
			nameButtonSize.Y=yy;
			return nameButtonSize;
		}
		private Point calculateCurlyBracesLocation(Panel timeLinePanel)
		{
			Point CurlyBracesLication= new Point();
			//int xx=2;
			int ButtonLineHeight=timeLinePanel.Size.Height/document[docNumber].numOfPatiants;
			//int yy=ButtonLineHeight*30/100-2+ButtonLineHeight*0;
			CurlyBracesLication.X=timeLinePanel.Size.Width*document[docNumber].percentOfSpaceBeforeButtonsInTimeLine/100*(document[docNumber].percentOfSizeOfNameButtonOfSizeOfSpaceBeforeButtonInTimeLine+document[docNumber].percentOfSizeOfSpaceBetweenNameButtonsAndCurlyBraces)/100;
			CurlyBracesLication.Y= ((timeLinePanel.Size.Height-(document[docNumber].numOfPatiants*document[docNumber].widthOfTimeLineButton))/(document[docNumber].numOfPatiants+1)) -3/*+(document[docNumber].widthOfTimeLineButton)*/; 
			return CurlyBracesLication;
		}
		private Size calculateCurlyBracesSize(Panel timeLinePanel)
		{
			Size buttonStartSize=new Size();
			buttonStartSize.Width=timeLinePanel.Size.Width*document[docNumber].percentOfSpaceBeforeButtonsInTimeLine/100*(100-document[docNumber].percentOfSizeOfNameButtonOfSizeOfSpaceBeforeButtonInTimeLine-document[docNumber].percentOfSizeOfSpaceBetweenNameButtonsAndCurlyBraces)/100+5;
			buttonStartSize.Height=((timeLinePanel.Size.Height-(document[docNumber].numOfPatiants*document[docNumber].widthOfTimeLineButton))/(document[docNumber].numOfPatiants+1) * (document[docNumber].numOfPatiants-1)) +(document[docNumber].widthOfTimeLineButton*(document[docNumber].numOfPatiants)+5); 
				//((timeLinePanel.Size.Height-(document[docNumber].numOfPatiants*document[docNumber].widthOfTimeLineButton))/(document[docNumber].numOfPatiants+1) * (document[docNumber].numOfPatiants))+(document[docNumber].widthOfTimeLineButton* document[docNumber].numOfPatiants ); 
            return  buttonStartSize;
		}
		public void drawNamesButtons(/*Panel timeLinePanel*/)
		{
			Point location=new Point();
			Point size=new Point();
			
			for (int panelCounter = 0 ;panelCounter<document[docNumber].numOfPanelsInSession;panelCounter++)
			{
				size= calculateNameButtonSize(timeLinePanel[panelCounter]);
				for (int patiantCounter=0;patiantCounter<document[docNumber].numOfPatiants;patiantCounter++)
				{
					
					NameButtonArray[panelCounter,patiantCounter] = new ALable();
					location=calculateNameButonLocation(timeLinePanel[panelCounter],patiantCounter);
					NameButtonArray[panelCounter,patiantCounter].Font=new System.Drawing.Font("Ariel",12);
					NameButtonArray[panelCounter,patiantCounter].TextAlign=ContentAlignment.MiddleLeft;
					NameButtonArray[panelCounter,patiantCounter].Text=document[docNumber].timeLine[patiantCounter].PatiantName;
					NameButtonArray[panelCounter,patiantCounter].FlatStyle= FlatStyle.Flat;
					
					NameButtonArray[panelCounter,patiantCounter].Location =location;
					NameButtonArray[panelCounter,patiantCounter].Size= new Size(size.X,size.Y);
					NameButtonArray[panelCounter,patiantCounter].Click += new System.EventHandler(NameButtonClick);
					NameButtonArray[panelCounter,patiantCounter].x=panelCounter;
					NameButtonArray[panelCounter,patiantCounter].y=patiantCounter;
					timeLinePanel[panelCounter].Controls.Add(NameButtonArray[panelCounter,patiantCounter]);	
					sessionToolTip.SetToolTip(NameButtonArray[panelCounter,patiantCounter], this.document[docNumber].timeLine[patiantCounter].additionalInfoAboutPatiant);				
				}
			}
		}
		private int getNumOfButtonsInRow()
		{
			return document[docNumber].sessionDuration/document[docNumber].numOfPanelsInSession*2 ;
		}
		private Point calculateButtonLocation(int panelCounter, int patiantNumber, int buttonCounter)
		{
			//Point StartLocation=new Point(0,0);
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[panelCounter]);
			Point StartLocation=calculateButtonsStartLocation(timeLinePanel[panelCounter],patiantNumber);
			int level=document[docNumber].timeLine[patiantNumber].MinutesArray[buttonCounter+(document[docNumber].numOfButtonsInTimeLine*panelCounter)].levelOfInstrumentIntensity;
			if (document[docNumber].timeLine[patiantNumber].MinutesArray[buttonCounter+(document[docNumber].numOfButtonsInTimeLine*panelCounter)].levelOfInstrumentIntensity==0)
				level=2;
			return new System.Drawing.Point((StartLocation.X + (buttonCounter * ButtonsSize.Width)), StartLocation.Y - level/2);
		}
		private Point calculateButtonLocation(int patiantNumber, int buttonCounter)
		{
			//Point StartLocation=new Point(0,0);
			int panelCounter = buttonCounter/document[docNumber].numOfButtonsInTimeLine;
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[panelCounter]);
			Point StartLocation=calculateButtonsStartLocation(timeLinePanel[panelCounter],patiantNumber);
			int level=document[docNumber].timeLine[patiantNumber].MinutesArray[buttonCounter].levelOfInstrumentIntensity;
			if (document[docNumber].timeLine[patiantNumber].MinutesArray[buttonCounter].levelOfInstrumentIntensity==0)
				level=2;
			return new System.Drawing.Point((StartLocation.X + ((buttonCounter-panelCounter*document[docNumber].numOfButtonsInTimeLine) * ButtonsSize.Width)), StartLocation.Y - level/2);
		}
		private Point calculateVideoPanelLocation()
		{
			int panelCounter = 0;//buttonCounter/document[docNumber].numOfButtonsInTimeLine;
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[panelCounter]);
			Point StartLocation=calculateButtonsStartLocation(timeLinePanel[panelCounter],this.document[docNumber].numOfPatiants-1/*patiantNumber*/);
			return new System.Drawing.Point(StartLocation.X , StartLocation.Y+3);
		}
		private Size calculateVideoPanelSize()
		{
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[0 ]);

			return new Size(ButtonsSize.Width*this.document[docNumber].numOfButtonsInTimeLine,6);
		}
		private Point calculateOpacPanelLocation(int patiantNumber, int buttonCounter)
		{
		
			int panelCounter = buttonCounter/document[docNumber].numOfButtonsInTimeLine;
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[panelCounter]);
			Point StartLocation=calculateButtonsStartLocation(timeLinePanel[panelCounter],patiantNumber);
			return new System.Drawing.Point(/*x*/(StartLocation.X + ((buttonCounter-panelCounter*document[docNumber].numOfButtonsInTimeLine) * ButtonsSize.Width)),
											/*y*/	StartLocation.Y - (timeLinePanel[panelCounter].Height/(document[docNumber].numOfPatiants+1))/2);
		}
        //private Point calculateOpacPanelLocation(int patiantNumber, int buttonCounter)
        //{

        //    int panelCounter = buttonCounter / document[docNumber].numOfButtonsInTimeLine;
        //    Size ButtonsSize = calculateButtonsSize(timeLinePanel[panelCounter]);
        //    Point StartLocation = calculateButtonsStartLocation(timeLinePanel[panelCounter], patiantNumber);
        //    return new System.Drawing.Point(/*x*/(StartLocation.X + ((buttonCounter - panelCounter * document[docNumber].numOfButtonsInTimeLine) * ButtonsSize.Width)),
        //        /*y*/	StartLocation.Y - (timeLinePanel[panelCounter].Height / (document[docNumber].numOfPatiants + 1)) / 2);
        //}
        private Point calculateSilencePanelLocation(int patiantNumber, int buttonCounter)
        {

            int panelCounter = buttonCounter / document[docNumber].numOfButtonsInTimeLine;
            Size ButtonsSize = calculateButtonsSize(timeLinePanel[panelCounter]);
            Point StartLocation = calculateButtonsStartLocation(timeLinePanel[panelCounter], patiantNumber);
            return new System.Drawing.Point(/*x*/(StartLocation.X + ((buttonCounter - panelCounter * document[docNumber].numOfButtonsInTimeLine) * ButtonsSize.Width)),
                                            /*y*/ StartLocation.Y -10);
        }
        private Point calculateMusicNotesPanelLocation(int patiantNumber, int buttonCounter)
        {

            int panelCounter = buttonCounter / document[docNumber].numOfButtonsInTimeLine;
            Size ButtonsSize = calculateButtonsSize(timeLinePanel[panelCounter]);
            Point StartLocation = calculateButtonsStartLocation(timeLinePanel[panelCounter], patiantNumber);
            return new System.Drawing.Point(/*x*/(StartLocation.X + ((buttonCounter - panelCounter * document[docNumber].numOfButtonsInTimeLine) * ButtonsSize.Width)),
                /*y*/	(timeLinePanel[panelCounter].Height *2)/100 );
        }
		private Size calculateOpacPanelSize(int patiantNumber, int buttonCounter,int numOfButtons, int numOfLines)
		{
		
			int panelCounter = buttonCounter/document[docNumber].numOfButtonsInTimeLine;
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[panelCounter]);
			Point StartLocation=calculateButtonsStartLocation(timeLinePanel[panelCounter],patiantNumber);
			return new Size(/*width*/ButtonsSize.Width* (numOfButtons+1),
							/*Height*/	numOfLines*(timeLinePanel[panelCounter].Height/(document[docNumber].numOfPatiants+1))+(timeLinePanel[panelCounter].Height/(document[docNumber].numOfPatiants+1)));
		}
        private Size calculateSilencePanelSize(int patiantNumber, int buttonCounter, int numOfButtons, int numOfLines)
        {

            int panelCounter = buttonCounter / document[docNumber].numOfButtonsInTimeLine;
            Size ButtonsSize = calculateButtonsSize(timeLinePanel[panelCounter]);
            Point StartLocation = calculateButtonsStartLocation(timeLinePanel[panelCounter], patiantNumber);
            return new Size(/*width*/ButtonsSize.Width * (numOfButtons + 1),
                            /*Height*/(numOfLines-1) * (timeLinePanel[panelCounter].Height/(document[docNumber].numOfPatiants+1))+20);
        }
        private Size calculateMusicNotesPanelSize(int patiantNumber, int buttonCounter, int numOfButtons, int numOfLines)
        {

            int panelCounter = buttonCounter / document[docNumber].numOfButtonsInTimeLine;
            Size ButtonsSize = calculateButtonsSize(timeLinePanel[panelCounter]);
            Point StartLocation = calculateButtonsStartLocation(timeLinePanel[panelCounter], patiantNumber);
            return new Size(/*width*/ButtonsSize.Width * (numOfButtons + 1),
                /*Height*/ StartLocation.Y - ((timeLinePanel[panelCounter].Height * 2) / 100) - document[docNumber].widthOfTimeLineButton);
        }
		private Point calculateDiscPanelLocation(int patiantNumber, int buttonCounter)
		{
			int panelCounter = buttonCounter/document[docNumber].numOfButtonsInTimeLine;
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[panelCounter]);
			Point StartLocation=calculateButtonsStartLocation(timeLinePanel[panelCounter],patiantNumber);
			return new System.Drawing.Point(/*x*/(StartLocation.X + ((buttonCounter-panelCounter*document[docNumber].numOfButtonsInTimeLine) * ButtonsSize.Width)),
				/*y*/	//StartLocation.Y - (timeLinePanel[panelCounter].Height/(document[docNumber].numOfPatiants+1))*5/6);
				  (timeLinePanel[panelCounter].Height*3/100));
		}
		private Size calculateDiscPanelSize(int numOfButtons)
		{
			int panelCounter = 0;//buttonCounter/document[docNumber].numOfButtonsInTimeLine;
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[panelCounter]);
			Point StartLocation=calculateButtonsStartLocation(timeLinePanel[panelCounter],0);
			int Width;
			if (this.document[docNumber].numOfButtonsInTimeLine>=50 && this.document[docNumber].numOfButtonsInTimeLine<60)
				Width=ButtonsSize.Width*3;
			else if (this.document[docNumber].numOfButtonsInTimeLine>=60)
				Width=ButtonsSize.Width*4;
			else
				Width=ButtonsSize.Width*2;
			return new Size(Width/*ButtonsSize.Width* (numOfButtons+1)*/,
				/*Height*/	//(this.document[docNumber].numOfPatiants-1)*(timeLinePanel[panelCounter].Height/(document[docNumber].numOfPatiants+1))+(timeLinePanel[panelCounter].Height/(document[docNumber].numOfPatiants+1)));
				this.document[docNumber].numOfPatiants*(timeLinePanel[panelCounter].Height/(document[docNumber].numOfPatiants+1))-(timeLinePanel[panelCounter].Height*3/100)+2);
		}
		
		private Point calculateEndInstrumentSectionButtonLocation(int panelCounter, int patiantNumber, int buttonCounter)
		{
			//Point StartLocation=new Point(0,0);
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[panelCounter]);
			Point StartLocation=calculateButtonsStartLocation(timeLinePanel[panelCounter],patiantNumber);
			return new System.Drawing.Point((StartLocation.X + ((buttonCounter+1) * ButtonsSize.Width) - document[docNumber].widthOfEndInstrumentSectionButton ), StartLocation.Y -document[docNumber].heightOfEndInstrumentSectionButton/2);
		}
		
		private Point calculateLableLocation(int panelCounter, int patiantNumber, int buttonCounter)
		{	
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[panelCounter]);
			Point StartLocation=calculateButtonsStartLocation(timeLinePanel[panelCounter],patiantNumber);
			return new System.Drawing.Point((StartLocation.X + (buttonCounter * ButtonsSize.Width))+((ButtonsSize.Width/2)-(document[docNumber].widthOfLable/2)), StartLocation.Y-(document[docNumber].heightOfLable/2) -2);//amit
		}
		private Point calculateInstrumentPictureLocation(int panelCounter, int patiantNumber, int buttonCounter)
		{
			
			Size ButtonsSize=calculateButtonsSize(timeLinePanel[panelCounter]);
			Size instrumentPictureBoxSize = calculateInstrumentPictureSize(timeLinePanel[panelCounter]);
			Point StartLocation=calculateButtonsStartLocation(timeLinePanel[panelCounter],patiantNumber);
			return new System.Drawing.Point((StartLocation.X + (buttonCounter * ButtonsSize.Width))+(ButtonsSize.Width/2)-(instrumentPictureBoxSize.Width /2), StartLocation.Y-(instrumentPictureBoxSize.Height/2) );
		}
		
		/*private void button_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			AButton button = (AButton)sender;
			button.DoDragDrop(button.x, DragDropEffects.Scroll );

		}*/
		private void button_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			AButton curButton = (AButton)sender;
			int target = Convert.ToInt16(e.Data.GetData(DataFormats.Text ) );
			for (int count=curButton.x;count<target;count++)
				ButtonArray[0,count].BackColor = Color.Aqua;
			//textBox1.Text = e.Data.GetData(DataFormats.Text).ToString();
		}
		private void button_mouseHover (object sender, System.EventArgs e)
		{
			AButton bb = (AButton) sender;
			ButtonArray[bb.y,bb.x].BackColor = Color.Red;
			ButtonArray[bb.y,bb.x].ForeColor = Color.Red;	
		}
	
		private void button_mouseLeave (object sender, System.EventArgs e)
		{
			AButton bb = (AButton) sender;
			if(document[docNumber].timeLine[bb.y].MinutesArray[bb.x].levelOfInstrumentIntensity==0)
			{
				this.ButtonArray[bb.y,bb.x].BackColor = document[docNumber].sessionColor.PanelColor;
				this.ButtonArray[bb.y,bb.x].ForeColor = document[docNumber].sessionColor.PanelColor;
			}
			else
			{
				ButtonArray[bb.y,bb.x].BackColor = document[docNumber].timeLine[bb.y].MinutesArray[bb.x].buttonBackColor;
				ButtonArray[bb.y,bb.x].ForeColor= document[docNumber].timeLine[bb.y].MinutesArray[bb.x].buttonBackColor;
			}
		}
		
		private void button_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text)) 
			{
				//If CTRL was pressed to a copy else move
				if ((e.KeyState & 8) == 8) 
				{
					e.Effect = DragDropEffects.Copy;
				}
				else 
				{
					e.Effect = DragDropEffects.Move;
				}
			}
			else 
			{
				e.Effect = DragDropEffects.Link;
			}
		}

		public Point getPressedButton()
		{
			Point tmp= new Point(9,9);
			for (int x=0;x<this.document[docNumber].numOfPatiants;x++)
			{	
				for (int y=0;y<60;y++)
				{
					if (this.ButtonArray[x,y].Pressed)
					{
						tmp.X=x;
						tmp.Y=y;
						return tmp;
					}
				}
			}
			return tmp;
		}
		
	
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sessions));
            this.mainContextMenu = new System.Windows.Forms.ContextMenu();
            this.AddText = new System.Windows.Forms.MenuItem();
            this.RemoveText = new System.Windows.Forms.MenuItem();
            this.ChanheColors = new System.Windows.Forms.MenuItem();
            this.ChangeBackroubdColor = new System.Windows.Forms.MenuItem();
            this.ChangePanelBackroundColor = new System.Windows.Forms.MenuItem();
            this.InstrumentImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // mainContextMenu
            // 
            this.mainContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.AddText,
            this.RemoveText,
            this.ChanheColors});
            this.mainContextMenu.Popup += new System.EventHandler(this.mainContextMenu_Popup);
            // 
            // AddText
            // 
            this.AddText.Index = 0;
            this.AddText.Text = "Add text";
            // 
            // RemoveText
            // 
            this.RemoveText.Index = 1;
            this.RemoveText.Text = "Remove text";
            // 
            // ChanheColors
            // 
            this.ChanheColors.Index = 2;
            this.ChanheColors.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ChangeBackroubdColor,
            this.ChangePanelBackroundColor});
            this.ChanheColors.Text = "change colors";
            // 
            // ChangeBackroubdColor
            // 
            this.ChangeBackroubdColor.Index = 0;
            this.ChangeBackroubdColor.Text = "change backround color";
            this.ChangeBackroubdColor.Click += new System.EventHandler(this.ChangeFrameBackroubdColor_Click);
            // 
            // ChangePanelBackroundColor
            // 
            this.ChangePanelBackroundColor.Index = 1;
            this.ChangePanelBackroundColor.Text = "change panel backround color";
            this.ChangePanelBackroundColor.Click += new System.EventHandler(this.ChangePanelBackroundColor_Click);
            // 
            // InstrumentImageList
            // 
            this.InstrumentImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("InstrumentImageList.ImageStream")));
            this.InstrumentImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.InstrumentImageList.Images.SetKeyName(0, "");
            this.InstrumentImageList.Images.SetKeyName(1, "");
            this.InstrumentImageList.Images.SetKeyName(2, "");
            this.InstrumentImageList.Images.SetKeyName(3, "");
            this.InstrumentImageList.Images.SetKeyName(4, "");
            this.InstrumentImageList.Images.SetKeyName(5, "");
            // 
            // Sessions
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.ContextMenu = this.mainContextMenu;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Sessions";
            this.Text = "Sessions";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Sessions_Paint_1);
            this.SizeChanged += new System.EventHandler(this.Sessions_SizeChanged);
            this.Closed += new System.EventHandler(this.Sessions_Closed);
            this.Enter += new System.EventHandler(this.Sessions_Enter);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Sessions_KeyUp);
            this.Load += new System.EventHandler(this.Sessions_Load);
            this.ResumeLayout(false);

		}
		#endregion
		public void setBackroundColor()
		{
			this.mainPanel.BackColor = this.document[docNumber].sessionColor.frameBackroundColor;
			
		}
		private void Sessions_Load(object sender, System.EventArgs e)
		{
//			e.Graphics.DrawString("SampleText", 
//				new Font("Arial", 80, FontStyle.Bold), Brushes.Black, 150, 125);

	
		}
		public bool ThumbnailCallback()
		{
			return false;
		}
		private void SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
		{
			Sessions_SizeChanged(sender,e);
		}
		int counterr=0;
		public void Sessions_SizeChanged(object sender, System.EventArgs e)
		{
			Point nameButtonLocation=new Point();
			Point nameButtonSize=new Point();
            this.SuspendLayout();
			for ( int panelCounter  = 0;panelCounter <document[docNumber].numOfPanelsInSession;panelCounter++)
			{
			
				if (timeLinePanel[panelCounter]!=null)
				{
					timeLinePanel[panelCounter].Location = setTimeLinePanelLocation(panelCounter+1);//new Point(y,x);
					timeLinePanel[panelCounter].Size = setTimeLinePanelSize(panelCounter+1);
					
				}
				counterr++;
				Bitmap tmp ;
				if (counterr <6)
				tmp= ResizeBitmap (bitmapArray[panelCounter],800,115);// timeLinePanel[panelCounter].Size.Width,timeLinePanel[panelCounter].Size.Height); //new Bitmap(bitmapArray[panelCounter]);
				else
				 tmp = ResizeBitmap (bitmapArray[panelCounter],600,50);
				bitmapArray[panelCounter].Dispose();
				bitmapArray[panelCounter] = tmp;

				nameButtonSize= calculateNameButtonSize(timeLinePanel[panelCounter]);
				for (int patiantsConter = 0; patiantsConter < document[docNumber].numOfPatiants; patiantsConter++)
				{
					
					for (int numOfButtons = 0; numOfButtons < getNumOfButtonsInRow(); numOfButtons++)
					{
						int yy=numOfButtons+getNumOfButtonsInRow()*panelCounter;
						ButtonArray[patiantsConter, yy].Location = calculateButtonLocation(panelCounter,patiantsConter,numOfButtons); 
						ButtonArray[patiantsConter, yy].Size = calculateButtonsSize(timeLinePanel[panelCounter],patiantsConter,yy);
						//LableArray[patiantsConter, yy].Location = calculateLableLocation(panelCounter,patiantsConter,numOfButtons); 
						//LableArray[patiantsConter, yy].Size = calculateLablesSize(timeLinePanel[panelCounter]);
                        //LableArray[patiantsConter, yy].BringToFront();
						InstrumentPictureArray[patiantsConter, yy].Size = calculateInstrumentPictureSize(timeLinePanel[panelCounter]);
						InstrumentPictureArray[patiantsConter, yy].Location = calculateInstrumentPictureLocation(panelCounter,patiantsConter,numOfButtons); 
						EndInstrumentSectionButtonArray[patiantsConter, yy].Location = calculateEndInstrumentSectionButtonLocation(panelCounter,patiantsConter,numOfButtons);						
					}
					nameButtonLocation=calculateNameButonLocation(timeLinePanel[panelCounter],patiantsConter);
					NameButtonArray[panelCounter,patiantsConter].Size=new Size(nameButtonSize.X,nameButtonSize.Y);
					NameButtonArray[panelCounter,patiantsConter].Location=nameButtonLocation;
					
				}
			//	CurlyBracesArray[panelCounter].SizeMode = PictureBoxSizeMode.StretchImage;
				CurlyBracesArray[panelCounter].Location = calculateCurlyBracesLocation(timeLinePanel[panelCounter]);
				CurlyBracesArray[panelCounter].Size=calculateCurlyBracesSize(timeLinePanel[panelCounter]);
				
				videoPanel[panelCounter].Location=calculateVideoPanelLocation();
				videoPanel[panelCounter].Size=calculateVideoPanelSize();
				
				
			}
			//TextPanel.Location = new Point(this.Location.X,(int)(this.Location.Y+this.Size.Height*document[docNumber].proportionOfPanelArearAndTextArea));
			//TextPanel.Size = new Size(this.Size.Width,this.Size.Height/3);
			
			//text size
			int columWidth=setColumnSize();
			int lineHeight=setLineSize();
			for (int x=0;x<document[docNumber].numOfTextBoxInColumn;x++)
			{
				for (int y=0;y<document[docNumber].numOfTextBoxColumns ;y++)
				{
					TextBoxArray[x, y].Location = new System.Drawing.Point(x*columWidth , y*lineHeight);
					TextBoxArray[x, y].Size = new System.Drawing.Size(columWidth, lineHeight);
				}
			}
            //this.mainSplitter.SplitPosition = this.Size.Height * this.document[docNumber].proportionOfPanelArearAndTextArea / 100;
			//bitmapPanel.Size=this.Size;
            refreshTopicLables();
			refreshOpacPanels();
			refreshSingScream();
			refreshArrows();
			refreshDiscPanels();
			refreshRichTextBoxes();
            refreshMusicNotes();
            refreshFrameePanels();
            refreshSilencePanels();
            this.initTextBoxesInTextPanel();
            this.ResumeLayout();
		}
		public Bitmap ResizeBitmap( Bitmap b, int nWidth, int nHeight )
		{  
			Bitmap result = new Bitmap( nWidth, nHeight );
			Graphics g = Graphics.FromImage( (Image) result ); 
				//Graphics g = Graphics.FromImage(source);
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.DrawImage( b, 0, 0, nWidth, nHeight );
			//b.Dispose();
			return result;
		}

		private void mainContextMenu_Popup(object sender, System.EventArgs e)
		{
		
		}

		public void ChangeFrameBackroubdColor_Click(object sender, System.EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.AllowFullOpen = true;
			colorDialog.AnyColor = true;
			colorDialog.SolidColorOnly = false;
			colorDialog.ShowHelp = true;
			colorDialog.Color=this.document[docNumber].sessionColor.frameBackroundColor;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				this.BackColor = colorDialog.Color;
				this.document[docNumber].sessionColor.frameBackroundColor= colorDialog.Color;
				this.Invalidate();
			}
			this.mainPanel.BackColor = this.document[docNumber].sessionColor.frameBackroundColor;
		}
		public void VideoPanel_Click(object sender, System.EventArgs e)
		{
			//APanel videoPanel=(APanel)sender;
			//videoPanelClicked=videoPanel.panelNumber;
			//Point ptCursor = Cursor.Position; 
			//ptCursor = PointToClient(ptCursor); 
		/*	if( videoPanel[0].Bounds.Contains(ptCursor) ) 
			{ 
				//mouse over button1 
				//.... 
			} 
			else 
			{ 
				//mouse not over button1 
				//.... 
			}
 */

			//Point point=(Point)e;
			//MessageBox.Show(videoPanel.panelNumber+" "+ptCursor.X+"  " + ptCursor.Y);
		}
				
		public void ChangePanelBackroundColor_Click(object sender, System.EventArgs e)
		{			
				ColorDialog colorDialog = new ColorDialog();
				colorDialog.AllowFullOpen = true;
				colorDialog.AnyColor = true;
				colorDialog.SolidColorOnly = false;
				colorDialog.ShowHelp = true;
				colorDialog.Color = this.document[docNumber].sessionColor.PanelColor;
				// Update the text box color if the user clicks OK 
				if (colorDialog.ShowDialog() == DialogResult.OK)
				{
					for (int x=0; x<document[docNumber].numOfPanelsInSession;x++)
					{
						timeLinePanel[x].BackColor=  colorDialog.Color;
						this.timeLinePanel[x].Invalidate();
					}
					this.document[docNumber].sessionColor.PanelColor= colorDialog.Color;
					
				}

		}

		private void Sessions_Enter(object sender, System.EventArgs e)
		{
			MainForm mainForm = (MainForm) this.MdiParent;
            if (document[docNumber].numOfPatiants > this.MaxNumOfPatiantsBeforeSplitingTimePanel)
			{
				//mainForm.PanelhScrollBar.Enabled= true;
			//	mainForm.PanelDown.Enabled= true;
			//	mainForm.PanelUp.Enabled= true;
				mainForm.enableSessionAndPanelNavigationButtons();
			}
			else
			{
				//mainForm.PanelhScrollBar.Enabled= false;
				//mainForm.PanelDown.Enabled= false;
				//mainForm.PanelUp.Enabled= false;
				mainForm.disableSessionAndPanelNavigationButtons();
			}
		}
		public void drawVerticalLinesInTimeLine()
		{
			/*Graphics g = null;
			g = Graphics.FromImage(CurlyBracesArray[0].Image);
			g.DrawLine(new Pen(Color.Black,3),0,0,200,200); 
			g.Dispose();*/
			
			System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Black,1);
			myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
			System.Drawing.Graphics formGraphics;
			for ( int panelCounter  = 0;panelCounter <document[docNumber].numOfPanelsInSession;panelCounter++)
			{
				formGraphics = timeLinePanel[panelCounter].CreateGraphics();
				//	formGraphics =ePaint.Graphics;
				//butonSize= 
				System.Drawing.Font myFont;
				myFont = new System.Drawing.Font("Arial", 10,FontStyle.Bold);
				for (int lineCounter=0;lineCounter<((document[docNumber].numOfButtonsInTimeLine/document[docNumber].intervalBetweenDashedVerticalLinesInTimeLine)+1);lineCounter++)
				{
					int yStart= ((timeLinePanel[panelCounter].Size.Height-(document[docNumber].numOfPatiants*0))/(document[docNumber].numOfPatiants+1) * (0+1)) +(/*document[docNumber].widthOfTimeLineButton*/0*((0+1)-1)); 
					int yEnd=((timeLinePanel[panelCounter].Size.Height-(document[docNumber].numOfPatiants*document[docNumber].widthOfTimeLineButton))/(document[docNumber].numOfPatiants+1) * (document[docNumber].numOfPatiants-1+1)) +(document[docNumber].widthOfTimeLineButton*((document[docNumber].numOfPatiants-1+1)-1)); 
					int x = timeLinePanel[panelCounter].Size.Width*document[docNumber].percentOfSpaceBeforeButtonsInTimeLine/100+
							lineCounter*((Size)( (calculateButtonsSize(timeLinePanel[panelCounter])))).Width*document[docNumber].intervalBetweenDashedVerticalLinesInTimeLine;
						// timeLinePanel[panelCounter].Size.Width*(100-document[docNumber].percentOfSpaceBeforeButtonsInTimeLine)/100/(document[docNumber].numOfButtonsInTimeLine/document[docNumber].intervalBetweenDashedVerticalLinesInTimeLine);
					Point lineStart = new Point(x,yStart);
					Point lineEnd = new Point(x,yEnd);
					float numberText=(float)((float)document[docNumber].intervalBetweenDashedVerticalLinesInTimeLine/2*(float)lineCounter+(float)document[docNumber].numOfButtonsInTimeLine/2*(float)panelCounter);
					int xOffSet;
					if (numberText>9)
						xOffSet=8;
					else
						xOffSet=1;
					formGraphics.DrawString(""+numberText.ToString(),myFont,System.Drawing.Brushes.Brown,x-xOffSet,yEnd+9/*2*/);
					formGraphics.DrawLine(myPen, lineStart.X,lineStart.Y,lineEnd.X,lineEnd.Y);
				}
			}
		}

		
		private void TimeLinePanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
            this.SuspendLayout();
            APanel panel  = (APanel) sender;
			drawVerticalLinesInTimeLine();
			//drawPanelBitmaps(panel.panelNumber);
			refreshArrows();
			refreshVideoPanels();
            this.ResumeLayout();
		}
		public void BringOpacPanelsToFront()
		{
			if (bringOpacPanelsToFront)
				bringOpacPanelsToFront=false;
			else
				bringOpacPanelsToFront=true;
	
			for (int x=0;x<OpacPanelsArrayList.Count;x++)
			{
				AmitOpacUserControl opac = (AmitOpacUserControl) OpacPanelsArrayList[x];
				if (bringOpacPanelsToFront)
					opac.OpacPanelBringToFront();
				else
					//opac.SendToBack();
					opac.OpacPanelSendToBack();
					 
			}
		

		}
		public void Sessions_mainPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			for ( int panelCounter  = 0;panelCounter <document[docNumber].numOfPanelsInSession;panelCounter++)
			{	
				timeLinePanel[panelCounter].Invalidate();
			}
			
			drawVerticalLinesInTimeLine();
			refreshArrows();
			//refreshVideoPanels();
			
		}
		public void Sessions_Paint_1(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			
		/*	for ( int panelCounter  = 0;panelCounter <document[docNumber].numOfPanelsInSession;panelCounter++)
			{	
				timeLinePanel[panelCounter].Invalidate();
			}*/
             
			drawVerticalLinesInTimeLine();
			foreach (Control cn in this.Controls)
			{
				cn.SendToBack();
			}
			//Graphics g = e.Graphics;
			//g.DrawLine(new Pen( Color.Black,3),new Point(1,1),new Point(200,200));
			//stopScrabling();
			refreshArrows();
			//refreshVideoPanels();
			
		}
		
		private void Sessions_Closed(object sender, System.EventArgs e)
		{
			if (( (MainForm)this.MdiParent).numOfSessions ==1)
			{
				((MainForm)this.MdiParent).disableButtons();
			}
				((MainForm)this.MdiParent).numOfSessions--;
		}

        private void Sessions_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.F9 || e.KeyData == Keys.Z)
            {
                //MessageBox.Show("In F10");
                this.Refresh();
            }
            //if (e.KeyData == Keys.F12)
            //{
            //    if (_bFullScreenMode == false)
            //    {
            //        FullScreenMode.Form2 f = new FullScreenMode.Form2();
            //        // f.BackColor = System.Drawing.Color.Black;
            //        // f.ClientSize = new System.Drawing.Size(292, 266);
            //        // f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            //        this.Owner = this.ParentForm;
            //        this.FormBorderStyle = FormBorderStyle.None;
            //        this.WindowState = FormWindowState.Maximized;
            //        this.Left = (Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2);
            //        this.Top = (Screen.PrimaryScreen.Bounds.Height/2 - this.Height/2);
            //        //this.
            //       f.Show();
            //        _bFullScreenMode = true;
            //        f.KeyUp += new KeyEventHandler(Sessions_KeyUp);
            //    }
            //    else
            //    {
            //        //Form f = this.Owner;
            //        //this.Owner = null;
            //        //f.Close();

            //        this.FormBorderStyle = FormBorderStyle.Sizable;
            //        _bFullScreenMode = false;
            //    }
            //}
        }

        
	}
		
}
