namespace FinalProject
{
    partial class moviePage
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.titleTxt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.genreTxt = new System.Windows.Forms.Label();
            this.ratingTxt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.releaseDateTxt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.descTxt = new System.Windows.Forms.Label();
            this.movieShows = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movieShows)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(112, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 122);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title : ";
            // 
            // titleTxt
            // 
            this.titleTxt.AutoSize = true;
            this.titleTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTxt.Location = new System.Drawing.Point(319, 95);
            this.titleTxt.Name = "titleTxt";
            this.titleTxt.Size = new System.Drawing.Size(65, 32);
            this.titleTxt.TabIndex = 2;
            this.titleTxt.Text = "title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Genre : ";
            // 
            // genreTxt
            // 
            this.genreTxt.AutoSize = true;
            this.genreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genreTxt.Location = new System.Drawing.Point(320, 132);
            this.genreTxt.Name = "genreTxt";
            this.genreTxt.Size = new System.Drawing.Size(46, 25);
            this.genreTxt.TabIndex = 4;
            this.genreTxt.Text = "title";
            // 
            // ratingTxt
            // 
            this.ratingTxt.AutoSize = true;
            this.ratingTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ratingTxt.Location = new System.Drawing.Point(329, 178);
            this.ratingTxt.Name = "ratingTxt";
            this.ratingTxt.Size = new System.Drawing.Size(46, 25);
            this.ratingTxt.TabIndex = 6;
            this.ratingTxt.Text = "title";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(271, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Rating :";
            // 
            // releaseDateTxt
            // 
            this.releaseDateTxt.AutoSize = true;
            this.releaseDateTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.releaseDateTxt.Location = new System.Drawing.Point(591, 180);
            this.releaseDateTxt.Name = "releaseDateTxt";
            this.releaseDateTxt.Size = new System.Drawing.Size(46, 25);
            this.releaseDateTxt.TabIndex = 8;
            this.releaseDateTxt.Text = "title";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(488, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Release Date :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // descTxt
            // 
            this.descTxt.AutoSize = true;
            this.descTxt.Location = new System.Drawing.Point(109, 250);
            this.descTxt.Name = "descTxt";
            this.descTxt.Size = new System.Drawing.Size(83, 16);
            this.descTxt.TabIndex = 9;
            this.descTxt.Text = "lorem ipsum ";
            // 
            // movieShows
            // 
            this.movieShows.AllowUserToAddRows = false;
            this.movieShows.AllowUserToDeleteRows = false;
            this.movieShows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.movieShows.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.movieShows.Location = new System.Drawing.Point(112, 306);
            this.movieShows.Name = "movieShows";
            this.movieShows.RowHeadersWidth = 51;
            this.movieShows.RowTemplate.Height = 24;
            this.movieShows.Size = new System.Drawing.Size(570, 150);
            this.movieShows.TabIndex = 10;
            this.movieShows.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellClick);
            // 
            // moviePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.movieShows);
            this.Controls.Add(this.descTxt);
            this.Controls.Add(this.releaseDateTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ratingTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.genreTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "moviePage";
            this.Size = new System.Drawing.Size(818, 497);
            this.Load += new System.EventHandler(this.moviePage_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cellClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movieShows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label titleTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label genreTxt;
        private System.Windows.Forms.Label ratingTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label releaseDateTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label descTxt;
        private System.Windows.Forms.DataGridView movieShows;
    }
}
