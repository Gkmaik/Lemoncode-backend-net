using BookManager.Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers;

public class BooksController : ControllerBase
{

    private readonly IAuthorService _bookService;

    public BooksController(IAuthorService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(CommandDtos.BookDto book)
    {
        var operationInfo = await _bookService.AddAuthor(book);
        if (!operationInfo.ValidationResult.IsValid)
        {
            operationInfo.ValidationResult.AddToModelState(this.ModelState);
            return ValidationProblem();
        }

        book.Id = operationInfo.BookId!.Value;
        return Created($"/api/books/{book.Id}", book);
    }
}
