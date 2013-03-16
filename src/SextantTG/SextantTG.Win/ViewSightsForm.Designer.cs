namespace SextantTG.Win
{
    partial class ViewSightsForm
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
            this.listBox_Sights = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_Country = new System.Windows.Forms.ComboBox();
            this.comboBox_Province = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_City = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_FilterSightsName = new System.Windows.Forms.TextBox();
            this.checkBox_Visited = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_SightsName = new System.Windows.Forms.TextBox();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.textBox_Country = new System.Windows.Forms.TextBox();
            this.textBox_Province = new System.Windows.Forms.TextBox();
            this.textBox_City = new System.Windows.Forms.TextBox();
            this.textBox_SightsLevel = new System.Windows.Forms.TextBox();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_Stars = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Comment = new System.Windows.Forms.DataGridView();
            this.Column_C_CommentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_C_CommentUserId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_C_Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_C_CreatingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_C_SightsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource_Comment = new System.Windows.Forms.BindingSource(this.components);
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button_Comment = new System.Windows.Forms.Button();
            this.button_Favorite = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_MyVisited = new System.Windows.Forms.TextBox();
            this.textBox_MyStars = new System.Windows.Forms.TextBox();
            this.button_Close = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Comment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Comment)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Blog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Blog)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_Sights
            // 
            this.listBox_Sights.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_Sights.FormattingEnabled = true;
            this.listBox_Sights.ItemHeight = 12;
            this.listBox_Sights.Location = new System.Drawing.Point(12, 168);
            this.listBox_Sights.Name = "listBox_Sights";
            this.listBox_Sights.Size = new System.Drawing.Size(220, 364);
            this.listBox_Sights.TabIndex = 1;
            this.listBox_Sights.SelectedIndexChanged += new System.EventHandler(this.listBox_Sights_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.comboBox_Country, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_Province, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_City, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBox_FilterSightsName, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.checkBox_Visited, 1, 4);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(220, 150);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // comboBox_Country
            // 
            this.comboBox_Country.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Country.FormattingEnabled = true;
            this.comboBox_Country.Location = new System.Drawing.Point(43, 5);
            this.comboBox_Country.Name = "comboBox_Country";
            this.comboBox_Country.Size = new System.Drawing.Size(174, 20);
            this.comboBox_Country.TabIndex = 1;
            this.comboBox_Country.SelectedIndexChanged += new System.EventHandler(this.comboBox_Country_SelectedIndexChanged);
            // 
            // comboBox_Province
            // 
            this.comboBox_Province.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Province.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Province.FormattingEnabled = true;
            this.comboBox_Province.Location = new System.Drawing.Point(43, 35);
            this.comboBox_Province.Name = "comboBox_Province";
            this.comboBox_Province.Size = new System.Drawing.Size(174, 20);
            this.comboBox_Province.TabIndex = 3;
            this.comboBox_Province.SelectedIndexChanged += new System.EventHandler(this.comboBox_Province_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "国家";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "城市";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "省份";
            // 
            // comboBox_City
            // 
            this.comboBox_City.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_City.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_City.FormattingEnabled = true;
            this.comboBox_City.Location = new System.Drawing.Point(43, 65);
            this.comboBox_City.Name = "comboBox_City";
            this.comboBox_City.Size = new System.Drawing.Size(174, 20);
            this.comboBox_City.TabIndex = 5;
            this.comboBox_City.SelectedIndexChanged += new System.EventHandler(this.comboBox_City_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "名称";
            // 
            // textBox_FilterSightsName
            // 
            this.textBox_FilterSightsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FilterSightsName.Location = new System.Drawing.Point(43, 94);
            this.textBox_FilterSightsName.Name = "textBox_FilterSightsName";
            this.textBox_FilterSightsName.Size = new System.Drawing.Size(174, 21);
            this.textBox_FilterSightsName.TabIndex = 7;
            this.textBox_FilterSightsName.TextChanged += new System.EventHandler(this.textBox_FilterSightsName_TextChanged);
            // 
            // checkBox_Visited
            // 
            this.checkBox_Visited.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_Visited.AutoSize = true;
            this.checkBox_Visited.Location = new System.Drawing.Point(43, 127);
            this.checkBox_Visited.Name = "checkBox_Visited";
            this.checkBox_Visited.Size = new System.Drawing.Size(108, 16);
            this.checkBox_Visited.TabIndex = 8;
            this.checkBox_Visited.Text = "只显示游览过的";
            this.checkBox_Visited.UseVisualStyleBackColor = true;
            this.checkBox_Visited.CheckedChanged += new System.EventHandler(this.checkBox_Visited_CheckedChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.47253F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.791207F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.47253F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.791207F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.47253F));
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.label12, 4, 1);
            this.tableLayoutPanel5.Controls.Add(this.label13, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label14, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.label15, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.textBox_SightsName, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBox_Description, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.textBox_Country, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.textBox_Province, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.textBox_City, 5, 1);
            this.tableLayoutPanel5.Controls.Add(this.textBox_SightsLevel, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.textBox_Price, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.label16, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.textBox_Stars, 5, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(508, 228);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "国家";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "景区";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "省份";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(346, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 8;
            this.label12.Text = "城市";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "级别";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(177, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "票价";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 150);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 15;
            this.label15.Text = "简介";
            // 
            // textBox_SightsName
            // 
            this.textBox_SightsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.textBox_SightsName, 3);
            this.textBox_SightsName.Location = new System.Drawing.Point(43, 3);
            this.textBox_SightsName.Name = "textBox_SightsName";
            this.textBox_SightsName.ReadOnly = true;
            this.textBox_SightsName.Size = new System.Drawing.Size(291, 21);
            this.textBox_SightsName.TabIndex = 1;
            // 
            // textBox_Description
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.textBox_Description, 5);
            this.textBox_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Description.Location = new System.Drawing.Point(43, 87);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.ReadOnly = true;
            this.textBox_Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Description.Size = new System.Drawing.Size(462, 138);
            this.textBox_Description.TabIndex = 14;
            // 
            // textBox_Country
            // 
            this.textBox_Country.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Country.Location = new System.Drawing.Point(43, 31);
            this.textBox_Country.Name = "textBox_Country";
            this.textBox_Country.ReadOnly = true;
            this.textBox_Country.Size = new System.Drawing.Size(122, 21);
            this.textBox_Country.TabIndex = 5;
            // 
            // textBox_Province
            // 
            this.textBox_Province.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Province.Location = new System.Drawing.Point(212, 31);
            this.textBox_Province.Name = "textBox_Province";
            this.textBox_Province.ReadOnly = true;
            this.textBox_Province.Size = new System.Drawing.Size(122, 21);
            this.textBox_Province.TabIndex = 7;
            // 
            // textBox_City
            // 
            this.textBox_City.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_City.Location = new System.Drawing.Point(381, 31);
            this.textBox_City.Name = "textBox_City";
            this.textBox_City.ReadOnly = true;
            this.textBox_City.Size = new System.Drawing.Size(124, 21);
            this.textBox_City.TabIndex = 9;
            // 
            // textBox_SightsLevel
            // 
            this.textBox_SightsLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SightsLevel.Location = new System.Drawing.Point(43, 59);
            this.textBox_SightsLevel.Name = "textBox_SightsLevel";
            this.textBox_SightsLevel.ReadOnly = true;
            this.textBox_SightsLevel.Size = new System.Drawing.Size(122, 21);
            this.textBox_SightsLevel.TabIndex = 11;
            // 
            // textBox_Price
            // 
            this.textBox_Price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Price.Location = new System.Drawing.Point(212, 59);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.ReadOnly = true;
            this.textBox_Price.Size = new System.Drawing.Size(122, 21);
            this.textBox_Price.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(346, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 2;
            this.label16.Text = "评分";
            // 
            // textBox_Stars
            // 
            this.textBox_Stars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Stars.Location = new System.Drawing.Point(381, 3);
            this.textBox_Stars.Name = "textBox_Stars";
            this.textBox_Stars.ReadOnly = true;
            this.textBox_Stars.Size = new System.Drawing.Size(124, 21);
            this.textBox_Stars.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(238, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(534, 509);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(526, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "景点概述";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tableLayoutPanel5);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(514, 248);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "概况";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView_Comment);
            this.groupBox1.Location = new System.Drawing.Point(6, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 217);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "留言";
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
            this.Column_C_SightsId});
            this.dataGridView_Comment.DataSource = this.bindingSource_Comment;
            this.dataGridView_Comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Comment.Location = new System.Drawing.Point(3, 17);
            this.dataGridView_Comment.MultiSelect = false;
            this.dataGridView_Comment.Name = "dataGridView_Comment";
            this.dataGridView_Comment.ReadOnly = true;
            this.dataGridView_Comment.RowTemplate.Height = 23;
            this.dataGridView_Comment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Comment.Size = new System.Drawing.Size(508, 197);
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
            // Column_C_SightsId
            // 
            this.Column_C_SightsId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_C_SightsId.DataPropertyName = "SightsId";
            this.Column_C_SightsId.HeaderText = "SightsId";
            this.Column_C_SightsId.Name = "Column_C_SightsId";
            this.Column_C_SightsId.ReadOnly = true;
            this.Column_C_SightsId.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.stgReadonlyPictures);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(526, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "景点图片";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // stgReadonlyPictures
            // 
            this.stgReadonlyPictures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stgReadonlyPictures.Location = new System.Drawing.Point(3, 3);
            this.stgReadonlyPictures.Name = "stgReadonlyPictures";
            this.stgReadonlyPictures.Size = new System.Drawing.Size(520, 477);
            this.stgReadonlyPictures.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView_Blog);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(526, 483);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "相关日志";
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
            this.dataGridView_Blog.MultiSelect = false;
            this.dataGridView_Blog.Name = "dataGridView_Blog";
            this.dataGridView_Blog.ReadOnly = true;
            this.dataGridView_Blog.RowTemplate.Height = 23;
            this.dataGridView_Blog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Blog.Size = new System.Drawing.Size(520, 477);
            this.dataGridView_Blog.TabIndex = 2;
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
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button_Comment);
            this.tabPage4.Controls.Add(this.button_Favorite);
            this.tabPage4.Controls.Add(this.tableLayoutPanel1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(526, 483);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "我的足迹";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button_Comment
            // 
            this.button_Comment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Comment.Location = new System.Drawing.Point(364, 72);
            this.button_Comment.Name = "button_Comment";
            this.button_Comment.Size = new System.Drawing.Size(75, 23);
            this.button_Comment.TabIndex = 1;
            this.button_Comment.Text = "我要留言";
            this.button_Comment.UseVisualStyleBackColor = true;
            this.button_Comment.Click += new System.EventHandler(this.button_Comment_Click);
            // 
            // button_Favorite
            // 
            this.button_Favorite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Favorite.Location = new System.Drawing.Point(445, 72);
            this.button_Favorite.Name = "button_Favorite";
            this.button_Favorite.Size = new System.Drawing.Size(75, 23);
            this.button_Favorite.TabIndex = 2;
            this.button_Favorite.Text = "我要打分";
            this.button_Favorite.UseVisualStyleBackColor = true;
            this.button_Favorite.Click += new System.EventHandler(this.button_Favorite_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_MyVisited, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_MyStars, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(514, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "是否游览过";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "评分";
            // 
            // textBox_MyVisited
            // 
            this.textBox_MyVisited.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_MyVisited.Location = new System.Drawing.Point(83, 4);
            this.textBox_MyVisited.Name = "textBox_MyVisited";
            this.textBox_MyVisited.ReadOnly = true;
            this.textBox_MyVisited.Size = new System.Drawing.Size(428, 21);
            this.textBox_MyVisited.TabIndex = 1;
            // 
            // textBox_MyStars
            // 
            this.textBox_MyStars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_MyStars.Location = new System.Drawing.Point(83, 34);
            this.textBox_MyStars.Name = "textBox_MyStars";
            this.textBox_MyStars.ReadOnly = true;
            this.textBox_MyStars.Size = new System.Drawing.Size(428, 21);
            this.textBox_MyStars.TabIndex = 3;
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Location = new System.Drawing.Point(697, 527);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 3;
            this.button_Close.Text = "关闭";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // ViewSightsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.listBox_Sights);
            this.Name = "ViewSightsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "景点一览";
            this.Load += new System.EventHandler(this.SightsForm_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Comment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Comment)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Blog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Blog)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Sights;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox comboBox_Country;
        private System.Windows.Forms.ComboBox comboBox_Province;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_City;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.TextBox textBox_SightsName;
        private System.Windows.Forms.TextBox textBox_Country;
        private System.Windows.Forms.TextBox textBox_Province;
        private System.Windows.Forms.TextBox textBox_City;
        private System.Windows.Forms.TextBox textBox_SightsLevel;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.TextBox textBox_Stars;
        private System.Windows.Forms.Label label16;
        private STGReadonlyPictures stgReadonlyPictures;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_FilterSightsName;
        private System.Windows.Forms.BindingSource bindingSource_Comment;
        private System.Windows.Forms.CheckBox checkBox_Visited;
        private System.Windows.Forms.BindingSource bindingSource_Blog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Favorite;
        private System.Windows.Forms.TextBox textBox_MyVisited;
        private System.Windows.Forms.TextBox textBox_MyStars;
        private System.Windows.Forms.Button button_Comment;
        private System.Windows.Forms.DataGridView dataGridView_Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_CommentId;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_C_CommentUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_CreatingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_C_SightsId;
        private System.Windows.Forms.DataGridView dataGridView_Blog;
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