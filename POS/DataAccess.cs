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
                CREATE TABLE IF NOT EXISTS Products (Barcode TEXT PRIMARY KEY, Name TEXT NOT NULL, Description TEXT, Quantity INTEGER NOT NULL, MinStock INTEGER NOT NULL, Unit TEXT, PurchasePrice REAL NOT NULL, SalePrice REAL NOT NULL, ImagePath TEXT, CategoryId INTEGER, FOREIGN KEY (CategoryId) REFERENCES Categories (Id) ON DELETE SET NULL);
                CREATE TABLE IF NOT EXISTS Sales (SaleId INTEGER PRIMARY KEY AUTOINCREMENT, TransactionId TEXT NOT NULL, SaleDate TEXT NOT NULL, ProductBarcode TEXT NOT NULL, ProductName TEXT NOT NULL, QuantitySold INTEGER NOT NULL, SalePrice REAL NOT NULL);
                CREATE TABLE IF NOT EXISTS Returns (ReturnId INTEGER PRIMARY KEY AUTOINCREMENT, OriginalTransactionId TEXT NOT NULL, ReturnDate TEXT NOT NULL, ProductBarcode TEXT NOT NULL, ProductName TEXT NOT NULL, QuantityReturned INTEGER NOT NULL);";
                using (var cmd = new SQLiteCommand(sql, cnn)) cmd.ExecuteNonQuery();
            }
        }

        #region User Methods
        public static bool UserExists(string username)
        {
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = "SELECT COUNT(1) FROM Users WHERE Username = @username COLLATE NOCASE";
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
            User user = null;
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = "SELECT * FROM Users WHERE Username = @username COLLATE NOCASE";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User { Username = reader["Username"].ToString(), PasswordHash = reader["PasswordHash"].ToString() };
                        }
                    }
                }
            }
            return user;
        }
        #endregion

        #region Category Methods
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
        #endregion

        #region Product Methods
        public static DataTable GetProductsForDisplay()
        {
            DataTable dt = new DataTable();
            string sql = @"
                SELECT p.Barcode, p.Name AS Ad, p.Quantity AS Miqdar, 
                       p.SalePrice AS 'Satış Qiyməti', c.Name AS Kateqoriya, p.MinStock
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryId = c.Id";
            using (var cnn = new SQLiteConnection(connectionString))
            {
                using (var adapter = new SQLiteDataAdapter(sql, cnn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public static Product GetProductByBarcode(string barcode)
        {
            Product product = null;
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = "SELECT * FROM Products WHERE Barcode = @barcode";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@barcode", barcode);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                Barcode = reader["Barcode"].ToString(),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                MinStock = Convert.ToInt32(reader["MinStock"]),
                                Unit = reader["Unit"].ToString(),
                                PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"]),
                                SalePrice = Convert.ToDecimal(reader["SalePrice"]),
                                ImagePath = reader["ImagePath"].ToString(),
                                CategoryId = reader["CategoryId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["CategoryId"])
                            };
                        }
                    }
                }
            }
            return product;
        }
        public static void AddProduct(Product product)
        {
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = @"INSERT INTO Products (Barcode, Name, Description, Quantity, MinStock, Unit, PurchasePrice, SalePrice, ImagePath, CategoryId) 
                               VALUES (@Barcode, @Name, @Description, @Quantity, @MinStock, @Unit, @PurchasePrice, @SalePrice, @ImagePath, @CategoryId)";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@Barcode", product.Barcode);
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@MinStock", product.MinStock);
                    cmd.Parameters.AddWithValue("@Unit", product.Unit);
                    cmd.Parameters.AddWithValue("@PurchasePrice", product.PurchasePrice);
                    cmd.Parameters.AddWithValue("@SalePrice", product.SalePrice);
                    cmd.Parameters.AddWithValue("@ImagePath", product.ImagePath);
                    cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateProduct(Product product, string originalBarcode)
        {
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = @"UPDATE Products SET 
                               Barcode = @Barcode, Name = @Name, Description = @Description, Quantity = @Quantity, 
                               MinStock = @MinStock, Unit = @Unit, PurchasePrice = @PurchasePrice, 
                               SalePrice = @SalePrice, ImagePath = @ImagePath, CategoryId = @CategoryId 
                               WHERE Barcode = @OriginalBarcode";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@Barcode", product.Barcode);
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@MinStock", product.MinStock);
                    cmd.Parameters.AddWithValue("@Unit", product.Unit);
                    cmd.Parameters.AddWithValue("@PurchasePrice", product.PurchasePrice);
                    cmd.Parameters.AddWithValue("@SalePrice", product.SalePrice);
                    cmd.Parameters.AddWithValue("@ImagePath", product.ImagePath);
                    cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    cmd.Parameters.AddWithValue("@OriginalBarcode", originalBarcode);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteProduct(string barcode)
        {
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                string sql = "DELETE FROM Products WHERE Barcode = @barcode";
                using (var cmd = new SQLiteCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@barcode", barcode);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Sale and Return Methods
        public static void ProcessSale(DataTable basket, string transactionId)
        {
            using (var cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                using (var transaction = cnn.BeginTransaction())
                {
                    try
                    {
                        foreach (DataRow row in basket.Rows)
                        {
                            string barcode = row["Barkod"].ToString();
                            int quantitySold = Convert.ToInt32(row["Miqdar"]);

                            string insertSaleSql = "INSERT INTO Sales (TransactionId, SaleDate, ProductBarcode, ProductName, QuantitySold, SalePrice) VALUES (@tid, @date, @barcode, @name, @qty, @price)";
                            using (var cmd = new SQLiteCommand(insertSaleSql, cnn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@tid", transactionId);
                                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("o"));
                                cmd.Parameters.AddWithValue("@barcode", barcode);
                                cmd.Parameters.AddWithValue("@name", row["Ad"].ToString());
                                cmd.Parameters.AddWithValue("@qty", quantitySold);
                                cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(row["Qiymət"]));
                                cmd.ExecuteNonQuery();
                            }

                            string updateStockSql = "UPDATE Products SET Quantity = Quantity - @qty WHERE Barcode = @barcode";
                            using (var cmd = new SQLiteCommand(updateStockSql, cnn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@qty", quantitySold);
                                cmd.Parameters.AddWithValue("@barcode", barcode);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        #endregion
    }
}