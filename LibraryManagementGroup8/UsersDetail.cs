using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagementGroup8
{
    public partial class UsersDetail : Form
    {
        private int _userId;
        public static int infoUpdated = 0;

        public UsersDetail(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadUsersDetail();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadUsersDetail()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var user = context.UserTbls.FirstOrDefault(u => u.UserId == _userId);
                if (user != null)
                {
                    var userDetail = context.UserDetailTbls.FirstOrDefault(ud => ud.UserId == user.UserId);
                    UserLogNameTb.Text = user.UserLogName;
                    UserTypeTb.Text = user.UserType;
                    CreDateTb.Text = user.CreationDate.ToString("dd/MM/yyyy");
                    ExpiDateTb.Text = user.ExpirationDate.ToString("dd/MM/yyyy");
                    UserIdTb.Text = user.UserId.ToString();
                    if (userDetail != null)
                    {
                        UserNameTb.Text = userDetail.UserName;
                        UserAddTb.Text = userDetail.UserAdd;
                        UserPhoneTb.Text = userDetail.UserPhone;
                        UserEmailTb.Text = userDetail.UserEmail;
                        UserGenderCb.Text = userDetail.UserGender;
                        PersonIdTb.Text = userDetail.PersonId;

                        if (userDetail.UserPfp != null)
                        {
                            using (var ms = new MemoryStream(userDetail.UserPfp.ToArray()))
                            {
                                UserImagePb.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var user = context.UserTbls.FirstOrDefault(u => u.UserId == _userId);
                if (user != null)
                {
                    var userDetail = context.UserDetailTbls.FirstOrDefault(ud => ud.UserId == user.UserId);
                    if (userDetail != null)
                    {
                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDetail.PersonId);
                        user.UserPass = hashedPassword;
                        context.SubmitChanges();
                        MessageBox.Show("Mật khẩu người dùng đã được reset !");
                        this.Close();
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            infoUpdated++;
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var user = context.UserTbls.FirstOrDefault(u => u.UserId == _userId);
                if (user != null)
                {
                    user.UserStatus = "Không khả dụng";
                    context.SubmitChanges();
                    MessageBox.Show("Thẻ đã hủy thành công !");
                    this.Close();
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (UserPhoneTb.Text == "" || UserAddTb.Text == "" || UserEmailTb.Text == "" || UserNameTb.Text == "")
            {
                MessageBox.Show("Thiếu thông tin !");
            }
            else
            {
                infoUpdated++;
                try
                {
                    using (var context = new LibraryManagmentGroup8DataContext())
                    {
                        var userToUpdate = context.UserDetailTbls.FirstOrDefault(user => user.UserId == _userId);

                        if (userToUpdate != null)
                        {
                            userToUpdate.UserPhone = UserPhoneTb.Text;
                            userToUpdate.UserEmail = UserEmailTb.Text;
                            userToUpdate.UserAdd = UserAddTb.Text;
                            userToUpdate.UserName = UserNameTb.Text;
                            userToUpdate.UserGender = UserGenderCb.Text;
                            userToUpdate.UserPfp = ConvertImageToBytes(UserImagePb);
                            context.SubmitChanges();
                            MessageBox.Show("Thông tin người dùng đã được cập nhật");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Thông tin người dùng không tồn tại !!!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UserImagePb.Image = new Bitmap(openFileDialog.FileName);
            }
        }
        private byte[] ConvertImageToBytes(PictureBox pictureBox)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            infoUpdated++;
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var user = context.UserTbls.FirstOrDefault(u => u.UserId == _userId);
                if (user != null)
                {
                    user.UserStatus = "Khả dụng";
                    context.SubmitChanges();
                    MessageBox.Show("Thẻ đã được khôi phục thành công !");
                    this.Close();
                }
            }
        }
    }
}
