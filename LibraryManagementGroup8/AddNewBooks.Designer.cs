namespace LibraryManagementGroup8
{
    partial class AddNewBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewBooks));
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.UserImagePb = new System.Windows.Forms.PictureBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SaveButton = new Guna.UI2.WinForms.Guna2Button();
            this.BNameTb = new Guna.UI2.WinForms.Guna2TextBox();
            this.ImageButton = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UserPfpPb = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BAuthorTb = new Guna.UI2.WinForms.Guna2TextBox();
            this.BYPulishedTb = new Guna.UI2.WinForms.Guna2TextBox();
            this.BGenreTb = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BQtyNUD = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.BLinkTb = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BTypeCb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BLocationTb = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.UserImagePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserPfpPb)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BQtyNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 504);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(555, 17);
            this.panel2.TabIndex = 123;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 10;
            this.bunifuElipse2.TargetControl = this.UserImagePb;
            // 
            // UserImagePb
            // 
            this.UserImagePb.Image = ((System.Drawing.Image)(resources.GetObject("UserImagePb.Image")));
            this.UserImagePb.Location = new System.Drawing.Point(21, 88);
            this.UserImagePb.Name = "UserImagePb";
            this.UserImagePb.Size = new System.Drawing.Size(100, 130);
            this.UserImagePb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserImagePb.TabIndex = 109;
            this.UserImagePb.TabStop = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
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
            this.SaveButton.Location = new System.Drawing.Point(235, 450);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(95, 35);
            this.SaveButton.TabIndex = 121;
            this.SaveButton.Text = "THÊM";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BNameTb
            // 
            this.BNameTb.BorderRadius = 5;
            this.BNameTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BNameTb.DefaultText = "";
            this.BNameTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.BNameTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.BNameTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BNameTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BNameTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BNameTb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BNameTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.BNameTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BNameTb.IconLeftSize = new System.Drawing.Size(25, 25);
            this.BNameTb.Location = new System.Drawing.Point(310, 88);
            this.BNameTb.Name = "BNameTb";
            this.BNameTb.PasswordChar = '\0';
            this.BNameTb.PlaceholderText = "";
            this.BNameTb.SelectedText = "";
            this.BNameTb.Size = new System.Drawing.Size(228, 33);
            this.BNameTb.TabIndex = 111;
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
            this.ImageButton.Location = new System.Drawing.Point(21, 230);
            this.ImageButton.Name = "ImageButton";
            this.ImageButton.Size = new System.Drawing.Size(102, 25);
            this.ImageButton.TabIndex = 110;
            this.ImageButton.Text = "Chọn ảnh";
            this.ImageButton.Click += new System.EventHandler(this.ImageButton_Click);
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
            this.UserPfpPb.Location = new System.Drawing.Point(0, -11);
            this.UserPfpPb.Name = "UserPfpPb";
            this.UserPfpPb.Size = new System.Drawing.Size(83, 73);
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
            this.label1.Size = new System.Drawing.Size(154, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "THÊM SÁCH";
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
            this.panel1.Size = new System.Drawing.Size(555, 62);
            this.panel1.TabIndex = 108;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(159, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 24);
            this.label2.TabIndex = 125;
            this.label2.Text = "Tên sách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(159, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 24);
            this.label3.TabIndex = 126;
            this.label3.Text = "Tác giả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label4.Location = new System.Drawing.Point(159, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 24);
            this.label4.TabIndex = 127;
            this.label4.Text = "Năm xuất bản";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label5.Location = new System.Drawing.Point(159, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 24);
            this.label5.TabIndex = 128;
            this.label5.Text = "Thể loại";
            // 
            // BAuthorTb
            // 
            this.BAuthorTb.BorderRadius = 5;
            this.BAuthorTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BAuthorTb.DefaultText = "";
            this.BAuthorTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.BAuthorTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.BAuthorTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BAuthorTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BAuthorTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BAuthorTb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BAuthorTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.BAuthorTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BAuthorTb.IconLeftSize = new System.Drawing.Size(25, 25);
            this.BAuthorTb.Location = new System.Drawing.Point(310, 138);
            this.BAuthorTb.Name = "BAuthorTb";
            this.BAuthorTb.PasswordChar = '\0';
            this.BAuthorTb.PlaceholderText = "";
            this.BAuthorTb.SelectedText = "";
            this.BAuthorTb.Size = new System.Drawing.Size(228, 33);
            this.BAuthorTb.TabIndex = 129;
            // 
            // BYPulishedTb
            // 
            this.BYPulishedTb.BorderRadius = 5;
            this.BYPulishedTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BYPulishedTb.DefaultText = "";
            this.BYPulishedTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.BYPulishedTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.BYPulishedTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BYPulishedTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BYPulishedTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BYPulishedTb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BYPulishedTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.BYPulishedTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BYPulishedTb.IconLeftSize = new System.Drawing.Size(25, 25);
            this.BYPulishedTb.Location = new System.Drawing.Point(310, 238);
            this.BYPulishedTb.Name = "BYPulishedTb";
            this.BYPulishedTb.PasswordChar = '\0';
            this.BYPulishedTb.PlaceholderText = "";
            this.BYPulishedTb.SelectedText = "";
            this.BYPulishedTb.Size = new System.Drawing.Size(101, 33);
            this.BYPulishedTb.TabIndex = 130;
            // 
            // BGenreTb
            // 
            this.BGenreTb.BorderRadius = 5;
            this.BGenreTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BGenreTb.DefaultText = "";
            this.BGenreTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.BGenreTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.BGenreTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BGenreTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BGenreTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BGenreTb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BGenreTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.BGenreTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BGenreTb.IconLeftSize = new System.Drawing.Size(25, 25);
            this.BGenreTb.Location = new System.Drawing.Point(310, 288);
            this.BGenreTb.Name = "BGenreTb";
            this.BGenreTb.PasswordChar = '\0';
            this.BGenreTb.PlaceholderText = "";
            this.BGenreTb.SelectedText = "";
            this.BGenreTb.Size = new System.Drawing.Size(101, 33);
            this.BGenreTb.TabIndex = 131;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label6.Location = new System.Drawing.Point(159, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 24);
            this.label6.TabIndex = 133;
            this.label6.Text = "Số lượng";
            // 
            // BQtyNUD
            // 
            this.BQtyNUD.BackColor = System.Drawing.Color.Transparent;
            this.BQtyNUD.BorderRadius = 5;
            this.BQtyNUD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BQtyNUD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BQtyNUD.Location = new System.Drawing.Point(310, 338);
            this.BQtyNUD.Name = "BQtyNUD";
            this.BQtyNUD.Size = new System.Drawing.Size(101, 33);
            this.BQtyNUD.TabIndex = 134;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label7.Location = new System.Drawing.Point(159, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 24);
            this.label7.TabIndex = 135;
            this.label7.Text = "Loại sách";
            // 
            // BLinkTb
            // 
            this.BLinkTb.BorderRadius = 5;
            this.BLinkTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BLinkTb.DefaultText = "";
            this.BLinkTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.BLinkTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.BLinkTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BLinkTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BLinkTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BLinkTb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BLinkTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.BLinkTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BLinkTb.IconLeftSize = new System.Drawing.Size(25, 25);
            this.BLinkTb.Location = new System.Drawing.Point(309, 392);
            this.BLinkTb.Name = "BLinkTb";
            this.BLinkTb.PasswordChar = '\0';
            this.BLinkTb.PlaceholderText = "";
            this.BLinkTb.SelectedText = "";
            this.BLinkTb.Size = new System.Drawing.Size(229, 33);
            this.BLinkTb.TabIndex = 138;
            this.BLinkTb.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label8.Location = new System.Drawing.Point(158, 388);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 24);
            this.label8.TabIndex = 137;
            this.label8.Text = "Đường dẫn";
            this.label8.Visible = false;
            // 
            // BTypeCb
            // 
            this.BTypeCb.BackColor = System.Drawing.Color.Transparent;
            this.BTypeCb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.BTypeCb.BorderRadius = 5;
            this.BTypeCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.BTypeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BTypeCb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BTypeCb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BTypeCb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BTypeCb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.BTypeCb.ItemHeight = 30;
            this.BTypeCb.Items.AddRange(new object[] {
            "Sách truyền thống",
            "Sách điện tử"});
            this.BTypeCb.Location = new System.Drawing.Point(310, 188);
            this.BTypeCb.Name = "BTypeCb";
            this.BTypeCb.Size = new System.Drawing.Size(179, 36);
            this.BTypeCb.TabIndex = 139;
            this.BTypeCb.SelectedIndexChanged += new System.EventHandler(this.BTypeCb_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.label9.Location = new System.Drawing.Point(159, 388);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 24);
            this.label9.TabIndex = 140;
            this.label9.Text = "Vị trí";
            // 
            // BLocationTb
            // 
            this.BLocationTb.BorderRadius = 5;
            this.BLocationTb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BLocationTb.DefaultText = "";
            this.BLocationTb.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.BLocationTb.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.BLocationTb.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BLocationTb.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BLocationTb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BLocationTb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BLocationTb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.BLocationTb.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BLocationTb.IconLeftSize = new System.Drawing.Size(25, 25);
            this.BLocationTb.Location = new System.Drawing.Point(309, 392);
            this.BLocationTb.Name = "BLocationTb";
            this.BLocationTb.PasswordChar = '\0';
            this.BLocationTb.PlaceholderText = "";
            this.BLocationTb.SelectedText = "";
            this.BLocationTb.Size = new System.Drawing.Size(229, 33);
            this.BLocationTb.TabIndex = 141;
            // 
            // AddNewBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(555, 521);
            this.Controls.Add(this.BLocationTb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BTypeCb);
            this.Controls.Add(this.BLinkTb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BQtyNUD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BGenreTb);
            this.Controls.Add(this.BYPulishedTb);
            this.Controls.Add(this.BAuthorTb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.BNameTb);
            this.Controls.Add(this.ImageButton);
            this.Controls.Add(this.UserImagePb);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddNewBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddNewBooks";
            ((System.ComponentModel.ISupportInitialize)(this.UserImagePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserPfpPb)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BQtyNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.PictureBox UserImagePb;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Guna.UI2.WinForms.Guna2Button SaveButton;
        private Guna.UI2.WinForms.Guna2TextBox BNameTb;
        private Guna.UI2.WinForms.Guna2Button ImageButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox UserPfpPb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox BGenreTb;
        private Guna.UI2.WinForms.Guna2TextBox BYPulishedTb;
        private Guna.UI2.WinForms.Guna2TextBox BAuthorTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2NumericUpDown BQtyNUD;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox BLinkTb;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2ComboBox BTypeCb;
        private Guna.UI2.WinForms.Guna2TextBox BLocationTb;
        private System.Windows.Forms.Label label9;
    }
}