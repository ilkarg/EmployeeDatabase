using System.Collections.Generic;

namespace WpfApp1
{
    public static class Data
    {
        public static string[] createTableQuery =
        {
            "CREATE TABLE IF NOT EXISTS Workers(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, full_name TEXT NOT NULL UNIQUE, birthday DATE NOT NULL, gender TEXT NOT NULL, job TEXT NOT NULL, chief_full_name TEXT NOT NULL, subdivision TEXT NOT NULL, FOREIGN KEY (job) REFERENCES Jobs(id))",
            "CREATE TABLE IF NOT EXISTS Jobs(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT NOT NULL UNIQUE)"
        };

        public static string[] usersTestData =
        {
            "INSERT INTO Workers (full_name, birthday, gender, job, chief_full_name, subdivision) VALUES ('Хребтов Илья Ярославович', '05.07.2002', 'Мужской', 1, '-', 'Омский Бекон')",
            "INSERT INTO Workers (full_name, birthday, gender, job, chief_full_name, subdivision) VALUES ('Пушкин Александр Сергеевич', '26.05.1799', 'Мужской', 2, '-', 'Слесари')",
            "INSERT INTO Workers (full_name, birthday, gender, job, chief_full_name, subdivision) VALUES ('Толстой Лев Николаевич', '09.09.1828', 'Мужской', 3, 'Иванов Иван Иванович', '-')",
            "INSERT INTO Workers (full_name, birthday, gender, job, chief_full_name, subdivision) VALUES ('Тестовый Юзер 1', '29.05.2022', 'Бот', 4, 'Иванов Иван Иванович', '-')",
            "INSERT INTO Workers (full_name, birthday, gender, job, chief_full_name, subdivision) VALUES ('Тестовый Юзер 2', '29.05.2022', 'Бот', 4, 'Иванов Иван Иванович', '-')"
        };

        public static string[] jobsTestData =
        {
            "INSERT INTO Jobs (name) VALUES ('Директор')",
            "INSERT INTO Jobs (name) VALUES ('Руководитель подразделения')",
            "INSERT INTO Jobs (name) VALUES ('Контролер')",
            "INSERT INTO Jobs (name) VALUES ('Рабочий')"
        };

        public static string[] jobsList = 
        {
            "Директор", "Руководитель подразделения", "Контролер", "Рабочий"
        };

        public static List<UserCard> userCardList = new List<UserCard>();
        public static List<Worker> workerList = new List<Worker>();

        public static MainWindow? window { get; set; }

        public static string? filter = "";
        public static List<UserCard> filteredWorkerCardsList = new List<UserCard>();
    }
}
