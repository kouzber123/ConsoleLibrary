using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bookLibary.Models
{
  public class Book
  {
    public int Id { get; set; }
    public string? Name { get; set; }

    //FOR author
    public int AuthorId { get; set; }
    public virtual Author? Author { get; set; }
  }
}