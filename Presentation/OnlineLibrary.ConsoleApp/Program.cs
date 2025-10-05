using OnlineLibrary.Application.Interfaces.Repositories;
using OnlineLibrary.Domain.Entities;
using OnlineLibrary.Domain.Enums;
using OnlineLibrary.Persistence.Contexts;
using OnlineLibrary.Persistence.Implementations.Repositories;

namespace OnlineLibrary.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            var app = new ManagementApp();
            app.Run();
        }
    }
}


