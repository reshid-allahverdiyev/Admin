namespace Admin
{
    partial class frmUserAdd
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
            System.Windows.Forms.Button btnUserAddCancel;
            System.Windows.Forms.Button btnUserAddApply;
            System.Windows.Forms.Button btnUserModifyCancel;
            System.Windows.Forms.Button btnUserModifyApply;
            this.pnlUserAdd = new System.Windows.Forms.Panel();
            this.chckBxUserPasswordAdd = new System.Windows.Forms.CheckBox();
            this.lblPasswordRepeatAdd = new System.Windows.Forms.Label();
            this.txtUserPasswordAdd1 = new System.Windows.Forms.TextBox();
            this.dateUserBirthdayAdd = new System.Windows.Forms.DateTimePicker();
            this.txtUserPasswordAdd = new System.Windows.Forms.TextBox();
            this.txtUserPinAdd = new System.Windows.Forms.TextBox();
            this.txtUserSurnameAdd = new System.Windows.Forms.TextBox();
            this.txtUserNameAdd = new System.Windows.Forms.TextBox();
            this.lblUserPasswordAdd = new System.Windows.Forms.Label();
            this.lblUserPinAdd = new System.Windows.Forms.Label();
            this.lblUserBirthdayAdd = new System.Windows.Forms.Label();
            this.lblUserSurnameAdd = new System.Windows.Forms.Label();
            this.lblUserNameAdd = new System.Windows.Forms.Label();
            this.pnlUserModify = new System.Windows.Forms.Panel();
            this.chckBxUserPasswordModify1 = new System.Windows.Forms.CheckBox();
            this.chckBxUserPasswordModify = new System.Windows.Forms.CheckBox();
            this.lblPasswordRepeatModify = new System.Windows.Forms.Label();
            this.txtUserPasswordModify1 = new System.Windows.Forms.TextBox();
            this.dateUserBirthdayModify = new System.Windows.Forms.DateTimePicker();
            this.txtUserPasswordModify = new System.Windows.Forms.TextBox();
            this.txtUserPinModify = new System.Windows.Forms.TextBox();
            this.txtUserSurnameModify = new System.Windows.Forms.TextBox();
            this.txtUserNameModify = new System.Windows.Forms.TextBox();
            this.lblUserPasswordModify = new System.Windows.Forms.Label();
            this.lblUserPinModify = new System.Windows.Forms.Label();
            this.lblUserBirthdayModify = new System.Windows.Forms.Label();
            this.lblUserSurnameModify = new System.Windows.Forms.Label();
            this.lblUserNameModify = new System.Windows.Forms.Label();
            this.txtUserUsernameAdd = new System.Windows.Forms.TextBox();
            this.lblUserUsernameAdd = new System.Windows.Forms.Label();
            this.txtUserUsernameModify = new System.Windows.Forms.TextBox();
            this.lblUserUsernameModify = new System.Windows.Forms.Label();
            btnUserAddCancel = new System.Windows.Forms.Button();
            btnUserAddApply = new System.Windows.Forms.Button();
            btnUserModifyCancel = new System.Windows.Forms.Button();
            btnUserModifyApply = new System.Windows.Forms.Button();
            this.pnlUserAdd.SuspendLayout();
            this.pnlUserModify.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUserAdd
            // 
            this.pnlUserAdd.Controls.Add(this.txtUserUsernameAdd);
            this.pnlUserAdd.Controls.Add(this.lblUserUsernameAdd);
            this.pnlUserAdd.Controls.Add(btnUserAddCancel);
            this.pnlUserAdd.Controls.Add(this.chckBxUserPasswordAdd);
            this.pnlUserAdd.Controls.Add(btnUserAddApply);
            this.pnlUserAdd.Controls.Add(this.lblPasswordRepeatAdd);
            this.pnlUserAdd.Controls.Add(this.txtUserPasswordAdd1);
            this.pnlUserAdd.Controls.Add(this.dateUserBirthdayAdd);
            this.pnlUserAdd.Controls.Add(this.txtUserPasswordAdd);
            this.pnlUserAdd.Controls.Add(this.txtUserPinAdd);
            this.pnlUserAdd.Controls.Add(this.txtUserSurnameAdd);
            this.pnlUserAdd.Controls.Add(this.txtUserNameAdd);
            this.pnlUserAdd.Controls.Add(this.lblUserPasswordAdd);
            this.pnlUserAdd.Controls.Add(this.lblUserPinAdd);
            this.pnlUserAdd.Controls.Add(this.lblUserBirthdayAdd);
            this.pnlUserAdd.Controls.Add(this.lblUserSurnameAdd);
            this.pnlUserAdd.Controls.Add(this.lblUserNameAdd);
            this.pnlUserAdd.Location = new System.Drawing.Point(10, 10);
            this.pnlUserAdd.Name = "pnlUserAdd";
            this.pnlUserAdd.Size = new System.Drawing.Size(409, 384);
            this.pnlUserAdd.TabIndex = 39;
            // 
            // btnUserAddCancel
            // 
            btnUserAddCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnUserAddCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnUserAddCancel.Location = new System.Drawing.Point(51, 335);
            btnUserAddCancel.Name = "btnUserAddCancel";
            btnUserAddCancel.Size = new System.Drawing.Size(153, 37);
            btnUserAddCancel.TabIndex = 52;
            btnUserAddCancel.Text = "İmtina et";
            btnUserAddCancel.UseVisualStyleBackColor = true;
            btnUserAddCancel.Click += new System.EventHandler(this.BtnUserAddCancel_Click);
            // 
            // chckBxUserPasswordAdd
            // 
            this.chckBxUserPasswordAdd.AutoSize = true;
            this.chckBxUserPasswordAdd.Location = new System.Drawing.Point(249, 210);
            this.chckBxUserPasswordAdd.Name = "chckBxUserPasswordAdd";
            this.chckBxUserPasswordAdd.Size = new System.Drawing.Size(141, 17);
            this.chckBxUserPasswordAdd.TabIndex = 51;
            this.chckBxUserPasswordAdd.Text = "Şifrə əl ilə daxil olunsun?";
            this.chckBxUserPasswordAdd.UseVisualStyleBackColor = true;
            this.chckBxUserPasswordAdd.CheckedChanged += new System.EventHandler(this.ChckBxUserPasswordAdd_CheckedChanged);
            // 
            // btnUserAddApply
            // 
            btnUserAddApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnUserAddApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnUserAddApply.Location = new System.Drawing.Point(237, 335);
            btnUserAddApply.Name = "btnUserAddApply";
            btnUserAddApply.Size = new System.Drawing.Size(153, 37);
            btnUserAddApply.TabIndex = 50;
            btnUserAddApply.Text = "Təsdiq et";
            btnUserAddApply.UseVisualStyleBackColor = true;
            btnUserAddApply.Click += new System.EventHandler(this.BtnUserAddApply_Click);
            // 
            // lblPasswordRepeatAdd
            // 
            this.lblPasswordRepeatAdd.AutoSize = true;
            this.lblPasswordRepeatAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordRepeatAdd.Location = new System.Drawing.Point(123, 296);
            this.lblPasswordRepeatAdd.Name = "lblPasswordRepeatAdd";
            this.lblPasswordRepeatAdd.Size = new System.Drawing.Size(142, 13);
            this.lblPasswordRepeatAdd.TabIndex = 49;
            this.lblPasswordRepeatAdd.Text = "Şifrəni təkrar daxil edin!";
            // 
            // txtUserPasswordAdd1
            // 
            this.txtUserPasswordAdd1.Enabled = false;
            this.txtUserPasswordAdd1.Location = new System.Drawing.Point(126, 273);
            this.txtUserPasswordAdd1.Name = "txtUserPasswordAdd1";
            this.txtUserPasswordAdd1.PasswordChar = '*';
            this.txtUserPasswordAdd1.Size = new System.Drawing.Size(264, 20);
            this.txtUserPasswordAdd1.TabIndex = 48;
            // 
            // dateUserBirthdayAdd
            // 
            this.dateUserBirthdayAdd.Location = new System.Drawing.Point(126, 89);
            this.dateUserBirthdayAdd.Name = "dateUserBirthdayAdd";
            this.dateUserBirthdayAdd.Size = new System.Drawing.Size(264, 20);
            this.dateUserBirthdayAdd.TabIndex = 47;
            // 
            // txtUserPasswordAdd
            // 
            this.txtUserPasswordAdd.Enabled = false;
            this.txtUserPasswordAdd.Location = new System.Drawing.Point(126, 236);
            this.txtUserPasswordAdd.Name = "txtUserPasswordAdd";
            this.txtUserPasswordAdd.Size = new System.Drawing.Size(264, 20);
            this.txtUserPasswordAdd.TabIndex = 46;
            // 
            // txtUserPinAdd
            // 
            this.txtUserPinAdd.Location = new System.Drawing.Point(126, 130);
            this.txtUserPinAdd.Name = "txtUserPinAdd";
            this.txtUserPinAdd.Size = new System.Drawing.Size(264, 20);
            this.txtUserPinAdd.TabIndex = 45;
            // 
            // txtUserSurnameAdd
            // 
            this.txtUserSurnameAdd.Location = new System.Drawing.Point(126, 52);
            this.txtUserSurnameAdd.Name = "txtUserSurnameAdd";
            this.txtUserSurnameAdd.Size = new System.Drawing.Size(264, 20);
            this.txtUserSurnameAdd.TabIndex = 44;
            // 
            // txtUserNameAdd
            // 
            this.txtUserNameAdd.Location = new System.Drawing.Point(126, 13);
            this.txtUserNameAdd.Name = "txtUserNameAdd";
            this.txtUserNameAdd.Size = new System.Drawing.Size(264, 20);
            this.txtUserNameAdd.TabIndex = 43;
            // 
            // lblUserPasswordAdd
            // 
            this.lblUserPasswordAdd.AutoSize = true;
            this.lblUserPasswordAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserPasswordAdd.Location = new System.Drawing.Point(69, 239);
            this.lblUserPasswordAdd.Name = "lblUserPasswordAdd";
            this.lblUserPasswordAdd.Size = new System.Drawing.Size(40, 16);
            this.lblUserPasswordAdd.TabIndex = 42;
            this.lblUserPasswordAdd.Text = "Şifrə";
            // 
            // lblUserPinAdd
            // 
            this.lblUserPinAdd.AutoSize = true;
            this.lblUserPinAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserPinAdd.Location = new System.Drawing.Point(78, 132);
            this.lblUserPinAdd.Name = "lblUserPinAdd";
            this.lblUserPinAdd.Size = new System.Drawing.Size(30, 16);
            this.lblUserPinAdd.TabIndex = 41;
            this.lblUserPinAdd.Text = "Pin";
            // 
            // lblUserBirthdayAdd
            // 
            this.lblUserBirthdayAdd.AutoSize = true;
            this.lblUserBirthdayAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserBirthdayAdd.Location = new System.Drawing.Point(18, 93);
            this.lblUserBirthdayAdd.Name = "lblUserBirthdayAdd";
            this.lblUserBirthdayAdd.Size = new System.Drawing.Size(94, 16);
            this.lblUserBirthdayAdd.TabIndex = 40;
            this.lblUserBirthdayAdd.Text = "Doğum tarixi";
            // 
            // lblUserSurnameAdd
            // 
            this.lblUserSurnameAdd.AutoSize = true;
            this.lblUserSurnameAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserSurnameAdd.Location = new System.Drawing.Point(66, 59);
            this.lblUserSurnameAdd.Name = "lblUserSurnameAdd";
            this.lblUserSurnameAdd.Size = new System.Drawing.Size(53, 16);
            this.lblUserSurnameAdd.TabIndex = 39;
            this.lblUserSurnameAdd.Text = "Soyad";
            // 
            // lblUserNameAdd
            // 
            this.lblUserNameAdd.AutoSize = true;
            this.lblUserNameAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNameAdd.Location = new System.Drawing.Point(85, 19);
            this.lblUserNameAdd.Name = "lblUserNameAdd";
            this.lblUserNameAdd.Size = new System.Drawing.Size(27, 16);
            this.lblUserNameAdd.TabIndex = 38;
            this.lblUserNameAdd.Text = "Ad";
            // 
            // pnlUserModify
            // 
            this.pnlUserModify.Controls.Add(this.txtUserUsernameModify);
            this.pnlUserModify.Controls.Add(this.lblUserUsernameModify);
            this.pnlUserModify.Controls.Add(this.chckBxUserPasswordModify1);
            this.pnlUserModify.Controls.Add(btnUserModifyCancel);
            this.pnlUserModify.Controls.Add(this.chckBxUserPasswordModify);
            this.pnlUserModify.Controls.Add(btnUserModifyApply);
            this.pnlUserModify.Controls.Add(this.lblPasswordRepeatModify);
            this.pnlUserModify.Controls.Add(this.txtUserPasswordModify1);
            this.pnlUserModify.Controls.Add(this.dateUserBirthdayModify);
            this.pnlUserModify.Controls.Add(this.txtUserPasswordModify);
            this.pnlUserModify.Controls.Add(this.txtUserPinModify);
            this.pnlUserModify.Controls.Add(this.txtUserSurnameModify);
            this.pnlUserModify.Controls.Add(this.txtUserNameModify);
            this.pnlUserModify.Controls.Add(this.lblUserPasswordModify);
            this.pnlUserModify.Controls.Add(this.lblUserPinModify);
            this.pnlUserModify.Controls.Add(this.lblUserBirthdayModify);
            this.pnlUserModify.Controls.Add(this.lblUserSurnameModify);
            this.pnlUserModify.Controls.Add(this.lblUserNameModify);
            this.pnlUserModify.Location = new System.Drawing.Point(10, 10);
            this.pnlUserModify.Name = "pnlUserModify";
            this.pnlUserModify.Size = new System.Drawing.Size(406, 384);
            this.pnlUserModify.TabIndex = 40;
            // 
            // chckBxUserPasswordModify1
            // 
            this.chckBxUserPasswordModify1.AutoSize = true;
            this.chckBxUserPasswordModify1.Location = new System.Drawing.Point(36, 216);
            this.chckBxUserPasswordModify1.Name = "chckBxUserPasswordModify1";
            this.chckBxUserPasswordModify1.Size = new System.Drawing.Size(160, 17);
            this.chckBxUserPasswordModify1.TabIndex = 53;
            this.chckBxUserPasswordModify1.Text = "Şifrəni yeniləmək istəyirsiniz?";
            this.chckBxUserPasswordModify1.UseVisualStyleBackColor = true;
            this.chckBxUserPasswordModify1.CheckedChanged += new System.EventHandler(this.ChckBxUserPasswordModify1_CheckedChanged);
            // 
            // btnUserModifyCancel
            // 
            btnUserModifyCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnUserModifyCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnUserModifyCancel.Location = new System.Drawing.Point(48, 335);
            btnUserModifyCancel.Name = "btnUserModifyCancel";
            btnUserModifyCancel.Size = new System.Drawing.Size(153, 37);
            btnUserModifyCancel.TabIndex = 52;
            btnUserModifyCancel.Text = "İmtina et";
            btnUserModifyCancel.UseVisualStyleBackColor = true;
            btnUserModifyCancel.Click += new System.EventHandler(this.BtnUserModifyCancel_Click);
            // 
            // chckBxUserPasswordModify
            // 
            this.chckBxUserPasswordModify.AutoSize = true;
            this.chckBxUserPasswordModify.Location = new System.Drawing.Point(249, 217);
            this.chckBxUserPasswordModify.Name = "chckBxUserPasswordModify";
            this.chckBxUserPasswordModify.Size = new System.Drawing.Size(141, 17);
            this.chckBxUserPasswordModify.TabIndex = 51;
            this.chckBxUserPasswordModify.Text = "Şifrə əl ilə daxil olunsun?";
            this.chckBxUserPasswordModify.UseVisualStyleBackColor = true;
            this.chckBxUserPasswordModify.CheckedChanged += new System.EventHandler(this.ChckBxUserPasswordModify_CheckedChanged);
            // 
            // btnUserModifyApply
            // 
            btnUserModifyApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnUserModifyApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnUserModifyApply.Location = new System.Drawing.Point(234, 335);
            btnUserModifyApply.Name = "btnUserModifyApply";
            btnUserModifyApply.Size = new System.Drawing.Size(153, 37);
            btnUserModifyApply.TabIndex = 50;
            btnUserModifyApply.Text = "Düzəlişi təsdiq et";
            btnUserModifyApply.UseVisualStyleBackColor = true;
            btnUserModifyApply.Click += new System.EventHandler(this.BtnUserModifyApply_Click);
            // 
            // lblPasswordRepeatModify
            // 
            this.lblPasswordRepeatModify.AutoSize = true;
            this.lblPasswordRepeatModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordRepeatModify.Location = new System.Drawing.Point(123, 303);
            this.lblPasswordRepeatModify.Name = "lblPasswordRepeatModify";
            this.lblPasswordRepeatModify.Size = new System.Drawing.Size(142, 13);
            this.lblPasswordRepeatModify.TabIndex = 49;
            this.lblPasswordRepeatModify.Text = "Şifrəni təkrar daxil edin!";
            // 
            // txtUserPasswordModify1
            // 
            this.txtUserPasswordModify1.Enabled = false;
            this.txtUserPasswordModify1.Location = new System.Drawing.Point(126, 280);
            this.txtUserPasswordModify1.Name = "txtUserPasswordModify1";
            this.txtUserPasswordModify1.PasswordChar = '*';
            this.txtUserPasswordModify1.Size = new System.Drawing.Size(264, 20);
            this.txtUserPasswordModify1.TabIndex = 48;
            this.txtUserPasswordModify1.TextChanged += new System.EventHandler(this.TxtUserPasswordModify1_TextChanged);
            // 
            // dateUserBirthdayModify
            // 
            this.dateUserBirthdayModify.Location = new System.Drawing.Point(126, 89);
            this.dateUserBirthdayModify.Name = "dateUserBirthdayModify";
            this.dateUserBirthdayModify.Size = new System.Drawing.Size(264, 20);
            this.dateUserBirthdayModify.TabIndex = 47;
            this.dateUserBirthdayModify.ValueChanged += new System.EventHandler(this.DateUserBirthdayModify_ValueChanged);
            // 
            // txtUserPasswordModify
            // 
            this.txtUserPasswordModify.Enabled = false;
            this.txtUserPasswordModify.Location = new System.Drawing.Point(126, 243);
            this.txtUserPasswordModify.Name = "txtUserPasswordModify";
            this.txtUserPasswordModify.Size = new System.Drawing.Size(264, 20);
            this.txtUserPasswordModify.TabIndex = 46;
            this.txtUserPasswordModify.TextChanged += new System.EventHandler(this.TxtUserPasswordModify_TextChanged);
            // 
            // txtUserPinModify
            // 
            this.txtUserPinModify.Location = new System.Drawing.Point(126, 130);
            this.txtUserPinModify.Name = "txtUserPinModify";
            this.txtUserPinModify.Size = new System.Drawing.Size(264, 20);
            this.txtUserPinModify.TabIndex = 45;
            this.txtUserPinModify.TextChanged += new System.EventHandler(this.TxtUserPinModify_TextChanged);
            // 
            // txtUserSurnameModify
            // 
            this.txtUserSurnameModify.Location = new System.Drawing.Point(126, 52);
            this.txtUserSurnameModify.Name = "txtUserSurnameModify";
            this.txtUserSurnameModify.Size = new System.Drawing.Size(264, 20);
            this.txtUserSurnameModify.TabIndex = 44;
            this.txtUserSurnameModify.TextChanged += new System.EventHandler(this.TxtUserSurnameModify_TextChanged);
            // 
            // txtUserNameModify
            // 
            this.txtUserNameModify.Location = new System.Drawing.Point(126, 13);
            this.txtUserNameModify.Name = "txtUserNameModify";
            this.txtUserNameModify.Size = new System.Drawing.Size(264, 20);
            this.txtUserNameModify.TabIndex = 43;
            this.txtUserNameModify.TextChanged += new System.EventHandler(this.TxtUserNameModify_TextChanged);
            // 
            // lblUserPasswordModify
            // 
            this.lblUserPasswordModify.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock;
            this.lblUserPasswordModify.AutoSize = true;
            this.lblUserPasswordModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserPasswordModify.Location = new System.Drawing.Point(69, 246);
            this.lblUserPasswordModify.Name = "lblUserPasswordModify";
            this.lblUserPasswordModify.Size = new System.Drawing.Size(40, 16);
            this.lblUserPasswordModify.TabIndex = 42;
            this.lblUserPasswordModify.Text = "Şifrə";
            // 
            // lblUserPinModify
            // 
            this.lblUserPinModify.AutoSize = true;
            this.lblUserPinModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserPinModify.Location = new System.Drawing.Point(78, 132);
            this.lblUserPinModify.Name = "lblUserPinModify";
            this.lblUserPinModify.Size = new System.Drawing.Size(30, 16);
            this.lblUserPinModify.TabIndex = 41;
            this.lblUserPinModify.Text = "Pin";
            // 
            // lblUserBirthdayModify
            // 
            this.lblUserBirthdayModify.AutoSize = true;
            this.lblUserBirthdayModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserBirthdayModify.Location = new System.Drawing.Point(18, 93);
            this.lblUserBirthdayModify.Name = "lblUserBirthdayModify";
            this.lblUserBirthdayModify.Size = new System.Drawing.Size(94, 16);
            this.lblUserBirthdayModify.TabIndex = 40;
            this.lblUserBirthdayModify.Text = "Doğum tarixi";
            // 
            // lblUserSurnameModify
            // 
            this.lblUserSurnameModify.AutoSize = true;
            this.lblUserSurnameModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserSurnameModify.Location = new System.Drawing.Point(66, 59);
            this.lblUserSurnameModify.Name = "lblUserSurnameModify";
            this.lblUserSurnameModify.Size = new System.Drawing.Size(53, 16);
            this.lblUserSurnameModify.TabIndex = 39;
            this.lblUserSurnameModify.Text = "Soyad";
            // 
            // lblUserNameModify
            // 
            this.lblUserNameModify.AutoSize = true;
            this.lblUserNameModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNameModify.Location = new System.Drawing.Point(85, 19);
            this.lblUserNameModify.Name = "lblUserNameModify";
            this.lblUserNameModify.Size = new System.Drawing.Size(27, 16);
            this.lblUserNameModify.TabIndex = 38;
            this.lblUserNameModify.Text = "Ad";
            // 
            // txtUserUsernameAdd
            // 
            this.txtUserUsernameAdd.Location = new System.Drawing.Point(126, 168);
            this.txtUserUsernameAdd.Name = "txtUserUsernameAdd";
            this.txtUserUsernameAdd.Size = new System.Drawing.Size(264, 20);
            this.txtUserUsernameAdd.TabIndex = 54;
            // 
            // lblUserUsernameAdd
            // 
            this.lblUserUsernameAdd.AutoSize = true;
            this.lblUserUsernameAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserUsernameAdd.Location = new System.Drawing.Point(11, 168);
            this.lblUserUsernameAdd.Name = "lblUserUsernameAdd";
            this.lblUserUsernameAdd.Size = new System.Drawing.Size(97, 16);
            this.lblUserUsernameAdd.TabIndex = 53;
            this.lblUserUsernameAdd.Text = "İstidafəçi adı";
            // 
            // txtUserUsernameModify
            // 
            this.txtUserUsernameModify.Location = new System.Drawing.Point(126, 169);
            this.txtUserUsernameModify.Name = "txtUserUsernameModify";
            this.txtUserUsernameModify.Size = new System.Drawing.Size(264, 20);
            this.txtUserUsernameModify.TabIndex = 56;
            this.txtUserUsernameModify.TextChanged += new System.EventHandler(this.TxtUserUsernameModify_TextChanged);
            // 
            // lblUserUsernameModify
            // 
            this.lblUserUsernameModify.AutoSize = true;
            this.lblUserUsernameModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserUsernameModify.Location = new System.Drawing.Point(11, 169);
            this.lblUserUsernameModify.Name = "lblUserUsernameModify";
            this.lblUserUsernameModify.Size = new System.Drawing.Size(97, 16);
            this.lblUserUsernameModify.TabIndex = 55;
            this.lblUserUsernameModify.Text = "İstidafəçi adı";
            // 
            // frmUserAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(424, 399);
            this.Controls.Add(this.pnlUserModify);
            this.Controls.Add(this.pnlUserAdd);
            this.MaximizeBox = false;
            this.Name = "frmUserAdd";
            this.Text = "Yeni istifadəçi";
            this.Load += new System.EventHandler(this.FrmUserAdd_Load);
            this.pnlUserAdd.ResumeLayout(false);
            this.pnlUserAdd.PerformLayout();
            this.pnlUserModify.ResumeLayout(false);
            this.pnlUserModify.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUserAdd;
        private System.Windows.Forms.CheckBox chckBxUserPasswordAdd;
        private System.Windows.Forms.Label lblPasswordRepeatAdd;
        private System.Windows.Forms.TextBox txtUserPasswordAdd1;
        private System.Windows.Forms.DateTimePicker dateUserBirthdayAdd;
        private System.Windows.Forms.TextBox txtUserPasswordAdd;
        private System.Windows.Forms.TextBox txtUserPinAdd;
        private System.Windows.Forms.TextBox txtUserSurnameAdd;
        private System.Windows.Forms.TextBox txtUserNameAdd;
        private System.Windows.Forms.Label lblUserPasswordAdd;
        private System.Windows.Forms.Label lblUserPinAdd;
        private System.Windows.Forms.Label lblUserBirthdayAdd;
        private System.Windows.Forms.Label lblUserSurnameAdd;
        private System.Windows.Forms.Label lblUserNameAdd;
        private System.Windows.Forms.Panel pnlUserModify;
        private System.Windows.Forms.CheckBox chckBxUserPasswordModify1;
        private System.Windows.Forms.CheckBox chckBxUserPasswordModify;
        private System.Windows.Forms.Label lblPasswordRepeatModify;
        private System.Windows.Forms.TextBox txtUserPasswordModify1;
        private System.Windows.Forms.DateTimePicker dateUserBirthdayModify;
        private System.Windows.Forms.TextBox txtUserPasswordModify;
        private System.Windows.Forms.TextBox txtUserPinModify;
        private System.Windows.Forms.TextBox txtUserSurnameModify;
        private System.Windows.Forms.TextBox txtUserNameModify;
        private System.Windows.Forms.Label lblUserPasswordModify;
        private System.Windows.Forms.Label lblUserPinModify;
        private System.Windows.Forms.Label lblUserBirthdayModify;
        private System.Windows.Forms.Label lblUserSurnameModify;
        private System.Windows.Forms.Label lblUserNameModify;
        private System.Windows.Forms.TextBox txtUserUsernameAdd;
        private System.Windows.Forms.Label lblUserUsernameAdd;
        private System.Windows.Forms.TextBox txtUserUsernameModify;
        private System.Windows.Forms.Label lblUserUsernameModify;
    }
}