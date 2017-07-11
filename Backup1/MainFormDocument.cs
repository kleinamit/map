using System;
using System.Collections;
namespace musicTherapy1
{
	/// <summary>
	/// Summary description for MainFormDocument.
	/// </summary>
	[Serializable]
	public class MainFormDocument
	{
		public ArrayList instrumetnInfoList = new ArrayList();
		public MainFormDocument()
		{
			
			//
			// TODO: Add constructor logic here
			//
		}
		public int numOfInstrumentsInLine=6;
        public int HeightOfInstrumentPicture = 60;
        public int WidthOfInstrumentPicture = 60;
        public int upBorderHeight = 50;
        public int sidesBorderWidth = 200;
        public int verticalIntervalBetweenPictures = 50;
        public int HorizontalIntervalBetweenPictures = 20;
        public int heighOfCategoryAndSubCategoryLable = 50;
		

	}
}
