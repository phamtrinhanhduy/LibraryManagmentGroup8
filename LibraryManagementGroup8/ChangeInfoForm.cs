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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagementGroup8
{
    public partial class ChangeInfoForm : Form
    {
        public ChangeInfoForm()
        {
            InitializeComponent();
            LoadUserInfo();
            NoteLbl.Text = "";
        }

        private void UserLogNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UserImagePb_.Image = new Bitmap(openFileDialog.FileName);
            }
        }
        private void LoadUserInfo()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var user = context.UserDetailTbls.FirstOrDefault(u => u.UserId == Login.userId);

                if (user != null)
                {
                    UserAddTb.Text = user.UserAdd;
                    UserPhoneTb.Text = user.UserPhone;
                    UserEmailTb.Text = user.UserEmail;
                    if (user.UserPfp != null)
                    {
                        using (var ms = new MemoryStream(user.UserPfp.ToArray()))
                        {
                            UserImagePb_.Image = Image.FromStream(ms);
                        }
                    }
                }
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (UserPhoneTb.Text == "" || UserAddTb.Text == "" || UserEmailTb.Text == "")
            {
                NoteLbl.Text = "Thiếu thông tin !!!";
            }
            else
            {
                try
                {
                    using (var context = new LibraryManagmentGroup8DataContext())
                    {
                        var userToUpdate = context.UserDetailTbls.FirstOrDefault(user => user.UserId == Login.userId);

                        if (userToUpdate != null)
                        {
                            userToUpdate.UserPhone = UserPhoneTb.Text;
                            userToUpdate.UserEmail = UserEmailTb.Text;
                            userToUpdate.UserAdd = UserAddTb.Text;
                            userToUpdate.UserPfp = ConvertImageToBytes(UserImagePb_);

                            context.SubmitChanges();
                            MessageBox.Show("Thông tin người dùng đã được cập nhật");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Thông tin người dùng không tồn tài !!!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
