using System;
using System.Data;
using System.Data.SqlClient;
namespace DVLD_DataAccess.Users
{
    public class clsUserData
    {

        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName, ref bool IsActive,ref string  PasswordHash)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT *
                             FROM Users
                             WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    IsActive = (bool)reader["IsActive"];
                    PasswordHash = reader["PasswordHash"] == DBNull.Value ? null : reader["PasswordHash"].ToString();
                }
                else
                {
                    IsFound = false;
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
        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName, ref bool IsActive, ref string PasswordHash)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT *
                             FROM Users
                             WHERE PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    IsActive = (bool)reader["IsActive"];
                    PasswordHash = reader["PasswordHash"] == DBNull.Value ? null : reader["PasswordHash"].ToString();
                }
                else
                {
                    IsFound = false;
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
        public static bool GetUserInfoByUserName(string UserName, ref int UserID, ref int PersonID , ref bool IsActive, ref string PasswordHash)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT *
                             FROM Users
                             WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                    PasswordHash = reader["PasswordHash"] == DBNull.Value ? null : reader["PasswordHash"].ToString();

                }
                else
                {
                    IsFound = false;
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
        public static int AddNewUser( int PersonID, string UserName, bool IsActive, string PasswordHash)
       {
            int UserID = -1 ;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string Query = @"INSERT INTO [dbo].[Users]
                           ([PersonID]
                           ,[UserName]
                           ,[IsActive]
                           ,[PasswordHash])

                     VALUES
                           (@PersonID
                           ,@UserName
                           ,@IsActive 
                           ,@PasswordHash);
                            SELECT SCOPE_IDENTITY() ";

       

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@PasswordHash", PasswordHash);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
                }
            }
            catch (Exception ex)
            {
                throw ;
            }
            finally
            {
                connection.Close();
            }
            return UserID;
        }
        public static bool UpdateUser (int UserID, int PersonID, string UserName, bool IsActive, string PasswordHash)
        {
            int RowsEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE [dbo].[Users]
                            SET [PersonID] = @PersonID
                               ,[UserName] = @UserName
                               ,[IsActive] = @IsActive
                               ,[PasswordHash] = @PasswordHash
                                 WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@PasswordHash", PasswordHash);

            try
            {
                connection.Open();
                RowsEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (RowsEffected > 0) ;       
        }
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Users.UserID
                                  ,Users.PersonID
                                 ,People.FirstName   +' '+
                                  People.SecondName  +' '+
                                  ISNULL(People.ThirdName ,''  )+' '+
                                  People.LastName  AS FullName
                                  ,Users.UserName
                                  ,Users.IsActive
                                 
                    FROM Users
                    INNER JOIN People
                        ON Users.PersonID = People.PersonID";

        
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader); 
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
            return dt;
        }   
        public static bool  DeleteUser (int UserID)
        {
            int RowsEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @" DELETE FROM [dbo].[Users]
                            WHERE UserID = @UserID ";

            SqlCommand command = new SqlCommand (Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                RowsEffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ;
            }
            finally
            {
                connection.Close();
            }
            return RowsEffected > 0;
        }
        public static string GetPasswordHashByUserName(string UserName)
        {
            string PasswordHash = null;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT PasswordHash FROM Users
                             WHERE UserName = @UserName  ";
            
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    PasswordHash = reader["PasswordHash"] == DBNull.Value ?
                        null : reader["PasswordHash"].ToString();
                }
               reader.Close (); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return PasswordHash;
        }
        public static bool IsUserExist(bool IsActive)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT Found=1
                             FROM Users
                             WHERE IsActive = @IsActive";
                            
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@IsActive", IsActive);

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
        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT Found=1
                             FROM Users
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
        public static bool ChangePassword(int UserID, string PasswordHash)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Users  
                           SET PasswordHash = @PasswordHash
                            where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            
            
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PasswordHash", PasswordHash);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }

            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
    }
    
}
