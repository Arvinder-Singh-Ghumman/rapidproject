using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class homePage : UserControl
    {
        public Form1 formparent { get; set; }
        public Action<string> openMovie { get; set; }
        public Action openProfile { get; set; }
        public homePage()
        {
            InitializeComponent();
            LoadMovies();
            //user.Text = formparent.username;
        }
        private void LoadMovies()
        {
            try
            {
                databaseFunctions fnctions = new databaseFunctions();
                using (SqlDataReader reader = fnctions.FetchMovies())
                {
                    FillMovies(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void FillMovies(SqlDataReader reader)
        {
            // Clear existing controls in FlowLayoutPanel
            allMovies.Controls.Clear();
            while (reader.Read())
            {
                string title = reader["Title"].ToString();
                string posterUrl = reader["PosterURL"].ToString();

                // Create a panel for each movie
                Panel moviePanel = CreateMoviePanel(title, posterUrl);
                allMovies.Controls.Add(moviePanel);
            }
        }
        private Panel CreateMoviePanel(string title, string posterUrl)
        {
            Panel panel = new Panel
            {
                Size = new Size(100, 150),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            // PictureBox for poster
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(100, 100),
                ImageLocation = posterUrl,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // Label for title
            Label label = new Label
            {
                Text = title,
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Height = 50,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            // onclick opens movie's page
            panel.Click += (sender, e) => openMovie?.Invoke(title);
            pictureBox.Click += (sender, e) => openMovie?.Invoke(title);
            label.Click += (sender, e) => openMovie?.Invoke(title);

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(label);

            return panel;
        }
        private void allMovies_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homePage_Load(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                databaseFunctions fnctions = new databaseFunctions();

                using (SqlDataReader reader = fnctions.GetSearchedMovie(searchInput.Text))
                {
                    if (reader != null && reader.HasRows)
                    {
                        // Reset or clear any previous results in the UI
                        allMovies.Controls.Clear();

                        // Fill UI with movie data
                        FillMovies(reader);
                    }
                    else
                    {
                        // Handle case where no data is returned
                        MessageBox.Show("No movies found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void user_Click(object sender, EventArgs e)
        {
            openProfile?.Invoke();
        }
    }
}
