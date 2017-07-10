using System;
using System.Windows.Forms;

namespace musicTherapy1
{
    /*public partial class StatisticsReportChart : Form
    {
        public Form parentForm;
        public StatisticsReportChart()
        {
            InitializeComponent();
        }
        public  CrystalDecisions.Windows.Forms.CrystalReportViewer reportView
        {
            get { return this.crystalReportViewer1; }
        }
        public void changeDatabase()
        {
            CrystalReport1 crReportDocument = new CrystalReport1();
            Database crDatabase;
            Tables crTables;
            Table crTable;
            TableLogOnInfo crTableLogOnInfo;
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            //System.Data.OleDb.OleDbConnection aaa = new System.Data.OleDb.OleDbConnection();

            //Setup the connection information structure
            //to log on to the data source for the report.
            // If using ODBC, this should be the DSN. If using
            // OLEDB, etc, this should be the physical server name


            //crConnectionInfo.ServerName = "Microsoft.Jet.OLEDB.4.0";

            // If you are connecting to Oracle there is no
            // DatabaseName. Use an empty
            // string i.e. crConnectionInfo.DatabaseName = "";
            //MainForm mainForm = (MainForm)this.parentForm;
            Statistics stat = (Statistics)this.parentForm;
            MainForm mainForm = (MainForm)stat.parentForm;
            string dbName = mainForm.MainDirectory + "\\db2.mdb";
            crConnectionInfo.ServerName = dbName;// @"D:\Documents and Settings\amklein\" + @"My Documents\db3.mdb";
            //        crConnectionInfo.UserID = "";
            //crConnectionInfo.Password = "";

            // This code works for both user tables and stored
            //procedures

            //Get the table information from the report
            crDatabase = crReportDocument.Database;
            crTables = crDatabase.Tables;

            //Loop through all tables in the report and apply the
            //connection information for each table.
            for (int i = 0; i < crTables.Count; i++)
            {
                crTable = crTables[i];
                crTableLogOnInfo = crTable.LogOnInfo;
                crTableLogOnInfo.ConnectionInfo =
                crConnectionInfo;
                crTable.ApplyLogOnInfo(crTableLogOnInfo);

                //If your DatabaseName is changing at runtime, specify
                //the table location. For example, when you are reporting
                //off of a Northwind database on SQL server
                //you should have the following line of code:

                //crTable.Location = "Northwind.dbo." + crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1);
            }
            this.crystalReportViewer1.ReportSource = crReportDocument;
        }
        private void StatisticsReportChart_Load(object sender, EventArgs e)
        {
            changeDatabase();
            CrystalReport1 cry = (CrystalReport1)this.crystalReportViewer1.ReportSource;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.RefreshReport();
            //cry.ReportDefinition.ReportObjects.
            //ChartObject chart = cry.Section1.ReportObjects[0];
            //chart.
            //Object ff= 
             //MessageBox.Show("f :" + ff.GetType());
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
        
        }

        private void StatisticsReportChart_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Statistics)this.parentForm).report = null;
        }
    }*/
}