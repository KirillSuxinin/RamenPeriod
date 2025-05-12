namespace Ramen_period.Dialogs
{
    partial class AboutProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutProductForm));
            this.img_prod = new System.Windows.Forms.PictureBox();
            this.txt_name = new System.Windows.Forms.Label();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.txt_price = new System.Windows.Forms.Label();
            this.txt_addeddate = new System.Windows.Forms.Label();
            this.txt_categories = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.img_prod)).BeginInit();
            this.SuspendLayout();
            // 
            // img_prod
            // 
            this.img_prod.Location = new System.Drawing.Point(12, 12);
            this.img_prod.Name = "img_prod";
            this.img_prod.Size = new System.Drawing.Size(229, 199);
            this.img_prod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_prod.TabIndex = 0;
            this.img_prod.TabStop = false;
            // 
            // txt_name
            // 
            this.txt_name.AutoSize = true;
            this.txt_name.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txt_name.Location = new System.Drawing.Point(247, 12);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(142, 19);
            this.txt_name.TabIndex = 1;
            this.txt_name.Text = "НАИМЕНОВАНИЕ:";
            // 
            // txtDescr
            // 
            this.txtDescr.AcceptsReturn = true;
            this.txtDescr.AcceptsTab = true;
            this.txtDescr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            this.txtDescr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescr.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDescr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtDescr.HideSelection = false;
            this.txtDescr.Location = new System.Drawing.Point(251, 34);
            this.txtDescr.Multiline = true;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.ReadOnly = true;
            this.txtDescr.Size = new System.Drawing.Size(310, 100);
            this.txtDescr.TabIndex = 2;
            // 
            // txt_price
            // 
            this.txt_price.AutoSize = true;
            this.txt_price.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txt_price.Location = new System.Drawing.Point(247, 137);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(107, 19);
            this.txt_price.TabIndex = 1;
            this.txt_price.Text = "СТОИМОСТЬ";
            // 
            // txt_addeddate
            // 
            this.txt_addeddate.AutoSize = true;
            this.txt_addeddate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_addeddate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txt_addeddate.Location = new System.Drawing.Point(247, 192);
            this.txt_addeddate.Name = "txt_addeddate";
            this.txt_addeddate.Size = new System.Drawing.Size(101, 21);
            this.txt_addeddate.TabIndex = 1;
            this.txt_addeddate.Text = "ДАТА ДОБ";
            // 
            // txt_categories
            // 
            this.txt_categories.AutoSize = true;
            this.txt_categories.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txt_categories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txt_categories.Location = new System.Drawing.Point(12, 226);
            this.txt_categories.Name = "txt_categories";
            this.txt_categories.Size = new System.Drawing.Size(119, 21);
            this.txt_categories.TabIndex = 1;
            this.txt_categories.Text = "КАТЕГОРИЯ";
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnBack.Location = new System.Drawing.Point(12, 303);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // AboutProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(573, 338);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.txt_categories);
            this.Controls.Add(this.txt_addeddate);
            this.Controls.Add(this.txt_price);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.img_prod);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Рамен и точка. О продукте";
            this.Load += new System.EventHandler(this.AboutProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img_prod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox img_prod;
        private System.Windows.Forms.Label txt_name;
        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.Label txt_price;
        private System.Windows.Forms.Label txt_addeddate;
        private System.Windows.Forms.Label txt_categories;
        private System.Windows.Forms.Button btnBack;
    }
}