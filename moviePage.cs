using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public class ShowTime
    {
        public int ShowId { get; set; }
        public string MovieTitle { get; set; }
        public string Showtime { get; set; }
        public string Theater { get; set; }
    }

    public partial class moviePage : UserControl
    {
        public int movieId;

     public event Action<int, string, string, string> buyTicket;

     databaseFunctions db = new databaseFunctions();
        public moviePage(string movieName)
        {
            InitializeComponent();
            Movie movie = db.GetMovieDetails(movieName);
            pictureBox1.Load(movie.PosterURL);
            titleTxt.Text = movie.Title;
            genreTxt.Text = movie.Genre;
            ratingTxt.Text = Convert.ToString(movie.Rating);
            releaseDateTxt.Text = Convert.ToString(movie.ReleaseDate);
            descTxt.Text = movie.Description;
            this.movieId = movie.MovieID;
            fillShowTimes(movie.MovieID);

        }



        public void fillShowTimes(int movieId)
        {
            // Adding show times
            SqlDataReader reader = db.GetMovieTheaters(movieId);

            if (reader != null && reader.HasRows)
            {
                // Create a list to hold showtime objects
                BindingList<ShowTime> showTimes = new BindingList<ShowTime>();

                // Loop through the reader and add rows to the BindingList
                while (reader.Read())
                {
                    int showId = Convert.ToInt32(reader["ShowId"]);
                    string movieTitle = reader["MovieTitle"].ToString();
                    DateTime showtime = Convert.ToDateTime(reader["Showtime"]);
                    string theater = reader["Theatre"].ToString(); // Changed to match the query

                    // Create a new ShowTime object and add it to the list
                    showTimes.Add(new ShowTime
                    {
                        ShowId = showId,
                        MovieTitle = movieTitle,
                        Showtime = showtime.ToString("yyyy-MM-dd HH:mm"),
                        Theater = theater
                    });
                }

                // Close the reader
                reader.Close();

                // Bind the list to the DataGridView
                movieShows.DataSource = showTimes;
            }
            else
            {
                MessageBox.Show("No data found.");
            }
        }

        public void cellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Check if the clicked cell is not the header row
            if (e.RowIndex >= 0)
            {
                // Get the values from the clicked row
                int showId = Convert.ToInt32(movieShows.Rows[e.RowIndex].Cells["ShowId"].Value);
                string movieTitle = movieShows.Rows[e.RowIndex].Cells["MovieTitle"].Value.ToString();
                string showtime = movieShows.Rows[e.RowIndex].Cells["Showtime"].Value.ToString();
                string theater = movieShows.Rows[e.RowIndex].Cells["Theater"].Value.ToString();

                // Show a confirmation message
                DialogResult result = MessageBox.Show($"Do you want to buy a ticket for {movieTitle} at {showtime} in {theater}?",
                    "Confirm Purchase", MessageBoxButtons.YesNo);

                // If user clicks Yes, proceed with the purchase
                if (result == DialogResult.Yes)
                {
                    // Proceed to the ticket purchase logic
                    buyTicket?.Invoke(showId, movieTitle, showtime, theater); // Using null-conditional operator
                }
                fillShowTimes(movieId);
            }

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void moviePage_Load(object sender, EventArgs e)
        {

        }

        private void cellClick(object sender, MouseEventArgs e)
        {

        }
    }
}
