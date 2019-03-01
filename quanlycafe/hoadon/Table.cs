using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlycafe
{
    class Table
    {
        private int tableID;
        private string tableName;
        private ListViewItem[] tableOrder;

        public Table(int tableID, string tableName)
        {
            this.tableID = tableID;
            this.tableName = tableName;
            this.tableOrder = new ListViewItem[0];
        }

        public int TableID { get => tableID; set => tableID = value; }
        public string TableName { get => tableName; set => tableName = value; }
		public ListViewItem[] TableOrder { get => tableOrder; set => tableOrder = value; }
	}
}
