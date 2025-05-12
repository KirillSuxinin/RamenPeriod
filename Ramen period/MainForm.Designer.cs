namespace Ramen_period
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.UpMainMenu = new System.Windows.Forms.MenuStrip();
            this.AuthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostElementTable = new System.Windows.Forms.Integration.ElementHost();
            this.ExitAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpMainMenu
            // 
            this.UpMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(125)))), ((int)(((byte)(96)))));
            this.UpMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AuthToolStripMenuItem,
            this.cardsToolStripMenuItem,
            this.EditToolStripMenuItem});
            this.UpMainMenu.Location = new System.Drawing.Point(0, 0);
            this.UpMainMenu.Name = "UpMainMenu";
            this.UpMainMenu.Size = new System.Drawing.Size(804, 24);
            this.UpMainMenu.TabIndex = 0;
            this.UpMainMenu.Text = "UpMenu";
            // 
            // AuthToolStripMenuItem
            // 
            this.AuthToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AuthToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AuthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitAccountToolStripMenuItem});
            this.AuthToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.AuthToolStripMenuItem.Name = "AuthToolStripMenuItem";
            this.AuthToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.AuthToolStripMenuItem.Text = "Войти";
            // 
            // cardsToolStripMenuItem
            // 
            this.cardsToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cardsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cardsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cardsToolStripMenuItem.Name = "cardsToolStripMenuItem";
            this.cardsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.cardsToolStripMenuItem.Text = "Корзина";
            this.cardsToolStripMenuItem.Click += new System.EventHandler(this.cardsToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.EditToolStripMenuItem.Text = "Редактирование";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // hostElementTable
            // 
            this.hostElementTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hostElementTable.Location = new System.Drawing.Point(0, 59);
            this.hostElementTable.Name = "hostElementTable";
            this.hostElementTable.Size = new System.Drawing.Size(804, 379);
            this.hostElementTable.TabIndex = 1;
            this.hostElementTable.Text = "asd";
            this.hostElementTable.Child = null;
            // 
            // ExitAccountToolStripMenuItem
            // 
            this.ExitAccountToolStripMenuItem.Name = "ExitAccountToolStripMenuItem";
            this.ExitAccountToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitAccountToolStripMenuItem.Text = "Выйти";
            this.ExitAccountToolStripMenuItem.Click += new System.EventHandler(this.ExitAccountToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(804, 450);
            this.Controls.Add(this.hostElementTable);
            this.Controls.Add(this.UpMainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.UpMainMenu;
            this.MinimumSize = new System.Drawing.Size(820, 489);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рамен и точка";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.UpMainMenu.ResumeLayout(false);
            this.UpMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip UpMainMenu;
        private System.Windows.Forms.ToolStripMenuItem AuthToolStripMenuItem;
        private System.Windows.Forms.Integration.ElementHost hostElementTable;
        private System.Windows.Forms.ToolStripMenuItem cardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitAccountToolStripMenuItem;
    }
}