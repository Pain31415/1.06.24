namespace _1._06._24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}


//CREATE TABLE Books (
//    BookId INT PRIMARY KEY IDENTITY,
//    Title NVARCHAR(100) NOT NULL,
//    Author NVARCHAR(100) NOT NULL,
//    Publisher NVARCHAR(100),
//    PageCount INT,
//    Genre NVARCHAR(50),
//    YearPublished INT,
//    CostPrice DECIMAL(10, 2),
//    SalePrice DECIMAL(10, 2),
//    IsContinuation BIT,
//    PreviousBookId INT,
//    FOREIGN KEY (PreviousBookId) REFERENCES Books(BookId)
//);

//CREATE TABLE Users (
//    UserId INT PRIMARY KEY IDENTITY,
//    Username NVARCHAR(50) NOT NULL,
//    Password NVARCHAR(50) NOT NULL,
//    IsAdmin BIT
//);

//CREATE TABLE Sales (
//    SaleId INT PRIMARY KEY IDENTITY,
//    BookId INT,
//    SaleDate DATETIME,
//    Quantity INT,
//    FOREIGN KEY (BookId) REFERENCES Books(BookId)
//);

//CREATE TABLE Reservations (
//    ReservationId INT PRIMARY KEY IDENTITY,
//    BookId INT,
//    UserId INT,
//    ReservationDate DATETIME,
//    FOREIGN KEY (BookId) REFERENCES Books(BookId),
//    FOREIGN KEY (UserId) REFERENCES Users(UserId)
//);


class BookstoreApp
{
    static string connectionString = "your_connection_string_here";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Вхід");
            Console.WriteLine("2. Вихід");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Login();
            }
            else if (choice == "2")
            {
                break;
            }
        }
    }

    static void Login()
    {
        Console.Write("Введіть логін: ");
        string username = Console.ReadLine();
        Console.Write("Введіть пароль: ");
        string password = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                bool isAdmin = (bool)reader["IsAdmin"];
                if (isAdmin)
                {
                    AdminMenu();
                }
                else
                {
                    UserMenu();
                }
            }
            else
            {
                Console.WriteLine("Невірний логін або пароль");
            }
        }
    }

    static void AdminMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Додати книгу");
            Console.WriteLine("2. Видалити книгу");
            Console.WriteLine("3. Редагувати параметри книги");
            Console.WriteLine("4. Продати книгу");
            Console.WriteLine("5. Списати книгу");
            Console.WriteLine("6. Додати книгу в акцію");
            Console.WriteLine("7. Відкласти книгу для покупця");
            Console.WriteLine("8. Вихід");
            string choice = Console.ReadLine();
            if (choice == "1") { AddBook(); }
            else if (choice == "2") { DeleteBook(); }
            else if (choice == "3") { EditBook(); }
            else if (choice == "4") { SellBook(); }
            else if (choice == "5") { WriteOffBook(); }
            else if (choice == "6") { AddBookToPromotion(); }
            else if (choice == "7") { ReserveBook(); }
            else if (choice == "8") { break; }
        }
    }

    static void UserMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Пошук книги");
            Console.WriteLine("2. Перегляд новинок");
            Console.WriteLine("3. Перегляд найпопулярніших книг");
            Console.WriteLine("4. Перегляд найпопулярніших авторів");
            Console.WriteLine("5. Перегляд найпопулярніших жанрів");
            Console.WriteLine("6. Вихід");
            string choice = Console.ReadLine();
            if (choice == "1") { SearchBook(); }
            else if (choice == "2") { ViewNewBooks(); }
            else if (choice == "3") { ViewPopularBooks(); }
            else if (choice == "4") { ViewPopularAuthors(); }
            else if (choice == "5") { ViewPopularGenres(); }
            else if (choice == "6") { break; }
        }
    }

    class BookstoreApp
    {
        static string connectionString = "your_connection_string_here";

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Exit");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Login();
                }
                else if (choice == "2")
                {
                    break;
                }
            }
        }

        static void Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    bool isAdmin = (bool)reader["IsAdmin"];
                    if (isAdmin)
                    {
                        AdminMenu();
                    }
                    else
                    {
                        UserMenu();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
        }

        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Delete Book");
                Console.WriteLine("3. Edit Book");
                Console.WriteLine("4. Sell Book");
                Console.WriteLine("5. Write Off Book");
                Console.WriteLine("6. Add Book to Promotion");
                Console.WriteLine("7. Reserve Book");
                Console.WriteLine("8. Exit");
                string choice = Console.ReadLine();
                if (choice == "1") { AddBook(); }
                else if (choice == "2") { DeleteBook(); }
                else if (choice == "3") { EditBook(); }
                else if (choice == "4") { SellBook(); }
                else if (choice == "5") { WriteOffBook(); }
                else if (choice == "6") { AddBookToPromotion(); }
                else if (choice == "7") { ReserveBook(); }
                else if (choice == "8") { break; }
            }
        }

        static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Search Book");
                Console.WriteLine("2. View New Books");
                Console.WriteLine("3. View Popular Books");
                Console.WriteLine("4. View Popular Authors");
                Console.WriteLine("5. View Popular Genres");
                Console.WriteLine("6. Exit");
                string choice = Console.ReadLine();
                if (choice == "1") { SearchBook(); }
                else if (choice == "2") { ViewNewBooks(); }
                else if (choice == "3") { ViewPopularBooks(); }
                else if (choice == "4") { ViewPopularAuthors(); }
                else if (choice == "5") { ViewPopularGenres(); }
                else if (choice == "6") { break; }
            }
        }

        static void AddBook()
        {
            try
            {
                Console.Write("Enter book title: ");
                string title = Console.ReadLine();
                Console.Write("Enter author's name: ");
                string author = Console.ReadLine();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Books (Title, Author, ...) VALUES (@Title, @Author, ...)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Author", author);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Book added successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding book: " + ex.Message);
            }
        }

        static void DeleteBook()
        {
            try
            {
                Console.Write("Enter book ID to delete: ");
                int bookId = int.Parse(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Books WHERE BookId = @BookId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BookId", bookId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Book deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Book not found with the given ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting book: " + ex.Message);
            }
        }

        static void EditBook()
        {
            try
            {
                Console.Write("Enter book ID to edit: ");
                int bookId = int.Parse(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Books WHERE BookId = @BookId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BookId", bookId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                    }
                    else
                    {
                        Console.WriteLine("Book not found with the given ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error editing book: " + ex.Message);
            }
        }

        static void SellBook()
        {
            try
            {
                Console.Write("Enter book ID to sell: ");
                int bookId = int.Parse(Console.ReadLine());