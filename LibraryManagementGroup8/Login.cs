using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementGroup8
{
    public partial class Login : Form
    {
        static public int userId;
        static public string userName;
        static public string userType;
        private int doubleCheck;
        public Login()
        {
            InitializeComponent();
            CheckUserExpiStatus();
            NoteLbl.Visible = false;
            PasswordTb.UseSystemPasswordChar = true;
        }
        public void CheckUserExpiStatus() //Kiểm tra xem thẻ hết hạn chưa (All users)
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var users = context.UserTbls.ToList();

                foreach (var user in users)
                {
                    if (user.ExpirationDate < DateTime.Now)
                    {
                        user.UserStatus = "Không khả dụng";
                    }
                }
                context.SubmitChanges();
            }
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            Register Obj = new Register();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            UsernameTb.Clear();
            PasswordTb.Clear();
            NoteLbl.Text = "";
        }

        private void ShowPassChk_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassChk.Checked) PasswordTb.UseSystemPasswordChar = false;
            else PasswordTb.UseSystemPasswordChar = true;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UsernameTb.Text == "" || PasswordTb.Text == "")
            {
                NoteLbl.Visible = true;
                NoteLbl.Text = "Vui lòng điền đầy đủ thông tin !";
            }
            else
            {
                bool flag = false;
                string tk = UsernameTb.Text.Trim();
                string mk = PasswordTb.Text.Trim();

                using (var context = new LibraryManagmentGroup8DataContext())
                {
                    // Lấy thông tin người dùng từ cơ sở dữ liệu dựa trên tên đăng nhập
                    var user = context.UserTbls.FirstOrDefault(u => u.UserLogName == tk);

                    if (user != null)
                    {
                        // Kiểm tra trạng thái tài khoản
                        if (user.UserStatus == "Không khả dụng")
                        {
                            NoteLbl.Text = "Tài khoản không khả dụng!"; // Nếu hết hiệu lực thì không cho đăng nhập
                            NoteLbl.Visible = true;
                        }
                        else
                        {
                            // So sánh mật khẩu nhập vào với mật khẩu hash lưu trữ
                            if (BCrypt.Net.BCrypt.Verify(mk, user.UserPass))
                            {
                                flag = true;
                                UsernameTb.ResetText();
                                PasswordTb.ResetText();
                                var detail = context.UserDetailTbls.FirstOrDefault(u => u.UserId == user.UserId);
                                userId = user.UserId;
                                userName = detail.UserName;
                                userType = user.UserType;
                                Properties.Settings.Default.NOV++;
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                NoteLbl.Text = "Tài khoản hoặc mật khẩu không đúng!";
                                NoteLbl.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        NoteLbl.Text = "Tài khoản hoặc mật khẩu không đúng!";
                        NoteLbl.Visible = true;
                    }
                }

                if (flag)
                {
                    Homes Obj = new Homes();
                    Obj.Show();
                    this.Hide();
                }
            }
        }


        private void SaveInfoChk_CheckedChanged(object sender, EventArgs e)
        {
            if (UsernameTb.Text != "" && PasswordTb.Text != "")
            {
                if (SaveInfoChk.Checked == true)
                {
                    string users = UsernameTb.Text;
                    string pwd = PasswordTb.Text;
                    Properties.Settings.Default.username = users;
                    Properties.Settings.Default.password = pwd;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    doubleCheck = Properties.Settings.Default.NOV;// Sao luu lai vi khi ko chon luu tk mk nua phai reset lai trong phan setting
                    Properties.Settings.Default.Reset();
                    Properties.Settings.Default.NOV = doubleCheck;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load_1(object sender, EventArgs e)
        {
            UsernameTb.Text = Properties.Settings.Default.username;
            PasswordTb.Text = Properties.Settings.Default.password;
            if (Properties.Settings.Default.username != "")
            {
                SaveInfoChk.Checked = true;
            }
        }
    }
}
