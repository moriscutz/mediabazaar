using BusinessLogic.Algorithm;
using BusinessLogic.Classes;
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
    public partial class GenerateScheduleWindow : Form
    {
        private readonly Administration administration;
        private readonly ScheduleEmployeeAlgorithm algorithm;
        public GenerateScheduleWindow(Administration _administration)
        {
            administration = _administration;
            algorithm = new ScheduleEmployeeAlgorithm(administration);
            InitializeComponent();
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar.SelectionStart;
            DateTime todayDate = DateTime.Today;
            if (selectedDate == todayDate)
            {
                MessageBox.Show("You cannot schedule shifts for today, please do it manually.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (selectedDate < todayDate)
            {
                MessageBox.Show("You cannot schedule shifts in the past.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                while (selectedDate.DayOfWeek != DayOfWeek.Monday)
                {
                    selectedDate = selectedDate.AddDays(1);
                }

                int shiftsGenerated = algorithm.GenerateSchedule(selectedDate);

                if (algorithm.daysNotScheduled.Count > 0)
                {
                    string daysNotScheduledMessage = $"There were insufficient employees on the following days: ";
                    foreach (DateTime date in algorithm.daysNotScheduled)
                    {
                        daysNotScheduledMessage += $"{date.ToShortDateString()}, ";
                    }
                    daysNotScheduledMessage = daysNotScheduledMessage.TrimEnd(',', ' ');
                    daysNotScheduledMessage += ". Please create schedules manually for these days.";

                    MessageBox.Show(daysNotScheduledMessage, "Schedule Partially Generated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                string message = $"{shiftsGenerated} shifts have been scheduled starting from {selectedDate.ToShortDateString()} until the end of the week. ";
                message += $"{algorithm.shiftsAlreadyScheduled} shifts were already scheduled. ";
                if (algorithm.daysWithInsufficientStaff > 0)
                {
                    message += $"{algorithm.daysWithInsufficientStaff} days had insufficient staff to fully schedule.";
                }

                MessageBox.Show(message, "Schedule Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        public List<DateTime> GetNotFullyScheduledDays()
        {
            return algorithm.daysNotScheduled;
        }
    }
}
