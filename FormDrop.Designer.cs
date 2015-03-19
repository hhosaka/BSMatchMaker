namespace BSMatchMaker {
	partial class FormDrop {
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
			this.listViewMain = new System.Windows.Forms.ListView();
			this.buttonOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listViewMain
			// 
			this.listViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewMain.CheckBoxes = true;
			this.listViewMain.Location = new System.Drawing.Point(0, 2);
			this.listViewMain.Name = "listViewMain";
			this.listViewMain.Size = new System.Drawing.Size(504, 219);
			this.listViewMain.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listViewMain.TabIndex = 0;
			this.listViewMain.UseCompatibleStateImageBehavior = false;
			this.listViewMain.View = System.Windows.Forms.View.List;
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(12, 227);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "Close";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// FormDrop
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(502, 262);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.listViewMain);
			this.Name = "FormDrop";
			this.Text = "FormDrop";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listViewMain;
		private System.Windows.Forms.Button buttonOK;
	}
}