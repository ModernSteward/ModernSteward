namespace ModernSteward
{
    partial class AddPluginTestForm
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
            this.buttonAddPlugin = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonBrowseForPlugin = new System.Windows.Forms.Button();
            this.textBoxPluginPath = new System.Windows.Forms.TextBox();
            this.buttonStartTheEngine = new Telerik.WinControls.UI.RadButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonStartTheEngine)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddPlugin
            // 
            this.buttonAddPlugin.Location = new System.Drawing.Point(34, 128);
            this.buttonAddPlugin.Name = "buttonAddPlugin";
            this.buttonAddPlugin.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPlugin.TabIndex = 0;
            this.buttonAddPlugin.Text = "Add plugin";
            this.buttonAddPlugin.UseVisualStyleBackColor = true;
            this.buttonAddPlugin.Click += new System.EventHandler(this.buttonAddPlugin_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(9, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.Text = "Name";
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Location = new System.Drawing.Point(9, 46);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(100, 20);
            this.textBoxKeyword.TabIndex = 2;
            this.textBoxKeyword.Text = "Keyword";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonBrowseForPlugin);
            this.groupBox1.Controls.Add(this.textBoxPluginPath);
            this.groupBox1.Controls.Add(this.buttonAddPlugin);
            this.groupBox1.Controls.Add(this.textBoxKeyword);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 157);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AddPlugin";
            // 
            // buttonBrowseForPlugin
            // 
            this.buttonBrowseForPlugin.Location = new System.Drawing.Point(34, 99);
            this.buttonBrowseForPlugin.Name = "buttonBrowseForPlugin";
            this.buttonBrowseForPlugin.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseForPlugin.TabIndex = 4;
            this.buttonBrowseForPlugin.Text = "Browse";
            this.buttonBrowseForPlugin.UseVisualStyleBackColor = true;
            this.buttonBrowseForPlugin.Click += new System.EventHandler(this.buttonBrowseForPlugin_Click);
            // 
            // textBoxPluginPath
            // 
            this.textBoxPluginPath.Location = new System.Drawing.Point(9, 73);
            this.textBoxPluginPath.Name = "textBoxPluginPath";
            this.textBoxPluginPath.Size = new System.Drawing.Size(100, 20);
            this.textBoxPluginPath.TabIndex = 3;
            // 
            // buttonStartTheEngine
            // 
            this.buttonStartTheEngine.Location = new System.Drawing.Point(139, 13);
            this.buttonStartTheEngine.Name = "buttonStartTheEngine";
            this.buttonStartTheEngine.Size = new System.Drawing.Size(130, 156);
            this.buttonStartTheEngine.TabIndex = 4;
            this.buttonStartTheEngine.Text = "Start the speech recognition engine!";
            this.buttonStartTheEngine.TextWrap = true;
            this.buttonStartTheEngine.Click += new System.EventHandler(this.buttonStartTheEngine_Click);
            // 
            // AddPluginTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.Controls.Add(this.buttonStartTheEngine);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddPluginTestForm";
            this.Text = "ModernSteward";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonStartTheEngine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddPlugin;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonBrowseForPlugin;
        private System.Windows.Forms.TextBox textBoxPluginPath;
        private Telerik.WinControls.UI.RadButton buttonStartTheEngine;
    }
}

