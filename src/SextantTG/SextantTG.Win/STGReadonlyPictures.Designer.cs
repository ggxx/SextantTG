namespace SextantTG.Win
{
    partial class STGReadonlyPictures
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView_Pic = new System.Windows.Forms.ListView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_Pic
            // 
            this.listView_Pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Pic.Location = new System.Drawing.Point(0, 0);
            this.listView_Pic.Name = "listView_Pic";
            this.listView_Pic.Size = new System.Drawing.Size(583, 327);
            this.listView_Pic.TabIndex = 9;
            this.listView_Pic.TileSize = new System.Drawing.Size(128, 64);
            this.listView_Pic.UseCompatibleStateImageBehavior = false;
            this.listView_Pic.View = System.Windows.Forms.View.Tile;
            this.listView_Pic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Pic_MouseClick);
            this.listView_Pic.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_Pic_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewPictureToolStripMenuItem,
            this.addCommentToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(161, 70);
            // 
            // viewPictureToolStripMenuItem
            // 
            this.viewPictureToolStripMenuItem.Name = "viewPictureToolStripMenuItem";
            this.viewPictureToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.viewPictureToolStripMenuItem.Text = "查看大图(&P)";
            this.viewPictureToolStripMenuItem.Click += new System.EventHandler(this.viewPictureToolStripMenuItem_Click);
            // 
            // addCommentToolStripMenuItem
            // 
            this.addCommentToolStripMenuItem.Name = "addCommentToolStripMenuItem";
            this.addCommentToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addCommentToolStripMenuItem.Text = "添加评论(&C)";
            this.addCommentToolStripMenuItem.Click += new System.EventHandler(this.addCommentToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.saveAsToolStripMenuItem.Text = "目标另存为(&S)...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // STGReadonlyPictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView_Pic);
            this.Name = "STGReadonlyPictures";
            this.Size = new System.Drawing.Size(583, 327);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_Pic;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCommentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}
