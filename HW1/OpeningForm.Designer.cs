namespace HW2
{
    partial class OpeningForm
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
            lblText = new Label();
            btnVid = new Button();
            btnImage = new Button();
            SuspendLayout();
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText.Location = new Point(149, 83);
            lblText.Name = "lblText";
            lblText.Size = new Size(641, 22);
            lblText.TabIndex = 0;
            lblText.Text = "Welcome to Sith's Palace. Please select one of the following buttons to procede.";
            // 
            // btnVid
            // 
            btnVid.Location = new Point(173, 197);
            btnVid.Margin = new Padding(3, 4, 3, 4);
            btnVid.Name = "btnVid";
            btnVid.Size = new Size(184, 121);
            btnVid.TabIndex = 1;
            btnVid.Text = "Video GUI";
            btnVid.UseVisualStyleBackColor = true;
            btnVid.Click += btnVid_Click;
            // 
            // btnImage
            // 
            btnImage.Location = new Point(550, 197);
            btnImage.Margin = new Padding(3, 4, 3, 4);
            btnImage.Name = "btnImage";
            btnImage.Size = new Size(184, 121);
            btnImage.TabIndex = 2;
            btnImage.Text = "Image GUI";
            btnImage.UseVisualStyleBackColor = true;
            btnImage.Click += button2_Click;
            // 
            // OpeningForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnImage);
            Controls.Add(btnVid);
            Controls.Add(lblText);
            Margin = new Padding(3, 4, 3, 4);
            Name = "OpeningForm";
            Text = "Welcome Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblText;
        private Button btnVid;
        private Button btnImage;
    }
}