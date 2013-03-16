namespace SextantTG.Win
{
    partial class FindSubTourForm
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
            this.listBox_Tour = new System.Windows.Forms.ListBox();
            this.bindingSource_Tour = new System.Windows.Forms.BindingSource(this.components);
            this.listBox_SubTour = new System.Windows.Forms.ListBox();
            this.bindingSource_SubTour = new System.Windows.Forms.BindingSource(this.components);
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Tour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_SubTour)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_Tour
            // 
            this.listBox_Tour.DataSource = this.bindingSource_Tour;
            this.listBox_Tour.FormattingEnabled = true;
            this.listBox_Tour.ItemHeight = 12;
            this.listBox_Tour.Location = new System.Drawing.Point(12, 12);
            this.listBox_Tour.Name = "listBox_Tour";
            this.listBox_Tour.Size = new System.Drawing.Size(240, 256);
            this.listBox_Tour.TabIndex = 0;
            this.listBox_Tour.SelectedIndexChanged += new System.EventHandler(this.listBox_Tour_SelectedIndexChanged);
            // 
            // listBox_SubTour
            // 
            this.listBox_SubTour.DataSource = this.bindingSource_SubTour;
            this.listBox_SubTour.FormattingEnabled = true;
            this.listBox_SubTour.ItemHeight = 12;
            this.listBox_SubTour.Location = new System.Drawing.Point(261, 12);
            this.listBox_SubTour.Name = "listBox_SubTour";
            this.listBox_SubTour.Size = new System.Drawing.Size(240, 256);
            this.listBox_SubTour.TabIndex = 1;
            this.listBox_SubTour.SelectedIndexChanged += new System.EventHandler(this.listBox_SubTour_SelectedIndexChanged);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancel.Location = new System.Drawing.Point(426, 280);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OK.Location = new System.Drawing.Point(345, 280);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "确定";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // FindSubTourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 315);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.listBox_SubTour);
            this.Controls.Add(this.listBox_Tour);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindSubTourForm";
            this.Text = "选择一个行程";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Tour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_SubTour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Tour;
        private System.Windows.Forms.ListBox listBox_SubTour;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.BindingSource bindingSource_Tour;
        private System.Windows.Forms.BindingSource bindingSource_SubTour;
    }
}