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

namespace quanlycafe
{
    public partial class AdminForm : Form
    {
        private MForm mainForm;
        private BindingSource bs_Account = new BindingSource();
        private SqlServer sql = new SqlServer();

        public AdminForm(MForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
			loadDateTimePicker();
			loadCbLoai();
			loadGrvMenu();
			loadGrvTable();
            loadGrvAccount();
			addBinding();
		}

        #region methods
        private void loadCbLoai()
        {
            using (SqlConnection connect = new SqlConnection(sql.Server))
            {
                try
                {
                    connect.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.Loai", connect);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    cbTypeFood.DataSource = data;
                    cbTypeFood.DisplayMember = "Ten";
                    cbTypeFood.ValueMember = "id";
					SqlDataAdapter adapter1 = new SqlDataAdapter("SELECT * FROM dbo.Loai WHERE id != 110", connect);
					DataTable data1 = new DataTable();
					adapter1.Fill(data1);
					cbTypeFoodInfo.DataSource = data1;
					cbTypeFoodInfo.DisplayMember = "Ten";
					cbTypeFoodInfo.ValueMember = "id";
				}
                catch (Exception)
                {
                    MessageBox.Show("Lỗi load cbLoai");
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void loadDateTimePicker()
        {
            dtPBegin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtPEnd.Value = dtPBegin.Value.AddMonths(1).AddDays(-1);
        }

		private void loadGrvMenu()
		{
            mainForm.BS_foodMenu.RemoveFilter();
            grvMenu.DataSource = mainForm.BS_foodMenu;
            mainForm.BS_foodMenu.Sort = "Tên Món";
		}

		private void loadGrvTable()
		{
            grvTable.DataSource = mainForm.BL_tableList;
            grvTable.Columns["TableID"].Visible = false;
		}

        private void loadGrvAccount()
        {
            using(SqlConnection connect=new SqlConnection(sql.Server))
            {
                try
                {
                    connect.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT TK AS [Tên đăng nhập],MK AS [Mật khẩu],FullName AS [Tên người dùng],TruyCap AS [Quyền truy cập] FROM dbo.account", connect);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    bs_Account.DataSource = data;
                    grvAccount.DataSource = bs_Account;
                    grvAccount.Columns["Mật khẩu"].Visible = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi loadGrvAccount");
                }
                finally
                {
                    connect.Close();
                }
            }
        }

		private void addBinding()
		{
            txtTen.DataBindings.Add(new Binding("Text", grvMenu.DataSource, "Tên Món", true, DataSourceUpdateMode.Never));
            txtDVT.DataBindings.Add(new Binding("Text", grvMenu.DataSource, "Đơn vị tính", true, DataSourceUpdateMode.Never));
            txtPrice.DataBindings.Add(new Binding("Text", grvMenu.DataSource, "Đơn Giá", true, DataSourceUpdateMode.Never));
            cbTypeFoodInfo.DataBindings.Add(new Binding("Text", grvMenu.DataSource, "Loại", true, DataSourceUpdateMode.Never));
            //---------------------------------------------
            txtUserName.DataBindings.Add(new Binding("Text", grvAccount.DataSource, "Tên đăng nhập", true, DataSourceUpdateMode.Never));
            txtPassword.DataBindings.Add(new Binding("Text", grvAccount.DataSource, "Mật khẩu", true, DataSourceUpdateMode.Never));
            txtFullName.DataBindings.Add(new Binding("Text", grvAccount.DataSource, "Tên người dùng", true, DataSourceUpdateMode.Never));
            cbAccountType.DataBindings.Add(new Binding("Text", grvAccount.DataSource, "Quyền truy cập", true, DataSourceUpdateMode.Never));
        }

        private void clearTextbox(Control control)
		{
			foreach (TextBox tb in control.Controls.OfType<TextBox>())
			{
                tb.Clear();
			}
		}
        #endregion



        #region events
        private void btnThongke_Click(object sender, EventArgs e)
        {
            using(SqlConnection connect=new SqlConnection(sql.Server))
            {
                try
                {
                    connect.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT id AS [ID],(SELECT FORMAT(NgayXuat,'HH:mm:ss dd/MM/yyyy')) AS [Ngày xuất],TenBan AS [Tên Bàn],GiamGia AS [Giảm giá],ThanhTien AS [Thành tiền] FROM dbo.HoaDon WHERE (SELECT FORMAT(NgayXuat,'yyyyMMdd')) <= '" + dtPEnd.Value.ToString("yyyyMMdd") + "' AND (SELECT FORMAT(NgayXuat,'yyyyMMdd')) >= '" + dtPBegin.Value.ToString("yyyyMMdd") + "'", connect);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    grvHoaDon.DataSource = data;
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi thống kê");
                }
                finally
                {
                    connect.Close();
                }
            }
        }

		private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKeyword.Clear();
			if (cbTypeFood.SelectedIndex == 0)
			{
                mainForm.BS_foodMenu.RemoveFilter();
			}
			else
			{
                mainForm.BS_foodMenu.Filter = "[Loại] = '" + cbTypeFood.Text + "'";
			}
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
			if (cbTypeFood.SelectedIndex == 0)
			{
                mainForm.BS_foodMenu.Filter = "[Tên Món] LIKE '" + txtKeyword.Text + "%'";
			}
			else
			{
                mainForm.BS_foodMenu.Filter = "[Loại] = '" + cbTypeFood.Text + "' AND [Tên Món] LIKE '" + txtKeyword.Text + "%'";
			}
        }

		private void btnAdd_Click(object sender, EventArgs e)
		{
			using (SqlConnection connect = new SqlConnection(sql.Server))
			{
				try
				{
					connect.Open();
					SqlCommand command = new SqlCommand("INSERT dbo.thucdon (Ten,DVT,DonGia,idLoai) VALUES(N'" + txtTen.Text + "', N'" + txtDVT.Text + "', " + txtPrice.Text + "," + cbTypeFoodInfo.SelectedValue.ToString() + ")", connect);
					command.ExecuteNonQuery();
					DataTable data = mainForm.BS_foodMenu.DataSource as DataTable;
					DataRow row = data.NewRow();
					row["Tên Món"] = txtTen.Text;
					row["Đơn vị tính"] = txtDVT.Text;
					row["Đơn Giá"] = txtPrice.Text;
					row["Loại"] = cbTypeFoodInfo.Text;
					data.Rows.Add(row);
				}
				catch (Exception)
				{
					MessageBox.Show("Lỗi thêm món");
				}
				finally
				{
					connect.Close();
				}
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			using (SqlConnection connect = new SqlConnection(sql.Server))
			{
				try
				{
					connect.Open();
					SqlCommand command = new SqlCommand("UPDATE dbo.thucdon SET Ten=N'" + txtTen.Text + "',DVT=N'" + txtDVT.Text + "',DonGia=" + txtPrice.Text + ",idLoai=" + cbTypeFoodInfo.SelectedValue.ToString() + " WHERE Ten=N'" + grvMenu.SelectedRows[0].Cells["Tên Món"].Value.ToString() + "'", connect);
					command.ExecuteNonQuery();
                    DataRowView row = mainForm.BS_foodMenu.Current as DataRowView;
                    row["Tên Món"] = txtTen.Text;
                    row["Đơn vị tính"] = txtDVT.Text;
                    row["Đơn Giá"] = txtPrice.Text;
                    row["Loại"] = cbTypeFoodInfo.Text;
                    row.EndEdit();
                }
				catch (Exception)
				{
					MessageBox.Show("Lỗi Update Món");
				}
				finally
				{
					connect.Close();
				}
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			using (SqlConnection connect = new SqlConnection(sql.Server))
			{
				try
				{
					connect.Open();
					SqlCommand command = new SqlCommand("DELETE dbo.thucdon WHERE Ten=N'" + grvMenu.SelectedRows[0].Cells["Tên Món"].Value.ToString() + "'", connect);
					command.ExecuteNonQuery();
					mainForm.BS_foodMenu.RemoveCurrent();
				}
				catch (Exception)
				{
					MessageBox.Show("Lỗi delete món");
				}
				finally
				{
					connect.Close();
				}
			}
		}

		private void btnClear0_Click(object sender, EventArgs e)
		{
			foreach (Control c in this.pnFoodInfo.Controls)
			{
				clearTextbox(c);
			}
            cbTypeFoodInfo.SelectedIndex = -1;
		}

        private void grvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(sql.Server))
            {
                try
                {
                    connect.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT TenMon AS [Tên Món],SoLuong AS [Số Lượng],DonGia AS [Đơn Giá] FROM dbo.ChiTietHoaDon WHERE idHoaDon = " + grvHoaDon.SelectedRows[0].Cells["ID"].Value.ToString(), connect);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    BillInfoForm billInfoForm = new BillInfoForm();
                    billInfoForm.GrvBillInfo.DataSource = data;
                    billInfoForm.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi hiển thị chi tiết hóa đơn");
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(sql.Server))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand("INSERT dbo.BanAn(idBan,TenBan) VALUES(" + mainForm.BL_tableList.Count + ",N'Bàn '+CAST(" + (mainForm.BL_tableList.Count + 1) + " AS NVARCHAR(10)))", connect);
                    command.ExecuteNonQuery();
                    mainForm.BL_tableList.Add(new Table(mainForm.BL_tableList.Count, "Bàn " + (mainForm.BL_tableList.Count + 1)));
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi thêm bàn");
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(sql.Server))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand("DELETE BanAn WHERE idBan = " + (mainForm.BL_tableList.Count - 1), connect);
                    command.ExecuteNonQuery();
                    mainForm.BL_tableList.RemoveAt(mainForm.BL_tableList.Count - 1);
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi xóa bàn");
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.CbTypeFood.SelectedIndex = -1;
            mainForm.CbTypeFood.SelectedIndex = 0;
            mainForm.loadFlpTable();
        }

        private void btnClear1_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.pnAccountInfo.Controls)
            {
                clearTextbox(c);
            }
            cbAccountType.SelectedIndex = -1;
        }

        private void btnAddAc_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(sql.Server))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand("INSERT dbo.account(TK,MK,FullName,TruyCap) VALUES('" + txtUserName.Text + "','" + txtPassword.Text + "',N'" + txtFullName.Text + "'," + cbAccountType.Text + ")", connect);
                    command.ExecuteNonQuery();
                    DataRow row = (bs_Account.DataSource as DataTable).NewRow();
                    row["Tên đăng nhập"] = txtUserName.Text;
                    row["Mật khẩu"] = txtPassword.Text;
                    row["Tên người dùng"] = txtFullName.Text;
                    row["Quyền truy cập"] = cbAccountType.Text;
                    (bs_Account.DataSource as DataTable).Rows.Add(row);
                }
                catch (Exception)
                {
                    MessageBox.Show("Kiểm tra lại thông tin!");
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void btnUpdateAc_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(sql.Server))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand("UPDATE dbo.account SET TK = '" + txtUserName.Text + "',MK = '" + txtPassword.Text + "',FullName = N'" + txtFullName.Text + "',TruyCap = " + cbAccountType.Text + " WHERE TK = '" + grvAccount.SelectedRows[0].Cells["Tên đăng nhập"].Value.ToString() + "'", connect);
                    command.ExecuteNonQuery();
                    DataRowView row = bs_Account.Current as DataRowView;
                    row["Tên đăng nhập"] = txtUserName.Text;
                    row["Mật khẩu"] = txtPassword.Text;
                    row["Tên người dùng"] = txtFullName.Text;
                    row["Quyền truy cập"] = cbAccountType.Text;
                    row.EndEdit();
                }
                catch (Exception)
                {
                    MessageBox.Show("Kiểm tra lại thông tin!");
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void btnDeleteAc_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(sql.Server))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand("DELETE dbo.account WHERE TK = '" + grvAccount.SelectedRows[0].Cells["Tên đăng nhập"].Value.ToString() + "'", connect);
                    command.ExecuteNonQuery();
                    bs_Account.RemoveCurrent();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa tài khoản!");
                }
                finally
                {
                    connect.Close();
                }
            }
        }
        #endregion
    }
}
