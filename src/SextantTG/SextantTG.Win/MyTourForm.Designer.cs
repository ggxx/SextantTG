namespace SextantTG.Win
{
    partial class MyTourForm
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
            this.button_Close = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Comment = new System.Windows.Forms.DataGridView();
            this.Column_C_CommentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_C_CommentUserId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_C_Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_C_CreatingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_C_TourId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource_Comment = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_SubTour = new System.Windows.Forms.DataGridView();
            this.Column_ST_TourId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ST_SubTourId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ST_SubTourName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ST_SightsId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_ST_BeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ST_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ST_CreatingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ST_Memos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource_SubTour = new System.Windows.Forms.BindingSource(this.components);
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
            this.Column_B_BlogId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_B_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_B_TourId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_B_SubTourId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_B_SightsId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_B_Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_B_UserId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_B_CreatingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource_Blog = new System.Windows.Forms.BindingSource(this.components);
            this.listBox_Tour = new System.Windows.Forms.ListBox();
            this.button_New = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Blog = new System.Windows.Forms.Button();
            this.button_Comment = new System.Windows.Forms.Button();
            this.button_Picture = new System.Windows.Forms.Button();
            this.button_Del = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Comment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Comment)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SubTour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_SubTour)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Blog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Blog)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Location = new System.Drawing.Point(757, 527);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 8;
            this.button_Close.Text = "关闭";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
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
            this.tabControl1.Size = new System.Drawing.Size(582, 509);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(574, 483);
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
            this.groupBox3.Size = new System.Drawing.Size(562, 139);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "留言";
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
            this.Column_C_TourId});
            this.dataGridView_Comment.DataSource = this.bindingSource_Comment;
            this.dataGridView_Comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Comment.Location = new System.Drawing.Point(3, 17);
            this.dataGridView_Comment.Name = "dataGridView_Comment";
            this.dataGridView_Comment.ReadOnly = true;
            this.dataGridView_Comment.RowTemplate.Height = 23;
            this.dataGridView_Comment.Size = new System.Drawing.Size(556, 119);
            this.dataGridView_Comment.TabIndex = 7;
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
            // Column_C_TourId
            // 
            this.Column_C_TourId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_C_TourId.DataPropertyName = "TourId";
            this.Column_C_TourId.HeaderText = "TourId";
            this.Column_C_TourId.Name = "Column_C_TourId";
            this.Column_C_TourId.ReadOnly = true;
            this.Column_C_TourId.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView_SubTour);
            this.groupBox2.Location = new System.Drawing.Point(6, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(562, 180);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "行程安排";
            // 
            // dataGridView_SubTour
            // 
            this.dataGridView_SubTour.AllowUserToAddRows = false;
            this.dataGridView_SubTour.AllowUserToDeleteRows = false;
            this.dataGridView_SubTour.AutoGenerateColumns = false;
            this.dataGridView_SubTour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SubTour.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ST_TourId,
            this.Column_ST_SubTourId,
            this.Column_ST_SubTourName,
            this.Column_ST_SightsId,
            this.Column_ST_BeginDate,
            this.Column_ST_EndDate,
            this.Column_ST_CreatingTime,
            this.Column_ST_Memos});
            this.dataGridView_SubTour.DataSource = this.bindingSource_SubTour;
            this.dataGridView_SubTour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_SubTour.Location = new System.Drawing.Point(3, 17);
            this.dataGridView_SubTour.Name = "dataGridView_SubTour";
            this.dataGridView_SubTour.ReadOnly = true;
            this.dataGridView_SubTour.RowTemplate.Height = 23;
            this.dataGridView_SubTour.Size = new System.Drawing.Size(556, 160);
            this.dataGridView_SubTour.TabIndex = 7;
            // 
            // Column_ST_TourId
            // 
            this.Column_ST_TourId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_ST_TourId.DataPropertyName = "TourId";
            this.Column_ST_TourId.HeaderText = "TourId";
            this.Column_ST_TourId.Name = "Column_ST_TourId";
            this.Column_ST_TourId.ReadOnly = true;
            this.Column_ST_TourId.Visible = false;
            // 
            // Column_ST_SubTourId
            // 
            this.Column_ST_SubTourId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_ST_SubTourId.DataPropertyName = "SubTourId";
            this.Column_ST_SubTourId.HeaderText = "SubTourId";
            this.Column_ST_SubTourId.Name = "Column_ST_SubTourId";
            this.Column_ST_SubTourId.ReadOnly = true;
            this.Column_ST_SubTourId.Visible = false;
            // 
            // Column_ST_SubTourName
            // 
            this.Column_ST_SubTourName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_ST_SubTourName.DataPropertyName = "SubTourName";
            this.Column_ST_SubTourName.HeaderText = "行程名称";
            this.Column_ST_SubTourName.Name = "Column_ST_SubTourName";
            this.Column_ST_SubTourName.ReadOnly = true;
            // 
            // Column_ST_SightsId
            // 
            this.Column_ST_SightsId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_ST_SightsId.DataPropertyName = "SightsId";
            this.Column_ST_SightsId.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column_ST_SightsId.HeaderText = "景点";
            this.Column_ST_SightsId.Name = "Column_ST_SightsId";
            this.Column_ST_SightsId.ReadOnly = true;
            // 
            // Column_ST_BeginDate
            // 
            this.Column_ST_BeginDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_ST_BeginDate.DataPropertyName = "BeginDate";
            this.Column_ST_BeginDate.HeaderText = "起始日期";
            this.Column_ST_BeginDate.Name = "Column_ST_BeginDate";
            this.Column_ST_BeginDate.ReadOnly = true;
            this.Column_ST_BeginDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_ST_BeginDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_ST_EndDate
            // 
            this.Column_ST_EndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_ST_EndDate.DataPropertyName = "EndDate";
            this.Column_ST_EndDate.HeaderText = "结束日期";
            this.Column_ST_EndDate.Name = "Column_ST_EndDate";
            this.Column_ST_EndDate.ReadOnly = true;
            this.Column_ST_EndDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_ST_EndDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_ST_CreatingTime
            // 
            this.Column_ST_CreatingTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_ST_CreatingTime.DataPropertyName = "CreatingTime";
            this.Column_ST_CreatingTime.HeaderText = "CreatingTime";
            this.Column_ST_CreatingTime.Name = "Column_ST_CreatingTime";
            this.Column_ST_CreatingTime.ReadOnly = true;
            this.Column_ST_CreatingTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_ST_CreatingTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_ST_CreatingTime.Visible = false;
            // 
            // Column_ST_Memos
            // 
            this.Column_ST_Memos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_ST_Memos.DataPropertyName = "Memos";
            this.Column_ST_Memos.HeaderText = "Memos";
            this.Column_ST_Memos.Name = "Column_ST_Memos";
            this.Column_ST_Memos.ReadOnly = true;
            this.Column_ST_Memos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_ST_Memos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_ST_Memos.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 140);
            this.groupBox1.TabIndex = 0;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(556, 120);
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
            this.textBox_TourName.Size = new System.Drawing.Size(470, 21);
            this.textBox_TourName.TabIndex = 1;
            // 
            // textBox_User
            // 
            this.textBox_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_User.Location = new System.Drawing.Point(83, 34);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.ReadOnly = true;
            this.textBox_User.Size = new System.Drawing.Size(192, 21);
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
            this.textBox_BeginDate.Size = new System.Drawing.Size(192, 21);
            this.textBox_BeginDate.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "备注";
            // 
            // textBox_Cost
            // 
            this.textBox_Cost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Cost.Location = new System.Drawing.Point(361, 34);
            this.textBox_Cost.Name = "textBox_Cost";
            this.textBox_Cost.ReadOnly = true;
            this.textBox_Cost.Size = new System.Drawing.Size(192, 21);
            this.textBox_Cost.TabIndex = 10;
            // 
            // textBox_Status
            // 
            this.textBox_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Status.Location = new System.Drawing.Point(361, 64);
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.ReadOnly = true;
            this.textBox_Status.Size = new System.Drawing.Size(192, 21);
            this.textBox_Status.TabIndex = 11;
            // 
            // textBox_Memos
            // 
            this.textBox_Memos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Memos.Location = new System.Drawing.Point(361, 94);
            this.textBox_Memos.Name = "textBox_Memos";
            this.textBox_Memos.ReadOnly = true;
            this.textBox_Memos.Size = new System.Drawing.Size(192, 21);
            this.textBox_Memos.TabIndex = 12;
            // 
            // textBox_EndDate
            // 
            this.textBox_EndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_EndDate.Location = new System.Drawing.Point(83, 94);
            this.textBox_EndDate.Name = "textBox_EndDate";
            this.textBox_EndDate.ReadOnly = true;
            this.textBox_EndDate.Size = new System.Drawing.Size(192, 21);
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
            this.label6.Location = new System.Drawing.Point(326, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "状态";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(302, 39);
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
            this.tabPage2.Size = new System.Drawing.Size(574, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "沿途美景";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // stgReadonlyPictures
            // 
            this.stgReadonlyPictures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stgReadonlyPictures.Location = new System.Drawing.Point(3, 3);
            this.stgReadonlyPictures.Name = "stgReadonlyPictures";
            this.stgReadonlyPictures.Size = new System.Drawing.Size(568, 477);
            this.stgReadonlyPictures.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView_Blog);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(574, 483);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "心情分享";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Blog
            // 
            this.dataGridView_Blog.AllowUserToAddRows = false;
            this.dataGridView_Blog.AllowUserToDeleteRows = false;
            this.dataGridView_Blog.AutoGenerateColumns = false;
            this.dataGridView_Blog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Blog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_B_BlogId,
            this.Column_B_Title,
            this.Column_B_TourId,
            this.Column_B_SubTourId,
            this.Column_B_SightsId,
            this.Column_B_Content,
            this.Column_B_UserId,
            this.Column_B_CreatingTime});
            this.dataGridView_Blog.DataSource = this.bindingSource_Blog;
            this.dataGridView_Blog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Blog.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_Blog.Name = "dataGridView_Blog";
            this.dataGridView_Blog.ReadOnly = true;
            this.dataGridView_Blog.RowTemplate.Height = 23;
            this.dataGridView_Blog.Size = new System.Drawing.Size(568, 477);
            this.dataGridView_Blog.TabIndex = 1;
            // 
            // Column_B_BlogId
            // 
            this.Column_B_BlogId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_B_BlogId.DataPropertyName = "BlogId";
            this.Column_B_BlogId.HeaderText = "BlogId";
            this.Column_B_BlogId.Name = "Column_B_BlogId";
            this.Column_B_BlogId.ReadOnly = true;
            this.Column_B_BlogId.Visible = false;
            // 
            // Column_B_Title
            // 
            this.Column_B_Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_B_Title.DataPropertyName = "Title";
            this.Column_B_Title.HeaderText = "日志标题";
            this.Column_B_Title.Name = "Column_B_Title";
            this.Column_B_Title.ReadOnly = true;
            this.Column_B_Title.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_B_Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_B_TourId
            // 
            this.Column_B_TourId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_B_TourId.DataPropertyName = "TourId";
            this.Column_B_TourId.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column_B_TourId.HeaderText = "旅行";
            this.Column_B_TourId.Name = "Column_B_TourId";
            this.Column_B_TourId.ReadOnly = true;
            // 
            // Column_B_SubTourId
            // 
            this.Column_B_SubTourId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_B_SubTourId.DataPropertyName = "SubTourId";
            this.Column_B_SubTourId.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column_B_SubTourId.HeaderText = "行程";
            this.Column_B_SubTourId.Name = "Column_B_SubTourId";
            this.Column_B_SubTourId.ReadOnly = true;
            // 
            // Column_B_SightsId
            // 
            this.Column_B_SightsId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_B_SightsId.DataPropertyName = "SightsId";
            this.Column_B_SightsId.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column_B_SightsId.HeaderText = "景点";
            this.Column_B_SightsId.Name = "Column_B_SightsId";
            this.Column_B_SightsId.ReadOnly = true;
            // 
            // Column_B_Content
            // 
            this.Column_B_Content.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_B_Content.DataPropertyName = "Content";
            this.Column_B_Content.HeaderText = "日志";
            this.Column_B_Content.Name = "Column_B_Content";
            this.Column_B_Content.ReadOnly = true;
            this.Column_B_Content.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_B_Content.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_B_Content.Visible = false;
            // 
            // Column_B_UserId
            // 
            this.Column_B_UserId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_B_UserId.DataPropertyName = "UserId";
            this.Column_B_UserId.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column_B_UserId.HeaderText = "UserId";
            this.Column_B_UserId.Name = "Column_B_UserId";
            this.Column_B_UserId.ReadOnly = true;
            this.Column_B_UserId.Visible = false;
            // 
            // Column_B_CreatingTime
            // 
            this.Column_B_CreatingTime.DataPropertyName = "CreatingTime";
            this.Column_B_CreatingTime.HeaderText = "创建时间";
            this.Column_B_CreatingTime.Name = "Column_B_CreatingTime";
            this.Column_B_CreatingTime.ReadOnly = true;
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
            this.listBox_Tour.TabIndex = 0;
            this.listBox_Tour.SelectedIndexChanged += new System.EventHandler(this.listBox_Tour_SelectedIndexChanged);
            // 
            // button_New
            // 
            this.button_New.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_New.Location = new System.Drawing.Point(250, 527);
            this.button_New.Name = "button_New";
            this.button_New.Size = new System.Drawing.Size(75, 23);
            this.button_New.TabIndex = 2;
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
            this.button_Edit.TabIndex = 3;
            this.button_Edit.Text = "修改旅行";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Blog
            // 
            this.button_Blog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Blog.Enabled = false;
            this.button_Blog.Location = new System.Drawing.Point(574, 527);
            this.button_Blog.Name = "button_Blog";
            this.button_Blog.Size = new System.Drawing.Size(75, 23);
            this.button_Blog.TabIndex = 6;
            this.button_Blog.Text = "撰写日志";
            this.button_Blog.UseVisualStyleBackColor = true;
            this.button_Blog.Click += new System.EventHandler(this.button_Blog_Click);
            // 
            // button_Comment
            // 
            this.button_Comment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Comment.Location = new System.Drawing.Point(493, 527);
            this.button_Comment.Name = "button_Comment";
            this.button_Comment.Size = new System.Drawing.Size(75, 23);
            this.button_Comment.TabIndex = 5;
            this.button_Comment.Text = "我要留言";
            this.button_Comment.UseVisualStyleBackColor = true;
            this.button_Comment.Click += new System.EventHandler(this.button_Comment_Click);
            // 
            // button_Picture
            // 
            this.button_Picture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Picture.Enabled = false;
            this.button_Picture.Location = new System.Drawing.Point(655, 527);
            this.button_Picture.Name = "button_Picture";
            this.button_Picture.Size = new System.Drawing.Size(75, 23);
            this.button_Picture.TabIndex = 7;
            this.button_Picture.Text = "上传图片";
            this.button_Picture.UseVisualStyleBackColor = true;
            this.button_Picture.Click += new System.EventHandler(this.button_Picture_Click);
            // 
            // button_Del
            // 
            this.button_Del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Del.Location = new System.Drawing.Point(412, 527);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(75, 23);
            this.button_Del.TabIndex = 4;
            this.button_Del.Text = "删除旅行";
            this.button_Del.UseVisualStyleBackColor = true;
            this.button_Del.Click += new System.EventHandler(this.button_Del_Click);
            // 
            // MyTourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 562);
            this.Controls.Add(this.button_Del);
            this.Controls.Add(this.button_Picture);
            this.Controls.Add(this.button_Comment);
            this.Controls.Add(this.button_Blog);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.button_New);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listBox_Tour);
            this.Name = "MyTourForm";
            this.Text = "我的旅行";
            this.Load += new System.EventHandler(this.ViewUserTourForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Comment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Comment)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SubTour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_SubTour)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Blog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Blog)).EndInit();
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
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView_Blog;
        private System.Windows.Forms.ListBox listBox_Tour;
        private System.Windows.Forms.Button button_New;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Blog;
        private System.Windows.Forms.Button button_Comment;
        private System.Windows.Forms.BindingSource bindingSource_SubTour;
        private System.Windows.Forms.BindingSource bindingSource_Comment;
        private System.Windows.Forms.BindingSource bindingSource_Blog;
        private System.Windows.Forms.Button button_Picture;
        private STGReadonlyPictures stgReadonlyPictures;
        private System.Windows.Forms.Button button_Del;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_CommentUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_CommentId;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_C_CommentUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_CreatingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_TourId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ST_TourId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ST_SubTourId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ST_SubTourName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_ST_SightsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ST_BeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ST_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ST_CreatingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ST_Memos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_B_BlogId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_B_Title;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_B_TourId;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_B_SubTourId;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_B_SightsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_B_Content;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_B_UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_B_CreatingTime;
    }
}