using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SkiaSharp;
using System.CodeDom;
using System.Text.RegularExpressions;
using HW4;

namespace HW2
{

    public partial class ImageGUI : Form
    {
        public ImageGUI()
        {
            InitializeComponent();
        }

        /* Assignment 2 Code Specified Underneath ******************************************************************************************************/

        Features features = new Features();
        FeaturesRF featuresRF = new FeaturesRF();
        Report report = new Report();


        List<(double[] normFts, int index)> normalizedFts = new List<(double[], int index)>();
        // Initialize for image retrieval and norm weights storage
        List<double> normWeight = new List<double>();
        List<int> imgIndexRF = new List<int>();

        /* 
         * This function combines the two methods and obtains the normalized features 
         */
        private void combineIntensityColorCode()
        {
            List<double[]> featuresList = new List<double[]>(); //initialize to combine both intensity and color code bins

            for (int i = 0; i < lstView.Items.Count; i++) // go through image count on listbox and combine the bins together
            {
                double[] newList = new double[listIntensity[i].Length + listColorC[i].Length];
                for (int j = 0; j < listIntensity[i].Length; j++)
                {
                    newList[j] = (double)listIntensity[i][j] / (double)pixels[i];
                }
                for (int k = 0; k < listColorC[i].Length; k++)
                {
                    newList[k + listIntensity[i].Length] = (double)listColorC[i][k] / (double)pixels[i];
                }
                featuresList.Add(newList);
            }

            List<double> averageBins = featuresRF.average(featuresList); // obtains average per bin
            List<double> stdBins = featuresRF.standardDeviation(featuresList, averageBins); // obtains standard deviation per bin

            normalizedFts = featuresRF.createNormalizedFeatures(featuresList, averageBins, stdBins); // Creates and stores the normalized features
        }

        /*
         * Function obtains the checked images from the query, and then stores it for post-query checks
         */
        private List<int> retrieveChecked(List<(double distance, int index)> copyOfSortedRF)
        {
            List<int> selectedImages = new List<int>();

            if (rBtnPanel.Checked) // adds checkbox to panels within the tablelayout panel
            {
                for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
                {
                    for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
                    {
                        Panel panel = (Panel)tableLayoutPanel1.GetControlFromPosition(col, row); //obtains panel control
                        if (panel != null)
                        {
                            foreach (Control control in panel.Controls) //checks if it is a check box
                            {
                                if (control is CheckBox checkBox && checkBox.Checked)
                                {
                                    int index = (row * 5) + col; // gets the index to use for sort list

                                    selectedImages.Add(copyOfSortedRF[index].index); // use "index" variable to find the index of the image
                                }
                            }
                        }
                    }
                }
                return selectedImages; // return to acknowledge the checked images for image retrieval and for storage
            }
            else
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    // check if the cell in the checkbox column is not null and is checked
                    if (dataGridView1.Rows[i].Cells[2].Value is bool isChecked && isChecked)
                    {
                        selectedImages.Add(sortedRF[i].index);
                    }
                }
                return selectedImages; // return to acknowledge the checked images for image retrieval and for storage
            }
        }

        /*
         * Button allowing the user to query the update with the following images that are relevant or reset query
         */
        private void btnQueryRF_Click(object sender, EventArgs e)
        {
            imgIndexRF = retrieveChecked(sortedRF);

            if (imgIndexRF.Count == 0 || imgIndexRF == null)
            {
                displayResults2(); // allows requery for users to reset
                return;
            }

            List<double[]> normFtsUsed = new List<double[]>();

            for (int i = 0; i < imgIndexRF.Count; i++) //appends necessary normalized features of images for manhattan distance formula
            {
                int value = imgIndexRF[i];
                normFtsUsed.Add(normalizedFts[value].normFts);
            }

            List<double> averageBins = featuresRF.average(normFtsUsed); // obtains average of all bins
            List<double> stdBins = featuresRF.standardDeviation(normFtsUsed, averageBins); // obtains standard deviation of all bins

            //obtain the values
            List<double> updateWeightBins = featuresRF.updateWeight(stdBins, averageBins);

            normWeight = featuresRF.normalizedWeight(updateWeightBins); // obtains the normalized weights of 

            displayResultsQuery(); // runs query for updating GUI by the relevant images
        }

        /*
         * Checkbox used to add or remove checkboxes necessary for relevance feedback
         */
        private void chkRF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRF.Checked)
            {
                // expand and enable controls for usability
                gboSearchTools.Height = 220;
                btnQueryRF.Visible = true;

                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "colRFCheck";
                checkColumn.HeaderText = "Relevance Feedback Checkbox";

                //insert column for datagridview
                dataGridView1.Columns.Insert(2, checkColumn);

                //insert checkbox for each panel
                for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
                {
                    for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
                    {
                        Panel panel = (Panel)tableLayoutPanel1.GetControlFromPosition(col, row);

                        //create textbox
                        var checkBox = new CheckBox
                        {
                            Dock = DockStyle.Bottom,
                            Text = "Relevant",
                            //Name = "chkBox" + lstView.Items[selectedList[i].index].ToString()
                        };

                        panel.Controls.Add(checkBox);
                    }
                }
            }
            else
            {
                // shrink and disable controls to prevent user usability
                gboSearchTools.Height = 122;
                btnQueryRF.Visible = false;

                // delete column
                if (dataGridView1.Columns[2].Name == "colRFCheck")
                {
                    dataGridView1.Columns.Remove(dataGridView1.Columns[2]);
                }

                // delete label, used GPT to help perform this task
                /*
                 * OpenAI, LLC. (n.d.). "how can I delete checkbox from a panel control after insert?" ChatGPT. https://chat.openai.com
                 */
                // Iterate through each panel in the TableLayoutPanel
                for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
                {
                    for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
                    {
                        Panel panel = (Panel)tableLayoutPanel1.GetControlFromPosition(col, row);

                        if (panel != null) // Ensure the panel is not null
                        {
                            // Iterate through the panel's controls to find and remove checkboxes
                            for (int i = panel.Controls.Count - 1; i >= 0; i--) // Loop backwards
                            {
                                if (panel.Controls[i] is CheckBox) // Check if the control is a CheckBox
                                {
                                    panel.Controls.RemoveAt(i); // Remove the CheckBox
                                }
                            }
                        }
                    }
                }
            }
        }

        /*
         * Displays result for all relevant images
         */
        private void displayResultsQuery()
        {
            distanceRF.Clear();

            // Calculates manhattan distance with stored lists (obtained from the form load)
            featuresRF.manhattanDistanceRF(normalizedFts, normWeight, distanceRF, lstView);

            //obtains the sorted list
            sortedRF = features.sortList(distanceRF);

            //output to GUI
            displayToGUI_RF(rbtnInCC.Checked, sortedRF);
        }

        List<(double distance, int index)> sortedRF = new List<(double distance, int index)>();

        /*
         * Displays result for if there are no relevant images or first searched
         */
        private void displayResults2()
        {
            distanceRF.Clear();
            imgIndexRF.Clear();

            // Update statuses
            lblStatus.Text = "Show Method Status: Loading...";

            // Calculates manhattan distance with stored lists (obtained from the form load)
            featuresRF.manhattanDistanceRF(normalizedFts, null, distanceRF, lstView);

            //obtains the sorted list
            sortedRF = features.sortList(distanceRF);

            //output to GUI
            displayToGUI_RF(rbtnInCC.Checked, sortedRF);

            lblStatus.Text = "Show Method Status: Done";
        }

        /*
         * Displays GUI for both display results functions
         */
        private void displayToGUI_RF(bool rfCheck, List<(double distance, int index)> normalizedFt)
        {
            /* 
             * DGV GUI: Better for reporting
             * Table GUI: Better for visualization
             */
            report.createDGV_RF(normalizedFt, dataGridView1, lstView, imgIndexRF);
            report.createTablePanel_RF(normalizedFt, tableLayoutPanel1, lstView, imgIndexRF, chkRF);
        }

        List<double> distanceRF = new List<double>();

        /* Code from assignment 1 below ***********************************************
         * 
         */

        private void Form1_Load(object sender, EventArgs e)
        {
            loadLst(); // Loads list box items, fills for user to select between many files

            calculateAllPictures(); // calculates all pictures regarding the two methods to ensure query time is faster 

            combineIntensityColorCode();

            try // Makes a temporary file for image features relevant to a method found later in code
            {
                using (FileStream fs = File.Create("temp.txt"))
                { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the file: " + ex.Message);
            }
        }

        /*
         * Summary: initializes variables to store related variables as functions are ran to lower query time
         */

        private List<int> pixels = new List<int>(); // Stores pixel count for manhattan distance formula

        private List<int[]> listIntensity = new List<int[]>(); // Stores bins in list after Formload and CalculateAllPictures runs
        private List<int[]> listColorC = new List<int[]>();

        private List<double> distanceIntensity = new List<double>(); // Stores values in respect to the index for distances obtained from function
        private List<double> distanceColorC = new List<double>();

        private void loadLst()
        {
            // Get all .jpg files in the "images" directory
            string[] jpgFiles = Directory.GetFiles("images", "*.jpg");
            string[] copy = Directory.GetFiles("images", "*.jpg");

            var fileNumberPairs = new List<(string filepath, int number)>(); // Useful for sorting

            // For reordering files to the specified #.jpg
            for (int i = 0; i < copy.Length; i++)
            {
                copy[i] = copy[i].Substring(7).Replace(".jpg", "");
                int num = int.Parse(copy[i]);

                fileNumberPairs.Add((jpgFiles[i], num));
            }

            // Sort the list by the integer value, Source ChatGPT
            var sortedFileNumberPairs = fileNumberPairs.OrderBy(pair => pair.number).ToList();

            for (int i = 0; i < sortedFileNumberPairs.Count; i++)
            {
                lstView.Items.Add(sortedFileNumberPairs[i].filepath); // Add sorted file paths to the list view
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap myImg = new Bitmap(lstView.SelectedItem.ToString()); // Obtains image from list box

            int hor = myImg.Height;
            int width = myImg.Width;
            Size newS = new Size(width, hor);
            queryPicture.Size = newS;
            queryPicture.Image = myImg; // Sets query picture to the picture box

            // Initializes points after image resize for relocation of specified controls
            Point newP = new Point(queryPicture.Location.X + width + 25, gboMethods.Location.Y);
            Point newP2 = new Point(queryPicture.Location.X + width + 275, gboImgSel.Location.Y);
            Point newP3 = new Point(queryPicture.Location.X + width + 275, gboImgRet.Location.Y);
            Point newP4 = new Point(queryPicture.Location.X + width + 25, gboBtns.Location.Y);
            Point newP5 = new Point(queryPicture.Location.X + width + 275, lblStatus.Location.Y);
            Point newP6 = new Point(queryPicture.Location.X + width + 550, gboSearchTools.Location.Y);

            // Updates locations of controls with the given points
            gboMethods.Location = newP;
            gboImgSel.Location = newP2;
            gboImgRet.Location = newP3;
            gboBtns.Location = newP4; //x 386  y 169
            lblStatus.Location = newP5;
            gboSearchTools.Location = newP6;

            // Displays file name
            lblPicFile.Text = "Image File Name: " + lstView.SelectedItem.ToString();

            // Allows for requery of "search" if true
            //do search if true
            if (Searched && !rbtnInCC.Checked)
            {
                chkRF.Visible = false;

                distanceIntensity.Clear();
                distanceColorC.Clear();

                displayResults();
                //displayToGUI(rBtnIn.Checked, sortedIntensity, sortedColorC);
            }
            else if (Searched && rbtnInCC.Checked)
            {
                distanceRF.Clear();

                chkRF.Visible = true;

                displayResults2();
                //displayToGUI_RF(chkRF.Checked, sortedRF);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // displays image path (for debugging)
            if (lstView.SelectedItems.Count > 0)
            {
                MessageBox.Show(Path.GetFullPath(lstView.SelectedItem.ToString()));
            }
            else
            {
                MessageBox.Show("Please select an image."); // Message box exception
            }
        }

        private void calculateAllPictures()
        {
            for (int i = 0; i < lstView.Items.Count; i++)
            {
                // Imported from SkiaMap nuget package
                SKBitmap myImg = SKBitmap.Decode(lstView.Items[i].ToString());
                List<int[]> Image_Pixels = new List<int[]>();
                int Pixel_Count = 0;

                // Loop through each pixel in the image. Source: ChatGPT, with some minor tweaks
                for (int x = 0; x < myImg.Width; x++)
                {
                    for (int y = 0; y < myImg.Height; y++)
                    {
                        Pixel_Count++;

                        var pixel = myImg.GetPixel(x, y);
                        // Store RGB values as an array of 3 integers [R, G, B]
                        int[] rgb = new int[3] { pixel.Red, pixel.Green, pixel.Blue };

                        //Add to ArrayList containing the pixels
                        Image_Pixels.Add(rgb);
                    }
                }


                pixels.Add(Pixel_Count); //obtains pizel count

                int[] CcBins = new int[64]; // Initializes an array of size 64 with all values set to 0
                int[] InBins = new int[25];

                features.ColorCodeMethod(Image_Pixels, CcBins); // Runs Methods
                features.IntensityMethod(Image_Pixels, InBins);

                listIntensity.Add(InBins); // Stores bins as list and this can be reused throughout the process of the form being opened
                listColorC.Add(CcBins);
            }
        }


        private void rBtn_CheckedChanged(object sender, EventArgs e)
        {
            //do search if true
            if (Searched && !rbtnInCC.Checked)
            {
                chkRF.Visible = false;
                displayResults();
            }
            else if (Searched && rbtnInCC.Checked)
            {
                chkRF.Visible = true;
                displayResults2();
            }
            return;
        }

        // initialized bool so that it can determine to run while it shows "search" controls
        private bool Searched = false;

        // Initialized to store sorted distances for display
        List<(double distance, int index)> sortedIntensity;
        List<(double distance, int index)> sortedColorC;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an image to compare with the selected methods."); // Ensures image is selected before running
                return;
            }

            if (btnSearch.Text == "Show Search w/ Method")
            {
                Searched = true;
                gboSearchTools.Visible = true;
                btnSearch.Text = "Hide Search w/ Method";

                if (rbtnInCC.Checked) // runs intensity and color code method
                {
                    chkRF.Visible = true;
                    distanceRF.Clear();

                    displayResults2();
                }
                else
                {
                    chkRF.Visible = false;
                    // Clears distance lists so that it there isnt a conflict with appending new data
                    distanceColorC.Clear();
                    distanceIntensity.Clear();

                    displayResults(); // Re-runs function
                }

                if (rBtnPanel.Checked)
                {
                    dataGridView1.Visible = false;
                    tableLayoutPanel1.Visible = true;
                }
                else
                {
                    dataGridView1.Visible = true;
                    tableLayoutPanel1.Visible = false;
                }
            }
            else
            {
                lblStatus.Text = "Show Method Status: ";
                Searched = false;
                tableLayoutPanel1.Visible = false;
                gboSearchTools.Visible = false;
                btnSearch.Text = "Show Search w/ Method";

                dataGridView1.Visible = false;
                tableLayoutPanel1.Visible = false;
            }
        }

        private void displayResults()
        {
            // Update statuses
            lblStatus.Text = "Show Method Status: Loading...";

            // Calculates manhattan distance with stored lists (obtained from the form load)
            features.manhattanDistance(listIntensity, listColorC, distanceIntensity, distanceColorC, pixels, lstView);

            //obtains the sorted list
            sortedIntensity = features.sortList(distanceIntensity);
            sortedColorC = features.sortList(distanceColorC);

            //output to GUI
            displayToGUI(rBtnIn.Checked, sortedIntensity, sortedColorC);

            lblStatus.Text = "Show Method Status: Done";
        }

        private void displayToGUI(bool intensityChecked, List<(double distance, int index)> Intensity, List<(double distance, int index)> ColorC)
        {
            /* 
             * For DGV GUI: Better for reporting
             */

            report.createDGV(intensityChecked, Intensity, ColorC, dataGridView1, lstView);
            report.createTablePanel(intensityChecked, Intensity, ColorC, tableLayoutPanel1, lstView);
        }

        /*
         * Resizes image to the specific width and height inputted so that it does not cut out a portion of an image
         * 
         * Utilized ChatGPT to obtain this function
         * Citation: OpenAI, LLC. (n.d.). "How can I fully resize an image given the width and height" ChatGPT. https://chat.openai.com
         */
        private Bitmap ResizeImage(Bitmap img, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(img, 0, 0, width, height);
            }
            return resizedImage;
        }

        private void btnToTxt_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count == 0) // Ensures users select an image from file
            {
                MessageBox.Show("Please select an image to output results to text file.");
                return;
            }
            else
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter("temp.txt", false)) // 'false' to overwrite file
                    {
                        if (checkAllFiles.Checked) // Overwrites text file and writes all of the image features onto the file if boc is checked
                        {
                            for (int i = 0; i < lstView.Items.Count; i++)
                            {
                                if (rbtnInCC.Checked)
                                {
                                    writer.WriteLine("(" + lstView.Items[i].ToString() + ")" + " Results\n\nNormalized Features:\n"
                                        + string.Join(",", normalizedFts[i].normFts) + "\n");
                                }
                                else
                                {
                                    writer.WriteLine("(" + lstView.Items[i].ToString() + ")" + " Results\n\nIntensity Method: " + string.Join(",", listIntensity[i])
                                    + "\n\nColor-Code Method: " + string.Join(",", listColorC[i]) + "\n");
                                }
                            }
                        }
                        else  // Overwrites text file and writes image features of query image onto the file if box is not checked
                        {
                            if (rbtnInCC.Checked)
                            {
                                writer.WriteLine("Normalized Features:\n"
                                  + string.Join(",", normalizedFts[lstView.SelectedIndex].normFts));
                            }
                            else
                            {
                                writer.WriteLine("Intensity Method: " + string.Join(",", listIntensity[lstView.SelectedIndex])
                             + "\n\nColor-Code Method: " + string.Join(",", listColorC[lstView.SelectedIndex]));
                            }
                        }
                    }

                    // open notepad to see results from the current image
                    System.Diagnostics.Process.Start("notepad.exe", "temp.txt");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message); // Throw exception when error foung
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete("temp.txt"); // Deletes temporary file
        }

        private void Form1_SizeChanged(object sender, EventArgs e) // Resizes table panel control as it does not grow and shrink alongside form size
        {
            // original size: 1245, 649
            if (this.Size.Width > 1245 && this.Size.Height > 649)
            {
                tableLayoutPanel1.Height = 189 + this.Height - 680;
            }
        }

        // For "search type" radio buttons
        private void rBtn_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!rBtnPanel.Checked)
            {
                dataGridView1.Visible = true;
                tableLayoutPanel1.Visible = false;
            }
            else
            {
                dataGridView1.Visible = false;
                tableLayoutPanel1.Visible = true;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
