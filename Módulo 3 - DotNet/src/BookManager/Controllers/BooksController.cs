using BookManager.Application.Abstractions.Queries;
using BookManager.Application.Abstractions.Services;
using BookManager.Application.Dtos.Commands.Books;
using BookManager.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{

    private readonly IBookService _bookService;
    private readonly IBookQueriesService _bookQueriesService;


    public BooksController(IBookService bookService, IBookQueriesService bookQueriesService)
    {
        _bookService = bookService;
        _bookQueriesService = bookQueriesService;

    }

    [HttpGet]
    public async Task<IActionResult> GetBooks(
        [FromQuery, Range(1, int.MaxValue, ErrorMessage = "The page number must be greater than 1.")] int page = 1,
        [FromQuery, Range(1, int.MaxValue, ErrorMessage = "The page size must be greater than 1.")] int pageSize = 10)
    {
        return Ok(await _bookQueriesService.GetBooks());
    }


    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetBook([FromRoute] int bookId)
    {
        try
        {
            return Ok(await _bookQueriesService.GetBookById(bookId));
        }
        catch (Exception ex)
        {
            return this.Problem(ex);
        }
    }    

    [HttpPost]
    public async Task<IActionResult> AddBook(BookDto book)
    {
        var operationInfo = await _bookService.AddBook(book);
        if (!operationInfo.ValidationResult.IsValid)
        {
            operationInfo.ValidationResult.AddToModelState(this.ModelState);
            return ValidationProblem();
        }

        book.Id = operationInfo.BookId!.Value;
        return Created($"/api/books/{book.Id}", book);
    }

    [HttpPut]
    public async Task<IActionResult> EditBook(BookDto book)
    {
        try
        {
            var validationResult = await _bookService.EditBook(book);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return ValidationProblem();
            }

            return Ok(book);
        }
        catch (Exception ex)
        {
            return this.Problem(ex);
        }
    }
}
