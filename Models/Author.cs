using System.ComponentModel;

namespace bookLibary.Models
{
  public class Author
  {
    public int Id { get; set; }
    public string? Name { get; set; }

    // public virtual AuthorProfile? Profile  {get; set;}
    public virtual ICollection<Book>? Books { get; set; }


  }
}