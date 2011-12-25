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
            this.treeViewCommands = new System.Windows.Forms.TreeView();
            this.buttonStartRecognition = new System.Windows.Forms.Button();
            this.buttonExportToXML = new System.Windows.Forms.Button();
            this.buttonLoadTree = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewCommands
            // 
            this.treeViewCommands.Location = new System.Drawing.Point(13, 13);
            this.treeViewCommands.Name = "treeViewCommands";
            this.treeViewCommands.Size = new System.Drawing.Size(259, 237);
            this.treeViewCommands.TabIndex = 0;
            // 
            // buttonStartRecognition
            // 
            this.buttonStartRecognition.Location = new System.Drawing.Point(13, 257);
            this.buttonStartRecognition.Name = "buttonStartRecognition";
            this.buttonStartRecognition.Size = new System.Drawing.Size(75, 48);
            this.buttonStartRecognition.TabIndex = 2;
            this.buttonStartRecognition.Text = "Start recognition";
            this.buttonStartRecognition.UseVisualStyleBackColor = true;
            this.buttonStartRecognition.Click += new System.EventHandler(this.buttonStartRecognition_Click);
            // 
            // buttonExportToXML
            // 
            this.buttonExportToXML.Location = new System.Drawing.Point(95, 257);
            this.buttonExportToXML.Name = "buttonExportToXML";
            this.buttonExportToXML.Size = new System.Drawing.Size(96, 48);
            this.buttonExportToXML.TabIndex = 3;
            this.buttonExportToXML.Text = "Export to XML";
            this.buttonExportToXML.UseVisualStyleBackColor = true;
            this.buttonExportToXML.Click += new System.EventHandler(this.buttonExportToXML_Click);
            // 
            // buttonLoadTree
            // 
            this.buttonLoadTree.Location = new System.Drawing.Point(198, 257);
            this.buttonLoadTree.Name = "buttonLoadTree";
            this.buttonLoadTree.Size = new System.Drawing.Size(74, 48);
            this.buttonLoadTree.TabIndex = 4;
            this.buttonLoadTree.Text = "Load tree";
            this.buttonLoadTree.UseVisualStyleBackColor = true;
            this.buttonLoadTree.Click += new System.EventHandler(this.buttonLoadTree_Click);
            // 
            // SpeechGrammarBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 308);
            this.Controls.Add(this.buttonLoadTree);
            this.Controls.Add(this.buttonExportToXML);
            this.Controls.Add(this.buttonStartRecognition);
            this.Controls.Add(this.treeViewCommands);
            this.Name = "SpeechGrammarBuilderForm";
            this.Text = "SpeechGrammarBuilder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewCommands;
        private System.Windows.Forms.Button buttonWriteInConsoleTheTree;
        private System.Windows.Forms.Button buttonStartRecognition;
        private System.Windows.Forms.Button buttonExportToXML;
        private System.Windows.Forms.Button buttonLoadTree;
    }
}

