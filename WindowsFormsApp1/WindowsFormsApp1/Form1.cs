using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form_login : Form
    {
        public Form_login()
        {
            InitializeComponent();
        }        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (tb_user.Text == "quanly" && tb_pass.Text == "quanly")
            {
                Form_quanly form_ql = new Form_quanly();
                form_ql.ShowDialog();
            }
            else if (tb_user.Text == "nhanvien" && tb_pass.Text == "nhanvien")
            {
                Form_nhanvien form_nv = new Form_nhanvien();
                form_nv.ShowDialog();
            }
            else MessageBox.Show("Login unsuccessful");
        }
    }
}
