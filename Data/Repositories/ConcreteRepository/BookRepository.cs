using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookLibary.Data.DTOs;
using bookLibary.Data.Repositories.InterfaceRepository;
using bookLibary.Models;
using Microsoft.EntityFrameworkCore;

namespace bookLibary.Data.Repositories.ConcreteRepository
{
  public class BookRepository : IBookRepository
  {
    private readonly DataContext _context;
    //context
    public BookRepository(DataContext context)
    {
      _context = context;
    }


    //get all
    public async Task<IEnumerable<BookDTO>> GetAll()
    {
      var books = await _context.Books
      .Include(b => b.Author)
      .ToListAsync();

      return books.Select(b => new BookDTO
      {
        Id = b.Id,
        Name = b.Name,
        AuthorId = b.AuthorId

      });
    }

    //by id
    public async Task<IEnumerable<BookDTO>> GetByAuthorId(int authorId)
    {
      throw new NotImplementedException();
    }

    public async Task<BookDTO> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public Task<BookDTO> Update(Book book)
    {
      throw new NotImplementedException();
    }

    public async Task Add(Book book)
    {
      _context.Books.Add(book);
      await _context.SaveChangesAsync();
    }

    Task<Book> IBookRepository.Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}