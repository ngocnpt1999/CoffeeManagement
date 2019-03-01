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
    public partial class LoginForm : Form
    {
        private SqlServer sql = new SqlServer();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(sql.Server))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) AS TC,TK,MK,FullName,TruyCap FROM dbo.account WHERE TK='" + tenDN.Text + "' AND MK='" + mk.Text + "' GROUP BY TK,MK,FullName,TruyCap", connect);
                    SqlDataReader reader = command.ExecuteReader();
                    bool cayCo = false;
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["TC"]) == 1)
                        {
                            cayCo = true;
                            MForm mainForm = new MForm();
                            mainForm.UserData = new User(reader["TK"].ToString(), reader["MK"].ToString(), reader["FullName"].ToString(), Convert.ToInt32(reader["TruyCap"].ToString()));
                            this.Hide();
                            mainForm.ShowDialog();
                            this.Show();
                        }
                    }
                    if (cayCo == false)
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi không xác định");
                }
                finally
                {
                    connect.Close();
                }
            }
        }
    }
}
