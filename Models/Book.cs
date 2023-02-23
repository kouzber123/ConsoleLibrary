namespace bookLibary.Models
{
  public class Book
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? AuthorName { get; set; }
    //FOR author
    public int AuthorId { get; set; }
    public virtual Author? Author { get; set; }
  }
}