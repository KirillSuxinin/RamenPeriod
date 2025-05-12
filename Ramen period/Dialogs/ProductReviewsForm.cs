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
    public partial class ProductReviewsForm : Form
    {
        public ProductReviewsForm(int IdProduct)
        {
            InitializeComponent();
            BindL<ProductReviewsForm>.Set(this);
            this.IdPRod = IdProduct;
        }
        private int IdPRod;
        private void ProductReviewsForm_Load(object sender, EventArgs e)
        {

            //Product Pre-load
            var prod_com = Program.SQL.CreateCommand();
            prod_com.CommandText = $"SELECT * FROM [Products] WHERE [ProductID] = \'{IdPRod}\'";
            var prod_reader = prod_com.ExecuteReader();
            var tabProd = new DataTable();
            tabProd.Load(prod_reader);
            prod_reader.Close();
            txtName.Text = tabProd.Rows[0].Field<string>("ProductName");

            picProduct.Image = Program.GetBitmap(tabProd.Rows[0].Field<string>("ImageURL"));
            txtDesc.Text = tabProd.Rows[0].Field<string>("Description");

            var com = Program.SQL.CreateCommand();
            com.CommandText = $"SELECT * FROM [ProductReviews] WHERE [ProductID] = \'{IdPRod}\'";
            var reader = com.ExecuteReader();
            var tab = new DataTable();
            tab.Load(reader);
            reader.Close();
            if(tab.Rows.Count > 0)
            {
                List<ViewerT.Reviews> ilist = new List<ViewerT.Reviews>();
                for(int i = 0; i < tab.Rows.Count; i++)
                {
                    //User Pre-load
                    var lite_com = Program.SQL.CreateCommand();
                    string user_id = tab.Rows[i].Field<int>("UserID").ToString();
                    lite_com.CommandText = $"SELECT * FROM [Users] WHERE [UserID] = \'{user_id}\'";
                    var lite_reader = lite_com.ExecuteReader();
                    var lite_tab = new DataTable();
                    lite_tab.Load(lite_reader);
                    lite_reader.Close();



                    string user_name = lite_tab.Rows[0].Field<string>("FirstName");
                    var child = new ViewerT.Reviews()
                    {
                        FirstName = user_name,
                        Comment = tab.Rows[i].Field<string>("Comment"),
                        Rating = tab.Rows[i].Field<int>("Rating").ToString(),
                        ReviewDate = tab.Rows[i].Field<DateTime>("ReviewDate")
                    };
                    Bitmap img_rat = Properties.Resources.picStar_Empty;
                    
                    if(child.Rating == "1")
                    {
                        img_rat = Properties.Resources.picStar_1;
                    }
                    if (child.Rating == "2")
                    {
                        img_rat = Properties.Resources.picStar_2;
                    }
                    if (child.Rating == "3")
                    {
                        img_rat = Properties.Resources.picStar_3;
                    }
                    if (child.Rating == "4")
                    {
                        img_rat = Properties.Resources.picStar_4;
                    }
                    if (child.Rating == "5")
                    {
                        img_rat = Properties.Resources.picStar_5;
                    }
                    child.SetPicStar(img_rat);
                    ilist.Add(child);

                }

                this.elemHost.Child = new ViewerT.ProductReviewsControl(ilist);
                ((this.elemHost.Child as ViewerT.ProductReviewsControl).DataContext as ViewerT.ProductReviews_View).SetUrlImage(tabProd.Rows[0].Field<string>("ImageURL"));
            }
            else
            {
                MessageBox.Show(this, "Товар не имеет отзывы\nНапишите первыми!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnSendRating_Click(object sender, EventArgs e)
        {
            //TODO: HERE WE CREATE FORM FOR CREATE RATING
            if (!Program.IsAuth())
            {
                MessageBox.Show(this,"Отзывы может оставлять только авторизованный пользователь!","Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
        }
    }
}
