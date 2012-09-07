namespace ModernSteward
{
	partial class MacroWizardForm
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
			this.labelStatus = new Telerik.WinControls.UI.RadLabel();
			this.labelCommand = new Telerik.WinControls.UI.RadLabel();
			this.textboxCommand = new Telerik.WinControls.UI.RadTextBox();
			this.buttonSave = new Telerik.WinControls.UI.RadButton();
			this.groupBoxMain = new Telerik.WinControls.UI.RadGroupBox();
			this.buttonRecord = new Telerik.WinControls.UI.RadButton();
			((System.ComponentModel.ISupportInitialize)(this.labelStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.labelCommand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textboxCommand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonSave)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupBoxMain)).BeginInit();
			this.groupBoxMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.buttonRecord)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// labelStatus
			// 
			this.labelStatus.Location = new System.Drawing.Point(5, 55);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(141, 18);
			this.labelStatus.TabIndex = 4;
			this.labelStatus.Text = "Press Esc to stop recording";
			// 
			// labelCommand
			// 
			this.labelCommand.Location = new System.Drawing.Point(5, 21);
			this.labelCommand.Name = "labelCommand";
			this.labelCommand.Size = new System.Drawing.Size(64, 18);
			this.labelCommand.TabIndex = 1;
			this.labelCommand.Text = "Command: ";
			// 
			// textboxCommand
			// 
			this.textboxCommand.Location = new System.Drawing.Point(75, 21);
			this.textboxCommand.Name = "textboxCommand";
			this.textboxCommand.Size = new System.Drawing.Size(220, 20);
			this.textboxCommand.TabIndex = 0;
			this.textboxCommand.TabStop = false;
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(240, 49);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(86, 24);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "Save";
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// groupBoxMain
			// 
			this.groupBoxMain.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this.groupBoxMain.Controls.Add(this.labelCommand);
			this.groupBoxMain.Controls.Add(this.labelStatus);
			this.groupBoxMain.Controls.Add(this.textboxCommand);
			this.groupBoxMain.Controls.Add(this.buttonSave);
			this.groupBoxMain.Controls.Add(this.buttonRecord);
			this.groupBoxMain.FooterImageIndex = -1;
			this.groupBoxMain.FooterImageKey = "";
			this.groupBoxMain.HeaderImageIndex = -1;
			this.groupBoxMain.HeaderImageKey = "";
			this.groupBoxMain.HeaderMargin = new System.Windows.Forms.Padding(0);
			this.groupBoxMain.HeaderText = "Create your own macro plugin";
			this.groupBoxMain.Location = new System.Drawing.Point(12, 12);
			this.groupBoxMain.Name = "groupBoxMain";
			this.groupBoxMain.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
			// 
			// 
			// 
			this.groupBoxMain.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
			this.groupBoxMain.Size = new System.Drawing.Size(333, 78);
			this.groupBoxMain.TabIndex = 5;
			this.groupBoxMain.Text = "Create your own macro plugin";
			// 
			// buttonRecord
			// 
			this.buttonRecord.Image = global::ModernSteward.Properties.Resources.iconMacro;
			this.buttonRecord.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonRecord.Location = new System.Drawing.Point(301, 19);
			this.buttonRecord.Name = "buttonRecord";
			this.buttonRecord.Size = new System.Drawing.Size(25, 24);
			this.buttonRecord.TabIndex = 2;
			this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
			// 
			// MacroWizardForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(357, 102);
			this.Controls.Add(this.groupBoxMain);
			this.Name = "MacroWizardForm";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.Text = "MacroWizard";
			this.ThemeName = "ControlDefault";
			((System.ComponentModel.ISupportInitialize)(this.labelStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.labelCommand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textboxCommand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonSave)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupBoxMain)).EndInit();
			this.groupBoxMain.ResumeLayout(false);
			this.groupBoxMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.buttonRecord)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private Telerik.WinControls.UI.RadLabel labelStatus;
		private Telerik.WinControls.UI.RadLabel labelCommand;
		private Telerik.WinControls.UI.RadTextBox textboxCommand;
		private Telerik.WinControls.UI.RadButton buttonRecord;
		private Telerik.WinControls.UI.RadButton buttonSave;
		private Telerik.WinControls.UI.RadGroupBox groupBoxMain;
    }
}
