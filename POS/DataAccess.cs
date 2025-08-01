using System;
using System.Data.SQLite; // SQLite kitabxanasını əlavə edirik
using System.IO;

namespace POS
{
    public static class DataAccess
    {
        // Verilənlər bazası faylının adını və yolunu təyin edirik.
        private static readonly string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pos_database.sqlite");
        private static readonly string connectionString = $"Data Source={dbFilePath};Version=3;";

        // Bu metod proqram ilk dəfə işə düşəndə çağırılacaq.
        // Baza və cədvəllərin mövcud olub-olmadığını yoxlayıb, lazım gələrsə yaradacaq.
        public static void InitializeDatabase()
        {
            // Əgər baza faylı mövcud deyilsə, onu yaradırıq.
            if (!File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);
            }

            // Baza ilə əlaqə yaradırıq.
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Cədvəlləri yaratmaq üçün SQL əmrləri
                // Kateqoriyalar cədvəli
                string createCategoriesTable = @"
                CREATE TABLE IF NOT EXISTS Categories (
                    Id      INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name    TEXT NOT NULL UNIQUE
                );";

                // Məhsullar cədvəli
                string createProductsTable = @"
                CREATE TABLE IF NOT EXISTS Products (
                    Barcode         TEXT PRIMARY KEY,
                    Name            TEXT NOT NULL,
                    Description     TEXT,
                    Quantity        INTEGER NOT NULL,
                    MinStock        INTEGER NOT NULL,
                    Unit            TEXT,
                    ProductionDate  TEXT,
                    PurchasePrice   REAL NOT NULL,
                    SalePrice       REAL NOT NULL,
                    ImagePath       TEXT,
                    CategoryId      INTEGER,
                    FOREIGN KEY (CategoryId) REFERENCES Categories (Id)
                );";

                // SQL əmrlərini icra edirik
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = createCategoriesTable;
                    command.ExecuteNonQuery();

                    command.CommandText = createProductsTable;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}