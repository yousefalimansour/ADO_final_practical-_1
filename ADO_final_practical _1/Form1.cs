using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_final_practical__1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sqlcmdselect = new SqlCommand("select * from Product",sqlcn);
            sqlcmdselectsupplier = new SqlCommand("select id as SID ,CompanyName from Supplier", sqlcn);

            DA=new SqlDataAdapter(sqlcmdselect);
            supplier=new SqlDataAdapter(sqlcmdselectsupplier);

            dt=new DataTable();
            dtsupplier = new DataTable();
        }
        SqlConnection sqlcn=new SqlConnection("Data Source=.;Initial Catalog=Northwind2021;Integrated Security=True");

        SqlCommand sqlcmdselect;
        SqlCommand sqlcmdselectsupplier;

        SqlDataAdapter DA;
        SqlDataAdapter supplier;

        DataTable dt;
        DataTable dtsupplier;
     
       

        BindingSource prdbindingsource;
        private void btnload_Click(object sender, EventArgs e)
        {

            DA.Fill(dt);     
            prdbindingsource = new BindingSource(dt,"");
            grdview.DataSource = prdbindingsource;
            grdview.Columns["id"].ReadOnly = true;
            //grdview.Columns["SupplierId"].Visible = false;
            ///////
            ///////
            DataGridViewComboBoxColumn dc = new DataGridViewComboBoxColumn();
            dc.HeaderText = "Supplier";
            grdview.Columns.AddRange(dc);
            supplier.Fill(dtsupplier);
            dc.DataSource = dtsupplier;
            dc.DisplayMember = "CompanyName";
            dc.ValueMember = "SID";
            dc.DataPropertyName = "id";
          
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            grdview.EndEdit();
            //DA.Update(dt);
            foreach (DataRow dr in dtsupplier.Rows)
            {
                Debug.WriteLine(dr.RowState);
            }
        }
    }
}
