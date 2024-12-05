namespace LibraryManagementGroup8
{
    partial class ucLoanBooks
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
            this.components = new System.ComponentModel.Container();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.lblPayBack = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLoanStatus = new System.Windows.Forms.Label();
            this.lblLoanId = new System.Windows.Forms.Label();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblBForfeit = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLoanDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 8;
            this.bunifuElipse2.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.lblReturnDate);
            this.panel1.Controls.Add(this.lblPayBack);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblLoanStatus);
            this.panel1.Controls.Add(this.lblLoanId);
            this.panel1.Controls.Add(this.pictureBox15);
            this.panel1.Controls.Add(this.lblDueDate);
            this.panel1.Controls.Add(this.lblBForfeit);
            this.panel1.Controls.Add(this.lblUserId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblLoanDate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 177);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnDate.ForeColor = System.Drawing.Color.White;
            this.lblReturnDate.Location = new System.Drawing.Point(187, 148);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(39, 16);
            this.lblReturnDate.TabIndex = 132;
            this.lblReturnDate.Text = "Ngày";
            this.lblReturnDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPayBack
            // 
            this.lblPayBack.AutoSize = true;
            this.lblPayBack.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayBack.ForeColor = System.Drawing.Color.White;
            this.lblPayBack.Location = new System.Drawing.Point(96, 148);
            this.lblPayBack.Name = "lblPayBack";
            this.lblPayBack.Size = new System.Drawing.Size(64, 16);
            this.lblPayBack.TabIndex = 131;
            this.lblPayBack.Text = "Ngày trả:";
            this.lblPayBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 80);
            this.label6.MaximumSize = new System.Drawing.Size(135, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 38);
            this.label6.TabIndex = 130;
            this.label6.Text = "#";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoanStatus
            // 
            this.lblLoanStatus.AutoSize = true;
            this.lblLoanStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoanStatus.ForeColor = System.Drawing.Color.White;
            this.lblLoanStatus.Location = new System.Drawing.Point(249, 7);
            this.lblLoanStatus.Name = "lblLoanStatus";
            this.lblLoanStatus.Size = new System.Drawing.Size(43, 16);
            this.lblLoanStatus.TabIndex = 129;
            this.lblLoanStatus.Text = "status";
            this.lblLoanStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoanId
            // 
            this.lblLoanId.AutoSize = true;
            this.lblLoanId.Font = new System.Drawing.Font("Arial", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoanId.ForeColor = System.Drawing.Color.White;
            this.lblLoanId.Location = new System.Drawing.Point(29, 80);
            this.lblLoanId.MaximumSize = new System.Drawing.Size(135, 0);
            this.lblLoanId.Name = "lblLoanId";
            this.lblLoanId.Size = new System.Drawing.Size(35, 38);
            this.lblLoanId.TabIndex = 128;
            this.lblLoanId.Text = "1";
            this.lblLoanId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.White;
            this.pictureBox15.Location = new System.Drawing.Point(-1, 31);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(318, 3);
            this.pictureBox15.TabIndex = 121;
            this.pictureBox15.TabStop = false;
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.ForeColor = System.Drawing.Color.White;
            this.lblDueDate.Location = new System.Drawing.Point(187, 114);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(39, 16);
            this.lblDueDate.TabIndex = 119;
            this.lblDueDate.Text = "Ngày";
            this.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBForfeit
            // 
            this.lblBForfeit.AutoSize = true;
            this.lblBForfeit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBForfeit.ForeColor = System.Drawing.Color.White;
            this.lblBForfeit.Location = new System.Drawing.Point(166, 148);
            this.lblBForfeit.Name = "lblBForfeit";
            this.lblBForfeit.Size = new System.Drawing.Size(35, 16);
            this.lblBForfeit.TabIndex = 118;
            this.lblBForfeit.Text = "Loại";
            this.lblBForfeit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.ForeColor = System.Drawing.Color.White;
            this.lblUserId.Location = new System.Drawing.Point(156, 46);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(27, 16);
            this.lblUserId.TabIndex = 117;
            this.lblUserId.Text = "mã";
            this.lblUserId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(96, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 127;
            this.label1.Text = "Hạn trả:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(96, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 126;
            this.label2.Text = "Ngày mượn:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(96, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 125;
            this.label3.Text = "Phí phạt:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(96, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 124;
            this.label4.Text = "Mã thẻ:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoanDate
            // 
            this.lblLoanDate.AutoSize = true;
            this.lblLoanDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoanDate.ForeColor = System.Drawing.Color.White;
            this.lblLoanDate.Location = new System.Drawing.Point(187, 80);
            this.lblLoanDate.Name = "lblLoanDate";
            this.lblLoanDate.Size = new System.Drawing.Size(39, 16);
            this.lblLoanDate.TabIndex = 123;
            this.lblLoanDate.Text = "Ngày";
            this.lblLoanDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(69, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 18);
            this.label5.TabIndex = 122;
            this.label5.Text = "PHIẾU MƯỢN SÁCH";
            // 
            // ucLoanBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucLoanBooks";
            this.Size = new System.Drawing.Size(312, 177);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.Label lblLoanId;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLoanDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLoanStatus;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblPayBack;
        public System.Windows.Forms.Label lblReturnDate;
        public System.Windows.Forms.Label lblBForfeit;
        public System.Windows.Forms.Label label3;
    }
}
