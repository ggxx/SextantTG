namespace SextantTG.Win
{
    partial class ViewUserTourForm
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
            this.button_Close = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Comment = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_SubTour = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_TourName = new System.Windows.Forms.TextBox();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_BeginDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Cost = new System.Windows.Forms.TextBox();
            this.textBox_Status = new System.Windows.Forms.TextBox();
            this.textBox_Memos = new System.Windows.Forms.TextBox();
            this.textBox_EndDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.stgReadonlyPictures = new SextantTG.Win.STGReadonlyPictures();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView_Blog = new System.Windows.Forms.DataGridView();
            this.listBox_Tour = new System.Windows.Forms.ListBox();
            this.button_New = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Blog = new System.Windows.Forms.Button();
            this.button_Comment = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Comment)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SubTour)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Blog)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Location = new System.Drawing.Point(697, 527);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 12;
            this.button_Close.Text = "关闭";
            this.button_Close.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(250, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(522, 509);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(514, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "旅行概述";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dataGridView_Comment);
            this.groupBox3.Location = new System.Drawing.Point(6, 338);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(502, 139);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "留言";
            // 
            // dataGridView_Comment
            // 
            this.dataGridView_Comment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Comment.Location = new System.Drawing.Point(3, 17);
            this.dataGridView_Comment.Name = "dataGridView_Comment";
            this.dataGridView_Comment.RowTemplate.Height = 23;
            this.dataGridView_Comment.Size = new System.Drawing.Size(496, 119);
            this.dataGridView_Comment.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView_SubTour);
            this.groupBox2.Location = new System.Drawing.Point(6, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 180);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "行程安排";
            // 
            // dataGridView_SubTour
            // 
            this.dataGridView_SubTour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SubTour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SubTour.Location = new System.Drawing.Point(3, 17);
            this.dataGridView_SubTour.Name = "dataGridView_SubTour";
            this.dataGridView_SubTour.RowTemplate.Height = 23;
            this.dataGridView_SubTour.Size = new System.Drawing.Size(496, 160);
            this.dataGridView_SubTour.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 140);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "旅行概况";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_TourName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_User, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_BeginDate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Cost, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Status, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Memos, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_EndDate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(496, 120);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "旅行名称";
            // 
            // textBox_TourName
            // 
            this.textBox_TourName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_TourName, 3);
            this.textBox_TourName.Location = new System.Drawing.Point(83, 4);
            this.textBox_TourName.Name = "textBox_TourName";
            this.textBox_TourName.ReadOnly = true;
            this.textBox_TourName.Size = new System.Drawing.Size(410, 21);
            this.textBox_TourName.TabIndex = 1;
            // 
            // textBox_User
            // 
            this.textBox_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_User.Location = new System.Drawing.Point(83, 34);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.ReadOnly = true;
            this.textBox_User.Size = new System.Drawing.Size(162, 21);
            this.textBox_User.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "旅行者";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "出发日期";
            // 
            // textBox_BeginDate
            // 
            this.textBox_BeginDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_BeginDate.Location = new System.Drawing.Point(83, 64);
            this.textBox_BeginDate.Name = "textBox_BeginDate";
            this.textBox_BeginDate.ReadOnly = true;
            this.textBox_BeginDate.Size = new System.Drawing.Size(162, 21);
            this.textBox_BeginDate.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(296, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "备注";
            // 
            // textBox_Cost
            // 
            this.textBox_Cost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Cost.Location = new System.Drawing.Point(331, 34);
            this.textBox_Cost.Name = "textBox_Cost";
            this.textBox_Cost.ReadOnly = true;
            this.textBox_Cost.Size = new System.Drawing.Size(162, 21);
            this.textBox_Cost.TabIndex = 10;
            // 
            // textBox_Status
            // 
            this.textBox_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Status.Location = new System.Drawing.Point(331, 64);
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.ReadOnly = true;
            this.textBox_Status.Size = new System.Drawing.Size(162, 21);
            this.textBox_Status.TabIndex = 11;
            // 
            // textBox_Memos
            // 
            this.textBox_Memos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Memos.Location = new System.Drawing.Point(331, 94);
            this.textBox_Memos.Name = "textBox_Memos";
            this.textBox_Memos.ReadOnly = true;
            this.textBox_Memos.Size = new System.Drawing.Size(162, 21);
            this.textBox_Memos.TabIndex = 12;
            // 
            // textBox_EndDate
            // 
            this.textBox_EndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_EndDate.Location = new System.Drawing.Point(83, 94);
            this.textBox_EndDate.Name = "textBox_EndDate";
            this.textBox_EndDate.ReadOnly = true;
            this.textBox_EndDate.Size = new System.Drawing.Size(162, 21);
            this.textBox_EndDate.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "结束日期";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "状态";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "费用(元)";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.stgReadonlyPictures);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(514, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "沿途美景";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // stgReadonlyPictures
            // 
            this.stgReadonlyPictures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stgReadonlyPictures.Location = new System.Drawing.Point(3, 3);
            this.stgReadonlyPictures.Name = "stgReadonlyPictures";
            this.stgReadonlyPictures.Size = new System.Drawing.Size(508, 477);
            this.stgReadonlyPictures.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView_Blog);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(514, 483);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "心情分享";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Blog
            // 
            this.dataGridView_Blog.AllowUserToAddRows = false;
            this.dataGridView_Blog.AllowUserToDeleteRows = false;
            this.dataGridView_Blog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Blog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Blog.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_Blog.Name = "dataGridView_Blog";
            this.dataGridView_Blog.ReadOnly = true;
            this.dataGridView_Blog.RowTemplate.Height = 23;
            this.dataGridView_Blog.Size = new System.Drawing.Size(508, 477);
            this.dataGridView_Blog.TabIndex = 1;
            // 
            // listBox_Tour
            // 
            this.listBox_Tour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_Tour.FormattingEnabled = true;
            this.listBox_Tour.ItemHeight = 12;
            this.listBox_Tour.Location = new System.Drawing.Point(12, 12);
            this.listBox_Tour.Name = "listBox_Tour";
            this.listBox_Tour.Size = new System.Drawing.Size(232, 532);
            this.listBox_Tour.TabIndex = 10;
            // 
            // button_New
            // 
            this.button_New.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_New.Location = new System.Drawing.Point(250, 527);
            this.button_New.Name = "button_New";
            this.button_New.Size = new System.Drawing.Size(75, 23);
            this.button_New.TabIndex = 13;
            this.button_New.Text = "新的旅行";
            this.button_New.UseVisualStyleBackColor = true;
            this.button_New.Click += new System.EventHandler(this.button_New_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Edit.Location = new System.Drawing.Point(331, 527);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(75, 23);
            this.button_Edit.TabIndex = 14;
            this.button_Edit.Text = "修改旅行";
            this.button_Edit.UseVisualStyleBackColor = true;
            // 
            // button_Blog
            // 
            this.button_Blog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Blog.Location = new System.Drawing.Point(412, 527);
            this.button_Blog.Name = "button_Blog";
            this.button_Blog.Size = new System.Drawing.Size(75, 23);
            this.button_Blog.TabIndex = 15;
            this.button_Blog.Text = "撰写日志";
            this.button_Blog.UseVisualStyleBackColor = true;
            // 
            // button_Comment
            // 
            this.button_Comment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Comment.Location = new System.Drawing.Point(493, 527);
            this.button_Comment.Name = "button_Comment";
            this.button_Comment.Size = new System.Drawing.Size(75, 23);
            this.button_Comment.TabIndex = 16;
            this.button_Comment.Text = "我要留言";
            this.button_Comment.UseVisualStyleBackColor = true;
            // 
            // ViewUserTourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.button_Comment);
            this.Controls.Add(this.button_Blog);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.button_New);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listBox_Tour);
            this.Name = "ViewUserTourForm";
            this.Text = "我的旅行";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Comment)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SubTour)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Blog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView_Comment;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_SubTour;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_TourName;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_BeginDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_Cost;
        private System.Windows.Forms.TextBox textBox_Status;
        private System.Windows.Forms.TextBox textBox_Memos;
        private System.Windows.Forms.TextBox textBox_EndDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage2;
        private STGReadonlyPictures stgReadonlyPictures;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView_Blog;
        private System.Windows.Forms.ListBox listBox_Tour;
        private System.Windows.Forms.Button button_New;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Blog;
        private System.Windows.Forms.Button button_Comment;
    }
}