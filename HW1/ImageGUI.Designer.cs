namespace HW2
{
    partial class ImageGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstView = new ListBox();
            gboMethods = new GroupBox();
            chkRF = new CheckBox();
            rbtnInCC = new RadioButton();
            rBtnCC = new RadioButton();
            rBtnIn = new RadioButton();
            queryPicture = new PictureBox();
            lblPicFile = new Label();
            button1 = new Button();
            gboImgRet = new GroupBox();
            gboImgSel = new GroupBox();
            btnSearch = new Button();
            btnToTxt = new Button();
            gboBtns = new GroupBox();
            checkAllFiles = new CheckBox();
            btnQueryRF = new Button();
            lblStatus = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            gboSearchTools = new GroupBox();
            rBtnPanel = new RadioButton();
            rBtnDGV = new RadioButton();
            dataGridView1 = new DataGridView();
            colDistID = new DataGridViewTextBoxColumn();
            colImage = new DataGridViewImageColumn();
            colFileName = new DataGridViewTextBoxColumn();
            colDistance = new DataGridViewTextBoxColumn();
            gboMethods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)queryPicture).BeginInit();
            gboImgRet.SuspendLayout();
            gboImgSel.SuspendLayout();
            gboBtns.SuspendLayout();
            gboSearchTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lstView
            // 
            lstView.FormattingEnabled = true;
            lstView.Location = new Point(42, 39);
            lstView.Margin = new Padding(3, 4, 3, 4);
            lstView.Name = "lstView";
            lstView.Size = new Size(147, 204);
            lstView.TabIndex = 0;
            lstView.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // gboMethods
            // 
            gboMethods.Controls.Add(chkRF);
            gboMethods.Controls.Add(rbtnInCC);
            gboMethods.Controls.Add(rBtnCC);
            gboMethods.Controls.Add(rBtnIn);
            gboMethods.Location = new Point(403, 48);
            gboMethods.Margin = new Padding(3, 4, 3, 4);
            gboMethods.Name = "gboMethods";
            gboMethods.Padding = new Padding(3, 4, 3, 4);
            gboMethods.Size = new Size(267, 169);
            gboMethods.TabIndex = 1;
            gboMethods.TabStop = false;
            gboMethods.Text = "Method Selectors";
            // 
            // chkRF
            // 
            chkRF.AutoSize = true;
            chkRF.BackColor = SystemColors.ActiveCaption;
            chkRF.Location = new Point(51, 127);
            chkRF.Name = "chkRF";
            chkRF.Size = new Size(165, 24);
            chkRF.TabIndex = 3;
            chkRF.Text = "Relevance Feedback";
            chkRF.UseVisualStyleBackColor = false;
            chkRF.Visible = false;
            chkRF.CheckedChanged += chkRF_CheckedChanged;
            // 
            // rbtnInCC
            // 
            rbtnInCC.AutoSize = true;
            rbtnInCC.Location = new Point(19, 96);
            rbtnInCC.Margin = new Padding(3, 4, 3, 4);
            rbtnInCC.Name = "rbtnInCC";
            rbtnInCC.Size = new Size(234, 24);
            rbtnInCC.TabIndex = 2;
            rbtnInCC.TabStop = true;
            rbtnInCC.Text = "Color Code + Intensity Method";
            rbtnInCC.UseVisualStyleBackColor = true;
            rbtnInCC.CheckedChanged += rBtn_CheckedChanged;
            // 
            // rBtnCC
            // 
            rBtnCC.AutoSize = true;
            rBtnCC.Location = new Point(19, 63);
            rBtnCC.Margin = new Padding(3, 4, 3, 4);
            rBtnCC.Name = "rBtnCC";
            rBtnCC.Size = new Size(163, 24);
            rBtnCC.TabIndex = 1;
            rBtnCC.Text = "Color-Code Method";
            rBtnCC.UseVisualStyleBackColor = true;
            rBtnCC.CheckedChanged += rBtn_CheckedChanged;
            // 
            // rBtnIn
            // 
            rBtnIn.AutoSize = true;
            rBtnIn.Checked = true;
            rBtnIn.Location = new Point(19, 29);
            rBtnIn.Margin = new Padding(3, 4, 3, 4);
            rBtnIn.Name = "rBtnIn";
            rBtnIn.Size = new Size(141, 24);
            rBtnIn.TabIndex = 0;
            rBtnIn.TabStop = true;
            rBtnIn.Text = "Intensity Method";
            rBtnIn.UseVisualStyleBackColor = true;
            rBtnIn.CheckedChanged += rBtn_CheckedChanged;
            // 
            // queryPicture
            // 
            queryPicture.Location = new Point(70, 48);
            queryPicture.Margin = new Padding(3, 4, 3, 4);
            queryPicture.Name = "queryPicture";
            queryPicture.Size = new Size(289, 289);
            queryPicture.TabIndex = 3;
            queryPicture.TabStop = false;
            // 
            // lblPicFile
            // 
            lblPicFile.AutoSize = true;
            lblPicFile.Location = new Point(7, 84);
            lblPicFile.Name = "lblPicFile";
            lblPicFile.Size = new Size(129, 20);
            lblPicFile.TabIndex = 4;
            lblPicFile.Text = "Image File Name: ";
            // 
            // button1
            // 
            button1.Location = new Point(40, 43);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(153, 31);
            button1.TabIndex = 5;
            button1.Text = "Show File Path";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // gboImgRet
            // 
            gboImgRet.Controls.Add(button1);
            gboImgRet.Controls.Add(lblPicFile);
            gboImgRet.Location = new Point(714, 91);
            gboImgRet.Margin = new Padding(3, 4, 3, 4);
            gboImgRet.Name = "gboImgRet";
            gboImgRet.Padding = new Padding(3, 4, 3, 4);
            gboImgRet.Size = new Size(229, 120);
            gboImgRet.TabIndex = 6;
            gboImgRet.TabStop = false;
            gboImgRet.Text = "Image Retrieval Info";
            // 
            // gboImgSel
            // 
            gboImgSel.Controls.Add(lstView);
            gboImgSel.Location = new Point(714, 225);
            gboImgSel.Margin = new Padding(3, 4, 3, 4);
            gboImgSel.Name = "gboImgSel";
            gboImgSel.Padding = new Padding(3, 4, 3, 4);
            gboImgSel.Size = new Size(229, 255);
            gboImgSel.TabIndex = 7;
            gboImgSel.TabStop = false;
            gboImgSel.Text = "Image Selector";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(40, 28);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(153, 67);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Show Search w/ Method";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnToTxt
            // 
            btnToTxt.Location = new Point(40, 119);
            btnToTxt.Margin = new Padding(3, 4, 3, 4);
            btnToTxt.Name = "btnToTxt";
            btnToTxt.Size = new Size(153, 71);
            btnToTxt.TabIndex = 13;
            btnToTxt.Text = "Show Image Features (Text File)";
            btnToTxt.UseVisualStyleBackColor = true;
            btnToTxt.Click += btnToTxt_Click;
            // 
            // gboBtns
            // 
            gboBtns.Controls.Add(checkAllFiles);
            gboBtns.Controls.Add(btnSearch);
            gboBtns.Controls.Add(btnToTxt);
            gboBtns.Location = new Point(403, 225);
            gboBtns.Margin = new Padding(3, 4, 3, 4);
            gboBtns.Name = "gboBtns";
            gboBtns.Padding = new Padding(3, 4, 3, 4);
            gboBtns.Size = new Size(235, 255);
            gboBtns.TabIndex = 14;
            gboBtns.TabStop = false;
            gboBtns.Text = "Buttons";
            // 
            // checkAllFiles
            // 
            checkAllFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkAllFiles.AutoSize = true;
            checkAllFiles.Location = new Point(40, 208);
            checkAllFiles.Margin = new Padding(3, 4, 3, 4);
            checkAllFiles.Name = "checkAllFiles";
            checkAllFiles.Size = new Size(154, 24);
            checkAllFiles.TabIndex = 14;
            checkAllFiles.Text = "All Image Features";
            checkAllFiles.UseVisualStyleBackColor = true;
            // 
            // btnQueryRF
            // 
            btnQueryRF.Location = new Point(82, 147);
            btnQueryRF.Margin = new Padding(3, 4, 3, 4);
            btnQueryRF.Name = "btnQueryRF";
            btnQueryRF.Size = new Size(105, 79);
            btnQueryRF.TabIndex = 15;
            btnQueryRF.Text = "Update Relevance Feedback";
            btnQueryRF.UseVisualStyleBackColor = true;
            btnQueryRF.Visible = false;
            btnQueryRF.Click += btnQueryRF_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = SystemColors.ActiveBorder;
            lblStatus.Location = new Point(714, 48);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(152, 20);
            lblStatus.TabIndex = 15;
            lblStatus.Text = "Show Method Status: ";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.BackColor = SystemColors.ButtonShadow;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Location = new Point(31, 540);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(1342, 252);
            tableLayoutPanel1.TabIndex = 17;
            tableLayoutPanel1.Visible = false;
            // 
            // gboSearchTools
            // 
            gboSearchTools.Controls.Add(btnQueryRF);
            gboSearchTools.Controls.Add(rBtnPanel);
            gboSearchTools.Controls.Add(rBtnDGV);
            gboSearchTools.Location = new Point(965, 48);
            gboSearchTools.Margin = new Padding(3, 4, 3, 4);
            gboSearchTools.Name = "gboSearchTools";
            gboSearchTools.Padding = new Padding(3, 4, 3, 4);
            gboSearchTools.Size = new Size(274, 147);
            gboSearchTools.TabIndex = 18;
            gboSearchTools.TabStop = false;
            gboSearchTools.Text = "Search Query Tools";
            gboSearchTools.Visible = false;
            // 
            // rBtnPanel
            // 
            rBtnPanel.AutoSize = true;
            rBtnPanel.Checked = true;
            rBtnPanel.Location = new Point(43, 43);
            rBtnPanel.Margin = new Padding(3, 4, 3, 4);
            rBtnPanel.Name = "rBtnPanel";
            rBtnPanel.Size = new Size(105, 24);
            rBtnPanel.TabIndex = 1;
            rBtnPanel.TabStop = true;
            rBtnPanel.Text = "Show Panel";
            rBtnPanel.UseVisualStyleBackColor = true;
            rBtnPanel.CheckedChanged += rBtn_CheckedChanged_1;
            // 
            // rBtnDGV
            // 
            rBtnDGV.AutoSize = true;
            rBtnDGV.Location = new Point(43, 72);
            rBtnDGV.Margin = new Padding(3, 4, 3, 4);
            rBtnDGV.Name = "rBtnDGV";
            rBtnDGV.Size = new Size(219, 24);
            rBtnDGV.TabIndex = 0;
            rBtnDGV.Text = "Show Data Grid View Report";
            rBtnDGV.UseVisualStyleBackColor = true;
            rBtnDGV.CheckedChanged += rBtn_CheckedChanged_1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colDistID, colImage, colFileName, colDistance });
            dataGridView1.Location = new Point(31, 540);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1070, 257);
            dataGridView1.TabIndex = 19;
            dataGridView1.Visible = false;
            dataGridView1.DataError += dataGridView1_DataError;
            // 
            // colDistID
            // 
            colDistID.HeaderText = "Distance ID";
            colDistID.MinimumWidth = 6;
            colDistID.Name = "colDistID";
            colDistID.Width = 125;
            // 
            // colImage
            // 
            colImage.HeaderText = "Image Display";
            colImage.MinimumWidth = 6;
            colImage.Name = "colImage";
            colImage.Width = 125;
            // 
            // colFileName
            // 
            colFileName.HeaderText = "File Name";
            colFileName.MinimumWidth = 6;
            colFileName.Name = "colFileName";
            colFileName.Width = 125;
            // 
            // colDistance
            // 
            colDistance.HeaderText = "Distance from Query Image";
            colDistance.MinimumWidth = 6;
            colDistance.Name = "colDistance";
            colDistance.Width = 125;
            // 
            // ImageGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1405, 813);
            Controls.Add(gboSearchTools);
            Controls.Add(lblStatus);
            Controls.Add(gboBtns);
            Controls.Add(gboImgSel);
            Controls.Add(gboImgRet);
            Controls.Add(queryPicture);
            Controls.Add(gboMethods);
            Controls.Add(dataGridView1);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ImageGUI";
            Text = "Simple CBIRS";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            SizeChanged += Form1_SizeChanged;
            gboMethods.ResumeLayout(false);
            gboMethods.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)queryPicture).EndInit();
            gboImgRet.ResumeLayout(false);
            gboImgRet.PerformLayout();
            gboImgSel.ResumeLayout(false);
            gboBtns.ResumeLayout(false);
            gboBtns.PerformLayout();
            gboSearchTools.ResumeLayout(false);
            gboSearchTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstView;
        private GroupBox gboMethods;
        private PictureBox queryPicture;
        private Label lblPicFile;
        private RadioButton rBtnCC;
        private RadioButton rBtnIn;
        private Button button1;
        private GroupBox gboImgRet;
        private GroupBox gboImgSel;
        private Button btnSearch;
        private Button btnToTxt;
        private GroupBox gboBtns;
        private Label lblStatus;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox gboSearchTools;
        private RadioButton rBtnPanel;
        private RadioButton rBtnDGV;
        private DataGridView dataGridView1;
        private CheckBox checkAllFiles;
        private RadioButton rbtnInCC;
        private CheckBox chkRF;
        private Button btnQueryRF;
        private DataGridViewTextBoxColumn colDistID;
        private DataGridViewImageColumn colImage;
        private DataGridViewTextBoxColumn colFileName;
        private DataGridViewTextBoxColumn colDistance;
    }
}
