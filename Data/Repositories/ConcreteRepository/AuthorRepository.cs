using bookLibary.Data.DTOs;
using bookLibary.Data.Repositories.InterfaceRepository;
using bookLibary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace bookLibary.Data.Repositories.ConcreteRepository
{
  public class AuthorRepository : IAuthorRepository
  {
    private readonly DataContext _context;
    public AuthorRepository(DataContext context)
    {
      _context = context;
    }

    public async Task Add(Author author)
    {
      _context.Authors.Add(author);
      await _context.SaveChangesAsync();


    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    //after this we do filtering
    public async Task<IEnumerable<AuthorDTO>> GetAll()
    {
      var authors = await _context.Authors
      .Include(a => a.Books)
      .ToListAsync();

      return authors.Select(a => new AuthorDTO { Id = a.Id, Name = a.Name });

    }

    public async Task<AuthorDTO> GetById(int id)
    {
      var author = await _context.Authors
      .Include(a => a.Books)
      .SingleOrDefaultAsync(a => a.Id == id);

      return new AuthorDTO
      {
        Id = author.Id,
        Name = author.Name,
        Books = author.Books.Select(b => new BookDTO
        {
          Id = b.Id,
          Name = b.Name,
          AuthorId = b.AuthorId
        }).ToList()
      };
    }

    public Task<AuthorDTO> Update(Author author)
    {
      throw new NotImplementedException();
    }


  }
}