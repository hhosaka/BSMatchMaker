namespace BSMatchMaker {
	partial class FormAbout {
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
			this.labelAppName = new System.Windows.Forms.Label();
			this.labelAppVersion = new System.Windows.Forms.Label();
			this.labelCopyright = new System.Windows.Forms.Label();
			this.labelCompany = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelAppName
			// 
			this.labelAppName.AutoSize = true;
			this.labelAppName.Location = new System.Drawing.Point(12, 9);
			this.labelAppName.Name = "labelAppName";
			this.labelAppName.Size = new System.Drawing.Size(25, 12);
			this.labelAppName.TabIndex = 0;
			this.labelAppName.Text = "title";
			// 
			// labelAppVersion
			// 
			this.labelAppVersion.AutoSize = true;
			this.labelAppVersion.Location = new System.Drawing.Point(12, 33);
			this.labelAppVersion.Name = "labelAppVersion";
			this.labelAppVersion.Size = new System.Drawing.Size(42, 12);
			this.labelAppVersion.TabIndex = 1;
			this.labelAppVersion.Text = "version";
			// 
			// labelCopyright
			// 
			this.labelCopyright.AutoSize = true;
			this.labelCopyright.Location = new System.Drawing.Point(12, 45);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new System.Drawing.Size(52, 12);
			this.labelCopyright.TabIndex = 2;
			this.labelCopyright.Text = "copyright";
			// 
			// labelCompany
			// 
			this.labelCompany.AutoSize = true;
			this.labelCompany.Location = new System.Drawing.Point(12, 21);
			this.labelCompany.Name = "labelCompany";
			this.labelCompany.Size = new System.Drawing.Size(50, 12);
			this.labelCompany.TabIndex = 3;
			this.labelCompany.Text = "company";
			// 
			// FormAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(230, 72);
			this.Controls.Add(this.labelCompany);
			this.Controls.Add(this.labelCopyright);
			this.Controls.Add(this.labelAppVersion);
			this.Controls.Add(this.labelAppName);
			this.Name = "FormAbout";
			this.Text = "About This Application";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelAppName;
		private System.Windows.Forms.Label labelAppVersion;
		private System.Windows.Forms.Label labelCopyright;
		private System.Windows.Forms.Label labelCompany;
	}
}