namespace TestClasses
{
    [TestClass]
    public class ScheduleEmployeeAlgorithmTests
    {
        private Mock<IAdministration> mockAdministration;
        private ScheduleEmployeeAlgorithm algorithm;

        [TestInitialize]
        public void Setup()
        {

            mockAdministration = new Mock<IAdministration>();

            var mockEmployees = new List<Employee>
        {
            new Employee(Guid.Parse("B0E51A3C-C088-4B9D-81CC-4F7D75E2B38D"), "Bob", "Johnson", Position.Picker, "qwerty", "bobjohnson"),
            new Employee(Guid.Parse("5E70995E-9CA2-4442-BD9A-58EF74FF1934"), "John", "Doe", Position.Supervisor, "password123", "john.doe"),
            new Employee(Guid.Parse("3294AB82-F393-4E88-9F08-77AFA76B4F29"), "Supervisor", "Supervisor", Position.Supervisor, "supervisor", "supervisor"),
            new Employee(Guid.Parse("65D9A69F-7495-4171-BAAB-7B882B803C2A"), "Alice", "Smith", Position.Picker, "alicepassword", "alice.smith"),
            new Employee(Guid.Parse("819BE9E1-F8CF-4F94-9F71-9321D002342F"), "Chloe", "Adams", Position.Manager, "chloeadams", "chloe.adams")
        };

            mockAdministration.Setup(a => a.GetAvailableEmployees(It.IsAny<DateTime>(), It.IsAny<ShiftType>()))
                              .Returns(mockEmployees);

            mockAdministration.Setup(a => a.GetShiftsByDate(It.IsAny<DateTime>()))
                              .Returns(new List<Shift>());

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
        public void GenerateSchedule_WhenEmployeesAvailable_ShouldAssignShifts()
        {
            // Arrange
            var startDate = new DateTime(2024, 1, 1); 
            var expectedShiftCount = 21; 

            // Act
            var actualShiftCount = algorithm.GenerateSchedule(startDate);

            // Assert
            Assert.AreEqual(expectedShiftCount, actualShiftCount, "The number of shifts generated should match the expected count.");
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

        
    }
}
