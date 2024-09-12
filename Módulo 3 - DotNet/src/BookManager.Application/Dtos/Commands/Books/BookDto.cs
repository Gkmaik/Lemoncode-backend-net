using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Dtos.Commands.Books;

public class BookDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The name of the title is required.")]
    [StringLength(100, ErrorMessage = "The name must contains 100 characters maximum.")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Publish date format must be MM/dd/yyyy.")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime PublishedOn { get; set; }

    [Required(ErrorMessage = "The description is required.")]
    [StringLength(1000, ErrorMessage = "The description must contains 1000 characters maximum.")]
    public string? Description { get; set; }
}
