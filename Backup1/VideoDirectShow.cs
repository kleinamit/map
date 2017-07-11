using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using DShowNET;
using System.Timers;

namespace musicTherapy1
{
	
	/******************************************************
				  DirectShow .NET
			  netmaster@swissonline.ch
*******************************************************/
	//					PlayWndNET MainForm

		/// <summary> MainForm for this sample media file player. </summary>
		public class VideoDirectShow : System.Windows.Forms.Form
		{
			private System.Windows.Forms.MainMenu mainMenu1;
			private System.Windows.Forms.MenuItem menuTopFile;
			private System.Windows.Forms.MenuItem menuFileOpenClip;
			private System.Windows.Forms.MenuItem menuFileCloseClip;
			private System.Windows.Forms.MenuItem menuFileExit;
			private System.Windows.Forms.MenuItem menuTopControl;
			private System.Windows.Forms.MenuItem menuControlPause;
			private System.Windows.Forms.MenuItem menuControlStop;
			private System.Windows.Forms.MenuItem menuControlMute;
			private System.Windows.Forms.MenuItem menuControlStep;
			private System.Windows.Forms.MenuItem menuControlHalf;
			private System.Windows.Forms.MenuItem menuControlThreeQ;
			private System.Windows.Forms.MenuItem menuControlNormal;
			private System.Windows.Forms.MenuItem menuControlDouble;
			private System.Windows.Forms.MenuItem menuControlFullScr;
			private System.Windows.Forms.MenuItem menuTopRate;
			private System.Windows.Forms.MenuItem menuRateIncr;
			private System.Windows.Forms.MenuItem menuRateDecr;
			private System.Windows.Forms.MenuItem menuRateNormal;
			private System.Windows.Forms.MenuItem menuRateHalf;
			private System.Windows.Forms.MenuItem menuRateDouble;
			private System.Windows.Forms.MenuItem menuTopHelp;
			private System.Windows.Forms.MenuItem menuHelpAbout;
			private System.Windows.Forms.MenuItem menuFileSep1;
			private System.Windows.Forms.MenuItem menuControlSep1;
			private System.Windows.Forms.MenuItem menuControlSep2;
			private System.Windows.Forms.MenuItem menuControlSep3;
			private System.Windows.Forms.MenuItem menuRateSep1;
			private System.Windows.Forms.Panel VideoPanel;
			private System.Windows.Forms.TrackBar trackBar1;

			private System.Timers.Timer videoTimer;
			public double CurrentVideoTime=0;
			private System.Windows.Forms.Button ForwardButton;
			private System.Windows.Forms.Button PauseButton;
			private System.Windows.Forms.Button RewindButton;
			private System.Windows.Forms.Button PlatButton;
            private System.Windows.Forms.Panel panel1;
            private IContainer components;
			private int forwardInterval=60;
			private System.Windows.Forms.Label TimeLabel;
			private System.Windows.Forms.Panel panel2;
			private System.Windows.Forms.Panel panel3;
			private System.Windows.Forms.Button stopButton;
			private int rewindInterval = 60;
			private System.Windows.Forms.Label VideoTimeLable;
			private int timerInterval=1000;
            private MenuItem menuItem1;
            private MenuItem menuItem2;
            private MenuItem menuItem3;
            private MenuItem menuItem4;
            private MenuItem menuItem5;
            private MenuItem menuItem6;
            private MenuItem menuItem7;
            private MenuItem menuItem8;
            private MenuItem menuItem9;
            private MenuItem menuItem10;
            private MenuItem menuItem11;
            private MenuItem menuItem12;
            private MenuItem menuItem13;
            private MenuItem menuItem14;
            private MenuItem menuItem15;
            private MenuItem menuItem16;
            private MenuItem menuItem17;
            private MenuItem menuItem18;
            private MenuItem menuItem19;
			private int startPositionOfVideoInSession=0;
            private Button OpenVideo;
            private ToolTip VideoToolTip;
			//public 
			public VideoDirectShow()
			{
				// Required for Windows Form Designer support
				InitializeComponent();
				videoTimer= new System.Timers.Timer();
				videoTimer.Elapsed+=new ElapsedEventHandler(Elapsed_timer);
				videoTimer.Interval=timerInterval;
                VideoToolTip = new ToolTip();
                VideoToolTip.SetToolTip(ForwardButton, "60");
                VideoToolTip.SetToolTip(RewindButton, "60");
                AddContextMenu();


			}

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					CloseInterfaces();
				
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoDirectShow));
                this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
                this.menuTopFile = new System.Windows.Forms.MenuItem();
                this.menuFileOpenClip = new System.Windows.Forms.MenuItem();
                this.menuFileCloseClip = new System.Windows.Forms.MenuItem();
                this.menuFileSep1 = new System.Windows.Forms.MenuItem();
                this.menuFileExit = new System.Windows.Forms.MenuItem();
                this.menuTopControl = new System.Windows.Forms.MenuItem();
                this.menuControlPause = new System.Windows.Forms.MenuItem();
                this.menuControlStop = new System.Windows.Forms.MenuItem();
                this.menuControlMute = new System.Windows.Forms.MenuItem();
                this.menuControlSep1 = new System.Windows.Forms.MenuItem();
                this.menuControlStep = new System.Windows.Forms.MenuItem();
                this.menuControlSep2 = new System.Windows.Forms.MenuItem();
                this.menuControlHalf = new System.Windows.Forms.MenuItem();
                this.menuControlThreeQ = new System.Windows.Forms.MenuItem();
                this.menuControlNormal = new System.Windows.Forms.MenuItem();
                this.menuControlDouble = new System.Windows.Forms.MenuItem();
                this.menuControlSep3 = new System.Windows.Forms.MenuItem();
                this.menuControlFullScr = new System.Windows.Forms.MenuItem();
                this.menuTopRate = new System.Windows.Forms.MenuItem();
                this.menuRateIncr = new System.Windows.Forms.MenuItem();
                this.menuRateDecr = new System.Windows.Forms.MenuItem();
                this.menuRateSep1 = new System.Windows.Forms.MenuItem();
                this.menuRateNormal = new System.Windows.Forms.MenuItem();
                this.menuRateHalf = new System.Windows.Forms.MenuItem();
                this.menuRateDouble = new System.Windows.Forms.MenuItem();
                this.menuTopHelp = new System.Windows.Forms.MenuItem();
                this.menuHelpAbout = new System.Windows.Forms.MenuItem();
                this.menuItem1 = new System.Windows.Forms.MenuItem();
                this.menuItem2 = new System.Windows.Forms.MenuItem();
                this.menuItem3 = new System.Windows.Forms.MenuItem();
                this.menuItem4 = new System.Windows.Forms.MenuItem();
                this.menuItem5 = new System.Windows.Forms.MenuItem();
                this.menuItem6 = new System.Windows.Forms.MenuItem();
                this.menuItem7 = new System.Windows.Forms.MenuItem();
                this.menuItem8 = new System.Windows.Forms.MenuItem();
                this.menuItem9 = new System.Windows.Forms.MenuItem();
                this.menuItem10 = new System.Windows.Forms.MenuItem();
                this.menuItem11 = new System.Windows.Forms.MenuItem();
                this.menuItem12 = new System.Windows.Forms.MenuItem();
                this.menuItem13 = new System.Windows.Forms.MenuItem();
                this.menuItem14 = new System.Windows.Forms.MenuItem();
                this.menuItem15 = new System.Windows.Forms.MenuItem();
                this.menuItem16 = new System.Windows.Forms.MenuItem();
                this.menuItem17 = new System.Windows.Forms.MenuItem();
                this.menuItem18 = new System.Windows.Forms.MenuItem();
                this.menuItem19 = new System.Windows.Forms.MenuItem();
                this.VideoPanel = new System.Windows.Forms.Panel();
                this.trackBar1 = new System.Windows.Forms.TrackBar();
                this.ForwardButton = new System.Windows.Forms.Button();
                this.stopButton = new System.Windows.Forms.Button();
                this.PauseButton = new System.Windows.Forms.Button();
                this.RewindButton = new System.Windows.Forms.Button();
                this.PlatButton = new System.Windows.Forms.Button();
                this.panel1 = new System.Windows.Forms.Panel();
                this.TimeLabel = new System.Windows.Forms.Label();
                this.panel2 = new System.Windows.Forms.Panel();
                this.OpenVideo = new System.Windows.Forms.Button();
                this.panel3 = new System.Windows.Forms.Panel();
                this.VideoTimeLable = new System.Windows.Forms.Label();
                ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
                this.panel1.SuspendLayout();
                this.panel2.SuspendLayout();
                this.SuspendLayout();
                // 
                // mainMenu1
                // 
                this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuTopFile,
            this.menuTopControl,
            this.menuTopRate,
            this.menuTopHelp,
            this.menuItem1});
                // 
                // menuTopFile
                // 
                this.menuTopFile.Index = 0;
                this.menuTopFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFileOpenClip,
            this.menuFileCloseClip,
            this.menuFileSep1,
            this.menuFileExit});
                this.menuTopFile.Text = "&Video";
                // 
                // menuFileOpenClip
                // 
                this.menuFileOpenClip.Index = 0;
                this.menuFileOpenClip.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
                this.menuFileOpenClip.Text = "&Open Clip...";
                this.menuFileOpenClip.Click += new System.EventHandler(this.menuFileOpenClip_Click);
                // 
                // menuFileCloseClip
                // 
                this.menuFileCloseClip.Enabled = false;
                this.menuFileCloseClip.Index = 1;
                this.menuFileCloseClip.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
                this.menuFileCloseClip.Text = "&Close Clip";
                this.menuFileCloseClip.Click += new System.EventHandler(this.menuFileCloseClip_Click);
                // 
                // menuFileSep1
                // 
                this.menuFileSep1.Index = 2;
                this.menuFileSep1.Text = "-";
                // 
                // menuFileExit
                // 
                this.menuFileExit.Index = 3;
                this.menuFileExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
                this.menuFileExit.Text = "E&xit";
                this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
                // 
                // menuTopControl
                // 
                this.menuTopControl.Index = 1;
                this.menuTopControl.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuControlPause,
            this.menuControlStop,
            this.menuControlMute,
            this.menuControlSep1,
            this.menuControlStep,
            this.menuControlSep2,
            this.menuControlHalf,
            this.menuControlThreeQ,
            this.menuControlNormal,
            this.menuControlDouble,
            this.menuControlSep3,
            this.menuControlFullScr});
                this.menuTopControl.Text = "&Control";
                // 
                // menuControlPause
                // 
                this.menuControlPause.Enabled = false;
                this.menuControlPause.Index = 0;
                this.menuControlPause.Text = "&Pause/Play\tP";
                this.menuControlPause.Click += new System.EventHandler(this.menuControlPause_Click);
                // 
                // menuControlStop
                // 
                this.menuControlStop.Enabled = false;
                this.menuControlStop.Index = 1;
                this.menuControlStop.Text = "&Stop\tS";
                this.menuControlStop.Click += new System.EventHandler(this.menuControlStop_Click);
                // 
                // menuControlMute
                // 
                this.menuControlMute.Enabled = false;
                this.menuControlMute.Index = 2;
                this.menuControlMute.Text = "&Mute/Unmute\tM";
                this.menuControlMute.Click += new System.EventHandler(this.menuControlMute_Click);
                // 
                // menuControlSep1
                // 
                this.menuControlSep1.Index = 3;
                this.menuControlSep1.Text = "-";
                // 
                // menuControlStep
                // 
                this.menuControlStep.Enabled = false;
                this.menuControlStep.Index = 4;
                this.menuControlStep.Text = "Single F&rame Step\t<Space>";
                this.menuControlStep.Click += new System.EventHandler(this.menuControlStep_Click);
                // 
                // menuControlSep2
                // 
                this.menuControlSep2.Index = 5;
                this.menuControlSep2.Text = "-";
                // 
                // menuControlHalf
                // 
                this.menuControlHalf.Enabled = false;
                this.menuControlHalf.Index = 6;
                this.menuControlHalf.RadioCheck = true;
                this.menuControlHalf.Text = "&Half size (50%)\tH";
                this.menuControlHalf.Click += new System.EventHandler(this.menuControlHalf_Click);
                // 
                // menuControlThreeQ
                // 
                this.menuControlThreeQ.Enabled = false;
                this.menuControlThreeQ.Index = 7;
                this.menuControlThreeQ.RadioCheck = true;
                this.menuControlThreeQ.Text = "&Three-quarter size (75%)\tT";
                this.menuControlThreeQ.Click += new System.EventHandler(this.menuControlThreeQ_Click);
                // 
                // menuControlNormal
                // 
                this.menuControlNormal.Enabled = false;
                this.menuControlNormal.Index = 8;
                this.menuControlNormal.RadioCheck = true;
                this.menuControlNormal.Text = "&Normal size (100%)\tN";
                this.menuControlNormal.Click += new System.EventHandler(this.menuControlNormal_Click);
                // 
                // menuControlDouble
                // 
                this.menuControlDouble.Enabled = false;
                this.menuControlDouble.Index = 9;
                this.menuControlDouble.RadioCheck = true;
                this.menuControlDouble.Text = "&Double size (200%)\tD";
                this.menuControlDouble.Click += new System.EventHandler(this.menuControlDouble_Click);
                // 
                // menuControlSep3
                // 
                this.menuControlSep3.Index = 10;
                this.menuControlSep3.Text = "-";
                // 
                // menuControlFullScr
                // 
                this.menuControlFullScr.Enabled = false;
                this.menuControlFullScr.Index = 11;
                this.menuControlFullScr.Text = "&Full screen\t<enter> or F";
                this.menuControlFullScr.Click += new System.EventHandler(this.menuControlFullScr_Click);
                // 
                // menuTopRate
                // 
                this.menuTopRate.Index = 2;
                this.menuTopRate.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuRateIncr,
            this.menuRateDecr,
            this.menuRateSep1,
            this.menuRateNormal,
            this.menuRateHalf,
            this.menuRateDouble});
                this.menuTopRate.Text = "&Rate";
                this.menuTopRate.Click += new System.EventHandler(this.menuTopRate_Click);
                // 
                // menuRateIncr
                // 
                this.menuRateIncr.Enabled = false;
                this.menuRateIncr.Index = 0;
                this.menuRateIncr.Text = "&Increase playback rate\t<Right arrow>";
                this.menuRateIncr.Click += new System.EventHandler(this.menuRateIncr_Click);
                // 
                // menuRateDecr
                // 
                this.menuRateDecr.Enabled = false;
                this.menuRateDecr.Index = 1;
                this.menuRateDecr.Text = "&Decrease playback rate\t<Left arrow>";
                this.menuRateDecr.Click += new System.EventHandler(this.menuRateDecr_Click);
                // 
                // menuRateSep1
                // 
                this.menuRateSep1.Index = 2;
                this.menuRateSep1.Text = "-";
                // 
                // menuRateNormal
                // 
                this.menuRateNormal.Enabled = false;
                this.menuRateNormal.Index = 3;
                this.menuRateNormal.RadioCheck = true;
                this.menuRateNormal.Text = "&Normal playback rate\t<Back>";
                this.menuRateNormal.Click += new System.EventHandler(this.menuRateNormal_Click);
                // 
                // menuRateHalf
                // 
                this.menuRateHalf.Enabled = false;
                this.menuRateHalf.Index = 4;
                this.menuRateHalf.RadioCheck = true;
                this.menuRateHalf.Text = "&Half playback rate\t<Down arrow>";
                this.menuRateHalf.Click += new System.EventHandler(this.menuRateHalf_Click);
                // 
                // menuRateDouble
                // 
                this.menuRateDouble.Enabled = false;
                this.menuRateDouble.Index = 5;
                this.menuRateDouble.RadioCheck = true;
                this.menuRateDouble.Text = "Dou&ble playback rate\t<Up arrow>";
                this.menuRateDouble.Click += new System.EventHandler(this.menuRateDouble_Click);
                // 
                // menuTopHelp
                // 
                this.menuTopHelp.Index = 3;
                this.menuTopHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuHelpAbout});
                this.menuTopHelp.Text = "&Help";
                // 
                // menuHelpAbout
                // 
                this.menuHelpAbout.Index = 0;
                this.menuHelpAbout.Shortcut = System.Windows.Forms.Shortcut.F1;
                this.menuHelpAbout.Text = "&About...";
                this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
                // 
                // menuItem1
                // 
                this.menuItem1.Index = 4;
                this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem11});
                this.menuItem1.Text = "Options";
                // 
                // menuItem2
                // 
                this.menuItem2.Index = 0;
                this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6,
            this.menuItem7,
            this.menuItem8,
            this.menuItem9,
            this.menuItem10});
                this.menuItem2.Text = "Fast forward interval";
                // 
                // menuItem3
                // 
                this.menuItem3.Index = 0;
                this.menuItem3.Text = "10";
                this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
                // 
                // menuItem4
                // 
                this.menuItem4.Index = 1;
                this.menuItem4.Text = "20";
                this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
                // 
                // menuItem5
                // 
                this.menuItem5.Index = 2;
                this.menuItem5.Text = "30";
                this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
                // 
                // menuItem6
                // 
                this.menuItem6.Index = 3;
                this.menuItem6.Text = "40";
                this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
                // 
                // menuItem7
                // 
                this.menuItem7.Index = 4;
                this.menuItem7.Text = "50";
                this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
                // 
                // menuItem8
                // 
                this.menuItem8.Checked = true;
                this.menuItem8.Index = 5;
                this.menuItem8.Text = "60";
                this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
                // 
                // menuItem9
                // 
                this.menuItem9.Index = 6;
                this.menuItem9.Text = "120";
                this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
                // 
                // menuItem10
                // 
                this.menuItem10.Index = 7;
                this.menuItem10.Text = "180";
                this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
                // 
                // menuItem11
                // 
                this.menuItem11.Index = 1;
                this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem12,
            this.menuItem13,
            this.menuItem14,
            this.menuItem15,
            this.menuItem16,
            this.menuItem17,
            this.menuItem18,
            this.menuItem19});
                this.menuItem11.Text = "Rewind interval";
                // 
                // menuItem12
                // 
                this.menuItem12.Index = 0;
                this.menuItem12.Text = "10";
                this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
                // 
                // menuItem13
                // 
                this.menuItem13.Index = 1;
                this.menuItem13.Text = "20";
                this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
                // 
                // menuItem14
                // 
                this.menuItem14.Index = 2;
                this.menuItem14.Text = "30";
                this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
                // 
                // menuItem15
                // 
                this.menuItem15.Index = 3;
                this.menuItem15.Text = "40";
                this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
                // 
                // menuItem16
                // 
                this.menuItem16.Index = 4;
                this.menuItem16.Text = "50";
                this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
                // 
                // menuItem17
                // 
                this.menuItem17.Checked = true;
                this.menuItem17.Index = 5;
                this.menuItem17.Text = "60";
                this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
                // 
                // menuItem18
                // 
                this.menuItem18.Index = 6;
                this.menuItem18.Text = "120";
                this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
                // 
                // menuItem19
                // 
                this.menuItem19.Index = 7;
                this.menuItem19.Text = "180";
                this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
                // 
                // VideoPanel
                // 
                this.VideoPanel.BackColor = System.Drawing.Color.Black;
                this.VideoPanel.Location = new System.Drawing.Point(32, 24);
                this.VideoPanel.Name = "VideoPanel";
                this.VideoPanel.Size = new System.Drawing.Size(200, 100);
                this.VideoPanel.TabIndex = 0;
                // 
                // trackBar1
                // 
                this.trackBar1.Location = new System.Drawing.Point(32, 144);
                this.trackBar1.Name = "trackBar1";
                this.trackBar1.Size = new System.Drawing.Size(192, 45);
                this.trackBar1.TabIndex = 1;
                this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
                // 
                // ForwardButton
                // 
                this.ForwardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                this.ForwardButton.Image = ((System.Drawing.Image)(resources.GetObject("ForwardButton.Image")));
                this.ForwardButton.Location = new System.Drawing.Point(150, 12);
                this.ForwardButton.Name = "ForwardButton";
                this.ForwardButton.Size = new System.Drawing.Size(24, 24);
                this.ForwardButton.TabIndex = 3;
                this.ForwardButton.UseVisualStyleBackColor = false;
                this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
                // 
                // stopButton
                // 
                this.stopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
                this.stopButton.Location = new System.Drawing.Point(116, 12);
                this.stopButton.Name = "stopButton";
                this.stopButton.Size = new System.Drawing.Size(24, 24);
                this.stopButton.TabIndex = 4;
                this.stopButton.UseVisualStyleBackColor = false;
                this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
                // 
                // PauseButton
                // 
                this.PauseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                this.PauseButton.Image = ((System.Drawing.Image)(resources.GetObject("PauseButton.Image")));
                this.PauseButton.Location = new System.Drawing.Point(82, 12);
                this.PauseButton.Name = "PauseButton";
                this.PauseButton.Size = new System.Drawing.Size(24, 24);
                this.PauseButton.TabIndex = 5;
                this.PauseButton.UseVisualStyleBackColor = false;
                this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
                // 
                // RewindButton
                // 
                this.RewindButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                this.RewindButton.Image = ((System.Drawing.Image)(resources.GetObject("RewindButton.Image")));
                this.RewindButton.Location = new System.Drawing.Point(14, 12);
                this.RewindButton.Name = "RewindButton";
                this.RewindButton.Size = new System.Drawing.Size(24, 24);
                this.RewindButton.TabIndex = 6;
                this.RewindButton.UseVisualStyleBackColor = false;
                this.RewindButton.Click += new System.EventHandler(this.RewindButton_Click);
                // 
                // PlatButton
                // 
                this.PlatButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                this.PlatButton.Image = ((System.Drawing.Image)(resources.GetObject("PlatButton.Image")));
                this.PlatButton.Location = new System.Drawing.Point(48, 12);
                this.PlatButton.Name = "PlatButton";
                this.PlatButton.Size = new System.Drawing.Size(24, 24);
                this.PlatButton.TabIndex = 7;
                this.PlatButton.UseVisualStyleBackColor = false;
                this.PlatButton.Click += new System.EventHandler(this.PlatButton_Click);
                // 
                // panel1
                // 
                this.panel1.BackColor = System.Drawing.Color.White;
                this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.panel1.Controls.Add(this.ForwardButton);
                this.panel1.Controls.Add(this.PauseButton);
                this.panel1.Controls.Add(this.PlatButton);
                this.panel1.Controls.Add(this.RewindButton);
                this.panel1.Controls.Add(this.stopButton);
                this.panel1.Location = new System.Drawing.Point(32, 192);
                this.panel1.Name = "panel1";
                this.panel1.Padding = new System.Windows.Forms.Padding(5);
                this.panel1.Size = new System.Drawing.Size(192, 48);
                this.panel1.TabIndex = 8;
                // 
                // TimeLabel
                // 
                this.TimeLabel.BackColor = System.Drawing.Color.White;
                this.TimeLabel.Dock = System.Windows.Forms.DockStyle.Top;
                this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                this.TimeLabel.Location = new System.Drawing.Point(0, 0);
                this.TimeLabel.Name = "TimeLabel";
                this.TimeLabel.Size = new System.Drawing.Size(264, 56);
                this.TimeLabel.TabIndex = 9;
                this.TimeLabel.Text = "00:00:00";
                this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // panel2
                // 
                this.panel2.BackColor = System.Drawing.Color.DarkGray;
                this.panel2.Controls.Add(this.OpenVideo);
                this.panel2.Controls.Add(this.panel3);
                this.panel2.Controls.Add(this.VideoPanel);
                this.panel2.Controls.Add(this.trackBar1);
                this.panel2.Controls.Add(this.panel1);
                this.panel2.Controls.Add(this.VideoTimeLable);
                this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
                this.panel2.Location = new System.Drawing.Point(0, 56);
                this.panel2.Name = "panel2";
                this.panel2.Size = new System.Drawing.Size(264, 233);
                this.panel2.TabIndex = 10;
                // 
                // OpenVideo
                // 
                this.OpenVideo.Location = new System.Drawing.Point(12, 288);
                this.OpenVideo.Name = "OpenVideo";
                this.OpenVideo.Size = new System.Drawing.Size(75, 23);
                this.OpenVideo.TabIndex = 10;
                this.OpenVideo.Text = "Open video";
                this.OpenVideo.UseVisualStyleBackColor = true;
                this.OpenVideo.Click += new System.EventHandler(this.OpenVideo_Click);
                // 
                // panel3
                // 
                this.panel3.BackColor = System.Drawing.Color.Black;
                this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.panel3.Location = new System.Drawing.Point(0, 217);
                this.panel3.Name = "panel3";
                this.panel3.Size = new System.Drawing.Size(264, 16);
                this.panel3.TabIndex = 2;
                // 
                // VideoTimeLable
                // 
                this.VideoTimeLable.BackColor = System.Drawing.Color.White;
                this.VideoTimeLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                this.VideoTimeLable.ForeColor = System.Drawing.Color.DarkGreen;
                this.VideoTimeLable.Location = new System.Drawing.Point(72, 248);
                this.VideoTimeLable.Name = "VideoTimeLable";
                this.VideoTimeLable.Size = new System.Drawing.Size(100, 23);
                this.VideoTimeLable.TabIndex = 9;
                this.VideoTimeLable.Text = "00:00:00";
                // 
                // VideoDirectShow
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.BackColor = System.Drawing.Color.Black;
                this.ClientSize = new System.Drawing.Size(264, 289);
                this.Controls.Add(this.panel2);
                this.Controls.Add(this.TimeLabel);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.KeyPreview = true;
                this.Menu = this.mainMenu1;
                this.Name = "VideoDirectShow";
                this.Text = "Video clip";
                this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VideoDirectShow_FormClosed);
                this.Resize += new System.EventHandler(this.MainForm_Resize);
                this.Activated += new System.EventHandler(this.MainForm_Activated);
                this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
                this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
                this.Load += new System.EventHandler(this.VideoDirectShow_Load);
                ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
                this.panel1.ResumeLayout(false);
                this.panel2.ResumeLayout(false);
                this.panel2.PerformLayout();
                this.ResumeLayout(false);

			}
		#endregion

			/// <summary>
			/// The main entry point for the application.
			/// </summary>
			/*[STAThread]
			static void Main() 
			{
				Application.Run( new MainForm() );
			}*/
            private void AddContextMenu()
            {
                ContextMenu contextMenu = new ContextMenu();
                this.ContextMenu= contextMenu;
                contextMenu.MenuItems.Add(menuItem1);
                ////MenuItem[] dest =new MenuItem[40];
                ////menuItem1.MenuItems.CopyTo(dest, 0);
                //MenuItem item = new MenuItem("fff");
                ////dest.Clone();
                //item.MenuItems.Add(this.menuItem3);
                ////item = menuTopRate;
                contextMenu.MenuItems.Add(this.menuTopRate);
            }
			private void MainForm_Activated(object sender, System.EventArgs e)
			{
				if( firstActive )
					return;
				firstActive = true;

				if( ! DsUtils.IsCorrectDirectXVersion() )
				{
					MessageBox.Show( this, "DirectX 8.1 NOT installed!", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
					this.Close(); return;
				}
			}
			public  void Elapsed_timer(Object sender, ElapsedEventArgs e)
			{
				//CurrentVideoTime++;
				
				double position;
				mediaPos.get_CurrentPosition(out position);	
				CurrentVideoTime = position;
				this.TimeLabel.Text=ConvertSecondsToTime(CurrentVideoTime+startPositionOfVideoInSession);
				this.VideoTimeLable.Text=ConvertSecondsToTime(CurrentVideoTime);
				trackBar1.Value=(int)CurrentVideoTime;
				MainForm tmpForm =(MainForm)this.MdiParent;
				Sessions session = (Sessions)tmpForm.ActiveMdiChild;
				session.refeshVideoPointer((int)CurrentVideoTime);
			
			}
			private string ConvertSecondsToTime(double movieSeconds)
			{
			
				int hours=(int)movieSeconds/3600;
				int minutes=((int)movieSeconds-(3600*hours))/60;
				int seconds=(int)movieSeconds-(3600*hours)-(60*minutes);
				 return String.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
				
			}
			private void menuFileExit_Click( object sender, System.EventArgs e )
			{
				this.Close();
			}
			private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
			{
				CloseInterfaces();
				MainForm tmpParent  =  (MainForm)this.MdiParent;
				tmpParent.videoForm=null;
			}

			private void MainForm_Resize(object sender, System.EventArgs e)
			{
				ResizeVideoWindow();	// also resize video preview
				resizeWindowControls();
			}

			private void menuFileOpenClip_Click(object sender, System.EventArgs e)
			{
				OpenFileDialog af = new OpenFileDialog();
				af.Title = "Open Media File...";
				af.InitialDirectory = @"C:\";//AppDomain.CurrentDomain.BaseDirectory;
				af.Filter = clipFileFilters;
				if( af.ShowDialog() != DialogResult.OK )
					return;

				menuFileCloseClip_Click( null, null );

				clipFile = af.FileName;
				if( ! PlayClip() )
					menuFileCloseClip_Click( null, null );

				UpdatePlaybackMenu();
				UpdateMainTitle();
			}
			public void loadVideoFile(string videoFile, int position/*in half minutes*/,int startPositionInSession)
			{
				
				clipFile = videoFile;
				if( ! PlayClip() )
					menuFileCloseClip_Click( null, null );
				long newPosition= (long)position*60/2;
				mediaPos.put_CurrentPosition(newPosition);
				CurrentVideoTime=newPosition;
				UpdatePlaybackMenu();
				UpdateMainTitle();
				startPositionOfVideoInSession=startPositionInSession*30;
			}
			public void menuFileCloseClip_Click(object sender, System.EventArgs e)
			{
				clipFile = null;
				clipType = ClipType.None;
				CloseInterfaces();
				videoTimer.Stop();
				trackBar1.Value=0;
				UpdatePlaybackMenu();
				UpdateMainTitle();
				InitPlayerWindow();
				this.Refresh();
			}



			/// <summary> start all the interfaces, graphs and preview window. </summary>
			bool PlayClip()
			{
				try 
				{
					CloseInterfaces();
					if( ! GetInterfaces() )
						return false;
				
					CheckClipType();
					if( clipType == ClipType.None )
						return false;

					int hr = mediaEvt.SetNotifyWindow( this.Handle, WM_GRAPHNOTIFY, IntPtr.Zero );
			
					if( (clipType == ClipType.AudioVideo) || (clipType == ClipType.VideoOnly) )
					{
						videoWin.put_Owner( VideoPanel.Handle/*this.Handle*/ );
						videoWin.put_WindowStyle( WS_CHILD | WS_CLIPSIBLINGS | WS_CLIPCHILDREN );

						InitVideoWindow( 1, 1 );
						CheckSizeMenu( menuControlNormal );
						GetFrameStepInterface();
					}
					else
						InitPlayerWindow();
					long duration;

					mediaSeek.GetDuration(out duration);
					this.trackBar1.Maximum=(int)(duration/10000000);
					this.trackBar1.TickFrequency=500;
					hr = mediaCtrl.Run();
					if( hr >= 0 )
					{
						playState = PlayState.Running;
						videoTimer.Start();
					}
					return hr >= 0;
				}
				catch( Exception ee )
				{
					MessageBox.Show( this, "Could not start clip\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
					return false;
				}
			}


			/// <summary> create the used COM components and get the interfaces. </summary>
			bool GetInterfaces()
			{
				Type comtype = null;
				object comobj = null;
				try 
				{
					comtype = Type.GetTypeFromCLSID( Clsid.CaptureGraphBuilder2/*FilterGraph*/ );
					if( comtype == null )
						throw new NotSupportedException( "DirectX (8.1 or higher) not installed?" );
					comobj = Activator.CreateInstance( comtype );
					graphBuilder = (IGraphBuilder) comobj; comobj = null;
			
					int hr = graphBuilder.RenderFile( clipFile, null );
					if( hr < 0 )
						Marshal.ThrowExceptionForHR( hr );

					mediaCtrl	= (IMediaControl)  graphBuilder;
					mediaEvt	= (IMediaEventEx)  graphBuilder;
					mediaSeek	= (IMediaSeeking)  graphBuilder;
					mediaPos	= (IMediaPosition) graphBuilder;

					videoWin	= graphBuilder as IVideoWindow;
					basicVideo	= graphBuilder as IBasicVideo2;
					basicAudio	= graphBuilder as IBasicAudio;
					return true;
				}
				catch( Exception ee )
				{
					MessageBox.Show( this, "Could not get interfaces\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
					return false;
				}
				finally
				{
					if( comobj != null )
						Marshal.ReleaseComObject( comobj ); comobj = null;
				}
			}



			/// <summary> try to get the step interfaces. </summary>
			bool GetFrameStepInterface()
			{
				videoStep = graphBuilder as IVideoFrameStep;
				if( videoStep == null )
					return false;

				// Check if this decoder can step
				int hr = videoStep.CanStep( 0, null );
				if( hr != 0 )
				{
					videoStep = null;
					return false;
				}
				return true;
			}


			/// <summary> try to detect clip type (video/audio) [not reliable]. </summary>
			void CheckClipType()
			{
				if( basicAudio == null )
					clipType = ClipType.None;
				else
					clipType = ClipType.AudioOnly;

				if( (videoWin == null) || (basicVideo == null) )
					return;

				int visible;
				int hr = videoWin.get_Visible( out visible );
				if( hr < 0 )
					return;
				else
				{
					if( basicAudio == null )
						clipType = ClipType.VideoOnly;
					else
						clipType = ClipType.AudioVideo;
				}
			}


			/// <summary> configure video preview window. </summary>
			bool InitVideoWindow( int multiplier, int divider )
			{
				if( basicVideo == null )
					return false;

				int height, width, hr;

				// Read the default video size
				hr = basicVideo.GetVideoSize( out width, out height );
				if( (hr != 0) || (width < 16) || (height < 16) )
					return true;

				// Account for requests of normal, half, or double size
				width  = width  * multiplier / divider;
				height = height * multiplier / divider;
		
				//this.ClientSize = new Size( width, height );
				ResizeVideoWindow();
				return true;
			}

			/// <summary> configure window for audio playback. </summary>
			bool InitPlayerWindow()
			{
			//	this.ClientSize = new Size( 240, 120 );
				resizeWindowControls();
				return true;
			}


			/// <summary> resize preview video window to fill client area. </summary>
			void ResizeVideoWindow()
			{	
				resizeWindowControls();
				
				if( videoWin == null )
					return;
				
				
				Rectangle rc = VideoPanel.ClientRectangle;/*this.ClientRectangle*/;
				int hr = videoWin.SetWindowPosition( 0, 0, rc.Right, rc.Bottom );
		
			}
			private void resizeWindowControls()
			{
				int newWidth=this.Size.Width*80/100;
				int newHeight=newWidth*3/4; //this.Size.Height*40/100;
				this.VideoPanel.Size=new Size(newWidth,newHeight);
				this.VideoPanel.Location=new Point(this.Size.Width*10/100,this.Size.Height*5/100);
				
				trackBar1.Size=new Size(newWidth,this.Size.Height);
				trackBar1.Location = new Point(this.Size.Width*10/100,(this.Size.Height*5/100+newHeight));
				//panel1.Location=new Point(this.Size.Width*10/100,trackBar1.Location.Y+trackBar1.Size.Height+20);
				panel1.Location=new Point((this.Size.Width-panel1.Size.Width)/2,trackBar1.Location.Y+trackBar1.Size.Height+20);
				VideoTimeLable.Location = new Point(panel1.Location.X+ (panel1.Size.Width-VideoTimeLable.Size.Width)/2 ,panel1.Location.Y+panel1.Size.Height+10);
                this.OpenVideo.Location = new Point(VideoTimeLable.Location.X + (VideoTimeLable.Size.Width- OpenVideo.Size.Width )/ 2, VideoTimeLable.Location.Y + VideoTimeLable.Size.Height + 14);

			}

			/// <summary> enable menu items to match current state. </summary>
			void UpdatePlaybackMenu()
			{
				menuFileCloseClip.Enabled = clipFile != null;

				bool enable = playState != PlayState.Init;
				menuControlPause.Enabled	= enable;
				menuControlStop.Enabled		= enable;
				menuControlMute.Enabled		= enable;
				menuControlStep.Enabled		= videoStep != null;

				menuRateIncr.Enabled		= enable;
				menuRateDecr.Enabled		= enable;
				menuRateNormal.Enabled		= enable;
				menuRateHalf.Enabled		= enable;
				menuRateDouble.Enabled		= enable;

				enable = enable && (clipType != ClipType.AudioOnly);
				menuControlHalf.Enabled		= enable;
				menuControlThreeQ.Enabled	= enable;
				menuControlNormal.Enabled	= enable;
				menuControlDouble.Enabled	= enable;
				menuControlFullScr.Enabled	= enable;
			}


			/// <summary> do cleanup and release DirectShow. </summary>
			void CloseInterfaces()
			{
				int hr;
				try 
				{
					if( mediaCtrl != null )
					{
						hr = mediaCtrl.StopWhenReady();
						mediaCtrl = null;
					}

					playState = PlayState.Stopped;

					if( mediaEvt != null )
					{
						hr = mediaEvt.SetNotifyWindow( IntPtr.Zero, WM_GRAPHNOTIFY, IntPtr.Zero );
						mediaEvt = null;
					}

					if( videoWin != null )
					{
						hr = videoWin.put_Visible( DsHlp.OAFALSE );
						hr = videoWin.put_Owner( IntPtr.Zero );
						videoWin = null;
					}

					mediaSeek	= null;
					mediaPos	= null;
					basicVideo	= null;
					videoStep	= null;
					basicAudio	= null;

					if( graphBuilder != null )
						Marshal.ReleaseComObject( graphBuilder ); graphBuilder = null;

					playState = PlayState.Init;
				}
				catch( Exception )
				{}
			}


			/// <summary> override window fn to handle graph events. </summary>
			protected override void WndProc( ref Message m )
			{
				if( m.Msg == WM_GRAPHNOTIFY )
				{
					if( mediaEvt != null )
						OnGraphNotify();
					return;
				}
				base.WndProc( ref m );
			}

			/// <summary> graph event (WM_GRAPHNOTIFY) handler. </summary>
			void OnGraphNotify()
			{
				int p1, p2, hr = 0;
				DsEvCode code;
				do
				{
					hr = mediaEvt.GetEvent( out code, out p1, out p2, 0 );
					if( hr < 0 )
						break;
					hr = mediaEvt.FreeEventParams( code, p1, p2 );
					if( code == DsEvCode.Complete )
						OnClipCompleted();
				}
				while( hr == 0 );
			}

			/// <summary> graph event if clip has finished </summary>
			void OnClipCompleted()
			{
				if( (mediaCtrl == null) || (mediaSeek == null) )
					return;

				DsOptInt64 pos = new DsOptInt64( 0 );
				int hr = mediaSeek.SetPositions( pos, SeekingFlags.AbsolutePositioning, null, SeekingFlags.NoPositioning );
				if( hr == 0 )
					return;
				hr = mediaCtrl.Stop();
				if( hr < 0 )
					return;
				videoTimer.Stop();
				stopButton_Click(null,null);
				//hr = mediaCtrl.Run();
			}

			/// <summary> menu clicked to pause the playback. </summary>
			private void menuControlPause_Click(object sender, System.EventArgs e)
			{
				if( mediaCtrl == null )
					return;

				if( (playState == PlayState.Paused) || (playState == PlayState.Stopped) )
				{
					if( mediaCtrl.Run() == 0 )
					{
						playState = PlayState.Running;
						videoTimer.Start();
					}
				}
				else if( playState == PlayState.Running )
				{
					if( mediaCtrl.Pause() == 0 )
					{
						playState = PlayState.Paused;
						videoTimer.Stop();
					}
				}
				UpdateMainTitle();
			}

			/// <summary> menu clicked to stop the playback. </summary>
			private void menuControlStop_Click(object sender, System.EventArgs e)
			{
				if( (mediaCtrl == null) || (mediaSeek == null) )
					return;

				if( (playState != PlayState.Paused) && (playState != PlayState.Running) )
					return;

				int hr = mediaCtrl.Stop();
				playState = PlayState.Stopped;
				videoTimer.Stop();
				CurrentVideoTime=0;
				DsOptInt64 pos = new DsOptInt64( 0 );
				hr = mediaSeek.SetPositions( pos, SeekingFlags.AbsolutePositioning, null, SeekingFlags.NoPositioning );
				hr = mediaCtrl.Pause();
				UpdateMainTitle();
			}

			/// <summary> menu clicked to mute audio. </summary>
			private void menuControlMute_Click(object sender, System.EventArgs e)
			{
				int hr, currentVolume;

				if( (graphBuilder == null) || (basicAudio == null) )
					return;
				hr = basicAudio.get_Volume( out currentVolume );
				if( hr != 0 )
					return;

				if( currentVolume != -10000 )   // midi may use -9640 ???
				{
					savedVolume = currentVolume;
					currentVolume = -10000;
					menuControlMute.Checked = true;
				}
				else
				{
					currentVolume = savedVolume;
					menuControlMute.Checked = false;
				}

				hr = basicAudio.put_Volume( currentVolume );
				hr += 1;
			}

			/// <summary> menu clicked to step one frame. </summary>
			private void menuControlStep_Click(object sender, System.EventArgs e)
			{
				int hr;
				if( (videoStep == null) || (mediaCtrl == null) )
					return;
				if( playState != PlayState.Paused )
					hr = mediaCtrl.Pause();
				playState = PlayState.Paused;
				hr = videoStep.Step( 1, null );
			}

			/// <summary> step n-numbers of frames in stream. </summary>
			private void StepFrames( int frames )
			{
				int hr;
				if( (videoStep == null) || (mediaCtrl == null) )
					return;
				hr = videoStep.CanStep( frames, null );
				if( hr != 0 )
					return;
				if( playState != PlayState.Paused )
					hr = mediaCtrl.Pause();
				playState = PlayState.Paused;
				hr = videoStep.Step( frames, null );
			}



			private void menuControlHalf_Click(object sender, System.EventArgs e)
			{
				InitVideoWindow( 1, 2 );
				CheckSizeMenu( menuControlHalf );
			}
			private void menuControlThreeQ_Click(object sender, System.EventArgs e)
			{
				InitVideoWindow( 3, 4 );
				CheckSizeMenu( menuControlThreeQ );
			}

			private void menuControlNormal_Click(object sender, System.EventArgs e)
			{
				InitVideoWindow( 1, 1 );
				CheckSizeMenu( menuControlNormal );
			}

			private void menuControlDouble_Click(object sender, System.EventArgs e)
			{
				InitVideoWindow( 2, 1 );
				CheckSizeMenu( menuControlDouble );
			}
			void CheckSizeMenu( MenuItem checkItem )
			{
				menuControlHalf.Checked		= checkItem == menuControlHalf;
				menuControlThreeQ.Checked	= checkItem == menuControlThreeQ;
				menuControlNormal.Checked	= checkItem == menuControlNormal;
				menuControlDouble.Checked	= checkItem == menuControlDouble;
			}


			private void menuControlFullScr_Click(object sender, System.EventArgs e)
			{
				ToggleFullScreen();
			}

			private void menuRateIncr_Click(object sender, System.EventArgs e)
			{
				ModifyRate( 0.25 );
			}
			private void menuRateDecr_Click(object sender, System.EventArgs e)
			{
				ModifyRate( -0.25 );
			}
			private void menuRateNormal_Click(object sender, System.EventArgs e)
			{
				SetRate( 1.0 );
			}
			private void menuRateHalf_Click(object sender, System.EventArgs e)
			{
				SetRate( 0.5 );
			}
			private void menuRateDouble_Click(object sender, System.EventArgs e)
			{
				SetRate( 2.0 );
			}


			void ModifyRate( double rateAdjust )
			{
				if( (mediaPos == null) || (rateAdjust == 0.0) )
					return;
				
				
				double rate;
				int hr = mediaPos.get_Rate( out rate );
				if( hr < 0 )
					return;
				rate += rateAdjust;
				if (rate>=1 && rate <2 )
					timerInterval=(int) (1000 -  ((double)1000*(rate-1)));
				else if (rate>=2  )
					timerInterval=(int)((double)1000/rate);
				else if (rate<=-1 && rate >-2 )
					timerInterval=(int) (1000 -  ((double)1000*(rate+1)));
				else if (rate<=-2  )
					timerInterval=(int)((double)1000/rate)*(-1);
				else if (rate >0 && rate <1)
					timerInterval=(int)((double)1000/rate);
				else if (rate <0 && rate >-1)
					timerInterval=(int)((double)1000/rate)*(-1);


				videoTimer.Interval=timerInterval;
				hr = mediaPos.put_Rate( rate );
			}
			void SetRate( double newRate )
			{
				if( mediaPos == null )
					return;
				if (newRate>1)
					timerInterval=(int)((double)1000/newRate);
				else if (newRate<1)
					timerInterval=(int)((double)1000*newRate);
				else 
					timerInterval=1000;
				videoTimer.Interval=timerInterval;
				int hr = mediaPos.put_Rate( newRate );
			}




			/// <summary> update caption text of this form. </summary>
			void UpdateMainTitle()
			{
				if( clipFile == null )
				{
					this.Text = "Video clip";
					return;
				}

                string txt = Path.GetFileName(clipFile);// +" : " + clipType.ToString();
				if( playState == PlayState.Paused )
					txt = txt + " -Paused-";
				this.Text = txt;
			}

	
			/// <summary> keyboard handling for shortcuts. </summary>
			private void MainForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if( playState == PlayState.Init )
					return;

				switch( e.KeyCode )
				{
					case Keys.P:
					{	menuControlPause_Click( null, null ); break; }
					case Keys.S:
					{	menuControlStop_Click( null, null ); break; }
					case Keys.M:
					{	menuControlMute_Click( null, null ); break; }

					case Keys.D1:
					case Keys.Space:
					{	menuControlStep_Click( null, null ); break; }
					case Keys.D2:
					{	StepFrames( 2 ); break; }
					case Keys.D3:
					{	StepFrames( 3 ); break; }
					case Keys.D4:
					{	StepFrames( 4 ); break; }
					case Keys.D5:
					{	StepFrames( 5 ); break; }
					case Keys.D6:
					{	StepFrames( 6 ); break; }
					case Keys.D7:
					{	StepFrames( 7 ); break; }
					case Keys.D8:
					{	StepFrames( 8 ); break; }
					case Keys.D9:
					{	StepFrames( 9 ); break; }

					case Keys.H:
					{	menuControlHalf_Click( null, null ); break; }
					case Keys.T:
					{	menuControlThreeQ_Click( null, null ); break; }
					case Keys.N:
					{	menuControlNormal_Click( null, null ); break; }
					case Keys.D:
					{	menuControlDouble_Click( null, null ); break; }

					case Keys.F:
					{	ToggleFullScreen(); break; }
					case Keys.Enter:
					{	ToggleFullScreen(); break; }
					case Keys.Escape:
					{
						if( fullScreen )
							ToggleFullScreen();
						break;
					}

					case Keys.Left:
					{	menuRateDecr_Click( null, null ); break; }
					case Keys.Right:
					{	menuRateIncr_Click( null, null ); break; }
					case Keys.Up:
					{	menuRateDouble_Click( null, null ); break; }
					case Keys.Down:
					{	menuRateHalf_Click( null, null ); break; }
					case Keys.Back:
					{	menuRateNormal_Click( null, null ); break; }
				}
			}

			/// <summary> full-screen toggle. </summary>
			void ToggleFullScreen()
			{
				if( (clipType != ClipType.VideoOnly) && (clipType != ClipType.AudioVideo) )
					return;
				if( videoWin == null )
					return;

				int mode;
				int hr = videoWin.get_FullScreenMode( out mode );
				if( mode == DsHlp.OAFALSE )
				{
					hr = videoWin.get_MessageDrain( out drainWin );
					hr = videoWin.put_MessageDrain( this.Handle );
					mode = DsHlp.OATRUE;
					hr = videoWin.put_FullScreenMode( mode );
					if( hr >= 0 )
						fullScreen = true;
				}
				else
				{
					mode = DsHlp.OAFALSE;
					hr = videoWin.put_FullScreenMode( mode );
					if( hr >= 0 )
						fullScreen = false;
					hr = videoWin.put_MessageDrain( drainWin );
					this.BringToFront();
					this.Refresh();
				}
			}

			private void menuHelpAbout_Click( object sender, System.EventArgs e )
			{
				MessageBox.Show( this, "Presented by:\r\nNETMaster", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Information );
			}


			/// <summary> file name of clip. </summary>
			private	string					clipFile;

			/// <summary> flag to detect first Form appearance </summary>
			private bool					firstActive;

			/// <summary> type of clip, video / audio. </summary>
			private	ClipType				clipType;
			private	PlayState				playState;
			private	bool					fullScreen;

			private IGraphBuilder			graphBuilder;

			/// <summary> control interface. </summary>
			private IMediaControl			mediaCtrl;

			/// <summary> graph event interface. </summary>
			private IMediaEventEx			mediaEvt;

			/// <summary> seek interface for positioning in stream. </summary>
			private IMediaSeeking			mediaSeek;
			/// <summary> seek interface to set position in stream. </summary>
			private IMediaPosition			mediaPos;

			/// <summary> video preview window interface. </summary>
			private IVideoWindow			videoWin;
			/// <summary> interface to get information and control video. </summary>
			private IBasicVideo2			basicVideo;
			/// <summary> interface to single-step video. </summary>
			private IVideoFrameStep			videoStep;

			/// <summary> audio interface used to control volume. </summary>
			private IBasicAudio				basicAudio;
			private int						savedVolume = -5000;
			private IntPtr					drainWin;


			private const int WM_GRAPHNOTIFY	= 0x00008001;	// message from graph

			private const int WS_CHILD			= 0x40000000;	// attributes for video window
			private const int WS_CLIPCHILDREN	= 0x02000000;
			private const int WS_CLIPSIBLINGS	= 0x04000000;

			private const string clipFileFilters =
				"Video Files (avi qt mov mpg mpeg m1v)|*.avi;*.qt;*.mov;*.mpg;*.mpeg;*.m1v|" +
				"Audio files (wav mpa mp2 mp3 au aif aiff snd)|*.wav;*.mpa;*.mp2;*.mp3;*.au;*.aif;*.aiff;*.snd|" +
				"MIDI Files (mid midi rmi)|*.mid;*.midi;*.rmi|" +
				"Image Files (jpg bmp gif tga)|*.jpg;*.bmp;*.gif;*.tga|" +
				"All Files (*.*)|*.*";

			private void VideoDirectShow_Load(object sender, System.EventArgs e)
			{
				resizeWindowControls();
			}

			private void trackBar1_Scroll(object sender, System.EventArgs e)
			{
				if (mediaPos ==null)
					return;
				mediaPos.put_CurrentPosition((long)trackBar1.Value);
				CurrentVideoTime=trackBar1.Value;
				this.TimeLabel.Text=ConvertSecondsToTime(CurrentVideoTime+startPositionOfVideoInSession);
				this.VideoTimeLable.Text=ConvertSecondsToTime(CurrentVideoTime);
			}

			private void ForwardButton_Click(object sender, System.EventArgs e)
			{
				double CurrentPosition;
				double duration;
				mediaPos.get_Duration(out duration);
				mediaPos.get_CurrentPosition(out CurrentPosition);
				if (CurrentPosition+forwardInterval>=duration)
				{
					this.stopButton_Click(null,null);
					return;
				}
				
				mediaPos.put_CurrentPosition(CurrentPosition+(long)forwardInterval);
				CurrentVideoTime=CurrentPosition+forwardInterval;
				this.trackBar1.Value=(int)CurrentVideoTime;
				this.TimeLabel.Text=ConvertSecondsToTime(CurrentVideoTime+startPositionOfVideoInSession);
				this.VideoTimeLable.Text=ConvertSecondsToTime(CurrentVideoTime);
			}

			private void RewindButton_Click(object sender, System.EventArgs e)
			{
				
				double CurrentPosition;
				mediaPos.get_CurrentPosition(out CurrentPosition);
				if (CurrentPosition<=rewindInterval)
				{
					mediaPos.put_CurrentPosition(0);
					CurrentVideoTime=0;
					this.TimeLabel.Text=ConvertSecondsToTime(0+startPositionOfVideoInSession);
					this.VideoTimeLable.Text=ConvertSecondsToTime(0);
					this.trackBar1.Value=(int)CurrentVideoTime;
				}
				else
				{
					mediaPos.put_CurrentPosition(CurrentPosition-(long)rewindInterval);
					CurrentVideoTime=CurrentPosition-rewindInterval;
					this.TimeLabel.Text=ConvertSecondsToTime(CurrentVideoTime+startPositionOfVideoInSession);
					this.VideoTimeLable.Text=ConvertSecondsToTime(CurrentVideoTime);
					this.trackBar1.Value=(int)CurrentVideoTime;
				}
				
			}

			private void PlatButton_Click(object sender, System.EventArgs e)
			{
				if( mediaCtrl.Run() == 0 )
				{
					playState = PlayState.Running;
					videoTimer.Start();
				}
				UpdateMainTitle();
			}

			private void PauseButton_Click(object sender, System.EventArgs e)
			{
				if( mediaCtrl.Pause() == 0 )
				{
					playState = PlayState.Paused;
					videoTimer.Stop();
				}
				UpdateMainTitle();
			}

			private void stopButton_Click(object sender, System.EventArgs e)
			{
				int hr = mediaCtrl.Stop();
				playState = PlayState.Stopped;
				videoTimer.Stop();
				trackBar1.Value=0;
				this.CurrentVideoTime=0;
				this.TimeLabel.Text=ConvertSecondsToTime(CurrentVideoTime+startPositionOfVideoInSession);
				this.VideoTimeLable.Text=ConvertSecondsToTime(CurrentVideoTime);
				DsOptInt64 pos = new DsOptInt64( 0 );
				hr = mediaSeek.SetPositions( pos, SeekingFlags.AbsolutePositioning, null, SeekingFlags.NoPositioning );
				hr = mediaCtrl.Pause();
				UpdateMainTitle();
			}
            private void UnCheckFastForwardMenuItems()
            {
                menuItem3.Checked = false;
                menuItem4.Checked = false;
                menuItem5.Checked = false;
                menuItem6.Checked = false;
                menuItem7.Checked = false;
                menuItem8.Checked = false;
                menuItem9.Checked = false;
            }
            private void UnChekRewindMenuItems()
            {
                menuItem12.Checked = false;
                menuItem13.Checked = false;
                menuItem14.Checked = false;
                menuItem15.Checked = false;
                menuItem16.Checked = false;
                menuItem17.Checked = false;
                menuItem18.Checked = false;
            
            }
            private void menuItem3_Click(object sender, EventArgs e)
            {
                forwardInterval = 10;
                UnCheckFastForwardMenuItems();
                VideoToolTip.SetToolTip(ForwardButton, "10");
                menuItem3.Checked = true;
            }

            private void menuItem9_Click(object sender, EventArgs e)
            {
                forwardInterval = 120;
                UnCheckFastForwardMenuItems();
                VideoToolTip.SetToolTip(ForwardButton, "120");
                menuItem9.Checked = true;
            }

            private void menuItem4_Click(object sender, EventArgs e)
            {
                forwardInterval = 20;
                UnCheckFastForwardMenuItems();
                VideoToolTip.SetToolTip(ForwardButton, "20");
                menuItem4.Checked = true;
            }

            private void menuItem5_Click(object sender, EventArgs e)
            {
                forwardInterval = 30;
                UnCheckFastForwardMenuItems();
                VideoToolTip.SetToolTip(ForwardButton, "30");
                menuItem5.Checked = true;
            }

            private void menuItem6_Click(object sender, EventArgs e)
            {
                forwardInterval = 40;
                UnCheckFastForwardMenuItems();
                VideoToolTip.SetToolTip(ForwardButton, "40");
                menuItem6.Checked = true;
            }

            private void menuItem7_Click(object sender, EventArgs e)
            {
                forwardInterval = 50;
                UnCheckFastForwardMenuItems();
                VideoToolTip.SetToolTip(ForwardButton, "50");
                menuItem7.Checked = true;
            }

            private void menuItem8_Click(object sender, EventArgs e)
            {
                forwardInterval = 60;
                UnCheckFastForwardMenuItems();
                VideoToolTip.SetToolTip(ForwardButton, "60");
                menuItem8.Checked = true;
            }

            private void menuItem10_Click(object sender, EventArgs e)
            {
                forwardInterval = 180;
                UnCheckFastForwardMenuItems();
                VideoToolTip.SetToolTip(ForwardButton, "180");
                menuItem10.Checked = true;
            }

            private void menuItem12_Click(object sender, EventArgs e)
            {
                rewindInterval = 10;
                UnChekRewindMenuItems();
                VideoToolTip.SetToolTip(RewindButton, "10");
                menuItem12.Checked = true;
            }

            private void menuItem13_Click(object sender, EventArgs e)
            {
                rewindInterval = 20;
                UnChekRewindMenuItems();
                VideoToolTip.SetToolTip(RewindButton, "20");
                menuItem13.Checked = true;
            }

            private void menuItem14_Click(object sender, EventArgs e)
            {
                rewindInterval = 30;
                UnChekRewindMenuItems();
                VideoToolTip.SetToolTip(RewindButton, "30");
                menuItem14.Checked = true;
            }

            private void menuItem15_Click(object sender, EventArgs e)
            {
                rewindInterval = 40;
                UnChekRewindMenuItems();
                VideoToolTip.SetToolTip(RewindButton, "40");
                menuItem15.Checked = true;
            }

            private void menuItem16_Click(object sender, EventArgs e)
            {
                rewindInterval = 50;
                UnChekRewindMenuItems();
                VideoToolTip.SetToolTip(RewindButton, "50");
                menuItem16.Checked = true;
            }

            private void menuItem17_Click(object sender, EventArgs e)
            {
                rewindInterval = 60;
                UnChekRewindMenuItems();
                VideoToolTip.SetToolTip(RewindButton, "60");
                menuItem17.Checked = true;
            }

            private void menuItem18_Click(object sender, EventArgs e)
            {
                rewindInterval = 120;
                UnChekRewindMenuItems();
                VideoToolTip.SetToolTip(RewindButton, "120");
                menuItem18.Checked = true;
            }

            private void menuItem19_Click(object sender, EventArgs e)
            {
                MenuItem aa = (MenuItem)sender;
                UnChekRewindMenuItems();
                VideoToolTip.SetToolTip(RewindButton, "180");
                aa.Checked = true;
                rewindInterval = 180;
            }

            private void OpenVideo_Click(object sender, EventArgs e)
            {
                menuFileOpenClip_Click(null, null);
            }

            private void VideoDirectShow_FormClosed(object sender, FormClosedEventArgs e)
            {
                MainForm fr = (MainForm)this.MdiParent;
                if (fr.SessionsArray[0] != null)
                {
                    fr.SessionsArray[0].Size = new Size(fr.Size.Width, fr.Size.Height);
                    fr.SessionsArray[0].Location = new Point(0, 0);
                }
            }

            private void menuTopRate_Click(object sender, EventArgs e)
            {

            }

            

           

		}

		internal enum PlayState
		{
			Init, Stopped, Paused, Running
		}

		internal enum ClipType
		{
			None, AudioVideo, VideoOnly, AudioOnly
		}


	

	/// <summary>
	/// Summary description for VideoDirectShow.
	/// </summary>
	/*public class VideoDirectShow
	{
		
		
		public VideoDirectShow()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}*/
}
