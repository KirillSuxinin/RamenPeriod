using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ramen_period.Dialogs;

namespace Ramen_period
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.Retry;
            BindL<MainForm>.Set(this);
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateLentaProducts();
            UpdateState();
            UpdateCardsCount();
            var tms = new System.Windows.Forms.Timer();
            tms.Tick += Timer_Handler;
            tms.Interval = 5000;
            tms.Start();
        }

        private string Last = "";

        private void Timer_Handler(object sender,EventArgs e)
        {
            Last = cardsToolStripMenuItem.Text;
            UpdateState();
            UpdateCardsCount();
            if(cardsToolStripMenuItem.Text != Last)
            {
                UpdateLentaProducts();
            }
        }

        /// <summary>
        /// Событие для кнопки "Войти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialogs.AuthDialogForm authF = new Dialogs.AuthDialogForm();

            authF.Owner = this;
            authF.DialogResult = DialogResult.None;
            authF.ShowDialog();
            UpdateState();
            UpdateCardsCount();
            

        }

        public void UpdateState()
        {
            if (Program.IsAuth())
            {
                Debugger.Log(11, PATHCODE.WARNING, "IsAuth True", typeof(MainForm));
                AuthToolStripMenuItem.Text = "Мой аккаунт";

                //Очистка событий (нужно чтобы избежать повторности вызыва)
                AuthToolStripMenuItem.Click -= AuthToolStripMenuItem_Click;
                AuthToolStripMenuItem.Click -= DeAuthToolStripMenuItem_Click;
                //Добавление чистого события
                AuthToolStripMenuItem.Click += DeAuthToolStripMenuItem_Click;
                cardsToolStripMenuItem.Visible = true;
                foreach (var v in ((hostElementTable.Child as ViewerT.ViewerTable).DataContext as ViewerT.ViewerTable_ViewModel).MeProducts)
                {
                    v.DelVisible = System.Windows.Visibility.Visible;
                }
                if (Program.IsAdmin())
                {
                    EditToolStripMenuItem.Visible = true;
                    foreach (var v in ((hostElementTable.Child as ViewerT.ViewerTable).DataContext as ViewerT.ViewerTable_ViewModel).MeProducts)
                    {
                        v.EditVisible = System.Windows.Visibility.Visible;
                    }
                }
                else
                {
                    foreach (var v in ((hostElementTable.Child as ViewerT.ViewerTable).DataContext as ViewerT.ViewerTable_ViewModel).MeProducts)
                    {
                        v.EditVisible = System.Windows.Visibility.Hidden;
                    }
                    EditToolStripMenuItem.Visible = false;
                }

            }
            else
            {
                AuthToolStripMenuItem.Text = "Войти";
                AuthToolStripMenuItem.Click -= AuthToolStripMenuItem_Click;
                AuthToolStripMenuItem.Click -= DeAuthToolStripMenuItem_Click;
                //Добавление чистого события
                AuthToolStripMenuItem.Click += AuthToolStripMenuItem_Click;
                foreach (var v in ((hostElementTable.Child as ViewerT.ViewerTable).DataContext as ViewerT.ViewerTable_ViewModel).MeProducts)
                {
                    v.DelVisible = System.Windows.Visibility.Hidden;
                    v.EditVisible = System.Windows.Visibility.Hidden;
                    ((hostElementTable.Child as ViewerT.ViewerTable)).UpdateDefaultStyle();
                    ((hostElementTable.Child as ViewerT.ViewerTable)).UpdateLayout();
                }
                cardsToolStripMenuItem.Visible = false;
                EditToolStripMenuItem.Visible = false;
            }


        }

        private void UpdateLentaProducts()
        {
            while (true)
            {
                try
                {
                    Program.SQL.CreateCommand();
                    break;
                }
                catch
                {
                    continue;
                }
            }

            List<ViewerT.MeProducts> prods = new List<ViewerT.MeProducts>();
            var com = Program.SQL.CreateCommand();
            com.CommandText = "SELECT * FROM [Products]";
            var reader = com.ExecuteReader();
            DataTable tab = new DataTable();
            tab.Load(reader);
            reader.Close();

            for (int i = 0; i < tab.Rows.Count; i++)
            {
                ViewerT.MeProducts prod = new ViewerT.MeProducts();
                prod.IdProduct = int.Parse(tab.Rows[i].ItemArray[0].ToString());
                prod.ProductName = tab.Rows[i].ItemArray[2].ToString();
                prod.Description = tab.Rows[i].ItemArray[3].ToString();
                prod.Price = tab.Rows[i].ItemArray[4].ToString();
                prod.AddedDate = DateTime.Parse(tab.Rows[i].ItemArray[5].ToString());


                //pre-load for shop cards
                var check_com = Program.SQL.CreateCommand();
                check_com.CommandText = $"SELECT * FROM [ShoppingCart] WHERE [ProductID] = \'{tab.Rows[i].ItemArray[0]}\' AND [UserID] = \'{Program.GetUID()}\'";
                using (var rd = check_com.ExecuteReader())
                {
                    if (rd.HasRows)
                    {
                        DataTable table = new DataTable();
                        table.Load(rd);
                        if (table.Rows.Count > 0)
                            prod.CountAdded = table.Rows[0].Field<int>("Quantity").ToString();
                    }
                }


                prod.Set_Image_Url(tab.Rows[i].ItemArray[6].ToString());
                prods.Add(prod);
            }


            var ACT_ABOUT = new ViewerT.HandlerProduct((IDP, _sender) =>
            {
                var obj = tab.Rows.Cast<DataRow>().Where(x => x.ItemArray[0].ToString() == IDP.ToString()).FirstOrDefault();


                Dialogs.AboutProductForm f_about = new AboutProductForm(IDP);
                f_about.Owner = this;
              //  f_about.Show();

                Dialogs.ProductReviewsForm rev = new ProductReviewsForm(IDP);
                rev.Show();
                return string.Empty;
            });

            var ACT_ADD = new ViewerT.HandlerProduct((IDP,_sender) =>
            {
                if (Program.IsAuth())
                {
                    var check_com = Program.SQL.CreateCommand();
                    bool create = true;
                    check_com.CommandText = $"SELECT * FROM [ShoppingCart] WHERE [ProductID] = \'{IDP}\' AND [UserID] = \'{Program.GetUID()}\'";
                    using(var rd = check_com.ExecuteReader())
                    {
                        if(rd.HasRows)
                        {
                            create = false;
                        }
                    }

                    if(create)
                    {
                        var create_new_card = Program.SQL.CreateCommand();
                        int newIDCard = Program.GetMaxID("ShoppingCart", "CartID")+1;
                        create_new_card.CommandText = $"INSERT INTO [ShoppingCart] (CartID, UserID, ProductID, Quantity) VALUES({newIDCard},{Program.GetUID()},{IDP},1)";
                        create_new_card.ExecuteNonQuery();

                        MessageBox.Show(this, "Товар добавлен в корзину", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (_sender is System.Windows.Controls.MenuItem)
                        {
                            UpdateLentaProducts();
                        }
                        return $"Добавить (1)";
                    }
                    else
                    {
                        int quant = 1;
                        using(var rd = check_com.ExecuteReader())
                        {
                            var tb = new DataTable();
                            tb.Load(rd);
                            quant = tb.Rows[0].Field<int>("Quantity");
                        }
                        var com_update = Program.SQL.CreateCommand();
                        quant += 1;
                        com_update.CommandText = $"UPDATE ShoppingCart SET [Quantity] = {quant} WHERE [ProductID] = '{IDP}' AND [UserID] = '{Program.GetUID()}'";
                        com_update.ExecuteNonQuery();
                        if (_sender is MenuItem)
                        {
                            UpdateLentaProducts();
                            UpdateCardsCount();
                        }
                        return $"Добавить ({quant})";
                    }

                }
                else
                    MessageBox.Show(this, "Необходимо авторизоватся", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Добавить";
            });

            var ACT_DEL = new ViewerT.HandlerProduct((IDP, _sender) =>
            {
                if (Program.IsAuth())
                {
                    if (MessageBox.Show(this, "Вы уверены что хотите убрать данный товар из корзины?", "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var del_com = Program.SQL.CreateCommand();
                        del_com.CommandText = $"DELETE FROM [ShoppingCart] WHERE [ProductID] = \'{IDP}\' AND [UserID] = \'{Program.GetUID()}\'";
                        int r = del_com.ExecuteNonQuery();
                        UpdateLentaProducts();
                        UpdateCardsCount();
                        if(r == 0)
                        {
                            MessageBox.Show(this, "0 элементов затронуто", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show(this, "Данная позиция больше не в корзине", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show(this, "Необходимо авторизоватся", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            });

            var ACT_EDIT = new ViewerT.HandlerProduct((IDP, _sender) =>
            {
                return string.Empty;
            });


            ViewerT.ViewerTable ctrl = new ViewerT.ViewerTable(prods, ACT_ADD, ACT_ABOUT, ACT_EDIT, ACT_DEL);
            hostElementTable.Child = ctrl;
            if (!Program.IsAuth())
            {
                foreach(var v in (ctrl.DataContext as ViewerT.ViewerTable_ViewModel).MeProducts)
                {
                    v.DelVisible = System.Windows.Visibility.Hidden;
                    v.EditVisible = System.Windows.Visibility.Hidden;
                }
                Debugger.Log(0, PATHCODE.ERROR, "SET HIDDEN");
            }
        }


        

        /// <summary>
        /// Событие для кнопки "Мой аккаунт"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeAuthToolStripMenuItem_Click(object sender,EventArgs e)
        {
            Debugger.Log(505, PATHCODE.WARNING, "OPEN ME ACCOUNT", typeof(MainForm));


        }

        public void UpdateCardsCount()
        {
            if (Program.IsAuth())
            {
                int UID = Program.GetUID();
                //ShoppingCart
                var com = Program.SQL.CreateCommand();
                com.CommandText = $"SELECT * FROM [ShoppingCart] WHERE [UserID] = \'{UID}\'";
                Debugger.Log(0, PATHCODE.MESSAGE, com.CommandText, typeof(MainForm));
                using(var reader = com.ExecuteReader())
                {
                    var tb = new DataTable();
                    tb.Load(reader);
                    
                    cardsToolStripMenuItem.Text = $"Корзина ({tb.Rows.Count})";
                }
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Login = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.SaveMe = false;
            Properties.Settings.Default.Save();
        }

        private void cardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialogs.MeCardsForm mecard = new MeCardsForm();
            mecard.Owner = this;
            mecard.Show();
        }
    }
}
