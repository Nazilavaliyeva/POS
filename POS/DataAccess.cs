using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace POS
{
    public static class DataAccess
    {
        private static readonly string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pos_database.sqlite");
        private static readonly string connectionString = $"Data Source={dbFilePath};Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists(dbFilePath)) SQLiteConnection.CreateFile(dbFilePath);
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = @"
                CREATE TABLE IF NOT EXISTS Users (Username TEXT PRIMARY KEY, PasswordHash TEXT NOT NULL);
                CREATE TABLE IF NOT EXISTS Categories (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL UNIQUE);
                CREATE TABLE IF NOT EXISTS Products (Barcode TEXT PRIMARY KEY, Name TEXT NOT NULL, Description TEXT, Quantity INTEGER NOT NULL, MinStock INTEGER NOT NULL, Unit TEXT, PurchasePrice REAL NOT NULL, SalePrice REAL NOT NULL, ImagePath TEXT, CategoryId INTEGER, FOREIGN KEY (CategoryId) REFERENCES Categories (Id));
                CREATE TABLE IF NOT EXISTS Sales (SaleId INTEGER PRIMARY KEY AUTOINCREMENT, TransactionId TEXT NOT NULL, SaleDate TEXT NOT NULL, ProductBarcode TEXT NOT NULL, ProductName TEXT NOT NULL, QuantitySold INTEGER NOT NULL, SalePrice REAL NOT NULL);
                CREATE TABLE IF NOT EXISTS Returns (ReturnId INTEGER PRIMARY KEY AUTOINCREMENT, OriginalSaleId TEXT NOT NULL, ReturnDate TEXT NOT NULL, ProductBarcode TEXT NOT NULL, ProductName TEXT NOT NULL, QuantityReturned INTEGER NOT NULL);";
                using (var cmd = new SQLiteCommand(sql, cnn)) cmd.ExecuteNonQuery();
            }
        }

        // --- İstifadəçi Metodları ---
        public static bool UserExists(string username)
        {
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = "SELECT COUNT(1) FROM Users WHERE Username = @username";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public static void AddUser(User user)
        {
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = "INSERT INTO Users (Username, PasswordHash) VALUES (@username, @hash)";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@hash", user.PasswordHash);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static User GetUser(string username)
        {
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = "SELECT * FROM Users WHERE Username = @username";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User { Username = reader["Username"].ToString(), PasswordHash = reader["PasswordHash"].ToString() };
                        }
                    }
                }
            }
            return null;
        }

        // --- Kateqoriya Metodları ---
        public static List<Category> GetAllCategories()
        {
            var list = new List<Category>();
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = "SELECT Id, Name FROM Categories ORDER BY Name";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) list.Add(new Category { Id = Convert.ToInt32(reader["Id"]), Name = reader["Name"].ToString() });
                    }
                }
            }
            return list;
        }

        public static void AddCategory(string name)
        {
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = "INSERT INTO Categories (Name) VALUES (@name)";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCategory(int id, string newName)
        {
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = "UPDATE Categories SET Name = @name WHERE Id = @id";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@name", newName);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCategory(int id)
        {
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = "DELETE FROM Categories WHERE Id = @id";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool IsCategoryInUse(int categoryId)
        {
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = "SELECT COUNT(1) FROM Products WHERE CategoryId = @categoryId";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // --- Məhsul Metodları ---
        public static DataTable GetProductsForDisplay()
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT 
                    p.Barcode, 
                    p.Name AS Ad, 
                    p.Quantity AS Miqdar, 
                    p.SalePrice AS 'Satış Qiyməti', 
                    c.Name AS Kateqoriya, 
                    p.MinStock AS 'Min. Stok'
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryId = c.Id";

            using (var cnn = new SQLiteConnection(connectionString))
            {
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}