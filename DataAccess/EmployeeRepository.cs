using BusinessLogic.Classes;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string connectionString = ConnectionManager.GetConnectionString();

        public void AddEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO dbo.Employee (ID, FirstName, LastName, JobPosition, Password, Username) VALUES (@ID, @FirstName, @LastName, @JobPosition, @Password, @Username)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", employee.ID);
                        command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        command.Parameters.AddWithValue("@LastName", employee.LastName);
                        command.Parameters.AddWithValue("@JobPosition", employee.JobPosition.ToString());
                        command.Parameters.AddWithValue("@Password", employee.Password);
                        command.Parameters.AddWithValue("@Username", employee.Username);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in AddEmployee: " + ex.Message);
                throw;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE dbo.Employee SET FirstName = @FirstName, LastName = @LastName, JobPosition = @JobPosition, Password = @Password, Username = @Username WHERE ID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", employee.ID);
                        command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        command.Parameters.AddWithValue("@LastName", employee.LastName);
                        command.Parameters.AddWithValue("@JobPosition", employee.JobPosition.ToString());
                        command.Parameters.AddWithValue("@Password", employee.Password);
                        command.Parameters.AddWithValue("@Username", employee.Username);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in UpdateEmployee: " + ex.Message);
                throw;
            }
        }

        public void DeleteEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        string deleteAvailabilityQuery = "DELETE FROM dbo.Availability WHERE EmployeeId = @EmployeeId";
                        using (var deleteAvailabilityCommand = new SqlCommand(deleteAvailabilityQuery, connection, transaction))
                        {
                            deleteAvailabilityCommand.Parameters.AddWithValue("@EmployeeId", employee.ID);
                            deleteAvailabilityCommand.ExecuteNonQuery();
                        }

                        string deleteEmployeeQuery = "DELETE FROM dbo.Employee WHERE ID = @ID";
                        using (var deleteEmployeeCommand = new SqlCommand(deleteEmployeeQuery, connection, transaction))
                        {
                            deleteEmployeeCommand.Parameters.AddWithValue("@ID", employee.ID);
                            deleteEmployeeCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in DeleteEmployee: " + ex.Message);
                throw;
            }
        }

        public Employee GetEmployeeById(Guid id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM dbo.Employee WHERE ID = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Employee
                                {
                                    ID = (Guid)reader["ID"],
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    JobPosition = (Position)Enum.Parse(typeof(Position), reader["JobPosition"].ToString()),
                                    Password = reader["Password"].ToString(),
                                    Username = reader["Username"].ToString()
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in GetEmployeeById: " + ex.Message);
                throw;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                var employees = new List<Employee>();
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM dbo.Employee";
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(new Employee
                                {
                                    ID = (Guid)reader["ID"],
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    JobPosition = (Position)Enum.Parse(typeof(Position), reader["JobPosition"].ToString()),
                                    Password = reader["Password"].ToString(),
                                    Username = reader["Username"].ToString()
                                });
                            }
                        }
                    }
                }
                return employees;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in GetAllEmployees: " + ex.Message);
                throw;
            }
        }

        public Employee Authenticate(string username, string password)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM dbo.Employee WHERE Username = @Username AND Password = @Password";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Employee
                                {
                                    ID = (Guid)reader["ID"],
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    JobPosition = (Position)Enum.Parse(typeof(Position), reader["JobPosition"].ToString()),
                                    Password = reader["Password"].ToString(),
                                    Username = reader["Username"].ToString()
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in Authenticate: " + ex.Message);
                throw;
            }
        }

        public Employee GetEmployeeByUsername(string username)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM dbo.Employee WHERE Username = @Username";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Employee
                                {
                                    ID = (Guid)reader["ID"],
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    JobPosition = (Position)Enum.Parse(typeof(Position), reader["JobPosition"].ToString()),
                                    Password = reader["Password"].ToString(),
                                    Username = reader["Username"].ToString()
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in GetEmployeeByUsername: " + ex.Message);
                throw;
            }
        }
    }
}
