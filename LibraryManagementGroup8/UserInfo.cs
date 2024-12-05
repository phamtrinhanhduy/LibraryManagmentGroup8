using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementGroup8
{
    public partial class UserInfo : Form
    {

        public UserInfo()
        {
            InitializeComponent();
            LoadUserInfo();
            UserAccess();
        }
        private void UserAccess()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var userDetail = context.UserDetailTbls.FirstOrDefault(ud => ud.UserId == Login.userId);
                if (userDetail != null)
                {
                    Username.Text = userDetail.UserName;
                    UserInfoBtn.Text = Login.userType;
                    if (userDetail.UserPfp != null)
                    {
                        using (var ms = new MemoryStream(userDetail.UserPfp.ToArray()))
                        {
                            UserImagePb.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
            if (Login.userType == "Khách" || Login.userType == "Giảng viên" || Login.userType == "Sinh viên")
            {
                guna2Button7.Visible = false;
                guna2Button3.Visible = false;
                guna2Button1.Visible = false;
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void UserInfo_Load(object sender, EventArgs e)
        {
        }
        private void LoadUserInfo()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var user = context.UserTbls.FirstOrDefault(u => u.UserId == Login.userId);
                if (user != null)
                {
                    var userDetail = context.UserDetailTbls.FirstOrDefault(ud => ud.UserId == user.UserId);
                    UserLogNameLbl.Text = user.UserLogName;
                    UserTypeLbl.Text = user.UserType;
                    if (userDetail != null)
                    {
                        Username.Text = userDetail.UserName;
                        UserNameLbl.Text = userDetail.UserName;
                        UserAddLbl.Text = userDetail.UserAdd;
                        UserPhoneLbl.Text = userDetail.UserPhone;
                        UserEmailLbl.Text = userDetail.UserEmail;
                        UserGenderLbl.Text = userDetail.UserGender;
                        UserDOBLbl.Text = userDetail.UserDOB.ToString("dd/MM/yyyy");
                        if (userDetail.UserPfp != null)
                        {
                            using (var ms = new MemoryStream(userDetail.UserPfp.ToArray()))
                            {
                                //UserAvatar.Image = Image.FromStream(ms);
                                UserImage.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ChangePassForm Obj = new ChangePassForm();
            Obj.ShowDialog();
            LoadUserInfo();
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            ChangeInfoForm Obj = new ChangeInfoForm();
            Obj.ShowDialog();
            LoadUserInfo();
            UserAccess();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Books Obj = new Books();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Homes obj = new Homes();
            obj.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Books obj = new Books();
            obj.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            LoanBooks obj = new LoanBooks();
            obj.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Service obj = new Service();
            obj.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Statistical obj = new Statistical();
            obj.Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            UserInLib obj = new UserInLib();
            obj.Show();
            this.Hide();
        }

        private void CustAndSupBtn_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Close();
        }
    }
}
