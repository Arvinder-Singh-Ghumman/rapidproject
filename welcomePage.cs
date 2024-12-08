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
    public partial class welcomePage : UserControl
    {
        public event Action<string> loginSignin;
        public welcomePage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            loginSignin?.Invoke("login");
        }

        private void SigninButton_Click(object sender, EventArgs e)
        {
            loginSignin?.Invoke("signin");

        }
    }
}
