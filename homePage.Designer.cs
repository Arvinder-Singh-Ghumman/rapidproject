namespace FinalProject
{
    partial class homePage
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
            this.user = new System.Windows.Forms.Label();
            this.allMovies = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.searchInput = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(738, 22);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(50, 25);
            this.user.TabIndex = 0;
            this.user.Text = "user";
            this.user.Click += new System.EventHandler(this.user_Click);
            // 
            // allMovies
            // 
            this.allMovies.AutoScroll = true;
            this.allMovies.Location = new System.Drawing.Point(78, 162);
            this.allMovies.Name = "allMovies";
            this.allMovies.Size = new System.Drawing.Size(676, 295);
            this.allMovies.TabIndex = 1;
            this.allMovies.Paint += new System.Windows.Forms.PaintEventHandler(this.allMovies_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "All movies";
            // 
            // searchInput
            // 
            this.searchInput.Location = new System.Drawing.Point(381, 109);
            this.searchInput.Name = "searchInput";
            this.searchInput.Size = new System.Drawing.Size(330, 22);
            this.searchInput.TabIndex = 3;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(713, 109);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 4;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // homePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.search);
            this.Controls.Add(this.searchInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.allMovies);
            this.Controls.Add(this.user);
            this.Name = "homePage";
            this.Size = new System.Drawing.Size(818, 497);
            this.Load += new System.EventHandler(this.homePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label user;
        private System.Windows.Forms.FlowLayoutPanel allMovies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchInput;
        private System.Windows.Forms.Button search;
    }
}
