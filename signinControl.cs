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
    public partial class signinControl : UserControl
    {
        public event Action<string> SigninSuccessful;

        public event Action showLogIn;
        public signinControl()
        {
            InitializeComponent();
        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            //sign in logic
            if (confirmPasswordInput.Text == passwordInput.Text)
            {
                //checking if there are valid inputs
                if (string.IsNullOrWhiteSpace(usernameInput.Text) ||
                    string.IsNullOrWhiteSpace(emailInput.Text) ||
                    string.IsNullOrWhiteSpace(passwordInput.Text) ||
                    string.IsNullOrWhiteSpace(confirmPasswordInput.Text) ||
                    string.IsNullOrWhiteSpace(phoneinput.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }
                // Validate email format
                else
                {
                    var emailRegex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
                    if (!emailRegex.IsMatch(emailInput.Text))
                    {
                        MessageBox.Show("Please enter a valid email address."); return;
                    }
                    else
                    {
                        var phoneRegex = new System.Text.RegularExpressions.Regex(@"^\d{10}$"); // 10-digit phone number
                        if (!phoneRegex.IsMatch(phoneinput.Text))
                        {
                            MessageBox.Show("Please enter a valid phone number."); return;
                        }
                        else if (passwordInput.Text.Length < 8 || !passwordInput.Text.Any(char.IsLetter) || !passwordInput.Text.Any(char.IsDigit))
                        {
                            MessageBox.Show("Password must be at least 8 characters long and contain a mix of letters and numbers."); return;
                        }
                    }
                }

                databaseFunctions dbHelper = new databaseFunctions();
            bool isValidUser = dbHelper.SignUp(usernameInput.Text, emailInput.Text, passwordInput.Text,phoneinput.Text);

                //success 
                if (isValidUser) SigninSuccessful?.Invoke(usernameInput.Text);
            }
            else
            {
                MessageBox.Show("Passwords do not match.");
            }
        }

        private void loginToSignin_Click(object sender, EventArgs e)
        {
            showLogIn?.Invoke();
        }
    }
}
