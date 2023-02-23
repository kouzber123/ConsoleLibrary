using bookLibary.Data.DTOs;
using bookLibary.Data.Repositories.InterfaceRepository;
using bookLibary.Models;
using Microsoft.EntityFrameworkCore;

namespace bookLibary.Data.Repositories.ConcreteRepository
{
  public class AuthorRepository : IAuthorRepository
  {
    private readonly DataContext _context;
    public AuthorRepository(DataContext context)
    {
      _context = context;
    }

    //------------------------cruds
    public async Task Add(Author author)
    {
      _context.Authors?.Add(author);
      await _context.SaveChangesAsync();


    }

    //delete
    public async Task Delete(int id)
    {
      //SET returns DbSet <entity type> provides CRUD
      var author = await _context.Set<Author>().FindAsync(id);
      if (author != null)
      {
        _context.Authors?.Remove(author);
        await _context.SaveChangesAsync();
      }


    }

    //after this we do filtering
    public async Task<IEnumerable<AuthorDTO>> GetAll()
    {
      var authors = await _context.Authors!
      .Include(a => a.Books)
      .ToListAsync();

      return authors.Select(a => new AuthorDTO
      {
        Id = a.Id,
        Name = a.Name,
        Books = a.Books!.Select(b => new BookDTO
        {
          Name = b.Name
        }).ToList()
      });

    }
    //Get by id
    public async Task<AuthorDTO> GetById(int id)
    {
      var author = await _context.Authors!
      .Include(a => a.Books)
      .SingleOrDefaultAsync(a => a.Id == id);

      if (author == null)
      {
        return null!;
      }
      var authorDTO = new AuthorDTO
      {
        Id = author.Id,
        Name = author.Name,
        Books = author.Books?.Select(b => new BookDTO
        {
          Id = b.Id,
          Name = b.Name,
          AuthorId = b.AuthorId,
        }).ToList()
      };
      return authorDTO;
    }

    //update
    public async Task<AuthorDTO> Update(int id, AuthorDTO authorDTO)
    {
      var author = await _context.Authors!.FindAsync(id);

      if (author == null)
      {
        return null!;
      }

      //update author that we found with new values
      author.Name = authorDTO.Name;

      // save changes
      await _context.SaveChangesAsync();

      //return new updated data
      return new AuthorDTO
      {
        Id = author.Id,
        Name = author.Name,

      };
    }


  }
}