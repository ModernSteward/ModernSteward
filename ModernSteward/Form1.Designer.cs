namespace ModernSteward
{
    partial class Form1
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
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.comboBoxPlugins = new System.Windows.Forms.ComboBox();
            this.groupTriggerPlugin = new System.Windows.Forms.GroupBox();
            this.buttonTriggerPlugin = new System.Windows.Forms.Button();
            this.textBoxAdditionalCommands = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupTriggerPlugin.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddPlugin
            // 
            this.buttonAddPlugin.Location = new System.Drawing.Point(34, 101);
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
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Location = new System.Drawing.Point(9, 46);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(100, 20);
            this.textBoxKeyword.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxCommand);
            this.groupBox1.Controls.Add(this.buttonAddPlugin);
            this.groupBox1.Controls.Add(this.textBoxKeyword);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 130);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AddPlugin";
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(9, 73);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(100, 20);
            this.textBoxCommand.TabIndex = 3;
            // 
            // comboBoxPlugins
            // 
            this.comboBoxPlugins.FormattingEnabled = true;
            this.comboBoxPlugins.Location = new System.Drawing.Point(10, 18);
            this.comboBoxPlugins.Name = "comboBoxPlugins";
            this.comboBoxPlugins.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPlugins.TabIndex = 4;
            // 
            // groupTriggerPlugin
            // 
            this.groupTriggerPlugin.Controls.Add(this.textBoxAdditionalCommands);
            this.groupTriggerPlugin.Controls.Add(this.buttonTriggerPlugin);
            this.groupTriggerPlugin.Controls.Add(this.comboBoxPlugins);
            this.groupTriggerPlugin.Location = new System.Drawing.Point(138, 12);
            this.groupTriggerPlugin.Name = "groupTriggerPlugin";
            this.groupTriggerPlugin.Size = new System.Drawing.Size(137, 103);
            this.groupTriggerPlugin.TabIndex = 5;
            this.groupTriggerPlugin.TabStop = false;
            this.groupTriggerPlugin.Text = "TriggerPlugin";
            // 
            // buttonTriggerPlugin
            // 
            this.buttonTriggerPlugin.Location = new System.Drawing.Point(56, 71);
            this.buttonTriggerPlugin.Name = "buttonTriggerPlugin";
            this.buttonTriggerPlugin.Size = new System.Drawing.Size(75, 23);
            this.buttonTriggerPlugin.TabIndex = 5;
            this.buttonTriggerPlugin.Text = "Trigger plugin!";
            this.buttonTriggerPlugin.UseVisualStyleBackColor = true;
            this.buttonTriggerPlugin.Click += new System.EventHandler(this.buttonTriggerPlugin_Click);
            // 
            // textBoxAdditionalCommands
            // 
            this.textBoxAdditionalCommands.Location = new System.Drawing.Point(10, 45);
            this.textBoxAdditionalCommands.Name = "textBoxAdditionalCommands";
            this.textBoxAdditionalCommands.Size = new System.Drawing.Size(121, 20);
            this.textBoxAdditionalCommands.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 157);
            this.Controls.Add(this.groupTriggerPlugin);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "ModernSteward";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupTriggerPlugin.ResumeLayout(false);
            this.groupTriggerPlugin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddPlugin;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.ComboBox comboBoxPlugins;
        private System.Windows.Forms.GroupBox groupTriggerPlugin;
        private System.Windows.Forms.Button buttonTriggerPlugin;
        private System.Windows.Forms.TextBox textBoxAdditionalCommands;
    }
}

