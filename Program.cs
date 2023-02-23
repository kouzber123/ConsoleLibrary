// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;
using bookLibary.Data;
using bookLibary.Data.Repositories.ConcreteRepository;
using bookLibary.Models;

DataContext dataContext = new();

AuthorRepository authorRepository = new(dataContext);
BookRepository bookRepository = new(dataContext);
//! find id
// AuthorDTO authorDTO = new() { Name = "John snow" };
// var update = await authorRepository.Update(4, authorDTO);
while (true)
{
  Console.Clear();
  Console.WriteLine("Select action: ");
  Console.WriteLine("1) Add user: ");
  Console.WriteLine("2) Delete Author: ");
  Console.WriteLine("3) Get Author by id: ");
  Console.WriteLine("4) Get all Authors: ");
  Console.WriteLine("-------------------------");
  Console.WriteLine("5) Add Book");
  Console.WriteLine("6) Delete Book");
  Console.WriteLine("7) Get Book by id");
  Console.WriteLine("8) Get Book by Author");
  Console.WriteLine("9) Get all books");
  Console.WriteLine("press anything to else to quit");

  string choise = Console.ReadLine()!;

  switch (choise)
  {
    case "1":
      string name = Console.ReadLine()!;
      Author author1 = new() { Name = name };
      await authorRepository.Add(author1);
      break;
    case "2":
      try
      {
        string tryId = Console.ReadLine()!;
        int id = int.Parse(tryId);

        await authorRepository.Delete(id);
        break;
      }
      catch (FormatException)
      {

        Console.WriteLine("Not correct id");
      }
      break;
    case "3":
      try
      {
        string tryId = Console.ReadLine()!;
        int id = int.Parse(tryId);

        var authorId = await authorRepository.GetById(id);
        Console.WriteLine($"{authorId.Name},  books : ");
        foreach (var item in authorId.Books!)
        {
          Console.WriteLine(item.Name);
        }
        Console.ReadKey();
        break;
      }
      catch (FormatException)
      {

        Console.WriteLine("Not correct id");
      }
      break;
    case "4":

      var authors = await authorRepository.GetAll();
      foreach (var item in authors)
      {
        Console.WriteLine($"id: {item.Id} Name:{item.Name} : books:  ");
        foreach (var book in item.Books!)
        {
          Console.WriteLine($"-{book.Name}");

        }
        Console.WriteLine("----------------------");

      }
      Console.ReadKey();
      break;


    case "5":

      try
      {
        Console.WriteLine("book name");
        string bookname = Console.ReadLine()!;
        Console.WriteLine("author name");
        string authorname = Console.ReadLine()!;
        Console.WriteLine("Author Id");
        string authorId = Console.ReadLine()!;
        int id = int.Parse(authorId);
        Book book1 = new() { Name = bookname, AuthorId = id, AuthorName = authorname};
        await bookRepository.Add(book1);
      }
      catch (FormatException)
      {

        Console.WriteLine("Incorrect input");
      }

      break;
    case "6":
      try
      {
        string tryId = Console.ReadLine()!;
        int id = int.Parse(tryId);

        await bookRepository.Delete(id);
      }
      catch (FormatException)
      {

        Console.WriteLine("Not correct id");
      }
      break;
    case "7":
      try
      {
        string tryId = Console.ReadLine()!;
        int id = int.Parse(tryId);

        var booksss = await bookRepository.GetById(id);
        Console.WriteLine($"Name : {booksss.Name} by {booksss.AuthorName} / id: {booksss.AuthorId}");

      }
      catch (FormatException)
      {

        Console.WriteLine("Not correct id");
      }
      Console.ReadKey();
      break;
    case "8":
      try
      {
        string tryId = Console.ReadLine()!;
        int id = int.Parse(tryId);

        var bookss = await bookRepository.GetByAuthorId(id);
        foreach (var item in bookss)
        {
          Console.WriteLine($"Books: {item.Name} by {item.AuthorName}");
        }
;
      }
      catch (FormatException)
      {

        Console.WriteLine("Not correct id");
      }
      Console.ReadKey();
      break;
    case "9":
      var books = await bookRepository.GetAll();
      foreach (var item in books)
      {
        Console.WriteLine($"id: {item.Id} Name:{item.Name}  by: {item.AuthorName} ");
        Console.WriteLine("----------------------");

      }
      Console.ReadKey();
      break;



    default:
      break;
  }

}

// var author = await authorRepository.GetById(3);

// Console.WriteLine($"{author.Name} has books : ");
// foreach (var book in author.Books)
// {
//   Console.WriteLine($"- {book.Name}");
// }



//! add create
// Author author = new() { Name = "money man" };
// Book book = new() { Name = "how to your moms", AuthorId = author.Id, Author = author };

// await authorRepository.Add(author);
// await bookRepository.Add(book);
// await authorRepository.Delete(2);

// await dataContext.SaveChangesAsync();

