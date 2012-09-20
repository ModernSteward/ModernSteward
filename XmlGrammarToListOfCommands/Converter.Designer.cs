namespace XmlGrammarToListOfCommands
{
	partial class Converter
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
			this.labelXmlFile = new System.Windows.Forms.Label();
			this.textBoxXmlFilePath = new System.Windows.Forms.TextBox();
			this.textBoxListOfCommands = new System.Windows.Forms.TextBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelXmlFile
			// 
			this.labelXmlFile.AutoSize = true;
			this.labelXmlFile.Location = new System.Drawing.Point(12, 12);
			this.labelXmlFile.Name = "labelXmlFile";
			this.labelXmlFile.Size = new System.Drawing.Size(44, 13);
			this.labelXmlFile.TabIndex = 0;
			this.labelXmlFile.Text = ".xml file:";
			// 
			// textBoxXmlFilePath
			// 
			this.textBoxXmlFilePath.Location = new System.Drawing.Point(53, 9);
			this.textBoxXmlFilePath.Name = "textBoxXmlFilePath";
			this.textBoxXmlFilePath.Size = new System.Drawing.Size(479, 20);
			this.textBoxXmlFilePath.TabIndex = 1;
			// 
			// textBoxListOfCommands
			// 
			this.textBoxListOfCommands.Location = new System.Drawing.Point(15, 35);
			this.textBoxListOfCommands.Multiline = true;
			this.textBoxListOfCommands.Name = "textBoxListOfCommands";
			this.textBoxListOfCommands.Size = new System.Drawing.Size(598, 438);
			this.textBoxListOfCommands.TabIndex = 2;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Location = new System.Drawing.Point(538, 9);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowse.TabIndex = 3;
			this.buttonBrowse.Text = "Browse";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// Converter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(625, 485);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.textBoxListOfCommands);
			this.Controls.Add(this.textBoxXmlFilePath);
			this.Controls.Add(this.labelXmlFile);
			this.Name = "Converter";
			this.Text = "Convert your grammar into list of commands";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelXmlFile;
		private System.Windows.Forms.TextBox textBoxXmlFilePath;
		private System.Windows.Forms.TextBox textBoxListOfCommands;
		private System.Windows.Forms.Button buttonBrowse;
	}
}

