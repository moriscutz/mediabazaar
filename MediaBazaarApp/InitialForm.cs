using BusinessLogic.Classes;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarApp
{
    public partial class InitialForm : Form
    {
        private readonly Administration administration;
        public InitialForm(IEmployeeDB employeeDB, IShiftDB shiftDB, IAvailabilityDB availabilityDB)
        {
            administration = new Administration(employeeDB, shiftDB, availabilityDB);
            InitializeComponent();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {

            if (usernameTextBox.Text == string.Empty || passwordTextBox.Text == string.Empty)
                MessageBox.Show("Please enter your username and password first!");
            else
            {
                var user = administration.Authenticate(usernameTextBox.Text, passwordTextBox.Text);
                ManagingForm managingForm;
                if (user != null)
                {
                    switch (user.JobPosition)
                    {
                        case Position.Manager:
                            managingForm = new ManagingForm(administration);
                            managingForm.Show();
                            this.Hide();
                            break;
                        case Position.Supervisor:
                            managingForm = new ManagingForm(administration);
                            managingForm.Show();
                            this.Hide();
                            break;
                        default:
                            MessageBox.Show("Your role does not allow you to use this application!");
                            break;
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("User is null");
                    MessageBox.Show("The user is not in the database");
                }
            }
        }
    }
}
