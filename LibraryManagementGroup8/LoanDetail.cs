using Guna.UI2.WinForms;
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
    public partial class LoanDetail : Form
    {
        private int _loanId;
        static public int loanIdDetail;
        static public int userId;
        static public int countB;
        static public string loanDate;
        static public string returnDate;
        static public int loanUpdated = 0;

        public LoanDetail(int loanId)
        {
            InitializeComponent();
            _loanId = loanId;
            LoadLoanDetail();
            LoadLoanBooks();
            loanIdDetail = loanId;
            userId = int.Parse(lblUserId.Text);
            loanDate = lblLoanDate.Text;
            returnDate = DateTime.Now.ToString("dd/MM/yyyy");
            countB = int.Parse(lblBCount.Text);
            UserAccess();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadLoanDetail()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var loan = context.LoanTbls.FirstOrDefault(u => u.LoanId == _loanId);
                if (loan != null)
                {
                    var detail = context.LoanDetailTbls.FirstOrDefault(ud => ud.LoanId == loan.LoanId);
                    lblBCount.Text = loan.NOFBooks.ToString();
                    lblUserId.Text = loan.UserId.ToString();
                    lblLoanId.Text = loan.LoanId.ToString();
                    lblTotalBForfeit.Text = loan.TotalBForfeit.ToString();
                    if (detail != null)
                    {
                        lblDueDate.Text = detail.DueDate.ToString("dd/MM/yyyy");
                        lblLoanDate.Text = detail.LoanDate.ToString("dd/MM/yyyy");
                    }
                }
            }
        }
        private void LoadLoanBooks()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var bs = from b in context.LoanDetailTbls
                         where b.LoanId == _loanId
                         select new
                         {
                             LoanDetailId = b.LoanDetailId,
                             BId = b.BId,
                             BName = b.BName,
                             BForfeit = b.BForfeit,
                             BNotedBefore = b.BNotedBefore,
                             BNotedAfter = b.BNotedAfter,
                             LoanBStatus = b.LoanBStatus
                         };

                var bList = bs.ToList();
                LoanBooksDGV.Rows.Clear();

                foreach (var b in bList)
                {
                    int rowIndex = LoanBooksDGV.Rows.Add();
                    DataGridViewRow row = LoanBooksDGV.Rows[rowIndex];
                    row.Cells["Column9"].Value = b.LoanDetailId;
                    row.Cells["Column1"].Value = b.BId;
                    row.Cells["Column2"].Value = b.BName;
                    row.Cells["Column3"].Value = b.BForfeit;
                    row.Cells["Column4"].Value = b.BNotedBefore;
                    row.Cells["Column5"].Value = b.BNotedAfter;
                    row.Cells["Column8"].Value = b.LoanBStatus;
                }
            }
        }

        private void LoanBooksDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string collname = LoanBooksDGV.Columns[e.ColumnIndex].Name;
            int loanDetailId = Convert.ToInt32(LoanBooksDGV.Rows[e.RowIndex].Cells["Column9"].Value);
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var loanDetail = context.LoanDetailTbls.FirstOrDefault(b => b.LoanDetailId == loanDetailId);
                if (loanDetail != null)
                {
                    if (collname == "Column6")
                    {
                        if (Login.userType == "Khách" || Login.userType == "Giảng viên" || Login.userType == "Sinh viên")
                        {
                            MessageBox.Show("Bạn không có quyền sử dụng !");
                            return;
                        }
                        Noted obj = new Noted();
                        obj.ShowDialog();
                        loanDetail.BNotedAfter = obj.NotedTb.Text;
                    }
                    else if (collname == "Column7")
                    {
                        if (Login.userType == "Khách" || Login.userType == "Giảng viên" || Login.userType == "Sinh viên")
                        {
                            MessageBox.Show("Bạn không có quyền sử dụng !");
                            return;
                        }
                        loanDetail.LoanBStatus = "Đã trả";
                        loanDetail.ReturnDate = DateTime.Now;
                        var book = context.BookTbls.FirstOrDefault(b => b.BId == loanDetail.BId);
                        if (book != null)
                        {
                            book.BQuanlity += 1; // Tăng số lượng sách lại trong thư viện, tang 1 vi luc cho vao phieu muon la cho vao tung cuon một
                        }
                        MessageBox.Show("Trả sách tương ứng thành công !");
                        loanUpdated++;
                    }
                    context.SubmitChanges();
                    LoadLoanBooks();
                }
            }
        }
        private void UserAccess()
        {
            if (Login.userType == "Khách" || Login.userType == "Giảng viên" || Login.userType == "Sinh viên")
            {
                this.Size = new Size(565, 505);
                SaveButton.Visible = false;
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            loanUpdated++;
            try
            {
                using (var context = new LibraryManagmentGroup8DataContext())
                {
                    var loan = context.LoanTbls.FirstOrDefault(u => u.LoanId == _loanId);
                    if (loan != null)
                    {
                        var details = context.LoanDetailTbls.Where(ud => ud.LoanId == loan.LoanId).ToList();
                        loan.LoanStatus = "Hoàn tất";

                        foreach (var detail in details)
                        {
                            if (detail.LoanBStatus != "Đã trả")
                            {
                                detail.LoanBStatus = "Đã trả";
                                detail.ReturnDate = DateTime.Now;

                                var book = context.BookTbls.FirstOrDefault(b => b.BId == detail.BId);
                                if (book != null)
                                {
                                    book.BQuanlity += 1;
                                }
                            }
                        }
                    }
                    context.SubmitChanges();
                    MessageBox.Show("In phiếu trả thành công !");
                    this.Close();
                    PrintReturnBooks obj = new PrintReturnBooks();
                    obj.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

    }
}
