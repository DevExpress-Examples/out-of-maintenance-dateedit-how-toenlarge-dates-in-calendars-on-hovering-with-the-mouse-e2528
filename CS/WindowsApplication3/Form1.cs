using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Drawing;


namespace WindowsApplication3 {
    public partial class Form1: XtraForm {
        public Form1() {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.nwindDataSet.Orders);
        }

        private void OnGridViewShownEditor(object sender, EventArgs e) {
            GridView view = sender as GridView;
            if(view.ActiveEditor is DateEdit)
                dateEditExtender1.SetEnlargeDatesOnMouseHover(view.ActiveEditor as DateEdit, checkEdit1.Checked);
        }

        private void OnCheckedChanged(object sender, EventArgs e) {
            dateEditExtender1.SetEnlargeDatesOnMouseHover(dateEdit1, (sender as CheckEdit).Checked);
        }
    }
}
