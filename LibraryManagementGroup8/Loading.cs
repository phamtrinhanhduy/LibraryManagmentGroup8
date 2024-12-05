using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace LibraryManagementGroup8
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
            timer1.Start();
        }
        int startP = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startP += 2;
            Myprogress.Value = startP;
            PercentageLbl.Text = startP + "%";
            if (Myprogress.Value == 100)
            {
                Myprogress.Value = 0;
                Login Obj = new Login();
                Obj.Show();
                this.Hide();
                timer1.Stop();
            }
        }
    }
}
