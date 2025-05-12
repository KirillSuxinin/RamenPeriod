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
    public partial class MeCardsForm : Form
    {
        public MeCardsForm()
        {
            InitializeComponent();
            BindL<MeCardsForm>.Set(this);
        }

        private void MeCardsForm_Load(object sender, EventArgs e)
        {
            var com = Program.SQL.CreateCommand();
            com.CommandText = $"SELECT * FROM [ShoppingCart] WHERE [UserID] = \'{Properties.Settings.Default.UserID}\'";
            var reader = com.ExecuteReader();
            var tb = new DataTable();
            tb.Load(reader);
            reader.Close();
            decimal mepric = 0;
            List<ViewerT.Card> ilist = new List<ViewerT.Card>();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                ViewerT.Card card = new ViewerT.Card();
                card.IdProduct = tb.Rows[i].Field<int>("ProductID");
                var com_prod = Program.SQL.CreateCommand();
                com_prod.CommandText = $"SELECT * FROM [Products] WHERE [ProductID] = \'{card.IdProduct}\'";
                Debugger.Log(0, PATHCODE.ERROR, $"{tb.Rows.Count}");

                var reader_prod = com_prod.ExecuteReader();
                var tb_prod = new DataTable();
                tb_prod.Load(reader_prod);
                reader_prod.Close();
                var element = tb_prod.Rows[0];

                card.ProductName = element.Field<string>("ProductName");
                card.Set_Image_Url(element.Field<string>("ImageURL"));
                card.Description = element.Field<string>("Description");
                card.AddedDate = tb.Rows[i].Field<DateTime>("AddedDate");
                card.Quantity = tb.Rows[i].Field<int>("Quantity").ToString();
                card.Price = element.Field<decimal>("Price").ToString();
                mepric += element.Field<decimal>("Price") * tb.Rows[i].Field<int>("Quantity");
                ilist.Add(card);

            }


            ViewerT.HandlerProduct ACT_ADD = new ViewerT.HandlerProduct((IDP, _sender) =>
            {

                var com_check_del = Program.SQL.CreateCommand();
                com_check_del.CommandText = $"SELECT * FROM [ShoppingCart] WHERE [UserID] = \'{Properties.Settings.Default.UserID}\' and [ProductID] = \'{IDP}\'";
                var rd_check_del = com_check_del.ExecuteReader();
                var tb_check_del = new DataTable();
                tb_check_del.Load(rd_check_del);
                rd_check_del.Close();

                int QUANTITY = tb_check_del.Rows[0].Field<int>("Quantity");
                QUANTITY++;

                var com_update_del = Program.SQL.CreateCommand();
                com_update_del.CommandText = $"UPDATE [ShoppingCart] Set [Quantity] = {QUANTITY} WHERE [UserID] = '{Properties.Settings.Default.UserID}' and [ProductID] = '{IDP}'";
                int res = com_update_del.ExecuteNonQuery();
                if (res == 0)
                {
                    MessageBox.Show(this, "Ноль строк затронуто", "Рамен и точка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                MeCardsForm_Load(sender, e);
                return QUANTITY.ToString();

            });
            ViewerT.HandlerProduct ACT_DEL = new ViewerT.HandlerProduct((IDP, _sender) =>
            {
                var com_check_del = Program.SQL.CreateCommand();
                com_check_del.CommandText = $"SELECT * FROM [ShoppingCart] WHERE [UserID] = \'{Properties.Settings.Default.UserID}\' and [ProductID] = \'{IDP}\'";
                var rd_check_del = com_check_del.ExecuteReader();
                var tb_check_del = new DataTable();
                tb_check_del.Load(rd_check_del);
                rd_check_del.Close();

                int QUANTITY = tb_check_del.Rows[0].Field<int>("Quantity");
                QUANTITY--;
                if (QUANTITY == 0)
                {

                    var com_update_del = Program.SQL.CreateCommand();
                    com_update_del.CommandText = $"DELETE FROM [ShoppingCart] WHERE [UserID] = '{Properties.Settings.Default.UserID}' and [ProductID] = '{IDP}'";
                    int res = com_update_del.ExecuteNonQuery();
                    if (res == 0)
                    {
                        MessageBox.Show(this, "Ноль строк затронуто", "Рамен и точка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    MeCardsForm_Load(sender, e);
                }
                else
                {
                    var com_update_del = Program.SQL.CreateCommand();
                    com_update_del.CommandText = $"UPDATE [ShoppingCart] Set [Quantity] = {QUANTITY} WHERE [UserID] = '{Properties.Settings.Default.UserID}' and [ProductID] = '{IDP}'";
                    int res = com_update_del.ExecuteNonQuery();
                    if (res == 0)
                    {
                        MessageBox.Show(this, "Ноль строк затронуто", "Рамен и точка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    MeCardsForm_Load(sender, e);
                    return QUANTITY.ToString();
                }

                return "0";
            });
            ViewerT.HandlerProduct ACT_ORDER_UPDATE = new ViewerT.HandlerProduct((IDP, _sender) =>
            {

                return string.Empty;

            });


            elementHost1.Child = new ViewerT.CardsViewerControl(ilist, ACT_DEL, ACT_ADD, ACT_ORDER_UPDATE);



            txt_price.Text = $"Итог: {mepric} руб.";


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }
    }
}
