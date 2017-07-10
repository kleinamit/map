using System;
using System.Drawing;
using System.Windows.Forms;

namespace musicTherapy1
{
    public partial class SilenceAttributes : Form
    {
        public SilenceAttributes()
        {
            InitializeComponent();
        }
        public Color SilenceColor
        {
            get { return this.ColorPanel.BackColor; }
            set { this.ColorPanel.BackColor = value; }
        }
        public string SilenceTime
        {
            get
            {
                return this.TimeTextBox.Text;
            }
            set
            {
                this.TimeTextBox.Text = value;
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