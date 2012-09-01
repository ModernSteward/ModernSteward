namespace ModernSteward
{
    partial class PluginCommandsForm
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
			this.treeViewCommands = new Telerik.WinControls.UI.RadTreeView();
			((System.ComponentModel.ISupportInitialize)(this.treeViewCommands)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// treeViewCommands
			// 
			this.treeViewCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewCommands.Location = new System.Drawing.Point(13, 13);
			this.treeViewCommands.Name = "treeViewCommands";
			this.treeViewCommands.Size = new System.Drawing.Size(489, 587);
			this.treeViewCommands.SpacingBetweenNodes = -1;
			this.treeViewCommands.TabIndex = 0;
			this.treeViewCommands.Text = "radTreeView1";
			// 
			// PluginCommandsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 612);
			this.Controls.Add(this.treeViewCommands);
			this.Name = "PluginCommandsForm";
			// 
			// 
			// 
			this.RootElement.ApplyShapeToControl = true;
			this.Text = "Commands";
			this.ThemeName = "ControlDefault";
			((System.ComponentModel.ISupportInitialize)(this.treeViewCommands)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private Telerik.WinControls.UI.RadTreeView treeViewCommands;
    }
}
