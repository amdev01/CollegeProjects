namespace HangManVisual
{
    partial class HangManUI
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
            this.lblWrdToGuessText = new System.Windows.Forms.Label();
            this.lblOutWord = new System.Windows.Forms.Label();
            this.lblHelper = new System.Windows.Forms.Label();
            this.txtbGuessIn = new System.Windows.Forms.TextBox();
            this.btnSubmitGuess = new System.Windows.Forms.Button();
            this.lblUsedLettersText = new System.Windows.Forms.Label();
            this.pictureOutBox = new System.Windows.Forms.PictureBox();
            this.btnOpenFiles = new System.Windows.Forms.Button();
            this.openFilesDialog = new System.Windows.Forms.OpenFileDialog();
            this.richTxtbUsedLs = new System.Windows.Forms.RichTextBox();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOutBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWrdToGuessText
            // 
            this.lblWrdToGuessText.AutoSize = true;
            this.lblWrdToGuessText.Location = new System.Drawing.Point(10, 9);
            this.lblWrdToGuessText.Name = "lblWrdToGuessText";
            this.lblWrdToGuessText.Size = new System.Drawing.Size(79, 13);
            this.lblWrdToGuessText.TabIndex = 0;
            this.lblWrdToGuessText.Text = "Word to guess:";
            // 
            // lblOutWord
            // 
            this.lblOutWord.AutoSize = true;
            this.lblOutWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutWord.Location = new System.Drawing.Point(9, 31);
            this.lblOutWord.Name = "lblOutWord";
            this.lblOutWord.Size = new System.Drawing.Size(0, 20);
            this.lblOutWord.TabIndex = 1;
            // 
            // lblHelper
            // 
            this.lblHelper.AutoSize = true;
            this.lblHelper.Location = new System.Drawing.Point(10, 58);
            this.lblHelper.Name = "lblHelper";
            this.lblHelper.Size = new System.Drawing.Size(108, 13);
            this.lblHelper.TabIndex = 2;
            this.lblHelper.Text = "Enter your word here:";
            // 
            // txtbGuessIn
            // 
            this.txtbGuessIn.Location = new System.Drawing.Point(13, 76);
            this.txtbGuessIn.Name = "txtbGuessIn";
            this.txtbGuessIn.Size = new System.Drawing.Size(44, 20);
            this.txtbGuessIn.TabIndex = 3;
            // 
            // btnSubmitGuess
            // 
            this.btnSubmitGuess.Location = new System.Drawing.Point(63, 74);
            this.btnSubmitGuess.Name = "btnSubmitGuess";
            this.btnSubmitGuess.Size = new System.Drawing.Size(75, 23);
            this.btnSubmitGuess.TabIndex = 4;
            this.btnSubmitGuess.Text = "Check";
            this.btnSubmitGuess.UseVisualStyleBackColor = true;
            this.btnSubmitGuess.Click += new System.EventHandler(this.btnSubmitGuess_Click);
            // 
            // lblUsedLettersText
            // 
            this.lblUsedLettersText.AutoSize = true;
            this.lblUsedLettersText.Location = new System.Drawing.Point(12, 112);
            this.lblUsedLettersText.Name = "lblUsedLettersText";
            this.lblUsedLettersText.Size = new System.Drawing.Size(66, 13);
            this.lblUsedLettersText.TabIndex = 5;
            this.lblUsedLettersText.Text = "Used letters:";
            // 
            // pictureOutBox
            // 
            this.pictureOutBox.Image = global::HangManVisual.Properties.Resources.hangman_stage1;
            this.pictureOutBox.Location = new System.Drawing.Point(168, 12);
            this.pictureOutBox.Name = "pictureOutBox";
            this.pictureOutBox.Size = new System.Drawing.Size(150, 250);
            this.pictureOutBox.TabIndex = 7;
            this.pictureOutBox.TabStop = false;
            // 
            // btnOpenFiles
            // 
            this.btnOpenFiles.Location = new System.Drawing.Point(12, 239);
            this.btnOpenFiles.Name = "btnOpenFiles";
            this.btnOpenFiles.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFiles.TabIndex = 8;
            this.btnOpenFiles.Text = "Words list";
            this.btnOpenFiles.UseVisualStyleBackColor = true;
            this.btnOpenFiles.Click += new System.EventHandler(this.btnOpenFiles_Click);
            // 
            // openFilesDialog
            // 
            this.openFilesDialog.FileName = "words.txt";
            // 
            // richTxtbUsedLs
            // 
            this.richTxtbUsedLs.Location = new System.Drawing.Point(12, 128);
            this.richTxtbUsedLs.Name = "richTxtbUsedLs";
            this.richTxtbUsedLs.Size = new System.Drawing.Size(126, 96);
            this.richTxtbUsedLs.TabIndex = 10;
            this.richTxtbUsedLs.Text = "";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(93, 239);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(45, 23);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // HangManUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 280);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.richTxtbUsedLs);
            this.Controls.Add(this.btnOpenFiles);
            this.Controls.Add(this.pictureOutBox);
            this.Controls.Add(this.lblUsedLettersText);
            this.Controls.Add(this.btnSubmitGuess);
            this.Controls.Add(this.txtbGuessIn);
            this.Controls.Add(this.lblHelper);
            this.Controls.Add(this.lblOutWord);
            this.Controls.Add(this.lblWrdToGuessText);
            this.Name = "HangManUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HangMan by Adam Myczkowski";
            this.Load += new System.EventHandler(this.HangManUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureOutBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWrdToGuessText;
        private System.Windows.Forms.Label lblOutWord;
        private System.Windows.Forms.Label lblHelper;
        private System.Windows.Forms.TextBox txtbGuessIn;
        private System.Windows.Forms.Button btnSubmitGuess;
        private System.Windows.Forms.Label lblUsedLettersText;
        private System.Windows.Forms.PictureBox pictureOutBox;
        private System.Windows.Forms.Button btnOpenFiles;
        private System.Windows.Forms.OpenFileDialog openFilesDialog;
        private System.Windows.Forms.RichTextBox richTxtbUsedLs;
        private System.Windows.Forms.Button btnReset;
    }
}

