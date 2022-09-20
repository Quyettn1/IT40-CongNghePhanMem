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
    public partial class Form_quanly : Form
    {
        public Form_quanly()
        {
            InitializeComponent();
        }
        #region khai báo & hàm con
        string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\IT59_TranNgocQuyet\WindowsFormsApp1\WindowsFormsApp1\Database\Database1.mdf;Integrated Security=True;Connect Timeout=30";
        DataTable tb_nv = new DataTable();
        DataTable tb_hd = new DataTable();
        DataTable tb_sp = new DataTable();
        DataTable tb_ncc = new DataTable();
        DataTable tb_pn = new DataTable();
        DataTable tb_px = new DataTable();
        DataTable tb_pbh = new DataTable();
        
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
        bool check_timPN(string x)
        {
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("select maphieu from phieunhap where maphieu ='" +
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
        #endregion
        private void bt_quanlykhachhang_Click(object sender, EventArgs e)
        {
            #region view
            gb_quanly_nhanvien.Left = 12;
            gb_quanly_nhanvien.Top = 12;
            gb_quanly_nhanvien.Enabled = true;

            // an group box:
            gb_quanly_hoadon.Left = 1200;
            gb_quanly_hoadon.Top = 1200;
            gb_quanly_hoadon.Enabled = false;
            gb_quanly_sanpham.Left = 1200;
            gb_quanly_sanpham.Top = 1200;
            gb_quanly_sanpham.Enabled = false;
            gb_quanly_ncc.Left = 1200;
            gb_quanly_ncc.Top = 1200;
            gb_quanly_ncc.Enabled = false;
            gb_quanly_phieunhap.Left = 1200;
            gb_quanly_phieunhap.Top = 1200;
            gb_quanly_phieunhap.Enabled = false;
            gb_quanly_phieubh.Top = 1200;
            gb_quanly_phieubh.Left = 1200;
            gb_quanly_phieubh.Enabled = false;
            gb_quanly_thongke.Top = 1200;
            gb_quanly_thongke.Left = 1200;
            gb_quanly_thongke.Enabled = false;
            gb_quanly_phieuxuat.Top = 1200;
            gb_quanly_phieuxuat.Left = 1200;
            gb_quanly_phieuxuat.Enabled = false;
            #endregion
        }

        private void bt_quanlyhoadon_Click(object sender, EventArgs e)
        {
            #region View
            gb_quanly_hoadon.Left = 12;
            gb_quanly_hoadon.Top = 12;
            gb_quanly_hoadon.Enabled = true;

            // an group box:
            gb_quanly_nhanvien.Left = 1200;
            gb_quanly_nhanvien.Top = 1200;
            gb_quanly_nhanvien.Enabled = false;
            gb_quanly_sanpham.Left = 1200;
            gb_quanly_sanpham.Top = 1200;
            gb_quanly_sanpham.Enabled = false;
            gb_quanly_ncc.Left = 1200;
            gb_quanly_ncc.Top = 1200;
            gb_quanly_ncc.Enabled = false;
            gb_quanly_phieunhap.Left = 1200;
            gb_quanly_phieunhap.Top = 1200;
            gb_quanly_phieunhap.Enabled = false;
            gb_quanly_phieubh.Top = 1200;
            gb_quanly_phieubh.Left = 1200;
            gb_quanly_phieubh.Enabled = false;
            gb_quanly_thongke.Top = 1200;
            gb_quanly_thongke.Left = 1200;
            gb_quanly_thongke.Enabled = false;
            gb_quanly_phieuxuat.Top = 1200;
            gb_quanly_phieuxuat.Left = 1200;
            gb_quanly_phieuxuat.Enabled = false;
            #endregion
        }

        private void bt_sanpham_Click(object sender, EventArgs e)
        {
            #region View
            gb_quanly_sanpham.Left = 12;
            gb_quanly_sanpham.Top = 12;
            gb_quanly_sanpham.Enabled = true;

            // an group box:
            gb_quanly_nhanvien.Left = 1200;
            gb_quanly_nhanvien.Top = 1200;
            gb_quanly_nhanvien.Enabled = false;
            gb_quanly_hoadon.Left = 1200;
            gb_quanly_hoadon.Top = 1200;
            gb_quanly_hoadon.Enabled = false;
            gb_quanly_ncc.Left = 1200;
            gb_quanly_ncc.Top = 1200;
            gb_quanly_ncc.Enabled = false;
            gb_quanly_phieunhap.Left = 1200;
            gb_quanly_phieunhap.Top = 1200;
            gb_quanly_phieunhap.Enabled = false;
            gb_quanly_phieubh.Top = 1200;
            gb_quanly_phieubh.Left = 1200;
            gb_quanly_phieubh.Enabled = false;
            gb_quanly_thongke.Top = 1200;
            gb_quanly_thongke.Left = 1200;
            gb_quanly_thongke.Enabled = false;
            gb_quanly_phieuxuat.Top = 1200;
            gb_quanly_phieuxuat.Left = 1200;
            gb_quanly_phieuxuat.Enabled = false;
            #endregion
        }

        private void bt_ncc_Click(object sender, EventArgs e)
        {
            #region View
            gb_quanly_ncc.Left = 12;
            gb_quanly_ncc.Top = 12;
            gb_quanly_ncc.Enabled = true;

            // an group box:
            gb_quanly_nhanvien.Left = 1200;
            gb_quanly_nhanvien.Top = 1200;
            gb_quanly_nhanvien.Enabled = false;
            gb_quanly_hoadon.Left = 1200;
            gb_quanly_hoadon.Top = 1200;
            gb_quanly_hoadon.Enabled = false;
            gb_quanly_sanpham.Left = 1200;
            gb_quanly_sanpham.Top = 1200;
            gb_quanly_sanpham.Enabled = false;
            gb_quanly_phieunhap.Left = 1200;
            gb_quanly_phieunhap.Top = 1200;
            gb_quanly_phieunhap.Enabled = false;
            gb_quanly_phieubh.Top = 1200;
            gb_quanly_phieubh.Left = 1200;
            gb_quanly_phieubh.Enabled = false;
            gb_quanly_thongke.Top = 1200;
            gb_quanly_thongke.Left = 1200;
            gb_quanly_thongke.Enabled = false;
            gb_quanly_phieuxuat.Top = 1200;
            gb_quanly_phieuxuat.Left = 1200;
            gb_quanly_phieuxuat.Enabled = false;
            #endregion
        }

        private void bt_phieunhap_Click(object sender, EventArgs e)
        {
            #region View
            gb_quanly_phieunhap.Left = 12;
            gb_quanly_phieunhap.Top = 12;
            gb_quanly_phieunhap.Enabled = true;

            // an group box:
            gb_quanly_nhanvien.Left = 1200;
            gb_quanly_nhanvien.Top = 1200;
            gb_quanly_nhanvien.Enabled = false;
            gb_quanly_hoadon.Left = 1200;
            gb_quanly_hoadon.Top = 1200;
            gb_quanly_hoadon.Enabled = false;
            gb_quanly_sanpham.Left = 1200;
            gb_quanly_sanpham.Top = 1200;
            gb_quanly_sanpham.Enabled = false;
            gb_quanly_ncc.Left = 1200;
            gb_quanly_ncc.Top = 1200;
            gb_quanly_ncc.Enabled = false;
            gb_quanly_phieubh.Top = 1200;
            gb_quanly_phieubh.Left = 1200;
            gb_quanly_phieubh.Enabled = false;
            gb_quanly_thongke.Top = 1200;
            gb_quanly_thongke.Left = 1200;
            gb_quanly_thongke.Enabled = false;
            gb_quanly_phieuxuat.Top = 1200;
            gb_quanly_phieuxuat.Left = 1200;
            gb_quanly_phieuxuat.Enabled = false;
            #endregion
        }

        private void bt_phieubh_Click(object sender, EventArgs e)
        {
            #region View
            gb_quanly_phieubh.Top = 12;
            gb_quanly_phieubh.Left = 12;
            gb_quanly_phieubh.Enabled = true;

            // an group box:
            gb_quanly_nhanvien.Left = 1200;
            gb_quanly_nhanvien.Top = 1200;
            gb_quanly_nhanvien.Enabled = false;
            gb_quanly_hoadon.Left = 1200;
            gb_quanly_hoadon.Top = 1200;
            gb_quanly_hoadon.Enabled = false;
            gb_quanly_sanpham.Left = 1200;
            gb_quanly_sanpham.Top = 1200;
            gb_quanly_sanpham.Enabled = false;
            gb_quanly_ncc.Left = 1200;
            gb_quanly_ncc.Top = 1200;
            gb_quanly_ncc.Enabled = false;
            gb_quanly_phieunhap.Top = 1200;
            gb_quanly_phieunhap.Left = 1200;
            gb_quanly_phieunhap.Enabled = false;
            gb_quanly_thongke.Top = 1200;
            gb_quanly_thongke.Left = 1200;
            gb_quanly_thongke.Enabled = false;
            gb_quanly_phieuxuat.Top = 1200;
            gb_quanly_phieuxuat.Left = 1200;
            gb_quanly_phieuxuat.Enabled = false;
            #endregion
        }

        private void bt_thongke_Click(object sender, EventArgs e)
        {
            #region View
            gb_quanly_thongke.Top = 12;
            gb_quanly_thongke.Left = 12;
            gb_quanly_thongke.Enabled = true;

            // an group box:
            gb_quanly_nhanvien.Left = 1200;
            gb_quanly_nhanvien.Top = 1200;
            gb_quanly_nhanvien.Enabled = false;
            gb_quanly_hoadon.Left = 1200;
            gb_quanly_hoadon.Top = 1200;
            gb_quanly_hoadon.Enabled = false;
            gb_quanly_sanpham.Left = 1200;
            gb_quanly_sanpham.Top = 1200;
            gb_quanly_sanpham.Enabled = false;
            gb_quanly_ncc.Left = 1200;
            gb_quanly_ncc.Top = 1200;
            gb_quanly_ncc.Enabled = false;
            gb_quanly_phieunhap.Top = 1200;
            gb_quanly_phieunhap.Left = 1200;
            gb_quanly_phieunhap.Enabled = false;
            gb_quanly_phieubh.Top = 1200;
            gb_quanly_phieubh.Left = 1200;
            gb_quanly_phieubh.Enabled = false;
            gb_quanly_phieuxuat.Top = 1200;
            gb_quanly_phieuxuat.Left = 1200;
            gb_quanly_phieuxuat.Enabled = false;
            #endregion
        }

        private void bt_phieuxuat_Click(object sender, EventArgs e)
        {
            #region View
            gb_quanly_phieuxuat.Top = 12;
            gb_quanly_phieuxuat.Left = 12;
            gb_quanly_phieuxuat.Enabled = true;

            // an group box:
            gb_quanly_nhanvien.Left = 1200;
            gb_quanly_nhanvien.Top = 1200;
            gb_quanly_nhanvien.Enabled = false;
            gb_quanly_hoadon.Left = 1200;
            gb_quanly_hoadon.Top = 1200;
            gb_quanly_hoadon.Enabled = false;
            gb_quanly_sanpham.Left = 1200;
            gb_quanly_sanpham.Top = 1200;
            gb_quanly_sanpham.Enabled = false;
            gb_quanly_ncc.Left = 1200;
            gb_quanly_ncc.Top = 1200;
            gb_quanly_ncc.Enabled = false;
            gb_quanly_phieunhap.Top = 1200;
            gb_quanly_phieunhap.Left = 1200;
            gb_quanly_phieunhap.Enabled = false;
            gb_quanly_phieubh.Top = 1200;
            gb_quanly_phieubh.Left = 1200;
            gb_quanly_phieubh.Enabled = false;
            gb_quanly_thongke.Top = 1200;
            gb_quanly_thongke.Left = 1200;
            gb_quanly_thongke.Enabled = false;
            #endregion

        }

        private void bt_timkiem_Click(object sender, EventArgs e)
        {
            string text = "select * from nhanvien ";
            #region checkdata find
            int and = 0;
            if(tbmnv.Text.Trim().Length >0)
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
                    using(SqlCommand cmd = new SqlCommand(text, cnn))
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

        private void button2_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if(tbmnv.Text.Trim()=="" || tbtnv.Text.Trim() == "" || tbcv.Text.Trim() == ""
                || tbgt.Text.Trim() == "" || tbsdt.Text.Trim() == "" || tbqq.Text.Trim() == ""
                || tbdtt.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            // Check kiểu dữ liệu:
            if(check_number(tbtnv.Text) || check_char(tbdtt.Text) || check_char(tbsdt.Text))
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    " Tên nhân viên không được chứa số, SĐT và Điểm thành tích không được chứa kí tự,...");
                return;
            }                    
            if (check_timNV(tbmnv.Text) )                          
            {                                            
                MessageBox.Show("Mã nhân viên đã tồn tại");                            
                return;                   
            }             
           
            // INSERT:
            string text = "insert into nhanvien values('"+tbmnv.Text+"','"+tbtnv.Text+"','"+
                tbcv.Text+"','"+tbgt.Text+"','"+tbsdt.Text+"','"+tbqq.Text+"',"+tbdtt.Text+")";
            
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
                            MessageBox.Show("Lỗi thêm nhân viên!");                        
                    }
                    cnn.Close();
                }                    
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

        private void button3_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbmnv.Text.Trim() == "" || tbtnv.Text.Trim() == "" || tbcv.Text.Trim() == ""
                || tbgt.Text.Trim() == "" || tbsdt.Text.Trim() == "" || tbqq.Text.Trim() == ""
                || tbdtt.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            // Check kiểu dữ liệu:
            if (check_number(tbtnv.Text) || check_char(tbdtt.Text) || check_char(tbsdt.Text))
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    " Tên nhân viên không được chứa số, SĐT và Điểm thành tích không được chứa kí tự,...");
                return;
            }
            // Check Mã nhân viên đã tồn tại chưa:
            if(!check_timNV(tbmnv.Text))
            {
                MessageBox.Show("Mã nhân viên chưa tồn tại");
                return;
            }
            // UPDATE:
            string text = "update nhanvien set tennhanvien ='" + tbtnv.Text +
                "', chucvu='" + tbcv.Text + "', gioitinh='" + tbgt.Text +
                 "', sodienthoai='" + tbsdt.Text + "', quequan='" + tbqq.Text +
                  "', diemthanhtich=" + tbdtt.Text +
                " where manhanvien ='" + tbmnv.Text + "'";

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
                            MessageBox.Show("Lỗi sửa nhân viên!");
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("Lỗi sửa nhân viên!");
                }
            }
        }
    
        
        // Xoassssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
        private void button4_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbmnv.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập Mã nhân viên!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá nhân viên " 
                + tbmnv.Text, "cảnh báo!", MessageBoxButtons.YesNo) == DialogResult.No)
                return;            
            // Check Mã nhân viên đã tồn tại chưa:
            if (!check_timNV(tbmnv.Text))
            {
                MessageBox.Show("Mã nhân viên không tồn tại");
                return;
            }
            // DELETE:
            string text = "delete nhanvien where manhanvien ='" + tbmnv.Text + "'";
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
                        MessageBox.Show("Lỗi Xoá nhân viên!");
                }
                cnn.Close();
            }
        }       

        //Tim kiemmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        private void button9_Click_1(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            tbhdmhd.Text = "";
            tbhdnl.Text = "";
            tbhdmkh.Text = "";
            tbhdmsp.Text = "";
            tbhdmnv.Text = "";
        
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

        // sưaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        private void button7_Click(object sender, EventArgs e)
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
            check_timHD(tbhdmhd.Text);
            // UPDATE:
            string text = "update hoadon set ngaylap ='" + tbhdnl.Text.Trim() +
                "', masanpham='" + tbhdmsp.Text.Trim() + "', manhanvien='" + tbhdmnv.Text.Trim() +
                 "', makhachhang='" + tbhdmkh.Text.Trim() + "' where mahoadon ='" + tbhdmhd.Text.Trim() + "'";
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
                            MessageBox.Show("Lỗi sửa hoá đơn!");
                    }
                    cnn.Close();
                }
                catch
                {

                }
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {            
            // Check nhập đủ thông tin:
            if (tbhdmhd.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập Mã hoá đơn!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá hoá đơn " + tbmnv.Text, "cảnh báo!", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            // Check Mã hoá đơn đã tồn tại chưa:
            check_timHD(tbhdmhd.Text);
            // DELETE:
            string text = "delete hoadon where mahoadon ='" + tbhdmhd.Text + "'";
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
                        MessageBox.Show("Lỗi Xoá hoá đơn!");
                }
                cnn.Close();
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
            if (tbspgb.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and giaban ='" + tbspgb.Text.Trim() + "' ";
                else
                    text += "where giaban ='" + tbspgb.Text.Trim() + "' ";
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

        private void dataGridView_sanpham_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        // Themmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

        private void button13_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbspmsp.Text.Trim() == "" || tbsptsp.Text.Trim() == "" || tbspmt.Text.Trim() == ""
                || tbspncc.Text.Trim() == "" || tbspnn.Text.Trim() == "" || tbspgn.Text.Trim() == ""
                || tbspgb.Text.Trim() == "" || tbspgg.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            // Check kiểu dữ liệu:
            if (check_char(tbspnn.Text) || check_char(tbspgn.Text)
                || check_char(tbspgb.Text) || check_char(tbspgg.Text))
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    "Ngày lập, giá tiền không được chứa kí tự,...");
                return;
            }
            // Check Mã sản phẩm đã tồn tại chưa:                         
            if (check_timSP(tbspmsp.Text.Trim()))                   
            {                   
                MessageBox.Show("Mã sản phẩm đã tồn tại");                    
                return;                   
            }              
            
            //Check Má nhà cung cấp đã tồn tại chưa:
            if (!check_timNCC(tbspncc.Text.Trim()))
            {
                MessageBox.Show("Mã Nhà cung cấp không tồn tại");
                return;
            }

            // INSERT:
            string text = "insert into sanpham values('" + tbspmsp.Text.Trim() + "','" + tbsptsp.Text.Trim() + "','" +
                tbspmt.Text.Trim() + "','" + tbspncc.Text.Trim() + "','" + tbspnn.Text.Trim() + "'," 
                 + tbspgn.Text.Trim() + "," + tbspgb.Text.Trim() + "," + tbspgg.Text.Trim() +
                ")";
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
                        MessageBox.Show("Lỗi thêm sản phẩm!");
                }
                cnn.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbspmsp.Text.Trim() == "" || tbsptsp.Text.Trim() == "" || tbspmt.Text.Trim() == ""
                || tbspncc.Text.Trim() == "" || tbspnn.Text.Trim() == "" || tbspgn.Text.Trim() == ""
                || tbspgb.Text.Trim() == "" || tbspgg.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            // Check kiểu dữ liệu:
            if (check_char(tbspnn.Text) || check_char(tbspgn.Text)
                || check_char(tbspgb.Text) || check_char(tbspgg.Text))
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    "Ngày lập, giá tiền không được chứa kí tự,...");
                return;
            }
            // Check Mã sản phẩm đã tồn tại chưa:
            if (!check_timSP(tbspmsp.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm không tồn tại");
                return;
            }
            //Check Má nhà cung cấp đã tồn tại chưa:
            if (!check_timNCC(tbspncc.Text.Trim()))
            {
                MessageBox.Show("Mã Nhà cung cấp không tồn tại");
                return;
            }
            // UPDATE:
            string text = "update sanpham set tensanpham ='" + tbsptsp.Text.Trim() +
                "', mota='" + tbspmt.Text.Trim() + "', manhacungcap='" + tbspncc.Text.Trim() +
                 "', ngaynhap='" + tbspnn.Text.Trim() + "', gianhap=" + tbspgn.Text.Trim() +
                 ", giaban=" + tbspgb.Text.Trim() + ", giagiam='" + tbspgg.Text.Trim() +
                 "' where masanpham ='" + tbspmsp.Text.Trim() + "'";
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
                            MessageBox.Show("Lỗi sửa sản phẩm!");
                    }
                    cnn.Close();
                }
                catch
                {

                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbspmsp.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập Mã sản phẩm!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá sản phẩm " + tbspmsp.Text, "cảnh báo!", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            // Check Mã sản phẩm đã tồn tại chưa:
            if (!check_timSP(tbspmsp.Text))
            {
                MessageBox.Show("Mã sản phẩm không tồn tại");
                return;
            }
            // DELETE:
            string text = "delete sanpham where masanpham ='" + tbspmsp.Text.Trim() + "'";
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
                        MessageBox.Show("Lỗi Xoá sản phẩm!");
                }
                cnn.Close();
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

        private void button15_Click(object sender, EventArgs e)
        {
            tbnccmncc.Text = "";
            tbncctncc.Text = "";
            tbnccdc.Text = "";
            tbnccsdt.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbnccmncc.Text.Trim() == "" || tbncctncc.Text.Trim() == ""
                || tbnccdc.Text.Trim() == "" || tbnccsdt.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            // Check kiểu dữ liệu:
            if (check_char(tbnccsdt.Text))
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    "Số điện thoại không được chứa kí tự,...");
                return;
            }           

            //Check Má nhà cung cấp đã tồn tại chưa:
            if (check_timNCC(tbnccmncc.Text.Trim()))
            {
                MessageBox.Show("Mã Nhà cung cấp đã tồn tại");
                return;
            }

            // INSERT:
            string text = "insert into nhacungcap values('" + tbnccmncc.Text.Trim() + "','" +
                tbncctncc.Text.Trim() + "','" + tbnccdc.Text.Trim() + "','" +
                 tbnccsdt.Text.Trim() + "')";
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(text, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Thêm thành công " + tbnccmncc.Text);
                    else
                        MessageBox.Show("Lỗi thêm dữ liệu!");
                }
                cnn.Close();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbnccmncc.Text.Trim() == "" || tbncctncc.Text.Trim() == ""
                || tbnccdc.Text.Trim() == "" || tbnccsdt.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            // Check kiểu dữ liệu:
            if (check_char(tbnccsdt.Text))
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    "Số điện thoại không được chứa kí tự,...");
                return;
            }

            //Check Má nhà cung cấp đã tồn tại chưa:
            if (!check_timNCC(tbnccmncc.Text.Trim()))
            {
                MessageBox.Show("Mã Nhà cung cấp không tồn tại");
                return;
            }
            // UPDATE:
            string text = "update nhacungcap set tennhacungcap ='" + tbncctncc.Text.Trim() +
                "', diachi='" + tbnccdc.Text.Trim() + "', sodienthoai='" + tbnccsdt.Text.Trim() +                 
                 "' where manhacungcap ='" + tbnccmncc.Text.Trim() + "'";
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
                            MessageBox.Show("Lỗi sửa Nhà cung cấp!");
                    }
                    cnn.Close();
                }
                catch
                {

                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbnccmncc.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập Mã nhà cung cấp!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá nhà cung cấp " + tbnccmncc.Text, "cảnh báo!", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            // Check Mã ncc đã tồn tại chưa:
            if (!check_timNCC(tbnccmncc.Text))
            {
                MessageBox.Show("Mã Nhà cung cấp không tồn tại");
                return;
            }
            // DELETE:
            string text = "delete nhacungcap where manhacungcap ='" + tbnccmncc.Text + "'";
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
                        MessageBox.Show("Lỗi Xoá nhà cung cấp!");
                }
                cnn.Close();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string text = "select * from phieunhap ";
            #region checkdata find
            int and = 0;
            if (tbpnmp.Text.Trim().Length > 0)
            {
                text += "where maphieu ='" + tbpnmp.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpntp.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and tenphieu ='" + tbpntp.Text.Trim() + "' ";
                else
                    text += "where tenphieu ='" + tbpntp.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpnmncc.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and manhacungcap ='" + tbpnmncc.Text.Trim() + "' ";
                else
                    text += "where manhacungcap ='" + tbpnmncc.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpnmsp.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and masanpham ='" + tbpnmsp.Text.Trim() + "' ";
                else
                    text += "where masanpham ='" + tbpnmsp.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpnmnv.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and manhanvien ='" + tbpnmnv.Text.Trim() + "' ";
                else
                    text += "where manhanvien ='" + tbpnmnv.Text.Trim() + "' ";
                and = 1;
            }
            if (tbpnsl.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and soluong =" + tbpnsl.Text.Trim() + " ";
                else
                    text += "where soluong =" + tbpnsl.Text.Trim() + " ";
                and = 1;
            }
            if (tbpnnn.Text.Trim().Length > 0)
            {
                if (and == 1)
                    text += "and ngaynhap ='" + tbpnnn.Text.Trim() + "' ";
                else
                    text += "where ngaynhap ='" + tbpnnn.Text.Trim() + "' ";
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
                            tb_pn.Clear();
                            ad.Fill(tb_pn);
                            dataGridView_phieunhap.DataSource = tb_pn;
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

        private void dataGridView_phieunhap_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Clicks == 1)
                {
                    tbpnmp.Text = tb_pn.Rows[e.RowIndex][0].ToString();
                    tbpntp.Text = tb_pn.Rows[e.RowIndex][1].ToString();
                    tbpnmncc.Text = tb_pn.Rows[e.RowIndex][2].ToString();
                    tbpnmsp.Text = tb_pn.Rows[e.RowIndex][3].ToString();
                    tbpnmnv.Text = tb_pn.Rows[e.RowIndex][4].ToString();
                    tbpnsl.Text = tb_pn.Rows[e.RowIndex][5].ToString();
                    tbpnnn.Text = tb_pn.Rows[e.RowIndex][6].ToString();
                }
            }
            catch
            {

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tbpnmp.Text = "";
            tbpntp.Text = "";
            tbpnmncc.Text = "";
            tbpnmsp.Text = "";
            tbpnmnv.Text = "";
            tbpnsl.Text = "";
            tbpnnn.Text = "";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbpnmp.Text.Trim() == "" || tbpntp.Text.Trim() == "" || tbpnmncc.Text.Trim() == ""
                || tbpnmsp.Text.Trim() == "" || tbpnmnv.Text.Trim() == "" || tbpnsl.Text.Trim() == ""
                || tbpnnn.Text.Trim() == "" )
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            // Check kiểu dữ liệu:
            if (check_char(tbpnsl.Text) || check_char(tbpnnn.Text))
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    "Ngày lập, số lượng không được chứa kí tự,...");
                return;
            }
            // Check mã phiếu nhập đã tồn tại chưa                    
            if (check_timPN(tbpnmp.Text.Trim()))
            {
                MessageBox.Show("Mã phiếu nhập đã tồn tại");
                return;
            }

            //Check Mã nhà cung cấp, mã nhân viên, mã sản phẩm đã tồn tại chưa: 
            if (!check_timNCC(tbpnmncc.Text.Trim()))
            {
                MessageBox.Show("Mã Nhà cung cấp không tồn tại");
                return;
            }
            if (!check_timNV(tbpnmnv.Text.Trim()))
            {
                MessageBox.Show("Mã Nhân viên không tồn tại");
                return;
            }
            if (!check_timSP(tbpnmsp.Text.Trim()))
            {
                MessageBox.Show("Mã Sản phẩm không tồn tại");
                return;
            }

            // INSERT:
            string text = "insert into phieunhap values('" + tbpnmp.Text.Trim() + "','" + tbpntp.Text.Trim() + "','" +
                tbpnmncc.Text.Trim() + "','" + tbpnmsp.Text.Trim() + "','" + tbpnmnv.Text.Trim() + "',"
                 + tbpnsl.Text.Trim() + ",'" + tbpnnn.Text.Trim() +  "')";
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
                        MessageBox.Show("Lỗi thêm Phiếu nhập!");
                }
                cnn.Close();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbpnmp.Text.Trim() == "" || tbpntp.Text.Trim() == "" || tbpnmncc.Text.Trim() == ""
                || tbpnmsp.Text.Trim() == "" || tbpnmnv.Text.Trim() == "" || tbpnsl.Text.Trim() == ""
                || tbpnnn.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin!");
                return;
            }
            // Check kiểu dữ liệu:
            if (check_char(tbpnsl.Text) || check_char(tbpnnn.Text))
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    "Ngày lập, số lượng không được chứa kí tự,...");
                return;
            }
            // Check mã phiếu nhập đã tồn tại chưa                    
            if (!check_timPN(tbpnmp.Text.Trim()))
            {
                MessageBox.Show("Mã phiếu nhập không tồn tại");
                return;
            }

            //Check Mã nhà cung cấp, mã nhân viên, mã sản phẩm đã tồn tại chưa: 
            if (!check_timNCC(tbpnmncc.Text.Trim()))
            {
                MessageBox.Show("Mã Nhà cung cấp không tồn tại");
                return;
            }
            if (!check_timNV(tbpnmnv.Text.Trim()))
            {
                MessageBox.Show("Mã Nhân viên không tồn tại");
                return;
            }
            if (!check_timSP(tbpnmsp.Text.Trim()))
            {
                MessageBox.Show("Mã Sản phẩm không tồn tại");
                return;
            }
            // UPDATE:
            string text = "update phieunhap set tenphieu ='" + tbpntp.Text.Trim() +
                 "', manhacungcap='" + tbpnmncc.Text.Trim() +
                 "', masanpham='" + tbpnmsp.Text.Trim() + "', manhanvien='" + tbpnmnv.Text.Trim() +
                 "', soluong=" + tbpnsl.Text.Trim() + ", ngaynhap='" + tbpnnn.Text.Trim() +
                 "' where maphieu ='" + tbpnmp.Text.Trim() + "'";
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
                            MessageBox.Show("Lỗi sửa phiếu nhập!");
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
            if (tbpnmp.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập Mã phiếu!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá phiếu nhập " + tbpnmp.Text, "cảnh báo!", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            // Check Mã phiếu nhập đã tồn tại chưa:
            if (!check_timPN(tbpnmp.Text))
            {
                MessageBox.Show("Mã Phiếu nhập không tồn tại");
                return;
            }
            // DELETE:
            string text = "delete phieunhap where maphieu ='" + tbpnmp.Text + "'";
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
                        MessageBox.Show("Lỗi Xoá Phiếu nhập!");
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
            if (!check_timPX(tbpxmp.Text.Trim()))
            {
                MessageBox.Show("Mã phiếu xuất không tồn tại");
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

            // UPDATE:
            string text = "update phieuxuat set tenphieu ='" + tbpxtp.Text.Trim() +
                "', makhachhang='" + tbpxmkh.Text.Trim() + "', masanpham='" + tbpxmsp.Text.Trim() +
                 "', manhanvien='" + tbpxmnv.Text.Trim() + "', soluong=" + tbpxsl.Text.Trim() +
                 ", ngayxuat='" + tbpxnx.Text.Trim() +
                 "' where maphieu ='" + tbpxmp.Text.Trim() + "'";
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
                            MessageBox.Show("Sửa thành công " + tbpxmp.Text);
                        else
                            MessageBox.Show("Lỗi sửa phiếu xuất!");
                    }
                    cnn.Close();
                }
                catch
                {

                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbpxmp.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập Mã phiếu xuất!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá phiếu xuất " + tbpxmp.Text, "cảnh báo!", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            // Check Mã phiếu xuất đã tồn tại chưa:
            if (!check_timPX(tbpxmp.Text))
            {
                MessageBox.Show("Mã phiếu xuất không tồn tại");
                return;
            }
            // DELETE:
            string text = "delete phieuxuat where maphieu ='" + tbpxmp.Text + "'";
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
                        MessageBox.Show("Lỗi Xoá phiếu xuất!");
                }
                cnn.Close();
            }
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
                    text += "and sothangbaohanh =" + tbpbhstbh.Text.Trim() + " ";
                else
                    text += "where sothangbaohanh =" + tbpbhstbh.Text.Trim() + " ";
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

        private void dataGridView5_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            if (check_char(tbpbhstbh.Text) )
            {
                MessageBox.Show("Sai kiểu dữ liệu! \n" +
                    "Số tháng bảo hành không được chứa kí tự,...");
                return;
            }
            // Check mã phiếu bảo hành đã tồn tại chưa                    
            if (!check_timPBH(tbpbhmp.Text.Trim()))
            {
                MessageBox.Show("Mã phiếu boả hành chưa tồn tại");
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

            // UPDATE:
            string text = "update phieubaohanh set masanpham ='" + tbpbhmsp.Text.Trim() +
                "', manhacungcap='" + tbpbhmncc.Text.Trim() + "', sothangbaohanh=" + tbpbhstbh.Text.Trim() +
                 ", mahoadon='" + tbpbhmhd.Text.Trim() + "', manhanvien='" + tbpbhmnv.Text.Trim() +
                 "', makhachhang='" + tbpbhmkh.Text.Trim() +
                 "' where maphieu ='" + tbpbhmp.Text.Trim() + "'";
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
                            MessageBox.Show("Sửa thành công " + tbpbhmp.Text);
                        else
                            MessageBox.Show("Lỗi sửa phiếu bảo hành!");
                    }
                    cnn.Close();
                }
                catch
                {

                }
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            // Check nhập đủ thông tin:
            if (tbpbhmp.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập Mã phiếu!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá phiếu bảo hành " + tbpbhmp.Text, "cảnh báo!", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            // Check Mã phiếu bảo hành đã tồn tại chưa:
            if (!check_timPBH(tbpbhmp.Text))
            {
                MessageBox.Show("Mã Phiếu bảo hành không tồn tại");
                return;
            }
            // DELETE:
            string text = "delete phieubaohanh where maphieu ='" + tbpbhmp.Text + "'";
            using (SqlConnection cnn = new SqlConnection(connectionstring))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(text, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Xoá thành công " + tbpbhmp.Text);
                    else
                        MessageBox.Show("Lỗi Xoá Phiếu bảo hành!");
                }
                cnn.Close();
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            DataTable tb_tk = new DataTable();
            string text = "";
            if (cbdc.Text.Trim().Length > 0)
            {
                text = "SELECT TOP " + cbdc.Text.Trim() + " manhanvien,tennhanvien,chucvu," +
                    " gioitinh,sodienthoai,quequan,diemthanhtich FROM nhanvien  ORDER BY  diemthanhtich DESC ";
            }
            else return;
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
                            tb_tk.Clear();
                            ad.Fill(tb_tk);
                            dataGridView_thongke.DataSource = tb_tk;
                        }
                    }
                    cnn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi thống kê!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataTable tb_tk = new DataTable();
            string text ="SELECT manhanvien, COUNT(manhanvien) as 'soluong'" +
                " FROM hoadon Group by manhanvien order by soluong desc  ";
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
                            tb_tk.Clear();
                            ad.Fill(tb_tk);
                            dataGridView_thongke.DataSource = tb_tk;
                        }
                    }
                    cnn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi thống kê!");
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            string text = "";
            if (cbdtt.Text.Trim().Length == 2 && cbdtn.Text.Trim().Length == 4)                
                text = "select COUNT(hoadon.ngaylap) as 'So luong hoa don' , SUM(sanpham.giaban) as 'Tong tien' " +
                        "from hoadon, sanpham where hoadon.ngaylap like '__" +
                        cbdtt.Text.Trim() + cbdtn.Text.Trim()+
                        "%' and hoadon.masanpham=sanpham.masanpham";
            else if(cbdtt.Text.Trim().Length ==2)
                text = "select COUNT(hoadon.ngaylap) as 'So luong hoa don' , SUM(sanpham.giaban) as 'Tong tien' " +
                        "from hoadon, sanpham where hoadon.ngaylap like '__" +
                        cbdtt.Text.Trim() +
                        "%' and hoadon.masanpham=sanpham.masanpham";
            else if(cbdtn.Text.Trim().Length == 4)
                text = "select COUNT(hoadon.ngaylap) as 'So luong hoa don' , SUM(sanpham.giaban) as 'Tong tien' " +
                        "from hoadon, sanpham where hoadon.ngaylap like '____" +
                        cbdtn.Text.Trim() +
                        "%' and hoadon.masanpham=sanpham.masanpham";            
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
                            DataTable tb_tk = new DataTable();
                            tb_tk.Clear();
                            ad.Fill(tb_tk);
                            dataGridView_thongke.DataSource = tb_tk;
                        }
                    }
                    cnn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi thống kê!");
            }

        }

        private void button34_Click(object sender, EventArgs e)
        {
            string text = "";
            if (cbhtt.Text.Trim().Length == 2 && cbhtn.Text.Trim().Length == 4)
                text = "select phieunhap.masanpham as 'Ma san pham'" +
                    ", SUM(phieunhap.soluong) as 'Tong nhap'" +
                    ", sum(phieuxuat.soluong) as 'Tong xuat'" +
                    ", (SUM(phieunhap.soluong) - SUM(phieuxuat.soluong)) as 'So luong ton'" +
                    " from phieunhap, phieuxuat" +
                    " where phieuxuat.ngayxuat like '__" +
                    cbhtt.Text.Trim() + cbhtn.Text.Trim()+
                    "%' and phieunhap.masanpham = phieuxuat.masanpham" +
                    " group by phieunhap.masanpham";
            else if (cbhtt.Text.Trim().Length == 2)
                text = "select phieunhap.masanpham as 'Ma san pham'" +
                    ", SUM(phieunhap.soluong) as 'Tong nhap'" +
                    ", sum(phieuxuat.soluong) as 'Tong xuat'" +
                    ", (SUM(phieunhap.soluong) - SUM(phieuxuat.soluong)) as 'So luong ton'" +
                    " from phieunhap, phieuxuat" +
                    " where phieuxuat.ngayxuat like '__" +
                    cbhtt.Text.Trim() + 
                    "%' and phieunhap.masanpham = phieuxuat.masanpham" +
                    " group by phieunhap.masanpham";
            else if (cbhtn.Text.Trim().Length == 4)
                text = "select phieunhap.masanpham as 'Ma san pham'" +
                    ", SUM(phieunhap.soluong) as 'Tong nhap'" +
                    ", sum(phieuxuat.soluong) as 'Tong xuat'" +
                    ", (SUM(phieunhap.soluong) - SUM(phieuxuat.soluong)) as 'So luong ton'" +
                    " from phieunhap, phieuxuat" +
                    " where phieuxuat.ngayxuat like '____" +
                     cbhtn.Text.Trim() +
                    "%' and phieunhap.masanpham = phieuxuat.masanpham" +
                    " group by phieunhap.masanpham";
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
                            DataTable tb_tk = new DataTable();
                            tb_tk.Clear();
                            ad.Fill(tb_tk);
                            dataGridView_thongke.DataSource = tb_tk;
                        }
                    }
                    cnn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi thống kê!");
            }
        }
    }
}
