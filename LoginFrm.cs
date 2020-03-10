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
            try
            {
                this.dm = new DatabaseManipulator();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
            }
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
                this.dm.setSQL("EXECUTE loginCredentialExistence @Username = '" + txtUsername.Text + "', @Password = '" + txtPassword.Text + "';");
                this.dm.getDataReader();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
