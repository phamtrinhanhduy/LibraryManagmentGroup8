using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace LibraryManagementGroup8
{
    public partial class Books : Form
    {
        private List<int> _exportedBooksIds = new List<int>();
        private int count = 1;
        private string bookType = "Sách truyền thống";
        //private readonly LibraryManagmentGroup8DataContext db;
        public Books()
        {
            InitializeComponent();
            GetGenres();
            LoadBooks();
            UserAccess();
            //db = new LibraryManagmentGroup8DataContext();
            //db.ExecuteCommand("DELETE FROM BookTbl");
            //db.ExecuteCommand("DBCC CHECKIDENT (BookTbl, RESEED, 0)");
            //db.SubmitChanges();
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
                AddBook_Button.Visible = false;
                if ( Login.userType == "Khách")
                {
                    SwitchToEBookButton.Visible = false;
                }
            }
        }
        private void SwitchToEBookButton_Click(object sender, EventArgs e)
        {
            count++;
            if (count == 2)
            {
                SwitchToEBookButton.FillColor = Color.LimeGreen;
                bookType = "Sách điện tử"; 
                GetGenres();
                Clear();
                LoadBooks();
            }
            else if (count == 3)
            {
                count = 1;
                SwitchToEBookButton.FillColor = Color.Red;
                bookType = "Sách truyền thống";
                GetGenres();
                Clear();
                LoadBooks();
            }
        }
        //private void AddBook(int id, string name, Image bimage, string genre, string author)
        //{
            //var b = new ucBooks
            //{
                //BName = name,
                //BAuthor = author,
                //BGenre = genre,
                //BImage = bimage,
                //BId = id,
            //};
            //flowLayoutPanel1.Controls.Add(b);
        //}

        public void LoadBooks()
        {
            GenreCb.StartIndex = 0;
            _exportedBooksIds.Clear(); 
            flowLayoutPanel1.Controls.Clear(); 

            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var books = from book in context.BookTbls
                            where !_exportedBooksIds.Contains(book.BId) && book.BType == bookType
                            select new
                            {
                                book.BId,
                                book.BName,
                                BImage = book.BImage,
                                book.BGenre,
                                book.BAuthor,
                                book.BQuanlity,
                                book.BStatus
                            };

                if (!books.Any())
                {
                    return;
                }

                foreach (var book in books)
                {
                    byte[] imageArray = book.BImage.ToArray();
                    Image bookImage = Image.FromStream(new MemoryStream(imageArray));

                    AddToLoanCard(book.BId, book.BName, bookImage, book.BGenre, book.BAuthor, book.BQuanlity, book.BStatus);

                    _exportedBooksIds.Add(book.BId);
                }

                //Co UserAccess nua nen ko con sai
                //var userDetail = context.UserDetailTbls.FirstOrDefault(ud => ud.UserId == Login.userId);
                //if (userDetail != null)
                //{
                    //Username.Text = userDetail.UserName;

                    //if (userDetail.UserPfp != null)
                    //{
                        //using (var ms = new MemoryStream(userDetail.UserPfp.ToArray()))
                        //{
                            //UserImage.Image = Image.FromStream(ms);
                        //}
                    //}
                //}
            }
        }

        private void AddToLoanCard(int id, string name, Image bimage, string genre, string author, int qty, string status)
        {
            var lb = new ucBooks
            {
                BName = name,
                BAuthor = author,
                BGenre = genre,
                BImage = bimage,
                BId = id,
                BQty = qty,
                BStatus = status
            };
            //Cap nhat sach sau khi click chi tiet sach (sau khi update, hide sach)
            lb.BUpdated += (s, e) =>
            {
                if (BooksDetail.cUpdated == 1)
                {
                    LoadBooks();
                    BooksDetail.cUpdated = 0;
                }
            };
            //Neu so luong bang 0 thi vien xám
            if (qty == 0)
            {
                lb.BackColor = Color.FromArgb(100,100,100);
            }
            //Neu trang thai an thi nen xám nhạt hơn
            if (status == "Không khả dụng")
            {
                lb.PanelUcProducts.FillColor = Color.FromArgb(130,130,130);
                lb.lblName.ForeColor = Color.White;
                if (Login.userType == "Khách" || Login.userType == "Giảng viên" || Login.userType == "Sinh viên")
                {
                    lb.Visible = false;
                }
            }
            flowLayoutPanel1.Controls.Add(lb);
        }


        private void UserInfo_Click(object sender, EventArgs e)
        {
            UserInfo Obj = new UserInfo();
            Obj.Show();
            this.Hide();
        }

        private void AddBook_Button_Click(object sender, EventArgs e)
        {
            AddNewBooks Obj = new AddNewBooks();
            Obj.ShowDialog();
            if (AddNewBooks.addUpdated == 1)
            {
                LoadBooks();
                AddNewBooks.addUpdated = 0;
                GetType();
            }
        }

        private void Clear()
        {
            SearchTb.Clear();
            AuthorTb.Clear();
            IdTb.Clear();
            GenreCb.StartIndex = 0;
            GenreCb.ForeColor = Color.FromArgb(193, 200, 207);
        }

        private void GetGenres()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var genres = context.BookTbls
                                    .Where(b => b.BType == bookType)
                                    .Select(b => b.BGenre)
                                    .Distinct()
                                    .ToList();
               genres.Insert(0, "Chọn thể loại");
               GenreCb.DataSource = genres;
            }
            GenreCb.StartIndex = 0;
            GenreCb.ForeColor = Color.FromArgb(193, 200, 207);
        }
        private void SearchBooks()
        {
            string nameSearchTerm = SearchTb.Text.Trim().ToLower();
            string authorSearchTerm = AuthorTb.Text.Trim().ToLower();
            string genreSearchTerm = GenreCb.SelectedValue?.ToString().ToLower();
            string idSearch = IdTb.Text.Trim();

            foreach (ucBooks book in flowLayoutPanel1.Controls)
            {
                bool matchesName = string.IsNullOrEmpty(nameSearchTerm) || book.BName.ToLower().Contains(nameSearchTerm);
                bool matchesAuthor = string.IsNullOrEmpty(authorSearchTerm) || book.BAuthor.ToLower().Contains(authorSearchTerm);
                bool matchesGenre = genreSearchTerm == "chọn thể loại" || string.IsNullOrEmpty(genreSearchTerm) || book.BGenre.ToLower().Contains(genreSearchTerm);
                bool matchesId = string.IsNullOrEmpty(idSearch) || book.BId.ToString().Contains(idSearch);

                book.Visible = matchesName && matchesAuthor && matchesGenre && matchesId;
            }
        }
        private void AuthorTb_TextChanged(object sender, EventArgs e)
        {
            SearchBooks();
        }

        private void GenreCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenreCb.ForeColor = Color.FromArgb(75, 50, 80);
            if (GenreCb.SelectedItem == "Chọn thể loại")
            {
                GenreCb.ForeColor = Color.FromArgb(193, 200, 207);
                SearchBooks();
            }
            SearchBooks();
        }

        private void SearchTb_TextChanged_1(object sender, EventArgs e)
        {
            SearchBooks();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void IdTb_TextChanged(object sender, EventArgs e)
        {
            SearchBooks();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Homes obj = new Homes();
            obj.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
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

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            SearchTb.Clear();
            AuthorTb.Clear();
            IdTb.Clear();
            GenreCb.StartIndex = 0;
            SearchBooks();
            GenreCb.ForeColor = Color.FromArgb(193, 200, 207);
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
    }
}
