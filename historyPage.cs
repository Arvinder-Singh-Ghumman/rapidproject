using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FinalProject
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int ShowtimeID { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime BookingDate { get;  set; }
        public int MovieId { get; set; }
        public int TheaterID { get; set; }
        public string Username { get; set; }
        public string MovieTitle { get; set; } // Added to store movie title from the movies table
    }

    public partial class historyPage : UserControl
    {
        private string username;
        private Label lblBookingsCount;
        private Button closeButton;
        private DataGridView bookingsGridView;
        public event Action closeHistory;

        public historyPage(string userName)
        {
            InitializeComponent();
            this.username = userName;
            InitializeControls();
            LoadBookingHistory(username);
        }
        private void InitializeControls()
        {
            // Initialize the label to show the number of bookings
            lblBookingsCount = new Label();
            lblBookingsCount.AutoSize = true;
            lblBookingsCount.Location = new Point(20, 20); // Adjust position as necessary
            lblBookingsCount.Font = new Font("Arial", 16, FontStyle.Bold);
            this.Controls.Add(lblBookingsCount);

            // Initialize DataGridView to display bookings
            bookingsGridView = new DataGridView();
            bookingsGridView.Location = new Point(10, 60);
            bookingsGridView.Size = new Size(600, 300); // Adjust size as needed
            bookingsGridView.AutoGenerateColumns = true;
            this.Controls.Add(bookingsGridView);

            // Initialize the Close Button
            closeButton = new Button();
            closeButton.Text = "X"; // You can use an icon here if preferred
            closeButton.Size = new Size(30, 30); // Adjust size as needed
            closeButton.Location = new Point(this.Width - closeButton.Width - 10, 10); // Top-right corner, adjust as needed
            closeButton.Click += CloseButton_Click; // Handle the click event
            this.Controls.Add(closeButton);
        }

        private void LoadBookingHistory(string username)
        {
            try
            {
                // Fetch number of bookings for the current user from the database
                int bookingsCount = GetBookingsCountForUser(username);

                // Display the result on the label
                lblBookingsCount.Text = $"You have booked {bookingsCount} shows.";

                // Load booking details into the DataGridView
                LoadBookingDetails(username); // Call this method to bind data to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking history: {ex.Message}");
            }
        }

        private void LoadBookingDetails(string username)
        {
            try
            {
                // Fetch booking details from the database
                List<Booking> bookings = GetBookingsForUser(username);

                // Bind the result to the DataGridView
                bookingsGridView.DataSource = bookings;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking details: {ex.Message}");
            }
        }


        private int GetBookingsCountForUser(string username)
        {
            // Example: Query the database to count bookings for the given username
            var db = new databaseFunctions();
            string query = "SELECT COUNT(*) FROM bookings WHERE username = @username";
            var parameters = new Dictionary<string, object> { { "@username", username } };
            return db.ExecuteScalar<int>(query, parameters); // ExecuteScalar will return the count as an integer
        }


        private List<Booking> GetBookingsForUser(string username)
        {
            // Example: Query the database to get booking details for the given username, including MovieTitle from movies table
            var db = new databaseFunctions();
            string query = @"
                SELECT b.BookingID, b.ShowtimeID, b.TotalAmount, b.BookingDate, 
                       b.MovieId, b.TheaterID, b.username, m.Title
                FROM bookings b
                JOIN movies m ON b.MovieId = m.MovieId
                WHERE b.username = @username";
            var parameters = new Dictionary<string, object> { { "@username", username } };

            // Assuming this method fetches data from the database and returns a list of bookings
            var bookingDataTable = db.ExecuteQuery(query, parameters);

            // Convert DataTable to List<Booking>
            List<Booking> bookings = new List<Booking>();
            foreach (DataRow row in bookingDataTable.Rows)
            {
                bookings.Add(new Booking
                {
                    BookingID = Convert.ToInt32(row["BookingID"]),
                    ShowtimeID = Convert.ToInt32(row["ShowtimeID"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    BookingDate = Convert.ToDateTime(row["BookingDate"]),
                    MovieTitle = row["Title"].ToString(),
                    MovieId = Convert.ToInt32(row["MovieId"]),
                    TheaterID = Convert.ToInt32(row["TheaterID"]),
                    Username = row["username"].ToString()
                });
            }

            return bookings;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            closeHistory?.Invoke();
            // Close or hide the control
            this.Dispose();
        }

        private void historyPage_Load(object sender, EventArgs e)
        {

        }
    }
}
