namespace Admin
{
    partial class frmGroupAddCandidate
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
            this.chckdlstbxCandidateGroup = new System.Windows.Forms.CheckedListBox();
            this.btnGroupAddCandidate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chckdlstbxCandidateGroup
            // 
            this.chckdlstbxCandidateGroup.CausesValidation = false;
            this.chckdlstbxCandidateGroup.CheckOnClick = true;
            this.chckdlstbxCandidateGroup.FormattingEnabled = true;
            this.chckdlstbxCandidateGroup.Location = new System.Drawing.Point(12, 12);
            this.chckdlstbxCandidateGroup.Name = "chckdlstbxCandidateGroup";
            this.chckdlstbxCandidateGroup.Size = new System.Drawing.Size(371, 409);
            this.chckdlstbxCandidateGroup.TabIndex = 0;
            this.chckdlstbxCandidateGroup.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ChckdlstCandidateGroup_ItemCheck);
            // 
            // btnGroupAddCandidate
            // 
            this.btnGroupAddCandidate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGroupAddCandidate.Location = new System.Drawing.Point(256, 429);
            this.btnGroupAddCandidate.Name = "btnGroupAddCandidate";
            this.btnGroupAddCandidate.Size = new System.Drawing.Size(127, 45);
            this.btnGroupAddCandidate.TabIndex = 1;
            this.btnGroupAddCandidate.Text = "Təsdiq et";
            this.btnGroupAddCandidate.UseVisualStyleBackColor = true;
            this.btnGroupAddCandidate.Click += new System.EventHandler(this.BtnGroupAddCandidate_Click);
            // 
            // frmGroupAddCandidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(400, 486);
            this.Controls.Add(this.btnGroupAddCandidate);
            this.Controls.Add(this.chckdlstbxCandidateGroup);
            this.MaximizeBox = false;
            this.Name = "frmGroupAddCandidate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qrupa namizəd əlavə etmək";
            this.Load += new System.EventHandler(this.FrmGroupAddCandidate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chckdlstbxCandidateGroup;
        private System.Windows.Forms.Button btnGroupAddCandidate;
    }
}