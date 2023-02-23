using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookLibary.Data.DTOs
{
  public class BookDTO
  {
    public int Id { get; set; }
    public string? Name { get; set; }

    public virtual int AuthorId { get; set; }

  }
}