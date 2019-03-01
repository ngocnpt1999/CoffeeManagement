using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace quanlycafe
{
    class SqlServer
    {
        private string server = @"Data Source=DESKTOP-VJVTV7H\SQLEXPRESS;Initial Catalog=QuanLyCoffee;Integrated Security=True";

		public SqlServer(){}
        public string Server { get => server;}
    }
}