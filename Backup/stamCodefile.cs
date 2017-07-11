/*private void buttonDragLeave(object sender, System.EventArgs e)
		{
			AButton tmp= (AButton) sender; 
			tmp.DoDragDrop(tmp.Text, DragDropEffects.Copy | 
				DragDropEffects.Move);
			for (int x=0;x<this.document[docNumber].numOfPatiants;x++)
				for (int y=0;y<60;y++)
				{
					ButtonArray[x,y].Pressed= false;
				}
			tmp.Pressed=true;
			
		}
		*/	
		/*private void buttonDragEnter(object sender, 
			System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.Text)) 
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}
		private void buttonDragDrop(object sender, 
			System.Windows.Forms.DragEventArgs e)
		{
			AButton tmp= (AButton) sender; 
			int fromButton=0, toButton=0;
			for (int x=0;x<this.document[docNumber].numOfPatiants;x++)
				for (int y=0;y<60;y++)
				{
					if (ButtonArray[x,y].Pressed==true)
					{
						//ButtonArray[x,y].Pressed=false;
						fromButton= y;
					}
					ButtonArray[x,y].Pressed= false;
				}
			//tmp.Pressed=true;
			toButton=tmp.x;
			//MainForm tmpMF=  (MainForm ) this.MdiParent;
			if (this.ChoosedInstrument != (int)instruments.noInstrument)
			{
				for (int x=fromButton;x<toButton;x++)
					this.document[docNumber].timeLine[tmp.y].MinutesArray[x].InstrumentType=this.ChoosedInstrument;
				this.AddInstrument();
			}

			for (int x=0;x<this.document[docNumber].numOfPatiants;x++)
				for ( int y=0;y<60;y++)
				{
					ButtonArray[x,y].Pressed= false;
				}
			//tmp.Text = e.Data.GetData(DataFormats.Text).ToString();
		}
		*/

//string a="A2";
			//string bb= "A3";
			//compare= a.CompareTo(bb);//-1  
			//compare=bb.CompareTo(a);//1

	/*	int z, s;

					// Loop through the images pixels to reset color.
					for(z=0; z<image1.Width; z++)
					{
						for(s=0; s<image1.Height; s++)
						{
							Color pixelColor = image1.GetPixel(z, s);
							Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
							image1.SetPixel(z, s, newColor);
						}
					}*/
				//	CurlyBracesArray[panelCounter].Location = calculateCurlyBracesLocation(timeLinePanel[panelCounter]);//new Point(0,0);
				
					
				
						//Size= calculateCurlyBracesSize(timeLinePanel[panelCounter]);
				
					// Set the PictureBox to display the image.
					//PictureBox PictureBox1=new PictureBox();

	//MainForm  mnfrm = (MainForm)this.MdiParent;
				//CurlyBracesArray[panelCounter].Image=mnfrm.InstrumentImageList.Images[8];
					

//				Image image1 = new Bitmap(@"C:\Documents and Settings\All Users\" 
//					+ @"Documents\My Music\curlyBracats.bmp", true);

//				CurlyBracesArray[panelCounter].Image=new Bitmap("curlyBracats.bmp",true);
				//(Bitmap)(resources.GetObject("name")


		//System.Drawing.Image.GetThumbnailImageAbort dummyCallBack    = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
				//CurlyBracesArray[panelCounter].Image.GetThumbnailImage(1000,1000,dummyCallBack, IntPtr.Zero);
				//System.Drawing.Image fullSizeImg    = CurlyBracesArray[panelCounter].Image;
				//System.Drawing.Image thumbNailImg    = fullSizeImg.GetThumbnailImage(100, 100, dummyCallBack, IntPtr.Zero);
				//CurlyBracesArray[panelCounter].ClientSize=calculateCurlyBracesSize(timeLinePanel[panelCounter]);
				//CurlyBracesArray[panelCounter].BorderStyle =BorderStyle.FixedSingle;	
			