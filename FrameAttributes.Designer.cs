namespace musicTherapy1
{
    partial class FrameAttributes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Color = new System.Windows.Forms.Button();
            this.ColorPanel = new System.Windows.Forms.Panel();
            this.AdditionlInfo = new System.Windows.Forms.Label();
            this.TimeLable = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.WidthnumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.TypeListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.WidthnumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // Color
            // 
            this.Color.Location = new System.Drawing.Point(18, 161);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(88, 23);
            this.Color.TabIndex = 21;
            this.Color.Text = "Change color";
            this.Color.Click += new System.EventHandler(this.Color_Click);
            // 
            // ColorPanel
            // 
            this.ColorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPanel.Location = new System.Drawing.Point(134, 161);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(38, 23);
            this.ColorPanel.TabIndex = 20;
            // 
            // AdditionlInfo
            // 
            this.AdditionlInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AdditionlInfo.Location = new System.Drawing.Point(14, 65);
            this.AdditionlInfo.Name = "AdditionlInfo";
            this.AdditionlInfo.Size = new System.Drawing.Size(120, 23);
            this.AdditionlInfo.TabIndex = 15;
            this.AdditionlInfo.Text = "Type:";
            // 
            // TimeLable
            // 
            this.TimeLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TimeLable.Location = new System.Drawing.Point(14, 23);
            this.TimeLable.Name = "TimeLable";
            this.TimeLable.Size = new System.Drawing.Size(64, 23);
            this.TimeLable.TabIndex = 14;
            this.TimeLable.Text = "Width:";
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(205, 57);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 13;
            this.Cancel.Text = "Cancel";
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(205, 28);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 12;
            this.OK.Text = "OK";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // WidthnumericUpDown1
            // 
            this.WidthnumericUpDown1.Location = new System.Drawing.Point(88, 28);
            this.WidthnumericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.WidthnumericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthnumericUpDown1.Name = "WidthnumericUpDown1";
            this.WidthnumericUpDown1.Size = new System.Drawing.Size(47, 20);
            this.WidthnumericUpDown1.TabIndex = 22;
            this.WidthnumericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // TypeListBox
            // 
            this.TypeListBox.FormattingEnabled = true;
            this.TypeListBox.Items.AddRange(new object[] {
            "Dot",
            "Solid",
            "Dash-Dot-Dot",
            "Dash-Dot",
            "Dash"});
            this.TypeListBox.Location = new System.Drawing.Point(88, 65);
            this.TypeListBox.Name = "TypeListBox";
            this.TypeListBox.Size = new System.Drawing.Size(84, 69);
            this.TypeListBox.TabIndex = 23;
            // 
            // FrameAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 196);
            this.Controls.Add(this.TypeListBox);
            this.Controls.Add(this.WidthnumericUpDown1);
            this.Controls.Add(this.Color);
            this.Controls.Add(this.ColorPanel);
            this.Controls.Add(this.AdditionlInfo);
            this.Controls.Add(this.TimeLable);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Name = "FrameAttributes";
            this.Text = "Frame attributes";
            ((System.ComponentModel.ISupportInitialize)(this.WidthnumericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Color;
        private System.Windows.Forms.Panel ColorPanel;
        private System.Windows.Forms.Label AdditionlInfo;
        private System.Windows.Forms.Label TimeLable;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.NumericUpDown WidthnumericUpDown1;
        private System.Windows.Forms.ListBox TypeListBox;
    }
}