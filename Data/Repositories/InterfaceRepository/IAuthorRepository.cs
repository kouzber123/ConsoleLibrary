using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    Task<AuthorDTO> GetById(int id);

    Task<AuthorDTO> Update(Author author);
    Task Delete(int id);

    Task Add(Author author);


  }
}