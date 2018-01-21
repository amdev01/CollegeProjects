namespace HangManVisual
{
    partial class LoginForm
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
            this.lblUsersTxt = new System.Windows.Forms.Label();
            this.lblAddNewU = new System.Windows.Forms.Label();
            this.txtbNewUser = new System.Windows.Forms.TextBox();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.btnGuestPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsersTxt
            // 
            this.lblUsersTxt.AutoSize = true;
            this.lblUsersTxt.Location = new System.Drawing.Point(12, 9);
            this.lblUsersTxt.Name = "lblUsersTxt";
            this.lblUsersTxt.Size = new System.Drawing.Size(114, 13);
            this.lblUsersTxt.TabIndex = 0;
            this.lblUsersTxt.Text = "Log in as existing user:";
            // 
            // lblAddNewU
            // 
            this.lblAddNewU.AutoSize = true;
            this.lblAddNewU.Location = new System.Drawing.Point(12, 119);
            this.lblAddNewU.Name = "lblAddNewU";
            this.lblAddNewU.Size = new System.Drawing.Size(87, 13);
            this.lblAddNewU.TabIndex = 1;
            this.lblAddNewU.Text = "Create new user:";
            // 
            // txtbNewUser
            // 
            this.txtbNewUser.Location = new System.Drawing.Point(12, 140);
            this.txtbNewUser.Name = "txtbNewUser";
            this.txtbNewUser.Size = new System.Drawing.Size(100, 20);
            this.txtbNewUser.TabIndex = 2;
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(128, 138);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(75, 23);
            this.btnNewUser.TabIndex = 3;
            this.btnNewUser.Text = "Create!";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // btnGuestPlay
            // 
            this.btnGuestPlay.Location = new System.Drawing.Point(12, 196);
            this.btnGuestPlay.Name = "btnGuestPlay";
            this.btnGuestPlay.Size = new System.Drawing.Size(260, 23);
            this.btnGuestPlay.TabIndex = 4;
            this.btnGuestPlay.Text = "Play as a guest";
            this.btnGuestPlay.UseVisualStyleBackColor = true;
            this.btnGuestPlay.Click += new System.EventHandler(this.btnGuestPlay_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnGuestPlay);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.txtbNewUser);
            this.Controls.Add(this.lblAddNewU);
            this.Controls.Add(this.lblUsersTxt);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsersTxt;
        private System.Windows.Forms.Label lblAddNewU;
        private System.Windows.Forms.TextBox txtbNewUser;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.Button btnGuestPlay;
    }
}