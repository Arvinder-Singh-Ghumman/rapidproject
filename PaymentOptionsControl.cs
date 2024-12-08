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
    public partial class PaymentOptionsControl : UserControl
    {
        public PaymentOptionsControl(string name)
        {
            InitializeComponent(); InitializeControls();
            this.username = name;
        }

        private string username;
        private TextBox txtCardNumber;
        private TextBox txtCVV;
        private TextBox txtHolderName;
        private Button btnAddPaymentOption;
        private Button closeButton;
        private Label lblMessage;
        private Label lblCardNumber;
        private Label lblCVV;
        private Label lblHolderName;
        private databaseFunctions db = new databaseFunctions();
        public event Action closePayment;

        private void InitializeControls()
        {
            // Initialize the controls for user input
            txtCardNumber = new TextBox { Location = new System.Drawing.Point(50, 50), Width = 200, MaxLength = 16 };
            txtCVV = new TextBox { Location = new System.Drawing.Point(50, 100), Width = 100, MaxLength = 3, PasswordChar = '*' };
            txtHolderName = new TextBox { Location = new System.Drawing.Point(50, 150), Width = 200 };

            // Initialize labels for the input fields
            lblCardNumber = new Label { Text = "Card Number", Location = new System.Drawing.Point(50, 30), AutoSize = true };
            lblCVV = new Label { Text = "CVV", Location = new System.Drawing.Point(50, 80), AutoSize = true };
            lblHolderName = new Label { Text = "Holder's Name", Location = new System.Drawing.Point(50, 130), AutoSize = true };

            // Add a submit button
            btnAddPaymentOption = new Button
            {
                Text = "Add Payment Option",
                Location = new System.Drawing.Point(20, 200),
                Width = 200
            };
            btnAddPaymentOption.Click += BtnAddPaymentOption_Click;

            // Label to show success or error messages
            lblMessage = new Label
            {
                Location = new System.Drawing.Point(20, 250),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Red
            };

            // Initialize the Close Button
            closeButton = new Button();
            closeButton.Text = "X"; 
            closeButton.Size = new Size(30, 30); 
            closeButton.Location = new Point(this.Width - closeButton.Width - 40, 40); // Top-right corner, adjust as needed
            closeButton.Click += button1_Click; // Handle the click event

            // Add controls to the UserControl
            this.Controls.Add(closeButton);
            this.Controls.Add(txtCardNumber);
            this.Controls.Add(txtCVV);
            this.Controls.Add(txtHolderName);
            this.Controls.Add(btnAddPaymentOption);
            this.Controls.Add(lblMessage);
            this.Controls.Add(lblCardNumber);
            this.Controls.Add(lblCVV);
            this.Controls.Add(lblHolderName);
        }

        private void BtnAddPaymentOption_Click(object sender, EventArgs e)
        {
            // Validate user input
            if (string.IsNullOrEmpty(txtCardNumber.Text) || string.IsNullOrEmpty(txtCVV.Text) || string.IsNullOrEmpty(txtHolderName.Text))
            {
                lblMessage.Text = "All fields are required!";
                return;
            }

            if (txtCardNumber.Text.Length != 16 || txtCVV.Text.Length != 3)
            {
                lblMessage.Text = "Invalid card number or CVV!";
                return;
            }

            // Call method to save the payment option (you would save it to a database or local storage here)
            SavePaymentOption(txtCardNumber.Text, username);

            // Clear the form fields after saving
            txtCardNumber.Clear();
            txtCVV.Clear();
            txtHolderName.Clear();

            // Show success message
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Payment option added successfully!";
        }

        private void SavePaymentOption(string cardNumber, string username)
        {
            var db = new databaseFunctions();

            // Step 1: Get the current card numbers for the user
            string currentCardNumbers = db.GetCardNumbers(username);

            // Step 2: Append the new card number to the current list
            string newCardNumbers;
            if (currentCardNumbers==null || string.IsNullOrEmpty(currentCardNumbers))
            {
                newCardNumbers = cardNumber;  // If no cards exist, just set the new card number
            }
            else
            {
                newCardNumbers = currentCardNumbers + "," + cardNumber;  // Append the new card number
            }
            // Step 3: Update the PaymentOptions table with the new card numbers
            string updateQuery = "UPDATE Users SET PaymentOptions = @CardNumbers WHERE Username = @Username";
            var updateParameters = new Dictionary<string, object>
    {
        { "@CardNumbers", newCardNumbers },
        { "@Username", username }
    };

            db.ExecuteNonQuery(updateQuery, updateParameters);  // Execute the update
        }

        private void PaymentOptionsControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            closePayment?.Invoke();
        }
    }
}
