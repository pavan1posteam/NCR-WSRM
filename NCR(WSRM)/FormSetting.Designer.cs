
namespace NCR_WSRM_
{
    partial class FormSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.btnExit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblDbStatus = new System.Windows.Forms.Label();
            this.btnDbSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblFtpStatus = new System.Windows.Forms.Label();
            this.btnFTPSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFtpLocation = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFtpUserName = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtStoreId = new System.Windows.Forms.TextBox();
            this.txtUpFolder = new System.Windows.Forms.TextBox();
            this.txtFtpPwd = new System.Windows.Forms.TextBox();
            this.txtUploadTimer = new System.Windows.Forms.NumericUpDown();
            this.chkStocked = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblCatStatus = new System.Windows.Forms.Label();
            this.btnCatSave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUploadTimer)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(316, 256);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 55);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(11, 11);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(413, 231);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.lblDbStatus);
            this.tabPage1.Controls.Add(this.btnDbSave);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(405, 205);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Database Setting";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblDbStatus
            // 
            this.lblDbStatus.AutoSize = true;
            this.lblDbStatus.Location = new System.Drawing.Point(4, 115);
            this.lblDbStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDbStatus.Name = "lblDbStatus";
            this.lblDbStatus.Size = new System.Drawing.Size(0, 13);
            this.lblDbStatus.TabIndex = 8;
            // 
            // btnDbSave
            // 
            this.btnDbSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDbSave.Location = new System.Drawing.Point(268, 169);
            this.btnDbSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnDbSave.Name = "btnDbSave";
            this.btnDbSave.Size = new System.Drawing.Size(134, 34);
            this.btnDbSave.TabIndex = 7;
            this.btnDbSave.Text = "Save DB Setting";
            this.btnDbSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDbSave.UseVisualStyleBackColor = true;
            this.btnDbSave.Click += new System.EventHandler(this.btnDbSave_Click_1);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDatabase);
            this.panel1.Controls.Add(this.txtDBServer);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 140);
            this.panel1.TabIndex = 0;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(142, 86);
            this.txtDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(245, 20);
            this.txtDatabase.TabIndex = 8;
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(142, 12);
            this.txtDBServer.Margin = new System.Windows.Forms.Padding(2);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(245, 20);
            this.txtDBServer.TabIndex = 7;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(142, 113);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(163, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Windows Authentication";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(142, 57);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(245, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(142, 37);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(245, 20);
            this.txtUserName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Database";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.lblFtpStatus);
            this.tabPage2.Controls.Add(this.btnFTPSave);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(405, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "FTP";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblFtpStatus
            // 
            this.lblFtpStatus.AutoSize = true;
            this.lblFtpStatus.Location = new System.Drawing.Point(2, 118);
            this.lblFtpStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFtpStatus.Name = "lblFtpStatus";
            this.lblFtpStatus.Size = new System.Drawing.Size(0, 13);
            this.lblFtpStatus.TabIndex = 10;
            // 
            // btnFTPSave
            // 
            this.btnFTPSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFTPSave.Location = new System.Drawing.Point(99, 171);
            this.btnFTPSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnFTPSave.Name = "btnFTPSave";
            this.btnFTPSave.Size = new System.Drawing.Size(81, 26);
            this.btnFTPSave.TabIndex = 9;
            this.btnFTPSave.Text = "Save FTP Setting";
            this.btnFTPSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFTPSave.UseVisualStyleBackColor = true;
            this.btnFTPSave.Click += new System.EventHandler(this.btnFTPSave_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtTax);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtFtpLocation);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtFtpUserName);
            this.panel2.Controls.Add(this.txtServer);
            this.panel2.Controls.Add(this.txtStoreId);
            this.panel2.Controls.Add(this.txtUpFolder);
            this.panel2.Controls.Add(this.txtFtpPwd);
            this.panel2.Controls.Add(this.txtUploadTimer);
            this.panel2.Controls.Add(this.chkStocked);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 155);
            this.panel2.TabIndex = 0;
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(166, 109);
            this.txtTax.Margin = new System.Windows.Forms.Padding(2);
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(128, 20);
            this.txtTax.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 107);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Tax";
            // 
            // txtFtpLocation
            // 
            this.txtFtpLocation.Location = new System.Drawing.Point(166, 92);
            this.txtFtpLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtFtpLocation.Name = "txtFtpLocation";
            this.txtFtpLocation.Size = new System.Drawing.Size(128, 20);
            this.txtFtpLocation.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 90);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Location";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(137, 132);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "(Minus)";
            // 
            // txtFtpUserName
            // 
            this.txtFtpUserName.Location = new System.Drawing.Point(166, 39);
            this.txtFtpUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFtpUserName.Name = "txtFtpUserName";
            this.txtFtpUserName.Size = new System.Drawing.Size(128, 20);
            this.txtFtpUserName.TabIndex = 11;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(166, 21);
            this.txtServer.Margin = new System.Windows.Forms.Padding(2);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(128, 20);
            this.txtServer.TabIndex = 10;
            // 
            // txtStoreId
            // 
            this.txtStoreId.Location = new System.Drawing.Point(166, 4);
            this.txtStoreId.Margin = new System.Windows.Forms.Padding(2);
            this.txtStoreId.Name = "txtStoreId";
            this.txtStoreId.Size = new System.Drawing.Size(128, 20);
            this.txtStoreId.TabIndex = 9;
            // 
            // txtUpFolder
            // 
            this.txtUpFolder.Location = new System.Drawing.Point(166, 74);
            this.txtUpFolder.Margin = new System.Windows.Forms.Padding(2);
            this.txtUpFolder.Name = "txtUpFolder";
            this.txtUpFolder.Size = new System.Drawing.Size(128, 20);
            this.txtUpFolder.TabIndex = 8;
            // 
            // txtFtpPwd
            // 
            this.txtFtpPwd.Location = new System.Drawing.Point(166, 57);
            this.txtFtpPwd.Margin = new System.Windows.Forms.Padding(2);
            this.txtFtpPwd.Name = "txtFtpPwd";
            this.txtFtpPwd.PasswordChar = '*';
            this.txtFtpPwd.Size = new System.Drawing.Size(128, 20);
            this.txtFtpPwd.TabIndex = 7;
            // 
            // txtUploadTimer
            // 
            this.txtUploadTimer.Location = new System.Drawing.Point(98, 132);
            this.txtUploadTimer.Margin = new System.Windows.Forms.Padding(2);
            this.txtUploadTimer.Name = "txtUploadTimer";
            this.txtUploadTimer.Size = new System.Drawing.Size(36, 20);
            this.txtUploadTimer.TabIndex = 1;
            this.txtUploadTimer.ValueChanged += new System.EventHandler(this.txtUploadTimer_ValueChanged);
            // 
            // chkStocked
            // 
            this.chkStocked.AutoSize = true;
            this.chkStocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkStocked.Checked = true;
            this.chkStocked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStocked.Location = new System.Drawing.Point(249, 132);
            this.chkStocked.Margin = new System.Windows.Forms.Padding(2);
            this.chkStocked.Name = "chkStocked";
            this.chkStocked.Size = new System.Drawing.Size(130, 17);
            this.chkStocked.TabIndex = 6;
            this.chkStocked.Text = "Stocked Item Only";
            this.chkStocked.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 135);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Upload Time Interval";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 73);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Upload Folder FTP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 57);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 40);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "User Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Server";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = " Store ID";
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.lblCatStatus);
            this.tabPage3.Controls.Add(this.btnCatSave);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(405, 205);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Categories";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblCatStatus
            // 
            this.lblCatStatus.AutoSize = true;
            this.lblCatStatus.Location = new System.Drawing.Point(2, 121);
            this.lblCatStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCatStatus.Name = "lblCatStatus";
            this.lblCatStatus.Size = new System.Drawing.Size(0, 13);
            this.lblCatStatus.TabIndex = 2;
            // 
            // btnCatSave
            // 
            this.btnCatSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCatSave.Location = new System.Drawing.Point(238, 167);
            this.btnCatSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnCatSave.Name = "btnCatSave";
            this.btnCatSave.Size = new System.Drawing.Size(142, 36);
            this.btnCatSave.TabIndex = 1;
            this.btnCatSave.Text = "Save Categories";
            this.btnCatSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCatSave.UseVisualStyleBackColor = true;
            this.btnCatSave.Click += new System.EventHandler(this.btnCatSave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.CatID,
            this.Description});
            this.dataGridView1.Location = new System.Drawing.Point(14, 8);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(368, 157);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.VirtualMode = true;
            // 
            // Select
            // 
            this.Select.FalseValue = "0";
            this.Select.HeaderText = "Select";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            this.Select.TrueValue = "1";
            this.Select.Width = 125;
            // 
            // CatID
            // 
            this.CatID.HeaderText = "CatID";
            this.CatID.MinimumWidth = 6;
            this.CatID.Name = "CatID";
            this.CatID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CatID.Width = 125;
            // 
            // Description
            // 
            this.Description.HeaderText = "Name";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Description.Width = 125;
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 323);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSetting";
            this.Text = "FormSetting";
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUploadTimer)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblDbStatus;
        private System.Windows.Forms.Button btnDbSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtDBServer;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblFtpStatus;
        private System.Windows.Forms.Button btnFTPSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtFtpLocation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFtpUserName;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtStoreId;
        private System.Windows.Forms.TextBox txtUpFolder;
        private System.Windows.Forms.TextBox txtFtpPwd;
        private System.Windows.Forms.NumericUpDown txtUploadTimer;
        private System.Windows.Forms.CheckBox chkStocked;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblCatStatus;
        private System.Windows.Forms.Button btnCatSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}