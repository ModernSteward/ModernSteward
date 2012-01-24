namespace MasterDictionaryUserControl
{
    partial class MasterDictionaryManager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridViewDictionaryItems = new Telerik.WinControls.UI.RadGridView();
            this.buttonAddNewWordToTheMasterDictionary = new Telerik.WinControls.UI.RadButton();
            this.textBoxNewWordToAdd = new Telerik.WinControls.UI.RadTextBox();
            this.buttonDeleteSelectedWord = new Telerik.WinControls.UI.RadButton();
            this.labelWord = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDictionaryItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddNewWordToTheMasterDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxNewWordToAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDeleteSelectedWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelWord)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewDictionaryItems
            // 
            this.gridViewDictionaryItems.Location = new System.Drawing.Point(0, 0);
            this.gridViewDictionaryItems.Name = "gridViewDictionaryItems";
            this.gridViewDictionaryItems.Size = new System.Drawing.Size(295, 307);
            this.gridViewDictionaryItems.TabIndex = 0;
            // 
            // buttonAddNewWordToTheMasterDictionary
            // 
            this.buttonAddNewWordToTheMasterDictionary.Location = new System.Drawing.Point(3, 354);
            this.buttonAddNewWordToTheMasterDictionary.Name = "buttonAddNewWordToTheMasterDictionary";
            this.buttonAddNewWordToTheMasterDictionary.Size = new System.Drawing.Size(142, 24);
            this.buttonAddNewWordToTheMasterDictionary.TabIndex = 1;
            this.buttonAddNewWordToTheMasterDictionary.Text = "Добави";
            this.buttonAddNewWordToTheMasterDictionary.Click += new System.EventHandler(this.buttonAddNewWordToTheMasterDictionary_Click);
            // 
            // textBoxNewWordToAdd
            // 
            this.textBoxNewWordToAdd.Location = new System.Drawing.Point(3, 331);
            this.textBoxNewWordToAdd.Name = "textBoxNewWordToAdd";
            this.textBoxNewWordToAdd.Size = new System.Drawing.Size(289, 20);
            this.textBoxNewWordToAdd.TabIndex = 2;
            this.textBoxNewWordToAdd.TabStop = false;
            this.textBoxNewWordToAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNewWordToAdd_KeyDown);
            // 
            // buttonDeleteSelectedWord
            // 
            this.buttonDeleteSelectedWord.Location = new System.Drawing.Point(150, 354);
            this.buttonDeleteSelectedWord.Name = "buttonDeleteSelectedWord";
            this.buttonDeleteSelectedWord.Size = new System.Drawing.Size(141, 24);
            this.buttonDeleteSelectedWord.TabIndex = 3;
            this.buttonDeleteSelectedWord.Text = "Изтрии";
            this.buttonDeleteSelectedWord.Click += new System.EventHandler(this.buttonDeleteSelectedWord_Click);
            // 
            // labelWord
            // 
            this.labelWord.Location = new System.Drawing.Point(3, 313);
            this.labelWord.Name = "labelWord";
            this.labelWord.Size = new System.Drawing.Size(41, 16);
            this.labelWord.TabIndex = 4;
            this.labelWord.Text = "Дума: ";
            // 
            // MasterDictionaryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelWord);
            this.Controls.Add(this.buttonDeleteSelectedWord);
            this.Controls.Add(this.textBoxNewWordToAdd);
            this.Controls.Add(this.buttonAddNewWordToTheMasterDictionary);
            this.Controls.Add(this.gridViewDictionaryItems);
            this.Name = "MasterDictionaryManager";
            this.Size = new System.Drawing.Size(295, 381);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDictionaryItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddNewWordToTheMasterDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxNewWordToAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDeleteSelectedWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelWord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gridViewDictionaryItems;
        private Telerik.WinControls.UI.RadButton buttonAddNewWordToTheMasterDictionary;
        private Telerik.WinControls.UI.RadTextBox textBoxNewWordToAdd;
        private Telerik.WinControls.UI.RadButton buttonDeleteSelectedWord;
        private Telerik.WinControls.UI.RadLabel labelWord;

    }
}
