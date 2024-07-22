using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class Library
    {
        private List<User> users = new List<User>();
        private List<Book> books = new List<Book>();
        private User currentUser;

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Library System");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        return;
                }
            }
        }

        private void Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            currentUser = users.Find(u => u.Username == username && u.Authenticate(password));
            if (currentUser != null)
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Invalid credentials. Press any key to continue.");
                Console.ReadKey();
            }
        }

        private void Register()
        {
            Console.Write("Choose a username: ");
            string username = Console.ReadLine();
            Console.Write("Choose a password: ");
            string password = Console.ReadLine();

            if (users.Exists(u => u.Username == username))
            {
                Console.WriteLine("Username already exists. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            users.Add(new User(username, password));
            Console.WriteLine("Registration successful. Press any key to continue.");
            Console.ReadKey();
        }

        private void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome, {currentUser.Username}");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. List Books");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. List Users");
                Console.WriteLine("6. Logout");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        ListBooks();
                        break;
                    case "3":
                        BorrowBook();
                        break;
                    case "4":
                        ReturnBook(GetBooks());
                        break;
                    case "5":
                        ListUsers();
                        break;
                    case "6":
                        return;
                }
            }
        }

        private void AddBook()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();

            books.Add(new Book(title, author));
            Console.WriteLine("Book added. Press any key to continue.");
            Console.ReadKey();
        }

        private void ListBooks()
        {
            Console.Clear();
            Console.WriteLine("Books in library:");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void BorrowBook()
        {
            Console.Write("Enter book title to borrow: ");
            string title = Console.ReadLine();

            Book book = books.Find(b => b.Title == title && !b.IsBorrowed);
            if (book != null)
            {
                book.Borrow();
                Console.WriteLine("Book borrowed. Press any key to continue.");
            }
            else
            {
                Console.WriteLine("Book not found or already borrowed. Press any key to continue.");
            }
            Console.ReadKey();
        }

        private List<Book> GetBooks()
        {
            return books;
        }

        private void ReturnBook(List<Book> books)
        {
            Console.Write("Enter book title to return: ");
            string title = Console.ReadLine();

            Book book = books.Find(b => b.Title == title && b.IsBorrowed);
            if (book != null)
            {
                book.Return();
                Console.WriteLine("Book returned. Press any key to continue.");
            }
            else
            {
                Console.WriteLine("Book not found or not borrowed. Press any key to continue.");
            }
            Console.ReadKey();
        }

        private void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("Registered users:");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
