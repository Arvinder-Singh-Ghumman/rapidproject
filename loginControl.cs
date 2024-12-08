using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{

    public partial class loginControl : UserControl
    {
        public event Action<string> LoginSuccessful;    
        public event Action showSignin;    
        public loginControl()
        {
            InitializeComponent();
        }

        private void usernameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void passowrdInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameInput.Text) || string.IsNullOrWhiteSpace(passowrdInput.Text))
            {
                MessageBox.Show("Please enter both username and password.");return;
            }
            else
            {
                // Proceed with the login process
                string username = usernameInput.Text;
                string password = passowrdInput.Text;

                // Call the database function to check if the username and password match
                databaseFunctions dbHelper = new databaseFunctions();
                bool isValidUser = dbHelper.Login(username, password);

                // Check if login is successful
                if (isValidUser)
                {
                    // Trigger the SignInSuccessful event with the username
                    MessageBox.Show($"Welcome, {username}!"); 
                    LoginSuccessful?.Invoke(username);
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
        }

        private void loginControl_Load(object sender, EventArgs e)
        {

        }

        private void loginToSignin_Click(object sender, EventArgs e)
        {
            showSignin?.Invoke();
        }
    }
}
