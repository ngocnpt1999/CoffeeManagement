﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlycafe
{
    public partial class BillInfoForm : Form
    {
        public BillInfoForm()
        {
            InitializeComponent();
        }
        public DataGridView GrvBillInfo => grvBillInfo;
    }
}
