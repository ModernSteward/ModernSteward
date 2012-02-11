namespace ModernSteward
{
    partial class MasterDictionaryForm
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
            this.masterDictionaryManager = new MasterDictionaryUserControl.MasterDictionaryManager();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // masterDictionaryManager
            // 
            this.masterDictionaryManager.Location = new System.Drawing.Point(13, 13);
            this.masterDictionaryManager.Name = "masterDictionaryManager";
            this.masterDictionaryManager.Size = new System.Drawing.Size(295, 381);
            this.masterDictionaryManager.TabIndex = 0;
            // 
            // MasterDictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 401);
            this.Controls.Add(this.masterDictionaryManager);
            this.Name = "MasterDictionaryForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Главен речник";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MasterDictionaryUserControl.MasterDictionaryManager masterDictionaryManager;
    }
}
