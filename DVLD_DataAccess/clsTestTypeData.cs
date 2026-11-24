using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestTypeData
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM TestTypes";

            SqlCommand command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
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
                Connection.Close();
            }
            return dt;
        }
        public static bool GetTestTypeByID(int TestTypeID, ref string Titel, ref string Description, ref float Fees)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @" SELECT * FROM TestTypes 
                            WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    Titel = (string)reader["TestTypeTitle"];
                    Description = (string)reader["TestTypeDescription"];
                    Fees = Convert.ToSingle(reader["TestTypeFees"]);
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
        public static int AddNewTestType ( string Titel, string Description, float Fees)
        {
            int AppTypeID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO [dbo].[TestTypes]
                                   ([TestTypeTitle]
                                   ,[TestTypeDescription]
                                   ,[TestTypeFees])
                             VALUES
                                   (@TestTypeTitle
                                   ,@TestTypeDescription
                                   ,@TestTypeFees)

                            SELECT SCOPE_IDENTITY() ";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@TestTypeTitle", Titel);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@TestTypeFees", Fees);
            try
            {
                Connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    AppTypeID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return AppTypeID;
        }
        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            int RowEffectived = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @" UPDATE [dbo].[TestTypes]
                       SET [TestTypeTitle] = @TestTypeTitle
                          ,[TestTypeDescription] = @TestTypeDescription
                          ,[TestTypeFees] = @TestTypeFees
                       WHERE  TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            Command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            Command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            try
            {
                Connection.Open();
                RowEffectived = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }
            return RowEffectived > 0;
        }
        public static bool IsTestTypeIDExist(int ID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT FOUND = 1 from TestTypes
                                where TestTypes.TestTypeID = @ID";


            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue(@"ID", ID);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;
                Connection.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }
            return IsFound;
        }
        public static bool DeleteTestType(int ID)
        {
            int RowEffectived = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM [dbo].[TestTypes]
                            WHERE TestTypeID = @ID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", ID);

            try
            {
                Connection.Open();
                RowEffectived = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }
            return RowEffectived > 0;
        }
    }
}

    

