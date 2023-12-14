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
            List<Preference> preferences = administration.GetPreferencesByEmployeeId(employee.ID);

            InitializeComponent();

            //MessageBox.Show("This functionality is NOT finished!");

            PopulatePage(administration, employee, preferences);
        }

        private void PopulatePage(Administration administration, Employee employee, List<Preference> preferences)
        {
            IDLabel.Text = employee.ID.ToString();
            firstNameTextBox.Text = employee.FirstName;
            lastNameTextBox.Text = employee.LastName;
            //emailTextBox
            usernameTextBox.Text = employee.Username;

            positionComboBox.SelectedItem = employee.JobPosition.ToString();


            SetComboBoxForDay(MondayComboBox, preferences, DayOfWeek.Monday);
            SetComboBoxForDay(TuesdayComboBox, preferences, DayOfWeek.Tuesday);
            SetComboBoxForDay(WednesdayComboBox, preferences, DayOfWeek.Wednesday);
            SetComboBoxForDay(ThursdayComboBox, preferences, DayOfWeek.Thursday);
            SetComboBoxForDay(FridayComboBox, preferences, DayOfWeek.Friday);
            SetComboBoxForDay(SaturdayComboBox, preferences, DayOfWeek.Saturday);
            SetComboBoxForDay(SundayComboBox, preferences, DayOfWeek.Sunday + 7);
        }

        private void SetComboBoxForDay(ComboBox comboBox, List<Preference> preferences, DayOfWeek dayOfWeek)
        {
            Preference dayPreference = preferences.FirstOrDefault(p => p.DayOfWeek == (int)dayOfWeek);

            if (dayPreference != null)
            {
                
                comboBox.SelectedItem = dayPreference.ShiftType.ToString();
            }
            else
            {
                System.Diagnostics.Debug.Write($"No preference found for {dayOfWeek}");
            }
        }

        private void updateEmployeeButton_Click(object sender, EventArgs e)
        {
            try
            {
                employee.FirstName = firstNameTextBox.Text;
                employee.LastName = lastNameTextBox.Text;
                employee.Username = usernameTextBox.Text;   
                string positionBox = positionComboBox.SelectedItem?.ToString();

                if (Enum.TryParse(positionBox, out position))
                {
                    employee.JobPosition = position;

                    
                    administration.UpdateEmployee(employee);
                    UpdatePreferences(employee);


                    MessageBox.Show("Employee updated successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid selection for the Position");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}");
            }
        }

        private void UpdatePreferences(Employee employee)
        {
            
            var updatedPreferences = new List<Preference>();

            
            UpdatePreferenceForDay(updatedPreferences, DayOfWeek.Monday, MondayComboBox);
            UpdatePreferenceForDay(updatedPreferences, DayOfWeek.Tuesday, TuesdayComboBox);
            UpdatePreferenceForDay(updatedPreferences, DayOfWeek.Wednesday, WednesdayComboBox);
            UpdatePreferenceForDay(updatedPreferences, DayOfWeek.Thursday, ThursdayComboBox);
            UpdatePreferenceForDay(updatedPreferences, DayOfWeek.Friday, FridayComboBox);
            UpdatePreferenceForDay(updatedPreferences, DayOfWeek.Saturday, SaturdayComboBox);
            UpdatePreferenceForDay(updatedPreferences, DayOfWeek.Sunday + 7, SundayComboBox);

            administration.UpdatePreferencesForEmployee(employee.ID, updatedPreferences);
        }

        private void UpdatePreferenceForDay(List<Preference> updatedPreferences, DayOfWeek dayOfWeek, ComboBox comboBox)
        {
            if (Enum.TryParse(comboBox.SelectedItem?.ToString(), out shiftType))
            {
                int databaseDayOfWeek = ((int)dayOfWeek);
                var preference = new Preference
                {
                    PreferenceId = Guid.NewGuid(),
                    DayOfWeek = databaseDayOfWeek,
                    ShiftType = shiftType,
                    EmployeeId = employee.ID
                };

                updatedPreferences.Add(preference);
            }
            else
            {
                MessageBox.Show($"Invalid selection for {dayOfWeek} preference");
            }
        }
    }
}
