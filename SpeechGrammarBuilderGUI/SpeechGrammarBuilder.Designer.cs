using Telerik.WinControls.UI;
namespace SpeechGrammarBuilderGUI
{
    partial class SpeechGrammarBuilderForm
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
            this.buttonStartRecognition = new Telerik.WinControls.UI.RadButton();
            this.buttonExportToXML = new Telerik.WinControls.UI.RadButton();
            this.buttonLoadTree = new Telerik.WinControls.UI.RadButton();
            this.radCheckBoxIsTheNodeDictation = new Telerik.WinControls.UI.RadCheckBox();
            this.buttonPrintDictItems = new Telerik.WinControls.UI.RadButton();
            this.textBoxWordToAddToTheDictionary = new Telerik.WinControls.UI.RadTextBox();
            this.buttonAddWordToTheDictionary = new Telerik.WinControls.UI.RadButton();
            this.buttonShowTheTreeInPlainText = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewCommands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonStartRecognition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExportToXML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLoadTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBoxIsTheNodeDictation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPrintDictItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxWordToAddToTheDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddWordToTheDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonShowTheTreeInPlainText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewCommands
            // 
            this.treeViewCommands.Location = new System.Drawing.Point(13, 13);
            this.treeViewCommands.Name = "treeViewCommands";
            this.treeViewCommands.Size = new System.Drawing.Size(259, 237);
            this.treeViewCommands.SpacingBetweenNodes = -1;
            this.treeViewCommands.TabIndex = 0;
            // 
            // buttonStartRecognition
            // 
            this.buttonStartRecognition.Location = new System.Drawing.Point(13, 257);
            this.buttonStartRecognition.Name = "buttonStartRecognition";
            this.buttonStartRecognition.Size = new System.Drawing.Size(76, 48);
            this.buttonStartRecognition.TabIndex = 2;
            this.buttonStartRecognition.Text = "Start recognition";
            this.buttonStartRecognition.TextWrap = true;
            this.buttonStartRecognition.Click += new System.EventHandler(this.buttonStartRecognition_Click);
            // 
            // buttonExportToXML
            // 
            this.buttonExportToXML.Location = new System.Drawing.Point(95, 257);
            this.buttonExportToXML.Name = "buttonExportToXML";
            this.buttonExportToXML.Size = new System.Drawing.Size(96, 48);
            this.buttonExportToXML.TabIndex = 3;
            this.buttonExportToXML.Text = "Export grammar to XML";
            this.buttonExportToXML.TextWrap = true;
            this.buttonExportToXML.Click += new System.EventHandler(this.buttonExportToXML_Click);
            // 
            // buttonLoadTree
            // 
            this.buttonLoadTree.Location = new System.Drawing.Point(198, 257);
            this.buttonLoadTree.Name = "buttonLoadTree";
            this.buttonLoadTree.Size = new System.Drawing.Size(74, 48);
            this.buttonLoadTree.TabIndex = 4;
            this.buttonLoadTree.Text = "Load grammar from XML";
            this.buttonLoadTree.TextWrap = true;
            this.buttonLoadTree.Click += new System.EventHandler(this.buttonLoadTree_Click);
            // 
            // radCheckBoxIsTheNodeDictation
            // 
            this.radCheckBoxIsTheNodeDictation.Location = new System.Drawing.Point(279, 13);
            this.radCheckBoxIsTheNodeDictation.Name = "radCheckBoxIsTheNodeDictation";
            this.radCheckBoxIsTheNodeDictation.Size = new System.Drawing.Size(65, 18);
            this.radCheckBoxIsTheNodeDictation.TabIndex = 5;
            this.radCheckBoxIsTheNodeDictation.Text = "Dictation";
            this.radCheckBoxIsTheNodeDictation.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBoxIsTheNodeDictation_ToggleStateChanged);
            // 
            // buttonPrintDictItems
            // 
            this.buttonPrintDictItems.Location = new System.Drawing.Point(279, 257);
            this.buttonPrintDictItems.Name = "buttonPrintDictItems";
            this.buttonPrintDictItems.Size = new System.Drawing.Size(72, 48);
            this.buttonPrintDictItems.TabIndex = 6;
            this.buttonPrintDictItems.Text = "Print dictionary items";
            this.buttonPrintDictItems.TextWrap = true;
            this.buttonPrintDictItems.Click += new System.EventHandler(this.buttonPrintDictItems_Click);
            // 
            // textBoxWordToAddToTheDictionary
            // 
            this.textBoxWordToAddToTheDictionary.Location = new System.Drawing.Point(279, 172);
            this.textBoxWordToAddToTheDictionary.Name = "textBoxWordToAddToTheDictionary";
            this.textBoxWordToAddToTheDictionary.Size = new System.Drawing.Size(72, 20);
            this.textBoxWordToAddToTheDictionary.TabIndex = 7;
            this.textBoxWordToAddToTheDictionary.TabStop = false;
            // 
            // buttonAddWordToTheDictionary
            // 
            this.buttonAddWordToTheDictionary.Location = new System.Drawing.Point(279, 199);
            this.buttonAddWordToTheDictionary.Name = "buttonAddWordToTheDictionary";
            this.buttonAddWordToTheDictionary.Size = new System.Drawing.Size(72, 52);
            this.buttonAddWordToTheDictionary.TabIndex = 8;
            this.buttonAddWordToTheDictionary.Text = "Add word to the dictionary";
            this.buttonAddWordToTheDictionary.TextWrap = true;
            this.buttonAddWordToTheDictionary.Click += new System.EventHandler(this.buttonAddWordToTheDictionary_Click);
            // 
            // buttonShowTheTreeInPlainText
            // 
            this.buttonShowTheTreeInPlainText.Location = new System.Drawing.Point(279, 38);
            this.buttonShowTheTreeInPlainText.Name = "buttonShowTheTreeInPlainText";
            this.buttonShowTheTreeInPlainText.Size = new System.Drawing.Size(72, 55);
            this.buttonShowTheTreeInPlainText.TabIndex = 9;
            this.buttonShowTheTreeInPlainText.Text = "Show the tree in plain text";
            this.buttonShowTheTreeInPlainText.TextWrap = true;
            this.buttonShowTheTreeInPlainText.Click += new System.EventHandler(this.buttonShowTheTreeInPlainText_Click);
            // 
            // SpeechGrammarBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 308);
            this.Controls.Add(this.buttonShowTheTreeInPlainText);
            this.Controls.Add(this.buttonAddWordToTheDictionary);
            this.Controls.Add(this.textBoxWordToAddToTheDictionary);
            this.Controls.Add(this.buttonPrintDictItems);
            this.Controls.Add(this.radCheckBoxIsTheNodeDictation);
            this.Controls.Add(this.buttonLoadTree);
            this.Controls.Add(this.buttonExportToXML);
            this.Controls.Add(this.buttonStartRecognition);
            this.Controls.Add(this.treeViewCommands);
            this.Name = "SpeechGrammarBuilderForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "SpeechGrammarBuilder";
            ((System.ComponentModel.ISupportInitialize)(this.treeViewCommands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonStartRecognition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExportToXML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLoadTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBoxIsTheNodeDictation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPrintDictItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxWordToAddToTheDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddWordToTheDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonShowTheTreeInPlainText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadTreeView treeViewCommands;
        private RadButton buttonWriteInConsoleTheTree;
        private RadButton buttonStartRecognition;
        private RadButton buttonExportToXML;
        private RadButton buttonLoadTree;
        private RadCheckBox radCheckBoxIsTheNodeDictation;
        private RadButton buttonPrintDictItems;
        private RadButton buttonAddWordToTheDictionary;
        private RadTextBox textBoxWordToAddToTheDictionary;
        private RadButton buttonShowTheTreeInPlainText;
    }
}

