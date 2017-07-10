namespace musicTherapy1
{
    partial class Statistics
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
            this.InstrumentListView = new System.Windows.Forms.ListView();
            this.TextlistView = new System.Windows.Forms.ListView();
            this.GeneralStatisticItemsListView = new System.Windows.Forms.ListView();
            this.StatisticsListView = new System.Windows.Forms.ListView();
            this.DeleteFromListButton = new System.Windows.Forms.Button();
            this.RunStatistics = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CountTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SessionRangeCountRadioButton = new System.Windows.Forms.RadioButton();
            this.ToMinuteNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FromMinuteNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ToSessionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FromSessionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectAllInstruments = new System.Windows.Forms.Button();
            this.InsertGeneralItemsToListButton = new System.Windows.Forms.Button();
            this.InsertTextToListButton = new System.Windows.Forms.Button();
            this.insertInstrumentToListButton = new System.Windows.Forms.Button();
            this.NamesPanel = new System.Windows.Forms.Panel();
            this.CheckAllnamesButton = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.SesseionNumbersPanel = new System.Windows.Forms.Panel();
            this.SessionComparisonRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.ComparePatiantsCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToMinuteNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromMinuteNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToSessionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromSessionNumericUpDown)).BeginInit();
            this.NamesPanel.SuspendLayout();
            this.SesseionNumbersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InstrumentListView
            // 
            this.InstrumentListView.Location = new System.Drawing.Point(232, 86);
            this.InstrumentListView.Name = "InstrumentListView";
            this.InstrumentListView.Size = new System.Drawing.Size(172, 208);
            this.InstrumentListView.TabIndex = 0;
            this.InstrumentListView.UseCompatibleStateImageBehavior = false;
            // 
            // TextlistView
            // 
            this.TextlistView.Location = new System.Drawing.Point(692, 86);
            this.TextlistView.Name = "TextlistView";
            this.TextlistView.Size = new System.Drawing.Size(190, 208);
            this.TextlistView.TabIndex = 1;
            this.TextlistView.UseCompatibleStateImageBehavior = false;
            // 
            // GeneralStatisticItemsListView
            // 
            this.GeneralStatisticItemsListView.Location = new System.Drawing.Point(496, 12);
            this.GeneralStatisticItemsListView.Name = "GeneralStatisticItemsListView";
            this.GeneralStatisticItemsListView.Size = new System.Drawing.Size(100, 82);
            this.GeneralStatisticItemsListView.TabIndex = 2;
            this.GeneralStatisticItemsListView.UseCompatibleStateImageBehavior = false;
            // 
            // StatisticsListView
            // 
            this.StatisticsListView.Location = new System.Drawing.Point(450, 130);
            this.StatisticsListView.Name = "StatisticsListView";
            this.StatisticsListView.Size = new System.Drawing.Size(200, 184);
            this.StatisticsListView.TabIndex = 3;
            this.StatisticsListView.UseCompatibleStateImageBehavior = false;
            // 
            // DeleteFromListButton
            // 
            this.DeleteFromListButton.Location = new System.Drawing.Point(450, 320);
            this.DeleteFromListButton.Name = "DeleteFromListButton";
            this.DeleteFromListButton.Size = new System.Drawing.Size(60, 23);
            this.DeleteFromListButton.TabIndex = 5;
            this.DeleteFromListButton.Text = "Delete";
            this.DeleteFromListButton.UseVisualStyleBackColor = true;
            this.DeleteFromListButton.Click += new System.EventHandler(this.DeleteFromListButton_Click);
            // 
            // RunStatistics
            // 
            this.RunStatistics.Location = new System.Drawing.Point(295, 373);
            this.RunStatistics.Name = "RunStatistics";
            this.RunStatistics.Size = new System.Drawing.Size(75, 23);
            this.RunStatistics.TabIndex = 7;
            this.RunStatistics.Text = "Execute";
            this.RunStatistics.UseVisualStyleBackColor = true;
            this.RunStatistics.Click += new System.EventHandler(this.RunStatistics_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Count";
            // 
            // CountTextBox
            // 
            this.CountTextBox.Location = new System.Drawing.Point(164, 376);
            this.CountTextBox.Name = "CountTextBox";
            this.CountTextBox.Size = new System.Drawing.Size(100, 20);
            this.CountTextBox.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.SessionRangeCountRadioButton);
            this.panel1.Controls.Add(this.ToMinuteNumericUpDown);
            this.panel1.Controls.Add(this.FromMinuteNumericUpDown);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ToSessionNumericUpDown);
            this.panel1.Controls.Add(this.FromSessionNumericUpDown);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 108);
            this.panel1.TabIndex = 10;
            // 
            // SessionRangeCountRadioButton
            // 
            this.SessionRangeCountRadioButton.AutoSize = true;
            this.SessionRangeCountRadioButton.Location = new System.Drawing.Point(6, 3);
            this.SessionRangeCountRadioButton.Name = "SessionRangeCountRadioButton";
            this.SessionRangeCountRadioButton.Size = new System.Drawing.Size(122, 17);
            this.SessionRangeCountRadioButton.TabIndex = 10;
            this.SessionRangeCountRadioButton.TabStop = true;
            this.SessionRangeCountRadioButton.Text = "Sessein range count";
            this.SessionRangeCountRadioButton.UseVisualStyleBackColor = true;
            this.SessionRangeCountRadioButton.CheckedChanged += new System.EventHandler(this.SessionRangeCountRadioButton_CheckedChanged);
            // 
            // ToMinuteNumericUpDown
            // 
            this.ToMinuteNumericUpDown.Location = new System.Drawing.Point(175, 78);
            this.ToMinuteNumericUpDown.Name = "ToMinuteNumericUpDown";
            this.ToMinuteNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.ToMinuteNumericUpDown.TabIndex = 7;
            // 
            // FromMinuteNumericUpDown
            // 
            this.FromMinuteNumericUpDown.Location = new System.Drawing.Point(73, 78);
            this.FromMinuteNumericUpDown.Name = "FromMinuteNumericUpDown";
            this.FromMinuteNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.FromMinuteNumericUpDown.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "to minute:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "from minute:";
            // 
            // ToSessionNumericUpDown
            // 
            this.ToSessionNumericUpDown.Location = new System.Drawing.Point(174, 41);
            this.ToSessionNumericUpDown.Name = "ToSessionNumericUpDown";
            this.ToSessionNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.ToSessionNumericUpDown.TabIndex = 3;
            // 
            // FromSessionNumericUpDown
            // 
            this.FromSessionNumericUpDown.Location = new System.Drawing.Point(72, 41);
            this.FromSessionNumericUpDown.Name = "FromSessionNumericUpDown";
            this.FromSessionNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.FromSessionNumericUpDown.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "to session:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "from session:";
            // 
            // SelectAllInstruments
            // 
            this.SelectAllInstruments.Location = new System.Drawing.Point(232, 300);
            this.SelectAllInstruments.Name = "SelectAllInstruments";
            this.SelectAllInstruments.Size = new System.Drawing.Size(59, 23);
            this.SelectAllInstruments.TabIndex = 11;
            this.SelectAllInstruments.Text = "Select all";
            this.SelectAllInstruments.UseVisualStyleBackColor = true;
            this.SelectAllInstruments.Click += new System.EventHandler(this.SelectAllInstruments_Click);
            // 
            // InsertGeneralItemsToListButton
            // 
            this.InsertGeneralItemsToListButton.BackgroundImage = global::musicTherapy1.Properties.Resources.play_big_down2;
            this.InsertGeneralItemsToListButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.InsertGeneralItemsToListButton.Location = new System.Drawing.Point(527, 100);
            this.InsertGeneralItemsToListButton.Name = "InsertGeneralItemsToListButton";
            this.InsertGeneralItemsToListButton.Size = new System.Drawing.Size(48, 25);
            this.InsertGeneralItemsToListButton.TabIndex = 12;
            this.InsertGeneralItemsToListButton.UseVisualStyleBackColor = true;
            this.InsertGeneralItemsToListButton.Click += new System.EventHandler(this.InsertGeneralItemsToListButton_Click);
            // 
            // InsertTextToListButton
            // 
            this.InsertTextToListButton.Image = global::musicTherapy1.Properties.Resources.play_big_left;
            this.InsertTextToListButton.Location = new System.Drawing.Point(656, 169);
            this.InsertTextToListButton.Name = "InsertTextToListButton";
            this.InsertTextToListButton.Size = new System.Drawing.Size(34, 39);
            this.InsertTextToListButton.TabIndex = 6;
            this.InsertTextToListButton.UseVisualStyleBackColor = true;
            this.InsertTextToListButton.Click += new System.EventHandler(this.InsertTextToListButton_Click);
            // 
            // insertInstrumentToListButton
            // 
            this.insertInstrumentToListButton.Image = global::musicTherapy1.Properties.Resources.play_big_right2;
            this.insertInstrumentToListButton.Location = new System.Drawing.Point(410, 169);
            this.insertInstrumentToListButton.Name = "insertInstrumentToListButton";
            this.insertInstrumentToListButton.Size = new System.Drawing.Size(34, 39);
            this.insertInstrumentToListButton.TabIndex = 4;
            this.insertInstrumentToListButton.UseVisualStyleBackColor = true;
            this.insertInstrumentToListButton.Click += new System.EventHandler(this.insertInstrumentToListButton_Click);
            // 
            // NamesPanel
            // 
            this.NamesPanel.BackColor = System.Drawing.Color.AntiqueWhite;
            this.NamesPanel.Controls.Add(this.CheckAllnamesButton);
            this.NamesPanel.Location = new System.Drawing.Point(12, 4);
            this.NamesPanel.Name = "NamesPanel";
            this.NamesPanel.Size = new System.Drawing.Size(214, 100);
            this.NamesPanel.TabIndex = 13;
            // 
            // CheckAllnamesButton
            // 
            this.CheckAllnamesButton.Location = new System.Drawing.Point(3, 73);
            this.CheckAllnamesButton.Name = "CheckAllnamesButton";
            this.CheckAllnamesButton.Size = new System.Drawing.Size(116, 24);
            this.CheckAllnamesButton.TabIndex = 0;
            this.CheckAllnamesButton.Text = "Sellect all names";
            this.CheckAllnamesButton.UseVisualStyleBackColor = true;
            this.CheckAllnamesButton.Click += new System.EventHandler(this.CheckAllnamesButton_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(527, 320);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 14;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // SesseionNumbersPanel
            // 
            this.SesseionNumbersPanel.BackColor = System.Drawing.Color.Thistle;
            this.SesseionNumbersPanel.Controls.Add(this.SessionComparisonRadioButton);
            this.SesseionNumbersPanel.Controls.Add(this.button1);
            this.SesseionNumbersPanel.Location = new System.Drawing.Point(12, 224);
            this.SesseionNumbersPanel.Name = "SesseionNumbersPanel";
            this.SesseionNumbersPanel.Size = new System.Drawing.Size(214, 146);
            this.SesseionNumbersPanel.TabIndex = 15;
            // 
            // SessionComparisonRadioButton
            // 
            this.SessionComparisonRadioButton.AutoSize = true;
            this.SessionComparisonRadioButton.Location = new System.Drawing.Point(5, 3);
            this.SessionComparisonRadioButton.Name = "SessionComparisonRadioButton";
            this.SessionComparisonRadioButton.Size = new System.Drawing.Size(119, 17);
            this.SessionComparisonRadioButton.TabIndex = 9;
            this.SessionComparisonRadioButton.TabStop = true;
            this.SessionComparisonRadioButton.Text = "Sessein comparison";
            this.SessionComparisonRadioButton.UseVisualStyleBackColor = true;
            this.SessionComparisonRadioButton.CheckedChanged += new System.EventHandler(this.SessionComparisonRadioButton_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sellect all ssesions";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ComparePatiantsCheckBox
            // 
            this.ComparePatiantsCheckBox.AutoSize = true;
            this.ComparePatiantsCheckBox.Location = new System.Drawing.Point(232, 12);
            this.ComparePatiantsCheckBox.Name = "ComparePatiantsCheckBox";
            this.ComparePatiantsCheckBox.Size = new System.Drawing.Size(108, 17);
            this.ComparePatiantsCheckBox.TabIndex = 1;
            this.ComparePatiantsCheckBox.Text = "Compare patiants";
            this.ComparePatiantsCheckBox.UseVisualStyleBackColor = true;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 530);
            this.Controls.Add(this.ComparePatiantsCheckBox);
            this.Controls.Add(this.SesseionNumbersPanel);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.NamesPanel);
            this.Controls.Add(this.InsertGeneralItemsToListButton);
            this.Controls.Add(this.SelectAllInstruments);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CountTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InsertTextToListButton);
            this.Controls.Add(this.DeleteFromListButton);
            this.Controls.Add(this.RunStatistics);
            this.Controls.Add(this.insertInstrumentToListButton);
            this.Controls.Add(this.StatisticsListView);
            this.Controls.Add(this.GeneralStatisticItemsListView);
            this.Controls.Add(this.TextlistView);
            this.Controls.Add(this.InstrumentListView);
            this.Name = "Statistics";
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.Statistics_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToMinuteNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromMinuteNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToSessionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromSessionNumericUpDown)).EndInit();
            this.NamesPanel.ResumeLayout(false);
            this.SesseionNumbersPanel.ResumeLayout(false);
            this.SesseionNumbersPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView InstrumentListView;
        private System.Windows.Forms.ListView TextlistView;
        private System.Windows.Forms.ListView GeneralStatisticItemsListView;
        private System.Windows.Forms.ListView StatisticsListView;
        private System.Windows.Forms.Button insertInstrumentToListButton;
        private System.Windows.Forms.Button DeleteFromListButton;
        private System.Windows.Forms.Button InsertTextToListButton;
        private System.Windows.Forms.Button RunStatistics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CountTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown ToSessionNumericUpDown;
        private System.Windows.Forms.NumericUpDown FromSessionNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ToMinuteNumericUpDown;
        private System.Windows.Forms.NumericUpDown FromMinuteNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SelectAllInstruments;
        private System.Windows.Forms.Button InsertGeneralItemsToListButton;
        private System.Windows.Forms.Panel NamesPanel;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button CheckAllnamesButton;
        private System.Windows.Forms.Panel SesseionNumbersPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton SessionComparisonRadioButton;
        private System.Windows.Forms.CheckBox ComparePatiantsCheckBox;
        private System.Windows.Forms.RadioButton SessionRangeCountRadioButton;
    }
}