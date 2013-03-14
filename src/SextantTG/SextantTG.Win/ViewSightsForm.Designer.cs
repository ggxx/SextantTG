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
            this.listBox_Sights = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_Country = new System.Windows.Forms.ComboBox();
            this.comboBox_Province = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_City = new System.Windows.Forms.ComboBox();
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.stgReadonlyPictures = new SextantTG.Win.STGReadonlyPictures();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_FilterSightsName = new System.Windows.Forms.TextBox();
            this.checkBox_Visited = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_Sights
            // 
            this.listBox_Sights.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox_Sights.FormattingEnabled = true;
            this.listBox_Sights.ItemHeight = 12;
            this.listBox_Sights.Location = new System.Drawing.Point(13, 168);
            this.listBox_Sights.Name = "listBox_Sights";
            this.listBox_Sights.Size = new System.Drawing.Size(180, 352);
            this.listBox_Sights.TabIndex = 2;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(181, 150);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // comboBox_Country
            // 
            this.comboBox_Country.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Country.FormattingEnabled = true;
            this.comboBox_Country.Location = new System.Drawing.Point(43, 5);
            this.comboBox_Country.Name = "comboBox_Country";
            this.comboBox_Country.Size = new System.Drawing.Size(135, 20);
            this.comboBox_Country.TabIndex = 4;
            this.comboBox_Country.SelectedIndexChanged += new System.EventHandler(this.comboBox_Country_SelectedIndexChanged);
            // 
            // comboBox_Province
            // 
            this.comboBox_Province.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Province.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Province.FormattingEnabled = true;
            this.comboBox_Province.Location = new System.Drawing.Point(43, 35);
            this.comboBox_Province.Name = "comboBox_Province";
            this.comboBox_Province.Size = new System.Drawing.Size(135, 20);
            this.comboBox_Province.TabIndex = 5;
            this.comboBox_Province.SelectedIndexChanged += new System.EventHandler(this.comboBox_Province_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "国家";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "城市";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "省份";
            // 
            // comboBox_City
            // 
            this.comboBox_City.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_City.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_City.FormattingEnabled = true;
            this.comboBox_City.Location = new System.Drawing.Point(43, 65);
            this.comboBox_City.Name = "comboBox_City";
            this.comboBox_City.Size = new System.Drawing.Size(135, 20);
            this.comboBox_City.TabIndex = 7;
            this.comboBox_City.SelectedIndexChanged += new System.EventHandler(this.comboBox_City_SelectedIndexChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.90099F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.75248F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.920792F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.75248F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.920792F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.75248F));
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
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(547, 228);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "国家";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "景区";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "省份";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(378, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "城市";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "级别";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(200, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 11;
            this.label14.Text = "票价";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 150);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 10;
            this.label15.Text = "简介";
            // 
            // textBox_SightsName
            // 
            this.textBox_SightsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.textBox_SightsName, 3);
            this.textBox_SightsName.Location = new System.Drawing.Point(57, 3);
            this.textBox_SightsName.Name = "textBox_SightsName";
            this.textBox_SightsName.ReadOnly = true;
            this.textBox_SightsName.Size = new System.Drawing.Size(307, 21);
            this.textBox_SightsName.TabIndex = 14;
            // 
            // textBox_Description
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.textBox_Description, 5);
            this.textBox_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Description.Location = new System.Drawing.Point(57, 87);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.ReadOnly = true;
            this.textBox_Description.Size = new System.Drawing.Size(487, 138);
            this.textBox_Description.TabIndex = 17;
            // 
            // textBox_Country
            // 
            this.textBox_Country.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Country.Location = new System.Drawing.Point(57, 31);
            this.textBox_Country.Name = "textBox_Country";
            this.textBox_Country.ReadOnly = true;
            this.textBox_Country.Size = new System.Drawing.Size(129, 21);
            this.textBox_Country.TabIndex = 18;
            // 
            // textBox_Province
            // 
            this.textBox_Province.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Province.Location = new System.Drawing.Point(235, 31);
            this.textBox_Province.Name = "textBox_Province";
            this.textBox_Province.ReadOnly = true;
            this.textBox_Province.Size = new System.Drawing.Size(129, 21);
            this.textBox_Province.TabIndex = 19;
            // 
            // textBox_City
            // 
            this.textBox_City.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_City.Location = new System.Drawing.Point(413, 31);
            this.textBox_City.Name = "textBox_City";
            this.textBox_City.ReadOnly = true;
            this.textBox_City.Size = new System.Drawing.Size(131, 21);
            this.textBox_City.TabIndex = 20;
            // 
            // textBox_SightsLevel
            // 
            this.textBox_SightsLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SightsLevel.Location = new System.Drawing.Point(57, 59);
            this.textBox_SightsLevel.Name = "textBox_SightsLevel";
            this.textBox_SightsLevel.ReadOnly = true;
            this.textBox_SightsLevel.Size = new System.Drawing.Size(129, 21);
            this.textBox_SightsLevel.TabIndex = 21;
            // 
            // textBox_Price
            // 
            this.textBox_Price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Price.Location = new System.Drawing.Point(235, 59);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.ReadOnly = true;
            this.textBox_Price.Size = new System.Drawing.Size(129, 21);
            this.textBox_Price.TabIndex = 22;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(378, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 23;
            this.label16.Text = "评分";
            // 
            // textBox_Stars
            // 
            this.textBox_Stars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Stars.Location = new System.Drawing.Point(413, 3);
            this.textBox_Stars.Name = "textBox_Stars";
            this.textBox_Stars.ReadOnly = true;
            this.textBox_Stars.Size = new System.Drawing.Size(131, 21);
            this.textBox_Stars.TabIndex = 24;
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
            this.tabControl1.Location = new System.Drawing.Point(199, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(573, 509);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(565, 483);
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
            this.groupBox2.Size = new System.Drawing.Size(553, 248);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "概况";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(6, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 217);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "留言";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(547, 197);
            this.dataGridView1.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.stgReadonlyPictures);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(565, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "相关图片";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // stgReadonlyPictures
            // 
            this.stgReadonlyPictures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stgReadonlyPictures.Location = new System.Drawing.Point(3, 3);
            this.stgReadonlyPictures.Name = "stgReadonlyPictures";
            this.stgReadonlyPictures.Size = new System.Drawing.Size(559, 477);
            this.stgReadonlyPictures.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(565, 483);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "相关日志";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(559, 477);
            this.dataGridView2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(565, 483);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "我的足迹";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(697, 527);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "名称";
            // 
            // textBox_FilterSightsName
            // 
            this.textBox_FilterSightsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FilterSightsName.Location = new System.Drawing.Point(43, 94);
            this.textBox_FilterSightsName.Name = "textBox_FilterSightsName";
            this.textBox_FilterSightsName.Size = new System.Drawing.Size(135, 21);
            this.textBox_FilterSightsName.TabIndex = 10;
            // 
            // checkBox_Visited
            // 
            this.checkBox_Visited.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_Visited.AutoSize = true;
            this.checkBox_Visited.Location = new System.Drawing.Point(43, 127);
            this.checkBox_Visited.Name = "checkBox_Visited";
            this.checkBox_Visited.Size = new System.Drawing.Size(60, 16);
            this.checkBox_Visited.TabIndex = 11;
            this.checkBox_Visited.Text = "游览过";
            this.checkBox_Visited.UseVisualStyleBackColor = true;
            // 
            // ViewSightsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.listBox_Sights);
            this.Name = "ViewSightsForm";
            this.Text = "SightsForm";
            this.Load += new System.EventHandler(this.SightsForm_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_FilterSightsName;
        private System.Windows.Forms.CheckBox checkBox_Visited;
    }
}