using BusinessLogic.Classes;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly string connectionString = ConnectionManager.GetConnectionString();
        public void AddShift(Shift shift)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                
                string query = "INSERT INTO dbo.Shift (ShiftId, Date, Type, EmployeeID) VALUES (@ShiftId, @Date, @Type, @EmployeeID)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ShiftId", Guid.NewGuid());
                    command.Parameters.AddWithValue("@Date", shift.Date);
                    command.Parameters.AddWithValue("@Type", shift.Type.ToString());
                    command.Parameters.AddWithValue("@EmployeeID", shift.EmployeeID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public int CountShiftsOnDateAndType(DateTime date, ShiftType shiftType)
        {
            int count = 0;
            using (var connection = new SqlConnection(connectionString)) 
            {
                string query = "SELECT COUNT(*) FROM Shift WHERE Date = @Date AND Type = @Type";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", date.Date);
                    command.Parameters.AddWithValue("@Type", shiftType.ToString());

                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
            }
            return count;
        }

        public void UpdateShift(Shift shift)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE dbo.Shift SET Date = @Date, Type = @Type, EmployeeID = @EmployeeID WHERE ShiftId = @ShiftId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ShiftId", shift.ShiftId);
                    command.Parameters.AddWithValue("@Date", shift.Date);
                    command.Parameters.AddWithValue("@Type", shift.Type.ToString());
                    command.Parameters.AddWithValue("@EmployeeID", shift.EmployeeID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteShift(Shift shift)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM dbo.Shift WHERE ShiftId = @ShiftId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ShiftId", shift.ShiftId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Shift GetShiftById(Guid shiftId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM dbo.Shift WHERE ShiftId = @ShiftId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ShiftId", shiftId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            shiftId = (Guid)reader["ShiftId"];
                            DateTime date = (DateTime)reader["Date"];
                            ShiftType shiftType = (ShiftType)Enum.Parse(typeof(ShiftType), reader["Type"].ToString());
                            Guid employeeId = (Guid)reader["EmployeeID"];
                            var shift = new Shift(shiftId, date, shiftType, employeeId);

                            return shift;
                        }
                    }
                }
            }
            return null;
        }

        public List<Shift> GetAllShifts()
        {
            var shifts = new List<Shift>();
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ShiftId, Date, Type, EmployeeID FROM dbo.Shift";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid shiftId = (Guid)reader["ShiftId"];
                            DateTime date = (DateTime)reader["Date"];
                            ShiftType shiftType = (ShiftType)Enum.Parse(typeof(ShiftType), reader["Type"].ToString());
                            Guid employeeId = (Guid)reader["EmployeeID"];
                            var shift = new Shift(shiftId, date, shiftType, employeeId);
                            
                            shifts.Add(shift);
                        }
                    }
                }
            }
            return shifts;
        }

        public List<Shift> GetShiftsForEmployeeById(Guid employeeId)
        {
            var shifts = new List<Shift>();
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ShiftId, Date, Type FROM dbo.Shift WHERE EmployeeID = @EmployeeID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid shiftId = (Guid)reader["ShiftId"];
                            DateTime date = (DateTime)reader["Date"];
                            ShiftType shiftType = (ShiftType)Enum.Parse(typeof(ShiftType), reader["Type"].ToString());
                            var shift = new Shift(shiftId, date, shiftType, employeeId);

                            shifts.Add(shift);
                        }
                    }
                }
            }
            return shifts;
        }
        public void DeleteAllShifts()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "delete from Shift";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public Shift GetShiftByDateAndType(DateTime date, ShiftType shiftType)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT ShiftId, Date, Type, EmployeeID 
            FROM dbo.Shift 
            WHERE Date = @Date AND Type = @Type";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", date.Date);
                    command.Parameters.AddWithValue("@Type", shiftType.ToString());

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Guid shiftId = (Guid)reader["ShiftId"];
                            DateTime shiftDate = (DateTime)reader["Date"];
                            ShiftType foundShiftType = (ShiftType)Enum.Parse(typeof(ShiftType), reader["Type"].ToString());
                            Guid employeeId = (Guid)reader["EmployeeID"];

                            return new Shift(shiftId, shiftDate, foundShiftType, employeeId);
                        }
                    }
                }
            }
            return null;
        }
        public List<Shift> GetShiftsByDateAndType(DateTime date, ShiftType shiftType)
        {
            var shifts = new List<Shift>();
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT ShiftId, Date, Type, EmployeeID 
            FROM dbo.Shift 
            WHERE Date = @Date AND Type = @Type";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", date.Date);
                    command.Parameters.AddWithValue("@Type", shiftType.ToString());

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid shiftId = (Guid)reader["ShiftId"];
                            DateTime shiftDate = (DateTime)reader["Date"];
                            ShiftType foundShiftType = (ShiftType)Enum.Parse(typeof(ShiftType), reader["Type"].ToString());
                            Guid employeeId = (Guid)reader["EmployeeID"];

                            shifts.Add(new Shift(shiftId, shiftDate, foundShiftType, employeeId));
                        }
                    }
                }
            }
            return shifts;
        }
        public List<Shift> GetShiftsByDate(DateTime date)
        {
            var shifts = new List<Shift>();
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT ShiftId, Date, Type, EmployeeID 
                FROM dbo.Shift 
                WHERE Date = @Date";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", date.Date);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Guid shiftId = (Guid)reader["ShiftId"];
                            DateTime shiftDate = (DateTime)reader["Date"];
                            ShiftType foundShiftType = (ShiftType)Enum.Parse(typeof(ShiftType), reader["Type"].ToString());
                            Guid employeeId = (Guid)reader["EmployeeID"];

                            shifts.Add(new Shift(shiftId, shiftDate, foundShiftType, employeeId));
                        }
                    }
                }
            }
            return shifts;
        }
    }
}
