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
      var books = await _context.Books!
      .Include(b => b.Author)
      .ToListAsync();

      return books.Select(b => new BookDTO
      {
        Id = b.Id,
        Name = b.Name,
        AuthorId = b.AuthorId,
        AuthorName = b.Author.Name


      });
    }

    //by author id
    public async Task<IEnumerable<BookDTO>> GetByAuthorId(int authorId)
    {
      var books = await _context.Books!
      .Where(b => b.AuthorId == authorId)
      .Include(b => b.Author)
      .ToListAsync();

      return books.Select(b => new BookDTO
      {
        Id = b.Id,
        Name = b.Name,
        AuthorName = b.Author.Name
      });
    }

    //get by book id
    public async Task<BookDTO> GetById(int id)
    {
      var books = await _context.Books!
     .Include(b => b.Author)
     .SingleOrDefaultAsync(b => b.Id == id);
      if (books == null)
      {
        return null!;
      }
      var bookDTO = new BookDTO
      {
        Id = books.Id,
        Name = books.Name,
        AuthorName = books.Author.Name,
        AuthorId = books.AuthorId

      };
      return bookDTO;

    }

    //update book
    public async Task<BookDTO> Update(int id, BookDTO bookDTO)
    {
      var book = await _context.Books!.FindAsync(id);
      if (book == null)
      {
        return null!;
      }
      book.Name = bookDTO.Name;
      book.Author!.Name = bookDTO.AuthorName;
      book.AuthorId = bookDTO.AuthorId;

      await _context.SaveChangesAsync();
      return new BookDTO
      {
        Id = book.Id,
        AuthorId = book.AuthorId,
        Name = book.Name,
        AuthorName = book.AuthorName

      };

    }

    //add book
    public async Task Add(Book book)
    {
      _context.Books?.Add(book);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      var book = await _context.Set<Book>().FindAsync(id);
      if (book != null)
      {
        _context.Books?.Remove(book);
        await _context.SaveChangesAsync();
      }
    }
  }
}