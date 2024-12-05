using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementGroup8
{
    public partial class ucUsers : UserControl
    {
        public event EventHandler onSelect = null;
        public event EventHandler UserUpdated; //Sự kiện 
        public ucUsers()
        {
            InitializeComponent();
            lblStatus.Visible = false;
            ShowUserDetail();
        }
        private void UcUsers_Click(object sender, EventArgs e)
        {
            if (UserStatus == "Khả dụng")
            {
                UsersDetail userDetailForm = new UsersDetail(UserId);
                userDetailForm.ShowDialog();
            }
            else
            {
                UsersDetail userDetailForm = new UsersDetail(UserId);
                userDetailForm.ReturnBtn.Visible = true;
                userDetailForm.ShowDialog();
            }
            onSelect?.Invoke(this, EventArgs.Empty);
            UserUpdated?.Invoke(this, EventArgs.Empty); //Gọi sự kiện sau khi thoát form
        }

        public int UserId { 
            get { return int.Parse(lblId.Text); } 
            set { lblId.Text = value.ToString(); }
        }
        public string UserName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }
        public string UserType
        {
            get { return lblType.Text; }
            set { lblType.Text = value; }
        }
        public string UserCreDate
        {
            get { return lblCreDate.Text; }
            set { lblCreDate.Text = value; }
        }
        public string UserExpiDate
        {
            get { return lblExpiDate.Text; }
            set { lblExpiDate.Text = value; }
        }
        public Image UserPfp
        {
            get { return pbImage.Image; }
            set { pbImage.Image = value; }
        }
        public string UserStatus
        {
            get { return lblStatus.Text; }
            set { lblStatus.Text = value; }
        }
        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void ucUsers_Load(object sender, EventArgs e)
        {

        }
        private void ShowUserDetail()
        {
            panel1.Click += UcUsers_Click;
            label5.Click += UcUsers_Click;
            pbImage.Click += UcUsers_Click;
            label6.Click += UcUsers_Click;
            pictureBox15.Click += UcUsers_Click;
            lblId.Click += UcUsers_Click;
            lblName.Click += UcUsers_Click;
            lblCreDate.Click += UcUsers_Click;
            lblExpiDate.Click += UcUsers_Click;
            lblType.Click += UcUsers_Click;
            label4.Click += UcUsers_Click;
            label3.Click += UcUsers_Click;
            label2.Click += UcUsers_Click;
            label1.Click += UcUsers_Click;
        }
    }
}
