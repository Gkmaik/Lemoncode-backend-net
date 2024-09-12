using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Dtos.Queries.Books;

public class BookCountDto
{

    public int Id { get; set; }

    //public required string FirstName { get; set; }

    //public required string LastName { get; set; }

    public int BookCount { get; set; }

}