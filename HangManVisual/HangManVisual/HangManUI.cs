using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HangManVisual
{
    public partial class HangManUI : Form
    {
        private static string RandWord;
        private static int counter = 1;
        private static List<String> wordsList = new List<string>();

        public HangManUI()
        {
            InitializeComponent();
        }

        private void HangManUI_Load(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            btnSubmitGuess.Enabled = false;
            MessageBox.Show("Please select list of words to use!", "Get Started", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void init()
        {
            btnReset.Enabled = true;
            btnSubmitGuess.Enabled = true;
            randFromList();
            lblOutWord.Text = setupBlanks();
        }

        private void randFromList()
        {
            Random ran = new Random();
            RandWord = wordsList[ran.Next(0, wordsList.Count())];
        }

       private string setupBlanks()
        {
            string blanks = null;
            for (int i = 0; i < RandWord.Length; i++)
            {
                blanks += "*";
            }
            return blanks;
        }

        private void btnOpenFiles_Click(object sender, EventArgs e)
        {
            wordsList.Clear();
            openFilesDialog.Filter = "Text files|*.txt";
            if (openFilesDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFilesDialog.FileName);
                int counter = 0;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    wordsList.Add(line);
                    counter++;
                }
                sr.Close();
                btnReset_Click(sender, e);
                init();
            }
        }

        private bool checkWin()
        {
            if (lblOutWord.Text.IndexOf('*') == -1) return true;
            return false;
        }

        private void btnSubmitGuess_Click(object sender, EventArgs e)
        {
            char guess;
            if (!char.TryParse(txtbGuessIn.Text, out guess)) MessageBox.Show("Please use single characters!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (!richTxtbUsedLs.Text.Contains(guess))
                {
                    richTxtbUsedLs.AppendText(guess + ", ");
                    if (RandWord.Contains(guess))
                    {
                        int index = RandWord.IndexOf(guess);
                        StringBuilder sb = new StringBuilder(lblOutWord.Text);
                        sb[index] = guess;
                        while (index < lblOutWord.Text.Length)
                        {
                            index = RandWord.IndexOf(guess, index + 1);
                            if (index != -1) sb[index] = guess;
                            else break;
                        }
                        lblOutWord.Text = sb.ToString();
                    }
                    else
                    {
                        if (counter < 10)
                        {
                            counter++;
                            pictureOutBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("hangman_stage" + counter);
                        }
                        else { MessageBox.Show("You lose!", "End of the game", MessageBoxButtons.OK, MessageBoxIcon.Information); btnSubmitGuess.Enabled = false; }
                    }
                    if (checkWin()) { MessageBox.Show("You win!", "End of the game", MessageBoxButtons.OK, MessageBoxIcon.Information); btnSubmitGuess.Enabled = false; }
                }
                else MessageBox.Show($"{guess} has already been used!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtbGuessIn.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtbGuessIn.Clear();
            richTxtbUsedLs.Clear();
            RandWord = null;
            counter = 1;
            pictureOutBox.Image = Properties.Resources.hangman_stage1;
            init();
        }
    }
}
