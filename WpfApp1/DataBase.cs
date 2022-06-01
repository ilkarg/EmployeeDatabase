using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Data.Sqlite;

namespace WpfApp1
{
    public class DataBase
    {
        public string? connectionString { get; set; }

        public DataBase(string db)
        {
            if (db.EndsWith(".db") && db.Trim().Length > 0)
            {
                this.connectionString = $"Data Source = {db}";
            }
        }

        public bool DeleteWorker(Worker worker) 
        {
            try
            {
                string sqlExpression = $"DELETE FROM Workers WHERE id={worker.WorkerId}";

                using (var connection = new SqliteConnection(this.connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception error) 
            {
                MessageBox.Show(error.Message, "Ошибка");
                return false;
            }

            return true;
        }

        public bool AddUser(Worker worker) 
        {
            try 
            {
                string sqlExpression = $"INSERT INTO Workers (full_name, birthday, gender, job, chief_full_name, subdivision) VALUES ('{worker.Fullname}', '{worker.Birthday}', '{worker.Gender}', {Array.IndexOf(Data.jobsList, worker.Job) + 1}, '{worker.ChiefFullName}', '{worker.Subdivision}')";

                using (var connection = new SqliteConnection(this.connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception error) 
            {
                MessageBox.Show(error.Message, "Ошибка");
                return false;
            }

            return true;
        }

        public bool UpdateWorker(Worker worker) 
        {
            try 
            {
                string sqlExpression = $"UPDATE Workers SET Job={Array.IndexOf(Data.jobsList, worker.Job) + 1} WHERE id={worker.WorkerId}";

                using (var connection = new SqliteConnection(this.connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception error) 
            {
                MessageBox.Show(error.Message, "Ошибка");
                return false;
            }

            return true;
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
                                    Data.workerList.Add(new Worker()
                                    {
                                        WorkerId = reader.GetInt32(0),
                                        Fullname = reader.GetString(1),
                                        Birthday = reader.GetString(2),
                                        Gender = reader.GetString(3),
                                        Job = Data.jobsList[int.Parse(reader.GetString(4)) - 1],
                                        ChiefFullName = reader.GetString(5),
                                        Subdivision = reader.GetString(6)
                                    });
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
                MessageBox.Show(error.Message, "Ошибка");
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
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка");
                return false;
            }

            return true;
        }
    }
}