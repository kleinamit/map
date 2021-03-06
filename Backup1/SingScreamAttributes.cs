using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace musicTherapy1
{
	/// <summary>
	/// Summary description for SingScreamAttributes.
	/// </summary>
	public class SingScreamAttributes : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DomainUpDown FrequencyUpDown;
		private System.Windows.Forms.Label FrequencyLable;
		private System.Windows.Forms.Panel ColorPanel;
		private System.Windows.Forms.Label AmplitudeLabel1;
		private System.Windows.Forms.Button ChangeColorButton;
		private System.Windows.Forms.NumericUpDown AmplitudeUpDown1;
		
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown WidthNumericUpDown;
		private System.Windows.Forms.NumericUpDown PhaseNumericUpDown;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Color SingColor
		{
			get { return this.ColorPanel.BackColor; }
		}
		public int Frequncy
		{
			get 
			{
				return this.FrequencyUpDown.SelectedIndex;
			}
		}
		public int Amplitude
		{
			get 
			{
				return (int)this.AmplitudeUpDown1.Value;
			}
		}
		public int Phase
		{
			get
			{
				return (int)this.PhaseNumericUpDown.Value;
			}
		}
		 public int WidthOfSingScream //OfSingScream
		{
			get
			{
				return (int)this.WidthNumericUpDown.Value;
				}
		}
		public SingScreamAttributes()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			FrequencyUpDown.SelectedIndex=2;
			AmplitudeUpDown1.Value=10;
			ColorPanel.BackColor = Color.Black;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingScreamAttributes));
            this.FrequencyUpDown = new System.Windows.Forms.DomainUpDown();
            this.FrequencyLable = new System.Windows.Forms.Label();
            this.ColorPanel = new System.Windows.Forms.Panel();
            this.ChangeColorButton = new System.Windows.Forms.Button();
            this.AmplitudeUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.AmplitudeLabel1 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.WidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.PhaseNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AmplitudeUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhaseNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // FrequencyUpDown
            // 
            this.FrequencyUpDown.Items.Add("High ");
            this.FrequencyUpDown.Items.Add("Mid ");
            this.FrequencyUpDown.Items.Add("Low");
            this.FrequencyUpDown.Location = new System.Drawing.Point(15, 32);
            this.FrequencyUpDown.Name = "FrequencyUpDown";
            this.FrequencyUpDown.Size = new System.Drawing.Size(83, 20);
            this.FrequencyUpDown.TabIndex = 1;
            // 
            // FrequencyLable
            // 
            this.FrequencyLable.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FrequencyLable.Location = new System.Drawing.Point(14, 14);
            this.FrequencyLable.Name = "FrequencyLable";
            this.FrequencyLable.Size = new System.Drawing.Size(100, 23);
            this.FrequencyLable.TabIndex = 2;
            this.FrequencyLable.Text = "Frequency";
            // 
            // ColorPanel
            // 
            this.ColorPanel.Location = new System.Drawing.Point(154, 267);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(55, 24);
            this.ColorPanel.TabIndex = 3;
            // 
            // ChangeColorButton
            // 
            this.ChangeColorButton.Location = new System.Drawing.Point(15, 267);
            this.ChangeColorButton.Name = "ChangeColorButton";
            this.ChangeColorButton.Size = new System.Drawing.Size(133, 23);
            this.ChangeColorButton.TabIndex = 4;
            this.ChangeColorButton.Text = "Change color";
            this.ChangeColorButton.Click += new System.EventHandler(this.ChangeColorButton_Click);
            // 
            // AmplitudeUpDown1
            // 
            this.AmplitudeUpDown1.Location = new System.Drawing.Point(17, 152);
            this.AmplitudeUpDown1.Name = "AmplitudeUpDown1";
            this.AmplitudeUpDown1.Size = new System.Drawing.Size(83, 20);
            this.AmplitudeUpDown1.TabIndex = 5;
            this.AmplitudeUpDown1.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.AmplitudeUpDown1.ValueChanged += new System.EventHandler(this.AmplitudeUpDown1_ValueChanged);
            // 
            // AmplitudeLabel1
            // 
            this.AmplitudeLabel1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AmplitudeLabel1.Location = new System.Drawing.Point(16, 133);
            this.AmplitudeLabel1.Name = "AmplitudeLabel1";
            this.AmplitudeLabel1.Size = new System.Drawing.Size(100, 23);
            this.AmplitudeLabel1.TabIndex = 6;
            this.AmplitudeLabel1.Text = "Amplitude";
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(134, 29);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "OK";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // WidthNumericUpDown
            // 
            this.WidthNumericUpDown.Location = new System.Drawing.Point(17, 90);
            this.WidthNumericUpDown.Name = "WidthNumericUpDown";
            this.WidthNumericUpDown.Size = new System.Drawing.Size(83, 20);
            this.WidthNumericUpDown.TabIndex = 9;
            this.WidthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(14, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Width";
            // 
            // PhaseNumericUpDown
            // 
            this.PhaseNumericUpDown.Location = new System.Drawing.Point(15, 219);
            this.PhaseNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PhaseNumericUpDown.Name = "PhaseNumericUpDown";
            this.PhaseNumericUpDown.Size = new System.Drawing.Size(85, 20);
            this.PhaseNumericUpDown.TabIndex = 11;
            this.PhaseNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(12, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Phase";
            // 
            // SingScreamAttributes
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(225, 316);
            this.Controls.Add(this.FrequencyUpDown);
            this.Controls.Add(this.AmplitudeUpDown1);
            this.Controls.Add(this.PhaseNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WidthNumericUpDown);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.AmplitudeLabel1);
            this.Controls.Add(this.ChangeColorButton);
            this.Controls.Add(this.ColorPanel);
            this.Controls.Add(this.FrequencyLable);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SingScreamAttributes";
            this.Text = "Sing/scream attributes";
            ((System.ComponentModel.ISupportInitialize)(this.AmplitudeUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhaseNumericUpDown)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void ChangeColorButton_Click(object sender, System.EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.AllowFullOpen = true;
			colorDialog.AnyColor = true;
			colorDialog.SolidColorOnly = false;
			colorDialog.ShowHelp = true;
			
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				//arrow.color= colorDialog.Color;
				this.ColorPanel.BackColor = colorDialog.Color;
			}
		}

		private void OKButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void AmplitudeUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
		
		}

		

		
	}
}
