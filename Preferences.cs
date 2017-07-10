using System.Windows.Forms;

namespace musicTherapy1
{
    /// <summary>
    /// Summary description for Preferences.
    /// </summary>
    public class Preferences : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown TimeLineWidth;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
        private Label label2;
        private NumericUpDown MaxNumOfPatiantsForSplitStaff;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public int timeLineWidth
		{
			get { return (int)TimeLineWidth.Value; }
			set {this.TimeLineWidth.Value=timeLineWidth;}
		}
        public int maxNumOfPatiantsForSplitStaff
        {
            get { return (int)this.MaxNumOfPatiantsForSplitStaff.Value; }
            set { this.MaxNumOfPatiantsForSplitStaff.Value = (decimal)value; }
        }
		public Preferences()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            this.label1 = new System.Windows.Forms.Label();
            this.TimeLineWidth = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxNumOfPatiantsForSplitStaff = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.TimeLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumOfPatiantsForSplitStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Timeline width";
            // 
            // TimeLineWidth
            // 
            this.TimeLineWidth.Location = new System.Drawing.Point(112, 24);
            this.TimeLineWidth.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.TimeLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimeLineWidth.Name = "TimeLineWidth";
            this.TimeLineWidth.Size = new System.Drawing.Size(120, 20);
            this.TimeLineWidth.TabIndex = 1;
            this.TimeLineWidth.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.TimeLineWidth.ValueChanged += new System.EventHandler(this.TimeLineWidth_ValueChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(176, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ok";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(32, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max num of patiants for spliting staff";
            // 
            // MaxNumOfPatiantsForSplitStaff
            // 
            this.MaxNumOfPatiantsForSplitStaff.Location = new System.Drawing.Point(112, 109);
            this.MaxNumOfPatiantsForSplitStaff.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MaxNumOfPatiantsForSplitStaff.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxNumOfPatiantsForSplitStaff.Name = "MaxNumOfPatiantsForSplitStaff";
            this.MaxNumOfPatiantsForSplitStaff.Size = new System.Drawing.Size(120, 20);
            this.MaxNumOfPatiantsForSplitStaff.TabIndex = 5;
            this.MaxNumOfPatiantsForSplitStaff.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // Preferences
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.MaxNumOfPatiantsForSplitStaff);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TimeLineWidth);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Preferences";
            this.Text = "Preferences";
            ((System.ComponentModel.ISupportInitialize)(this.TimeLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumOfPatiantsForSplitStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.timeLineWidth= (int)(this.TimeLineWidth.Value);
			this.Close();
		}

		private void TimeLineWidth_ValueChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
