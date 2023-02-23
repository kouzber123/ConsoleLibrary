namespace bookLibary.Data.DTOs
{
  public class AuthorDTO
  {
    public int Id { get; set; }
    public string? Name { get; set; }

    public virtual ICollection<BookDTO>? Books { get; set; }
  }
}