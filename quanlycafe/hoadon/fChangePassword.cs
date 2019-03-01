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
    public partial class ChangePassForm : Form
    {
        private MForm mainForm;
        private SqlServer sql = new SqlServer();

        public ChangePassForm(MForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect=new SqlConnection(sql.Server))
            {
                try
                {
                    connect.Open();
                    if (txtOldPass.Text == mainForm.UserData.Password && !string.IsNullOrEmpty(txtNewPass.Text))
                    {
                        SqlCommand command = new SqlCommand("UPDATE dbo.account SET MK='" + txtNewPass.Text + "' WHERE TK='" + mainForm.UserData.Username + "'", connect);
                        command.ExecuteNonQuery();
                        txtOldPass.Clear();
                        txtNewPass.Clear();
                        MessageBox.Show("Đổi mật khẩu thành công");
                    }
                    else
                    {
                        txtOldPass.Clear();
                        txtNewPass.Clear();
                        MessageBox.Show("Sai mật khẩu");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fail");
                }
                finally
                {
                    connect.Close();
                }
            }
        }
    }
}
