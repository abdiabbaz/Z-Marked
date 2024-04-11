using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Z_Lib.Exceptions;
using Z_Marked.Model;
using Z_Marked.Services;

namespace Z_Lib.Services
{
    public class UserDB : IUserSource
    {
        private string ConnectionString = Secret.ConnectionString; 

        public void AddUser(User user)
        {
            string query = "insert into Z_User values (@pUsername, @pPassword, @pEmail, @pPhoneNumber)";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("Username", user.UserName);
                cmd.Parameters.AddWithValue("pPassword", user.Password);
                cmd.Parameters.AddWithValue("pEmail", user.Email);
                cmd.Parameters.AddWithValue("pPhoneNumber", user.PhoneNumber);
                int fieldsUpdated = cmd.ExecuteNonQuery();
                if (fieldsUpdated == 0)
                {
                    throw new DBException(user.UserName); 
                }
            }
            

        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            string query = "select * from Z_User"; 
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    users.Add(ReadUserFromDB(reader));

                }

            }
            return users;

        }

        private User ReadUserFromDB(SqlDataReader reader)
        {
            return new User(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(0));
        }

        public User GetUser(string username, string password)
        {
            User? user = null;
            string query = "select * from Z_User where UserName like @pName and Codeword like @pPassword";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@pName", username);
                cmd.Parameters.AddWithValue("@pPassword", password);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user = ReadUserFromDB(reader);
                }
            }
            if (user == null)
            {
                throw new UserNotFoundException(username, password);
            }
            return user; 
        }

        public User ReadUser(int userid)
        {
            User? user = null;
            string query = "select * from Z_User where ID = @pID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@pID", userid);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user = ReadUserFromDB(reader);
                }
            }
            if (user == null)
            {
                throw new UserNotFoundException(userid);
            }
            return user;
        }

        public User ReadUser(string username)
        {
            User? user = null;
            string query = "select * from Z_User where UserName like @pUsername";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue($"@pUsername", username);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user = ReadUserFromDB(reader);
                }
            }
            if (user == null)
            {
                throw new UserNotFoundException(username);
            }
            return user;
        }

        public void RemoveUser(User user)
        {
            string query = "delete from Z_User where UserName like @pUsername and Codeword like @pPassword";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue($"@pUsername", user.UserName);
                cmd.Parameters.AddWithValue($"@pPassword", user.Password);
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Rows affected: {rowsAffected}");
            }
        }

        public void UpdateUser(int id, User user)
        {
            string query = "update Z_User set UserName = @pUsername, " +
                "Codeword = @pPassword, " +
                "Email = @pEmail, " +
                "Phone = @pPhone" +
                "where ID = @pID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue($"@pUsername", user.UserName);
                cmd.Parameters.AddWithValue($"@pPassword", user.Password);
                cmd.Parameters.AddWithValue($"@pEmail", user.Email);
                cmd.Parameters.AddWithValue($"@pPhone", user.PhoneNumber);
                cmd.Parameters.AddWithValue($"@pID", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Rows affected: {rowsAffected}");
            }
            if (user == null)
            {
                throw new DBException(id);
            }
            
        }
    }
}
