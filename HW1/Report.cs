using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HW2
{
    internal class Report
    {
        public Report() { }

        private Bitmap ResizeImage(Bitmap img, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(img, 0, 0, width, height);
            }
            return resizedImage;
        }

        public void createTablePanel(bool intensityChecked, List<(double distance, int index)> Intensity, List<(double distance, int index)> ColorC, TableLayoutPanel tableLayoutPanel1, ListBox lstView)
        {
            List<(double distance, int index)> selectedList = intensityChecked ? Intensity : ColorC;

            // Clear query if queried earlier
            tableLayoutPanel1.Controls.Clear();

            // Set the number of columns
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.RowCount = (int)Math.Ceiling((double)lstView.Items.Count / tableLayoutPanel1.ColumnCount);

            // Set the size for each PictureBox and Label
            int pictureBoxWidth = 133;
            int pictureBoxHeight = 144;

            for (int i = 0; i < selectedList.Count; i++)
            {
                // Calculate the current column and row
                int col = i % tableLayoutPanel1.ColumnCount;
                int row = i / tableLayoutPanel1.ColumnCount;

                // Use Image to then resize with method
                Bitmap img = new Bitmap(lstView.Items[selectedList[i].index].ToString());

                // Create a Panel to hold both controls
                Panel panel = new Panel
                {
                    Size = new Size(pictureBoxWidth, pictureBoxHeight + 20), // Adjust height for the CheckBox
                    Dock = DockStyle.Fill
                };

                // Create PictureBox
                var pictureBox = new PictureBox
                {
                    Image = ResizeImage(img, pictureBoxWidth, pictureBoxHeight), // Resize image

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Name = "picBox" + selectedList[i].index.ToString(),
                    Width = pictureBoxWidth,
                    Height = pictureBoxHeight,
                    Dock = DockStyle.Top // Align to the top of the cell
                };

                panel.Controls.Add(pictureBox);


                // Add controls to the TableLayoutPanel
                tableLayoutPanel1.Controls.Add(panel, col, row);
            }
            // Adjust row heights if needed
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize + 20)); // Auto size the rows
            }
        }

        public void createDGV(bool intensityChecked, List<(double distance, int index)> Intensity, List<(double distance, int index)> ColorC, DataGridView dataGridView1, ListBox lstView)
        {
            /* 
             * For DGV GUI: Better for reporting
             */

            // Clear existing rows if it had already been queried
            dataGridView1.Rows.Clear();

            // Set column widths and row height
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 133;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 100;

            dataGridView1.RowTemplate.Height = 144;

            // Initialized bool to select proper list
            List<(double distance, int index)> selectedList = intensityChecked ? Intensity : ColorC;

            // Runs through list to display the sorted order of images in regards to distance
            int offset = 1;
            for (int i = 0; i < selectedList.Count; i++)
            {
                // Obtains image and then resizes it using method
                Bitmap image = new Bitmap(lstView.Items[selectedList[i].index].ToString());
                Bitmap resizedImg = ResizeImage(image, 133, 144);
                // Add datagridview rows with the proper parameters
                dataGridView1.Rows.Add(i + offset, resizedImg, lstView.Items[selectedList[i].index].ToString(), Math.Round(selectedList[i].distance, 4));
            }
        }

        /*
        * Creates the Table Panel intended for relevance feedback
        */
        public void createTablePanel_RF(List<(double distance, int index)> normalizedFt, TableLayoutPanel tableLayoutPanel1, ListBox lstView, List<int> imgIndexRF, CheckBox chkRF)
        {
            // Initialized bool to select proper list
            List<(double distance, int index)> selectedList = normalizedFt;

            // Clear query if queried earlier
            tableLayoutPanel1.Controls.Clear();

            // Set the number of columns
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.RowCount = (int)Math.Ceiling((double)lstView.Items.Count / tableLayoutPanel1.ColumnCount);

            // Set the size for each PictureBox and Label
            int pictureBoxWidth = 133;
            int pictureBoxHeight = 144;

            for (int i = 0; i < selectedList.Count; i++)
            {
                // Calculate the current column and row
                int col = i % tableLayoutPanel1.ColumnCount;
                int row = i / tableLayoutPanel1.ColumnCount;

                // Use Image to then resize with method
                Bitmap img = new Bitmap(lstView.Items[selectedList[i].index].ToString());

                // Create a Panel to hold both controls
                Panel panel = new Panel
                {
                    Size = new Size(pictureBoxWidth, pictureBoxHeight + 20), // Adjust height for the CheckBox
                    Dock = DockStyle.Fill
                };

                // Create PictureBox
                var pictureBox = new PictureBox
                {
                    Image = ResizeImage(img, pictureBoxWidth, pictureBoxHeight), // Resize image

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = lstView.Items[selectedList[i].index].ToString(),
                    Width = pictureBoxWidth,
                    Height = pictureBoxHeight,
                    Dock = DockStyle.Top // Align to the top of the cell
                };

                panel.Controls.Add(pictureBox);

                // Add controls to the TableLayoutPanel
                tableLayoutPanel1.Controls.Add(panel, col, row);
            }

            if (chkRF.Checked) // ensures it adds checkbox to panel when "relevance feedback" is checked
            {
                //insert checkbox for each panel
                for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
                {
                    for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
                    {
                        int index = (row * 5) + col;

                        Panel panel = (Panel)tableLayoutPanel1.GetControlFromPosition(col, row);

                        //create textbox
                        var checkBox = new CheckBox();
                        checkBox.Dock = DockStyle.Bottom;
                        checkBox.Text = "Relevant";
                        if (imgIndexRF.Contains(selectedList[index].index))  // checks true for images previously deemed relevant when "update" button was clicked
                            checkBox.Checked = true;
                        else
                            checkBox.Checked = false;

                        panel.Controls.Add(checkBox);
                    }
                }
            }

            // Adjust row heights if needed
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize + 20)); // Auto size the rows
            }
            return;
        }

        /*
         * Creates the data grid view intended for relevance feedback
         */
        public void createDGV_RF(List<(double distance, int index)> normalizedFt, DataGridView dataGridView1, ListBox lstView, List<int> imgIndexRF)
        {
            // Clear existing rows if it had already been queried
            dataGridView1.Rows.Clear();

            // Set column widths and row height
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 133;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 100;

            dataGridView1.RowTemplate.Height = 144;

            // Initialized bool to select proper list
            List<(double distance, int index)> selectedList = normalizedFt;

            // Runs through list to display the sorted order of images in regards to distance
            int offset = 1;
            for (int i = 0; i < selectedList.Count; i++)
            {
                // Obtains image and then resizes it using method
                Bitmap image = new Bitmap(lstView.Items[selectedList[i].index].ToString());
                Bitmap resizedImg = ResizeImage(image, 133, 144);

                // Add datagridview rows with the proper parameters
                if (dataGridView1.Columns[2].Name == "colRFCheck")
                {
                    if (imgIndexRF.Contains(selectedList[i].index)) // ensures it adds checkbox to panel when "relevance feedback" is checked
                    {
                        dataGridView1.Rows.Add(i + offset, resizedImg, true, lstView.Items[selectedList[i].index].ToString(), Math.Round(selectedList[i].distance, 4));
                    }
                    else
                    {
                        dataGridView1.Rows.Add(i + offset, resizedImg, false, lstView.Items[selectedList[i].index].ToString(), Math.Round(selectedList[i].distance, 4));
                    }
                }
                else
                {
                    dataGridView1.Rows.Add(i + offset, resizedImg, lstView.Items[selectedList[i].index].ToString(), Math.Round(selectedList[i].distance, 4)); // creates data grid view when relevance feedback is not checked
                }
            }
            return;
        }
    }
}
