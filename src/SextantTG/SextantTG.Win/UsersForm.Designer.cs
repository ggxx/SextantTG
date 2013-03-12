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
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_Permission = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Revert
            // 
            this.button_Revert.Location = new System.Drawing.Point(93, 407);
            this.button_Revert.Name = "button_Revert";
            this.button_Revert.Size = new System.Drawing.Size(75, 23);
            this.button_Revert.TabIndex = 19;
            this.button_Revert.Text = "恢复";
            this.button_Revert.UseVisualStyleBackColor = true;
            this.button_Revert.Click += new System.EventHandler(this.button_Revert_Click);
            // 
            // button_Blacklist
            // 
            this.button_Blacklist.Location = new System.Drawing.Point(12, 407);
            this.button_Blacklist.Name = "button_Blacklist";
            this.button_Blacklist.Size = new System.Drawing.Size(75, 23);
            this.button_Blacklist.TabIndex = 18;
            this.button_Blacklist.Text = "禁言";
            this.button_Blacklist.UseVisualStyleBackColor = true;
            this.button_Blacklist.Click += new System.EventHandler(this.button_Blacklist_Click);
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(537, 407);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 17;
            this.button_Close.Text = "关闭";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.DataSource = this.bindingSource;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(600, 389);
            this.dataGridView.TabIndex = 16;
            // 
            // button_Permission
            // 
            this.button_Permission.Location = new System.Drawing.Point(174, 407);
            this.button_Permission.Name = "button_Permission";
            this.button_Permission.Size = new System.Drawing.Size(75, 23);
            this.button_Permission.TabIndex = 20;
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
            this.Text = "UsersForm";
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
    }
}