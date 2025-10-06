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

        private readonly AuthorService _authorService;
        private readonly BookService _bookService;
        private readonly ReservedItemService _reservedService;

        public ManagementApp()
        {
            #region MyRegion
            //var context = new AppDbContext();

            //var authorRepo = new AuthorRepository(context);
            //var bookRepo = new BookRepository(context);
            //var reservedRepo = new ReservedItemRepository(context);

            //_authorService = new AuthorService(authorRepo);
            //_bookService = new BookService(bookRepo,authorRepo);
            //_reservedService = new ReservedItemService(reservedRepo, bookRepo);

            //AppDbContext context = new AppDbContext();
            //BookRepository bookRepository = new BookRepository(context);
            //AuthorRepository authorRepository = new AuthorRepository(context);
            //ReservedItemRepository reservedItemRepository = new ReservedItemRepository(context);
            //BookService bookService = new BookService(bookRepository, authorRepository);
            //AuthorService authorService = new AuthorService(authorRepository);
            //ReservedItemService reservedItemService = new ReservedItemService(reservedItemRepository, bookRepository); 
            #endregion

            AppDbContext context = new AppDbContext();
            BookRepository bookRepository = new BookRepository(context);
            AuthorRepository authorRepository = new AuthorRepository(context);
            ReservedItemRepository reservedItemRepository = new ReservedItemRepository(context);

            _authorService = new AuthorService(authorRepository);
            _bookService = new BookService(bookRepository, authorRepository);
            _reservedService = new ReservedItemService(reservedItemRepository, bookRepository);
        }

        public void Run()
        {
            #region MenuVersion
            //while (true)
            //{
            //    Console.WriteLine("\n--- Online Library Menu ---");
            //    Console.WriteLine("1. Create Book");
            //    Console.WriteLine("2. Delete Book");
            //    Console.WriteLine("3. Get Book by Id");
            //    Console.WriteLine("4. Show All Books");
            //    Console.WriteLine("5. Create Author");
            //    Console.WriteLine("6. Show All Authors");
            //    Console.WriteLine("7. Show Author's Books");
            //    Console.WriteLine("8. Reserve Book");
            //    Console.WriteLine("9. Reservation List");
            //    Console.WriteLine("10. Change Reservation Status");
            //    Console.WriteLine("11. User's Reservations List");
            //    Console.WriteLine("0. Exit");
            //    Console.Write("Select option: ");

            //    string input = Console.ReadLine();
            //    Console.Clear();

            //    if (!int.TryParse(input, out int choice))
            //    {
            //        Console.WriteLine("Invalid input!");
            //        continue;
            //    }

            //    switch (choice)
            //    {
            //        case 1:

            //            string bookName;
            //            do
            //            {
            //                Console.Write("Book Name: ");
            //                bookName = Console.ReadLine().Trim();
            //                if (bookName.Length == 0) Console.WriteLine("Book name is needed.");
            //            } while (bookName.Length == 0);
            //            int page;
            //            while (true)
            //            {
            //                Console.Write("Page Count: ");
            //                if (int.TryParse(Console.ReadLine(), out page) && page > 0) break;
            //                Console.WriteLine("Page Count must be greater than 0.");
            //            }
            //            List<Author> authors = _authorService.GetAllAuthors();
            //            foreach (Author author1 in authors)
            //            {
            //                Console.WriteLine($"{author1.Id} - {author1.Name} {author1.Surname}");
            //            }
            //            Console.WriteLine("Enter author id:");
            //            int authorId;
            //            while(true)
            //            {
            //                Console.Write("Enter author id:");
            //                if (int.TryParse(Console.ReadLine(), out authorId)) break;
            //            }

            //            if (_authorService.GetById(authorId) != null)
            //            {
            //                Book newBook = new Book
            //                {
            //                    Name = bookName,
            //                    PageCount = page,
            //                    AuthorId = authorId
            //                };

            //                _bookService.Create(newBook);
            //                Console.WriteLine("Book created successfully!");
            //            }
            //            else
            //            {
            //                Console.WriteLine("Author ");
            //            }
            //            break;
            //        case 2:
            //            Console.Write("Enter Book Id to delete: ");
            //            var delId = int.Parse(Console.ReadLine()!);
            //            _bookService.Delete(delId);
            //            Console.WriteLine("Book deleted successfully!");
            //            break;
            //        case 3:
            //            Console.Write("Enter Book Id: ");
            //            var getId = int.Parse(Console.ReadLine()!);
            //            var book = _bookService.GetById(getId);
            //            if (book == null)
            //            {
            //                Console.WriteLine("Book not found!");
            //            }
            //            else
            //            {
            //                Console.WriteLine($"Book: {book.Id} - {book.Name} | Pages: {book.PageCount} | Author: {book.Author.Name}");

            //                if (book.ReservedItems.Any())
            //                {
            //                    Console.WriteLine("Reservation History:");
            //                    foreach (var r in book.ReservedItems)
            //                    {
            //                        Console.WriteLine($" {r.Id} | {r.FinCode} | {r.StartDate:dd.MM.yyyy} - {r.EndDate:dd.MM.yyyy} | Status: {r.Status}");
            //                    }
            //                }
            //            }
            //            break;
            //        case 4:
            //            var allBooks = _bookService.GetAllBooks();
            //            if (!allBooks.Any())
            //            {
            //                Console.WriteLine("No books found.");
            //            }
            //            else
            //            {
            //                Console.WriteLine("All Books:");
            //                foreach (var bk in allBooks)
            //                    Console.WriteLine($"{bk.Id} - {bk.Name} | Pages: {bk.PageCount} | Author: {bk.Author.Name}");
            //            }
            //            break;
            //        case 5:
            //            Console.Write("Author Name: ");
            //            var aName = Console.ReadLine()!;
            //            Console.Write("Author Surname (optional): ");
            //            var aSurname = Console.ReadLine();

            //            Console.Write("Gender (0-Female,1-Male,2-Other,3-Unknown): ");
            //            var g = int.Parse(Console.ReadLine()!);
            //            var gender = (Gender)g;

            //            var newAuthor = new Author
            //            {
            //                Name = aName,
            //                Surname = string.IsNullOrWhiteSpace(aSurname) ? null : aSurname,
            //                Gender = gender
            //            };

            //            _authorService.Create(newAuthor);
            //            Console.WriteLine("Author created successfully!");
            //            break;
            //        case 6:
            //            var authors2 = _authorService.GetAllAuthors();
            //            if (!authors2.Any())
            //            {
            //                Console.WriteLine("No authors found.");
            //            }
            //            else
            //            {
            //                Console.WriteLine("All Authors:");
            //                foreach (var a in authors2)
            //                    Console.WriteLine($"{a.Id} - {a.Name} {a.Surname} | Books: {a.Books.Count}");
            //            }
            //            break;
            //        case 7:
            //            Console.Write("Enter Author Id: ");
            //            var authBooksId = int.Parse(Console.ReadLine()!);
            //            var author = _authorService.GetById(authBooksId);
            //            if (author == null)
            //            {
            //                Console.WriteLine("Author not found!");
            //            }
            //            else if (!author.Books.Any())
            //            {
            //                Console.WriteLine("This author has no books.");
            //            }
            //            else
            //            {
            //                Console.WriteLine($"Books by {author.Name} {author.Surname}:");
            //                foreach (var b in author.Books)
            //                    Console.WriteLine($"{b.Id} - {b.Name} | Pages: {b.PageCount}");
            //            }
            //            break;
            //        case 8:
            //            Console.Write("Enter Book Id to reserve: ");
            //            var resBookId = int.Parse(Console.ReadLine()!);
            //            Console.Write("Enter User FIN Code: ");
            //            var fin = Console.ReadLine()!;
            //            Console.Write("Enter Start Date (yyyy-MM-dd): ");
            //            var sDate = DateTime.Parse(Console.ReadLine()!);
            //            Console.Write("Enter End Date (yyyy-MM-dd): ");
            //            var eDate = DateTime.Parse(Console.ReadLine()!);

            //            _reservedService.ReserveBook(fin, resBookId, sDate, eDate);
            //            Console.WriteLine("Book reserved successfully!");
            //            break;
            //        case 9:
            //            var reservations = _reservedService.ReservationList().OrderBy(r => r.Status);
            //            if (!reservations.Any())
            //            {
            //                Console.WriteLine("No reservations found.");
            //            }
            //            else
            //            {
            //                Console.WriteLine("Reservation List:");
            //                foreach (var r in reservations)
            //                    Console.WriteLine($"{r.Id} | Book: {r.Book.Name} | {r.FinCode} | {r.StartDate:dd.MM.yyyy}-{r.EndDate:dd.MM.yyyy} | Status: {r.Status}");
            //            }
            //            break;
            //        case 10:
            //            Console.Write("Enter Reservation Id: ");
            //            var resId = int.Parse(Console.ReadLine()!);
            //            Console.WriteLine("Choose New Status: 0-Confirmed,1-Started,2-Completed,3-Canceled");
            //            var newStatusInt = int.Parse(Console.ReadLine()!);
            //            var newStatus = (Status)newStatusInt;

            //            _reservedService.ChangeReservationStatus(resId, newStatus);
            //            Console.WriteLine("Reservation status updated!");
            //            break;
            //        case 11:
            //            Console.Write("Enter User FIN Code: ");
            //            var userFin = Console.ReadLine()!;
            //            var userRes = _reservedService.UserReservationsList(userFin);
            //            if (!userRes.Any())
            //            {
            //                Console.WriteLine("No reservations found for this user.");
            //            }
            //            else
            //            {
            //                Console.WriteLine($"Reservations for {userFin}:");
            //                foreach (var r in userRes)
            //                    Console.WriteLine($"{r.Id} | Book: {r.Book.Name} | {r.StartDate:dd.MM.yyyy}-{r.EndDate:dd.MM.yyyy} | Status: {r.Status}");
            //            }
            //            break;
            //        case 0:
            //            Console.WriteLine("Program exited.");
            //            return;
            //        default:
            //            Console.WriteLine("Wrong input. Try again."); break;
            //    }
            //} 
            #endregion

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
                    Console.WriteLine("Invalid input! Enter a number from 0 to 11.");
                    continue;
                }

                if (choice == 0)
                {
                    Console.WriteLine("Program exited.");
                    return;
                }

                if (choice == 1)
                {
                    string bookName;
                    do
                    {
                        Console.Write("Book Name: ");
                        bookName = Console.ReadLine()?.Trim() ?? "";
                        if (bookName.Length == 0) Console.WriteLine("Book name is required.");
                    } while (bookName.Length == 0);

                    int page;
                    while (true)
                    {
                        Console.Write("Page Count: ");
                        if (int.TryParse(Console.ReadLine(), out page) && page > 0) break;
                        Console.WriteLine("Page Count must be a positive number.");
                    }

                    var authors = _authorService.GetAllAuthors();
                    if (!authors.Any())
                    {
                        Console.WriteLine("No authors found. Please create an author first.");
                        continue;
                    }

                    foreach (var a in authors)
                        Console.WriteLine($"{a.Id} - {a.Name} {a.Surname}");

                    int authorId;
                    while (true)
                    {
                        Console.Write("Enter Author Id: ");
                        if (int.TryParse(Console.ReadLine(), out authorId) &&
                            _authorService.GetById(authorId) != null)
                            break;
                        Console.WriteLine("Invalid Author Id. Try again.");
                    }

                    Book newBook = new Book
                    {
                        Name = bookName,
                        PageCount = page,
                        AuthorId = authorId
                    };

                    _bookService.Create(newBook);
                    Console.WriteLine("Book created successfully!");
                }
                else if (choice == 2)
                {
                    int delId;
                    while (true)
                    {
                        Console.Write("Enter Book Id to delete: ");
                        if (int.TryParse(Console.ReadLine(), out delId)) break;
                        Console.WriteLine("Invalid Id. Try again.");
                    }

                    var book = _bookService.GetById(delId);
                    if (book == null)
                    {
                        Console.WriteLine("Book not found!");
                    }
                    else if (book.ReservedItems.Any(r => r.Status == Status.Confirmed || r.Status == Status.Started))
                    {
                        Console.WriteLine("This book is currently reserved. Cannot delete.");
                    }
                    else
                    {
                        _bookService.Delete(delId);
                        Console.WriteLine("Book deleted successfully!");
                    }
                }
                else if (choice == 3)
                {
                    int getId;
                    while (true)
                    {
                        Console.Write("Enter Book Id: ");
                        if (int.TryParse(Console.ReadLine(), out getId)) break;
                        Console.WriteLine("Invalid Id. Try again.");
                    }

                    var book = _bookService.GetById(getId);
                    if (book == null)
                        Console.WriteLine("Book not found!");
                    else
                    {
                        Console.WriteLine($"Book: {book.Id} - {book.Name} | Pages: {book.PageCount} | Author: {book.Author.Name}");
                        if (book.ReservedItems.Any())
                        {
                            Console.WriteLine("Reservation History:");
                            foreach (var r in book.ReservedItems)
                                Console.WriteLine($"{r.Id} | {r.FinCode} | {r.StartDate:dd.MM.yyyy} - {r.EndDate:dd.MM.yyyy} | Status: {r.Status}");
                        }
                    }
                }
                else if (choice == 4)
                {
                    var books = _bookService.GetAllBooks();
                    if (!books.Any())
                        Console.WriteLine("No books found.");
                    else
                        foreach (var b in books)
                            Console.WriteLine($"{b.Id} - {b.Name} | Pages: {b.PageCount} | Author: {b.Author.Name}");
                }
                else if (choice == 5)
                {
                    string aName;
                    do
                    {
                        Console.Write("Author Name: ");
                        aName = Console.ReadLine()?.Trim() ?? "";
                        if (aName.Length == 0) Console.WriteLine("Author name is required.");
                    } while (aName.Length == 0);

                    Console.Write("Author Surname (optional): ");
                    string? aSurname = Console.ReadLine();

                    Gender gender;
                    while (true)
                    {
                        Console.Write("Gender (0-Female,1-Male,2-Other,3-Unknown): ");
                        if (int.TryParse(Console.ReadLine(), out int g) &&
                            Enum.IsDefined(typeof(Gender), g))
                        {
                            gender = (Gender)g;
                            break;
                        }
                        Console.WriteLine("Invalid gender. Try again.");
                    }

                    var newAuthor = new Author
                    {
                        Name = aName,
                        Surname = string.IsNullOrWhiteSpace(aSurname) ? null : aSurname,
                        Gender = gender
                    };

                    _authorService.Create(newAuthor);
                    Console.WriteLine("Author created successfully!");
                }
                else if (choice == 6)
                {
                    var authors2 = _authorService.GetAllAuthors();
                    if (!authors2.Any())
                        Console.WriteLine("No authors found.");
                    else
                        foreach (var a in authors2)
                            Console.WriteLine($"{a.Id} - {a.Name} {a.Surname} | Books: {a.Books.Count}");
                }
                else if (choice == 7)
                {
                    int authId;
                    while (true)
                    {
                        Console.Write("Enter Author Id: ");
                        if (int.TryParse(Console.ReadLine(), out authId)) break;
                        Console.WriteLine("Invalid Id. Try again.");
                    }

                    var author = _authorService.GetById(authId);
                    if (author == null)
                        Console.WriteLine("Author not found!");
                    else if (!author.Books.Any())
                        Console.WriteLine("This author has no books.");
                    else
                        foreach (var b in author.Books)
                            Console.WriteLine($"{b.Id} - {b.Name} | Pages: {b.PageCount}");
                }
                else if (choice == 8)
                {
                    int resBookId;
                    while (true)
                    {
                        Console.Write("Enter Book Id to reserve: ");
                        if (int.TryParse(Console.ReadLine(), out resBookId)) break;
                        Console.WriteLine("Invalid Id. Try again.");
                    }

                    Console.Write("Enter User FIN Code: ");
                    string fin = Console.ReadLine() ?? "";

                    DateTime sDate;
                    while (true)
                    {
                        Console.Write("Enter Start Date (yyyy-MM-dd): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, DateTimeStyles.None, out sDate))
                            break;
                        Console.WriteLine("Invalid date format. Try again.");
                    }

                    DateTime eDate;
                    while (true)
                    {
                        Console.Write("Enter End Date (yyyy-MM-dd): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, DateTimeStyles.None, out eDate))
                            break;
                        Console.WriteLine("Invalid date format. Try again.");
                    }

                    if (eDate <= sDate)
                    {
                        Console.WriteLine("End date must be after start date.");
                        continue;  
                    }

                    var userReservations = _reservedService.UserReservationsList(fin)
                        .Where(r => r.Status == Status.Confirmed || r.Status == Status.Started).ToList();
                    if (userReservations.Count >= 3)
                    {
                        Console.WriteLine("This user already has 3 active reservations. Cannot reserve more books.");
                        continue;
                    }

                    _reservedService.ReserveBook(fin, resBookId, sDate, eDate);
                    Console.WriteLine("Book reserved successfully!");
                }
                else if (choice == 9)
                {
                    var reservations = _reservedService.ReservationList().OrderBy(r => r.Status);
                    if (!reservations.Any())
                        Console.WriteLine("No reservations found.");
                    else
                        foreach (var r in reservations)
                            Console.WriteLine($"{r.Id} | Book: {r.Book.Name} | {r.FinCode} | {r.StartDate:dd.MM.yyyy}-{r.EndDate:dd.MM.yyyy} | Status: {r.Status}");
                }
                else if (choice == 10)
                {
                    int resId;
                    while (true)
                    {
                        Console.Write("Enter Reservation Id: ");
                        if (int.TryParse(Console.ReadLine(), out resId)) break;
                        Console.WriteLine("Invalid Id. Try again.");
                    }

                    Status newStatus;
                    while (true)
                    {
                        Console.WriteLine("Choose New Status: 0-Confirmed,1-Started,2-Completed,3-Canceled");
                        if (int.TryParse(Console.ReadLine(), out int ns) && Enum.IsDefined(typeof(Status), ns))
                        {
                            newStatus = (Status)ns;
                            break;
                        }
                        Console.WriteLine("Invalid status. Try again.");
                    }

                    _reservedService.ChangeReservationStatus(resId, newStatus);
                    Console.WriteLine("Reservation status updated!");
                }
                else if (choice == 11)
                {
                    Console.Write("Enter User FIN Code: ");
                    string userFin = Console.ReadLine() ?? "";
                    var userRes = _reservedService.UserReservationsList(userFin);
                    if (!userRes.Any())
                        Console.WriteLine("No reservations found for this user.");
                    else
                        foreach (var r in userRes)
                            Console.WriteLine($"{r.Id} | Book: {r.Book.Name} | {r.StartDate:dd.MM.yyyy}-{r.EndDate:dd.MM.yyyy} | Status: {r.Status}");
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again.");
                }
            }
        }


    }        
    
}