namespace SextantTG.Win
{
    partial class WeiboOauthForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.OauthCode_textbox = new System.Windows.Forms.TextBox();
            this.OauthOk_button = new System.Windows.Forms.Button();
            this.OauthCancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入授权码：";
            // 
            // OauthCode_textbox
            // 
            this.OauthCode_textbox.Location = new System.Drawing.Point(124, 15);
            this.OauthCode_textbox.Name = "OauthCode_textbox";
            this.OauthCode_textbox.Size = new System.Drawing.Size(100, 21);
            this.OauthCode_textbox.TabIndex = 1;
            // 
            // OauthOk_button
            // 
            this.OauthOk_button.Location = new System.Drawing.Point(30, 69);
            this.OauthOk_button.Name = "OauthOk_button";
            this.OauthOk_button.Size = new System.Drawing.Size(75, 23);
            this.OauthOk_button.TabIndex = 2;
            this.OauthOk_button.Text = "OK";
            this.OauthOk_button.UseVisualStyleBackColor = true;
            this.OauthOk_button.Click += new System.EventHandler(this.OauthOk_button_Click);
            // 
            // OauthCancel_button
            // 
            this.OauthCancel_button.Location = new System.Drawing.Point(159, 69);
            this.OauthCancel_button.Name = "OauthCancel_button";
            this.OauthCancel_button.Size = new System.Drawing.Size(75, 23);
            this.OauthCancel_button.TabIndex = 3;
            this.OauthCancel_button.Text = "Cancel";
            this.OauthCancel_button.UseVisualStyleBackColor = true;
            this.OauthCancel_button.Click += new System.EventHandler(this.OauthCancel_button_Click);
            // 
            // WeiboOauthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 116);
            this.Controls.Add(this.OauthCancel_button);
            this.Controls.Add(this.OauthOk_button);
            this.Controls.Add(this.OauthCode_textbox);
            this.Controls.Add(this.label1);
            this.Name = "WeiboOauthForm";
            this.Text = "微博链接授权";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OauthCode_textbox;
        private System.Windows.Forms.Button OauthOk_button;
        private System.Windows.Forms.Button OauthCancel_button;

    }
}