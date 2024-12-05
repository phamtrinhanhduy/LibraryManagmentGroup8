using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace LibraryManagementGroup8
{
    public partial class Register : Form
    {
        static public int addUpdated = 0;
        public Register()
        {
            InitializeComponent();
            StudentIdTb.Visible = false;
            NoteLbl.Text = "";
            UserAccess();
        }
        void UserAccess()
        {
            if (Login.userType == "Thủ thư")
            {
                UserTypeCb.DataSource = new List<string> { "Theo loại", "Khách", "Sinh viên", "Giảng viên" };
            }
            else
            {
                UserTypeCb.DataSource = new List<string> { "Theo loại", "Thủ thư", "Khách", "Sinh viên", "Giảng viên" };
            }
        }
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private byte[] ConvertImageToBytes(PictureBox pictureBox)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        private void Clear()
        {
            UserNameTb.Text = "";
            UserLogNameTb.Text = "";
            UserPhoneTb.Text = "";
            UserAddTb.Text = "";
            UserPass1Tb.Text = "";
            UserPass2Tb.Text = "";
            UserEmailTb.Text = "";
            UserTypeCb.SelectedItem = null;
            UserGenderCb.SelectedItem = null;
            StudentIdTb.Text = "";
            UserImage.Image = Image.FromFile("empty_avatar.png");
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(UserPass1Tb.Text == UserPass2Tb.Text)
            {
                if (UserLogNameTb.Text == "" || UserPass1Tb.Text == "" || UserPass2Tb.Text == "" || UserNameTb.Text == "" || UserPhoneTb.Text == "" || UserAddTb.Text == "" || UserEmailTb.Text == "" || UserTypeCb.SelectedItem == "Chọn loại" || StudentIdTb.Text == "" || UserGenderCb.SelectedItem == "Giới")
                {
                    NoteLbl.Text = "Thiếu thông tin !!!";
                }
                else
                {
                    if (UserPass1Tb.Text.Length < 8)
                    {
                        NoteLbl.Text="Mật khẩu phải từ 8 kí tự trở lên";
                        return;
                    }
                    if(UserTypeCb.SelectedItem.ToString() == "Sinh viên")
                    {
                        if(StudentIdTb.TextLength != 13)
                        {
                            NoteLbl.Text = "Mã số sinh viên không hợp lệ !!! Ví dụ hợp lệ: 48.01.103.019";
                        }
                        else
                        {
                            addUpdated++;
                            try
                            {
                                using (var context = new LibraryManagmentGroup8DataContext())
                                {
                                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(UserPass1Tb.Text);
                                    var newUser = new UserTbl
                                    {
                                        UserLogName = UserLogNameTb.Text,
                                        UserPass = hashedPassword,
                                        UserType = UserTypeCb.Text,
                                        CreationDate = DateTime.Now,
                                        ExpirationDate = DateTime.Now.AddYears(1),
                                        UserStatus = "Khả dụng",
                                    };
                                    context.UserTbls.InsertOnSubmit(newUser);
                                    context.SubmitChanges();
                                    var newUserDetail = new UserDetailTbl
                                    {
                                        UserGender = UserGenderCb.Text,
                                        UserName = UserNameTb.Text,
                                        UserPhone = UserPhoneTb.Text,
                                        UserEmail = UserEmailTb.Text,
                                        UserDOB = UserDOB.Value.Date,
                                        UserAdd = UserAddTb.Text,
                                        PersonId = StudentIdTb.Text,
                                        UserId = newUser.UserId,
                                        UserPfp = ConvertImageToBytes(UserImage)
                                    };
                                    context.UserDetailTbls.InsertOnSubmit(newUserDetail);
                                    context.SubmitChanges();

                                }
                                MessageBox.Show("Đăng ký thành công !!!");
                                Clear();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                    else if (UserTypeCb.SelectedItem.ToString() == "Khách")
                    {
                        if (StudentIdTb.TextLength != 12)
                        {
                            NoteLbl.Text = "Số CMND/CCCD không hợp lệ !!! Ví dụ hợp lệ: 079201892003";
                        }
                        else
                        {
                            addUpdated++;
                            try
                            {
                                using (var context = new LibraryManagmentGroup8DataContext())
                                {
                                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(UserPass1Tb.Text);
                                    var newUser = new UserTbl
                                    {
                                        UserLogName = UserLogNameTb.Text,
                                        UserPass = hashedPassword,
                                        UserType = UserTypeCb.Text,
                                        CreationDate = DateTime.Now,
                                        ExpirationDate = DateTime.Now.AddYears(1),
                                        UserStatus = "Khả dụng",
                                    };
                                    context.UserTbls.InsertOnSubmit(newUser);
                                    context.SubmitChanges();
                                    var newUserDetail = new UserDetailTbl
                                    {
                                        UserGender = UserGenderCb.Text,
                                        UserName = UserNameTb.Text,
                                        UserPhone = UserPhoneTb.Text,
                                        UserEmail = UserEmailTb.Text,
                                        UserDOB = UserDOB.Value.Date,
                                        UserAdd = UserAddTb.Text,
                                        PersonId = StudentIdTb.Text,
                                        UserId = newUser.UserId,
                                        UserPfp = ConvertImageToBytes(UserImage)
                                    };
                                    context.UserDetailTbls.InsertOnSubmit(newUserDetail);
                                    context.SubmitChanges();
                                }
                                MessageBox.Show("Đăng ký thành công !!!");
                                Clear();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else if (UserTypeCb.SelectedItem.ToString() == "Thủ thư")
                    {
                        if (StudentIdTb.TextLength != 12)
                        {
                            NoteLbl.Text = "Số CMND/CCCD không hợp lệ !!! Ví dụ hợp lệ: 079201892003";
                        }
                        else
                        {
                            addUpdated++;
                            try
                            {
                                using (var context = new LibraryManagmentGroup8DataContext())
                                {
                                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(UserPass1Tb.Text);
                                    var newUser = new UserTbl
                                    {
                                        UserLogName = UserLogNameTb.Text,
                                        UserPass = hashedPassword,
                                        UserType = UserTypeCb.Text,
                                        CreationDate = DateTime.Now,
                                        ExpirationDate = new DateTime(2999, 12, 31),
                                        UserStatus = "Khả dụng",
                                    };
                                    context.UserTbls.InsertOnSubmit(newUser);
                                    context.SubmitChanges();
                                    var newUserDetail = new UserDetailTbl
                                    {
                                        UserGender = UserGenderCb.Text,
                                        UserName = UserNameTb.Text,
                                        UserPhone = UserPhoneTb.Text,
                                        UserEmail = UserEmailTb.Text,
                                        UserDOB = UserDOB.Value.Date,
                                        UserAdd = UserAddTb.Text,
                                        PersonId = StudentIdTb.Text,
                                        UserId = newUser.UserId,
                                        UserPfp = ConvertImageToBytes(UserImage)
                                    };
                                    context.UserDetailTbls.InsertOnSubmit(newUserDetail);
                                    context.SubmitChanges();
                                }
                                MessageBox.Show("Đăng ký thành công !!!");
                                Clear();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        if (StudentIdTb.TextLength != 13)
                        {
                            NoteLbl.Text = "Mã giảng viên không hợp lệ !!! Ví dụ hợp lệ: HCMUE.103.001";
                        }
                        else
                        {
                            addUpdated++;
                            try
                            {
                                using (var context = new LibraryManagmentGroup8DataContext())
                                {
                                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(UserPass1Tb.Text);
                                    var newUser = new UserTbl
                                    {
                                        UserLogName = UserLogNameTb.Text,
                                        UserPass = hashedPassword,
                                        UserType = UserTypeCb.Text,
                                        CreationDate = DateTime.Now,
                                        ExpirationDate = DateTime.Now.AddYears(1),
                                        UserStatus = "Khả dụng",
                                    };
                                    context.UserTbls.InsertOnSubmit(newUser);
                                    context.SubmitChanges();
                                    var newUserDetail = new UserDetailTbl
                                    {
                                        UserGender = UserGenderCb.Text,
                                        UserName = UserNameTb.Text,
                                        UserPhone = UserPhoneTb.Text,
                                        UserEmail = UserEmailTb.Text,
                                        UserDOB = UserDOB.Value.Date,
                                        UserAdd = UserAddTb.Text,
                                        PersonId = StudentIdTb.Text,
                                        UserId = newUser.UserId,
                                        UserPfp = ConvertImageToBytes(UserImage)
                                    };
                                    context.UserDetailTbls.InsertOnSubmit(newUserDetail);
                                    context.SubmitChanges();

                                }
                                MessageBox.Show("Đăng ký thành công !!!");
                                Clear();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                }
            }
            else
            {
                NoteLbl.Text = "Mật khẩu không trùng khớp !!!";
            }
        }
        private void UserTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserTypeCb.ForeColor = Color.FromArgb(75, 50, 80);
            if (UserTypeCb.SelectedItem != null && UserTypeCb.SelectedItem.ToString() == "Sinh viên")
            {
                StudentIdTb.PlaceholderText = "Mã số sinh viên";
                StudentIdTb.Visible = true;
            }
            else if (UserTypeCb.SelectedItem != null && UserTypeCb.SelectedItem.ToString() == "Khách")
            {
                StudentIdTb.PlaceholderText = "Số CMND/CCCD";
                StudentIdTb.Visible = true;
            }
            else if (UserTypeCb.SelectedItem != null && UserTypeCb.SelectedItem.ToString() == "Thủ thư")
            {
                StudentIdTb.PlaceholderText = "Số CMND/CCCD";
                StudentIdTb.Visible = true;
            }
            else if (UserTypeCb.SelectedItem != null && UserTypeCb.SelectedItem.ToString() == "Giảng viên")
            {
                StudentIdTb.PlaceholderText = "Mã giảng viên";
                StudentIdTb.Visible = true;
            }
            else
            {
                UserTypeCb.ForeColor = Color.FromArgb(193, 200, 207);
                StudentIdTb.Visible = false;
            }
        }


        private void ImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); 
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UserImage.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserGenderCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserGenderCb.ForeColor = Color.FromArgb(75, 50, 80);
            if (UserGenderCb.SelectedItem != null && UserGenderCb.SelectedItem.ToString() == "Giới")
            {
                UserGenderCb.ForeColor = Color.FromArgb(193, 200, 207);
            }
        }
    }
}
