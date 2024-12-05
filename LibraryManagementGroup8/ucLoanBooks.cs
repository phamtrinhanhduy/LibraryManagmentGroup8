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
    public partial class ucLoanBooks : UserControl
    {
        public event EventHandler onSelect = null;
        public event EventHandler LUpdated;
        public ucLoanBooks()
        {
            InitializeComponent();
            lblLoanStatus.Visible = false;
            lblPayBack.Visible = false;
            lblReturnDate.Visible = false;
            ShowDetail();
        }
        private void ShowDetail()
        {
            panel1.Click += UcLoanBooks_Click;
            label6.Click += UcLoanBooks_Click;
            pictureBox15.Click += UcLoanBooks_Click;
            label5.Click += UcLoanBooks_Click;
            lblBForfeit.Click += UcLoanBooks_Click;
            lblLoanStatus.Click += UcLoanBooks_Click;
            label4.Click += UcLoanBooks_Click;
            lblUserId.Click += UcLoanBooks_Click;
            lblLoanId.Click += UcLoanBooks_Click;
            lblLoanDate.Click += UcLoanBooks_Click;
            lblDueDate.Click += UcLoanBooks_Click;
            lblReturnDate.Click += UcLoanBooks_Click;
            label2.Click += UcLoanBooks_Click;
            label1.Click += UcLoanBooks_Click;
            label3.Click += UcLoanBooks_Click;
            lblPayBack.Click += UcLoanBooks_Click;
        }
        private void UcLoanBooks_Click(object sender, EventArgs e)
        {
            LoanDetail detailForm = new LoanDetail(LoanId);
            detailForm.ShowDialog();
            onSelect?.Invoke(this, EventArgs.Empty);
            LUpdated?.Invoke(this, EventArgs.Empty); //Gọi sự kiện sau khi thoát form
        }
        public int UserId
        {
            get { return int.Parse(lblUserId.Text); }
            set { lblUserId.Text = value.ToString(); }
        }
        public int LoanId
        {
            get { return int.Parse(lblLoanId.Text); }
            set { lblLoanId.Text = value.ToString(); }
        }
        public string LoanDate
        {
            get { return lblLoanDate.Text; }
            set { lblLoanDate.Text = value; }
        }
        public string DueDate
        {
            get { return lblDueDate.Text; }
            set { lblDueDate.Text = value; }
        }
        public string ReturnDate
        {
            get { return lblReturnDate.Text; }
            set { lblReturnDate.Text = value; }
        }
        public string LoanStatus
        {
            get { return lblLoanStatus.Text; }
            set { lblLoanStatus.Text = value; }
        }
        public int BForfeit
        {
            get { return int.Parse(lblBForfeit.Text); }
            set { lblBForfeit.Text = value.ToString(); }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
