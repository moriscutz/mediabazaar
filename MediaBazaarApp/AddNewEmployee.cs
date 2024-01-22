using BusinessLogic.Classes;
using BusinessLogic.Enums;
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
    public partial class AddNewEmployee : Form
    {
        private readonly Administration administration;
        Position positionEnum;
        ShiftType shiftTypeEnum;
        public AddNewEmployee(Administration administration)
        {
            this.administration = administration;
            InitializeComponent();
        }

        private void createEmployeeButton_Click(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text != string.Empty && lastNameTextBox.Text != string.Empty
                && usernameTextBox.Text != string.Empty && passwordTextBox.Text != string.Empty)
            {
                if(administration.GetEmployeeByUsername(usernameTextBox.Text) != null)
                {
                    MessageBox.Show("The username is already taken.", "Username Taken", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Employee newEmployee = new Employee();
                    newEmployee.ID = Guid.NewGuid();
                    newEmployee.FirstName = firstNameTextBox.Text;
                    newEmployee.LastName = lastNameTextBox.Text;
                    newEmployee.Username = usernameTextBox.Text;
                    newEmployee.Password = passwordTextBox.Text;
                    newEmployee.Availabilities = new List<Availability>();

                    string selectedPosition = RoleComboBox.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(selectedPosition) && Enum.TryParse(selectedPosition, out positionEnum))
                    {
                        newEmployee.JobPosition = positionEnum;
                    }
                    else
                    {
                        MessageBox.Show("Invalid selection for the Role");
                        return;
                    }

                    foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
                    {
                        ComboBox dayComboBox = this.Controls.Find($"{day}Preference", true).FirstOrDefault() as ComboBox;

                        if (dayComboBox != null)
                        {
                            bool isAvailable = dayComboBox.SelectedItem.ToString() == "Available";
                            ShiftType defaultShiftType = ShiftType.Morning;

                            newEmployee.Availabilities.Add(new Availability(newEmployee.ID, day, defaultShiftType, isAvailable));
                        }
                    }

                    administration.AddEmployee(newEmployee);
                    MessageBox.Show("Employee created successfully");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill each box in the form!");
            }
        }

    }
}
