using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagementGroup8
{
    public partial class Homes : Form
    {
        public Homes()
        {
            InitializeComponent();
            label12.Text = "Sách dược mượn nhiều nhất trong tháng " + DateTime.Now.Month.ToString();
            label11.Text = "Độc giả tích cực nhất trong tháng " + DateTime.Now.Month.ToString();
            CountUserInLib();
            DisplayUsers();
            DisplayBooks();
            CountBookInLib();
            CountEBookInLib();
            CountLoanBookInLib();
            ActiveBook();
            ActiveUser();
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
            if (Login.userType == "Khách" || Login.userType == "Giảng viên" || Login.userType == "Sinh viên")
            {
                guna2Button2.Visible = false;
                guna2Button3.Visible = false;
                guna2Button1.Visible = false;
            }
        }
        private void ActiveBook()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var currentMonth = DateTime.Now.Month;
                var currentYear = DateTime.Now.Year;

                var mostFrequentBId = (from detail in context.LoanDetailTbls
                                       where detail.LoanDate.Month == currentMonth && detail.LoanDate.Year == currentYear
                                       group detail by detail.BId into g
                                       orderby g.Count() descending
                                       select new { BId = g.Key, Count = g.Count() }).FirstOrDefault();

                if (mostFrequentBId == null)
                {
                    ActiveBIdLbl.Text = "";
                    MostActiveBookImage.Image = null;
                    return;
                }

                var bookInfo = (from book in context.BookTbls
                                where book.BId == mostFrequentBId.BId
                                select new
                                {
                                    BName = book.BName,
                                    BId = book.BId,
                                    BImage = book.BImage,
                                }).FirstOrDefault();

                if (bookInfo != null)
                {
                    ActiveBookLbl.Text = bookInfo.BName;
                    ActiveBIdLbl.Text = "Mã sách #" + bookInfo.BId;

                    if (bookInfo.BImage != null)
                    {
                        using (var ms = new MemoryStream(bookInfo.BImage.ToArray()))
                        {
                            MostActiveBookImage.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MostActiveBookImage.Image = null; 
                    }
                }
            }
        }

        private void ActiveUser()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var currentMonth = DateTime.Now.Month;
                var currentYear = DateTime.Now.Year;

                // Tìm đọc giả tích cực nhất trong tháng hiện tại (dựa vào bảng LoanDetailTbl và LoanTbl)
                var mostFrequentUser = (from detail in context.LoanDetailTbls
                                        join loan in context.LoanTbls on detail.LoanId equals loan.LoanId
                                        where detail.LoanDate.Month == currentMonth && detail.LoanDate.Year == currentYear
                                        group detail by loan.UserId into g
                                        orderby g.Count() descending
                                        select new { UserId = g.Key, Count = g.Count() }).FirstOrDefault();

                if (mostFrequentUser != null)
                {
                    var userInfo = from user in context.UserTbls
                                   join detail in context.UserDetailTbls on user.UserId equals detail.UserId
                                   where user.UserId == mostFrequentUser.UserId
                                   select new
                                   {
                                       UserName = detail.UserName,
                                       UserId = user.UserId,
                                       UserImage = detail.UserPfp,
                                   };

                    var mostActiveUser = userInfo.FirstOrDefault();
                    if (mostActiveUser != null)
                    {
                        // Hiển thị thông tin của đọc giả tích cực nhất
                        ActiveUserLbl.Text = mostActiveUser.UserName;
                        ActiveUserIdLbl.Text = "Mã độc giả #" + mostActiveUser.UserId;
                        if (mostActiveUser.UserImage != null)
                        {
                            using (var ms = new MemoryStream(mostActiveUser.UserImage.ToArray()))
                            {
                                MostActiveUserImage.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
        }

        private void CountUserInLib()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                int userCount = context.UserTbls.Count();
                CountUserLbl.Text = userCount.ToString();
            }
        }
        private void CountBookInLib()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                int totalBooks = context.LoanDetailTbls
                                            .Where(book => book.LoanBStatus == "Đang mượn")
                                            .Count();
                int totalQuantity = context.BookTbls
                                           .Where(book => book.BQuanlity != 0 && book.BType == "Sách truyền thống")
                                           .Sum(book => book.BQuanlity);

                CountBookLbl.Text = (totalQuantity+ totalBooks).ToString();
            }
        }
        private void CountLoanBookInLib()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                int totalBooks = context.LoanDetailTbls
                                        .Where(book => book.LoanBStatus == "Đang mượn")
                                        .Count();

                CountLoanBooksLbl.Text = totalBooks.ToString();
            }
        }

        private void CountEBookInLib()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                int totalBooks = context.BookTbls
                                        .Where(book => book.BType == "Sách điện tử" & book.BStatus == "Khả dụng")
                                        .Count();

                CountEBooksLbl.Text = totalBooks.ToString();
            }
        }

        private void DisplayUsers()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var today = DateTime.Today;
                var users = from user in context.UserTbls
                            join detail in context.UserDetailTbls on user.UserId equals detail.UserId
                            where user.CreationDate.Date == today
                            select new
                            {
                                UserType = user.UserType,    
                                UserName = detail.UserName,  
                                UserEmail = detail.UserEmail 
                            };

                var userList = users.ToList();
                NewUserDGV.Rows.Clear();

                foreach (var user in userList)
                {
                    int rowIndex = NewUserDGV.Rows.Add();
                    DataGridViewRow row = NewUserDGV.Rows[rowIndex];
                    row.Cells["UserTypeColumn"].Value = user.UserType;
                    row.Cells["UserNameColumn"].Value = user.UserName;
                    row.Cells["UserEmailColumn"].Value = user.UserEmail;
                }
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
        }

        private void DisplayBooks()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var today = DateTime.Today;
                var books = from book in context.BookTbls
                            where book.BAddDate == today
                            select new
                            {
                                BAuthor = book.BAuthor,
                                BName = book.BName,
                                BGenre = book.BGenre
                            };

                var bookList = books.ToList();
                NewBookDGV.Rows.Clear();

                foreach (var book in bookList)
                {
                    int rowIndex = NewBookDGV.Rows.Add();
                    DataGridViewRow row = NewBookDGV.Rows[rowIndex];
                    row.Cells["BNameColumn"].Value = book.BName;
                    row.Cells["BGenreColumn"].Value = book.BGenre;
                    row.Cells["BAuthorColumn"].Value = book.BAuthor;
                }
            }
        }

        private void UserInfo_Click(object sender, EventArgs e)
        {
        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel19_Click(object sender, EventArgs e)
        {

        }

        private void panel18_Click(object sender, EventArgs e)
        {
            Books obj = new Books();
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Statistical obj = new Statistical();
            obj.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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

        private void Username_Click(object sender, EventArgs e)
        {
            UserInfo obj = new UserInfo();
            obj.Show();
            this.Hide();
        }
    }
}
