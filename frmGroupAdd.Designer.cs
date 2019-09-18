namespace Admin
{
    partial class frmGroupAdd
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
            System.Windows.Forms.Button btnGroupAddCancel;
            System.Windows.Forms.Button btnGroupAddApply;
            System.Windows.Forms.Button btnGroupModifyApply;
            System.Windows.Forms.Button btnGroupModifyCancel;
            this.pnlGroupAdd = new System.Windows.Forms.Panel();
            this.txtGroupNameAdd = new System.Windows.Forms.TextBox();
            this.lblGroupNameAdd = new System.Windows.Forms.Label();
            this.lblGroupNameModify = new System.Windows.Forms.Label();
            this.lblGroupCnadidateCountModify = new System.Windows.Forms.Label();
            this.txtGroupNameModify = new System.Windows.Forms.TextBox();
            this.txtGroupCandidateCountModify = new System.Windows.Forms.TextBox();
            this.pnlGroupModify = new System.Windows.Forms.Panel();
            this.txtGroupCandidateCountAdd = new System.Windows.Forms.TextBox();
            this.lblGroupCandidateCountAdd = new System.Windows.Forms.Label();
            btnGroupAddCancel = new System.Windows.Forms.Button();
            btnGroupAddApply = new System.Windows.Forms.Button();
            btnGroupModifyApply = new System.Windows.Forms.Button();
            btnGroupModifyCancel = new System.Windows.Forms.Button();
            this.pnlGroupAdd.SuspendLayout();
            this.pnlGroupModify.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGroupAddCancel
            // 
            btnGroupAddCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnGroupAddCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnGroupAddCancel.Location = new System.Drawing.Point(51, 190);
            btnGroupAddCancel.Name = "btnGroupAddCancel";
            btnGroupAddCancel.Size = new System.Drawing.Size(153, 37);
            btnGroupAddCancel.TabIndex = 52;
            btnGroupAddCancel.Text = "İmtina et";
            btnGroupAddCancel.UseVisualStyleBackColor = true;
            btnGroupAddCancel.Click += new System.EventHandler(this.BtnGroupAddCancel_Click);
            // 
            // btnGroupAddApply
            // 
            btnGroupAddApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnGroupAddApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnGroupAddApply.Location = new System.Drawing.Point(237, 190);
            btnGroupAddApply.Name = "btnGroupAddApply";
            btnGroupAddApply.Size = new System.Drawing.Size(153, 37);
            btnGroupAddApply.TabIndex = 50;
            btnGroupAddApply.Text = "Təsdiq et";
            btnGroupAddApply.UseVisualStyleBackColor = true;
            btnGroupAddApply.Click += new System.EventHandler(this.BtnGroupAddApply_Click);
            // 
            // btnGroupModifyApply
            // 
            btnGroupModifyApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnGroupModifyApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnGroupModifyApply.Location = new System.Drawing.Point(234, 191);
            btnGroupModifyApply.Name = "btnGroupModifyApply";
            btnGroupModifyApply.Size = new System.Drawing.Size(153, 37);
            btnGroupModifyApply.TabIndex = 50;
            btnGroupModifyApply.Text = "Düzəlişi təsdiq et";
            btnGroupModifyApply.UseVisualStyleBackColor = true;
            btnGroupModifyApply.Click += new System.EventHandler(this.BtnGroupModifyApply_Click);
            // 
            // btnGroupModifyCancel
            // 
            btnGroupModifyCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnGroupModifyCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnGroupModifyCancel.Location = new System.Drawing.Point(48, 191);
            btnGroupModifyCancel.Name = "btnGroupModifyCancel";
            btnGroupModifyCancel.Size = new System.Drawing.Size(153, 37);
            btnGroupModifyCancel.TabIndex = 52;
            btnGroupModifyCancel.Text = "İmtina et";
            btnGroupModifyCancel.UseVisualStyleBackColor = true;
            btnGroupModifyCancel.Click += new System.EventHandler(this.BtnGroupModifyCancel_Click);
            // 
            // pnlGroupAdd
            // 
            this.pnlGroupAdd.Controls.Add(btnGroupAddCancel);
            this.pnlGroupAdd.Controls.Add(btnGroupAddApply);
            this.pnlGroupAdd.Controls.Add(this.txtGroupCandidateCountAdd);
            this.pnlGroupAdd.Controls.Add(this.txtGroupNameAdd);
            this.pnlGroupAdd.Controls.Add(this.lblGroupCandidateCountAdd);
            this.pnlGroupAdd.Controls.Add(this.lblGroupNameAdd);
            this.pnlGroupAdd.Location = new System.Drawing.Point(1, 4);
            this.pnlGroupAdd.Name = "pnlGroupAdd";
            this.pnlGroupAdd.Size = new System.Drawing.Size(409, 313);
            this.pnlGroupAdd.TabIndex = 39;
            // 
            // txtGroupNameAdd
            // 
            this.txtGroupNameAdd.Location = new System.Drawing.Point(126, 49);
            this.txtGroupNameAdd.Name = "txtGroupNameAdd";
            this.txtGroupNameAdd.Size = new System.Drawing.Size(264, 20);
            this.txtGroupNameAdd.TabIndex = 43;
            // 
            // lblGroupNameAdd
            // 
            this.lblGroupNameAdd.AutoSize = true;
            this.lblGroupNameAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupNameAdd.Location = new System.Drawing.Point(85, 55);
            this.lblGroupNameAdd.Name = "lblGroupNameAdd";
            this.lblGroupNameAdd.Size = new System.Drawing.Size(27, 16);
            this.lblGroupNameAdd.TabIndex = 38;
            this.lblGroupNameAdd.Text = "Ad";
            // 
            // lblGroupNameModify
            // 
            this.lblGroupNameModify.AutoSize = true;
            this.lblGroupNameModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupNameModify.Location = new System.Drawing.Point(85, 57);
            this.lblGroupNameModify.Name = "lblGroupNameModify";
            this.lblGroupNameModify.Size = new System.Drawing.Size(27, 16);
            this.lblGroupNameModify.TabIndex = 38;
            this.lblGroupNameModify.Text = "Ad";
            // 
            // lblGroupCnadidateCountModify
            // 
            this.lblGroupCnadidateCountModify.AutoSize = true;
            this.lblGroupCnadidateCountModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupCnadidateCountModify.Location = new System.Drawing.Point(11, 91);
            this.lblGroupCnadidateCountModify.Name = "lblGroupCnadidateCountModify";
            this.lblGroupCnadidateCountModify.Size = new System.Drawing.Size(102, 16);
            this.lblGroupCnadidateCountModify.TabIndex = 39;
            this.lblGroupCnadidateCountModify.Text = "Namizəd sayı";
            // 
            // txtGroupNameModify
            // 
            this.txtGroupNameModify.Location = new System.Drawing.Point(126, 51);
            this.txtGroupNameModify.Name = "txtGroupNameModify";
            this.txtGroupNameModify.Size = new System.Drawing.Size(264, 20);
            this.txtGroupNameModify.TabIndex = 43;
            this.txtGroupNameModify.TextChanged += new System.EventHandler(this.TxtGroupNameModify_TextChanged);
            // 
            // txtGroupCandidateCountModify
            // 
            this.txtGroupCandidateCountModify.Location = new System.Drawing.Point(126, 90);
            this.txtGroupCandidateCountModify.Name = "txtGroupCandidateCountModify";
            this.txtGroupCandidateCountModify.Size = new System.Drawing.Size(264, 20);
            this.txtGroupCandidateCountModify.TabIndex = 44;
            this.txtGroupCandidateCountModify.TextChanged += new System.EventHandler(this.TxtGroupCandidateCountModify_TextChanged);
            // 
            // pnlGroupModify
            // 
            this.pnlGroupModify.Controls.Add(btnGroupModifyCancel);
            this.pnlGroupModify.Controls.Add(btnGroupModifyApply);
            this.pnlGroupModify.Controls.Add(this.txtGroupCandidateCountModify);
            this.pnlGroupModify.Controls.Add(this.txtGroupNameModify);
            this.pnlGroupModify.Controls.Add(this.lblGroupCnadidateCountModify);
            this.pnlGroupModify.Controls.Add(this.lblGroupNameModify);
            this.pnlGroupModify.Location = new System.Drawing.Point(4, 4);
            this.pnlGroupModify.Name = "pnlGroupModify";
            this.pnlGroupModify.Size = new System.Drawing.Size(406, 313);
            this.pnlGroupModify.TabIndex = 40;
            // 
            // txtGroupCandidateCountAdd
            // 
            this.txtGroupCandidateCountAdd.Location = new System.Drawing.Point(126, 88);
            this.txtGroupCandidateCountAdd.Name = "txtGroupCandidateCountAdd";
            this.txtGroupCandidateCountAdd.Size = new System.Drawing.Size(264, 20);
            this.txtGroupCandidateCountAdd.TabIndex = 44;
            // 
            // lblGroupCandidateCountAdd
            // 
            this.lblGroupCandidateCountAdd.AutoSize = true;
            this.lblGroupCandidateCountAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupCandidateCountAdd.Location = new System.Drawing.Point(18, 89);
            this.lblGroupCandidateCountAdd.Name = "lblGroupCandidateCountAdd";
            this.lblGroupCandidateCountAdd.Size = new System.Drawing.Size(102, 16);
            this.lblGroupCandidateCountAdd.TabIndex = 39;
            this.lblGroupCandidateCountAdd.Text = "Namizəd sayı";
            // 
            // frmGroupAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(411, 319);
            this.Controls.Add(this.pnlGroupModify);
            this.Controls.Add(this.pnlGroupAdd);
            this.MaximizeBox = false;
            this.Name = "frmGroupAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni qrup";
            this.Load += new System.EventHandler(this.FrmGroupAdd_Load);
            this.pnlGroupAdd.ResumeLayout(false);
            this.pnlGroupAdd.PerformLayout();
            this.pnlGroupModify.ResumeLayout(false);
            this.pnlGroupModify.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGroupAdd;
        private System.Windows.Forms.TextBox txtGroupNameAdd;
        private System.Windows.Forms.Label lblGroupNameAdd;
        private System.Windows.Forms.Label lblGroupNameModify;
        private System.Windows.Forms.Label lblGroupCnadidateCountModify;
        private System.Windows.Forms.TextBox txtGroupNameModify;
        private System.Windows.Forms.TextBox txtGroupCandidateCountModify;
        private System.Windows.Forms.Panel pnlGroupModify;
        private System.Windows.Forms.TextBox txtGroupCandidateCountAdd;
        private System.Windows.Forms.Label lblGroupCandidateCountAdd;
    }
}