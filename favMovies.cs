using Azure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class favMovies : UserControl
    {
        private BindingSource bindingSource = new BindingSource();
        private List<Movie> favoriteMovies;
        private databaseFunctions db;
        protected string username;
        public event Action closeFav;
        private Button closeButton;
        public favMovies(string name)
        {
            InitializeComponent();
            db = new databaseFunctions();
            this.username = name;

            // Create the Close Button
            closeButton = new Button();
            closeButton.Text = "X";
            closeButton.Size = new Size(30, 30);
            closeButton.Location = new Point(this.Width - 35, 5); // Adjust position as needed
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.BackColor = Color.Red;
            closeButton.ForeColor = Color.White;
            closeButton.Click += CloseButton_Click;

            // Add Close Button to the Control
            this.Controls.Add(closeButton);

            // Load favorite movies for the given user
            LoadFavoriteMovies(username);
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Remove the UserControl from its parent
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
                this.Dispose(); // Clean up resources
            }
        }

        private void LoadFavoriteMovies(string username)
        {
            try
            {
                // Retrieve favorite movies JSON from the database
                string favoriteMoviesJson = db.GetUserFavoriteMovies(username);

                // Deserialize JSON into a list of Movie objects
                favoriteMovies = JsonSerializer.Deserialize<List<Movie>>(favoriteMoviesJson) ?? new List<Movie>();

                // Set up data binding
                bindingSource.DataSource = favoriteMovies;

                // Bind the BindingSource to the DataGridView
                favoritesGridView.DataSource = bindingSource;

                // Set up columns (optional formatting)
                favoritesGridView.Columns["MovieID"].Visible = false; // Hide MovieID
                favoritesGridView.Columns["Title"].HeaderText = "Title";
                favoritesGridView.Columns["Genre"].HeaderText = "Genre";
                favoritesGridView.Columns["Rating"].Visible = false;
                favoritesGridView.Columns["Cast"].Visible = false;
                favoritesGridView.Columns["Duration"].Visible = false;
                favoritesGridView.Columns["ReleaseDate"].Visible = false;
                favoritesGridView.Columns["Description"].Visible = false;
                favoritesGridView.Columns["TrailerURL"].Visible = false;
                favoritesGridView.Columns["PosterURL"].Visible = false;


                // Add a Delete button column if not already added
                if (!favoritesGridView.Columns.Contains("Action"))
                {
                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                    {
                        Text = "Delete",
                        UseColumnTextForButtonValue = true,
                        HeaderText = "Action",
                        Name = "Action"
                    };
                    favoritesGridView.Columns.Add(deleteColumn);
                }

                // Attach CellClick event for handling delete actions
                favoritesGridView.CellClick += FavoritesGridView_CellClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading favorite movies: {ex.Message}");
            }
        }

        private void FavoritesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked cell is not a header or out of bounds
            if (e.RowIndex >= 0 && favoritesGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete this movie?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Get the MovieID of the selected movie
                    int movieId = Convert.ToInt32(favoritesGridView.Rows[e.RowIndex].Cells["MovieID"].Value);

                    // Remove the movie from the list
                    favoriteMovies.RemoveAt(e.RowIndex);
                    bindingSource.ResetBindings(false); // Refresh the DataGridView

                    // Update the database with the new favorites
                    string updatedFavoritesJson = JsonSerializer.Serialize(favoriteMovies);
                    db.UpdateUserFavoriteMovies(username, updatedFavoritesJson);

                    MessageBox.Show("Movie deleted successfully!");
                }
            }
        }


        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
