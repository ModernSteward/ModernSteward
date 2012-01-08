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
            this.buttonMakeSolution = new Telerik.WinControls.UI.RadButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewCommands)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonStartRecognition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExportToXML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLoadTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBoxIsTheNodeDictation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPrintDictItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxWordToAddToTheDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddWordToTheDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonShowTheTreeInPlainText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMakeSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewCommands
            // 
            this.treeViewCommands.Location = new System.Drawing.Point(18, 3);
            this.treeViewCommands.Name = "treeViewCommands";
            this.treeViewCommands.Size = new System.Drawing.Size(259, 237);
            this.treeViewCommands.SpacingBetweenNodes = -1;
            this.treeViewCommands.TabIndex = 0;
            // 
            // buttonStartRecognition
            // 
            this.buttonStartRecognition.Location = new System.Drawing.Point(18, 247);
            this.buttonStartRecognition.Name = "buttonStartRecognition";
            this.buttonStartRecognition.Size = new System.Drawing.Size(76, 48);
            this.buttonStartRecognition.TabIndex = 2;
            this.buttonStartRecognition.Text = "Start recognition";
            this.buttonStartRecognition.TextWrap = true;
            this.buttonStartRecognition.Click += new System.EventHandler(this.buttonStartRecognition_Click);
            // 
            // buttonExportToXML
            // 
            this.buttonExportToXML.Location = new System.Drawing.Point(100, 247);
            this.buttonExportToXML.Name = "buttonExportToXML";
            this.buttonExportToXML.Size = new System.Drawing.Size(96, 48);
            this.buttonExportToXML.TabIndex = 3;
            this.buttonExportToXML.Text = "Export grammar to XML";
            this.buttonExportToXML.TextWrap = true;
            this.buttonExportToXML.Click += new System.EventHandler(this.buttonExportToXML_Click);
            // 
            // buttonLoadTree
            // 
            this.buttonLoadTree.Location = new System.Drawing.Point(203, 247);
            this.buttonLoadTree.Name = "buttonLoadTree";
            this.buttonLoadTree.Size = new System.Drawing.Size(74, 48);
            this.buttonLoadTree.TabIndex = 4;
            this.buttonLoadTree.Text = "Load grammar from XML";
            this.buttonLoadTree.TextWrap = true;
            this.buttonLoadTree.Click += new System.EventHandler(this.buttonLoadTree_Click);
            // 
            // radCheckBoxIsTheNodeDictation
            // 
            this.radCheckBoxIsTheNodeDictation.Location = new System.Drawing.Point(284, 3);
            this.radCheckBoxIsTheNodeDictation.Name = "radCheckBoxIsTheNodeDictation";
            this.radCheckBoxIsTheNodeDictation.Size = new System.Drawing.Size(65, 18);
            this.radCheckBoxIsTheNodeDictation.TabIndex = 5;
            this.radCheckBoxIsTheNodeDictation.Text = "Dictation";
            this.radCheckBoxIsTheNodeDictation.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBoxIsTheNodeDictation_ToggleStateChanged);
            // 
            // buttonPrintDictItems
            // 
            this.buttonPrintDictItems.Location = new System.Drawing.Point(284, 247);
            this.buttonPrintDictItems.Name = "buttonPrintDictItems";
            this.buttonPrintDictItems.Size = new System.Drawing.Size(72, 48);
            this.buttonPrintDictItems.TabIndex = 6;
            this.buttonPrintDictItems.Text = "Print dictionary items";
            this.buttonPrintDictItems.TextWrap = true;
            this.buttonPrintDictItems.Click += new System.EventHandler(this.buttonPrintDictItems_Click);
            // 
            // textBoxWordToAddToTheDictionary
            // 
            this.textBoxWordToAddToTheDictionary.Location = new System.Drawing.Point(284, 162);
            this.textBoxWordToAddToTheDictionary.Name = "textBoxWordToAddToTheDictionary";
            this.textBoxWordToAddToTheDictionary.Size = new System.Drawing.Size(72, 20);
            this.textBoxWordToAddToTheDictionary.TabIndex = 7;
            this.textBoxWordToAddToTheDictionary.TabStop = false;
            // 
            // buttonAddWordToTheDictionary
            // 
            this.buttonAddWordToTheDictionary.Location = new System.Drawing.Point(284, 189);
            this.buttonAddWordToTheDictionary.Name = "buttonAddWordToTheDictionary";
            this.buttonAddWordToTheDictionary.Size = new System.Drawing.Size(72, 52);
            this.buttonAddWordToTheDictionary.TabIndex = 8;
            this.buttonAddWordToTheDictionary.Text = "Add word to the dictionary";
            this.buttonAddWordToTheDictionary.TextWrap = true;
            this.buttonAddWordToTheDictionary.Click += new System.EventHandler(this.buttonAddWordToTheDictionary_Click);
            // 
            // buttonShowTheTreeInPlainText
            // 
            this.buttonShowTheTreeInPlainText.Location = new System.Drawing.Point(284, 28);
            this.buttonShowTheTreeInPlainText.Name = "buttonShowTheTreeInPlainText";
            this.buttonShowTheTreeInPlainText.Size = new System.Drawing.Size(72, 55);
            this.buttonShowTheTreeInPlainText.TabIndex = 9;
            this.buttonShowTheTreeInPlainText.Text = "Show the tree in plain text";
            this.buttonShowTheTreeInPlainText.TextWrap = true;
            this.buttonShowTheTreeInPlainText.Click += new System.EventHandler(this.buttonShowTheTreeInPlainText_Click);
            // 
            // buttonMakeSolution
            // 
            this.buttonMakeSolution.Location = new System.Drawing.Point(284, 90);
            this.buttonMakeSolution.Name = "buttonMakeSolution";
            this.buttonMakeSolution.Size = new System.Drawing.Size(72, 66);
            this.buttonMakeSolution.TabIndex = 10;
            this.buttonMakeSolution.Text = "Make the solution!";
            this.buttonMakeSolution.TextWrap = true;
            this.buttonMakeSolution.Click += new System.EventHandler(this.buttonMakeSolution_Click);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.treeViewCommands);
            this.radPanel1.Controls.Add(this.buttonStartRecognition);
            this.radPanel1.Controls.Add(this.buttonMakeSolution);
            this.radPanel1.Controls.Add(this.buttonExportToXML);
            this.radPanel1.Controls.Add(this.buttonShowTheTreeInPlainText);
            this.radPanel1.Controls.Add(this.buttonLoadTree);
            this.radPanel1.Controls.Add(this.buttonAddWordToTheDictionary);
            this.radPanel1.Controls.Add(this.radCheckBoxIsTheNodeDictation);
            this.radPanel1.Controls.Add(this.textBoxWordToAddToTheDictionary);
            this.radPanel1.Controls.Add(this.buttonPrintDictItems);
            this.radPanel1.Location = new System.Drawing.Point(12, 12);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(366, 307);
            this.radPanel1.TabIndex = 11;
            this.radPanel1.Text = "radPanel1";
            // 
            // SpeechGrammarBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 405);
            this.Controls.Add(this.radPanel1);
            this.Name = "SpeechGrammarBuilderForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.treeViewCommands)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonStartRecognition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExportToXML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLoadTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBoxIsTheNodeDictation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonPrintDictItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxWordToAddToTheDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAddWordToTheDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonShowTheTreeInPlainText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMakeSolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

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
        private RadButton buttonMakeSolution;
        private RadPanel radPanel1;
    }
}

