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
            this.listView_Pic = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listView_Pic
            // 
            this.listView_Pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Pic.Location = new System.Drawing.Point(0, 0);
            this.listView_Pic.Name = "listView_Pic";
            this.listView_Pic.Size = new System.Drawing.Size(583, 327);
            this.listView_Pic.TabIndex = 9;
            this.listView_Pic.TileSize = new System.Drawing.Size(512, 256);
            this.listView_Pic.UseCompatibleStateImageBehavior = false;
            this.listView_Pic.View = System.Windows.Forms.View.Tile;
            // 
            // STGReadonlyPictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView_Pic);
            this.Name = "STGReadonlyPictures";
            this.Size = new System.Drawing.Size(583, 327);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_Pic;
    }
}
