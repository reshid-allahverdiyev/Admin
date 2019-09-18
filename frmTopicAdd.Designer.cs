namespace Admin
{
    partial class frmTopicAdd
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
            System.Windows.Forms.Button btnTopicModifyCancel;
            System.Windows.Forms.Button btnTopicModifyApply;
            System.Windows.Forms.Button btnTopicAddCancel;
            System.Windows.Forms.Button btnTopicAddApply;
            this.pnlTopicModify = new System.Windows.Forms.Panel();
            this.txtTopicNameModify = new System.Windows.Forms.TextBox();
            this.lblTopicNameModify = new System.Windows.Forms.Label();
            this.pnlTopicAdd = new System.Windows.Forms.Panel();
            this.txtTopicNameAdd = new System.Windows.Forms.TextBox();
            this.lblTopicNameAdd = new System.Windows.Forms.Label();
            btnTopicModifyCancel = new System.Windows.Forms.Button();
            btnTopicModifyApply = new System.Windows.Forms.Button();
            btnTopicAddCancel = new System.Windows.Forms.Button();
            btnTopicAddApply = new System.Windows.Forms.Button();
            this.pnlTopicModify.SuspendLayout();
            this.pnlTopicAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTopicModifyCancel
            // 
            btnTopicModifyCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnTopicModifyCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnTopicModifyCancel.Location = new System.Drawing.Point(48, 191);
            btnTopicModifyCancel.Name = "btnTopicModifyCancel";
            btnTopicModifyCancel.Size = new System.Drawing.Size(153, 37);
            btnTopicModifyCancel.TabIndex = 52;
            btnTopicModifyCancel.Text = "İmtina et";
            btnTopicModifyCancel.UseVisualStyleBackColor = true;
            btnTopicModifyCancel.Click += new System.EventHandler(this.BtnTopicModifyCancel_Click);
            // 
            // btnTopicModifyApply
            // 
            btnTopicModifyApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnTopicModifyApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnTopicModifyApply.Location = new System.Drawing.Point(234, 191);
            btnTopicModifyApply.Name = "btnTopicModifyApply";
            btnTopicModifyApply.Size = new System.Drawing.Size(153, 37);
            btnTopicModifyApply.TabIndex = 50;
            btnTopicModifyApply.Text = "Düzəlişi təsdiq et";
            btnTopicModifyApply.UseVisualStyleBackColor = true;
            btnTopicModifyApply.Click += new System.EventHandler(this.BtnTopicModifyApply_Click);
            // 
            // btnTopicAddCancel
            // 
            btnTopicAddCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnTopicAddCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnTopicAddCancel.Location = new System.Drawing.Point(51, 190);
            btnTopicAddCancel.Name = "btnTopicAddCancel";
            btnTopicAddCancel.Size = new System.Drawing.Size(153, 37);
            btnTopicAddCancel.TabIndex = 52;
            btnTopicAddCancel.Text = "İmtina et";
            btnTopicAddCancel.UseVisualStyleBackColor = true;
            btnTopicAddCancel.Click += new System.EventHandler(this.BtnTopicAddCancel_Click);
            // 
            // btnTopicAddApply
            // 
            btnTopicAddApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnTopicAddApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnTopicAddApply.Location = new System.Drawing.Point(237, 190);
            btnTopicAddApply.Name = "btnTopicAddApply";
            btnTopicAddApply.Size = new System.Drawing.Size(153, 37);
            btnTopicAddApply.TabIndex = 50;
            btnTopicAddApply.Text = "Təsdiq et";
            btnTopicAddApply.UseVisualStyleBackColor = true;
            btnTopicAddApply.Click += new System.EventHandler(this.BtnTopicAddApply_Click);
            // 
            // pnlTopicModify
            // 
            this.pnlTopicModify.Controls.Add(btnTopicModifyCancel);
            this.pnlTopicModify.Controls.Add(btnTopicModifyApply);
            this.pnlTopicModify.Controls.Add(this.txtTopicNameModify);
            this.pnlTopicModify.Controls.Add(this.lblTopicNameModify);
            this.pnlTopicModify.Location = new System.Drawing.Point(2, 2);
            this.pnlTopicModify.Name = "pnlTopicModify";
            this.pnlTopicModify.Size = new System.Drawing.Size(406, 313);
            this.pnlTopicModify.TabIndex = 41;
            // 
            // txtTopicNameModify
            // 
            this.txtTopicNameModify.Location = new System.Drawing.Point(126, 51);
            this.txtTopicNameModify.Name = "txtTopicNameModify";
            this.txtTopicNameModify.Size = new System.Drawing.Size(264, 20);
            this.txtTopicNameModify.TabIndex = 43;
            this.txtTopicNameModify.TextChanged += new System.EventHandler(this.TxtTopicNameModify_TextChanged);
            // 
            // lblTopicNameModify
            // 
            this.lblTopicNameModify.AutoSize = true;
            this.lblTopicNameModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopicNameModify.Location = new System.Drawing.Point(85, 57);
            this.lblTopicNameModify.Name = "lblTopicNameModify";
            this.lblTopicNameModify.Size = new System.Drawing.Size(27, 16);
            this.lblTopicNameModify.TabIndex = 38;
            this.lblTopicNameModify.Text = "Ad";
            // 
            // pnlTopicAdd
            // 
            this.pnlTopicAdd.Controls.Add(btnTopicAddCancel);
            this.pnlTopicAdd.Controls.Add(btnTopicAddApply);
            this.pnlTopicAdd.Controls.Add(this.txtTopicNameAdd);
            this.pnlTopicAdd.Controls.Add(this.lblTopicNameAdd);
            this.pnlTopicAdd.Location = new System.Drawing.Point(1, 2);
            this.pnlTopicAdd.Name = "pnlTopicAdd";
            this.pnlTopicAdd.Size = new System.Drawing.Size(409, 313);
            this.pnlTopicAdd.TabIndex = 42;
            // 
            // txtTopicNameAdd
            // 
            this.txtTopicNameAdd.Location = new System.Drawing.Point(110, 49);
            this.txtTopicNameAdd.Name = "txtTopicNameAdd";
            this.txtTopicNameAdd.Size = new System.Drawing.Size(264, 20);
            this.txtTopicNameAdd.TabIndex = 43;
            // 
            // lblTopicNameAdd
            // 
            this.lblTopicNameAdd.AutoSize = true;
            this.lblTopicNameAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopicNameAdd.Location = new System.Drawing.Point(69, 55);
            this.lblTopicNameAdd.Name = "lblTopicNameAdd";
            this.lblTopicNameAdd.Size = new System.Drawing.Size(27, 16);
            this.lblTopicNameAdd.TabIndex = 38;
            this.lblTopicNameAdd.Text = "Ad";
            // 
            // frmTopicAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(415, 281);
            this.Controls.Add(this.pnlTopicAdd);
            this.Controls.Add(this.pnlTopicModify);
            this.MaximizeBox = false;
            this.Name = "frmTopicAdd";
            this.Text = "Yeni mövzu";
            this.Load += new System.EventHandler(this.FrmTopicAdd_Load);
            this.pnlTopicModify.ResumeLayout(false);
            this.pnlTopicModify.PerformLayout();
            this.pnlTopicAdd.ResumeLayout(false);
            this.pnlTopicAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopicModify;
        private System.Windows.Forms.TextBox txtTopicNameModify;
        private System.Windows.Forms.Label lblTopicNameModify;
        private System.Windows.Forms.Panel pnlTopicAdd;
        private System.Windows.Forms.TextBox txtTopicNameAdd;
        private System.Windows.Forms.Label lblTopicNameAdd;
    }
}