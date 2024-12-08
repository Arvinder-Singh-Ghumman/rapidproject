using Azure.Identity;
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
    public partial class profilePage : UserControl
    {
        databaseFunctions functions = new databaseFunctions();
        public Action logOut { get; set; }
        public Action showFav{ get; set; }
        public Action showHistory{ get; set; }
        public Action showPaymentOptions { get; set; }
        public string userName;
        public profilePage(string name)
        {
            InitializeComponent();
            this.userName = name;
            txtwelcome.Text = "Welcome, " + userName;
        }

        private void logout_Click(object sender, EventArgs e)
        {
            logOut?.Invoke();
        }

        private void favMovies_Click(object sender, EventArgs e)
        {
            showFav?.Invoke();

        }

        private void history_Click(object sender, EventArgs e)
        {
            showHistory?.Invoke();
        }

        private void paymentOptions_Click(object sender, EventArgs e)
        {
            showPaymentOptions?.Invoke();
        }

        private void deleteHistory_Click(object sender, EventArgs e)
        {
            if (functions.DeleteUserBookings(userName))
                MessageBox.Show("Deleted");
            
        }
    }
}
