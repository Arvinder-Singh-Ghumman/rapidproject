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

    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public float Rating { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate {  get; set; }
        public string Cast { get; set; }
        public string Description { get; set; }
        public string TrailerURL { get; set; }
        public string PosterURL { get; set; }
    }
    public partial class Form1 : Form
    {
        private UserControl activeUserControl;
        databaseFunctions dbFunctions = new databaseFunctions();

        private welcomePage welcomepage;
        private loginControl login;
        private signinControl signin;
        private homePage homePage;
        private profilePage profilepage;
        private favMovies favmovies;
        private PaymentOptionsControl paymentOptionsControl;
        private Button homebutton=new Button();

        public string username;
        public Form1()
        {
            InitializeComponent();
            //adding pages
            welcomepage = new welcomePage{Visible = true};
            login = new loginControl{Visible = false};
            signin = new signinControl{Visible = false};
            homePage = new homePage{Visible = false};


            // Add the controls to the form
            this.Controls.Add(welcomepage);
            this.Controls.Add(login);
            this.Controls.Add(signin);
            this.Controls.Add(homePage);
            this.Controls.Add(homebutton);
            activeUserControl = welcomepage;
            AddHomeButton(homebutton);
            homebutton.BringToFront();

            // Subscribe to the Login event
            welcomepage.loginSignin += OnloginSignin;
            login.LoginSuccessful += OnLoginSuccessful;
            signin.SigninSuccessful += onSigninSuccessful;
            login.showSignin += showSignin; 
            signin.showLogIn += showLogin;
            homePage.openMovie += openMovie;
            homePage.openProfile += showProfilePage;
        }

        private void showPaymentOptions()
        {
            // Create and add PaymentOptionsControl to the form
            paymentOptionsControl = new PaymentOptionsControl(username);
            paymentOptionsControl.Location = new Point(50, 50); // Adjust as needed
            this.Controls.Add(paymentOptionsControl);
            activeUserControl.Visible = false;
            paymentOptionsControl.closePayment += closePaymentOptions;
        }
        public void showProfilePage()
        {
            profilepage = new profilePage(username) { Visible = true };
            this.Controls.Add(profilepage);
            profilepage.showFav += showFav;
            profilepage.showHistory += showHistory;
            profilepage.showPaymentOptions += showPaymentOptions;
            
            profilepage.logOut += logOut;
            profilepage.showFav += showFav;
            activeUserControl.Visible = false;
            homePage.Visible = false;
            homebutton.Visible = true;
            activeUserControl = profilepage;
        }
        public void closePaymentOptions()
        {
            activeUserControl.Visible=false;
            showProfilePage();
        }public void closeHistory()
        {
            activeUserControl.Visible=false;
            showProfilePage();
        }
        public void showHistory()
        {
            // Create the HistoryPage control with the current username
            historyPage historyPage = new historyPage(username);

            // Hide other pages if necessary
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != historyPage)
                {
                    ctrl.Visible = false;
                }
            }

            // Show the HistoryPage
            historyPage.Visible = true;
            this.Controls.Add(historyPage);
            historyPage.closeHistory += closeHistory;
            activeUserControl = historyPage;
        }
        public void showFav()
        {
            favMovies favmovies = new favMovies(username) { Visible = true };
            favmovies.BringToFront();
            this.Controls.Add(favmovies);
            activeUserControl.Visible = false;
            activeUserControl = favmovies;
            favmovies.Visible = true;
            profilepage.Visible = false;
        }
        public void closeFav()
        {
            favmovies.Visible = false;
            showProfilePage();
        }
        private void logOut()
        {
            username = null;
            homebutton.Visible = false;
            profilepage.Visible = false;
            welcomepage.Visible = true;
        }

        private void AddHomeButton(Button homeButton)
        {
            // Create a Home button
            homeButton.Text = "Home";
            homeButton.Size = new Size(100, 40); // Customize the size as needed
            homeButton.Location = new Point(10, 10); // Position at top-left corner
            homeButton.BringToFront(); // Make sure it's on top of other controls
            homeButton.Click += HomeButton_Click;

            // Add the button to the form
            homeButton.Visible = false;
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != welcomepage)
                {
                    ctrl.Visible = false;
                }
            homePage.Visible = true ;
                homebutton.Visible = true ;
            }

        }

        private void showSignin()
        {
            login.Visible = false;
            signin.Visible = true;
        }private void showLogin()
        {
            login.Visible = true;
            signin.Visible = false;
        }
        private void OnLoginSuccessful(string loggedInUsername)
        {
            username = loggedInUsername;

            // Hide the login/signup control
            login.Visible = false;
            homePage.Visible= true;
            homebutton.Visible= true;   

            // Show a welcome message or update the UI
            MessageBox.Show($"Logged in as {username}");
        }
        private void OnloginSignin(string option)
        {
            welcomepage.Visible = false;
            if(option=="login")
            {
                login.Visible = true;
            }
            else
            {
                signin.Visible = true;
            }

        }
        //signedin
        private void onSigninSuccessful(string signinUsername)
        {
            username = signinUsername;
            MessageBox.Show($"Logged in as {username}");

            // Hide the login/signup control
            signin.Visible = false;
            homePage.Visible = true;
            homebutton.Visible= true;

            // Show a welcome message or update the UI
        }
        //opening a page of movie
        private void openMovie(string movieName)
        {
            homePage.Visible = false;
            //MessageBox.Show(movieName);
            moviePage moviepage = new moviePage(movieName){Visible = true};
            this.Controls.Add(moviepage);
            activeUserControl =  moviepage;

        moviepage.buyTicket += buyTicket;
        }

        public void buyTicket(int id, string title, string time, string theater)
        {
            List<string> options = dbFunctions.getPaymentOptions(username);
            payment paymentForm = new payment(options, id, username);
            paymentForm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //login button
        private void button1_Click(object sender, EventArgs e)
        {
            login.Visible = true;
        }

        //sign in button
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void loginControl1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
