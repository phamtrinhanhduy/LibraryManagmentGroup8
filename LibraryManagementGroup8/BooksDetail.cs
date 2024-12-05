using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagementGroup8
{
    public partial class BooksDetail : Form
    {
        private int _bookId;
        public static int cUpdated = 0; //Cap nhat lai sach neu co thay doi
        public BooksDetail(int bookId)
        {
            InitializeComponent();
            UserAccess();
            _bookId = bookId;
            LoadBookDetail();
        }
        private void UserAccess()
        {
            if (Login.userType == "Khách" || Login.userType == "Giảng viên" || Login.userType == "Sinh viên")
            {
                this.Size = new Size(723, 450);
                BLinkTb.Visible = false;
                ImageButton.Visible = false;
                BIdTb.Enabled = false;
                BNameTb.Enabled = false;
                BTypeCb.Enabled = false;
                BYPulishedTb.Enabled = false;
                BGenreTb.Enabled = false;
                BLocationTb.Enabled = false;
                BQtyNUD.Enabled = false;
                BQtyNUD.FillColor = Color.FromArgb(226, 226, 226);
                BAuthorTb.Enabled = false;
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {

        }
        private void LoadBookDetail()
        {
            using (var context = new LibraryManagmentGroup8DataContext())
            {
                var book = context.BookTbls.FirstOrDefault(b => b.BId == _bookId);
                if (book != null)
                {
                    BIdTb.Text = (book.BId).ToString();
                    BNameTb.Text = book.BName;
                    BGenreTb.Text = book.BGenre;
                    BYPulishedTb.Text = book.BYPublished;
                    BTypeCb.Text = book.BType;
                    BQtyNUD.Text = (book.BQuanlity).ToString();
                    BAuthorTb.Text = book.BAuthor;
                    BLinkTb.Text = book.BLink;
                    BLocationTb.Text = book.BLocation;
                    byte[] imageArray = book.BImage.ToArray();
                    BImagePb.Image = Image.FromStream(new MemoryStream(imageArray));
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            cUpdated++;
            try
            {
                using (var context = new LibraryManagmentGroup8DataContext())
                {
                    var bookToHide = context.BookTbls.FirstOrDefault(b => b.BId == _bookId);
                    if (bookToHide != null)
                    {
                        bookToHide.BStatus = "Không khả dụng";
                        context.SubmitChanges();
                        MessageBox.Show("Sách không còn khả dụng !!!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sách không tồn tại !!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (BNameTb.Text == "" || BAuthorTb.Text == "" || BYPulishedTb.Text == "" || BGenreTb.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !!!");
            }
            else
            {

                if (BTypeCb.Text == "Sách điện tử")
                {
                    if (BLinkTb.Text == "")
                    {
                        MessageBox.Show("Vui lòng điền đường dẫn sách điện tử !!!");
                    }
                    else
                    {
                        cUpdated++;
                        try
                        {
                            using (var context = new LibraryManagmentGroup8DataContext())
                            {
                                var bookToUpdate = context.BookTbls.FirstOrDefault(b => b.BId == _bookId);

                                if (bookToUpdate != null)
                                {
                                    bookToUpdate.BName = BNameTb.Text;
                                    bookToUpdate.BAuthor = BAuthorTb.Text;
                                    bookToUpdate.BQuanlity = 1;
                                    bookToUpdate.BYPublished = BYPulishedTb.Text;
                                    bookToUpdate.BGenre = BGenreTb.Text;
                                    bookToUpdate.BImage = ConvertImageToBytes(BImagePb);
                                    bookToUpdate.BType = "Sách điện tử";
                                    bookToUpdate.BLink = BLinkTb.Text;
                                    bookToUpdate.BLocation = "";
                                    context.SubmitChanges();
                                    MessageBox.Show("Thông tin sách đã được cập nhật");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Sách không tồn tại");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
                else if (BTypeCb.Text == "Sách truyền thống")
                {
                    if (BLocationTb.Text == "")
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin !!!");
                        return;
                    }
                    cUpdated++;
                    try
                    {
                        using (var context = new LibraryManagmentGroup8DataContext())
                        {
                            var bookToUpdate = context.BookTbls.FirstOrDefault(b => b.BId == _bookId);

                            if (bookToUpdate != null)
                            {
                                bookToUpdate.BName = BNameTb.Text;
                                bookToUpdate.BAuthor = BAuthorTb.Text;
                                bookToUpdate.BQuanlity = int.Parse(BQtyNUD.Text);
                                bookToUpdate.BYPublished = BYPulishedTb.Text;
                                bookToUpdate.BGenre = BGenreTb.Text;
                                bookToUpdate.BImage = ConvertImageToBytes(BImagePb);
                                bookToUpdate.BType = "Sách truyền thống";
                                bookToUpdate.BLink = "";
                                bookToUpdate.BLocation = BLocationTb.Text;
                                context.SubmitChanges();
                                MessageBox.Show("Thông tin sách đã được cập nhật");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Sách không tồn tại");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private byte[] ConvertImageToBytes(PictureBox pictureBox)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        private void ImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                BImagePb.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void BTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BTypeCb.SelectedItem.ToString() == "Sách điện tử")
            {
                if (Login.userType == "Khách" || Login.userType == "Giảng viên" || Login.userType == "Sinh viên")
                {
                    BLinkTb.Visible = false;
                }
                else
                {
                    BLinkTb.Visible = true;

                }
                using (var context = new LibraryManagmentGroup8DataContext())
                {
                    var book = context.BookTbls.FirstOrDefault(b => b.BId == _bookId);
                    if (book != null)
                    {
                        BQtyNUD.Text = (book.BQuanlity).ToString();
                        BLinkTb.Text = book.BLink;
                        BLocationTb.Text = book.BLocation;
                    }
                }
                label6.Visible = false;
                BQtyNUD.Visible = false;
                lblLocation.Visible = false;
                BLocationTb.Visible = false;
                BLocationTb.Text = "";
                BQtyNUD.Value = 1;
            }
            else if (BTypeCb.SelectedItem.ToString() == "Sách truyền thống")
            {
                using (var context = new LibraryManagmentGroup8DataContext())
                {
                    var book = context.BookTbls.FirstOrDefault(b => b.BId == _bookId);
                    if (book != null)
                    {
                        BQtyNUD.Text = (book.BQuanlity).ToString();
                        BLinkTb.Text = book.BLink;
                        BLocationTb.Text = book.BLocation;
                    }
                }
                BLinkTb.Visible = false;
                ReadNowBtn.Visible = false;
                label6.Visible = true;
                BQtyNUD.Visible = true;
                BLinkTb.Text = "";
                BLocationTb.Visible = true;
                lblLocation.Visible = true;
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            BFlipLink obj = new BFlipLink(_bookId);
            obj.ShowDialog();
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            cUpdated++;
            try
            {
                using (var context = new LibraryManagmentGroup8DataContext())
                {
                    var bookToHide = context.BookTbls.FirstOrDefault(b => b.BId == _bookId);
                    if (bookToHide != null)
                    {
                        bookToHide.BStatus = "Khả dụng";
                        context.SubmitChanges();
                        MessageBox.Show("Sách khôi phục thành công !!!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sách không tồn tại !!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
