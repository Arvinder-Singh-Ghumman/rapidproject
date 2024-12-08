namespace FinalProject
{
    partial class favMovies
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
            this.favoritesGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.favoritesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // favoritesGridView
            // 
            this.favoritesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.favoritesGridView.Location = new System.Drawing.Point(27, 65);
            this.favoritesGridView.Name = "favoritesGridView";
            this.favoritesGridView.RowHeadersWidth = 51;
            this.favoritesGridView.RowTemplate.Height = 24;
            this.favoritesGridView.Size = new System.Drawing.Size(764, 408);
            this.favoritesGridView.TabIndex = 0;
            this.favoritesGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FavoritesGridView_CellClick);
            // 
            // favMovies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.favoritesGridView);
            this.Name = "favMovies";
            this.Size = new System.Drawing.Size(818, 497);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.favoritesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView favoritesGridView;
    }
}
