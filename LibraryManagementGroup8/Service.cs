using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagementGroup8
{
    public partial class Service : Form
    {
        static public int loanId = 0;
        static public int uuserId = 0;
        static public int countB = 0;
        public Service()
        {
            InitializeComponent();
            lblDateLoan.Text = DateTime.Today.ToString("dd/MM/yyyy"); // Ngày mượn
            lblDateReturn.Text = DateTime.Today.AddDays(14).ToString("dd/MM/yyyy"); // Hạn trả (2 tuần)
            LoadUsers();
            LoadBooks();
            lblCountB.Text = "0";
            LoanBooksInDay();
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
        }
        public void LoanBooksInDay()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                int totalBooks = context.LoanDetailTbls
                                            .Where(book => book.LoanBStatus == "Đang mượn")
                                            .Count();
                int totalQuantity = context.BookTbls
                                           .Where(book => book.BQuanlity != 0 && book.BType == "Sách truyền thống")
                                           .Sum(book => book.BQuanlity);

                ProgressBars.Maximum = totalBooks + totalQuantity;
                ProgressBars.Value = Math.Min(totalQuantity, totalBooks + totalQuantity);
                ProgressBars.Text = $"{totalQuantity}";
                ProgressBars.Refresh();
            }
        }

        private void LoadUsers()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                // Truy vấn kết hợp giữa bảng UserTbl và UserDetailTbl
                var users = from user in context.UserTbls
                            where user.UserStatus == "Khả dụng" && user.UserType != "Thủ thư" && user.UserType != "Admin"
                            join detail in context.UserDetailTbls
                            on user.UserId equals detail.UserId 
                            select new
                            {
                                UserId = user.UserId,
                                UserName = detail.UserName,
                                UserPhone = detail.UserPhone,
                                UserType = user.UserType,
                                PersonId = detail.PersonId
                            };

                var userList = users.ToList();
                UsersDGV.Rows.Clear();

                foreach (var user in userList)
                {
                    int rowIndex = UsersDGV.Rows.Add();
                    DataGridViewRow row = UsersDGV.Rows[rowIndex];
                    row.Cells["Column6"].Value = user.UserId;
                    row.Cells["Column7"].Value = user.UserName;
                    row.Cells["Column8"].Value = user.UserPhone;
                    row.Cells["Column9"].Value = user.UserType;
                    row.Cells["Column10"].Value = user.PersonId;
                }
            }
        }
        private void LoadBooks()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var bs = from b in context.BookTbls
                         where b.BStatus == "Khả dụng" && b.BType == "Sách truyền thống"
                         select new
                            {
                                BId = b.BId,
                                BName = b.BName,
                                BAuthor = b.BAuthor,
                                BGenre = b.BGenre,
                                BQuanlity = b.BQuanlity,
                            };

                var bList = bs.ToList();
                BooksDGV.Rows.Clear();

                foreach (var b in bList)
                {
                    int rowIndex = BooksDGV.Rows.Add();
                    DataGridViewRow row = BooksDGV.Rows[rowIndex];
                    row.Cells["Column12"].Value = b.BId;
                    row.Cells["Column13"].Value = b.BName;
                    row.Cells["Column14"].Value = b.BAuthor;
                    row.Cells["Column15"].Value = b.BGenre;
                    row.Cells["Column16"].Value = b.BQuanlity;
                }
            }
        }
 
        private void SearchUsers()
        {
            string searchValue = SearchUsersTb.Text.Trim().ToLower();

            using (var context = new LibraryManagmentGroup8DataContext())
            {
                // Dữ liệu từ cả UserTbls và UserDetailTbls
                var cs = from cr in context.UserTbls
                         join detail in context.UserDetailTbls on cr.UserId equals detail.UserId
                         where cr.UserType != "Thủ thư" && cr.UserType != "Admin" && cr.UserStatus == "Khả dụng"
                         select new
                         {
                             cr.UserId,
                             detail.UserName,
                             cr.UserType,
                             detail.UserPhone,
                             detail.PersonId
                         };

                if (!string.IsNullOrEmpty(searchValue))
                {
                    cs = cs.Where(c =>
                        c.UserId.ToString().Contains(searchValue) ||
                        c.UserName.ToLower().Contains(searchValue) ||
                        c.UserType.ToLower().Contains(searchValue) ||
                        c.UserPhone.Contains(searchValue) ||
                        c.PersonId.ToLower().Contains(searchValue));
                }

                UsersDGV.Rows.Clear();
                foreach (var c in cs)
                {
                    int rowIndex = UsersDGV.Rows.Add();
                    UsersDGV.Rows[rowIndex].Cells["Column6"].Value = c.UserId;
                    UsersDGV.Rows[rowIndex].Cells["Column7"].Value = c.UserName;
                    UsersDGV.Rows[rowIndex].Cells["Column8"].Value = c.UserPhone;
                    UsersDGV.Rows[rowIndex].Cells["Column9"].Value = c.UserType;
                    UsersDGV.Rows[rowIndex].Cells["Column10"].Value = c.PersonId;
                }
            }
        }
        private void SearchBooks()
        {
            string searchValue = SearchBooksTb.Text.Trim().ToLower();

            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var cs = from cr in context.BookTbls
                         where cr.BStatus == "Khả dụng" && cr.BType == "Sách truyền thống"
                         select new
                         {
                             cr.BId,
                             cr.BName,
                             cr.BAuthor,
                             cr.BGenre,
                             cr.BQuanlity,
                         };

                if (!string.IsNullOrEmpty(searchValue))
                {
                    cs = cs.Where(c =>
                        c.BId.ToString().Contains(searchValue) ||
                        (c.BName != null && c.BName.ToLower().Contains(searchValue)) ||
                        (c.BAuthor != null && c.BAuthor.ToLower().Contains(searchValue)) ||
                        (c.BGenre != null && c.BGenre.ToLower().Contains(searchValue)) ||
                        (c.BQuanlity != null && c.BQuanlity.ToString().Contains(searchValue))
                    );
                }
                BooksDGV.Rows.Clear();
                foreach (var c in cs)
                {
                    int rowIndex = BooksDGV.Rows.Add();
                    BooksDGV.Rows[rowIndex].Cells["Column12"].Value = c.BId;
                    BooksDGV.Rows[rowIndex].Cells["Column13"].Value = c.BName;
                    BooksDGV.Rows[rowIndex].Cells["Column14"].Value = c.BAuthor;
                    BooksDGV.Rows[rowIndex].Cells["Column15"].Value = c.BGenre;
                    BooksDGV.Rows[rowIndex].Cells["Column16"].Value = c.BQuanlity;
                }
            }
        }
        private void UsersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string collname = UsersDGV.Columns[e.ColumnIndex].Name;
            if (collname == "Column11")
            {
                lblUserId.Text = UsersDGV.SelectedRows[0].Cells[0].Value.ToString();
            }
        }
        private void TempLoanDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)  // Hàm để tự động đánh STT dựa trên số hàng
        {
            if (e.ColumnIndex == 0)
            {
                lblCountB.Text = TempLoanDGV.Rows.Count.ToString();
                e.Value = e.RowIndex + 1;
            }
        }
        private void BooksDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string collname = BooksDGV.Columns[e.ColumnIndex].Name;
            if (collname == "Column17")
            {
                Noted obj = new Noted();
                obj.ShowDialog();
                string col12Value = BooksDGV.Rows[e.RowIndex].Cells[0].Value.ToString(); // Mã sách
                string col13Value = BooksDGV.Rows[e.RowIndex].Cells[1].Value.ToString(); // Tên sách
                string col14Value = BooksDGV.Rows[e.RowIndex].Cells[2].Value.ToString(); // Tác giả
                TempLoanDGV.Rows.Add(null, col12Value, col13Value, col14Value, obj.NotedTb.Text);
            }
        }

        private void TempLoanDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string collname = TempLoanDGV.Columns[e.ColumnIndex].Name;
            if (collname == "Column6_")
            {
                TempLoanDGV.Rows.RemoveAt(e.RowIndex);
            }
            if (TempLoanDGV.Rows.Count == 0)
            {
                lblCountB.Text = "0";
            }
        }
        private bool UpdateStockAndCheckQuantity(LibraryManagmentGroup8DataContext context) // Hàm này để cập nhật SL sách trong thư viện
        {
            Dictionary<int, int> productQuantities = new Dictionary<int, int>();

            foreach (DataGridViewRow row in TempLoanDGV.Rows)
            {
                int bId = Convert.ToInt32(row.Cells["Column2"].Value);
                int bTy = 1;

                if (productQuantities.ContainsKey(bId))
                {
                    productQuantities[bId] += bTy;
                }
                else
                {
                    productQuantities[bId] = bTy;
                }
            }

            foreach (var item in productQuantities)
            {
                int bId = item.Key;
                int requiredQty = item.Value;

                var product = context.BookTbls.FirstOrDefault(p => p.BId == bId);

                if (product != null)
                {
                    if (product.BQuanlity >= requiredQty)
                    {
                        // Trừ đi số lượng
                        product.BQuanlity -= requiredQty;
                    }
                    else
                    {
                        MessageBox.Show($"Sách {product.BName} không đủ số lượng trong thư viện !");
                        return false;
                    }
                }
            }

            return true;
        }
        private bool CanBorrowMoreBooks(int userId, int additionalBooks)
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var user = context.UserTbls.FirstOrDefault(u => u.UserId == userId);


                //giới hạn mượn của UserType
                int borrowLimit;
                switch (user.UserType)
                {
                    case "Khách":
                        borrowLimit = 2;
                        break;
                    case "Sinh viên":
                        borrowLimit = 4;
                        break;
                    case "Giảng viên":
                        borrowLimit = 10;
                        break;
                    default:
                        borrowLimit = 0;
                        break;
                }

                var loanIds = context.LoanTbls
                                     .Where(l => l.UserId == userId)
                                     .Select(l => l.LoanId)
                                     .ToList();

                // Đếm số sách người dùng đang mượn
                int currentlyBorrowed = context.LoanDetailTbls
                                                .Where(ld => loanIds.Contains(ld.LoanId) && ld.LoanBStatus == "Đang mượn")
                                                .Count();

                // Kiểm tra xem dc mượn tiếp hay ko
                if (currentlyBorrowed + additionalBooks > borrowLimit)
                {
                    MessageBox.Show($"Người dùng loại {user.UserType} chỉ được mượn tối đa {borrowLimit} sách.\n" +
                                    $"Hiện tại đang mượn {currentlyBorrowed} sách.");
                    return false;
                }

                return true;
            }
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            if (lblUserId.Text == "")
            {
                MessageBox.Show("Vui lòng chọn mã độc giả");
            }
            else if (TempLoanDGV.Rows.Count == 0)
            {
                MessageBox.Show("Không thể xuất phiếu mượn nếu không có sách trong danh sách.");
            }
            else if (lblUserId.Text != "" && TempLoanDGV.Rows.Count != 0)
            {
                int userId = int.Parse(lblUserId.Text);
                int booksToBorrow = TempLoanDGV.Rows.Count;

                if (!CanBorrowMoreBooks(userId, booksToBorrow))
                {
                    return; // Ko được phép mượn thêm
                }
                try
                {
                    using (var context = new LibraryManagmentGroup8DataContext())
                    {
                        if (UpdateStockAndCheckQuantity(context))
                        {
                            var newLoan = new LoanTbl
                            {
                                NOFBooks = int.Parse(lblCountB.Text),
                                UserId = int.Parse(lblUserId.Text),
                                LoanStatus = "Chưa hoàn tất",
                            };
                            context.LoanTbls.InsertOnSubmit(newLoan);
                            context.SubmitChanges();
                            loanId = newLoan.LoanId;
                            uuserId = newLoan.UserId;
                            countB = newLoan.NOFBooks;
                            foreach (DataGridViewRow row in TempLoanDGV.Rows)
                            {
                                int bId = Convert.ToInt32(row.Cells["Column2"].Value);
                                string bName = row.Cells["Column3"].Value.ToString();
                                string bAuthor = row.Cells["Column4"].Value.ToString();

                                string bNoted = row.Cells["Column5"].Value.ToString();

                                var newLoanDetail = new LoanDetailTbl
                                {
                                    LoanId = newLoan.LoanId,
                                    BId = bId,
                                    BName = bName,
                                    BAuthor = bAuthor,
                                    LoanBStatus = "Đang mượn",
                                    BNotedBefore = bNoted,
                                    LoanDate = DateTime.Now.Date,
                                    DueDate = DateTime.Today.AddDays(14),
                                    ReturnDate = DateTime.Today.AddDays(14),
                                    BForfeit = 0,
                                };
                                context.LoanDetailTbls.InsertOnSubmit(newLoanDetail);
                                context.SubmitChanges();
                            }
                            PrintLoanBooks obj = new PrintLoanBooks();
                            MessageBox.Show("Xuất phiếu mượn thành công !");
                            obj.ShowDialog();
                            lblUserId.Text = "";
                            TempLoanDGV.Rows.Clear();
                            lblCountB.Text = "0";
                            LoadBooks();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
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
            this.Hide();
        }

        private void SearchUsersTb_TextChanged(object sender, EventArgs e)
        {
            SearchUsers();
        }

        private void SearchBooksTb_TextChanged(object sender, EventArgs e)
        {
            SearchBooks();
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
