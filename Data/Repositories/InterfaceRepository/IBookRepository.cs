using bookLibary.Data.DTOs;
using bookLibary.Models;

namespace bookLibary.Data.Repositories.InterfaceRepository
{
  public interface IBookRepository
  {
    Task<IEnumerable<BookDTO>> GetAll();
    Task<BookDTO> GetById(int id);
    Task<IEnumerable<BookDTO>> GetByAuthorId(int authorId);

    Task<BookDTO> Update(int id, BookDTO bookDTO);
    Task Delete(int id);

    Task Add(Book book);
  }
}