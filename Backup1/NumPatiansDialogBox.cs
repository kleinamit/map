using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace musicTherapy1
{
	/// <summary>
	/// Summary description for NumPatiansDialogBox.
	/// </summary>
	public class NumPatiansDialogBox : System.Windows.Forms.Form
	{
		private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox listBox1;
		ArrayList values = new ArrayList();

		

		public MainForm MyParentForm;
		public int numOfPatiants
		{
			get { return (int)numericUpDown1.Value; }
		}
		public int sessionDuration
		{
			get { return (int)numericUpDown2.Value; }
		}
		
		public int timeIntervalBetweenBars;
		//{
		//	get { 
				/*if (listBox1.Text == "2.5")
					return 5;
				else if(listBox1.Text == "5")
					return 10; 
				else if (listBox1.Text == "10")
					return 20;
				else return 5;*/
		//		return timeIntervalBetweenBars;
		//		}
		//}
		public NumPatiansDialogBox()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			values.Add ("2.5");
			values.Add ("5");
			values.Add ("10");
			listBox1.DataSource = values;
			//listBox1.DataBind();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumPatiansDialogBox));
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(31, 64);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(252, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(23, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of participants in a single session:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(23, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 48);
            this.label2.TabIndex = 4;
            this.label2.Text = "Length of a single session (in minutes): ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(31, 128);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(23, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Time interval between bar lines (in minutes):";
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(31, 192);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 43);
            this.listBox1.TabIndex = 7;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // NumPatiansDialogBox
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(361, 256);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NumPatiansDialogBox";
            this.Text = "Session attributes";
            this.Load += new System.EventHandler(this.NumPatiansDialogBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			/*if ( listBox1.SelectedIndex > -1 )
            MessageBox.Show("You chose: " + listBox1.SelectedItem.ToString());
			ListBox lbi  = ((sender as ListBox).SelectedItem as ListBoxItem);
			tb.Text = "   You selected " + lbi.Content.ToString() + ".";
*/
			
			if (listBox1.SelectedIndex ==0)
					this.timeIntervalBetweenBars= 5;
				else if(listBox1.GetSelected(1))
					this.timeIntervalBetweenBars= 10; 
				else if (listBox1.GetSelected(2))
					this.timeIntervalBetweenBars= 20;
				
			
			
			this.Close();
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void NumPatiansDialogBox_Load(object sender, System.EventArgs e)
		{
			//listBox1.SelectedIndex=1;
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//listBox1.SelectedIndex
		}
	}
}
