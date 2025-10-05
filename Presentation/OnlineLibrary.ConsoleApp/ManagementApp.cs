using System;
using System.Globalization;
using System.Linq;
using OnlineLibrary.Application.Interfaces.Services;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Domain.Enums;
using OnlineLibrary.Persistence.Contexts;
using OnlineLibrary.Persistence.Implementations.Repositories;
using OnlineLibrary.Persistence.Implementations.Services;

namespace OnlineLibrary
{
    internal class ManagementApp
    {
        private AuthorService _authorService { get; set; }
        private BookService _bookService { get; set; }
        private ReservedItemService _reservedService { get; set; }

        public ManagementApp()
        {
            var context = new AppDbContext();

            var authorRepo = new AuthorRepository(context);
            var bookRepo = new BookRepository(context);
            var reservedRepo = new ReservedItemRepository(context);

            _authorService = new AuthorService(authorRepo);
            _bookService = new BookService(bookRepo,authorRepo);
            _reservedService = new ReservedItemService(reservedRepo, bookRepo);
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n--- Online Library Menu ---");
                Console.WriteLine("1. Create Book");
                Console.WriteLine("2. Delete Book");
                Console.WriteLine("3. Get Book by Id");
                Console.WriteLine("4. Show All Books");
                Console.WriteLine("5. Create Author");
                Console.WriteLine("6. Show All Authors");
                Console.WriteLine("7. Show Author's Books");
                Console.WriteLine("8. Reserve Book");
                Console.WriteLine("9. Reservation List");
                Console.WriteLine("10. Change Reservation Status");
                Console.WriteLine("11. User's Reservations List");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");

                string input = Console.ReadLine();
                Console.Clear();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Book Name: ");
                        var bName = Console.ReadLine()!;
                        Console.Write("Page Count: ");
                        var page = int.Parse(Console.ReadLine()!);
                        Console.Write("Author Id: ");
                        var authId = int.Parse(Console.ReadLine()!);

                        var newBook = new Book
                        {
                            Name = bName,
                            PageCount = page,
                            AuthorId = authId
                        };

                        _bookService.Create(newBook);
                        Console.WriteLine("Book created successfully!");
                        break;
                    case 2:
                        Console.Write("Enter Book Id to delete: ");
                        var delId = int.Parse(Console.ReadLine()!);
                        _bookService.Delete(delId);
                        Console.WriteLine("Book deleted successfully!");
                        break;
                    case 3:
                        Console.Write("Enter Book Id: ");
                        var getId = int.Parse(Console.ReadLine()!);
                        var book = _bookService.GetById(getId);
                        if (book == null)
                        {
                            Console.WriteLine("Book not found!");
                        }
                        else
                        {
                            Console.WriteLine($"Book: {book.Id} - {book.Name} | Pages: {book.PageCount} | Author: {book.Author.Name}");

                            if (book.ReservedItems.Any())
                            {
                                Console.WriteLine("Reservation History:");
                                foreach (var r in book.ReservedItems)
                                {
                                    Console.WriteLine($" {r.Id} | {r.FinCode} | {r.StartDate:dd.MM.yyyy} - {r.EndDate:dd.MM.yyyy} | Status: {r.Status}");
                                }
                            }
                        }
                        break;
                    case 4:
                        var allBooks = _bookService.GetAllBooks();
                        if (!allBooks.Any())
                        {
                            Console.WriteLine("No books found.");
                        }
                        else
                        {
                            Console.WriteLine("All Books:");
                            foreach (var bk in allBooks)
                                Console.WriteLine($"{bk.Id} - {bk.Name} | Pages: {bk.PageCount} | Author: {bk.Author.Name}");
                        }
                        break;
                    case 5:
                        Console.Write("Author Name: ");
                        var aName = Console.ReadLine()!;
                        Console.Write("Author Surname (optional): ");
                        var aSurname = Console.ReadLine();

                        Console.Write("Gender (0-Female,1-Male,2-Other,3-Unknown): ");
                        var g = int.Parse(Console.ReadLine()!);
                        var gender = (Gender)g;

                        var newAuthor = new Author
                        {
                            Name = aName,
                            Surname = string.IsNullOrWhiteSpace(aSurname) ? null : aSurname,
                            Gender = gender
                        };

                        _authorService.Create(newAuthor);
                        Console.WriteLine("Author created successfully!");
                        break;
                    case 6:
                        var authors = _authorService.GetAllAuthors();
                        if (!authors.Any())
                        {
                            Console.WriteLine("No authors found.");
                        }
                        else
                        {
                            Console.WriteLine("All Authors:");
                            foreach (var a in authors)
                                Console.WriteLine($"{a.Id} - {a.Name} {a.Surname} | Books: {a.Books.Count}");
                        }
                        break;
                    case 7:
                        Console.Write("Enter Author Id: ");
                        var authBooksId = int.Parse(Console.ReadLine()!);
                        var author = _authorService.GetById(authBooksId);
                        if (author == null)
                        {
                            Console.WriteLine("Author not found!");
                        }
                        else if (!author.Books.Any())
                        {
                            Console.WriteLine("This author has no books.");
                        }
                        else
                        {
                            Console.WriteLine($"Books by {author.Name} {author.Surname}:");
                            foreach (var b in author.Books)
                                Console.WriteLine($"{b.Id} - {b.Name} | Pages: {b.PageCount}");
                        }
                        break;
                    case 8:
                        Console.Write("Enter Book Id to reserve: ");
                        var resBookId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter User FIN Code: ");
                        var fin = Console.ReadLine()!;
                        Console.Write("Enter Start Date (yyyy-MM-dd): ");
                        var sDate = DateTime.Parse(Console.ReadLine()!);
                        Console.Write("Enter End Date (yyyy-MM-dd): ");
                        var eDate = DateTime.Parse(Console.ReadLine()!);

                        _reservedService.ReserveBook(fin, resBookId, sDate, eDate);
                        Console.WriteLine("Book reserved successfully!");
                        break;
                    case 9:
                        var reservations = _reservedService.ReservationList().OrderBy(r => r.Status);
                        if (!reservations.Any())
                        {
                            Console.WriteLine("No reservations found.");
                        }
                        else
                        {
                            Console.WriteLine("Reservation List:");
                            foreach (var r in reservations)
                                Console.WriteLine($"{r.Id} | Book: {r.Book.Name} | {r.FinCode} | {r.StartDate:dd.MM.yyyy}-{r.EndDate:dd.MM.yyyy} | Status: {r.Status}");
                        }
                        break;
                    case 10:
                        Console.Write("Enter Reservation Id: ");
                        var resId = int.Parse(Console.ReadLine()!);
                        Console.WriteLine("Choose New Status: 0-Confirmed,1-Started,2-Completed,3-Canceled");
                        var newStatusInt = int.Parse(Console.ReadLine()!);
                        var newStatus = (Status)newStatusInt;

                        _reservedService.ChangeReservationStatus(resId, newStatus);
                        Console.WriteLine("Reservation status updated!");
                        break;
                    case 11:
                        Console.Write("Enter User FIN Code: ");
                        var userFin = Console.ReadLine()!;
                        var userRes = _reservedService.UserReservationsList(userFin);
                        if (!userRes.Any())
                        {
                            Console.WriteLine("No reservations found for this user.");
                        }
                        else
                        {
                            Console.WriteLine($"Reservations for {userFin}:");
                            foreach (var r in userRes)
                                Console.WriteLine($"{r.Id} | Book: {r.Book.Name} | {r.StartDate:dd.MM.yyyy}-{r.EndDate:dd.MM.yyyy} | Status: {r.Status}");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Program exited.");
                        return;
                    default:
                        Console.WriteLine("Wrong input. Try again."); break;
                }
            }
        }

        #region E
        //private void CreateBook()
        //{
        //    Console.Write("Book Name: "); string name = Console.ReadLine();
        //    Console.Write("Page Count: "); int pageCount = int.Parse(Console.ReadLine());
        //    Console.Write("Author Id: "); int authorId = int.Parse(Console.ReadLine());

        //    var book = new Book { Name = name, PageCount = pageCount, AuthorId = authorId };
        //    try { _bookService.Create(book); Console.WriteLine("Book created!"); }
        //    catch (Exception ex) { Console.WriteLine(ex.Message); }
        //}

        //private void DeleteBook()
        //{
        //    Console.Write("Book Id to delete: "); int id = int.Parse(Console.ReadLine());
        //    _bookService.Delete(id);
        //    Console.WriteLine("Book deleted!");
        //}

        //private void GetBookById()
        //{
        //    Console.Write("Book Id: "); int id = int.Parse(Console.ReadLine());
        //    var book = _bookService.GetById(id);
        //    if (book == null) { Console.WriteLine("Book not found!"); return; }
        //    Console.WriteLine($"Id:{book.Id}, Name:{book.Name}, PageCount:{book.PageCount}, Author:{book.Author.Name}");
        //    if (book.ReservedItems.Any())
        //    {
        //        foreach (var r in book.ReservedItems)
        //            Console.WriteLine($"Reservation: Id:{r.Id}, FinCode:{r.FinCode}, {r.StartDate:d}-{r.EndDate:d}, Status:{r.Status}");
        //    }
        //}

        //private void ShowAllBooks()
        //{
        //    var books = _bookService.GetAllBooks();
        //    foreach (var b in books)
        //        Console.WriteLine($"Id:{b.Id}, Name:{b.Name}, PageCount:{b.PageCount}, Author:{b.Author.Name}");
        //}

        //private void CreateAuthor()
        //{
        //    Console.Write("Author Name: "); string name = Console.ReadLine();
        //    Console.Write("Author Surname (optional): "); string surname = Console.ReadLine();
        //    Console.Write("Gender (Female=1, Male=2, Other=3, Unknown=4): "); int g = int.Parse(Console.ReadLine());
        //    var author = new Author { Name = name, Surname = string.IsNullOrEmpty(surname) ? null : surname, Gender = (Gender)g };
        //    _authorService.CreateAuthor(author);
        //    Console.WriteLine("Author created!");
        //}

        //private void ShowAllAuthors()
        //{
        //    var authors = _authorService.GetAllAuthors();
        //    foreach (var a in authors)
        //        Console.WriteLine($"Id:{a.Id}, Name:{a.Name}, BooksCount:{a.Books.Count}");
        //}

        //private void ShowAuthorsBooks()
        //{
        //    Console.Write("Author Id: "); int id = int.Parse(Console.ReadLine());
        //    var books = _authorService.ShowAuthorsBooks(id);
        //    foreach (var b in books)
        //        Console.WriteLine($"Id:{b.Id}, Name:{b.Name}, PageCount:{b.PageCount}");
        //}

        //private void ReserveBook()
        //{
        //    Console.Write("Book Id: "); int bookId = int.Parse(Console.ReadLine());
        //    Console.Write("FinCode: "); string fin = Console.ReadLine();
        //    Console.Write("Start Date (yyyy-MM-dd): "); DateTime start = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
        //    Console.Write("End Date (yyyy-MM-dd): "); DateTime end = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

        //    var item = new ReservedItem { BookId = bookId, FinCode = fin, StartDate = start, EndDate = end, Status = Status.Confirmed };
        //    _reservedService.ReserveBook(item);
        //    Console.WriteLine("Book reserved!");
        //}

        //private void ShowReservationList()
        //{
        //    var list = _reservedService.ReservationList();
        //    foreach (var r in list)
        //        Console.WriteLine($"Id:{r.Id}, Book:{r.Book.Name}, {r.StartDate:d}-{r.EndDate:d}, FinCode:{r.FinCode}, Status:{r.Status}");
        //}

        //private void ChangeReservationStatus()
        //{
        //    Console.Write("Reservation Id: "); int id = int.Parse(Console.ReadLine());
        //    Console.Write("Status (Confirmed=1, Started=2, Completed=3, Canceled=4): "); int s = int.Parse(Console.ReadLine());
        //    _reservedService.ChangeReservationStatus(id, (Status)s);
        //    Console.WriteLine("Status changed!");
        //}

        //private void ShowUserReservations()
        //{
        //    Console.Write("User FinCode: "); string fin = Console.ReadLine();
        //    var list = _reservedService.UserReservationsList(fin);
        //    if (!list.Any()) { Console.WriteLine("No reservations found."); return; }
        //    foreach (var r in list)
        //        Console.WriteLine($"Id:{r.Id}, Book:{r.Book.Name}, {r.StartDate:d}-{r.EndDate:d}, Status:{r.Status}");
        //} 
        #endregion
    }
}