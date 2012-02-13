using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpeechLib;
using Telerik.WinControls.UI;

namespace MasterDictionaryUserControl
{
    public partial class MasterDictionaryManager : UserControl
    {
        public MasterDictionaryManager()
        {
            InitializeComponent();

            gridViewDictionaryItems.AllowAddNewRow = false;
            gridViewDictionaryItems.AllowColumnChooser = false;
            gridViewDictionaryItems.AllowColumnResize = false;
            gridViewDictionaryItems.AllowDeleteRow = false;
            gridViewDictionaryItems.AllowDrop = false;
            gridViewDictionaryItems.AllowEditRow = false;
            gridViewDictionaryItems.AllowMultiColumnSorting = false;
            gridViewDictionaryItems.AllowRowReorder = false;
            gridViewDictionaryItems.EnableCustomGrouping = false;
            gridViewDictionaryItems.EnableCustomSorting = false;
            gridViewDictionaryItems.EnableGrouping = false;

            gridViewDictionaryItems.Columns.Add("Дума");

            RenewGridViewDictionaryItems();

            gridViewDictionaryItems.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

        }

        private void RenewGridViewDictionaryItems()
        {
            gridViewDictionaryItems.Rows.Clear();

            ISpeechLexiconWords splexWords;
            SpLexicon lex = new SpLexicon();
            int generationId = 0;
            splexWords = lex.GetWords(SpeechLexiconType.SLTUser, out generationId);
            foreach (ISpeechLexiconWord splexWord in splexWords)
            {
                gridViewDictionaryItems.Rows.Add(splexWord.Word);
            }

        }

        private void buttonAddNewWordToTheMasterDictionary_Click(object sender, EventArgs e)
        {
            addWordToTheMasterDictionary(textBoxNewWordToAdd.Text);
        }

        void addWordToTheMasterDictionary(string word)
        {
            try
            {
                SpLexicon lex = new SpLexicon();
                lex.AddPronunciation(word, 1033);
                textBoxNewWordToAdd.Text = "";
                RenewGridViewDictionaryItems();
            }
            catch { }
        }

        private void buttonDeleteSelectedWord_Click(object sender, EventArgs e)
        {
            try
            {
                deleteWordFromTheDictionary(gridViewDictionaryItems.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch { }
        }

        private void deleteWordFromTheDictionary(string wordToDelete)
        {
            SpLexicon lex = new SpLexicon();
            lex.RemovePronunciation(wordToDelete, 1033);
            RenewGridViewDictionaryItems();
        }

        private void textBoxNewWordToAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                addWordToTheMasterDictionary(textBoxNewWordToAdd.Text);
            }
        }
    }
}
