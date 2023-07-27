using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    #region VARIABLES

    [Header("Database Properties")]
    public string Host = "localhost";
    public string User = "root";
    public string Password = "root";
    public string Database = "users";

    private string connectionString;

    #endregion

    #region UNITY METHODS

    private void Start()
    {
        connectionString = GetConnectionString();
        Connect();
    }

    #endregion

    #region METHODS

    private string GetConnectionString()
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        builder.Server = Host;
        builder.UserID = User;
        builder.Password = Password;
        builder.Database = Database;

        return builder.ToString();
    }

    private void Connect()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Debug.Log("MySQL - Opened Connection");
            }
        }
        catch (MySqlException exception)
        {
            Debug.LogError(exception.Message);
        }
    }

    public void InsertData(string nickname, string password, string email)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            // Exclude the "id" column from the query since it's auto-incrementing
            string query = "INSERT INTO users (name, password, email) VALUES (@nickname, @password, @email)";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@nickname", nickname); // Update this line to use "@nickname"
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);

                try
                {
                    cmd.ExecuteNonQuery();
                    Debug.Log("Data inserted successfully!");
                }
                catch (MySqlException exception)
                {
                    Debug.LogError(exception.Message);
                }
            }
        }
    }


    // Update data in the table
    public void UpdateData(string name, string password, string email)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE users SET name = @name, password = @password, email = @email WHERE id = @id";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                // cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    cmd.ExecuteNonQuery();
                    Debug.Log("Data updated successfully!");
                }
                catch (MySqlException exception)
                {
                    Debug.LogError(exception.Message);
                }
            }
        }
    }

    // Query data from the table
    public void QueryData()
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM users";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //int id = reader.GetInt32("id");
                            string name = reader.GetString("name");
                            string password = reader.GetString("password");
                            string email = reader.GetString("email");

                            Debug.Log($"Name: {name}, Password: {password}, Email: {email}");
                        }
                    }
                }
                catch (MySqlException exception)
                {
                    Debug.LogError(exception.Message);
                }
            }
        }
    }

    // public void Login(string email, string password, System.Action<bool> onLoginComplete)
    // {
    //     using (MySqlConnection connection = new MySqlConnection(connectionString))
    //     {
    //         connection.Open();

    //         string query = "SELECT COUNT(*) FROM users WHERE email = @email AND password = @password";

    //         using (MySqlCommand cmd = new MySqlCommand(query, connection))
    //         {
    //             cmd.Parameters.AddWithValue("@email", email);
    //             cmd.Parameters.AddWithValue("@password", password);

    //             try
    //             {
    //                 int count = Convert.ToInt32(cmd.ExecuteScalar());
    //                 bool loginSuccessful = count > 0;
    //                 onLoginComplete?.Invoke(loginSuccessful);
    //             }
    //             catch (MySqlException exception)
    //             {
    //                 Debug.LogError(exception.Message);
    //                 onLoginComplete?.Invoke(false);
    //             }
    //         }
    //     }
    // }

    #endregion
}
