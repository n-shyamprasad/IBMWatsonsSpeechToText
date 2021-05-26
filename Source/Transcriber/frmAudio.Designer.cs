
namespace Transcriber
{
	partial class frmAudio
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblAudioFilePath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.lblOutputPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(12, 9);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(90, 15);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Audio File path:\r\n";
            // 
            // lblAudioFilePath
            // 
            this.lblAudioFilePath.AutoSize = true;
            this.lblAudioFilePath.Location = new System.Drawing.Point(99, 9);
            this.lblAudioFilePath.Name = "lblAudioFilePath";
            this.lblAudioFilePath.Size = new System.Drawing.Size(47, 15);
            this.lblAudioFilePath.TabIndex = 3;
            this.lblAudioFilePath.Text = "<path>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Count:";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(61, 33);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(54, 15);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "<count>";
            // 
            // btnConvert
            // 
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConvert.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConvert.Location = new System.Drawing.Point(12, 51);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(507, 23);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // Progress
            // 
            this.Progress.Location = new System.Drawing.Point(12, 80);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(507, 22);
            this.Progress.TabIndex = 8;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // lblOutputPath
            // 
            this.lblOutputPath.AutoSize = true;
            this.lblOutputPath.Location = new System.Drawing.Point(13, 105);
            this.lblOutputPath.Name = "lblOutputPath";
            this.lblOutputPath.Size = new System.Drawing.Size(0, 15);
            this.lblOutputPath.TabIndex = 9;
            // 
            // frmAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 122);
            this.Controls.Add(this.lblOutputPath);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAudioFilePath);
            this.Controls.Add(this.lbl1);
            this.MaximizeBox = false;
            this.Name = "frmAudio";
            this.Text = "IBM Watsons - Speech To Text";
            this.Load += new System.EventHandler(this.frmAudio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblAudioFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ProgressBar Progress;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Label lblOutputPath;
    }
}

