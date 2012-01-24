namespace PluginWizard
{
    partial class PluginWizardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginWizardForm));
            this.pluginWizard = new Telerik.WinControls.UI.RadWizard();
            this.wizardCompletionPage1 = new Telerik.WinControls.UI.WizardCompletionPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.labelWelcome = new Telerik.WinControls.UI.RadLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonBrowse = new Telerik.WinControls.UI.RadButton();
            this.textBoxSaveFilePath = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.groupBoxBuiltInDictionary = new Telerik.WinControls.UI.RadGroupBox();
            this.groupBoxGrammarBuilder = new Telerik.WinControls.UI.RadGroupBox();
            this.textBoxContext = new Telerik.WinControls.UI.RadTextBox();
            this.labelContext = new Telerik.WinControls.UI.RadLabel();
            this.checkBoxItemOptional = new Telerik.WinControls.UI.RadCheckBox();
            this.checkBoxIsTheNodeDictation = new Telerik.WinControls.UI.RadCheckBox();
            this.treeViewCommands = new Telerik.WinControls.UI.RadTreeView();
            this.buttonLoadTree = new Telerik.WinControls.UI.RadButton();
            this.buttonExportToXML = new Telerik.WinControls.UI.RadButton();
            this.wizardWelcomePage1 = new Telerik.WinControls.UI.WizardWelcomePage();
            this.wizardPage1 = new Telerik.WinControls.UI.WizardPage();
            this.masterDictionaryManager1 = new MasterDictionaryUserControl.MasterDictionaryManager();
            ((System.ComponentModel.ISupportInitialize)(this.pluginWizard)).BeginInit();
            this.pluginWizard.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelWelcome)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxSaveFilePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxBuiltInDictionary)).BeginInit();
            this.groupBoxBuiltInDictionary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxGrammarBuilder)).BeginInit();
            this.groupBoxGrammarBuilder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxItemOptional)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxIsTheNodeDictation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewCommands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLoadTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExportToXML)).BeginInit();
            this.SuspendLayout();
            // 
            // pluginWizard
            // 
            this.pluginWizard.CompletionPage = this.wizardCompletionPage1;
            this.pluginWizard.Controls.Add(this.panel1);
            this.pluginWizard.Controls.Add(this.panel2);
            this.pluginWizard.Controls.Add(this.panel3);
            this.pluginWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pluginWizard.Location = new System.Drawing.Point(0, 0);
            this.pluginWizard.Mode = Telerik.WinControls.UI.WizardMode.Wizard97;
            this.pluginWizard.Name = "pluginWizard";
            this.pluginWizard.PageHeaderIcon = ((System.Drawing.Image)(resources.GetObject("pluginWizard.PageHeaderIcon")));
            this.pluginWizard.Pages.Add(this.wizardWelcomePage1);
            this.pluginWizard.Pages.Add(this.wizardPage1);
            this.pluginWizard.Pages.Add(this.wizardCompletionPage1);
            this.pluginWizard.Size = new System.Drawing.Size(653, 553);
            this.pluginWizard.TabIndex = 0;
            this.pluginWizard.WelcomePage = this.wizardWelcomePage1;
            this.pluginWizard.Finish += new System.EventHandler(this.pluginWizard_Finish);
            this.pluginWizard.Cancel += new System.EventHandler(this.pluginWizard_Cancel);
            // 
            // wizardCompletionPage1
            // 
            this.wizardCompletionPage1.ContentArea = this.panel3;
            this.wizardCompletionPage1.HeaderVisibility = Telerik.WinControls.ElementVisibility.Hidden;
            this.wizardCompletionPage1.Name = "wizardCompletionPage1";
            this.wizardCompletionPage1.Title = "Завършване";
            this.wizardCompletionPage1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(150, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(503, 410);
            this.panel3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.radLabel1);
            this.panel1.Controls.Add(this.labelWelcome);
            this.panel1.Location = new System.Drawing.Point(150, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 449);
            this.panel1.TabIndex = 0;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(17, 75);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(423, 16);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Чрез този магьосник можете да създадете нов плъгин за \"Модерният иконом\"";
            // 
            // labelWelcome
            // 
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.Location = new System.Drawing.Point(13, 22);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(253, 46);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Добре дошли!";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.buttonBrowse);
            this.panel2.Controls.Add(this.textBoxSaveFilePath);
            this.panel2.Controls.Add(this.radLabel2);
            this.panel2.Controls.Add(this.groupBoxBuiltInDictionary);
            this.panel2.Controls.Add(this.groupBoxGrammarBuilder);
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(653, 441);
            this.panel2.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(528, 414);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(108, 24);
            this.buttonBrowse.TabIndex = 8;
            this.buttonBrowse.Text = "Разлисти";
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxSaveFilePath
            // 
            this.textBoxSaveFilePath.Location = new System.Drawing.Point(84, 417);
            this.textBoxSaveFilePath.Name = "textBoxSaveFilePath";
            this.textBoxSaveFilePath.Size = new System.Drawing.Size(437, 20);
            this.textBoxSaveFilePath.TabIndex = 7;
            this.textBoxSaveFilePath.TabStop = false;
            this.textBoxSaveFilePath.Text = "C:\\";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 419);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(76, 16);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "Директория: ";
            // 
            // groupBoxBuiltInDictionary
            // 
            this.groupBoxBuiltInDictionary.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.groupBoxBuiltInDictionary.Controls.Add(this.masterDictionaryManager1);
            this.groupBoxBuiltInDictionary.FooterImageIndex = -1;
            this.groupBoxBuiltInDictionary.FooterImageKey = "";
            this.groupBoxBuiltInDictionary.HeaderImageIndex = -1;
            this.groupBoxBuiltInDictionary.HeaderImageKey = "";
            this.groupBoxBuiltInDictionary.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.groupBoxBuiltInDictionary.HeaderText = "Вграден речник";
            this.groupBoxBuiltInDictionary.Location = new System.Drawing.Point(335, 3);
            this.groupBoxBuiltInDictionary.Name = "groupBoxBuiltInDictionary";
            this.groupBoxBuiltInDictionary.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            // 
            // 
            // 
            this.groupBoxBuiltInDictionary.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.groupBoxBuiltInDictionary.Size = new System.Drawing.Size(306, 405);
            this.groupBoxBuiltInDictionary.TabIndex = 5;
            this.groupBoxBuiltInDictionary.Text = "Вграден речник";
            // 
            // groupBoxGrammarBuilder
            // 
            this.groupBoxGrammarBuilder.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.groupBoxGrammarBuilder.Controls.Add(this.textBoxContext);
            this.groupBoxGrammarBuilder.Controls.Add(this.labelContext);
            this.groupBoxGrammarBuilder.Controls.Add(this.checkBoxItemOptional);
            this.groupBoxGrammarBuilder.Controls.Add(this.checkBoxIsTheNodeDictation);
            this.groupBoxGrammarBuilder.Controls.Add(this.treeViewCommands);
            this.groupBoxGrammarBuilder.Controls.Add(this.buttonLoadTree);
            this.groupBoxGrammarBuilder.Controls.Add(this.buttonExportToXML);
            this.groupBoxGrammarBuilder.FooterImageIndex = -1;
            this.groupBoxGrammarBuilder.FooterImageKey = "";
            this.groupBoxGrammarBuilder.HeaderImageIndex = -1;
            this.groupBoxGrammarBuilder.HeaderImageKey = "";
            this.groupBoxGrammarBuilder.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.groupBoxGrammarBuilder.HeaderText = "Граматика";
            this.groupBoxGrammarBuilder.Location = new System.Drawing.Point(12, 3);
            this.groupBoxGrammarBuilder.Name = "groupBoxGrammarBuilder";
            this.groupBoxGrammarBuilder.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            // 
            // 
            // 
            this.groupBoxGrammarBuilder.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.groupBoxGrammarBuilder.Size = new System.Drawing.Size(317, 405);
            this.groupBoxGrammarBuilder.TabIndex = 4;
            this.groupBoxGrammarBuilder.Text = "Граматика";
            // 
            // textBoxContext
            // 
            this.textBoxContext.Location = new System.Drawing.Point(159, 353);
            this.textBoxContext.Name = "textBoxContext";
            this.textBoxContext.Size = new System.Drawing.Size(152, 20);
            this.textBoxContext.TabIndex = 6;
            this.textBoxContext.TabStop = false;
            this.textBoxContext.TextChanged += new System.EventHandler(this.textBoxContext_TextChanged);
            // 
            // labelContext
            // 
            this.labelContext.Location = new System.Drawing.Point(159, 336);
            this.labelContext.Name = "labelContext";
            this.labelContext.Size = new System.Drawing.Size(54, 18);
            this.labelContext.TabIndex = 5;
            this.labelContext.Text = "Контекст:";
            // 
            // checkBoxItemOptional
            // 
            this.checkBoxItemOptional.Location = new System.Drawing.Point(5, 356);
            this.checkBoxItemOptional.Name = "checkBoxItemOptional";
            this.checkBoxItemOptional.Size = new System.Drawing.Size(73, 18);
            this.checkBoxItemOptional.TabIndex = 4;
            this.checkBoxItemOptional.Text = "Избираем";
            this.checkBoxItemOptional.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.checkBoxItemOptional_ToggleStateChanged);
            // 
            // checkBoxIsTheNodeDictation
            // 
            this.checkBoxIsTheNodeDictation.Location = new System.Drawing.Point(5, 336);
            this.checkBoxIsTheNodeDictation.Name = "checkBoxIsTheNodeDictation";
            this.checkBoxIsTheNodeDictation.Size = new System.Drawing.Size(75, 18);
            this.checkBoxIsTheNodeDictation.TabIndex = 3;
            this.checkBoxIsTheNodeDictation.Text = "Диктуване";
            this.checkBoxIsTheNodeDictation.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.checkBoxIsTheNodeDictation_ToggleStateChanged);
            // 
            // treeViewCommands
            // 
            this.treeViewCommands.Location = new System.Drawing.Point(5, 21);
            this.treeViewCommands.Name = "treeViewCommands";
            this.treeViewCommands.Size = new System.Drawing.Size(307, 307);
            this.treeViewCommands.SpacingBetweenNodes = -1;
            this.treeViewCommands.TabIndex = 0;
            this.treeViewCommands.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.treeViewCommands_SelectedNodeChanged);
            this.treeViewCommands.NodeAdded += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.treeViewCommands_NodeAdded);
            // 
            // buttonLoadTree
            // 
            this.buttonLoadTree.Location = new System.Drawing.Point(159, 376);
            this.buttonLoadTree.Name = "buttonLoadTree";
            this.buttonLoadTree.Size = new System.Drawing.Size(153, 24);
            this.buttonLoadTree.TabIndex = 2;
            this.buttonLoadTree.Text = "Зареди граматика";
            this.buttonLoadTree.Click += new System.EventHandler(this.buttonLoadTree_Click);
            // 
            // buttonExportToXML
            // 
            this.buttonExportToXML.Location = new System.Drawing.Point(5, 376);
            this.buttonExportToXML.Name = "buttonExportToXML";
            this.buttonExportToXML.Size = new System.Drawing.Size(151, 24);
            this.buttonExportToXML.TabIndex = 1;
            this.buttonExportToXML.Text = "Запази граматиката";
            this.buttonExportToXML.Click += new System.EventHandler(this.buttonExportToXML_Click);
            // 
            // wizardWelcomePage1
            // 
            this.wizardWelcomePage1.ContentArea = this.panel1;
            this.wizardWelcomePage1.HeaderVisibility = Telerik.WinControls.ElementVisibility.Hidden;
            this.wizardWelcomePage1.Name = "wizardWelcomePage1";
            this.wizardWelcomePage1.Title = "Създаване на плъгин";
            this.wizardWelcomePage1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // wizardPage1
            // 
            this.wizardPage1.ContentArea = this.panel2;
            this.wizardPage1.Header = "";
            this.wizardPage1.HeaderVisibility = Telerik.WinControls.ElementVisibility.Hidden;
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Title = "Създаване на граматика";
            this.wizardPage1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // masterDictionaryManager1
            // 
            this.masterDictionaryManager1.Location = new System.Drawing.Point(6, 22);
            this.masterDictionaryManager1.Name = "masterDictionaryManager1";
            this.masterDictionaryManager1.Size = new System.Drawing.Size(295, 378);
            this.masterDictionaryManager1.TabIndex = 0;
            // 
            // PluginWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 553);
            this.Controls.Add(this.pluginWizard);
            this.Name = "PluginWizardForm";
            this.Text = "Магьосник за създаване на плъгини";
            ((System.ComponentModel.ISupportInitialize)(this.pluginWizard)).EndInit();
            this.pluginWizard.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelWelcome)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxSaveFilePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxBuiltInDictionary)).EndInit();
            this.groupBoxBuiltInDictionary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxGrammarBuilder)).EndInit();
            this.groupBoxGrammarBuilder.ResumeLayout(false);
            this.groupBoxGrammarBuilder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxItemOptional)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxIsTheNodeDictation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewCommands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLoadTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExportToXML)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadWizard pluginWizard;
        private Telerik.WinControls.UI.WizardCompletionPage wizardCompletionPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.WizardWelcomePage wizardWelcomePage1;
        private Telerik.WinControls.UI.WizardPage wizardPage1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel labelWelcome;
        private Telerik.WinControls.UI.RadCheckBox checkBoxIsTheNodeDictation;
        private Telerik.WinControls.UI.RadButton buttonLoadTree;
        private Telerik.WinControls.UI.RadButton buttonExportToXML;
        private Telerik.WinControls.UI.RadTreeView treeViewCommands;
        private Telerik.WinControls.UI.RadGroupBox groupBoxBuiltInDictionary;
        private Telerik.WinControls.UI.RadGroupBox groupBoxGrammarBuilder;
        private Telerik.WinControls.UI.RadButton buttonBrowse;
        private Telerik.WinControls.UI.RadTextBox textBoxSaveFilePath;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox textBoxContext;
        private Telerik.WinControls.UI.RadLabel labelContext;
        private Telerik.WinControls.UI.RadCheckBox checkBoxItemOptional;
        private MasterDictionaryUserControl.MasterDictionaryManager masterDictionaryManager1;
    }
}

