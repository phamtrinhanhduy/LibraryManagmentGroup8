using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementGroup8
{
    public partial class BFlipLink : Form
    {
        private int _bookId;
        public BFlipLink(int bookId)
        {
            InitializeComponent();
            _bookId = bookId;
            InitializeWebView2();
        }

        private async void InitializeWebView2()
        {
            try
            {
                using (var context = new LibraryManagmentGroup8DataContext())
                {
                    var bookToShow = context.BookTbls.FirstOrDefault(b => b.BId == _bookId);
                    await webView2.EnsureCoreWebView2Async(null);
                    webView2.CoreWebView2.Navigate(bookToShow.BLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}