using System;
using System.Data.SqlClient;
using System.Data;


namespace DVLD_DataAccess
{
    public class clsDriverData
    {
        // Get Driver Info By DriverID
        public static bool GetDriverInfoByDriverID(
            int DriverID,
            ref int PersonID,
            ref int CreatedByUserID,
            ref DateTime CreatedDate)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT *
                             FROM Drivers
                             WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        // Get Driver Info By PersonID
        public static bool GetDriverInfoByPersonID(
            int PersonID,
            ref int DriverID,
            ref int CreatedByUserID,
            ref DateTime CreatedDate)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT *
                             FROM Drivers
                             WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        // Add New Driver
        public static int AddNewDriver(
            int PersonID,
            int CreatedByUserID,
            DateTime CreatedDate)
        {
            int DriverID = -1;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                INSERT INTO Drivers
                (
                    PersonID,
                    CreatedByUserID,
                    CreatedDate
                )
                VALUES
                (
                    @PersonID,
                    @CreatedByUserID,
                    @CreatedDate
                );

                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null &&
                    int.TryParse(result.ToString(), out int insertedID))
                {
                    DriverID = insertedID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return DriverID;
        }

        // Update Driver
        public static bool UpdateDriver(
            int DriverID,
            int PersonID,
            int CreatedByUserID,
            DateTime CreatedDate)
        {
            int RowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                UPDATE Drivers
                SET
                    PersonID = @PersonID,
                    CreatedByUserID = @CreatedByUserID,
                    CreatedDate = @CreatedDate
                WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;
        }

        // Get All Drivers
        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select * from Drivers_View

                        ORDER BY DriverID";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);
                
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        // Delete Driver
        public static bool DeleteDriver(int DriverID)
        {
            int RowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                DELETE FROM Drivers
                WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;
        }

        // Check If Driver Exists By PersonID
        public static bool IsDriverExist(int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                SELECT Found = 1
                FROM Drivers
                WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }
    }
}

    
