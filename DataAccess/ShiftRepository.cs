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
        public List<Preference> GetPreferencesByEmployeeId(Guid employeeId)
        {
            var preferences = new List<Preference>();
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Preferences WHERE EmployeeId = @EmployeeId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var preference = new Preference
                            {
                                PreferenceId = (Guid)reader["PreferenceId"],
                                DayOfWeek = (int)reader["DayOfWeek"],
                                ShiftType = (ShiftType)(int)reader["ShiftType"],
                                EmployeeId = (Guid)reader["EmployeeId"]
                            };
                            preferences.Add(preference);
                        }
                    }
                }
            }
            return preferences;
        }

        public List<Preference> GetPreferencesByDayOfWeek(int dayOfWeek)
        {
            var preferences = new List<Preference>();
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Preferences WHERE DayOfWeek = @DayOfWeek";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DayOfWeek", dayOfWeek);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var preference = new Preference
                            {
                                PreferenceId = (Guid)reader["PreferenceId"],
                                DayOfWeek = (int)reader["DayOfWeek"],
                                ShiftType = (ShiftType)(int)reader["ShiftType"],
                                EmployeeId = (Guid)reader["EmployeeId"]
                            };
                            preferences.Add(preference);
                        }
                    }
                }
            }
            return preferences;
        }

        public void UpdatePreference(Preference preference)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE dbo.Preferences SET ShiftType = @ShiftType WHERE PreferenceId = @PreferenceId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ShiftType", (int)preference.ShiftType);
                    command.Parameters.AddWithValue("@PreferenceId", preference.PreferenceId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddPreference(Preference preference)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO dbo.Preferences (PreferenceId, DayOfWeek, ShiftType, EmployeeId) " +
                               "VALUES (@PreferenceId, @DayOfWeek, @ShiftType, @EmployeeId)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PreferenceId", preference.PreferenceId);
                    command.Parameters.AddWithValue("@DayOfWeek", preference.DayOfWeek);
                    command.Parameters.AddWithValue("@ShiftType", (int)preference.ShiftType);
                    command.Parameters.AddWithValue("@EmployeeId", preference.EmployeeId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
