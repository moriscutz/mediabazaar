using BusinessLogic.Classes;

namespace TestClasses
{
    [TestClass]
    public class ScheduleEmployeeAlgorithmTests
    {
        private Mock<IAdministration> mockAdministration;
        private ScheduleEmployeeAlgorithm algorithm;
        private List<Employee> mockEmployees;

        [TestInitialize]
        public void Setup()
        {
            // Initialize mock objects
            mockAdministration = new Mock<IAdministration>();

            // Here, include all your mock employees
            mockEmployees = new List<Employee>
            {
            new Employee(Guid.Parse("B0E51A3C-C088-4B9D-81CC-4F7D75E2B38D"), "Bob", "Johnson", Position.Picker, "qwerty", "bobjohnson"),
            new Employee(Guid.Parse("5E70995E-9CA2-4442-BD9A-58EF74FF1934"), "John", "Doe", Position.Supervisor, "password123", "john.doe"),
            new Employee(Guid.Parse("3294AB82-F393-4E88-9F08-77AFA76B4F29"), "Supervisor", "Supervisor", Position.Supervisor, "supervisor", "supervisor"),
            new Employee(Guid.Parse("65D9A69F-7495-4171-BAAB-7B882B803C2A"), "Alice", "Smith", Position.Picker, "alicepassword", "alice.smith"),
            new Employee(Guid.Parse("819BE9E1-F8CF-4F94-9F71-9321D002342F"), "Chloe", "Adams", Position.Manager, "chloeadams", "chloe.adams")
            };

            List<Availability> allAvailabilities = new List<Availability>
            {
                new Availability(Guid.Parse("B0E51A3C-C088-4B9D-81CC-4F7D75E2B38D"), DaysOfWeek.Monday, ShiftType.Morning, true),
                new Availability(Guid.Parse("B0E51A3C-C088-4B9D-81CC-4F7D75E2B38D"), DaysOfWeek.Tuesday, ShiftType.Morning, true),
                new Availability(Guid.Parse("B0E51A3C-C088-4B9D-81CC-4F7D75E2B38D"), DaysOfWeek.Wednesday, ShiftType.Morning, true),
                new Availability(Guid.Parse("B0E51A3C-C088-4B9D-81CC-4F7D75E2B38D"), DaysOfWeek.Thursday, ShiftType.Morning, false),
                new Availability(Guid.Parse("B0E51A3C-C088-4B9D-81CC-4F7D75E2B38D"), DaysOfWeek.Friday, ShiftType.Morning, false),
                new Availability(Guid.Parse("B0E51A3C-C088-4B9D-81CC-4F7D75E2B38D"), DaysOfWeek.Saturday, ShiftType.Morning, true),
                new Availability(Guid.Parse("B0E51A3C-C088-4B9D-81CC-4F7D75E2B38D"), DaysOfWeek.Sunday, ShiftType.Morning, false),

                new Availability(Guid.Parse("5E70995E-9CA2-4442-BD9A-58EF74FF1934"), DaysOfWeek.Monday, ShiftType.Morning, true),
                new Availability(Guid.Parse("5E70995E-9CA2-4442-BD9A-58EF74FF1934"), DaysOfWeek.Tuesday, ShiftType.Morning, true),
                new Availability(Guid.Parse("5E70995E-9CA2-4442-BD9A-58EF74FF1934"), DaysOfWeek.Wednesday, ShiftType.Morning, true),
                new Availability(Guid.Parse("5E70995E-9CA2-4442-BD9A-58EF74FF1934"), DaysOfWeek.Thursday, ShiftType.Morning, false),
                new Availability(Guid.Parse("5E70995E-9CA2-4442-BD9A-58EF74FF1934"), DaysOfWeek.Friday, ShiftType.Morning, false),
                new Availability(Guid.Parse("5E70995E-9CA2-4442-BD9A-58EF74FF1934"), DaysOfWeek.Saturday, ShiftType.Morning, true),
                new Availability(Guid.Parse("5E70995E-9CA2-4442-BD9A-58EF74FF1934"), DaysOfWeek.Sunday, ShiftType.Morning, false),

                new Availability(Guid.Parse("3294AB82-F393-4E88-9F08-77AFA76B4F29"), DaysOfWeek.Monday, ShiftType.Morning, true),
                new Availability(Guid.Parse("3294AB82-F393-4E88-9F08-77AFA76B4F29"), DaysOfWeek.Tuesday, ShiftType.Morning, true),
                new Availability(Guid.Parse("3294AB82-F393-4E88-9F08-77AFA76B4F29"), DaysOfWeek.Wednesday, ShiftType.Morning, true),
                new Availability(Guid.Parse("3294AB82-F393-4E88-9F08-77AFA76B4F29"), DaysOfWeek.Thursday, ShiftType.Morning, false),
                new Availability(Guid.Parse("3294AB82-F393-4E88-9F08-77AFA76B4F29"), DaysOfWeek.Friday, ShiftType.Morning, false),
                new Availability(Guid.Parse("3294AB82-F393-4E88-9F08-77AFA76B4F29"), DaysOfWeek.Saturday, ShiftType.Morning, true),
                new Availability(Guid.Parse("3294AB82-F393-4E88-9F08-77AFA76B4F29"), DaysOfWeek.Sunday, ShiftType.Morning, false),

                new Availability(Guid.Parse("65D9A69F-7495-4171-BAAB-7B882B803C2A"), DaysOfWeek.Monday, ShiftType.Morning, true),
                new Availability(Guid.Parse("65D9A69F-7495-4171-BAAB-7B882B803C2A"), DaysOfWeek.Tuesday, ShiftType.Morning, true),
                new Availability(Guid.Parse("65D9A69F-7495-4171-BAAB-7B882B803C2A"), DaysOfWeek.Wednesday, ShiftType.Morning, true),
                new Availability(Guid.Parse("65D9A69F-7495-4171-BAAB-7B882B803C2A"), DaysOfWeek.Thursday, ShiftType.Morning, false),
                new Availability(Guid.Parse("65D9A69F-7495-4171-BAAB-7B882B803C2A"), DaysOfWeek.Friday, ShiftType.Morning, false),
                new Availability(Guid.Parse("65D9A69F-7495-4171-BAAB-7B882B803C2A"), DaysOfWeek.Saturday, ShiftType.Morning, true),
                new Availability(Guid.Parse("65D9A69F-7495-4171-BAAB-7B882B803C2A"), DaysOfWeek.Sunday, ShiftType.Morning, false),

                new Availability(Guid.Parse("819BE9E1-F8CF-4F94-9F71-9321D002342F"), DaysOfWeek.Monday, ShiftType.Morning, true),
                new Availability(Guid.Parse("819BE9E1-F8CF-4F94-9F71-9321D002342F"), DaysOfWeek.Tuesday, ShiftType.Morning, true),
                new Availability(Guid.Parse("819BE9E1-F8CF-4F94-9F71-9321D002342F"), DaysOfWeek.Wednesday, ShiftType.Morning, true),
                new Availability(Guid.Parse("819BE9E1-F8CF-4F94-9F71-9321D002342F"), DaysOfWeek.Thursday, ShiftType.Morning, false),
                new Availability(Guid.Parse("819BE9E1-F8CF-4F94-9F71-9321D002342F"), DaysOfWeek.Friday, ShiftType.Morning, false),
                new Availability(Guid.Parse("819BE9E1-F8CF-4F94-9F71-9321D002342F"), DaysOfWeek.Saturday, ShiftType.Morning, true),
                new Availability(Guid.Parse("819BE9E1-F8CF-4F94-9F71-9321D002342F"), DaysOfWeek.Sunday, ShiftType.Morning, false),

            };

            mockAdministration.Setup(a => a.GetAvailableEmployees(It.IsAny<DateTime>(), It.IsAny<ShiftType>()))
                      .Returns((DateTime date, ShiftType shiftType) => mockEmployees);



            mockAdministration.Setup(a => a.GetShiftsByDate(It.IsAny<DateTime>()))
                              .Returns(new List<Shift>());

            // Initialize the algorithm
            algorithm = new ScheduleEmployeeAlgorithm(mockAdministration.Object);
        }


        [TestMethod]
        public void GenerateSchedule_WhenNoEmployeesAvailable_ShouldHaveDaysNotScheduled()
        {
            // Arrange
            var startDate = new DateTime(2024, 1, 1);
            mockAdministration.Setup(a => a.GetAvailableEmployees(It.IsAny<DateTime>(), It.IsAny<ShiftType>()))
                              .Returns(new List<Employee>());


            // Act
            algorithm.GenerateSchedule(startDate);

            // Assert
            Assert.IsTrue(algorithm.daysNotScheduled.Count > 0);
        }

        [TestMethod]
        public void GenerateSchedule_WhenEmployeeAlreadyScheduled_ShouldNotDoubleSchedule()
        {
            // Arrange
            var startDate = new DateTime(2024, 1, 1);
            var employeeId = Guid.NewGuid();
            var employees = new List<Employee> { new Employee { ID = employeeId } };
            var existingShift = new Shift(Guid.NewGuid(), startDate, ShiftType.Morning, employeeId);

            mockAdministration.Setup(a => a.GetAvailableEmployees(It.IsAny<DateTime>(), It.IsAny<ShiftType>()))
                              .Returns(employees);
            mockAdministration.Setup(a => a.GetShiftsByDate(startDate))
                              .Returns(new List<Shift> { existingShift });

            // Act
            algorithm.GenerateSchedule(startDate);

            // Assert
            Assert.IsTrue(algorithm.shiftsAlreadyScheduled > 0);
        }

        [TestMethod]
        public void GenerateSchedule_InsufficientEmployeesForADay_ShouldReflectInDaysNotScheduled()
        {
            // Arrange
            var startDate = new DateTime(2024, 1, 1);
            var limitedEmployees = mockEmployees.Take(5).ToList(); 

            mockAdministration.Setup(a => a.GetAvailableEmployees(It.IsAny<DateTime>(), It.IsAny<ShiftType>()))
                              .Returns(limitedEmployees);

            // Act
            algorithm.GenerateSchedule(startDate);

            // Assert
            Assert.IsTrue(algorithm.daysNotScheduled.Count > 0, "There should be days with not enough employees scheduled.");
        }
}
