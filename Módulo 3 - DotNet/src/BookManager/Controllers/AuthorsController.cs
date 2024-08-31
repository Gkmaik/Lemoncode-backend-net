using BookManager.Extensions;
using BookManager.Application.Abstractions.Services;
using BookManager.DataAccess;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using CommandDtos = BookManager.Application.Dtos.Commands.Authors;
using BookManager.Application.Abstractions.Queries;
using BookManager.Application.Dtos.Commands.Authors;

namespace BookManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{

    private readonly IAuthorService _authorService;


    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthor(AuthorDto author)
    {
        var operationInfo = await _authorService.AddAuthor(author);
        if (!operationInfo.ValidationResult.IsValid)
        {
            operationInfo.ValidationResult.AddToModelState(this.ModelState);
            return ValidationProblem();
        }

        author.Id = operationInfo.AuthorId!.Value;
        return Created($"/api/books/{author.Id}", author);
    }
}
