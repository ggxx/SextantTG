namespace SextantTG.Win
{
    partial class UsersForm
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
            this.button_Revert = new System.Windows.Forms.Button();
            this.button_Blacklist = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column_UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_LoginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_Permission = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Revert
            // 
            this.button_Revert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Revert.Location = new System.Drawing.Point(93, 407);
            this.button_Revert.Name = "button_Revert";
            this.button_Revert.Size = new System.Drawing.Size(75, 23);
            this.button_Revert.TabIndex = 2;
            this.button_Revert.Text = "恢复";
            this.button_Revert.UseVisualStyleBackColor = true;
            this.button_Revert.Click += new System.EventHandler(this.button_Revert_Click);
            // 
            // button_Blacklist
            // 
            this.button_Blacklist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Blacklist.Location = new System.Drawing.Point(12, 407);
            this.button_Blacklist.Name = "button_Blacklist";
            this.button_Blacklist.Size = new System.Drawing.Size(75, 23);
            this.button_Blacklist.TabIndex = 1;
            this.button_Blacklist.Text = "禁言";
            this.button_Blacklist.UseVisualStyleBackColor = true;
            this.button_Blacklist.Click += new System.EventHandler(this.button_Blacklist_Click);
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Location = new System.Drawing.Point(537, 407);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 4;
            this.button_Close.Text = "关闭";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_UserId,
            this.Column_LoginName,
            this.Column_Email,
            this.Column_Status});
            this.dataGridView.DataSource = this.bindingSource;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(600, 389);
            this.dataGridView.TabIndex = 0;
            // 
            // Column_UserId
            // 
            this.Column_UserId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_UserId.DataPropertyName = "UserId";
            this.Column_UserId.HeaderText = "ID";
            this.Column_UserId.Name = "Column_UserId";
            this.Column_UserId.ReadOnly = true;
            this.Column_UserId.Visible = false;
            // 
            // Column_LoginName
            // 
            this.Column_LoginName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_LoginName.DataPropertyName = "LoginName";
            this.Column_LoginName.HeaderText = "登录名";
            this.Column_LoginName.Name = "Column_LoginName";
            this.Column_LoginName.ReadOnly = true;
            // 
            // Column_Email
            // 
            this.Column_Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Email.DataPropertyName = "Email";
            this.Column_Email.HeaderText = "Email";
            this.Column_Email.Name = "Column_Email";
            this.Column_Email.ReadOnly = true;
            // 
            // Column_Status
            // 
            this.Column_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Status.DataPropertyName = "Status";
            this.Column_Status.HeaderText = "有效";
            this.Column_Status.Name = "Column_Status";
            this.Column_Status.ReadOnly = true;
            this.Column_Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button_Permission
            // 
            this.button_Permission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Permission.Location = new System.Drawing.Point(174, 407);
            this.button_Permission.Name = "button_Permission";
            this.button_Permission.Size = new System.Drawing.Size(75, 23);
            this.button_Permission.TabIndex = 3;
            this.button_Permission.Text = "权限";
            this.button_Permission.UseVisualStyleBackColor = true;
            this.button_Permission.Click += new System.EventHandler(this.button_Permission_Click);
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.button_Permission);
            this.Controls.Add(this.button_Revert);
            this.Controls.Add(this.button_Blacklist);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.dataGridView);
            this.Name = "UsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户字典维护";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Revert;
        private System.Windows.Forms.Button button_Blacklist;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button button_Permission;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_LoginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Status;
    }
}