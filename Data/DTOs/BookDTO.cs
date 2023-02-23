namespace bookLibary.Data.DTOs
{
  public class BookDTO
  {
    public int Id { get; set; }
    public string? Name { get; set; }

    public string? AuthorName { get; set; }
    public virtual int AuthorId { get; set; }

  }
}