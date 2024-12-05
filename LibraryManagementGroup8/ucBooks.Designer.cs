namespace LibraryManagementGroup8
{
    partial class ucBooks
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBooks));
            this.PanelUcProducts = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lblBId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.PanelUcProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelUcProducts
            // 
            this.PanelUcProducts.BackColor = System.Drawing.Color.Transparent;
            this.PanelUcProducts.Controls.Add(this.lblName);
            this.PanelUcProducts.Controls.Add(this.lblBId);
            this.PanelUcProducts.Controls.Add(this.lblStatus);
            this.PanelUcProducts.Controls.Add(this.lblQty);
            this.PanelUcProducts.Controls.Add(this.lblGenre);
            this.PanelUcProducts.Controls.Add(this.lblId);
            this.PanelUcProducts.Controls.Add(this.lblAuthor);
            this.PanelUcProducts.Controls.Add(this.pbImage);
            this.PanelUcProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelUcProducts.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.PanelUcProducts.Location = new System.Drawing.Point(0, 0);
            this.PanelUcProducts.Name = "PanelUcProducts";
            this.PanelUcProducts.ShadowColor = System.Drawing.Color.Black;
            this.PanelUcProducts.Size = new System.Drawing.Size(145, 207);
            this.PanelUcProducts.TabIndex = 0;
            this.PanelUcProducts.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2ShadowPanel1_Paint);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblStatus.Location = new System.Drawing.Point(8, 81);
            this.lblStatus.MaximumSize = new System.Drawing.Size(135, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 71;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblQty.Location = new System.Drawing.Point(37, 79);
            this.lblQty.MaximumSize = new System.Drawing.Size(135, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(0, 15);
            this.lblQty.TabIndex = 70;
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenre.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGenre.Location = new System.Drawing.Point(69, 94);
            this.lblGenre.MaximumSize = new System.Drawing.Size(135, 0);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(0, 15);
            this.lblGenre.TabIndex = 69;
            this.lblGenre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblId.Location = new System.Drawing.Point(125, 79);
            this.lblId.MaximumSize = new System.Drawing.Size(135, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 15);
            this.lblId.TabIndex = 68;
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAuthor.Location = new System.Drawing.Point(10, 79);
            this.lblAuthor.MaximumSize = new System.Drawing.Size(135, 0);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(0, 15);
            this.lblAuthor.TabIndex = 67;
            this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Black;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Image = ((System.Drawing.Image)(resources.GetObject("pbImage.Image")));
            this.pbImage.Location = new System.Drawing.Point(20, 14);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(103, 130);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            this.pbImage.Click += new System.EventHandler(this.UcProducts_Click);
            // 
            // lblBId
            // 
            this.lblBId.AutoSize = true;
            this.lblBId.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBId.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblBId.Location = new System.Drawing.Point(8, 81);
            this.lblBId.MaximumSize = new System.Drawing.Size(135, 0);
            this.lblBId.Name = "lblBId";
            this.lblBId.Size = new System.Drawing.Size(0, 15);
            this.lblBId.TabIndex = 72;
            this.lblBId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBId.Visible = false;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblName.Location = new System.Drawing.Point(7, 152);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(131, 48);
            this.lblName.TabIndex = 122;
            this.lblName.Text = "Nhập môn công nghệ phần mềm Nhập môn công nghệ phần mềm\r\n";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ucBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.PanelUcProducts);
            this.Name = "ucBooks";
            this.Size = new System.Drawing.Size(145, 207);
            this.PanelUcProducts.ResumeLayout(false);
            this.PanelUcProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblStatus;
        public Guna.UI2.WinForms.Guna2ShadowPanel PanelUcProducts;
        public System.Windows.Forms.Label lblBId;
        public System.Windows.Forms.Label lblName;
    }
}
