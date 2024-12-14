using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public partial class VideoGUI : Form
    {
        public VideoGUI()
        {
            InitializeComponent();
        }



        private void VideoGUI_Load(object sender, EventArgs e)
        {
            MediaPlayer.Visible = false;
            queryPicture.Visible = false;


        }


        private void rBtnVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnPlayVid.Checked)
            {
                queryPicture.Visible = false;
                MediaPlayer.Visible = true;

            }
            else
            {
                queryPicture.Visible = true;
                MediaPlayer.Visible = false;
            }
        }
    }
}
