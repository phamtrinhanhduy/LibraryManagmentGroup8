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
using static Guna.UI2.Native.WinApi;

namespace LibraryManagementGroup8
{
    public partial class UserInLib : Form
    {
        private List<int> _exportedUsersIds = new List<int>();
        public int count = 1;
        public UserInLib()
        {
            InitializeComponent();
            UserStatusCb.Text = "Khả dụng";
            UserTypeCb.DataSource = new List<string> { "Theo loại", "Khách", "Sinh viên", "Giảng viên" };
            LoadUsers();
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
                    UserInfo.Text = Login.userType;
                    if (userDetail.UserPfp != null)
                    {
                        using (var ms = new MemoryStream(userDetail.UserPfp.ToArray()))
                        {
                            UserImage.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
            if (Login.userType == "Thủ thư")
            {
                SwitchToAdminButton.Visible = false;
            }
        }

        private void AddUser(int id, string name, string type, Image uimage, string credate, string expidate, string statuss)
        {
            var b = new ucUsers
            {
                UserId = id,
                UserName = name,
                UserType = type,
                UserPfp = uimage,
                UserCreDate = credate,
                UserExpiDate = expidate,
                UserStatus = statuss,
            };
            b.UserUpdated += (s, e) =>
            {
                if (UsersDetail.infoUpdated == 1)
                {
                    LoadUsers();
                    UsersDetail.infoUpdated = 0;
                }
            };
            if (type == "Khách")
            {
                b.BackColor = Color.MediumSeaGreen;
            }
            else if (type == "Giảng viên")
            {
                b.BackColor = Color.SteelBlue;
            }
            else if (type == "Thủ thư")
            {
                b.BackColor = Color.DarkGreen;
            }
            else if (type == "Admin")
            {
                b.BackColor = Color.Goldenrod;
            }
            if (statuss == "Không khả dụng")
            {
                b.BackColor = Color.DarkRed;
            }
            flowLayoutPanel1.Controls.Add(b);
        }
        public void LoadUsers()
        {
            UserTypeCb.StartIndex = 0;
            _exportedUsersIds.Clear();
            flowLayoutPanel1.Controls.Clear();

            using (var context = new LibraryManagmentGroup8DataContext())
            {
                if (count == 1)
                {
                    SwitchToAdminButton.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Admin_No.png"));
                    //Xuất ra độc giả trong lib
                    var users = from user in context.UserTbls
                                join detail in context.UserDetailTbls on user.UserId equals detail.UserId
                                where !_exportedUsersIds.Contains(user.UserId) && user.UserStatus == UserStatusCb.Text
                                 && (user.UserType == "Khách" || user.UserType == "Sinh Viên" || user.UserType == "Giảng Viên")
                                select new
                                {
                                    user.UserId,
                                    UserName = detail.UserName, 
                                    user.UserType,
                                    UserPfp = detail.UserPfp,  
                                    user.CreationDate,
                                    user.ExpirationDate,
                                    user.UserStatus,
                                };
                    if (!users.Any())
                    {
                        return;
                    }

                    foreach (var u in users)
                    {
                        byte[] imageArray = u.UserPfp.ToArray();
                        Image userImage = Image.FromStream(new MemoryStream(imageArray));
                        AddUser(u.UserId, u.UserName, u.UserType, userImage, u.CreationDate.ToString("dd/MM/yyyy"), u.ExpirationDate.ToString("dd/MM/yyyy"), u.UserStatus);

                        _exportedUsersIds.Add(u.UserId);
                    }
                }
                else
                {
                    SwitchToAdminButton.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Admin_Yes.png"));
                    var users = from user in context.UserTbls
                                join detail in context.UserDetailTbls on user.UserId equals detail.UserId
                                where !_exportedUsersIds.Contains(user.UserId) && user.UserStatus == UserStatusCb.Text
                                 && (user.UserType == "Thủ thư" || user.UserType == "Admin")
                                select new
                                {
                                    user.UserId,
                                    UserName = detail.UserName,
                                    user.UserType,
                                    UserPfp = detail.UserPfp,
                                    user.CreationDate,
                                    user.ExpirationDate,
                                    user.UserStatus,
                                };
                    if (!users.Any())
                    {
                        return;
                    }

                    foreach (var u in users)
                    {
                        byte[] imageArray = u.UserPfp.ToArray();
                        Image userImage = Image.FromStream(new MemoryStream(imageArray));
                        AddUser(u.UserId, u.UserName, u.UserType, userImage, u.CreationDate.ToString("dd/MM/yyyy"), u.ExpirationDate.ToString("dd/MM/yyyy"), u.UserStatus);

                        _exportedUsersIds.Add(u.UserId);
                    }
                }
                // Lấy chi tiết người dùng đăng nhập
                var userDetail = context.UserDetailTbls.FirstOrDefault(ud => ud.UserId == Login.userId);
                if (userDetail != null)
                {
                    Username.Text = userDetail.UserName;

                    if (userDetail.UserPfp != null)
                    {
                        using (var ms = new MemoryStream(userDetail.UserPfp.ToArray()))
                        {
                            UserImage.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
        }
        private void SearchUsers()
        {
            // Lấy thông tin tìm kiếm từ các TextBox và ComboBox
            string nameSearch = SearchByNameTb.Text.Trim().ToLower();
            string idSearch = SearchByIDTb.Text.Trim().ToLower();
            string userTypeSearch = UserTypeCb.SelectedValue?.ToString().ToLower();

            foreach (ucUsers user in flowLayoutPanel1.Controls)
            {
                bool matchesName = string.IsNullOrEmpty(nameSearch) || user.UserName.ToLower().Contains(nameSearch);

                bool matchesId = string.IsNullOrEmpty(idSearch) || user.UserId.ToString().Contains(idSearch);

                bool matchesType = userTypeSearch == "theo loại" || string.IsNullOrEmpty(userTypeSearch) || user.UserType.ToLower().Contains(userTypeSearch);

                user.Visible = matchesName && matchesId && matchesType;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Register obj = new Register();
            obj.ShowDialog();
            if (Register.addUpdated == 1)
            {
                LoadUsers();
                Register.addUpdated = 0;
            }

        }

        private void SearchByNameTb_TextChanged(object sender, EventArgs e)
        {
            SearchUsers();
        }

        private void SearchByIDTb_TextChanged(object sender, EventArgs e)
        {
            SearchUsers();
        }

        private void UserTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserTypeCb.ForeColor = Color.FromArgb(75, 50, 80);
            if (UserTypeCb.SelectedItem == "Theo loại")
            {
                UserTypeCb.ForeColor = Color.FromArgb(193, 200, 207);
            }
            SearchUsers();
        }

        private void AddBook_Button_Click(object sender, EventArgs e)
        {
            SearchByNameTb.Clear();
            SearchByIDTb.Clear();
            UserTypeCb.StartIndex = 0;
            SearchUsers();
            UserTypeCb.ForeColor = Color.FromArgb(193, 200, 207);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsers();// Chuyển theo giá trị Cb hiện tại
        }

        private void SwitchToAdminButton_Click(object sender, EventArgs e)
        {
            count++;
            UserTypeCb.DataSource = new List<string> { "Theo loại", "Admin", "Thủ thư"};
            if (count == 3)
            {
                count = 1;// Quay lại giá trị lúc đầu
                UserTypeCb.DataSource = new List<string> { "Theo loại", "Khách", "Sinh viên", "Giảng viên" };
            }
            LoadUsers();
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

        private void CustAndSupBtn_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Username_Click(object sender, EventArgs e)
        {
            UserInfo obj = new UserInfo();
            obj.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Statistical obj = new Statistical();
            obj.Show();
            this.Hide();
        }
    }
}
