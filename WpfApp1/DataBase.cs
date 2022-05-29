using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Data.Sqlite;

namespace WpfApp1
{
    public class DataBase
    {
        public string connectionString { get; set; }

        public DataBase(string db)
        {
            if (db.EndsWith(".db") && db.Trim().Length > 0)
            {
                this.connectionString = $"Data Source = {db}";
            }
        }

        public bool CreateAllTables(string[] tables, bool fillData) 
        {
            if (tables.Length == 0) 
            {
                return false;
            }

            try 
            {
                foreach(var table in tables) 
                {
                    using (var connection = new SqliteConnection(this.connectionString))
                    {
                        connection.Open();
                        SqliteCommand command = new SqliteCommand();
                        command.Connection = connection;

                        foreach (var query in Data.createTableQuery)
                        {
                            command.CommandText = query;
                            command.ExecuteNonQuery();
                        }

                        if (fillData)
                        {
                            try
                            {
                                foreach (var job in Data.jobsTestData)
                                {
                                    command.CommandText = job;
                                    command.ExecuteNonQuery();
                                }
                            }
                            catch { }

                            try
                            {
                                foreach (var user in Data.usersTestData)
                                {
                                    command.CommandText = user;
                                    command.ExecuteNonQuery();
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
                return false;
            }

            return true;
        }

        public List<string>? GetAllDataFromTable(string tableName)
        {
            if (tableName.Trim().Length == 0) 
            {
                return null;
            }

            List<string> data = new List<string>();

            try
            {
                using (var connection = new SqliteConnection(this.connectionString))
                {
                    connection.Open();

                    SqliteCommand command = new SqliteCommand($"SELECT * FROM {tableName}", connection);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (tableName.Equals("Workers"))
                                {
                                    data.Add($"{reader["id"]} | {reader["full_name"]} | {reader["birthday"]} | {reader["gender"]}\n");
                                }
                                else if (tableName.Equals("Jobs")) 
                                {
                                    data.Add($"{reader["id"]} | {reader["name"]}\n");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return null;
            }

            return data;
        }

        public bool OutputAllDataFromTable(string tableName)
        {
            if (tableName.Trim().Length == 0) 
            {
                return false;
            }

            try
            {
                using (var connection = new SqliteConnection(this.connectionString))
                {
                    connection.Open();

                    SqliteCommand command = new SqliteCommand($"SELECT * FROM {tableName}", connection);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        string result = "";

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (tableName.Equals("Workers"))
                                {
                                    result += $"{reader["id"]} | {reader["full_name"]} | {reader["birthday"]} | {reader["gender"]}\n";
                                }
                                else if (tableName.Equals("Jobs"))
                                {
                                    result += $"{reader["id"]} | {reader["name"]}\n";
                                }
                            }

                            MessageBox.Show(result);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return false;
            }

            return true;
        }
    }
}