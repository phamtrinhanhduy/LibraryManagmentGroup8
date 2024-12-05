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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagementGroup8
{
    public partial class LoanBooks : Form
    {
        private List<int> _exportedIds = new List<int>();
        public LoanBooks()
        {
            InitializeComponent();
            UpdateLoanStatus();
            LoanStatusCb.Text = "Chưa hoàn tất";
            BForfeit();
            TotalBForfeit();
            LoadLoanCard();
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
        private void UpdateLoanStatus()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var loans = context.LoanTbls.ToList();
                foreach (var loan in loans)
                {
                    var loanDetails = context.LoanDetailTbls.Where(ld => ld.LoanId == loan.LoanId).ToList();

                    if (loanDetails.All(ld => ld.LoanBStatus == "Đã trả"))
                    {
                        loan.LoanStatus = "Hoàn tất";
                    }
                }
                context.SubmitChanges();
            }
        }


        private void SearchLoanBooks()
        {
            string dateSearch = SearchByDateTb.Text.Trim().ToLower();
            string userIdSearch = SearchByUserIdTb.Text.Trim();
            string loanIdSearch = SearchByLoanIdTb.Text.Trim();

            foreach (ucLoanBooks u in flowLayoutPanel1.Controls)
            {
                bool matchesDate = string.IsNullOrEmpty(dateSearch) || u.LoanDate.ToLower().Contains(dateSearch);

                bool matchesUserId = string.IsNullOrEmpty(userIdSearch) || u.UserId.ToString().Contains(userIdSearch);

                bool matchesLoanId = string.IsNullOrEmpty(loanIdSearch) || u.LoanId.ToString().Contains(loanIdSearch);

                u.Visible = matchesDate && matchesUserId && matchesLoanId;
            }
        }
        private void AddLoanCard(int loanid, int userid, string loandate, string duedate, int bforfeit, string loanstatus, string returndate)
        {
            var b = new ucLoanBooks
            {
                UserId = userid,
                LoanId = loanid,
                LoanDate = loandate,
                DueDate = duedate,
                BForfeit = bforfeit,
                ReturnDate = returndate,
                LoanStatus = loanstatus,
            };
            b.LUpdated += (s, e) =>
            {
                if (LoanDetail.loanUpdated == 1)
                {
                    LoadLoanCard();
                    LoanDetail.loanUpdated = 0;
                }
            };
            if (b.BForfeit != 0)
            {
                b.panel1.BackColor = Color.DarkRed;
            }
            if (b.LoanStatus == "Hoàn tất")
            {
                b.panel1.BackColor = Color.Green;
                b.lblPayBack.Visible = true;
                b.lblReturnDate.Visible = true;
                b.label3.Visible = false;
                b.lblBForfeit.Visible = false;
            }
            DateTime dueDateTime = DateTime.ParseExact(b.DueDate, "dd/MM/yyyy", null);
            int daysLeft = (dueDateTime - DateTime.Today).Days;
            if (daysLeft < 3 && daysLeft > 0 && b.LoanStatus != "Hoàn tất" )
            {
                b.panel1.BackColor = Color.IndianRed;
            }
            flowLayoutPanel1.Controls.Add(b);
        }
        void BForfeit()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var overdueLoans = from detail in context.LoanDetailTbls
                                   where detail.DueDate < DateTime.Now where detail.LoanBStatus != "Đã trả" //Tra roi thi ko tinh phi phat nua
                                   join loan in context.LoanTbls on detail.LoanId equals loan.LoanId
                                   join user in context.UserTbls on loan.UserId equals user.UserId
                                   select new
                                   {
                                       detail.LoanDetailId,
                                       loan.UserId,
                                       detail.DueDate,
                                       UserType = user.UserType,
                                       DaysLate = (DateTime.Now - detail.DueDate).Days
                                   };

                foreach (var overdueLoan in overdueLoans)
                {
                    int finePerDay = 0;
                    if (overdueLoan.UserType == "Khách")
                    {
                        finePerDay = 8000;
                    }
                    else if (overdueLoan.UserType == "Giảng viên")
                    {
                        finePerDay = 3000;
                    }
                    else if (overdueLoan.UserType == "Sinh viên")
                    {
                        finePerDay = 5000;
                    }

                    int totalFine = overdueLoan.DaysLate * finePerDay;

                    var loanDetailToUpdate = context.LoanDetailTbls.FirstOrDefault(d => d.LoanDetailId == overdueLoan.LoanDetailId);
                    if (loanDetailToUpdate != null)
                    {
                        loanDetailToUpdate.BForfeit = totalFine;
                    }
                }
                context.SubmitChanges();
            }
        }
        void TotalBForfeit()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var loansWithTotalBForfeit = from loan in context.LoanTbls
                                             join detail in context.LoanDetailTbls on loan.LoanId equals detail.LoanId
                                             group detail by loan.LoanId into loanGroup
                                             select new
                                             {
                                                 LoanId = loanGroup.Key,
                                                 TotalBForfeit = loanGroup.Sum(d => d.BForfeit)
                                             };

                foreach (var loan in loansWithTotalBForfeit)
                {
                    var loanToUpdate = context.LoanTbls.FirstOrDefault(l => l.LoanId == loan.LoanId);
                    if (loanToUpdate != null)
                    {
                        loanToUpdate.TotalBForfeit = loan.TotalBForfeit;
                    }
                }
                context.SubmitChanges();
            }
        }

        public void LoadLoanCard() //*
        {
            _exportedIds.Clear();
            flowLayoutPanel1.Controls.Clear();

            using (var context = new LibraryManagmentGroup8DataContext())
            {
                if (Login.userType == "Khách" || Login.userType == "Giảng viên" || Login.userType == "Sinh viên")
                {
                    var loans = from loan in context.LoanTbls
                                where !_exportedIds.Contains(loan.LoanId) && loan.LoanStatus == LoanStatusCb.Text && loan.UserId == Login.userId //Chỉ xuất ra phiếu của người đó nếu họ là độc giả
                                select new
                                {
                                    loan.LoanId,
                                    loan.LoanStatus,
                                    loan.UserId,
                                    LoanDate = context.LoanDetailTbls
                                                .Where(detail => detail.LoanId == loan.LoanId)
                                                .Min(detail => detail.LoanDate), // Ngày mượn đầu tiên
                                    DueDate = context.LoanDetailTbls
                                                .Where(detail => detail.LoanId == loan.LoanId)
                                                .Max(detail => detail.DueDate), // Ngày hết hạn
                                    ReturnDate = context.LoanDetailTbls
                                                .Where(detail => detail.LoanId == loan.LoanId)
                                                .Max(detail => detail.ReturnDate), // Ngày trả
                                    loan.TotalBForfeit
                                };
                    if (!loans.Any())
                    {
                        return;
                    }

                    foreach (var loan in loans)
                    {
                        AddLoanCard(
                            loan.LoanId,
                            loan.UserId,
                            loan.LoanDate.ToString("dd/MM/yyyy"),
                            loan.DueDate.ToString("dd/MM/yyyy"),
                            loan.TotalBForfeit,
                            loan.LoanStatus,
                            loan.ReturnDate.ToString("dd/MM/yyyy")
                        );

                        _exportedIds.Add(loan.LoanId);
                    }
                }
                else
                {
                    var loans = from loan in context.LoanTbls
                                where !_exportedIds.Contains(loan.LoanId) && loan.LoanStatus == LoanStatusCb.Text
                                select new
                                {
                                    loan.LoanId,
                                    loan.LoanStatus,
                                    loan.UserId,
                                    LoanDate = context.LoanDetailTbls
                                                .Where(detail => detail.LoanId == loan.LoanId)
                                                .Min(detail => detail.LoanDate), // Ngày mượn đầu tiên
                                    DueDate = context.LoanDetailTbls
                                                .Where(detail => detail.LoanId == loan.LoanId)
                                                .Max(detail => detail.DueDate), // Hết hạn
                                    ReturnDate = context.LoanDetailTbls
                                                .Where(detail => detail.LoanId == loan.LoanId)
                                                .Max(detail => detail.ReturnDate), // Ngày trả
                                    loan.TotalBForfeit
                                };
                    if (!loans.Any())
                    {
                        return;
                    }

                    foreach (var loan in loans)
                    {
                        AddLoanCard(
                            loan.LoanId,
                            loan.UserId,
                            loan.LoanDate.ToString("dd/MM/yyyy"),
                            loan.DueDate.ToString("dd/MM/yyyy"),
                            loan.TotalBForfeit,
                            loan.LoanStatus,
                            loan.ReturnDate.ToString("dd/MM/yyyy")
                        );

                        _exportedIds.Add(loan.LoanId);
                    }
                }
            }
        }

        private void SearchByDateTb_TextChanged(object sender, EventArgs e)
        {
            SearchLoanBooks();
        }

        private void SearchByUserIdTb_TextChanged(object sender, EventArgs e)
        {
            SearchLoanBooks();
        }

        private void SearchByLoanIdTb_TextChanged(object sender, EventArgs e)
        {
            SearchLoanBooks();
        }

        private void Refresh_Button_Click(object sender, EventArgs e)
        {
            SearchByDateTb.Clear();
            SearchByLoanIdTb.Clear();
            SearchByUserIdTb.Clear();
        }

        private void LoanStatusCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLoanCard();
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
            this.Hide();
        }

        private void Username_Click(object sender, EventArgs e)
        {
            UserInfo obj = new UserInfo();
            obj.Show();
            this.Hide();
        }
    }
}
