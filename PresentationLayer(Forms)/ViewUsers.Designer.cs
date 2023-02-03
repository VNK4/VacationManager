namespace PresentationLayer_Forms_
{
    partial class ViewUsers
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vacationsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.normalizedUserNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.normalizedEmailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailConfirmedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.passwordHashDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.securityStampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concurrencyStampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumberConfirmedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.twoFactorEnabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lockoutEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lockoutEnabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.accessFailedCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.firstNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(52, 177);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 28);
            this.comboBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(52, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "filter";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(52, 327);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 29);
            this.button3.TabIndex = 4;
            this.button3.Text = "view user information";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(52, 372);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 29);
            this.button4.TabIndex = 5;
            this.button4.Text = "create user";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.teamDataGridViewTextBoxColumn,
            this.vacationsDataGridViewTextBoxColumn,
            this.roleDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.normalizedUserNameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.normalizedEmailDataGridViewTextBoxColumn,
            this.emailConfirmedDataGridViewCheckBoxColumn,
            this.passwordHashDataGridViewTextBoxColumn,
            this.securityStampDataGridViewTextBoxColumn,
            this.concurrencyStampDataGridViewTextBoxColumn,
            this.phoneNumberDataGridViewTextBoxColumn,
            this.phoneNumberConfirmedDataGridViewCheckBoxColumn,
            this.twoFactorEnabledDataGridViewCheckBoxColumn,
            this.lockoutEndDataGridViewTextBoxColumn,
            this.lockoutEnabledDataGridViewCheckBoxColumn,
            this.accessFailedCountDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.userBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(293, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1049, 188);
            this.dataGridView1.TabIndex = 6;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            this.firstNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            this.lastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            this.lastNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // teamDataGridViewTextBoxColumn
            // 
            this.teamDataGridViewTextBoxColumn.DataPropertyName = "Team";
            this.teamDataGridViewTextBoxColumn.HeaderText = "Team";
            this.teamDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.teamDataGridViewTextBoxColumn.Name = "teamDataGridViewTextBoxColumn";
            this.teamDataGridViewTextBoxColumn.Width = 125;
            // 
            // vacationsDataGridViewTextBoxColumn
            // 
            this.vacationsDataGridViewTextBoxColumn.DataPropertyName = "Vacations";
            this.vacationsDataGridViewTextBoxColumn.HeaderText = "Vacations";
            this.vacationsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.vacationsDataGridViewTextBoxColumn.Name = "vacationsDataGridViewTextBoxColumn";
            this.vacationsDataGridViewTextBoxColumn.Width = 125;
            // 
            // roleDataGridViewTextBoxColumn
            // 
            this.roleDataGridViewTextBoxColumn.DataPropertyName = "Role";
            this.roleDataGridViewTextBoxColumn.HeaderText = "Role";
            this.roleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.roleDataGridViewTextBoxColumn.Name = "roleDataGridViewTextBoxColumn";
            this.roleDataGridViewTextBoxColumn.Width = 125;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // normalizedUserNameDataGridViewTextBoxColumn
            // 
            this.normalizedUserNameDataGridViewTextBoxColumn.DataPropertyName = "NormalizedUserName";
            this.normalizedUserNameDataGridViewTextBoxColumn.HeaderText = "NormalizedUserName";
            this.normalizedUserNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.normalizedUserNameDataGridViewTextBoxColumn.Name = "normalizedUserNameDataGridViewTextBoxColumn";
            this.normalizedUserNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // normalizedEmailDataGridViewTextBoxColumn
            // 
            this.normalizedEmailDataGridViewTextBoxColumn.DataPropertyName = "NormalizedEmail";
            this.normalizedEmailDataGridViewTextBoxColumn.HeaderText = "NormalizedEmail";
            this.normalizedEmailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.normalizedEmailDataGridViewTextBoxColumn.Name = "normalizedEmailDataGridViewTextBoxColumn";
            this.normalizedEmailDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailConfirmedDataGridViewCheckBoxColumn
            // 
            this.emailConfirmedDataGridViewCheckBoxColumn.DataPropertyName = "EmailConfirmed";
            this.emailConfirmedDataGridViewCheckBoxColumn.HeaderText = "EmailConfirmed";
            this.emailConfirmedDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.emailConfirmedDataGridViewCheckBoxColumn.Name = "emailConfirmedDataGridViewCheckBoxColumn";
            this.emailConfirmedDataGridViewCheckBoxColumn.Width = 125;
            // 
            // passwordHashDataGridViewTextBoxColumn
            // 
            this.passwordHashDataGridViewTextBoxColumn.DataPropertyName = "PasswordHash";
            this.passwordHashDataGridViewTextBoxColumn.HeaderText = "PasswordHash";
            this.passwordHashDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.passwordHashDataGridViewTextBoxColumn.Name = "passwordHashDataGridViewTextBoxColumn";
            this.passwordHashDataGridViewTextBoxColumn.Width = 125;
            // 
            // securityStampDataGridViewTextBoxColumn
            // 
            this.securityStampDataGridViewTextBoxColumn.DataPropertyName = "SecurityStamp";
            this.securityStampDataGridViewTextBoxColumn.HeaderText = "SecurityStamp";
            this.securityStampDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.securityStampDataGridViewTextBoxColumn.Name = "securityStampDataGridViewTextBoxColumn";
            this.securityStampDataGridViewTextBoxColumn.Width = 125;
            // 
            // concurrencyStampDataGridViewTextBoxColumn
            // 
            this.concurrencyStampDataGridViewTextBoxColumn.DataPropertyName = "ConcurrencyStamp";
            this.concurrencyStampDataGridViewTextBoxColumn.HeaderText = "ConcurrencyStamp";
            this.concurrencyStampDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.concurrencyStampDataGridViewTextBoxColumn.Name = "concurrencyStampDataGridViewTextBoxColumn";
            this.concurrencyStampDataGridViewTextBoxColumn.Width = 125;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            this.phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            this.phoneNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // phoneNumberConfirmedDataGridViewCheckBoxColumn
            // 
            this.phoneNumberConfirmedDataGridViewCheckBoxColumn.DataPropertyName = "PhoneNumberConfirmed";
            this.phoneNumberConfirmedDataGridViewCheckBoxColumn.HeaderText = "PhoneNumberConfirmed";
            this.phoneNumberConfirmedDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.phoneNumberConfirmedDataGridViewCheckBoxColumn.Name = "phoneNumberConfirmedDataGridViewCheckBoxColumn";
            this.phoneNumberConfirmedDataGridViewCheckBoxColumn.Width = 125;
            // 
            // twoFactorEnabledDataGridViewCheckBoxColumn
            // 
            this.twoFactorEnabledDataGridViewCheckBoxColumn.DataPropertyName = "TwoFactorEnabled";
            this.twoFactorEnabledDataGridViewCheckBoxColumn.HeaderText = "TwoFactorEnabled";
            this.twoFactorEnabledDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.twoFactorEnabledDataGridViewCheckBoxColumn.Name = "twoFactorEnabledDataGridViewCheckBoxColumn";
            this.twoFactorEnabledDataGridViewCheckBoxColumn.Width = 125;
            // 
            // lockoutEndDataGridViewTextBoxColumn
            // 
            this.lockoutEndDataGridViewTextBoxColumn.DataPropertyName = "LockoutEnd";
            this.lockoutEndDataGridViewTextBoxColumn.HeaderText = "LockoutEnd";
            this.lockoutEndDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lockoutEndDataGridViewTextBoxColumn.Name = "lockoutEndDataGridViewTextBoxColumn";
            this.lockoutEndDataGridViewTextBoxColumn.Width = 125;
            // 
            // lockoutEnabledDataGridViewCheckBoxColumn
            // 
            this.lockoutEnabledDataGridViewCheckBoxColumn.DataPropertyName = "LockoutEnabled";
            this.lockoutEnabledDataGridViewCheckBoxColumn.HeaderText = "LockoutEnabled";
            this.lockoutEnabledDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.lockoutEnabledDataGridViewCheckBoxColumn.Name = "lockoutEnabledDataGridViewCheckBoxColumn";
            this.lockoutEnabledDataGridViewCheckBoxColumn.Width = 125;
            // 
            // accessFailedCountDataGridViewTextBoxColumn
            // 
            this.accessFailedCountDataGridViewTextBoxColumn.DataPropertyName = "AccessFailedCount";
            this.accessFailedCountDataGridViewTextBoxColumn.HeaderText = "AccessFailedCount";
            this.accessFailedCountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.accessFailedCountDataGridViewTextBoxColumn.Name = "accessFailedCountDataGridViewTextBoxColumn";
            this.accessFailedCountDataGridViewTextBoxColumn.Width = 125;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(BusinessLayer.User);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firstNameDataGridViewTextBoxColumn1,
            this.lastNameDataGridViewTextBoxColumn1,
            this.userNameDataGridViewTextBoxColumn1,
            this.roleDataGridViewTextBoxColumn1,
            this.teamDataGridViewTextBoxColumn1});
            this.dataGridView2.DataSource = this.userBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(307, 34);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(673, 404);
            this.dataGridView2.TabIndex = 7;
            // 
            // firstNameDataGridViewTextBoxColumn1
            // 
            this.firstNameDataGridViewTextBoxColumn1.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn1.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.firstNameDataGridViewTextBoxColumn1.Name = "firstNameDataGridViewTextBoxColumn1";
            this.firstNameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // lastNameDataGridViewTextBoxColumn1
            // 
            this.lastNameDataGridViewTextBoxColumn1.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn1.HeaderText = "LastName";
            this.lastNameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.lastNameDataGridViewTextBoxColumn1.Name = "lastNameDataGridViewTextBoxColumn1";
            this.lastNameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // userNameDataGridViewTextBoxColumn1
            // 
            this.userNameDataGridViewTextBoxColumn1.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn1.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.userNameDataGridViewTextBoxColumn1.Name = "userNameDataGridViewTextBoxColumn1";
            this.userNameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // roleDataGridViewTextBoxColumn1
            // 
            this.roleDataGridViewTextBoxColumn1.DataPropertyName = "Role";
            this.roleDataGridViewTextBoxColumn1.HeaderText = "Role";
            this.roleDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.roleDataGridViewTextBoxColumn1.Name = "roleDataGridViewTextBoxColumn1";
            this.roleDataGridViewTextBoxColumn1.Width = 125;
            // 
            // teamDataGridViewTextBoxColumn1
            // 
            this.teamDataGridViewTextBoxColumn1.DataPropertyName = "Team";
            this.teamDataGridViewTextBoxColumn1.HeaderText = "Team";
            this.teamDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.teamDataGridViewTextBoxColumn1.Name = "teamDataGridViewTextBoxColumn1";
            this.teamDataGridViewTextBoxColumn1.Width = 125;
            // 
            // ViewUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "ViewUsers";
            this.Text = "View users";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private ComboBox comboBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView1;
        private BindingSource userBindingSource;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn teamDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn vacationsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn normalizedUserNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn normalizedEmailDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn emailConfirmedDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn passwordHashDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn securityStampDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn concurrencyStampDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn phoneNumberConfirmedDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn twoFactorEnabledDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn lockoutEndDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn lockoutEnabledDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn accessFailedCountDataGridViewTextBoxColumn;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn teamDataGridViewTextBoxColumn1;
    }
}