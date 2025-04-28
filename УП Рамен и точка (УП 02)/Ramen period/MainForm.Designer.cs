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
            this.UpMainMenu = new System.Windows.Forms.MenuStrip();
            this.AuthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpMainMenu
            // 
            this.UpMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AuthToolStripMenuItem});
            this.UpMainMenu.Location = new System.Drawing.Point(0, 0);
            this.UpMainMenu.Name = "UpMainMenu";
            this.UpMainMenu.Size = new System.Drawing.Size(800, 24);
            this.UpMainMenu.TabIndex = 0;
            this.UpMainMenu.Text = "UpMenu";
            // 
            // AuthToolStripMenuItem
            // 
            this.AuthToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AuthToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AuthToolStripMenuItem.Name = "AuthToolStripMenuItem";
            this.AuthToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.AuthToolStripMenuItem.Text = "Войти";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UpMainMenu);
            this.MainMenuStrip = this.UpMainMenu;
            this.Name = "MainForm";
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
    }
}