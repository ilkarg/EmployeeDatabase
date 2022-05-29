using System.Collections.Generic;

namespace WpfApp1
{
    public static class Data
    {
        public static string[] createTableQuery =
        {
            "CREATE TABLE IF NOT EXISTS Workers(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, full_name TEXT NOT NULL UNIQUE, birthday DATE NOT NULL, gender TEXT NOT NULL)",
            /*"CREATE TABLE IF NOT EXISTS Workers(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, full_name TEXT NOT NULL UNIQUE, birthday DATE NOT NULL, gender TEXT NOT NULL, job TEXT NOT NULL, chief_full_name TEXT NOT NULL, subdivision TEXT NOT NULL)",*/
            "CREATE TABLE IF NOT EXISTS Jobs(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL UNIQUE)"
        };

        public static string[] usersTestData =
        {
            "INSERT INTO Workers (full_name, birthday, gender) VALUES ('Хребтов Илья Ярославович', '05.07.2002', 'Мужской')",
            "INSERT INTO Workers (full_name, birthday, gender) VALUES ('Пушкин Александр Сергеевич', '26.05.1799', 'Мужской')",
            "INSERT INTO Workers (full_name, birthday, gender) VALUES ('Толстой Лев Николаевич', '09.09.1828', 'Мужской')"
        };

        public static string[] jobsTestData =
        {
            "INSERT INTO Jobs (name) VALUES ('Директор')",
            "INSERT INTO Jobs (name) VALUES ('Руководитель подразделения')",
            "INSERT INTO Jobs (name) VALUES ('Контролер')",
            "INSERT INTO Jobs (name) VALUES ('Рабочий')"
        };

        public static List<UserCard> userCardList = new List<UserCard>();
        public static List<Worker> workerList = new List<Worker>();
    }
}
