namespace ModernSteward
{
    partial class LoadingForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
			this.buttonOfflineMode = new Telerik.WinControls.UI.RadButton();
			this.textBoxEmail = new Telerik.WinControls.UI.RadTextBox();
			this.textBoxPassword = new Telerik.WinControls.UI.RadTextBox();
			this.checkBoxGeneralPluginControl = new Telerik.WinControls.UI.RadCheckBox();
			this.buttonLogin = new Telerik.WinControls.UI.RadButton();
			((System.ComponentModel.ISupportInitialize)(this.buttonOfflineMode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBoxEmail)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textBoxPassword)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkBoxGeneralPluginControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonLogin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOfflineMode
			// 
			this.buttonOfflineMode.Location = new System.Drawing.Point(12, 268);
			this.buttonOfflineMode.Name = "buttonOfflineMode";
			this.buttonOfflineMode.Size = new System.Drawing.Size(79, 24);
			this.buttonOfflineMode.TabIndex = 4;
			this.buttonOfflineMode.Text = "Offline";
			this.buttonOfflineMode.Click += new System.EventHandler(this.buttonOfflineMode_Click);
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Location = new System.Drawing.Point(339, 235);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(166, 20);
			this.textBoxEmail.TabIndex = 6;
			this.textBoxEmail.TabStop = false;
			this.textBoxEmail.Text = "melissa@modernsteward.com";
			this.textBoxEmail.Enter += new System.EventHandler(this.textBoxEmail_Enter);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(339, 262);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(166, 20);
			this.textBoxPassword.TabIndex = 7;
			this.textBoxPassword.TabStop = false;
			this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);
			// 
			// checkBoxGeneralPluginControl
			// 
			this.checkBoxGeneralPluginControl.Location = new System.Drawing.Point(12, 294);
			this.checkBoxGeneralPluginControl.Name = "checkBoxGeneralPluginControl";
			this.checkBoxGeneralPluginControl.Size = new System.Drawing.Size(282, 18);
			this.checkBoxGeneralPluginControl.TabIndex = 8;
			this.checkBoxGeneralPluginControl.Text = "Advanced mode (all plugins have acces to all others)";
			// 
			// buttonLogin
			// 
			this.buttonLogin.Location = new System.Drawing.Point(426, 288);
			this.buttonLogin.Name = "buttonLogin";
			this.buttonLogin.Size = new System.Drawing.Size(79, 24);
			this.buttonLogin.TabIndex = 5;
			this.buttonLogin.Text = "Login";
			this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
			// 
			// LoadingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BackgroundImage = global::ModernSteward.Properties.Resources.loadingScreen;
			this.ClientSize = new System.Drawing.Size(543, 428);
			this.Controls.Add(this.checkBoxGeneralPluginControl);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.buttonLogin);
			this.Controls.Add(this.buttonOfflineMode);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "LoadingForm";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.Text = "ModernSteward";
			this.ThemeName = "ControlDefault";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadingForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.buttonOfflineMode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBoxEmail)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textBoxPassword)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkBoxGeneralPluginControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonLogin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private Telerik.WinControls.UI.RadButton buttonOfflineMode;
		private Telerik.WinControls.UI.RadTextBox textBoxEmail;
		private Telerik.WinControls.UI.RadTextBox textBoxPassword;
		private Telerik.WinControls.UI.RadCheckBox checkBoxGeneralPluginControl;
		private Telerik.WinControls.UI.RadButton buttonLogin;


	}
}
