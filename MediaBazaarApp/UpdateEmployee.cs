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
    public partial class UpdateEmployee : Form
    {
        Position position;
        ShiftType shiftType;
        private readonly Administration administration;
        private readonly Employee employee;
        public UpdateEmployee(Administration _administration, Employee _employee)
        {
            administration= _administration;
            employee= _employee;
             _employee.Availabilities = administration.GetAvailabilitiesByEmployeeId(employee.ID);
            InitializeComponent();

            LoadEmployeeData(employee);
        }

        private void LoadEmployeeData(Employee employee)
        {
            IDLabel.Text = employee.ID.ToString();
            firstNameTextBox.Text = employee.FirstName;
            lastNameTextBox.Text = employee.LastName;
            usernameTextBox.Text = employee.Username;
            positionComboBox.SelectedItem = employee.JobPosition.ToString();

            foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
            {
                ComboBox dayComboBox = this.Controls.Find($"{day}ComboBox", true).FirstOrDefault() as ComboBox;
                if (dayComboBox != null)
                {
                    dayComboBox.SelectedItem = "Not Available"; // Default value
                }
            }
            foreach (var availability in employee.Availabilities)
            {
                string dayName = availability.DayOfWeek.ToString();
                ComboBox dayComboBox = this.Controls.Find($"{dayName}ComboBox", true).FirstOrDefault() as ComboBox;
                if (dayComboBox != null)
                {
                    string availabilityText = availability.IsAvailable ? "Available" : "Not Available";
                    dayComboBox.SelectedItem = availabilityText;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"ComboBox not found for {dayName}");
                }
            }
        }
            private void updateEmployeeButton_Click(object sender, EventArgs e)
            {
                if (ValidateForm())
                {
                    UpdateEmployeeData();
                }
            }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return false;
            }
            return true;
        }
        private void UpdateEmployeeData()
        {
            employee.FirstName = firstNameTextBox.Text;
            employee.LastName = lastNameTextBox.Text;
            employee.Username = usernameTextBox.Text;
            employee.JobPosition = (Position)Enum.Parse(typeof(Position), positionComboBox.SelectedItem.ToString());

            employee.Availabilities.Clear();
            foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
            {
                ComboBox dayComboBox = this.Controls.Find($"{day}ComboBox", true).FirstOrDefault() as ComboBox;

                if (dayComboBox != null)
                {
                    bool isAvailable = dayComboBox.SelectedItem.ToString() == "Available";
                    ShiftType defaultShiftType = ShiftType.Morning; // DEFAULT VALUE.

                    employee.Availabilities.Add(new Availability(employee.ID, day, defaultShiftType, isAvailable));
                }
            }


            administration.UpdateEmployee(employee);

            MessageBox.Show("The data has been updated in the database.");
            this.Close();

        }

    }
}
