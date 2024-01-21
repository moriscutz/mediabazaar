using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BusinessLogic.Enums;

namespace DataAccess
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private readonly string connectionString = ConnectionManager.GetConnectionString();

        public void AddAvailabilitiesToEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        string query = "INSERT INTO dbo.Availability (EmployeeID, DayOfWeek, ShiftTime, IsAvailable) VALUES (@EmployeeID, @DayOfWeek, @ShiftTime, @IsAvailable)";
                        foreach (var availability in employee.Availabilities)
                        {
                            using (var command = new SqlCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@EmployeeID", employee.ID);
                                command.Parameters.AddWithValue("@DayOfWeek", (int)availability.DayOfWeek);
                                command.Parameters.AddWithValue("@ShiftTime", (int)availability.ShiftTime);
                                command.Parameters.AddWithValue("@IsAvailable", availability.IsAvailable);
                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("SQL Error in AddAvailabilitiesToEmployee: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in AddAvailabilitiesToEmployee: " + ex.Message);
                throw;
            }
        }

        public void UpdateAvailabilitiesForEmployeeById(Guid guid)
        {

        }

        public void UpdateAvailabilitiesForEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        string deleteQuery = "DELETE FROM dbo.Availability WHERE EmployeeID = @EmployeeID";
                        using (var deleteCommand = new SqlCommand(deleteQuery, connection, transaction))
                        {
                            deleteCommand.Parameters.AddWithValue("@EmployeeID", employee.ID);
                            deleteCommand.ExecuteNonQuery();
                        }

                        string insertQuery = "INSERT INTO dbo.Availability (EmployeeID, DayOfWeek, ShiftTime, IsAvailable) VALUES (@EmployeeID, @DayOfWeek, @ShiftTime, @IsAvailable)";
                        foreach (var availability in employee.Availabilities)
                        {
                            using (var insertCommand = new SqlCommand(insertQuery, connection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@EmployeeID", employee.ID);
                                insertCommand.Parameters.AddWithValue("@DayOfWeek", (int)availability.DayOfWeek);
                                insertCommand.Parameters.AddWithValue("@ShiftTime", (int)availability.ShiftTime);
                                insertCommand.Parameters.AddWithValue("@IsAvailable", availability.IsAvailable);
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("SQL Error in UpdateAvailabilitiesForEmployee: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in UpdateAvailabilitiesForEmployee: " + ex.Message);
                throw;
            }
        }

        public List<Availability> GetAvailabilitiesByEmployeeId(Guid id)
        {
            try
            {
                List<Availability> availabilities = new List<Availability>();
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT EmployeeID, DayOfWeek, ShiftTime, IsAvailable FROM dbo.Availability WHERE EmployeeID = @EmployeeID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", id);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var availability = new Availability
                                {
                                    EmployeeID = (Guid)reader["EmployeeID"],
                                    DayOfWeek = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), reader["DayOfWeek"].ToString()),
                                    ShiftTime = (ShiftType)Enum.Parse(typeof(ShiftType), reader["ShiftTime"].ToString()),
                                    IsAvailable = (bool)reader["IsAvailable"]
                                };
                                availabilities.Add(availability);
                            }
                        }
                    }
                }
                return availabilities;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("SQL Error in GetAvailabilitiesByEmployeeId: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetAvailabilitiesByEmployeeId: " + ex.Message);
                throw;
            }
        }

        public List<Employee> GetAvailableEmployeesByDayAndShift(int dayOfWeek, ShiftType shiftType)
        {
            try
            {
                List<Employee> availableEmployees = new List<Employee>();
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT e.* FROM Employee e JOIN Availability a ON e.ID = a.EmployeeID WHERE a.DayOfWeek = @DayOfWeek AND a.IsAvailable = 1";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DayOfWeek", dayOfWeek);
                        command.Parameters.AddWithValue("@ShiftTime", (int)shiftType);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var employee = new Employee
                                {
                                    ID = (Guid)reader["ID"],
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    JobPosition = (Position)Enum.Parse(typeof(Position), reader["JobPosition"].ToString()),
                                    Password = reader["Password"].ToString(),
                                    Username = reader["Username"].ToString()
                                };
                                employee.Shifts = new List<Shift>();
                                employee.Availabilities = GetAvailabilitiesByEmployeeId(employee.ID);
                                availableEmployees.Add(employee);
                            }
                        }
                    }
                }
                return availableEmployees;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("SQL Error in GetAvailableEmployeesByDayAndShift: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetAvailableEmployeesByDayAndShift: " + ex.Message);
                throw;
            }
        }

        public List<Employee> GetAvailableEmployeesByDay(int dayOfWeek)
        {
            try
            {
                var availableEmployees = new List<Employee>();
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT e.* FROM Employee e INNER JOIN Availability a ON e.ID = a.EmployeeID WHERE a.DayOfWeek = @DayOfWeek AND a.IsAvailable = 1";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DayOfWeek", dayOfWeek);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var employee = new Employee
                                {
                                    ID = (Guid)reader["ID"],
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    JobPosition = (Position)Enum.Parse(typeof(Position), reader["JobPosition"].ToString()),
                                    Password = reader["Password"].ToString(),
                                    Username = reader["Username"].ToString()
                                };
                                availableEmployees.Add(employee);
                            }
                        }
                    }
                }
                return availableEmployees;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine("SQL Error in GetAvailableEmployeesByDay: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetAvailableEmployeesByDay: " + ex.Message);
                throw;
            }
        }
    }
}
