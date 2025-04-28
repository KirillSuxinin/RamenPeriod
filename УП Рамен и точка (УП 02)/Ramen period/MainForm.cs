using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ramen_period
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            if(Program.IsAuth())
            {
                AuthToolStripMenuItem.Text = "Мой аккаунт";

                //Очистка событий (нужно чтобы избежать повторности вызыва)
                AuthToolStripMenuItem.Click -= AuthToolStripMenuItem_Click;
                AuthToolStripMenuItem.Click -= DeAuthToolStripMenuItem_Click;
                //Добавление чистого события
                AuthToolStripMenuItem.Click += DeAuthToolStripMenuItem_Click;
            }
            else
            {
                AuthToolStripMenuItem.Text = "Войти";
                AuthToolStripMenuItem.Click -= AuthToolStripMenuItem_Click;
                AuthToolStripMenuItem.Click -= DeAuthToolStripMenuItem_Click;
                //Добавление чистого события
                AuthToolStripMenuItem.Click += AuthToolStripMenuItem_Click;

            }
        }
        /// <summary>
        /// Событие для кнопки "Войти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("СОБЫТИЕ ВОЙТИ");

        }
        /// <summary>
        /// Событие для кнопки "Мой аккаунт"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeAuthToolStripMenuItem_Click(object sender,EventArgs e)
        {
            MessageBox.Show("СОБЫТИЕ МОЙ АККАУНТ");
        }
    }
}
