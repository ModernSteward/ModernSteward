﻿namespace SpeechGrammarBuilderGUI
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
            this.SuspendLayout();
            // 
            // treeViewCommands
            // 
            this.treeViewCommands.Location = new System.Drawing.Point(13, 13);
            this.treeViewCommands.Name = "treeViewCommands";
            this.treeViewCommands.Size = new System.Drawing.Size(259, 237);
            this.treeViewCommands.TabIndex = 0;
            // 
            // SpeechGrammarBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.treeViewCommands);
            this.Name = "SpeechGrammarBuilderForm";
            this.Text = "SpeechGrammarBuilder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewCommands;
    }
}

