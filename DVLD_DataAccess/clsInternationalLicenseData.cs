
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsInternationalLicenseData
    {
        // Get International License Info By InternationalLicenseID
        public static bool GetInternationalLicenseInfoByID(
            int InternationalLicenseID,
            ref int ApplicationID,
            ref int DriverID,
            ref int IssuedUsingLocalLicenseID,
            ref DateTime IssueDate,
            ref DateTime ExpirationDate,
            ref bool IsActive,
            ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT *
                             FROM InternationalLicenses
                             WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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


        // Get International License Info By ApplicationID
        public static bool GetInternationalLicenseInfoByApplicationID(
            int ApplicationID,
            ref int InternationalLicenseID,
            ref int DriverID,
            ref int IssuedUsingLocalLicenseID,
            ref DateTime IssueDate,
            ref DateTime ExpirationDate,
            ref bool IsActive,
            ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT *
                             FROM InternationalLicenses
                             WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    DriverID = (int)reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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


        // Get International License Info By LocalLicenseID
        public static bool GetInternationalLicenseInfoByLocalLicenseID(
            int LocalLicenseID,
            ref int InternationalLicenseID,
            ref int ApplicationID,
            ref int DriverID,
            ref DateTime IssueDate,
            ref DateTime ExpirationDate,
            ref bool IsActive,
            ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT TOP 1 *
                             FROM InternationalLicenses
                             WHERE IssuedUsingLocalLicenseID = @LocalLicenseID
                             ORDER BY InternationalLicenseID DESC";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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


        // Add New International License
        public static int AddNewInternationalLicense(
            int ApplicationID,
            int DriverID,
            int IssuedUsingLocalLicenseID,
            DateTime IssueDate,
            DateTime ExpirationDate,
            bool IsActive,
            int CreatedByUserID)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"

                        Update  InternationalLicenses 
                        Set IsActive = 0
                        Where DriverID = @DriverID;


                INSERT INTO InternationalLicenses
                (
                    ApplicationID,
                    DriverID,
                    IssuedUsingLocalLicenseID,
                    IssueDate,
                    ExpirationDate,
                    IsActive,
                    CreatedByUserID
                )
                VALUES
                (
                    @ApplicationID,
                    @DriverID,
                    @IssuedUsingLocalLicenseID,
                    @IssueDate,
                    @ExpirationDate,
                    @IsActive,
                    @CreatedByUserID
                );

                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null &&
                    int.TryParse(result.ToString(), out int insertedID))
                {
                    InternationalLicenseID = insertedID;
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

            return InternationalLicenseID;
        }


        // Update International License
        public static bool UpdateInternationalLicense(
            int InternationalLicenseID,
            int ApplicationID,
            int DriverID,
            int IssuedUsingLocalLicenseID,
            DateTime IssueDate,
            DateTime ExpirationDate,
            bool IsActive,
            int CreatedByUserID)
        {
            int RowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                UPDATE InternationalLicenses
                SET
                    ApplicationID = @ApplicationID,
                    DriverID = @DriverID,
                    IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                    IssueDate = @IssueDate,
                    ExpirationDate = @ExpirationDate,
                    IsActive = @IsActive,
                    CreatedByUserID = @CreatedByUserID
                WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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


        // Get All International Licenses
        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                SELECT
                    InternationalLicenseID,
                    ApplicationID,
                    DriverID,
                    IssuedUsingLocalLicenseID AS LocalLicenseID,
                    IssueDate,
                    ExpirationDate,
                    IsActive,
                    CreatedByUserID
                FROM InternationalLicenses
                ORDER BY InternationalLicenseID";

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
        
        public static DataTable GetAllBaseInternationalLicensesByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT
                                InternationalLicenseID,
                                ApplicationID,
                                IssuedUsingLocalLicenseID ,
                                IssueDate,
                                ExpirationDate,
                                IsActive
                            FROM InternationalLicenses
                            INNER JOIN Drivers
                            ON InternationalLicenses.DriverID = Drivers.DriverID
                            WHERE Drivers.PersonID = @PersonID
                            AND InternationalLicenses.IsActive = 1

                            ORDER BY InternationalLicenses.InternationalLicenseID"
;
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
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

        // Delete International License
        public static bool DeleteInternationalLicense(int InternationalLicenseID)
        {
            int RowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                DELETE FROM InternationalLicenses
                WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

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


        // Check If International License Exists By ApplicationID
        public static bool IsInternationalLicenseExist(int ApplicationID)
        {
            bool IsFound = false;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                SELECT Found = 1
                FROM InternationalLicenses
                WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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
        public static int GetActiveInternationalLicenseByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                            SELECT TOP 1 InternationalLicenseID
                            FROM InternationalLicenses
                            WHERE DriverID = @DriverID
                            AND IsActive = 1
                            AND GETDATE() BETWEEN IssueDate AND ExpirationDate
                            ORDER BY ExpirationDate DESC;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && Result != DBNull.Value)
                {
                    InternationalLicenseID = Convert.ToInt32(Result);
                }
            }
            catch
            {
                InternationalLicenseID = -1;
            }
            finally
            {
                connection.Close();
            }

            return InternationalLicenseID;
        }

    }
}

