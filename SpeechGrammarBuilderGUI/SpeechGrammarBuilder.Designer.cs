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
            this.buttonWriteInConsoleTheTree = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewCommands
            // 
            this.treeViewCommands.Location = new System.Drawing.Point(13, 13);
            this.treeViewCommands.Name = "treeViewCommands";
            this.treeViewCommands.Size = new System.Drawing.Size(259, 237);
            this.treeViewCommands.TabIndex = 0;
            // 
            // buttonWriteInConsoleTheTree
            // 
            this.buttonWriteInConsoleTheTree.Location = new System.Drawing.Point(197, 254);
            this.buttonWriteInConsoleTheTree.Name = "buttonWriteInConsoleTheTree";
            this.buttonWriteInConsoleTheTree.Size = new System.Drawing.Size(75, 51);
            this.buttonWriteInConsoleTheTree.TabIndex = 1;
            this.buttonWriteInConsoleTheTree.Text = "Try writing it in the console!";
            this.buttonWriteInConsoleTheTree.UseVisualStyleBackColor = true;
            this.buttonWriteInConsoleTheTree.Click += new System.EventHandler(this.buttonWriteInConsoleTheTree_Click);
            // 
            // SpeechGrammarBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 308);
            this.Controls.Add(this.buttonWriteInConsoleTheTree);
            this.Controls.Add(this.treeViewCommands);
            this.Name = "SpeechGrammarBuilderForm";
            this.Text = "SpeechGrammarBuilder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewCommands;
        private System.Windows.Forms.Button buttonWriteInConsoleTheTree;
    }
}

