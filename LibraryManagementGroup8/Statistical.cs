using LiveCharts.Wpf;
using LiveCharts;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace LibraryManagementGroup8
{
    public partial class Statistical : Form
    {
        public Statistical()
        {
            InitializeComponent();
            UserAccess();
            CountLoanBookInLib();
            CountNewBookInLib();
            CountNewUserInLib();
            CountTLoanInLib();
            LoadPieChart();
            LoadLineChart();
        }
        private void LoadPieChart()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                int currentMonth = DateTime.Now.Month;

                var productData = from od in context.LoanDetailTbls
                                  join p in context.BookTbls on od.BId equals p.BId
                                  join o in context.LoanTbls on od.LoanId equals o.LoanId
                                  where od.LoanDate.Month == currentMonth
                                  group od by p.BGenre into g
                                  select new
                                  {
                                      ProductType = g.Key,
                                      TotalQuantity = g.Count(),
                                  };

                chartByPType.Series.Clear();

                foreach (var item in productData)
                {
                    chartByPType.Series.Add(new PieSeries
                    {
                        Title = item.ProductType,
                        Values = new ChartValues<int> { item.TotalQuantity },
                        FontSize = 10,
                        DataLabels = true
                    });
                }
            }
        }
        private void LoadLineChart()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var monthlyBookCounts = context.LoanDetailTbls
                                               .GroupBy(detail => new { detail.LoanDate.Year, detail.LoanDate.Month })
                                               .Select(g => new
                                               {
                                                   Year = g.Key.Year,
                                                   Month = g.Key.Month,
                                                   BookCount = g.Count()
                                               })
                                               .OrderBy(g => g.Year).ThenBy(g => g.Month)
                                               .ToList();

                chartMonth.Series.Clear();

                chartMonth.Series.Add("BooksBorrowed");
                chartMonth.Series["BooksBorrowed"].ChartType = SeriesChartType.Column;
                chartMonth.Series["BooksBorrowed"]["PointWidth"] = "0.1";

                foreach (var item in monthlyBookCounts)
                {
                    string label = $"Tháng {item.Month}/{item.Year}";
                    chartMonth.Series["BooksBorrowed"].Points.AddXY(label, item.BookCount);
                }
            }
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
        private void CountLoanBookInLib()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var currentMonth = DateTime.Now.Month;
                var currentYear = DateTime.Now.Year;

                int totalForfeit = context.LoanDetailTbls
                                              .Where(f => f.ReturnDate.Month == currentMonth && f.ReturnDate.Year == currentYear)
                                              .Sum(f => f.BForfeit);

                TotalForfeitLbl.Text = totalForfeit.ToString();
            }
        }
        private void CountTLoanInLib()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {

                int total = context.LoanTbls
                                              .Where(f => f.LoanStatus == "Hoàn tất")
                                              .Count();

                CountLoanLbl.Text = total.ToString();
            }
            NOVLbl.Text = Properties.Settings.Default.NOV.ToString();// Display luôn số lượt truy cập vào chương trình
        }
        private void CountNewBookInLib()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var currentMonth = DateTime.Now.Month;
                var currentYear = DateTime.Now.Year;

                int newB = context.BookTbls
                                              .Where(f => f.BAddDate.Month == currentMonth && f.BAddDate.Year == currentYear)
                                              .Count();

                CountNewBLbl.Text = newB.ToString();
            }
        }
        private void CountNewUserInLib()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var currentMonth = DateTime.Now.Month;
                var currentYear = DateTime.Now.Year;

                int newU = context.UserTbls
                                              .Where(f => f.CreationDate.Month == currentMonth && f.CreationDate.Year == currentYear)
                                              .Count();

                CountNewULbl.Text = newU.ToString();
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Homes obj = new Homes();
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

        private void chartByPType_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
