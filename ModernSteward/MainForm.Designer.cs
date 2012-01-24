namespace ModernSteward
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn3 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn4 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            this.gridViewNotInitializedPlugins = new Telerik.WinControls.UI.RadGridView();
            this.buttonAddPlugin = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.gridViewInitializedPlugins = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.browseEditorAddPlugin = new Telerik.WinControls.UI.RadBrowseEditor();
            this.buttonStartStop = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.labelStartStop = new Telerik.WinControls.UI.RadLabel();
            this.menuItemFile = new Telerik.WinControls.UI.RadMenuItem();
            this.menuItemAdvanced = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemPluginWizard = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.menuItemMasterDictionary = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNotInitializedPlugins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddPlugin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInitializedPlugins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browseEditorAddPlugin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonStartStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelStartStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewNotInitializedPlugins
            // 
            this.gridViewNotInitializedPlugins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.gridViewNotInitializedPlugins.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridViewNotInitializedPlugins.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gridViewNotInitializedPlugins.ForeColor = System.Drawing.Color.Black;
            this.gridViewNotInitializedPlugins.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridViewNotInitializedPlugins.Location = new System.Drawing.Point(7, 21);
            // 
            // gridViewNotInitializedPlugins
            // 
            this.gridViewNotInitializedPlugins.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "nameOfThePlugin";
            gridViewTextBoxColumn3.HeaderText = "Име";
            gridViewTextBoxColumn3.Name = "nameOfThePlugin";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewCheckBoxColumn3.EnableExpressionEditor = false;
            gridViewCheckBoxColumn3.FieldName = "initializePluginOnStartup";
            gridViewCheckBoxColumn3.HeaderText = "Инициализирай при стартиране";
            gridViewCheckBoxColumn3.MinWidth = 20;
            gridViewCheckBoxColumn3.Name = "initializePluginOnStartup";
            gridViewCheckBoxColumn3.WrapText = true;
            gridViewCommandColumn3.EnableExpressionEditor = false;
            gridViewCommandColumn3.FieldName = "initializeThePlugin";
            gridViewCommandColumn3.Name = "initializeThePlugin";
            gridViewCommandColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.gridViewNotInitializedPlugins.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewCheckBoxColumn3,
            gridViewCommandColumn3});
            this.gridViewNotInitializedPlugins.MasterTemplate.EnableGrouping = false;
            this.gridViewNotInitializedPlugins.MasterTemplate.ShowRowHeaderColumn = false;
            this.gridViewNotInitializedPlugins.Name = "gridViewNotInitializedPlugins";
            this.gridViewNotInitializedPlugins.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridViewNotInitializedPlugins.ShowGroupPanel = false;
            this.gridViewNotInitializedPlugins.Size = new System.Drawing.Size(321, 233);
            this.gridViewNotInitializedPlugins.TabIndex = 0;
            // 
            // buttonAddPlugin
            // 
            this.buttonAddPlugin.Location = new System.Drawing.Point(193, 48);
            this.buttonAddPlugin.Name = "buttonAddPlugin";
            this.buttonAddPlugin.Size = new System.Drawing.Size(135, 24);
            this.buttonAddPlugin.TabIndex = 1;
            this.buttonAddPlugin.Text = "Добави плъгин";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.gridViewNotInitializedPlugins);
            this.radGroupBox1.FooterImageIndex = -1;
            this.radGroupBox1.FooterImageKey = "";
            this.radGroupBox1.HeaderImageIndex = -1;
            this.radGroupBox1.HeaderImageKey = "";
            this.radGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox1.HeaderText = "Неинициализирани";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 26);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            // 
            // 
            // 
            this.radGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox1.Size = new System.Drawing.Size(334, 261);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Неинициализирани";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.gridViewInitializedPlugins);
            this.radGroupBox2.FooterImageIndex = -1;
            this.radGroupBox2.FooterImageKey = "";
            this.radGroupBox2.HeaderImageIndex = -1;
            this.radGroupBox2.HeaderImageKey = "";
            this.radGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox2.HeaderText = "Инициализирани";
            this.radGroupBox2.Location = new System.Drawing.Point(352, 26);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            // 
            // 
            // 
            this.radGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox2.Size = new System.Drawing.Size(334, 261);
            this.radGroupBox2.TabIndex = 3;
            this.radGroupBox2.Text = "Инициализирани";
            // 
            // gridViewInitializedPlugins
            // 
            this.gridViewInitializedPlugins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.gridViewInitializedPlugins.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridViewInitializedPlugins.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gridViewInitializedPlugins.ForeColor = System.Drawing.Color.Black;
            this.gridViewInitializedPlugins.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gridViewInitializedPlugins.Location = new System.Drawing.Point(7, 21);
            // 
            // gridViewInitializedPlugins
            // 
            this.gridViewInitializedPlugins.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "nameOfThePlugin";
            gridViewTextBoxColumn4.HeaderText = "Име";
            gridViewTextBoxColumn4.Name = "nameOfThePlugin";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewCheckBoxColumn4.EnableExpressionEditor = false;
            gridViewCheckBoxColumn4.FieldName = "initializePluginOnStartup";
            gridViewCheckBoxColumn4.HeaderText = "Инициализирай при стартиране";
            gridViewCheckBoxColumn4.MinWidth = 20;
            gridViewCheckBoxColumn4.Name = "initializePluginOnStartup";
            gridViewCheckBoxColumn4.WrapText = true;
            gridViewCommandColumn4.EnableExpressionEditor = false;
            gridViewCommandColumn4.FieldName = "initializeThePlugin";
            gridViewCommandColumn4.Name = "initializeThePlugin";
            gridViewCommandColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.gridViewInitializedPlugins.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewCheckBoxColumn4,
            gridViewCommandColumn4});
            this.gridViewInitializedPlugins.MasterTemplate.EnableGrouping = false;
            this.gridViewInitializedPlugins.MasterTemplate.ShowRowHeaderColumn = false;
            this.gridViewInitializedPlugins.Name = "gridViewInitializedPlugins";
            this.gridViewInitializedPlugins.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridViewInitializedPlugins.ShowGroupPanel = false;
            this.gridViewInitializedPlugins.Size = new System.Drawing.Size(321, 233);
            this.gridViewInitializedPlugins.TabIndex = 0;
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.browseEditorAddPlugin);
            this.radGroupBox3.Controls.Add(this.buttonAddPlugin);
            this.radGroupBox3.FooterImageIndex = -1;
            this.radGroupBox3.FooterImageKey = "";
            this.radGroupBox3.HeaderImageIndex = -1;
            this.radGroupBox3.HeaderImageKey = "";
            this.radGroupBox3.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox3.HeaderText = "Добави плъгин";
            this.radGroupBox3.Location = new System.Drawing.Point(12, 294);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            // 
            // 
            // 
            this.radGroupBox3.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox3.Size = new System.Drawing.Size(334, 78);
            this.radGroupBox3.TabIndex = 4;
            this.radGroupBox3.Text = "Добави плъгин";
            // 
            // browseEditorAddPlugin
            // 
            this.browseEditorAddPlugin.Location = new System.Drawing.Point(7, 22);
            this.browseEditorAddPlugin.Name = "browseEditorAddPlugin";
            this.browseEditorAddPlugin.Size = new System.Drawing.Size(321, 20);
            this.browseEditorAddPlugin.TabIndex = 2;
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Location = new System.Drawing.Point(198, 21);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(130, 51);
            this.buttonStartStop.TabIndex = 5;
            this.buttonStartStop.Text = "Стартирай";
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Controls.Add(this.labelStartStop);
            this.radGroupBox4.Controls.Add(this.buttonStartStop);
            this.radGroupBox4.FooterImageIndex = -1;
            this.radGroupBox4.FooterImageKey = "";
            this.radGroupBox4.HeaderImageIndex = -1;
            this.radGroupBox4.HeaderImageKey = "";
            this.radGroupBox4.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox4.HeaderText = "Статус";
            this.radGroupBox4.Location = new System.Drawing.Point(352, 294);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            // 
            // 
            // 
            this.radGroupBox4.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox4.Size = new System.Drawing.Size(334, 79);
            this.radGroupBox4.TabIndex = 7;
            this.radGroupBox4.Text = "Статус";
            // 
            // labelStartStop
            // 
            this.labelStartStop.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.labelStartStop.ForeColor = System.Drawing.Color.Maroon;
            this.labelStartStop.Location = new System.Drawing.Point(19, 27);
            this.labelStartStop.Name = "labelStartStop";
            this.labelStartStop.Size = new System.Drawing.Size(164, 37);
            this.labelStartStop.TabIndex = 7;
            this.labelStartStop.Text = "ИЗКЛЮЧЕНО";
            // 
            // menuItemFile
            // 
            this.menuItemFile.AccessibleDescription = "Файл";
            this.menuItemFile.AccessibleName = "Файл";
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Text = "Файл";
            this.menuItemFile.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // menuItemAdvanced
            // 
            this.menuItemAdvanced.AccessibleDescription = "Напреднали";
            this.menuItemAdvanced.AccessibleName = "Напреднали";
            this.menuItemAdvanced.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItemPluginWizard,
            this.menuItemMasterDictionary});
            this.menuItemAdvanced.Name = "menuItemAdvanced";
            this.menuItemAdvanced.Text = "Напреднали";
            this.menuItemAdvanced.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // radMenuItemPluginWizard
            // 
            this.radMenuItemPluginWizard.AccessibleDescription = "radMenuItem3";
            this.radMenuItemPluginWizard.AccessibleName = "radMenuItem3";
            this.radMenuItemPluginWizard.Name = "radMenuItemPluginWizard";
            this.radMenuItemPluginWizard.Text = "Магьосник за плъгини";
            this.radMenuItemPluginWizard.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radMenuItemPluginWizard.Click += new System.EventHandler(this.radMenuItemPluginWizard_Click);
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuItemFile,
            this.menuItemAdvanced});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(698, 20);
            this.radMenu1.TabIndex = 8;
            this.radMenu1.Text = "radMenu1";
            // 
            // menuItemMasterDictionary
            // 
            this.menuItemMasterDictionary.AccessibleDescription = "Главен речник";
            this.menuItemMasterDictionary.AccessibleName = "Главен речник";
            this.menuItemMasterDictionary.Name = "menuItemMasterDictionary";
            this.menuItemMasterDictionary.Text = "Главен речник";
            this.menuItemMasterDictionary.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 385);
            this.Controls.Add(this.radMenu1);
            this.Controls.Add(this.radGroupBox4);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "MainForm";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNotInitializedPlugins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddPlugin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInitializedPlugins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.browseEditorAddPlugin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonStartStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            this.radGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelStartStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridViewNotInitializedPlugins;
        private Telerik.WinControls.UI.RadButton buttonAddPlugin;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView gridViewInitializedPlugins;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadBrowseEditor browseEditorAddPlugin;
        private Telerik.WinControls.UI.RadButton buttonStartStop;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadLabel labelStartStop;
        private Telerik.WinControls.UI.RadMenuItem menuItemFile;
        private Telerik.WinControls.UI.RadMenuItem menuItemAdvanced;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemPluginWizard;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem menuItemMasterDictionary;

    }
}
