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
            txtlogin.Tag = "BAD";
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
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count > 0)
                    {
                        reader.Close();
                        MessageBox.Show(this, "Авторизация успешна!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Properties.Settings.Default.Login = txtlogin.Text;
                        Properties.Settings.Default.Password = txtPass.Text;


                        reader.Close();
                        Debugger.Log(0, PATHCODE.WARNING, $"{tb.Rows.Count}");

                        Properties.Settings.Default.UserID = tb.Rows.Cast<DataRow>().FirstOrDefault().Field<int>("UserID");

                        if (cb_GetMe.Checked)
                            Properties.Settings.Default.Save();
                        DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show(this, "Не удалось войти", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
            else
            {
                MessageBox.Show(this, "Ошибка данных!\nВ поле логин", "Введите корректировки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtlogin_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            if (txtlogin.Text.Length <= 0)
            {
                txtlogin.BackColor = Color.FromArgb(255, 255, 255);
                txtlogin.Tag = "BAD";
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

        private void AuthDialogForm_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !cb_showpass.Checked;
            cb_GetMe.Checked = Properties.Settings.Default.SaveMe;
            if (cb_GetMe.Checked)
            {
                txtlogin.Text = Properties.Settings.Default.Login;
                txtPass.Text = Properties.Settings.Default.Password;
            }
        }

        private void cb_showpass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !cb_showpass.Checked;
        }

        private void AuthDialogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SaveMe = cb_GetMe.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
