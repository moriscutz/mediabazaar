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

            while (selectedDate.DayOfWeek != DayOfWeek.Monday)
            {
                selectedDate = selectedDate.AddDays(1);
            }

            int shiftsGenerated = algorithm.GenerateSchedule(selectedDate);

            if(algorithm.daysNotScheduled.Count>0)
            {
                foreach (DateTime date in algorithm.daysNotScheduled)
                {
                    
                        MessageBox.Show($"There are not enough available employees for the date {date.DayOfWeek}, {date.Day}:{date.Month}:{date.Year}. Please create schedules manually.", "Schedule Not Generated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                }
                    
            }
            MessageBox.Show($"{shiftsGenerated} shifts have been scheduled starting from {selectedDate.DayOfWeek}, {selectedDate.ToShortDateString()}, until the end of the week. {algorithm.shiftsAlreadyScheduled} shifts were already scheduled.", "Schedule Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
