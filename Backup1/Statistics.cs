using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.Collections;

namespace musicTherapy1
{
    
    public partial class Statistics : Form
    {
        public MainForm parentForm;
        ArrayList StatisticsArrayList;
        Panel checkBoxPanel = new Panel();
        Panel SessionCheckBoxPanel = new Panel();
        public int[] SessionsStatisticsArray;
    //    public DataSet dataset;
        public System.Data.DataSet dataset;
        System.Data.OleDb.OleDbConnection conn;
        public StatisticsReportChart report;
        public Statistics()
        {
            InitializeComponent();
            StatisticsArrayList = new ArrayList();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            StatisticsArrayList.Clear();
            ConnectToAccess();
            deleteAllrecordsFromDB();
            InitStatisticsListView();
            LoadTextListFromDocument();
            LoadInstrumentListFromDocument();
            LoadGeneralItemsListView();
            LoadNamesToNamePanel();
            LoadSessionsToSessionPanel();
            MainForm mainForm = (MainForm)this.parentForm;
            int numOfSessions = mainForm.numOfSessions;
            Sessions sesion = (Sessions)mainForm.ActiveMdiChild;
				int numOfDocuments;
				for ( numOfDocuments=0;numOfDocuments<20;numOfDocuments++)
				{
					if (sesion.document[numOfDocuments] ==null)
						break;
				}
                
            this.ToSessionNumericUpDown.Maximum= numOfDocuments;
            this.FromSessionNumericUpDown.Minimum = 1;
            this.FromSessionNumericUpDown.Value = 1;
            this.ToSessionNumericUpDown.Value = numOfDocuments;
            
            this.FromMinuteNumericUpDown.Minimum = 0;
            this.ToMinuteNumericUpDown.Maximum = sesion.document[0].sessionDuration;
            this.FromMinuteNumericUpDown.Value = 0;
            this.ToMinuteNumericUpDown.Value = sesion.document[0].sessionDuration;


        }
        private void LoadNamesToNamePanel()
        {
            MainForm mainForm = (MainForm)this.parentForm;
            int numOfSessions = mainForm.numOfSessions; 
            int yCordinate = 4;
            
            checkBoxPanel.Size = new Size(NamesPanel.Size.Width, NamesPanel.Size.Height - 25);
            checkBoxPanel.AutoScroll = true;
            NamesPanel.Controls.Add(checkBoxPanel);

            for (int patiantCounter = 0; patiantCounter < mainForm.SessionsArray[numOfSessions].document[0].numOfPatiants; patiantCounter++)
                {
                   CheckBox checkBox = new CheckBox();
                   checkBox.Text= mainForm.SessionsArray[numOfSessions].document[0].timeLine[patiantCounter].PatiantName;
                   checkBox.Checked=false;
                   checkBox.Location = new Point(12, yCordinate);
                   yCordinate += checkBox.Size.Height;
                   checkBoxPanel.Controls.Add(checkBox);
                }
                //RadioButton checkAllNamesCheckBox = new RadioButton();
                //checkAllNamesCheckBox.Text = "Check all names";
                //NamesPanel.Controls.Add(checkAllNamesCheckBox);
                //checkAllNamesCheckBox.Size = new Size(NamesPanel.Size.Width, 15);    
                //checkAllNamesCheckBox.Location = new Point(12, NamesPanel.Size.Height-checkAllNamesCheckBox.Size.Height);
        }
        private void LoadSessionsToSessionPanel()
        {
            MainForm mainForm = (MainForm)this.parentForm;
            int numOfSessions = mainForm.numOfSessions;
            int yCordinate = 24;

            SessionCheckBoxPanel.Size = new Size(NamesPanel.Size.Width, NamesPanel.Size.Height - 25);
            SessionCheckBoxPanel.AutoScroll = true;
            SesseionNumbersPanel.Controls.Add(SessionCheckBoxPanel);
            Sessions sesion = (Sessions)mainForm.ActiveMdiChild;
            int numOfDocuments;
            for (numOfDocuments = 0; numOfDocuments < getDocNumber(); numOfDocuments++)
            {    
                CheckBox checkBox = new CheckBox();
                checkBox.Text = "Session " +(numOfDocuments+1);
                checkBox.Checked = false;
                checkBox.Location = new Point(12, yCordinate);
                yCordinate += checkBox.Size.Height;
                SessionCheckBoxPanel.Controls.Add(checkBox);
            }
        }
        private void InitStatisticsListView()
        {
            StatisticsListView.View = View.Details;
            StatisticsListView.Columns.Add("Name", 150, HorizontalAlignment.Left);
            StatisticsListView.Columns.Add("Category", 100, HorizontalAlignment.Left);
            StatisticsListView.Columns.Add("SubCategory", 0, HorizontalAlignment.Left);
            StatisticsListView.Columns.Add("Description", 0, HorizontalAlignment.Left);
            StatisticsListView.Columns.Add("Type", 0, HorizontalAlignment.Left);//for internal use to know the type of item: instrumetn, text etc
            StatisticsListView.LargeImageList = new ImageList();
            StatisticsListView.LargeImageList.ImageSize = new Size(32, 32);
            StatisticsListView.SmallImageList = new ImageList();
            StatisticsListView.SmallImageList.ImageSize = new Size(16, 16);

        }
        private int getDocNumber()
        {
            MainForm mainForm = (MainForm)this.parentForm;
            int numOfSessions = mainForm.numOfSessions;
            Sessions sesion = (Sessions)mainForm.ActiveMdiChild;
            int numOfDocuments;
            for (numOfDocuments = 0; numOfDocuments < 20; numOfDocuments++)
            {
                if (sesion.document[numOfDocuments] == null)
                    break;
            }
            return numOfDocuments;
        }
        private void LoadGeneralItemsListView()
        {

            MainForm mainForm = (MainForm)this.parentForm;
            int numOfSessions = mainForm.numOfSessions;
            GeneralStatisticItemsListView.LargeImageList = new ImageList();

            GeneralStatisticItemsListView.LargeImageList.ImageSize = new Size(32, 32);
            GeneralStatisticItemsListView.SmallImageList = new ImageList();
            GeneralStatisticItemsListView.SmallImageList.ImageSize = new Size(16, 16);

            GeneralStatisticItemsListView.View = View.SmallIcon;
            GeneralStatisticItemsListView.Columns.Add("Name", 240, HorizontalAlignment.Right);
       
            string picName = mainForm.MainDirectory + "\\pictures\\arrow.jpg" ;
            Bitmap image1 = new Bitmap(picName);
            Bitmap image = new Bitmap(image1, new Size(32, 32));
            GeneralStatisticItemsListView.LargeImageList.Images.Add(image);
            ListViewItem textListItem = GeneralStatisticItemsListView.Items.Add("Arrow", 0);
            image = new Bitmap(image1, new Size(16, 16));
            GeneralStatisticItemsListView.SmallImageList.Images.Add(image);
            textListItem.SubItems.Add("stam1");
            textListItem.SubItems.Add("stam2");
            textListItem.SubItems.Add("stam3");
            
            //textListItem.SubItems.Add("Arrow");
             picName = mainForm.MainDirectory + "\\pictures\\disc.jpg";
            image1 = new Bitmap(picName);
            image = new Bitmap(image1, new Size(32, 32));
            GeneralStatisticItemsListView.LargeImageList.Images.Add(image);
            textListItem = GeneralStatisticItemsListView.Items.Add("Disc", 1);
            image = new Bitmap(image1, new Size(16, 16));
            GeneralStatisticItemsListView.SmallImageList.Images.Add(image);
            textListItem.SubItems.Add("stam1");
            textListItem.SubItems.Add("stam2");
            textListItem.SubItems.Add("stam3");
            
            picName = mainForm.MainDirectory + "\\pictures\\sing.jpg";
            image1 = new Bitmap(picName);
            image = new Bitmap(image1, new Size(32, 32));
            GeneralStatisticItemsListView.LargeImageList.Images.Add(image);
            textListItem = GeneralStatisticItemsListView.Items.Add("Sing", 2);
            image = new Bitmap(image1, new Size(16, 16));
            GeneralStatisticItemsListView.SmallImageList.Images.Add(image);
            textListItem.SubItems.Add("stam1");
            textListItem.SubItems.Add("stam2");
            textListItem.SubItems.Add("stam3");
            
            picName = mainForm.MainDirectory + "\\pictures\\scream.jpg";
            image1 = new Bitmap(picName);
            image = new Bitmap(image1, new Size(32, 32));
            GeneralStatisticItemsListView.LargeImageList.Images.Add(image);
            textListItem = GeneralStatisticItemsListView.Items.Add("Scream", 3);
            image = new Bitmap(image1, new Size(16, 16));
            GeneralStatisticItemsListView.SmallImageList.Images.Add(image);
            textListItem.SubItems.Add("stam1");
            textListItem.SubItems.Add("stam2");
            textListItem.SubItems.Add("stam3");
           
            picName = mainForm.MainDirectory + "\\pictures\\silence.jpg";
            image1 = new Bitmap(picName);
            image = new Bitmap(image1, new Size(32, 32));
            GeneralStatisticItemsListView.LargeImageList.Images.Add(image);
            textListItem = GeneralStatisticItemsListView.Items.Add("Silence", 4);
            image = new Bitmap(image1, new Size(16, 16));
            GeneralStatisticItemsListView.SmallImageList.Images.Add(image);
            textListItem.SubItems.Add("stam1");
            textListItem.SubItems.Add("stam2");
            textListItem.SubItems.Add("stam3");
            
        }
        private void LoadInstrumentListFromDocument()
        {
            InstrumentListView.LargeImageList = new ImageList();

            InstrumentListView.LargeImageList.ImageSize = new Size(32, 32);
            InstrumentListView.SmallImageList = new ImageList();
            InstrumentListView.SmallImageList.ImageSize = new Size(16, 16);

            InstrumentListView.View = View.List;
            InstrumentListView.Columns.Add("Name", 100, HorizontalAlignment.Left);
            InstrumentListView.Columns.Add("Category", 50, HorizontalAlignment.Left);
            InstrumentListView.Columns.Add("SubCategory", 40, HorizontalAlignment.Left);
            InstrumentListView.Columns.Add("Description", 0, HorizontalAlignment.Left);
            InstrumentListView.View = View.Details;
            
            
            MainForm mainForm = (MainForm)this.parentForm;
            int numOfSessions = mainForm.numOfSessions;
            int instrumentListCounter = 0;
            for (int docCounter = 0; docCounter < getDocNumber(); docCounter++)
            {
                for (int patiantCounter = 0; patiantCounter < mainForm.SessionsArray[numOfSessions].document[/*mainForm.SessionsArray[numOfSessions].docNumber*/docCounter].numOfPatiants; patiantCounter++)
                {
                    for (int minutesCounter = 0; minutesCounter < mainForm.SessionsArray[numOfSessions].document[/*mainForm.SessionsArray[numOfSessions].docNumber*/docCounter].sessionDuration * 2; minutesCounter++)
                    {
                        if (mainForm.SessionsArray[numOfSessions].document[docCounter/*mainForm.SessionsArray[numOfSessions].docNumber*/].timeLine[patiantCounter].MinutesArray[minutesCounter].instrumentStartHere)
                        {

                            InstrumentInfo instrument = (InstrumentInfo)mainForm.SessionsArray[numOfSessions].document[/*mainForm.SessionsArray[numOfSessions].docNumber*/docCounter].timeLine[patiantCounter].MinutesArray[minutesCounter].instrumetnInfo;
                            bool existsInStatisticsList = false;

                            foreach (ListViewItem item in InstrumentListView.Items)
                            {
                                if (item.Text == instrument.Name)
                                    existsInStatisticsList = true;
                            }
                            if (existsInStatisticsList)
                                continue;

                            //myImage my_image = (myImage)imageList[imageCounter];
                            string picName = mainForm.MainDirectory + "\\pictures\\instruments\\" + instrument.Category + "\\" + instrument.SubCategory + "\\" + instrument.Name;
                            Bitmap image1 = new Bitmap(picName);
                            Bitmap image = new Bitmap(image1, new Size(32, 32));
                            InstrumentListView.LargeImageList.Images.Add(image);
                            ListViewItem textListItem = InstrumentListView.Items.Add(instrument.Name, instrumentListCounter);
                            image = new Bitmap(image1, new Size(16, 16));
                            InstrumentListView.SmallImageList.Images.Add(image);
                            textListItem.SubItems.Add(instrument.Category);
                            textListItem.SubItems.Add(instrument.SubCategory);
                            textListItem.SubItems.Add(instrument.Description);
                            instrumentListCounter++;
                        }
                    }
                }
            }
        }
        private void LoadTextListFromDocument()
        {
            TextlistView.LargeImageList = new ImageList();
            TextlistView.LargeImageList.ImageSize = new Size(32, 32);
            TextlistView.SmallImageList = new ImageList();
            TextlistView.SmallImageList.ImageSize = new Size(16, 16);
            TextlistView.View = View.List;
            TextlistView.Columns.Add("Topic", 50, HorizontalAlignment.Left);
            TextlistView.Columns.Add("SubTopic", 50, HorizontalAlignment.Left);
            TextlistView.Columns.Add("Text", 100, HorizontalAlignment.Left);
            TextlistView.Columns.Add("Long text", 0, HorizontalAlignment.Left);
            TextlistView.View = View.Details;
            
            MainForm mainForm = (MainForm)this.parentForm;
            int numOfSessions = mainForm.numOfSessions;
            ArrayList listText = (ArrayList)mainForm.SessionsArray[numOfSessions].document[mainForm.SessionsArray[numOfSessions].docNumber].listText;
            for (int x = 0; x < listText.Count; x++)
            {
                TextTalkedinSession text = (TextTalkedinSession)listText[x];
                string picName = mainForm.MainDirectory + "\\pictures\\Text.jpg" ;
                Bitmap image1 = new Bitmap(picName);
                Bitmap image = new Bitmap(image1, new Size(32, 32));
                TextlistView.LargeImageList.Images.Add(image);
                ListViewItem textListItem = TextlistView.Items.Add(text.topic, x);
                image = new Bitmap(image1, new Size(16, 16));
                TextlistView.SmallImageList.Images.Add(image);

                textListItem.SubItems.Add(text.subTopic);
                textListItem.SubItems.Add(text.shortText);
                textListItem.SubItems.Add(text.longText);
            }
        }

        private void insertInstrumentToListButton_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = InstrumentListView.SelectedItems;
            for (int x = 0; x < items.Count; x++)
            {
                StatisticsListItem statisticsItem = new StatisticsListItem();
                statisticsItem.ItemType = 1;
                string instrumentName = items[x].Text;
                string instrumentCategory = items[x].SubItems[1].Text;
                string instrumentSubCategory = items[x].SubItems[2].Text;
                string instrumentDescription = items[x].SubItems[3].Text;

                statisticsItem.ItemName = instrumentCategory + "\\" + instrumentSubCategory + "\\" + instrumentName;


                ListViewItem ii = (ListViewItem)items[x].Clone();
                ii.SubItems.Add("1");
                

                bool existsInStatisticsList = false;
                foreach (ListViewItem item in StatisticsListView.Items)
                {
                    if (item.Text == ii.Text)
                        existsInStatisticsList = true;
                }
                if (!existsInStatisticsList)
                {
                    MainForm mainForm = (MainForm)this.parentForm;
                    int numOfSessions = mainForm.numOfSessions;

                 //   string picName = mainForm.MainDirectory + "\\pictures\\Text.jpg";
                   // Bitmap image1 = new Bitmap(picName);
                   // Bitmap image = new Bitmap(image1, new Size(32, 32));
                    StatisticsListView.LargeImageList.Images.Add(InstrumentListView.LargeImageList.Images[ii.ImageIndex]);
                    //ListViewItem textListItem = TextlistView.Items.Add(text.topic, x);
                    //image = new Bitmap(image1, new Size(16, 16));
                    StatisticsListView.SmallImageList.Images.Add(InstrumentListView.LargeImageList.Images[ii.ImageIndex]);
                    ii.ImageIndex = StatisticsListView.SmallImageList.Images.Count - 1;
                    
                    StatisticsListView.Items.Add(ii);//add to view
                    StatisticsArrayList.Add(statisticsItem);//add to memory
                }
                //ListViewItem textListItem = StatisticsListView.Items.Add(InstrumentListView.Items[items[x]]);
            }
        }

        private void InsertTextToListButton_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = TextlistView.SelectedItems;
            for (int x = 0; x < items.Count; x++)
            {
                StatisticsListItem statisticsItem = new StatisticsListItem();
                statisticsItem.ItemType = 2;
                string textTopic = items[x].Text;
                string textSubTopic = items[x].SubItems[1].Text;
                string textShortText = items[x].SubItems[2].Text;
                string textLongText = items[x].SubItems[3].Text;

                statisticsItem.ItemName = textTopic  + textSubTopic ;


                ListViewItem ii = (ListViewItem)items[x].Clone();
               
                //ii.SubItems;
                bool existsInStatisticsList = false;
                foreach (ListViewItem item in StatisticsListView.Items)
                {
                    if (item.Text == ii.Text &&
                        item.SubItems[1].Text == textSubTopic &&
                        item.SubItems[2].Text == textShortText)
                        existsInStatisticsList = true;
                }
                if (!existsInStatisticsList)
                {

                    MainForm mainForm = (MainForm)this.parentForm;
                    int numOfSessions = mainForm.numOfSessions; 
                    
                    string picName = mainForm.MainDirectory + "\\pictures\\Text.jpg";
                    Bitmap image1 = new Bitmap(picName);
                    Bitmap image = new Bitmap(image1, new Size(32, 32));
                    StatisticsListView.LargeImageList.Images.Add(image);
                    //ListViewItem textListItem = TextlistView.Items.Add(text.topic, x);
                    image = new Bitmap(image1, new Size(16, 16));
                    StatisticsListView.SmallImageList.Images.Add(image);
                    ii.ImageIndex = StatisticsListView.SmallImageList.Images.Count-1;
                    StatisticsListView.Items.Add(ii);//add to view
                    StatisticsArrayList.Add(statisticsItem);//add to memory
                }
                //ListViewItem textListItem = StatisticsListView.Items.Add(InstrumentListView.Items[items[x]]);
            }
        }

        private void RunStatistics_Click(object sender, EventArgs e)
        {
            deleteAllrecordsFromDB();
            MainForm mainForm = (MainForm)this.parentForm;
            if (SessionComparisonRadioButton.Checked)
            {
                SessionsStatisticsArray = new int[getDocNumber()];
               
                for (int docNum = 0; docNum < getDocNumber(); docNum++)
                {
                    bool dontCountThisSession = false;
                    foreach (CheckBox checkbox in SessionCheckBoxPanel.Controls)
                    {
                        //char [10] aa=new char("Session ");
                        string aa = "Session ";
                        
                        string bb = checkbox.Text.TrimStart(aa.ToCharArray());
                        int sessionNumber=Convert.ToInt16( bb);
                        if (sessionNumber - 1 == docNum )
                        {
                            if (checkbox.Checked == false)
                            dontCountThisSession = true;    
                            break;
                        }
                    }
                    if (dontCountThisSession)
                        continue;
                    else
                    {
                        //for (int patiantCounter = 0; patiantCounter < mainForm.SessionsArray[0].document[0].numOfPatiants; patiantCounter++)
                        //{
                        //    bool dontCountThisPatiant = false;
                        //    foreach (CheckBox checkbox in checkBoxPanel.Controls)
                        //    {
                        //        if (mainForm.SessionsArray[numOfSessions].document[docCounter].timeLine[patiantCounter].PatiantName == checkbox.Text && checkbox.Checked == false)
                        //            dontCountThisPatiant = true;
                        //    }
                        //    if (dontCountThisPatiant)
                        //        continue;
                        //}
                        DataSet oDS;
                        System.Data.OleDb.OleDbDataAdapter oOrdersDataAdapter;
                        SessionsStatisticsArray[docNum] = performStatistics(docNum, docNum, 0, mainForm.SessionsArray[0].document[0].numOfPatiants);
                        oDS = new DataSet();
                        oOrdersDataAdapter = new System.Data.OleDb.OleDbDataAdapter(new System.Data.OleDb.OleDbCommand("SELECT * FROM amitTable", conn));
                        System.Data.OleDb.OleDbCommandBuilder oOrdersCmdBuilder = new System.Data.OleDb.OleDbCommandBuilder(oOrdersDataAdapter);
                        oOrdersDataAdapter.FillSchema(oDS, SchemaType.Source);

                        DataTable pTable = oDS.Tables["Table"];
                        pTable.TableName = "statisticsTable";



                        // Insert the Data
                        DataRow oOrderRow = oDS.Tables["statisticsTable"].NewRow();
                        oOrderRow["FirstName"] = (docNum+1).ToString();
                        oOrderRow["Field1"] = performStatistics(docNum, docNum, 0, mainForm.SessionsArray[0].document[0].numOfPatiants);
                        oDS.Tables["statisticsTable"].Rows.Add(oOrderRow);

                        //System.Data.OleDb.OleDbDataAdapter dataAdapter = new System.Data.OleDb.OleDbDataAdapter();
                        //System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT* from amitTable;", conn);
                        oOrdersDataAdapter.Update(oDS, "statisticsTable");
                       // conn.Close();
                        
                        // DataTable table = new DataTable("amit");
                       // table.Columns.Add("column");
                       // dataset.Tables.Add(table);
                    }
                   // Graphics g = this.TablePanel.CreateGraphics();
                  //  g.
                }

                if (report == null)
                {
                    report= new StatisticsReportChart();
                    report.parentForm = this;
                    report.WindowState = FormWindowState.Maximized;
                }
                report.reportView.RefreshReport();
                report.Show();
            }
            else //not session comparison
            {
                int fromSession = Convert.ToInt16(this.FromSessionNumericUpDown.Value) - 1;
                int toSession = Convert.ToInt16(this.ToSessionNumericUpDown.Value) - 1;
                int statisticsCounter = performStatistics(fromSession, toSession, 0, mainForm.SessionsArray[0].document[0].numOfPatiants);
                this.CountTextBox.Text = statisticsCounter.ToString();
            }
            
            

        }
        public void ConnectToAccess()
        {
            conn = new System.Data.OleDb.OleDbConnection();
            
            // TODO: Modify the connection string and include any
            // additional required properties for your database.
            MainForm mainForm = (MainForm)this.parentForm;
            string dbName = mainForm.MainDirectory + "\\db2.mdb";
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data source="+dbName;

            //conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
            //  @"Data source= D:\Documents and Settings\amklein\" +
            //@"My Documents\db2.mdb";
            try
            {
                conn.Open();
                // Insert code to process data.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source");
            }
            finally
            {
                // conn.Close();
            }
            //DataSet1.amitTable1DataTable table = new DataSet1.amitTable1DataTable();

            //oDS = new DataSet();
            //oOrdersDataAdapter = new
            //        System.Data.OleDb.OleDbDataAdapter(new System.Data.OleDb.OleDbCommand("SELECT * FROM amitTable", conn));
            //System.Data.OleDb.OleDbCommandBuilder oOrdersCmdBuilder = new
            //    System.Data.OleDb.OleDbCommandBuilder(oOrdersDataAdapter);
            //oOrdersDataAdapter.FillSchema(oDS, SchemaType.Source);
            //// DataSet1.
            //DataTable pTable = oDS.Tables["Table"];
            //pTable.TableName = "Orders";



            //// Insert the Data
            //DataRow oOrderRow = oDS.Tables["Orders"].NewRow();
            //oOrderRow["FirstName"] = "amit";
            //oOrderRow["Field1"] = 3.0;
            //oDS.Tables["Orders"].Rows.Add(oOrderRow);

            ////System.Data.OleDb.OleDbDataAdapter dataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            ////System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT* from amitTable;", conn);
            //oOrdersDataAdapter.Update(oDS, "Orders");
            //conn.Close();
            /*dataAdapter.SelectCommand = command;
            //dataAdapter.UpdateCommand = new System.Data.OleDb.OleDbCommand("UPDATE amitTable;", conn);
          //  dataAdapter.InsertCommand = new System.Data.OleDb.OleDbCommand("INSERT INTO table (name1, name2) VALUES ( 333,33) ;", conn);
            //dataAdapter.Fill(dataset1);
            dataset1.Tables[0].Rows.Add(new object [] { "sfds" , "North West" });
            DataRow oOrderRow = oDS.Tables["table"].NewRow();
            oOrderRow["name1"] = "fdsfsd";

            dataAdapter.Update(dataset1,"table");
            //SqlCommand command  = new SqlCommand("SELECT * from amitTable",conn);
            System.Data.OleDb.OleDbDataReader reader = command.ExecuteReader();
            //conn.
            while(reader.Read())
            {
            MessageBox.Show("name " +
            reader[0] + " " +reader[1]+ " value " + reader[2]+" " + reader[3]);
            }
             * */
        }
       
        private void deleteAllrecordsFromDB()
        {
            DataSet oDS;
            System.Data.OleDb.OleDbDataAdapter oOrdersDataAdapter;
           
            oDS = new DataSet();
            oOrdersDataAdapter = new System.Data.OleDb.OleDbDataAdapter(new System.Data.OleDb.OleDbCommand("SELECT * FROM amitTable", conn));
            System.Data.OleDb.OleDbCommandBuilder oOrdersCmdBuilder = new System.Data.OleDb.OleDbCommandBuilder(oOrdersDataAdapter);
            oOrdersDataAdapter.FillSchema(oDS, SchemaType.Source);

            DataTable pTable = oDS.Tables["Table"];
            pTable.TableName = "statisticsTable";


            oOrdersDataAdapter.Fill(oDS);
            // Insert the Data
         //   oDS.Tables["statisticsTable"].Rows.Add(oOrderRow);
            //foreach (DataRow oOrderRow in oDS.Tables["statisticsTable"].Rows)
            //{
            //    oOrderRow.Delete();
            //}
            foreach (DataRow oOrderRow in oDS.Tables["Table"].Rows)
            {
                oOrderRow.Delete();
            }
            
            //oOrderRow["FirstName"] = (docNum + 1).ToString();
            //oOrderRow["Field1"] = performStatistics(docNum, docNum);
            //oDS.Tables["statisticsTable"].Rows.Add(oOrderRow);

            
            
            //oDS.Tables[0].Rows.Clear();
            //oDS.Tables[1].Rows.Clear();
            //oOrderRow["FirstName"] = (docNum + 1).ToString();
            //oOrderRow["Field1"] = performStatistics(docNum, docNum);
            //oDS.Tables["statisticsTable"].Rows.Add(oOrderRow);
            oOrdersDataAdapter.Update(oDS, "Table");
            //System.Data.OleDb.OleDbDataAdapter dataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            //System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand("SELECT* from amitTable;", conn);
                        
        }
        private int performStatistics(int fromSession, int toSession, int fromPatiant, int toPatiant)
        {
            int statisticsCounter = 0;
            MainForm mainForm = (MainForm)this.parentForm;
            int numOfSessions = mainForm.numOfSessions;
             int fromMinute = Convert.ToInt16(this.FromMinuteNumericUpDown.Value) * 2;
            int toMinute = Convert.ToInt16(this.ToMinuteNumericUpDown.Value) * 2;

            for (int listCounter = 0; listCounter < StatisticsArrayList.Count; listCounter++)
            {
                StatisticsListItem statisticsItem = (StatisticsListItem)StatisticsArrayList[listCounter];
                switch (statisticsItem.ItemType)
                {
                    case 1://instrument
                        for (int docCounter = fromSession; docCounter <= toSession; docCounter++)
                        {
                            for (int patiantCounter = fromPatiant; patiantCounter < toPatiant/*mainForm.SessionsArray[numOfSessions].document[docCounter].numOfPatiants*/; patiantCounter++)
                            {
                                bool dontCountThisPatiant = false;
                                foreach (CheckBox checkbox in checkBoxPanel.Controls)
                                {
                                    if (mainForm.SessionsArray[numOfSessions].document[docCounter].timeLine[patiantCounter].PatiantName == checkbox.Text && checkbox.Checked == false)
                                        dontCountThisPatiant = true;
                                }
                                if (dontCountThisPatiant)
                                    continue;
                                for (int minutesCounter = fromMinute; minutesCounter < /*mainForm.SessionsArray[numOfSessions].document[docCounter].sessionDuration * 2*/toMinute; minutesCounter++)
                                {
                                    if (mainForm.SessionsArray[numOfSessions].document[docCounter].timeLine[patiantCounter].MinutesArray[minutesCounter].instrumentStartHere)
                                    {

                                        InstrumentInfo instrument = (InstrumentInfo)mainForm.SessionsArray[numOfSessions].document[/*mainForm.SessionsArray[numOfSessions].docNumber*/docCounter].timeLine[patiantCounter].MinutesArray[minutesCounter].instrumetnInfo;

                                        //myImage my_image = (myImage)imageList[imageCounter];
                                        string instrName = instrument.Category + "\\" + instrument.SubCategory + "\\" + instrument.Name;
                                        if (statisticsItem.ItemName == instrName)
                                            statisticsCounter++;

                                    }
                                }
                            }
                        }
                        break;
                    case 2://text
                        for (int patiantCounter = 0; patiantCounter < mainForm.SessionsArray[numOfSessions].document[mainForm.SessionsArray[numOfSessions].docNumber].numOfPatiants; patiantCounter++)
                        {
                            for (int minutesCounter = 0; minutesCounter < mainForm.SessionsArray[numOfSessions].document[mainForm.SessionsArray[numOfSessions].docNumber].sessionDuration * 2; minutesCounter++)
                            {
                                if (mainForm.SessionsArray[numOfSessions].document[mainForm.SessionsArray[numOfSessions].docNumber].timeLine[patiantCounter].MinutesArray[minutesCounter].topicAndSubTopic == statisticsItem.ItemName)
                                {
                                    statisticsCounter++;
                                }
                            }
                        }
                        break;
                    case 3: //arrow

                        break;
                    case 4: //disc
                        for (int docCounter = fromSession; docCounter <= toSession; docCounter++)
                        {
                            for (int x = 0; x < mainForm.SessionsArray[numOfSessions].document[docCounter].DiscList.Count; x++)
                            {
                                Disc disc = (Disc)mainForm.SessionsArray[numOfSessions].document[docCounter].DiscList[x];
                                if (disc.startPoint >= fromMinute && disc.startPoint <= toMinute)
                                    statisticsCounter++;
                            }
                        }
                        break;
                    case 5://sing
                        for (int docCounter = fromSession; docCounter <= toSession; docCounter++)
                        {
                            for (int x = 0; x < mainForm.SessionsArray[numOfSessions].document[docCounter].SingScreamList.Count; x++)
                            {
                                SingSinusAndScreamZigzag sing = (SingSinusAndScreamZigzag)mainForm.SessionsArray[numOfSessions].document[docCounter].SingScreamList[x];
                                if (sing.startPoint >= fromMinute && sing.startPoint <= toMinute && sing.type == 1)
                                {
                                    bool dontCountThisPatiant = false;
                                    foreach (CheckBox checkbox in checkBoxPanel.Controls)
                                    {
                                        if (mainForm.SessionsArray[numOfSessions].document[docCounter].timeLine[sing.patiantNumber].PatiantName == checkbox.Text && checkbox.Checked == false)
                                            dontCountThisPatiant = true;
                                    }
                                    if (dontCountThisPatiant)
                                        continue;

                                    statisticsCounter++;
                                }
                            }
                        }
                        break;
                    case 6://scream
                        for (int docCounter = fromSession; docCounter <= toSession; docCounter++)
                        {
                            for (int x = 0; x < mainForm.SessionsArray[numOfSessions].document[docCounter].SingScreamList.Count; x++)
                            {
                                SingSinusAndScreamZigzag sing = (SingSinusAndScreamZigzag)mainForm.SessionsArray[numOfSessions].document[docCounter].SingScreamList[x];
                                if (sing.startPoint >= fromMinute && sing.startPoint <= toMinute && sing.type == 2)
                                {
                                    bool dontCountThisPatiant = false;
                                    foreach (CheckBox checkbox in checkBoxPanel.Controls)
                                    {
                                        if (mainForm.SessionsArray[numOfSessions].document[docCounter].timeLine[sing.patiantNumber].PatiantName == checkbox.Text && checkbox.Checked == false)
                                            dontCountThisPatiant = true;
                                    }
                                    if (dontCountThisPatiant)
                                        continue;

                                    statisticsCounter++;
                                }

                            }
                        }
                        break;
                    case 7://silence
                        for (int docCounter = fromSession; docCounter <= toSession; docCounter++)
                        {
                            for (int x = 0; x < mainForm.SessionsArray[numOfSessions].document[docCounter].SilencePanelList.Count; x++)
                            {
                                SilencePanel silence = (SilencePanel)mainForm.SessionsArray[numOfSessions].document[docCounter].SilencePanelList[x];
                                if (silence.startPoint >= fromMinute && silence.startPoint <= toMinute)
                                    statisticsCounter++;
                            }
                        }
                        break;
                }
            }
            
            return statisticsCounter;
        }
        private void SelectAllInstruments_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in InstrumentListView.Items)
                item.Selected = true;
            InstrumentListView.Focus();
        }

        private void DeleteFromListButton_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = StatisticsListView.SelectedItems;
            foreach (ListViewItem item in items)
            {
                int type = Convert.ToInt16(item.SubItems[4].Text);
                removeItemFromListView(type, item);

            }
        }
        private void removeItemFromListView(int type, ListViewItem item)
        {
            string instrumentName1 = item.Text;
            string instrumentCategory1 = item.SubItems[1].Text;
            string instrumentSubCategory1 = item.SubItems[2].Text;
            string instrumentDescription1 = item.SubItems[3].Text;
            string itemName1=instrumentCategory1 + "\\" + instrumentSubCategory1 + "\\" + instrumentName1;

            switch (type)
            {
                case 1:
                    for (int x = 0; x < StatisticsListView.Items.Count; x++)
                    {
                        string instrumentName = StatisticsListView.Items[x].Text;
                        string instrumentCategory = StatisticsListView.Items[x].SubItems[1].Text;
                        string instrumentSubCategory = StatisticsListView.Items[x].SubItems[2].Text;
                        string instrumentDescription = StatisticsListView.Items[x].SubItems[3].Text;
                        string itemName = instrumentCategory + "\\" + instrumentSubCategory + "\\" + instrumentName;
                        if (itemName == itemName1)
                        {
                            StatisticsListView.Items[x].Remove();
                        }
                    }
                    foreach (Object statisticsItem in StatisticsArrayList)
                    {
                        StatisticsListItem dd = (StatisticsListItem)statisticsItem;
                        string name = dd.ItemName;
                        if (name == itemName1)
                        {
                            StatisticsArrayList.Remove(statisticsItem);
                            break;
                        }
                    }
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    for (int x = 0; x < StatisticsListView.Items.Count; x++)
                    {
                        string instrumentName = StatisticsListView.Items[x].Text;
                        string instrumentCategory = StatisticsListView.Items[x].SubItems[1].Text;
                        string instrumentSubCategory = StatisticsListView.Items[x].SubItems[2].Text;
                        string instrumentDescription = StatisticsListView.Items[x].SubItems[3].Text;
                        string itemName = instrumentCategory + "\\" + instrumentSubCategory + "\\" + instrumentName;
                        if (itemName == itemName1)
                        {
                            StatisticsListView.Items[x].Remove();
                        }
                    }
                    foreach (Object statisticsItem in StatisticsArrayList)
                    {
                        StatisticsListItem dd = (StatisticsListItem)statisticsItem;
                        string name = dd.ItemName;
                        if (name == item.Text)
                        {
                            StatisticsArrayList.Remove(statisticsItem);
                            break;
                        }
                    }
                    break;

            }
        }

        private void InsertGeneralItemsToListButton_Click(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection items = GeneralStatisticItemsListView.SelectedItems;
            string picName="";
            for (int x = 0; x < items.Count; x++)
            {
                StatisticsListItem statisticsItem = new StatisticsListItem();
                string textTopic = items[x].Text;
                statisticsItem.ItemName = textTopic;

                ListViewItem ii = (ListViewItem)items[x].Clone();
                MainForm mainForm = (MainForm)this.parentForm;
                int numOfSessions = mainForm.numOfSessions;
                
                if (ii.Text == "Arrow")
                {
                    statisticsItem.ItemType = 3;
                    picName = mainForm.MainDirectory + "\\pictures\\arrow.jpg";
                    ii.SubItems.Add("3");
                }
                if (ii.Text == "Disc")
                {
                    statisticsItem.ItemType = 4;
                    picName = mainForm.MainDirectory + "\\pictures\\disc.jpg";
                    ii.SubItems.Add("4");
                }
                if (ii.Text == "Sing")
                {
                    statisticsItem.ItemType = 5;
                    ii.SubItems.Add("5");
                    picName = mainForm.MainDirectory + "\\pictures\\sing.jpg";
                }
                if (ii.Text == "Scream")
                {
                    statisticsItem.ItemType = 6;
                    picName = mainForm.MainDirectory + "\\pictures\\scream.jpg";
                    ii.SubItems.Add("6");
                }
                if (ii.Text == "Silence")
                {
                    statisticsItem.ItemType = 7;
                    picName = mainForm.MainDirectory + "\\pictures\\silence.jpg";
                    ii.SubItems.Add("7");
                }

               
                bool existsInStatisticsList = false;
                foreach (ListViewItem item in StatisticsListView.Items)
                {
                    if (item.Text == ii.Text )
                        existsInStatisticsList = true;
                }
                if (!existsInStatisticsList)
                {
                    Bitmap image1 = new Bitmap(picName);
                    Bitmap image = new Bitmap(image1, new Size(32, 32));
                    StatisticsListView.LargeImageList.Images.Add(image);
                    //ListViewItem textListItem = TextlistView.Items.Add(text.topic, x);
                    image = new Bitmap(image1, new Size(16, 16));
                    StatisticsListView.SmallImageList.Images.Add(image);
                    ii.ImageIndex = StatisticsListView.SmallImageList.Images.Count - 1;

                    StatisticsListView.Items.Add(ii);//add to view
                    StatisticsArrayList.Add(statisticsItem);//add to memory
                }
                //ListViewItem textListItem = StatisticsListView.Items.Add(InstrumentListView.Items[items[x]]);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            StatisticsListView.Clear();
            StatisticsArrayList.Clear();
            InitStatisticsListView();
            //StatisticsListView.SmallImageList.
        }

        private void CheckAllnamesButton_Click(object sender, EventArgs e)
        {
            foreach (Object checkbox in this.checkBoxPanel.Controls)
            {
                CheckBox tt =new CheckBox();
                Type type2 =tt.GetType();
                Type type=checkbox.GetType();
                if (type2==type)
               ((CheckBox) checkbox).Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Object checkbox in this.SessionCheckBoxPanel.Controls)
            {
                CheckBox tt = new CheckBox();
                Type type2 = tt.GetType();
                Type type = checkbox.GetType();
                if (type2 == type)
                    ((CheckBox)checkbox).Checked = true;
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //crystalReportViewer1.cre
        }

        private void SessionRangeCountRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SessionRangeCountRadioButton.Checked)
                this.SessionComparisonRadioButton.Checked = false;
            else
                this.SessionComparisonRadioButton.Checked = true;

        }

        private void SessionComparisonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SessionComparisonRadioButton.Checked)
                this.SessionRangeCountRadioButton.Checked = false;
            else
                this.SessionRangeCountRadioButton.Checked = true;
        }

      
       
    } 
    public class StatisticsListItem
    {
        public StatisticsListItem() { }
        public int ItemType; //1-instrument;2-text;3-arrow
        public string ItemName;
    }
    
}