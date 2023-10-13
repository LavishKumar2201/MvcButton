using Microsoft.EntityFrameworkCore;
using MvcButton.Models;

namespace MvcButton.Data
{
    public class MvcButtonContext : DbContext
    {
        public MvcButtonContext(DbContextOptions<MvcButtonContext> options)
            : base(options)
        {
        }

        public DbSet<Button> Button { get; set; }
    }
}