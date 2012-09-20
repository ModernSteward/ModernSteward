namespace XmlGrammarToListOfCommandsForm
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
			this.labelZipFile = new System.Windows.Forms.Label();
			this.textBoxZipFilePath = new System.Windows.Forms.TextBox();
			this.textBoxCommands = new System.Windows.Forms.TextBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelZipFile
			// 
			this.labelZipFile.AutoSize = true;
			this.labelZipFile.Location = new System.Drawing.Point(12, 15);
			this.labelZipFile.Name = "labelZipFile";
			this.labelZipFile.Size = new System.Drawing.Size(41, 13);
			this.labelZipFile.TabIndex = 0;
			this.labelZipFile.Text = ".xml file";
			// 
			// textBoxZipFilePath
			// 
			this.textBoxZipFilePath.Location = new System.Drawing.Point(53, 12);
			this.textBoxZipFilePath.Name = "textBoxZipFilePath";
			this.textBoxZipFilePath.Size = new System.Drawing.Size(406, 20);
			this.textBoxZipFilePath.TabIndex = 1;
			// 
			// textBoxCommands
			// 
			this.textBoxCommands.Location = new System.Drawing.Point(15, 39);
			this.textBoxCommands.Multiline = true;
			this.textBoxCommands.Name = "textBoxCommands";
			this.textBoxCommands.Size = new System.Drawing.Size(525, 242);
			this.textBoxCommands.TabIndex = 2;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Location = new System.Drawing.Point(465, 10);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowse.TabIndex = 3;
			this.buttonBrowse.Text = "Browse";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(558, 297);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.textBoxCommands);
			this.Controls.Add(this.textBoxZipFilePath);
			this.Controls.Add(this.labelZipFile);
			this.Name = "MainForm";
			this.Text = ".xml to list of commands converter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelZipFile;
		private System.Windows.Forms.TextBox textBoxZipFilePath;
		private System.Windows.Forms.TextBox textBoxCommands;
		private System.Windows.Forms.Button buttonBrowse;
	}
}

