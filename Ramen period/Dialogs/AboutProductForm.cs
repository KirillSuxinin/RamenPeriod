using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ramen_period.Dialogs
{
    public partial class AboutProductForm : Form
    {
        public AboutProductForm(int index)
        {
            InitializeComponent();
            IndexProduct = index;
            BindL<AboutProductForm>.Set(this);
        }

        private int IndexProduct;

        private void AboutProductForm_Load(object sender, EventArgs e)
        {
            var com = Program.SQL.CreateCommand();
            com.CommandText = $"SELECT * FROM [Products] WHERE [ProductID] = \'{IndexProduct}\'";
            var reader = com.ExecuteReader();
            var tb = new DataTable();
            tb.Load(reader);
            reader.Close();

            var element = tb.Rows[0];
            if(element != null)
            {
                txtDescr.Text = element.Field<string>("Description");
                txt_name.Text = element.Field<string>("ProductName");

                txt_addeddate.Text = element.Field<DateTime>("AddedDate").ToString();
                img_prod.Image = Program.GetBitmap(element.Field<string>("ImageURL"));
                txt_price.Text = element.Field<Decimal>("Price").ToString() + " руб.";

                var com_cat = Program.SQL.CreateCommand();
                com_cat.CommandText = $"SELECT * FROM [Categories] WHERE [CategoryID] = \'{element.Field<int>("CategoryID")}\'";
                var reader_cat = com_cat.ExecuteReader();
                var tb_cat = new DataTable();
                tb_cat.Load(reader_cat);
                reader_cat.Close();


                txt_categories.Text = tb_cat.Rows[0].Field<string>("CategoryName");

            }
            else
            {
                Debugger.Log(0, PATHCODE.ERROR, "element was null!", typeof(AboutProductForm));
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
