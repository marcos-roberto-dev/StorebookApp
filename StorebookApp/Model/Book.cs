namespace StorebookApp.Model;

public enum Genre
{
    Fiction,
    NonFiction,
    Mystery,
    Romance,
    Horror,
    Thriller,

    Fantasy,
    Other
}

public class Book
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Genre[] Genre { get; set; } = [];
    public double Price { get; set; } = 0;
    public int Stock { get; set; } = 0;
}
