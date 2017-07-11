using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace musicTherapy1
{
	/// <summary>
	/// Summary description for Document.
	/// 
	/// </summary>

	[Serializable]
	public class InstrumentsDocument
	{
		//public ArrayList instrumetnInfoList = new ArrayList();

	}
	
	
	[Serializable]
	public class Document
	{
		public string version="1.0";
		public ArrayList listText = new ArrayList();
		public ArrayList videoFileList = new ArrayList();
		public ArrayList SingScreamList = new ArrayList();
		public ArrayList DiscList  = new ArrayList();
		public ArrayList RichTextList  = new ArrayList();
		public TimeLine[] timeLine;
		public int numOfPatiants;
		public int sessionDuration;
		public int numOfButtonsInTimeLine;
		public int numOfPanelsInSession=3;
		public SessionColors sessionColor;
		public int proportionOfPanelArearAndTextArea= 70;
		public int percentOfPanelAreaOfHoleWindow= 95;
		public int numOfTextBoxes=0;
		public int numOfTextBoxColumns=6;
		public int numOfTextBoxInColumn=6;
		public int widthOfTimeLineButton=2;//2, 4, 6, 8, 10
		public int widthOfLable=15;
		public int heightOfLable=15;	
		public int percentOfSpaceBeforeButtonsInTimeLine=10;
		public int percentOfSizeOfNameButtonOfSizeOfSpaceBeforeButtonInTimeLine=80;
		public int percentOfSizeOfSpaceBetweenNameButtonsAndCurlyBraces=3;
		public int intervalBetweenDashedVerticalLinesInTimeLine=5;
		public int nameButtonHeight=20;
		public int widthOfEndInstrumentSectionButton = 5;
		public int heightOfEndInstrumentSectionButton = 20;
		public Color ColorForButtonsWithDisc=Color.Brown;
		public Color EndInstrumentButtonColor = Color.Blue;
		public Color ColorForAbsentPatiant=Color.Gray;//Color.FromArgb(20,Color.Gray);
		//public int timeIntervalBetweenBars;
		public Document(int numOfPatiantsa, int sessionDurationa, int timeIntervalBetweenBarsa )
		{
			this.numOfPatiants=numOfPatiantsa;
			this.sessionDuration= sessionDurationa;
			this.numOfButtonsInTimeLine= this.sessionDuration/numOfPanelsInSession*2;
			this.intervalBetweenDashedVerticalLinesInTimeLine = timeIntervalBetweenBarsa;
		}
		public void initTimeLines()
		{
			
			timeLine= new TimeLine[numOfPatiants]; 
			sessionColor= new SessionColors();
			for (int x=0;x<numOfPatiants;x++)
			{
				timeLine[x]=new TimeLine(x+1, sessionDuration);
			}
			
		}
	}
	[Serializable]
	public class TimeLine
	{
		public TimeLine(int x, int sessionDuration)
		{
			switch (x)
			{
				case 1:
					ButtonColor=Color.Black;
					PatiantName="Therapist";
					break;
				case 2:
					ButtonColor=Color.Black;
					PatiantName="Client";
					break;
			}
			if (x>2)
			{
				ButtonColor=Color.Black;
				PatiantName="P-"+x;	
			}
			MinutesArray= new Minute[sessionDuration*2];
			for (int min=0 ;min<sessionDuration*2;min++)
				MinutesArray[min]= new Minute();
		}
		public Minute[] MinutesArray;
		public string PatiantName="DUDI";
		public bool IsPatiantAbsent = false;
		public Color ButtonColor=Color.Black;
		public Color TextColor=Color.White;
		public string additionalInfoAboutPatiant="Add additional text here about the patiant";
		//private int FromMinute=0;
	}
	[Serializable]
	public class SessionColors 
	{
		public Color frameBackroundColor=Color.WhiteSmoke;
		public Color PanelColor=Color.White;
	}
	
	[Serializable]
	public class Minute
	{
		public string topicAndSubTopic;
		public  int     levelOfInstrumentIntensity=2;
		public  bool    instrumentStartHere;
		public  bool    instrumentEndHere;
		public  bool    isInstrumentInButton=false;
		public  InstrumentInfo instrumetnInfo;
		public bool isOpacPanelStartHere=false;
		public OpacPanel opacPanel;
		public Color buttonBackColor=Color.Black;
		public ArrayList arrowList;
		
		public Minute()
		{
			isInstrumentInButton=false;
			instrumetnInfo=new InstrumentInfo("","","","");
			opacPanel=new OpacPanel(Color.Red,100,new Point(0,0));
			arrowList = new ArrayList();
		}
	}
	[Serializable]
	public class OpacPanel
	{
		public Color color;
		public int opacity;
		public Point endPoint;
		
		public OpacPanel(Color color,int opacity,Point endPoint)
		{
			this.color= color;
			this.opacity=opacity;
			this.endPoint=endPoint;
		}
	}
	[Serializable]
	public class SingSinusAndScreamZigzag
	{
		public int frequency;
		public int amplitude;
		public int type; //sing=1 scream=2;
		public int startPoint;
		public int endPoint;
		public Color color;
		public int patiantNumber;
		public int Width;
		public int Phase;
	}
	[Serializable]
	public class RichTextAboveTimeLine
	{
		//public RichTextBox richTextBox;
		public string RTF;
		public string Text;
		public string AdditionalText;
		public int startPoint;
	}
	[Serializable]
	public class Disc
	{
		public int startPoint;
		public int endPoint;
		public Color color;
		public string title;
		public string performance;
		public string additionlInfo;
		public Disc()
		{
			startPoint=0;
			endPoint=0;
			color=Color.White;
			title="";
			performance="";
			additionlInfo="";
		}
	}
	[Serializable]
	public class VideoFile
	{
		public string videoFileName;
		public double videoFileDuration;
		public int startPoint;
		public int endPoint;
		public VideoFile()
		{
			videoFileName="";
			videoFileDuration=0;
		}
	}
	[Serializable]
	public class Arrow
	{
		public Color color;
		public Point startPoint;
		public Point endPoint;
		public int arrowType=1;//1- button to button
						//2- buton to picture
						//3- picture to picture
						//4- picture to button
		public Arrow(Color color,Point startPoint,Point endPoint,int arrowType)
		{
			this.color= color;
			this.startPoint= startPoint;
			this.endPoint=endPoint;
			this.arrowType=arrowType;
		}
	}
	[Serializable]
	public class TextTalkedinSession
	{
		public string shortText;
		public string longText;
		public string topic;
		public string subTopic;
		public TextTalkedinSession(string shortText,string longText,string topic,string subTopic)
		{
			this.shortText=shortText;
			this.longText=longText;
			this.topic=topic;
			this.subTopic=subTopic;
		}
	}
	enum instruments
	{
		noInstrument=0 , drum, guitar, recorder, triangle, keyboard
	}

	
}
