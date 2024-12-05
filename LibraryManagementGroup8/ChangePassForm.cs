using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementGroup8
{
    public partial class ChangePassForm : Form
    {
        public ChangePassForm()
        {
            InitializeComponent();
            NoteLbl.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var user = context.UserTbls.FirstOrDefault(u => u.UserId == Login.userId);
                if (!BCrypt.Net.BCrypt.Verify(UserPrePassTb.Text, user.UserPass))
                {
                    NoteLbl.Text = "Mật khẩu hiện tại không đúng !!! ";
                }
                if (UserPass1Tb.Text != UserPass2Tb.Text)//Mk nhập vào ô ko mã hóa, khi nào xác nhận rồi mới băm ra
                {
                    NoteLbl.Text = "Mật khẩu mới không trùng khớp !!!";
                }
                if (UserPass1Tb.Text == "" ||  UserPass2Tb.Text == "" || UserPrePassTb.Text == "")
                {
                    NoteLbl.Text = "Vui lòng điền đầy đủ thông tin !!!";
                }
                else
                {
                    if (UserPass1Tb.Text.Length < 8)
                    {
                        NoteLbl.Text="Mật khẩu phải từ 8 kí tự trở lên";
                        return;
                    }
                    if (BCrypt.Net.BCrypt.Verify(UserPrePassTb.Text, user.UserPass) && UserPass1Tb.Text == UserPass2Tb.Text)
                    {
                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(UserPass2Tb.Text);
                        user.UserPass = hashedPassword;
                        context.SubmitChanges();
                        MessageBox.Show("Mật khẩu đã được cập nhật !!!");
                        this.Close();
                    }
                }
            }
        }
    }
}
