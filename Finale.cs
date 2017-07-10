using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace musicTherapy1
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Finale : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Panel sketchPanel;
		private System.ComponentModel.IContainer components;
		private int numberOfNotes=0;
		public int noteWidth=30;
		PictureBox mafteachSol;
        public Form parentForm;
		private Panel[] StafPanelArray;
		int [] stafLine;
		int bandPathOfStafLine;
		int mouseX ;
		int mouseY;
		bool cursorPointsAboveStaf;
		bool cursorPointsBelowStaf;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton Quater;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton Half;
		private ArrayList notesControlsArrayList;
		private System.Windows.Forms.ToolBarButton DeleteNote;
		private System.Windows.Forms.ToolBarButton eights;
		private System.Windows.Forms.ToolBarButton sixteens;
		private System.Windows.Forms.ToolBarButton Whole;
		private System.Windows.Forms.ToolBarButton Dot;
        private Button OkButton;
        private Button CancelButton;
        private NumericUpDown TempoNumericUpDown1;
        private Label label1;
        private RadioButton ComposeNotesRadioButton;
        private RadioButton FromFileRadioButton;
        private Button BrowseButton;
        private TextBox FileNameTextBox;
        private ToolBarButton Flat;
        private ToolBarButton Sharp;
        private ToolBarButton Sol;
        private ToolBarButton Fa;
        private ToolBarButton Natural;
		public ArrayList notesArrayList;
        public int Mafteach = 0; //0-sol, 1 - fa
        //public int MafteachType
        public string Tempo
        {
            get { return Convert.ToString( this.TempoNumericUpDown1.Value); }
        }
        public string NotePictureFileName
        {
            get { return this.FileNameTextBox.Text; }
            set { this.FileNameTextBox.Text = value; }
        }
		//private bool stafPanelWasClicked = false;
		public Finale()
		{
			//
			// Required for Windows Form Designer support
			//
			StafPanelArray=new Panel[5];
			stafLine = new int[20];
			InitializeComponent();
			notesControlsArrayList = new ArrayList();
			notesArrayList= new ArrayList();
			
		}
        public void drawStaf(Panel sketchPanel)
		{
			int panelHeight=sketchPanel.ClientRectangle.Height;
            int panelWidth = sketchPanel.ClientRectangle.Width;
			
			mafteachSol =new PictureBox();
			//mafteachSol.Image = new Bitmap(@"D:\Documents and Settings\amklein\My Documents\Visual Studio Projects\70px-Music_Sol_key.jpg");
            if (Mafteach==0)
            mafteachSol.Image = new Bitmap(((MainForm)((Sessions)this.parentForm).ParentForm).MainDirectory + "\\GtrebelKey3.png");
            if (Mafteach ==1)
                mafteachSol.Image = new Bitmap(((MainForm)((Sessions)this.parentForm).ParentForm).MainDirectory + "\\Music_Fa_key3.png");

            mafteachSol.Size = new Size(panelHeight * 2 / 3, panelHeight);
			mafteachSol.SizeMode = PictureBoxSizeMode.StretchImage;
			mafteachSol.Location=new Point(0,0);
			
			sketchPanel.Controls.Add(mafteachSol);
			
			Graphics g = sketchPanel.CreateGraphics();
			Pen p = new Pen(Color.Black,1);
			
			for (int x=0;x<5;x++)
			{
				StafPanelArray[x] = new Panel();
              //  StafPanelArray[x].Location = new Point(0, (panelHeight * 11 / 51 +/*(panelHeight*29/51)/4*/panelHeight*7 * x / 51));
                StafPanelArray[x].Location = new Point(0, (panelHeight * 25 / 100 + (panelHeight * 50 / 100) / 4 * x));
				StafPanelArray[x].Size = new Size(panelWidth,1);
				StafPanelArray[x].BackColor=Color.Black;
				StafPanelArray[x].BringToFront();
				//StafPanelArray[x].Click +=new System.EventHandler(this.StafPanel_Click);
			//	StafPanelArray[x].MouseDown+=new System.Windows.Forms.MouseEventHandler(this.Staf_MouseDown);
				sketchPanel.Controls.Add( StafPanelArray[x]);

				//g.DrawLine(new Pen(new SolidBrush(Color.Black),3),0,(panelHeight*25/100+(panelHeight*50/100)/4*x),panelWidth,(panelHeight*25/100+(panelHeight*50/100)/4*x));
			}
			mafteachSol.SendToBack();
			//sketchPanel.Click+=new System.EventHandler(this.sketchPanel_Click);
			sketchPanel.MouseDown+=new System.Windows.Forms.MouseEventHandler(this.sketch_MouseDown);
			
		}
		private void sketch_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e )
		{
		//	stafPanelWasClicked=false; 
			//MessageBox.Show("sketch " + e.X+ " " + e.Y);
			Point p=new Point(e.X,e.Y);
			drawNote(p);
			
		}
	/*	private void Staf_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e )
		{
			stafPanelWasClicked=true; 
			MessageBox.Show("staf " + e.X+ " " + e.Y);
			Point p=new Point(e.X,e.Y);
			drawNote(p);	
		}*/
        public void initStafLineArray(Panel sketchPanel)
		{
			int panelHeight=sketchPanel.Size.Height;
			int panelWidth=sketchPanel.Size.Width;
			bandPathOfStafLine=panelHeight*60*6/100/100; //  like 60/100 * 7/100
			
			int counter=1;

			/***************
	0		--------------------------------------C
			0- - - - - - - - - - - - - - - - - - - 
			1- - - - - - - - - - - - - - - - - - - 
			--------------------------------------A
			2- - - - - - - - - - - - - - - - - - - 
			3- - - - - - - - - - - - - - - - - - - 
			--------------------------------------1
			4- - - - - - - - - - - - - - - - - - - 
			5- - - - - - - - - - - - - - - - - - - 
			--------------------------------------2
			6- - - - - - - - - - - - - - - - - - - 
			7- - - - - - - - - - - - - - - - - - - 
			--------------------------------------3
			8- - - - - - - - - - - - - - - - - - - 
			9 - - - - - - - - - - - - - - - - - - 
			--------------------------------------4
			10- - - - - - - - - - - - - - - - - - - 
			11- - - - - - - - - - - - - - - - - - - 
			--------------------------------------5
			12- - - - - - - - - - - - - - - - - - - 
		    13- - - - - - - - - - - - - - - - - - -
		    ---------------------------------------C
		    14- - - - - - - - - - - - - - - - - - - 
		    15- - - - - - - - - - - - - - - - - - - 
	100	    ----------------------------------------A
			 * */
			//set the 10 lines places (the y coordinate)
			for (int x=1;x<8;x++)
			{
				stafLine[counter++] =(panelHeight/8*x)-bandPathOfStafLine;
				stafLine[counter++] =(panelHeight/8*x)+bandPathOfStafLine;
	
			}
				stafLine[0] =0;
			/*for (int x=0;x<5;x++)
			{
				stafLine[counter++] =(panelHeight*25/100+(panelHeight*50/100)/4*x)-bandPathOfStafLine;
				stafLine[counter++] =(panelHeight*25/100+(panelHeight*50/100)/4*x)+bandPathOfStafLine;
	
			}*/
		}
		private void drawNote(Point p)
		{
			Point realPoint=new Point();
			Note n=new Note();
			if (p.X > (numberOfNotes*noteWidth +mafteachSol.Size.Width)&& p.X <((numberOfNotes+1)*noteWidth +mafteachSol.Size.Width))
				realPoint.X=numberOfNotes*noteWidth+mafteachSol.Size.Width;
			else 
			return;
			//int offset = (noteWidth*5/4*10/32);
			int offset = (noteWidth*5/4*1/2);
			//find where the cursor was clicked and where to locate the note
            if (p.Y > stafLine[0] && p.Y <= stafLine[1])
            {
                realPoint.Y = stafLine[0] + bandPathOfStafLine - offset;
                n.noteIndex = 0;
            }
            else if (p.Y > stafLine[1] && p.Y <= stafLine[2])//#
            {
                realPoint.Y = (stafLine[1] + stafLine[2]) / 2 - offset;
                n.noteIndex = 1;
            }
            else if (p.Y > stafLine[2] && p.Y <= stafLine[3])
            {
                realPoint.Y = stafLine[2] + bandPathOfStafLine - offset;
                n.noteIndex = 2;
            }
            else if (p.Y > stafLine[3] && p.Y <= stafLine[4])//#
            {
                realPoint.Y = (stafLine[3] + stafLine[4]) / 2 - offset;
                n.noteIndex = 3;
            }
            else if (p.Y > stafLine[4] && p.Y <= stafLine[5])
            {
                realPoint.Y = stafLine[4] + bandPathOfStafLine - offset;
                n.noteIndex = 4;
            }
            else if (p.Y > stafLine[5] && p.Y <= stafLine[6])//#
            {
                realPoint.Y = (stafLine[5] + stafLine[6]) / 2 - offset;
                n.noteIndex = 5;
            }
            else if (p.Y > stafLine[6] && p.Y <= stafLine[7])
            {
                realPoint.Y = stafLine[6] + bandPathOfStafLine - offset;
                n.noteIndex = 6;
            }
            else if (p.Y > stafLine[7] && p.Y <= stafLine[8])//#
            {
                realPoint.Y = (stafLine[7] + stafLine[8]) / 2 - offset;
                n.noteIndex = 7;
            }
            else if (p.Y > stafLine[8] && p.Y <= stafLine[9])
            {
                realPoint.Y = stafLine[8] + bandPathOfStafLine - offset;
                n.noteIndex = 8;
            }
            else if (p.Y > stafLine[9] && p.Y <= stafLine[10])//#
            {
                realPoint.Y = (stafLine[9] + stafLine[10]) / 2 - offset;
                n.noteIndex = 9;
            }
            else if (p.Y > stafLine[10] && p.Y <= stafLine[11])
            {
                realPoint.Y = stafLine[10] + bandPathOfStafLine - offset;
                n.noteIndex = 10;
            }
            else if (p.Y > stafLine[11] && p.Y <= stafLine[12])//#
            {
                realPoint.Y = (stafLine[11] + stafLine[12]) / 2 - offset;
                n.noteIndex = 11;
            }
            else if (p.Y > stafLine[12] && p.Y <= stafLine[13])
            {
                realPoint.Y = stafLine[12] + bandPathOfStafLine - offset;
                n.noteIndex = 12;
            }
            else if (p.Y > stafLine[13] && p.Y <= stafLine[14])//#
            {
                realPoint.Y = (stafLine[13] + stafLine[14]) / 2 - offset;
                n.noteIndex = 13;
            }
            else if (p.Y > stafLine[14] && p.Y <= stafLine[15])
            {
                realPoint.Y = stafLine[14] + bandPathOfStafLine - offset;
                n.noteIndex = 14;
            }
            else if (p.Y > stafLine[15] && p.Y <= stafLine[16])//#
            {
                realPoint.Y = (stafLine[15] + stafLine[16]) / 2 - offset;
                n.noteIndex = 15;
            }

            else return;
						
			n.p= realPoint;
			//set direction of ma-ke-l
			if (p.Y>stafLine[8])
				n.direction=1;
			else 
				n.direction= -1;
			//set the number of dashaes
			if (p.Y >stafLine[13] && p.Y <stafLine[14])
				n.dashed=1;
			if (p.Y >stafLine[1] && p.Y <stafLine[2])
				n.dashed=1;

			if (Whole.Pushed)
 			   n.type=0;
			if (Half.Pushed)
				n.type=1;
			if (Quater.Pushed)
				n.type=2;
			if (eights.Pushed)
				n.type=3;
			if (sixteens.Pushed)
				n.type=4;
            if (Dot.Pushed)
                n.doted = 1;
            else
                n.doted = 0;

            if (Natural.Pushed)
                n.accidental=1;
            else if (Sharp.Pushed)
                n.accidental = 2;
            else if (Flat.Pushed)
                n.accidental = 3;
            else n.accidental = 0;

			notesArrayList.Add(n);

				//g.DrawLine(pen,linePoint.X,linePoint.Y,linePoint.X,linePoint.Y+25);
			//g.DrawEllipse(pen,elipsePoint.X,elipsePoint.Y,25,12);
			//g.FillEllipse(new SolidBrush(Color.Blue),elipsePoint.X,elipsePoint.Y,25,12);
			refreshNotes(this.sketchPanel,this.notesArrayList);
			numberOfNotes++;
			//sketchPanel.Invalidate();
		}
        public void setNotesLocation(ArrayList notesArraylist)
        {
            int offset = ((noteWidth * 30 / 54) * 16 / 14);//(noteWidth * 5 / 4 * 1 / 2);
            for (int Counter = 0; Counter < notesArraylist.Count; Counter++)
            {
                Note note = (Note)notesArraylist[Counter];
                note.p.X= Counter * noteWidth + mafteachSol.Size.Width;
                if (note.noteIndex == 0)
                {
                    note.p.Y = stafLine[0] + bandPathOfStafLine - offset;
                    
                }
                else if (note.noteIndex == 1)//#
                {
                    note.p.Y = (stafLine[1] + stafLine[2]) / 2 - offset;
                    
                }
                else if (note.noteIndex == 2)
                {
                    note.p.Y = stafLine[2] + bandPathOfStafLine - offset;
                    
                }
                else if (note.noteIndex == 3)//#
                {
                    note.p.Y = (stafLine[3] + stafLine[4]) / 2 - offset;
                    
                }
                else if (note.noteIndex == 4)
                {
                    note.p.Y = stafLine[4] + bandPathOfStafLine - offset;
                    
                }
                else if (note.noteIndex == 5)//#
                {
                    note.p.Y = (stafLine[5] + stafLine[6]) / 2 - offset;
                    
                }
                else if (note.noteIndex == 6)
                {
                    note.p.Y = stafLine[6] + bandPathOfStafLine - offset;
                    
                }
                else if (note.noteIndex == 7)//#
                {
                    note.p.Y = (stafLine[7] + stafLine[8]) / 2 - offset;
                    
                }
                else if (note.noteIndex == 8)
                {
                    note.p.Y = stafLine[8] + bandPathOfStafLine - offset;
                    
                }
                else if (note.noteIndex == 9)//#
                {
                    note.p.Y = (stafLine[9] + stafLine[10]) / 2 - offset;
                    
                }
                else if (note.noteIndex == 10)
                {
                    note.p.Y = stafLine[10] + bandPathOfStafLine - offset;
                    
                }
                else if (note.noteIndex == 11)//#
                {
                    note.p.Y = (stafLine[11] + stafLine[12]) / 2 - offset;
                    
                }
                else if (note.noteIndex == 12)
                {
                    note.p.Y = stafLine[12] + bandPathOfStafLine - offset;
                    
                }
                else if (note.noteIndex == 13)//#
                {
                    note.p.Y = (stafLine[13] + stafLine[14]) / 2 - offset;
                    
                }
                else if (note.noteIndex == 14)
                {
                    note.p.Y = stafLine[14] + bandPathOfStafLine - offset;
                    
                }
                else if (note.noteIndex == 15)//#
                {
                    note.p.Y = (stafLine[15] + stafLine[16]) / 2 - offset;
                }
            }
        }
        public void refreshNotes(Panel sketchPanel,ArrayList notesArrayList)
		{
			
			//first  the opca panels from the time lines
			foreach (Control cont in notesControlsArrayList)
			{
				this.sketchPanel.Controls.Remove(cont);
				
			}
			//clear the array list
			notesControlsArrayList.Clear();
			
			for (int Counter=0;Counter<notesArrayList.Count;Counter++)
			{
				Note note= (Note)notesArrayList[Counter];
				
				AmitNoteControl.AmitNoteUserControl controlNote = new AmitNoteControl.AmitNoteUserControl();
				//Point elipsePoint=new Point(note.p.X,note.p.Y-6);
				//Point linePoint=new Point(note.p.X,note.p.Y);
				controlNote.Size=new Size(noteWidth,noteWidth*5/4);
				controlNote.Location = note.p;
				controlNote.p=note.p;
				controlNote.direction=note.direction;
				controlNote.type=note.type;
                controlNote.doted = note.doted;
				controlNote.dashed= note.dashed;
                controlNote.accidental = note.accidental;
				controlNote.Click += new System.EventHandler(this.NoteControl_Click);
				notesControlsArrayList.Add(controlNote);
				sketchPanel.Controls.Add(controlNote);
				controlNote.BringToFront();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Finale));
            this.sketchPanel = new System.Windows.Forms.Panel();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.Sol = new System.Windows.Forms.ToolBarButton();
            this.Fa = new System.Windows.Forms.ToolBarButton();
            this.Flat = new System.Windows.Forms.ToolBarButton();
            this.Sharp = new System.Windows.Forms.ToolBarButton();
            this.Natural = new System.Windows.Forms.ToolBarButton();
            this.Whole = new System.Windows.Forms.ToolBarButton();
            this.Half = new System.Windows.Forms.ToolBarButton();
            this.Quater = new System.Windows.Forms.ToolBarButton();
            this.eights = new System.Windows.Forms.ToolBarButton();
            this.sixteens = new System.Windows.Forms.ToolBarButton();
            this.Dot = new System.Windows.Forms.ToolBarButton();
            this.DeleteNote = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.TempoNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ComposeNotesRadioButton = new System.Windows.Forms.RadioButton();
            this.FromFileRadioButton = new System.Windows.Forms.RadioButton();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TempoNumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // sketchPanel
            // 
            this.sketchPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sketchPanel.Location = new System.Drawing.Point(127, 72);
            this.sketchPanel.Name = "sketchPanel";
            this.sketchPanel.Size = new System.Drawing.Size(384, 56);
            this.sketchPanel.TabIndex = 0;
            this.sketchPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sketchPanel_MouseMove);
            this.sketchPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.sketchPanel_Paint);
            this.sketchPanel.MouseHover += new System.EventHandler(this.sketchPanel_MouseHover);
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.Sol,
            this.Fa,
            this.Flat,
            this.Sharp,
            this.Natural,
            this.Whole,
            this.Half,
            this.Quater,
            this.eights,
            this.sixteens,
            this.Dot,
            this.DeleteNote});
            this.toolBar1.ButtonSize = new System.Drawing.Size(32, 32);
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(537, 44);
            this.toolBar1.TabIndex = 3;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // Sol
            // 
            this.Sol.ImageIndex = 10;
            this.Sol.Name = "Sol";
            this.Sol.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // Fa
            // 
            this.Fa.ImageIndex = 9;
            this.Fa.Name = "Fa";
            this.Fa.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // Flat
            // 
            this.Flat.ImageIndex = 8;
            this.Flat.Name = "Flat";
            this.Flat.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // Sharp
            // 
            this.Sharp.ImageIndex = 7;
            this.Sharp.Name = "Sharp";
            this.Sharp.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // Natural
            // 
            this.Natural.ImageIndex = 11;
            this.Natural.Name = "Natural";
            this.Natural.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // Whole
            // 
            this.Whole.ImageIndex = 0;
            this.Whole.Name = "Whole";
            this.Whole.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // Half
            // 
            this.Half.ImageIndex = 1;
            this.Half.Name = "Half";
            this.Half.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // Quater
            // 
            this.Quater.ImageIndex = 2;
            this.Quater.Name = "Quater";
            this.Quater.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // eights
            // 
            this.eights.ImageIndex = 3;
            this.eights.Name = "eights";
            this.eights.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // sixteens
            // 
            this.sixteens.ImageIndex = 4;
            this.sixteens.Name = "sixteens";
            this.sixteens.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // Dot
            // 
            this.Dot.ImageIndex = 5;
            this.Dot.Name = "Dot";
            this.Dot.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // DeleteNote
            // 
            this.DeleteNote.ImageIndex = 6;
            this.DeleteNote.Name = "DeleteNote";
            this.DeleteNote.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "sharp2.ico");
            this.imageList1.Images.SetKeyName(8, "flat2.ico");
            this.imageList1.Images.SetKeyName(9, "Music_Fa_key3.ico");
            this.imageList1.Images.SetKeyName(10, "GtrebelKey5.ico");
            this.imageList1.Images.SetKeyName(11, "natural.ico");
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(353, 247);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(250, 247);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // TempoNumericUpDown1
            // 
            this.TempoNumericUpDown1.Location = new System.Drawing.Point(161, 247);
            this.TempoNumericUpDown1.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.TempoNumericUpDown1.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.TempoNumericUpDown1.Name = "TempoNumericUpDown1";
            this.TempoNumericUpDown1.Size = new System.Drawing.Size(53, 20);
            this.TempoNumericUpDown1.TabIndex = 6;
            this.TempoNumericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(93, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tempo";
            // 
            // ComposeNotesRadioButton
            // 
            this.ComposeNotesRadioButton.AutoSize = true;
            this.ComposeNotesRadioButton.Location = new System.Drawing.Point(26, 92);
            this.ComposeNotesRadioButton.Name = "ComposeNotesRadioButton";
            this.ComposeNotesRadioButton.Size = new System.Drawing.Size(69, 17);
            this.ComposeNotesRadioButton.TabIndex = 8;
            this.ComposeNotesRadioButton.Text = "Compose";
            this.ComposeNotesRadioButton.UseVisualStyleBackColor = true;
            this.ComposeNotesRadioButton.CheckedChanged += new System.EventHandler(this.ComposeNotesRadioButton_CheckedChanged);
            // 
            // FromFileRadioButton
            // 
            this.FromFileRadioButton.AutoSize = true;
            this.FromFileRadioButton.Checked = true;
            this.FromFileRadioButton.Location = new System.Drawing.Point(26, 179);
            this.FromFileRadioButton.Name = "FromFileRadioButton";
            this.FromFileRadioButton.Size = new System.Drawing.Size(67, 17);
            this.FromFileRadioButton.TabIndex = 9;
            this.FromFileRadioButton.TabStop = true;
            this.FromFileRadioButton.Text = "From File";
            this.FromFileRadioButton.UseVisualStyleBackColor = true;
            this.FromFileRadioButton.CheckedChanged += new System.EventHandler(this.FromFileRadioButton_CheckedChanged);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(127, 173);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 10;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(221, 175);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(218, 20);
            this.FileNameTextBox.TabIndex = 11;
            // 
            // Finale
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(537, 302);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.FromFileRadioButton);
            this.Controls.Add(this.ComposeNotesRadioButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TempoNumericUpDown1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.sketchPanel);
            this.Name = "Finale";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Finale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TempoNumericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
        //[STAThread]
        //static void Main() 
        //{
        //    Application.Run(new Finale());
        //}
		/*private void StafPanel_Click(object sender, System.EventArgs e)
		{
			stafPanelWasClicked=true;
			MessageBox.Show(" staf" );
		}*/
	
		private void NoteControl_Click(object sender, System.EventArgs e)
		{
			AmitNoteControl.AmitNoteUserControl controlNote = (AmitNoteControl.AmitNoteUserControl)sender;
			for (int x=0;x<this.notesArrayList.Count;x++)
			{
				AmitNoteControl.AmitNoteUserControl tmp=(AmitNoteControl.AmitNoteUserControl )this.notesControlsArrayList[x];
				if (tmp.p==controlNote.p)
					this.notesArrayList.RemoveAt(x);
			}
			this.numberOfNotes--;
			refreshNotes(this.sketchPanel,this.notesArrayList);
															   
		}
		private void disableNoteButtons()
		{
            this.Whole.Pushed = false;
            this.Half.Pushed = false;
            this.Quater.Pushed = false;
            this.eights.Pushed = false;
            this.sixteens.Pushed = false;

		}
        private void disableOrEnableNoteButtons(bool state)
        {
            this.Whole.Enabled = state;
            this.Half.Enabled = state;
            this.Quater.Enabled = state;
            this.eights.Enabled = state;
            this.sixteens.Enabled = state;
            this.DeleteNote.Enabled = state;
            this.Flat.Enabled = state;
            this.Sharp.Enabled = state;
            this.Natural.Enabled = state;
            this.Sol.Enabled = state;
            this.Fa.Enabled = state;
            this.Dot.Enabled = state;

            if (state)
            {
                Sol.Pushed = true;
                Mafteach = 0;
            }

        }
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
            if (e.Button == Fa)
            {
                Mafteach = 1;
                Sol.Pushed = false;
                
                sketchPanel.Controls.Clear();
                drawStaf(this.sketchPanel);
                refreshNotes(this.sketchPanel, this.notesArrayList);
            }
            if (e.Button == Sol)
            {
                Mafteach = 0;
                Fa.Pushed = false;
                sketchPanel.Controls.Clear();
                drawStaf(this.sketchPanel);
                refreshNotes(this.sketchPanel, this.notesArrayList);
            }
            if (e.Button == DeleteNote)
                disableNoteButtons();
            
            // if (e.Button != Dot && e.Button != DeleteNote)
            if (e.Button == Flat)
            {
                Natural.Pushed = false;
                Sharp.Pushed = false;
            }
            if (e.Button == Sharp)
            {
                Natural.Pushed = false;
                Flat.Pushed = false;
            }
            if (e.Button == Natural)
            {
                Sharp.Pushed = false;
                Flat.Pushed = false;
            }
			if (e.Button == Quater)
			{

                disableNoteButtons();
                Cursor.Current = new Cursor(((MainForm)((Sessions)this.parentForm).ParentForm).MainDirectory + @"pictures\notes\note.quater.down.nodash.nodot.noaccidental.ico");
                sketchPanel.Cursor = Cursor.Current;
				this.Quater.Pushed=true;
				
			}
			if (e.Button == Half)
			{
                disableNoteButtons();
                Cursor.Current = new Cursor(((MainForm)((Sessions)this.parentForm).ParentForm).MainDirectory + @"pictures\notes\note.half.down.nodash.nodot.noaccidental.ico");
				sketchPanel.Cursor = Cursor.Current;	
				this.Half.Pushed=true;
			}
			if (e.Button == Whole)
			{
                disableNoteButtons();
                Cursor.Current = new Cursor(((MainForm)((Sessions)this.parentForm).ParentForm).MainDirectory + @"pictures\notes\note.whole.down.nodash.nodot.noaccidental.ico");
				sketchPanel.Cursor = Cursor.Current;	
				this.Whole.Pushed=true;
				
			}
			if (e.Button == eights)
			{
                disableNoteButtons();
                Cursor.Current = new Cursor(((MainForm)((Sessions)this.parentForm).ParentForm).MainDirectory + @"pictures\notes\note.eight.down.nodash.nodot.noaccidental.ico");
				sketchPanel.Cursor = Cursor.Current;	
				this.eights.Pushed=true;
			}
			if (e.Button == sixteens)
			{
                disableNoteButtons();
                Cursor.Current = new Cursor(((MainForm)((Sessions)this.parentForm).ParentForm).MainDirectory + @"pictures\notes\note.sixteen.down.nodash.nodot.noaccidental.ico");
				sketchPanel.Cursor = Cursor.Current;	
				this.sixteens.Pushed=true;
			}
			
		}

		private void sketchPanel_MouseHover(object sender, System.EventArgs e)
		{
			/*Graphics g = sketchPanel.CreateGraphics();
			//g.Clear(Color.White);
			Pen pen=new Pen(new SolidBrush(Color.Black),3);
			if (mouseY< stafLine[3])
			{
				cursorPointsAboveStaf=true;
				//MessageBox.Show("fgsfsdg up aa");
			}
			if (mouseY> stafLine[12])
			{
				//MessageBox.Show("fgsfsdg down aa");
				cursorPointsBelowStaf=true;
				if (mouseY >stafLine[13] && mouseY <stafLine[14])
					g.DrawLine(pen,numberOfNotes*noteWidth+mafteachSol.Size.Width,((stafLine[13]+stafLine[14])/2),numberOfNotes*noteWidth+mafteachSol.Size.Width+noteWidth,((stafLine[13]+stafLine[14])/2));
			}
			sketchPanel.Invalidate();*/
		}

		private void sketchPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			 mouseX = e.X;
			 mouseY = e.Y;

		}

		private void sketchPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = sketchPanel.CreateGraphics();
			g.Clear(Color.White);
			Pen pen=new Pen(new SolidBrush(Color.Black),3);
			Pen penLight=new Pen(new SolidBrush(Color.Gray),2);
			g.DrawRectangle(pen,((numberOfNotes)*noteWidth +mafteachSol.Size.Width),0,noteWidth,sketchPanel.Size.Height);
			g.DrawRectangle(penLight,((numberOfNotes)*noteWidth +mafteachSol.Size.Width),sketchPanel.Size.Height/8 ,noteWidth,sketchPanel.Size.Height*6/8 );

			if (cursorPointsBelowStaf)
			{
				if (mouseY >stafLine[13] && mouseY <stafLine[14])
					g.DrawLine(pen,numberOfNotes*noteWidth+mafteachSol.Size.Width,((stafLine[13]+stafLine[14])/2),numberOfNotes*noteWidth+mafteachSol.Size.Width+noteWidth,((stafLine[13]+stafLine[14])/2));
			}
		//refreshNotes();
		}

        private void FromFileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.BrowseButton.Enabled = true;
            this.FileNameTextBox.Enabled = true;
            disableOrEnableNoteButtons(false);
        }

        private void ComposeNotesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.BrowseButton.Enabled = false;
            this.FileNameTextBox.Enabled = false;
            this.FileNameTextBox.Text = "";
            disableOrEnableNoteButtons(true);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
			//openFileDialog.DefaultExt = "*.*";
			openFileDialog.Filter = "jpg files (*.jpg)|*.jpg"  ;
			//openFileDialog.Filter = "map files (*.map)|*.map|All files(*.*)|*.*"  ;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.FileNameTextBox.Text = openFileDialog.FileName.ToString();

            }	
        }

        private void Finale_Load(object sender, EventArgs e)
        {
            disableOrEnableNoteButtons(false);
        }
	}
    [Serializable]
	public class Note
	{
		public Point p;
		public int type;
		public int direction;
		public int dashed;
        public int noteIndex;
        public int doted;
        public int accidental;
	}
}
