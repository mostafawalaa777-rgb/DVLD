using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;
using System.Reflection;
using System.Collections;

namespace DVLD_DataAccess
{
    public class clsTestsData
    {
        public static bool GetTestByTestID(int TestID, ref int TestAppointmentID,
            ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @" select * from Tests
                                where TestID  = @TestID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes = reader["Notes"] == DBNull.Value
                        ? string.Empty
                        : reader["Notes"].ToString();
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                {
                    IsFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool GetTestByTestAppointmentID(int TestAppointmentID, ref int TestID ,
            ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Tests
                 WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    TestID = (int)reader["TestID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes = Convert.ToString(reader["Notes"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                {
                    IsFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }


        public static bool GetTestByLocalDrivingLicenseApplicationIDAndTestTypeID(int LocalDrivingLicenseApplicationID, int TestTypeID,
                                ref int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT top 1
                                    T.TestID AS TestID,
                                    T.TestAppointmentID as TestAppointmentID,
                                    T.TestResult,
                                    T.Notes,
                                    T.CreatedByUserID

                            from Tests as T
	                        inner join TestAppointments as TA on T.TestAppointmentID = TA.TestAppointmentID
	                        where  TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
	                        and TA.TestTypeID = @TestTypeID
	                        order by TA.AppointmentDate desc, T.testID DESC ";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    TestID = (int)reader["TestID"];
                    TestResult = (bool)reader["TestResult"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    Notes = reader["Notes"] == DBNull.Value ? ""
                    : reader["Notes"].ToString();

                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                {
                    IsFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        public static DataTable GetAllTests(int TestID, int TestAppointmentID,
           bool TestResult, string Notes, int CreatedByUserID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * from Tests";
            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static int AddNewTest(int TestAppointmentID,
            bool TestResult, string Notes, int CreatedByUserID)
        { 
            int TestID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO [dbo].[Tests]
                               ([TestAppointmentID]
                               ,[TestResult]
                               ,[Notes]
                               ,[CreatedByUserID])
                         VALUES
                               (@TestAppointmentID
                               ,@TestResult
                               ,@Notes
                               ,@CreatedByUserID);

                                UPDATE TestAppointments
                                set IsLocked = 1
                                where TestAppointmentID  = @TestAppointmentID


                      SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();
                Object Results = command.ExecuteScalar();
                if (Results != null && int.TryParse(Results.ToString(), out int insertedID))
                {
                    TestID = insertedID;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }
            return TestID;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult,
            string Notes, int CreatedByUserID)
        {
            int RowsEffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @" UPDATE [dbo].[Tests]
                                SET [TestAppointmentID] = @TestAppointmentID 
                                    ,[TestResult] = @TestResult
                                    ,[Notes] = @Notes
                                    ,[CreatedByUserID] = @CreatedByUserID
                                WHERE  TestID = @TestID";


            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();
                RowsEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }
            return RowsEffected > 0;
        }

        public static bool DeleteTest(int TestID)
        {
            int RowsEffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Delete FROM Tests
                            WHERE  TestID = @TestID";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                Connection.Open();
                RowsEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }
            return RowsEffected > 0;
        }
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PassedTestCount = count(TestTypeID)
                         FROM Tests INNER JOIN
                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
						 where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestResult=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte ptCount))
                {
                    PassedTestCount = ptCount;
                }
            }

            catch (Exception ex)
            {
                throw;
            }

            finally
            {
                connection.Close();
            }

            return PassedTestCount;
        }
        public static byte GetFailedTestCount(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            byte FailedTestCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT COUNT(*)
                        FROM Tests
                        INNER JOIN TestAppointments
                            ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                        WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                          AND TestTypeID = @TestTypeID
                          AND TestResult = 0";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte ptCount))
                {
                    FailedTestCount = ptCount;
                }
            }

            catch (Exception ex)
            {
                throw;
            }

            finally
            {
                connection.Close();
            }

            return FailedTestCount;
        }
        public static bool GetLastTestResult( int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            SqlConnection Connection =
                new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query =@"SELECT TOP 1 Tests.TestResult
                            FROM Tests
                            INNER JOIN TestAppointments
                                ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                            WHERE TestAppointments.LocalDrivingLicenseApplicationID =
                                  @LocalDrivingLicenseApplicationID
                              AND TestAppointments.TestTypeID = @TestTypeID
 
                            ORDER BY Tests.TestID DESC";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                Connection.Open();
                object Result = command.ExecuteScalar();
                
                if (Result == null || Result == DBNull.Value)
                    return false;

                return Convert.ToBoolean(Result);
            }
            catch
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }
        }

        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass
           (int PersonID, int LicenseClassID, int TestTypeID, ref int TestID,
             ref int TestAppointmentID, ref bool TestResult,
             ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT  top 1 Tests.TestID, 
                Tests.TestAppointmentID, Tests.TestResult, 
			    Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                FROM            LocalDrivingLicenseApplications INNER JOIN
                                         Tests INNER JOIN
                                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                WHERE        (Applications.ApplicantPersonID = @PersonID) 
                        AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                        AND ( TestAppointments.TestTypeID=@TestTypeID)
                ORDER BY Tests.TestAppointmentID DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == DBNull.Value)

                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool DoesPassedTestType (int LocalDrivingLicenseApplicationID,  int TestTypeID)
        {
            bool IsPassed = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Tests.TestResult
                            FROM Tests
                            INNER JOIN TestAppointments
                                ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                            WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                              AND TestAppointments.TestTypeID = @TestTypeID
                              AND Tests.TestResult = 1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                IsPassed = reader.Read();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return IsPassed;
        }

    }
}

    
