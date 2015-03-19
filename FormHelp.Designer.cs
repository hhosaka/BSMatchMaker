namespace BSMatchMaker
{
    partial class FormHelp
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			this.webBrowserMain = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// webBrowserMain
			// 
			this.webBrowserMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowserMain.Location = new System.Drawing.Point(0, 0);
			this.webBrowserMain.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowserMain.Name = "webBrowserMain";
			this.webBrowserMain.Size = new System.Drawing.Size(556, 316);
			this.webBrowserMain.TabIndex = 0;
			// 
			// FormHelp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(556, 316);
			this.Controls.Add(this.webBrowserMain);
			this.Name = "FormHelp";
			this.Text = "BS Match Maker Help";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserMain;
    }
}