using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoApplication
{
    public partial class LoginFrm : Form
    {
        private DatabaseManipulator dm;
        public LoginFrm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "")
            {
                MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter a password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            try
            {
                this.dm = new DatabaseManipulator();
                this.dm.setSQL("EXECUTE loginCredentialExistence @Username = '" + txtUsername.Text + "', @Password = '" + txtPassword.Text + "';");
                this.dm.executeScript();
                if(this.dm.getDataReader().Read() != false)
                {
                    this.Hide();
                    var mainFrm = new mainWindow(txtUsername.Text);
                    mainFrm.Closed += (s, args) => this.Close();
                    mainFrm.Show();
                }
                else
                {
                    MessageBox.Show("Username and/or password incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
