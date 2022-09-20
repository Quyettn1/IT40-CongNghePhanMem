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
    public partial class Form_nhanvien : Form
    {
        public Form_nhanvien()
        {
            InitializeComponent();
        }
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\IT59_TranNgocQuyet\WindowsFormsApp1\WindowsFormsApp1\Database\Database1.mdf;Integrated Security=True;Connect Timeout=30";
        DataTable tb_nv = new DataTable();
        DataTable tb_hd = new DataTable();
        DataTable tb_sp = new DataTable();
        DataTable tb_ncc = new DataTable();
        DataTable tb_pn = new DataTable();
        DataTable tb_px = new DataTable();
        DataTable tb_pbh = new DataTable();
        DataTable tb_kh = new DataTable();
        bool check_timNV(string x)
        {
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("select manhanvien from nhanvien where manhanvien ='" +
                    x + "'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                        return true;
                }
                cnn.Close();
            }
            return false;
        }
        bool check_timNCC(string x)
        {
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("select manhacungcap" +
                    " from nhacungcap where manhacungcap ='" +
                    x + "'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                        return true;
                }
                cnn.Close();
            }
            return false;
        }
        bool check_timPBH(string x)
        {
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("select maphieu from phieubaohanh where maphieu ='" +
                    x + "'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                        return true;
                }
                cnn.Close();
            }
            return false;
        }
        bool check_timPX(string x)
        {
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("select maphieu from phieuxuat where maphieu ='" +
                    x + "'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                        return true;
                }
                cnn.Close();
            }
            return false;
        }
        bool check_timKH(string x)
        {
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("select makhachhang from khachhang where makhachhang ='" +
                    x + "'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                        return true;
                }
                cnn.Close();
            }
            return false;
        }
        bool check_timSP(string x)
        {
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("select masanpham" +
                    " from sanpham where masanpham ='" +
                    x + "'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                        return true;
                }
                cnn.Close();
            }
            return false;
        }
        bool check_timHD(string x)
        {
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("select mahoadon from hoadon where mahoadon ='" +
                    x + "'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {                        
                        return true;
                    }
                }
                cnn.Close();
            }
            return false;
        }
        bool check_number(string x)
        {
            foreach (char i in x)
            {
                // Trong chuoi x co chua so number
                if (Char.IsDigit(i))
                    return true;
            }
            return false;
        }
        bool check_char(string x)
        {
            foreach (char i in x)
            {
                // Trong chuoi x co chua ki tu char
                if (!Char.IsDigit(i))
                    return true;
            }
            return false;
        }

        private void bt_nhanvien_Click(object sender, EventArgs e)
        {
            #region view
            gb_nhanvien_nhanvien.Left = 12;
            gb_nhanvien_nhanvien.Top = 12;
            gb_nhanvien_nhanvien.Enabled = true;

            // an group box:
            gb_nhanvien_hoadon.Left = 1200;
            gb_nhanvien_hoadon.Top = 1200;
            gb_nhanvien_hoadon.Enabled = false;
            gb_nhanvien_sanpham.Left = 1200;
            gb_nhanvien_sanpham.Top = 1200;
            gb_nhanvien_sanpham.Enabled = false;
            gb_nhanvien_ncc.Left = 1200;
            gb_nhanvien_ncc.Top = 1200;
            gb_nhanvien_ncc.Enabled = false;
            gb_nhanvien_khachhang.Left = 1200;
            gb_nhanvien_khachhang.Top = 1200;
            gb_nhanvien_khachhang.Enabled = false;
            gb_nhanvien_phieubh.Top = 1200;
            gb_nhanvien_phieubh.Left = 1200;
            gb_nhanvien_phieubh.Enabled = false;            
            gb_nhanvien_phieuxuat.Top = 1200;
            gb_nhanvien_phieuxuat.Left = 1200;
            gb_nhanvien_phieuxuat.Enabled = false;
            #endregion
        }

        private void bt_hoadon_Click(object sender, EventArgs e)
        {
            #region View
            gb_nhanvien_hoadon.Left = 12;
            gb_nhanvien_hoadon.Top = 12;
            gb_nhanvien_hoadon.Enabled = true;

            // an group box:
            gb_nhanvien_nhanvien.Left = 1200;
            gb_nhanvien_nhanvien.Top = 1200;
            gb_nhanvien_nhanvien.Enabled = false;
            gb_nhanvien_sanpham.Left = 1200;
            gb_nhanvien_sanpham.Top = 1200;
            gb_nhanvien_sanpham.Enabled = false;
            gb_nhanvien_ncc.Left = 1200;
            gb_nhanvien_ncc.Top = 1200;
            gb_nhanvien_ncc.Enabled = false;
            gb_nhanvien_khachhang.Left = 1200;
            gb_nhanvien_khachhang.Top = 1200;
            gb_nhanvien_khachhang.Enabled = false;
            gb_nhanvien_phieubh.Top = 1200;
            gb_nhanvien_phieubh.Left = 1200;
            gb_nhanvien_phieubh.Enabled = false;
            gb_nhanvien_phieuxuat.Top = 1200;
            gb_nhanvien_phieuxuat.Left = 1200;
            gb_nhanvien_phieuxuat.Enabled = false;
            #endregion
        }

        private void bt_sanpham_Click(object sender, EventArgs e)
        {
            #region View
            gb_nhanvien_sanpham.Left = 12;
            gb_nhanvien_sanpham.Top = 12;
            gb_nhanvien_sanpham.Enabled = true;

            // an group box:
            gb_nhanvien_nhanvien.Left = 1200;
            gb_nhanvien_nhanvien.Top = 1200;
            gb_nhanvien_nhanvien.Enabled = false;
            gb_nhanvien_hoadon.Left = 1200;
            gb_nhanvien_hoadon.Top = 1200;
            gb_nhanvien_hoadon.Enabled = false;
            gb_nhanvien_ncc.Left = 1200;
            gb_nhanvien_ncc.Top = 1200;
            gb_nhanvien_ncc.Enabled = false;
            gb_nhanvien_khachhang.Left = 1200;
            gb_nhanvien_khachhang.Top = 1200;
            gb_nhanvien_khachhang.Enabled = false;
            gb_nhanvien_phieubh.Top = 1200;
            gb_nhanvien_phieubh.Left = 1200;
            gb_nhanvien_phieubh.Enabled = false;
            gb_nhanvien_phieuxuat.Top = 1200;
            gb_nhanvien_phieuxuat.Left = 1200;
            gb_nhanvien_phieuxuat.Enabled = false;
            #endregion
        }

        private void bt_ncc_Click(object sender, EventArgs e)
        {
            #region View
            gb_nhanvien_ncc.Left = 12;
            gb_nhanvien_ncc.Top = 12;
            gb_nhanvien_ncc.Enabled = true;

            // an group box:
            gb_nhanvien_nhanvien.Left = 1200;
            gb_nhanvien_nhanvien.Top = 1200;
            gb_nhanvien_nhanvien.Enabled = false;
            gb_nhanvien_hoadon.Left = 1200;
            gb_nhanvien_hoadon.Top = 1200;
            gb_nhanvien_hoadon.Enabled = false;
            gb_nhanvien_sanpham.Left = 1200;
            gb_nhanvien_sanpham.Top = 1200;
            gb_nhanvien_sanpham.Enabled = false;
            gb_nhanvien_khachhang.Left = 1200;
            gb_nhanvien_khachhang.Top = 1200;
            gb_nhanvien_khachhang.Enabled = false;
            gb_nhanvien_phieubh.Top = 1200;
            gb_nhanvien_phieubh.Left = 1200;
            gb_nhanvien_phieubh.Enabled = false;
            gb_nhanvien_phieuxuat.Top = 1200;
            gb_nhanvien_phieuxuat.Left = 1200;
            gb_nhanvien_phieuxuat.Enabled = false;
            #endregion
        }

        private void bt_phieunhap_Click(object sender, EventArgs e)
        {
            #region View
            gb_nhanvien_khachhang.Left = 12;
            gb_nhanvien_khachhang.Top = 12;
            gb_nhanvien_khachhang.Enabled = true;

            // an group box:
            gb_nhanvien_nhanvien.Left = 1200;
            gb_nhanvien_nhanvien.Top = 1200;
            gb_nhanvien_nhanvien.Enabled = false;
            gb_nhanvien_hoadon.Left = 1200;
            gb_nhanvien_hoadon.Top = 1200;
            gb_nhanvien_hoadon.Enabled = false;
            gb_nhanvien_sanpham.Left = 1200;
            gb_nhanvien_sanpham.Top = 1200;
            gb_nhanvien_sanpham.Enabled = false;
            gb_nhanvien_ncc.Left = 1200;
            gb_nhanvien_ncc.Top = 1200;
            gb_nhanvien_ncc.Enabled = false;
            gb_nhanvien_phieubh.Top = 1200;
            gb_nhanvien_phieubh.Left = 1200;
            gb_nhanvien_phieubh.Enabled = false;
            gb_nhanvien_phieuxuat.Top = 1200;
            gb_nhanvien_phieuxuat.Left = 1200;
            gb_nhanvien_phieuxuat.Enabled = false;
            #endregion
        }

        private void bt_phieuxuat_Click(object sender, EventArgs e)
        {
            #region View
            gb_nhanvien_phieuxuat.Left = 12;
            gb_nhanvien_phieuxuat.Top = 12;
            gb_nhanvien_phieuxuat.Enabled = true;

            // an group box:
            gb_nhanvien_nhanvien.Left = 1200;
            gb_nhanvien_nhanvien.Top = 1200;
            gb_nhanvien_nhanvien.Enabled = false;
            gb_nhanvien_hoadon.Left = 1200;
            gb_nhanvien_hoadon.Top = 1200;
            gb_nhanvien_hoadon.Enabled = false;
            gb_nhanvien_sanpham.Left = 1200;
            gb_nhanvien_sanpham.Top = 1200;
            gb_nhanvien_sanpham.Enabled = false;
            gb_nhanvien_ncc.Left = 1200;
            gb_nhanvien_ncc.Top = 1200;
            gb_nhanvien_ncc.Enabled = false;
            gb_nhanvien_phieubh.Top = 1200;
            gb_nhanvien_phieubh.Left = 1200;
            gb_nhanvien_phieubh.Enabled = false;
            gb_nhanvien_khachhang.Top = 1200;
            gb_nhanvien_khachhang.Left = 1200;
            gb_nhanvien_khachhang.Enabled = false;
            #endregion
        }

        private void bt_phieubh_Click(object sender, EventArgs e)
        {
            #region View
            gb_nhanvien_phieubh.Left = 12;
            gb_nhanvien_phieubh.Top = 12;
            gb_nhanvien_phieubh.Enabled = true;

            // an group box:
            gb_nhanvien_nhanvien.Left = 1200;
            gb_nhanvien_nhanvien.Top = 1200;
            gb_nhanvien_nhanvien.Enabled = false;
            gb_nhanvien_hoadon.Left = 1200;
            gb_nhanvien_hoadon.Top = 1200;
            gb_nhanvien_hoadon.Enabled = false;
            gb_nhanvien_sanpham.Left = 1200;
            gb_nhanvien_sanpham.Top = 1200;
            gb_nhanvien_sanpham.Enabled = false;
            gb_nhanvien_ncc.Left = 1200;
            gb_nhanvien_ncc.Top = 1200;
            gb_nhanvien_ncc.Enabled = false;
            gb_nhanvien_phieuxuat.Top = 1200;
            gb_nhanvien_phieuxuat.Left = 1200;
            gb_nhanvien_phieuxuat.Enabled = false;
            gb_nhanvien_khachhang.Top = 1200;
            gb_nhanvien_khachhang.Left = 1200;
            gb_nhanvien_khachhang.Enabled = false;
            #endregion
        }

        private void bt_timkiem_Click(object sender, EventArgs e)
        {
            string text = "select * from nhanvien ";
            #region checkdata find
            int and = 0;
            if (tbmnv.Text.Trim().Length > 0)
            {
                text += "where manhanvien ='" + tbmnv.Text.Trim() + "' ";
                and = 1;
            }
            if (tbtnv.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and tennhanvien ='" + tbtnv.Text.Trim() + "' ";
                else
                    text += "where tennhanvien ='" + tbtnv.Text.Trim() + "' ";
                and = 1;
            }
            if (tbcv.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and chucvu ='" + tbcv.Text.Trim() + "' ";
                else
                    text += "where chucvu ='" + tbcv.Text.Trim() + "' ";
                and = 1;
            }
            if (tbgt.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and gioitinh ='" + tbgt.Text.Trim() + "' ";
                else
                    text += "where gioitinh ='" + tbgt.Text.Trim() + "' ";
                and = 1;
            }
            if (tbsdt.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and sodienthoai ='" + tbsdt.Text.Trim() + "' ";
                else
                    text += "where sodienthoai ='" + tbsdt.Text.Trim() + "' ";
                and = 1;
            }
            if (tbqq.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and quequan ='" + tbqq.Text.Trim() + "' ";
                else
                    text += "where quequan ='" + tbqq.Text.Trim() + "' ";
                and = 1;
            }
            if (tbdtt.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and diemthanhtich ='" + tbdtt.Text.Trim() + "' ";
                else
                    text += "where diemthanhtich ='" + tbdtt.Text.Trim() + "' ";
                and = 1;
            }
            #endregion

            #region Tìm kiếm:
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionstring))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(text, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            tb_nv.Clear();
                            ad.Fill(tb_nv);
                            dataGridView_nhanvien.DataSource = tb_nv;
                        }
                    }
                    cnn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi tìm kiếm!");
            }
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbmnv.Text = "";
            tbtnv.Text = "";
            tbcv.Text = "";
            tbgt.Text = "";
            tbsdt.Text = "";
            tbqq.Text = "";
            tbdtt.Text = "";
        }

        private void dataGridView_nhanvien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Clicks == 1)
                {
                    tbmnv.Text = tb_nv.Rows[e.RowIndex][0].ToString();
                    tbtnv.Text = tb_nv.Rows[e.RowIndex][1].ToString();
                    tbcv.Text = tb_nv.Rows[e.RowIndex][2].ToString();
                    tbgt.Text = tb_nv.Rows[e.RowIndex][3].ToString();
                    tbsdt.Text = tb_nv.Rows[e.RowIndex][4].ToString();
                    tbqq.Text = tb_nv.Rows[e.RowIndex][5].ToString();
                    tbdtt.Text = tb_nv.Rows[e.RowIndex][6].ToString();
                }
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbhdmhd.Text = "";
            tbhdnl.Text = "";
            tbhdmsp.Text = "";
            tbhdmnv.Text = "";
            tbhdmkh.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string text = "select * from hoadon ";
            #region checkdata find
            int and = 0;
            if (tbhdmhd.Text.Trim().Length > 0)
            {
                text += "where mahoadon ='" + tbhdmhd.Text.Trim() + "' ";
                and = 1;
            }
            if (tbhdnl.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and ngaylap ='" + tbhdnl.Text.Trim() + "' ";
                else
                    text += "where ngaylap ='" + tbhdnl.Text.Trim() + "' ";
                and = 1;
            }
            if (tbhdmsp.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and masanpham ='" + tbhdmsp.Text.Trim() + "' ";
                else
                    text += "where masanpham ='" + tbhdmsp.Text.Trim() + "' ";
                and = 1;
            }
            if (tbhdmnv.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and manhanvien ='" + tbhdmnv.Text.Trim() + "' ";
                else
                    text += "where manhanvien ='" + tbhdmnv.Text.Trim() + "' ";
                and = 1;
            }
            if (tbhdmkh.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and makhachhang ='" + tbhdmkh.Text.Trim() + "' ";
                else
                    text += "where makhachhang ='" + tbhdmkh.Text.Trim() + "' ";
                and = 1;
            }

            #endregion

            #region Tìm kiếm:
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionstring))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(text, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            tb_hd.Clear();
                            ad.Fill(tb_hd);
                            dataGridView_hoadon.DataSource = tb_hd;
                        }
                    }
                    cnn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi tìm kiếm!");
            }
            #endregion
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbhdmhd.Text.Trim() == "" || tbhdnl.Text.Trim() == "" || tbhdmnv.Text.Trim() == ""
                || tbhdmsp.Text.Trim() == "" || tbhdmkh.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            // Check kiểu dữ liệu:
            if (check_char(tbhdnl.Text))
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    "Ngày lập không được chứa kí tự,...");
                return;
            }
            // Check Mã hoá đơn đã tồn tại chưa:              
            if (check_timHD(tbhdmhd.Text))                  
            {                  
                MessageBox.Show("Mã hoá đơn đã tồn tại");                   
                return;                  
            }
                
            
            //Check Mã sản phẩm , mã khách hàng, mã nhân viên, đã tồn tại chưa:
            if (check_timNV(tbhdmnv.Text.Trim()))
            {
                MessageBox.Show("Mã nhân viên không tồn tại");
                return;
            }

            // INSERT:
            string text = "insert into hoadon values('" + tbhdmhd.Text.Trim() + "','" + tbhdnl.Text.Trim() + "','" +
                tbhdmsp.Text.Trim() + "','" + tbhdmnv.Text.Trim() + "','" + tbhdmkh.Text.Trim() + "')";
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(text, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Thêm thành công " + tbmnv.Text);
                    else
                        MessageBox.Show("Lỗi thêm hoá đơn!");
                }
                cnn.Close();
            }
        }

        private void dataGridView_hoadon_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Clicks == 1)
                {
                    tbhdmhd.Text = tb_hd.Rows[e.RowIndex][0].ToString();
                    tbhdnl.Text = tb_hd.Rows[e.RowIndex][1].ToString();
                    tbhdmsp.Text = tb_hd.Rows[e.RowIndex][2].ToString();
                    tbhdmnv.Text = tb_hd.Rows[e.RowIndex][3].ToString();
                    tbhdmkh.Text = tb_hd.Rows[e.RowIndex][4].ToString();
                }
            }
            catch
            {

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string text = "select * from sanpham ";
            #region checkdata find
            int and = 0;
            if (tbspmsp.Text.Trim().Length > 0)
            {
                text += "where masanpham ='" + tbspmsp.Text.Trim() + "' ";
                and = 1;
            }
            if (tbsptsp.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and tensanpham ='" + tbsptsp.Text.Trim() + "' ";
                else
                    text += "where tensanpham ='" + tbsptsp.Text.Trim() + "' ";
                and = 1;
            }
            if (tbspmt.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and mota ='" + tbspmt.Text.Trim() + "' ";
                else
                    text += "where mota ='" + tbspmt.Text.Trim() + "' ";
                and = 1;
            }
            if (tbspncc.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and manhacungcap ='" + tbspncc.Text.Trim() + "' ";
                else
                    text += "where manhacungcap ='" + tbspncc.Text.Trim() + "' ";
                and = 1;
            }
            if (tbspnn.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and ngaynhap ='" + tbspnn.Text.Trim() + "' ";
                else
                    text += "where ngaynhap ='" + tbspnn.Text.Trim() + "' ";
                and = 1;
            }
            if (tbspgn.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and gianhap ='" + tbspgn.Text.Trim() + "' ";
                else
                    text += "where gianhap ='" + tbspgn.Text.Trim() + "' ";
                and = 1;
            }
            if (tbspgn.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and giaban ='" + tbspgn.Text.Trim() + "' ";
                else
                    text += "where giaban ='" + tbspgn.Text.Trim() + "' ";
                and = 1;
            }
            if (tbspgg.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and giagiam ='" + tbspgg.Text.Trim() + "' ";
                else
                    text += "where giagiam ='" + tbspgg.Text.Trim() + "' ";
                and = 1;
            }

            #endregion

            #region Tìm kiếm:
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionstring))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(text, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            tb_sp.Clear();
                            ad.Fill(tb_sp);
                            dataGridView_sanpham.DataSource = tb_sp;
                        }
                    }
                    cnn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi tìm kiếm!");
            }
            #endregion
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tbspmsp.Text = "";
            tbsptsp.Text = "";
            tbspmt.Text = "";
            tbspncc.Text = "";
            tbspnn.Text = "";
            tbspgn.Text = "";
            tbspgb.Text = "";
            tbspgg.Text = "";
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Clicks == 1)
                {
                    tbspmsp.Text = tb_sp.Rows[e.RowIndex][0].ToString();
                    tbsptsp.Text = tb_sp.Rows[e.RowIndex][1].ToString();
                    tbspmt.Text = tb_sp.Rows[e.RowIndex][2].ToString();
                    tbspncc.Text = tb_sp.Rows[e.RowIndex][3].ToString();
                    tbspnn.Text = tb_sp.Rows[e.RowIndex][4].ToString();
                    tbspgn.Text = tb_sp.Rows[e.RowIndex][5].ToString();
                    tbspgb.Text = tb_sp.Rows[e.RowIndex][6].ToString();
                    tbspgg.Text = tb_sp.Rows[e.RowIndex][7].ToString();
                }
            }
            catch
            {

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string text = "select * from nhacungcap ";
            #region checkdata find
            int and = 0;
            if (tbnccmncc.Text.Trim().Length > 0)
            {
                text += "where manhacungcap ='" + tbnccmncc.Text.Trim() + "' ";
                and = 1;
            }
            if (tbncctncc.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and tennhacungcap ='" + tbncctncc.Text.Trim() + "' ";
                else
                    text += "where tennhacungcap ='" + tbncctncc.Text.Trim() + "' ";
                and = 1;
            }
            if (tbnccdc.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and diachi ='" + tbnccdc.Text.Trim() + "' ";
                else
                    text += "where diachi ='" + tbnccdc.Text.Trim() + "' ";
                and = 1;
            }
            if (tbnccsdt.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and sodienthoai ='" + tbnccsdt.Text.Trim() + "' ";
                else
                    text += "where sodienthoai ='" + tbnccsdt.Text.Trim() + "' ";
                and = 1;
            }

            #endregion

            #region Tìm kiếm:
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionstring))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(text, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            tb_ncc.Clear();
                            ad.Fill(tb_ncc);
                            dataGridView_ncc.DataSource = tb_ncc;
                        }
                    }
                    cnn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi tìm kiếm!");
            }
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbnccmncc.Text = "";
            tbncctncc.Text = "";
            tbnccdc.Text = "";
            tbnccsdt.Text = "";
        }

        private void dataGridView_ncc_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Clicks == 1)
                {
                    tbnccmncc.Text = tb_ncc.Rows[e.RowIndex][0].ToString();
                    tbncctncc.Text = tb_ncc.Rows[e.RowIndex][1].ToString();
                    tbnccdc.Text = tb_ncc.Rows[e.RowIndex][2].ToString();
                    tbnccsdt.Text = tb_ncc.Rows[e.RowIndex][3].ToString();
                }
            }
            catch
            {

            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string text = "select * from khachhang ";
            #region checkdata find
            int and = 0;
            if (tbkhmkh.Text.Trim().Length > 0)
            {
                text += "where makhachhang ='" + tbkhmkh.Text.Trim() + "' ";
                and = 1;
            }
            if (tbkhtkh.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and tenkhachhang ='" + tbkhtkh.Text.Trim() + "' ";
                else
                    text += "where tenkhachhang ='" + tbkhtkh.Text.Trim() + "' ";
                and = 1;
            }
            if (tbkhsdt.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and sodienthoai ='" + tbkhsdt.Text.Trim() + "' ";
                else
                    text += "where sodienthoai ='" + tbkhsdt.Text.Trim() + "' ";
                and = 1;
            }         
            #endregion

            #region Tìm kiếm:
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionstring))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(text, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            tb_kh.Clear();
                            ad.Fill(tb_kh);
                            dataGridView_khachhang.DataSource = tb_kh;
                        }
                    }
                    cnn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi tìm kiếm!");
            }
            #endregion
        }

        private void dataGridView_khachhang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Clicks == 1)
                {
                    tbkhmkh.Text = tb_kh.Rows[e.RowIndex][0].ToString();
                    tbkhtkh.Text = tb_kh.Rows[e.RowIndex][1].ToString();
                    tbkhsdt.Text = tb_kh.Rows[e.RowIndex][2].ToString();                    
                }
            }
            catch
            {

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tbkhmkh.Text = "";
            tbkhtkh.Text = "";
            tbkhsdt.Text = "";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbkhmkh.Text.Trim() == "" || tbkhtkh.Text.Trim() == "" || tbkhsdt.Text.Trim() == "" )
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            // Check kiểu dữ liệu:
            if (check_char(tbkhsdt.Text) || check_number(tbkhtkh.Text))
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    "SĐT không được chứa kí tự, tên không được chứa số,...");
                return;
            }
            // Check mã khách hàng đã tồn tại chưa                    
            if (check_timKH(tbkhmkh.Text.Trim()))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại");
                return;
            }
            
            // INSERT:
            string text = "insert into khachhang values('" + tbkhmkh.Text.Trim() + "','" + tbkhtkh.Text.Trim() + "','" +
                tbkhsdt.Text.Trim() + "')";
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(text, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Thêm thành công " + tbmnv.Text);
                    else
                        MessageBox.Show("Lỗi thêm khách hàng!");
                }
                cnn.Close();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbkhmkh.Text.Trim() == "" || tbkhtkh.Text.Trim() == "" || tbkhsdt.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            // Check kiểu dữ liệu:
            if (check_char(tbkhsdt.Text) || check_number(tbkhtkh.Text))
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    "SĐT không được chứa kí tự, tên không được chứa số,...");
                return;
            }
            // Check mã khách hàng đã tồn tại chưa                    
            if (!check_timKH(tbkhmkh.Text.Trim()))
            {
                MessageBox.Show("Mã khách hàng không tồn tại");
                return;
            }
            // UPDATE:
            string text = "update khachhang set tenkhachhang ='" + tbkhtkh.Text.Trim() +
                 "', sodienthoai='" + tbkhsdt.Text.Trim() +                 
                 "' where makhachhang ='" + tbkhmkh.Text.Trim() + "'";
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                try
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(text, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            MessageBox.Show("Sửa thành công " + tbmnv.Text);
                        else
                            MessageBox.Show("Lỗi sửa khach hàng!");
                    }
                    cnn.Close();
                }
                catch
                {

                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbkhmkh.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập Mã khách hàng!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá khách hàng " + tbkhmkh.Text, "cảnh báo!", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            // Check Mã khách hàng đã tồn tại chưa:
            if (!check_timKH(tbkhmkh.Text))
            {
                MessageBox.Show("Mã khách hàng không tồn tại");
                return;
            }
            // DELETE:
            string text = "delete khachhang where makhachhang ='" + tbkhmkh.Text + "'";
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(text, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Xoá thành công " + tbmnv.Text);
                    else
                        MessageBox.Show("Lỗi Xoá Khách hàng!");
                }
                cnn.Close();
            }
        }

        private void dataGridView_phieuxuat_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Clicks == 1)
                {
                    tbpxmp.Text = tb_px.Rows[e.RowIndex][0].ToString();
                    tbpxtp.Text = tb_px.Rows[e.RowIndex][1].ToString();
                    tbpxmkh.Text = tb_px.Rows[e.RowIndex][2].ToString();
                    tbpxmsp.Text = tb_px.Rows[e.RowIndex][3].ToString();
                    tbpxmnv.Text = tb_px.Rows[e.RowIndex][4].ToString();
                    tbpxsl.Text = tb_px.Rows[e.RowIndex][5].ToString();
                    tbpxnx.Text = tb_px.Rows[e.RowIndex][6].ToString();
                }
            }
            catch
            {

            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            tbpxmp.Text = "";
            tbpxtp.Text = "";
            tbpxmkh.Text = "";
            tbpxmsp.Text = "";
            tbpxmnv.Text = "";
            tbpxsl.Text = "";
            tbpxnx.Text = "";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbpxmp.Text.Trim() == "" || tbpxtp.Text.Trim() == "" || tbpxmkh.Text.Trim() == ""
                || tbpxmsp.Text.Trim() == "" || tbpxmnv.Text.Trim() == "" || tbpxsl.Text.Trim() == ""
                || tbpxnx.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            // Check kiểu dữ liệu:
            if (check_char(tbpxsl.Text) || check_char(tbpxnx.Text))
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    "Ngày lập, số lượng không được chứa kí tự,...");
                return;
            }
            // Check mã phiếu xuất đã tồn tại chưa                    
            if (check_timPX(tbpxmp.Text.Trim()))
            {
                MessageBox.Show("Mã phiếu xuất đã tồn tại");
                return;
            }

            //Check Mã khách hàng, mã nhân viên, mã sản phẩm đã tồn tại chưa: 
            if (!check_timKH(tbpxmkh.Text.Trim()))
            {
                MessageBox.Show("Mã khách hàng không tồn tại");
                return;
            }
            if (!check_timNV(tbpxmnv.Text.Trim()))
            {
                MessageBox.Show("Mã Nhân viên không tồn tại");
                return;
            }
            if (!check_timSP(tbpxmsp.Text.Trim()))
            {
                MessageBox.Show("Mã Sản phẩm không tồn tại");
                return;
            }

            // INSERT:
            string text = "insert into phieuxuat values('" + tbpxmp.Text.Trim() + "','" + tbpxtp.Text.Trim() + "','" +
                tbpxmkh.Text.Trim() + "','" + tbpxmsp.Text.Trim() + "','" + tbpxmnv.Text.Trim() + "',"
                 + tbpxsl.Text.Trim() + ",'" + tbpxnx.Text.Trim() + "')";
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(text, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Thêm thành công " + tbmnv.Text);
                    else
                        MessageBox.Show("Lỗi thêm Phiếu xuất!");
                }
                cnn.Close();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            string text = "select * from phieuxuat ";
            #region checkdata find
            int and = 0;
            if (tbpxmp.Text.Trim().Length > 0)
            {
                text += "where maphieu ='" + tbpxmp.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpxtp.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and tenphieu ='" + tbpxtp.Text.Trim() + "' ";
                else
                    text += "where tenphieu ='" + tbpxtp.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpxmkh.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and makhachhang ='" + tbpxmkh.Text.Trim() + "' ";
                else
                    text += "where makhachhang ='" + tbpxmkh.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpxmsp.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and masanpham ='" + tbpxmsp.Text.Trim() + "' ";
                else
                    text += "where masanpham ='" + tbpxmsp.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpxmnv.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and manhanvien ='" + tbpxmnv.Text.Trim() + "' ";
                else
                    text += "where manhanvien ='" + tbpxmnv.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpxsl.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and soluong =" + tbpxsl.Text.Trim() + " ";
                else
                    text += "where soluong =" + tbpxsl.Text.Trim() + " ";
                and = 1;
            }
            if (tbpxnx.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += " and ngayxuat ='" + tbpxnx.Text.Trim() + "' ";
                else
                    text += " where ngayxuat ='" + tbpxnx.Text.Trim() + "' ";
                and = 1;
            }

            #endregion

            #region Tìm kiếm:
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionstring))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(text, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            tb_px.Clear();
                            ad.Fill(tb_px);
                            dataGridView_phieuxuat.DataSource = tb_px;
                        }
                    }
                    cnn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi tìm kiếm!");
            }
            #endregion
        }

        private void button33_Click(object sender, EventArgs e)
        {
            string text = "select * from phieubaohanh ";
            #region checkdata find
            int and = 0;
            if (tbpbhmp.Text.Trim().Length > 0)
            {
                text += "where maphieu ='" + tbpbhmp.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpbhmsp.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and masanpham ='" + tbpbhmsp.Text.Trim() + "' ";
                else
                    text += "where masanpham ='" + tbpbhmsp.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpbhmncc.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and manhacungcap ='" + tbpbhmncc.Text.Trim() + "' ";
                else
                    text += "where manhacungcap ='" + tbpbhmncc.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpbhstbh.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and sothangbaohanh ='" + tbpbhstbh.Text.Trim() + "' ";
                else
                    text += "where sothangbaohanh ='" + tbpbhstbh.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpbhmhd.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and mahoadon ='" + tbpbhmhd.Text.Trim() + "' ";
                else
                    text += "where mahoadon ='" + tbpbhmhd.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpbhmnv.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and manhanvien ='" + tbpbhmnv.Text.Trim() + "' ";
                else
                    text += "where manhanvien ='" + tbpbhmnv.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpbhmkh.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += " and makhachhang ='" + tbpbhmkh.Text.Trim() + "' ";
                else
                    text += " where makhachhang ='" + tbpbhmkh.Text.Trim() + "' ";
                and = 1;
            }

            #endregion

            #region Tìm kiếm:
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionstring))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(text, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            tb_pbh.Clear();
                            ad.Fill(tb_pbh);
                            dataGridView_phieubaohanh.DataSource = tb_pbh;
                        }
                    }
                    cnn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi tìm kiếm!");
            }
            #endregion
        }

        private void dataGridView_phieubaohanh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Clicks == 1)
                {
                    tbpbhmp.Text = tb_pbh.Rows[e.RowIndex][0].ToString();
                    tbpbhmsp.Text = tb_pbh.Rows[e.RowIndex][1].ToString();
                    tbpbhmncc.Text = tb_pbh.Rows[e.RowIndex][2].ToString();
                    tbpbhstbh.Text = tb_pbh.Rows[e.RowIndex][3].ToString();
                    tbpbhmhd.Text = tb_pbh.Rows[e.RowIndex][4].ToString();
                    tbpbhmnv.Text = tb_pbh.Rows[e.RowIndex][5].ToString();
                    tbpbhmkh.Text = tb_pbh.Rows[e.RowIndex][6].ToString();
                }            
            }
            catch
            {

            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            tbpbhmp.Text = "";
            tbpbhmsp.Text = "";
            tbpbhmncc.Text = "";
            tbpbhmnv.Text = "";
            tbpbhstbh.Text = "";
            tbpbhmhd.Text = "";
            tbpbhmkh.Text = "";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbpbhmp.Text.Trim() == "" || tbpbhmsp.Text.Trim() == "" || tbpbhmncc.Text.Trim() == ""
                || tbpbhstbh.Text.Trim() == "" || tbpbhmhd.Text.Trim() == "" || tbpbhmnv.Text.Trim() == ""
                || tbpbhmkh.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            // Check kiểu dữ liệu:
            if (check_char(tbpbhstbh.Text))
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    "Số tháng bảo hành không được chứa kí tự,...");
                return;
            }
            // Check mã phiếu bảo hành đã tồn tại chưa                    
            if (check_timPBH(tbpbhmp.Text.Trim()))
            {
                MessageBox.Show("Mã phiếu boả hành đã tồn tại");
                return;
            }

            //Check Mã khách hàng, mã nhân viên, mã sản phẩm đã tồn tại chưa: 
            if (!check_timKH(tbpbhmkh.Text.Trim()))
            {
                MessageBox.Show("Mã khách hàng không tồn tại");
                return;
            }
            if (!check_timNV(tbpbhmnv.Text.Trim()))
            {
                MessageBox.Show("Mã Nhân viên không tồn tại");
                return;
            }
            if (!check_timSP(tbpbhmsp.Text.Trim()))
            {
                MessageBox.Show("Mã Sản phẩm không tồn tại");
                return;
            }
            if (!check_timNCC(tbpbhmncc.Text.Trim()))
            {
                MessageBox.Show("Mã Nhà cung cấp không tồn tại");
                return;
            }

            // INSERT:
            string text = "insert into phieubaohanh values('" + tbpbhmp.Text.Trim() + "','" + tbpbhmsp.Text.Trim() + "','" +
                tbpbhmncc.Text.Trim() + "'," + tbpbhstbh.Text.Trim() + ",'" + tbpbhmhd.Text.Trim() + "','"
                 + tbpbhmnv.Text.Trim() + "','" + tbpbhmkh.Text.Trim() + "')";
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(text, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Thêm thành công " + tbpbhmp.Text);
                    else
                        MessageBox.Show("Lỗi thêm Phiếu bảo hành!");
                }
                cnn.Close();
            }
        }
    }
}
