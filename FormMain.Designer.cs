namespace BSMatchMaker {
    partial class FormMain {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.listViewMain = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.matchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.autoSavingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPercentageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMatchMakerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonMatch = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewMain
            // 
            resources.ApplyResources(this.listViewMain, "listViewMain");
            this.listViewMain.FullRowSelect = true;
            this.listViewMain.GridLines = true;
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.Details;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNew,
            this.openToolStripMenuItem,
            this.toolStripMenuSave,
            this.toolStripMenuItemSaveAs,
            this.toolStripSeparator2,
            this.toolStripMenuItemPrint,
            this.toolStripMenuItemExcel,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // toolStripMenuItemNew
            // 
            this.toolStripMenuItemNew.Name = "toolStripMenuItemNew";
            resources.ApplyResources(this.toolStripMenuItemNew, "toolStripMenuItemNew");
            this.toolStripMenuItemNew.Click += new System.EventHandler(this.toolStripMenuItemNew_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemOpen_Click);
            // 
            // toolStripMenuSave
            // 
            resources.ApplyResources(this.toolStripMenuSave, "toolStripMenuSave");
            this.toolStripMenuSave.Name = "toolStripMenuSave";
            this.toolStripMenuSave.Click += new System.EventHandler(this.toolStripMenuSave_Click);
            // 
            // toolStripMenuItemSaveAs
            // 
            resources.ApplyResources(this.toolStripMenuItemSaveAs, "toolStripMenuItemSaveAs");
            this.toolStripMenuItemSaveAs.Name = "toolStripMenuItemSaveAs";
            this.toolStripMenuItemSaveAs.Click += new System.EventHandler(this.toolStripMenuItemSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripMenuItemPrint
            // 
            resources.ApplyResources(this.toolStripMenuItemPrint, "toolStripMenuItemPrint");
            this.toolStripMenuItemPrint.Name = "toolStripMenuItemPrint";
            this.toolStripMenuItemPrint.Click += new System.EventHandler(this.toolStripMenuItemPrint_Click);
            // 
            // toolStripMenuItemExcel
            // 
            resources.ApplyResources(this.toolStripMenuItemExcel, "toolStripMenuItemExcel");
            this.toolStripMenuItemExcel.Name = "toolStripMenuItemExcel";
            this.toolStripMenuItemExcel.Click += new System.EventHandler(this.toolStripMenuItemExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matchToolStripMenuItem,
            this.dropToolStripMenuItem,
            this.seedToolStripMenuItem,
            this.blockToolStripMenuItem,
            this.toolStripSeparator1,
            this.autoSavingToolStripMenuItem,
            this.showPercentageToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // matchToolStripMenuItem
            // 
            resources.ApplyResources(this.matchToolStripMenuItem, "matchToolStripMenuItem");
            this.matchToolStripMenuItem.Name = "matchToolStripMenuItem";
            this.matchToolStripMenuItem.Click += new System.EventHandler(this.matchToolStripMenuItem_Click);
            // 
            // dropToolStripMenuItem
            // 
            resources.ApplyResources(this.dropToolStripMenuItem, "dropToolStripMenuItem");
            this.dropToolStripMenuItem.Name = "dropToolStripMenuItem";
            this.dropToolStripMenuItem.Click += new System.EventHandler(this.dropToolStripMenuItem_Click);
            // 
            // seedToolStripMenuItem
            // 
            this.seedToolStripMenuItem.CheckOnClick = true;
            resources.ApplyResources(this.seedToolStripMenuItem, "seedToolStripMenuItem");
            this.seedToolStripMenuItem.Name = "seedToolStripMenuItem";
            // 
            // blockToolStripMenuItem
            // 
            resources.ApplyResources(this.blockToolStripMenuItem, "blockToolStripMenuItem");
            this.blockToolStripMenuItem.Name = "blockToolStripMenuItem";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // autoSavingToolStripMenuItem
            // 
            this.autoSavingToolStripMenuItem.CheckOnClick = true;
            this.autoSavingToolStripMenuItem.Name = "autoSavingToolStripMenuItem";
            resources.ApplyResources(this.autoSavingToolStripMenuItem, "autoSavingToolStripMenuItem");
            this.autoSavingToolStripMenuItem.Click += new System.EventHandler(this.autoSavingToolStripMenuItem_Click);
            // 
            // showPercentageToolStripMenuItem
            // 
            this.showPercentageToolStripMenuItem.CheckOnClick = true;
            this.showPercentageToolStripMenuItem.Name = "showPercentageToolStripMenuItem";
            resources.ApplyResources(this.showPercentageToolStripMenuItem, "showPercentageToolStripMenuItem");
            this.showPercentageToolStripMenuItem.Click += new System.EventHandler(this.showPercentageToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usageToolStripMenuItem,
            this.toolStripMenuItem2,
            this.aboutMatchMakerToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // usageToolStripMenuItem
            // 
            this.usageToolStripMenuItem.Name = "usageToolStripMenuItem";
            resources.ApplyResources(this.usageToolStripMenuItem, "usageToolStripMenuItem");
            this.usageToolStripMenuItem.Click += new System.EventHandler(this.usageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItemSupport_Click);
            // 
            // aboutMatchMakerToolStripMenuItem
            // 
            this.aboutMatchMakerToolStripMenuItem.Name = "aboutMatchMakerToolStripMenuItem";
            resources.ApplyResources(this.aboutMatchMakerToolStripMenuItem, "aboutMatchMakerToolStripMenuItem");
            this.aboutMatchMakerToolStripMenuItem.Click += new System.EventHandler(this.MatchMakerToolStripMenuItemAbout_Click);
            // 
            // buttonMatch
            // 
            resources.ApplyResources(this.buttonMatch, "buttonMatch");
            this.buttonMatch.Name = "buttonMatch";
            this.buttonMatch.UseVisualStyleBackColor = true;
            this.buttonMatch.Click += new System.EventHandler(this.buttonMatch_Click);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonMatch);
            this.Controls.Add(this.listViewMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem usageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMatchMakerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNew;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem matchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dropToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem seedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem blockToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExcel;
		private System.Windows.Forms.Button buttonMatch;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveAs;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem autoSavingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showPercentageToolStripMenuItem;

    }
}

