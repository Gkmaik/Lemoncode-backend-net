using BookManager.DataAccess;
using BookManager.Models;
using Microsoft.EntityFrameworkCore;

using var context = new LibraryContext();
context.SaveChanges();
