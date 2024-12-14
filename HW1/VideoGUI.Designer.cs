namespace HW2
{
    partial class VideoGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoGUI));
            lblStatus = new Label();
            gboBtns = new GroupBox();
            checkAllFiles = new CheckBox();
            btnSearch = new Button();
            btnToTxt = new Button();
            gboImgSel = new GroupBox();
            lstView = new ListBox();
            gboImgRet = new GroupBox();
            button1 = new Button();
            lblPicFile = new Label();
            queryPicture = new PictureBox();
            gboMethods = new GroupBox();
            chkRF = new CheckBox();
            rbtnInCC = new RadioButton();
            rBtnCC = new RadioButton();
            rBtnIn = new RadioButton();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            gboVidOps = new GroupBox();
            rBtnPlayVid = new RadioButton();
            radioButton1 = new RadioButton();
            MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            gboBtns.SuspendLayout();
            gboImgSel.SuspendLayout();
            gboImgRet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)queryPicture).BeginInit();
            gboMethods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            gboVidOps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MediaPlayer).BeginInit();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = SystemColors.ActiveBorder;
            lblStatus.Location = new Point(941, 86);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(152, 20);
            lblStatus.TabIndex = 24;
            lblStatus.Text = "Show Method Status: ";
            // 
            // gboBtns
            // 
            gboBtns.Controls.Add(checkAllFiles);
            gboBtns.Controls.Add(btnSearch);
            gboBtns.Controls.Add(btnToTxt);
            gboBtns.Location = new Point(1199, 263);
            gboBtns.Margin = new Padding(3, 4, 3, 4);
            gboBtns.Name = "gboBtns";
            gboBtns.Padding = new Padding(3, 4, 3, 4);
            gboBtns.Size = new Size(235, 255);
            gboBtns.TabIndex = 23;
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
            // btnSearch
            // 
            btnSearch.Location = new Point(40, 28);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(153, 67);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Show Search w/ Method";
            btnSearch.UseVisualStyleBackColor = true;
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
            // 
            // gboImgSel
            // 
            gboImgSel.Controls.Add(lstView);
            gboImgSel.Location = new Point(941, 263);
            gboImgSel.Margin = new Padding(3, 4, 3, 4);
            gboImgSel.Name = "gboImgSel";
            gboImgSel.Padding = new Padding(3, 4, 3, 4);
            gboImgSel.Size = new Size(229, 255);
            gboImgSel.TabIndex = 22;
            gboImgSel.TabStop = false;
            gboImgSel.Text = "Video Selector";
            // 
            // lstView
            // 
            lstView.FormattingEnabled = true;
            lstView.Location = new Point(42, 39);
            lstView.Margin = new Padding(3, 4, 3, 4);
            lstView.Name = "lstView";
            lstView.Size = new Size(147, 204);
            lstView.TabIndex = 0;
            // 
            // gboImgRet
            // 
            gboImgRet.Controls.Add(button1);
            gboImgRet.Controls.Add(lblPicFile);
            gboImgRet.Location = new Point(941, 128);
            gboImgRet.Margin = new Padding(3, 4, 3, 4);
            gboImgRet.Name = "gboImgRet";
            gboImgRet.Padding = new Padding(3, 4, 3, 4);
            gboImgRet.Size = new Size(229, 120);
            gboImgRet.TabIndex = 21;
            gboImgRet.TabStop = false;
            gboImgRet.Text = "Video Retrieval Info";
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
            // 
            // lblPicFile
            // 
            lblPicFile.AutoSize = true;
            lblPicFile.Location = new Point(7, 84);
            lblPicFile.Name = "lblPicFile";
            lblPicFile.Size = new Size(126, 20);
            lblPicFile.TabIndex = 4;
            lblPicFile.Text = "Video File Name: ";
            // 
            // queryPicture
            // 
            queryPicture.Location = new Point(41, 83);
            queryPicture.Margin = new Padding(3, 4, 3, 4);
            queryPicture.Name = "queryPicture";
            queryPicture.Size = new Size(591, 432);
            queryPicture.TabIndex = 20;
            queryPicture.TabStop = false;
            // 
            // gboMethods
            // 
            gboMethods.Controls.Add(chkRF);
            gboMethods.Controls.Add(rbtnInCC);
            gboMethods.Controls.Add(rBtnCC);
            gboMethods.Controls.Add(rBtnIn);
            gboMethods.Location = new Point(1199, 86);
            gboMethods.Margin = new Padding(3, 4, 3, 4);
            gboMethods.Name = "gboMethods";
            gboMethods.Padding = new Padding(3, 4, 3, 4);
            gboMethods.Size = new Size(267, 169);
            gboMethods.TabIndex = 19;
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
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(664, 423);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(664, 384);
            label1.Name = "label1";
            label1.Size = new Size(142, 20);
            label1.TabIndex = 26;
            label1.Text = "Frame Rate Number";
            // 
            // gboVidOps
            // 
            gboVidOps.Controls.Add(rBtnPlayVid);
            gboVidOps.Controls.Add(radioButton1);
            gboVidOps.Location = new Point(664, 171);
            gboVidOps.Name = "gboVidOps";
            gboVidOps.Size = new Size(245, 187);
            gboVidOps.TabIndex = 27;
            gboVidOps.TabStop = false;
            gboVidOps.Text = "Video Options";
            // 
            // rBtnPlayVid
            // 
            rBtnPlayVid.AutoSize = true;
            rBtnPlayVid.Location = new Point(46, 60);
            rBtnPlayVid.Name = "rBtnPlayVid";
            rBtnPlayVid.Size = new Size(100, 24);
            rBtnPlayVid.TabIndex = 2;
            rBtnPlayVid.TabStop = true;
            rBtnPlayVid.Text = "Play Video";
            rBtnPlayVid.UseVisualStyleBackColor = true;
            rBtnPlayVid.CheckedChanged += rBtnVideo_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(45, 112);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(149, 24);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "Frame Breakdown";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += rBtnVideo_CheckedChanged;
            // 
            // MediaPlayer
            // 
            MediaPlayer.Enabled = true;
            MediaPlayer.Location = new Point(41, 83);
            MediaPlayer.Name = "MediaPlayer";
            MediaPlayer.OcxState = (AxHost.State)resources.GetObject("MediaPlayer.OcxState");
            MediaPlayer.Size = new Size(591, 432);
            MediaPlayer.TabIndex = 28;
            // 
            // VideoGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 599);
            Controls.Add(MediaPlayer);
            Controls.Add(gboVidOps);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(lblStatus);
            Controls.Add(gboBtns);
            Controls.Add(gboImgSel);
            Controls.Add(gboImgRet);
            Controls.Add(queryPicture);
            Controls.Add(gboMethods);
            Margin = new Padding(3, 4, 3, 4);
            Name = "VideoGUI";
            Text = "Video Shot Boundary Detection System";
            Load += VideoGUI_Load;
            gboBtns.ResumeLayout(false);
            gboBtns.PerformLayout();
            gboImgSel.ResumeLayout(false);
            gboImgRet.ResumeLayout(false);
            gboImgRet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)queryPicture).EndInit();
            gboMethods.ResumeLayout(false);
            gboMethods.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            gboVidOps.ResumeLayout(false);
            gboVidOps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MediaPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblStatus;
        private GroupBox gboBtns;
        private CheckBox checkAllFiles;
        private Button btnSearch;
        private Button btnToTxt;
        private GroupBox gboImgSel;
        private ListBox lstView;
        private GroupBox gboImgRet;
        private Button button1;
        private Label lblPicFile;
        private PictureBox queryPicture;
        private GroupBox gboMethods;
        private CheckBox chkRF;
        private RadioButton rbtnInCC;
        private RadioButton rBtnCC;
        private RadioButton rBtnIn;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private GroupBox gboVidOps;
        private RadioButton rBtnPlayVid;
        private RadioButton radioButton1;
        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
    }
}