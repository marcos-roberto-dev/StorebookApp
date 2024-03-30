using Microsoft.AspNetCore.Mvc;

using StorebookApp.Model;
using StorebookApp.Controller;

namespace MyFirstApi.Controllers;

class RequestBookIdJson
{
    public string Id { get; set; } = "0asd4a-example-54a64sd";
}


public class BookController : StorebookApiBaseController
{
    private static List<Book> books = new List<Book>();
    [HttpPost]
    [ProducesResponseType(typeof(Dictionary<string, string>), StatusCodes.Status200OK)]
    public IActionResult CreateBook([FromBody] Book body)
    {
        var book = new Book
        {
            Title = body.Title,
            Author = body.Author,
            Genre = body.Genre,
            Price = body.Price,
            Stock = body.Stock
        };

        books.Add(book);
    
        return Created("api/book", new { id = book.Id });
    }
   
    [HttpGet]
    [ProducesResponseType(typeof(Book[]), StatusCodes.Status200OK)]
    public IActionResult GetBooks()
    {
        return Ok(books);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateBook([FromRoute] string id, [FromBody] Book body)

    {
        var bookSelected = books.FirstOrDefault(book => book.Id == id);

        if (bookSelected == null)
        {
            return NotFound();
        }

        bookSelected.Title = body.Title ?? bookSelected.Title;
        bookSelected.Author = body.Author ?? bookSelected.Author;
        bookSelected.Genre = body.Genre ?? bookSelected.Genre;
        bookSelected.Price = body.Price < 0 ? body.Price : bookSelected.Price;
        bookSelected.Stock = body.Stock < 0 ? body.Stock : bookSelected.Stock;

        return Ok(bookSelected);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteBook([FromRoute] string id)
    {
        var bookSelected = books.FirstOrDefault(book => book.Id == id);

        if (bookSelected == null)
        {
            return NotFound();
        }

        books.Remove(bookSelected);

        return NoContent();
    }  

}
