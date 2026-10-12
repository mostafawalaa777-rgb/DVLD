using System;
using System.Data;
using System.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
namespace DVLD_DataAccess
{
    public class clsApplicationTypesData
    {
        public static bool GetAppTypeByID(int ID, ref string Titel, ref float Fees)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @" SELECT * FROM ApplicationTypes 
                            WHERE ApplicationTypeID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    Titel = (string)reader["ApplicationTypeTitle"];
                    Fees = Convert.ToSingle(reader["ApplicationFees"]);
                }
                else
                {
                    IsFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        public static int AddNewAppType( string Title, float Fees)
        {
            int AppTypeID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO [dbo].[ApplicationTypes]
                ([ApplicationTypeTitle] ,[ApplicationFees])
                    VALUES (@ApplicationTypeTitle,  @ApplicationFees
            SELECT SCOPE_IDENTITY() ";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue(@"Title", Title);
            command.Parameters.AddWithValue(@"Fees", Fees);

            try
            {
                Connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    AppTypeID = insertedID;
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
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM ApplicationTypes";

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
        public static bool UpdateApplicationType(int ID, string Title, float Fees)
        {
            int RowEffectived = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE [dbo].[ApplicationTypes]
                                SET [ApplicationTypeTitle] = @Title
                                   ,[ApplicationFees] = @Fees
                                    WHERE ApplicationTypeID = @ID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ID", ID);
            Command.Parameters.AddWithValue("@Title", Title);
            Command.Parameters.AddWithValue("@Fees", Fees);

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
        public static bool IsAppTypeIDExist(int  ID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT FOUND = 1 from ApplicationTypes
                                where ApplicationTypes.ApplicationTypeID = @ID";


            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue(@"ID", ID);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;
                Connection.Close();
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
        public static bool DeleteApplicationType(int ID)
        {
            int RowEffectived = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM [dbo].[ApplicationTypes]
                            WHERE ApplicationTypeID = @ID";

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


