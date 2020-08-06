using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject
{
    public partial class SignIn : Form
    {
        DBAccess objDBAccess = new DBAccess();
        DataTable dtUsers = new DataTable();
        public SignIn()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string userEmail = txtEmailLogin.Text;
            string userPassword = txtPasswordLogin.Text;

            if (userEmail.Equals(""))
            {
                MessageBox.Show("Please enter email");
            }
            else if (userPassword.Equals(""))
            {
                MessageBox.Show("Please enter password");
            }
            else
            {
                string query = "SELECT * FROM Users WHERE Email = '" + userEmail + "' AND Password='" + userPassword + "'";

                objDBAccess.readDatathroughAdapter(query, dtUsers);

                if (dtUsers.Rows.Count == 1)
                {
                    MessageBox.Show("Congratulations, you are logged in Successfully!");
                    objDBAccess.closeConn();

                    this.Hide();
                    HomePage home = new HomePage();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("Invalid credentials, Provide correct email and password");
                }
            }
        }
    }
}
