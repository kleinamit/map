using System.Drawing;
using System.Windows.Forms;

namespace musicTherapy1
{
    /// <summary>
    /// Summary description for RichText.
    /// </summary>
    public class RichText : System.Windows.Forms.Form
	{
		public System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Button OK;
		public int MaximumLength=60;
		private System.Windows.Forms.RichTextBox AdditionalTextRichTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton Color;
		private System.Windows.Forms.ToolBarButton BoldButton;
		private System.Windows.Forms.ToolBarButton ItalicButton;
		private System.Windows.Forms.ToolBarButton UnderLineButton;
		private System.Windows.Forms.ToolBarButton LeftButton;
		private System.Windows.Forms.ToolBarButton CenterButton;
		private System.Windows.Forms.ToolBarButton RifhtButton;
	
		public RichTextBox MainText
		{
			get 
			{
				return this.richTextBox1;
			}
		}
		public string RTF
		{
			get 
			{
				return this.richTextBox1.Rtf;
			}
			set
			{
				this.richTextBox1.Rtf=value;
			}
		}
		public string MainTextUpdate
		{
			get
			{
				return this.richTextBox1.Text;
			}
			set
			{
				this.richTextBox1.Text=value;
			}
		}
		public string AdditionalText
		{
			get 
			{
				return this.AdditionalTextRichTextBox.Text;
			}
			set
			{
				this.AdditionalTextRichTextBox.Text=value;
			}
		}
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RichText()
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.Cancel = new System.Windows.Forms.Button();
			this.OK = new System.Windows.Forms.Button();
			this.AdditionalTextRichTextBox = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.Color = new System.Windows.Forms.ToolBarButton();
			this.BoldButton = new System.Windows.Forms.ToolBarButton();
			this.ItalicButton = new System.Windows.Forms.ToolBarButton();
			this.UnderLineButton = new System.Windows.Forms.ToolBarButton();
			this.LeftButton = new System.Windows.Forms.ToolBarButton();
			this.CenterButton = new System.Windows.Forms.ToolBarButton();
			this.RifhtButton = new System.Windows.Forms.ToolBarButton();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(24, 136);
			this.richTextBox1.MaxLength = 60;
			this.richTextBox1.Multiline = false;
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(424, 24);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(256, 304);
			this.Cancel.Name = "Cancel";
			this.Cancel.TabIndex = 7;
			this.Cancel.Text = "Cancel";
			// 
			// OK
			// 
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Location = new System.Drawing.Point(352, 304);
			this.OK.Name = "OK";
			this.OK.TabIndex = 8;
			this.OK.Text = "OK";
			// 
			// AdditionalTextRichTextBox
			// 
			this.AdditionalTextRichTextBox.Location = new System.Drawing.Point(24, 232);
			this.AdditionalTextRichTextBox.Name = "AdditionalTextRichTextBox";
			this.AdditionalTextRichTextBox.Size = new System.Drawing.Size(424, 64);
			this.AdditionalTextRichTextBox.TabIndex = 9;
			this.AdditionalTextRichTextBox.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.label1.Location = new System.Drawing.Point(24, 104);
			this.label1.Name = "label1";
			this.label1.TabIndex = 10;
			this.label1.Text = "Main text";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.label2.Location = new System.Drawing.Point(24, 192);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 23);
			this.label2.TabIndex = 11;
			this.label2.Text = "Additional text";
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.BoldButton,
																						this.ItalicButton,
																						this.UnderLineButton,
																						this.Color,
																						this.LeftButton,
																						this.CenterButton,
																						this.RifhtButton});
			this.toolBar1.ButtonSize = new System.Drawing.Size(36, 36);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(472, 39);
			this.toolBar1.TabIndex = 12;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// Color
			// 
			this.Color.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			// 
			// BoldButton
			// 
			this.BoldButton.Text = "B";
			// 
			// ItalicButton
			// 
			this.ItalicButton.Text = "I";
			// 
			// UnderLineButton
			// 
			this.UnderLineButton.Text = "U";
			// 
			// LeftButton
			// 
			this.LeftButton.Text = "L";
			// 
			// CenterButton
			// 
			this.CenterButton.Text = "C";
			// 
			// RifhtButton
			// 
			this.RifhtButton.Text = "R";
			// 
			// RichText
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 358);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.toolBar1,
																		  this.label2,
																		  this.label1,
																		  this.AdditionalTextRichTextBox,
																		  this.OK,
																		  this.Cancel,
																		  this.richTextBox1});
			this.Name = "RichText";
			this.Text = "RichText";
			this.Load += new System.EventHandler(this.RichText_Load);
			this.ResumeLayout(false);

		}
		#endregion

		

		private void RichText_Load(object sender, System.EventArgs e)
		{
			this.richTextBox1.MaxLength=MaximumLength;
			AddColorMenu();
		}

		public void AddColorMenu()
		{
			ContextMenu contextMenu = new ContextMenu();
			this.Color.DropDownMenu = contextMenu;
			
			MenuItem chanhePanelColor = new MenuItem("Change panel color");
			MenuItem chanheFrameColor = new MenuItem("Change frame color");
			
			//chanheFrameColor.Click += new System.EventHandler(this.changeFrameColor_Click);
			//chanhePanelColor.Click += new System.EventHandler(this.changePanelColor_Click);
			
			contextMenu.MenuItems.Add(chanheFrameColor);
			contextMenu.MenuItems.Add(chanhePanelColor);

		}
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == BoldButton)
			{
				Font fontOfSelectedText = this.richTextBox1.SelectionFont;
				FontStyle styleApplied;

				if( this.richTextBox1.SelectionFont.Bold == true )
					styleApplied = FontStyle.Regular;
				else
					styleApplied = FontStyle.Bold;

				Font FontToApply = new Font(fontOfSelectedText, styleApplied);
				this.richTextBox1.SelectionFont = FontToApply;

			}
			if (e.Button == ItalicButton)
			{
				Font fontOfSelectedText = this.richTextBox1.SelectionFont;
				FontStyle styleApplied;

				if( this.richTextBox1.SelectionFont.Italic == true )
					styleApplied = FontStyle.Regular;
				else
					styleApplied = FontStyle.Italic;

				Font FontToApply = new Font(fontOfSelectedText, styleApplied);
				this.richTextBox1.SelectionFont = FontToApply;
			}
			if (e.Button == UnderLineButton)
			{
				Font fontOfSelectedText = this.richTextBox1.SelectionFont;
				FontStyle styleApplied;

				if( this.richTextBox1.SelectionFont.Underline == true )
					styleApplied = FontStyle.Regular;
				else
					styleApplied = FontStyle.Underline;

				Font FontToApply = new Font(fontOfSelectedText, styleApplied);
				this.richTextBox1.SelectionFont = FontToApply;
			}
			if (e.Button == CenterButton)
			{
				this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
			}
			if (e.Button == LeftButton)
				this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
			if (e.Button == RifhtButton)
				this.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;

		}

		
	}
}
