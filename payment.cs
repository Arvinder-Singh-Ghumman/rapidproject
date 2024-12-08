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
    public partial class payment : Form
    {
        public string SelectedPaymentOption { get; private set; }
        public int showTimeId;
        public string username;

        databaseFunctions db = new databaseFunctions();

        public bool IsPaymentConfirmed { get; private set; }
        public payment(List<string> paymentOptions, int showTimeId, string username)
        {
            InitializeComponent();
            this.showTimeId = showTimeId;
            this.username = username;
            // Check if payment options are available
            if (paymentOptions.Count == 0)
            {
                MessageBox.Show("No payment options found. Please add one in the settings.");
                IsPaymentConfirmed = false;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                // Populate ComboBox with payment options
                paymentoptions.DataSource = paymentOptions;
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Confirm payment with selected option
            SelectedPaymentOption = paymentoptions.SelectedItem.ToString();

            //logic
            
            bool isBooked = db.BookShowtime(showTimeId, username);

            if (isBooked)
            {
                MessageBox.Show("Showtime booked successfully!");
            }
            else
            {
                MessageBox.Show("Failed to book the showtime.");
                IsPaymentConfirmed = false;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            IsPaymentConfirmed = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel the payment process
            IsPaymentConfirmed = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
