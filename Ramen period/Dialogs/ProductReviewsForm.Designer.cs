namespace Ramen_period.Dialogs
{
    partial class ProductReviewsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductReviewsForm));
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.elemHost = new System.Windows.Forms.Integration.ElementHost();
            this.productReviewsControl1 = new ViewerT.ProductReviewsControl();
            this.txtName = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btnSendRating = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // picProduct
            // 
            this.picProduct.Location = new System.Drawing.Point(0, 0);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(148, 125);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProduct.TabIndex = 1;
            this.picProduct.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Location = new System.Drawing.Point(12, 415);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // elemHost
            // 
            this.elemHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elemHost.Location = new System.Drawing.Point(0, 131);
            this.elemHost.Name = "elemHost";
            this.elemHost.Size = new System.Drawing.Size(558, 275);
            this.elemHost.TabIndex = 0;
            this.elemHost.Text = "HOST";
            this.elemHost.Child = this.productReviewsControl1;
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtName.Location = new System.Drawing.Point(154, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(76, 19);
            this.txtName.TabIndex = 3;
            this.txtName.Text = "НАИМЕН";
            // 
            // txtDesc
            // 
            this.txtDesc.AcceptsReturn = true;
            this.txtDesc.AcceptsTab = true;
            this.txtDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            this.txtDesc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtDesc.Location = new System.Drawing.Point(158, 48);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(389, 77);
            this.txtDesc.TabIndex = 4;
            // 
            // btnSendRating
            // 
            this.btnSendRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendRating.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSendRating.Location = new System.Drawing.Point(425, 415);
            this.btnSendRating.Name = "btnSendRating";
            this.btnSendRating.Size = new System.Drawing.Size(122, 23);
            this.btnSendRating.TabIndex = 5;
            this.btnSendRating.Text = "Оставить отзыв";
            this.btnSendRating.UseVisualStyleBackColor = true;
            this.btnSendRating.Click += new System.EventHandler(this.btnSendRating_Click);
            // 
            // ProductReviewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(559, 450);
            this.Controls.Add(this.btnSendRating);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.picProduct);
            this.Controls.Add(this.elemHost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(575, 489);
            this.Name = "ProductReviewsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отзывы о продукте";
            this.Load += new System.EventHandler(this.ProductReviewsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elemHost;
        private ViewerT.ProductReviewsControl productReviewsControl1;
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Button btnSendRating;
    }
}