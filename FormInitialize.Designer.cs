namespace BSMatchMaker {
    partial class FormInitialize {
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.radioButtonImport = new System.Windows.Forms.RadioButton();
			this.groupBoxSource = new System.Windows.Forms.GroupBox();
			this.numericUpDownPlayer = new System.Windows.Forms.NumericUpDown();
			this.radioButtonGenerate = new System.Windows.Forms.RadioButton();
			this.groupBoxPoint = new System.Windows.Forms.GroupBox();
			this.radioButtonOnePoint = new System.Windows.Forms.RadioButton();
			this.radioButtonThreePoint = new System.Windows.Forms.RadioButton();
			this.groupBoxSource.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayer)).BeginInit();
			this.groupBoxPoint.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(13, 227);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(94, 227);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// radioButtonImport
			// 
			this.radioButtonImport.AutoSize = true;
			this.radioButtonImport.Location = new System.Drawing.Point(6, 65);
			this.radioButtonImport.Name = "radioButtonImport";
			this.radioButtonImport.Size = new System.Drawing.Size(55, 16);
			this.radioButtonImport.TabIndex = 2;
			this.radioButtonImport.Text = "Import";
			this.radioButtonImport.UseVisualStyleBackColor = true;
			this.radioButtonImport.Click += new System.EventHandler(this.radioButtonImport_Click);
			// 
			// groupBoxSource
			// 
			this.groupBoxSource.Controls.Add(this.numericUpDownPlayer);
			this.groupBoxSource.Controls.Add(this.radioButtonGenerate);
			this.groupBoxSource.Controls.Add(this.radioButtonImport);
			this.groupBoxSource.Location = new System.Drawing.Point(12, 10);
			this.groupBoxSource.Name = "groupBoxSource";
			this.groupBoxSource.Size = new System.Drawing.Size(260, 114);
			this.groupBoxSource.TabIndex = 3;
			this.groupBoxSource.TabStop = false;
			this.groupBoxSource.Text = "Data Source";
			// 
			// numericUpDownPlayer
			// 
			this.numericUpDownPlayer.Location = new System.Drawing.Point(6, 40);
			this.numericUpDownPlayer.Name = "numericUpDownPlayer";
			this.numericUpDownPlayer.Size = new System.Drawing.Size(120, 19);
			this.numericUpDownPlayer.TabIndex = 4;
			this.numericUpDownPlayer.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// radioButtonGenerate
			// 
			this.radioButtonGenerate.AutoSize = true;
			this.radioButtonGenerate.Checked = true;
			this.radioButtonGenerate.Location = new System.Drawing.Point(6, 18);
			this.radioButtonGenerate.Name = "radioButtonGenerate";
			this.radioButtonGenerate.Size = new System.Drawing.Size(128, 16);
			this.radioButtonGenerate.TabIndex = 3;
			this.radioButtonGenerate.TabStop = true;
			this.radioButtonGenerate.Text = "Generate by Number";
			this.radioButtonGenerate.UseVisualStyleBackColor = true;
			this.radioButtonGenerate.Click += new System.EventHandler(this.radioButtonGenerate_Click);
			// 
			// groupBoxPoint
			// 
			this.groupBoxPoint.Controls.Add(this.radioButtonOnePoint);
			this.groupBoxPoint.Controls.Add(this.radioButtonThreePoint);
			this.groupBoxPoint.Location = new System.Drawing.Point(12, 130);
			this.groupBoxPoint.Name = "groupBoxPoint";
			this.groupBoxPoint.Size = new System.Drawing.Size(260, 65);
			this.groupBoxPoint.TabIndex = 4;
			this.groupBoxPoint.TabStop = false;
			this.groupBoxPoint.Text = "Match Point";
			// 
			// radioButtonOnePoint
			// 
			this.radioButtonOnePoint.AutoSize = true;
			this.radioButtonOnePoint.Checked = true;
			this.radioButtonOnePoint.Location = new System.Drawing.Point(6, 20);
			this.radioButtonOnePoint.Name = "radioButtonOnePoint";
			this.radioButtonOnePoint.Size = new System.Drawing.Size(108, 16);
			this.radioButtonOnePoint.TabIndex = 3;
			this.radioButtonOnePoint.TabStop = true;
			this.radioButtonOnePoint.Text = "One Point Match";
			this.radioButtonOnePoint.UseVisualStyleBackColor = true;
			// 
			// radioButtonThreePoint
			// 
			this.radioButtonThreePoint.AutoSize = true;
			this.radioButtonThreePoint.Location = new System.Drawing.Point(6, 42);
			this.radioButtonThreePoint.Name = "radioButtonThreePoint";
			this.radioButtonThreePoint.Size = new System.Drawing.Size(117, 16);
			this.radioButtonThreePoint.TabIndex = 2;
			this.radioButtonThreePoint.Text = "Three Point Match";
			this.radioButtonThreePoint.UseVisualStyleBackColor = true;
			// 
			// FormInitialize
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.groupBoxPoint);
			this.Controls.Add(this.groupBoxSource);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Name = "FormInitialize";
			this.Text = "BS Match Maker Initialize";
			this.groupBoxSource.ResumeLayout(false);
			this.groupBoxSource.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayer)).EndInit();
			this.groupBoxPoint.ResumeLayout(false);
			this.groupBoxPoint.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RadioButton radioButtonImport;
        private System.Windows.Forms.GroupBox groupBoxSource;
        private System.Windows.Forms.RadioButton radioButtonGenerate;
        private System.Windows.Forms.GroupBox groupBoxPoint;
        private System.Windows.Forms.RadioButton radioButtonOnePoint;
        private System.Windows.Forms.RadioButton radioButtonThreePoint;
        private System.Windows.Forms.NumericUpDown numericUpDownPlayer;
    }
}
