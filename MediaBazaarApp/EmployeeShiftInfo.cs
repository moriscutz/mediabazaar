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
    public partial class EmployeeShiftInfo : Form
    {
        private readonly Administration administration;
        private readonly Employee employee;
        private List<Shift> shifts;
        
        public EmployeeShiftInfo(Administration _administration, Employee _employee)
        {
            administration= _administration;
            employee= _employee;
            shifts = administration.GetShiftsForEmployeeById(employee.ID);
            
            InitializeComponent();
           
            RefreshShifts();
        }
       
        private void RefreshShifts()
        {
            
            shifts = administration.GetShiftsForEmployeeById(employee.ID);

            
            dataGridView.DataSource = shifts;
        }

        private void cancelShiftButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                
                Shift selectedShift = dataGridView.SelectedRows[0].DataBoundItem as Shift;

                
                administration.DeleteShift(selectedShift);

                MessageBox.Show("The shift has been deleted succesfully");
                
                RefreshShifts();
            }
            else
            {
                MessageBox.Show("Please select a shift to cancel.");
            }
        }

        private void changeShiftButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {

                Shift selectedShift = dataGridView.SelectedRows[0].DataBoundItem as Shift;
                ChangeShift changeShift = new ChangeShift(administration,selectedShift);
                changeShift.Show();
            }
            else
            {
                MessageBox.Show("Please select a shift to change.");
            }
        }

        private void refreshShiftsButton_Click(object sender, EventArgs e)
        {
            RefreshShifts();
        }
    }
}
