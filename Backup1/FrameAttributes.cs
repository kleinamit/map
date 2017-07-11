using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace musicTherapy1
{
    public partial class FrameAttributes : Form
    {
        public FrameAttributes()
        {
            InitializeComponent();
        }
        public Color FrameColor
        {
            get { return this.ColorPanel.BackColor; }
            set { this.ColorPanel.BackColor = value; }
        }
        public int FrameType
        {
            get
            {
                return this.TypeListBox.SelectedIndex;
            }
            set
            {
                this.TypeListBox.SelectedIndex = value;
            }
        }
        public int FrameWidth
        {
            get
            {
                return (int)this.WidthnumericUpDown1.Value;
            }
            set
            {
                this.WidthnumericUpDown1.Value = value;
            }
        }
        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Color_Click(object sender, EventArgs e)
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
    }
}