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
using DevExpress.XtraEditors.Repository;


namespace WindowsApplication3 {
    public partial class Form1: XtraForm {
        public Form1() {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.nwindDataSet.Orders);
          dateEdit1.Properties.AppearanceCalendar.DayCellHighlighted.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          dateEdit1.Properties.AppearanceCalendar.DayCellHighlighted.Options.UseFont = true;
         repositoryItemDateEdit1.AppearanceCalendar.DayCellHighlighted.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         repositoryItemDateEdit1.AppearanceCalendar.DayCellHighlighted.Options.UseFont = true;
         
        }

    }
}
