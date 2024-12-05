using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementGroup8
{
    public partial class ucBooks : UserControl
    {
        public event EventHandler BUpdated; 
        public event EventHandler onSelect = null;
        public ucBooks()
        {
            InitializeComponent();
            lblAuthor.Visible = false;
            lblGenre.Visible = false;
            lblQty.Visible = false;
            lblStatus.Visible = false;
            ShowPDetail();
        }
        private void ShowPDetail()
        {
            PanelUcProducts.Click += UcProducts_Click;
            //pbImage.Click += UcProducts_Click;
            //lblName.Click += UcProducts_Click;
            //lblAuthor.Click += UcProducts_Click;
            //lblGenre.Click += UcProducts_Click;
        }

        // Gọi sự kiện này khi bất cứ chỗ nào dc ấn vào
        private void UcProducts_Click(object sender, EventArgs e)
        {
            if (BStatus == "Khả dụng")
            {
                BooksDetail bookDetailForm = new BooksDetail(BId);
                bookDetailForm.ShowDialog();
            }
            else
            {
                BooksDetail bookDetailForm = new BooksDetail(BId);
                bookDetailForm.ReturnBtn.Visible = true;
                bookDetailForm.ShowDialog();
            }

            onSelect?.Invoke(this, EventArgs.Empty); // Gọi sự kiện onSelect để thông báo cho form cha
            BUpdated?.Invoke(this, EventArgs.Empty); //Gọi sự kiện sau khi thoát form
        }

        public int BId {
            get { return int.Parse(lblBId.Text); }
            set { lblBId.Text = value.ToString(); }
        }
        public string BAuthor
        {
            get { return lblAuthor.Text; }
            set { lblAuthor.Text = value; }
        }
        public int BQty
        {
            get { return int.Parse(lblQty.Text); }
            set { lblQty.Text = value.ToString(); }
        }
        public string BGenre
        {
            get { return lblGenre.Text; }
            set { lblGenre.Text = value; }
        }
        public string BName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }
        public string BStatus
        {
            get { return lblStatus.Text; }
            set { lblStatus.Text = value; }
        }
        public Image BImage
        {
            get { return pbImage.Image; }
            set { pbImage.Image = value; }
        }

        private void pbImage_Click(object sender, EventArgs e)
        {

        }

        //private void OpenBookDetail()
        //{
            //BooksDetail bookDetailForm = new BooksDetail(BId);
            //bookDetailForm.ShowDialog();

        //}

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
