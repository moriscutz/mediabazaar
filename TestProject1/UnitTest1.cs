using BusinessLogic.Classes;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting; // MSTest Framework Namespace


namespace TestProject1
{
    public class MockDateService : BusinessLogic.Classes.Administration.IDateService
    {
        private DateTime _currentDate;

        public MockDateService()
        {
            _currentDate = DateTime.Today; // Initialize with the current date
        }

        public DateTime Today => _currentDate;

        public void SetCurrentDate(DateTime date)
        {
            _currentDate = date;
        }
    }



    public class MockEmployeeDB : IEmployeeDB
    {
        private List<Employee> mockEmployees = new List<Employee>();

        public void AddEmployeeWithPreferences(Employee employee)
        {

        }
        public void UpdateEmployeeWithPreferences(Employee employee)
        {

        }
        public void UpdatePreferencesForEmployee(Guid ID, List<Preference> updatedPreferences)
        {


        }
        public void AddEmployee(Employee employee)
        {
            mockEmployees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = mockEmployees.FirstOrDefault(e => e.ID == employee.ID);
            if (existingEmployee != null)
            {
                mockEmployees.Remove(existingEmployee);
                mockEmployees.Add(employee);
            }
        }

        public void DeleteEmployee(Employee employee)
        {
            mockEmployees.Remove(employee);
        }

        public Employee GetEmployeeById(Guid id)
        {
            return mockEmployees.FirstOrDefault(e => e.ID == id);
        }

        public List<Employee> GetAllEmployees()
        {
            return new List<Employee>(mockEmployees);
        }

        public Employee Authenticate(string username, string password)
        {
            return mockEmployees.FirstOrDefault(e => e.Username == username && e.Password == password);
        }
    }

    public class MockShiftDB : IShiftDB
    {
        private List<Shift> mockShifts = new List<Shift>();
        private List<Preference> mockPreferences = new List<Preference>();

        public void AddShift(Shift shift)
        {
            mockShifts.Add(shift);
        }
        public int CountShiftsOnDateAndType(DateTime date, ShiftType shiftType)
        {
            return mockShifts.Count(s => s.Date.Date == date.Date && s.Type == shiftType);
        }

        public void UpdateShift(Shift shift)
        {
            var existingShift = mockShifts.FirstOrDefault(s => s.ShiftId == shift.ShiftId);
            if (existingShift != null)
            {
                mockShifts.Remove(existingShift);
                mockShifts.Add(shift);
            }
        }

        public void DeleteShift(Shift shift)
        {
            mockShifts.Remove(shift);
        }

        public Shift GetShiftById(Guid shiftId)
        {
            return mockShifts.FirstOrDefault(s => s.ShiftId == shiftId);
        }

        public List<Shift> GetAllShifts()
        {
            return new List<Shift>(mockShifts);
        }

        public List<Shift> GetShiftsForEmployeeById(Guid employeeId)
        {
            return mockShifts.Where(s => s.EmployeeID == employeeId).ToList();
        }

        public void AddPreference(Preference preference)
        {
            mockPreferences.Add(preference);
        }

        public void UpdatePreference(Preference preference)
        {
            var existingPreference = mockPreferences.FirstOrDefault(p => p.PreferenceId == preference.PreferenceId);
            if (existingPreference != null)
            {
                mockPreferences.Remove(existingPreference);
                mockPreferences.Add(preference);
            }
        }

        public List<Preference> GetPreferencesByEmployeeId(Guid employeeId)
        {
            return mockPreferences.Where(p => p.EmployeeId == employeeId).ToList();
        }

        public List<Preference> GetPreferencesByDayOfWeek(int dayOfWeek)
        {
            return mockPreferences.Where(p => p.DayOfWeek == dayOfWeek).ToList();
        }
    }

    [TestClass]
    public class AdministrationTests
    {
        private MockEmployeeDB mockEmployeeDB;
        private MockShiftDB mockShiftDB;
        private MockDateService mockDateService;
        private Administration administration;
        private Employee testEmployee;
        private string preferencePattern = "0120120"; // Class-level field
        private string initialPreferencePattern = "1111111";
        private string updatedPreferencePattern = "2102102";
        [TestInitialize]
        public void Initialize()
        {
            mockEmployeeDB = new MockEmployeeDB();
            mockShiftDB = new MockShiftDB();
            mockDateService = new MockDateService();
            administration = new Administration(mockEmployeeDB, mockShiftDB, mockDateService);

            // Create a test employee
            testEmployee = new Employee
            {
                ID = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Username = "johndoe",
                Password = "password"
            };

            // Add the employee to mock DB
            mockEmployeeDB.AddEmployee(testEmployee);

            // Define preferences (0: Morning, 1: Afternoon, 2: Night)
            for (int day = 0; day < 7; day++)
            {
                var preference = new Preference
                {
                    PreferenceId = Guid.NewGuid(),
                    DayOfWeek = day + 1, // Assuming 1 to 7 represent Monday to Sunday
                    ShiftType = (ShiftType)(int.Parse(preferencePattern[day].ToString())),
                    EmployeeId = testEmployee.ID
                };

                mockShiftDB.AddPreference(preference);
            }
        }

        [TestMethod]
        public void ScheduleShiftsBasedOnPreferences_AssignsShiftsCorrectly()
        {
            // Arrange
            var mockEmployeeDB = new MockEmployeeDB();
            var mockShiftDB = new MockShiftDB();
            var mockDateService = new MockDateService();
            var administration = new Administration(mockEmployeeDB, mockShiftDB, mockDateService);

            // Setting up test data
            var employeeId = Guid.NewGuid();
            var testEmployee = new Employee { ID = employeeId, FirstName = "John", LastName = "Doe", Username = "johndoe", Password = "password" };
            mockEmployeeDB.AddEmployee(testEmployee);

            var preference = new Preference { PreferenceId = Guid.NewGuid(), DayOfWeek = 1, ShiftType = ShiftType.Morning, EmployeeId = employeeId };
            mockShiftDB.AddPreference(preference);

            // Act
            administration.ScheduleShiftsBasedOnPreferences();

            // Assert
            var shifts = mockShiftDB.GetShiftsForEmployeeById(employeeId);
            Assert.IsTrue(shifts.Any());
            Assert.IsTrue(shifts.All(s => s.Type == ShiftType.Morning)); // Verifying all assigned shifts are morning shifts as per preference
        }

        private (DateTime startDate, DateTime endDate) GetSchedulingPeriodForTesting()
        {
            // Adjust this method to return the start and end dates of Week 3
            var today = mockDateService.Today;
            int daysUntilNextNextMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 14) % 7;
            daysUntilNextNextMonday = daysUntilNextNextMonday == 0 ? 7 : daysUntilNextNextMonday;

            var startDate = today.AddDays(daysUntilNextNextMonday + 7); // Start of Week 3
            var endDate = startDate.AddDays(6); // End of Week 3

            return (startDate, endDate);
        }


    }
    public interface IDateService
    {
        DateTime Today { get; }
    }
    public class DateService : IDateService
    {
        public DateTime Today => DateTime.Today;
    }
    [TestClass]
    public class RandomTest
    {
        private Random random = new Random();

        [TestMethod]
        public void TestRandomNumbers()
        {
            // Generate two random integers between 1 and 100 (inclusive)
            int randomNumber1 = random.Next(1, 101);
            int randomNumber2 = random.Next(1, 101);

            // Assert that the generated numbers are within the valid range
            Assert.IsTrue(randomNumber1 >= 1 && randomNumber1 <= 100);
            Assert.IsTrue(randomNumber2 >= 1 && randomNumber2 <= 100);

            // Perform some random calculations
            int sum = randomNumber1 + randomNumber2;
            int product = randomNumber1 * randomNumber2;

            // Assert specific conditions on the calculated values
            Assert.IsTrue(sum >= 2);
            Assert.IsTrue(product >= 1);

            // Display the generated numbers and calculations
            Console.WriteLine($"Random Number 1: {randomNumber1}");
            Console.WriteLine($"Random Number 2: {randomNumber2}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Product: {product}");
        }
    }



}