namespace SextantTG.Win
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viweSightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myMainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mySightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myBlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myTourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cityDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provinceDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countryDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sightsDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sightsToolStripMenuItem,
            this.myToolStripMenuItem,
            this.managementToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowsToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sightsToolStripMenuItem
            // 
            this.sightsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viweSightsToolStripMenuItem});
            this.sightsToolStripMenuItem.Name = "sightsToolStripMenuItem";
            this.sightsToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.sightsToolStripMenuItem.Text = "景点(&S)";
            // 
            // viweSightsToolStripMenuItem
            // 
            this.viweSightsToolStripMenuItem.Name = "viweSightsToolStripMenuItem";
            this.viweSightsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viweSightsToolStripMenuItem.Text = "景点一览(&V)...";
            this.viweSightsToolStripMenuItem.Click += new System.EventHandler(this.viewSightsToolStripMenuItem_Click);
            // 
            // myToolStripMenuItem
            // 
            this.myToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myMainToolStripMenuItem,
            this.mySightsToolStripMenuItem,
            this.myBlogToolStripMenuItem,
            this.myTourToolStripMenuItem});
            this.myToolStripMenuItem.Name = "myToolStripMenuItem";
            this.myToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.myToolStripMenuItem.Text = "用户(&U)";
            // 
            // myMainToolStripMenuItem
            // 
            this.myMainToolStripMenuItem.Name = "myMainToolStripMenuItem";
            this.myMainToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.myMainToolStripMenuItem.Text = "我的主页(&H)...";
            // 
            // mySightsToolStripMenuItem
            // 
            this.mySightsToolStripMenuItem.Name = "mySightsToolStripMenuItem";
            this.mySightsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mySightsToolStripMenuItem.Text = "我的景点(&G)...";
            // 
            // myBlogToolStripMenuItem
            // 
            this.myBlogToolStripMenuItem.Name = "myBlogToolStripMenuItem";
            this.myBlogToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.myBlogToolStripMenuItem.Text = "我的日志(&B)...";
            // 
            // myTourToolStripMenuItem
            // 
            this.myTourToolStripMenuItem.Name = "myTourToolStripMenuItem";
            this.myTourToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.myTourToolStripMenuItem.Text = "我的旅行(&T)...";
            // 
            // managementToolStripMenuItem
            // 
            this.managementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dictToolStripMenuItem,
            this.userDictToolStripMenuItem,
            this.sightsDictToolStripMenuItem});
            this.managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            this.managementToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.managementToolStripMenuItem.Text = "管理(&M)";
            // 
            // dictToolStripMenuItem
            // 
            this.dictToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cityDictToolStripMenuItem,
            this.provinceDictToolStripMenuItem,
            this.countryDictToolStripMenuItem});
            this.dictToolStripMenuItem.Name = "dictToolStripMenuItem";
            this.dictToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dictToolStripMenuItem.Text = "字典管理(&D)";
            // 
            // cityDictToolStripMenuItem
            // 
            this.cityDictToolStripMenuItem.Name = "cityDictToolStripMenuItem";
            this.cityDictToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cityDictToolStripMenuItem.Text = "国家字典(&C)...";
            this.cityDictToolStripMenuItem.Click += new System.EventHandler(this.cityDictToolStripMenuItem_Click);
            // 
            // provinceDictToolStripMenuItem
            // 
            this.provinceDictToolStripMenuItem.Name = "provinceDictToolStripMenuItem";
            this.provinceDictToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.provinceDictToolStripMenuItem.Text = "省份字典(&P)...";
            this.provinceDictToolStripMenuItem.Click += new System.EventHandler(this.provinceDictToolStripMenuItem_Click);
            // 
            // countryDictToolStripMenuItem
            // 
            this.countryDictToolStripMenuItem.Name = "countryDictToolStripMenuItem";
            this.countryDictToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.countryDictToolStripMenuItem.Text = "城市字典(&I)...";
            this.countryDictToolStripMenuItem.Click += new System.EventHandler(this.countryDictToolStripMenuItem_Click);
            // 
            // userDictToolStripMenuItem
            // 
            this.userDictToolStripMenuItem.Name = "userDictToolStripMenuItem";
            this.userDictToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.userDictToolStripMenuItem.Text = "用户管理(&R)...";
            this.userDictToolStripMenuItem.Click += new System.EventHandler(this.userDictToolStripMenuItem_Click);
            // 
            // sightsDictToolStripMenuItem
            // 
            this.sightsDictToolStripMenuItem.Name = "sightsDictToolStripMenuItem";
            this.sightsDictToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sightsDictToolStripMenuItem.Text = "景点管理(&E)...";
            this.sightsDictToolStripMenuItem.Click += new System.EventHandler(this.sightsDictToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.windowsToolStripMenuItem.Text = "窗口(&W)";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.helpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.aboutToolStripMenuItem.Text = "关于 Sextant Tour Guide(A)";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 612);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Sextant Tour Guide";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem dictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cityDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provinceDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countryDictToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem viweSightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sightsDictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myMainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mySightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myBlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myTourToolStripMenuItem;
    }
}