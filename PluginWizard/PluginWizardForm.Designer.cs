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
            this.wizardWelcomePage1 = new Telerik.WinControls.UI.WizardWelcomePage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.wizardPage1 = new Telerik.WinControls.UI.WizardPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.wizardCompletionPage1 = new Telerik.WinControls.UI.WizardCompletionPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelWelcome = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.treeViewCommands = new Telerik.WinControls.UI.RadTreeView();
            this.buttonExportToXML = new Telerik.WinControls.UI.RadButton();
            this.buttonLoadTree = new Telerik.WinControls.UI.RadButton();
            this.checkBoxIsTheNodeDictation = new Telerik.WinControls.UI.RadCheckBox();
            this.groupBoxGrammarBuilder = new Telerik.WinControls.UI.RadGroupBox();
            this.groupBoxBuiltInDictionary = new Telerik.WinControls.UI.RadGroupBox();
            this.gridViewDictionaryItems = new Telerik.WinControls.UI.RadGridView();
            this.buttonAddNewWordToTheMasterDictionary = new Telerik.WinControls.UI.RadButton();
            this.textBoxNewWordToAdd = new Telerik.WinControls.UI.RadTextBox();
            this.buttonDeleteSelectedWord = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.textBoxSaveFilePath = new Telerik.WinControls.UI.RadTextBox();
            this.buttonBrowse = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.pluginWizard)).BeginInit();
            this.pluginWizard.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelWelcome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewCommands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExportToXML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLoadTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxIsTheNodeDictation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxGrammarBuilder)).BeginInit();
            this.groupBoxGrammarBuilder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxBuiltInDictionary)).BeginInit();
            this.groupBoxBuiltInDictionary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDictionaryItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddNewWordToTheMasterDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxNewWordToAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDeleteSelectedWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxSaveFilePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBrowse)).BeginInit();
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
            this.pluginWizard.Size = new System.Drawing.Size(653, 514);
            this.pluginWizard.TabIndex = 0;
            this.pluginWizard.WelcomePage = this.wizardWelcomePage1;
            this.pluginWizard.Finish += new System.EventHandler(this.pluginWizard_Finish);
            // 
            // wizardWelcomePage1
            // 
            this.wizardWelcomePage1.ContentArea = this.panel1;
            this.wizardWelcomePage1.HeaderVisibility = Telerik.WinControls.ElementVisibility.Hidden;
            this.wizardWelcomePage1.Name = "wizardWelcomePage1";
            this.wizardWelcomePage1.Title = "Създаване на плъгин";
            this.wizardWelcomePage1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.radLabel1);
            this.panel1.Controls.Add(this.labelWelcome);
            this.panel1.Location = new System.Drawing.Point(150, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 381);
            this.panel1.TabIndex = 0;
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
            this.panel2.Size = new System.Drawing.Size(653, 402);
            this.panel2.TabIndex = 1;
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
            this.panel3.Size = new System.Drawing.Size(503, 381);
            this.panel3.TabIndex = 2;
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
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(17, 75);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(423, 16);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Чрез този магьосник можете да създадете нов плъгин за \"Модерният иконом\"";
            // 
            // treeViewCommands
            // 
            this.treeViewCommands.Location = new System.Drawing.Point(14, 22);
            this.treeViewCommands.Name = "treeViewCommands";
            this.treeViewCommands.Size = new System.Drawing.Size(290, 288);
            this.treeViewCommands.SpacingBetweenNodes = -1;
            this.treeViewCommands.TabIndex = 0;
            this.treeViewCommands.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.treeViewCommands_SelectedNodeChanged);
            // 
            // buttonExportToXML
            // 
            this.buttonExportToXML.Location = new System.Drawing.Point(14, 338);
            this.buttonExportToXML.Name = "buttonExportToXML";
            this.buttonExportToXML.Size = new System.Drawing.Size(142, 24);
            this.buttonExportToXML.TabIndex = 1;
            this.buttonExportToXML.Text = "Запази граматиката";
            this.buttonExportToXML.Click += new System.EventHandler(this.buttonExportToXML_Click);
            // 
            // buttonLoadTree
            // 
            this.buttonLoadTree.Location = new System.Drawing.Point(162, 338);
            this.buttonLoadTree.Name = "buttonLoadTree";
            this.buttonLoadTree.Size = new System.Drawing.Size(142, 24);
            this.buttonLoadTree.TabIndex = 2;
            this.buttonLoadTree.Text = "Зареди граматика";
            this.buttonLoadTree.Click += new System.EventHandler(this.buttonLoadTree_Click);
            // 
            // checkBoxIsTheNodeDictation
            // 
            this.checkBoxIsTheNodeDictation.Location = new System.Drawing.Point(17, 316);
            this.checkBoxIsTheNodeDictation.Name = "checkBoxIsTheNodeDictation";
            this.checkBoxIsTheNodeDictation.Size = new System.Drawing.Size(75, 18);
            this.checkBoxIsTheNodeDictation.TabIndex = 3;
            this.checkBoxIsTheNodeDictation.Text = "Диктуване";
            this.checkBoxIsTheNodeDictation.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.checkBoxIsTheNodeDictation_ToggleStateChanged);
            // 
            // groupBoxGrammarBuilder
            // 
            this.groupBoxGrammarBuilder.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
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
            this.groupBoxGrammarBuilder.Size = new System.Drawing.Size(317, 367);
            this.groupBoxGrammarBuilder.TabIndex = 4;
            this.groupBoxGrammarBuilder.Text = "Граматика";
            // 
            // groupBoxBuiltInDictionary
            // 
            this.groupBoxBuiltInDictionary.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.groupBoxBuiltInDictionary.Controls.Add(this.buttonDeleteSelectedWord);
            this.groupBoxBuiltInDictionary.Controls.Add(this.textBoxNewWordToAdd);
            this.groupBoxBuiltInDictionary.Controls.Add(this.buttonAddNewWordToTheMasterDictionary);
            this.groupBoxBuiltInDictionary.Controls.Add(this.gridViewDictionaryItems);
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
            this.groupBoxBuiltInDictionary.Size = new System.Drawing.Size(306, 367);
            this.groupBoxBuiltInDictionary.TabIndex = 5;
            this.groupBoxBuiltInDictionary.Text = "Вграден речник";
            // 
            // gridViewDictionaryItems
            // 
            this.gridViewDictionaryItems.Location = new System.Drawing.Point(6, 22);
            this.gridViewDictionaryItems.Name = "gridViewDictionaryItems";
            this.gridViewDictionaryItems.Size = new System.Drawing.Size(295, 288);
            this.gridViewDictionaryItems.TabIndex = 0;
            // 
            // buttonAddNewWordToTheMasterDictionary
            // 
            this.buttonAddNewWordToTheMasterDictionary.Location = new System.Drawing.Point(6, 338);
            this.buttonAddNewWordToTheMasterDictionary.Name = "buttonAddNewWordToTheMasterDictionary";
            this.buttonAddNewWordToTheMasterDictionary.Size = new System.Drawing.Size(181, 24);
            this.buttonAddNewWordToTheMasterDictionary.TabIndex = 1;
            this.buttonAddNewWordToTheMasterDictionary.Text = "Добави нова дума или фраза";
            this.buttonAddNewWordToTheMasterDictionary.Click += new System.EventHandler(this.buttonAddNewWordToTheMasterDictionary_Click);
            // 
            // textBoxNewWordToAdd
            // 
            this.textBoxNewWordToAdd.Location = new System.Drawing.Point(6, 314);
            this.textBoxNewWordToAdd.Name = "textBoxNewWordToAdd";
            this.textBoxNewWordToAdd.Size = new System.Drawing.Size(130, 20);
            this.textBoxNewWordToAdd.TabIndex = 2;
            this.textBoxNewWordToAdd.TabStop = false;
            // 
            // buttonDeleteSelectedWord
            // 
            this.buttonDeleteSelectedWord.Location = new System.Drawing.Point(194, 338);
            this.buttonDeleteSelectedWord.Name = "buttonDeleteSelectedWord";
            this.buttonDeleteSelectedWord.Size = new System.Drawing.Size(107, 24);
            this.buttonDeleteSelectedWord.TabIndex = 3;
            this.buttonDeleteSelectedWord.Text = "Изтрий";
            this.buttonDeleteSelectedWord.Click += new System.EventHandler(this.buttonDeleteSelectedWord_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(13, 379);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(76, 16);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "Директория: ";
            // 
            // textBoxSaveFilePath
            // 
            this.textBoxSaveFilePath.Location = new System.Drawing.Point(85, 377);
            this.textBoxSaveFilePath.Name = "textBoxSaveFilePath";
            this.textBoxSaveFilePath.Size = new System.Drawing.Size(437, 20);
            this.textBoxSaveFilePath.TabIndex = 7;
            this.textBoxSaveFilePath.TabStop = false;
            this.textBoxSaveFilePath.Text = "C:\\";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(529, 374);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(108, 24);
            this.buttonBrowse.TabIndex = 8;
            this.buttonBrowse.Text = "Разлисти";
            // 
            // PluginWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 514);
            this.Controls.Add(this.pluginWizard);
            this.Name = "PluginWizardForm";
            this.Text = "Магьосник за създаване на плъгини";
            ((System.ComponentModel.ISupportInitialize)(this.pluginWizard)).EndInit();
            this.pluginWizard.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelWelcome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewCommands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExportToXML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLoadTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxIsTheNodeDictation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxGrammarBuilder)).EndInit();
            this.groupBoxGrammarBuilder.ResumeLayout(false);
            this.groupBoxGrammarBuilder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxBuiltInDictionary)).EndInit();
            this.groupBoxBuiltInDictionary.ResumeLayout(false);
            this.groupBoxBuiltInDictionary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDictionaryItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddNewWordToTheMasterDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxNewWordToAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDeleteSelectedWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxSaveFilePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonBrowse)).EndInit();
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
        private Telerik.WinControls.UI.RadButton buttonDeleteSelectedWord;
        private Telerik.WinControls.UI.RadTextBox textBoxNewWordToAdd;
        private Telerik.WinControls.UI.RadButton buttonAddNewWordToTheMasterDictionary;
        private Telerik.WinControls.UI.RadGridView gridViewDictionaryItems;
        private Telerik.WinControls.UI.RadGroupBox groupBoxGrammarBuilder;
        private Telerik.WinControls.UI.RadButton buttonBrowse;
        private Telerik.WinControls.UI.RadTextBox textBoxSaveFilePath;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}

