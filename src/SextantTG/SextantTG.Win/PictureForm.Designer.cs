namespace SextantTG.Win
{
    partial class PictureForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Comment = new System.Windows.Forms.DataGridView();
            this.Column_C_CommentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_C_CommentUserId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_C_Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_C_CreatingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_C_PictureId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource_Comment = new System.Windows.Forms.BindingSource(this.components);
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Comment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Comment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Comment)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.ImageLocation = "";
            this.pictureBox.Location = new System.Drawing.Point(3, 17);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(594, 397);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 417);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图片";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView_Comment);
            this.groupBox2.Location = new System.Drawing.Point(15, 435);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(597, 126);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "评论";
            // 
            // dataGridView_Comment
            // 
            this.dataGridView_Comment.AllowUserToAddRows = false;
            this.dataGridView_Comment.AllowUserToDeleteRows = false;
            this.dataGridView_Comment.AutoGenerateColumns = false;
            this.dataGridView_Comment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Comment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_C_CommentId,
            this.Column_C_CommentUserId,
            this.Column_C_Comment,
            this.Column_C_CreatingTime,
            this.Column_C_PictureId});
            this.dataGridView_Comment.DataSource = this.bindingSource_Comment;
            this.dataGridView_Comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Comment.Location = new System.Drawing.Point(3, 17);
            this.dataGridView_Comment.MultiSelect = false;
            this.dataGridView_Comment.Name = "dataGridView_Comment";
            this.dataGridView_Comment.ReadOnly = true;
            this.dataGridView_Comment.RowTemplate.Height = 23;
            this.dataGridView_Comment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Comment.Size = new System.Drawing.Size(591, 106);
            this.dataGridView_Comment.TabIndex = 0;
            // 
            // Column_C_CommentId
            // 
            this.Column_C_CommentId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_C_CommentId.DataPropertyName = "CommentId";
            this.Column_C_CommentId.HeaderText = "CommentId";
            this.Column_C_CommentId.Name = "Column_C_CommentId";
            this.Column_C_CommentId.ReadOnly = true;
            this.Column_C_CommentId.Visible = false;
            // 
            // Column_C_CommentUserId
            // 
            this.Column_C_CommentUserId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_C_CommentUserId.DataPropertyName = "CommentUserId";
            this.Column_C_CommentUserId.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column_C_CommentUserId.HeaderText = "用户";
            this.Column_C_CommentUserId.Name = "Column_C_CommentUserId";
            this.Column_C_CommentUserId.ReadOnly = true;
            this.Column_C_CommentUserId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_C_CommentUserId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column_C_Comment
            // 
            this.Column_C_Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_C_Comment.DataPropertyName = "Comment";
            this.Column_C_Comment.HeaderText = "留言";
            this.Column_C_Comment.Name = "Column_C_Comment";
            this.Column_C_Comment.ReadOnly = true;
            // 
            // Column_C_CreatingTime
            // 
            this.Column_C_CreatingTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_C_CreatingTime.DataPropertyName = "CreatingTime";
            this.Column_C_CreatingTime.HeaderText = "时间";
            this.Column_C_CreatingTime.Name = "Column_C_CreatingTime";
            this.Column_C_CreatingTime.ReadOnly = true;
            // 
            // Column_C_PictureId
            // 
            this.Column_C_PictureId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_C_PictureId.DataPropertyName = "PictureId";
            this.Column_C_PictureId.HeaderText = "PictureId";
            this.Column_C_PictureId.Name = "Column_C_PictureId";
            this.Column_C_PictureId.ReadOnly = true;
            this.Column_C_PictureId.Visible = false;
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Location = new System.Drawing.Point(537, 567);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 3;
            this.button_Close.Text = "关闭";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Comment
            // 
            this.button_Comment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Comment.Location = new System.Drawing.Point(12, 567);
            this.button_Comment.Name = "button_Comment";
            this.button_Comment.Size = new System.Drawing.Size(75, 23);
            this.button_Comment.TabIndex = 2;
            this.button_Comment.Text = "添加评论";
            this.button_Comment.UseVisualStyleBackColor = true;
            this.button_Comment.Click += new System.EventHandler(this.button_Comment_Click);
            // 
            // PictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 602);
            this.Controls.Add(this.button_Comment);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PictureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图片浏览";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Comment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Comment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Comment;
        private System.Windows.Forms.DataGridView dataGridView_Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_CommentId;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_C_CommentUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_CreatingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_PictureId;
        private System.Windows.Forms.BindingSource bindingSource_Comment;
    }
}