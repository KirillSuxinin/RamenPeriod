using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Ramen_period
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient web = new WebClient();
            byte[] dat = web.DownloadData(@"https://sun9-10.userapi.com/impg/IOxWhTf5vHdaErwvUHz6LpVBtdbQXH_eUBHG-w/JrxHi27cfr8.jpg?size=320x320&quality=95&sign=cbbcb855a0aa5040958e0957f92f477b&type=album");
            Bitmap bt = (Bitmap)(Image.FromStream(new MemoryStream(dat)));
            pictureBox1.Image = bt;
            
        }
    }
}
