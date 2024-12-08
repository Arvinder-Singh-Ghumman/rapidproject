using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject
{
    internal class databaseFunctions
    {
        private readonly string connectionString;

        public databaseFunctions()
        {
            // Retrieve the connection string from App.config
            //connectionString = "Data Source=LAPTOP-U84GJ6UI\\SQLEXPRESS;Initial Catalog=movieTickets;Integrated Security=True;";

        connectionString = ConfigurationManager.ConnectionStrings["movieTickets"].ConnectionString;
    }

    public bool Login(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password); // Ideally hashed password

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count == 1; // Return true if the user exists
            }
        }

        // Insert a new user for signup
        public bool SignUp(string username, string email, string password, string phoneNumber)
        {
            try
            {                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //checking if username already exists
                    string checkQuery = "SELECT COUNT(1) FROM Users WHERE Username = @Username";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("This username already exists");
                        return false;
                    }

                    // saving user in the database
                    string query = "INSERT INTO Users (Username, Email, Password, PhoneNumber) VALUES (@Username, @Email, @Password, @PhoneNumber)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password); 
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("An error occured.");
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public SqlDataReader FetchMovies()
        {
            try
            {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Title, PosterURL FROM Movies";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection); // Close connection when reader is closed
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }
        }

        public Movie GetMovieDetails(string movieName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Movies WHERE Title = @MovieName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MovieName", movieName);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Map the database fields to the Movie object
                            Movie movie = new Movie
                            {
                                MovieID = reader.IsDBNull(reader.GetOrdinal("MovieID")) ? 0 : reader.GetInt32(reader.GetOrdinal("MovieID")),
                                Title = reader.IsDBNull(reader.GetOrdinal("Title")) ? "Unknown Title" : reader.GetString(reader.GetOrdinal("Title")),
                                Genre = reader.IsDBNull(reader.GetOrdinal("Genre")) ? "Unknown Genre" : reader.GetString(reader.GetOrdinal("Genre")),
                                Rating = reader.IsDBNull(reader.GetOrdinal("Rating")) ? 0 : Convert.ToSingle(reader["Rating"]),
                                Duration = reader.IsDBNull(reader.GetOrdinal("Duration")) ? 0 : reader.GetInt32(reader.GetOrdinal("Duration")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "No Description Available" : reader.GetString(reader.GetOrdinal("Description")),
                                TrailerURL = reader.IsDBNull(reader.GetOrdinal("TrailerURL")) ? string.Empty : reader.GetString(reader.GetOrdinal("TrailerURL")),
                                PosterURL = reader.IsDBNull(reader.GetOrdinal("PosterURL")) ? string.Empty : reader.GetString(reader.GetOrdinal("PosterURL")),
                                ReleaseDate = reader.IsDBNull(reader.GetOrdinal("ReleaseDate")) ? DateTime.MinValue : Convert.ToDateTime(reader["ReleaseDate"])
                            };
                            //MessageBox.Show(movie.Title);
                            return movie;
                        }
                        else
                        {
                            MessageBox.Show("Movie not found.");
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }
        }

        public SqlDataReader GetSearchedMovie(string searchTerm)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "SELECT * FROM Movies WHERE Title LIKE @SearchTerm";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection); // This reader will be automatically closed when the connection is closed
                return reader; // Return the reader to be used outside
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }
        }

        public SqlDataReader GetMovieTheaters(int movieID)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                string query = @"
                SELECT 
                    S.ShowtimeID as ShowId,
                    M.Title AS MovieTitle, 
                    S.Showtime,
                    T.Name AS Theatre
                FROM 
                    Showtimes S
                INNER JOIN 
                    Movies M ON S.MovieID = M.MovieID
                INNER JOIN 
                    Theaters T ON S.TheaterID = T.TheaterID
                WHERE 
                    S.MovieID = @MovieID AND S.Showtime >= GETDATE() -- Only future showtimes
                ORDER BY 
                    S.Showtime;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MovieID", movieID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                // Return the reader to be processed outside
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }
        }

        public List<string> getPaymentOptions(string username)
        {
            List<string> paymentOptions = new List<string>();

            string query = @"
                SELECT PaymentOptions 
                FROM Users
                WHERE Username = @Username;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //MessageBox.Show(username);
                    // Add the parameter and value for @Username
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open(); // Open the connection
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string options = reader["PaymentOptions"]?.ToString();
                            if (!string.IsNullOrWhiteSpace(options))
                            {
                                paymentOptions = options.Split(',').ToList();
                            }
                        }
                    }
                }
            }

            return paymentOptions;
        }

        public bool BookShowtime(int showtimeId, string userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Step 1: Fetch Showtime details (TheaterID, Showtime, MovieID, TicketPrice)
                            string fetchQuery = @"
                        SELECT 
                            ShowtimeID,
                            TheaterID,
                            Showtime,
                            MovieID,
                            TicketPrice
                        FROM 
                            Showtimes 
                        WHERE 
                            ShowtimeID = @ShowtimeID";
                            SqlCommand fetchCommand = new SqlCommand(fetchQuery, connection, transaction);
                            fetchCommand.Parameters.AddWithValue("@ShowtimeID", showtimeId);

                            int theaterID = 0;
                            DateTime showtime = DateTime.MinValue;
                            int movieID = 0;
                            decimal ticketPrice = 0;

                            using (SqlDataReader reader = fetchCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    theaterID = reader.GetInt32(reader.GetOrdinal("TheaterID"));
                                    showtime = reader.GetDateTime(reader.GetOrdinal("Showtime"));
                                    movieID = reader.GetInt32(reader.GetOrdinal("MovieID"));
                                    ticketPrice = reader.IsDBNull(reader.GetOrdinal("TicketPrice")) ? 20 : reader.GetDecimal(reader.GetOrdinal("TicketPrice"));
                                }
                                else
                                {
                                    throw new Exception("Showtime not found.");
                                }
                            }

                            // Step 2: Insert Booking details into Bookings table
                            string insertQuery = @"
INSERT INTO Bookings (username, ShowtimeID, MovieID, TheaterID, TotalAmount, BookingDate) 
VALUES (@UserID, @ShowtimeID, @MovieID, @TheaterID, @TotalAmount, @BookingDate)";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction);
                            insertCommand.Parameters.AddWithValue("@UserID", userId);
                            insertCommand.Parameters.AddWithValue("@ShowtimeID", showtimeId);
                            insertCommand.Parameters.AddWithValue("@MovieID", movieID); // MovieID from the fetched data
                            insertCommand.Parameters.AddWithValue("@TheaterID", theaterID); // TheaterID from the fetched data
                            insertCommand.Parameters.AddWithValue("@TotalAmount", ticketPrice);
                            insertCommand.Parameters.AddWithValue("@BookingDate", DateTime.Now);

                            insertCommand.ExecuteNonQuery();

                            // Step 3: Delete from Showtimes table
                            string deleteQuery = "DELETE FROM Showtimes WHERE ShowtimeID = @ShowtimeID";
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                            deleteCommand.Parameters.AddWithValue("@ShowtimeID", showtimeId);

                            int deleteResult = deleteCommand.ExecuteNonQuery();

                            if (deleteResult == 0)
                            {
                                throw new Exception("Failed to delete showtime. Showtime may not exist.");
                            }

                            // Commit the transaction
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction on error
                            transaction.Rollback();
                            MessageBox.Show($"Error during booking: {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }

        public string GetUserFavoriteMovies(string username)
        {
            string query = "SELECT Favorites FROM Users WHERE Username = @Username";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    return cmd.ExecuteScalar()?.ToString() ?? "[]"; // Return empty JSON array if null
                }
            }
        }

        public void UpdateUserFavoriteMovies(string username, string updatedFavoritesJson)
        {
            string query = "UPDATE Users SET Favorites = @FavoriteMovies WHERE Username = @Username";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FavoriteMovies", updatedFavoritesJson);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        dataAdapter.SelectCommand.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable); // Fill DataTable with the results of the query
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }

            return dataTable;
        }

        // Method to execute a scalar query (e.g., COUNT query)

        public T ExecuteScalar<T>(string query, Dictionary<string, object> parameters = null)
        {
             object result = default;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                try
                {
                    connection.Open();

                    result = (T)command.ExecuteScalar(); // Get a single value from the query
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }
            if (result == DBNull.Value)
            {
                return default(T);  // Return default value for type T (e.g., null for reference types, 0 for numeric types)
            }

            return (T)result;
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters to the command
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                conn.Open();
                return cmd.ExecuteNonQuery(); // Returns the number of rows affected
            }
        }

        public string GetCardNumbers(string username)
        {
            string getCardNumbersQuery = "SELECT PaymentOptions FROM Users WHERE Username = @Username";

            // Create parameters dictionary
            var parameters = new Dictionary<string, object>
    {
        { "@Username", username }
    };

            // Execute the query using ExecuteScalar to get the result
            object result = ExecuteScalar<object>(getCardNumbersQuery, parameters);

            // Check if the result is DBNull or null and return an appropriate value
            if (result == DBNull.Value || result == null)
            {
                return string.Empty;  // Return an empty string if no result or DBNull
            }

            // Return the result as a string
            return result.ToString();
        }

        public bool DeleteUserBookings(string username)
        {
            string query = "DELETE FROM Bookings WHERE Username = @Username"; // Query to delete bookings for a user

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Open the database connection

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username); // Set the username parameter value

                        int rowsAffected = command.ExecuteNonQuery(); // Execute the query
                        return rowsAffected > 0; // Return true if at least one row was deleted
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting bookings: {ex.Message}");
                return false; // Return false if there was an error
            }
        }

    }
}
