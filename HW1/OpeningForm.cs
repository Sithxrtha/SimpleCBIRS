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
    public partial class OpeningForm : Form
    {
        public OpeningForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImageGUI form1 = new ImageGUI();
            form1.ShowDialog();
        }

        private void btnVid_Click(object sender, EventArgs e)
        {
            VideoGUI form1 = new VideoGUI();
            form1.ShowDialog();
        }
    }
}
