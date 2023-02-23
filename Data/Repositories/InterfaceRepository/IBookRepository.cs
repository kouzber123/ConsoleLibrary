using bookLibary.Data.DTOs;
using bookLibary.Models;

namespace bookLibary.Data.Repositories.InterfaceRepository
{
  public interface IBookRepository
  {
    Task<IEnumerable<BookDTO>> GetAll();
    Task<BookDTO> GetById(int id);
    Task<IEnumerable<BookDTO>> GetByAuthorId(int authorId);

    Task<BookDTO> Update(Book book);
    Task<Book> Delete(int id);

    Task Add(Book book);
  }
}