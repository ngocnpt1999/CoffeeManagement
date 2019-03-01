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
    public partial class MForm : Form
    {
        private User userData;
        private SqlServer sql = new SqlServer();
        private BindingSource bs_foodMenu = new BindingSource();
        private BindingList<Table> bl_tableList = new BindingList<Table>();

        internal User UserData { get => userData; set => userData = value; }
        internal BindingList<Table> BL_tableList { get => bl_tableList; set => bl_tableList = value; }
        public BindingSource BS_foodMenu { get => bs_foodMenu; set => bs_foodMenu = value; }
        public ComboBox CbTypeFood => cbTypeFood;

        public MForm()
        {
            InitializeComponent();
			loadLivMenu();
            loadTableList();
            loadCbTypeFood();
        }

        #region methods
        private void loadLivMenu()
		{
			using(SqlConnection connect=new SqlConnection(sql.Server))
			{
				try
				{
					connect.Open();
					SqlDataAdapter adapter = new SqlDataAdapter("SELECT thucdon.Ten AS [Tên Món],DVT AS [Đơn vị tính],DonGia AS [Đơn Giá],Loai.Ten AS [Loại] FROM dbo.thucdon JOIN dbo.Loai ON Loai.id = thucdon.idLoai", connect);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
					foreach(DataRow row in data.Rows)
					{
						ListViewItem item = new ListViewItem();
						item.Text = row["Tên Món"].ToString();
						item.SubItems.Add(row["Đơn vị tính"].ToString());
						item.SubItems.Add(row["Đơn Giá"].ToString());
						livMenu.Items.Add(item);
					}
                    bs_foodMenu.DataSource = data;
				}
				catch (Exception)
				{
					MessageBox.Show("Lỗi loadLivMenu");
				}
				finally
				{
					connect.Close();
				}
			}
		}

		private void loadTableList()
        {
            using (SqlConnection connect = new SqlConnection(sql.Server))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.BanAn", connect);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        bl_tableList.Add(new Table(Convert.ToInt32(reader["idBan"]), reader["TenBan"].ToString()));
                    }
                    loadFlpTable();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi load tableList");
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        public void loadFlpTable()
        {
            flpTable.Controls.Clear();
            foreach(Table table in bl_tableList)
            {
                Button button = new Button();
                button.Text = table.TableName;
                button.Tag = table.TableID;
                button.Width = 70;
                button.Height = 70;
                if (table.TableOrder.Length == 0)
                {
                    button.BackColor = Color.LightGreen;
                }
                else
                {
                    button.BackColor = Color.LightPink;
                }
                button.Click += new EventHandler(btnTable_Click);
                flpTable.Controls.Add(button);
            }
        }

        private void loadCbTypeFood()
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

        private void resetOrder()
        {
            livOrder.Items.Clear();
            bl_tableList[Convert.ToInt32(lbTableName.Tag)].TableOrder = new ListViewItem[0];
			numUDDiscount.Value = 0;
            lbThanhtien.Text = "0";
            loadFlpTable();
        }

        private void loadLbThanhtien()
        {
            double price = 0;
            for (int i = 0; i < livOrder.Items.Count; i++)
            {
                price += (Convert.ToDouble(livOrder.Items[i].SubItems[2].Text) * Convert.ToInt32(livOrder.Items[i].SubItems[3].Text));
            }
            price = price * (double)((100 - numUDDiscount.Value) / 100);
            lbThanhtien.Text = price + "";
        }

        private void saveTableOrder(Table table)
        {
            ListViewItem[] items = new ListViewItem[livOrder.Items.Count];
            for (int i = 0; i < livOrder.Items.Count; i++)
            {
                items[i] = livOrder.Items[i];
            }
            table.TableOrder = items;
        }
        #endregion



        #region events
        private void btnTable_Click(object sender, EventArgs e)
        {
            lbTableName.Text = (sender as Button).Text;
            lbTableName.Tag = (sender as Button).Tag;
            livOrder.Items.Clear();
            if (bl_tableList[Convert.ToInt32(lbTableName.Tag)].TableOrder != null)
            {
                livOrder.Items.AddRange(bl_tableList[Convert.ToInt32(lbTableName.Tag)].TableOrder);
            }
            loadLbThanhtien();
        }

        private void MForm_Load(object sender, EventArgs e)
        {
            smenuAdmin.Enabled = (userData.Truycap == 1 ? true : false);
        }

        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            livMenu.Items.Clear();
			if (cbTypeFood.SelectedIndex == 0)
			{
				foreach (DataRow row in ((DataTable)bs_foodMenu.DataSource).Rows)
				{
					ListViewItem item = new ListViewItem();
					item.Text = row["Tên Món"].ToString();
					item.SubItems.Add(row["Đơn vị tính"].ToString());
					item.SubItems.Add(row["Đơn Giá"].ToString());
					livMenu.Items.Add(item);
				}
			}
			else
			{
                DataRow[] rows = ((DataTable)bs_foodMenu.DataSource).Select("[Loại] = '" + cbTypeFood.Text + "'");
				foreach(DataRow row in rows)
				{
					ListViewItem item = new ListViewItem();
					item.Text = row["Tên Món"].ToString();
					item.SubItems.Add(row["Đơn vị tính"].ToString());
					item.SubItems.Add(row["Đơn Giá"].ToString());
					livMenu.Items.Add(item);
				}
			}
        }

        private void livMenu_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = livMenu.SelectedItems[0].Clone() as ListViewItem;
            item.SubItems.Add("1");
            bool cayCo = true;
            for (int i = 0; i < livOrder.Items.Count; i++)
            {
                if (item.Text == livOrder.Items[i].Text)
                {
                    livOrder.Items[i].SubItems[3].Text = (Convert.ToInt32(livOrder.Items[i].SubItems[3].Text) + 1) + "";
                    cayCo = false;
                    break;
                }
            }
            if (cayCo == true)
            {
                livOrder.Items.Add(item);
            }
            saveTableOrder(bl_tableList[Convert.ToInt32(lbTableName.Tag)]);
            loadLbThanhtien();
            loadFlpTable();
        }        

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetOrder();
        }

        private void livOrder_DoubleClick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(livOrder.SelectedItems[0].SubItems[3].Text) > 1)
            {
                livOrder.SelectedItems[0].SubItems[3].Text = (Convert.ToInt32(livOrder.SelectedItems[0].SubItems[3].Text) - 1) + "";
            }
            else
            {
                livOrder.SelectedItems[0].Remove();
            }
            saveTableOrder(bl_tableList[Convert.ToInt32(lbTableName.Tag)]);
            loadLbThanhtien();
            loadFlpTable();
        }

        private void numUDGiamGia_ValueChanged(object sender, EventArgs e)
        {
            loadLbThanhtien();
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Có chắc chắn thanh toán cho bàn này?","Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                using (SqlConnection connect = new SqlConnection(sql.Server))
                {
                    try
                    {
                        connect.Open();
                        SqlCommand command = new SqlCommand("INSERT dbo.HoaDon(NgayXuat,TenBan,GiamGia,ThanhTien) VALUES(GETDATE(),N'" + bl_tableList[Convert.ToInt32(lbTableName.Tag)].TableName + "'," + numUDDiscount.Value.ToString() + "," + lbThanhtien.Text + ")", connect);
                        command.ExecuteNonQuery();
                        foreach (ListViewItem item in bl_tableList[Convert.ToInt32(lbTableName.Tag)].TableOrder)
                        {
                            SqlCommand command1 = new SqlCommand("INSERT dbo.ChiTietHoaDon(idHoaDon,TenMon,SoLuong,DonGia) VALUES((SELECT MAX(id) FROM dbo.HoaDon),N'" + item.Text + "'," + item.SubItems[3].Text + "," + item.SubItems[2].Text + ")", connect);
                            command1.ExecuteNonQuery();
                        }
                        resetOrder();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi thanh toán");
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void smenuAdmin_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm(this);
            form.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassForm form = new ChangePassForm(this);
            form.ShowDialog();
        }
        #endregion
    }
}
