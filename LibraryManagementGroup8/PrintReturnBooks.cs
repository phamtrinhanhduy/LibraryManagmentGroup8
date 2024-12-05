using Microsoft.Reporting.WinForms;
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
    public partial class PrintReturnBooks : Form
    {
        public PrintReturnBooks()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintReturnBooks_Load(object sender, EventArgs e)
        {
            LibraryManagmentGroup8DataContext dbContext = new LibraryManagmentGroup8DataContext();
            var query = from detail in dbContext.LoanDetailTbls
                        where detail.LoanId == LoanDetail.loanIdDetail
                        select new
                        {
                            detail.BId,
                            detail.BName,
                            detail.BAuthor,
                            detail.BNotedAfter,
                        };
            DataTable dt = new DataTable();
            dt.Columns.Add("BId");
            dt.Columns.Add("BName");
            dt.Columns.Add("BAuthor");
            dt.Columns.Add("BNotedAfter");
            foreach (var item in query)
            {
                dt.Rows.Add(item.BId, item.BName, item.BAuthor, item.BNotedAfter);
            }
            ReportParameter pr1 = new ReportParameter("rp1", LoanDetail.loanIdDetail.ToString());
            this.reportViewer1.LocalReport.SetParameters(pr1);
            ReportParameter pr2 = new ReportParameter("rp2", LoanDetail.userId.ToString());
            this.reportViewer1.LocalReport.SetParameters(pr2);
            ReportParameter pr3 = new ReportParameter("rp3", LoanDetail.loanDate);
            this.reportViewer1.LocalReport.SetParameters(pr3);
            ReportParameter pr4 = new ReportParameter("rp4", LoanDetail.returnDate);
            this.reportViewer1.LocalReport.SetParameters(pr4);
            ReportParameter pr5 = new ReportParameter("rp5", LoanDetail.countB.ToString());
            this.reportViewer1.LocalReport.SetParameters(pr5);
            ReportParameter pr6 = new ReportParameter("rp6", LoanDetail.countB.ToString());
            this.reportViewer1.LocalReport.SetParameters(pr6);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            reportViewer1.RefreshReport();
        }
    }
}
