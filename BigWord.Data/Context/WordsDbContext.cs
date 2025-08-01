using Microsoft.EntityFrameworkCore;
using BigWord.Data.Models;

namespace BigWord.Data.Context
{
    public class WordsDbContext : DbContext
    {
        public WordsDbContext(DbContextOptions<WordsDbContext> options) : base(options) { }

        public DbSet<Word> Words { get; set; }

    }
}
