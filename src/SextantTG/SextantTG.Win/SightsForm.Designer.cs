namespace SextantTG.Win
{
    partial class SightsForm
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
            this.comboBox_Countries = new System.Windows.Forms.ComboBox();
            this.bindingSource_Country = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox_Provinces = new System.Windows.Forms.ComboBox();
            this.bindingSource_Province = new System.Windows.Forms.BindingSource(this.components);
            this.listBox_Sights = new System.Windows.Forms.ListBox();
            this.bindingSource_City = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_Cities = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Country)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Province)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_City)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Countries
            // 
            this.comboBox_Countries.DataSource = this.bindingSource_Country;
            this.comboBox_Countries.FormattingEnabled = true;
            this.comboBox_Countries.Location = new System.Drawing.Point(72, 12);
            this.comboBox_Countries.Name = "comboBox_Countries";
            this.comboBox_Countries.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Countries.TabIndex = 0;
            this.comboBox_Countries.SelectedIndexChanged += new System.EventHandler(this.comboBox_Countries_SelectedIndexChanged);
            // 
            // comboBox_Provinces
            // 
            this.comboBox_Provinces.DataSource = this.bindingSource_Province;
            this.comboBox_Provinces.FormattingEnabled = true;
            this.comboBox_Provinces.Location = new System.Drawing.Point(72, 38);
            this.comboBox_Provinces.Name = "comboBox_Provinces";
            this.comboBox_Provinces.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Provinces.TabIndex = 1;
            this.comboBox_Provinces.SelectedIndexChanged += new System.EventHandler(this.comboBox_Provinces_SelectedIndexChanged);
            // 
            // listBox_Sights
            // 
            this.listBox_Sights.DataSource = this.bindingSource_City;
            this.listBox_Sights.FormattingEnabled = true;
            this.listBox_Sights.ItemHeight = 12;
            this.listBox_Sights.Location = new System.Drawing.Point(13, 88);
            this.listBox_Sights.Name = "listBox_Sights";
            this.listBox_Sights.Size = new System.Drawing.Size(180, 340);
            this.listBox_Sights.TabIndex = 2;
            this.listBox_Sights.SelectedIndexChanged += new System.EventHandler(this.listBox_Cities_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(199, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(413, 416);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "景点简介";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "景点收藏数/评分";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "景点Blogs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "景点图片";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "我的景点";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "国家";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "省份";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "城市";
            // 
            // comboBox_Cities
            // 
            this.comboBox_Cities.DataSource = this.bindingSource_Province;
            this.comboBox_Cities.FormattingEnabled = true;
            this.comboBox_Cities.Location = new System.Drawing.Point(72, 64);
            this.comboBox_Cities.Name = "comboBox_Cities";
            this.comboBox_Cities.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Cities.TabIndex = 6;
            // 
            // SightsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox_Cities);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.listBox_Sights);
            this.Controls.Add(this.comboBox_Provinces);
            this.Controls.Add(this.comboBox_Countries);
            this.Name = "SightsForm";
            this.Text = "SightsForm";
            this.Load += new System.EventHandler(this.SightsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Country)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Province)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_City)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Countries;
        private System.Windows.Forms.ComboBox comboBox_Provinces;
        private System.Windows.Forms.ListBox listBox_Sights;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource bindingSource_Country;
        private System.Windows.Forms.BindingSource bindingSource_Province;
        private System.Windows.Forms.BindingSource bindingSource_City;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_Cities;
    }
}