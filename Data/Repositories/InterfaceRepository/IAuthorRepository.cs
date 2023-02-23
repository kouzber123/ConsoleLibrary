using bookLibary.Data.DTOs;
using bookLibary.Models;

namespace bookLibary.Data.Repositories.InterfaceRepository
{
  public interface IAuthorRepository
  {
    //crud
    //get all
    Task<IEnumerable<AuthorDTO>> GetAll();
    //get by id 
    Task <AuthorDTO> GetById(int id);
    Task<AuthorDTO> Update(int id, AuthorDTO authorDTO);
    Task Delete(int id);
    Task Add(Author author);
  }
}