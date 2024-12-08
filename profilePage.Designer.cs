namespace FinalProject
{
    partial class profilePage
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
            this.txtwelcome = new System.Windows.Forms.Label();
            this.favMovies = new System.Windows.Forms.Label();
            this.history = new System.Windows.Forms.Label();
            this.paymentOptions = new System.Windows.Forms.Label();
            this.deleteAccount = new System.Windows.Forms.Label();
            this.deleteHistory = new System.Windows.Forms.Label();
            this.logout = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtwelcome
            // 
            this.txtwelcome.AutoSize = true;
            this.txtwelcome.Location = new System.Drawing.Point(444, 188);
            this.txtwelcome.Name = "txtwelcome";
            this.txtwelcome.Size = new System.Drawing.Size(41, 16);
            this.txtwelcome.TabIndex = 0;
            this.txtwelcome.Text = "name";
            // 
            // favMovies
            // 
            this.favMovies.AutoSize = true;
            this.favMovies.Location = new System.Drawing.Point(63, 138);
            this.favMovies.Name = "favMovies";
            this.favMovies.Size = new System.Drawing.Size(77, 16);
            this.favMovies.TabIndex = 1;
            this.favMovies.Text = "Fav movies";
            this.favMovies.Click += new System.EventHandler(this.favMovies_Click);
            // 
            // history
            // 
            this.history.AutoSize = true;
            this.history.Location = new System.Drawing.Point(63, 169);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(49, 16);
            this.history.TabIndex = 2;
            this.history.Text = "History";
            this.history.Click += new System.EventHandler(this.history_Click);
            // 
            // paymentOptions
            // 
            this.paymentOptions.AutoSize = true;
            this.paymentOptions.Location = new System.Drawing.Point(63, 219);
            this.paymentOptions.Name = "paymentOptions";
            this.paymentOptions.Size = new System.Drawing.Size(109, 16);
            this.paymentOptions.TabIndex = 3;
            this.paymentOptions.Text = "Payment Options";
            this.paymentOptions.Click += new System.EventHandler(this.paymentOptions_Click);
            // 
            // deleteAccount
            // 
            this.deleteAccount.AutoSize = true;
            this.deleteAccount.Location = new System.Drawing.Point(63, 460);
            this.deleteAccount.Name = "deleteAccount";
            this.deleteAccount.Size = new System.Drawing.Size(98, 16);
            this.deleteAccount.TabIndex = 4;
            this.deleteAccount.Text = "Delete Account";
            // 
            // deleteHistory
            // 
            this.deleteHistory.AutoSize = true;
            this.deleteHistory.Location = new System.Drawing.Point(63, 245);
            this.deleteHistory.Name = "deleteHistory";
            this.deleteHistory.Size = new System.Drawing.Size(89, 16);
            this.deleteHistory.TabIndex = 5;
            this.deleteHistory.Text = "Delete history";
            this.deleteHistory.Click += new System.EventHandler(this.deleteHistory_Click);
            // 
            // logout
            // 
            this.logout.AutoSize = true;
            this.logout.Location = new System.Drawing.Point(706, 57);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(48, 16);
            this.logout.TabIndex = 6;
            this.logout.Text = "Logout";
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // profilePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logout);
            this.Controls.Add(this.deleteHistory);
            this.Controls.Add(this.deleteAccount);
            this.Controls.Add(this.paymentOptions);
            this.Controls.Add(this.history);
            this.Controls.Add(this.favMovies);
            this.Controls.Add(this.txtwelcome);
            this.Name = "profilePage";
            this.Size = new System.Drawing.Size(818, 497);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtwelcome;
        private System.Windows.Forms.Label favMovies;
        private System.Windows.Forms.Label history;
        private System.Windows.Forms.Label paymentOptions;
        private System.Windows.Forms.Label deleteAccount;
        private System.Windows.Forms.Label deleteHistory;
        private System.Windows.Forms.Label logout;
    }
}
