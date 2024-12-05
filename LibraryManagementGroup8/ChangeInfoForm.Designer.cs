namespace LibraryManagementGroup8
{
    partial class ChangeInfoForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeInfoForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UserPfpPb = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ImageButton = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.UserEmailTb = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UserPhoneTb = new Guna.UI2.WinForms.Guna2TextBox();
            this.UserAddTb = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SaveButton = new Guna.UI2.WinForms.Guna2Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.NoteLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UserImagePb_ = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserPfpPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserImagePb_)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.UserPfpPb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 62);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(519, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 26);
            this.pictureBox1.TabIndex = 90;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // UserPfpPb
            // 
            this.UserPfpPb.Image = ((System.Drawing.Image)(resources.GetObject("UserPfpPb.Image")));
            this.UserPfpPb.Location = new System.Drawing.Point(12, 3);
            this.UserPfpPb.Name = "UserPfpPb";
            this.UserPfpPb.Size = new System.Drawing.Size(68, 56);
            this.UserPfpPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserPfpPb.TabIndex = 85;
            this.UserPfpPb.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(92, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "THÔNG TIN NGƯỜI DÙNG";
            // 
            // ImageButton
            // 
            this.ImageButton.BorderRadius = 5;
            this.ImageButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ImageButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ImageButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ImageButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ImageButton.FillColor = System.Drawing.Color.ForestGreen;
            this.ImageButton.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageButton.ForeColor = System.Drawing.Color.White;
            this.ImageButton.Location = new System.Drawing.Point(21, 214);
            this.ImageButton.Name = "ImageButton";
            this.ImageButton.Size = new System.Drawing.Size(109, 25);
            this.ImageButton.TabIndex = 90;
            this.ImageButton.Text = "Chọn ảnh";
            this.ImageButton.Click += new System.EventHandler(this.ImageButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(15)))));
            this.label3.Location = new System.Drawing.Point(153, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 97;
            this.label3.Text = "Email";
            // 
            // UserEmailTb
            // 
            this.UserEmailTb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(50)))));
            this.UserEmailTb.BorderRadius = 5;
            this.UserEmailTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UserEmailTb.DefaultText = "";
            this.UserEmailTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.UserEmailTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.UserEmailTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UserEmailTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UserEmailTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserEmailTb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UserEmailTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.UserEmailTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserEmailTb.IconLeftSize = new System.Drawing.Size(25, 25);
            this.UserEmailTb.Location = new System.Drawing.Point(315, 88);
            this.UserEmailTb.Name = "UserEmailTb";
            this.UserEmailTb.PasswordChar = '\0';
            this.UserEmailTb.PlaceholderText = "";
            this.UserEmailTb.SelectedText = "";
            this.UserEmailTb.Size = new System.Drawing.Size(212, 33);
            this.UserEmailTb.TabIndex = 96;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(15)))));
            this.label4.Location = new System.Drawing.Point(153, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 24);
            this.label4.TabIndex = 99;
            this.label4.Text = "Số điện thoại";
            // 
            // UserPhoneTb
            // 
            this.UserPhoneTb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(50)))));
            this.UserPhoneTb.BorderRadius = 5;
            this.UserPhoneTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UserPhoneTb.DefaultText = "";
            this.UserPhoneTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.UserPhoneTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.UserPhoneTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UserPhoneTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UserPhoneTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserPhoneTb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UserPhoneTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.UserPhoneTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserPhoneTb.IconLeftSize = new System.Drawing.Size(25, 25);
            this.UserPhoneTb.Location = new System.Drawing.Point(315, 138);
            this.UserPhoneTb.Name = "UserPhoneTb";
            this.UserPhoneTb.PasswordChar = '\0';
            this.UserPhoneTb.PlaceholderText = "";
            this.UserPhoneTb.SelectedText = "";
            this.UserPhoneTb.Size = new System.Drawing.Size(212, 33);
            this.UserPhoneTb.TabIndex = 98;
            // 
            // UserAddTb
            // 
            this.UserAddTb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(50)))));
            this.UserAddTb.BorderRadius = 5;
            this.UserAddTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UserAddTb.DefaultText = "";
            this.UserAddTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.UserAddTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.UserAddTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UserAddTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.UserAddTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserAddTb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UserAddTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.UserAddTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserAddTb.IconLeftSize = new System.Drawing.Size(25, 25);
            this.UserAddTb.Location = new System.Drawing.Point(315, 188);
            this.UserAddTb.Name = "UserAddTb";
            this.UserAddTb.PasswordChar = '\0';
            this.UserAddTb.PlaceholderText = "";
            this.UserAddTb.SelectedText = "";
            this.UserAddTb.Size = new System.Drawing.Size(212, 33);
            this.UserAddTb.TabIndex = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(20)))), ((int)(((byte)(15)))));
            this.label5.Location = new System.Drawing.Point(153, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 24);
            this.label5.TabIndex = 102;
            this.label5.Text = "Địa chỉ";
            // 
            // SaveButton
            // 
            this.SaveButton.BorderRadius = 5;
            this.SaveButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SaveButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SaveButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SaveButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SaveButton.FillColor = System.Drawing.Color.ForestGreen;
            this.SaveButton.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(157, 276);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(237, 35);
            this.SaveButton.TabIndex = 105;
            this.SaveButton.Text = "CẬP NHẬT THÔNG TIN";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // NoteLbl
            // 
            this.NoteLbl.AutoSize = true;
            this.NoteLbl.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteLbl.ForeColor = System.Drawing.Color.Crimson;
            this.NoteLbl.Location = new System.Drawing.Point(154, 247);
            this.NoteLbl.Name = "NoteLbl";
            this.NoteLbl.Size = new System.Drawing.Size(65, 15);
            this.NoteLbl.TabIndex = 106;
            this.NoteLbl.Text = "Thông báo";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 328);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 17);
            this.panel2.TabIndex = 107;
            // 
            // UserImagePb_
            // 
            this.UserImagePb_.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UserImagePb_.FillColor = System.Drawing.Color.Black;
            this.UserImagePb_.ImageRotate = 0F;
            this.UserImagePb_.Location = new System.Drawing.Point(21, 88);
            this.UserImagePb_.Name = "UserImagePb_";
            this.UserImagePb_.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.UserImagePb_.Size = new System.Drawing.Size(109, 109);
            this.UserImagePb_.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserImagePb_.TabIndex = 108;
            this.UserImagePb_.TabStop = false;
            // 
            // ChangeInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 345);
            this.Controls.Add(this.UserImagePb_);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.NoteLbl);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.UserAddTb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UserPhoneTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UserEmailTb);
            this.Controls.Add(this.ImageButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangeInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeInfoForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserPfpPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserImagePb_)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox UserPfpPb;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button ImageButton;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox UserEmailTb;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox UserPhoneTb;
        private Guna.UI2.WinForms.Guna2TextBox UserAddTb;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button SaveButton;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label NoteLbl;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2CirclePictureBox UserImagePb_;
    }
}