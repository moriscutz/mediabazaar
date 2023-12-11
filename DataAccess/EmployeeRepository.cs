using BusinessLogic.Classes;
using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessLogic.Interfaces;

namespace DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string connectionString = ConnectionManager.GetConnectionString();

        public void AddEmployee(Employee employee)
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

        public void UpdateEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE dbo.Employee SET FirstName = @FirstName, LastName = @LastName, JobPosition = @JobPosition, Password = @Password WHERE ID = @ID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", employee.ID);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@JobPosition", employee.JobPosition.ToString());
                    command.Parameters.AddWithValue("@Password", employee.Password);
                    

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM dbo.Employee WHERE ID = @ID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", employee.ID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Employee GetEmployeeById(Guid id)
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

                            return employee;
                        }
                    }
                }
            }
            return null;
        }

        public List<Employee> GetAllEmployees()
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

        public Employee Authenticate(string username, string password)
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
    }
}
