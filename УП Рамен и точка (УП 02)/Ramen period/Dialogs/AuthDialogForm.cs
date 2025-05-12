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
    public partial class AuthDialogForm : Form
    {
        /// <summary>
        /// DialogResult start None
        /// </summary>
        public AuthDialogForm()
        {
            InitializeComponent();
            txtlogin.Tag = "A";
            BindL<AuthDialogForm>.Set(this);
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            if(DialogResult == DialogResult.None)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnInvokeAuth_Click(object sender, EventArgs e)
        {
            if(txtlogin.Tag.ToString() == "G")
            {
                if (!string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    var com = Program.SQL.CreateCommand();
                    com.CommandText = $"SELECT * From [Users] WHERE [Phone] = \'+{txtlogin.Text}\' AND [Password] = \'{txtPass.Text}\'";
                    var reader = com.ExecuteReader();
                    if(reader.HasRows)
                    {
                        MessageBox.Show("!");
                    }
                    else
                    {
                        MessageBox.Show(this, "Не удалось войти", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    reader.Close();
                    
                }
            }
        }

        private void txtlogin_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            if (txtlogin.Text.Length <= 0)
            {
                txtlogin.BackColor = Color.FromArgb(255, 255, 255);
                return;
            }
            else if ((txtlogin.Text.Length < "79001234561".Length || txtlogin.Text.Length > "79001234561".Length) || !double.TryParse(txtlogin.Text,out tmp))
            {
                txtlogin.BackColor = Color.FromArgb(255, 128, 128);
                txtlogin.Tag = "BAD";
            }

            else 
            {
                txtlogin.BackColor = Color.FromArgb(255, 255,255);
                txtlogin.Tag = "G";
            }
        }
    }
}
