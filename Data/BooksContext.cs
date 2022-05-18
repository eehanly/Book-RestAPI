#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

    public class BooksContext : DbContext
    {
        public BooksContext (DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
