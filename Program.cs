// See https://aka.ms/new-console-template for more information
using bookLibary.Data;
using bookLibary.Data.Repositories.ConcreteRepository;
using bookLibary.Models;

Console.WriteLine("Hello, World!");

DataContext dataContext = new();

AuthorRepository authorRepository = new(dataContext);
BookRepository bookRepository = new(dataContext);

// Author author = new() { Name = "Jespori guula" };
Book book = new() { Name = "how to sql IN 2023", AuthorId = 1 };

// await authorRepository.Add(author);
await bookRepository.Add(book);

await dataContext.SaveChangesAsync();

