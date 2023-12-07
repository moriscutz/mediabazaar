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
                string query = "INSERT INTO dbo.Shift (Date, Type, EmployeeID) VALUES (@Date, @Type, @EmployeeID)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", shift.Date);
                    command.Parameters.AddWithValue("@Type", shift.Type.ToString());
                    command.Parameters.AddWithValue("@EmployeeID", shift.EmployeeID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
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
    }
}
