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

namespace LibraryManagementGroup8
{
    public partial class AddNewBooks : Form
    {
        static public int addUpdated = 0;
        public AddNewBooks()
        {
            InitializeComponent();
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UserImagePb.Image = new Bitmap(openFileDialog.FileName);
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (BNameTb.Text == "" || BAuthorTb.Text == "" || BYPulishedTb.Text == "" || BGenreTb.Text == "" || BQtyNUD.Value == 0 || BTypeCb.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin và số lượng phải khác 0 !!!");
            }
            else
            {
                if (BTypeCb.Text == "Sách truyền thống")
                {
                    try
                    {
                        using (var context = new LibraryManagmentGroup8DataContext())
                        {
                            var newUser = new BookTbl
                            {
                                BName = BNameTb.Text,
                                BYPublished = BYPulishedTb.Text,
                                BAuthor = BAuthorTb.Text,
                                BQuanlity = (int)BQtyNUD.Value,
                                BImage = ConvertImageToBytes(UserImagePb),
                                BType = BTypeCb.Text,
                                BGenre = BGenreTb.Text,
                                BAddDate = DateTime.Now,
                                BStatus = "Khả dụng",
                                BLink = "",
                                BLocation = BLocationTb.Text,
                            };
                            context.BookTbls.InsertOnSubmit(newUser);
                            context.SubmitChanges();
                        }
                        MessageBox.Show("Thêm sách thành công !!!");
                        ++addUpdated;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else//Nếu là sách điện tử
                {
                    if (BLinkTb.Text == "")
                    {
                        MessageBox.Show("Đường dãn không được để trống !!!");
                    }
                    else
                    {
                        try
                        {
                            using (var context = new LibraryManagmentGroup8DataContext())
                            {
                                var newUser = new BookTbl
                                {
                                    BName = BNameTb.Text,
                                    BYPublished = BYPulishedTb.Text,
                                    BAuthor = BAuthorTb.Text,
                                    BQuanlity = 1,
                                    BImage = ConvertImageToBytes(UserImagePb),
                                    BType = BTypeCb.Text,
                                    BLink = BLinkTb.Text,
                                    BGenre = BGenreTb.Text,
                                    BAddDate = DateTime.Now,
                                    BStatus = "Khả dụng",
                                    BLocation = "",
                                };
                                context.BookTbls.InsertOnSubmit(newUser);
                                context.SubmitChanges();
                            }
                            MessageBox.Show("Thêm sách thành công !!!");
                            ++addUpdated;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTypeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BTypeCb.SelectedItem.ToString() == "Sách điện tử")
            {
                BLinkTb.Visible = true;
                label8.Visible = true;
                BQtyNUD.Value = 1;
                BQtyNUD.Enabled = false;
                BQtyNUD.FillColor = Color.FromArgb(224, 224, 224);
                label9.Visible = false;
                BLocationTb.Visible = false;
            }
            else if (BTypeCb.SelectedItem.ToString() == "Sách truyền thống")
            {
                BLinkTb.Visible = false;
                label8.Visible = false;
                BQtyNUD.Enabled = true;
                BQtyNUD.Value = 0;
                BQtyNUD.FillColor = Color.White;
                label9.Visible = true;
                BLocationTb.Visible = true;
            }
        }
    }
}
